using Minecraft.Registry;

namespace Minecraft.Schemas;

public record ItemAttributeModifier(
    int Attribute,
    Identifier Id,
    double Value,
    AttributeOperation Operation,
    AttributeActiveSlot Slot) {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(Attribute)
            .Write(Id)
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
