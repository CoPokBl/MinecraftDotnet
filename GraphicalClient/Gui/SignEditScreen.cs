using System.Text.RegularExpressions;
using ClientLib;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.BlockEntities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary><c>TextFieldHelper</c>: a cursor and selection over a string something else keeps, edited only where the validator allows.</summary>
public sealed partial class TextFieldHelper {
    private readonly Func<string> _getMessage;
    private readonly Action<string> _setMessage;
    private readonly Func<string> _getClipboard;
    private readonly Action<string> _setClipboard;
    private readonly Predicate<string> _validator;

    public TextFieldHelper(Func<string> getMessage, Action<string> setMessage, Func<string> getClipboard, Action<string> setClipboard, Predicate<string> validator) {
        _getMessage = getMessage;
        _setMessage = setMessage;
        _getClipboard = getClipboard;
        _setClipboard = setClipboard;
        _validator = validator;
        SetCursorToEnd();
    }

    public int CursorPos { get; private set; }
    public int SelectionPos { get; private set; }

    [GeneratedRegex("(?i)\u00a7[0-9A-FK-OR]")]
    private static partial Regex FormattingCode();

    /// <summary><c>getClipboardContents</c>: carriage returns and formatting codes taken out.</summary>
    public static string ClipboardContents(GuiContext context) => FormattingCode().Replace((context.ReadClipboard?.Invoke() ?? "").Replace("\r", ""), "");

    public void CharTyped(char c) {
        if (EditBox.IsAllowedChatCharacter(c)) {
            InsertText(_getMessage(), c.ToString());
        }
    }

    /// <summary><c>keyPressed</c>: whether the key was one of the field's.</summary>
    public bool KeyPressed(Key key, bool control, bool shift) {
        switch (key) {
            case Key.A when control && !shift:
                SelectAll();
                return true;
            case Key.C when control && !shift:
                _setClipboard(Selected(_getMessage()));
                return true;
            case Key.V when control && !shift:
                InsertText(_getMessage(), _getClipboard());
                SelectionPos = CursorPos;
                return true;
            case Key.X when control && !shift:
                string message = _getMessage();
                _setClipboard(Selected(message));
                _setMessage(DeleteSelection(message));
                return true;
            case Key.Backspace:
                RemoveFromCursor(-1, control);
                return true;
            case Key.Delete:
                RemoveFromCursor(1, control);
                return false;
            case Key.Left:
                MoveBy(-1, shift, control);
                return true;
            case Key.Right:
                MoveBy(1, shift, control);
                return true;
            case Key.Home:
                CursorPos = 0;
                ResetSelectionIfNeeded(shift);
                return true;
            case Key.End:
                SetCursorToEnd(shift);
                return true;
        }
        return false;
    }

    private void InsertText(string message, string text) {
        if (SelectionPos != CursorPos) {
            message = DeleteSelection(message);
        }
        CursorPos = Math.Clamp(CursorPos, 0, message.Length);
        string newText = message.Insert(CursorPos, text);
        if (_validator(newText)) {
            _setMessage(newText);
            SelectionPos = CursorPos = Math.Min(newText.Length, CursorPos + text.Length);
        }
    }

    private void ResetSelectionIfNeeded(bool selecting) {
        if (!selecting) {
            SelectionPos = CursorPos;
        }
    }

    private void MoveBy(int count, bool selecting, bool byWord) {
        CursorPos = byWord ? GetWordPosition(_getMessage(), count, CursorPos, true) : EditBox.OffsetByCodepoints(_getMessage(), CursorPos, count);
        ResetSelectionIfNeeded(selecting);
    }

    private void RemoveFromCursor(int count, bool byWord) {
        if (byWord) {
            count = GetWordPosition(_getMessage(), count, CursorPos, true) - CursorPos;
        }
        string message = _getMessage();
        if (message.Length == 0) {
            return;
        }
        string newMessage;
        if (SelectionPos != CursorPos) {
            newMessage = DeleteSelection(message);
        }
        else {
            int otherPos = EditBox.OffsetByCodepoints(message, CursorPos, count);
            int start = Math.Min(otherPos, CursorPos), end = Math.Max(otherPos, CursorPos);
            newMessage = message.Remove(start, end - start);
            if (count < 0) {
                SelectionPos = CursorPos = start;
            }
        }
        _setMessage(newMessage);
    }

    private void SelectAll() {
        SelectionPos = 0;
        CursorPos = _getMessage().Length;
    }

    private string Selected(string text) => text[Math.Min(CursorPos, SelectionPos)..Math.Max(CursorPos, SelectionPos)];

