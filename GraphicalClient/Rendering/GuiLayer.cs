using ClientLib;
using ClientLib.Interaction;
using GraphicalClient.Gui;

namespace GraphicalClient.Rendering;

/// <summary>Everything drawn over the world, in order: screen effects, crosshair, HUD, debug overlay and the open screen.</summary>
public sealed class GuiLayer(GameRenderer renderer, MinecraftClient client, Hud hud, DebugOverlay debug, string rendererName) {
    /// <summary>The connection the HUD is drawn from, replaced on every join.</summary>
    public MinecraftClient Client { get; set; } = client;

    /// <summary>The toasts, drawn over everything else.</summary>
    public Action<GuiContext>? Toasts { get; set; }

    /// <summary>A resource reload's overlay, drawn in place of the screen, which it draws itself while it is fading.</summary>
    public Func<LoadingOverlay?> Overlay { get; set; } = () => null;

    private GuiRenderer Gui => renderer.Gui;
    private Camera Camera => renderer.Camera;

    public void Render(GuiContext context, FramePlan plan, Screen? screen, bool tabHeld, (float X, float Y) mouse, int fps, double frameMs) {
        float partialTick = plan.PartialTick;
        WorldRenderer world = renderer.World;
        Gui.Begin(plan.Size.X, plan.Size.Y);
        if (plan.InWorld && Client.Level is { } level && Client.Player is { } effectsPlayer) {
            renderer.Scene.ScreenEffects.Render(Gui, effectsPlayer, level, Camera, renderer.View.FirstPerson, effectsPlayer.IsSleeping,
                renderer.Lighting.SkyDarkening);
        }
        if (plan.InWorld && !renderer.HideGui && (screen == null || screen.ShowsHud)) {
            if (Client.Player is { } overlaid && Client.Level is { } overlaidLevel) {
                renderer.Scene.CameraOverlays.Render(Gui, overlaid, overlaidLevel, Client.CameraEntity, renderer.View.FirstPerson,
                    context.Settings?.Vignette ?? true, (float)(context.Settings?.ScreenEffectScale ?? 1.0), plan.DeltaTicks, partialTick);
            }
            if (screen == null && !debug.Visible) {
                Gui.Flush();
                DrawCrosshair();
                DrawAttackIndicator();
                Gui.FlushInverted();
            }
            context.PartialTick = partialTick;
            hud.ShowTabList = screen == null && tabHeld;
            hud.ScreenShowsEffects = screen != null && screen.ShowsActiveEffects(context);
            hud.Render(context, partialTick);
            debug.Render(context, new DebugStats(fps, frameMs, world.VisibleSections, world.LoadedSections, world.PendingSections, rendererName,
                Client.Interactions.Target is BlockHitResult hit ? (hit.X, hit.Y, hit.Z) : null));
        }
        else if (plan.InWorld && Client.Player is { } sleeper) {
            // Hud.extractSleepOverlay is drawn with the rest of the HUD hidden too.
            Hud.DrawSleepOverlay(context, sleeper);
        }
        else if (!plan.InWorld && screen == null) {
            Gui.Rect(0, 0, Gui.ScaledWidth, Gui.ScaledHeight, 0xFF2A2420);
            string status = Client.Phase switch {
                ClientPhase.Connecting => "connect.connecting",
                ClientPhase.Login => "connect.authorizing",
                ClientPhase.Configuration => "connect.joining",
                _ => "multiplayer.downloadingTerrain"
            };
            renderer.Text.DrawCentred(Menus.T(status), Gui.ScaledWidth / 2.0F, Gui.ScaledHeight / 2.0F - 4);
        }
        context.PartialTick = partialTick;
        (context.MouseX, context.MouseY) = mouse;
        if (Overlay() is { } overlay) {
            overlay.Render(context, screen, partialTick);
        }
        else {
            screen?.Render(context, partialTick);
        }
        Toasts?.Invoke(context);
        Gui.End();
    }

    private void DrawCrosshair() {
        float cx = Gui.ScaledWidth / 2.0F, cy = Gui.ScaledHeight / 2.0F;
        // Vanilla puts the 15 pixel crosshair's corner at (width - 15) / 2, which centres it.
        if (!renderer.Sprites.Sprite(Gui, "hud/crosshair", (int)((Gui.ScaledWidth - 15) / 2), (int)((Gui.ScaledHeight - 15) / 2), 15, 15)) {
            Gui.Rect(cx - 4.5F, cy - 0.5F, 9, 1, 0xFFFFFFFF);
            Gui.Rect(cx - 0.5F, cy - 4.5F, 1, 4, 0xFFFFFFFF);
            Gui.Rect(cx - 0.5F, cy + 0.5F, 1, 4, 0xFFFFFFFF);
        }
    }

    /// <summary>
    /// <c>Hud.extractCrosshair</c>'s attack indicator: the cooldown filling under the crosshair, or the
    /// full sword when a living target is in reach of a charged swing. An item's <c>attack_range</c>
    /// component is not checked, so such a weapon shows full at any range the pick reaches.
    /// </summary>
    private void DrawAttackIndicator() {
        if (Client.Player is not { } player || !renderer.View.FirstPerson) {
            return;
        }
        float attackStrengthScale = player.AttackStrengthScale(0.0F);
        bool renderMax = false;
        if (Client.Interactions.Target is EntityHitResult { Entity: { IsLiving: true } target } && attackStrengthScale >= 1.0F) {
            renderMax = player.CurrentItemAttackStrengthDelay > 5.0F && target.CurrentHealth > 0;
        }
        int y = (int)Gui.ScaledHeight / 2 - 7 + 16;
        int x = (int)Gui.ScaledWidth / 2 - 8;
        GuiSprites sprites = renderer.Sprites;
        if (renderMax) {
            sprites.Sprite(Gui, "hud/crosshair_attack_indicator_full", x, y, 16, 16);
        }
        else if (attackStrengthScale < 1.0F) {
            int progress = (int)(attackStrengthScale * 17.0F);
            sprites.Sprite(Gui, "hud/crosshair_attack_indicator_background", x, y, 16, 4);
            sprites.Sprite(Gui, "hud/crosshair_attack_indicator_progress", x, y, 16, 4, fraction: progress / 16.0F);
        }
    }
}
