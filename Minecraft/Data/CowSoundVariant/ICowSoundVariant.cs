using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.CowSoundVariant;

public interface ICowSoundVariant : IProtocolType {
    public SoundEvent AmbientSound { get; }
    public SoundEvent HurtSound { get; }
    public SoundEvent DeathSound { get; }
    public SoundEvent StepSound { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("ambient_sound", AmbientSound.ToNbt()),
            ("hurt_sound", HurtSound.ToNbt()),
            ("death_sound", DeathSound.ToNbt()),
            ("step_sound", StepSound.ToNbt()));
    }

    public static ICowSoundVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleCowSoundVariant(
            ident,
            SoundEvent.FromNbt(tag["ambient_sound"], reg),
            SoundEvent.FromNbt(tag["hurt_sound"], reg),
            SoundEvent.FromNbt(tag["death_sound"], reg),
            SoundEvent.FromNbt(tag["step_sound"], reg));
    }
}
