using Minecraft.Data;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public abstract class ProtocolTypeRegistry<T> where T : IProtocolType {
    private readonly Dictionary<int, T> _byProtocolId = new();
    private readonly Dictionary<Identifier, T> _byId = new();
    
    public T this[int protocolId] => _byProtocolId[protocolId];
    public T this[Identifier id] => _byId[id];
    
    public long Count => _byId.Count;

    public void Add(T type) {
        _byId.Add(type.Identifier, type);
        _byProtocolId.Add(type.ProtocolId, type);
    }
}
