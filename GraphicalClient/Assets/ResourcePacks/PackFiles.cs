using System.IO.Compression;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// The files of one or more resource packs, by path inside the pack (<c>assets/minecraft/...</c>).
/// A pack is a folder, or a zip, which a game jar also is. Packs given later override earlier ones
/// file by file, the order the game's own pack list stacks in.
/// </summary>
public sealed class PackFiles : IDisposable {
    /// <summary>One pack's files. Reading may be asked for from several threads at once.</summary>
    public interface IPack : IDisposable {
        byte[]? Read(string path);
        bool Exists(string path);
        IEnumerable<string> Paths(string prefix);
    }

    private sealed class FolderPack(string root) : IPack {
        public byte[]? Read(string path) {
            string full = Path.Combine(root, path);
            return File.Exists(full) ? File.ReadAllBytes(full) : null;
        }

        public bool Exists(string path) => File.Exists(Path.Combine(root, path));

        public IEnumerable<string> Paths(string prefix) {
            string directory = Path.Combine(root, prefix);
            if (!Directory.Exists(directory)) {
                return [];
            }
            return Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories)
                .Select(file => Path.GetRelativePath(root, file).Replace('\\', '/'));
        }

        public void Dispose() { }
    }

    private sealed class ZipPack : IPack {
        private readonly ZipArchive _zip;
        private readonly Dictionary<string, ZipArchiveEntry> _entries = new(StringComparer.Ordinal);

        public ZipPack(string file) {
            _zip = ZipFile.OpenRead(file);
            foreach (ZipArchiveEntry entry in _zip.Entries) {
                if (entry.FullName.StartsWith("assets/", StringComparison.Ordinal) || entry.FullName == "pack.mcmeta") {
                    _entries[entry.FullName] = entry;
                }
            }
        }

        public byte[]? Read(string path) {
            if (!_entries.TryGetValue(path, out ZipArchiveEntry? entry)) {
                return null;
            }
            // ZipArchive is not safe to read from two threads at once.
            lock (_zip) {
                using Stream stream = entry.Open();
                byte[] data = new byte[entry.Length];
                stream.ReadExactly(data);
                return data;
            }
        }

        public bool Exists(string path) => _entries.ContainsKey(path);

        public IEnumerable<string> Paths(string prefix) => _entries.Keys.Where(k => k.StartsWith(prefix, StringComparison.Ordinal) && !k.EndsWith('/'));

        public void Dispose() => _zip.Dispose();
    }

    private readonly List<IPack> _packs = [];

    public IReadOnlyList<string> Names { get; }

    public PackFiles(IReadOnlyList<string> paths) {
        Names = paths.Select(Path.GetFileName).Select(n => n ?? "").ToList();
        foreach (string path in paths) {
            if (Directory.Exists(path)) {
                _packs.Add(new FolderPack(path));
            }
            else if (File.Exists(path)) {
                _packs.Add(new ZipPack(path));
            }
            else {
                throw new FileNotFoundException($"Resource pack not found: {path}");
            }
        }
    }

    /// <summary>A pack beneath every other, as the game's own assets sit beneath the packs a player adds.</summary>
    public void AddLowest(IPack pack) => _packs.Insert(0, pack);

    /// <summary>The file from every pack that has it, lowest first, for files that packs add to rather than replace.</summary>
    public IEnumerable<byte[]> ReadEach(string path) {
        foreach (IPack pack in _packs) {
            if (pack.Read(path) is { } data) {
                yield return data;
            }
        }
    }

    public bool Exists(string path) => _packs.Any(p => p.Exists(path));

    /// <summary>The file from the last pack that has it.</summary>
    public byte[]? Read(string path) {
        for (int i = _packs.Count - 1; i >= 0; i--) {
            if (_packs[i].Read(path) is { } data) {
                return data;
            }
        }
        return null;
    }

    /// <summary>Every path under <paramref name="prefix"/> in any pack, once each.</summary>
    public IEnumerable<string> Paths(string prefix) => _packs.SelectMany(p => p.Paths(prefix)).Distinct();

    public void Dispose() {
        foreach (IPack pack in _packs) {
            pack.Dispose();
        }
    }
}
