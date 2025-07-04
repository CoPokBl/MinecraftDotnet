using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundKnownPacksPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:select_known_packs";
    
    public required KnownDataPack[] Packs;

    protected override DataWriter WriteData(DataWriter w) {
        return w.WritePrefixedArray(Packs, (pack, writer) => writer
            .WriteString(pack.Namespace)
            .WriteString(pack.Id)
            .WriteString(pack.Version));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundKnownPacksPacket {
        Packs = r.ReadPrefixedArray(reader => 
            new KnownDataPack(reader.ReadString(), reader.ReadString(), reader.ReadString()))
    };
}
