using System.Globalization;

namespace ClientLib.Brigadier;

/// <summary>Java library behaviour the command parsers rely on, where .NET's nearest equivalent answers differently.</summary>
public static class JavaText {
    /// <summary><c>Character.isWhitespace</c>: unlike .NET's, no-break spaces are not whitespace and the information separators are.</summary>
    public static bool IsWhitespace(char c) => c is not ('\u00A0' or '\u2007' or '\u202F') && (c is >= '\u001C' and <= '\u001F' || char.IsWhiteSpace(c));

    /// <summary><c>String.trim</c>: strips every char up to and including the space, and nothing else.</summary>
    public static string Trim(string s) {
        int start = 0, end = s.Length;
        while (start < end && s[start] <= ' ') {
            start++;
        }
        while (end > start && s[end - 1] <= ' ') {
            end--;
        }
        return s[start..end];
    }

    /// <summary><c>String.toLowerCase(Locale.ROOT)</c>.</summary>
    public static string ToLowerRoot(string s) => s.ToLowerInvariant();

    /// <summary><c>String.compareTo</c>: UTF-16 code unit order.</summary>
    public static int CompareTo(string a, string b) => string.CompareOrdinal(a, b);

    /// <summary><c>String.compareToIgnoreCase</c>: each char upper cased then lower cased before comparing.</summary>
    public static int CompareToIgnoreCase(string a, string b) {
        int n = Math.Min(a.Length, b.Length);
        for (int i = 0; i < n; i++) {
            char c1 = a[i], c2 = b[i];
            if (c1 == c2) {
                continue;
            }
            c1 = char.ToLowerInvariant(char.ToUpperInvariant(c1));
            c2 = char.ToLowerInvariant(char.ToUpperInvariant(c2));
            if (c1 != c2) {
                return c1 - c2;
            }
        }
        return a.Length - b.Length;
    }

    /// <summary><c>Integer.parseInt</c>: an optional sign then decimal digits, nothing else.</summary>
    public static bool TryParseInt(string s, out int value) =>
        int.TryParse(s, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out value) && IsJavaInteger(s);

    /// <summary><c>Long.parseLong</c>.</summary>
    public static bool TryParseLong(string s, out long value) =>
        long.TryParse(s, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out value) && IsJavaInteger(s);

