using ManagedServer.Terrain.Features;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// The carving pass, vanilla's <c>NoiseBasedChunkGenerator.applyCarvers</c>.
/// </summary>
/// <remarks>
/// One per world, holding that world's seed and the shared carver data. Stateless per chunk, so
/// several chunks carve at once on the pool.
/// <p/>
/// <b>Every chunk within eight is replayed over this one.</b> A carver is a walk that starts in one
/// chunk and may run more than a hundred blocks, so the only way to know what reaches this chunk is to
/// run every walk that could. That is 289 source chunks, and it is not an approximation of anything
/// cheaper: a carver cannot write outside the chunk being generated, so a tunnel exists in this chunk
/// only if it is replayed here.
/// <p/>
/// The seeding is what makes that agree with itself. A source chunk's carver is seeded from the world
/// seed, that carver's index in the biome's list, and the source chunk position alone, so the tunnel
/// this chunk replays is bit for bit the one its own chunk cut, whichever order the two were generated
/// in and on however many threads.
/// <p/>
/// Runs after the surface pass and before the features, which is vanilla's chunk status order and not
/// a free choice: the fix-up that turns exposed dirt into a biome's top block has nothing to read
/// before the surface exists, and a tree placed before the carvers would be left hanging over the cave
/// that removed the ground under it.
/// </remarks>
public sealed class CarverSystem(VanillaCarverData data, MinecraftRegistry registry, long seed) {
    /// <summary>How many chunks out a carver may start and still reach this one.</summary>
    private const int Range = 8;

    /// <summary>
    /// Carves one chunk.
    /// </summary>
    /// <param name="chunk">The staging column the terrain and surface passes filled, read and written.</param>
    /// <param name="aquifer">
    /// The chunk's own aquifer, the same one the noise pass filled from. It decides what a carved
    /// position becomes, which is how a cave cut through an aquifer comes out flooded rather than open.
    /// </param>
    /// <param name="carverBiomeAt">
    /// The biome whose carver list a source chunk uses, sampled at that chunk's minimum corner at
    /// <b>y zero</b>. One sample decides the whole chunk's carvers, so a chunk straddling a biome
    /// border carves as whichever biome its corner is in.
    /// </param>
    /// <param name="topMaterial">The surface rules at one position, for the dirt a carve exposes.</param>
    public void Carve(ChunkColumn chunk, IAquifer aquifer, int chunkX, int chunkZ, int minY, int maxY,
        Func<int, int, Identifier> carverBiomeAt, CarvingContext.TopMaterialGetter topMaterial) {

        int genDepth = maxY - minY;

        CarvingMask mask = new(genDepth, minY);
        CarvingContext context = new(registry, chunk, mask, aquifer, chunkX, chunkZ, minY, genDepth,
            topMaterial);

        // One generator for the whole pass, reseeded before every carver it considers. Its own seed
        // never reaches anything, which is why upstream starts it from a genuinely random number.
        WorldgenRandom random = new(new LegacyRandomSource(0L));

        for (int dx = -Range; dx <= Range; dx++) {
            for (int dz = -Range; dz <= Range; dz++) {
                int sourceChunkX = chunkX + dx;
                int sourceChunkZ = chunkZ + dz;

                IReadOnlyList<ConfiguredWorldCarver> carvers =
                    data.For(carverBiomeAt(sourceChunkX, sourceChunkZ));

                for (int index = 0; index < carvers.Count; index++) {
                    random.SetLargeFeatureSeed(seed + index, sourceChunkX, sourceChunkZ);

                    if (carvers[index].IsStartChunk(random)) {
                        carvers[index].Carve(context, random, sourceChunkX, sourceChunkZ);
                    }
                }
            }
        }
    }
}
