using ClientLib;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>Vanilla's <c>DeathScreen</c>: the cause, the score, and a way back.</summary>
public sealed class DeathScreen : Screen {
    public override bool CloseOnEscape => false;

    protected override void Init(GuiContext context, int width, int height) =>
        Add(new Button("Respawn (R)", width / 2.0F - 100, height / 4.0F + 72, 200, () => Respawn(context)));

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (key is Key.R or Key.Enter or Key.Space) {
            Respawn(context);
        }
    }

    private void Respawn(GuiContext context) {
        context.Client.Respawn();
        Close(context);
    }

    public override void Render(GuiContext context, float partialTick) {
        int w = context.Width, h = context.Height;
        context.Gui.Rect(0, 0, w, h, 0x60500000);
        context.Gui.Rect(0, 0, w, h / 2.0F, 0x30A00000);
        context.Gui.Zoom = 2.0F;
        context.Text.DrawCentred(context.Client.Hardcore ? "Game over!" : "You died!", w / 4.0F, 30, 0xFFFFFFFF);
        context.Gui.Zoom = 1.0F;
        if (context.Client.DeathMessage != null) {
            context.Text.DrawCentred(TextFlattener.Flatten(context.Client.DeathMessage), w / 2.0F, 85);
        }
        context.Text.DrawCentred($"Score: {context.Client.Player?.TotalExperience ?? 0}", w / 2.0F, 100, 0xFFFFFF55);
        RenderWidgets(context);
    }
}
