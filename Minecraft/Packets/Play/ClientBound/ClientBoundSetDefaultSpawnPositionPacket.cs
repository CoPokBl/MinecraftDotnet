using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetDefaultSpawnPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_default_spawn_position";

    /// <summary>The dimension the spawn is in. Part of the position as of 26.2.</summary>
    public required Identifier Dimension { get; init; }

    public required Vec3<int> Location { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Dimension)
            .WritePosition(Location)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetDefaultSpawnPositionPacket {
        Dimension = r.ReadString(),
        Location = r.ReadPosition(),
        Yaw = r.ReadFloat(),
        Pitch = r.ReadFloat()
    };
}
