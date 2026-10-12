using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Interaction;
using GraphicalClient.Gui;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering;

/// <summary>Everything drawn over the world, in order: screen effects, crosshair, name tags, HUD, debug overlay and the open screen.</summary>
public sealed class GuiLayer(GameRenderer renderer, MinecraftClient client, Hud hud, DebugOverlay debug, string rendererName) {
    private GuiRenderer Gui => renderer.Gui;
    private Camera Camera => renderer.Camera;

    public void Render(GuiContext context, FramePlan plan, Screen? screen, bool tabHeld, (float X, float Y) mouse, int fps, double frameMs) {
        float partialTick = plan.PartialTick;
        WorldRenderer world = renderer.World;
        Gui.Begin(plan.Size.X, plan.Size.Y);
        if (plan.InWorld && client.Level is { } level && client.Player is { } effectsPlayer) {
            renderer.Scene.ScreenEffects.Render(Gui, effectsPlayer, level, Camera, renderer.View.FirstPerson, effectsPlayer.IsSleeping,
                renderer.Lighting.SkyDarkening);
        }
        if (plan.InWorld && !renderer.HideGui && (screen == null || screen.ShowsHud)) {
            if (client.Player is { } overlaid && client.Level is { } overlaidLevel) {
                renderer.Scene.CameraOverlays.Render(Gui, overlaid, overlaidLevel, client.CameraEntity, renderer.View.FirstPerson,
                    context.Settings?.Vignette ?? true, (float)(context.Settings?.ScreenEffectScale ?? 1.0), plan.DeltaTicks, partialTick);
            }
            if (screen == null && !debug.Visible) {
                DrawCrosshair();
                DrawAttackIndicator();
                Gui.FlushInverted();
            }
            DrawNameTags(partialTick);
            context.PartialTick = partialTick;
            hud.ShowTabList = screen == null && tabHeld;
            hud.ScreenShowsEffects = screen != null && screen.ShowsActiveEffects(context);
            hud.Render(context, partialTick);
            debug.Render(context, new DebugStats(fps, frameMs, world.VisibleSections, world.LoadedSections, world.PendingSections, rendererName,
                client.Interactions.Target is BlockHitResult hit ? (hit.X, hit.Y, hit.Z) : null));
        }
        else if (plan.InWorld && client.Player is { } sleeper) {
            // Hud.extractSleepOverlay is drawn with the rest of the HUD hidden too.
            Hud.DrawSleepOverlay(context, sleeper);
        }
        else if (!plan.InWorld && screen == null) {
            Gui.Rect(0, 0, Gui.ScaledWidth, Gui.ScaledHeight, 0xFF2A2420);
            string status = client.Phase switch {
                ClientPhase.Connecting => Translations.Get("connect.connecting"),
                ClientPhase.Login => Translations.Get("connect.authorizing"),
                ClientPhase.Configuration => Translations.Get("connect.joining"),
                _ => Translations.Get("multiplayer.downloadingTerrain")
            };
            renderer.Text.DrawCentred(status, Gui.ScaledWidth / 2.0F, Gui.ScaledHeight / 2.0F - 4);
        }
        context.PartialTick = partialTick;
        (context.MouseX, context.MouseY) = mouse;
        screen?.Render(context, partialTick);
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
        if (client.Player is not { } player || !renderer.View.FirstPerson) {
            return;
        }
        float attackStrengthScale = player.AttackStrengthScale(0.0F);
        bool renderMax = false;
        if (client.Interactions.Target is EntityHitResult { Entity: { IsLiving: true } target } && attackStrengthScale >= 1.0F) {
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

    /// <summary>Names over players and named mobs, drawn on the HUD at the projected head position.</summary>
    private void DrawNameTags(float partialTick) {
        Matrix4x4 viewProjection = Camera.View * Camera.RenderProjection;
        foreach (ClientEntity entity in client.Entities.Values) {
            // LivingEntityRenderer.shouldShowName: never the camera entity or a vehicle; the local player is the
            // camera or, while it spectates another, not drawn at all.
            if (entity == client.CameraEntity || entity == client.Player || entity.IsVehicle) {
                continue;
            }
            // Entity.getDisplayName: a player by its profile name, anything else by its custom name, in its team's style.
            string? holder;
            Minecraft.Text.TextComponent? baseName;
            if (entity.Type == EntityType.Player) {
                holder = client.PlayerList.TryGetValue(entity.Uuid, out PlayerListEntry? info) ? info.Name : null;
                baseName = holder != null ? Minecraft.Text.TextComponent.Text(holder) : null;
            }
            else if (entity.Is(EntityClass.ItemFrame)) {
                // ItemFrameRenderer.shouldShowName: the framed item's name, while the frame is looked at and the item is named.
                holder = entity.Uuid.ToString();
                baseName = client.Interactions.Target is EntityHitResult { Entity: var target } && target == entity
                           && entity.Get(EntityDataFields.ItemFrame.Item) is { } item && ItemNames.CustomName(item) != null
                    ? ItemNames.HoverName(item)
                    : null;
            }
            else {
                holder = entity.Uuid.ToString();
                baseName = entity.Get(EntityDataFields.Entity.CustomName) is { Present: true } custom ? custom.Value : null;
            }
            if (baseName == null || entity.IsInvisible) {
                continue;
            }
            List<TextRun> name = TextFlattener.Flatten(Team.FormatNameForTeam(client.Scoreboard.TeamOf(holder!), baseName));
            double x = ClientEntity.Lerp(partialTick, entity.OldPosition.X, entity.Position.X) - Camera.Position.X;
            // LivingEntity.SLEEPING_DIMENSIONS: a sleeper's name tag sits on the bed.
            double height = entity.IsLiving && entity.Get(EntityDataFields.Entity.Pose) == EntityPose.Sleeping ? 0.2F : entity.Height;
            double y = ClientEntity.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y) + height + 0.5 - Camera.Position.Y;
            double z = ClientEntity.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z) - Camera.Position.Z;
            if (x * x + y * y + z * z > 64 * 64) {
                continue;
            }
            Vector4 clip = Vector4.Transform(new Vector4((float)x, (float)y, (float)z, 1), viewProjection);
            if (clip.W <= 0.05F) {
                continue;
            }
            float sx = (clip.X / clip.W * 0.5F + 0.5F) * Gui.ScaledWidth;
            float sy = (0.5F - clip.Y / clip.W * 0.5F) * Gui.ScaledHeight;
            int width = renderer.Text.Width(name);
            Gui.Rect(sx - width / 2.0F - 1, sy - 1, width + 2, 9, 0x40000000);
            renderer.Text.DrawCentred(name, sx, sy, entity.IsCrouching ? (byte)0x80 : (byte)0xFF, false);
        }
    }
}
