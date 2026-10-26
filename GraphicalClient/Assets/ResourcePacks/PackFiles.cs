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

    /// <summary>
    /// <c>CompositePackResources</c>' search order for a pack with overlays: the overlay folders that apply, the last
    /// listed first, then the pack's own root. Root files such as <c>pack.mcmeta</c> only ever come from the root.
    /// </summary>
    private static string[] Prefixes(IReadOnlyList<string> overlays) => [.. overlays.Reverse().Select(o => o + "/"), ""];

    private static bool IsRootFile(string path) => !path.Contains('/');

    private sealed class FolderPack(string root, IReadOnlyList<string> overlays) : IPack {
        private readonly string[] _prefixes = Prefixes(overlays);

        private string? Find(string path) {
            foreach (string prefix in IsRootFile(path) ? [""] : _prefixes) {
                string full = Path.Combine(root, prefix + path);
                if (File.Exists(full)) {
                    return full;
                }
            }
            return null;
        }

        public byte[]? Read(string path) => Find(path) is { } full ? File.ReadAllBytes(full) : null;

        public bool Exists(string path) => Find(path) != null;

        public IEnumerable<string> Paths(string prefix) => _prefixes.SelectMany(overlay => {
            string overlayRoot = Path.Combine(root, overlay);
            string directory = Path.Combine(overlayRoot, prefix);
            return Directory.Exists(directory)
                ? Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories).Select(file => Path.GetRelativePath(overlayRoot, file).Replace('\\', '/'))
                : [];
        }).Distinct();

        public void Dispose() { }
    }

    private sealed class ZipPack : IPack {
        private readonly ZipArchive _zip;
        private readonly Dictionary<string, ZipArchiveEntry> _entries = new(StringComparer.Ordinal);
        private readonly string[] _prefixes;

        public ZipPack(string file, IReadOnlyList<string> overlays) {
            _prefixes = Prefixes(overlays);
            _zip = ZipFile.OpenRead(file);
            foreach (ZipArchiveEntry entry in _zip.Entries) {
                string name = entry.FullName;
                if (name is "pack.mcmeta" or "pack.png" || _prefixes.Any(prefix => name.Length > prefix.Length + 7 && name.StartsWith(prefix, StringComparison.Ordinal)
                        && string.CompareOrdinal(name, prefix.Length, "assets/", 0, 7) == 0)) {
                    _entries[name] = entry;
                }
            }
        }

        private ZipArchiveEntry? Find(string path) {
            foreach (string prefix in IsRootFile(path) ? [""] : _prefixes) {
                if (_entries.TryGetValue(prefix.Length == 0 ? path : prefix + path, out ZipArchiveEntry? entry)) {
                    return entry;
                }
            }
            return null;
        }

        public byte[]? Read(string path) {
            if (Find(path) is not { } entry) {
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

        public bool Exists(string path) => Find(path) != null;

        public IEnumerable<string> Paths(string prefix) => _prefixes.SelectMany(overlay => _entries.Keys
            .Where(k => k.StartsWith(overlay, StringComparison.Ordinal) && string.CompareOrdinal(k, overlay.Length, prefix, 0, prefix.Length) == 0 && !k.EndsWith('/'))
            .Select(k => k[overlay.Length..])).Distinct();

        public void Dispose() => _zip.Dispose();
    }

    private readonly List<IPack> _packs;

    public IReadOnlyList<string> Names { get; }

    /// <summary>Lowest priority first.</summary>
    public IReadOnlyList<IPack> Packs => _packs;

    /// <param name="packs">Lowest priority first, each with the name it is listed under.</param>
    public PackFiles(IReadOnlyList<(string Name, IPack Pack)> packs) {
        Names = packs.Select(p => p.Name).ToList();
        _packs = packs.Select(p => p.Pack).ToList();
    }

    /// <summary>
    /// A pack folder, or a zip, which a game jar also is: <c>openFull</c>, with the overlay folders its metadata
    /// chose for this version stacked over its root.
    /// </summary>
    public static IPack Open(string path, IReadOnlyList<string>? overlays = null) {
        if (Directory.Exists(path)) {
            return new FolderPack(path, overlays ?? []);
        }
        if (File.Exists(path)) {
            return new ZipPack(path, overlays ?? []);
        }
        throw new FileNotFoundException($"Resource pack not found: {path}");
    }

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
