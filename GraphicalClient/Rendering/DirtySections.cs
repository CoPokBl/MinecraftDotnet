namespace GraphicalClient.Rendering;

/// <summary>
/// Sections waiting to be meshed, also filed by whole sections of distance from a centre so the nearest
/// are found without looking at the rest. Ring entries are dropped lazily: one no longer queued is
/// removed when its ring is next read.
/// </summary>
internal sealed class DirtySections {
    private readonly HashSet<long> _queued = [];
    private readonly List<List<long>> _rings = [];
    private (int X, int Y, int Z) _centre = (int.MinValue, 0, 0);

    public int Count => _queued.Count;

    public void Add(long key) {
        if (_queued.Add(key)) {
            File(key);
        }
    }

    public void Remove(long key) => _queued.Remove(key);

    public void Clear() {
        _queued.Clear();
        _rings.Clear();
        _centre = (int.MinValue, 0, 0);
    }

    /// <summary>Rebuilds the rings around a new centre, which is the only time every queued section is visited.</summary>
    public void Recentre(int x, int y, int z) {
        if (_centre == (x, y, z)) {
            return;
        }
        _centre = (x, y, z);
        foreach (List<long> ring in _rings) {
            ring.Clear();
        }
        foreach (long key in _queued) {
            File(key);
        }
    }

    /// <summary>
    /// Takes up to <paramref name="count"/> of the nearest out of the queue, ring by ring outward and within a
    /// ring in the order they were queued, passing over those in <paramref name="skip"/>.
    /// </summary>
    public void TakeNearest(int count, HashSet<long> skip, List<long> taken) {
        for (int r = 0; r < _rings.Count && taken.Count < count; r++) {
            List<long> ring = _rings[r];
            for (int i = 0; i < ring.Count && taken.Count < count; i++) {
                long candidate = ring[i];
                if (_queued.Contains(candidate) && skip.Contains(candidate)) {
                    continue;
                }
                if (_queued.Remove(candidate)) {
                    taken.Add(candidate);
                }
                ring[i--] = ring[^1];
                ring.RemoveAt(ring.Count - 1);
            }
        }
    }

    private void File(long key) {
        if (_centre.X == int.MinValue) {
            return;
        }
        (int x, int y, int z) = WorldRenderer.Unpack(key);
        int dx = x - _centre.X, dy = y - _centre.Y, dz = z - _centre.Z;
        int ring = (int)MathF.Sqrt(dx * dx + dy * dy + dz * dz);
        while (_rings.Count <= ring) {
            _rings.Add([]);
        }
        _rings[ring].Add(key);
    }
}
