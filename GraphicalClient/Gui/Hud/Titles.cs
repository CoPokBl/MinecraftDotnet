using ClientLib;

namespace GraphicalClient.Gui;

/// <summary>The action bar over the hotbar and the title and subtitle in the middle of the screen.</summary>
public static class Titles {
    public static void DrawActionBar(GuiContext context, MinecraftClient client, int w, int h) {
        if (client.ActionBar == null || client.ActionBarTime <= 0) {
            return;
        }
        // Hud.extractOverlayMessage: centred on (w / 2, h - 68) and drawn from 4 above it.
        float t = client.ActionBarTime - context.PartialTick;
        int alpha = Math.Min((int)(t * 255.0F / 20.0F), 255);
        if (alpha > 0) {
            List<TextRun> message = TextFlattener.Flatten(client.ActionBar);
            context.Text.Draw(message, w / 2 - context.Text.Width(message) / 2, h - 68 - 4, (byte)alpha);
        }
    }

    public static void DrawTitle(GuiContext context, MinecraftClient client, int w, int h) {
        if (client.Title == null || client.TitleTime <= 0) {
            return;
        }
        (int fadeIn, int stay, int fadeOut) = client.TitleTimes;
        int age = fadeIn + stay + fadeOut - client.TitleTime;
        float opacity = age < fadeIn ? age / (float)Math.Max(1, fadeIn)
            : client.TitleTime < fadeOut ? client.TitleTime / (float)Math.Max(1, fadeOut) : 1.0F;
        byte alpha = (byte)Math.Clamp(opacity * 255, 8, 255);

        context.Gui.Zoom = 4.0F;
        context.Text.DrawCentred(TextFlattener.Flatten(client.Title), w / 2.0F / 4.0F, (h / 2.0F - 30) / 4.0F, alpha);
        context.Gui.Zoom = 2.0F;
        if (client.Subtitle != null) {
            context.Text.DrawCentred(TextFlattener.Flatten(client.Subtitle), w / 2.0F / 2.0F, (h / 2.0F + 6) / 2.0F, alpha);
        }
        context.Gui.Zoom = 1.0F;
    }
}
