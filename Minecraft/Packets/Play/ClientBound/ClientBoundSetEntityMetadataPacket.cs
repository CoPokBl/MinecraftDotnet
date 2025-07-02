using Minecraft.Schemas.Entities.Meta;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetEntityMetadataPacket : ClientBoundPacket {
    public required int EntityId;
    public required EntityMeta Meta;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .Write(Meta.Serialise)
            .Write(0xFF)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        throw new NotImplementedException("Deserialisation of EntityMeta is not implemented yet.");
    };
}
