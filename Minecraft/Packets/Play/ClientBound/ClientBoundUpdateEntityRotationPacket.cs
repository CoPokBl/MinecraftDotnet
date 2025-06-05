using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityRotationPacket(int entityId, Angle yaw, Angle pitch, bool onGround) : MinecraftPacket {
    public int EntityId = entityId;
    public Angle Yaw = yaw;
    public Angle Pitch = pitch;
    public bool OnGround = onGround;
    
    public ClientBoundUpdateEntityRotationPacket() : this(0, Angle.Zero, Angle.Zero, false) { }

    public override int GetPacketId() {
        return 0x31;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteAngle(Yaw)
            .WriteAngle(Pitch)
            .WriteBoolean(OnGround)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Yaw = r.ReadAngle();
        Pitch = r.ReadAngle();
        OnGround = r.ReadBoolean();
        return this;
    }
}