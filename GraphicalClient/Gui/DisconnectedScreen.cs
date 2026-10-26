using ClientLib;
using Minecraft.Text;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>DisconnectedScreen</c>: why the connection ended, and a button back to <paramref name="parent"/>. A session
/// with nowhere to go back to, a <c>--server</c> join without <c>--return-to-menu</c>, says to close the window instead.
/// </summary>
public sealed class DisconnectedScreen(TextComponent title, TextComponent reason, Screen? parent, string buttonKey = "gui.toMenu") : Screen {
    public override bool ShowsHud => false;
    public override bool CloseOnEscape => false;

    /// <summary>The layout's cells: the title and the reason padded 10, the button 2, centred as a column.</summary>
    private (List<List<TextRun>> Reason, float Top) Layout(GuiContext context) {
        List<List<TextRun>> lines = context.Text.Wrap(Menus.Runs(reason), context.Width - 50);
        float total = 9 + 20 + lines.Count * 9 + 20 + 20 + 4;
        return (lines, (context.Height - total) / 2);
    }

    protected override void Init(GuiContext context, int width, int height) {
        if (parent == null) {
            return;
        }
        (List<List<TextRun>> lines, float top) = Layout(context);
        Add(new Button(Menus.T(buttonKey), width / 2.0F - 100, top + 29 + lines.Count * 9 + 20 + 2, 200, () => context.Open?.Invoke(parent)));
    }

    public override void Render(GuiContext context, float partialTick) {
        Menus.Background(context);
        (List<List<TextRun>> lines, float top) = Layout(context);
        float x = context.Width / 2.0F;
        context.Text.DrawCentred(Menus.Runs(title), x, top + 10);
        float y = top + 29 + 10;
        foreach (List<TextRun> line in lines) {
            context.Text.DrawCentred(line, x, y);
            y += 9;
        }
        if (parent == null) {
            context.Text.DrawCentred(Menus.T("disconnect.closeWindow"), x, y + 12, 0xFF808080);
        }
        RenderWidgets(context);
    }
}
