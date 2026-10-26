using System.Globalization;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Storage.Stores;

/// <summary>
/// One file per chunk in a directory. The simplest thing that survives a crash: nothing is shared
/// between two chunks, so a write that dies halfway can only cost the chunk it was writing.
/// </summary>
/// <remarks>
/// Writes land on a temporary file and are moved into place, because a reader on another thread must
/// see either the whole previous chunk or the whole new one. Writing in place would hand it whatever
/// prefix had reached the disk.
/// <p/>
/// A directory holding a chunk per file scales badly past a few tens of thousands of them, on every
/// filesystem. That is what a region layout is for.
/// </remarks>
public sealed class DirectoryChunkBlobStore : IChunkBlobStore {
    private readonly string _directory;
    private readonly string _extension;

    public DirectoryChunkBlobStore(string directory, string extension = ".chunk") {
        _directory = directory;
        _extension = extension;
        Directory.CreateDirectory(directory);
    }

    private string PathFor(Vec2<int> pos) => Path.Join(_directory, $"c.{pos.X}.{pos.Y}{_extension}");

    public bool TryRead(Vec2<int> pos, out byte[] data) {
        string path = PathFor(pos);
        if (!File.Exists(path)) {
            data = [];
            return false;
        }

        try {
            data = File.ReadAllBytes(path);
            return true;
        } catch (FileNotFoundException) {
            // Deleted between the check and the read, which a reset racing a join can do.
            data = [];
            return false;
        }
    }

    public void Write(Vec2<int> pos, ReadOnlySpan<byte> data) {
        string path = PathFor(pos);
        string temporary = path + ".tmp" + Environment.CurrentManagedThreadId.ToString(CultureInfo.InvariantCulture);
        using (FileStream stream = File.Create(temporary)) {
            stream.Write(data);
        }

        File.Move(temporary, path, true);
    }

    public void Delete(Vec2<int> pos) => File.Delete(PathFor(pos));

    public void Flush() { }

    public IEnumerable<Vec2<int>> EnumerateChunks() {
        foreach (string path in Directory.EnumerateFiles(_directory, "c.*.*" + _extension)) {
            string[] parts = Path.GetFileNameWithoutExtension(path).Split('.');
            if (parts.Length == 3
                && int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int x)
                && int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int z)) {
                yield return new Vec2<int>(x, z);
            }
        }
    }

    public void Dispose() { }
}
