using ClientLib;
using ClientLib.Player;
using Minecraft.Schemas;

namespace GraphicalClient.Gui;

/// <summary>
/// The in-game overlay, laid out the way vanilla's <c>Gui</c> lays it out: hotbar at the bottom,
/// hearts and food above it either side, experience between, chat bottom left.
/// </summary>
public sealed class Hud {
    private readonly HeldItemName _heldItemName = new();

    public bool ChatOpen { get; set; }
    public int ChatScroll { get; set; }
    public bool ShowTabList { get; set; }

    /// <summary>Whether the open screen lists the effects itself, which hides the corner icons.</summary>
    public bool ScreenShowsEffects { get; set; }

    public void Render(GuiContext context, float partialTick) {
        MinecraftClient client = context.Client;
        if (client.Player is not { } player) {
            return;
        }
        int w = context.Width, h = context.Height;
        _heldItemName.Tick(client);

        bool spectator = player.GameMode == GameMode.Spectator;
        if (spectator) {
            SpectatorBar.Draw(context, client, w, h);
        }
        else {
            Hotbar.Draw(context, client, w, h);
        }
        if (player.GameMode is GameMode.Survival or GameMode.Adventure) {
            StatusBars.Draw(context, client, player, w, h);
        }
        if (!spectator) {
            StatusBars.DrawVehicleHealth(context, player, w, h);
            if (player.JumpableVehicle is { } jumpable) {
                StatusBars.DrawJumpBar(context, player, jumpable, w, h);
            }
        }
        EffectIcons.Draw(context, player, w, ScreenShowsEffects);
        BossBars.Draw(context, client, w);
        DrawSleepOverlay(context, player);
        ScoreboardSidebar.Draw(context, client, w, h);
        if (spectator) {
            SpectatorBar.DrawAction(context, client, w, h);
        }
        else {
            _heldItemName.Draw(context, client, w, h);
        }
        Titles.DrawActionBar(context, client, w, h);
        Titles.DrawTitle(context, client, w, h);
        ChatOverlay.Draw(context, client, h, ChatOpen, ChatScroll);
        if (ShowTabList) {
            TabList.Draw(context, client, w);
        }
    }

    /// <summary><c>Hud.extractSleepOverlay</c>: the screen darkens over the sleep timer and clears over the wake.</summary>
    public static void DrawSleepOverlay(GuiContext context, LocalPlayer player) {
        if (player.SleepTimer <= 0) {
            return;
        }
        float sleepTimer = player.SleepTimer;
        float amount = sleepTimer / 100.0F;
        if (amount > 1.0F) {
            amount = 1.0F - (sleepTimer - 100.0F) / 10.0F;
        }
        uint color = (uint)((int)(220.0F * amount) << 24 | 0x101020);
        context.Gui.Rect(0, 0, context.Width, context.Height, color);
    }
}
