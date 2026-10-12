using ClientLib;

namespace GraphicalClient.Gui;

/// <summary><c>ChatComponent</c>: recent lines fading out after ten seconds, or the scrollable history while chat is open.</summary>
public static class ChatOverlay {
    private const int Width = 320;

    public static void Draw(GuiContext context, MinecraftClient client, int h, bool open, int scroll) {
        int maxLines = open ? 20 : 10;
        int lineWidth = Math.Min(Width, context.Width - 8);

        List<(List<TextRun> Line, float Opacity)> lines = [];
        for (int i = client.Chat.Count - 1; i >= 0 && lines.Count < maxLines + scroll; i--) {
            ChatLine line = client.Chat[i];
            int age = (int)(client.ClientTicks - line.AddedTick);
            float opacity = open ? 1.0F : Math.Clamp((200 - age) / 10.0F, 0.0F, 1.0F);
            if (opacity <= 0.0F) {
                break;
            }
            List<List<TextRun>> wrapped = context.Text.Wrap(TextFlattener.Flatten(line.Message), lineWidth);
            for (int j = wrapped.Count - 1; j >= 0; j--) {
                lines.Add((wrapped[j], opacity * opacity));
            }
        }

        int shown = 0;
        for (int i = open ? scroll : 0; i < lines.Count && shown < maxLines; i++, shown++) {
            (List<TextRun> line, float opacity) = lines[i];
            // Each line's box ends where the one below starts, the lowest at h - 40.
            float top = h - 40 - (shown + 1) * TextRenderer.LineHeight;
            context.Gui.Rect(0, top, lineWidth + 4, TextRenderer.LineHeight, (uint)(opacity * 0.5F * 255) << 24);
            context.Text.Draw(line, 2, top + 1, (byte)(opacity * 255));
        }
    }
}
