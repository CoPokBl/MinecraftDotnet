using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemPacket(Hand hand, int sequence, Angle yaw, Angle pitch) : MinecraftPacket {
    public Hand UsedHand = hand;
    public int Sequence = sequence;
    public Angle Yaw = yaw;
    public Angle Pitch = pitch;
    
    public ServerBoundUseItemPacket() : this(Hand.MainHand, 0, Angle.Zero, Angle.Zero) { }

    public override int GetPacketId() {
        return 0x3F;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)UsedHand)
            .WriteVarInt(Sequence)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        UsedHand = (Hand)r.ReadVarInt();
        Sequence = r.ReadVarInt();
        Yaw = Angle.FromDegrees(r.ReadFloat());
        Pitch = Angle.FromDegrees(r.ReadFloat());
        return this;
    }
}