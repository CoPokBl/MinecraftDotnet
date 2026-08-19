using ManagedServer.Terrain;
using ManagedServer.Terrain.Structures;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.Worldgen;

/// <summary>
/// Finds the nearest position holding a given biome, and the nearest chunk a given structure starts
/// in, so the demo can be taken to one to look at.
/// </summary>
/// <remarks>
/// <b>The demo's own search rather than a port of <c>/locate</c>.</b> Vanilla's
/// <c>BiomeSource.findClosestBiome3d</c> and <c>ChunkGenerator.findNearestMapStructure</c> return the
/// first hit in a spiral, which is nearest only to within a ring; this takes the nearest hit of the
/// first ring that has one. Nothing about a generated world depends on either answer, so the two are
/// interchangeable for the thing this is for, which is standing next to what the pass built.
/// <p/>
/// Both searches are cheap enough to be worth running honestly and far too slow for the tick thread:
/// the structure one builds a piece tree per candidate chunk, and the first ask for a stronghold pays
/// for the whole world's ring positions. A caller runs them off the tick and comes back.
/// </remarks>
public static class WorldgenSearch {
    /// <summary>
    /// How far apart columns are sampled, in blocks. Vanilla's <c>/locate biome</c> uses the same, and
    /// it is four quart cells, so a biome smaller than that can be stepped over.
    /// </summary>
    private const int BiomeSampleStep = 32;

    /// <summary>Vertical sampling, which is what finds a biome that only exists in caves.</summary>
    private const int BiomeSampleHeight = 64;

    public sealed record BiomeHit(Identifier Biome, Vec3<int> Position, int Distance);

    public sealed record StructureHit(Identifier Structure, StructureStart Start, Vec3<int> Position,
        int Distance);

    /// <summary>
    /// The nearest position the climate names as the wanted biome, or null within the radius.
    /// </summary>
    /// <remarks>
    /// This is the grid a chunk stores rather than what a player standing there is told: the client
    /// reads it back through <c>BiomeZoom</c>, whose jitter can move a border by a couple of blocks.
    /// <p/>
    /// The y candidates are ordered by distance from <b>sea level</b> where vanilla orders them from
    /// the caller's own y. The climate sample depends on y, so a player flying at 200 asking vanilla
    /// gets whatever the table names that high up; ordering from sea level answers about the ground,
    /// which is what someone looking for a biome means.
    /// </remarks>
    public static BiomeHit? FindBiome(VanillaTerrainGenerator generator, Identifier biome,
        int originX, int originZ, int maxRadius) {

        NoiseSettings noise = generator.Settings.NoiseSettings;

        int[] sampleYs = SampleHeights(noise, generator.SeaLevel);
        int rings = maxRadius / BiomeSampleStep;

        for (int ring = 0; ring <= rings; ring++) {
            BiomeHit? best = null;

            foreach ((int stepX, int stepZ) in Ring(ring)) {
                int blockX = originX + stepX * BiomeSampleStep;
                int blockZ = originZ + stepZ * BiomeSampleStep;

                foreach (int blockY in sampleYs) {
                    if (generator.BiomeAt(blockX >> 2, blockY >> 2, blockZ >> 2) != biome) {
                        continue;
                    }

                    int distance = Distance(originX, originZ, blockX, blockZ);

                    if (best is null || distance < best.Distance) {
                        best = new BiomeHit(biome, new Vec3<int>(blockX, blockY, blockZ), distance);
                    }

                    break;
                }
            }

            if (best is not null) {
                return best;
            }
        }

        return null;
    }

    /// <summary>
    /// The nearest chunk the wanted structure starts in, or null within the radius.
    /// </summary>
    /// <remarks>
    /// The candidates come off the <b>placement</b>, never off a scan of every chunk: a set with a
    /// spacing of 32 puts one structure in each 1024 chunk cell, so asking each cell where its one
    /// candidate is turns a search of millions of chunks into a search of hundreds.
    /// <p/>
    /// A candidate still has to be generated to be checked, because a chunk the placement picked is
    /// one the structure may yet decline: the frequency roll, the biome list and a structure's own
    /// conditions all come after it. A set with several entries may also answer with a different one
    /// of them, which is why the answer is filtered by structure rather than taken whole.
    /// </remarks>
    public static StructureHit? FindStructure(VanillaTerrainGenerator generator, Identifier structure,
        int originX, int originZ, int maxRings) {

        StructureSystem? pass = generator.StructurePass;

        // A structure the pass skipped has no instance, so nothing can match it. That is the answer
        // for every structure built from an NBT template.
        if (pass is null || !pass.Data.Structures.TryGetValue(structure, out Structure? wanted)) {
            return null;
        }

        StructureHit? best = null;

        foreach (StructureSet set in pass.Data.Sets.Values) {
            if (set.Structures.All(entry => entry.Structure != structure)) {
                continue;
            }

            StructureHit? found = set.Placement switch {
                ConcentricRingsStructurePlacement rings =>
                    SearchRings(generator, pass, structure, wanted, rings, originX, originZ),
                RandomSpreadStructurePlacement spread =>
                    SearchSpread(generator, structure, wanted, spread, originX, originZ, maxRings),
                _ => null
            };

            if (found is not null && (best is null || found.Distance < best.Distance)) {
                best = found;
            }
        }

        return best;
    }

