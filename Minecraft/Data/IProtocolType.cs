using Minecraft.Schemas;

namespace Minecraft.Data;

public interface IProtocolType {
    public int ProtocolId { get; }
    public Identifier Identifier { get; }
}
