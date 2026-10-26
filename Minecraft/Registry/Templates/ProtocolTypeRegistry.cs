using Minecraft.Data;
using Minecraft.Registry.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Registry.Templates;

/// <summary>
/// Registry that stores entries mapped by an explicit protocol ID.
/// Used for hardcoded registries that are not changeable with a datapack.
/// </summary>
public abstract class MappedRegistry<TSelf, T> : MappedRegistry<T>, ISubRegistry<TSelf, T>
    where TSelf : MappedRegistry<TSelf, T> where T : IProtocolType {

    public override TSelf Clone() {
        TSelf clone = (TSelf)Activator.CreateInstance(GetType())!;
        foreach (KeyValuePair<Identifier, T> pair in ById) {
            clone.Add(ProtocolIds[pair.Key], pair.Value);
        }

        CopyTagsTo(clone);
        return clone;
    }

    ISubRegistry ISubRegistry.Clone() {
        return Clone();
    }
}

public abstract class MappedRegistry<T> : IProtocolTypeRegistry<T> where T : IProtocolType {
    protected readonly Dictionary<int, T> ByProtocolId = new();
    protected readonly Dictionary<Identifier, T> ById = new();
    protected readonly Dictionary<Identifier, int> ProtocolIds = new();

    public T this[int protocolId] => ByProtocolId[protocolId];
    public T this[Identifier id] => ById[id];

    public T Get(Identifier id) => ById[id];
    public T Get(int protocolId) => ByProtocolId[protocolId];
    public IEnumerable<T> All => ById.Values;
    public Identifier NameOf(int protocolId) => ByProtocolId[protocolId].Identifier;

    public long Count => ById.Count;

    public abstract Identifier RegistryId { get; }
    public RegistryTagContainer<T> Tags { get; } = new();
    RegistryTagContainer ISubRegistry.Tags => Tags;

    /// <summary>
    /// Carries the tags onto a copy. A clone without them is a registry the client is sent no tags
    /// for, which is not a copy of anything.
    /// </summary>
    /// <remarks>
    /// The tags themselves are shared rather than rebuilt, since an <see cref="IRegistryTag"/> is
    /// read only once constructed.
    /// </remarks>
    protected void CopyTagsTo(MappedRegistry<T> clone) {
        foreach (KeyValuePair<Identifier, IRegistryTag> tag in Tags.Tags) {
            clone.Tags.Tags[tag.Key] = tag.Value;
        }
    }

    public virtual void Add(int protocolId, T type) {
        ById.Add(type.Identifier, type);
        ByProtocolId.Add(protocolId, type);
        ProtocolIds.Add(type.Identifier, protocolId);
    }

    public int GetProtocolId(Identifier id) => ProtocolIds[id];
    public int GetProtocolId(IProtocolType type) => ProtocolIds[type.Identifier];

    public bool Contains(Identifier id) {
        return ById.ContainsKey(id);
    }

    public bool Contains(int protocolId) {
        return ByProtocolId.ContainsKey(protocolId);
    }

    public abstract ISubRegistry Clone();

    public virtual void Clear() {
        ById.Clear();
        ByProtocolId.Clear();
        ProtocolIds.Clear();
    }
}

/// <summary>
/// Registry that stores entries sequentially, where their index in the list is their protocol ID.
/// Used for NBT registries where entries are loaded dynamically.
/// </summary>
public abstract class SequentialRegistry<TSelf, T> : SequentialRegistry<T>, ISubRegistry<TSelf, T>
    where TSelf : SequentialRegistry<TSelf, T> where T : IProtocolType {

    public override TSelf Clone() {
        TSelf clone = (TSelf)Activator.CreateInstance(GetType())!;
        foreach (T entry in Entries) {
            clone.Add(entry);
        }

        CopyTagsTo(clone);
        return clone;
    }

    ISubRegistry ISubRegistry.Clone() {
        return Clone();
    }
}

public abstract class SequentialRegistry<T> : IProtocolTypeRegistry<T> where T : IProtocolType {
    protected readonly List<T> Entries = new();
    protected readonly Dictionary<Identifier, int> ProtocolIds = new();

    public T this[int protocolId] => Entries[protocolId];
    public T this[Identifier id] => Entries[ProtocolIds[id]];

    public T Get(Identifier id) => Entries[ProtocolIds[id]];
    public T Get(int protocolId) => Entries[protocolId];
    public IEnumerable<T> All => Entries;
    public Identifier NameOf(int protocolId) => Entries[protocolId].Identifier;

    public long Count => Entries.Count;

    public abstract Identifier RegistryId { get; }
    public RegistryTagContainer<T> Tags { get; } = new();
    RegistryTagContainer ISubRegistry.Tags => Tags;

    /// <summary>
    /// Carries the tags onto a copy. A clone without them is a registry the client is sent no tags
    /// for, which is not a copy of anything.
    /// </summary>
    /// <remarks>
    /// The tags themselves are shared rather than rebuilt, since an <see cref="IRegistryTag"/> is
    /// read only once constructed.
    /// </remarks>
    protected void CopyTagsTo(SequentialRegistry<T> clone) {
        foreach (KeyValuePair<Identifier, IRegistryTag> tag in Tags.Tags) {
            clone.Tags.Tags[tag.Key] = tag.Value;
        }
    }

    public virtual void Add(T type) {
        int protocolId = Entries.Count;
        Entries.Add(type);
        ProtocolIds.Add(type.Identifier, protocolId);
    }

    public int GetProtocolId(Identifier id) => ProtocolIds[id];
    public int GetProtocolId(IProtocolType type) => ProtocolIds[type.Identifier];

    public bool Contains(Identifier id) {
        return ProtocolIds.ContainsKey(id);
    }

    public bool Contains(int protocolId) {
        return protocolId >= 0 && protocolId < Entries.Count;
    }

    public abstract ISubRegistry Clone();

    public virtual void Clear() {
        Entries.Clear();
        ProtocolIds.Clear();
    }
}

public interface IProtocolTypeRegistry : ISubRegistry {
    long Count { get; }
    bool Contains(Identifier id);
    bool Contains(int protocolId);

    /// <summary>
    /// The name of an entry from its protocol id.
    /// </summary>
    /// <remarks>
    /// The wire form of a set of entries carries protocol ids while the datapack form carries names,
    /// so writing an <see cref="IdSet"/> back out as data needs this. Which registry the ids belong
    /// to is not in the set, which is why the caller names one.
    /// </remarks>
    Identifier NameOf(int protocolId);
}

/// <summary>A registry whose entry type is known, so a holder can be resolved to one.</summary>
public interface IProtocolTypeRegistry<out T> : IProtocolTypeRegistry where T : IProtocolType {
    T Get(Identifier id);
    T Get(int protocolId);

    /// <summary>Every entry, in no particular order.</summary>
    IEnumerable<T> All { get; }
}
