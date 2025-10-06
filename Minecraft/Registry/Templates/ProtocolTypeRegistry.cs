using Minecraft.Data;
using Minecraft.Registry.Tags;
using Minecraft.Schemas;

namespace Minecraft.Registry.Templates;

public abstract class ProtocolTypeRegistry<TSelf, T> : ProtocolTypeRegistry<T>, ISubRegistry<TSelf, T> where TSelf : ProtocolTypeRegistry<TSelf, T> where T : IProtocolType {
    
    public override TSelf Clone() {
        TSelf clone = (TSelf)Activator.CreateInstance(GetType())!;
        foreach (KeyValuePair<Identifier, T> pair in ById) {
            clone.Add(pair.Value);
        }
        return clone;
    }

    ISubRegistry ISubRegistry.Clone() {
        return Clone();
    }
}

// This allows us to avoid needing the TSelf generic parameter in most cases
public abstract class ProtocolTypeRegistry<T> : ISubRegistry where T : IProtocolType {
    protected readonly Dictionary<int, T> ByProtocolId = new();
    protected readonly Dictionary<Identifier, T> ById = new();
    
    public T this[int protocolId] => ByProtocolId[protocolId];
    public T this[Identifier id] => ById[id];
    
    public long Count => ById.Count;

    public abstract Identifier RegistryId { get; }
    public RegistryTagContainer<T> Tags { get; } = new();
    RegistryTagContainer ISubRegistry.Tags => Tags;

    public virtual void Add(T type) {
        ById.Add(type.Identifier, type);
        ByProtocolId.Add(type.ProtocolId, type);
    }
    
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
    }
}
