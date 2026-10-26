namespace ClientLib.Commands.Arguments;

/// <summary>
/// Java's <c>UUID.fromString</c>, far looser than <see cref="Guid.TryParse(string, out Guid)"/>: five dash
/// separated, optionally signed hex groups of any length up to 36 characters, so "1-2-3-4-5" is a UUID.
/// </summary>
public static class JavaUuid {
    public static bool TryParse(string name, out Guid uuid) {
        uuid = Guid.Empty;
        int len = name.Length;
        if (len > 36) {
            return false;
        }
        int dash1 = name.IndexOf('-');
        int dash2 = dash1 < 0 ? -1 : name.IndexOf('-', dash1 + 1);
        int dash3 = dash2 < 0 ? -1 : name.IndexOf('-', dash2 + 1);
        int dash4 = dash3 < 0 ? -1 : name.IndexOf('-', dash3 + 1);
        int dash5 = dash4 < 0 ? -1 : name.IndexOf('-', dash4 + 1);
        if (dash4 < 0 || dash5 >= 0) {
            return false;
        }
        if (!TryParseHexLong(name, 0, dash1, out long g0) || !TryParseHexLong(name, dash1 + 1, dash2, out long g1)
            || !TryParseHexLong(name, dash2 + 1, dash3, out long g2) || !TryParseHexLong(name, dash3 + 1, dash4, out long g3)
            || !TryParseHexLong(name, dash4 + 1, len, out long g4)) {
            return false;
        }
        long mostSigBits = (g0 & 0xffffffffL) << 32 | (g1 & 0xffffL) << 16 | (g2 & 0xffffL);
        long leastSigBits = (g3 & 0xffffL) << 48 | (g4 & 0xffffffffffffL);
        byte[] bytes = new byte[16];
        for (int i = 0; i < 8; i++) {
            bytes[i] = (byte)(mostSigBits >> (56 - 8 * i));
            bytes[8 + i] = (byte)(leastSigBits >> (56 - 8 * i));
        }
        uuid = new Guid(bytes, bigEndian: true);
        return true;
    }

    /// <summary><c>Long.parseLong(s, begin, end, 16)</c>.</summary>
    private static bool TryParseHexLong(string s, int begin, int end, out long value) {
        value = 0;
        if (begin >= end) {
            return false;
        }
        bool negative = false;
        int i = begin;
        if (s[i] is '-' or '+') {
            negative = s[i] == '-';
            i++;
            if (i == end) {
                return false;
            }
        }
        // Accumulates negatively, as Java does, so long.MinValue parses and nothing past it does.
        long limit = negative ? long.MinValue : -long.MaxValue;
        long result = 0;
        for (; i < end; i++) {
            int digit = HexDigit(s[i]);
            if (digit < 0 || result < limit / 16) {
                return false;
            }
            result *= 16;
            if (result < limit + digit) {
                return false;
            }
            result -= digit;
        }
        value = negative ? result : -result;
        return true;
    }

    private static int HexDigit(char c) => c switch {
        >= '0' and <= '9' => c - '0',
        >= 'a' and <= 'f' => c - 'a' + 10,
        >= 'A' and <= 'F' => c - 'A' + 10,
        _ => -1
    };
}
