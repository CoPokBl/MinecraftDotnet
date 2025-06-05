using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPosAndRotPacket(int entityId, SVec3 delta, Angle yaw, Angle pitch, bool onGround) : MinecraftPacket {
    public int EntityId = entityId;
    public SVec3 Delta = delta;
    public Angle Yaw = yaw;
    public Angle Pitch = pitch;
    public bool OnGround = onGround;
    
    public ClientBoundUpdateEntityPosAndRotPacket() : this(0, SVec3.Zero, Angle.Zero, Angle.Zero, false) { }

    public override int GetPacketId() {
        return 0x2F;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVec3(Delta)
            .WriteAngle(Yaw)
            .WriteAngle(Pitch)
            .WriteBoolean(OnGround)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Delta = r.ReadSVec3();
        OnGround = r.ReadBoolean();
        return this;
    }
}