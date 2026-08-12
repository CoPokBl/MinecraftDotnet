using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.BannerPattern;

public interface IBannerPattern : IProtocolType {
    public Identifier AssetId { get; }
    public string TranslationKey { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("asset_id", new StringTag(AssetId.ToString())),
            ("translation_key", new StringTag(TranslationKey)));
    }

    public static IBannerPattern FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleBannerPattern(ident, tag["asset_id"].GetString(), tag["translation_key"].GetString());
    }
}
