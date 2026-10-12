using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>TropicalFish</c>'s packed variant: the pattern in the low 16 bits, then the base and pattern dye ids.</summary>
public static class TropicalFish {
    public enum Base {
        Small = 0,
        Large = 1
    }

    /// <summary><c>TropicalFish.Pattern</c>, valued by its packed id: the base id, then the index shifted left 8.</summary>
    public enum Pattern {
        Kob = 0 | 0 << 8,
        Sunstreak = 0 | 1 << 8,
        Snooper = 0 | 2 << 8,
        Dasher = 0 | 3 << 8,
        Brinely = 0 | 4 << 8,
        Spotty = 0 | 5 << 8,
        Flopper = 1 | 0 << 8,
        Stripey = 1 | 1 << 8,
        Glitter = 1 | 2 << 8,
        Blockfish = 1 | 3 << 8,
        Betty = 1 | 4 << 8,
        Clayfish = 1 | 5 << 8
    }

    /// <summary><c>DEFAULT_VARIANT</c>: a white kob with a white pattern.</summary>
    public const int DefaultPackedVariant = (int)Pattern.Kob & 65535 | ((int)DyeColor.White & 0xFF) << 16 | ((int)DyeColor.White & 0xFF) << 24;

    public static Base BaseOf(Pattern pattern) => (Base)((int)pattern & 0xFF);

    /// <summary><c>TropicalFish.getPattern</c>: <c>ByIdMap.sparse</c>, so an unknown id is a kob.</summary>
    public static Pattern GetPattern(int packedVariant) {
        Pattern pattern = (Pattern)(packedVariant & 65535);
        return Enum.IsDefined(pattern) ? pattern : Pattern.Kob;
    }

    public static DyeColor GetBaseColor(int packedVariant) => DyeById(packedVariant >> 16 & 0xFF);

    public static DyeColor GetPatternColor(int packedVariant) => DyeById(packedVariant >> 24 & 0xFF);

    /// <summary><c>DyeColor.byId</c>: <c>ByIdMap.continuous</c> with the ZERO strategy, so an id out of range is white.</summary>
    private static DyeColor DyeById(int id) => id is >= 0 and < 16 ? (DyeColor)id : DyeColor.White;

    /// <summary><c>DyeColor.getTextureDiffuseColor</c>, made opaque as the constructor makes it.</summary>
    public static uint TextureDiffuseColor(DyeColor color) => 0xFF000000 | color switch {
        DyeColor.White => 16383998u,
        DyeColor.Orange => 16351261u,
        DyeColor.Magenta => 13061821u,
        DyeColor.LightBlue => 3847130u,
        DyeColor.Yellow => 16701501u,
        DyeColor.Lime => 8439583u,
        DyeColor.Pink => 15961002u,
        DyeColor.Gray => 4673362u,
        DyeColor.LightGray => 10329495u,
        DyeColor.Cyan => 1481884u,
        DyeColor.Purple => 8991416u,
        DyeColor.Blue => 3949738u,
        DyeColor.Brown => 8606770u,
        DyeColor.Green => 6192150u,
        DyeColor.Red => 11546150u,
        _ => 1908001u
    };
}
