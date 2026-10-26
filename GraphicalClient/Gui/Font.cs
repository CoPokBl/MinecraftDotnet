using System.Text;
using GraphicalClient.Assets.ResourcePacks;
using Newtonsoft.Json.Linq;
using Silk.NET.OpenGL;

namespace GraphicalClient.Gui;

/// <summary>
/// One character's look: where it is in the font texture, the size it is drawn at in GUI pixels with
/// its top <see cref="Top"/> below the line's, and how far the pen moves after it.
/// </summary>
/// <param name="ShadowOffset"><c>GlyphInfo.getShadowOffset</c>, which is also its bold offset: half a pixel for a unifont glyph.</param>
public readonly record struct Glyph(float U0, float V0, float U1, float V1, float Width, float Height, float Top, float Advance, float ShadowOffset = 1.0F);

/// <summary>
/// A bitmap font in one texture, looked up by code point: this client's own <see cref="PixelFont"/>,
/// or the packs' <c>font/default.json</c> over it. A pack's unifont glyphs are drawn into a spare part of
/// the texture the first time each is asked for, as the full set would not fit.
/// </summary>
public sealed unsafe class Font : IDisposable {
    private readonly GL _gl;
    private readonly Dictionary<int, Glyph> _glyphs;
    private readonly Dictionary<int, Glyph> _builtIn;
    private Glyph _missing;
    private readonly Dictionary<int, int[]> _byWidth;
    private readonly List<Dictionary<int, UnihexGlyph>> _unihex;
    private readonly Dictionary<int, Glyph> _lazy = new();
    private readonly int _glThread = Environment.CurrentManagedThreadId;
    private readonly int _lazyTop;
    private int _shelfX, _shelfY;

    public uint Texture { get; }

    /// <summary>The texture's pixels, for text drawn in the world from another atlas.</summary>
    public TextureImage Atlas { get; }

    /// <summary>Counts the unifont glyphs drawn into <see cref="Atlas"/> so far, so a copy of it can tell it is stale.</summary>
    public int AtlasVersion { get; private set; }

    private Font(GL gl, int width, int height, byte[] rgba, Dictionary<int, Glyph> glyphs, Glyph missing,
        List<Dictionary<int, UnihexGlyph>>? unihex = null, int lazyTop = 0, Dictionary<int, Glyph>? builtIn = null) {
        _gl = gl;
        _glyphs = glyphs;
        _builtIn = builtIn ?? [];
        _missing = missing;
        _unihex = unihex ?? [];
        _lazyTop = lazyTop;
        _shelfY = lazyTop;
        Atlas = new TextureImage(width, height, rgba);
        // The built in font has cells for the control characters, which no pack font maps.
        _byWidth = glyphs.Concat(_builtIn.Where(g => !glyphs.ContainsKey(g.Key))).Where(g => g.Key is >= 32 and not 127).GroupBy(g => (int)MathF.Ceiling(g.Value.Advance))
            .ToDictionary(g => g.Key, g => g.Select(e => e.Key).ToArray());
        Texture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, Texture);
        fixed (byte* p = rgba) {
            gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, (uint)width, (uint)height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
    }

    public Glyph this[int codePoint] =>
        _glyphs.TryGetValue(codePoint, out Glyph glyph) ? glyph
        : _unihex.Count > 0 && Unihex(codePoint) is { } unifont ? unifont
        : _builtIn.TryGetValue(codePoint, out glyph) ? glyph : _missing;

