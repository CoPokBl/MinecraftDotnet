using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSynchronisePlayerPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_position";
    
    public required Angle Pitch { get; init; }
    public required Angle Yaw { get; init; }
    public required Vec3<double> Velocity { get; init; }
    public required Vec3<double> Position { get; init; }
    public required int TeleportId { get; init; }
    public required TeleportFlags Flags { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(TeleportId)
            .WriteVec3(Position)
            .WriteVec3(Velocity)
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .WriteInteger((int)Flags);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSynchronisePlayerPositionPacket {
        TeleportId = r.ReadVarInt(),
        Position = r.ReadVec3(),
        Velocity = r.ReadVec3(),
        Yaw = Angle.FromDegrees(r.ReadFloat()),
        Pitch = Angle.FromDegrees(r.ReadFloat()),
        Flags = (TeleportFlags)r.ReadInteger()
    };
}
