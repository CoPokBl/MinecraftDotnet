using System.Text;
using ClientLib;
using ClientLib.Brigadier;
using GraphicalClient.Gui.Inventory;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>
/// Vanilla's <c>ChatScreen</c>: the input line, its command suggestions, the history Up and Down walk, the
/// chat window in front with its links and hovers, and the draft kept when the screen goes unsent.
/// </summary>
public class ChatScreen : Screen {
    public const uint UsageBackgroundColor = 0xD0000000;
    private const double MouseScrollSpeed = 7.0;

    private readonly bool _closeOnSubmit;
    private string _historyBuffer = "";
    private int _historyPos = -1;
    private EditBox? _input;
    private string _initial;
    private ChatComponent.DisplayMode _displayMode = ChatComponent.DisplayMode.Foreground;
    private CommandSuggestions? _commandSuggestions;

    public ChatScreen(Hud hud, string initial, bool isDraft, bool closeOnSubmit = true) {
        Hud = hud;
        _initial = initial;
        IsDraft = isDraft;
        _closeOnSubmit = closeOnSubmit;
    }

    protected Hud Hud { get; }

    private ChatComponent Chat => Hud.Chat;

    /// <summary>Whether the text is a draft brought back, drawn grey until it is edited.</summary>
    protected bool IsDraft { get; private set; }

    /// <summary><c>ChatScreen.ExitReason</c>, which decides what <see cref="Removed"/> does with the text.</summary>
    protected enum ExitReason {
        Intentional,
        Interrupted,
        Done
    }

    protected ExitReason Exit { get; set; } = ExitReason.Interrupted;

    public override bool HasFocusedEditBox => true;

    protected override string NarrationTitle => Menus.T("chat_screen.title");

    /// <summary>What is typed in the input line.</summary>
    protected string InputValue => _input?.Value ?? _initial;

    /// <summary><c>init</c>, which on a resize carries the typed text over as vanilla's <c>resize</c> does.</summary>
    protected override void Init(GuiContext context, int width, int height) {
        if (_input != null) {
            _initial = _input.Value;
        }
        _historyPos = Chat.RecentChat.Count;
        EditBox input = new(context.Text, 4, height - 12, width - 4, 12) {
            MaxLength = 256,
            Bordered = false
        };
        input.Value = _initial;
        input.SetResponder(OnEdited);
        input.AddFormatter(FormatChat);
        input.CanLoseFocus = false;
        _input = input;
        _commandSuggestions = new CommandSuggestions(context.Client, () => context.Height, input, context.Text, false, false, 1, 10, true, UsageBackgroundColor) {
            AutoSuggestions = () => context.Settings?.AutoSuggestions ?? true
        };
        _commandSuggestions.SetAllowHiding(false);
        _commandSuggestions.SetAllowSuggestions(false);
        ClientLib.Chat.ChatAbilities chatAbilities = context.Client.ChatAbilities;
        _displayMode = chatAbilities.HasAnyRestrictions ? ChatComponent.DisplayMode.ForegroundRestricted : ChatComponent.DisplayMode.Foreground;
        _commandSuggestions.SetRestrictions(chatAbilities.CanSendMessages, chatAbilities.CanSendCommands);
        _commandSuggestions.UpdateCommandInfo();
        input.Focused = true;
    }

    public override void Removed(GuiContext context) {
        Chat.ResetChatScroll();
        _initial = InputValue;
        if (ShouldDiscardDraft(context) || string.IsNullOrWhiteSpace(_initial)) {
            Chat.DiscardDraft();
        }
        else if (!IsDraft) {
            Chat.SaveAsDraft(_initial);
        }
    }

    private bool ShouldDiscardDraft(GuiContext context) =>
        Exit != ExitReason.Interrupted && (Exit != ExitReason.Intentional || context.Settings?.SaveChatDrafts != true);

    private void OnEdited(string value) {
        if (_commandSuggestions == null) {
            return;
        }
        _commandSuggestions.SetAllowSuggestions(true);
        _commandSuggestions.UpdateCommandInfo();
        IsDraft = false;
    }

    /// <summary><c>formatChat</c>: a draft is grey and italic.</summary>
    private List<TextRun>? FormatChat(string text, int offset) => IsDraft ? [new TextRun(text, 0xAAAAAA, Italic: true)] : null;

