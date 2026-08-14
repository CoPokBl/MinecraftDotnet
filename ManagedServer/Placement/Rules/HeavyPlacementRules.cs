using ManagedServer.Fluids;
using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>SpeleothemBlock</c>: pointed dripstone and the sulfur spike. The most stateful placement in the
/// game, and the only one that reads
/// <c>getNearestLookingVerticalDirection</c>.
/// <p/>
/// Two properties come out of it. <c>vertical_direction</c> is which way the tip points, taken from
/// where the placer is looking and flipped if that end has nothing to hang off. <c>thickness</c> is
/// how the piece joins the pieces around it, and it is not a size: <c>tip</c>, <c>frustum</c>,
/// <c>middle</c> and <c>base</c> are positions in a column, and <c>tip_merge</c> is the one state
/// where two tips growing towards each other have met.
/// </summary>
public sealed class SpeleothemPlacementRule : IBlockPlacementRule {
    private static readonly Identifier Speleothems = "minecraft:speleothems";

    public BlockClass VanillaClass => BlockClass.SpeleothemBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        World world = context.World;
        Vec3<int> pos = context.PlacePos;

        BlockFace preferred = context.NearestLookingVerticalDirection.Opposite();
        BlockFace? tip = TipDirectionFor(block, world, pos, preferred);
        if (tip is null || block is not IVerticallyDirected pointed) {
            return null;
        }

        // Sneaking is what stops two tips merging, so a player can build a column of separate points.
        bool mergeOpposingTips = !context.IsSecondaryUseActive;
        SpeleothemThickness thickness = ThicknessFor(block, world, pos, tip.Value, mergeOpposingTips);

        IBlock state = pointed.WithVerticalDirection(DirectionOf(tip.Value));
        return PlacementHelpers.Waterlog(WithThickness(state, thickness), context);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return IsValidPlacement(block, world, pos, TipOf(block));
    }

    /// <summary>
    /// Only the two vertical neighbours matter, and losing the anchor schedules a fall rather than
    /// breaking outright, so this only ever rewrites the thickness. That scheduling is the piece with
    /// no equivalent here: a dripstone whose ceiling is mined stays up.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (toNeighbour is not (BlockFace.PosY or BlockFace.NegY)) {
            return block;
        }

        BlockFace tip = TipOf(block);
        if (toNeighbour == tip.Opposite() && !CanSurvive(block, world, pos)) {
            return block;
        }

        bool mergeOpposingTips = block is ISpeleothem { Thickness: SpeleothemThickness.TipMerge };
        return WithThickness(block, ThicknessFor(block, world, pos, tip, mergeOpposingTips));
    }

    /// <summary>
    /// <c>calculateTipDirection</c>: the way the placer is looking if that works, its opposite if
    /// that works, and null if neither does, which is a refusal to place at all.
    /// </summary>
    private static BlockFace? TipDirectionFor(IBlock block, World world, Vec3<int> pos, BlockFace preferred) {
        if (IsValidPlacement(block, world, pos, preferred)) {
            return preferred;
        }

        return IsValidPlacement(block, world, pos, preferred.Opposite()) ? preferred.Opposite() : null;
    }

    /// <summary>
    /// <c>isValidSpeleothemPlacement</c>: a sturdy face behind the base end, or more of the same
    /// speleothem pointing the same way, which is how a column extends.
    /// </summary>
    private static bool IsValidPlacement(IBlock block, World world, Vec3<int> pos, BlockFace tip) {
        Vec3<int> behindPos = pos.GetBlockTowards(tip.Opposite());
        IBlock behind = world.GetBlock(behindPos);

        return PlacementHelpers.FaceSturdy(world, behindPos, tip)
               || (IsSpeleothemWith(world, behind, tip) && IBlock.SimilarTo(behind, block));
    }

    /// <summary>
    /// <c>calculateSpeleothemThickness</c>, transcribed branch for branch. The first branch is the
    /// merge, and it is the one that reads <paramref name="mergeOpposingTips"/>: two tips facing each
    /// other either fuse into a <c>tip_merge</c> pair or stay two separate tips.
    /// </summary>
    private static SpeleothemThickness ThicknessFor(IBlock block, World world, Vec3<int> pos,
        BlockFace tip, bool mergeOpposingTips) {
        BlockFace baseDirection = tip.Opposite();
        IBlock inFront = world.GetBlock(pos.GetBlockTowards(tip));

        if (IsSpeleothemWith(world, inFront, baseDirection) && IBlock.SimilarTo(inFront, block)) {
            return !mergeOpposingTips && ThicknessOf(inFront) != SpeleothemThickness.TipMerge
                ? SpeleothemThickness.Tip
                : SpeleothemThickness.TipMerge;
        }

        if (!IsSpeleothemWith(world, inFront, tip)) {
            return SpeleothemThickness.Tip;
        }

        if (ThicknessOf(inFront) is SpeleothemThickness.Tip or SpeleothemThickness.TipMerge) {
            return SpeleothemThickness.Frustum;
        }

        IBlock behind = world.GetBlock(pos.GetBlockTowards(baseDirection));
        return IsSpeleothemWith(world, behind, tip)
            ? SpeleothemThickness.Middle
            : SpeleothemThickness.Base;
    }

    private static bool IsSpeleothemWith(World world, IBlock block, BlockFace tip) {
        return PlacementHelpers.InTag(world.Server.Registry, Speleothems, block.Identifier)
               && block is IVerticallyDirected pointed && pointed.VerticalDirection == DirectionOf(tip);
    }

    private static IBlock WithThickness(IBlock block, SpeleothemThickness thickness) {
        return block is ISpeleothem speleothem ? speleothem.WithThickness(thickness) : block;
    }

    private static SpeleothemThickness ThicknessOf(IBlock block) {
        return block is ISpeleothem speleothem ? speleothem.Thickness : SpeleothemThickness.Tip;
    }

    private static BlockFace TipOf(IBlock block) {
        return block is IVerticallyDirected { VerticalDirection: VerticalDirection.Up }
            ? BlockFace.PosY
            : BlockFace.NegY;
    }

    private static VerticalDirection DirectionOf(BlockFace face) {
        return face == BlockFace.PosY ? VerticalDirection.Up : VerticalDirection.Down;
    }
}

