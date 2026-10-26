using Minecraft.Data.Blocks;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>A colour a model face's <c>tintindex</c> asks for: a biome colour looked up where the block is, or one fixed by the state.</summary>
public readonly record struct TintSource(TintKind Kind, uint Rgb = 0xFFFFFF);

/// <summary>
/// <c>BlockColors.createDefault</c>: which colours each block's tint indices take. A colour that only
/// depends on the state (redstone power, stem age) is worked out here once per state; a biome colour
/// is left to the mesher, which knows where the block is.
/// </summary>
public static class BlockTints {
    private static readonly TintSource Grass = new(TintKind.Grass);
    private static readonly TintSource Foliage = new(TintKind.Foliage);
    private static readonly TintSource Blank = new(TintKind.None);

    private static TintSource Constant(int argb) => new(TintKind.None, (uint)argb & 0xFFFFFF);

    public static TintSource[] For(IBlock state) => state.Identifier.Key switch {
        "large_fern" or "tall_grass" or "fern" or "short_grass" or "potted_fern" or "bush" or "grass_block" or "sugar_cane" => [Grass],
        "pink_petals" or "wildflowers" => [Blank, Grass],
        "spruce_leaves" => [Constant(-10380959)],
        "birch_leaves" => [Constant(-8345771)],
        "oak_leaves" or "jungle_leaves" or "acacia_leaves" or "dark_oak_leaves" or "vine" or "mangrove_leaves" => [Foliage],
        "leaf_litter" => [new TintSource(TintKind.DryFoliage)],
        "water_cauldron" => [new TintSource(TintKind.Water)],
        "redstone_wire" => [new TintSource(TintKind.None, RedstoneColour(StateProperties.GetInt(state, "power")))],
        "attached_melon_stem" or "attached_pumpkin_stem" => [Constant(-2046180)],
        "melon_stem" or "pumpkin_stem" => [StemColour(StateProperties.GetInt(state, "age"))],
        "lily_pad" => [Constant(-14647248)],
        _ => []
    };

    /// <summary><c>RedstoneWireBlock.COLORS</c>.</summary>
    private static uint RedstoneColour(int power) {
        float p = power / 15.0F;
        float red = p * 0.6F + (p > 0.0F ? 0.4F : 0.3F);
        float green = Math.Clamp(p * p * 0.7F - 0.5F, 0.0F, 1.0F);
        float blue = Math.Clamp(p * p * 0.6F - 0.7F, 0.0F, 1.0F);
        // ARGB.colorFromFloat floors each channel times 255; none is negative, so a cast does the same.
        return (uint)((int)(red * 255.0F) << 16 | (int)(green * 255.0F) << 8 | (int)(blue * 255.0F));
    }

    /// <summary><c>BlockTintSources.stem</c>.</summary>
    private static TintSource StemColour(int age) => new(TintKind.None, (uint)((age * 32 & 0xFF) << 16 | (255 - age * 8 & 0xFF) << 8 | (age * 4 & 0xFF)));
}
