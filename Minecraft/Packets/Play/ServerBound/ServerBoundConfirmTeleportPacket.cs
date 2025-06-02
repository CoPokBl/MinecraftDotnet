namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundConfirmTeleportPacket(int teleportId) : MinecraftPacket {
    public int TeleportId = teleportId;

    public ServerBoundConfirmTeleportPacket() : this(0) { }

    public override int GetPacketId() {
        return 0x00;
    }

    protected override byte[] GetData() {
        return new DataWriter().WriteVarInt(TeleportId).ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        TeleportId = new DataReader(data).ReadVarInt();
        return this;
    }
}