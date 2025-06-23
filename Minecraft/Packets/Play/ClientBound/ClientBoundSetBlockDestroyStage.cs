using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBlockDestroyStage(int entityId, BlockPosition block, byte stage) : MinecraftPacket {
    public int EntityId = entityId;
    public BlockPosition Block = block;
    public byte Stage = stage;
    
    public ClientBoundSetBlockDestroyStage() : this(0, BlockPosition.Zero, 0) { }
    
    public override int GetPacketId() {
        return 0x05;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WritePosition(Block)
            .WriteUnsignedByte(Stage)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Block = r.ReadPosition();
        Stage = r.Read();
        return this;
    }
}