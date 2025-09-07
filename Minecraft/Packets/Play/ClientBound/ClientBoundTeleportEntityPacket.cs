using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundTeleportEntityPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:entity_position_sync";
    
    public required int EntityId { get; init; }
    public required Vec3<double> Position { get; init; }
    public required Vec3<double> Velocity { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }
    public required bool OnGround { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteVec3(Position)
            .WriteVec3(Velocity)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .WriteBoolean(OnGround);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundTeleportEntityPacket {
        EntityId = r.ReadVarInt(),
        Position = r.ReadVec3(),
        Velocity = r.ReadVec3(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat()),
        OnGround = r.ReadBoolean()
    };
}
