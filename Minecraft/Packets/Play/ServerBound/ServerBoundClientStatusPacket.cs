namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientStatusPacket(ServerBoundClientStatusPacket.StatusAction action) : MinecraftPacket {
    public StatusAction Action = action;

    public ServerBoundClientStatusPacket() : this(StatusAction.Respawn) { }

    public enum StatusAction {
        Respawn = 0,
        RequestStats = 1
    }

    public override int GetPacketId() {
        return 0x0A;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)Action)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        Action = (StatusAction)new DataReader(data).ReadVarInt();
        return this;
    }
}