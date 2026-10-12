using Minecraft.Registry;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace ClientLib.Commands;

/// <summary>
/// Vanilla's <c>CommandBuildContext.simple</c>. Vanilla filters block, item and entity type lookups by
/// the enabled feature flags; the generated registries carry no flags for items or entity types, so
/// those are not filtered and a server with an experimental pack off still has its elements suggested.
/// </summary>
public sealed class CommandBuildContext(
    MinecraftRegistry registry,
    IReadOnlyDictionary<Identifier, Dictionary<Identifier, int[]>> tags,
    IReadOnlyCollection<Identifier> enabledFeatures) {

    public MinecraftRegistry Registry { get; } = registry;

    /// <summary>Tag contents as protocol ids, by registry and then tag, as the server sent them.</summary>
    public IReadOnlyDictionary<Identifier, Dictionary<Identifier, int[]>> Tags { get; } = tags;

    public IReadOnlyCollection<Identifier> EnabledFeatures { get; } = enabledFeatures;

    /// <summary>
    /// <c>lookup(key)</c>. Null for a registry the client does not hold; vanilla's client holds every
    /// built in registry, so a caller that falls back to asking the server does so more often here.
    /// </summary>
    public IRegistryLookup? Lookup(Identifier registryKey) =>
        ProtocolRegistry(registryKey) is { } protocol ? new ClientRegistryLookup(registryKey, protocol, Tags.GetValueOrDefault(registryKey)) : null;

    /// <summary>The tag's members as identifiers, or null when the server sent no such tag.</summary>
    public IReadOnlyList<Identifier>? TagMembers(Identifier registryKey, Identifier tag) {
        if (!Tags.TryGetValue(registryKey, out Dictionary<Identifier, int[]>? byTag) || !byTag.TryGetValue(tag, out int[]? ids)) {
            return null;
        }
        return ProtocolRegistry(registryKey) is { } protocol ? ids.Select(protocol.NameOf).ToList() : null;
    }

    private IProtocolTypeRegistry? ProtocolRegistry(Identifier registryKey) =>
        Registry.SubRegistries.FirstOrDefault(sub => sub.RegistryId == registryKey && sub is IProtocolTypeRegistry) as IProtocolTypeRegistry;
}

/// <summary>A registry and its tags as the client knows them.</summary>
public sealed class ClientRegistryLookup(Identifier key, IProtocolTypeRegistry registry, Dictionary<Identifier, int[]>? tags) : IRegistryLookup {
    public Identifier Key { get; } = key;
    public IProtocolTypeRegistry Registry { get; } = registry;

    /// <summary>In protocol id order, which is the order vanilla's registries iterate in.</summary>
    public IEnumerable<Identifier> ListElementIds() {
        if (Registry is not IProtocolTypeRegistry<Minecraft.Data.IProtocolType> typed) {
            return [];
        }
        return typed.All.Select(t => t.Identifier).OrderBy(Registry.GetProtocolId);
    }

    public IEnumerable<Identifier> ListTagIds() => tags?.Keys ?? Enumerable.Empty<Identifier>();

    public bool Contains(Identifier id) => Registry.Contains(id);

    public bool ContainsTag(Identifier tag) => tags?.ContainsKey(tag) ?? false;
}
