using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetPlayerPositionPacket(Vec3 position, MovePlayerFlags flags) : MinecraftPacket {
    public MovePlayerFlags Flags = flags;
    public Vec3 Position = position;
    
    public ServerBoundSetPlayerPositionPacket() : this(Vec3.Zero, MovePlayerFlags.OnGround) { }

    public override int GetPacketId() {
        return 0x1C;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVec3(Position)
            .WriteByte((int)Flags)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Position = r.ReadVec3();
        Flags = (MovePlayerFlags)r.ReadByte();
        return this;
    }
}