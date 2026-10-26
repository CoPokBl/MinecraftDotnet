using System.Collections.Concurrent;
using ClientLib.Entities;
using ClientLib.Physics;
using ClientLib.Player;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Physics;
using Minecraft.Placement;
using Minecraft.Placement.Helpers;
using Minecraft.Placement.Rules;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT.Tags;

namespace ClientLib.Interaction;

/// <summary>
/// <c>BlockItem.useOn</c>, which vanilla's client runs inside <c>useItemOn</c>'s prediction, with the
/// <c>BlockItem</c> subclasses that change a step. Which subclass an item is is a constructor argument in
/// <c>Items.java</c> that the dump does not carry, so each is told from the block the item places.
/// </summary>
public sealed partial class MultiPlayerGameMode {
    /// <summary>
    /// <c>BlockItem.place</c>'s <c>level.playSound(player, ...)</c>: the block a block item put down, and
    /// the item, for the place sound a server plays to everyone else.
    /// </summary>
    public event Action<(int X, int Y, int Z), IBlock, ItemStack>? PlacedBlock;

    /// <summary><c>BlockItem.placeBlock</c>'s update flags, vanilla's literal 11.</summary>
    private const int PlaceFlags = BlockUpdateFlags.NeighborUpdates | BlockUpdateFlags.Clients | BlockUpdateFlags.Immediate;

    /// <summary><c>DoubleHighBlockItem</c>'s 27 for the cell above, and <c>BedItem</c>'s 26.</summary>
    private const int DoubleHighFlags = PlaceFlags | BlockUpdateFlags.KnownShape;
    private const int BedFlags = BlockUpdateFlags.Clients | BlockUpdateFlags.Immediate | BlockUpdateFlags.KnownShape;

    /// <summary>The <c>DoubleHighBlockItem</c>s that are not doors. The pitcher plant is a double plant placed by a plain <c>BlockItem</c>.</summary>
    private static readonly HashSet<Identifier> DoubleHighPlants = [
        Item.SmallDripleaf.Identifier, Item.Sunflower.Identifier, Item.Lilac.Identifier, Item.RoseBush.Identifier,
        Item.Peony.Identifier, Item.TallGrass.Identifier, Item.LargeFern.Identifier
    ];

    /// <summary>The wall blocks a <c>StandingAndWallBlockItem</c> is built with.</summary>
    private static readonly BlockClass[] WallBlockClasses = [
        BlockClass.WallTorchBlock, BlockClass.RedstoneWallTorchBlock, BlockClass.BaseCoralWallFanBlock, BlockClass.WallSignBlock,
        BlockClass.WallHangingSignBlock, BlockClass.WallBannerBlock, BlockClass.WallSkullBlock
    ];

    private static readonly ConcurrentDictionary<Identifier, IBlock?> WallBlocks = new();

    private static readonly Identifier WallHangingSigns = "minecraft:wall_hanging_signs";

    /// <summary><c>ArmorStand.CLIENT_FLAG_MARKER</c>.</summary>
    private const sbyte ArmorStandMarker = 16;

    /// <summary>
    /// <c>BlockItem.useOn</c>, after <c>ItemStack.useOn</c> has let the player build. Divergence: the block's
    /// <c>requiredFeatures</c> are not checked against the enabled set.
    /// </summary>
    private UseResult BlockItemUseOn(Hand hand, BlockHitResult hit, ItemStack held) {
        IBlock block = Level.Registry.Blocks[held.Type.CorrespondingBlock!.Value];
        // PlaceOnWaterBlockItem places through use, at the water the player looks at.
        if (BlockClasses.Is(block.Identifier, BlockClass.LilyPadBlock) || BlockClasses.Is(block.Identifier, BlockClass.FrogspawnBlock)) {
            return UseResult.Pass;
        }

        PredictingLevel level = new(Level, this, _tags);
        BlockPlaceContext context = new(level, new Placer(Player.YRot, Player.XRot, Player.KeyPresses.Shift), hand, held,
            new Vec3<int>(hit.X, hit.Y, hit.Z), hit.Face, new Vec3<double>(hit.Location.X, hit.Location.Y, hit.Location.Z), hit.Inside);
        UseResult result = Place(level, block, context);
        // SolidBucketItem.useOn: the bucket comes back empty.
        if (result == UseResult.Success && held.Type.Identifier == Item.PowderSnowBucket.Identifier && !Player.InstaBuild) {
            SetItemInHand(hand, new ItemStack(Item.Bucket, 1));
        }
        return result;
    }

