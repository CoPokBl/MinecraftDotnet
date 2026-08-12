using Minecraft.Data.Dialogs;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Text;

namespace ManagedServer.Dialogs;

/// <summary>
/// Builds a dialog out of some text, some inputs and some buttons, each button carrying the code to
/// run when it's pressed. One button makes a notice, more than one makes a grid.
/// </summary>
/// <example>
/// <code>
/// player.ShowDialog(new DialogBuilder("Report a player")
///     .Body("Who are you reporting?")
///     .TextInput("name", "Name")
///     .Button("Send", r => Report(r.GetString("name")!))
///     .Button("Cancel", null));
/// </code>
/// </example>
public class DialogBuilder(TextComponent title) {
    private readonly List<DialogBody> _body = [];
    private readonly List<DialogInput> _inputs = [];
    private readonly List<(DialogActionButton Button, Action<DialogResponse>? Handler)> _buttons = [];
    private (DialogActionButton Button, Action<DialogResponse>? Handler)? _exitButton;
    private TextComponent? _externalTitle;
    private bool _canCloseWithEscape = true;
    private bool _pause = true;
    private bool _pauseSet;
    private DialogAfterAction _afterAction = DialogAfterAction.Close;
    private int _columns = 2;

    /// <summary>The title of the button that opens this dialog from a list, if it's ever in one.</summary>
    public DialogBuilder ExternalTitle(TextComponent title) {
        _externalTitle = title;
        return this;
    }

    /// <summary>Whether escape dismisses the dialog. On by default.</summary>
    public DialogBuilder CanCloseWithEscape(bool canClose = true) {
        _canCloseWithEscape = canClose;
        return this;
    }

    /// <summary>
    /// Whether a singleplayer world is paused while the dialog is open. On by default, except
    /// that <see cref="DialogAfterAction.None"/> turns it off, because the client rejects a dialog
    /// that pauses the game and never unpauses it.
    /// </summary>
    public DialogBuilder Pause(bool pause = true) {
        _pause = pause;
        _pauseSet = true;
        return this;
    }

    /// <summary>
    /// What happens to the dialog once a button is pressed. Closes by default;
    /// <see cref="DialogAfterAction.None"/> and <see cref="DialogAfterAction.WaitForResponse"/>
    /// leave it up, so the handlers stay live until something else closes it.
    /// <see cref="DialogAfterAction.None"/> can't be combined with pausing.
    /// </summary>
    public DialogBuilder AfterAction(DialogAfterAction afterAction) {
        _afterAction = afterAction;
        return this;
    }

    /// <summary>Adds a paragraph of text above the buttons.</summary>
    /// <param name="width">How wide the text gets before it wraps.</param>
    public DialogBuilder Body(TextComponent text, int width = 200) {
        return Body(new DialogBody.PlainMessage(text, width));
    }

    public DialogBuilder Body(DialogBody body) {
        _body.Add(body);
        return this;
    }

    /// <summary>Adds an item next to a description of it.</summary>
    public DialogBuilder ItemBody(DialogItem item, TextComponent? description = null) {
        return Body(new DialogBody.ItemBody(item,
            description == null ? null : new DialogBody.PlainMessage(description)));
    }

    /// <summary>A single line text box.</summary>
    /// <param name="key">What the value is called in the response.</param>
    public DialogBuilder TextInput(string key, TextComponent label, string initial = "",
        int maxLength = 32, int width = 200, bool labelVisible = true, MultilineOptions? multiline = null) {

        return Input(new DialogInput(key,
            new InputControl.Text(label, width, labelVisible, initial, maxLength, multiline)));
    }

    /// <summary>A tick box. Read it back with <see cref="DialogResponse.GetBool"/>.</summary>
    public DialogBuilder BooleanInput(string key, TextComponent label, bool initial = false,
        string onTrue = "true", string onFalse = "false") {

        return Input(new DialogInput(key, new InputControl.Boolean(label, initial, onTrue, onFalse)));
    }

    /// <summary>
    /// A slider. Read it back with <see cref="DialogResponse.GetFloat"/> or
    /// <see cref="DialogResponse.GetInt"/>.
    /// </summary>
    /// <param name="step">How far the slider moves per notch; it slides continuously when unset.</param>
    public DialogBuilder NumberInput(string key, TextComponent label, float start, float end,
        float? initial = null, float? step = null, int width = 200,
        string labelFormat = "options.generic_value") {

        return Input(new DialogInput(key,
            new InputControl.NumberRange(label, new RangeInfo(start, end, initial, step), width, labelFormat)));
    }

