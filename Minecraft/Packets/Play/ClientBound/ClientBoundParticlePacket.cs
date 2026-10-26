using Minecraft.Data.Particles;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundParticlePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:level_particles";
    
    public required bool LongDistance { get; init; }
    public required bool AlwaysVisible { get; init; }
    public required Vec3<double> Position { get; init; }
    public required Vec3<float> Offset { get; init; }

    /// <summary>The spread of each particle's speed along each axis.</summary>
    public required Vec3<float> MaxSpeed { get; init; }
    public required int ParticleCount { get; init; }
    public required IParticle Particle { get; init; }

    /// <summary>How each of <see cref="ParticleCount"/> particles is scattered.</summary>
    public RandomizationType Randomization { get; init; } = RandomizationType.Default;

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WriteVarInt(registry.Particles.GetProtocolId(Particle))
            .Write(wr => Particle.WriteData(wr, registry))
            .WriteBoolean(LongDistance)
            .WriteBoolean(AlwaysVisible)
            .WriteVec3(Position)
            .WriteVec3(Offset)
            .WriteVec3(MaxSpeed)
            .WriteVarInt(ParticleCount)
            .WriteVarInt((int)Randomization);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundParticlePacket {
        Particle = reg.Particles[r.ReadVarInt()].ReadData(r, reg),
        LongDistance = r.ReadBoolean(),
        AlwaysVisible = r.ReadBoolean(),
        Position = r.ReadVec3(),
        Offset = r.ReadFVec3(),
        MaxSpeed = r.ReadFVec3(),
        ParticleCount = r.ReadVarInt(),
        Randomization = r.ReadVarInt() switch {
            1 => RandomizationType.Alternative,
            2 => RandomizationType.AlternativeWithSpeed,
            _ => RandomizationType.Default
        }
    };

    /// <summary><c>ClientboundLevelParticlesPacket.RandomizationType</c>.</summary>
    public enum RandomizationType {
        /// <summary>Gaussian about the position and about zero speed.</summary>
        Default = 0,

        /// <summary>Uniform on the positive side of the position, at exactly the axis speeds.</summary>
        Alternative = 1,

        /// <summary>As <see cref="Alternative"/>, with each speed scaled by a uniform draw.</summary>
        AlternativeWithSpeed = 2
    }
}
