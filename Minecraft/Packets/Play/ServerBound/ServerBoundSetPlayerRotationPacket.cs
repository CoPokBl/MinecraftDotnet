using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerRotationPacket(float pitch, float yaw, MovePlayerFlags flags) : MinecraftPacket {
    public float Pitch = pitch;
    public float Yaw = yaw;
    public MovePlayerFlags Flags = flags;
    
    public ServerBoundSetPlayerRotationPacket() : this(0, 0, MovePlayerFlags.None) { }

    public override int GetPacketId() {
        return 0x1E;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteFloat(Pitch)
            .WriteFloat(Yaw)
            .WriteByte((byte)Flags)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Pitch = r.ReadFloat();
        Yaw = r.ReadFloat();
        Flags = (MovePlayerFlags)r.ReadByte();
        return this;
    }
}