    /// <summary>
    /// A unifont glyph, drawn into the texture's spare rows on the game thread; text drawn in the world copies
    /// the texture again when <see cref="AtlasVersion"/> moves.
    /// </summary>
    private Glyph? Unihex(int codePoint) {
        lock (_lazy) {
            if (_lazy.TryGetValue(codePoint, out Glyph known)) {
                return known;
            }
            UnihexGlyph? found = null;
            foreach (Dictionary<int, UnihexGlyph> provider in _unihex) {
                if (provider.TryGetValue(codePoint, out UnihexGlyph g)) {
                    found = g;
                    break;
                }
            }
            if (found is not { } source || Environment.CurrentManagedThreadId != _glThread) {
                return null;
            }
            int width = source.Right - source.Left + 1;
            if (_shelfX + width > Atlas.Width) {
                _shelfX = 0;
                _shelfY += UnihexGlyph.Height;
            }
            if (width <= 0 || width > Atlas.Width || _shelfY + UnihexGlyph.Height > Atlas.Height) {
                return null;
            }
            int x = _shelfX, y = _shelfY;
            _shelfX += width + 1;
            byte[] pixels = source.Unpack();
            for (int row = 0; row < UnihexGlyph.Height; row++) {
                Array.Copy(pixels, row * width * 4, Atlas.Rgba, ((y + row) * Atlas.Width + x) * 4, width * 4);
            }
            _gl.BindTexture(TextureTarget.Texture2D, Texture);
            fixed (byte* p = pixels) {
                _gl.TexSubImage2D(TextureTarget.Texture2D, 0, x, y, (uint)width, UnihexGlyph.Height, PixelFormat.Rgba, PixelType.UnsignedByte, p);
            }
            // UnihexProvider.Glyph: oversampled twice, so half its pixels wide, eight tall from the line's top.
            Glyph glyph = new(x / (float)Atlas.Width, y / (float)Atlas.Height, (x + width) / (float)Atlas.Width, (y + UnihexGlyph.Height) / (float)Atlas.Height,
                width / 2.0F, 8, 0, width / 2.0F + 1.0F, 0.5F);
            _lazy[codePoint] = glyph;
            AtlasVersion++;
            return glyph;
        }
    }

    /// <summary>
    /// <c>FontSet.getRandomGlyph</c>, what obfuscated text draws: any glyph whose advance rounds up to the
    /// width, else the missing glyph. Vanilla draws from its unifont fallback too, which this does not
    /// search, so the pick is from fewer glyphs.
    /// </summary>
    public Glyph RandomGlyph(Random random, int width) =>
        _byWidth.TryGetValue(width, out int[]? codes) ? this[codes[random.Next(codes.Length)]] : _missing;

    /// <summary>The built in font: 8 pixel cells, 16 to a row, Latin-1 only.</summary>
    public static Font BuiltIn(GL gl) {
        Dictionary<int, Glyph> glyphs = BuiltInGlyphs(0, 0, BuiltInSize, BuiltInSize, out byte[] atlas);
        return new Font(gl, BuiltInSize, BuiltInSize, atlas, glyphs, glyphs['?']);
    }

    private const int BuiltInSize = 128;

    /// <summary>The built in font's glyphs with its page at (<paramref name="x"/>, <paramref name="y"/>) in an atlas of the given size.</summary>
    private static Dictionary<int, Glyph> BuiltInGlyphs(int x, int y, int atlasWidth, int atlasHeight, out byte[] page) {
        page = PixelFont.BuildAtlas(out int[] widths);
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
        return glyphs;

        Glyph Cell(int column, int row, int width) => new(
            (x + column * 8) / (float)atlasWidth, (y + row * 8) / (float)atlasHeight,
            (x + column * 8 + width) / (float)atlasWidth, (y + row * 8 + PixelFont.Rows) / (float)atlasHeight,
            width, PixelFont.Rows, 0, width + 1);
    }

