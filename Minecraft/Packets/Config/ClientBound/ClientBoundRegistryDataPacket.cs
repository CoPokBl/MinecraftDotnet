using Minecraft.Schemas;
using NBT;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundRegistryDataPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:registry_data";

    public required string RegistryId { get; init; }
    public required Dictionary<string, INbtTag?> Entries { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(RegistryId)
            .WritePrefixedArray(
                Entries.ToArray(),
                (entry, writer) => writer
                    .WriteString(entry.Key)
                    .WritePrefixedOptional(entry.Value, (tag, dataWriter) => dataWriter.WriteNbt(tag)));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        return new ClientBoundRegistryDataPacket {
            RegistryId = r.ReadString(),
            Entries = new Dictionary<string, INbtTag?>(
                r.ReadPrefixedArray(reader => new KeyValuePair<string, INbtTag?>(
                    reader.ReadString(),
                    reader.ReadPrefixedOptional(re => re.ReadNbt()))))
        };
    };
}
