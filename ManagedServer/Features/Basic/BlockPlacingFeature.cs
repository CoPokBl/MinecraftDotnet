using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Inventories;
using ManagedServer.Physics;
using ManagedServer.Placement;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Placing a block by right clicking one, a port of <c>BlockItem.place</c>.
/// <p/>
/// The order of the checks is vanilla's and is load bearing, since each step can see what the one
/// before it did to the world. What state the block ends up in is not decided here at all: that is
/// <see cref="ManagedMinecraftServer.BlockPlacementRules"/>, so that anything else placing a block
/// the way a player does reaches the same answer.
/// </summary>
[CallsEvent(typeof(PlayerPlaceBlockEvent))]
public class BlockPlacingFeature : ScopedFeature {
    /// <summary><c>BlockItem.placeBlock</c>'s update flags, vanilla's literal 11.</summary>
    private const int PlaceFlags = BlockUpdateFlags.NeighborUpdates | BlockUpdateFlags.Clients
                                   | BlockUpdateFlags.Immediate;

    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemOnPacket packet) {
                return;
            }

            CheckBlockPlace(e.Player, packet);
        });
    }

    private void CheckBlockPlace(Player player, ServerBoundUseItemOnPacket use) {
        // TODO: Only allow whitelisted items in adventure

        if (player.GameMode == GameMode.Spectator) {
            return;
        }

        World world = player.World!;
        MinecraftPacket ack = new ClientBoundAcknowledgeBlockChangePacket { SequenceId = use.Sequence };

        // Vanilla acts on the hand the packet named. Guessing at the main hand first places the wrong
        // block whenever both hands hold one.
        Hand hand = use.ActiveHand;
        ItemStack usedItem = player.GetItemInHand(hand);
        if (usedItem.Type.CorrespondingBlock is not { } blockId) {
            return;
        }

        IBlock block = player.Server.Registry.Blocks[blockId];
        BlockPlacementRules rules = player.Server.BlockPlacementRules;

        // The packet's cursor is a fraction of the clicked block; vanilla's hit location is a world
        // point. Every rule that reads it subtracts a block position back off, so the two have to be
        // in the same space or a stair placed at a negative coordinate comes out the wrong half.
        Vec3<double> clickLocation = new(
            use.Position.X + use.CursorPosition.X,
            use.Position.Y + use.CursorPosition.Y,
            use.Position.Z + use.CursorPosition.Z);

        PlayerPlaceContext context = new(world, player, hand, usedItem, use.Position, use.Face,
            clickLocation, use.InsideBlock, rules);

        // Whether anything at all can go there, before asking the block what it would look like.
        if (!context.CanPlace() || !world.IsInBounds(context.PlacePos)) {
            Reject(player, context.PlacePos, ack);
            return;
        }

        player.Inventory.SendSlotUpdate(player.ActiveHotbarSlot);

        IBlockPlacementRule? rule = rules.For(block, world);
        IBlock? placed = rule is null ? block : rule.GetStateForPlacement(block, context);
        if (placed is null) {
            // The block refused: a door with no room above it, a torch with nothing to hang on.
            Reject(player, context.PlacePos, ack);
            return;
        }

        // canPlace: it has to be able to survive there, and it must not be inside anything.
        if (rule is not null && !rule.CanSurvive(placed, world, context.PlacePos)) {
            Reject(player, context.PlacePos, ack);
            return;
        }

        if (!IsUnobstructed(world, placed, context.PlacePos)) {
            Reject(player, context.PlacePos, ack);
            return;
        }

        PlayerPlaceBlockEvent placeEvent = new() {
            Player = player,
            Block = placed,
            Position = context.PlacePos,
            World = world,
            UsedItem = usedItem,
            Hand = hand
        };
        Scope.Events.CallEvent(placeEvent);

        if (placeEvent.Cancelled) {
            Reject(player, context.PlacePos, ack);
            return;
        }

        // BlockItem.placeBlock's flags, 11: notify neighbours, tell the clients, re-render at once.
        // UPDATE_KNOWN_SHAPE is deliberately absent, which is what makes the fences either side of a
        // new one connect to it.
        world.SetBlock(placeEvent.Position, placeEvent.Block, flags: PlaceFlags);
        player.SendPacket(ack);

        // setPlacedBy, which is where a door writes its top half, so it runs once the bottom exists.
        // Vanilla only reaches it when the block survived its own placement, so this re-reads rather
        // than trusting what it just wrote.
        if (rule is not null && IBlock.SimilarTo(world.GetBlock(placeEvent.Position), placeEvent.Block)) {
            rule.OnPlaced(world.GetBlock(placeEvent.Position), context);
        }

        if (placeEvent.ConsumeItem) {
            player.SetItemInHand(hand, usedItem.SubtractCount(1));
        }

        // prevent ghost items by sending the item update
        player.Inventory.SendSlotUpdate(hand == Hand.MainHand
            ? PlayerInventory.HotbarSlot1 + player.ActiveHotbarSlot
            : PlayerInventory.OffhandSlot);
    }

    /// <summary>
    /// Tells the client the placement it already drew did not happen, and acknowledges the sequence
    /// so it stops holding the prediction open.
    /// </summary>
    private static void Reject(Player player, Vec3<int> pos, MinecraftPacket ack) {
        if (player.World!.IsInBounds(pos)) {
            player.World!.SendBlockUpdate(pos, player);
        }

        player.SendPacket(ack);
    }

    /// <summary>
    /// <c>Level.isUnobstructed</c>: whether the state's own collision shape, moved to where it is
    /// going, is clear of everything that blocks building.
    /// <p/>
    /// Vanilla tests the block's collision shape rather than a player sized box, which is the whole
    /// difference between being able to place a slab under your feet and not. It also skips entities
    /// whose <c>blocksBuilding</c> is false, which is not modelled here; taking players and living
    /// entities and ignoring the rest gets the same answer, since the things that flag false are
    /// items, arrows and experience orbs.
    /// </summary>
    private static bool IsUnobstructed(World world, IBlock block, Vec3<int> pos) {
        Box[] boxes = BlockPhysicsData.CollisionBoxesOf(block.CollisionShape);
        if (boxes.Length == 0) {
            return true;
        }

        Vec3<double> offset = block.ShapeOffset(pos);
        foreach (Box local in boxes) {
            Box box = local.Translate(pos.X + offset.X, pos.Y + offset.Y, pos.Z + offset.Z);
            if (world.Entities.GetEntitiesInBox(box, e => e is LivingEntity).Length > 0) {
                return false;
            }
        }

        return true;
    }
}
