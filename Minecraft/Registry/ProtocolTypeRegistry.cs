using Minecraft.Data;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public abstract class ProtocolTypeRegistry<TSelf, T> : ISubRegistry<TSelf> where TSelf : ProtocolTypeRegistry<TSelf, T> where T : IProtocolType {
    private readonly Dictionary<int, T> _byProtocolId = new();
    private readonly Dictionary<Identifier, T> _byId = new();
    
    public T this[int protocolId] => _byProtocolId[protocolId];
    public T this[Identifier id] => _byId[id];
    
    public long Count => _byId.Count;

    public void Add(T type) {
        _byId.Add(type.Identifier, type);
        _byProtocolId.Add(type.ProtocolId, type);
    }
    
    public bool Contains(Identifier id) {
        return _byId.ContainsKey(id);
    }
    
    public bool Contains(int protocolId) {
        return _byProtocolId.ContainsKey(protocolId);
    }

    public TSelf Clone() {
        TSelf clone = (TSelf)Activator.CreateInstance(GetType())!;
        foreach (KeyValuePair<Identifier, T> pair in _byId) {
            clone.Add(pair.Value);
        }
        return clone;
    }

    public void Clear() {
        _byId.Clear();
        _byProtocolId.Clear();
    }
}
