using Minecraft.Schemas;

namespace Minecraft.Data.BannerPattern;

public record SimpleBannerPattern(
    Identifier Identifier,
    Identifier AssetId,
    string TranslationKey) : IBannerPattern;
