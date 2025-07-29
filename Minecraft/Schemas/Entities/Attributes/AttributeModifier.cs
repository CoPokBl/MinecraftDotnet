using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas.Entities.Attributes;

public record AttributeModifier(Identifier Id, double Value, AttributeOperation Operation) : INetworkType<AttributeModifier> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry _) {
        return writer
            .WriteString(Id)
            .WriteDouble(Value)
            .WriteByte((int)Operation);
    }
        
    public static AttributeModifier ReadData(DataReader reader, MinecraftRegistry _) {
        return new AttributeModifier(
            reader.ReadString(),
            reader.ReadDouble(),
            (AttributeOperation)reader.ReadByte()
        );
    }
}
