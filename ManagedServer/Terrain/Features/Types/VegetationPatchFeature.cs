using ManagedServer.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>VegetationPatchFeature</c>: a patch of ground replaced, with something growing out of it.
/// </summary>
/// <remarks>
/// The moss, the lush cave floors and the sculk patches are all this. It works over a rectangle of
/// columns, and for each one walks along the surface direction to find where the ground actually is,
/// so a patch follows a cave floor rather than sitting flat.
/// <p/>
/// <see cref="Surface"/> is which way "down" is for the patch: a floor patch grows downwards into the
/// ground and puts its vegetation above, a ceiling patch does the opposite. The corners of the
/// rectangle are always skipped and its edges are kept only on a roll, which is what rounds it off.
/// </remarks>
public record VegetationPatchFeature(Identifier Replaceable, BlockStateProvider GroundState,
    PlacedFeature VegetationFeature, bool CeilingSurface, IIntProvider Depth, float ExtraBottomBlockChance,
    int VerticalRange, float VegetationChance, IIntProvider XzRadius, float ExtraEdgeColumnChance)
    : ConfiguredFeature {

    /// <summary>The way the patch grows into the ground: down for a floor, up for a ceiling.</summary>
    protected Vec3<int> Inwards => CeilingSurface ? new Vec3<int>(0, 1, 0) : new Vec3<int>(0, -1, 0);

    protected Vec3<int> Outwards => CeilingSurface ? new Vec3<int>(0, -1, 0) : new Vec3<int>(0, 1, 0);

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        // Two draws, not one doubled: the patch is rectangular rather than square.
        int xRadius = XzRadius.Sample(random) + 1;
        int zRadius = XzRadius.Sample(random) + 1;

        JavaHashSet<Vec3<int>> surface = PlaceGroundPatch(level, random, origin, xRadius, zRadius);
        DistributeVegetation(context, level, random, surface);

        return surface.Count > 0;
    }

    /// <summary>
    /// The columns whose ground was replaced.
    /// </summary>
    /// <remarks>
    /// A <see cref="JavaHashSet{T}"/> because the caller loops over it drawing per entry, so its
    /// iteration order decides which columns get vegetation and in what order, while the number of
    /// draws is the same either way.
    /// </remarks>
    protected virtual JavaHashSet<Vec3<int>> PlaceGroundPatch(IFeatureLevel level, RandomSource random,
        Vec3<int> origin, int xRadius, int zRadius) {

        JavaHashSet<Vec3<int>> surface = FeatureUtil.PositionSet();

        for (int dx = -xRadius; dx <= xRadius; dx++) {
            bool isXEdge = dx == -xRadius || dx == xRadius;

            for (int dz = -zRadius; dz <= zRadius; dz++) {
                bool isZEdge = dz == -zRadius || dz == zRadius;
                bool isCorner = isXEdge && isZEdge;
                bool isEdgeNotCorner = (isXEdge || isZEdge) && !isCorner;

                if (isCorner) {
                    continue;
                }

                if (isEdgeNotCorner
                    && (ExtraEdgeColumnChance == 0.0f || random.NextFloat() > ExtraEdgeColumnChance)) {

                    continue;
                }

                Vec3<int> pos = origin + new Vec3<int>(dx, 0, dz);

                // Walk to the ground: inwards while in air, then back out while in solid, so the
                // result is the first empty block against the surface either way round.
                for (int i = 0; level.Blocks.IsAir(level.GetState(pos.X, pos.Y, pos.Z)) && i < VerticalRange;
                    i++) {

                    pos += Inwards;
                }

                for (int i = 0; !level.Blocks.IsAir(level.GetState(pos.X, pos.Y, pos.Z)) && i < VerticalRange;
                    i++) {

                    pos += Outwards;
                }

                Vec3<int> belowPos = pos + Inwards;
                IBlock belowState = level.Registry.Blocks
                    .GetByStateId(level.GetState(belowPos.X, belowPos.Y, belowPos.Z));

                if (!level.Blocks.IsAir(level.GetState(pos.X, pos.Y, pos.Z))
                    || !ShapeSupport.IsFaceSturdy(belowState, FaceOf(Outwards))) {

                    continue;
                }

                int depth = Depth.Sample(random)
                    + (ExtraBottomBlockChance > 0.0f && random.NextFloat() < ExtraBottomBlockChance ? 1 : 0);

                if (PlaceGround(level, random, belowPos, depth)) {
                    surface.Add(belowPos);
                }
            }
        }

        return surface;
    }

    /// <summary>
    /// Replaces a column of ground. Stops at the first block outside the replaceable tag, and reports
    /// success only if it got at least one block down.
    /// </summary>
    private bool PlaceGround(IFeatureLevel level, RandomSource random, Vec3<int> belowPos, int depth) {
        for (int i = 0; i < depth; i++) {
            IBlock stateToPlace = GroundState.GetState(level, random, belowPos.X, belowPos.Y, belowPos.Z);
            uint existing = level.GetState(belowPos.X, belowPos.Y, belowPos.Z);

            // Already the right block, so nothing to do and nothing to stop for.
            if (level.Registry.Blocks.GetByStateId(existing).Identifier.Equals(stateToPlace.Identifier)) {
                continue;
            }

            if (!level.Blocks.IsIn(Replaceable, existing)) {
                return i != 0;
            }

            level.SetState(belowPos.X, belowPos.Y, belowPos.Z, stateToPlace.StateId);
            belowPos += Inwards;
        }

        return true;
    }

    protected void DistributeVegetation(FeaturePlaceContext context, IFeatureLevel level,
        RandomSource random, JavaHashSet<Vec3<int>> surface) {

        foreach (Vec3<int> surfacePos in surface) {
            if (VegetationChance > 0.0f && random.NextFloat() < VegetationChance) {
                PlaceVegetation(context, random, surfacePos);
            }
        }
    }

    protected virtual bool PlaceVegetation(FeaturePlaceContext context, RandomSource random, Vec3<int> surfacePos) {
        return VegetationFeature.Place(context.Placement.Nested(), random, surfacePos + Outwards);
    }

    private static BlockFace FaceOf(Vec3<int> direction) {
        return direction.Y > 0 ? BlockFace.PosY : BlockFace.NegY;
    }
}

