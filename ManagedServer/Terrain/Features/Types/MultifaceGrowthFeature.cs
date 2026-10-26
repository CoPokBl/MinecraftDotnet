using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features.Placement;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>MultifaceGrowthFeature</c>: glow lichen and sculk vein, stuck to whatever is around them.
/// </summary>
/// <remarks>
/// A multiface block occupies faces of a cell rather than the cell itself, so placing one is choosing
/// a face, and the whole feature is a search for a cell with something worth sticking to beside it.
/// <p/>
/// Two shuffled direction lists are drawn per attempt and both are consumed in order, so which face a
/// patch lands on is decided by the shuffle rather than by any preference.
/// </remarks>
public sealed record MultifaceGrowthFeature(IBlock PlaceBlock, int SearchRange, bool CanPlaceOnFloor,
    bool CanPlaceOnCeiling, bool CanPlaceOnWall, float ChanceOfSpreading,
    IReadOnlySet<Identifier> CanBePlacedOn) : ConfiguredFeature {

    /// <summary>
    /// The faces the configuration allows, in the order the configuration builds them: ceiling,
    /// floor, then the four walls in <c>Plane.HORIZONTAL</c>'s order.
    /// </summary>
    /// <remarks>
    /// The order is what the shuffle below permutes, so it decides which face each of its draws lands
    /// on rather than being a way of writing down a set.
    /// </remarks>
    private BlockFace[] ValidDirections {
        get {
            List<BlockFace> directions = [];

            if (CanPlaceOnCeiling) {
                directions.Add(BlockFace.PosY);
            }

            if (CanPlaceOnFloor) {
                directions.Add(BlockFace.NegY);
            }

            if (CanPlaceOnWall) {
                directions.AddRange(Directions.Horizontal);
            }

            return [..directions];
        }
    }

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!IsAirOrWater(level, origin)) {
            return false;
        }

        BlockFace[] valid = ValidDirections;
        List<BlockFace> searchOrder = FeatureUtil.Shuffled(valid, random);

        IBlock here = level.Registry.Blocks.GetByStateId(level.GetState(origin.X, origin.Y, origin.Z));
        if (PlaceGrowthIfPossible(level, random, origin, here, searchOrder)) {
            return true;
        }

        foreach (BlockFace searchDirection in searchOrder) {
            List<BlockFace> placementOrder = FeatureUtil.Shuffled(
                valid.Where(face => face != searchDirection.Opposite()).ToArray(), random);

            for (int attempt = 0; attempt < SearchRange; attempt++) {
                // The cursor is reset to one step from the origin every iteration rather than
                // advancing, so the search never leaves the cell next door and the range is only a
                // repeat count. Vanilla's, and the repeats draw nothing, so they are pure repetition.
                Vec3<int> pos = origin + PlacementParser.Step(searchDirection);
                IBlock state = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));

                if (!IsAirOrWater(level, pos) && !state.Identifier.Equals(PlaceBlock.Identifier)) {
                    break;
                }

                if (PlaceGrowthIfPossible(level, random, pos, state, placementOrder)) {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// The first face with something on the allowed list behind it takes the growth, and a growth
    /// that lands may spread once more from where it landed.
    /// </summary>
    /// <remarks>
    /// A face whose neighbour is on the list but which cannot hold the block answers <b>false for the
    /// whole cell</b> rather than moving on to the next face, so one unusable face ends the attempt.
    /// </remarks>
    private bool PlaceGrowthIfPossible(IFeatureLevel level, RandomSource random, Vec3<int> pos,
        IBlock oldState, List<BlockFace> placementOrder) {

        foreach (BlockFace face in placementOrder) {
            Vec3<int> neighbour = pos + PlacementParser.Step(face);
            IBlock neighbourState =
                level.Registry.Blocks.GetByStateId(level.GetState(neighbour.X, neighbour.Y, neighbour.Z));

            if (!CanBePlacedOn.Contains(neighbourState.Identifier)) {
                continue;
            }

            IBlock? newState = StateForPlacement(level, oldState, pos, face);
            if (newState is null) {
                return false;
            }

            level.SetState(pos.X, pos.Y, pos.Z, newState.StateId);

            if (random.NextFloat() < ChanceOfSpreading) {
                SpreadFromFaceTowardRandomDirection(level, random, newState, pos, face);
            }

            return true;
        }

        return false;
    }

    /// <summary>
    /// <c>MultifaceBlock.getStateForPlacement</c>: add a face to what is already there, or start a
    /// new block, waterlogged if it is going into a water source.
    /// </summary>
    private IBlock? StateForPlacement(IFeatureLevel level, IBlock oldState, Vec3<int> pos, BlockFace face) {
        if (!IsValidStateForPlacement(level, oldState, pos, face)) {
            return null;
        }

        IBlock state;

        if (oldState.Identifier.Equals(PlaceBlock.Identifier)) {
            state = oldState;
        } else if (oldState.Identifier.Equals(Block.Water.Identifier)
            && PlaceBlock is IWaterlogged waterloggable) {

            state = waterloggable.WithWaterlogged(true);
        } else {
            state = PlaceBlock;
        }

        return state is IFaceConnected connected ? connected.WithConnection(face, true) : state;
    }

    /// <summary>
    /// <c>MultifaceBlock.isValidStateForPlacement</c>: a face that is not already taken, with
    /// something behind it a multiface block can attach to.
    /// </summary>
    private bool IsValidStateForPlacement(IFeatureLevel level, IBlock state, Vec3<int> pos, BlockFace face) {
        if (state.Identifier.Equals(PlaceBlock.Identifier) && HasFace(state, face)) {
            return false;
        }

        Vec3<int> behind = pos + PlacementParser.Step(face);
        IBlock support = level.Registry.Blocks.GetByStateId(level.GetState(behind.X, behind.Y, behind.Z));
        BlockFace against = face.Opposite();

        return ShapeSupport.IsFaceFull(support.SupportShape, against)
            || ShapeSupport.IsFaceFull(support.CollisionShape, against);
    }

    /// <summary>
    /// <c>MultifaceSpreader.spreadFromFaceTowardRandomDirection</c>: one more growth beside the one
    /// just placed, in the first of six shuffled directions that takes it.
    /// </summary>
    private void SpreadFromFaceTowardRandomDirection(IFeatureLevel level, RandomSource random,
        IBlock state, Vec3<int> pos, BlockFace fromFace) {

        foreach (BlockFace spreadDirection in FeatureUtil.Shuffled(FeatureUtil.AllDirections, random)) {
            if (SpreadTowards(level, state, pos, fromFace, spreadDirection)) {
                return;
            }
        }
    }

    /// <summary>
    /// The three ways a face grows into a neighbouring one, tried in order: around the inside of the
    /// same cell, along a flat wall, then around an outside corner.
    /// </summary>
    /// <remarks>
    /// The axis test at the top is what stops a face growing into itself: a north face cannot spread
    /// north or south, only up, down, east or west.
    /// </remarks>
    private bool SpreadTowards(IFeatureLevel level, IBlock state, Vec3<int> pos, BlockFace fromFace,
        BlockFace spreadDirection) {

        if (Axis(spreadDirection) == Axis(fromFace)) {
            return false;
        }

        if (!IsOtherBlockValidAsSource(state)
            && (!HasFace(state, fromFace) || HasFace(state, spreadDirection))) {

            return false;
        }

        Vec3<int> along = PlacementParser.Step(spreadDirection);
        Vec3<int> outward = PlacementParser.Step(fromFace);

        (Vec3<int> Pos, BlockFace Face)[] candidates = [
            (pos, spreadDirection),
            (pos + along, fromFace),
            (pos + along + outward, spreadDirection.Opposite())
        ];

        foreach ((Vec3<int> target, BlockFace face) in candidates) {
            IBlock existing =
                level.Registry.Blocks.GetByStateId(level.GetState(target.X, target.Y, target.Z));

            if (!StateCanBeReplaced(level, pos, target, face, existing.StateId)
                || !IsValidStateForPlacement(level, existing, target, face)) {

                continue;
            }

            if (StateForPlacement(level, existing, target, face) is not { } placed) {
                continue;
            }

            level.SetState(target.X, target.Y, target.Z, placed.StateId);
            return true;
        }

        return false;
    }

    /// <summary>Whether this feature's block is the sculk vein, which carries its own spread config.</summary>
    private bool IsSculkVein => PlaceBlock.Identifier.Equals(Block.SculkVein.Identifier);

    /// <summary>
    /// <c>SpreadConfig.stateCanBeReplaced</c>, which comes off the <b>block being spread</b> rather
    /// than being one rule for the feature.
    /// </summary>
    /// <remarks>
    /// The sculk vein overrides it and glow lichen does not, so a vein refuses to take a face backed
    /// by sculk and steps to the next candidate where a lichen would have taken it. Using the default
    /// for both puts the vein's second growth on the block it came from instead of one over, which is
    /// the same number of veins in slightly the wrong places.
    /// </remarks>
    private bool StateCanBeReplaced(IFeatureLevel level, Vec3<int> source, Vec3<int> target,
        BlockFace face, uint existing) {

        return IsSculkVein
            ? MultifaceSpreader.SculkStateCanBeReplaced(level, source, target, face, existing)
            : MultifaceSpreader.DefaultStateCanBeReplaced(level, PlaceBlock.Identifier, existing);
    }

    /// <summary>
    /// <c>SpreadConfig.isOtherBlockValidAsSource</c>: false by default, and anything that is not
    /// already a vein for the sculk vein.
    /// </summary>
    private bool IsOtherBlockValidAsSource(IBlock state) {
        return IsSculkVein && !state.Identifier.Equals(Block.SculkVein.Identifier);
    }

    private bool HasFace(IBlock state, BlockFace face) {
        return state.Identifier.Equals(PlaceBlock.Identifier)
            && state is IFaceConnected connected && connected.Connected(face);
    }

    private static int Axis(BlockFace face) {
        return face switch {
            BlockFace.NegY or BlockFace.PosY => 1,
            BlockFace.NegZ or BlockFace.PosZ => 2,
            _ => 0
        };
    }

    private static bool IsAirOrWater(IFeatureLevel level, Vec3<int> pos) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));
        return block.Air || block.Identifier.Equals(Block.Water.Identifier);
    }
}
