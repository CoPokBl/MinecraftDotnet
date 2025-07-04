using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:use_item";
    
    public required Hand UsedHand;
    public required int Sequence;
    public required Angle Yaw;
    public required Angle Pitch;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)UsedHand)
            .WriteVarInt(Sequence)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundUseItemPacket {
        UsedHand = (Hand)r.ReadVarInt(),
        Sequence = r.ReadVarInt(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat())
    };
}
