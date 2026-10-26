namespace ManagedServer.Terrain.Data;

/// <summary>
/// Several datapacks read as one, later ones winning, which is how the game stacks them.
/// </summary>
/// <remarks>
/// This is what makes "vanilla but my caves" one file rather than a fork: the consumer's pack goes on
/// top of the jar, and only the ids it defines are replaced. A pack that defines nothing under a
/// registry path leaves that whole registry to the layer below.
/// <p/>
/// Overriding is per <b>id</b>, not per registry: two packs both carrying
/// <c>minecraft:overworld/base_3d_noise</c> resolve to the topmost one, and every other density
/// function still comes off the bottom layer.
/// </remarks>
public sealed class LayeredDatapack(params IDatapackSource[] layers) : IDatapackSource {
    public IEnumerable<DatapackEntry> Entries(string registryPath, string extension = ".json") {
        Dictionary<Minecraft.Schemas.Identifier, DatapackEntry> byId = [];

        // In order, so a later layer's entry replaces an earlier one's.
        foreach (IDatapackSource layer in layers) {
            foreach (DatapackEntry entry in layer.Entries(registryPath, extension)) {
                byId[entry.Id] = entry;
            }
        }

        return byId.Values;
    }

    /// <summary>
    /// Opens a path against whichever layer holds it, topmost first.
    /// </summary>
    /// <remarks>
    /// A path is a layer's own, so this is a search rather than a lookup: the layer that listed it is
    /// the only one that can open it, and asking the others first would be wrong rather than merely
    /// wasteful if two layers used the same path string.
    /// </remarks>
    public Stream Open(string path) {
        for (int i = layers.Length - 1; i >= 0; i--) {
            try {
                return layers[i].Open(path);
            } catch (Exception exception) when (exception is FileNotFoundException
                or DirectoryNotFoundException) {
                // The next layer down.
            }
        }

        throw new FileNotFoundException($"\"{path}\" is in none of the layered packs.", path);
    }

    public string Describe() => string.Join(" over ", layers.Reverse().Select(layer => layer.Describe()));
}
