using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>BlockBlobFeature</c>: three overlapping lumps walked downhill from each other, which is what a
/// mossy cobblestone boulder in a taiga is.
/// </summary>
/// <remarks>
/// The three radii are drawn per lump and the walk between them is four more draws, so a blob costs
/// the same random whatever it lands on.
/// </remarks>
public sealed record BlockBlobFeature(uint State, BlockPredicate CanPlaceOn) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        while (origin.Y > level.MinY + 3 && !CanPlaceOn.Test(level, origin.X, origin.Y - 1, origin.Z)) {
            origin = origin.WithY(origin.Y - 1);
        }

        if (origin.Y <= level.MinY + 3) {
            return false;
        }

        for (int lump = 0; lump < 3; lump++) {
            int radiusX = random.NextInt(2);
            int radiusY = random.NextInt(2);
            int radiusZ = random.NextInt(2);

            // Float, and squared as a float before the comparison widens it. A third of the radii
            // plus a half, so a lump of radius zero is still a single block.
            float threshold = (radiusX + radiusY + radiusZ) * 0.333f + 0.5f;

            // Vanilla walks a box iterator here. Nothing in the body draws from the random, so only
            // which positions are covered matters, not the order they are reached in.
            for (int dx = -radiusX; dx <= radiusX; dx++) {
                for (int dy = -radiusY; dy <= radiusY; dy++) {
                    for (int dz = -radiusZ; dz <= radiusZ; dz++) {
                        if (dx * dx + dy * dy + dz * dz <= (double)(threshold * threshold)) {
                            level.SetState(origin.X + dx, origin.Y + dy, origin.Z + dz, State);
                        }
                    }
                }
            }

            origin = new Vec3<int>(origin.X - 1 + random.NextInt(2), origin.Y - random.NextInt(2),
                origin.Z - 1 + random.NextInt(2));
        }

        return true;
    }
}

/// <summary>
/// <c>ReplaceBlobsFeature</c>: a diamond of one block swapped for another, which is how blackstone
/// gets into the basalt deltas.
/// </summary>
/// <remarks>
/// The three radii are sampled separately and then the largest of them is the manhattan limit, so the
/// result is a diamond clipped by a box rather than either on its own.
/// </remarks>
public sealed record ReplaceBlobsFeature(Identifier Target, uint Replace, IIntProvider Radius)
    : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int startY = Math.Clamp(origin.Y, level.MinY + 1, level.MaxY);
        int? found = FindTarget(level, origin.X, startY, origin.Z);
        if (found is not { } centreY) {
            return false;
        }

        int radiusX = Radius.Sample(random);
        int radiusY = Radius.Sample(random);
        int radiusZ = Radius.Sample(random);
        int limit = Math.Max(radiusX, Math.Max(radiusY, radiusZ));

        bool replacedAny = false;

        // Vanilla walks a manhattan iterator ordered by distance and stops at the first position past
        // the limit, so the positions it reaches are the box intersected with the diamond. Nothing in
        // the body draws from the random, so the set is the whole of what matters.
        for (int dx = -radiusX; dx <= radiusX; dx++) {
            for (int dy = -radiusY; dy <= radiusY; dy++) {
                for (int dz = -radiusZ; dz <= radiusZ; dz++) {
                    if (Math.Abs(dx) + Math.Abs(dy) + Math.Abs(dz) > limit) {
                        continue;
                    }

                    int x = origin.X + dx;
                    int y = centreY + dy;
                    int z = origin.Z + dz;

                    if (!level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier
                        .Equals(Target)) {

                        continue;
                    }

                    level.SetState(x, y, z, Replace);
                    replacedAny = true;
                }
            }
        }

        return replacedAny;
    }

    private int? FindTarget(IFeatureLevel level, int x, int startY, int z) {
        for (int y = startY; y > level.MinY + 1; y--) {
            if (level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier.Equals(Target)) {
                return y;
            }
        }

        return null;
    }
}

