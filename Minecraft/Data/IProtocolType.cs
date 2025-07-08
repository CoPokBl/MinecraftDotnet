using Minecraft.Schemas;

namespace Minecraft.Data;

public interface IProtocolType {
    public int ProtocolId { get; }
    public Identifier Identifier { get; }
    
    public static bool Equals(IProtocolType i1, IProtocolType i2) {
        return i1.Identifier == i2.Identifier;
    }
}
