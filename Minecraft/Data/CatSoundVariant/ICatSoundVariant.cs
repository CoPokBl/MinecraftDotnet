using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.CatSoundVariant;

public interface ICatSoundVariant : IProtocolType {
    public CatSoundSet AdultSounds { get; }
    public CatSoundSet BabySounds { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("adult_sounds", AdultSounds.ToNbt()),
            ("baby_sounds", BabySounds.ToNbt()));
    }

    public static ICatSoundVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleCatSoundVariant(
            ident,
            CatSoundSet.FromNbt(tag["adult_sounds"]!, reg),
            CatSoundSet.FromNbt(tag["baby_sounds"]!, reg));
    }
}
