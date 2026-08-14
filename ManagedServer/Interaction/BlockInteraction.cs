using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Interaction;

/// <summary>
/// A port of <c>ServerGamePacketListenerImpl.handleUseItemOn</c> and
/// <c>ServerPlayerGameMode.useItemOn</c>: what happens when a player right clicks a block.
/// <p/>
/// This is <b>core</b> rather than a feature, on the same rule as <c>EntityPhysics.CheckFallDamage</c>
/// and <c>LivingEntity.Damage</c>. Every step of it starts with nothing registered, so a bare server
/// still does nothing at all with a right click, but the <em>order</em> of the steps is not something
/// a consumer can get wrong. That order is the entire point:
/// <list type="number">
/// <item>the block's own interaction, <see cref="PlayerBlockInteractEvent"/>, and</item>
/// <item>only if that did not consume the click, the held item, <see cref="PlayerUseItemOnBlockEvent"/>,
/// which is where block placement lives.</item>
/// </list>
/// Before this existed both stages were listeners on the same raw packet event, so opening a chest
/// and placing a block both happened on one click, decided by registration order. Two events with
/// core sequencing them makes that structural instead of a race.
/// <p/>
/// The split into two methods is vanilla's and is load bearing: the acknowledgement and the block
/// resends belong to the packet listener and happen whatever the outcome, while the sequence belongs
/// to the game mode and returns a result.
/// </summary>
public static class BlockInteraction {
    /// <summary>
    /// <c>ServerGamePacketListenerImpl.handleUseItemOn</c>. Runs the sequence, then tells the client
    /// what really happened.
    /// </summary>
    public static void HandleUseItemOn(Player player, ServerBoundUseItemOnPacket use) {
        if (player.World is not { } world) {
            return;
        }

        BlockHit hit = HitOf(use);
        InteractionResult result = UseItemOn(player, world, player.GetItemInHand(use.ActiveHand),
            use.ActiveHand, hit);

        if (result.Swing == SwingSource.Server) {
            player.SwingArm(use.ActiveHand);
        }

        // Vanilla's last two statements, and they are unconditional: the clicked block and the one
        // across the face it was clicked on both go back to the player on every outcome, success
        // included. This, not the acknowledgement, is what un-ghosts a block the client predicted and
        // the server did not place, and it covers both positions a placement could have landed on.
        SendBlockUpdate(world, player, hit.Position);
        SendBlockUpdate(world, player, hit.Position.GetBlockTowards(hit.Face));

        // Divergence: vanilla acks first, at the top of the listener. But ackBlockChangesUpTo only
        // records the sequence, and the packet is flushed from ServerPlayerGameMode.tick, i.e. after
        // the tick's writes have gone out. There is no per tick ack flush here, so sending it last
        // reproduces the effect rather than the statement order. Acking before the block updates
        // would release the client's prediction before the correction for it exists.
        player.SendPacket(new ClientBoundAcknowledgeBlockChangePacket { SequenceId = use.Sequence });
    }

    /// <summary>
    /// <c>ServerPlayerGameMode.useItemOn</c>: the block first, then the item.
    /// </summary>
    public static InteractionResult UseItemOn(Player player, World world, ItemStack stack, Hand hand,
        BlockHit hit) {
        // Vanilla's first statement is a feature flag check on the block, which is not modelled.

        if (player.GameMode == GameMode.Spectator) {
            // Vanilla opens the block's menu read only here, through BlockState.getMenuProvider. That
            // needs block entity behaviour, which does not exist: BlockEntity is the wire record sent
            // with chunk data and carries no contents and no menu. So a spectator interacts with
            // nothing, which is the same answer vanilla gives for a block with no menu.
            return InteractionResult.Pass;
        }

        // isSecondaryUseActive() && (main hand or offhand holds something). Three things here are
        // easy to get wrong and each changes behaviour:
        //  - it reads BOTH hands, never the hand the packet named, so sneaking with an empty main
        //    hand and a block in the offhand skips the block for the main hand's click too;
        //  - it is an AND, so crouching with both hands empty does NOT skip, and a crouching bare
        //    handed player still opens a chest;
        //  - this is the only thing that lets a player place a block against an interactive one.
        bool handsNotEmpty = !player.GetItemInHand(Hand.MainHand).IsAir()
                             || !player.GetItemInHand(Hand.OffHand).IsAir();
        bool skipBlock = player.IsSecondaryUseActive && handsNotEmpty;

        if (!skipBlock) {
            InteractionResult onBlock = Interact(player, world, hit, hand, stack, InteractStage.UseItemOn);
            if (onBlock.ConsumesAction) {
                return onBlock;
            }

            // The retry, and it is gated on the main hand. That is why an offhand click carrying a
            // block places it rather than opening the chest it hit: ChestBlock, DoorBlock and almost
            // everything else interactive override useWithoutItem, so the offhand never reaches them.
            // It looks like a bug and it is vanilla.
            if (onBlock.Kind == InteractionResultKind.TryEmptyHand && hand == Hand.MainHand) {
                InteractionResult bare = Interact(player, world, hit, hand, stack, InteractStage.UseWithoutItem);
                if (bare.ConsumesAction) {
                    return bare;
                }
            }
        }

        // Vanilla is `stack.isEmpty() || cooldowns.isOnCooldown(stack)`, and note where it sits: the
        // cooldown is checked HERE, not at the top of the method, so an item on cooldown still opens
        // a chest. The cooldown half is missing because ItemCooldowns is ItemCooldownsFeature, which
        // keeps its map on a player tag, and core cannot ask a feature. Wiring it up wants that map
        // moved into core first; until then an item on cooldown can still be placed.
        if (stack.IsAir()) {
            return InteractionResult.Pass;
        }

        return UseItem(player, world, hit, hand, stack);
    }

