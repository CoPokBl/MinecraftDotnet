using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Rotates the player's view without moving them.</summary>
public class ClientBoundPlayerRotationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_rotation";

    public required Angle Yaw { get; init; }

    /// <summary>Whether <see cref="Yaw"/> is added to the current yaw rather than replacing it.</summary>
    public required bool RelativeYaw { get; init; }

    public required Angle Pitch { get; init; }

    /// <summary>Whether <see cref="Pitch"/> is added to the current pitch rather than replacing it.</summary>
    public required bool RelativePitch { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteFloat(Yaw.DegreesF)
            .WriteBoolean(RelativeYaw)
            .WriteFloat(Pitch.DegreesF)
            .WriteBoolean(RelativePitch);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPlayerRotationPacket {
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        RelativeYaw = r.ReadBoolean(),
        Pitch = Angle.FromDegrees(r.ReadFloat()),
        RelativePitch = r.ReadBoolean()
    };
}
