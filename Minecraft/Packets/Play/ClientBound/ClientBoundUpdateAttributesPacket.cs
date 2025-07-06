using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateAttributesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_attributes";
    
    public required int EntityId;
    public required AttributeValue[] Attributes;

    public record AttributeValue(int AttributeIndex, double BaseValue, params AttributeModifier[] Modifiers) : IWritable {
        public void Write(DataWriter writer) {
            writer.WriteVarInt(AttributeIndex);
            writer.WriteDouble(BaseValue);
            writer.WritePrefixedArray(Modifiers, (modifier, wr) => wr.Write(modifier));
        }

        public static AttributeValue Read(DataReader reader) {
            return new AttributeValue(
                reader.ReadVarInt(),
                reader.ReadDouble(),
                reader.ReadPrefixedArray(AttributeModifier.Read)
            );
        }
    }

    public record AttributeModifier(string Id, double Value, AttributeOperation Operation) : IWritable {
        public void Write(DataWriter writer) {
            writer.WriteString(Id);
            writer.WriteDouble(Value);
            writer.WriteByte((int)Operation);
        }
        
        public static AttributeModifier Read(DataReader reader) {
            return new AttributeModifier(
                reader.ReadString(),
                reader.ReadDouble(),
                (AttributeOperation)reader.ReadByte()
            );
        }
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WritePrefixedArray(Attributes, (attribute, writer) => attribute.Write(writer));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateAttributesPacket {
        EntityId = r.ReadVarInt(),
        Attributes = r.ReadPrefixedArray(AttributeValue.Read)
    };
}
