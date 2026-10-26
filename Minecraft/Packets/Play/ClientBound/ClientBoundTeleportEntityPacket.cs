using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundTeleportEntityPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:entity_position_sync";
    
    public required int EntityId { get; init; }

    /// <summary>Where the entity ends up. For a stepped path this is where the last step lands.</summary>
    public required Vec3<double> Position { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }
    public required bool OnGround { get; init; }

    /// <summary>
    /// <c>PositionPath.Stepped</c>: absolute positions, each reached some ticks after the packet, or null
    /// for a single position. Never empty when set.
    /// </summary>
    public IReadOnlyList<Step>? Steps { get; init; }

    public sealed record Step(Vec3<double> Position, int TickOffset);

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteVarInt(EntityId);
        if (Steps is { Count: > 0 } steps) {
            w.WriteVarInt(1).WritePrefixedArray(steps.ToArray(), (Step step, DataWriter writer) => writer.WriteVec3(step.Position).WriteVarInt(step.TickOffset));
        }
        else {
            w.WriteVarInt(0).WriteVec3(Position);
        }

        return w
            .WriteFloat(Yaw.DegreesF)
            .WriteFloat(Pitch.DegreesF)
            .WriteBoolean(OnGround);
    }
    
    /// <remarks>A path type this does not know reads as a single position, as vanilla's id mapper falls back.</remarks>
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        int entityId = r.ReadVarInt();
        Step[]? steps = r.ReadVarInt() == 1 ? r.ReadPrefixedArray(reader => new Step(reader.ReadVec3(), reader.ReadVarInt())) : null;
        Vec3<double> position = steps is { Length: > 0 } ? steps[^1].Position : r.ReadVec3();
        return new ClientBoundTeleportEntityPacket {
            EntityId = entityId,
            Position = position,
            Steps = steps,
            Yaw = Angle.FromDegrees(r.ReadFloat()),
            Pitch = Angle.FromDegrees(r.ReadFloat()),
            OnGround = r.ReadBoolean()
        };
    };
}
