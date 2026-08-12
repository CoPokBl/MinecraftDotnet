using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Rotates the player to face a point or an entity, as <c>/teleport ... facing</c> does.</summary>
public class ClientBoundLookAtPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_look_at";

    /// <summary>Which part of the player's body is aimed at the target.</summary>
    public required EntityAnchor FromAnchor { get; init; }

    public required Vec3<double> Target { get; init; }

    /// <summary>When set, the client re-aims at this entity instead of the fixed point.</summary>
    public int? TargetEntityId { get; init; }

    /// <summary>Which part of the target entity is aimed at. Only sent with <see cref="TargetEntityId"/>.</summary>
    public EntityAnchor TargetAnchor { get; init; } = EntityAnchor.Feet;

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteVarInt((int)FromAnchor)
            .WriteVec3(Target)
            .WriteBoolean(TargetEntityId != null);

        if (TargetEntityId != null) {
            w.WriteVarInt(TargetEntityId.Value)
                .WriteVarInt((int)TargetAnchor);
        }

        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        EntityAnchor fromAnchor = (EntityAnchor)r.ReadVarInt();
        Vec3<double> target = r.ReadVec3();
        bool atEntity = r.ReadBoolean();
        return new ClientBoundLookAtPacket {
            FromAnchor = fromAnchor,
            Target = target,
            TargetEntityId = atEntity ? r.ReadVarInt() : null,
            TargetAnchor = atEntity ? (EntityAnchor)r.ReadVarInt() : EntityAnchor.Feet
        };
    };
}
