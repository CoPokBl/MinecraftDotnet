using System.Collections.Concurrent;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain.Providers;

/// <summary>
/// A terrain provider that wraps an <see cref="ITerrainGenerator"/>.
/// This allows using the higher-level GenerationUnit API with the existing
/// terrain provider infrastructure.
/// </summary>
/// <remarks>
/// This provider handles pending fork modifications by applying them when chunks are generated.
/// Fork modifications that target chunks not yet generated are stored and applied later.
/// </remarks>
public class GeneratorTerrainProvider : ITerrainProvider {
    private readonly ITerrainGenerator _generator;
    private readonly int _minY;
    private readonly ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> _pendingForkModifications = new();

    /// <summary>
    /// Creates a new GeneratorTerrainProvider.
    /// </summary>
    /// <param name="generator">The terrain generator to use.</param>
    /// <param name="minY">The minimum Y coordinate of the world (default: -64 for vanilla overworld).</param>
    public GeneratorTerrainProvider(ITerrainGenerator generator, int minY = -64) {
        _generator = generator;
        _minY = minY;
    }

    /// <summary>
    /// Creates a new GeneratorTerrainProvider with a lambda generator.
    /// </summary>
    /// <param name="generator">The generation action.</param>
    /// <param name="minY">The minimum Y coordinate of the world (default: -64 for vanilla overworld).</param>
    public GeneratorTerrainProvider(Action<IGenerationUnit> generator, int minY = -64)
        : this(new LambdaTerrainGenerator(generator), minY) {
    }

    /// <inheritdoc />
    public void GetChunk(ref ChunkData chunk) {
        Vec2<int> chunkPos = new(chunk.ChunkX, chunk.ChunkZ);

        // Create a generation unit for this chunk
        GenerationUnit unit = new(chunk, _minY, _pendingForkModifications);

        // Run the generator
        _generator.Generate(unit);

        // Apply any pending fork modifications for this chunk
        ApplyPendingModifications(chunk, chunkPos);
    }

    /// <inheritdoc />
    public void GetChunks(int start, int count, ChunkData[] chunks) {
        for (int i = start; i < start + count; i++) {
            GetChunk(ref chunks[i]);
        }
    }

    private void ApplyPendingModifications(ChunkData chunk, Vec2<int> chunkPos) {
        if (!_pendingForkModifications.TryRemove(chunkPos, out List<Action<ChunkData>>? actions)) {
            return;
        }

        lock (actions) {
            foreach (Action<ChunkData> action in actions) {
                action(chunk);
            }
        }
    }
}
