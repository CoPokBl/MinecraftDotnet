using System.Text;
using ClientLib;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>Vanilla's <c>EditBox</c>: a single line text field.</summary>
public sealed class EditBox {
    private const uint DefaultTextColor = 0xFFE0E0E0;
    private const uint TextColorUneditable = 0xFF707070;
    private const int LineHeight = TextRenderer.LineHeight;
    private const long CursorBlinkIntervalMs = 300;

    /// <summary><c>EditBox.TextFormatter</c>: styled runs for a slice of the value starting at <paramref name="offset"/>, or null to pass.</summary>
    public delegate List<TextRun>? TextFormatter(string text, int offset);

    private readonly TextRenderer _font;
    private string _value = "";
    private int _maxLength = 32;
    private bool _bordered = true;
    private bool _canLoseFocus = true;
    private int _displayPos;
    private int _cursorPos;
    private int _highlightPos;
    private string? _suggestion;
    private Action<string>? _responder;
    private readonly List<TextFormatter> _formatters = [];
    private long _focusedTime = Millis();
    private int _textX;
    private int _textY;
    private bool _focused;
    private bool _centered;

    public EditBox(TextRenderer font, int x, int y, int width, int height) {
        _font = font;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        UpdateTextPosition();
    }

    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }

    /// <summary><c>Util.getMillis</c>: a monotonic millisecond clock.</summary>
    private static long Millis() => Environment.TickCount64;

    public void SetResponder(Action<string> responder) => _responder = responder;

    public void AddFormatter(TextFormatter formatter) => _formatters.Add(formatter);

    public string Value {
        get => _value;
        set {
            _value = value.Length > _maxLength ? value[.._maxLength] : value;
            MoveCursorToEnd(false);
            SetHighlightPos(_cursorPos);
            OnValueChange(value);
        }
    }

    public string GetHighlighted() {
        int start = Math.Min(_cursorPos, _highlightPos);
        int end = Math.Max(_cursorPos, _highlightPos);
        return _value[start..end];
    }

    /// <summary><c>insertText</c>: replaces the selection, cut to what fits under the maximum length.</summary>
    public void InsertText(string input) {
        int start = Math.Min(_cursorPos, _highlightPos);
        int end = Math.Max(_cursorPos, _highlightPos);
        int maxInsertionLength = _maxLength - _value.Length - (start - end);
        if (maxInsertionLength <= 0) {
            return;
        }
        string text = FilterText(input);
        int insertionLength = text.Length;
        if (maxInsertionLength < insertionLength) {
            if (char.IsHighSurrogate(text[maxInsertionLength - 1])) {
                maxInsertionLength--;
            }
            text = text[..maxInsertionLength];
            insertionLength = maxInsertionLength;
        }
        _value = new StringBuilder(_value).Remove(start, end - start).Insert(start, text).ToString();
        SetCursorPosition(start + insertionLength);
        SetHighlightPos(_cursorPos);
        OnValueChange(_value);
    }

    /// <summary><c>StringUtil.isAllowedChatCharacter</c>.</summary>
    public static bool IsAllowedChatCharacter(int ch) => ch != 167 && ch >= 32 && ch != 127;

    /// <summary><c>StringUtil.filterText</c>, single line.</summary>
    public static string FilterText(string input) {
        StringBuilder builder = new();
        foreach (char c in input) {
            if (IsAllowedChatCharacter(c)) {
                builder.Append(c);
            }
        }
        return builder.ToString();
    }

    private void OnValueChange(string value) {
        _responder?.Invoke(value);
        UpdateTextPosition();
    }

    private void DeleteText(int dir, bool wholeWord) {
        if (wholeWord) {
            DeleteWords(dir);
        }
        else {
            DeleteChars(dir);
        }
    }

    public void DeleteWords(int dir) {
        if (_value.Length == 0) {
            return;
        }
        if (_highlightPos != _cursorPos) {
            InsertText("");
        }
        else {
            DeleteCharsToPos(GetWordPosition(dir));
        }
    }

    public void DeleteChars(int dir) => DeleteCharsToPos(GetCursorPos(dir));

    public void DeleteCharsToPos(int pos) {
        if (_value.Length == 0) {
            return;
        }
        if (_highlightPos != _cursorPos) {
            InsertText("");
            return;
        }
        int start = Math.Min(pos, _cursorPos);
        int end = Math.Max(pos, _cursorPos);
        if (start != end) {
            _value = _value.Remove(start, end - start);
            SetCursorPosition(start);
            OnValueChange(_value);
            MoveCursorTo(start, false);
        }
    }

    public int GetWordPosition(int dir) => GetWordPosition(dir, CursorPosition);

    private int GetWordPosition(int dir, int from) => GetWordPosition(dir, from, true);

    private int GetWordPosition(int dir, int from, bool stripSpaces) {
        int result = from;
        bool reverse = dir < 0;
        int abs = Math.Abs(dir);
        for (int i = 0; i < abs; i++) {
            if (!reverse) {
                int length = _value.Length;
                result = _value.IndexOf(' ', result);
                if (result == -1) {
                    result = length;
                }
                else {
                    while (stripSpaces && result < length && _value[result] == ' ') {
                        result++;
                    }
                }
            }
            else {
                while (stripSpaces && result > 0 && _value[result - 1] == ' ') {
                    result--;
                }
                while (result > 0 && _value[result - 1] != ' ') {
                    result--;
                }
            }
        }
        return result;
    }

    public void MoveCursor(int dir, bool hasShiftDown) => MoveCursorTo(GetCursorPos(dir), hasShiftDown);

    private int GetCursorPos(int dir) => OffsetByCodepoints(_value, _cursorPos, dir);

    /// <summary><c>Util.offsetByCodepoints</c>.</summary>
    internal static int OffsetByCodepoints(string input, int pos, int offset) {
        int length = input.Length;
        if (offset >= 0) {
            for (int i = 0; pos < length && i < offset; i++) {
                if (char.IsHighSurrogate(input[pos++]) && pos < length && char.IsLowSurrogate(input[pos])) {
                    pos++;
                }
            }
        }
        else {
            for (int i = offset; pos > 0 && i < 0; i++) {
                pos--;
                if (char.IsLowSurrogate(input[pos]) && pos > 0 && char.IsHighSurrogate(input[pos - 1])) {
                    pos--;
                }
            }
        }
        return pos;
    }

    public void MoveCursorTo(int pos, bool extendSelection) {
        SetCursorPosition(pos);
        if (!extendSelection) {
            SetHighlightPos(_cursorPos);
        }
        UpdateTextPosition();
    }

    public void SetCursorPosition(int pos) {
        _cursorPos = Math.Clamp(pos, 0, _value.Length);
        ScrollTo(_cursorPos);
    }

    public void MoveCursorToStart(bool hasShiftDown) => MoveCursorTo(0, hasShiftDown);

    public void MoveCursorToEnd(bool hasShiftDown) => MoveCursorTo(_value.Length, hasShiftDown);

    /// <summary><c>keyPressed</c>. Ctrl stands for vanilla's platform edit modifier, which is Command on macOS.</summary>
    public bool KeyPressed(GuiContext context, Key key, bool control, bool shift) {
        if (!Visible || !_focused) {
            return false;
        }
        switch (key) {
            case Key.Backspace:
                if (Editable) {
                    DeleteText(-1, control);
                }
                return true;
            case Key.Delete:
                if (Editable) {
                    DeleteText(1, control);
                }
                return true;
            case Key.Right:
                if (control) {
                    MoveCursorTo(GetWordPosition(1), shift);
                }
                else {
                    MoveCursor(1, shift);
                }
                return true;
            case Key.Left:
                if (control) {
                    MoveCursorTo(GetWordPosition(-1), shift);
                }
                else {
                    MoveCursor(-1, shift);
                }
                return true;
            case Key.Home:
                MoveCursorToStart(shift);
                return true;
            case Key.End:
                MoveCursorToEnd(shift);
                return true;
            case Key.A when control && !shift:
                MoveCursorToEnd(false);
                SetHighlightPos(0);
                return true;
            case Key.C when control && !shift:
                context.WriteClipboard?.Invoke(GetHighlighted());
                return true;
            case Key.V when control && !shift:
                if (Editable) {
                    InsertText(context.ReadClipboard?.Invoke() ?? "");
                }
                return true;
            case Key.X when control && !shift:
                context.WriteClipboard?.Invoke(GetHighlighted());
                if (Editable) {
                    InsertText("");
                }
                return true;
            default:
                return false;
        }
    }

    public bool CharTyped(char c) {
        if (!Visible || !_focused || !Editable || !IsAllowedChatCharacter(c)) {
            return false;
        }
        InsertText(c.ToString());
        return true;
    }

    private int FindClickedPositionInText(float mouseX) {
        int positionInText = Math.Min((int)MathF.Floor(mouseX) - _textX, InnerWidth);
        string displayed = _value[_displayPos..];
        return _displayPos + PlainSubstrByWidth(displayed, positionInText).Length;
    }

    /// <summary><c>AbstractWidget.isMouseOver</c>.</summary>
    public bool IsMouseOver(float mouseX, float mouseY) => Visible && mouseX >= X && mouseY >= Y && mouseX < X + Width && mouseY < Y + Height;

    /// <summary><c>onClick</c> without the double click word selection: the window reports no click count.</summary>
    public void OnClick(float mouseX, bool hasShiftDown) => MoveCursorTo(FindClickedPositionInText(mouseX), hasShiftDown);

    /// <summary><c>extractWidgetRenderState</c>. Without the pack's text field sprites the border is the flat one vanilla drew before them.</summary>
    public void Render(GuiContext context) {
        if (!Visible) {
            return;
        }
        if (_bordered && !context.Sprites.Sliced(context.Gui, _focused ? "widget/text_field_highlighted" : "widget/text_field", X, Y, Width, Height, 1)) {
            context.Gui.Rect(X, Y, Width, Height, _focused ? 0xFFFFFFFF : 0xFFA0A0A0);
            context.Gui.Rect(X + 1, Y + 1, Width - 2, Height - 2, 0xFF000000);
        }
        uint color = Editable ? TextColor : TextColorUneditable;
        int relCursorPos = _cursorPos - _displayPos;
        string displayed = PlainSubstrByWidth(_value[_displayPos..], InnerWidth);
        bool cursorOnScreen = relCursorPos >= 0 && relCursorPos <= displayed.Length;
        bool showCursor = _focused && IsCursorVisible(Millis() - _focusedTime) && cursorOnScreen;
        int drawX = _textX;
        int relHighlightPos = Math.Clamp(_highlightPos - _displayPos, 0, displayed.Length);
        if (displayed.Length > 0) {
            string half = cursorOnScreen ? displayed[..relCursorPos] : displayed;
            List<TextRun> charSequence = ApplyFormat(half, _displayPos, color);
            _font.Draw(charSequence, drawX, _textY, (byte)(color >> 24), TextShadow, false);
            drawX += _font.Width(charSequence) + 1;
        }

        if (Hint != null && displayed.Length == 0 && !_focused) {
            _font.Draw(Hint, drawX, _textY, (byte)(color >> 24), TextShadow);
        }

        bool insert = _cursorPos < _value.Length || _value.Length >= _maxLength;
        int cursorX = drawX;
        if (!cursorOnScreen) {
            cursorX = relCursorPos > 0 ? _textX + Width : _textX;
        }
        else if (insert) {
            cursorX = drawX - 1;
            drawX--;
        }

        if (displayed.Length > 0 && cursorOnScreen && relCursorPos < displayed.Length) {
            _font.Draw(ApplyFormat(displayed[relCursorPos..], _cursorPos, color), drawX, _textY, (byte)(color >> 24), TextShadow, false);
        }

        if (!insert && _suggestion != null) {
            _font.Draw(_suggestion, cursorX - 1, _textY, 0xFF808080, TextShadow);
        }

        if (relHighlightPos != relCursorPos) {
            int highlightX = _textX + _font.Width(displayed[..relHighlightPos]);
            TextHighlight(context, Math.Min(cursorX, X + Width), _textY - 1, Math.Min(highlightX - 1, X + Width), _textY + 1 + LineHeight);
        }

        if (showCursor) {
            if (insert) {
                context.Gui.Rect(cursorX, _textY - 1, 1, LineHeight + 1 + 1, color);
            }
            else {
                _font.Draw("_", cursorX, _textY, color, TextShadow);
            }
        }
    }

    /// <summary><c>TextCursorUtils.isCursorVisible</c>.</summary>
    private static bool IsCursorVisible(long timeInMs) => timeInMs / CursorBlinkIntervalMs % 2L == 0L;

    /// <summary>
    /// <c>GuiGraphicsExtractor.textHighlight</c>. Vanilla's highlight pass draws its blue with a logic
    /// op; the GUI batch has no logic op, so the blue goes over the inverted text as a translucent fill.
    /// </summary>
    public static void TextHighlight(GuiContext context, int x0, int y0, int x1, int y1) {
        int left = Math.Min(x0, x1), right = Math.Max(x0, x1);
        int top = Math.Min(y0, y1), bottom = Math.Max(y0, y1);
        context.Gui.Flush();
        context.Gui.Rect(left, top, right - left, bottom - top, 0xFFFFFFFF);
        context.Gui.FlushInverted();
        context.Gui.Rect(left, top, right - left, bottom - top, 0x600000FF);
    }

    private List<TextRun> ApplyFormat(string text, int offset, uint color) {
        foreach (TextFormatter formatter in _formatters) {
            List<TextRun>? formatted = formatter(text, offset);
            if (formatted != null) {
                return formatted;
            }
        }
        return [new TextRun(text, (int)(color & 0xFFFFFF))];
    }

    private void UpdateTextPosition() {
        string displayed = PlainSubstrByWidth(_value[Math.Min(_displayPos, _value.Length)..], InnerWidth);
        _textX = X + (_centered ? (Width - _font.Width(displayed)) / 2 : _bordered ? 4 : 0);
        _textY = _bordered ? Y + (Height - 8) / 2 : Y;
    }

    public int MaxLength {
        get => _maxLength;
        set {
            _maxLength = value;
            if (_value.Length > value) {
                _value = _value[..value];
                OnValueChange(_value);
            }
        }
    }

    public int CursorPosition => _cursorPos;

    public bool Bordered {
        get => _bordered;
        set {
            _bordered = value;
            UpdateTextPosition();
        }
    }

    public bool Focused {
        get => _focused;
        set {
            if (_canLoseFocus || value) {
                _focused = value;
                if (value) {
                    _focusedTime = Millis();
                }
            }
        }
    }

    public uint TextColor { get; set; } = DefaultTextColor;

    /// <summary><c>setHint</c>: drawn while the box is empty and unfocused.</summary>
    public List<TextRun>? Hint { get; set; }

    /// <summary>A hidden box is neither drawn nor takes keys.</summary>
    public bool Visible { get; set; } = true;

    /// <summary><c>setEditable</c>: an uneditable box still takes focus, moves its cursor and copies, greyed.</summary>
    public bool Editable { get; set; } = true;

    public bool TextShadow { get; set; } = true;

    public bool Centered {
        get => _centered;
        set {
            _centered = value;
            UpdateTextPosition();
        }
    }

    public bool CanLoseFocus {
        set => _canLoseFocus = value;
    }

    public int InnerWidth => _bordered ? Width - 8 : Width;

    public void SetHighlightPos(int pos) {
        _highlightPos = Math.Clamp(pos, 0, _value.Length);
        ScrollTo(_highlightPos);
    }

    private void ScrollTo(int pos) {
        _displayPos = Math.Min(_displayPos, _value.Length);
        int innerWidth = InnerWidth;
        string displayed = PlainSubstrByWidth(_value[_displayPos..], innerWidth);
        int lastPos = displayed.Length + _displayPos;
        if (pos == _displayPos) {
            _displayPos -= PlainTailByWidth(_value, innerWidth).Length;
        }
        if (pos > lastPos) {
            _displayPos += pos - lastPos;
        }
        else if (pos <= _displayPos) {
            _displayPos -= _displayPos - pos;
        }
        _displayPos = Math.Clamp(_displayPos, 0, _value.Length);
    }

    public void SetSuggestion(string? suggestion) => _suggestion = suggestion;

    public int GetScreenX(int charIndex) => charIndex > _value.Length ? X : X + _font.Width(_value[..charIndex]);

    /// <summary><c>StringSplitter.plainHeadByWidth</c>: the longest prefix whose width does not pass <paramref name="maxWidth"/>.</summary>
    private string PlainSubstrByWidth(string str, int maxWidth) {
        float width = 0;
        int i = 0;
        while (i < str.Length) {
            int next = char.IsSurrogatePair(str, i) ? i + 2 : i + 1;
            width += GlyphWidth(str, i, next);
            if (width > maxWidth) {
                break;
            }
            i = next;
        }
        return str[..i];
    }

    /// <summary><c>StringSplitter.plainTailByWidth</c>.</summary>
    private string PlainTailByWidth(string str, int maxWidth) {
        float width = 0;
        int result = str.Length;
        int i = str.Length;
        while (i > 0) {
            int start = i >= 2 && char.IsSurrogatePair(str, i - 2) ? i - 2 : i - 1;
            width += GlyphWidth(str, start, i);
            if (width > maxWidth) {
                break;
            }
            result = start;
            i = start;
        }
        return str[result..];
    }

    private float GlyphWidth(string str, int start, int end) => end - start == 1 ? _font.Advance(str[start]) : _font.Width(str[start..end]);
}
