namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// What shape an environment attribute's value has. The attribute registry is open ended and each
/// entry carries its own value type, so nothing can be read out of an attribute map without first
/// asking the attribute which of these it is.
/// </summary>
public enum EnvironmentAttributeValueKind {
    Boolean,
    Float,

    /// <summary>An opaque colour, written as <c>#rrggbb</c>.</summary>
    RgbColor,

    /// <summary>A colour with alpha, written as <c>#aarrggbb</c>.</summary>
    ArgbColor,

    /// <summary>The id of a villager activity.</summary>
    Activity,

    /// <summary>Yes, no, or leave it to whatever set the value underneath.</summary>
    TriState,

    MoonPhase,
    Particle,
    AmbientParticles,
    AmbientSounds,
    BackgroundMusic,
    BedRule,

    /// <summary>
    /// <c>MobSpawnSettings</c>, kept as the tag it arrived as: the protocol layer does not spawn
    /// anything, and the attribute is never sent to a client.
    /// </summary>
    MobSpawnSettings
}
