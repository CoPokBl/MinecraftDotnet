using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemOnPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:use_item_on";
    
    public required Hand ActiveHand { get; init; }
    public required Vec3<int> Position { get; init; }
    public required BlockFace Face { get; init; }
    public required Vec3<float> CursorPosition { get; init; }
    public required bool InsideBlock { get; init; }
    public required bool WorldBorderHit { get; init; }
    public required int Sequence { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)ActiveHand)
            .WritePosition(Position)
            .WriteVarInt((int)Face)
            .WriteVec3(CursorPosition)
            .WriteBoolean(InsideBlock)
            .WriteBoolean(WorldBorderHit)
            .WriteVarInt(Sequence);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundUseItemOnPacket {
        ActiveHand = (Hand)r.ReadVarInt(),
        Position = r.ReadPosition(),
        Face = (BlockFace)r.ReadVarInt(),
        CursorPosition = r.ReadFVec3(),
        InsideBlock = r.ReadBoolean(),
        WorldBorderHit = r.ReadBoolean(),
        Sequence = r.ReadVarInt()
    };
}
