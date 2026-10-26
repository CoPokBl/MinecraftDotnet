using System.Globalization;
using System.Text;

namespace ClientLib;

/// <summary>
/// <c>FormattedBidiReorder.reorder</c>: Arabic letters shaped, then the line laid out by the Unicode
/// bidirectional algorithm, runs at odd levels reversed with their brackets mirrored. Vanilla hands this to
/// ICU's <c>Bidi</c> and <c>ArabicShaping</c>; this is the implicit algorithm without explicit embeddings,
/// overrides or isolates (their control characters count as other neutrals), with the bidi classes and
/// joining forms of the scripts the game's fonts draw rather than the whole Unicode database.
/// </summary>
public static class BidiReorder {
    private enum BidiClass : byte {
        L, R, AL, EN, ES, ET, AN, CS, NSM, B, S, WS, ON
    }

    /// <summary>
    /// The runs as they are drawn, left to right. A paragraph takes its direction from its first strong letter,
    /// or <paramref name="defaultRightToLeft"/> without one, as ICU's <c>DEFAULT_RTL</c> and <c>DEFAULT_LTR</c>.
    /// </summary>
    public static IReadOnlyList<TextRun> Reorder(IReadOnlyList<TextRun> runs, bool defaultRightToLeft) {
        if (!defaultRightToLeft && !runs.Any(run => run.Text.Any(c => Classify(c) is BidiClass.R or BidiClass.AL or BidiClass.AN))) {
            return runs;
        }
        StringBuilder plain = new();
        List<int> styles = [];
        for (int i = 0; i < runs.Count; i++) {
            plain.Append(runs[i].Text);
            styles.AddRange(Enumerable.Repeat(i, runs[i].Text.Length));
        }
        string text = Shape(plain.ToString());
        byte[] levels = Levels(text, defaultRightToLeft);

        List<(int Start, int Length, bool Odd)> visualRuns = VisualRuns(levels);
        List<TextRun> result = [];
        foreach ((int start, int length, bool odd) in visualRuns) {
            result.AddRange(Substring(runs, styles, text, start, length, odd));
        }
        return result;
    }

    /// <summary><c>SubStringSource.substring</c>: the span split where the style changes, reversed and mirrored when odd.</summary>
    private static List<TextRun> Substring(IReadOnlyList<TextRun> runs, List<int> styles, string text, int start, int length, bool reverse) {
        List<TextRun> parts = [];
        int runStart = start;
        for (int i = 1; i <= length; i++) {
            int index = start + i;
            if (i < length && Style(styles, index) == Style(styles, runStart)) {
                continue;
            }
            string part = text[runStart..index];
            if (reverse) {
                char[] chars = part.ToCharArray();
                Array.Reverse(chars);
                for (int c = 0; c < chars.Length; c++) {
                    chars[c] = Mirror(chars[c]);
                }
                part = new string(chars);
            }
            parts.Add(runs[Style(styles, runStart)] with { Text = part });
            runStart = index;
        }
        if (reverse) {
            parts.Reverse();
        }
        return parts;
    }

    /// <summary>A position's style; a lam-alef ligature shortens the text, so later characters read their neighbour's, as vanilla's do.</summary>
    private static int Style(List<int> styles, int index) => styles[Math.Min(index, styles.Count - 1)];

    /// <summary>The runs of equal level in visual order, rule L2: from the highest level down, each run of at least it reversed.</summary>
    private static List<(int Start, int Length, bool Odd)> VisualRuns(byte[] levels) {
        List<(int Start, int End, byte Level)> runs = [];
        for (int i = 0; i < levels.Length;) {
            int end = i;
            while (end < levels.Length && levels[end] == levels[i]) {
                end++;
            }
            runs.Add((i, end, levels[i]));
            i = end;
        }
        if (runs.Count == 0) {
            return [];
        }
        int highest = runs.Max(r => r.Level);
        int lowestOdd = runs.Where(r => r.Level % 2 == 1).Select(r => (int)r.Level).DefaultIfEmpty(highest + 1).Min();
        for (int level = highest; level >= lowestOdd; level--) {
            for (int i = 0; i < runs.Count;) {
                if (runs[i].Level < level) {
                    i++;
                    continue;
                }
                int end = i;
                while (end < runs.Count && runs[end].Level >= level) {
                    end++;
                }
                runs.Reverse(i, end - i);
                i = end;
            }
        }
        return runs.Select(r => (r.Start, r.End - r.Start, r.Level % 2 == 1)).ToList();
    }

