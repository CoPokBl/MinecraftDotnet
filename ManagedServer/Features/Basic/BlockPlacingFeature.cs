using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Interaction;
using ManagedServer.Inventories;
using Minecraft.Physics;
using ManagedServer.Placement;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Placing a block by right clicking one, a port of <c>BlockItem.place</c>.
/// <p/>
/// This is the <b>item</b> half of a right click, <c>ItemStack.useOn</c>, so it listens to
/// <see cref="PlayerUseItemOnBlockEvent"/> rather than to the packet. Core only fires that once the
/// block's own interaction has passed on the click (see <see cref="BlockInteraction"/>), which is
/// what stops a block being placed into a chest that is opening. Listening to the raw packet instead
/// would put this in a race with every interaction handler, decided by registration order.
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
        AddEventHandler<PlayerUseItemOnBlockEvent>(e => {
            if (e.Result.ConsumesAction) {
                return;
            }

            e.Result = Place(e);
        });
    }

    private InteractionResult Place(PlayerUseItemOnBlockEvent e) {
        // TODO: Only allow whitelisted items in adventure
        // Spectator is not checked here: BlockInteraction.UseItemOn returns before the item stage
        // for one, exactly as vanilla's game mode does, so duplicating it would be a second copy of
        // a rule that already has a home.

        Player player = e.Player;
        World world = e.World;

        ItemStack usedItem = e.Item;
        if (usedItem.Type.CorrespondingBlock is not { } blockId) {
            return InteractionResult.Pass;
        }

        IBlock block = player.Server.Registry.Blocks[blockId];
        BlockPlacementRules rules = player.Server.BlockPlacementRules;

        BlockPlaceContext context = new(world, new Placer(player.Yaw.DegreesF, player.Pitch.DegreesF, player.IsSecondaryUseActive),
            e.Hand, usedItem, e.Position, e.Face, e.ClickLocation, e.InsideBlock);

        // Whether anything at all can go there, before asking the block what it would look like.
        // Every refusal below is BlockItem.place returning FAIL. Nothing needs to be sent to put the
        // client's prediction back: BlockInteraction resends both the clicked block and the one
        // across its face on every outcome, which covers both values PlacePos can take.
        if (!context.CanPlace() || !world.IsInBounds(context.PlacePos)) {
            return InteractionResult.Fail;
        }

        player.Inventory.SendSlotUpdate(player.ActiveHotbarSlot);

        IBlockPlacementRule? rule = rules.For(block, world);
        IBlock? placed = rule is null ? block : rule.GetStateForPlacement(block, context);
        if (placed is null) {
            // The block refused: a door with no room above it, a torch with nothing to hang on.
            return InteractionResult.Fail;
        }

        // canPlace: it has to be able to survive there, and it must not be inside anything.
        if (rule is not null && !rule.CanSurvive(placed, world, context.PlacePos)) {
            return InteractionResult.Fail;
        }

        if (!IsUnobstructed(world, placed, context.PlacePos)) {
            return InteractionResult.Fail;
        }

        PlayerPlaceBlockEvent placeEvent = new() {
            Player = player,
            Block = placed,
            Position = context.PlacePos,
            World = world,
            UsedItem = usedItem,
            Hand = e.Hand,
            // Vanilla does this in ServerPlayerGameMode.useItemOn rather than in the item: it saves
            // the stack's count around the call to useOn when hasInfiniteMaterials() and puts it
            // back afterwards. The sequencer cannot do that here, because the item write belongs to
            // this feature, so the branch lives at the consumption site instead of being dropped.
            ConsumeItem = player.GameMode != GameMode.Creative
        };
        Scope.Events.CallEvent(placeEvent);

        if (placeEvent.Cancelled) {
            return InteractionResult.Fail;
        }

        // BlockItem.placeBlock's flags, 11: notify neighbours, tell the clients, re-render at once.
        // UPDATE_KNOWN_SHAPE is deliberately absent, which is what makes the fences either side of a
        // new one connect to it.
        world.SetBlock(placeEvent.Position, placeEvent.Block, flags: PlaceFlags);

        // setPlacedBy, which is where a door writes its top half, so it runs once the bottom exists.
        // Vanilla only reaches it when the block survived its own placement, so this re-reads rather
        // than trusting what it just wrote.
        if (rule is not null && IBlock.SimilarTo(world.GetBlock(placeEvent.Position), placeEvent.Block)) {
            rule.OnPlaced(world.GetBlock(placeEvent.Position), context);
        }

        if (placeEvent.ConsumeItem) {
            player.SetItemInHand(e.Hand, usedItem.SubtractCount(1));
        }

        // prevent ghost items by sending the item update
        player.Inventory.SendSlotUpdate(e.Hand == Hand.MainHand
            ? PlayerInventory.HotbarSlot1 + player.ActiveHotbarSlot
            : PlayerInventory.OffhandSlot);

        return InteractionResult.Success;
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
