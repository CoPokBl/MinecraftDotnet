using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBlockDestroyStage : ClientBoundPacket {
    public required int EntityId;
    public required BlockPosition Block;
    public required byte Stage;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WritePosition(Block)
            .WriteUnsignedByte(Stage)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundSetBlockDestroyStage {
        EntityId = r.ReadVarInt(),
        Block = r.ReadPosition(),
        Stage = r.Read()
    };
}
