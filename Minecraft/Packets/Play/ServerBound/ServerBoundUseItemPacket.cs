using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:use_item";
    
    public required Hand UsedHand { get; init; }
    public required int Sequence { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }

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
