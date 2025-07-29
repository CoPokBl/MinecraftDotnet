using Minecraft.Data;
using Minecraft.Data.Attributes;
using Minecraft.Registry;

namespace Minecraft.Schemas.Entities.Attributes;

public record AttributeValue(IAttribute Attribute, double BaseValue, params AttributeModifier[] Modifiers) : 
    INetworkType<AttributeValue> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
        return writer
            .WriteVarInt(Attribute.ProtocolId)
            .WriteDouble(BaseValue)
            .WritePrefixedArray(Modifiers, reg);
    }

    public static AttributeValue ReadData(DataReader reader, MinecraftRegistry reg) {
        return new AttributeValue(
            reg.Attributes[reader.ReadVarInt()],
            reader.ReadDouble(),
            reader.ReadPrefixedArray<AttributeModifier>(reg)
        );
    }
}
