using Minecraft.Schemas;

namespace Minecraft.Data.Entities;

public interface IEntityType {
    public int ProtocolId { get; }
    public Identifier Identifier { get; }
}
