using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityRotationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_entity_rot";
    
    public required int EntityId { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }
    public required bool OnGround { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteBoolean(OnGround)
            .WriteAngle(Yaw)
            .WriteAngle(Pitch);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateEntityRotationPacket {
        EntityId = r.ReadVarInt(),
        OnGround = r.ReadBoolean(),
        Yaw = r.ReadAngle(),
        Pitch = r.ReadAngle()
    };
}
