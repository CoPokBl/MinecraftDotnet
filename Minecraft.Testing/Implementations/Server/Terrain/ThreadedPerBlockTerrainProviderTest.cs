using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Testing.Implementations.Server.Terrain;

/// <summary>
/// The threaded provider has to produce exactly what the single threaded one does.
/// </summary>
/// <remarks>
/// A <see cref="ChunkSection"/> converts between its packed and unpacked forms in place on first
/// access, so two threads writing the same section each build their own block array and the one
/// that stores last discards the other's writes. Nothing downstream notices — the chunk
/// serialises and decodes perfectly, it is just missing a rectangular block of terrain — so this
/// has to be caught by comparing against a known-good generation.
/// </remarks>
public class ThreadedPerBlockTerrainProviderTest {
    private const int WorldHeight = 384;

    /// <summary>Solid below a cone, air above, so most sections hold a mix.</summary>
    private static uint ConeBlock(int x, int y, int z) {
        return y >= (int)Math.Sqrt(x * x + z * z) ? 0u : 1u;
    }

    private class ThreadedCone : ThreadedPerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) => ConeBlock(x, y, z);
    }

    private class SingleThreadedCone : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) => ConeBlock(x, y, z);
    }

    [Test]
    public void ThreadedGenerationLosesNoBlocks() {
        ThreadedCone threaded = new();
        SingleThreadedCone single = new();

        // The loss depends on how the threads interleave, so one clean pass proves nothing.
        for (int attempt = 0; attempt < 10; attempt++) {
            foreach (int chunk in new[] { 0, 3, 10 }) {
                ChunkData actual = new(WorldHeight) { ChunkX = chunk, ChunkZ = chunk };
                ChunkData expected = new(WorldHeight) { ChunkX = chunk, ChunkZ = chunk };
                threaded.GetChunk(ref actual);
                single.GetChunk(ref expected);

                int mismatches = 0;
                for (int y = 0; y < WorldHeight; y++)
                for (int x = 0; x < ChunkSection.Size; x++)
                for (int z = 0; z < ChunkSection.Size; z++) {
                    if (actual.GetBlock(x, y, z) != expected.GetBlock(x, y, z)) {
                        mismatches++;
                    }
                }

                Assert.That(mismatches, Is.Zero,
                    $"attempt {attempt}, chunk ({chunk}, {chunk}): {mismatches} blocks differ from " +
                    "single threaded generation");
            }
        }
    }

    /// <summary>
    /// A world height that isn't a whole number of threads still has to be covered end to end.
    /// </summary>
    [Test]
    public void ThreadedGenerationCoversUnevenWorldHeights() {
        ThreadedCone threaded = new();
        SingleThreadedCone single = new();

        foreach (int height in new[] { 16, 64, 112, 320 }) {
            ChunkData actual = new(height) { ChunkX = 5, ChunkZ = 5 };
            ChunkData expected = new(height) { ChunkX = 5, ChunkZ = 5 };
            threaded.GetChunk(ref actual);
            single.GetChunk(ref expected);

            for (int y = 0; y < height; y++)
            for (int x = 0; x < ChunkSection.Size; x++)
            for (int z = 0; z < ChunkSection.Size; z++) {
                Assert.That(actual.GetBlock(x, y, z), Is.EqualTo(expected.GetBlock(x, y, z)),
                    $"height {height} at {x},{y},{z}");
            }
        }
    }
}
