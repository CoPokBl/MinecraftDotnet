using Minecraft.Data.Items;

namespace Minecraft.Registry;

public class ItemRegistry {
    private readonly Dictionary<string, SimpleItem> _byId = new();
    private readonly Dictionary<int, SimpleItem> _byProtocolId = new();
    
    public SimpleItem this[string id] => _byId[id];
    public SimpleItem this[int protocolId] => _byProtocolId[protocolId];
    public long Count => _byId.Count;
    
    public void Add(SimpleItem item) {
        _byId.Add(item.Identifier.ToString(), item);
        _byProtocolId.Add(item.ProtocolId, item);
    }
}
