using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.BannerPattern;

public interface IBannerPattern : IProtocolType, INetworkType<IBannerPattern> {
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

    DataWriter INetworkType<IBannerPattern>.WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(AssetId).WriteString(TranslationKey);
    }

    static IBannerPattern INetworkType<IBannerPattern>.ReadData(DataReader reader, MinecraftRegistry registry) {
        return ReadData(reader, registry);
    }

    /// <remarks>
    /// An inline pattern has no registry name, so the asset it draws stands in as its identifier.
    /// </remarks>
    public new static IBannerPattern ReadData(DataReader reader, MinecraftRegistry registry) {
        Identifier assetId = reader.ReadString();
        return new SimpleBannerPattern(assetId, assetId, reader.ReadString());
    }
}
