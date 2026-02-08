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
        ChunkData[] singleChunkArray = [_chunk];
        return new ForkedGenerationUnit(start, end, _minY, _chunk.WorldHeight, singleChunkArray, 0, 1, _pendingForkModifications);
    }

    /// <inheritdoc />
    public void Fork(Action<IBlockSetter> setter) {
        ChunkData[] singleChunkArray = [_chunk];
        AutoExpandingBlockSetter blockSetter = new(singleChunkArray, 0, 1, _minY, _chunk.WorldHeight, _pendingForkModifications);
        setter(blockSetter);
        blockSetter.Apply();
    }
}

/// <summary>
/// Represents a generation unit that spans multiple chunks.
/// Created when GetChunks is called with multiple chunks at once.
/// </summary>
public class MultiChunkGenerationUnit : IGenerationUnit {
    private readonly ChunkData[] _chunks;
    private readonly int _startIndex;
    private readonly int _count;
    private readonly int _minY;
    private readonly IGenerationModifier _modifier;
    private readonly ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> _pendingForkModifications;

    /// <summary>
    /// Creates a new MultiChunkGenerationUnit spanning multiple chunks.
    /// </summary>
    public MultiChunkGenerationUnit(ChunkData[] chunks, int startIndex, int count, int minY, 
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pendingForkModifications) {
        _chunks = chunks;
        _startIndex = startIndex;
        _count = count;
        _minY = minY;
        _pendingForkModifications = pendingForkModifications;
        _modifier = new MultiChunkGenerationModifier(chunks, startIndex, count, minY);
    }

    /// <inheritdoc />
    public Vec3<int> AbsoluteStart() {
        int minX = int.MaxValue;
        int minZ = int.MaxValue;
        
        for (int i = _startIndex; i < _startIndex + _count; i++) {
            minX = Math.Min(minX, _chunks[i].ChunkX);
            minZ = Math.Min(minZ, _chunks[i].ChunkZ);
        }
        
        return new Vec3<int>(
            minX * ChunkSection.Size,
            _minY,
            minZ * ChunkSection.Size
        );
    }

    /// <inheritdoc />
    public Vec3<int> AbsoluteEnd() {
        int maxX = int.MinValue;
        int maxZ = int.MinValue;
        int worldHeight = _chunks[_startIndex].WorldHeight;
        
        for (int i = _startIndex; i < _startIndex + _count; i++) {
            maxX = Math.Max(maxX, _chunks[i].ChunkX);
            maxZ = Math.Max(maxZ, _chunks[i].ChunkZ);
        }
        
        return new Vec3<int>(
            (maxX + 1) * ChunkSection.Size,
            _minY + worldHeight,
            (maxZ + 1) * ChunkSection.Size
        );
    }

    /// <inheritdoc />
    public IGenerationModifier Modifier() {
        return _modifier;
    }

    /// <inheritdoc />
    public IGenerationUnit Fork(Vec3<int> start, Vec3<int> end) {
        return new ForkedGenerationUnit(start, end, _minY, _chunks[_startIndex].WorldHeight, _chunks, _startIndex, _count, _pendingForkModifications);
    }

    /// <inheritdoc />
    public void Fork(Action<IBlockSetter> setter) {
        AutoExpandingBlockSetter blockSetter = new(_chunks, _startIndex, _count, _minY, _chunks[_startIndex].WorldHeight, _pendingForkModifications);
        setter(blockSetter);
        blockSetter.Apply();
    }
}

/// <summary>
/// A modifier for multi-chunk generation units that applies changes across multiple chunks.
/// </summary>
internal class MultiChunkGenerationModifier : IGenerationModifier {
    private readonly ChunkData[] _chunks;
    private readonly int _startIndex;
    private readonly int _count;
    private readonly int _minY;
    private readonly ChunkGenerationModifier[] _cachedModifiers;

    public MultiChunkGenerationModifier(ChunkData[] chunks, int startIndex, int count, int minY) {
        _chunks = chunks;
        _startIndex = startIndex;
        _count = count;
        _minY = minY;
        _cachedModifiers = new ChunkGenerationModifier[count];
        for (int i = 0; i < count; i++) {
            _cachedModifiers[i] = new ChunkGenerationModifier(chunks[startIndex + i], minY);
        }
    }

    public void SetBlock(Vec3<int> position, IBlock block) {
        for (int i = 0; i < _count; i++) {
            _cachedModifiers[i].SetBlock(position, block);
        }
    }

    public void Fill(Vec3<int> start, Vec3<int> end, IBlock block) {
        for (int i = 0; i < _count; i++) {
            _cachedModifiers[i].Fill(start, end, block);
        }
    }

