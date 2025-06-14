using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundHurtAnimationPacket(int entityId, Angle yaw) : MinecraftPacket {
    public int EntityId = entityId;
    public Angle Yaw = yaw;
    
    public ClientBoundHurtAnimationPacket() : this(0, Angle.Zero) { }

    public override int GetPacketId() {
        return 0x24;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteFloat((float)Yaw.Degrees)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Yaw = Angle.FromDegrees(r.ReadFloat());
        return this;
    }
}