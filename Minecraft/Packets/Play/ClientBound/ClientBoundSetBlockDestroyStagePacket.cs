using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBlockDestroyStagePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:block_destruction";
    
    public required int EntityId;
    public required Vec3<int> Block;
    public required byte Stage;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WritePosition(Block)
            .WriteUnsignedByte(Stage);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetBlockDestroyStagePacket {
        EntityId = r.ReadVarInt(),
        Block = r.ReadPosition(),
        Stage = r.Read()
    };
}
