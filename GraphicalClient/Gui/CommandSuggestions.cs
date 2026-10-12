using System.Text.RegularExpressions;
using ClientLib;
using ClientLib.Brigadier;
using ClientLib.Commands;
using GraphicalClient.Gui.Inventory;
using Minecraft.Text;
using Silk.NET.Input;
using MessageArgument = ClientLib.Commands.Arguments.MessageArgument;
using StringReader = ClientLib.Brigadier.StringReader;

namespace GraphicalClient.Gui;

/// <summary>
/// Vanilla's <c>CommandSuggestions</c>: the highlighting, the suggestion list and the usage lines
/// that go with a text field taking commands. Narration is not ported.
/// </summary>
public sealed partial class CommandSuggestions {
    /// <summary>Java's <c>\s</c> is the six ASCII whitespace characters, where .NET's is every Unicode one.</summary>
    [GeneratedRegex("([ \\t\\n\\x0B\\f\\r]+)")]
    private static partial Regex WhitespacePattern();

    private static readonly int UnparsedStyle = Rgb(NamedTextColor.Red);
    private static readonly int LiteralStyle = Rgb(NamedTextColor.Gray);
    public static readonly int UsageFormat = Rgb(NamedTextColor.Gray);
    private static readonly int[] ArgumentStyles = [
        Rgb(NamedTextColor.Aqua), Rgb(NamedTextColor.Yellow), Rgb(NamedTextColor.Green), Rgb(NamedTextColor.LightPurple), Rgb(NamedTextColor.Gold)
    ];
    public const int LineHeight = 12;
    public const int UsageOffsetFromBottom = 27;

    private static TextComponent CommandsNotAllowedText => Component.Translatable("chat_screen.commands_not_allowed").WithColor(TextColor.Red);
    private static TextComponent MessagesNotAllowedText => Component.Translatable("chat_screen.messages_not_allowed").WithColor(TextColor.Red);

    private readonly MinecraftClient _minecraft;
    private readonly Func<int> _screenHeight;
    private readonly EditBox _input;
    private readonly TextRenderer _font;
    private readonly bool _commandsOnly;
    private readonly bool _onlyShowIfCursorPastError;
    private readonly int _lineStartOffset;
    private readonly int _suggestionLineLimit;
    private readonly bool _anchorToBottom;
    private readonly uint _fillColor;
    private readonly List<List<TextRun>> _commandUsage = [];
    private int _commandUsagePosition;
    private int _commandUsageWidth;
    private ParseResults<ClientSuggestionProvider>? _currentParse;
    private Task<Suggestions>? _pendingSuggestions;
    private SuggestionsList? _suggestions;
    private bool _currentParseIsCommand;
    private bool _currentParseIsMessage;
    private bool _allowSuggestions;
    private bool _keepSuggestions;
    private bool _allowHiding = true;
    private bool _messagesAllowed = true;
    private bool _commandsAllowed = true;

    public CommandSuggestions(MinecraftClient minecraft, Func<int> screenHeight, EditBox input, TextRenderer font, bool commandsOnly,
        bool onlyShowIfCursorPastError, int lineStartOffset, int suggestionLineLimit, bool anchorToBottom, uint fillColor) {
        _minecraft = minecraft;
        _screenHeight = screenHeight;
        _input = input;
        _font = font;
        _commandsOnly = commandsOnly;
        _onlyShowIfCursorPastError = onlyShowIfCursorPastError;
        _lineStartOffset = lineStartOffset;
        _suggestionLineLimit = suggestionLineLimit;
        _anchorToBottom = anchorToBottom;
        _fillColor = fillColor;
        input.AddFormatter(FormatChat);
    }

    private static int Rgb(NamedTextColor color) => color.ToTextColor().ToDecimal() & 0xFFFFFF;

    public void SetAllowSuggestions(bool allowSuggestions) {
        _allowSuggestions = allowSuggestions;
        if (!allowSuggestions) {
            _suggestions = null;
        }
    }

    public void SetAllowHiding(bool allowHiding) => _allowHiding = allowHiding;

    public void SetRestrictions(bool messagesAllowed, bool commandsAllowed) {
        _messagesAllowed = messagesAllowed;
        _commandsAllowed = commandsAllowed;
    }

    /// <summary><c>keyPressed</c>; the input having focus stands for it being the screen's focused widget.</summary>
    public bool KeyPressed(Key key, bool shift) {
        bool isVisible = _suggestions != null;
        if (isVisible && _suggestions!.KeyPressed(key, shift)) {
            return true;
        }
        if (!_input.Focused || key != Key.Tab || _allowHiding && !isVisible) {
            return false;
        }
        ShowSuggestions(true);
        return true;
    }

