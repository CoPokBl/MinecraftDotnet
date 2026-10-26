using Minecraft.Schemas;

namespace Minecraft.Data.ChickenSoundVariant;

public record SimpleChickenSoundVariant(
    Identifier Identifier,
    ChickenSoundSet AdultSounds,
    ChickenSoundSet BabySounds) : IChickenSoundVariant;
