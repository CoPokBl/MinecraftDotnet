using Minecraft.Data.Items;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class ItemRegistry {
    private readonly Dictionary<Identifier, SimpleItem> _byId = new();
    private readonly Dictionary<int, SimpleItem> _byProtocolId = new();
    
    public SimpleItem this[Identifier id] => _byId[id];
    public SimpleItem this[int protocolId] => _byProtocolId[protocolId];
    public long Count => _byId.Count;
    
    public void Add(SimpleItem item) {
        _byId.Add(item.Identifier, item);
        _byProtocolId.Add(item.ProtocolId, item);
    }
}
