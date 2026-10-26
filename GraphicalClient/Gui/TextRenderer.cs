using ClientLib;
using GraphicalClient.Rendering;
using System.Numerics;
using System.Text;

namespace GraphicalClient.Gui;

/// <summary>
/// Draws text with a <see cref="Font"/> through the GUI batch, shadowed the way vanilla's HUD text is. A
/// plain string is drawn as vanilla's font draws one, with its section sign codes applied.
/// </summary>
public sealed class TextRenderer : IDisposable {
    public const int LineHeight = 9;

    private readonly GuiRenderer _gui;
    private readonly Font _font;
    private readonly Random _obfuscation = new();
    private Glyph[] _glyphs = new Glyph[64];

    public TextRenderer(GuiRenderer gui, Font font) {
        _gui = gui;
        _font = font;
        Splitter = new StringSplitter((codepoint, style) => {
            Glyph glyph = _font[codepoint];
            return glyph.Advance + (style.Bold ? glyph.ShadowOffset : 0);
        });
    }

    /// <summary><c>Font.getSplitter</c>: measuring and line breaking with this font's advances.</summary>
    public StringSplitter Splitter { get; }

    public int Advance(char c, bool bold = false) => (int)_font[c].Advance + (bold ? 1 : 0);

    public int Width(string text) => (int)MathF.Ceiling(Splitter.StringWidth(text));

    public int Width(IEnumerable<TextRun> runs) => (int)MathF.Ceiling(Splitter.StringWidth(runs));

    /// <returns>The x just past the text.</returns>
    /// <summary>A plain string, in visual order as <c>GuiGraphicsExtractor.text</c> draws one.</summary>
    public float Draw(string text, float x, float y, uint argb = 0xFFFFFFFF, bool shadow = true) {
        if (text.Contains(StringDecomposer.SectionSign) || NeedsReordering(text)) {
            return Draw(TextFlattener.Formatted(text, (int)(argb & 0xFFFFFF)), x, y, (byte)(argb >> 24), shadow);
        }
        ReadOnlySpan<Glyph> glyphs = Glyphs(text, false);
        if (shadow) {
            DrawGlyphs(glyphs, x, y, ShadowOf(argb), false, false, true);
        }
        return DrawGlyphs(glyphs, x, y, argb, false, false, false);
    }

    /// <summary>
    /// Styled runs, put in visual order by <c>Language.getVisualOrder</c> unless <paramref name="bidi"/> is off, as
    /// for an edit box's text, which vanilla draws as typed.
    /// </summary>
    public float Draw(IReadOnlyList<TextRun> runs, float x, float y, byte alpha = 255, bool shadow = true, bool bidi = true) {
        float cursor = x;
        IReadOnlyList<TextRun> decoded = TextFlattener.Decode(runs);
        foreach (TextRun run in bidi ? BidiReorder.Reorder(decoded, Translations.DefaultRightToLeft) : decoded) {
            uint argb = (uint)alpha << 24 | (uint)run.Rgb & 0xFFFFFF;
            ReadOnlySpan<Glyph> glyphs = Glyphs(run.Text, run.Obfuscated);
            if (shadow) {
                DrawStyled(glyphs, cursor, y, ShadowOf(argb), run, true);
            }
            cursor = DrawStyled(glyphs, cursor, y, argb, run, false);
        }
        return cursor;
    }

    /// <summary>Whether a plain string could come out of the bidi pass changed: it holds right to left text, or the language reads that way.</summary>
    private static bool NeedsReordering(string text) {
        if (Translations.DefaultRightToLeft) {
            return true;
        }
        foreach (char c in text) {
            if (c is >= '\u0590' and <= '\u08FF' or >= '\uFB1D' and <= '\uFDFF' or >= '\uFE70' and <= '\uFEFF' or '\u200F') {
                return true;
            }
        }
        return false;
    }

    public void DrawCentred(string text, float centreX, float y, uint argb = 0xFFFFFFFF, bool shadow = true) {
        Draw(text, centreX - Width(text) / 2.0F, y, argb, shadow);
    }

    public void DrawCentred(IReadOnlyList<TextRun> runs, float centreX, float y, byte alpha = 255, bool shadow = true) {
        Draw(runs, centreX - Width(runs) / 2.0F, y, alpha, shadow);
    }

    /// <summary>
    /// <c>Font.getGlyph</c> for each code point. An obfuscated one is <see cref="Font.RandomGlyph"/> of its
    /// width, picked once so the shadow and the text match; a space stays a space.
    /// </summary>
    /// <remarks>The span is a buffer the next call overwrites.</remarks>
    private ReadOnlySpan<Glyph> Glyphs(string text, bool obfuscated) {
        if (_glyphs.Length < text.Length) {
            _glyphs = new Glyph[Math.Max(text.Length, _glyphs.Length * 2)];
        }
        int count = 0;
        foreach (Rune rune in text.EnumerateRunes()) {
            Glyph glyph = _font[rune.Value];
            if (obfuscated && rune.Value != ' ') {
                glyph = _font.RandomGlyph(_obfuscation, (int)MathF.Ceiling(glyph.Advance));
            }
            _glyphs[count++] = glyph;
        }
        return _glyphs.AsSpan(0, count);
    }

