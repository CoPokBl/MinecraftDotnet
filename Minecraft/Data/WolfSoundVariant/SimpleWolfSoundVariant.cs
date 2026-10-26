using Minecraft.Schemas;

namespace Minecraft.Data.WolfSoundVariant;

public record SimpleWolfSoundVariant(
    Identifier Identifier,
    WolfSoundSet AdultSounds,
    WolfSoundSet BabySounds) : IWolfSoundVariant;
