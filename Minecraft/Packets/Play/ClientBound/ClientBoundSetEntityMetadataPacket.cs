using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetEntityMetadataPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_entity_data";
    
    public required int EntityId { get; init; }
    public required EntityMetaContainer Meta { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(EntityId)
            .Write(wr => Meta.Write(reg, wr));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSetEntityMetadataPacket {
        EntityId = r.ReadVarInt(),
        Meta = new EntityMetaContainer().ReadData(reg, r)
    };
}
