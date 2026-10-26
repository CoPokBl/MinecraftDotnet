namespace GraphicalClient.Gui.Inventory;

/// <summary>
/// The container screens' art, drawn from rectangles: a bevelled grey panel and inset slots, in
/// this client's own colours.
/// </summary>
public static class Panel {
    public const uint Fill = 0xFFC6C6C6;
    public const uint Light = 0xFFFFFFFF;
    public const uint Shadow = 0xFF555555;
    public const uint Edge = 0xFF000000;
    public const uint Label = 0xFF404040;

    public static void Draw(GuiContext context, float x, float y, float w, float h) {
        context.Gui.Rect(x + 1, y, w - 2, h, Edge);
        context.Gui.Rect(x, y + 1, w, h - 2, Edge);
        context.Gui.Rect(x + 1, y + 1, w - 2, h - 2, Fill);
        context.Gui.Rect(x + 1, y + 1, w - 3, 2, Light);
        context.Gui.Rect(x + 1, y + 1, 2, h - 3, Light);
        context.Gui.Rect(x + 2, y + h - 3, w - 3, 2, Shadow);
        context.Gui.Rect(x + w - 3, y + 2, 2, h - 3, Shadow);
    }

    /// <summary>An 18 pixel slot frame around an item drawn at (x, y).</summary>
    public static void Slot(GuiContext context, float x, float y) {
        context.Gui.Rect(x - 1, y - 1, 18, 18, 0xFF8B8B8B);
        context.Gui.Rect(x - 1, y - 1, 17, 1, 0xFF373737);
        context.Gui.Rect(x - 1, y - 1, 1, 17, 0xFF373737);
        context.Gui.Rect(x, y + 16, 17, 1, Light);
        context.Gui.Rect(x + 16, y, 1, 17, Light);
    }

    /// <summary>A left to right progress arrow, filled to <paramref name="progress"/>.</summary>
    public static void Arrow(GuiContext context, float x, float y, float progress) {
        context.Gui.Rect(x, y + 6, 16, 4, 0xFF8B8B8B);
        context.Gui.Rect(x + 16, y + 2, 6, 12, 0xFF8B8B8B);
        float filled = 22 * Math.Clamp(progress, 0, 1);
        context.Gui.Rect(x, y + 6, Math.Min(filled, 16), 4, 0xFFFFFFFF);
        if (filled > 16) {
            context.Gui.Rect(x + 16, y + 2, filled - 16, 12, 0xFFFFFFFF);
        }
    }

    /// <summary>A flame that burns down from the top as <paramref name="remaining"/> falls.</summary>
    public static void Flame(GuiContext context, float x, float y, float remaining) {
        context.Gui.Rect(x, y, 14, 14, 0xFF8B8B8B);
        float height = 14 * Math.Clamp(remaining, 0, 1);
        context.Gui.Rect(x + 2, y + 14 - height, 10, height, 0xFFFF8020);
    }
}
