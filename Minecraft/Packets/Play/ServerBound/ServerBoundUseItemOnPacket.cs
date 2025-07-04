using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemOnPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:use_item_on";
    
    public required Hand ActiveHand;
    public required BlockPosition Position;
    public required BlockFace Face;
    public required FVec3 CursorPosition;
    public required bool InsideBlock;
    public required bool WorldBorderHit;
    public required int Sequence;

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
