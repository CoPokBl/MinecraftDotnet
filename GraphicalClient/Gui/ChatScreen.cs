using System.Text;
using ClientLib.Brigadier;
using GraphicalClient.Gui.Inventory;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>
/// Vanilla's <c>ChatScreen</c>: the input line, its command suggestions, and the history Up and Down
/// walk. Drafts, clickable chat and the restrictions screen are not ported.
/// </summary>
public class ChatScreen : Screen {
    public const uint UsageBackgroundColor = 0xD0000000;
    private const int MaxRecentChat = 100;

    /// <summary><c>ChatComponent.recentChat</c>, which outlives any one chat screen.</summary>
    private static readonly List<string> History = [];

    private string _historyBuffer = "";
    private int _historyPos = -1;
    private EditBox? _input;
    private string _initial;
    private CommandSuggestions? _commandSuggestions;
    private readonly bool _closeOnSubmit;

    public ChatScreen(Hud hud, string initial = "", bool closeOnSubmit = true) {
        Hud = hud;
        _initial = initial;
        _closeOnSubmit = closeOnSubmit;
        hud.ChatOpen = true;
        hud.ChatScroll = 0;
    }

    protected Hud Hud { get; }

    /// <summary>What is typed in the input line.</summary>
    protected string InputValue => _input?.Value ?? _initial;

    /// <summary><c>init</c>, which on a resize carries the typed text over as vanilla's <c>resize</c> does.</summary>
    protected override void Init(GuiContext context, int width, int height) {
        if (_input != null) {
            _initial = _input.Value;
        }
        _historyPos = History.Count;
        EditBox input = new(context.Text, 4, height - 12, width - 4, 12) {
            MaxLength = 256,
            Bordered = false
        };
        input.Value = _initial;
        input.SetResponder(OnEdited);
        input.CanLoseFocus = false;
        _input = input;
        _commandSuggestions = new CommandSuggestions(context.Client, () => context.Height, input, context.Text, false, false, 1, 10, true, UsageBackgroundColor);
        _commandSuggestions.SetAllowHiding(false);
        _commandSuggestions.SetAllowSuggestions(false);
        // Vanilla takes these from the player's chat abilities, which this client does not track.
        _commandSuggestions.SetRestrictions(true, true);
        _commandSuggestions.UpdateCommandInfo();
        input.Focused = true;
    }

    private void OnEdited(string value) {
        if (_commandSuggestions == null) {
            return;
        }
        _commandSuggestions.SetAllowSuggestions(true);
        _commandSuggestions.UpdateCommandInfo();
    }

    private static bool Shift => ContainerScreen.ShiftHeld();

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        if (_commandSuggestions!.KeyPressed(key, Shift)) {
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
                    Close(context);
                }
                else {
                    _input.Value = "";
                    Hud.ChatScroll = 0;
                }
                break;
            case Key.Down:
                MoveInHistory(1);
                break;
            case Key.Up:
                MoveInHistory(-1);
                break;
            case Key.PageUp:
                Hud.ChatScroll += 5;
                break;
            case Key.PageDown:
                Hud.ChatScroll = Math.Max(0, Hud.ChatScroll - 5);
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
        Hud.ChatScroll = Math.Max(0, Hud.ChatScroll + (delta > 0 ? 1 : -1));
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (_commandSuggestions!.MouseClicked(x, y)) {
            return;
        }
        if (ClickWidgets(context, x, y, button)) {
            return;
        }
        if (button == MouseButton.Left && _input!.IsMouseOver(x, y)) {
            _input.OnClick(x, Shift);
        }
    }

    public override void Close(GuiContext context) {
        Hud.ChatOpen = false;
        Hud.ChatScroll = 0;
        base.Close(context);
    }

    public void MoveInHistory(int dir) {
        int newPos = _historyPos + dir;
        int max = History.Count;
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
            _input!.Value = History[newPos];
            _commandSuggestions!.SetAllowSuggestions(false);
            _historyPos = newPos;
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        context.Gui.Rect(2, context.Height - 14, context.Width - 4, 12, 0x80000000);
        _input!.Render(context);
        _commandSuggestions!.Render(context, (int)MouseX, (int)MouseY);
        // Vanilla draws widgets before the suggestions, which cover the in bed screen's button; here it goes over them.
        RenderWidgets(context);
    }

    /// <summary><c>ChatComponent.addRecentChat</c>.</summary>
    private static void AddRecentChat(string message) {
        if (History.Count > 0 && History[^1] == message) {
            return;
        }
        if (History.Count >= MaxRecentChat) {
            History.RemoveAt(0);
        }
        History.Add(message);
    }

    public static void HandleChatInput(GuiContext context, string msg, bool addToRecent) {
        msg = NormalizeChatMessage(msg);
        if (msg.Length == 0) {
            return;
        }
        if (addToRecent) {
            AddRecentChat(msg);
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
                builder.Append(c == '\u00A0' ? ' ' : c);
                whitespacesCount = 0;
            }
        }
        if (whitespacesCount > 0 && builder.Length > 0) {
            builder.Length--;
        }
        return JavaText.Trim(builder.ToString());
    }
}
