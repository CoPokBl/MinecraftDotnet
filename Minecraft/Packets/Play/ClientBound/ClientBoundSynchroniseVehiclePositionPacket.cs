using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Teleports an entity the player is riding. Ordinary entity teleports use
/// <see cref="ClientBoundTeleportEntityPacket"/> instead.
/// </summary>
public class ClientBoundSynchroniseVehiclePositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:teleport_entity";

    public required int EntityId { get; init; }
    public required Vec3<double> Position { get; init; }
    public required Vec3<double> Velocity { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }

    /// <summary>Which of the above values are relative to the entity's current ones.</summary>
    public required TeleportFlags Flags { get; init; }

    public required bool OnGround { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteVec3(Position)
            .WriteVec3(Velocity)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .WriteInteger((int)Flags)
            .WriteBoolean(OnGround);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSynchroniseVehiclePositionPacket {
        EntityId = r.ReadVarInt(),
        Position = r.ReadVec3(),
        Velocity = r.ReadVec3(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat()),
        Flags = (TeleportFlags)r.ReadInteger(),
        OnGround = r.ReadBoolean()
    };
}
