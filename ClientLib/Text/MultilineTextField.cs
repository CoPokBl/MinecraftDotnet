using System.Text;

namespace ClientLib;

/// <summary>
/// <c>MultilineTextField</c>: the value of a wrapped text box, its display lines, and a cursor and
/// selection over them. The keys that drive it belong to the widget that holds it.
/// </summary>
public sealed class MultilineTextField {
    public const int NoLimit = int.MaxValue;
    private const int LineHeight = 9;

    /// <summary><c>StringView</c>: a range of the value, end exclusive.</summary>
    public readonly record struct StringView(int BeginIndex, int EndIndex);

    private readonly StringSplitter _font;
    private readonly int _width;
    private readonly List<StringView> _displayLines = [];
    private string _value = "";
    private int _cursor;
    private int _selectCursor;
    private int _characterLimit = NoLimit;
    private int _lineLimit = NoLimit;

    public MultilineTextField(StringSplitter font, int width) {
        _font = font;
        _width = width;
        SetValue("");
    }

    public Action<string> ValueListener { get; set; } = _ => { };
    public Action CursorListener { get; set; } = () => { };

    public bool Selecting { get; set; }

    public int CharacterLimit {
        get => _characterLimit;
        set => _characterLimit = value >= 0 ? value : throw new ArgumentException("Character limit cannot be negative");
    }

    public int LineLimit {
        set => _lineLimit = value >= 0 ? value : throw new ArgumentException("Character limit cannot be negative");
    }

    public bool HasCharacterLimit => _characterLimit != NoLimit;
    public bool HasLineLimit => _lineLimit != NoLimit;

    public string Value => _value;
    public int Cursor => _cursor;
    public int LineCount => _displayLines.Count;
    public IReadOnlyList<StringView> Lines => _displayLines;
    public bool HasSelection => _selectCursor != _cursor;

    public void SetValue(string value, bool allowOverflowLineLimit = false) {
        string newValue = TruncateFullText(value);
        if (allowOverflowLineLimit || !OverflowsLineLimit(newValue)) {
            _value = newValue;
            _cursor = _value.Length;
            _selectCursor = _cursor;
            OnValueChange();
        }
    }

    public void InsertText(string input) {
        if (input.Length == 0 && !HasSelection) {
            return;
        }
        string text = TruncateInsertionText(FilterText(input, true));
        StringView selected = Selected;
        string newValue = new StringBuilder(_value).Remove(selected.BeginIndex, selected.EndIndex - selected.BeginIndex)
            .Insert(selected.BeginIndex, text).ToString();
        if (!OverflowsLineLimit(newValue)) {
            _value = newValue;
            _cursor = selected.BeginIndex + text.Length;
            _selectCursor = _cursor;
            OnValueChange();
        }
    }

    public void DeleteText(int dir) {
        if (!HasSelection) {
            _selectCursor = Math.Clamp(_cursor + dir, 0, _value.Length);
        }
        InsertText("");
    }

    public StringView Selected => new(Math.Min(_selectCursor, _cursor), Math.Max(_selectCursor, _cursor));

    public string SelectedText {
        get {
            StringView selected = Selected;
            return _value[selected.BeginIndex..selected.EndIndex];
        }
    }

    public void SelectAll() {
        _cursor = _value.Length;
        _selectCursor = 0;
    }

    public int LineAtCursor {
        get {
            for (int i = 0; i < _displayLines.Count; i++) {
                StringView view = _displayLines[i];
                if (_cursor >= view.BeginIndex && _cursor <= view.EndIndex) {
                    return i;
                }
            }
            return -1;
        }
    }

    public StringView GetLineView(int lineIndex) => _displayLines[Math.Clamp(lineIndex, 0, _displayLines.Count - 1)];

    public enum Whence {
        Absolute,
        Relative,
        End
    }

    public void SeekCursor(Whence whence, int cursor) {
        _cursor = whence switch {
            Whence.Absolute => cursor,
            Whence.Relative => _cursor + cursor,
            _ => _value.Length + cursor
        };
        _cursor = Math.Clamp(_cursor, 0, _value.Length);
        CursorListener();
        if (!Selecting) {
            _selectCursor = _cursor;
        }
    }

    public void SeekCursorLine(int lineOffset) {
        if (lineOffset == 0) {
            return;
        }
        int oldCursorLeft = Width(_value[CursorLineView(0).BeginIndex.._cursor]) + 2;
        StringView lineView = CursorLineView(lineOffset);
        int newCursor = _font.PlainHeadByWidth(_value[lineView.BeginIndex..lineView.EndIndex], oldCursorLeft, StringSplitter.Empty).Length;
        SeekCursor(Whence.Absolute, lineView.BeginIndex + newCursor);
    }