    public void FillHeight(int minY, int maxY, IBlock block) {
        for (int i = 0; i < _count; i++) {
            int chunkAbsoluteX = _chunks[_startIndex + i].ChunkX * ChunkSection.Size;
            int chunkAbsoluteZ = _chunks[_startIndex + i].ChunkZ * ChunkSection.Size;
            _cachedModifiers[i].Fill(
                new Vec3<int>(chunkAbsoluteX, minY, chunkAbsoluteZ),
                new Vec3<int>(chunkAbsoluteX + ChunkSection.Size, maxY, chunkAbsoluteZ + ChunkSection.Size),
                block
            );
        }
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
    private readonly ChunkData[] _originChunks;
    private readonly int _originStartIndex;
    private readonly int _originCount;
    private readonly ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> _pendingModifications;
    private readonly ForkedGenerationModifier _modifier;

    internal ForkedGenerationUnit(
        Vec3<int> start, 
        Vec3<int> end, 
        int minY,
        int worldHeight,
        ChunkData[] originChunks,
        int originStartIndex,
        int originCount,
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pendingModifications) {
        _start = start;
        _end = end;
        _minY = minY;
        _worldHeight = worldHeight;
        _originChunks = originChunks;
        _originStartIndex = originStartIndex;
        _originCount = originCount;
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
        return new ForkedGenerationUnit(start, end, _minY, _worldHeight, _originChunks, _originStartIndex, _originCount, _pendingModifications);
    }

    /// <inheritdoc />
    public void Fork(Action<IBlockSetter> setter) {
        AutoExpandingBlockSetter blockSetter = new(_originChunks, _originStartIndex, _originCount, _minY, _worldHeight, _pendingModifications);
        setter(blockSetter);
        blockSetter.Apply();
    }

    /// <summary>
    /// Applies a modification to all affected chunks.
    /// If the chunk is in the origin chunks, it applies immediately.
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
                
                // Check if this chunk is one of the origin chunks
                ChunkData? originChunk = null;
                for (int i = _originStartIndex; i < _originStartIndex + _originCount; i++) {
                    if (_originChunks[i].ChunkX == cx && _originChunks[i].ChunkZ == cz) {
                        originChunk = _originChunks[i];
                        break;
                    }
                }
                
                if (originChunk != null) {
                    // Apply immediately to the origin chunk
                    modification(originChunk, _minY);
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

/// <summary>
/// A block setter that automatically tracks bounds based on the blocks set.
/// After all blocks are set, call Apply() to create the fork with the computed bounds.
/// </summary>
internal class AutoExpandingBlockSetter : IBlockSetter {
    private readonly ChunkData[] _originChunks;
    private readonly int _originStartIndex;
    private readonly int _originCount;
    private readonly int _minY;
    private readonly int _worldHeight;
    private readonly ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> _pendingModifications;
    private readonly List<(Vec3<int> position, IBlock block)> _pendingBlocks = [];
    
    private int _minX = int.MaxValue;
    private int _minBlockY = int.MaxValue;
    private int _minZ = int.MaxValue;
    private int _maxX = int.MinValue;
    private int _maxBlockY = int.MinValue;
    private int _maxZ = int.MinValue;
    private bool _hasBlocks;

    public AutoExpandingBlockSetter(
        ChunkData[] originChunks,
        int originStartIndex,
        int originCount,
        int minY,
        int worldHeight,
        ConcurrentDictionary<Vec2<int>, List<Action<ChunkData>>> pendingModifications) {
        _originChunks = originChunks;
        _originStartIndex = originStartIndex;
        _originCount = originCount;
        _minY = minY;
        _worldHeight = worldHeight;
        _pendingModifications = pendingModifications;
    }

    public void SetBlock(Vec3<int> position, IBlock block) {
        _pendingBlocks.Add((position, block));
        
        // Expand bounds
        _minX = Math.Min(_minX, position.X);
        _minBlockY = Math.Min(_minBlockY, position.Y);
        _minZ = Math.Min(_minZ, position.Z);
        _maxX = Math.Max(_maxX, position.X + 1); // +1 for exclusive end
        _maxBlockY = Math.Max(_maxBlockY, position.Y + 1);
        _maxZ = Math.Max(_maxZ, position.Z + 1);
        _hasBlocks = true;
    }

    /// <summary>
    /// Applies all the pending block modifications using the computed bounds.
    /// </summary>
    public void Apply() {
        if (!_hasBlocks) return;

        Vec3<int> start = new(_minX, _minBlockY, _minZ);
        Vec3<int> end = new(_maxX, _maxBlockY, _maxZ);

        ForkedGenerationUnit fork = new(start, end, _minY, _worldHeight, _originChunks, _originStartIndex, _originCount, _pendingModifications);

        foreach ((Vec3<int> position, IBlock block) in _pendingBlocks) {
            fork.Modifier().SetBlock(position, block);
        }
    }
}