/// <summary>
/// <c>GlowstoneFeature</c>: a blob hanging off a nether ceiling, grown one block at a time.
/// </summary>
/// <remarks>
/// The 1500 attempts are not a budget for 1500 blocks. Each one only lands where <b>exactly one</b>
/// neighbour is already glowstone, so the blob grows as a tendril rather than filling out, and most
/// attempts do nothing.
/// </remarks>
public sealed record GlowstoneFeature : ConfiguredFeature {
    public static readonly GlowstoneFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!level.IsEmptyBlock(origin.X, origin.Y, origin.Z)) {
            return false;
        }

        Identifier above = level.Registry.Blocks
            .GetByStateId(level.GetState(origin.X, origin.Y + 1, origin.Z)).Identifier;

        if (!above.Equals(Block.Netherrack.Identifier) && !above.Equals(Block.Basalt.Identifier)
            && !above.Equals(Block.Blackstone.Identifier)) {

            return false;
        }

        uint glowstone = Block.Glowstone.StateId;
        Identifier glowstoneId = Block.Glowstone.Identifier;

        level.SetState(origin.X, origin.Y, origin.Z, glowstone);

        for (int attempt = 0; attempt < 1500; attempt++) {
            int x = origin.X + random.NextInt(8) - random.NextInt(8);
            int y = origin.Y - random.NextInt(12);
            int z = origin.Z + random.NextInt(8) - random.NextInt(8);

            if (!level.Blocks.IsAir(level.GetState(x, y, z))) {
                continue;
            }

            int neighbours = 0;
            for (int face = 0; face < 6; face++) {
                Vec3<int> step = Placement.PlacementParser.Step((BlockFace)face);
                if (level.Registry.Blocks.GetByStateId(level.GetState(x + step.X, y + step.Y, z + step.Z))
                    .Identifier.Equals(glowstoneId)) {

                    neighbours++;
                }

                if (neighbours > 1) {
                    break;
                }
            }

            if (neighbours == 1) {
                level.SetState(x, y, z, glowstone);
            }
        }

        return true;
    }
}

/// <summary>
/// <c>BlueIceFeature</c>: a patch of blue ice grown out from packed ice under the sea.
/// </summary>
/// <remarks>
/// Grows the same way glowstone does, one block per attempt beside something already placed, but the
/// vertical spread is skewed: the offset is drawn as a difference of two ranges of different widths,
/// and the horizontal reach narrows with it, so a patch spreads sideways near its own level and
/// tapers going down.
/// </remarks>
public sealed record BlueIceFeature : ConfiguredFeature {
    public static readonly BlueIceFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (origin.Y > level.SeaLevel - 1) {
            return false;
        }

        if (!IsWater(level, origin.X, origin.Y, origin.Z)
            && !IsWater(level, origin.X, origin.Y - 1, origin.Z)) {

            return false;
        }

        Identifier packedIce = Block.PackedIce.Identifier;
        bool beside = false;

        for (int face = 0; face < 6; face++) {
            if ((BlockFace)face == BlockFace.NegY) {
                continue;
            }

            Vec3<int> step = Placement.PlacementParser.Step((BlockFace)face);
            if (Is(level, origin.X + step.X, origin.Y + step.Y, origin.Z + step.Z, packedIce)) {
                beside = true;
                break;
            }
        }

        if (!beside) {
            return false;
        }

        uint blueIce = Block.BlueIce.StateId;
        Identifier blueIceId = Block.BlueIce.Identifier;

        level.SetState(origin.X, origin.Y, origin.Z, blueIce);

        for (int attempt = 0; attempt < 200; attempt++) {
            int dy = random.NextInt(5) - random.NextInt(6);
            int reach = 3;

            if (dy < 2) {
                reach += dy / 2;
            }

            if (reach < 1) {
                continue;
            }

            int x = origin.X + random.NextInt(reach) - random.NextInt(reach);
            int y = origin.Y + dy;
            int z = origin.Z + random.NextInt(reach) - random.NextInt(reach);

            IBlock at = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
            if (!at.Air && !at.Identifier.Equals(Block.Water.Identifier)
                && !at.Identifier.Equals(packedIce) && !at.Identifier.Equals(Block.Ice.Identifier)) {

                continue;
            }

            for (int face = 0; face < 6; face++) {
                Vec3<int> step = Placement.PlacementParser.Step((BlockFace)face);
                if (Is(level, x + step.X, y + step.Y, z + step.Z, blueIceId)) {
                    level.SetState(x, y, z, blueIce);
                    break;
                }
            }
        }

        return true;
    }

    private static bool Is(IFeatureLevel level, int x, int y, int z, Identifier block) {
        return level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier.Equals(block);
    }

    private static bool IsWater(IFeatureLevel level, int x, int y, int z) {
        return Is(level, x, y, z, Block.Water.Identifier);
    }
}

