using Minecraft.Data.Particles;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Plays an explosion. The blocks it destroys are sent separately as ordinary block updates;
/// this packet only carries the visual and audible parts, plus the knockback on the receiver.
/// </summary>
public class ClientBoundExplosionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:explode";

    public required Vec3<double> Center { get; init; }
    public required float Radius { get; init; }

    /// <summary>How many blocks the explosion destroyed, used to scale the particle effect.</summary>
    public required int BlockCount { get; init; }

    /// <summary>Velocity added to the receiving player, or null to leave them alone.</summary>
    public Vec3<double>? PlayerKnockback { get; init; }

    /// <summary>The particle shown at the centre of the explosion.</summary>
    public required IParticle ExplosionParticle { get; init; }

    public ISoundType? SoundType { get; init; }
    public SoundEvent? SoundEvent { get; init; }

    /// <summary>Particles thrown out from the destroyed blocks, picked at random by weight.</summary>
    public BlockParticle[] BlockParticles { get; init; } = [];

    /// <summary>Whether the client plays the sound, which a silenced source turns off.</summary>
    public bool PlaySound { get; init; } = true;

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteVec3(Center)
            .WriteFloat(Radius)
            .WriteInteger(BlockCount)
            .WritePrefixedOptional(PlayerKnockback, (knockback, writer) => writer.WriteVec3(knockback))
            .WriteVarInt(reg.Particles.GetProtocolId(ExplosionParticle))
            .Write(writer => ExplosionParticle.WriteData(writer, reg));

        if (SoundEvent != null) {
            w.WriteVarInt(0).Write(SoundEvent, reg);
        }
        else {
            w.WriteVarInt(reg.SoundTypes.GetProtocolId(SoundType.ThrowIfNull()) + 1);
        }

        return w.WritePrefixedArray(BlockParticles, (particle, writer) => writer
            .WriteVarInt(reg.Particles.GetProtocolId(particle.Particle))
            .Write(pw => particle.Particle.WriteData(pw, reg))
            .WriteFloat(particle.Scaling)
            .WriteFloat(particle.Speed)
            .WriteVarInt(particle.Weight))
            .WriteBoolean(PlaySound);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        Vec3<double> center = r.ReadVec3();
        float radius = r.ReadFloat();
        int blockCount = r.ReadInteger();
        Vec3<double>? knockback = r.ReadPrefixedOptionalValue<Vec3<double>>(reader => reader.ReadVec3());
        IParticle particle = reg.Particles[r.ReadVarInt()].ReadData(r, reg);

        int soundId = r.ReadVarInt();
        SoundEvent? soundEvent = soundId == 0 ? r.Read<SoundEvent>(reg) : null;

        return new ClientBoundExplosionPacket {
            Center = center,
            Radius = radius,
            BlockCount = blockCount,
            PlayerKnockback = knockback,
            ExplosionParticle = particle,
            SoundEvent = soundEvent,
            SoundType = soundEvent == null ? reg.SoundTypes[soundId - 1] : null,
            BlockParticles = r.ReadPrefixedArray(reader => new BlockParticle(
                reg.Particles[reader.ReadVarInt()].ReadData(reader, reg),
                reader.ReadFloat(),
                reader.ReadFloat(),
                reader.ReadVarInt())),
            PlaySound = r.ReadBoolean()
        };
    };

    /// <param name="Particle">The particle to spawn.</param>
    /// <param name="Scaling">Multiplier applied to the particle's size.</param>
    /// <param name="Speed">Multiplier applied to how fast the particle travels.</param>
    /// <param name="Weight">Relative chance of this entry being picked.</param>
    public record BlockParticle(IParticle Particle, float Scaling, float Speed, int Weight);
}
