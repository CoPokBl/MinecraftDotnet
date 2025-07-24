using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas;

public record ItemAttributeModifier(
    int Attribute,
    Identifier Id,
    double Value,
    AttributeOperation Operation,
    AttributeActiveSlot Slot) : INetworkType<ItemAttributeModifier> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(Attribute)
            .WriteString(Id)
            .WriteDouble(Value)
            .WriteVarInt((int)Operation)
            .WriteVarInt((int)Slot);
    }
    
    public static ItemAttributeModifier ReadData(DataReader reader, MinecraftRegistry registry) {
        return new ItemAttributeModifier(
            reader.ReadVarInt(),
            reader.ReadString(),
            reader.ReadDouble(),
            (AttributeOperation)reader.ReadVarInt(),
            (AttributeActiveSlot)reader.ReadVarInt()
        );
    }
}
