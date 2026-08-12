using Minecraft.Data.DamageType;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Tells the client an entity took damage, so it can play the right sound and hurt animation.
/// The health change itself travels separately in the entity's metadata.
/// </summary>
public class ClientBoundDamageEventPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:damage_event";

    public required int EntityId { get; init; }
    public required IDamageType SourceType { get; init; }

    /// <summary>The entity responsible for the damage, or null when there isn't one.</summary>
    public int? SourceCauseId { get; init; }

    /// <summary>The entity that dealt the damage directly, such as an arrow, or null.</summary>
    public int? SourceDirectId { get; init; }

    /// <summary>Where the damage came from, sent only for sourceless damage such as an explosion.</summary>
    public Vec3<double>? SourcePosition { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(EntityId)
            .WriteVarInt(reg.DamageTypes.GetProtocolId(SourceType))
            // Entity ids here are offset by one so that zero can mean "no entity".
            .WriteVarInt((SourceCauseId ?? -1) + 1)
            .WriteVarInt((SourceDirectId ?? -1) + 1)
            .WritePrefixedOptional(SourcePosition, (pos, writer) => writer.WriteVec3(pos));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        int entityId = r.ReadVarInt();
        IDamageType sourceType = reg.DamageTypes[r.ReadVarInt()];
        int causeId = r.ReadVarInt() - 1;
        int directId = r.ReadVarInt() - 1;
        return new ClientBoundDamageEventPacket {
            EntityId = entityId,
            SourceType = sourceType,
            SourceCauseId = causeId == -1 ? null : causeId,
            SourceDirectId = directId == -1 ? null : directId,
            SourcePosition = r.ReadPrefixedOptional<Vec3<double>>(reader => reader.ReadVec3())
        };
    };
}
