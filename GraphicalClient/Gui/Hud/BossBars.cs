using ClientLib;
using Division = Minecraft.Packets.Play.ClientBound.ClientBoundBossBarPacket.Division;

namespace GraphicalClient.Gui;

/// <summary><c>BossHealthOverlay</c>.</summary>
public static class BossBars {
    private static readonly string[] Colours = ["pink", "blue", "red", "green", "yellow", "purple", "white"];
    private static readonly string[] Notches = ["notched_6", "notched_10", "notched_12", "notched_20"];
    private static readonly string[] BarBackground = Sprites(Colours, "background"), BarProgress = Sprites(Colours, "progress");
    private static readonly string[] OverlayBackground = Sprites(Notches, "background"), OverlayProgress = Sprites(Notches, "progress");

    private static string[] Sprites(string[] names, string part) => names.Select(name => $"boss_bar/{name}_{part}").ToArray();

    /// <summary><c>BossHealthOverlay.extractRenderState</c>.</summary>
    public static void Draw(GuiContext context, MinecraftClient client, int w) {
        if (client.BossOverlay.Count == 0) {
            return;
        }
        int yOffset = 12;
        foreach (LerpingBossEvent bossEvent in client.BossOverlay.Events) {
            int xLeft = w / 2 - 91;
            DrawBar(context, xLeft, yOffset, bossEvent);
            List<TextRun> msg = TextFlattener.Flatten(bossEvent.Name);
            int width = context.Text.Width(msg);
            int x = w / 2 - width / 2;
            int y = yOffset - 9;
            context.Text.Draw(msg, x, y);
            yOffset += 10 + 9;
            if (yOffset >= context.Height / 3) {
                break;
            }
        }
    }

    private static void DrawBar(GuiContext context, int x, int y, LerpingBossEvent bossEvent) {
        DrawBar(context, x, y, bossEvent, 182, BarBackground, OverlayBackground);
        int width = LerpDiscrete(bossEvent.Progress, 0, 182);
        if (width > 0) {
            DrawBar(context, x, y, bossEvent, width, BarProgress, OverlayProgress);
        }
    }

    /// <summary>
    /// The left <paramref name="width"/> columns of a 182 by 5 sprite, uncropped and unstretched, which is
    /// what vanilla's <c>blitSprite</c> with a sprite size and texture offset draws for a stretched sprite.
    /// </summary>
    private static void DrawBar(GuiContext context, int x, int y, LerpingBossEvent bossEvent, int width, string[] sprites, string[] overlaySprites) {
        float fraction = width / 182.0F;
        context.Sprites.Sprite(context.Gui, sprites[(int)bossEvent.Color], x, y, 182, 5, fraction: fraction);
        if (bossEvent.Overlay != Division.Zero) {
            context.Sprites.Sprite(context.Gui, overlaySprites[(int)bossEvent.Overlay - 1], x, y, 182, 5, fraction: fraction);
        }
    }

    /// <summary><c>Mth.lerpDiscrete</c>: any progress above zero shows at least one column.</summary>
    private static int LerpDiscrete(float alpha1, int p0, int p1) {
        int delta = p1 - p0;
        return p0 + (int)MathF.Floor(alpha1 * (delta - 1)) + (alpha1 > 0.0F ? 1 : 0);
    }
}
