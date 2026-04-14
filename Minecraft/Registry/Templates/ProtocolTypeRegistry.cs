using Minecraft.Data;
using Minecraft.Registry.Tags;
using Minecraft.Schemas;

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
        return clone;
    }

    ISubRegistry ISubRegistry.Clone() {
        return Clone();
    }
}

public abstract class MappedRegistry<T> : IProtocolTypeRegistry where T : IProtocolType {
    protected readonly Dictionary<int, T> ByProtocolId = new();
    protected readonly Dictionary<Identifier, T> ById = new();
    protected readonly Dictionary<Identifier, int> ProtocolIds = new();

    public T this[int protocolId] => ByProtocolId[protocolId];
    public T this[Identifier id] => ById[id];

    public long Count => ById.Count;

    public abstract Identifier RegistryId { get; }
    public RegistryTagContainer<T> Tags { get; } = new();
    RegistryTagContainer ISubRegistry.Tags => Tags;

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
        return clone;
    }

    ISubRegistry ISubRegistry.Clone() {
        return Clone();
    }
}

public abstract class SequentialRegistry<T> : IProtocolTypeRegistry where T : IProtocolType {
    protected readonly List<T> Entries = new();
    protected readonly Dictionary<Identifier, int> ProtocolIds = new();

    public T this[int protocolId] => Entries[protocolId];
    public T this[Identifier id] => Entries[ProtocolIds[id]];

    public long Count => Entries.Count;

    public abstract Identifier RegistryId { get; }
    public RegistryTagContainer<T> Tags { get; } = new();
    RegistryTagContainer ISubRegistry.Tags => Tags;

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
}