    /// <summary><c>BlockItem.place</c>.</summary>
    private UseResult Place(PredictingLevel level, IBlock block, BlockPlaceContext placeContext) {
        if (!placeContext.CanPlace()) {
            return UseResult.Fail;
        }
        IBlockPlaceContext? context = UpdatePlacementContext(level, block, placeContext);
        if (context == null) {
            return UseResult.Fail;
        }
        IBlock? placementState = PlacementState(level, block, context);
        if (placementState == null || !PlaceBlock(level, block, context, placementState)) {
            return UseResult.Fail;
        }

        Vec3<int> pos = context.PlacePos;
        IBlock placedState = level.GetBlock(pos);
        if (placedState.Identifier == placementState.Identifier) {
            placedState = UpdateBlockStateFromTag(level, pos, context.ItemInHand, placedState);
            // updateCustomBlockEntityTag is server only. Divergence: updateBlockEntityComponents is not
            // ported, so a placed banner or head shows its item's components once the server sends them.
            level.PlacementRuleFor(placedState)?.OnPlaced(placedState, context);
        }

        PlacedBlock?.Invoke((pos.X, pos.Y, pos.Z), placedState, context.ItemInHand);
        if (!Player.InstaBuild) {
            ItemStack stack = context.ItemInHand;
            SetItemInHand(context.Hand, stack.Count > 1 ? stack.WithCount(stack.Count - 1) : ItemStack.Air);
        }
        return UseResult.Success;
    }

    private void SetItemInHand(Hand hand, ItemStack stack) =>
        _client.Inventory.SetInventorySlot(hand == Hand.MainHand ? _client.Inventory.SelectedSlot : PlayerInventory.OffhandIndex, stack);

    /// <summary><c>ScaffoldingBlockItem.updatePlacementContext</c>: a click on a scaffold builds onto the end of its run.</summary>
    private static IBlockPlaceContext? UpdatePlacementContext(PredictingLevel level, IBlock block, BlockPlaceContext context) {
        if (!BlockClasses.Is(block.Identifier, BlockClass.ScaffoldingBlock)) {
            return context;
        }
        Vec3<int> pos = context.PlacePos;
        if (level.GetBlock(pos).Identifier != block.Identifier) {
            return ScaffoldingPlacementRule.DistanceAt(block, level, pos) == 7 ? null : context;
        }

        BlockFace direction = context.IsSecondaryUseActive
            ? context.IsInside ? context.ClickedFace.Opposite() : context.ClickedFace
            : context.ClickedFace == BlockFace.PosY ? context.HorizontalDirection.ToFace() : BlockFace.PosY;
        int horizontalDistance = 0;
        Vec3<int> placementPos = pos.GetBlockTowards(direction);
        // The build limit stop is server only.
        while (horizontalDistance < 7) {
            if (level.GetBlock(placementPos).Identifier != block.Identifier) {
                return context.CanReplaceAt(placementPos) ? context.At(placementPos, direction) : null;
            }
            placementPos = placementPos.GetBlockTowards(direction);
            if (Directions.IsHorizontal(direction)) {
                horizontalDistance++;
            }
        }
        return null;
    }

    /// <summary><c>getPlacementState</c>, as the item's class has it.</summary>
    private IBlock? PlacementState(PredictingLevel level, IBlock block, IBlockPlaceContext context) {
        if (WallBlockOf(level, block) is { } wallBlock) {
            return StandingAndWallPlacementState(level, block, wallBlock, context);
        }
        // GameMasterBlockItem.
        if (IsGameMasterBlock(block) && !_client.CanUseGameMasterBlocks) {
            return null;
        }
        IBlock? state = StateForPlacement(level, block, context);
        return state != null && CanPlace(level, block, context, state) ? state : null;
    }

