namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntityAnimationPacket(int entityId, ClientBoundEntityAnimationPacket.AnimationType animation) : MinecraftPacket {
    public int EntityId = entityId;
    public AnimationType Animation = animation;

    public ClientBoundEntityAnimationPacket() : this(0, AnimationType.SwingMainArm) { }

    public enum AnimationType {
        SwingMainArm = 0,
        LeaveBed = 2,
        SwingOffhand = 3,
        CriticalEffect = 4,
        MagicCriticalEffect = 5
    }

    public override int GetPacketId() {
        return 0x02;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteUnsignedByte((byte)Animation)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Animation = (AnimationType)r.Read();
        return this;
    }
}