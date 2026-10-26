namespace ClientLib;

/// <summary><c>FormattedCharSink</c>: one code point at a char index in a style, false to stop.</summary>
public delegate bool FormattedCharSink(int position, RunStyle style, int codepoint);

/// <summary><c>StringDecomposer</c>: a string as code points, with or without its section sign formatting codes applied.</summary>
public static class StringDecomposer {
    public const char SectionSign = '\u00A7';
    private const int ReplacementChar = 0xFFFD;

    private static bool FeedChar(RunStyle style, FormattedCharSink output, int pos, char ch) =>
        char.IsSurrogate(ch) ? output(pos, style, ReplacementChar) : output(pos, style, ch);

    public static bool Iterate(string text, RunStyle style, FormattedCharSink output) {
        int size = text.Length;
        for (int i = 0; i < size; i++) {
            char ch = text[i];
            if (char.IsHighSurrogate(ch)) {
                if (i + 1 >= size) {
                    if (!output(i, style, ReplacementChar)) {
                        return false;
                    }
                    break;
                }
                char low = text[i + 1];
                if (char.IsLowSurrogate(low)) {
                    if (!output(i, style, char.ConvertToUtf32(ch, low))) {
                        return false;
                    }
                    i++;
                }
                else if (!output(i, style, ReplacementChar)) {
                    return false;
                }
            }
            else if (!FeedChar(style, output, i, ch)) {
                return false;
            }
        }
        return true;
    }

    public static bool IterateBackwards(string text, RunStyle style, FormattedCharSink output) {
        for (int i = text.Length - 1; i >= 0; i--) {
            char ch = text[i];
            if (char.IsLowSurrogate(ch)) {
                if (i - 1 < 0) {
                    if (!output(0, style, ReplacementChar)) {
                        return false;
                    }
                    break;
                }
                char high = text[i - 1];
                if (char.IsHighSurrogate(high)) {
                    if (!output(--i, style, char.ConvertToUtf32(high, ch))) {
                        return false;
                    }
                }
                else if (!output(i, style, ReplacementChar)) {
                    return false;
                }
            }
            else if (!FeedChar(style, output, i, ch)) {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// <c>iterateFormatted</c>: a section sign and the character after it are dropped, and change the style
    /// when that character is a formatting code. A section sign at the very end is dropped too.
    /// </summary>
    public static bool IterateFormatted(string text, int offset, RunStyle currentStyle, RunStyle resetStyle, FormattedCharSink output) {
        int size = text.Length;
        RunStyle style = currentStyle;
        for (int i = offset; i < size; i++) {
            char ch = text[i];
            if (ch == SectionSign) {
                if (i + 1 >= size) {
                    break;
                }
                if (ApplyCode(style, resetStyle, text[i + 1]) is { } formatted) {
                    style = formatted;
                }
                i++;
            }
            else if (char.IsHighSurrogate(ch)) {
                if (i + 1 >= size) {
                    if (!output(i, style, ReplacementChar)) {
                        return false;
                    }
                    break;
                }
                char low = text[i + 1];
                if (char.IsLowSurrogate(low)) {
                    if (!output(i, style, char.ConvertToUtf32(ch, low))) {
                        return false;
                    }
                    i++;
                }
                else if (!output(i, style, ReplacementChar)) {
                    return false;
                }
            }
            else if (!FeedChar(style, output, i, ch)) {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// <c>ChatFormatting.getByCode</c> then <c>Style.applyLegacyFormat</c>, with <c>r</c> going back to the
    /// reset style. A colour clears the decorations; a decoration adds to what is there. Null for a
    /// character that is not a code.
    /// </summary>
    public static RunStyle? ApplyCode(RunStyle style, RunStyle resetStyle, char code) {
        return char.ToLowerInvariant(code) switch {
            'k' => style with { Obfuscated = true },
            'l' => style with { Bold = true },
            'm' => style with { Strikethrough = true },
            'n' => style with { Underlined = true },
            'o' => style with { Italic = true },
            'r' => resetStyle,
            var c when LegacyColour(c) is { } rgb => style with {
                Rgb = rgb, Obfuscated = false, Bold = false, Strikethrough = false, Underlined = false, Italic = false
            },
            _ => null
        };
    }

    /// <summary>The sixteen <c>ChatFormatting</c> colours by code, which team colours number in the same order.</summary>
    public static int? LegacyColour(char code) => code switch {
        '0' => 0x000000, '1' => 0x0000AA, '2' => 0x00AA00, '3' => 0x00AAAA,
        '4' => 0xAA0000, '5' => 0xAA00AA, '6' => 0xFFAA00, '7' => 0xAAAAAA,
        '8' => 0x555555, '9' => 0x5555FF, 'a' => 0x55FF55, 'b' => 0x55FFFF,
        'c' => 0xFF5555, 'd' => 0xFF55FF, 'e' => 0xFFFF55, 'f' => 0xFFFFFF,
        _ => null
    };
}
