using Minecraft.Data.BlockEntityTypes;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBlockEntityDataPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:block_entity_data";

    public required Vec3<int> Position { get; init; }
    public required IBlockEntityType Type { get; init; }
    public required INbtTag Data { get; init; }
    
    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WritePosition(Position)
            .WriteVarInt(registry.BlockEntityTypes.GetProtocolId(Type))
            .WriteNbt(Data);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundBlockEntityDataPacket {
        Position = r.ReadPosition(),
        Type = reg.BlockEntityTypes[r.ReadVarInt()],
        Data = r.ReadNbt()
    };
}
