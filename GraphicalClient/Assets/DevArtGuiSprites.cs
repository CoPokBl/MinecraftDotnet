using ClientLib.Entities;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Schemas;

namespace GraphicalClient.Assets;

/// <summary>
/// Built in art for GUI sprites a pack does not supply, drawn at the size vanilla's sprite of the same
/// name has so the caller's layout holds either way. Null for a sprite with no built in art.
/// </summary>
public static class DevArtGuiSprites {
    private const string BossBar = "boss_bar/", MobEffect = "mob_effect/";
    private const int EffectIconSize = 18;
    private const int BarWidth = 182, BarHeight = 5;

    private static readonly Dictionary<string, uint> BarColours = new() {
        ["pink"] = 0xEC00B8,
        ["blue"] = 0x00B7EC,
        ["red"] = 0xEC3500,
        ["green"] = 0x1DEC00,
        ["yellow"] = 0xE9EC00,
        ["purple"] = 0x7B00EC,
        ["white"] = 0xECECEC
    };

    public static TextureImage? Image(string sprite) {
        switch (sprite) {
            case "hud/effect_background":
                return EffectBackground(24, false);
            case "hud/effect_background_ambient":
                return EffectBackground(24, true);
            case "container/inventory/effect_background":
                return EffectBackground(32, false);
            case "container/inventory/effect_background_ambient":
                return EffectBackground(32, true);
        }
        if (sprite.StartsWith(MobEffect, StringComparison.Ordinal)) {
            return EffectIcon(MobEffects.Get(Identifier.Parse("minecraft:" + sprite[MobEffect.Length..])));
        }
        if (!sprite.StartsWith(BossBar, StringComparison.Ordinal)) {
            return null;
        }
        string name = sprite[BossBar.Length..];
        int split = name.LastIndexOf('_');
        if (split < 0) {
            return null;
        }
        string kind = name[..split], part = name[(split + 1)..];
        if (part is not ("background" or "progress")) {
            return null;
        }
        if (BarColours.TryGetValue(kind, out uint colour)) {
            return Bar(colour, part == "progress");
        }
        if (kind.StartsWith("notched_", StringComparison.Ordinal) && int.TryParse(kind["notched_".Length..], out int segments) && segments > 0) {
            return Notches(segments);
        }
        return null;
    }

    /// <summary>A bar with clipped corners and a dark rim; the filled bar is lit from the top, the empty one sunk.</summary>
    private static TextureImage Bar(uint colour, bool filled) {
        byte[] rgba = new byte[BarWidth * BarHeight * 4];
        float[] rows = filled ? [1.0F, 0.78F, 0.58F] : [0.36F, 0.29F, 0.33F];
        uint rim = DevArt.Shade(colour, filled ? 0.2F : 0.15F);
        for (int y = 0; y < BarHeight; y++) {
            for (int x = 0; x < BarWidth; x++) {
                bool edgeX = x == 0 || x == BarWidth - 1, edgeY = y == 0 || y == BarHeight - 1;
                if (edgeX && edgeY) {
                    continue;
                }
                uint rgb = edgeX || edgeY ? rim : DevArt.Shade(colour, rows[y - 1] * (x == 1 || x == BarWidth - 2 ? 0.85F : 1.0F));
                DevArt.Put(rgba, y * BarWidth + x, 0xFF000000 | rgb);
            }
        }
        return new TextureImage(BarWidth, BarHeight, rgba);
    }

    /// <summary>A faint dark tick at each division, through the bar's inside only.</summary>
    private static TextureImage Notches(int segments) {
        byte[] rgba = new byte[BarWidth * BarHeight * 4];
        for (int i = 1; i < segments; i++) {
            int x = (int)MathF.Round((float)BarWidth * i / segments);
            for (int y = 1; y < BarHeight - 1; y++) {
                DevArt.Put(rgba, y * BarWidth + x, 0x50000000);
            }
        }
        return new TextureImage(BarWidth, BarHeight, rgba);
    }

    /// <summary>
    /// A bevelled square with clipped corners, lit from the top left; an ambient one is tinted blue. Its edges sit
    /// within two pixels of the border so the 32 pixel one slices with vanilla's border of four.
    /// </summary>
    private static TextureImage EffectBackground(int size, bool ambient) {
        byte[] rgba = new byte[size * size * 4];
        uint fill = ambient ? 0x9DB8C9u : 0xB4B4B4u, light = ambient ? 0xD8ECF8u : 0xEEEEEEu, dark = ambient ? 0x4C6A80u : 0x5E5E5Eu;
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                bool edgeX = x == 0 || x == size - 1, edgeY = y == 0 || y == size - 1;
                if (edgeX && edgeY) {
                    continue;
                }
                uint rgb = edgeX || edgeY ? 0x161616u
                    : x == 1 || y == 1 ? (x == size - 2 || y == size - 2 ? fill : light)
                    : x == size - 2 || y == size - 2 ? dark
                    : fill;
                DevArt.Put(rgba, y * size + x, 0xFF000000 | rgb);
            }
        }
        return new TextureImage(size, size, rgba);
    }

    /// <summary>
    /// An orb in the effect's colour, shaded from the top left, marked with an up chevron when beneficial, a
    /// down chevron when harmful and a diamond when neutral.
    /// </summary>
    private static TextureImage EffectIcon(ClientLib.Entities.MobEffect effect) {
        const int size = EffectIconSize;
        const float centre = size / 2.0F, radius = 7.5F;
        uint colour = (uint)effect.Color & 0xFFFFFF;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float dx = x + 0.5F - centre, dy = y + 0.5F - centre;
                float distance = MathF.Sqrt(dx * dx + dy * dy);
                if (distance > radius) {
                    continue;
                }
                uint rgb = distance > radius - 1.0F ? DevArt.Shade(colour, 0.3F) : DevArt.Shade(colour, 0.8F - (dx + dy) / radius * 0.22F);
                float spot = MathF.Sqrt((dx + 3.0F) * (dx + 3.0F) + (dy + 3.0F) * (dy + 3.0F));
                if (spot < 1.6F) {
                    rgb = DevArt.Mix(rgb, 0xFFFFFF, 0.6F);
                }
                DevArt.Put(rgba, y * size + x, 0xFF000000 | rgb);
            }
        }
        float luminance = ((colour >> 16 & 0xFF) * 0.299F + (colour >> 8 & 0xFF) * 0.587F + (colour & 0xFF) * 0.114F) / 255.0F;
        uint mark = luminance > 0.6F ? 0xFF202020 : 0xFFFFFFFF;
        foreach ((int x, int y) in Emblem(effect.Category)) {
            DevArt.Put(rgba, y * size + x, mark);
        }
        return new TextureImage(size, size, rgba);
    }

    private static IEnumerable<(int X, int Y)> Emblem(MobEffectCategory category) {
        for (int i = 0; i < 4; i++) {
            int y = category switch {
                MobEffectCategory.Beneficial => 7 + i,
                MobEffectCategory.Harmful => 10 - i,
                _ => 0
            };
            if (category == MobEffectCategory.Neutral) {
                yield return (8 - i + 1, 6 + i);
                yield return (9 + i - 1, 6 + i);
                yield return (8 - i + 1, 11 - i);
                yield return (9 + i - 1, 11 - i);
                continue;
            }
            yield return (8 - i, y);
            yield return (9 + i, y);
            yield return (8 - i, y + (category == MobEffectCategory.Beneficial ? -1 : 1));
            yield return (9 + i, y + (category == MobEffectCategory.Beneficial ? -1 : 1));
        }
    }
}