    /// <summary>Rules P2 to L1 for one paragraph: each character's embedding level.</summary>
    private static byte[] Levels(string text, bool defaultRightToLeft) {
        int n = text.Length;
        BidiClass[] original = new BidiClass[n];
        for (int i = 0; i < n; i++) {
            original[i] = Classify(text[i]);
        }
        // P2, P3.
        byte paragraph = defaultRightToLeft ? (byte)1 : (byte)0;
        foreach (BidiClass type in original) {
            if (type == BidiClass.L) {
                paragraph = 0;
                break;
            }
            if (type is BidiClass.R or BidiClass.AL) {
                paragraph = 1;
                break;
            }
        }
        BidiClass sos = paragraph == 0 ? BidiClass.L : BidiClass.R;
        BidiClass[] types = (BidiClass[])original.Clone();

        // W1: a mark takes the type before it.
        for (int i = 0; i < n; i++) {
            if (types[i] == BidiClass.NSM) {
                types[i] = i == 0 ? sos : types[i - 1];
            }
        }
        // W2: a European number after Arabic letters is an Arabic number.
        BidiClass lastStrong = sos;
        for (int i = 0; i < n; i++) {
            if (types[i] is BidiClass.L or BidiClass.R or BidiClass.AL) {
                lastStrong = types[i];
            }
            else if (types[i] == BidiClass.EN && lastStrong == BidiClass.AL) {
                types[i] = BidiClass.AN;
            }
        }
        // W3.
        for (int i = 0; i < n; i++) {
            if (types[i] == BidiClass.AL) {
                types[i] = BidiClass.R;
            }
        }
        // W4: one separator between two numbers of a kind joins them.
        for (int i = 1; i < n - 1; i++) {
            if (types[i] == BidiClass.ES && types[i - 1] == BidiClass.EN && types[i + 1] == BidiClass.EN) {
                types[i] = BidiClass.EN;
            }
            else if (types[i] == BidiClass.CS && types[i - 1] == types[i + 1] && types[i - 1] is BidiClass.EN or BidiClass.AN) {
                types[i] = types[i - 1];
            }
        }
        // W5: terminators next to a European number are part of it.
        for (int i = 0; i < n; i++) {
            if (types[i] != BidiClass.ET) {
                continue;
            }
            int end = i;
            while (end < n && types[end] == BidiClass.ET) {
                end++;
            }
            bool adjacent = i > 0 && types[i - 1] == BidiClass.EN || end < n && types[end] == BidiClass.EN;
            for (int j = i; j < end; j++) {
                types[j] = adjacent ? BidiClass.EN : BidiClass.ET;
            }
            i = end - 1;
        }
        // W6.
        for (int i = 0; i < n; i++) {
            if (types[i] is BidiClass.ES or BidiClass.ET or BidiClass.CS) {
                types[i] = BidiClass.ON;
            }
        }
        // W7: a European number after left to right text is left to right.
        lastStrong = sos;
        for (int i = 0; i < n; i++) {
            if (types[i] is BidiClass.L or BidiClass.R) {
                lastStrong = types[i];
            }
            else if (types[i] == BidiClass.EN && lastStrong == BidiClass.L) {
                types[i] = BidiClass.L;
            }
        }
        // N1, N2: neutrals between two strong types of one direction take it, the rest the paragraph's.
        for (int i = 0; i < n; i++) {
            if (!IsNeutral(types[i])) {
                continue;
            }
            int end = i;
            while (end < n && IsNeutral(types[end])) {
                end++;
            }
            BidiClass before = i == 0 ? sos : Strong(types[i - 1]);
            BidiClass after = end == n ? sos : Strong(types[end]);
            BidiClass resolved = before == after ? before : paragraph == 0 ? BidiClass.L : BidiClass.R;
            for (int j = i; j < end; j++) {
                types[j] = resolved;
            }
            i = end - 1;
        }
        // I1, I2.
        byte[] levels = new byte[n];
        for (int i = 0; i < n; i++) {
            levels[i] = paragraph;
            if (paragraph == 0) {
                levels[i] += types[i] switch {
                    BidiClass.R => 1,
                    BidiClass.AN or BidiClass.EN => 2,
                    _ => 0
                };
            }
            else if (types[i] is BidiClass.L or BidiClass.EN or BidiClass.AN) {
                levels[i]++;
            }
        }
        // L1: separators, and whitespace before them or at the end, go back to the paragraph's level.
        bool trailing = true;
        for (int i = n - 1; i >= 0; i--) {
            BidiClass type = original[i];
            if (type is BidiClass.S or BidiClass.B) {
                levels[i] = paragraph;
                trailing = true;
            }
            else if (type == BidiClass.WS && trailing) {
                levels[i] = paragraph;
            }
            else {
                trailing = false;
            }
        }
        return levels;
    }

