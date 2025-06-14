using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundUseItemOnPacket(Hand hand, BlockPosition position, BlockFace face, FVec3 cursorPosition, 
    bool insideBlock, bool worldBorderHit, int sequence) : MinecraftPacket {
    public Hand ActiveHand = hand;
    public BlockPosition Position = position;
    public BlockFace Face = face;
    public FVec3 CursorPosition = cursorPosition;
    public bool InsideBlock = insideBlock;
    public bool WorldBorderHit = worldBorderHit;
    public int Sequence = sequence;
    
    public ServerBoundUseItemOnPacket() : this(Hand.MainHand, new BlockPosition(0, 0, 0), BlockFace.NegX, FVec3.Zero, false, false, 0) { }

    public override int GetPacketId() {
        return 0x3E;
    }

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

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        ActiveHand = (Hand)r.ReadVarInt();
        Position = r.ReadPosition();
        Face = (BlockFace)r.ReadVarInt();
        CursorPosition = r.ReadFVec3();
        InsideBlock = r.ReadBoolean();
        WorldBorderHit = r.ReadBoolean();
        Sequence = r.ReadVarInt();
        return this;
    }
}