using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.PigSoundVariant;

public interface IPigSoundVariant : IProtocolType {
    public PigSoundSet AdultSounds { get; }
    public PigSoundSet BabySounds { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("adult_sounds", AdultSounds.ToNbt()),
            ("baby_sounds", BabySounds.ToNbt()));
    }

    public static IPigSoundVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimplePigSoundVariant(
            ident,
            PigSoundSet.FromNbt(tag["adult_sounds"]!, reg),
            PigSoundSet.FromNbt(tag["baby_sounds"]!, reg));
    }
}