    public void SeekCursorToPoint(double x, double y) {
        int left = (int)Math.Floor(x);
        int top = (int)Math.Floor(y / LineHeight);
        StringView lineView = _displayLines[Math.Clamp(top, 0, _displayLines.Count - 1)];
        int clickedColumn = _font.PlainHeadByWidth(_value[lineView.BeginIndex..lineView.EndIndex], left, StringSplitter.Empty).Length;
        SeekCursor(Whence.Absolute, lineView.BeginIndex + clickedColumn);
    }

    public void SelectWordAtCursor() {
        StringView wordView = PreviousWord;
        SeekCursor(Whence.Absolute, wordView.BeginIndex);
        Selecting = true;
        SeekCursor(Whence.Absolute, wordView.EndIndex);
    }

    /// <summary>Home and End on the cursor's line.</summary>
    public StringView CursorLine => CursorLineView(0);

    private StringView CursorLineView(int lineOffset) {
        int lineIndex = LineAtCursor;
        return lineIndex < 0 ? _displayLines[^1] : _displayLines[Math.Clamp(lineIndex + lineOffset, 0, _displayLines.Count - 1)];
    }

    public StringView PreviousWord {
        get {
            if (_value.Length == 0) {
                return default;
            }
            int startPosition = Math.Clamp(_cursor, 0, _value.Length - 1);
            while (startPosition > 0 && IsWhitespace(_value[startPosition - 1])) {
                startPosition--;
            }
            while (startPosition > 0 && !IsWhitespace(_value[startPosition - 1])) {
                startPosition--;
            }
            return new StringView(startPosition, WordEndPosition(startPosition));
        }
    }

    public StringView NextWord {
        get {
            if (_value.Length == 0) {
                return default;
            }
            int startPosition = Math.Clamp(_cursor, 0, _value.Length - 1);
            while (startPosition < _value.Length && !IsWhitespace(_value[startPosition])) {
                startPosition++;
            }
            while (startPosition < _value.Length && IsWhitespace(_value[startPosition])) {
                startPosition++;
            }
            return new StringView(startPosition, WordEndPosition(startPosition));
        }
    }

    private int WordEndPosition(int from) {
        int end = from;
        while (end < _value.Length && !IsWhitespace(_value[end])) {
            end++;
        }
        return end;
    }

    /// <summary>Java's <c>Character.isWhitespace</c>, which leaves out the no-break spaces .NET counts.</summary>
    public static bool IsWhitespace(char c) =>
        c is >= '\u001C' and <= '\u001F' || char.IsWhiteSpace(c) && c is not ('\u00A0' or '\u2007' or '\u202F' or '\u0085');

    private int Width(string text) => (int)MathF.Ceiling(_font.StringWidth(text));

    private void OnValueChange() {
        ReflowDisplayLines();
        ValueListener(_value);
        CursorListener();
    }

    private void ReflowDisplayLines() {
        _displayLines.Clear();
        if (_value.Length == 0) {
            _displayLines.Add(default);
            return;
        }
        _font.SplitLines(_value, _width, StringSplitter.Empty, false, (_, start, end) => _displayLines.Add(new StringView(start, end)));
        if (_value[^1] == '\n') {
            _displayLines.Add(new StringView(_value.Length, _value.Length));
        }
    }

    private string TruncateFullText(string input) => HasCharacterLimit ? Truncate(input, _characterLimit) : input;

    private string TruncateInsertionText(string input) => HasCharacterLimit ? Truncate(input, _characterLimit - _value.Length) : input;

    /// <summary><c>StringUtil.truncateStringIfNecessary</c> without the ellipsis.</summary>
    private static string Truncate(string s, int maxLength) => s.Length <= maxLength ? s : s[..maxLength];

    private bool OverflowsLineLimit(string newValue) {
        if (!HasLineLimit) {
            return false;
        }
        int lines = 0;
        _font.SplitLines(newValue, _width, StringSplitter.Empty, false, (_, _, _) => lines++);
        return lines + (EndsWithNewLine(newValue) ? 1 : 0) > _lineLimit;
    }

    /// <summary><c>StringUtil.endsWithNewLine</c>: a final <c>\r\n</c> or any one of Java's vertical whitespace characters.</summary>
    public static bool EndsWithNewLine(string s) => s.Length > 0 && s[^1] is '\n' or '\u000B' or '\f' or '\r' or '\u0085' or '\u2028' or '\u2029';

    /// <summary><c>StringUtil.filterText</c>: the allowed chat characters, and newlines when <paramref name="multiline"/>.</summary>
    public static string FilterText(string input, bool multiline) {
        StringBuilder builder = new();
        foreach (char c in input) {
            if (IsAllowedChatCharacter(c) || multiline && c == '\n') {
                builder.Append(c);
            }
        }
        return builder.ToString();
    }

    /// <summary><c>StringUtil.isAllowedChatCharacter</c>.</summary>
    public static bool IsAllowedChatCharacter(int ch) => ch != StringDecomposer.SectionSign && ch >= 32 && ch != 127;
}
