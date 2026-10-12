using System.Text;
using GraphicalClient.Assets.ResourcePacks;
using Newtonsoft.Json.Linq;
using Silk.NET.OpenGL;

namespace GraphicalClient.Gui;

/// <summary>
/// One character's look: where it is in the font texture, the size it is drawn at in GUI pixels with
/// its top <see cref="Top"/> below the line's, and how far the pen moves after it.
/// </summary>
public readonly record struct Glyph(float U0, float V0, float U1, float V1, float Width, float Height, float Top, float Advance);

/// <summary>
/// A bitmap font in one texture, looked up by code point: this client's own <see cref="PixelFont"/>,
/// or a resource pack's <c>font/default.json</c>.
/// </summary>
public sealed unsafe class Font : IDisposable {
    private readonly GL _gl;
    private readonly Dictionary<int, Glyph> _glyphs;
    private readonly Glyph _missing;
    private readonly Dictionary<int, int[]> _byWidth;

    public uint Texture { get; }

    /// <summary>The texture's pixels, for text drawn in the world from another atlas.</summary>
    public TextureImage Atlas { get; }

    private Font(GL gl, int width, int height, byte[] rgba, Dictionary<int, Glyph> glyphs, Glyph missing) {
        _gl = gl;
        _glyphs = glyphs;
        _missing = missing;
        Atlas = new TextureImage(width, height, rgba);
        // The built in font has cells for the control characters, which no pack font maps.
        _byWidth = glyphs.Where(g => g.Key is >= 32 and not 127).GroupBy(g => (int)MathF.Ceiling(g.Value.Advance))
            .ToDictionary(g => g.Key, g => g.Select(e => e.Key).ToArray());
        Texture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, Texture);
        fixed (byte* p = rgba) {
            gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, (uint)width, (uint)height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
    }

    public Glyph this[int codePoint] => _glyphs.TryGetValue(codePoint, out Glyph glyph) ? glyph : _missing;

    /// <summary>
    /// <c>FontSet.getRandomGlyph</c>, what obfuscated text draws: any glyph whose advance rounds up to the
    /// width, else the missing glyph. Vanilla draws from its unifont fallback too, which this font does
    /// not load, so the pick is from fewer glyphs.
    /// </summary>
    public Glyph RandomGlyph(Random random, int width) =>
        _byWidth.TryGetValue(width, out int[]? codes) ? this[codes[random.Next(codes.Length)]] : _missing;

    /// <summary>The built in font: 8 pixel cells, 16 to a row, Latin-1 only.</summary>
    public static Font BuiltIn(GL gl) {
        byte[] atlas = PixelFont.BuildAtlas(out int[] widths);
        Dictionary<int, Glyph> glyphs = new();
        for (int code = 0; code < 256; code++) {
            glyphs[code] = Cell(code % 16, code / 16, widths[code]);
        }
        // Anything else falls back to its unaccented base letter, as the built in font draws accents that way.
        for (int code = 256; code < 0x2000; code++) {
            string decomposed = ((char)code).ToString().Normalize(NormalizationForm.FormD);
            if (decomposed.Length > 0 && decomposed[0] < 256 && decomposed[0] != code) {
                glyphs[code] = glyphs[decomposed[0]];
            }
        }
        return new Font(gl, 128, 128, atlas, glyphs, glyphs['?']);

        static Glyph Cell(int column, int row, int width) => new(
            column * 8 / 128.0F, row * 8 / 128.0F, (column * 8 + width) / 128.0F, (row * 8 + PixelFont.Rows) / 128.0F,
            width, PixelFont.Rows, 0, width + 1);
    }

