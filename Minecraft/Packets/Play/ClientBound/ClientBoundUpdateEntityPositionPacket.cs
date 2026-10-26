using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPositionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_entity_pos";
    
    public required int EntityId { get; init; }

    /// <summary>The whole move. For a stepped move this is where the last step ends.</summary>
    public required Vec3<float> Delta { get; init; }
    public required bool OnGround { get; init; }

    /// <summary>The path to take instead of one jump, or null for a single jump of <see cref="Delta"/>.</summary>
    public IReadOnlyList<MovementDelta.Step>? Steps { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        MovementDelta.WriteProperties(w.WriteVarInt(EntityId), OnGround, Steps);
        return MovementDelta.WriteDelta(w, Delta, Steps);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        int entityId = r.ReadVarInt();
        int properties = r.ReadVarInt();
        (Vec3<float> delta, MovementDelta.Step[]? steps) = MovementDelta.Read(r, properties);
        return new ClientBoundUpdateEntityPositionPacket {
            EntityId = entityId,
            Delta = delta,
            Steps = steps,
            OnGround = MovementDelta.OnGround(properties)
        };
    };
}
