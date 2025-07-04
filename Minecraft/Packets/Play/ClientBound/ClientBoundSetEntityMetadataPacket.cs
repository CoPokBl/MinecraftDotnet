using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetEntityMetadataPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_entity_data";
    
    public required int EntityId;
    public required EntityMeta Meta;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .Write(Meta.Serialise)
            .Write(0xFF);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        throw new NotImplementedException("Deserialisation of EntityMeta is not implemented yet.");
    };
}