    /// <summary>
    /// A pack's default font, following <c>reference</c> providers. For each code point the first
    /// provider that has it wins, as <c>FontSet</c> searches. Bitmap and space providers are read;
    /// the unifont fallback is not, so characters only it covers draw as the missing glyph.
    /// </summary>
    public static Font? FromPack(GL gl, PackFiles files, ResourcePackSource source) {
        List<JObject> providers = [];
        Collect(files, "minecraft:default", providers, 0);
        if (providers.Count == 0) {
            return null;
        }

        // Each bitmap page is copied whole into a shelf of the atlas.
        const int atlasWidth = 1024;
        int shelfX = 0, shelfY = 0, shelfHeight = 0;
        List<(JObject Provider, TextureImage Image, int X, int Y)> placed = [];
        foreach (JObject provider in providers) {
            if (provider.Value<string>("type") != "bitmap" || provider.Value<string>("file") is not { } file) {
                continue;
            }
            Minecraft.Schemas.Identifier id = Minecraft.Schemas.Identifier.Parse(file);
            if (source.Load($"assets/{id.Namespace}/textures/{id.Key}") is not { } image || image.Width > atlasWidth) {
                continue;
            }
            if (shelfX + image.Width > atlasWidth) {
                shelfX = 0;
                shelfY += shelfHeight;
                shelfHeight = 0;
            }
            placed.Add((provider, image, shelfX, shelfY));
            shelfX += image.Width;
            shelfHeight = Math.Max(shelfHeight, image.Height);
        }
        int atlasHeight = Math.Max(1, shelfY + shelfHeight);
        byte[] rgba = new byte[atlasWidth * atlasHeight * 4];
        foreach ((_, TextureImage image, int x, int y) in placed) {
            for (int row = 0; row < image.Height; row++) {
                Array.Copy(image.Rgba, row * image.Width * 4, rgba, ((y + row) * atlasWidth + x) * 4, image.Width * 4);
            }
        }

        Dictionary<int, Glyph> glyphs = new();
        foreach (JObject provider in providers) {
            switch (provider.Value<string>("type")) {
                case "space":
                    foreach ((string chars, JToken? advance) in (provider["advances"] as JObject) ?? []) {
                        int code = char.ConvertToUtf32(chars, 0);
                        glyphs.TryAdd(code, new Glyph(0, 0, 0, 0, 0, 0, 0, advance!.Value<float>()));
                    }
                    break;
                case "bitmap":
                    int index = placed.FindIndex(p => p.Provider == provider);
                    if (index >= 0) {
                        AddBitmap(placed[index], atlasWidth, atlasHeight, glyphs);
                    }
                    break;
            }
        }
        if (glyphs.Count == 0) {
            return null;
        }
        Glyph missing = glyphs.TryGetValue('?', out Glyph question) ? question : glyphs.Values.First();
        return new Font(gl, atlasWidth, atlasHeight, rgba, glyphs, missing);
    }

    private static void Collect(PackFiles files, string id, List<JObject> into, int depth) {
        Minecraft.Schemas.Identifier identifier = Minecraft.Schemas.Identifier.Parse(id);
        if (depth > 8 || files.Read($"assets/{identifier.Namespace}/font/{identifier.Key}.json") is not { } data) {
            return;
        }
        JObject json;
        try {
            json = JObject.Parse(Encoding.UTF8.GetString(data));
        }
        catch (Newtonsoft.Json.JsonException) {
            return;
        }
        foreach (JObject provider in (json["providers"] as JArray)?.OfType<JObject>() ?? []) {
            // A reference filtered to uniform fonts only stands in for the default when the player
            // forces unifont; it applies by default otherwise.
            if (provider.Value<string>("type") == "reference" && provider.Value<string>("id") is { } reference) {
                if (provider["filter"]?["uniform"]?.Value<bool>() != true) {
                    Collect(files, reference, into, depth + 1);
                }
            }
            else {
                into.Add(provider);
            }
        }
    }

    /// <summary>
    /// <c>BitmapProvider</c>: the page is a grid with a row per <c>chars</c> string; a glyph's width is
    /// up to its rightmost visible column, drawn scaled so the cell is <c>height</c> pixels tall.
    /// </summary>
    private static void AddBitmap((JObject Provider, TextureImage Image, int X, int Y) page, int atlasWidth, int atlasHeight, Dictionary<int, Glyph> glyphs) {
        (JObject provider, TextureImage image, int px, int py) = page;
        string[] rows = (provider["chars"] as JArray)?.Select(r => r.ToString()).ToArray() ?? [];
        if (rows.Length == 0) {
            return;
        }
        int[][] codes = rows.Select(r => r.EnumerateRunes().Select(rune => rune.Value).ToArray()).ToArray();
        int columns = codes.Max(r => r.Length);
        int cellWidth = image.Width / columns, cellHeight = image.Height / rows.Length;
        float height = provider.Value<float?>("height") ?? 8;
        float ascent = provider.Value<float?>("ascent") ?? 7;
        float scale = height / cellHeight;
        for (int row = 0; row < codes.Length; row++) {
            for (int column = 0; column < codes[row].Length; column++) {
                int code = codes[row][column];
                if (code == 0 || glyphs.ContainsKey(code)) {
                    continue;
                }
                int x0 = column * cellWidth, y0 = row * cellHeight;
                int width = 0;
                for (int x = cellWidth - 1; x >= 0 && width == 0; x--) {
                    for (int y = 0; y < cellHeight; y++) {
                        if (image.Rgba[((y0 + y) * image.Width + x0 + x) * 4 + 3] != 0) {
                            width = x + 1;
                            break;
                        }
                    }
                }
                glyphs[code] = new Glyph(
                    (px + x0) / (float)atlasWidth, (py + y0) / (float)atlasHeight,
                    (px + x0 + width) / (float)atlasWidth, (py + y0 + cellHeight) / (float)atlasHeight,
                    width * scale, height, 7 - ascent, (int)(0.5F + width * scale) + 1);
            }
        }
    }

    public void Dispose() => _gl.DeleteTexture(Texture);
}
