using ClientLib;
using Minecraft.Schemas;
using Minecraft.Text;

namespace GraphicalClient.Gui;

/// <summary>The player list held open by Tab: header, up to 80 names in columns of 20 with their latency, footer.</summary>
public static class TabList {
    public static void Draw(GuiContext context, MinecraftClient client, int w) {
        List<PlayerListEntry> entries = client.PlayerList.Values
            .Where(e => e.Listed)
            .OrderBy(e => -e.ListOrder)
            .ThenBy(e => e.GameMode == GameMode.Spectator)
            .ThenBy(e => e.Name, StringComparer.OrdinalIgnoreCase)
            .Take(80)
            .ToList();
        int columns = Math.Max(1, (entries.Count + 19) / 20);
        int rows = (entries.Count + columns - 1) / Math.Max(1, columns);
        List<List<TextRun>> names = entries.Select(e => TextFlattener.Flatten(NameForDisplay(client, e))).ToList();
        int columnWidth = entries.Count == 0 ? 80 : names.Max(n => context.Text.Width(n)) + 22;
        int total = columns * columnWidth;
        float x0 = w / 2.0F - total / 2.0F;
        float y = 10;

        if (client.TabHeader != null) {
            y = DrawCentredBlock(context, client.TabHeader, w, y) + 1;
        }
        context.Gui.Rect(x0 - 1, y - 1, total + 1, rows * 9 + 1, 0x80000000);
        for (int i = 0; i < entries.Count; i++) {
            PlayerListEntry entry = entries[i];
            float ex = x0 + i / rows * columnWidth, ey = y + i % rows * 9;
            context.Gui.Rect(ex, ey, columnWidth - 1, 8, 0x20FFFFFF);
            context.Text.Draw(names[i], ex + 1, ey, entry.GameMode == GameMode.Spectator ? (byte)0x90 : (byte)0xFF);
            int bars = entry.Latency switch {
                < 0 => 0,
                < 150 => 5,
                < 300 => 4,
                < 600 => 3,
                < 1000 => 2,
                _ => 1
            };
            for (int b = 0; b < 5; b++) {
                context.Gui.Rect(ex + columnWidth - 12 + b * 2, ey + 6 - b, 1, b + 1, b < bars ? 0xFF40E040 : 0xFF404040);
            }
        }
        if (client.TabFooter != null) {
            DrawCentredBlock(context, client.TabFooter, w, y + rows * 9 + 1);
        }
    }

    /// <summary>Wrapped centred lines each on their own backing, returning the y below them.</summary>
    private static float DrawCentredBlock(GuiContext context, TextComponent text, int w, float y) {
        foreach (List<TextRun> line in context.Text.Wrap(TextFlattener.Flatten(text), w - 50)) {
            float lw = context.Text.Width(line);
            context.Gui.Rect(w / 2.0F - lw / 2 - 1, y - 1, lw + 2, 9, 0x80000000);
            context.Text.Draw(line, w / 2.0F - lw / 2, y);
            y += 9;
        }
        return y;
    }

    /// <summary><c>PlayerTabOverlay.getNameForDisplay</c>: the list name, else the name in its team's style; italic for a spectator.</summary>
    private static TextComponent NameForDisplay(MinecraftClient client, PlayerListEntry entry) {
        TextComponent name = entry.DisplayName ?? Team.FormatNameForTeam(client.Scoreboard.TeamOf(entry.Name), TextComponent.Text(entry.Name));
        return entry.GameMode == GameMode.Spectator ? TextComponent.Empty().With(name).WithItalic() : name;
    }
}
