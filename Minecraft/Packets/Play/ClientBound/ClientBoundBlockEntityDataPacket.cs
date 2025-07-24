using Minecraft.Data.BlockEntityTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBlockEntityDataPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:block_entity_data";

    public required Vec3<int> Position;
    public required IBlockEntityType Type;
    public required INbtTag Data;
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Position)
            .WriteVarInt(Type.ProtocolId)
            .WriteNbt(Data);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundBlockEntityDataPacket {
        Position = r.ReadPosition(),
        Type = reg.BlockEntityTypes[r.ReadVarInt()],
        Data = r.ReadNbt()
    };
}
