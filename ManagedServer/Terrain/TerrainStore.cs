using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain;

/// <summary>
/// The terrain of chunks that have been generated recently, kept because their neighbours read it.
/// </summary>
/// <remarks>
/// A chunk's decoration reads the three by three around it, and the terrain of a neighbour is a pure
/// function of the world seed and that chunk's position, so it can be computed on demand. What makes
/// that affordable rather than nine times the work is this: every chunk in a viewport is generated
/// eventually, so a chunk's terrain is computed once and read by itself and its eight neighbours.
/// <p/>
/// <b>The capacity is what decides whether that holds.</b> A viewport is generated in distance order,
/// so the chunks in flight are a ring, and an entry has to survive from the first neighbour that asks
/// for it to the last. A ring at view distance 32 is a few hundred chunks, which is what
/// <see cref="DefaultCapacity"/> is sized for; a miss costs a terrain pass rather than a wrong answer,
/// so undersizing it is slow and not incorrect.
/// <p/>
/// Entries are built under a <see cref="Lazy{T}"/> rather than under the store's own lock, so a
/// neighbour that two chunks want at once is computed once and the terrain pass does not run holding a
/// lock every other chunk is waiting on.
/// </remarks>
public sealed class TerrainStore(int capacity) {
    /// <summary>
    /// Enough for the ring of chunks in flight at a large view distance, at about 100KB each.
    /// </summary>
    public const int DefaultCapacity = 512;

    private readonly Dictionary<Vec2<int>, Lazy<TerrainSnapshot>> _entries = [];

    /// <summary>Least recently used first, which is the order eviction takes them in.</summary>
    private readonly LinkedList<Vec2<int>> _order = [];
    private readonly Dictionary<Vec2<int>, LinkedListNode<Vec2<int>>> _nodes = [];

    private readonly Lock _gate = new();

    public TerrainStore() : this(DefaultCapacity) { }

    public int Count {
        get {
            lock (_gate) {
                return _entries.Count;
            }
        }
    }

    /// <summary>The terrain of a chunk if it has already been computed.</summary>
    public bool TryGet(Vec2<int> chunk, out TerrainSnapshot snapshot) {
        Lazy<TerrainSnapshot>? entry;

        lock (_gate) {
            if (!_entries.TryGetValue(chunk, out entry)) {
                snapshot = null!;
                return false;
            }

            Touch(chunk);
        }

        snapshot = entry.Value;
        return true;
    }

    /// <summary>
    /// Records terrain a chunk computed for itself, which is what keeps a generating chunk from
    /// building its own twice.
    /// </summary>
    public void Add(Vec2<int> chunk, TerrainSnapshot snapshot) {
        lock (_gate) {
            if (_entries.ContainsKey(chunk)) {
                return;
            }

            _entries[chunk] = new Lazy<TerrainSnapshot>(snapshot);
            _nodes[chunk] = _order.AddLast(chunk);
            Evict();
        }
    }

    /// <summary>The terrain of a chunk, computing it if nothing has yet.</summary>
    public TerrainSnapshot GetOrBuild(Vec2<int> chunk, Func<TerrainSnapshot> build) {
        Lazy<TerrainSnapshot> entry;

        lock (_gate) {
            if (_entries.TryGetValue(chunk, out Lazy<TerrainSnapshot>? existing)) {
                Touch(chunk);
                entry = existing;
            } else {
                entry = new Lazy<TerrainSnapshot>(build, LazyThreadSafetyMode.ExecutionAndPublication);
                _entries[chunk] = entry;
                _nodes[chunk] = _order.AddLast(chunk);
                Evict();
            }
        }

        return entry.Value;
    }

    private void Touch(Vec2<int> chunk) {
        if (_nodes.TryGetValue(chunk, out LinkedListNode<Vec2<int>>? node)) {
            _order.Remove(node);
            _order.AddLast(node);
        }
    }

    private void Evict() {
        while (_entries.Count > capacity && _order.First is { } oldest) {
            _order.RemoveFirst();
            _nodes.Remove(oldest.Value);
            _entries.Remove(oldest.Value);
        }
    }
}