    private string DeleteSelection(string message) {
        if (SelectionPos == CursorPos) {
            return message;
        }
        int start = Math.Min(CursorPos, SelectionPos), end = Math.Max(CursorPos, SelectionPos);
        SelectionPos = CursorPos = start;
        return message[..start] + message[end..];
    }

    public void SetCursorToEnd(bool selecting = false) {
        CursorPos = _getMessage().Length;
        ResetSelectionIfNeeded(selecting);
    }

    /// <summary><c>StringSplitter.getWordPosition</c>.</summary>
    public static int GetWordPosition(string text, int dir, int from, bool stripSpaces) {
        int result = from;
        bool reverse = dir < 0;
        for (int i = 0; i < Math.Abs(dir); i++) {
            if (reverse) {
                while (stripSpaces && result > 0 && text[result - 1] == ' ') {
                    result--;
                }
                while (result > 0 && text[result - 1] != ' ') {
                    result--;
                }
            }
            else {
                int length = text.Length;
                result = text.IndexOf(' ', result);
                if (result == -1) {
                    result = length;
                }
                else {
                    while (stripSpaces && result < length && text[result] == ' ') {
                        result++;
                    }
                }
            }
        }
        return result;
    }
}

/// <summary>
/// <c>AbstractSignEditScreen</c> with <c>SignEditScreen</c> and <c>HangingSignEditScreen</c>: four lines typed onto
/// the sign itself, each held to the width the sign shows. Whatever replaces the screen, Done, Escape, the
/// sign going or the player walking off, sends the lines once as it goes.
/// </summary>
public sealed class SignEditScreen : Screen {
    private const float StandingTextScale = 0.9765628F;

    private readonly SignBlockEntity _sign;
    private readonly bool _isFrontText;
    private readonly string[] _messages;
    private readonly string _woodType;
    private readonly bool _wall;
    private SignText _text;
    private long _cursorBlinkStartTime;
    private int _line;
    private TextFieldHelper? _signField;

    public SignEditScreen(SignBlockEntity sign, bool isFrontText, bool shouldFilter) {
        _sign = sign;
        _isFrontText = isFrontText;
        _text = sign.GetText(isFrontText);
        _messages = Enumerable.Range(0, 4).Select(i => TextFlattener.Plain(_text.GetMessage(i, shouldFilter))).ToArray();
        _woodType = WoodType(sign.State.Identifier.Key);
        _wall = BlockClasses.Is(sign.State.Identifier, BlockClass.WallSignBlock);
    }

    /// <summary><c>SignBlock.getWoodType</c> by the block's name: <c>dark_oak_wall_hanging_sign</c> is dark oak.</summary>
    private static string WoodType(string path) {
        foreach (string suffix in (string[])["_wall_hanging_sign", "_hanging_sign", "_wall_sign", "_sign"]) {
            if (path.EndsWith(suffix, StringComparison.Ordinal)) {
                return path[..^suffix.Length];
            }
        }
        return path;
    }

    private string Title => Translations.Get(_sign.IsHanging ? "hanging_sign.edit" : "sign.edit") ?? "";

    protected override string NarrationTitle => Title;

    public override bool IsAllowedInPortal => false;

    protected override void Init(GuiContext context, int width, int height) {
        _cursorBlinkStartTime = Environment.TickCount64;
        Add(new Button(Translations.Get("gui.done") ?? "Done", width / 2 - 100, height / 4 + 144, 200, () => Close(context)));
        _signField = new TextFieldHelper(() => _messages[_line], SetMessage, () => TextFieldHelper.ClipboardContents(context),
            text => context.WriteClipboard?.Invoke(text), s => context.Text.Width(s) <= _sign.MaxTextLineWidth);
    }

    /// <summary><c>tick</c>: the editor closes once the sign is gone or out of reach.</summary>
    public override void Tick(GuiContext context) {
        if (context.Client.Player == null || _sign.Removed || _sign.PlayerIsTooFarAwayToEdit(context.Client.Player)) {
            Close(context);
        }
    }

    /// <summary><c>removed</c>: the lines go to the server however the screen was left.</summary>
    public override void Removed(GuiContext context) {
        context.Client.Send(new ServerBoundUpdateSignPacket {
            Location = new Vec3<int>(_sign.X, _sign.Y, _sign.Z),
            IsFrontText = _isFrontText,
            Lines = (string[])_messages.Clone()
        });
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        if (key == Key.Up) {
            _line = (_line - 1) & 3;
            _signField!.SetCursorToEnd();
            return;
        }
        if (key is Key.Down or Key.Enter or Key.KeypadEnter) {
            _line = (_line + 1) & 3;
            _signField!.SetCursorToEnd();
            return;
        }
        if (!_signField!.KeyPressed(key, control, Inventory.ContainerScreen.ShiftHeld())) {
            base.KeyDown(context, key, control);
        }
    }

