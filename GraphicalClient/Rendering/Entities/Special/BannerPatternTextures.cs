using System.Text;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Components.Types;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary>
/// <c>BannerRenderer.submitPatterns</c>, drawn into one texture. Vanilla draws the base sprite, then the
/// pattern base and each of up to sixteen layers as the same model again, alpha blended in order. Every
/// pass shares its geometry and so its lighting, so blending the sprites first and drawing once gives the
/// same colours; the entity pass has no blending, and a coplanar redraw would lose its depth test.
/// </summary>
public static class BannerPatternTextures {
    public static EntityTexture Patterned(ISpriteGetter sprites, SpriteId baseSprite, bool banner, DyeColor baseColor,
        IReadOnlyList<BannerPatternsComponent.Layer> patterns) {
        StringBuilder key = new StringBuilder("patterned:").Append(baseSprite.Texture).Append('|').Append(baseColor);
        int count = Math.Min(16, patterns.Count);
        for (int i = 0; i < count; i++) {
            key.Append('|').Append(patterns[i].Pattern.AssetId).Append('=').Append(patterns[i].Color);
        }
        return sprites.Texture(key.ToString(), () => Compose(sprites, baseSprite, banner, baseColor, patterns, count));
    }

    private static TextureImage? Compose(ISpriteGetter sprites, SpriteId baseSprite, bool banner, DyeColor baseColor,
        IReadOnlyList<BannerPatternsComponent.Layer> patterns, int count) {
        if (sprites.Image(baseSprite) is not { } under) {
            return null;
        }
        byte[] rgba = (byte[])under.Rgba.Clone();
        // The base is drawn as entitySolid, which ignores the sprite's alpha.
        for (int i = 3; i < rgba.Length; i += 4) {
            rgba[i] = 255;
        }
        Layer(sprites.Image(banner ? Sheets.BannerPatternBase : Sheets.ShieldPatternBase), baseColor);
        for (int maskIndex = 0; maskIndex < count; maskIndex++) {
            BannerPatternsComponent.Layer layer = patterns[maskIndex];
            SpriteId sprite = banner ? Sheets.GetBannerSprite(layer.Pattern) : Sheets.GetShieldSprite(layer.Pattern);
            Layer(sprites.Image(sprite), layer.Color);
        }
        return new TextureImage(under.Width, under.Height, rgba);

        // A pattern sprite the pack lacks is left out; vanilla would draw the missing sprite over the shield.
        void Layer(TextureImage? pattern, DyeColor color) {
            if (pattern == null) {
                return;
            }
            byte[] source = pattern.Width == under.Width && pattern.Height == under.Height ? pattern.Rgba : Scaled(pattern, under.Width, under.Height);
            uint diffuse = TropicalFish.TextureDiffuseColor(color);
            float r = (diffuse >> 16 & 0xFF) / 255.0F, g = (diffuse >> 8 & 0xFF) / 255.0F, b = (diffuse & 0xFF) / 255.0F;
            for (int i = 0; i < rgba.Length; i += 4) {
                float alpha = source[i + 3] / 255.0F;
                if (alpha == 0) {
                    continue;
                }
                rgba[i] = (byte)MathF.Round(source[i] * r * alpha + rgba[i] * (1 - alpha));
                rgba[i + 1] = (byte)MathF.Round(source[i + 1] * g * alpha + rgba[i + 1] * (1 - alpha));
                rgba[i + 2] = (byte)MathF.Round(source[i + 2] * b * alpha + rgba[i + 2] * (1 - alpha));
            }
        }
    }

    /// <summary>A sprite at another resolution than the base, sampled nearest as the atlas would sample it at the same coordinates.</summary>
    private static byte[] Scaled(TextureImage image, int width, int height) {
        byte[] rgba = new byte[width * height * 4];
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                int sx = x * image.Width / width, sy = y * image.Height / height;
                Buffer.BlockCopy(image.Rgba, (sy * image.Width + sx) * 4, rgba, (y * width + x) * 4, 4);
            }
        }
        return rgba;
    }
}
