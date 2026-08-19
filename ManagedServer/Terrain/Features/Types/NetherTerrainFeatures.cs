using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>BasaltColumnsFeature</c>: the clusters of basalt spikes standing out of a delta's lava sea.
/// </summary>
/// <remarks>
/// Nine times in ten a cluster is tight and dense (50 columns within 5 blocks) and otherwise loose and
/// sparse (15 within 8), which is what makes deltas alternate between thickets and open lava.
/// <p/>
/// Height falls off with <b>manhattan</b> distance from the origin, so a cluster is a diamond in plan
/// and tapers to nothing at its corners.
/// </remarks>
public sealed record BasaltColumnsFeature(IIntProvider Reach, IIntProvider Height) : ConfiguredFeature {
    /// <summary>
    /// What a column will not stand on. Bedrock and lava are the floor and the sea; the rest are the
    /// pieces of a nether fortress, which a column growing through would ruin.
    /// </summary>
    private static readonly Identifier[] CannotPlaceOn = [
        "minecraft:lava", "minecraft:bedrock", "minecraft:magma_block", "minecraft:soul_sand",
        "minecraft:nether_bricks", "minecraft:nether_brick_fence", "minecraft:nether_brick_stairs",
        "minecraft:nether_wart", "minecraft:chest", "minecraft:spawner"
    ];

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;
        int lavaSeaLevel = level.SeaLevel;

        if (!CanPlaceAt(level, lavaSeaLevel, origin.X, origin.Y, origin.Z)) {
            return false;
        }

        int columnHeight = Height.Sample(random);
        bool clustered = random.NextFloat() < 0.9f;
        int spread = Math.Min(columnHeight, clustered ? 5 : 8);
        int count = clustered ? 50 : 15;

        bool placed = false;

        for (int i = 0; i < count; i++) {
            // Three draws per position even though the y range is a single value, because that is
            // what the box iterator does and the sequence has to match.
            int x = origin.X - spread + random.NextInt(spread * 2 + 1);
            int y = origin.Y + random.NextInt(1);
            int z = origin.Z - spread + random.NextInt(spread * 2 + 1);

            int remaining = columnHeight - Manhattan(x - origin.X, y - origin.Y, z - origin.Z);

            if (remaining >= 0) {
                placed |= PlaceColumn(level, lavaSeaLevel, x, y, z, remaining, Reach.Sample(random));
            }
        }

        return placed;
    }

    private static bool PlaceColumn(IFeatureLevel level, int lavaSeaLevel, int originX, int originY,
        int originZ, int columnHeight, int reach) {

        bool placedAny = false;

        for (int x = originX - reach; x <= originX + reach; x++) {
            for (int z = originZ - reach; z <= originZ + reach; z++) {
                int distance = Manhattan(x - originX, 0, z - originZ);

                // From open space the search goes down to the floor; from inside rock it goes up to
                // the first air. Either way it lands where a column can start.
                int? start = IsAirOrLavaOcean(level, lavaSeaLevel, x, originY, z)
                    ? FindSurface(level, lavaSeaLevel, x, originY, z, distance)
                    : FindAir(level, x, originY, z, distance);

                if (start is not { } startY) {
                    continue;
                }

                // Halved, so a column shortens more slowly across its own footprint than the cluster
                // does across itself.
                int blocks = columnHeight - distance / 2;
                int y = startY;

                for (; blocks >= 0; blocks--) {
                    if (IsAirOrLavaOcean(level, lavaSeaLevel, x, y, z)) {
                        level.SetState(x, y, z, Block.Basalt.StateId);
                        placedAny = true;
                    } else if (!level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier
                        .Equals(Block.Basalt.Identifier)) {

                        break;
                    }

                    y++;
                }
            }
        }

        return placedAny;
    }

    private static int? FindSurface(IFeatureLevel level, int lavaSeaLevel, int x, int y, int z, int limit) {
        while (y > level.MinY + 1 && limit > 0) {
            limit--;

            if (CanPlaceAt(level, lavaSeaLevel, x, y, z)) {
                return y;
            }

            y--;
        }

        return null;
    }

    private static int? FindAir(IFeatureLevel level, int x, int y, int z, int limit) {
        while (y <= level.MaxY && limit > 0) {
            limit--;

            IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

            if (CannotPlaceOn.Contains(block.Identifier)) {
                return null;
            }

            if (block.Air) {
                return y;
            }

            y++;
        }

        return null;
    }

    private static bool CanPlaceAt(IFeatureLevel level, int lavaSeaLevel, int x, int y, int z) {
        if (!IsAirOrLavaOcean(level, lavaSeaLevel, x, y, z)) {
            return false;
        }

        IBlock below = level.Registry.Blocks.GetByStateId(level.GetState(x, y - 1, z));
        return !below.Air && !CannotPlaceOn.Contains(below.Identifier);
    }

    /// <summary>
    /// Open space or the lava sea, which a column may stand in but not above: lava higher than the sea
    /// level is a pool sitting on something and is left alone.
    /// </summary>
    private static bool IsAirOrLavaOcean(IFeatureLevel level, int lavaSeaLevel, int x, int y, int z) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        return block.Air || (block.Identifier.Equals(Block.Lava.Identifier) && y <= lavaSeaLevel);
    }

    private static int Manhattan(int dx, int dy, int dz) {
        return Math.Abs(dx) + Math.Abs(dy) + Math.Abs(dz);
    }
}