/// <summary>
/// <c>ScaffoldingBlock</c>. Its <c>distance</c> is how far it is from something solid, counted
/// sideways, and seven is too far to stay up. That is what lets a tower be built from the ground and
/// a walkway be run out from it only so far.
/// <p/>
/// <b>Two parts are missing and both are item level.</b> <c>ScaffoldingBlockItem</c> is one of the two
/// <c>BlockItem</c> subclasses whose behaviour cannot live in a block rule: its
/// <c>updatePlacementContext</c> walks a click on the top of a scaffold up the column so the piece
/// lands on top of the tower, and its <c>mustSurvive</c> returns false so a piece can be placed at
/// distance seven and fall. Neither seam exists here yet, so scaffolding places one block at a time
/// and refuses at distance seven.
/// </summary>
public sealed class ScaffoldingPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.ScaffoldingBlock;

    /// <summary>
    /// Clicking a scaffold with a scaffold always replaces, whatever the item's own replaceability
    /// says, and unlike the default it does not care whether the block is sneaked on.
    /// </summary>
    public bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        return !context.ItemInHand.IsAir() && context.ItemInHand.Type.Identifier == existing.Item;
    }

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        World world = context.World;
        Vec3<int> pos = context.PlacePos;
        int distance = DistanceAt(block, world, pos);

        IBlock state = PlacementHelpers.Waterlog(block, context);
        return Settle(state, world, pos, distance);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return DistanceAt(block, world, pos) < 7;
    }

    /// <summary>
    /// Vanilla's <c>updateShape</c> schedules a tick and hands the state back, so the distance is
    /// recomputed a tick later rather than in the cascade. There is no block tick scheduler, so this
    /// recomputes inline. It reaches the same state, one tick earlier, and it is the difference
    /// between a scaffold tower collapsing when its base goes and standing there for ever.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        int distance = DistanceAt(block, world, pos);
        if (distance >= 7) {
            return Block.Air;
        }

        return Settle(block, world, pos, distance);
    }

    /// <summary>
    /// The pair vanilla always writes together, <c>setValue(DISTANCE, d).setValue(BOTTOM,
    /// isBottom(level, pos, d))</c>: <c>bottom</c> is derived from the distance that was just worked
    /// out, so writing one without the other is never right.
    /// </summary>
    private static IBlock Settle(IBlock state, World world, Vec3<int> pos, int distance) {
        if (state is IDistanced scaffold) {
            state = scaffold.WithDistance(distance);
        }

        return state is IBottomed based
            ? based.WithBottom(IsBottom(state, world, pos, distance))
            : state;
    }

    /// <summary>
    /// <c>ScaffoldingBlock.getDistance</c>. Zero straight away for a sturdy face below, otherwise one
    /// more than the nearest horizontal neighbour, with the scaffold below counting as its own
    /// distance rather than one more, which is what makes a vertical column free.
    /// </summary>
    private static int DistanceAt(IBlock block, World world, Vec3<int> pos) {
        Vec3<int> belowPos = pos.WithY(pos.Y - 1);
        IBlock below = world.GetBlock(belowPos);

        int distance = 7;
        if (IBlock.SimilarTo(below, block)) {
            distance = below is IDistanced scaffold ? scaffold.Distance : 7;
        }
        else if (PlacementHelpers.FaceSturdy(world, belowPos, BlockFace.PosY)) {
            return 0;
        }

        foreach (BlockFace face in Directions.Horizontal) {
            IBlock beside = world.GetBlock(pos.GetBlockTowards(face));
            if (!IBlock.SimilarTo(beside, block)) {
                continue;
            }

            distance = Math.Min(distance,
                (beside is IDistanced scaffold ? scaffold.Distance : 7) + 1);
            if (distance == 1) {
                break;
            }
        }

        return distance;
    }

    /// <summary>The bottom rung, drawn with legs: held sideways, with no scaffold under it.</summary>
    private static bool IsBottom(IBlock block, World world, Vec3<int> pos, int distance) {
        return distance > 0 && !IBlock.SimilarTo(world.GetBlock(pos.WithY(pos.Y - 1)), block);
    }
}