/// <summary>
/// <c>SpikeFeature</c>: an ice spike, and the pillar of packed ice holding it up.
/// </summary>
/// <remarks>
/// The rare tall ones are the <c>nextInt(60)</c>: a wide spike is occasionally lifted ten to forty
/// blocks into the air, and the pillar below it is what reaches back to the ground.
/// <p/>
/// The pillar's floor is a literal <b>50</b>, not the sea level or the world bottom, so a spike over
/// deep terrain stops there rather than reaching the void.
/// </remarks>
public sealed record SpikeFeature(uint State, BlockPredicate CanPlaceOn, BlockPredicate CanReplace)
    : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        while (level.IsEmptyBlock(origin.X, origin.Y, origin.Z) && origin.Y > level.MinY + 2) {
            origin = origin.WithY(origin.Y - 1);
        }

        if (!CanPlaceOn.Test(level, origin.X, origin.Y, origin.Z)) {
            return false;
        }

        origin = origin.WithY(origin.Y + random.NextInt(4));

        int height = random.NextInt(4) + 7;
        int width = height / 4 + random.NextInt(2);

        if (width > 1 && random.NextInt(60) == 0) {
            origin = origin.WithY(origin.Y + 10 + random.NextInt(30));
        }

        for (int dy = 0; dy < height; dy++) {
            float scale = (1.0f - (float)dy / height) * width;
            int reach = (int)MathF.Ceiling(scale);

            for (int dx = -reach; dx <= reach; dx++) {
                float distX = MathF.Abs(dx) - 0.25f;

                for (int dz = -reach; dz <= reach; dz++) {
                    float distZ = MathF.Abs(dz) - 0.25f;

                    bool inside = (dx == 0 && dz == 0)
                        || !(distX * distX + distZ * distZ > scale * scale);

                    // The draw sits behind two short circuits and is reached by neither a position
                    // outside the ellipse nor one away from the ring's edge, so taking it every time
                    // consumes a number per position of the bounding square instead of per edge
                    // position and moves everything the feature does afterwards.
                    if (!inside) {
                        continue;
                    }

                    bool onEdge = dx == -reach || dx == reach || dz == -reach || dz == reach;

                    if (onEdge && random.NextFloat() > 0.75f) {
                        continue;
                    }

                    PlaceIfReplaceable(level, origin.X + dx, origin.Y + dy, origin.Z + dz);

                    if (dy != 0 && reach > 1) {
                        PlaceIfReplaceable(level, origin.X + dx, origin.Y - dy, origin.Z + dz);
                    }
                }
            }
        }

        int pillar = Math.Clamp(width - 1, 0, 1);

        for (int dx = -pillar; dx <= pillar; dx++) {
            for (int dz = -pillar; dz <= pillar; dz++) {
                int x = origin.X + dx;
                int z = origin.Z + dz;
                int y = origin.Y - 1;

                // A run of solid pillar, then a gap, then another run. The diagonals start with a
                // short run, which is what makes the base of a spike ragged rather than a column.
                int run = Math.Abs(dx) == 1 && Math.Abs(dz) == 1 ? random.NextInt(5) : 50;

                while (y > 50) {
                    uint state = level.GetState(x, y, z);

                    if (!level.Blocks.IsAir(state) && !CanReplace.Test(level, x, y, z) && state != State) {
                        break;
                    }

                    level.SetState(x, y, z, State);
                    y--;

                    if (--run <= 0) {
                        y -= random.NextInt(5) + 1;
                        run = random.NextInt(5);
                    }
                }
            }
        }

        return true;
    }

    private void PlaceIfReplaceable(IFeatureLevel level, int x, int y, int z) {
        if (level.Blocks.IsAir(level.GetState(x, y, z)) || CanReplace.Test(level, x, y, z)) {
            level.SetState(x, y, z, State);
        }
    }
}

/// <summary>
/// <c>BasaltPillarFeature</c>: a column of basalt hanging from a delta ceiling, with a spatter of
/// blocks stuck to its sides.
/// </summary>
/// <remarks>
/// The four side flags are the reason a pillar looks eroded. Each starts true and is cleared for good
/// by the first <c>nextInt(10) == 0</c> on that side, so a side stops gaining blocks partway down and
/// never resumes.
/// </remarks>
public sealed record BasaltPillarFeature : ConfiguredFeature {
    public static readonly BasaltPillarFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!level.IsEmptyBlock(origin.X, origin.Y, origin.Z)
            || level.IsEmptyBlock(origin.X, origin.Y + 1, origin.Z)) {

            return false;
        }

        uint basalt = Block.Basalt.StateId;

        bool north = true;
        bool south = true;
        bool west = true;
        bool east = true;

        int y = origin.Y;

        while (level.IsEmptyBlock(origin.X, y, origin.Z)) {
            if (!level.InWorld(y)) {
                return true;
            }

            level.SetState(origin.X, y, origin.Z, basalt);

            north = north && HangOff(level, random, origin.X, y, origin.Z - 1, basalt);
            south = south && HangOff(level, random, origin.X, y, origin.Z + 1, basalt);
            west = west && HangOff(level, random, origin.X - 1, y, origin.Z, basalt);
            east = east && HangOff(level, random, origin.X + 1, y, origin.Z, basalt);

            y--;
        }

        y++;

        BaseHangOff(level, random, origin.X, y, origin.Z - 1, basalt);
        BaseHangOff(level, random, origin.X, y, origin.Z + 1, basalt);
        BaseHangOff(level, random, origin.X - 1, y, origin.Z, basalt);
        BaseHangOff(level, random, origin.X + 1, y, origin.Z, basalt);

        y--;

        for (int dx = -3; dx < 4; dx++) {
            for (int dz = -3; dz < 4; dz++) {
                // The corners of the seven by seven are the least likely to be filled, which rounds
                // the foot of the pillar off.
                if (random.NextInt(10) >= 10 - Math.Abs(dx) * Math.Abs(dz)) {
                    continue;
                }

                int baseX = origin.X + dx;
                int baseY = y;
                int baseZ = origin.Z + dz;

                int drop = 3;
                while (level.IsEmptyBlock(baseX, baseY - 1, baseZ)) {
                    baseY--;
                    if (--drop <= 0) {
                        break;
                    }
                }

                if (!level.IsEmptyBlock(baseX, baseY - 1, baseZ)) {
                    level.SetState(baseX, baseY, baseZ, basalt);
                }
            }
        }

        return true;
    }

    private static void BaseHangOff(IFeatureLevel level, RandomSource random, int x, int y, int z,
        uint basalt) {

        if (random.NextBoolean()) {
            level.SetState(x, y, z, basalt);
        }
    }

    private static bool HangOff(IFeatureLevel level, RandomSource random, int x, int y, int z,
        uint basalt) {

        if (random.NextInt(10) == 0) {
            return false;
        }

        level.SetState(x, y, z, basalt);
        return true;
    }
}

