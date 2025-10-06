using Minecraft.Data;
using Minecraft.Data.Attributes;
using Minecraft.Registry;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Attributes;

namespace Minecraft.Schemas;

// TODO: Fix this not working (error on client)
public record ItemAttributeModifier(
    IAttribute Attribute,
    Identifier Id,
    double Value,
    AttributeOperation Operation,
    EquipmentSlotGroup Slot) : INetworkType<ItemAttributeModifier> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(Attribute.ProtocolId)
            .WriteString(Id)
            .WriteDouble(Value)
            .WriteVarInt((int)Operation)
            .WriteVarInt(Slot.ProtocolId);
    }
    
    public static ItemAttributeModifier ReadData(DataReader reader, MinecraftRegistry registry) {
        return new ItemAttributeModifier(
            registry.Attributes[reader.ReadVarInt()],
            reader.ReadString(),
            reader.ReadDouble(),
            (AttributeOperation)reader.ReadVarInt(),
            EquipmentSlotGroup.FromProtocolId(reader.ReadVarInt())
        );
    }
    
    public AttributeModifier ToAttributeModifier() {
        return new AttributeModifier(Id, Value, Operation);
    }
}
