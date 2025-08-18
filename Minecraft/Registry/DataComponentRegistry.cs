using Minecraft.Data.Components;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class DataComponentRegistry : ISubRegistry<DataComponentRegistry> {
    private readonly Dictionary<Identifier, int> _fromIdent = new();
    private readonly Dictionary<int, IDataComponent> _fromId = new();
    
    public int this[Identifier id] => _fromIdent[id];
    public IDataComponent this[int netId] => _fromId[netId];

    public void Add(IDataComponent comp, int netId) {
        _fromIdent.Add(comp.Identifier, netId);
        _fromId.Add(netId, comp);
    }
    
    public bool Contains(Identifier id) {
        return _fromIdent.ContainsKey(id);
    }
    
    public bool Contains(int netId) {
        return _fromId.ContainsKey(netId);
    }

    public DataComponentRegistry Clone() {
        DataComponentRegistry clone = new();
        foreach (KeyValuePair<Identifier, int> pair in _fromIdent) {
            clone._fromIdent.Add(pair.Key, pair.Value);
        }
        foreach (KeyValuePair<int, IDataComponent> pair in _fromId) {
            clone._fromId.Add(pair.Key, pair.Value);
        }
        return clone;
    }

    public void Clear() {
        _fromIdent.Clear();
        _fromId.Clear();
    }
}
