namespace GraphicalClient.Gui;

/// <summary>
/// Vanilla's <c>InBedChatScreen</c>: chat that stays open while the player sleeps, with a button to get
/// up. Closing it only asks the server to wake the player; it goes away when the player has woken.
/// </summary>
public sealed class InBedChatScreen(Hud hud, string initial, bool isDraft) : ChatScreen(hud, initial, isDraft, closeOnSubmit: false) {
    protected override void Init(GuiContext context, int width, int height) {
        base.Init(context, width, height);
        string label = ClientLib.Translations.Get("multiplayer.stopSleeping")!;
        Add(new Button(label, width / 2.0F - 100, height - 40, 200, () => context.Client.Player?.SendWakeUp()));
    }

    /// <summary><c>onClose</c>: Escape asks to wake rather than closing.</summary>
    public override void Close(GuiContext context) => context.Client.Player?.SendWakeUp();

    /// <summary>
    /// <c>onPlayerWokeUp</c>: what replaces this screen once the player is awake, a plain chat screen
    /// keeping anything typed that is not an untouched draft, or nothing.
    /// </summary>
    public ChatScreen? OnPlayerWokeUp() {
        string text = InputValue;
        if (!IsDraft && text.Length > 0) {
            Exit = ExitReason.Done;
            return new ChatScreen(Hud, text, false);
        }
        Exit = ExitReason.Interrupted;
        return null;
    }
}