    public override void Char(GuiContext context, char c) {
        LayOut(context);
        _signField!.CharTyped(c);
    }

    private void SetMessage(string message) {
        _messages[_line] = message;
        _text = _text.SetMessage(_line, TextComponent.Text(message));
        _sign.SetText(_text, _isFrontText);
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        context.Gui.Rect(0, 0, context.Width, context.Height, 0xC8101010);
        RenderWidgets(context);
        context.Text.DrawCentred(Title, context.Width / 2.0F, 40, 0xFFFFFFFF);
        float offsetX = context.Width / 2.0F, offsetY = _sign.IsHanging ? 125.0F : 90.0F;
        if (_sign.IsHanging) {
            // translate(0, -13), scale(4.5), the 16 pixel texture centred.
            float s = 4.5F;
            if (!context.Sprites.Blit(context.Gui, "gui/hanging_signs/" + _woodType, offsetX - 8 * s, offsetY - 13 - 8 * s, 16 * s, 16 * s, 0, 0, 16, 16)) {
                context.Gui.Rect(offsetX - 8 * s, offsetY - 13 - 8 * s, 16 * s, 16 * s, 0xFF8A6A3A);
            }
        }
        else {
            // translate(0, 27), scale(3.9), a 24 by 26 texture of which a wall sign shows the 12 pixel board.
            float s = 3.9F;
            int displayedHeight = _wall ? 12 : 26;
            if (!context.Sprites.Blit(context.Gui, "gui/signs/" + _woodType, offsetX - 12 * s, offsetY + 27 - 13 * s, 24 * s, displayedHeight * s, 0, 0, 24,
                    displayedHeight)) {
                context.Gui.Rect(offsetX - 12 * s, offsetY + 27 - 13 * s, 24 * s, 12 * s, 0xFF8A6A3A);
            }
        }
        float scale = _sign.IsHanging ? 1.0F : StandingTextScale;
        context.Gui.Zoom = scale;
        RenderSignText(context, offsetX / scale, offsetY / scale);
        context.Gui.Zoom = 1.0F;
    }

    /// <summary><c>extractSignText</c>, in the sign's own scaled pixels about (<paramref name="ox"/>, <paramref name="oy"/>).</summary>
    private void RenderSignText(GuiContext context, float ox, float oy) {
        uint color = _text.HasGlowingText ? SignRenderer.TextColor(_text.Color) : SignRenderer.GetDarkColor(_text);
        bool showCursor = (Environment.TickCount64 - _cursorBlinkStartTime) / 300L % 2L == 0L;
        int cursorPos = _signField!.CursorPos, selectionPos = _signField.SelectionPos;
        int lineHeight = _sign.TextLineHeight;
        int signMidpoint = 4 * lineHeight / 2;
        int cursorY = _line * lineHeight - signMidpoint;
        for (int i = 0; i < _messages.Length; i++) {
            string line = _messages[i];
            int x1 = -context.Text.Width(line) / 2;
            context.Text.Draw(line, ox + x1, oy + i * lineHeight - signMidpoint, color, false);
            if (i == _line && cursorPos >= 0 && showCursor && cursorPos >= line.Length) {
                int cursorX = context.Text.Width(line[..Math.Clamp(cursorPos, 0, line.Length)]) - context.Text.Width(line) / 2;
                context.Text.Draw("_", ox + cursorX, oy + cursorY, color, false);
            }
        }
        string current = _messages[_line];
        if (cursorPos < 0) {
            return;
        }
        int cursorPosition = context.Text.Width(current[..Math.Clamp(cursorPos, 0, current.Length)]);
        int insertX = cursorPosition - context.Text.Width(current) / 2;
        if (cursorPos < current.Length && showCursor) {
            context.Gui.Rect(ox + insertX, oy + cursorY - 1, 1, lineHeight + 1, color | 0xFF000000);
        }
        if (selectionPos != cursorPos) {
            int start = Math.Min(cursorPos, selectionPos), end = Math.Max(cursorPos, selectionPos);
            int startX = context.Text.Width(current[..start]) - context.Text.Width(current) / 2;
            int endX = context.Text.Width(current[..end]) - context.Text.Width(current) / 2;
            EditBox.TextHighlight(context, (int)(ox + Math.Min(startX, endX)), (int)(oy + cursorY), (int)(ox + Math.Max(startX, endX)), (int)(oy + cursorY + lineHeight));
        }
    }
}
