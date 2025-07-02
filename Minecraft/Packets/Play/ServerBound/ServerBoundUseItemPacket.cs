using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemPacket : ServerBoundPacket {
    public required Hand UsedHand;
    public required int Sequence;
    public required Angle Yaw;
    public required Angle Pitch;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)UsedHand)
            .WriteVarInt(Sequence)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundUseItemPacket {
        UsedHand = (Hand)r.ReadVarInt(),
        Sequence = r.ReadVarInt(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat())
    };
}
