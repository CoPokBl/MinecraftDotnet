using Minecraft.Schemas;

namespace Minecraft.Data.Items;

public interface IItem {
    public int ProtocolId { get; }
    public Identifier Identifier { get; }
}
