using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent instead of the player movement packets while the player is steering a vehicle.</summary>
public class ServerBoundMoveVehiclePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:move_vehicle";

    public required Vec3<double> Position { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }
    public required bool OnGround { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVec3(Position)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .WriteBoolean(OnGround);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundMoveVehiclePacket {
        Position = r.ReadVec3(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat()),
        OnGround = r.ReadBoolean()
    };
}
