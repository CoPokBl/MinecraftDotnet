using Minecraft.Registry;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.ChickenSoundVariant;

/// <summary>The sounds one chicken of this variant makes, at one stage of its life.</summary>
public record ChickenSoundSet(
    SoundEvent AmbientSound,
    SoundEvent HurtSound,
    SoundEvent DeathSound,
    SoundEvent StepSound) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("ambient_sound", AmbientSound.ToNbt()),
            ("hurt_sound", HurtSound.ToNbt()),
            ("death_sound", DeathSound.ToNbt()),
            ("step_sound", StepSound.ToNbt()));
    }

    public static ChickenSoundSet FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new ChickenSoundSet(
            SoundEvent.FromNbt(compound["ambient_sound"]!, reg),
            SoundEvent.FromNbt(compound["hurt_sound"]!, reg),
            SoundEvent.FromNbt(compound["death_sound"]!, reg),
            SoundEvent.FromNbt(compound["step_sound"]!, reg));
    }
}
