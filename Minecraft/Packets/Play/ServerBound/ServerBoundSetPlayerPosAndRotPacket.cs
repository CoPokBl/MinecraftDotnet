using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerPosAndRotPacket(Vec3 position, float yaw, float pitch, MovePlayerFlags flags) : MinecraftPacket {
    public MovePlayerFlags Flags = flags;
    public float Pitch = pitch;
    public float Yaw = yaw;
    public Vec3 Position = position;

    public ServerBoundSetPlayerPosAndRotPacket() : this(Vec3.Zero, 0, 0, MovePlayerFlags.None) { }

    public override int GetPacketId() {
        return 0x1D;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVec3(Position)
            .WriteFloat(Yaw)
            .WriteFloat(Pitch)
            .WriteByte((int)Flags)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Position = r.ReadVec3();
        Yaw = r.ReadFloat();
        Pitch = r.ReadFloat();
        Flags = (MovePlayerFlags)r.Read();
        return this;
    }
}