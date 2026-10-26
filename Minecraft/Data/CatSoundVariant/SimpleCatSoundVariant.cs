using Minecraft.Schemas;

namespace Minecraft.Data.CatSoundVariant;

public record SimpleCatSoundVariant(
    Identifier Identifier,
    CatSoundSet AdultSounds,
    CatSoundSet BabySounds) : ICatSoundVariant;