    /// <summary>
    /// The packs' default font, following <c>reference</c> providers and keeping those whose <c>filter</c>
    /// matches <paramref name="options"/> (<c>uniform</c>, <c>jp</c>), as <c>FontManager</c> does. For each code
    /// point the first provider that has it wins, as <c>FontSet</c> searches, except that the bitmap and space
    /// providers are all searched before any unihex one, which only matters to a pack ordering them otherwise.
    /// The built in font is searched last, standing in for vanilla's own pack, which a pack's font adds to
    /// rather than replaces: a server's font defining only its private use glyphs still has letters under it.
    /// </summary>
    public static Font? FromPack(GL gl, PackFiles files, ResourcePackSource source, IReadOnlySet<string>? options = null) {
        List<JObject> providers = [];
        Collect(files, "minecraft:default", providers, 0, options ?? new HashSet<string>());
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
        if (shelfX + BuiltInSize > atlasWidth) {
            shelfX = 0;
            shelfY += shelfHeight;
            shelfHeight = 0;
        }
        int builtInX = shelfX, builtInY = shelfY;
        shelfHeight = Math.Max(shelfHeight, BuiltInSize);
        List<Dictionary<int, UnihexGlyph>> unihex = [];
        foreach (JObject provider in providers) {
            if (provider.Value<string>("type") == "unihex" && UnihexGlyph.Load(files, provider) is { } loaded) {
                unihex.Add(loaded);
            }
        }
        int lazyTop = shelfY + shelfHeight;
        // Room for a few thousand unifont glyphs, drawn in as they are first needed.
        int atlasHeight = Math.Max(1, lazyTop + (unihex.Count > 0 ? 1024 : 0));
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
        if (glyphs.Count == 0 && unihex.Count == 0) {
            return null;
        }
        Dictionary<int, Glyph> builtIn = BuiltInGlyphs(builtInX, builtInY, atlasWidth, atlasHeight, out byte[] builtInPage);
        for (int row = 0; row < BuiltInSize; row++) {
            Array.Copy(builtInPage, row * BuiltInSize * 4, rgba, ((builtInY + row) * atlasWidth + builtInX) * 4, BuiltInSize * 4);
        }
        Font font = new(gl, atlasWidth, atlasHeight, rgba, glyphs, builtIn['?'], unihex, lazyTop, builtIn);
        if (glyphs.TryGetValue('?', out Glyph question)) {
            font._missing = question;
        }
        else if (font.Unihex('?') is { } unifontQuestion) {
            font._missing = unifontQuestion;
        }
        return font;
    }

    /// <summary>
    /// <c>FontManager.loadResourceStack</c> and the reversal <c>apply</c> makes of it: the font's file from every
    /// pack, the highest first, each in its own order. A file that does not parse is skipped alone.
    /// </summary>
    private static void Collect(PackFiles files, string id, List<JObject> into, int depth, IReadOnlySet<string> options) {
        if (depth > 8) {
            return;
        }
        Minecraft.Schemas.Identifier identifier = Minecraft.Schemas.Identifier.Parse(id);
        foreach (byte[] data in files.ReadEach($"assets/{identifier.Namespace}/font/{identifier.Key}.json").Reverse()) {
            JObject json;
            try {
                json = JObject.Parse(Encoding.UTF8.GetString(data));
            }
            catch (Newtonsoft.Json.JsonException) {
                continue;
            }
            CollectProviders(files, json, into, depth, options);
        }
    }

