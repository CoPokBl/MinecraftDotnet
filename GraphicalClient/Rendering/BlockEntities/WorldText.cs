using System.Numerics;
using System.Text;
using ClientLib;
using GraphicalClient.Gui;
using GraphicalClient.Rendering.Entities;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary>
/// <c>Font.drawInBatch</c> for text in the world: the GUI font's glyphs as quads in the entity batch,
/// laid out in font pixels with y growing downward, as the pose a renderer sets up expects.
/// </summary>
public sealed class WorldText(Font font, EntityTextures textures) {
    private readonly Random _obfuscation = new();

    private EntityTexture Atlas => textures.Get("font:default", () => font.Atlas) ?? textures.Missing;

    private float Advance(int codePoint, bool bold) => font[codePoint].Advance + (bold ? 1 : 0);

    /// <summary><c>Font.width</c>: the advances, rounded up.</summary>
    public int Width(IReadOnlyList<TextRun> runs) {
        float width = 0;
        foreach (TextRun run in runs) {
            foreach (Rune rune in run.Text.EnumerateRunes()) {
                width += Advance(rune.Value, run.Bold);
            }
        }
        return (int)MathF.Ceiling(width);
    }

    /// <summary>
    /// <c>Font.split(text, maxWidth).get(0)</c>: as much as fits, broken after the last space that lets
    /// it, or mid word when none does. Empty for empty text.
    /// </summary>
    public List<TextRun> FirstLine(IReadOnlyList<TextRun> runs, int maxWidth) {
        List<(TextRun Run, Rune Rune)> characters = [];
        foreach (TextRun run in runs) {
            foreach (Rune rune in run.Text.EnumerateRunes()) {
                if (rune.Value == '\n') {
                    return Join(characters);
                }
                characters.Add((run, rune));
            }
        }
        float width = 0;
        int lastSpace = -1;
        for (int i = 0; i < characters.Count; i++) {
            width += Advance(characters[i].Rune.Value, characters[i].Run.Bold);
            if (width > maxWidth) {
                return Join(characters.GetRange(0, lastSpace >= 0 ? lastSpace + 1 : Math.Max(1, i)));
            }
            if (characters[i].Rune.Value == ' ') {
                lastSpace = i;
            }
        }
        return Join(characters);
    }

    private static List<TextRun> Join(List<(TextRun Run, Rune Rune)> characters) {
        List<TextRun> runs = [];
        foreach ((TextRun run, Rune rune) in characters) {
            if (runs.Count > 0 && runs[^1] with { Text = "" } == run with { Text = "" }) {
                runs[^1] = runs[^1] with { Text = runs[^1].Text + rune };
            }
            else {
                runs.Add(run with { Text = rune.ToString() });
            }
        }
        return runs;
    }

    /// <summary>
    /// A line at <paramref name="x"/>, <paramref name="y"/>, each run in its own colour at
    /// <paramref name="alpha"/>; a non-zero <paramref name="outlineArgb"/> first draws
    /// <c>prepare8xTextOutline</c>'s eight copies one pixel out, just behind the text.
    /// </summary>
    public void Draw(IReadOnlyList<TextRun> runs, float x, float y, byte alpha, uint outlineArgb, PoseStack pose, IModelSink sink, float skyLight, float blockLight) {
        if (outlineArgb != 0) {
            for (int xo = -1; xo <= 1; xo++) {
                for (int yo = -1; yo <= 1; yo++) {
                    if (xo != 0 || yo != 0) {
                        DrawLine(runs, x + xo, y + yo, 0.0F, run => outlineArgb, false, pose, sink, skyLight, blockLight);
                    }
                }
            }
        }
        DrawLine(runs, x, y, outlineArgb != 0 ? 0.05F : 0.0F, run => (uint)alpha << 24 | (uint)run.Rgb & 0xFFFFFF, true, pose, sink, skyLight, blockLight);
    }

    /// <summary>The glyphs and, with <paramref name="effects"/>, the underline and strikethrough bars; z is toward the reader.</summary>
    private void DrawLine(IReadOnlyList<TextRun> runs, float x, float y, float z, Func<TextRun, uint> colour, bool effects, PoseStack pose, IModelSink sink,
        float skyLight, float blockLight) {
        EntityTexture atlas = Atlas;
        Vector3 normal = pose.TransformNormal(Vector3.UnitZ);
        Matrix4x4 matrix = pose.Matrix;
        foreach (TextRun run in runs) {
            ModelDrawState draw = new(atlas, colour(run), skyLight, blockLight, 0);
            float start = x;
            foreach (Rune rune in run.Text.EnumerateRunes()) {
                Glyph glyph = font[rune.Value];
                if (run.Obfuscated && rune.Value != ' ') {
                    glyph = font[_obfuscation.Next('!', '~')];
                }
                if (glyph.Width > 0) {
                    Emit(glyph, x, y, z, run.Italic, matrix, normal, sink, draw);
                    if (run.Bold) {
                        Emit(glyph, x + 1, y, z + 0.01F, run.Italic, matrix, normal, sink, draw);
                    }
                }
                x += font[rune.Value].Advance + (run.Bold ? 1 : 0);
            }
            ModelDrawState bar = draw with { Texture = textures.White };
            if (effects && run.Underlined) {
                Quad(matrix, start - 1, y + TextRenderer.LineHeight - 1, x, y + TextRenderer.LineHeight, z, 0, 0, 0, 0, 1, 1, normal, sink, bar);
            }
            if (effects && run.Strikethrough) {
                Quad(matrix, start - 1, y + 3.5F, x, y + 4.5F, z, 0, 0, 0, 0, 1, 1, normal, sink, bar);
            }
        }
    }

    /// <summary><c>BakedSheetGlyph.render</c>: an italic glyph leans by its shear at its top and bottom edge.</summary>
    private static void Emit(Glyph glyph, float x, float y, float z, bool italic, Matrix4x4 matrix, Vector3 normal, IModelSink sink, ModelDrawState draw) {
        float y0 = y + glyph.Top, y1 = y + glyph.Top + glyph.Height;
        float shearTop = italic ? 1.0F - 0.25F * glyph.Top : 0.0F, shearBottom = italic ? 1.0F - 0.25F * (glyph.Top + glyph.Height) : 0.0F;
        Quad(matrix, x, y0, x + glyph.Width, y1, z, shearTop, shearBottom, glyph.U0, glyph.V0, glyph.U1, glyph.V1, normal, sink, draw);
    }

    /// <summary>A rectangle with its top edge moved by <paramref name="shearTop"/> and its bottom by <paramref name="shearBottom"/>.</summary>
    private static void Quad(Matrix4x4 matrix, float x0, float y0, float x1, float y1, float z, float shearTop, float shearBottom, float u0, float v0, float u1,
        float v1, Vector3 normal, IModelSink sink, ModelDrawState draw) {
        ReadOnlySpan<Vector3> corners = [
            Vector3.Transform(new Vector3(x0 + shearTop, y0, z), matrix), Vector3.Transform(new Vector3(x0 + shearBottom, y1, z), matrix),
            Vector3.Transform(new Vector3(x1 + shearBottom, y1, z), matrix), Vector3.Transform(new Vector3(x1 + shearTop, y0, z), matrix)
        ];
        ReadOnlySpan<Vector2> uvs = [new(u0, v0), new(u0, v1), new(u1, v1), new(u1, v0)];
        sink.Quad(corners, uvs, normal, draw);
    }
}
