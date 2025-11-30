using System.Collections.Concurrent;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// A terrain generator that uses a lambda/delegate for generation.
/// This provides a convenient way to create terrain generators without
/// implementing the full interface.
/// </summary>
/// <example>
/// <code>
/// var generator = new LambdaTerrainGenerator(unit => {
///     var start = unit.AbsoluteStart();
///     
///     // Create a snow carpet
///     unit.Modifier().FillHeight(-64, -60, Block.Snow);
///     
///     // Fork to add a tall structure
///     var fork = unit.Fork(start, start + new Vec3&lt;int&gt;(16, 32, 16));
///     fork.Modifier().Fill(start, start + new Vec3&lt;int&gt;(3, 19, 3), Block.PowderSnow);
/// });
/// </code>
/// </example>
public class LambdaTerrainGenerator : ITerrainGenerator {
    private readonly Action<IGenerationUnit> _generator;
    private readonly ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> _pendingForkModifications = new();

    /// <inheritdoc />
    public int MinY { get; }

    /// <summary>
    /// Creates a new LambdaTerrainGenerator with the specified generation action.
    /// </summary>
    /// <param name="generator">The action that generates terrain for a generation unit.</param>
    /// <param name="minY">The minimum Y coordinate of the world (default: -64 for vanilla overworld).</param>
    public LambdaTerrainGenerator(Action<IGenerationUnit> generator, int minY = -64) {
        _generator = generator;
        MinY = minY;
    }

    /// <inheritdoc />
    public void Generate(IGenerationUnit unit) {
        _generator(unit);
    }

    /// <inheritdoc />
    public void GetChunk(ref ChunkData chunk) {
        Vec2<int> chunkPos = new(chunk.ChunkX, chunk.ChunkZ);

        // Create a generation unit for this chunk
        GenerationUnit unit = new(chunk, MinY, _pendingForkModifications);

        // Run the generator
        Generate(unit);

        // Apply any pending fork modifications for this chunk
        ApplyPendingModifications(chunk, chunkPos);
    }

    /// <inheritdoc />
    public void GetChunks(int start, int count, ChunkData[] chunks) {
        // Create a multi-chunk generation unit that spans all the chunks
        MultiChunkGenerationUnit unit = new(chunks, start, count, MinY, _pendingForkModifications);

        // Run the generator once for all chunks
        Generate(unit);

        // Apply any pending fork modifications for these chunks
        for (int i = start; i < start + count; i++) {
            Vec2<int> chunkPos = new(chunks[i].ChunkX, chunks[i].ChunkZ);
            ApplyPendingModifications(chunks[i], chunkPos);
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
