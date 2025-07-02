namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundPlayerInfoRemovePacket : ClientBoundPacket {
    public required Guid[] Uuids;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePrefixedArray(Uuids, (guid, writer) => writer.WriteUuid(guid))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPlayerInfoRemovePacket {
        Uuids = r.ReadPrefixedArray(reader => reader.ReadUuid())
    };
}
