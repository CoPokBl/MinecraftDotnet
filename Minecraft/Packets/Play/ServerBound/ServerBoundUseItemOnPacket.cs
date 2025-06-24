using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemOnPacket : ServerBoundPacket {
    public required Hand ActiveHand;
    public required BlockPosition Position;
    public required BlockFace Face;
    public required FVec3 CursorPosition;
    public required bool InsideBlock;
    public required bool WorldBorderHit;
    public required int Sequence;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt((int)ActiveHand)
            .WritePosition(Position)
            .WriteVarInt((int)Face)
            .WriteVec3(CursorPosition)
            .WriteBoolean(InsideBlock)
            .WriteBoolean(WorldBorderHit)
            .WriteVarInt(Sequence)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundUseItemOnPacket {
        ActiveHand = (Hand)r.ReadVarInt(),
        Position = r.ReadPosition(),
        Face = (BlockFace)r.ReadVarInt(),
        CursorPosition = r.ReadFVec3(),
        InsideBlock = r.ReadBoolean(),
        WorldBorderHit = r.ReadBoolean(),
        Sequence = r.ReadVarInt()
    };
}
