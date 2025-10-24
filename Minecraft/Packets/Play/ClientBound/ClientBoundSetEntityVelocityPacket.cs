using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetEntityVelocityPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_entity_motion";
    
    public required int EntityId { get; init; }
    public required Vec3<double> Velocity { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(EntityId)
            .Write(new VelocityVecNetworkType(Velocity), reg);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSetEntityVelocityPacket {
        EntityId = r.ReadVarInt(),
        Velocity = r.Read<VelocityVecNetworkType>(reg).Value
    };
}
