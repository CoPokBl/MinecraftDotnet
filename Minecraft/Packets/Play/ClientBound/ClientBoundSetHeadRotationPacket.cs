using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHeadRotationPacket(int entityId, Angle yaw) : MinecraftPacket {
    public int EntityId = entityId;
    public Angle Yaw = yaw;
    
    public ClientBoundSetHeadRotationPacket() : this(0, Angle.Zero) { }

    public override int GetPacketId() {
        return 0x4C;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteAngle(Yaw)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Yaw = r.ReadAngle();
        return this;
    }
}