    private static void CollectProviders(PackFiles files, JObject json, List<JObject> into, int depth, IReadOnlySet<string> options) {
        foreach (JObject provider in (json["providers"] as JArray)?.OfType<JObject>() ?? []) {
            // FontOption.Filter: every option named must be on or off as it says.
            if (provider["filter"] is JObject filter && filter.Properties().Any(f => f.Value.Type != JTokenType.Boolean || options.Contains(f.Name) != f.Value.Value<bool>())) {
                continue;
            }
            if (provider.Value<string>("type") == "reference" && provider.Value<string>("id") is { } reference) {
                Collect(files, reference, into, depth + 1, options);
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

/// <summary>
/// <c>UnihexProvider.Glyph</c>: one glyph of a <c>.hex</c> file, sixteen rows of up to 32 bits with the most
/// significant bit leftmost, and the columns it is cut to.
/// </summary>
internal readonly record struct UnihexGlyph(int[] Lines, int Left, int Right) {
    public const int Height = 16;

    /// <summary><c>unpackBitsToBytes</c>: white where a bit is set, clear elsewhere.</summary>
    public byte[] Unpack() {
        int width = Right - Left + 1;
        byte[] rgba = new byte[width * Height * 4];
        for (int row = 0; row < Height; row++) {
            for (int column = 0; column < width; column++) {
                int bit = 31 - Left - column;
                if (bit is >= 0 and < 32 && (Lines[row] >> bit & 1) != 0) {
                    rgba.AsSpan((row * width + column) * 4, 4).Fill(0xFF);
                }
            }
        }
        return rgba;
    }

    /// <summary>
    /// <c>UnihexProvider.Definition.loadData</c>: every <c>.hex</c> in the zip, the <c>size_overrides</c> ranges cut
    /// to their given columns and the rest to their set bits. Null when the file is missing or does not parse.
    /// </summary>
    public static Dictionary<int, UnihexGlyph>? Load(PackFiles files, JObject provider) {
        if (provider.Value<string>("hex_file") is not { } hexFile) {
            return null;
        }
        Minecraft.Schemas.Identifier id = Minecraft.Schemas.Identifier.Parse(hexFile);
        if (files.Read($"assets/{id.Namespace}/{id.Key}") is not { } zip) {
            return null;
        }
        Dictionary<int, (int[] Lines, int BitWidth)> bits = new();
        try {
            using System.IO.Compression.ZipArchive archive = new(new MemoryStream(zip));
            foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries) {
                if (!entry.FullName.EndsWith(".hex", StringComparison.Ordinal)) {
                    continue;
                }
                using StreamReader reader = new(entry.Open(), Encoding.ASCII);
                while (reader.ReadLine() is { } line) {
                    if (line.Length > 0) {
                        (int codePoint, int[] lines, int bitWidth) = ParseLine(line);
                        bits[codePoint] = (lines, bitWidth);
                    }
                }
            }
        }
        catch (Exception e) when (e is InvalidDataException or FormatException or ArgumentException) {
            Console.WriteLine($"Unifont {hexFile} did not load: {e.Message}");
            return null;
        }
        Dictionary<int, UnihexGlyph> glyphs = new(bits.Count);
        foreach (JObject range in (provider["size_overrides"] as JArray)?.OfType<JObject>() ?? []) {
            int from = char.ConvertToUtf32(range.Value<string>("from")!, 0), to = char.ConvertToUtf32(range.Value<string>("to")!, 0);
            int left = range.Value<int>("left"), right = range.Value<int>("right");
            for (int c = from; c <= to; c++) {
                if (bits.Remove(c, out (int[] Lines, int) found)) {
                    glyphs[c] = new UnihexGlyph(found.Lines, left, right);
                }
            }
        }
        foreach ((int codePoint, (int[] lines, int bitWidth)) in bits) {
            // LineData.calculateWidth: the set columns, or the whole cell and one more for a blank glyph.
            int mask = lines.Aggregate(0, (a, b) => a | b);
            glyphs[codePoint] = mask == 0 ? new UnihexGlyph(lines, 0, bitWidth)
                : new UnihexGlyph(lines, System.Numerics.BitOperations.LeadingZeroCount((uint)mask), 32 - System.Numerics.BitOperations.TrailingZeroCount(mask) - 1);
        }
        return glyphs;
    }

    /// <summary><c>readFromStream</c>'s line: four to six hex digits, a colon, then 32, 64, 96 or 128 hex digits.</summary>
    private static (int CodePoint, int[] Lines, int BitWidth) ParseLine(string line) {
        int colon = line.IndexOf(':');
        if (colon is < 4 or > 6) {
            throw new FormatException($"Invalid entry {line}: expected 4, 5 or 6 hex digits followed by a colon");
        }
        int codePoint = Convert.ToInt32(line[..colon], 16);
        string data = line[(colon + 1)..];
        int bitWidth = data.Length switch {
            32 => 8,
            64 => 16,
            96 => 24,
            128 => 32,
            _ => throw new FormatException($"Invalid entry {line}: expected an (8,16,24,32) x 16 bitmap")
        };
        int digits = bitWidth / 4;
        int[] lines = new int[Height];
        for (int row = 0; row < Height; row++) {
            lines[row] = (int)(Convert.ToUInt32(data.Substring(row * digits, digits), 16) << (32 - bitWidth));
        }
        return (codePoint, lines, bitWidth);
    }
}