    private static bool IsNeutral(BidiClass type) => type is BidiClass.B or BidiClass.S or BidiClass.WS or BidiClass.ON;

    /// <summary>For rule N1, numbers count as right to left.</summary>
    private static BidiClass Strong(BidiClass type) => type == BidiClass.L ? BidiClass.L : BidiClass.R;

    private static BidiClass Classify(char c) {
        switch (c) {
            case >= '0' and <= '9' or '\u00B2' or '\u00B3' or '\u00B9' or >= '\u06F0' and <= '\u06F9':
                return BidiClass.EN;
            case '+' or '-' or '\u207A' or '\u207B':
                return BidiClass.ES;
            case '#' or '$' or '%' or >= '\u00A2' and <= '\u00A5' or '\u00B0' or '\u00B1' or '\u066A' or >= '\u2030' and <= '\u2034' or >= '\u20A0' and <= '\u20CF':
                return BidiClass.ET;
            case ',' or '.' or '/' or ':' or '\u00A0' or '\u060C' or '\u202F' or '\u2044' or '\uFE50' or '\uFE52' or '\uFE55':
                return BidiClass.CS;
            case >= '\u0660' and <= '\u0669' or '\u066B' or '\u066C' or >= '\u0600' and <= '\u0605' or '\u06DD':
                return BidiClass.AN;
            case '\n' or '\r' or >= '\u001C' and <= '\u001E' or '\u0085' or '\u2029':
                return BidiClass.B;
            case '\t' or '\u000B' or '\u001F':
                return BidiClass.S;
            case ' ' or '\u000C' or >= '\u2000' and <= '\u200A' or '\u2028' or '\u205F' or '\u3000':
                return BidiClass.WS;
            case '\u200E':
                return BidiClass.L;
            case '\u200F':
                return BidiClass.R;
        }
        UnicodeCategory category = char.GetUnicodeCategory(c);
        if (category is UnicodeCategory.NonSpacingMark or UnicodeCategory.EnclosingMark) {
            return BidiClass.NSM;
        }
        if (c is >= '\u0590' and <= '\u05FF' or >= '\u07C0' and <= '\u085F' or >= '\uFB1D' and <= '\uFB4F') {
            return BidiClass.R;
        }
        if (c is >= '\u0600' and <= '\u07BF' or >= '\u0860' and <= '\u08FF' or >= '\uFB50' and <= '\uFDFF' or >= '\uFE70' and <= '\uFEFE') {
            return BidiClass.AL;
        }
        // Astral characters arrive as surrogate halves; the right to left scripts among them are not drawn by the game's fonts.
        if (char.IsSurrogate(c)) {
            return BidiClass.L;
        }
        return category switch {
            UnicodeCategory.SpaceSeparator => BidiClass.WS,
            UnicodeCategory.Control or UnicodeCategory.Format => BidiClass.ON,
            >= UnicodeCategory.ConnectorPunctuation and <= UnicodeCategory.OtherSymbol => BidiClass.ON,
            _ => BidiClass.L
        };
    }

    /// <summary><c>UCharacter.getMirror</c> for the brackets and comparison signs.</summary>
    private static char Mirror(char c) => c switch {
        '(' => ')', ')' => '(', '[' => ']', ']' => '[', '{' => '}', '}' => '{', '<' => '>', '>' => '<',
        '\u00AB' => '\u00BB', '\u00BB' => '\u00AB', '\u2039' => '\u203A', '\u203A' => '\u2039',
        '\u2264' => '\u2265', '\u2265' => '\u2264', '\u2329' => '\u232A', '\u232A' => '\u2329',
        '\u3008' => '\u3009', '\u3009' => '\u3008', '\u300A' => '\u300B', '\u300B' => '\u300A',
        '\u300C' => '\u300D', '\u300D' => '\u300C', '\u300E' => '\u300F', '\u300F' => '\u300E',
        '\u3010' => '\u3011', '\u3011' => '\u3010', '\uFF08' => '\uFF09', '\uFF09' => '\uFF08',
        _ => c
    };

