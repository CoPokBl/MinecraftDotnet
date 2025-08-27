using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundUpdateTagsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_tags";
    
    public required TagSet[] Tags { get; init; }

    public record TagSet(string Registry, Tag[] Tags) : INetworkType<TagSet> {
        public DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
            return writer
                .WriteString(Registry)
                .WritePrefixedArray(Tags, reg);
        }

        public static TagSet ReadData(DataReader reader, MinecraftRegistry reg) {
            return new TagSet(
                reader.ReadString(), 
                reader.ReadPrefixedArray<Tag>(reg));
        }
    }

    public record Tag(string Name, int[] Entries) : INetworkType<Tag> {
        public DataWriter WriteData(DataWriter writer, MinecraftRegistry _) {
            return writer
                .WriteString(Name)
                .WritePrefixedArray(Entries, (i, wr) => wr.WriteVarInt(i));
        }

        public static Tag ReadData(DataReader reader, MinecraftRegistry _) {
            return new Tag(
                reader.ReadString(), 
                reader.ReadPrefixedArray(r => r.ReadVarInt()));
        }
    }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePrefixedArray(Tags, reg);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundUpdateTagsPacket {
        Tags = r.ReadPrefixedArray<TagSet>(reg)
    };
}