/// <summary>
/// <c>UnderwaterMagmaFeature</c>: magma in the floor of an underwater cave, placed only where it
/// cannot be seen.
/// </summary>
/// <remarks>
/// The visibility test is the point of the feature and it is inverted from what it reads like: a
/// position is <b>rejected</b> if any horizontal neighbour or the block below it fails to occlude,
/// so magma only appears buried in the floor and the bubble column above it is the only sign.
/// </remarks>
public sealed record UnderwaterMagmaFeature(int FloorSearchRange, int PlacementRadiusAroundFloor,
    float PlacementProbabilityPerValidPosition) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int? floor = FindFloor(level, origin);
        if (floor is not { } floorY) {
            return false;
        }

        int radius = PlacementRadiusAroundFloor;
        bool placedAny = false;

        // The box is walked x fastest, then y, then z, and the probability is drawn per position, so
        // the order decides which positions get which draw.
        for (int z = origin.Z - radius; z <= origin.Z + radius; z++) {
            for (int y = floorY - radius; y <= floorY + radius; y++) {
                for (int x = origin.X - radius; x <= origin.X + radius; x++) {
                    if (!(random.NextFloat() < PlacementProbabilityPerValidPosition)) {
                        continue;
                    }

                    if (!IsValidPlacement(level, x, y, z)) {
                        continue;
                    }

                    level.SetState(x, y, z, Block.MagmaBlock.StateId);
                    placedAny = true;
                }
            }
        }

        return placedAny;
    }

    /// <summary>
    /// <c>Column.scan</c> downwards: the first position under the origin that is not water, provided
    /// the origin is water and the search reached an edge inside its range.
    /// </summary>
    private int? FindFloor(IFeatureLevel level, Vec3<int> origin) {
        if (!IsWater(level, origin.X, origin.Y, origin.Z)) {
            return null;
        }

        int y = origin.Y;
        for (int step = 1; step < FloorSearchRange && IsWater(level, origin.X, y, origin.Z); step++) {
            y--;
        }

        return IsWater(level, origin.X, y, origin.Z) ? null : y;
    }

    private static bool IsValidPlacement(IFeatureLevel level, int x, int y, int z) {
        if (IsWaterOrAir(level, x, y, z) || IsVisibleFromOutside(level, x, y - 1, z, BlockFace.PosY)) {
            return false;
        }

        for (int face = 2; face < 6; face++) {
            BlockFace direction = (BlockFace)face;
            Vec3<int> step = Placement.PlacementParser.Step(direction);

            if (IsVisibleFromOutside(level, x + step.X, y + step.Y, z + step.Z, direction.Opposite())) {
                return false;
            }
        }

        return true;
    }

    private static bool IsWaterOrAir(IFeatureLevel level, int x, int y, int z) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        return block.Air || block.Identifier.Equals(Block.Water.Identifier);
    }

    private static bool IsWater(IFeatureLevel level, int x, int y, int z) {
        return level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier
            .Equals(Block.Water.Identifier);
    }

    /// <summary>
    /// Whether the covered face of a block fails to occlude, so something behind it would be seen.
    /// </summary>
    private static bool IsVisibleFromOutside(IFeatureLevel level, int x, int y, int z, BlockFace covered) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        return !ShapeSupport.IsFaceFull(block.OcclusionShape, covered);
    }

}
