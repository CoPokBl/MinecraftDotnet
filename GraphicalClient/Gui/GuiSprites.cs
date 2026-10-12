using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering;
using Silk.NET.OpenGL;

namespace GraphicalClient.Gui;

/// <summary>
/// GUI art from a resource pack: sprites under <c>textures/gui/sprites</c> by name (<c>hud/hotbar</c>),
/// and whole textures such as container backgrounds by path (<c>gui/container/furnace</c>). A sprite the
/// pack lacks comes from <see cref="DevArtGuiSprites"/> where that has one. Every draw says whether it
/// happened, so where neither has the art the caller draws its own instead.
/// </summary>
public sealed unsafe class GuiSprites(GL gl, ResourcePackSource? source) : IDisposable {
    private const string SpritePrefix = "assets/minecraft/textures/gui/sprites/";

    private readonly Dictionary<string, (uint Texture, int Width, int Height)?> _loaded = new();

    public bool Available => source != null;

    /// <summary>The pack's image for a sprite name, or null; for composing atlases like the HUD icons.</summary>
    public TextureImage? Image(string sprite) => source?.LoadFirstFrame(SpriteFile(sprite));

    private const string MobEffectSprites = "mob_effect/", MobEffectPrefix = "assets/minecraft/textures/mob_effect/";

    /// <summary>The <c>gui</c> atlas's sources: <c>gui/sprites</c>, and <c>mob_effect</c> under its own prefix.</summary>
    private static string SpriteFile(string sprite) =>
        sprite.StartsWith(MobEffectSprites, StringComparison.Ordinal) ? $"{MobEffectPrefix}{sprite[MobEffectSprites.Length..]}.png" : $"{SpritePrefix}{sprite}.png";

    private (uint Texture, int Width, int Height)? Get(string file) {
        if (_loaded.TryGetValue(file, out (uint, int, int)? known)) {
            return known;
        }
        (uint, int, int)? result = null;
        if ((source?.LoadFirstFrame(file) ?? DevArtSprite(file)) is { } image) {
            uint texture = gl.GenTexture();
            gl.BindTexture(TextureTarget.Texture2D, texture);
            fixed (byte* p = image.Rgba) {
                gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, (uint)image.Width, (uint)image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
            }
            gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            result = (texture, image.Width, image.Height);
        }
        _loaded[file] = result;
        return result;
    }

    private static TextureImage? DevArtSprite(string file) =>
        !file.EndsWith(".png", StringComparison.Ordinal) ? null
        : file.StartsWith(SpritePrefix, StringComparison.Ordinal) ? DevArtGuiSprites.Image(file[SpritePrefix.Length..^4])
        : file.StartsWith(MobEffectPrefix, StringComparison.Ordinal) ? DevArtGuiSprites.Image(MobEffectSprites + file[MobEffectPrefix.Length..^4])
        : null;

    /// <summary>A sprite stretched over the rectangle, or the left <paramref name="fraction"/> of it for a progress bar.</summary>
    public bool Sprite(GuiRenderer gui, string name, float x, float y, float w, float h, uint argb = 0xFFFFFFFF, float fraction = 1) {
        if (Get(SpriteFile(name)) is not { } sprite) {
            return false;
        }
        if (fraction > 0) {
            gui.Textured(sprite.Texture, x, y, w * fraction, h, 0, 0, fraction, 1, argb);
        }
        return true;
    }

    /// <summary>
    /// A <c>nine_slice</c> sprite at its own height and any width: the side borders drawn once, the middle
    /// tiled as vanilla tiles it. The border is the caller's, the vanilla value for that sprite; a pack's
    /// <c>.mcmeta</c> giving another is not read.
    /// </summary>
    public bool Sliced(GuiRenderer gui, string name, float x, float y, float w, float h, int border) {
        if (Get(SpriteFile(name)) is not { } sprite) {
            return false;
        }
        float texW = sprite.Width;
        float middle = texW - 2 * border;
        gui.Textured(sprite.Texture, x, y, border, h, 0, 0, border / texW, 1);
        for (float done = 0; done < w - 2 * border;) {
            float part = Math.Min(middle, w - 2 * border - done);
            gui.Textured(sprite.Texture, x + border + done, y, part, h, border / texW, 0, (border + part) / texW, 1);
            done += part;
        }
        gui.Textured(sprite.Texture, x + w - border, y, border, h, (texW - border) / texW, 0, 1, 1);
        return true;
    }

    /// <summary>A sprite showing only its bottom <paramref name="fraction"/>, for a gauge that empties from the top.</summary>
    public bool SpriteFromBottom(GuiRenderer gui, string name, float x, float y, float w, float h, float fraction) {
        if (Get(SpriteFile(name)) is not { } sprite) {
            return false;
        }
        float visible = h * Math.Clamp(fraction, 0, 1);
        if (visible > 0) {
            gui.Textured(sprite.Texture, x, y + h - visible, w, visible, 0, 1 - visible / h, 1, 1);
        }
        return true;
    }

    /// <summary>
    /// A region of a whole texture drawn at its own size, in the texture's own pixels: the way
    /// container screens blit their background from a 256 square image.
    /// </summary>
    public bool Region(GuiRenderer gui, string texture, float x, float y, float u, float v, float w, float h) {
        if (Get($"assets/minecraft/textures/{texture}.png") is not { } image) {
            return false;
        }
        gui.Textured(image.Texture, x, y, w, h, u / image.Width, v / image.Height, (u + w) / image.Width, (v + h) / image.Height);
        return true;
    }

    public void Dispose() {
        foreach ((uint Texture, int, int)? entry in _loaded.Values) {
            if (entry is { } loaded) {
                gl.DeleteTexture(loaded.Texture);
            }
        }
    }
}
