using System.Text;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace ClientLib;

/// <summary>A piece of text in one style, the unit a text renderer draws.</summary>
public readonly record struct TextRun(
    string Text,
    int Rgb,
    bool Bold = false,
    bool Italic = false,
    bool Underlined = false,
    bool Strikethrough = false,
    bool Obfuscated = false,
    ClickEvent? Click = null,
    HoverEvent? Hover = null,
    string? Insertion = null) {
    public RunStyle Style => new(Rgb, Bold, Italic, Underlined, Strikethrough, Obfuscated, Click, Hover, Insertion);

    public static TextRun Of(string text, RunStyle style) =>
        new(text, style.Rgb, style.Bold, style.Italic, style.Underlined, style.Strikethrough, style.Obfuscated, style.Click, style.Hover, style.Insertion);
}

/// <summary>A run's style without its text: vanilla's <c>Style</c> with the colour resolved and the font left out.</summary>
public readonly record struct RunStyle(
    int Rgb,
    bool Bold = false,
    bool Italic = false,
    bool Underlined = false,
    bool Strikethrough = false,
    bool Obfuscated = false,
    ClickEvent? Click = null,
    HoverEvent? Hover = null,
    string? Insertion = null);

/// <summary>
/// Turns a text component into styled runs. An untranslated key falls back to the component's fallback,
/// then to the key and its arguments.
/// </summary>
public static class TextFlattener {
    public const int DefaultRgb = 0xFFFFFF;

    public static string Plain(TextComponent component) => string.Concat(Flatten(component).Select(run => run.Text));

    public static List<TextRun> Flatten(TextComponent component, int defaultRgb = DefaultRgb) {
        List<TextRun> runs = [];
        Append(component, new RunStyle(defaultRgb), runs, 0);
        return runs;
    }

    /// <summary>A plain string as vanilla's font draws one, through <c>StringDecomposer.iterateFormatted</c> from an empty style.</summary>
    public static List<TextRun> Formatted(string text, int defaultRgb = DefaultRgb) {
        List<TextRun> runs = [];
        AppendLegacy(text, new RunStyle(defaultRgb), runs);
        return runs;
    }

    /// <summary>
    /// The runs with any section sign codes still in their text applied, as drawing a component's
    /// parts does. The list itself when there are none.
    /// </summary>
    public static IReadOnlyList<TextRun> Decode(IReadOnlyList<TextRun> runs) {
        bool any = false;
        foreach (TextRun run in runs) {
            any |= run.Text.Contains(StringDecomposer.SectionSign);
        }
        if (!any) {
            return runs;
        }
        List<TextRun> decoded = [];
        foreach (TextRun run in runs) {
            AppendLegacy(run.Text, run.Style, decoded);
        }
        return decoded;
    }

    private static void Append(TextComponent component, RunStyle parent, List<TextRun> runs, int depth) {
        if (depth > 32) {
            return;
        }

        RunStyle style = new(
            component.Color?.ToDecimal() ?? parent.Rgb,
            component.Bold ?? parent.Bold,
            component.Italic ?? parent.Italic,
            component.Underlined ?? parent.Underlined,
            component.Strikethrough ?? parent.Strikethrough,
            component.Obfuscated ?? parent.Obfuscated,
            component.ClickEvent ?? parent.Click,
            component.HoverEvent ?? parent.Hover,
            component.Insertion ?? parent.Insertion);

        TextContent content = component.Content;
        if (content.Type == "translatable") {
            AppendTranslation(content, style, runs, depth);
        }
        else {
            AppendLegacy(content.Type switch {
                "text" or "keybind" or "selector" => Field(content, content.Type),
                "score" => "?",
                _ => $"[{content.Type}]"
            }, style, runs);
        }

        foreach (TextComponent child in component.Children) {
            Append(child, style, runs, depth + 1);
        }
    }

    private static string Field(TextContent content, string key) {
        foreach ((string k, INbtTag tag) in content.Fields) {
            if (k == key) {
                return tag is StringTag s ? s.Value : tag.ToString() ?? "";
            }
        }
        return "";
    }

    private static void AppendTranslation(TextContent content, RunStyle style, List<TextRun> runs, int depth) {
        string key = Field(content, "translate");
        TextComponent[] args = [];
        foreach ((string k, INbtTag tag) in content.Fields) {
            if (k == "with" && tag is ListTag list) {
                args = list.Tags.ToArray().Select(t => TextComponent.FromTag(t)).ToArray();
            }
        }

        string? format = Translations.Get(key);
        if (format == null) {
            string fallback = Field(content, "fallback");
            format = fallback.Length > 0 ? fallback : null;
        }

        if (format == null) {
            AppendLegacy(key, style, runs);
            if (args.Length > 0) {
                AppendLegacy(" [", style, runs);
                for (int i = 0; i < args.Length; i++) {
                    if (i > 0) {
                        AppendLegacy(", ", style, runs);
                    }
                    Append(args[i], style, runs, depth + 1);
                }
                AppendLegacy("]", style, runs);
            }
            return;
        }

        // Java's Formatter subset vanilla's TranslatableContents.decomposeTemplate accepts: %s, %n$s and %%.
        int next = 0;
        int literalStart = 0;
        for (int i = 0; i < format.Length; i++) {
            if (format[i] != '%' || i + 1 >= format.Length) {
                continue;
            }

            if (format[i + 1] == '%') {
                AppendLegacy(format[literalStart..i] + "%", style, runs);
                i++;
                literalStart = i + 1;
                continue;
            }

            int j = i + 1;
            int? explicitIndex = null;
            while (j < format.Length && char.IsDigit(format[j])) {
                j++;
            }
            if (j > i + 1 && j < format.Length && format[j] == '$') {
                explicitIndex = int.Parse(format[(i + 1)..j]) - 1;
                j++;
            }
            else {
                j = i + 1;
            }
            if (j >= format.Length || format[j] != 's') {
                continue;
            }

            AppendLegacy(format[literalStart..i], style, runs);
            int argIndex = explicitIndex ?? next++;
            if (argIndex >= 0 && argIndex < args.Length) {
                Append(args[argIndex], style, runs, depth + 1);
            }
            i = j;
            literalStart = j + 1;
        }
        AppendLegacy(format[literalStart..], style, runs);
    }

    /// <summary>
    /// Literal text can still carry section sign codes, which vanilla applies to each literal part on its
    /// own: a code never reaches the next part, and <c>r</c> resets to the part's own style.
    /// </summary>
    private static void AppendLegacy(string text, RunStyle style, List<TextRun> runs) {
        if (text.Length == 0) {
            return;
        }
        if (!text.Contains(StringDecomposer.SectionSign)) {
            runs.Add(TextRun.Of(text, style));
            return;
        }

        StringBuilder piece = new();
        RunStyle pieceStyle = style;
        StringDecomposer.IterateFormatted(text, 0, style, style, (_, charStyle, codepoint) => {
            if (charStyle != pieceStyle && piece.Length > 0) {
                runs.Add(TextRun.Of(piece.ToString(), pieceStyle));
                piece.Clear();
            }
            pieceStyle = charStyle;
            piece.Append(char.ConvertFromUtf32(codepoint));
            return true;
        });
        if (piece.Length > 0) {
            runs.Add(TextRun.Of(piece.ToString(), pieceStyle));
        }
    }
}
