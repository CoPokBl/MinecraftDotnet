using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.ChickenSoundVariant;

public interface IChickenSoundVariant : IProtocolType {
    public ChickenSoundSet AdultSounds { get; }
    public ChickenSoundSet BabySounds { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("adult_sounds", AdultSounds.ToNbt()),
            ("baby_sounds", BabySounds.ToNbt()));
    }

    public static IChickenSoundVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleChickenSoundVariant(
            ident,
            ChickenSoundSet.FromNbt(tag["adult_sounds"]!, reg),
            ChickenSoundSet.FromNbt(tag["baby_sounds"]!, reg));
    }
}