/// <summary>
/// <c>ChestBlock</c>. Pairing, which is the only placement rule that reads two neighbours to decide a
/// property of both.
/// <p/>
/// Two ways a chest pairs. Sneaking while clicking the side of a block puts the new chest beside an
/// existing single chest and makes the pair line up with the wall that was clicked; not sneaking
/// looks left and right for a single chest already facing the same way. <c>type</c> then says which
/// half this is, and <c>updateShape</c> keeps the other half in step, including breaking the pair
/// when one is mined.
/// </summary>
public class ChestPlacementRule : IBlockPlacementRule {
    public virtual BlockClass VanillaClass => BlockClass.ChestBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        World world = context.World;
        Vec3<int> pos = context.PlacePos;

        ChestType type = ChestType.Single;
        Direction facing = context.HorizontalDirection.Opposite();
        bool secondaryUse = context.IsSecondaryUseActive;
        BlockFace clickedFace = context.ClickedFace;

        if (Directions.IsHorizontal(clickedFace) && secondaryUse) {
            Direction? partner = CandidatePartnerFacing(block, world, pos,
                clickedFace.Opposite().ToDirection());
            if (partner is not null && !Directions.SameAxis(partner.Value, clickedFace.ToDirection())) {
                facing = partner.Value;
                type = partner.Value.CounterClockWise() == clickedFace.Opposite().ToDirection()
                    ? ChestType.Right
                    : ChestType.Left;
            }
        }

        if (type == ChestType.Single && !secondaryUse) {
            type = ChestTypeAt(block, world, pos, facing);
        }

