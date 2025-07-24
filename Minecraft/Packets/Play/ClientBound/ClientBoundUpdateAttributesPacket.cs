using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateAttributesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_attributes";
    
    public required int EntityId;
    public required AttributeValue[] Attributes;

    public record AttributeValue(int AttributeIndex, double BaseValue, params AttributeModifier[] Modifiers) : INetworkType<AttributeValue> {
        public DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
            return writer
                .WriteVarInt(AttributeIndex)
                .WriteDouble(BaseValue)
                .WritePrefixedArray(Modifiers, reg);
        }

        public static AttributeValue ReadData(DataReader reader, MinecraftRegistry reg) {
            return new AttributeValue(
                reader.ReadVarInt(),
                reader.ReadDouble(),
                reader.ReadPrefixedArray<AttributeModifier>(reg)
            );
        }
    }

    public record AttributeModifier(string Id, double Value, AttributeOperation Operation) : INetworkType<AttributeModifier> {
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

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(EntityId)
            .WritePrefixedArray(Attributes, reg);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundUpdateAttributesPacket {
        EntityId = r.ReadVarInt(),
        Attributes = r.ReadPrefixedArray<AttributeValue>(reg)
    };
}