    /// <summary>
    /// One of <c>BlockState.useItemOn</c> / <c>useWithoutItem</c>: ask the rule, then let a listener
    /// overrule it.
    /// </summary>
    private static InteractionResult Interact(Player player, World world, BlockHit hit, Hand hand,
        ItemStack stack, InteractStage stage) {
        IBlock block = world.GetBlock(hit.Position);
        IBlockInteractionRule? rule = world.Server.BlockInteractionRules.For(block, world);

        // With no rule the seed is the vanilla method's own default body, which differs per stage:
        // useItemOn asks for the retry, useWithoutItem passes.
        InteractionResult seed = stage switch {
            InteractStage.UseItemOn => rule?.UseItemOn(block, world, hit.Position, player, hand, stack, hit)
                                       ?? InteractionResult.TryWithEmptyHand,
            _ => rule?.UseWithoutItem(block, world, hit.Position, player, hit)
                 ?? InteractionResult.Pass
        };

        PlayerBlockInteractEvent e = new() {
            Player = player,
            World = world,
            Stage = stage,
            Position = hit.Position,
            Block = block,
            Face = hit.Face,
            ClickLocation = hit.Location,
            InsideBlock = hit.Inside,
            Hand = hand,
            Item = stack,
            Result = seed
        };
        player.Events.CallEvent(e);
        return e.Result;
    }

    /// <summary><c>ItemStack.useOn</c>, where <c>BlockItem.place</c> lives.</summary>
    private static InteractionResult UseItem(Player player, World world, BlockHit hit, Hand hand,
        ItemStack stack) {
        // Vanilla saves and restores the stack's count around this call when the player has infinite
        // materials, which is not possible here because the item write belongs to the feature that
        // placed the block. BlockPlacingFeature does the creative check at its own consumption site
        // instead; the divergence is written up there.
        PlayerUseItemOnBlockEvent e = new() {
            Player = player,
            World = world,
            Position = hit.Position,
            Block = world.GetBlock(hit.Position),
            Face = hit.Face,
            ClickLocation = hit.Location,
            InsideBlock = hit.Inside,
            Hand = hand,
            Item = stack,
            Result = InteractionResult.Pass
        };
        player.Events.CallEvent(e);
        return e.Result;
    }

    /// <summary>
    /// The packet's hit as vanilla's <c>BlockHitResult</c>.
    /// <p/>
    /// The cursor on the wire is a fraction of the clicked block and vanilla's hit location is a
    /// world point. Every rule that reads it subtracts a block position back off, so the two have to
    /// be in the same space or a stair placed at a negative coordinate comes out the wrong half.
    /// </summary>
    public static BlockHit HitOf(ServerBoundUseItemOnPacket use) {
        return new BlockHit(
            use.Position,
            use.Face,
            new Vec3<double>(
                use.Position.X + use.CursorPosition.X,
                use.Position.Y + use.CursorPosition.Y,
                use.Position.Z + use.CursorPosition.Z),
            use.InsideBlock);
    }

    private static void SendBlockUpdate(World world, Player player, Vec3<int> pos) {
        if (world.IsInBounds(pos)) {
            world.SendBlockUpdate(pos, player);
        }
    }
}