    /// <summary>
    /// The stronghold's search: its positions are known for the whole world, so this is a scan of a
    /// list rather than a walk outwards.
    /// </summary>
    /// <remarks>
    /// A ring position is where a stronghold was <b>allowed</b> to start, and the structure is still
    /// asked whether it did, so a position whose biome search landed somewhere it declines is skipped
    /// rather than reported as a stronghold that is not there.
    /// <p/>
    /// Ordered by the middle of the candidate chunk, which is vanilla's comparison point, so the first
    /// position that generates is the nearest one that does.
    /// </remarks>
    private static StructureHit? SearchRings(VanillaTerrainGenerator generator, StructureSystem pass,
        Identifier structure, Structure wanted, ConcentricRingsStructurePlacement rings, int originX,
        int originZ) {

        return pass.RingPositionsFor(rings)
            .OrderBy(chunk => Distance(originX, originZ, (chunk.X << 4) + 8, (chunk.Y << 4) + 8))
            .Select(chunk => HitAt(generator, structure, wanted, chunk.X, chunk.Y, originX, originZ))
            .FirstOrDefault(hit => hit is not null);
    }

    /// <summary>
    /// The grid search: one candidate chunk per cell of the placement, walked outwards a ring of cells
    /// at a time.
    /// </summary>
    private static StructureHit? SearchSpread(VanillaTerrainGenerator generator, Identifier structure,
        Structure wanted, RandomSpreadStructurePlacement spread, int originX, int originZ,
        int maxRings) {

        int originChunkX = originX >> 4;
        int originChunkZ = originZ >> 4;

        for (int ring = 0; ring <= maxRings; ring++) {
            StructureHit? best = null;

            foreach ((int cellX, int cellZ) in Ring(ring)) {
                Vec2<int> candidate = spread.PotentialStructureChunk(generator.Seed,
                    originChunkX + spread.Spacing * cellX, originChunkZ + spread.Spacing * cellZ);

                StructureHit? hit = HitAt(generator, structure, wanted, candidate.X, candidate.Y,
                    originX, originZ);

                if (hit is not null && (best is null || hit.Distance < best.Distance)) {
                    best = hit;
                }
            }

            if (best is not null) {
                return best;
            }
        }

        return null;
    }

    /// <summary>The wanted structure's start in one chunk, if that is what starts there.</summary>
    private static StructureHit? HitAt(VanillaTerrainGenerator generator, Identifier structure,
        Structure wanted, int chunkX, int chunkZ, int originX, int originZ) {

        foreach (StructureStart start in generator.StructureStartsAt(chunkX, chunkZ)) {
            if (!ReferenceEquals(start.Structure, wanted)) {
                continue;
            }

            // The middle of the first piece at its floor, which is the reference every chunk the
            // structure spans agrees on, rather than the middle of a box whose corners are on
            // different pieces.
            BoundingBox first = start.Pieces[0].BoundingBox;
            Vec3<int> center = first.Center;
            Vec3<int> position = new(center.X, first.MinY, center.Z);

            return new StructureHit(structure, start, position,
                Distance(originX, originZ, position.X, position.Z));
        }

        return null;
    }

    /// <summary>
    /// The world's y range at the vertical sampling, ordered by distance from sea level.
    /// </summary>
    private static int[] SampleHeights(NoiseSettings noise, int seaLevel) {
        List<int> heights = [];

        for (int y = noise.MinY + 1; y < noise.MinY + noise.Height; y += BiomeSampleHeight) {
            heights.Add(y);
        }

        heights.Sort((a, b) => Math.Abs(a - seaLevel).CompareTo(Math.Abs(b - seaLevel)));
        return heights.ToArray();
    }

    /// <summary>The cells exactly <paramref name="ring"/> steps out, which is the square's edge.</summary>
    private static IEnumerable<(int X, int Z)> Ring(int ring) {
        if (ring == 0) {
            yield return (0, 0);
            yield break;
        }

        for (int x = -ring; x <= ring; x++) {
            bool xEdge = x == -ring || x == ring;

            for (int z = -ring; z <= ring; z++) {
                if (xEdge || z == -ring || z == ring) {
                    yield return (x, z);
                }
            }
        }
    }

    private static int Distance(int originX, int originZ, int x, int z) {
        long dx = x - originX;
        long dz = z - originZ;

        return (int)Math.Sqrt(dx * dx + dz * dz);
    }
}
