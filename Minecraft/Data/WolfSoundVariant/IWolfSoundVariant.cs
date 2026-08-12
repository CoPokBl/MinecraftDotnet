using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.WolfSoundVariant;

public interface IWolfSoundVariant : IProtocolType {
    public WolfSoundSet AdultSounds { get; }
    public WolfSoundSet BabySounds { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("adult_sounds", AdultSounds.ToNbt()),
            ("baby_sounds", BabySounds.ToNbt()));
    }

    public static IWolfSoundVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleWolfSoundVariant(
            ident,
            WolfSoundSet.FromNbt(tag["adult_sounds"]!, reg),
            WolfSoundSet.FromNbt(tag["baby_sounds"]!, reg));
    }
}