/// <summary>
/// <c>DeltaFeature</c>: a patch of one block with a rim of another offset from it.
/// </summary>
/// <remarks>
/// The rim is the same patch drawn twice, once in place and once shifted by the rim size, so the rim
/// shows only on the sides the shift moved away from. That is why a basalt delta's magma patches have
/// blackstone along two edges and not all four.
/// <p/>
/// <c>isClear</c> is what keeps it on the floor: every neighbour must be solid <b>except</b> the one
/// above, which must be air. A position with air beside it is a wall or a ledge and is skipped.
/// </remarks>
public sealed record DeltaFeature(uint Contents, uint Rim, IIntProvider Size, IIntProvider RimSize)
    : ConfiguredFeature {

    private static readonly Identifier[] CannotReplace = [
        "minecraft:bedrock", "minecraft:nether_bricks", "minecraft:nether_brick_fence",
        "minecraft:nether_brick_stairs", "minecraft:nether_wart", "minecraft:chest", "minecraft:spawner"
    ];

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        bool spawnRim = random.NextDouble() < 0.9;
        int rimX = spawnRim ? RimSize.Sample(random) : 0;
        int rimZ = spawnRim ? RimSize.Sample(random) : 0;
        bool hasRim = spawnRim && rimX != 0 && rimZ != 0;

        int radiusX = Size.Sample(random);
        int radiusZ = Size.Sample(random);
        int limit = Math.Max(radiusX, radiusZ);

        bool anyPlaced = false;

        // Vanilla walks a manhattan iterator ordered by distance and stops past the limit, so the
        // positions reached are the box intersected with the diamond. Nothing in the body draws from
        // the random, so the set is the whole of what matters.
        for (int dx = -radiusX; dx <= radiusX; dx++) {
            for (int dz = -radiusZ; dz <= radiusZ; dz++) {
                if (Math.Abs(dx) + Math.Abs(dz) > limit) {
                    continue;
                }

                int x = origin.X + dx;
                int z = origin.Z + dz;

                if (!IsClear(level, x, origin.Y, z)) {
                    continue;
                }

                if (hasRim) {
                    anyPlaced = true;
                    level.SetState(x, origin.Y, z, Rim);
                }

                if (IsClear(level, x + rimX, origin.Y, z + rimZ)) {
                    anyPlaced = true;
                    level.SetState(x + rimX, origin.Y, z + rimZ, Contents);
                }
            }
        }

        return anyPlaced;
    }

    private bool IsClear(IFeatureLevel level, int x, int y, int z) {
        uint state = level.GetState(x, y, z);
        IBlock block = level.Registry.Blocks.GetByStateId(state);

        if (state == Contents || CannotReplace.Contains(block.Identifier)) {
            return false;
        }

        foreach (BlockFace face in FeatureUtil.AllDirections) {
            Vec3<int> step = Placement.PlacementParser.Step(face);
            bool isAir = level.IsAir(x + step.X, y + step.Y, z + step.Z);

            if (isAir != (face == BlockFace.PosY)) {
                return false;
            }
        }

        return true;
    }
}
