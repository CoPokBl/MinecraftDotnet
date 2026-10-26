using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Data.CowSoundVariant;

public record SimpleCowSoundVariant(
    Identifier Identifier,
    SoundEvent AmbientSound,
    SoundEvent HurtSound,
    SoundEvent DeathSound,
    SoundEvent StepSound) : ICowSoundVariant;
