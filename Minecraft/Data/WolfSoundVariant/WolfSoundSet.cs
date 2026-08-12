using Minecraft.Registry;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.WolfSoundVariant;

/// <summary>The sounds one wolf of this variant makes, at one stage of its life.</summary>
public record WolfSoundSet(
    SoundEvent AmbientSound,
    SoundEvent DeathSound,
    SoundEvent GrowlSound,
    SoundEvent HurtSound,
    SoundEvent PantSound,
    SoundEvent WhineSound,
    SoundEvent StepSound) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("ambient_sound", AmbientSound.ToNbt()),
            ("death_sound", DeathSound.ToNbt()),
            ("growl_sound", GrowlSound.ToNbt()),
            ("hurt_sound", HurtSound.ToNbt()),
            ("pant_sound", PantSound.ToNbt()),
            ("whine_sound", WhineSound.ToNbt()),
            ("step_sound", StepSound.ToNbt()));
    }

    public static WolfSoundSet FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new WolfSoundSet(
            SoundEvent.FromNbt(compound["ambient_sound"]!, reg),
            SoundEvent.FromNbt(compound["death_sound"]!, reg),
            SoundEvent.FromNbt(compound["growl_sound"]!, reg),
            SoundEvent.FromNbt(compound["hurt_sound"]!, reg),
            SoundEvent.FromNbt(compound["pant_sound"]!, reg),
            SoundEvent.FromNbt(compound["whine_sound"]!, reg),
            SoundEvent.FromNbt(compound["step_sound"]!, reg));
    }
}
