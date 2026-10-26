using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Placement;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>LakeFeature</c>: a pool of water or lava carved into the surface, with a stone shell around it.
/// </summary>
/// <remarks>
/// Four to seven overlapping ellipsoids voxelised into a 16 by 8 by 16 grid, and then the grid is used
/// three times over: once to reject the whole lake, once to fill it, and once to lay the barrier.
/// <p/>
/// <b>The halfway line at y 4 is what makes it a lake rather than a blob.</b> Everything the grid
/// covers below it becomes fluid and everything above becomes cave air, so the shape is dug out on top
/// and filled underneath. The rejection pass uses the same line the other way round: liquid found in
/// the upper half or a gap in the lower half aborts the feature, which is what stops a lake being cut
/// into the side of a cliff.
/// <p/>
/// Two upstream calls have no equivalent here and neither changes a block: the scheduled tick on the
/// cave air, and marking the column above for post processing.
/// </remarks>
public sealed record LakeFeature(BlockStateProvider Fluid, BlockStateProvider Barrier,
    BlockPredicate CanPlaceFeature, BlockPredicate CanReplaceWithAirOrFluid,
    BlockPredicate CanReplaceWithBarrier) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (origin.Y <= level.MinY + 4) {
            return false;
        }

        origin = new Vec3<int>(origin.X - 8, origin.Y - 4, origin.Z - 8);

        bool[] grid = new bool[2048];
        int blobs = random.NextInt(4) + 4;

        for (int blob = 0; blob < blobs; blob++) {
            double radiusX = random.NextDouble() * 6.0 + 3.0;
            double radiusY = random.NextDouble() * 4.0 + 2.0;
            double radiusZ = random.NextDouble() * 6.0 + 3.0;
            double centreX = random.NextDouble() * (16.0 - radiusX - 2.0) + 1.0 + radiusX / 2.0;
            double centreY = random.NextDouble() * (8.0 - radiusY - 4.0) + 2.0 + radiusY / 2.0;
            double centreZ = random.NextDouble() * (16.0 - radiusZ - 2.0) + 1.0 + radiusZ / 2.0;

            // The one block margin is what leaves room for the barrier, so the walk stops short of
            // the grid's own edges rather than covering it.
            for (int x = 1; x < 15; x++) {
                for (int z = 1; z < 15; z++) {
                    for (int y = 1; y < 7; y++) {
                        double dx = (x - centreX) / (radiusX / 2.0);
                        double dy = (y - centreY) / (radiusY / 2.0);
                        double dz = (z - centreZ) / (radiusZ / 2.0);

                        if (dx * dx + dy * dy + dz * dz < 1.0) {
                            grid[Index(x, y, z)] = true;
                        }
                    }
                }
            }
        }

        IBlock fluid = Fluid.GetState(level, random, origin.X, origin.Y, origin.Z);

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 8; y++) {
                    if (!IsShell(grid, x, y, z)) {
                        continue;
                    }

                    int worldX = origin.X + x;
                    int worldY = origin.Y + y;
                    int worldZ = origin.Z + z;

                    uint state = level.GetState(worldX, worldY, worldZ);
                    IBlock block = level.Registry.Blocks.GetByStateId(state);

                    if (y >= 4 && block.Liquid) {
                        return false;
                    }

                    if (y < 4 && !level.Blocks.IsSolid(state) && state != fluid.StateId) {
                        return false;
                    }

                    if (!CanPlaceFeature.Test(level, worldX, worldY, worldZ)) {
                        return false;
                    }
                }
            }
        }

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 8; y++) {
                    if (!grid[Index(x, y, z)]) {
                        continue;
                    }

                    int worldX = origin.X + x;
                    int worldY = origin.Y + y;
                    int worldZ = origin.Z + z;

                    if (CanReplaceWithAirOrFluid.Test(level, worldX, worldY, worldZ)) {
                        level.SetState(worldX, worldY, worldZ,
                            y >= 4 ? Block.CaveAir.StateId : fluid.StateId);
                    }
                }
            }
        }

        IBlock barrier = Barrier.GetState(level, random, origin.X, origin.Y, origin.Z);

        if (!barrier.Air) {
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    for (int y = 0; y < 8; y++) {
                        if (!IsShell(grid, x, y, z)) {
                            continue;
                        }

                        // The roof of the shell is only half laid, which is what leaves a lake open
                        // to the sky rather than sealed under a dome.
                        if (y >= 4 && random.NextInt(2) == 0) {
                            continue;
                        }

                        int worldX = origin.X + x;
                        int worldY = origin.Y + y;
                        int worldZ = origin.Z + z;

                        if (level.Blocks.IsSolid(level.GetState(worldX, worldY, worldZ))
                            && CanReplaceWithBarrier.Test(level, worldX, worldY, worldZ)) {

                            level.SetState(worldX, worldY, worldZ, barrier.StateId);
                        }
                    }
                }
            }
        }

        if (fluid.Identifier.Equals(Block.Water.Identifier)) {
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    int worldX = origin.X + x;
                    int worldY = origin.Y + 4;
                    int worldZ = origin.Z + z;

                    IBiome biome = level.GetBiome(worldX, worldY, worldZ);

                    if (BiomeClimate.ShouldFreeze(biome, level, worldX, worldY, worldZ)
                        && CanReplaceWithAirOrFluid.Test(level, worldX, worldY, worldZ)) {

                        level.SetState(worldX, worldY, worldZ, Block.Ice.StateId);
                    }
                }
            }
        }

        return true;
    }

    /// <summary>
    /// A cell outside the lake with at least one of its six neighbours inside it, which is the surface
    /// the lake has to be judged and walled against.
    /// </summary>
    private static bool IsShell(bool[] grid, int x, int y, int z) {
        if (grid[Index(x, y, z)]) {
            return false;
        }

        return (x < 15 && grid[Index(x + 1, y, z)])
            || (x > 0 && grid[Index(x - 1, y, z)])
            || (z < 15 && grid[Index(x, y, z + 1)])
            || (z > 0 && grid[Index(x, y, z - 1)])
            || (y < 7 && grid[Index(x, y + 1, z)])
            || (y > 0 && grid[Index(x, y - 1, z)]);
    }

    private static int Index(int x, int y, int z) => (x * 16 + z) * 8 + y;
}

