using Minecraft.Registry;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.PigSoundVariant;

/// <summary>The sounds one pig of this variant makes, at one stage of its life.</summary>
public record PigSoundSet(
    SoundEvent AmbientSound,
    SoundEvent HurtSound,
    SoundEvent DeathSound,
    SoundEvent StepSound,
    SoundEvent EatSound) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("ambient_sound", AmbientSound.ToNbt()),
            ("hurt_sound", HurtSound.ToNbt()),
            ("death_sound", DeathSound.ToNbt()),
            ("step_sound", StepSound.ToNbt()),
            ("eat_sound", EatSound.ToNbt()));
    }

    public static PigSoundSet FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new PigSoundSet(
            SoundEvent.FromNbt(compound["ambient_sound"]!, reg),
            SoundEvent.FromNbt(compound["hurt_sound"]!, reg),
            SoundEvent.FromNbt(compound["death_sound"]!, reg),
            SoundEvent.FromNbt(compound["step_sound"]!, reg),
            SoundEvent.FromNbt(compound["eat_sound"]!, reg));
    }
}