    public bool MouseScrolled(double scroll, int mouseX, int mouseY) {
        return _suggestions != null && _suggestions.MouseScrolled(Math.Clamp(scroll, -1.0, 1.0), mouseX, mouseY);
    }

    public bool MouseClicked(float x, float y) => _suggestions != null && _suggestions.MouseClicked((int)x, (int)y);

    public void ShowSuggestions(bool immediateNarration) {
        if (_pendingSuggestions is not { IsCompletedSuccessfully: true }) {
            return;
        }
        Suggestions suggestions = _pendingSuggestions.Result;
        if (suggestions.IsEmpty) {
            return;
        }
        int maxSuggestionWidth = 0;
        foreach (Suggestion suggestion in suggestions.List) {
            maxSuggestionWidth = Math.Max(maxSuggestionWidth, _font.Width(suggestion.Text));
        }
        int x = Math.Clamp(_input.GetScreenX(suggestions.Range.Start), 0, _input.GetScreenX(0) + _input.InnerWidth - maxSuggestionWidth);
        int y = _anchorToBottom ? _screenHeight() - 12 : 72;
        _suggestions = new SuggestionsList(this, x, y, maxSuggestionWidth, SortSuggestions(suggestions));
    }

    public void Hide() => _suggestions = null;

    private List<Suggestion> SortSuggestions(Suggestions suggestions) {
        string partialCommand = _input.Value[.._input.CursorPosition];
        int lastWordIndex = GetLastWordIndex(partialCommand);
        string lastWord = JavaText.ToLowerRoot(partialCommand[lastWordIndex..]);
        List<Suggestion> suggestionList = [];
        List<Suggestion> partial = [];
        foreach (Suggestion suggestion in suggestions.List) {
            if (!suggestion.Text.StartsWith(lastWord, StringComparison.Ordinal) && !suggestion.Text.StartsWith("minecraft:" + lastWord, StringComparison.Ordinal)) {
                partial.Add(suggestion);
            }
            else {
                suggestionList.Add(suggestion);
            }
        }
        suggestionList.AddRange(partial);
        return suggestionList;
    }

    public void UpdateCommandInfo() {
        string command = _input.Value;
        if (_currentParse != null && _currentParse.Reader.String != command) {
            _currentParse = null;
            _currentParseIsCommand = false;
            _currentParseIsMessage = false;
        }
        if (!_keepSuggestions) {
            _input.SetSuggestion(null);
            _suggestions = null;
        }

        _commandUsage.Clear();
        StringReader reader = new(command);
        bool startsWithSlash = reader.CanRead() && reader.Peek() == '/';
        if (startsWithSlash) {
            reader.Skip();
        }

        bool isCommand = _commandsOnly || startsWithSlash;
        int cursorPosition = _input.CursorPosition;
        if (isCommand) {
            CommandDispatcher<ClientSuggestionProvider> commands = _minecraft.Commands;
            if (_currentParse == null) {
                _currentParse = commands.Parse(reader, _minecraft.SuggestionsProvider);
                _currentParseIsCommand = true;
                _currentParseIsMessage = HasMessageArguments(_currentParse);
            }

            int parseStart = _onlyShowIfCursorPastError ? reader.Cursor : 1;
            if (cursorPosition >= parseStart && (_suggestions == null || !_keepSuggestions)) {
                Task<Suggestions> pending = commands.GetCompletionSuggestions(_currentParse, cursorPosition);
                _pendingSuggestions = pending;
                pending.ContinueWith(task => {
                    if (_pendingSuggestions is { IsCompleted: true }) {
                        UpdateUsageInfo(_currentParse!, task.Result);
                    }
                }, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);
            }
        }
        else if (!command.All(JavaText.IsWhitespace)) {
            _currentParseIsMessage = true;
            string partialCommand = command[..cursorPosition];
            int lastWord = GetLastWordIndex(partialCommand);
            IReadOnlyCollection<string> nonCommandSuggestions = ((ISharedSuggestionProvider)_minecraft.SuggestionsProvider).CustomTabSuggestions;
            _pendingSuggestions = SharedSuggestionProvider.Suggest(nonCommandSuggestions, new SuggestionsBuilder(partialCommand, lastWord));
            if (_currentParseIsMessage && !_messagesAllowed) {
                _commandUsage.Add(TextFlattener.Flatten(MessagesNotAllowedText));
            }
            RecomputeUsageBoxWidth();
            _commandUsagePosition = 0;
        }
        else {
            _pendingSuggestions = null;
        }
    }