/// <summary>
/// <c>WaterloggedVegetationPatchFeature</c>: the same patch, with the sheltered part of it flooded.
/// </summary>
/// <remarks>
/// <b>It overrides where the patch is, not what grows on it.</b> The ground patch is built as usual
/// and then narrowed to the columns that are <b>not</b> exposed, those are filled with water, and that
/// narrowed set is what comes back. So the vegetation grows out of the pool rather than around it,
/// which is what a lush cave's clay pool looks like.
/// <p/>
/// A column counts as exposed when any of its four sides or its underside is not a sturdy face. The
/// test does not include the top, since the patch is what is above it.
/// </remarks>
public sealed record WaterloggedVegetationPatchFeature(Identifier Replaceable,
    BlockStateProvider GroundState, PlacedFeature VegetationFeature, bool CeilingSurface, IIntProvider Depth,
    float ExtraBottomBlockChance, int VerticalRange, float VegetationChance, IIntProvider XzRadius,
    float ExtraEdgeColumnChance)
    : VegetationPatchFeature(Replaceable, GroundState, VegetationFeature, CeilingSurface, Depth,
        ExtraBottomBlockChance, VerticalRange, VegetationChance, XzRadius, ExtraEdgeColumnChance) {

    protected override JavaHashSet<Vec3<int>> PlaceGroundPatch(IFeatureLevel level, RandomSource random,
        Vec3<int> origin, int xRadius, int zRadius) {

        JavaHashSet<Vec3<int>> surface = base.PlaceGroundPatch(level, random, origin, xRadius, zRadius);
        JavaHashSet<Vec3<int>> water = FeatureUtil.PositionSet();

        foreach (Vec3<int> pos in surface) {
            if (!IsExposed(level, pos)) {
                water.Add(pos);
            }
        }

        foreach (Vec3<int> pos in water) {
            level.SetState(pos.X, pos.Y, pos.Z, Minecraft.Data.Generated.Block.Water.StateId);
        }

        return water;
    }

    /// <summary>
    /// Grows the vegetation <b>in</b> the water block rather than above it, and waterlogs whatever it
    /// left there.
    /// </summary>
    /// <remarks>
    /// The offset cancels: this steps down one and the base steps back up, so the feature is placed at
    /// the surface position itself. Reading either half alone makes the other look like an error.
    /// </remarks>
    protected override bool PlaceVegetation(FeaturePlaceContext context, RandomSource random,
        Vec3<int> surfacePos) {

        if (!base.PlaceVegetation(context, random, surfacePos.WithY(surfacePos.Y - 1))) {
            return false;
        }

        IFeatureLevel level = context.Level;
        IBlock placed = level.Registry.Blocks
            .GetByStateId(level.GetState(surfacePos.X, surfacePos.Y, surfacePos.Z));

        if (placed is IWaterlogged { Waterlogged: false } waterlogged) {
            level.SetState(surfacePos.X, surfacePos.Y, surfacePos.Z,
                waterlogged.WithWaterlogged(true).StateId);
        }

        return true;
    }

    private static bool IsExposed(IFeatureLevel level, Vec3<int> pos) {
        foreach (BlockFace face in Faces) {
            Vec3<int> test = pos + Placement.PlacementParser.Step(face);
            IBlock state = level.Registry.Blocks.GetByStateId(level.GetState(test.X, test.Y, test.Z));

            if (!ShapeSupport.IsFaceSturdy(state, Opposite(face))) {
                return true;
            }
        }

        return false;
    }

    /// <summary>North, east, south, west and down, in vanilla's own order.</summary>
    private static readonly BlockFace[] Faces = [
        BlockFace.NegZ, BlockFace.PosX, BlockFace.PosZ, BlockFace.NegX, BlockFace.NegY
    ];

    private static BlockFace Opposite(BlockFace face) {
        return face switch {
            BlockFace.NegY => BlockFace.PosY,
            BlockFace.PosY => BlockFace.NegY,
            BlockFace.NegZ => BlockFace.PosZ,
            BlockFace.PosZ => BlockFace.NegZ,
            BlockFace.NegX => BlockFace.PosX,
            _ => BlockFace.NegX
        };
    }
}
