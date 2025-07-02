using Minecraft.NBT;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundRegistryDataPacket() : ClientBoundPacket {
    public required string RegistryId;
    public required Dictionary<string, ITag?> Entries;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(RegistryId)
            .WritePrefixedArray(
                Entries.ToArray(),
                (entry, writer) => writer
                    .WriteString(entry.Key)
                    .WritePrefixedOptional(entry.Value, (tag, dataWriter) => dataWriter.WriteNbt(tag)))
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        return new ClientBoundRegistryDataPacket {
            RegistryId = r.ReadString(),
            Entries = new Dictionary<string, ITag?>(
                r.ReadPrefixedArray(reader => new KeyValuePair<string, ITag?>(
                    reader.ReadString(),
                    reader.ReadPrefixedOptional(re => re.ReadNbt()))))
        };
    };
}
