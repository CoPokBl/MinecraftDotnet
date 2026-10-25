using ClientLib;
using Minecraft.Data.Generated;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>
/// Vanilla's <c>DeathScreen</c>: the cause, the score, and a way back. Its buttons stay inactive for the
/// first 20 ticks, so a respawn never goes out sooner than vanilla's could; in hardcore the respawn is a
/// switch to watching, and leaving asks nothing.
/// </summary>
public sealed class DeathScreen(Action quit) : Screen {
    private const int ButtonDelay = 20;

    private readonly List<Button> _exitButtons = [];
    private int _delayTicker;

    public override bool CloseOnEscape => false;

    private static string T(string key) => Translations.Get(key) ?? key;

    protected override void Init(GuiContext context, int width, int height) {
        _delayTicker = 0;
        _exitButtons.Clear();
        bool hardcore = context.Client.Hardcore;
        Button respawn = null!;
        respawn = new Button(T(hardcore ? "deathScreen.spectate" : "deathScreen.respawn"), width / 2.0F - 100, height / 4.0F + 72, 200, () => {
            context.Client.Respawn();
            respawn.Active = false;
        });
        Button exit = new(T("deathScreen.titleScreen"), width / 2.0F - 100, height / 4.0F + 96, 200, () => ExitToTitle(context));
        foreach (Button button in (Button[])[respawn, exit]) {
            Add(button);
            _exitButtons.Add(button);
        }
        SetButtonsActive(false);
    }

    private void ExitToTitle(GuiContext context) {
        if (context.Client.Hardcore) {
            quit();
            return;
        }
        context.Open?.Invoke(new ConfirmScreen(leave => {
                if (leave) {
                    quit();
                }
                else {
                    context.Client.Respawn();
                    Close(context);
                }
            },
            TextComponent.Translatable("deathScreen.quit.confirm"), TextComponent.Empty(), T("deathScreen.titleScreen"), T("deathScreen.respawn")));
    }

    private void SetButtonsActive(bool active) {
        foreach (Button button in _exitButtons) {
            button.Active = active;
        }
    }

    public override void Tick(GuiContext context) {
        _delayTicker++;
        if (_delayTicker == ButtonDelay) {
            SetButtonsActive(true);
        }
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
    }

    public override void Render(GuiContext context, float partialTick) {
        int w = context.Width, h = context.Height;
        // fillGradient(0, 0, width, height, 0x60500000, 0xA0803030).
        context.Gui.Rect(0, 0, w, h, 0x60500000);
        context.Gui.Rect(0, 0, w, h / 2.0F, 0x30A00000);
        context.Gui.Zoom = 2.0F;
        context.Text.DrawCentred(T(context.Client.Hardcore ? "deathScreen.title.hardcore" : "deathScreen.title"), w / 4.0F, 30, 0xFFFFFFFF);
        context.Gui.Zoom = 1.0F;
        if (context.Client.DeathMessage != null) {
            context.Text.DrawCentred(TextFlattener.Flatten(context.Client.DeathMessage), w / 2.0F, 85);
        }
        DrawScore(context, w / 2.0F, 100);
        RenderWidgets(context);
    }

    /// <summary><c>deathScreen.score.value</c> around <c>Player.getScore</c>, the number in yellow.</summary>
    private static void DrawScore(GuiContext context, float centreX, float y) {
        string score = (context.Client.Player?.Get(EntityDataFields.Player.Score, 0) ?? 0).ToString();
        string[] parts = T("deathScreen.score.value").Split("%s", 2);
        string before = parts[0], after = parts.Length > 1 ? parts[1] : "";
        float x = centreX - context.Text.Width(before + score + after) / 2.0F;
        context.Text.Draw(before, x, y, 0xFFFFFFFF);
        x += context.Text.Width(before);
        context.Text.Draw(score, x, y, 0xFFFFFF55);
        context.Text.Draw(after, x + context.Text.Width(score), y, 0xFFFFFFFF);
    }
}
