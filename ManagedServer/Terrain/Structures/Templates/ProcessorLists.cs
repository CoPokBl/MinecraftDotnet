using System.Text.Json;
using ManagedServer.Terrain.Data;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// The <c>worldgen/processor_list</c> registry, read from the pack.
/// </summary>
/// <remarks>
/// Read eagerly, unlike the templates: there are 41 of them and a jigsaw pool references them by id
/// from inside a piece list, so a missing one has to fail at load rather than while a chunk is being
/// generated on the thread pool.
/// </remarks>
public sealed class ProcessorLists {
    private static readonly Dictionary<(MinecraftRegistry, IDatapackSource), ProcessorLists> Cache =
        new();

    private static readonly Lock CacheLock = new();

    private readonly Dictionary<Identifier, IReadOnlyList<IStructureProcessor>> _lists = [];

    private ProcessorLists(MinecraftRegistry registry, IDatapackSource source) {
        ProcessorParser parser = new(registry);

        foreach (DatapackEntry entry in source.Entries("worldgen/processor_list")) {
            using Stream stream = source.Open(entry.Path);
            using JsonDocument document = JsonDocument.Parse(stream);

            try {
                _lists[entry.Id] = parser.ParseList(document.RootElement);
            } catch (Exception error) {
                throw new FormatException(
                    $"The processor list \"{entry.Id}\" did not read: {error.Message}", error);
            }
        }
    }

    public static ProcessorLists Load(IDatapackSource source, MinecraftRegistry? registry = null) {
        MinecraftRegistry actual = registry ?? VanillaRegistry.Data;

        lock (CacheLock) {
            if (Cache.TryGetValue((actual, source), out ProcessorLists? existing)) {
                return existing;
            }

            ProcessorLists lists = new(actual, source);
            Cache[(actual, source)] = lists;
            return lists;
        }
    }

    /// <summary>The named list. Throws for one the pack does not have.</summary>
    public IReadOnlyList<IStructureProcessor> Get(Identifier id) {
        return _lists.TryGetValue(id, out IReadOnlyList<IStructureProcessor>? found)
            ? found
            : throw new FormatException($"No processor list is registered as \"{id}\".");
    }

    public int Count => _lists.Count;
}