    private static IBlock? StateForPlacement(PredictingLevel level, IBlock block, IBlockPlaceContext context) =>
        level.PlacementRuleFor(block) is { } rule ? rule.GetStateForPlacement(block, context) : block;

    private static bool CanSurvive(PredictingLevel level, IBlock state, Vec3<int> pos) =>
        level.PlacementRuleFor(state)?.CanSurvive(state, level, pos) ?? true;

    /// <summary><c>BlockItem.canPlace</c>. <c>ScaffoldingBlockItem.mustSurvive</c> is false.</summary>
    private bool CanPlace(PredictingLevel level, IBlock block, IBlockPlaceContext context, IBlock state) =>
        (BlockClasses.Is(block.Identifier, BlockClass.ScaffoldingBlock) || CanSurvive(level, state, context.PlacePos))
        && IsUnobstructed(state, context.PlacePos, EntityCollisionContext.Placement(Player, Player.KeyPresses.Shift));

    /// <summary>The wall form of a <c>StandingAndWallBlockItem</c>'s block, the other block its item places.</summary>
    private static IBlock? WallBlockOf(PredictingLevel level, IBlock block) => WallBlocks.GetOrAdd(block.Identifier, _ =>
        block.Item == null ? null : level.Registry.Blocks.All.FirstOrDefault(other => other.Identifier != block.Identifier && other.Item == block.Item
            && WallBlockClasses.Any(type => BlockClasses.Is(other.Identifier, type))));

    /// <summary>
    /// <c>StandingAndWallBlockItem.getPlacementState</c>, with <c>HangingSignItem.canPlace</c>. The attachment
    /// direction is up for a hanging sign and down for the rest.
    /// </summary>
    private IBlock? StandingAndWallPlacementState(PredictingLevel level, IBlock block, IBlock wallBlock, IBlockPlaceContext context) {
        bool hanging = BlockClasses.Is(wallBlock.Identifier, BlockClass.WallHangingSignBlock);
        BlockFace attachmentDirection = hanging ? BlockFace.PosY : BlockFace.NegY;
        IBlock? wallState = StateForPlacement(level, wallBlock, context);
        IBlock? stateForPlacement = null;
        Vec3<int> pos = context.PlacePos;
        foreach (BlockFace direction in context.NearestLookingDirections) {
            if (direction == attachmentDirection.Opposite()) {
                continue;
            }
            IBlock? possibleState = direction == attachmentDirection ? StateForPlacement(level, block, context) : wallState;
            if (possibleState != null && CanSurvive(level, possibleState, pos)
                && (!hanging || !BlockClasses.Is(possibleState.Identifier, BlockClass.WallHangingSignBlock) || WallHangingSignCanPlace(level, possibleState, pos))) {
                stateForPlacement = possibleState;
                break;
            }
        }
        return stateForPlacement != null && IsUnobstructed(stateForPlacement, pos, default) ? stateForPlacement : null;
    }

    /// <summary><c>WallHangingSignBlock.canPlace</c>: something to hang from on one side or the other.</summary>
    private static bool WallHangingSignCanPlace(PredictingLevel level, IBlock state, Vec3<int> pos) {
        Direction facing = ((IHorizontalFacing)state).Facing;
        return CanAttachTo(pos.GetBlockTowards(facing.ClockWise().ToFace()), facing.CounterClockWise())
               || CanAttachTo(pos.GetBlockTowards(facing.CounterClockWise().ToFace()), facing.ClockWise());

        bool CanAttachTo(Vec3<int> attachPos, Direction attachFace) {
            IBlock attachState = level.GetBlock(attachPos);
            return level.IsInBlockTag(WallHangingSigns, attachState.Identifier)
                ? attachState is IHorizontalFacing attached && IsXAxis(attached.Facing) == IsXAxis(facing)
                : PlacementHelpers.FaceSturdy(level, attachPos, attachFace.ToFace());
        }

        static bool IsXAxis(Direction direction) => direction is Direction.East or Direction.West;
    }