    private static bool HasMessageArguments(ParseResults<ClientSuggestionProvider> parseResults) {
        bool foundMessageArgument = false;
        ArgumentVisitor.VisitArguments(parseResults, (_, _, value) => {
            foundMessageArgument |= value != null && value.Result is MessageArgument.Message;
        }, false);
        return foundMessageArgument;
    }

    private static int GetLastWordIndex(string text) {
        if (string.IsNullOrEmpty(text)) {
            return 0;
        }
        int result = 0;
        foreach (Match match in WhitespacePattern().Matches(text)) {
            result = match.Index + match.Length;
        }
        return result;
    }

    private static List<TextRun> GetExceptionMessage(CommandSyntaxException e) {
        TextComponent message = e.RawMessage;
        string? context = e.Context;
        return context == null
            ? TextFlattener.Flatten(message)
            : TextFlattener.Flatten(Component.Translatable("command.context.parse_error", message, e.Cursor, context));
    }

    private void UpdateUsageInfo(ParseResults<ClientSuggestionProvider> currentParse, Suggestions suggestions) {
        bool trailingCharacters = false;
        if (_input.CursorPosition == _input.Value.Length) {
            if (suggestions.IsEmpty && currentParse.Exceptions.Count > 0) {
                int literals = 0;
                foreach (CommandSyntaxException exception in currentParse.Exceptions.Values) {
                    if (exception.Type == CommandSyntaxException.BuiltInExceptions.LiteralIncorrect) {
                        literals++;
                    }
                    else {
                        _commandUsage.Add(GetExceptionMessage(exception));
                    }
                }
                if (literals > 0) {
                    _commandUsage.Add(GetExceptionMessage(CommandSyntaxException.BuiltInExceptions.DispatcherUnknownArgument.CreateWithContext(currentParse.Reader)));
                }
            }
            else if (currentParse.Reader.CanRead()) {
                trailingCharacters = true;
            }
        }

        SuggestionContext<ClientSuggestionProvider> suggestionContextAtCursor = currentParse.Context.FindSuggestionContext(_input.CursorPosition);
        if (_commandUsage.Count == 0) {
            List<List<TextRun>> usageEntries = FillNodeUsage(suggestionContextAtCursor, UsageFormat);
            if (usageEntries.Count == 0 && trailingCharacters) {
                _commandUsage.Add(GetExceptionMessage(CommandsUtil.GetParseException(currentParse)!));
            }
            _commandUsage.AddRange(usageEntries);
        }

        if (_currentParseIsCommand && !_commandsAllowed) {
            _commandUsage.Add(TextFlattener.Flatten(CommandsNotAllowedText));
        }
        if (_currentParseIsMessage && !_messagesAllowed) {
            _commandUsage.Add(TextFlattener.Flatten(MessagesNotAllowedText));
        }

        RecomputeUsageBoxWidth();
        if (_commandUsage.Count > 0) {
            _commandUsagePosition = Math.Clamp(_input.GetScreenX(suggestionContextAtCursor.StartPos), 0,
                _input.GetScreenX(0) + _input.InnerWidth - _commandUsageWidth);
        }
        else {
            _commandUsagePosition = 0;
        }

        _suggestions = null;
        // options.autoSuggestions, which defaults to on and has no setting in this client.
        if (_allowSuggestions) {
            ShowSuggestions(false);
        }
    }

    private List<List<TextRun>> FillNodeUsage(SuggestionContext<ClientSuggestionProvider> suggestionContext, int usageFormat) {
        OrderedDictionary<CommandNode<ClientSuggestionProvider>, string> usage =
            _minecraft.Commands.GetSmartUsage(suggestionContext.Parent, _minecraft.SuggestionsProvider);
        List<List<TextRun>> lines = [];
        foreach ((CommandNode<ClientSuggestionProvider> node, string text) in usage) {
            if (node is not LiteralCommandNode<ClientSuggestionProvider>) {
                lines.Add([new TextRun(text, usageFormat)]);
            }
        }
        return lines;
    }

    private void RecomputeUsageBoxWidth() {
        int longest = 0;
        foreach (List<TextRun> entry in _commandUsage) {
            longest = Math.Max(longest, _font.Width(entry));
        }
        _commandUsageWidth = longest;
    }

    private List<TextRun>? FormatChat(string text, int offset) => _currentParse != null ? FormatText(_currentParse, text, offset) : null;

