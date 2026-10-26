using System.IO.Compression;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Data;

/// <summary>
/// A datapack inside a zip, which is both the form a datapack is distributed in and what a server jar
/// is.
/// </summary>
/// <remarks>
/// <b>The vanilla server jar is a datapack.</b> Its <c>data/minecraft/</c> tree is the same layout with
/// the same contents: every one of the 963 worldgen files the vanilla data generator writes is already
/// in there, along with the loot tables and the structure templates. So the jar a consumer already has
/// is the source.
/// <p/>
/// <b>What Mojang serves is a bundler, not that jar.</b> The download is a launcher whose real server
/// jar is nested inside it at the path <c>META-INF/versions.list</c> names, and it carries no
/// <c>data/</c> of its own, so reading it directly finds an empty datapack rather than failing. This
/// unwraps it, which is why a consumer can hand over whichever of the two they happen to have.
/// <p/>
/// The archive is held open for the life of the source, since a parser resolves references lazily and
/// asks for entries long after the listing. Reads are serialised: <see cref="ZipArchive"/> is not
/// thread safe and chunk generation asks from the pool.
/// </remarks>
public sealed class ZipDatapack : IDatapackSource, IDisposable {
    private readonly string _path;
    private readonly ZipArchive _outer;
    private readonly ZipArchive _archive;

    /// <summary>The nested jar's bytes, held because the archive over them reads lazily.</summary>
    private readonly MemoryStream? _nested;

    private readonly Lock _gate = new();

    public ZipDatapack(string path) {
        _path = Path.GetFullPath(path);
        _outer = ZipFile.OpenRead(_path);

        _nested = Unbundle(_outer);
        _archive = _nested is null ? _outer : new ZipArchive(_nested, ZipArchiveMode.Read);
    }

    /// <summary>
    /// The server jar inside a bundler, or null when this is not one.
    /// </summary>
    /// <remarks>
    /// <c>versions.list</c> is one tab separated line per version: a SHA-256, the version name, and the
    /// path under <c>META-INF/versions/</c>. There is exactly one for a server download, and taking the
    /// first is what the bundler's own <c>Main</c> does when no version is selected.
    /// </remarks>
    private static MemoryStream? Unbundle(ZipArchive outer) {
        ZipArchiveEntry? list = outer.GetEntry("META-INF/versions.list");

        if (list is null) {
            return null;
        }

        using StreamReader reader = new(list.Open());
        string? line = reader.ReadLine();
        string[] fields = (line ?? string.Empty).Split('\t');

        if (fields.Length < 3) {
            return null;
        }

        ZipArchiveEntry? inner = outer.GetEntry("META-INF/versions/" + fields[2]);

        if (inner is null) {
            return null;
        }

        MemoryStream buffer = new((int)inner.Length);

        using (Stream raw = inner.Open()) {
            raw.CopyTo(buffer);
        }

        buffer.Position = 0;
        return buffer;
    }

    public IEnumerable<DatapackEntry> Entries(string registryPath, string extension = ".json") {
        // Listed under the lock and returned as a list rather than streamed, so a caller iterating
        // lazily cannot hold the archive while it parses.
        List<DatapackEntry> found = [];

        lock (_gate) {
            foreach (ZipArchiveEntry entry in _archive.Entries) {
                if (!entry.FullName.EndsWith(extension, StringComparison.Ordinal)
                    || !entry.FullName.StartsWith("data/", StringComparison.Ordinal)) {

                    continue;
                }

                // data/<namespace>/<registryPath>/<key><extension>
                string withoutData = entry.FullName["data/".Length..];
                int namespaceEnd = withoutData.IndexOf('/');

                if (namespaceEnd < 0) {
                    continue;
                }

                string ns = withoutData[..namespaceEnd];
                string rest = withoutData[(namespaceEnd + 1)..];
                string prefix = registryPath + "/";

                if (!rest.StartsWith(prefix, StringComparison.Ordinal)) {
                    continue;
                }

                string key = rest[prefix.Length..^extension.Length];
                found.Add(new DatapackEntry(new Identifier(ns, key), entry.FullName));
            }
        }

        return found;
    }

    /// <summary>
    /// Reads one entry whole.
    /// </summary>
    /// <remarks>
    /// Copied into memory rather than handing back the archive's own stream, which would keep the lock
    /// held for as long as the caller took to parse. Datapack files are kilobytes.
    /// </remarks>
    public Stream Open(string path) {
        lock (_gate) {
            ZipArchiveEntry entry = _archive.GetEntry(path)
                ?? throw new FileNotFoundException($"\"{path}\" is not in {_path}.", path);

            MemoryStream buffer = new((int)entry.Length);

            using (Stream raw = entry.Open()) {
                raw.CopyTo(buffer);
            }

            buffer.Position = 0;
            return buffer;
        }
    }

    public string Describe() => _path;

    public void Dispose() {
        if (!ReferenceEquals(_archive, _outer)) {
            _archive.Dispose();
        }

        _outer.Dispose();
        _nested?.Dispose();
    }
}