    /// <summary><c>placeBlock</c>, with <c>DoubleHighBlockItem</c> clearing the cell above first and <c>BedItem</c>'s flags.</summary>
    private static bool PlaceBlock(PredictingLevel level, IBlock block, IBlockPlaceContext context, IBlock placementState) {
        Vec3<int> pos = context.PlacePos;
        if (BlockClasses.Is(block.Identifier, BlockClass.BedBlock)) {
            return level.SetBlock(pos, placementState, BedFlags);
        }
        if (BlockClasses.Is(block.Identifier, BlockClass.DoorBlock) || DoubleHighPlants.Contains(context.ItemInHand.Type.Identifier)) {
            Vec3<int> above = pos.WithY(pos.Y + 1);
            bool water = Minecraft.Fluids.FluidState.Of(level.GetBlock(above)).Kind == Minecraft.Fluids.FluidKind.Water;
            level.SetBlock(above, water ? Block.Water : Block.Air, DoubleHighFlags);
        }
        return level.SetBlock(pos, placementState, PlaceFlags);
    }

    /// <summary><c>BlockItem.updateBlockStateFromTag</c>: the item's <c>block_state</c> properties the block has.</summary>
    private static IBlock UpdateBlockStateFromTag(PredictingLevel level, Vec3<int> pos, ItemStack stack, IBlock placedState) {
        if (ItemComponents.Get(stack, DataComponent.BlockState) is not { Count: > 0 } properties) {
            return placedState;
        }
        CompoundTag state = new(placedState.ToStateNbt().Children
            .Select(property => (property.key, properties.TryGetValue(property.key, out string? value) ? new StringTag(value) : property.child))
            .ToArray());
        IBlock modifiedState = placedState.WithState(state);
        if (modifiedState.StateId != placedState.StateId) {
            level.SetBlock(pos, modifiedState, BlockUpdateFlags.Clients);
        }
        return modifiedState;
    }

    /// <summary>
    /// <c>CollisionGetter.isUnobstructed</c>: the state's collision shape in the context, at the position,
    /// clear of every entity that <c>blocksBuilding</c>, the player included. <c>Shapes.joinIsNotEmpty</c>
    /// merges coordinates within 1.0E-7, so a box that touches or overlaps by less than that does not obstruct.
    /// </summary>
    private bool IsUnobstructed(IBlock state, Vec3<int> pos, EntityCollisionContext collisionContext) {
        Box[] boxes = collisionContext.ShapeOf(Level, Level.Registry, state.StateId, pos.X, pos.Y, pos.Z)
                      ?? BlockPhysicsData.CollisionBoxesOf(state.CollisionShape);
        if (boxes.Length == 0) {
            return true;
        }
        Vec3<double> offset = state.ShapeOffset(pos);
        foreach (ClientEntity entity in _client.Entities.Values) {
            if (entity.IsRemoved || !BlocksBuilding(entity) || EntityCollisions.IsSpectator(_client, entity)) {
                continue;
            }
            Box entityBox = entity.BoundingBox;
            foreach (Box local in boxes) {
                Box box = local.Translate(pos.X + offset.X, pos.Y + offset.Y, pos.Z + offset.Z);
                if (box.MinX < entityBox.MaxX - 1.0E-7 && entityBox.MinX < box.MaxX - 1.0E-7
                    && box.MinY < entityBox.MaxY - 1.0E-7 && entityBox.MinY < box.MaxY - 1.0E-7
                    && box.MinZ < entityBox.MaxZ - 1.0E-7 && entityBox.MinZ < box.MaxZ - 1.0E-7) {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary><c>Entity.blocksBuilding</c>: living things bar a marker armour stand, and the classes that set it themselves.</summary>
    private static bool BlocksBuilding(ClientEntity entity) {
        if (entity.IsLiving) {
            return !entity.Is(EntityClass.ArmorStand) || (entity.Get(EntityDataFields.ArmorStand.ClientFlags) & ArmorStandMarker) == 0;
        }
        return entity.Is(EntityClass.EndCrystal) || entity.Is(EntityClass.PrimedTnt) || entity.Is(EntityClass.FallingBlockEntity)
               || entity.Is(EntityClass.AbstractBoat) || entity.Is(EntityClass.AbstractMinecart);
    }
}