    private static string? CalculateSuggestionSuffix(string contents, string suggestion) {
        return suggestion.StartsWith(contents, StringComparison.Ordinal) ? suggestion[contents.Length..] : null;
    }

    private static List<TextRun> FormatText(ParseResults<ClientSuggestionProvider> currentParse, string text, int offset) {
        List<TextRun> parts = [];
        int unformattedStart = 0;
        int nextColor = -1;
        CommandContextBuilder<ClientSuggestionProvider> context = currentParse.Context.LastChild;
        foreach (ParsedArgument<ClientSuggestionProvider> argument in context.Arguments.Values) {
            if (++nextColor >= ArgumentStyles.Length) {
                nextColor = 0;
            }
            int start = Math.Max(argument.Range.Start - offset, 0);
            if (start >= text.Length) {
                break;
            }
            int end = Math.Min(argument.Range.End - offset, text.Length);
            if (end > 0) {
                parts.Add(new TextRun(text[unformattedStart..start], LiteralStyle));
                parts.Add(new TextRun(text[start..end], ArgumentStyles[nextColor]));
                unformattedStart = end;
            }
        }

        if (currentParse.Reader.CanRead()) {
            int start = Math.Max(currentParse.Reader.Cursor - offset, 0);
            if (start < text.Length) {
                int end = Math.Min(start + currentParse.Reader.RemainingLength, text.Length);
                parts.Add(new TextRun(text[unformattedStart..start], LiteralStyle));
                parts.Add(new TextRun(text[start..end], UnparsedStyle));
                unformattedStart = end;
            }
        }

        parts.Add(new TextRun(text[unformattedStart..], LiteralStyle));
        return parts;
    }

    public void Render(GuiContext context, int mouseX, int mouseY) {
        if (!RenderSuggestions(context, mouseX, mouseY)) {
            RenderUsage(context);
        }
    }

    public bool RenderSuggestions(GuiContext context, int mouseX, int mouseY) {
        if (_suggestions == null) {
            return false;
        }
        _suggestions.Render(context, mouseX, mouseY);
        return true;
    }

    public void RenderUsage(GuiContext context) {
        int y = 0;
        foreach (List<TextRun> line in _commandUsage) {
            int lineY = _anchorToBottom ? _screenHeight() - UsageOffsetFromBottom - LineHeight * y : 72 + LineHeight * y;
            context.Gui.Rect(_commandUsagePosition - 1, lineY, _commandUsageWidth + 2, LineHeight, _fillColor);
            _font.Draw(line, _commandUsagePosition, lineY + 2);
            y++;
        }
    }

    public bool HasAllowedInput => (!_currentParseIsMessage || _messagesAllowed) && (!_currentParseIsCommand || _commandsAllowed);

    /// <summary>Vanilla's <c>CommandSuggestions.SuggestionsList</c>.</summary>
    private sealed class SuggestionsList {
        private readonly CommandSuggestions _owner;
        private readonly int _rectX;
        private readonly int _rectY;
        private readonly int _rectWidth;
        private readonly int _rectHeight;
        private readonly string _originalContents;
        private readonly List<Suggestion> _suggestionList;
        private int _offset;
        private int _current;
        private (float X, float Y) _lastMouse = (0, 0);
        public bool TabCycles;

        public SuggestionsList(CommandSuggestions owner, int x, int y, int width, List<Suggestion> suggestionList) {
            _owner = owner;
            int listX = x - (owner._input.Bordered ? 0 : 1);
            int listY = owner._anchorToBottom
                ? y - 3 - Math.Min(suggestionList.Count, owner._suggestionLineLimit) * LineHeight
                : y - (owner._input.Bordered ? 1 : 0);
            _rectX = listX;
            _rectY = listY;
            _rectWidth = width + 1;
            _rectHeight = Math.Min(suggestionList.Count, owner._suggestionLineLimit) * LineHeight;
            _originalContents = owner._input.Value;
            _suggestionList = suggestionList;
            Select(0);
        }

        /// <summary><c>Rect2i.contains</c>, inclusive of the far edges.</summary>
        private bool RectContains(int x, int y) => x >= _rectX && x <= _rectX + _rectWidth && y >= _rectY && y <= _rectY + _rectHeight;