    private static bool IsJavaInteger(string s) {
        int i = s.Length > 0 && s[0] is '-' or '+' ? 1 : 0;
        if (i == s.Length) {
            return false;
        }
        for (; i < s.Length; i++) {
            if (s[i] is < '0' or > '9') {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// <c>Double.parseDouble</c> over signed decimals with an optional exponent. Java's <c>NaN</c>,
    /// <c>Infinity</c>, hex floats and type suffixes are refused; no command parser can hand one over.
    /// </summary>
    public static bool TryParseDouble(string s, out double value) {
        value = 0;
        return IsJavaDecimal(s) && double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }

    /// <summary><c>Float.parseFloat</c>, rounding straight to single precision as Java does.</summary>
    public static bool TryParseFloat(string s, out float value) {
        value = 0;
        return IsJavaDecimal(s) && float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }

    private static bool IsJavaDecimal(string s) {
        int i = 0;
        if (i < s.Length && s[i] is '-' or '+') {
            i++;
        }
        int digits = 0;
        while (i < s.Length && char.IsAsciiDigit(s[i])) {
            i++;
            digits++;
        }
        if (i < s.Length && s[i] == '.') {
            i++;
            while (i < s.Length && char.IsAsciiDigit(s[i])) {
                i++;
                digits++;
            }
        }
        if (digits == 0) {
            return false;
        }
        if (i < s.Length && s[i] is 'e' or 'E') {
            i++;
            if (i < s.Length && s[i] is '-' or '+') {
                i++;
            }
            int exponentDigits = 0;
            while (i < s.Length && char.IsAsciiDigit(s[i])) {
                i++;
                exponentDigits++;
            }
            if (exponentDigits == 0) {
                return false;
            }
        }
        return i == s.Length;
    }

    /// <summary><c>Double.toString</c>: shortest digits, plain between 10^-3 and 10^7, computerised scientific outside it.</summary>
    public static string ToString(double d) {
        if (double.IsNaN(d)) {
            return "NaN";
        }
        if (double.IsInfinity(d)) {
            return d > 0 ? "Infinity" : "-Infinity";
        }
        if (d == 0) {
            return double.IsNegative(d) ? "-0.0" : "0.0";
        }
        return Format(d.ToString("R", CultureInfo.InvariantCulture), Math.Abs(d) >= 1e-3 && Math.Abs(d) < 1e7);
    }

    /// <summary><c>Float.toString</c>.</summary>
    public static string ToString(float f) {
        if (float.IsNaN(f)) {
            return "NaN";
        }
        if (float.IsInfinity(f)) {
            return f > 0 ? "Infinity" : "-Infinity";
        }
        if (f == 0) {
            return float.IsNegative(f) ? "-0.0" : "0.0";
        }
        return Format(f.ToString("R", CultureInfo.InvariantCulture), Math.Abs(f) >= 1e-3f && Math.Abs(f) < 1e7f);
    }

    /// <summary>Reformats .NET's shortest round trip text, whatever notation it chose, into Java's.</summary>
    private static string Format(string roundTrip, bool plain) {
        bool negative = roundTrip.StartsWith('-');
        string body = negative ? roundTrip[1..] : roundTrip;
        int exponent = 0;
        int e = body.IndexOfAny(['E', 'e']);
        if (e >= 0) {
            exponent = int.Parse(body[(e + 1)..], NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
            body = body[..e];
        }
        int point = body.IndexOf('.');
        string digits = point >= 0 ? body.Remove(point, 1) : body;
        int pointPos = (point >= 0 ? point : body.Length) + exponent;
        int lead = 0;
        while (lead < digits.Length - 1 && digits[lead] == '0') {
            lead++;
            pointPos--;
        }
        digits = digits[lead..].TrimEnd('0');
        if (digits.Length == 0) {
            digits = "0";
        }

        string result;
        if (plain) {
            if (pointPos <= 0) {
                result = "0." + new string('0', -pointPos) + digits;
            }
            else if (pointPos >= digits.Length) {
                result = digits + new string('0', pointPos - digits.Length) + ".0";
            }
            else {
                result = digits[..pointPos] + "." + digits[pointPos..];
            }
        }
        else {
            string fraction = digits.Length > 1 ? digits[1..] : "0";
            result = digits[0] + "." + fraction + "E" + (pointPos - 1).ToString(CultureInfo.InvariantCulture);
        }
        return negative ? "-" + result : result;
    }

    /// <summary><c>Math.round(float)</c>: half up on the exact value, and a saturating cast outside the int range.</summary>
    public static int Round(float a) {
        int intBits = BitConverter.SingleToInt32Bits(a);
        int biasedExp = (intBits & 0x7F800000) >> 23;
        int shift = 24 - 2 + 127 - biasedExp;
        if ((shift & -32) == 0) {
            int r = (intBits & 0x007FFFFF) | 0x00800000;
            if (intBits < 0) {
                r = -r;
            }
            return ((r >> shift) + 1) >> 1;
        }
        return SaturatingInt(a);
    }

    /// <summary>Java's <c>(int)</c> of a float: NaN is 0 and anything out of range clamps.</summary>
    public static int SaturatingInt(double d) {
        if (double.IsNaN(d)) {
            return 0;
        }
        if (d >= int.MaxValue) {
            return int.MaxValue;
        }
        if (d <= int.MinValue) {
            return int.MinValue;
        }
        return (int)d;
    }

    /// <summary><c>String.format(Locale.ROOT, "%.Nf", d)</c>: Java rounds the shortest decimal form half up, not the exact binary value.</summary>
    public static string FormatFixed(double d, int decimals) {
        decimal exact = decimal.Parse(d.ToString("R", CultureInfo.InvariantCulture), NumberStyles.Float, CultureInfo.InvariantCulture);
        decimal rounded = Math.Round(exact, decimals, MidpointRounding.AwayFromZero);
        return rounded.ToString("F" + decimals, CultureInfo.InvariantCulture);
    }

    /// <summary><c>String.valueOf</c> for the argument of a translatable message.</summary>
    public static string ValueOf(object? o) => o switch {
        null => "null",
        string s => s,
        bool b => b ? "true" : "false",
        double d => ToString(d),
        float f => ToString(f),
        IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
        _ => o.ToString() ?? "null"
    };
}
