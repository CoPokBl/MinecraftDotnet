using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>ChunkGeneratorStructureState.generateRingPositions</c> and the <c>BiomeSource</c> search behind
/// it: where the strongholds go.
/// </summary>
/// <remarks>
/// The one placement that is not arithmetic. A concentric rings set works out its chunks <b>once for
/// the whole world</b>, by walking outwards in rings and looking for a preferred biome near each
/// point, and the placement test is then a lookup in that list. Everything else can answer "does a
/// structure start here" from the chunk position alone.
/// <p/>
/// It is not cheap: 128 strongholds, each searching a 57 by 57 grid of quart positions, is about
/// 416,000 climate samples. That is why it is computed lazily and kept, rather than being part of
/// building a generator.
/// </remarks>
public static class RingPositions {
    /// <summary>Vanilla's search radius around each candidate point, in blocks.</summary>
    private const int SearchRadius = 112;

    /// <summary>
    /// Works the whole ring out.
    /// </summary>
    /// <param name="seed">
    /// <c>concentricRingsSeed</c>, which <c>createForNormal</c> passes the world seed for.
    /// </param>
    /// <param name="biomes">The flattened climate lookup, at quart positions.</param>
    public static IReadOnlyList<Vec2<int>> Generate(ConcentricRingsStructurePlacement placement,
        long seed, BiomeAtQuart biomes) {

        if (placement.Count == 0) {
            return [];
        }

        // Every candidate and its forked random are worked out in order first, and only then are the
        // searches run. That is vanilla's own split, and it is what the fork is for: the draws are a
        // sequence and the searches are not, so the second half parallelises and the first cannot.
        (int ChunkX, int ChunkZ, RandomSource Search)[] candidates =
            new (int, int, RandomSource)[placement.Count];

        RandomSource random = new LegacyRandomSource(seed);
        double angle = random.NextDouble() * Math.PI * 2.0;

        int distance = placement.Distance;
        int spread = placement.Spread;
        int positionInCircle = 0;
        int circle = 0;

        for (int index = 0; index < placement.Count; index++) {
            // How far out this one sits: four cells, plus six per completed circle, plus a jitter of
            // up to a cell and a quarter either way.
            double radius = 4 * distance + distance * circle * 6
                + (random.NextDouble() - 0.5) * (distance * 2.5);

            int chunkX = (int)Math.Round(Math.Cos(angle) * radius);
            int chunkZ = (int)Math.Round(Math.Sin(angle) * radius);

            // Forked before the search, so each stronghold's tie breaking draws come from a stream of
            // its own and the searches do not have to run in order.
            candidates[index] = (chunkX, chunkZ, random.Fork());

            angle += Math.PI * 2 / spread;

            if (++positionInCircle != spread) {
                continue;
            }

            // A completed circle widens the next one and gives it a fresh starting angle, so the
            // rings are not spokes of one wheel.
            circle++;
            positionInCircle = 0;
            spread += 2 * spread / (circle + 1);
            spread = Math.Min(spread, placement.Count - index);
            angle += random.NextDouble() * Math.PI * 2.0;
        }

        Vec2<int>[] positions = new Vec2<int>[placement.Count];

        Parallel.For(0, placement.Count, index => {
            (int chunkX, int chunkZ, RandomSource search) = candidates[index];
            positions[index] = Search(chunkX, chunkZ, placement.PreferredBiomes, search, biomes);
        });

        return positions;
    }

    /// <summary>
    /// The nearest preferred biome to a candidate chunk, or the candidate itself where there is none
    /// within reach.
    /// </summary>
    private static Vec2<int> Search(int chunkX, int chunkZ, IReadOnlySet<Identifier> preferred,
        RandomSource random, BiomeAtQuart biomes) {

        // The middle of the candidate chunk, not its corner: vanilla's sectionToBlockCoord takes an
        // offset and this call passes eight.
        Vec3<int>? found = FindBiomeHorizontal((chunkX << 4) + 8, 0, (chunkZ << 4) + 8, SearchRadius,
            preferred, random, biomes);

        return found is { } position
            ? new Vec2<int>(position.X >> 4, position.Z >> 4)
            : new Vec2<int>(chunkX, chunkZ);
    }

    /// <summary>
    /// <c>BiomeSource.findBiomeHorizontal</c> with <c>findClosest</c> false, which is the only form
    /// the ring positions use.
    /// </summary>
    /// <remarks>
    /// <b>Not a spiral, despite the shape of the loop.</b> With <c>findClosest</c> false the walk
    /// starts at the <i>full</i> radius and steps by one, so it runs exactly once and scans the whole
    /// square. Reading it as an outward search and stopping at the first hit picks a different
    /// position every time.
    /// <p/>
    /// The choice among the hits is reservoir sampling: the nth match replaces the running answer with
    /// probability one in n, so every matching position is equally likely and the draw happens for
    /// each of them whether or not it wins.
    /// </remarks>
    private static Vec3<int>? FindBiomeHorizontal(int originX, int originY, int originZ, int radius,
        IReadOnlySet<Identifier> allowed, RandomSource random, BiomeAtQuart biomes) {

        int centerX = originX >> 2;
        int centerZ = originZ >> 2;
        int quartY = originY >> 2;
        int quartRadius = radius >> 2;

        Vec3<int>? result = null;
        int found = 0;

        for (int z = -quartRadius; z <= quartRadius; z++) {
            for (int x = -quartRadius; x <= quartRadius; x++) {
                int quartX = centerX + x;
                int quartZ = centerZ + z;

                if (!allowed.Contains(biomes(quartX, quartY, quartZ))) {
                    continue;
                }

                if (result is null || random.NextInt(found + 1) == 0) {
                    result = new Vec3<int>(quartX << 2, originY, quartZ << 2);
                }

                found++;
            }
        }

        return result;
    }
}