/// <summary>
/// <c>RootSystemFeature</c>: the rooted dirt and hanging roots under an azalea tree growing over a
/// lush cave.
/// </summary>
/// <remarks>
/// The feature works upwards from a cave ceiling looking for somewhere the tree could stand, places
/// the tree there, and then fills the column between the origin and the tree with rooted dirt. So the
/// visible half is the tree on the surface and the roots hanging into the cave below it, and the two
/// are placed by one feature because the column joining them is the point.
/// </remarks>
public sealed record RootSystemFeature(PlacedFeature TreeFeature, int RequiredVerticalSpaceForTree,
    int RootRadius, IReadOnlySet<Identifier> RootReplaceable, BlockStateProvider RootStateProvider,
    int RootPlacementAttempts, int RootColumnMaxHeight, int HangingRootRadius,
    int HangingRootsVerticalSpan, BlockStateProvider HangingRootStateProvider,
    int HangingRootPlacementAttempts, int AllowedVerticalWaterForTree, BlockPredicate AllowedTreePosition,
    int LevelTestDistance, int MaxLevelDeviation) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;

        if (!level.IsAir(origin.X, origin.Y, origin.Z)) {
            return false;
        }

        if (PlaceDirtAndTree(context, out int reached)) {
            PlaceDirt(context, reached);
            PlaceHangingRoots(context);
        }

        // Reports success whether or not a tree was found, which is what stops a chunk retrying.
        return true;
    }

    private bool PlaceDirtAndTree(FeaturePlaceContext context, out int reached) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;
        reached = 0;

        for (int step = 0; step < RootColumnMaxHeight; step++) {
            int y = origin.Y + step + 1;

            if (level.GetHeight(HeightmapType.WorldSurface, origin.X, origin.Z) < y) {
                return false;
            }

            if (!AllowedTreePosition.Test(level, origin.X, y, origin.Z)
                || !SpaceForTree(level, origin.X, y, origin.Z)) {

                continue;
            }

            // Solid ground, and not lava: a tree standing on a lava lake would burn away the moment
            // the chunk ticked.
            uint below = level.GetState(origin.X, y - 1, origin.Z);
            if (FeatureFluids.IsLava(level, below) || !level.Blocks.IsSolid(below)) {
                return false;
            }

            if (!TreeFeature.Place(context.Placement.Nested(), context.Random,
                new Vec3<int>(origin.X, y, origin.Z))) {

                continue;
            }

            reached = origin.Y + step;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Room above for the tree, and four corner probes that keep it off a slope.
    /// </summary>
    /// <remarks>
    /// The water allowance is counted from one block <b>above</b> the origin, so a tree may stand with
    /// its feet in shallow water and not in deep.
    /// </remarks>
    private bool SpaceForTree(IFeatureLevel level, int x, int y, int z) {
        for (int above = 1; above <= RequiredVerticalSpaceForTree; above++) {
            uint state = level.GetState(x, y + above, z);

            if (level.Blocks.IsAir(state)) {
                continue;
            }

            if (above + 1 > AllowedVerticalWaterForTree || !FeatureFluids.IsWater(level, state)) {
                return false;
            }
        }

        if (LevelTestDistance <= 0) {
            return true;
        }

        // Direction.from2DDataValue order: south, west, north, east.
        (int X, int Z)[] corners = [(0, 1), (-1, 0), (0, -1), (1, 0)];

        foreach ((int dx, int dz) in corners) {
            int cornerX = x + dx * LevelTestDistance;
            int cornerZ = z + dz * LevelTestDistance;

            bool belowIsAir = level.IsAir(cornerX, y - MaxLevelDeviation, cornerZ);
            bool aboveIsAir = level.IsAir(cornerX, y + MaxLevelDeviation, cornerZ);

            if (belowIsAir || !aboveIsAir) {
                return false;
            }
        }

        return true;
    }

    private void PlaceDirt(FeaturePlaceContext context, int targetHeight) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        for (int y = origin.Y; y < targetHeight; y++) {
            for (int attempt = 0; attempt < RootPlacementAttempts; attempt++) {
                int x = origin.X + random.NextInt(RootRadius) - random.NextInt(RootRadius);
                int z = origin.Z + random.NextInt(RootRadius) - random.NextInt(RootRadius);

                uint state = level.GetState(x, y, z);
                if (!RootReplaceable.Contains(level.Registry.Blocks.GetByStateId(state).Identifier)) {
                    continue;
                }

                level.SetState(x, y, z, RootStateProvider.GetState(level, random, x, y, z).StateId);
            }
        }
    }

    /// <summary>
    /// The roots hanging into the cave, each needing a sturdy ceiling directly above it.
    /// </summary>
    /// <remarks>
    /// Vanilla also asks the state's own <c>canSurvive</c> first, which for hanging roots is the same
    /// sturdy-ceiling test, so the pair is one condition.
    /// </remarks>
    private void PlaceHangingRoots(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        for (int attempt = 0; attempt < HangingRootPlacementAttempts; attempt++) {
            int x = origin.X + random.NextInt(HangingRootRadius) - random.NextInt(HangingRootRadius);
            int y = origin.Y + random.NextInt(HangingRootsVerticalSpan)
                - random.NextInt(HangingRootsVerticalSpan);
            int z = origin.Z + random.NextInt(HangingRootRadius) - random.NextInt(HangingRootRadius);

            if (!level.IsEmptyBlock(x, y, z)) {
                continue;
            }

            IBlock state = HangingRootStateProvider.GetState(level, random, x, y, z);
            IBlock above = level.Registry.Blocks.GetByStateId(level.GetState(x, y + 1, z));

            if (FeatureSurvival.CanSurvive(state, level, x, y, z)
                && ShapeSupport.IsFaceSturdy(above, BlockFace.NegY)) {

                level.SetState(x, y, z, state.StateId);
            }
        }
    }
}