    /// <summary>
    /// Presentation forms of the Arabic letters U+0621 to U+064A from U+FE80, each letter's isolated form, or 0
    /// for one with none; a letter joining on both sides has four forms in a row, one joining only before it two.
    /// </summary>
    private static readonly (char Isolated, bool Dual)[] ArabicForms = [
        ('\uFE80', false), ('\uFE81', false), ('\uFE83', false), ('\uFE85', false), ('\uFE87', false), ('\uFE89', true), ('\uFE8D', false),
        ('\uFE8F', true), ('\uFE93', false), ('\uFE95', true), ('\uFE99', true), ('\uFE9D', true), ('\uFEA1', true), ('\uFEA5', true),
        ('\uFEA9', false), ('\uFEAB', false), ('\uFEAD', false), ('\uFEAF', false), ('\uFEB1', true), ('\uFEB5', true), ('\uFEB9', true),
        ('\uFEBD', true), ('\uFEC1', true), ('\uFEC5', true), ('\uFEC9', true), ('\uFECD', true), ('\0', false), ('\0', false),
        ('\0', false), ('\0', false), ('\0', false), ('\0', true), ('\uFED1', true), ('\uFED5', true), ('\uFED9', true), ('\uFEDD', true),
        ('\uFEE1', true), ('\uFEE5', true), ('\uFEE9', true), ('\uFEED', false), ('\uFEEF', false), ('\uFEF1', true)
    ];

    private enum Joining : byte {
        None,
        Right,
        Dual,
        Transparent
    }

    private static Joining JoiningOf(char c) {
        if (c is >= '\u0621' and <= '\u064A') {
            return c == '\u0621' ? Joining.None : ArabicForms[c - '\u0621'].Dual ? Joining.Dual : ArabicForms[c - '\u0621'].Isolated == '\0' ? Joining.None : Joining.Right;
        }
        return char.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark ? Joining.Transparent : Joining.None;
    }

    /// <summary>
    /// <c>ArabicShaping(LETTERS_SHAPE)</c>: each letter in the form its joining neighbours call for, a lam
    /// followed by an alef becoming one ligature. Tatweel joins on both sides and keeps its own form.
    /// </summary>
    public static string Shape(string text) {
        if (!text.Any(c => c is >= '\u0621' and <= '\u064A')) {
            return text;
        }
        StringBuilder shaped = new(text.Length);
        for (int i = 0; i < text.Length; i++) {
            char c = text[i];
            if (c is < '\u0621' or > '\u064A' || ArabicForms[c - '\u0621'].Isolated == '\0') {
                shaped.Append(c);
                continue;
            }
            bool joinsBefore = JoinsBefore(text, i);
            int next = NextNonTransparent(text, i);
            if (c == '\u0644' && next >= 0 && text[next] is '\u0622' or '\u0623' or '\u0625' or '\u0627') {
                char ligature = text[next] switch {
                    '\u0622' => '\uFEF5',
                    '\u0623' => '\uFEF7',
                    '\u0625' => '\uFEF9',
                    _ => '\uFEFB'
                };
                shaped.Append((char)(ligature + (joinsBefore ? 1 : 0)));
                shaped.Append(text, i + 1, next - i - 1);
                i = next;
                continue;
            }
            (char isolated, bool dual) = ArabicForms[c - '\u0621'];
            bool joinsAfter = dual && next >= 0 && JoiningOf(text[next]) is Joining.Dual or Joining.Right;
            // Forms: isolated, final, initial, medial; hamza joins neither way and has only the first.
            int form = c == '\u0621' ? 0 : joinsBefore ? joinsAfter ? 3 : 1 : joinsAfter ? 2 : 0;
            shaped.Append((char)(isolated + form));
        }
        return shaped.ToString();
    }

    /// <summary>Whether the letter before, past any marks, joins forward to this one.</summary>
    private static bool JoinsBefore(string text, int i) {
        for (int j = i - 1; j >= 0; j--) {
            Joining joining = JoiningOf(text[j]);
            if (joining == Joining.Transparent) {
                continue;
            }
            return joining == Joining.Dual || text[j] == '\u0640';
        }
        return false;
    }

    private static int NextNonTransparent(string text, int i) {
        for (int j = i + 1; j < text.Length; j++) {
            if (JoiningOf(text[j]) != Joining.Transparent) {
                return j;
            }
        }
        return -1;
    }
}
