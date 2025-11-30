using System.Collections.Concurrent;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Represents a generation unit for a single chunk.
/// Provides methods to modify blocks and fork for cross-boundary modifications.
/// </summary>
public class GenerationUnit : IGenerationUnit {
    private readonly ChunkData _chunk;
    private readonly int _minY;
    private readonly IGenerationModifier _modifier;
    private readonly ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> _pendingForkModifications;

    /// <summary>
    /// Creates a new GenerationUnit for a single chunk.
    /// </summary>
    /// <param name="chunk">The chunk data to modify.</param>
    /// <param name="minY">The minimum Y coordinate of the world (e.g., -64 for vanilla overworld).</param>
    /// <param name="pendingForkModifications">Shared dictionary for storing pending fork modifications across chunks.</param>
    public GenerationUnit(ChunkData chunk, int minY, ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pendingForkModifications) {
        _chunk = chunk;
        _minY = minY;
        _modifier = new ChunkGenerationModifier(chunk, minY);
        _pendingForkModifications = pendingForkModifications;
    }

    /// <inheritdoc />
    public Vec3<int> AbsoluteStart() {
        return new Vec3<int>(
            _chunk.ChunkX * ChunkSection.Size,
            _minY,
            _chunk.ChunkZ * ChunkSection.Size
        );
    }

    /// <inheritdoc />
    public Vec3<int> AbsoluteEnd() {
        return new Vec3<int>(
            (_chunk.ChunkX + 1) * ChunkSection.Size,
            _minY + _chunk.WorldHeight,
            (_chunk.ChunkZ + 1) * ChunkSection.Size
        );
    }

    /// <inheritdoc />
    public IGenerationModifier Modifier() {
        return _modifier;
    }

    /// <inheritdoc />
    public IGenerationUnit Fork(Vec3<int> start, Vec3<int> end) {
        return new ForkedGenerationUnit(start, end, _minY, _chunk.WorldHeight, _chunk, _pendingForkModifications);
    }
}

/// <summary>
/// A forked generation unit that can span across multiple chunks.
/// Modifications are queued and applied when chunks are generated.
/// </summary>
public class ForkedGenerationUnit : IGenerationUnit {
    private readonly Vec3<int> _start;
    private readonly Vec3<int> _end;
    private readonly int _minY;
    private readonly int _worldHeight;
    private readonly ChunkData _originChunk;
    private readonly ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> _pendingModifications;
    private readonly ForkedGenerationModifier _modifier;

    internal ForkedGenerationUnit(
        Vec3<int> start, 
        Vec3<int> end, 
        int minY,
        int worldHeight,
        ChunkData originChunk, 
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pendingModifications) {
        _start = start;
        _end = end;
        _minY = minY;
        _worldHeight = worldHeight;
        _originChunk = originChunk;
        _pendingModifications = pendingModifications;
        _modifier = new ForkedGenerationModifier(this);
    }

    /// <inheritdoc />
    public Vec3<int> AbsoluteStart() => _start;

    /// <inheritdoc />
    public Vec3<int> AbsoluteEnd() => _end;

    /// <inheritdoc />
    public IGenerationModifier Modifier() => _modifier;

    /// <inheritdoc />
    public IGenerationUnit Fork(Vec3<int> start, Vec3<int> end) {
        // Nested forks reuse the same pending modifications dictionary
        return new ForkedGenerationUnit(start, end, _minY, _worldHeight, _originChunk, _pendingModifications);
    }

    /// <summary>
    /// Applies a modification to all affected chunks.
    /// If the chunk is the origin chunk, it applies immediately.
    /// Otherwise, it queues the modification for later application.
    /// </summary>
    internal void ApplyModification(Action<ChunkData, int> modification) {
        // Calculate which chunks are affected using integer division
        // For negative numbers, we need floor division, not truncation
        int startChunkX = _start.X >= 0 ? _start.X / ChunkSection.Size : (_start.X - ChunkSection.Size + 1) / ChunkSection.Size;
        int startChunkZ = _start.Z >= 0 ? _start.Z / ChunkSection.Size : (_start.Z - ChunkSection.Size + 1) / ChunkSection.Size;
        // For end, we need ceiling division
        int endChunkX = _end.X > 0 ? (_end.X + ChunkSection.Size - 1) / ChunkSection.Size : _end.X / ChunkSection.Size;
        int endChunkZ = _end.Z > 0 ? (_end.Z + ChunkSection.Size - 1) / ChunkSection.Size : _end.Z / ChunkSection.Size;

        for (int cx = startChunkX; cx < endChunkX; cx++) {
            for (int cz = startChunkZ; cz < endChunkZ; cz++) {
                Vec2<int> chunkPos = new(cx, cz);
                
                if (cx == _originChunk.ChunkX && cz == _originChunk.ChunkZ) {
                    // Apply immediately to the origin chunk
                    modification(_originChunk, _minY);
                }
                else {
                    // Queue for later application
                    List<Action<ChunkData>> actions = _pendingModifications.GetOrAdd(chunkPos, _ => []);
                    lock (actions) {
                        actions.Add(chunk => modification(chunk, _minY));
                    }
                }
            }
        }
    }
}

/// <summary>
/// A modifier for forked generation units that applies changes across multiple chunks.
/// </summary>
internal class ForkedGenerationModifier : IGenerationModifier {
    private readonly ForkedGenerationUnit _unit;

    public ForkedGenerationModifier(ForkedGenerationUnit unit) {
        _unit = unit;
    }

    public void SetBlock(Vec3<int> position, IBlock block) {
        _unit.ApplyModification((chunk, minY) => {
            ChunkGenerationModifier modifier = new(chunk, minY);
            modifier.SetBlock(position, block);
        });
    }

    public void Fill(Vec3<int> start, Vec3<int> end, IBlock block) {
        _unit.ApplyModification((chunk, minY) => {
            ChunkGenerationModifier modifier = new(chunk, minY);
            modifier.Fill(start, end, block);
        });
    }

    public void FillHeight(int minY, int maxY, IBlock block) {
        Vec3<int> start = _unit.AbsoluteStart();
        Vec3<int> end = _unit.AbsoluteEnd();
        Fill(new Vec3<int>(start.X, minY, start.Z), new Vec3<int>(end.X, maxY, end.Z), block);
    }
}
