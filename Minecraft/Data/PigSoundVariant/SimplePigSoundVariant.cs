using Minecraft.Schemas;

namespace Minecraft.Data.PigSoundVariant;

public record SimplePigSoundVariant(
    Identifier Identifier,
    PigSoundSet AdultSounds,
    PigSoundSet BabySounds) : IPigSoundVariant;
