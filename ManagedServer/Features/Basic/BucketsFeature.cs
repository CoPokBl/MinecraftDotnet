using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Fluids;
using ManagedServer.Inventories;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Data.Sounds;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using NBT.Tags;
using Entry = ManagedServer.Fluids.FluidBlockData.Entry;
using Minecraft.Fluids;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Water and lava buckets place their fluid and an empty bucket picks a source back up, a port of
/// vanilla's <c>BucketItem</c>.
/// <p/>
/// Needs a <see cref="LiquidsFeature"/> registered: a placed fluid is only interesting because that
/// feature makes it flow, and a fluid taken away has to go through the same simulation so the rest of
/// it starts moving again.
/// <p/>
/// Buckets act on <c>use_item</c>, not on <c>use_item_on</c>. A client aiming at a block sends both,
/// and vanilla's bucket does nothing for the first: it raycasts again in <c>use</c>, because an empty
/// bucket has to see fluids and the crosshair does not. Handling the click packet instead would place
/// the fluid and then, since the hand now holds an empty bucket, pick it straight back up.
/// </summary>
[CallsEvent(typeof(PlayerPlaceBlockEvent))]
public class BucketsFeature : ScopedFeature {
    public override void Register() {
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundUseItemPacket use) {
                return;
            }

            Handle(e.Player, use);
        });
    }

    private void Handle(Player player, ServerBoundUseItemPacket use) {
        if (player.GameMode == GameMode.Spectator) {
            return;
        }

        ItemStack held = player.GetItemInHand(use.UsedHand);
        FluidKind content = ContentOf(held.Type);
        bool empty = held.Type.Identifier.Equals(Item.Bucket.Identifier);
        if (content == FluidKind.Empty && !empty) {
            return;
        }

        World world = player.World!;
        FluidSimulation? fluids = SimulationOf(world);
        if (fluids == null) {
            return;
        }

        player.SendPacket(new ClientBoundAcknowledgeBlockChangePacket { SequenceId = use.Sequence });

        FluidRaycast.Hit? hit = FluidRaycast.Look(fluids, player, stopAtFluidSources: empty);
        if (hit == null) {
            return;
        }

        if (empty) {
            Pickup(player, fluids, use.UsedHand, hit.Value.Pos);
        }
        else {
            Place(player, fluids, use.UsedHand, content, hit.Value);
        }
    }

    #region placing

    private void Place(Player player, FluidSimulation fluids, Hand hand, FluidKind content, FluidRaycast.Hit hit) {
        Entry clicked = fluids.GetState(hit.Pos);

        // BucketItem.use: a water bucket aimed at something waterloggable fills that block rather than
        // the one in front of it.
        Vec3<int> fallback = FluidDirections.Relative(hit.Pos, hit.Face);
        Vec3<int> placePos = clicked.Container && content == FluidKind.Water ? hit.Pos : fallback;

        if (!EmptyContents(player, fluids, placePos, content, fallback)) {
            return;
        }

        PlaySound(player, placePos, content == FluidKind.Lava ? SoundType.BucketEmptyLava : SoundType.BucketEmpty);

        if (player.GameMode != GameMode.Creative) {
            player.SetItemInHand(hand, new ItemStack(Item.Bucket, 1));
        }

        SendSlotUpdate(player, hand);
    }

    /// <summary><c>BucketItem.emptyContents</c>. Returns whether the fluid was placed.</summary>
    /// <param name="fallbackPos">
    /// The block in front of the one that was aimed at, or null on the retry against it. Vanilla passes
    /// the hit result down and nulls it on the retry, and both of the things it reads it for turn on
    /// that: it is where the retry goes, and a crouching player only skips a position while it is there.
    /// So a crouching player still fills the block in front rather than nothing at all, and the retry
    /// against a position that is its own fallback (everything but a waterloggable block) is what places
    /// the fluid rather than a second identical refusal.
    /// </param>
    private bool EmptyContents(Player player, FluidSimulation fluids, Vec3<int> pos, FluidKind content, Vec3<int>? fallbackPos) {
        World world = fluids.World;
        if (!world.IsInBounds(new Vec3<double>(pos.X, pos.Y, pos.Z))) {
            return false;
        }

        Entry state = fluids.GetState(pos);

        // BlockState.canBeReplaced(Fluid).
        bool mayReplace = state.Block.Replaceable || !state.Solid;
        bool placeLiquid = mayReplace || (state.Container && content == FluidKind.Water);

        if (!state.Air && !(placeLiquid && (!player.Crouching || fallbackPos == null))) {
            // Aimed at something that will not take the fluid, so try the block in front of it.
            return fallbackPos != null && EmptyContents(player, fluids, fallbackPos.Value, content, null);
        }

        FluidState source = FluidState.SourceOf(content, false);
        bool waterlogs = state.Container && content == FluidKind.Water;

        PlayerPlaceBlockEvent placeEvent = new() {
            Player = player,
            // Waterlogging keeps the block that is there, so that is what a listener sees.
            Block = waterlogs ? state.Block : source.ToBlock(),
            Position = pos,
            World = world,
            UsedItem = player.HeldItem,
            Hand = Hand.MainHand
        };
        CallEvent(placeEvent);

        if (placeEvent.Cancelled) {
            world.SendBlockUpdate(pos, player);
            return false;
        }

        if (waterlogs) {
            fluids.PlaceLiquid(pos, state, source);
            return true;
        }

        fluids.SetBlock(pos, source.ToBlock());
        return true;
    }

    #endregion

    #region picking up

    private static void Pickup(Player player, FluidSimulation fluids, Hand hand, Vec3<int> pos) {
        Entry state = fluids.GetState(pos);
        FluidState fluid = state.Fluid;
        if (!fluid.Source) {
            return;
        }

        // LiquidBlock.pickupBlock only gives up a level 0 block; SimpleWaterloggedBlock.pickupBlock
        // takes the waterlogging off and leaves the block behind.
        if (state.Container) {
            fluids.SetBlock(pos, state.Block.WithState(new CompoundTag(("waterlogged", new StringTag("false")))));
        }
        else {
            fluids.SetBlock(pos, Block.Air);
        }

        if (player.GameMode != GameMode.Creative) {
            player.SetItemInHand(hand, new ItemStack(fluid.Kind == FluidKind.Lava ? Item.LavaBucket : Item.WaterBucket, 1));
        }

        SendSlotUpdate(player, hand);
        PlaySound(player, pos, fluid.Kind == FluidKind.Lava ? SoundType.BucketFillLava : SoundType.BucketFill);
    }

    #endregion

    private static FluidSimulation? SimulationOf(World world) {
        LiquidsFeature? liquids = world.Server.FeatureHandler.Features.OfType<LiquidsFeature>().FirstOrDefault();
        return liquids?.GetSimulation(world);
    }

    private static FluidKind ContentOf(IItem item) {
        if (item.Identifier.Equals(Item.WaterBucket.Identifier)) {
            return FluidKind.Water;
        }

        return item.Identifier.Equals(Item.LavaBucket.Identifier) ? FluidKind.Lava : FluidKind.Empty;
    }

    private static void SendSlotUpdate(Player player, Hand hand) {
        player.Inventory.SendSlotUpdate(hand == Hand.MainHand
            ? PlayerInventory.HotbarSlot1 + player.ActiveHotbarSlot
            : PlayerInventory.OffhandSlot);
    }

    /// <summary>
    /// Everyone but the player who swung the bucket, which is what vanilla's <c>Level.playSound</c> does
    /// with its first argument. Their client ran <c>BucketItem.use</c> as a prediction and played the
    /// sound itself, so sending it to them as well is what makes it play twice.
    /// </summary>
    private static void PlaySound(Player player, Vec3<int> pos, ISoundType sound) {
        MinecraftPacket packet = new ClientBoundSoundEffectPacket(sound, SoundCategory.Blocks,
            new Vec3<double>(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5), 1f, 1f, 0L);

        foreach (Player viewer in player.World!.GetViewersOf(pos)) {
            if (viewer != player) {
                viewer.SendPacket(packet);
            }
        }
    }
}
