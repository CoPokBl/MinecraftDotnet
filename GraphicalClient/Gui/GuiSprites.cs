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
        (uint, int, int)? result = (source?.LoadFirstFrame(file) ?? DevArtSprite(file)) is { } image ? Upload(image) : null;
        _loaded[file] = result;
        return result;
    }

    private (uint Texture, int Width, int Height) Upload(TextureImage image) {
        uint texture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, texture);
        fixed (byte* p = image.Rgba) {
            gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, (uint)image.Width, (uint)image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        return (texture, image.Width, image.Height);
    }

    /// <summary>
    /// An image made at run time rather than read from the packs, a pack's icon say, stretched over the rectangle.
    /// It is kept under the caller's key until the packs reload; null from <paramref name="load"/> draws nothing.
    /// </summary>
    public bool Dynamic(GuiRenderer gui, string key, Func<TextureImage?> load, float x, float y, float w, float h) {
        string file = "dynamic:" + key;
        if (!_loaded.TryGetValue(file, out (uint Texture, int Width, int Height)? image)) {
            image = load() is { } loaded ? Upload(loaded) : null;
            _loaded[file] = image;
        }
        if (image is not { } texture) {
            return false;
        }
        gui.Textured(texture.Texture, x, y, w, h, 0, 0, 1, 1);
        return true;
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
    /// A sprite its <c>.mcmeta</c> animates, at the frame its sequence has reached <paramref name="ticks"/> game ticks
    /// in, as the GUI atlas plays it; a still sprite or built in art is drawn as <see cref="Sprite"/> draws it.
    /// </summary>
    public bool AnimatedSprite(GuiRenderer gui, string name, long ticks, float x, float y, float w, float h, uint argb = 0xFFFFFFFF) {
        if (!_animations.TryGetValue(name, out AnimatedFrames? animation)) {
            animation = source?.Animation("pack:minecraft:gui/sprites/" + name) is { } read
                ? new AnimatedFrames(read.Frames.Select(frame => Upload(frame).Texture).ToArray(), read.Sequence)
                : null;
            _animations[name] = animation;
        }
        if (animation == null) {
            return Sprite(gui, name, x, y, w, h, argb);
        }
        gui.Textured(animation.FrameAt(ticks), x, y, w, h, 0, 0, 1, 1, argb);
        return true;
    }

    private readonly Dictionary<string, AnimatedFrames?> _animations = new();

    private sealed record AnimatedFrames(uint[] Textures, (int Index, int Time)[] Sequence) {
        private readonly int _length = Sequence.Sum(frame => frame.Time);

        public uint FrameAt(long ticks) {
            long into = ticks % _length;
            foreach ((int index, int time) in Sequence) {
                if (into < time) {
                    return Textures[index];
                }
                into -= time;
            }
            return Textures[Sequence[0].Index];
        }
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

    /// <summary>A <c>nine_slice</c> sprite over any rectangle: corners once, edges and middle tiled. The border is the caller's, as for <see cref="Sliced"/>.</summary>
    public bool NineSliced(GuiRenderer gui, string name, float x, float y, float w, float h, int border) =>
        NineSliced(gui, name, x, y, w, h, border, border, border, border);

    /// <summary><see cref="NineSliced(GuiRenderer, string, float, float, float, float, int)"/> with a border of its own on each side.</summary>
    public bool NineSliced(GuiRenderer gui, string name, float x, float y, float w, float h, int left, int top, int right, int bottom) {
        if (Get(SpriteFile(name)) is not { } sprite) {
            return false;
        }
        float texW = sprite.Width, texH = sprite.Height;
        // blitNineSlicedSprite: a rectangle narrower than two borders shares it between them.
        int bl = Math.Min(left, (int)w / 2), br = Math.Min(right, (int)w / 2), bt = Math.Min(top, (int)h / 2), bb = Math.Min(bottom, (int)h / 2);
        float[] us = [0, bl, texW - br, texW], vs = [0, bt, texH - bb, texH];
        float[] xs = [x, x + bl, x + w - br, x + w], ys = [y, y + bt, y + h - bb, y + h];
        for (int row = 0; row < 3; row++) {
            for (int column = 0; column < 3; column++) {
                float tileW = us[column + 1] - us[column], tileH = vs[row + 1] - vs[row];
                if (tileW <= 0 || tileH <= 0) {
                    continue;
                }
                for (float dy = ys[row]; dy < ys[row + 1]; dy += tileH) {
                    float partH = Math.Min(tileH, ys[row + 1] - dy);
                    for (float dx = xs[column]; dx < xs[column + 1]; dx += tileW) {
                        float partW = Math.Min(tileW, xs[column + 1] - dx);
                        gui.Textured(sprite.Texture, dx, dy, partW, partH, us[column] / texW, vs[row] / texH,
                            (us[column] + partW) / texW, (vs[row] + partH) / texH);
                    }
                }
            }
        }
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

    /// <summary>
    /// <c>blit</c> of a whole texture with the region's size in it apart from the size drawn: (<paramref name="u"/>,
    /// <paramref name="v"/>) and the region in texture pixels, scaled to the rectangle, repeating past the
    /// texture's edge as a tiled background does.
    /// </summary>
    public bool Blit(GuiRenderer gui, string texture, float x, float y, float w, float h, float u, float v, float regionW, float regionH) {
        if (Get($"assets/minecraft/textures/{texture}.png") is not { } image) {
            return false;
        }
        gui.Textured(image.Texture, x, y, w, h, u / image.Width, v / image.Height, (u + regionW) / image.Width, (v + regionH) / image.Height);
        return true;
    }

    /// <summary>A whole texture's image by its path under <c>textures</c>, for one drawn by other means, as the panorama is.</summary>
    public TextureImage? Texture(string texture) => source?.LoadFirstFrame($"assets/minecraft/textures/{texture}.png");

    /// <summary>
    /// <c>blit</c> with texture coordinates as fractions of the texture, which is how vanilla's declared texture
    /// size makes them whatever resolution the pack's image is; past 1 they repeat.
    /// </summary>
    public bool Stretched(GuiRenderer gui, string texture, float x, float y, float w, float h, float u0, float v0, float u1, float v1, uint argb = 0xFFFFFFFF) {
        if (Get($"assets/minecraft/textures/{texture}.png") is not { } image) {
            return false;
        }
        gui.Textured(image.Texture, x, y, w, h, u0, v0, u1, v1, argb);
        return true;
    }

    /// <summary>
    /// <see cref="Stretched(GuiRenderer, string, float, float, float, float, float, float, float, float, uint)"/> for a texture in any
    /// namespace, by its id as a <c>ClientAsset.ResourceTexture</c> names it: <c>ns:path</c> is <c>assets/ns/textures/path.png</c>.
    /// </summary>
    public bool StretchedTexture(GuiRenderer gui, Minecraft.Schemas.Identifier texture, float x, float y, float w, float h, float u0, float v0, float u1, float v1) {
        if (Get($"assets/{texture.Namespace}/textures/{texture.Key}.png") is not { } image) {
            return false;
        }
        gui.Textured(image.Texture, x, y, w, h, u0, v0, u1, v1);
        return true;
    }

    /// <summary><c>blit</c> of a texture taken to be <paramref name="tile"/> pixels square, repeated over the rectangle as a menu background is.</summary>
    public bool Tiled(GuiRenderer gui, string texture, float x, float y, float w, float h, float tile, uint argb = 0xFFFFFFFF) {
        if (Get($"assets/minecraft/textures/{texture}.png") is not { } image) {
            return false;
        }
        gui.Textured(image.Texture, x, y, w, h, x / tile, y / tile, (x + w) / tile, (y + h) / tile, argb);
        return true;
    }

    public void Dispose() {
        foreach ((uint Texture, int, int)? entry in _loaded.Values) {
            if (entry is { } loaded) {
                gl.DeleteTexture(loaded.Texture);
            }
        }
        foreach (AnimatedFrames? animation in _animations.Values) {
            foreach (uint texture in animation?.Textures ?? []) {
                gl.DeleteTexture(texture);
            }
        }
    }
}
