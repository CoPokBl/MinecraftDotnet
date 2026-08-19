using Minecraft.Schemas;

namespace ManagedServer.Terrain.Data;

/// <summary>
/// A datapack on disk, read from its <c>data/</c> directory.
/// </summary>
/// <remarks>
/// Takes the pack's root, the directory holding <c>data/</c> and <c>pack.mcmeta</c>, so a consumer
/// points it at a datapack unpacked exactly as the game would take it.
/// </remarks>
public sealed class DirectoryDatapack : IDatapackSource {
    private readonly string _root;
    private readonly string _dataRoot;

    public DirectoryDatapack(string root) {
        _root = System.IO.Path.GetFullPath(root);
        _dataRoot = System.IO.Path.Combine(_root, "data");

        if (!Directory.Exists(_dataRoot)) {
            throw new DirectoryNotFoundException(
                $"\"{_root}\" is not a datapack: it has no data/ directory.");
        }
    }

    public IEnumerable<DatapackEntry> Entries(string registryPath, string extension = ".json") {
        foreach (string namespaceDir in Directory.EnumerateDirectories(_dataRoot)) {
            string ns = System.IO.Path.GetFileName(namespaceDir);
            string registryDir = System.IO.Path.Combine(namespaceDir,
                registryPath.Replace('/', System.IO.Path.DirectorySeparatorChar));

            if (!Directory.Exists(registryDir)) {
                continue;
            }

            foreach (string file in Directory.EnumerateFiles(registryDir, "*" + extension,
                SearchOption.AllDirectories)) {

                // Relative to the registry directory, so a nested file keeps its subdirectories in
                // its id the way vanilla files them.
                string key = System.IO.Path.GetRelativePath(registryDir, file)
                    .Replace(System.IO.Path.DirectorySeparatorChar, '/');

                yield return new DatapackEntry(new Identifier(ns, key[..^extension.Length]), file);
            }
        }
    }

    public Stream Open(string path) => File.OpenRead(path);

    public string Describe() => _root;
}
