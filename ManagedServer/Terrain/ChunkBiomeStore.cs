using Minecraft.Data.Biomes;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain;

/// <summary>
/// One chunk's biome cells, in the order <c>LevelChunkSection.fillBiomesFromNoise</c> visits them,
/// together with the distinct biomes among them.
/// </summary>
public sealed record ChunkBiomes(IBiome[] Grid, IReadOnlySet<Identifier> Present);

/// <summary>
/// Each chunk's biome grid and the distinct biomes in it, kept because a chunk decorates from the
/// union over the three by three around it.
/// </summary>
/// <remarks>
/// Same argument as <see cref="TerrainStore"/> and the same shape: a chunk's biomes are a pure
/// function of the world seed and its position, every chunk in a viewport is generated eventually, so
/// a grid computed once is read by itself and its eight neighbours.
/// <p/>
/// <b>The grid is kept and not only the set</b>, because the chunk it belongs to needs it too: a
/// neighbour asking first would otherwise search the whole grid and then that chunk would search it
/// again when it generated. With the grid stored, every chunk's is computed exactly once whichever of
/// the nine asks first, and the extra work the union costs is only what falls off the end of this.
/// <p/>
/// Separate from the terrain store rather than a field on a snapshot, because the grid is wanted for a
/// neighbour whose terrain nothing has asked for: building the snapshot to reach it would trade a
/// biome grid for a whole terrain pass.
/// </remarks>
public sealed class ChunkBiomeStore(int capacity) {
    /// <summary>Enough for the ring of chunks in flight at a large view distance, at about 12KB each.</summary>
    public const int DefaultCapacity = 512;

    private readonly Dictionary<Vec2<int>, ChunkBiomes> _entries = [];

    /// <summary>Least recently used first, which is the order eviction takes them in.</summary>
    private readonly LinkedList<Vec2<int>> _order = [];
    private readonly Dictionary<Vec2<int>, LinkedListNode<Vec2<int>>> _nodes = [];

    private readonly Lock _gate = new();

    public ChunkBiomeStore() : this(DefaultCapacity) { }

    public bool TryGet(Vec2<int> chunk, out ChunkBiomes biomes) {
        lock (_gate) {
            if (!_entries.TryGetValue(chunk, out ChunkBiomes? found)) {
                biomes = null!;
                return false;
            }

            Touch(chunk);
            biomes = found;
            return true;
        }
    }

    public void Add(Vec2<int> chunk, ChunkBiomes biomes) {
        lock (_gate) {
            if (_entries.ContainsKey(chunk)) {
                return;
            }

            _entries[chunk] = biomes;
            _nodes[chunk] = _order.AddLast(chunk);

            while (_entries.Count > capacity && _order.First is { } oldest) {
                _order.RemoveFirst();
                _entries.Remove(oldest.Value);
                _nodes.Remove(oldest.Value);
            }
        }
    }

    private void Touch(Vec2<int> chunk) {
        if (_nodes.TryGetValue(chunk, out LinkedListNode<Vec2<int>>? node)) {
            _order.Remove(node);
            _order.AddLast(node);
        }
    }
}
