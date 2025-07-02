using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundKnownPacksPacket : ClientBoundPacket {
    public required KnownDataPack[] Packs;

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WritePrefixedArray(Packs, (pack, writer) => writer
            .WriteString(pack.Namespace)
            .WriteString(pack.Id)
            .WriteString(pack.Version));
        return w.ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        return new ClientBoundKnownPacksPacket {
            Packs = r.ReadPrefixedArray(reader =>
                new KnownDataPack(reader.ReadString(), reader.ReadString(), reader.ReadString()))
        };
    };
}
