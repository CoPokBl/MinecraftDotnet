namespace GraphicalClient.Gui;

/// <summary>Shown once the connection is gone. There is no menu to go back to, so it only says why.</summary>
public sealed class DisconnectedScreen(string reason) : Screen {
    public override bool ShowsHud => false;
    public override bool CloseOnEscape => false;

    public override void Render(GuiContext context, float partialTick) {
        int w = context.Width, h = context.Height;
        context.Gui.Rect(0, 0, w, h, 0xFF2A2420);
        context.Text.DrawCentred("Disconnected", w / 2.0F, h / 2.0F - 30, 0xFFAAAAAA);
        float y = h / 2.0F - 10;
        List<ClientLib.TextRun> message = context.Client.DisconnectReasonText is { } text
            ? ClientLib.TextFlattener.Flatten(text)
            : ClientLib.TextFlattener.Formatted(reason);
        foreach (List<ClientLib.TextRun> line in context.Text.Wrap(message, w - 40)) {
            context.Text.DrawCentred(line, w / 2.0F, y);
            y += 10;
        }
        context.Text.DrawCentred("Close the window to quit", w / 2.0F, y + 20, 0xFF808080);
    }
}
