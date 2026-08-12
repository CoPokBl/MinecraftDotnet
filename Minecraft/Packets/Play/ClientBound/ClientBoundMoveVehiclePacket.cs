using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Corrects the position of the vehicle the player is riding.</summary>
public class ClientBoundMoveVehiclePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_vehicle";

    public required Vec3<double> Position { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVec3(Position)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundMoveVehiclePacket {
        Position = r.ReadVec3(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat())
    };
}
