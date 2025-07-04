using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundUpdateTagsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_tags";
    
    public required TagSet[] Tags;

    public record TagSet(string Registry, Tag[] Tags) : IWritable {
        public void Write(DataWriter writer) {
            writer
                .WriteString(Registry)
                .WritePrefixedArray(Tags, (tag, wr) => wr.Write(tag));
        }

        public static TagSet Read(DataReader reader) {
            return new TagSet(
                reader.ReadString(), 
                reader.ReadPrefixedArray(Tag.Read));
        }
    }

    public record Tag(string Name, int[] Entries) : IWritable {
        public void Write(DataWriter writer) {
            writer
                .WriteString(Name)
                .WritePrefixedArray(Entries, (i, wr) => wr.WriteVarInt(i));
        }

        public static Tag Read(DataReader reader) {
            return new Tag(
                reader.ReadString(), 
                reader.ReadPrefixedArray(r => r.ReadVarInt()));
        }
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePrefixedArray(Tags, (tagSet, writer) => tagSet.Write(writer));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateTagsPacket {
        Tags = r.ReadPrefixedArray(TagSet.Read)
    };
}
