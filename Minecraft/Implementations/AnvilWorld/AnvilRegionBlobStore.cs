using System.Collections.Concurrent;
using System.Globalization;
using Minecraft.Implementations.Storage;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.AnvilWorld;

/// <summary>
/// A directory of <c>r.x.z.mca</c> files, the layout a vanilla world uses. Thirty two by thirty two
/// chunks share a file, which is what keeps a large world to a few hundred files rather than a few
/// hundred thousand.
/// </summary>
/// <remarks>
/// Region files are opened lazily and kept open, since a save writes into the same handful of them
/// over and over. Nothing here closes one again, so a world that wanders far enough accumulates
/// handles; that is the same bargain vanilla makes and the ceiling is one per region ever touched.
/// </remarks>
public sealed class AnvilRegionBlobStore : IChunkBlobStore {
    private readonly string _directory;
    private readonly bool _writable;
    private readonly ConcurrentDictionary<Vec2<int>, AnvilRegionFile?> _regions = new();

    /// <param name="directory">The <c>region</c> directory itself, not the world root.</param>
    /// <param name="writable">
    /// Whether a region may be created or written. A read only store answers a missing region with a
    /// miss rather than making one.
    /// </param>
    public AnvilRegionBlobStore(string directory, bool writable = true) {
        _directory = directory;
        _writable = writable;
        if (writable) {
            Directory.CreateDirectory(directory);
        }
    }

    private static Vec2<int> RegionOf(Vec2<int> chunk) => new(chunk.X >> 5, chunk.Y >> 5);

    private string PathFor(Vec2<int> region) => Path.Join(_directory, $"r.{region.X}.{region.Y}.mca");

    /// <param name="create">Whether a region that does not exist yet should be made.</param>
    private AnvilRegionFile? Region(Vec2<int> region, bool create) {
        if (_regions.TryGetValue(region, out AnvilRegionFile? existing) && (existing != null || !create)) {
            return existing;
        }

        string path = PathFor(region);
        if (!create && !File.Exists(path)) {
            // A miss is only recorded if nothing got there first. A write racing this one may have just
            // opened the region, and replacing its handle with a miss has the next write open a second
            // handle on the same file, with its own idea of which sectors are free.
            return _regions.GetOrAdd(region, (AnvilRegionFile?)null);
        }

        // Opened under a lock on the store rather than through GetOrAdd, whose factory can run twice
        // and would leave a second handle on the same file.
        lock (_regions) {
            if (_regions.TryGetValue(region, out AnvilRegionFile? raced) && raced != null) {
                return raced;
            }

            // Writable whenever the store is, however the region was first reached. A region opened by a
            // read is kept, so opening it read only would refuse every save into it for the life of the
            // store.
            AnvilRegionFile opened = new(path, _writable);
            _regions[region] = opened;
            return opened;
        }
    }

    public bool TryRead(Vec2<int> pos, out byte[] data) {
        AnvilRegionFile? region = Region(RegionOf(pos), false);
        byte[]? bytes = region?.ReadChunkBytes(pos.X, pos.Y);
        data = bytes ?? [];
        return bytes != null;
    }

    public void Write(Vec2<int> pos, ReadOnlySpan<byte> data) {
        EnsureWritable();
        Region(RegionOf(pos), true)!.WriteChunkBytes(pos.X, pos.Y, data);
    }

    public void Delete(Vec2<int> pos) {
        EnsureWritable();
        Region(RegionOf(pos), false)?.DeleteChunk(pos.X, pos.Y);
    }

    private void EnsureWritable() {
        if (!_writable) {
            throw new InvalidOperationException($"Region store at '{_directory}' is read only.");
        }
    }

    public void Flush() {
        foreach (AnvilRegionFile? region in _regions.Values) {
            region?.Flush();
        }
    }

    public IEnumerable<Vec2<int>> EnumerateChunks() {
        if (!Directory.Exists(_directory)) {
            yield break;
        }

        foreach (string path in Directory.EnumerateFiles(_directory, "r.*.*.mca")) {
            string[] parts = Path.GetFileName(path).Split('.');
            if (parts.Length != 4
                || !int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int rx)
                || !int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int rz)) {
                continue;
            }

            AnvilRegionFile? region = Region(new Vec2<int>(rx, rz), false);
            if (region == null) {
                continue;
            }

            foreach ((int x, int z) in region.EnumerateChunks()) {
                yield return new Vec2<int>(rx * 32 + x, rz * 32 + z);
            }
        }
    }

    public void Dispose() {
        foreach (AnvilRegionFile? region in _regions.Values) {
            region?.Dispose();
        }

        _regions.Clear();
    }
}