        IBlock state = block is IHorizontalFacing chest ? chest.WithFacing(facing) : block;
        state = WithType(state, type);
        return PlacementHelpers.Waterlog(state, context);
    }

    /// <summary>
    /// A single chest becomes a half when a half appears beside it pointing the same way and facing
    /// it, and a half becomes single again when its partner goes.
    /// </summary>
    public virtual IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (CanConnectTo(block, neighbourState) && Directions.IsHorizontal(toNeighbour)) {
            ChestType neighbourType = TypeOf(neighbourState);
            if (TypeOf(block) == ChestType.Single
                && neighbourType != ChestType.Single
                && SameFacing(block, neighbourState)
                && ConnectedDirection(neighbourState) == toNeighbour.Opposite()) {
                return WithType(block, Opposite(neighbourType));
            }
        }
        else if (ConnectedDirection(block) == toNeighbour) {
            return WithType(block, ChestType.Single);
        }

        return block;
    }

    /// <summary>
    /// <c>getChestType</c>: clockwise first, so a chest placed between two candidates pairs with the
    /// one on its left.
    /// </summary>
    private ChestType ChestTypeAt(IBlock block, World world, Vec3<int> pos, Direction facing) {
        if (facing == CandidatePartnerFacing(block, world, pos, facing.ClockWise())) {
            return ChestType.Left;
        }

        return facing == CandidatePartnerFacing(block, world, pos, facing.CounterClockWise())
            ? ChestType.Right
            : ChestType.Single;
    }

    /// <summary>The facing of a single chest that way, or null if there is nothing to pair with.</summary>
    private Direction? CandidatePartnerFacing(IBlock block, World world, Vec3<int> pos, Direction towards) {
        IBlock neighbour = world.GetBlock(pos.GetBlockTowards(towards.ToFace()));
        if (!CanConnectTo(block, neighbour) || TypeOf(neighbour) != ChestType.Single) {
            return null;
        }

        return neighbour is IHorizontalFacing chest ? chest.Facing : null;
    }

    /// <summary>
    /// <c>chestCanConnectTo</c>: the same block, so a trapped chest never pairs with a plain one. The
    /// copper chests widen it, which is why this is virtual.
    /// </summary>
    protected virtual bool CanConnectTo(IBlock block, IBlock neighbour) {
        return IBlock.SimilarTo(neighbour, block);
    }

    /// <summary>
    /// <c>getConnectedDirection</c>: which way the other half of the pair lies. A left half looks
    /// clockwise from its facing, a right half counter clockwise.
    /// </summary>
    private static BlockFace ConnectedDirection(IBlock chest) {
        if (chest is not IHorizontalFacing facing) {
            return BlockFace.PosY;
        }

        return TypeOf(chest) == ChestType.Left
            ? facing.Facing.ClockWise().ToFace()
            : facing.Facing.CounterClockWise().ToFace();
    }

    private static bool SameFacing(IBlock a, IBlock b) {
        return a is IHorizontalFacing fa && b is IHorizontalFacing fb && fa.Facing == fb.Facing;
    }

    private static IBlock WithType(IBlock block, ChestType type) {
        return block is IChestTyped chest ? chest.WithType(type) : block;
    }

    private static ChestType TypeOf(IBlock block) {
        return block is IChestTyped chest ? chest.Type : ChestType.Single;
    }

    private static ChestType Opposite(ChestType type) => type switch {
        ChestType.Left => ChestType.Right,
        ChestType.Right => ChestType.Left,
        _ => ChestType.Single
    };
}

/// <summary>
/// <c>CopperChestBlock</c>. A chest whose two halves must be the same level of oxidation, so pairing
/// with a weathered chest weathers this one, and the shape update pulls the other half along too.
/// <p/>
/// <b>Half transcribed.</b> The oxidation levelling reads a per block weathering chain that nothing
/// in the generated data carries, so the pairing is inherited from <see cref="ChestPlacementRule"/>
/// and the levelling is left out: two copper chests of different ages pair and keep their own
/// appearance. The rest of the copper chest behaves exactly as a chest.
/// </summary>
public sealed class CopperChestPlacementRule : ChestPlacementRule {
    public override BlockClass VanillaClass => BlockClass.CopperChestBlock;
}

/// <summary>
/// <c>RepeaterBlock</c>. Its state at placement is the diode's, plus <c>locked</c>, and its shape
/// update is the one thing <c>DiodeBlock</c> does not do: break when the block under it goes.
/// <p/>
/// <c>locked</c> goes through the <see cref="Redstone"/> stub and so is always false. It is written
/// out rather than left implicit so the branch is visible where redstone will fill it in.
/// </summary>
public sealed class RepeaterPlacementRule : IBlockPlacementRule {
    private static readonly DiodePlacementRule Diode = new();

    public BlockClass VanillaClass => BlockClass.RepeaterBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock? state = Diode.GetStateForPlacement(block, context);
        if (state is null) {
            return null;
        }

        Direction facing = state is IHorizontalFacing placed ? placed.Facing : Direction.North;
        return state is ILocked repeater
            ? repeater.WithLocked(Redstone.IsRepeaterLocked(context.World, context.PlacePos, facing))
            : state;
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return Diode.CanSurvive(block, world, pos);
    }

    /// <summary>
    /// The break below, then the one thing a repeater does that a comparator does not: anything
    /// changing across its facing axis makes it read its two sides again, because a repeater is
    /// locked by another one pointing into its side.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos)) {
            return Block.Air;
        }

        if (block is not IHorizontalFacing repeater
            || Directions.SameAxis(toNeighbour, repeater.Facing.ToFace())) {
            return block;
        }

        return block is ILocked locked
            ? locked.WithLocked(Redstone.IsRepeaterLocked(world, pos, repeater.Facing))
            : block;
    }

}

/// <summary>
/// <c>ComparatorBlock</c>. The same break as a repeater and nothing else: its placement state is the
/// diode's unchanged.
/// </summary>
public sealed class ComparatorPlacementRule : IBlockPlacementRule {
    private static readonly DiodePlacementRule Diode = new();

