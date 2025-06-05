using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundTeleportEntityPacket(int entityId, Vec3 position, Vec3 velocity, float yaw, float pitch, bool onGround) : MinecraftPacket {
    public int EntityId = entityId;
    public Vec3 Position = position;
    public Vec3 Velocity = velocity;
    public float Yaw = yaw;
    public float Pitch = pitch;
    public bool OnGround = onGround;
    
    public ClientBoundTeleportEntityPacket() : this(0, Vec3.Zero, Vec3.Zero, 0, 0, false) { }

    public override int GetPacketId() {
        return 0x1F;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVec3(Position)
            .WriteVec3(Velocity)
            .WriteFloat(Yaw)
            .WriteFloat(Pitch)
            .WriteBoolean(OnGround)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Position = r.ReadVec3();
        Velocity = r.ReadVec3();
        Yaw = r.ReadFloat();
        Pitch = r.ReadFloat();
        return this;
    }
}