    /// <summary>A run, or its shadow, which each glyph offsets by its own shadow offset and the lines by a pixel.</summary>
    private float DrawStyled(ReadOnlySpan<Glyph> glyphs, float x, float y, uint argb, TextRun run, bool shadow) {
        float end = DrawGlyphs(glyphs, x, y, argb, run.Bold, run.Italic, shadow);
        if (shadow) {
            (x, y, end) = (x + 1, y + 1, end + 1);
        }
        float start = x;
        if (run.Underlined) {
            _gui.Rect(start - 1, y + LineHeight - 1, end - start + 1, 1, argb);
        }
        if (run.Strikethrough) {
            _gui.Rect(start - 1, y + 3.5F, end - start + 1, 1, argb);
        }
        return end;
    }

    /// <summary>The glyphs from the pen at <paramref name="x"/>; a shadow is each glyph moved by its shadow offset, and bold a second copy moved by it.</summary>
    private float DrawGlyphs(ReadOnlySpan<Glyph> glyphs, float x, float y, uint argb, bool bold, bool italic, bool shadow) {
        foreach (Glyph glyph in glyphs) {
            if (glyph.Width > 0) {
                float offset = shadow ? glyph.ShadowOffset : 0;
                DrawGlyph(glyph, x + offset, y + offset, argb, italic);
                if (bold) {
                    DrawGlyph(glyph, x + offset + glyph.ShadowOffset, y + offset, argb, italic);
                }
            }
            x += glyph.Advance + (bold ? glyph.ShadowOffset : 0);
        }
        return x;
    }

    /// <summary><c>BakedSheetGlyph.render</c>: italic shears the quad, its top edge right and its bottom edge left of the baseline.</summary>
    private void DrawGlyph(Glyph glyph, float x, float y, uint argb, bool italic) {
        if (!italic) {
            _gui.Textured(_font.Texture, x, y + glyph.Top, glyph.Width, glyph.Height, glyph.U0, glyph.V0, glyph.U1, glyph.V1, argb);
            return;
        }
        float up = glyph.Top, down = glyph.Top + glyph.Height;
        float shearTop = 1.0F - 0.25F * up, shearBottom = 1.0F - 0.25F * down;
        float s = _gui.Scale * _gui.Zoom;
        ReadOnlySpan<Vector2> corners = [
            new((x + shearTop) * s, (y + up) * s), new((x + glyph.Width + shearTop) * s, (y + up) * s),
            new((x + glyph.Width + shearBottom) * s, (y + down) * s), new((x + shearBottom) * s, (y + down) * s)
        ];
        ReadOnlySpan<Vector2> uvs = [new(glyph.U0, glyph.V0), new(glyph.U1, glyph.V0), new(glyph.U1, glyph.V1), new(glyph.U0, glyph.V1)];
        _gui.ScreenQuad(_font.Texture, corners, uvs, argb);
    }

    /// <summary>Vanilla's shadow is the colour at a quarter brightness, same alpha.</summary>
    private static uint ShadowOf(uint argb) {
        uint r = (argb >> 16 & 0xFF) / 4, g = (argb >> 8 & 0xFF) / 4, b = (argb & 0xFF) / 4;
        return (argb & 0xFF000000) | r << 16 | g << 8 | b;
    }

    /// <summary>
    /// <c>ActiveTextCollector.findElementUnderCursor</c> for one line drawn at (<paramref name="x"/>,
    /// <paramref name="y"/>): the run whose glyph, or the space after a blank glyph, is under the point.
    /// </summary>
    public TextRun? RunAt(IReadOnlyList<TextRun> runs, float x, float y, float pointX, float pointY) {
        TextRun? found = null;
        float cursor = x;
        foreach (TextRun run in TextFlattener.Decode(runs)) {
            foreach (Rune rune in run.Text.EnumerateRunes()) {
                Glyph glyph = _font[rune.Value];
                float advance = glyph.Advance + (run.Bold ? glyph.ShadowOffset : 0);
                // EmptyArea for a glyph with nothing to draw: the full line height from the top of the line.
                float top = glyph.Width > 0 ? y + glyph.Top : y;
                float bottom = glyph.Width > 0 ? top + glyph.Height : y + LineHeight;
                if (pointX >= cursor && pointX < cursor + advance && pointY >= top && pointY < bottom) {
                    found = run;
                }
                cursor += advance;
            }
        }
        return found;
    }

    /// <summary><c>Font.split</c>: lines no wider than <paramref name="maxWidth"/>, one empty line for empty text.</summary>
    public List<List<TextRun>> Wrap(IReadOnlyList<TextRun> runs, int maxWidth) {
        List<List<TextRun>> lines = Splitter.SplitLines(TextFlattener.Decode(runs), maxWidth);
        return lines.Count == 0 ? [[]] : lines;
    }

    public void Dispose() => _font.Dispose();
}
