using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>AbstractHugeMushroomFeature</c>: the stem and the clearance test both kinds of huge mushroom
/// share.
/// </summary>
/// <remarks>
/// The cap goes down <b>before</b> the stem, so a stem block never has to displace a cap block. Both
/// only write into air or something tagged replaceable by mushrooms, which is what lets one grow
/// through grass without eating the ground.
/// </remarks>
public abstract record HugeMushroomFeature(BlockStateProvider CapProvider, BlockStateProvider StemProvider,
    int FoliageRadius, BlockPredicate CanPlaceOn) : ConfiguredFeature {

    private static readonly Identifier ReplaceableByMushrooms = "minecraft:replaceable_by_mushrooms";
    private static readonly Identifier Leaves = "minecraft:leaves";

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int height = TreeHeight(random);

        if (!IsValidPosition(level, origin, height)) {
            return false;
        }

        MakeCap(level, random, origin, height);
        PlaceTrunk(level, random, origin, height);

        return true;
    }

    /// <summary>
    /// Four to six blocks, doubled one time in twelve. That rare doubling is the whole of why a huge
    /// mushroom is sometimes twice the height of the ones beside it.
    /// </summary>
    private static int TreeHeight(RandomSource random) {
        int height = random.NextInt(3) + 4;
        return random.NextInt(12) == 0 ? height * 2 : height;
    }

    /// <summary>
    /// Room for the whole mushroom, measured against the radius <see cref="TreeRadiusForHeight"/>
    /// gives each layer rather than against a box.
    /// </summary>
    /// <remarks>
    /// Leaves count as clearance, so a mushroom will grow up through a tree canopy and not through
    /// its trunk.
    /// </remarks>
    private bool IsValidPosition(IFeatureLevel level, Vec3<int> origin, int height) {
        if (origin.Y < level.MinY + 1 || origin.Y + height + 1 > level.MaxY) {
            return false;
        }

        if (!CanPlaceOn.Test(level, origin.X, origin.Y - 1, origin.Z)) {
            return false;
        }

        for (int dy = 0; dy <= height; dy++) {
            // Vanilla passes -1 for the tree height here, not the real one, and the two kinds answer
            // that very differently: the brown ignores it and clears its whole plate, while every
            // branch of the red's is written against a height it will never match, so the red clears
            // its trunk column and nothing else. That is what lets a red mushroom grow in a dark
            // forest at all, where a plate wide test would hit an oak trunk almost every time.
            int radius = TreeRadiusForHeight(FoliageRadius, dy, -1);

            for (int dx = -radius; dx <= radius; dx++) {
                for (int dz = -radius; dz <= radius; dz++) {
                    uint state = level.GetState(origin.X + dx, origin.Y + dy, origin.Z + dz);

                    if (!level.Blocks.IsAir(state) && !level.Blocks.IsIn(Leaves, state)) {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private void PlaceTrunk(IFeatureLevel level, RandomSource random, Vec3<int> origin, int height) {
        for (int dy = 0; dy < height; dy++) {
            // The provider is asked at the origin every time, not at the block being written, which
            // matters for a noise driven one.
            PlaceMushroomBlock(level, origin.X, origin.Y + dy, origin.Z,
                StemProvider.GetState(level, random, origin.X, origin.Y, origin.Z));
        }
    }

    protected void PlaceMushroomBlock(IFeatureLevel level, int x, int y, int z, IBlock state) {
        uint current = level.GetState(x, y, z);

        if (level.Blocks.IsAir(current) || level.Blocks.IsIn(ReplaceableByMushrooms, current)) {
            level.SetState(x, y, z, state.StateId);
        }
    }

    /// <summary>
    /// How wide the clearance test is at a given height. The two kinds differ only here and in the
    /// cap, which is what the split into subclasses is for.
    /// </summary>
    protected abstract int TreeRadiusForHeight(int leafRadius, int dy, int height);

    protected abstract void MakeCap(IFeatureLevel level, RandomSource random, Vec3<int> origin, int height);

    /// <summary>
    /// The four sides of a huge mushroom block, which is what decides where the cap texture wraps.
    /// </summary>
    /// <remarks>
    /// Vanilla guards this with <c>hasProperty</c> on all four, so a cap provider handing back
    /// something that is not a huge mushroom block is left alone rather than failing.
    /// </remarks>
    protected static IBlock WithSides(IBlock state, bool west, bool east, bool north, bool south,
        bool? up = null) {

        if (state is not IFaceConnected connected) {
            return state;
        }

        IBlock result = connected.WithConnection(BlockFace.NegX, west);
        result = ((IFaceConnected)result).WithConnection(BlockFace.PosX, east);
        result = ((IFaceConnected)result).WithConnection(BlockFace.NegZ, north);
        result = ((IFaceConnected)result).WithConnection(BlockFace.PosZ, south);

        return up is { } upValue ? ((IFaceConnected)result).WithConnection(BlockFace.PosY, upValue) : result;
    }
}

/// <summary>
/// <c>HugeBrownMushroomFeature</c>: the flat plate cap, one layer thick, with its corners cut off.
/// </summary>
public sealed record HugeBrownMushroomFeature(BlockStateProvider CapProvider,
    BlockStateProvider StemProvider, int FoliageRadius, BlockPredicate CanPlaceOn)
    : HugeMushroomFeature(CapProvider, StemProvider, FoliageRadius, CanPlaceOn) {

    /// <summary>Nothing but the stem for the first four blocks, then the full plate.</summary>
    protected override int TreeRadiusForHeight(int leafRadius, int dy, int height) {
        return dy <= 3 ? 0 : leafRadius;
    }

    protected override void MakeCap(IFeatureLevel level, RandomSource random, Vec3<int> origin, int height) {
        int radius = FoliageRadius;

        for (int dx = -radius; dx <= radius; dx++) {
            for (int dz = -radius; dz <= radius; dz++) {
                bool minX = dx == -radius;
                bool maxX = dx == radius;
                bool minZ = dz == -radius;
                bool maxZ = dz == radius;
                bool xEdge = minX || maxX;
                bool zEdge = minZ || maxZ;

                // The four corners are left out, which is what rounds the plate off.
                if (xEdge && zEdge) {
                    continue;
                }

                bool west = minX || (zEdge && dx == 1 - radius);
                bool east = maxX || (zEdge && dx == radius - 1);
                bool north = minZ || (xEdge && dz == 1 - radius);
                bool south = maxZ || (xEdge && dz == radius - 1);

                IBlock state = CapProvider.GetState(level, random, origin.X, origin.Y, origin.Z);

                PlaceMushroomBlock(level, origin.X + dx, origin.Y + height, origin.Z + dz,
                    WithSides(state, west, east, north, south));
            }
        }
    }
}

/// <summary>
/// <c>HugeRedMushroomFeature</c>: the domed cap, four layers of hollow ring topped by a solid disc.
/// </summary>
public sealed record HugeRedMushroomFeature(BlockStateProvider CapProvider,
    BlockStateProvider StemProvider, int FoliageRadius, BlockPredicate CanPlaceOn)
    : HugeMushroomFeature(CapProvider, StemProvider, FoliageRadius, CanPlaceOn) {

    /// <remarks>
    /// Transcribed branch for branch rather than folded into <c>dy &gt;= height - 3</c>, which is the
    /// same answer for a real height and the opposite one for the <b>-1</b> its only caller passes:
    /// every branch here needs <c>height</c> to be a height, so a negative one falls through to zero
    /// where the folded form answers the full radius.
    /// </remarks>
    protected override int TreeRadiusForHeight(int leafRadius, int dy, int height) {
        if (dy < height && dy >= height - 3) {
            return leafRadius;
        }

        return dy == height ? leafRadius : 0;
    }

    protected override void MakeCap(IFeatureLevel level, RandomSource random, Vec3<int> origin, int height) {
        for (int dy = height - 3; dy <= height; dy++) {
            // The top layer is a block narrower, which is what turns the cylinder into a dome.
            int radius = dy < height ? FoliageRadius : FoliageRadius - 1;
            int centre = FoliageRadius - 2;

            for (int dx = -radius; dx <= radius; dx++) {
                for (int dz = -radius; dz <= radius; dz++) {
                    bool minX = dx == -radius;
                    bool maxX = dx == radius;
                    bool minZ = dz == -radius;
                    bool maxZ = dz == radius;
                    bool xEdge = minX || maxX;
                    bool zEdge = minZ || maxZ;

                    // Below the top the layers are hollow rings with the corners left out, so only
                    // the sides of the dome are drawn; the top layer is filled solid.
                    if (dy < height && xEdge == zEdge) {
                        continue;
                    }

                    IBlock state = CapProvider.GetState(level, random, origin.X, origin.Y, origin.Z);

                    PlaceMushroomBlock(level, origin.X + dx, origin.Y + dy, origin.Z + dz,
                        WithSides(state, dx < -centre, dx > centre, dz < -centre, dz > centre,
                            dy >= height - 1));
                }
            }
        }
    }
}
