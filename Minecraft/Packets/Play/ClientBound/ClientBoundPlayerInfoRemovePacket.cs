namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundPlayerInfoRemovePacket(params Guid[] uuids) : MinecraftPacket {
    public Guid[] Uuids = uuids;

    public override int GetPacketId() {
        return 0x3E;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePrefixedArray(Uuids, (guid, writer) => writer.WriteUuid(guid))
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Uuids = new DataReader(data).ReadPrefixedArray(reader => reader.ReadUuid());
        return this;
    }
}