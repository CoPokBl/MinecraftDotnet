using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <param name="Probability">Chance per tick that one is spawned near the player.</param>
public record AmbientParticle(ParticleValue Particle, float Probability) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("particle", Particle.ToNbt()),
            ("probability", new FloatTag(Probability)));
    }

    public static AmbientParticle FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new AmbientParticle(
            ParticleValue.FromNbt(compound["particle"]!),
            compound["probability"]!.GetFloat());
    }
}

/// <summary>
/// A particle in the data form registry entries use.
/// </summary>
/// <param name="Options">
/// Everything the particle carries beyond its type, kept as it was read. <c>IParticle</c> only
/// knows the wire form, and the two aren't the same shape, so a particle with options round trips
/// through here rather than through the particle registry.
/// </param>
public record ParticleValue(Identifier Type, IReadOnlyDictionary<string, INbtTag> Options) {

    public ParticleValue(Identifier type) : this(type, new Dictionary<string, INbtTag>()) { }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("type", new StringTag(Type.ToString()))];
        children.AddRange(Options.Select(o => (o.Key, o.Value)));
        return new CompoundTag(children.ToArray());
    }

    public static ParticleValue FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        Dictionary<string, INbtTag> options = [];
        foreach ((string key, INbtTag value) in compound.Children) {
            if (key != "type") {
                options[key] = value;
            }
        }

        return new ParticleValue(compound["type"]!.GetString(), options);
    }
}
