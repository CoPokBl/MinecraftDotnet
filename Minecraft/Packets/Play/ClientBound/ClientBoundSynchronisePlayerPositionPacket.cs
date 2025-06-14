using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSynchronisePlayerPositionPacket(
    int teleportId, 
    Vec3 position, 
    Vec3 velocity, 
    float yaw, 
    float pitch, 
    TeleportFlags teleportFlags) : MinecraftPacket {

    public float Pitch = pitch;
    public float Yaw = yaw;
    public Vec3 Velocity = velocity;
    public Vec3 Position = position;
    public int TeleportId = teleportId;
    public TeleportFlags Flags = teleportFlags;
    
    public ClientBoundSynchronisePlayerPositionPacket() : this(0, Vec3.Zero, Vec3.Zero, 0f, 0f, TeleportFlags.None) { }

    public ClientBoundSynchronisePlayerPositionPacket(int teleportId, PlayerPosition pos, TeleportFlags flags) : 
        this(teleportId, pos.Position, pos.Velocity, (float)pos.Yaw.Degrees, (float)pos.Pitch.Degrees, flags) { }
    
    public override int GetPacketId() {
        return 0x41;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(TeleportId)
            .WriteVec3(Position)
            .WriteVec3(Velocity)
            .WriteFloat(Yaw)
            .WriteFloat(Pitch)
            .WriteInteger((int)Flags)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        TeleportId = r.ReadVarInt();
        Position = r.ReadVec3();
        Velocity = r.ReadVec3();
        Yaw = r.ReadFloat();
        Pitch = r.ReadFloat();
        Flags = (TeleportFlags)r.ReadInteger();
        return this;
    }
}