    /// <summary>
    /// A dropdown. The response holds the <see cref="SingleOptionEntry.Id"/> of the chosen option.
    /// </summary>
    public DialogBuilder OptionInput(string key, TextComponent label, params SingleOptionEntry[] options) {
        return Input(new DialogInput(key, new InputControl.SingleOption(label, options)));
    }

    public DialogBuilder Input(DialogInput input) {
        // The client rejects the whole dialog over a bad key, so it's worth catching here
        if (input.Key.Length == 0 || !input.Key.All(c => char.IsLetterOrDigit(c) || c == '_')) {
            throw new ArgumentException(
                $"Input key '{input.Key}' must be made of letters, digits and underscores.", nameof(input));
        }

        if (_inputs.Any(i => i.Key == input.Key)) {
            throw new ArgumentException($"There is already an input called '{input.Key}'.", nameof(input));
        }

        _inputs.Add(input);
        return this;
    }

    /// <summary>
    /// Adds a button. <paramref name="onClick"/> is handed the dialog's inputs when it's pressed; a
    /// null one makes a button that only dismisses the dialog.
    /// </summary>
    public DialogBuilder Button(TextComponent label, Action<DialogResponse>? onClick,
        TextComponent? tooltip = null, int width = 150) {

        _buttons.Add((new DialogActionButton(label, tooltip, width), onClick));
        return this;
    }

    /// <summary>Adds a button that does something the client handles itself, like opening a URL.</summary>
    public DialogBuilder Button(DialogActionButton button) {
        _buttons.Add((button, null));
        return this;
    }

    /// <summary>
    /// Sets the button below the grid, which is usually a way back. Only shown when the dialog has
    /// more than one button.
    /// </summary>
    public DialogBuilder ExitButton(TextComponent label, Action<DialogResponse>? onClick = null,
        TextComponent? tooltip = null, int width = 150) {

        _exitButton = (new DialogActionButton(label, tooltip, width), onClick);
        return this;
    }

    /// <summary>How many buttons wide the grid is. Two by default.</summary>
    public DialogBuilder Columns(int columns) {
        _columns = columns;
        return this;
    }

    public ManagedDialog Build() {
        string prefix = ManagedDialog.NewActionPrefix();
        List<Action<DialogResponse>?> handlers = [];

        DialogActionButton WithAction((DialogActionButton Button, Action<DialogResponse>? Handler) entry) {
            handlers.Add(entry.Handler);

            // A button with nothing to run keeps whatever action it was given, which is none at all
            // for the ones built here, so it just dismisses the dialog
            return entry.Handler == null
                ? entry.Button
                : entry.Button with {
                    Action = new DialogAction.Custom(ManagedDialog.ButtonAction(prefix, handlers.Count - 1), null)
                };
        }

        CommonDialogData common = new(title, _externalTitle, _canCloseWithEscape, Pausing(), _afterAction,
            _body.ToArray(), _inputs.ToArray());

        DialogActionButton[] buttons = _buttons.Select(WithAction).ToArray();
        DialogActionButton? exitButton = _exitButton == null ? null : WithAction(_exitButton.Value);

        IDialog dialog = buttons.Length switch {
            0 => new NoticeDialog(ClientBoundShowDialogPacket.InlineIdentifier, common, NoticeDialog.DefaultAction),
            1 => new NoticeDialog(ClientBoundShowDialogPacket.InlineIdentifier, common, buttons[0]),
            _ => new MultiActionDialog(ClientBoundShowDialogPacket.InlineIdentifier, common, buttons,
                exitButton, _columns)
        };

        return new ManagedDialog(dialog, prefix, handlers.ToArray());
    }

    /// <summary>
    /// Whether the dialog pauses a singleplayer world. The client refuses to decode one that
    /// pauses the game without unpausing it on a button press, and drops the connection over it,
    /// so <see cref="DialogAfterAction.None"/> takes pausing with it unless it was asked for.
    /// </summary>
    private bool Pausing() {
        if (!_pause || _afterAction != DialogAfterAction.None) {
            return _pause;
        }

        if (_pauseSet) {
            throw new InvalidOperationException(
                "A dialog with AfterAction.None can't pause the game, the client rejects it. " +
                "Either call Pause(false) or use a different after action.");
        }

        return false;
    }

    public static implicit operator ManagedDialog(DialogBuilder builder) => builder.Build();
}