        public void Render(GuiContext context, int mouseX, int mouseY) {
            int limit = Math.Min(_suggestionList.Count, _owner._suggestionLineLimit);
            const uint unselectedColor = 0xFFAAAAAA;
            bool hasPrevious = _offset > 0;
            bool hasNext = _suggestionList.Count > _offset + limit;
            bool limited = hasPrevious || hasNext;
            bool mouseMoved = _lastMouse.X != mouseX || _lastMouse.Y != mouseY;
            if (mouseMoved) {
                _lastMouse = (mouseX, mouseY);
            }

            if (limited) {
                context.Gui.Rect(_rectX, _rectY - 1, _rectWidth, 1, _owner._fillColor);
                context.Gui.Rect(_rectX, _rectY + _rectHeight, _rectWidth, 1, _owner._fillColor);
                if (hasPrevious) {
                    DottedLine(context, _rectY - 1);
                }
                if (hasNext) {
                    DottedLine(context, _rectY + _rectHeight);
                }
            }

            bool hovered = false;
            for (int i = 0; i < limit; i++) {
                Suggestion suggestion = _suggestionList[i + _offset];
                context.Gui.Rect(_rectX, _rectY + LineHeight * i, _rectWidth, LineHeight, _owner._fillColor);
                if (mouseX > _rectX && mouseX < _rectX + _rectWidth && mouseY > _rectY + LineHeight * i && mouseY < _rectY + LineHeight * i + LineHeight) {
                    if (mouseMoved) {
                        Select(i + _offset);
                    }
                    hovered = true;
                }
                _owner._font.Draw(suggestion.Text, _rectX + 1, _rectY + 2 + LineHeight * i, i + _offset == _current ? 0xFFFFFF00 : unselectedColor);
            }

            if (hovered && _suggestionList[_current].Tooltip is { } tooltip) {
                Tooltips.Draw(context, [TextFlattener.Flatten(tooltip)], mouseX, mouseY);
            }
        }

        private void DottedLine(GuiContext context, int y) {
            for (int x = 0; x < _rectWidth; x += 2) {
                context.Gui.Rect(_rectX + x, y, 1, 1, 0xFFFFFFFF);
            }
        }

        public bool MouseClicked(int x, int y) {
            if (!RectContains(x, y)) {
                return false;
            }
            int line = (y - _rectY) / LineHeight + _offset;
            if (line >= 0 && line < _suggestionList.Count) {
                Select(line);
                UseSuggestion();
            }
            return true;
        }

        public bool MouseScrolled(double scroll, int mouseX, int mouseY) {
            if (!RectContains(mouseX, mouseY)) {
                return false;
            }
            _offset = Math.Clamp((int)(_offset - scroll), 0, Math.Max(_suggestionList.Count - _owner._suggestionLineLimit, 0));
            return true;
        }

        public bool KeyPressed(Key key, bool shift) {
            switch (key) {
                case Key.Up:
                    Cycle(-1);
                    TabCycles = false;
                    return true;
                case Key.Down:
                    Cycle(1);
                    TabCycles = false;
                    return true;
                case Key.Tab:
                    if (TabCycles) {
                        Cycle(shift ? -1 : 1);
                    }
                    UseSuggestion();
                    return true;
                case Key.Escape:
                    _owner.Hide();
                    _owner._input.SetSuggestion(null);
                    return true;
                default:
                    return false;
            }
        }

        public void Cycle(int direction) {
            Select(_current + direction);
            int first = _offset;
            int last = _offset + _owner._suggestionLineLimit - 1;
            if (_current < first) {
                _offset = Math.Clamp(_current, 0, Math.Max(_suggestionList.Count - _owner._suggestionLineLimit, 0));
            }
            else if (_current > last) {
                _offset = Math.Clamp(_current + _owner._lineStartOffset - _owner._suggestionLineLimit, 0,
                    Math.Max(_suggestionList.Count - _owner._suggestionLineLimit, 0));
            }
        }

        public void Select(int index) {
            _current = index;
            if (_current < 0) {
                _current += _suggestionList.Count;
            }
            if (_current >= _suggestionList.Count) {
                _current -= _suggestionList.Count;
            }
            Suggestion suggestion = _suggestionList[_current];
            _owner._input.SetSuggestion(CalculateSuggestionSuffix(_owner._input.Value, suggestion.Apply(_originalContents)));
        }

        public void UseSuggestion() {
            Suggestion suggestion = _suggestionList[_current];
            _owner._keepSuggestions = true;
            _owner._input.Value = suggestion.Apply(_originalContents);
            int end = suggestion.Range.Start + suggestion.Text.Length;
            _owner._input.SetCursorPosition(end);
            _owner._input.SetHighlightPos(end);
            Select(_current);
            _owner._keepSuggestions = false;
            TabCycles = true;
        }
    }
}
