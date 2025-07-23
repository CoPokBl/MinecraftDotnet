using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetEntityVelocityPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_entity_motion";
    
    public required int EntityId;
    public required SVec3 Velocity;

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(EntityId).WriteVec3(Velocity);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetEntityVelocityPacket {
        EntityId = r.ReadVarInt(),
        Velocity = r.ReadSVec3()
    };
}
