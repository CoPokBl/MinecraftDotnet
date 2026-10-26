using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPosAndRotPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_entity_pos_rot";
    
    public required int EntityId { get; init; }

    /// <inheritdoc cref="ClientBoundUpdateEntityPositionPacket.Delta"/>
    public required Vec3<float> Delta { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle Pitch { get; init; }
    public required bool OnGround { get; init; }

    /// <inheritdoc cref="ClientBoundUpdateEntityPositionPacket.Steps"/>
    public IReadOnlyList<MovementDelta.Step>? Steps { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        MovementDelta.WriteProperties(w.WriteVarInt(EntityId), OnGround, Steps);
        return MovementDelta.WriteDelta(w, Delta, Steps)
            .WriteAngle(Yaw)
            .WriteAngle(Pitch);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        int entityId = r.ReadVarInt();
        int properties = r.ReadVarInt();
        (Vec3<float> delta, MovementDelta.Step[]? steps) = MovementDelta.Read(r, properties);
        return new ClientBoundUpdateEntityPosAndRotPacket {
            EntityId = entityId,
            Delta = delta,
            Steps = steps,
            Yaw = r.ReadAngle(),
            Pitch = r.ReadAngle(),
            OnGround = MovementDelta.OnGround(properties)
        };
    };
}