    public BlockClass VanillaClass => BlockClass.ComparatorBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return Diode.GetStateForPlacement(block, context);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return Diode.CanSurvive(block, world, pos);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>SmallDripleafBlock</c>. A double plant with a facing, and the one whose lower half will grow
/// out of plain vegetation as long as it is standing in water.
/// </summary>
public sealed class SmallDripleafPlacementRule : DoublePlantPlacementRule {
    private static readonly Identifier SupportsSmallDripleaf = "minecraft:supports_small_dripleaf";

    public override BlockClass VanillaClass => BlockClass.SmallDripleafBlock;

    /// <summary>
    /// The tag, or standing in a water source over anything a plant grows on at all. The water is
    /// read at <c>pos.above()</c>, and <c>pos</c> here is the block <b>below</b> the plant, so that
    /// is the plant's own cell.
    /// <p/>
    /// Vanilla also overrides <c>canSurvive</c>, and its override says the same thing the inherited
    /// one does, so there is none here.
    /// </summary>
    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        return PlacementHelpers.InTag(world.Server.Registry, SupportsSmallDripleaf, below.Identifier)
               || (PlacementHelpers.IsWaterSourceAt(world, belowPos.WithY(belowPos.Y + 1))
                   && base.MayPlaceOn(plant, below, world, belowPos));
    }

    public override IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock? state = base.GetStateForPlacement(block, context);
        if (state is null) {
            return null;
        }

        if (state is IHorizontalFacing leaf) {
            state = leaf.WithFacing(context.HorizontalDirection.Opposite());
        }

        return CopyWaterloggedFrom(state, context.World, context.PlacePos);
    }

    /// <summary>The upper half keeps the facing and takes the water from its own cell.</summary>
    public override void OnPlaced(IBlock placed, IBlockPlaceContext context) {
        if (placed is not IDoubleHalved halved) {
            return;
        }

        Vec3<int> above = context.PlacePos.WithY(context.PlacePos.Y + 1);
        context.World.SetBlock(above,
            CopyWaterloggedFrom(halved.WithHalf(BlockHalf.Upper), context.World, above));
    }

    private static IBlock CopyWaterloggedFrom(IBlock block, World world, Vec3<int> pos) {
        return block is IWaterlogged waterloggable
            ? waterloggable.WithWaterlogged(PlacementHelpers.IsWaterAt(world, pos))
            : block;
    }
}

/// <summary>
/// <c>PitcherCropBlock</c>. A double plant that behaves like one only once it is grown: below age
/// three it is a single cell, and the upper half does not exist yet.
/// <p/>
/// Three deliberate departures from the double plant it inherits, all vanilla's.
/// <c>getStateForPlacement</c> skips the "is there room above" check entirely.
/// <c>canBeReplaced</c> is a flat false, so nothing is ever placed into a pitcher crop.
/// <c>setPlacedBy</c> is overridden to do <b>nothing</b>, which is why placing one does not write a
/// top half the way every other double plant does.
/// <p/>
/// <b>Documented divergence.</b> Vanilla's <c>canSurvive</c> is
/// <c>isLower(state) &amp;&amp; !sufficientLight(level, pos) ? false : super.canSurvive(...)</c>. The
/// light half is dropped for the reason <c>CropPlacementRule</c> records, there is no per position
/// brightness query, so the inherited answer is used unchanged and it errs permissive.
/// </summary>
public sealed class PitcherCropPlacementRule : DoublePlantPlacementRule {
    private static readonly Identifier SupportsCrops = "minecraft:supports_crops";

    public override BlockClass VanillaClass => BlockClass.PitcherCropBlock;

    protected override bool MayPlaceOn(IBlock plant, IBlock below, World world, Vec3<int> belowPos) {
        return PlacementHelpers.InTag(world.Server.Registry, SupportsCrops, below.Identifier);
    }

    public override bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        return false;
    }

    /// <summary>The room above test is skipped, and no top half is written.</summary>
    public override IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) => block;

    /// <inheritdoc cref="GetStateForPlacement"/>
    public override void OnPlaced(IBlock placed, IBlockPlaceContext context) { }

    /// <summary>
    /// Below age three the crop is one cell, so the two cell rule would kill it for having no partner
    /// above. Vanilla guards exactly that, and the ungrown branch is a plain survival test.
    /// </summary>
    public override IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        int age = block is IAged crop ? crop.Age : 0;
        if (age >= 3) {
            return base.UpdateShape(block, world, pos, toNeighbour, neighbourPos, neighbourState);
        }

        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}
