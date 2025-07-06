using Minecraft.Data.Entities;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class EntityTypeRegistry {
    private readonly Dictionary<int, IEntityType> _byProtocolId = new();
    private readonly Dictionary<Identifier, IEntityType> _byId = new();
    
    public IEntityType this[int protocolId] => _byProtocolId[protocolId];
    public IEntityType this[Identifier id] => _byId[id];

    public void Add(IEntityType type) {
        _byId.Add(type.Identifier, type);
        _byProtocolId.Add(type.ProtocolId, type);
    }
}
