namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateAttributesPacket : ClientBoundPacket {
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
    
    public enum AttributeOperation {
        Add = 0,
        AddPercent = 1,
        Multiply = 2
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WritePrefixedArray(Attributes, (attribute, writer) => attribute.Write(writer))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = reader => new ClientBoundUpdateAttributesPacket {
        EntityId = reader.ReadVarInt(),
        Attributes = reader.ReadPrefixedArray(AttributeValue.Read)
    };
}