    private static bool Shift => ContainerScreen.ShiftHeld();

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        if (_commandSuggestions!.KeyPressed(key, Shift)) {
            return;
        }
        if (IsDraft && key == Key.Backspace) {
            _input!.Value = "";
            IsDraft = false;
            return;
        }
        if (key == Key.Escape) {
            base.KeyDown(context, key, control);
            return;
        }
        if (_input!.KeyPressed(context, key, control, Shift)) {
            return;
        }
        switch (key) {
            case Key.Enter or Key.KeypadEnter:
                if (!_commandSuggestions.HasAllowedInput) {
                    return;
                }
                HandleChatInput(context, _input.Value, true);
                if (_closeOnSubmit) {
                    Exit = ExitReason.Done;
                    context.Open?.Invoke(null);
                }
                else {
                    _input.Value = "";
                    Chat.ResetChatScroll();
                }
                break;
            case Key.Down:
                MoveInHistory(1);
                break;
            case Key.Up:
                MoveInHistory(-1);
                break;
            case Key.PageUp:
                Chat.ScrollChat(Chat.LinesPerPage - 1);
                break;
            case Key.PageDown:
                Chat.ScrollChat(-Chat.LinesPerPage + 1);
                break;
        }
    }

    public override void Char(GuiContext context, char c) {
        LayOut(context);
        _input!.CharTyped(c);
    }

    public override void Scroll(GuiContext context, float delta) {
        LayOut(context);
        double scrollY = Math.Clamp(delta, -1.0, 1.0);
        if (_commandSuggestions!.MouseScrolled(scrollY, (int)MouseX, (int)MouseY)) {
            return;
        }
        if (!Shift) {
            scrollY *= MouseScrollSpeed;
        }
        Chat.ScrollChat((int)scrollY);
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (_commandSuggestions!.MouseClicked(x, y)) {
            return;
        }
        if (button == MouseButton.Left) {
            bool insertionClickMode = Shift;
            if (Chat.FindClickable(context, (int)context.Client.ClientTicks, (int)x, (int)y, _displayMode, insertionClickMode) is { } clicked
                && HandleComponentClicked(context, clicked, insertionClickMode)) {
                _initial = _input!.Value;
                return;
            }
        }
        if (ClickWidgets(context, x, y, button)) {
            return;
        }
        if (button == MouseButton.Left && _input!.IsMouseOver(x, y)) {
            _input.OnClick(x, Shift);
        }
    }

    /// <summary><c>handleComponentClicked</c>: shift inserts a run's insertion and lets the click carry on; otherwise its click event runs.</summary>
    private bool HandleComponentClicked(GuiContext context, TextRun clicked, bool allowInsertions) {
        if (allowInsertions) {
            if (clicked.Insertion != null) {
                InsertText(clicked.Insertion, false);
            }
            return false;
        }
        if (clicked.Click is not { } click) {
            return false;
        }
        if (ChatComponent.IsQueueExpand(click)) {
            if (context.Client.ChatListener.QueueSize != 0L) {
                context.Client.ChatListener.AcceptNextDelayedMessage();
            }
        }
        else if (ChatComponent.IsGoToRestrictions(click)) {
            context.Open?.Invoke(new RestrictionsScreen(this, context.Client.ChatAbilities));
        }
        else {
            ClickEvents.HandleGameClickEvent(context, click, this);
        }
        return true;
    }

    public override void InsertText(string text, bool replace) {
        if (_input == null) {
            _initial = replace ? text : _initial + text;
        }
        else if (replace) {
            _input.Value = text;
        }
        else {
            _input.InsertText(text);
        }
    }

    public override void Close(GuiContext context) {
        Exit = ExitReason.Intentional;
        base.Close(context);
    }

    public void MoveInHistory(int dir) {
        int newPos = _historyPos + dir;
        int max = Chat.RecentChat.Count;
        newPos = Math.Clamp(newPos, 0, max);
        if (newPos == _historyPos) {
            return;
        }
        if (newPos == max) {
            _historyPos = max;
            _input!.Value = _historyBuffer;
        }
        else {
            if (_historyPos == max) {
                _historyBuffer = _input!.Value;
            }
            _input!.Value = Chat.RecentChat[newPos];
            _commandSuggestions!.SetAllowSuggestions(false);
            _historyPos = newPos;
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        uint background = context.Settings?.BackgroundColor(0x80000000) ?? 0x80000000;
        context.Gui.Rect(2, context.Height - 14, context.Width - 4, 12, background);
        Action? tooltip = Chat.Render(context, (int)context.Client.ClientTicks, context.MouseX, context.MouseY, _displayMode);
        _input!.Render(context);
        RenderWidgets(context);
        _commandSuggestions!.Render(context, (int)MouseX, (int)MouseY);
        tooltip?.Invoke();
    }

    protected override void UpdateNarrationState(Narration.INarrationOutput output) {
        output.Add(Narration.NarratedElementType.Title, TextComponent.Translatable("chat_screen.title"));
        output.Add(Narration.NarratedElementType.Usage, _displayMode == ChatComponent.DisplayMode.ForegroundRestricted
            ? TextComponent.Empty().With(TextComponent.Translatable("chat_screen.usage")).With(TextComponent.Text(". "))
                .With(TextComponent.Translatable("chat_screen.restricted.narration"))
            : TextComponent.Translatable("chat_screen.usage"));
        string value = InputValue;
        if (value.Length > 0) {
            output.Nest().Add(Narration.NarratedElementType.Title, TextComponent.Translatable("chat_screen.message", with: [TextComponent.Text(value)]));
        }
    }

    /// <summary><c>handleChatInput</c>.</summary>
    public void HandleChatInput(GuiContext context, string msg, bool addToRecent) {
        msg = NormalizeChatMessage(msg);
        if (msg.Length == 0) {
            return;
        }
        if (addToRecent) {
            Chat.AddRecentChat(msg);
        }
        context.Client.SendChat(msg);
    }

    /// <summary><c>normalizeChatMessage</c>: trim, <c>StringUtils.normalizeSpace</c>, then <c>StringUtil.trimChatMessage</c>.</summary>
    public static string NormalizeChatMessage(string message) {
        string normalized = NormalizeSpace(JavaText.Trim(message));
        return normalized.Length <= 256 ? normalized : normalized[..256];
    }

    /// <summary>
    /// Commons Lang's <c>StringUtils.normalizeSpace</c>: each run of whitespace becomes one space, and a
    /// no-break space, which is not whitespace to Java, becomes a plain space without being collapsed.
    /// </summary>
    private static string NormalizeSpace(string str) {
        StringBuilder builder = new(str.Length);
        int whitespacesCount = 0;
        bool startWhitespaces = true;
        foreach (char c in str) {
            if (JavaText.IsWhitespace(c)) {
                if (whitespacesCount == 0 && !startWhitespaces) {
                    builder.Append(' ');
                }
                whitespacesCount++;
            }
            else {
                startWhitespaces = false;
                builder.Append(c == '\u00a0' ? ' ' : c);
                whitespacesCount = 0;
            }
        }
        if (whitespacesCount > 0 && builder.Length > 0) {
            builder.Length--;
        }
        return JavaText.Trim(builder.ToString());
    }
}
