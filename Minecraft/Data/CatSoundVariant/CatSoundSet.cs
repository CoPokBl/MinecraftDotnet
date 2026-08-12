using Minecraft.Registry;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.CatSoundVariant;

/// <summary>The sounds one cat of this variant makes, at one stage of its life.</summary>
public record CatSoundSet(
    SoundEvent AmbientSound,
    SoundEvent StrayAmbientSound,
    SoundEvent HissSound,
    SoundEvent HurtSound,
    SoundEvent DeathSound,
    SoundEvent EatSound,
    SoundEvent BegForFoodSound,
    SoundEvent PurrSound,
    SoundEvent PurreowSound) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("ambient_sound", AmbientSound.ToNbt()),
            ("stray_ambient_sound", StrayAmbientSound.ToNbt()),
            ("hiss_sound", HissSound.ToNbt()),
            ("hurt_sound", HurtSound.ToNbt()),
            ("death_sound", DeathSound.ToNbt()),
            ("eat_sound", EatSound.ToNbt()),
            ("beg_for_food_sound", BegForFoodSound.ToNbt()),
            ("purr_sound", PurrSound.ToNbt()),
            ("purreow_sound", PurreowSound.ToNbt()));
    }

    public static CatSoundSet FromNbt(INbtTag tag, MinecraftRegistry reg) {
        CompoundTag compound = (CompoundTag)tag;
        return new CatSoundSet(
            SoundEvent.FromNbt(compound["ambient_sound"]!, reg),
            SoundEvent.FromNbt(compound["stray_ambient_sound"]!, reg),
            SoundEvent.FromNbt(compound["hiss_sound"]!, reg),
            SoundEvent.FromNbt(compound["hurt_sound"]!, reg),
            SoundEvent.FromNbt(compound["death_sound"]!, reg),
            SoundEvent.FromNbt(compound["eat_sound"]!, reg),
            SoundEvent.FromNbt(compound["beg_for_food_sound"]!, reg),
            SoundEvent.FromNbt(compound["purr_sound"]!, reg),
            SoundEvent.FromNbt(compound["purreow_sound"]!, reg));
    }
}
