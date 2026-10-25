using GraphicalClient.Rendering;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>AbstractSelectionList</c>: rows of their own heights in a scrolling box, one of them selected. The screen
/// owning it draws each row's content and decides what a click on one does; this keeps the geometry, the
/// background, the separators, the selection outline and the scrollbar.
/// </summary>
public sealed class SelectionList(int defaultEntryHeight) {
    private const int ScrollbarWidth = 6;

    private readonly List<int> _heights = [];
    private bool _scrolling;

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Bottom => Y + Height;
    public int Right => X + Width;
    public double ScrollAmount { get; private set; }
    public int Count => _heights.Count;

    /// <summary>The selected row, -1 for none.</summary>
    public int Selected { get; set; } = -1;

    /// <summary>Whether it draws <c>extractListBackground</c> and <c>extractListSeparators</c>, which a list on a screen's own background leaves out.</summary>
    public bool Decorated { get; init; } = true;

    /// <summary><c>getRowWidth</c>.</summary>
    public Func<int> RowWidth { get; init; } = () => 220;

    /// <summary><c>scrollBarX</c>; null for vanilla's default just right of the rows.</summary>
    public Func<int>? ScrollBarXOverride { get; init; }

    /// <summary><c>getWidth</c> of an entry, which <c>TransferableSelectionList</c> narrows by the scrollbar while there is one.</summary>
    public Func<int>? EntryWidthOverride { get; init; }

    public int RowLeft => X + Width / 2 - RowWidth() / 2;
    public int RowRight => RowLeft + RowWidth();
    public int EntryWidth => EntryWidthOverride?.Invoke() ?? RowWidth();
    private int ScrollBarX => ScrollBarXOverride?.Invoke() ?? RowRight + ScrollbarWidth + 2;
    private int ScrollRate => defaultEntryHeight / 2;

    public void SetBounds(int x, int y, int width, int height) {
        (X, Y, Width, Height) = (x, y, width, height);
        RefreshScrollAmount();
    }

    public void Clear() {
        _heights.Clear();
        Selected = -1;
    }

    public int Add(int? height = null) {
        _heights.Add(height ?? defaultEntryHeight);
        return _heights.Count - 1;
    }

    /// <summary>The row's top, scrolled: <c>getFirstEntryY</c> is two below the list's top.</summary>
    public int RowTop(int row) {
        int y = Y + 2 - (int)ScrollAmount;
        for (int i = 0; i < row; i++) {
            y += _heights[i];
        }
        return y;
    }

    public int RowHeight(int row) => _heights[row];

    private int ContentHeight => _heights.Sum() + 4;

    public int MaxScrollAmount => Math.Max(0, ContentHeight - Height);

    public bool Scrollable => MaxScrollAmount > 0;

    public void SetScrollAmount(double amount) => ScrollAmount = Math.Clamp(amount, 0.0, MaxScrollAmount);

    public void RefreshScrollAmount() => SetScrollAmount(ScrollAmount);

    /// <summary><c>scrollToEntry</c>.</summary>
    public void ScrollToEntry(int row) {
        int topDelta = RowTop(row) - Y - 2;
        if (topDelta < 0) {
            SetScrollAmount(ScrollAmount + topDelta);
        }
        int bottomDelta = Bottom - RowTop(row) - _heights[row] - 2;
        if (bottomDelta < 0) {
            SetScrollAmount(ScrollAmount - bottomDelta);
        }
    }

    /// <summary><c>centerScrollOn</c>.</summary>
    public void CenterScrollOn(int row) {
        int y = 0;
        for (int i = 0; i < _heights.Count; i++) {
            if (i == row) {
                y += _heights[i] / 2;
                break;
            }
            y += _heights[i];
        }
        SetScrollAmount(y - Height / 2.0);
    }

    public bool IsMouseOver(float x, float y) => x >= X && x < Right && y >= Y && y < Bottom;

    /// <summary><c>getEntryAtPosition</c> within the list: the row under the point, or -1.</summary>
    public int EntryAt(float x, float y) {
        if (!IsMouseOver(x, y)) {
            return -1;
        }
        int top = RowTop(0);
        for (int i = 0; i < _heights.Count; top += _heights[i], i++) {
            if (x >= RowLeft && x < RowLeft + EntryWidth && y >= top && y < top + _heights[i]) {
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// <c>extractWidgetRenderState</c>: background, the visible rows through <paramref name="drawEntry"/> (row,
    /// x, y, width, height, hovered), the separators and the scrollbar. The outline marks the selected row.
    /// </summary>
    public void Render(GuiContext context, float mouseX, float mouseY, Action<int, int, int, int, int, bool> drawEntry, bool selectionFocused = true) {
        GuiRenderer gui = context.Gui;
        bool inWorld = context.Client.Level != null;
        int hovered = EntryAt(mouseX, mouseY);
        // extractListBackground: the tile scrolls with the list.
        if (Decorated && !context.Sprites.Tiled(gui, inWorld ? "gui/inworld_menu_list_background" : "gui/menu_list_background", X, Y, Width, Height, 32)) {
            gui.Rect(X, Y, Width, Height, 0x60000000);
        }
        gui.EnableScissor(Math.Max(0, X), Math.Max(0, Y), Math.Min(context.Width, Right), Math.Min(context.Height, Bottom));
        int top = RowTop(0);
        for (int i = 0; i < _heights.Count; top += _heights[i], i++) {
            if (top + _heights[i] < Y || top > Bottom) {
                continue;
            }
            if (i == Selected) {
                gui.Rect(RowLeft, top, EntryWidth, _heights[i], selectionFocused ? 0xFFFFFFFF : 0xFF808080);
                gui.Rect(RowLeft + 1, top + 1, EntryWidth - 2, _heights[i] - 2, 0xFF000000);
            }
            drawEntry(i, RowLeft, top, EntryWidth, _heights[i], i == hovered);
        }
        gui.DisableScissor();
        if (Decorated) {
            RenderSeparators(context);
        }
        RenderScrollbar(context);
    }

    private void RenderSeparators(GuiContext context) {
        GuiRenderer gui = context.Gui;
        bool inWorld = context.Client.Level != null;
        string header = inWorld ? "gui/inworld_header_separator" : "gui/header_separator";
        string footer = inWorld ? "gui/inworld_footer_separator" : "gui/footer_separator";
        if (!context.Sprites.Blit(gui, header, X, Y - 2, Width, 2, 0, 0, Width, 2)) {
            gui.Rect(X, Y - 2, Width, 1, 0x40FFFFFF);
        }
        if (!context.Sprites.Blit(gui, footer, X, Bottom, Width, 2, 0, 0, Width, 2)) {
            gui.Rect(X, Bottom + 1, Width, 1, 0x40FFFFFF);
        }
    }

    /// <summary><c>AbstractScrollArea.extractScrollbar</c>, while there is anything to scroll.</summary>
    private void RenderScrollbar(GuiContext context) {
        if (!Scrollable) {
            return;
        }
        int scrollerHeight = ScrollerHeight;
        int scrollerY = Math.Max(Y, (int)ScrollAmount * (Height - scrollerHeight) / MaxScrollAmount + Y);
        if (!context.Sprites.Sliced(context.Gui, "widget/scroller_background", ScrollBarX, Y, ScrollbarWidth, Height, 1)) {
            context.Gui.Rect(ScrollBarX, Y, ScrollbarWidth, Height, 0xFF000000);
        }
        if (!context.Sprites.Sprite(context.Gui, "widget/scroller", ScrollBarX, scrollerY, ScrollbarWidth, scrollerHeight)) {
            context.Gui.Rect(ScrollBarX, scrollerY, ScrollbarWidth, scrollerHeight, 0xFF808080);
            context.Gui.Rect(ScrollBarX, scrollerY, ScrollbarWidth - 1, scrollerHeight - 1, 0xFFC0C0C0);
        }
    }

    private int ScrollerHeight => Math.Clamp((int)((float)(Height * Height) / ContentHeight), 32, Height - 8);

    /// <summary><c>updateScrolling</c>: whether a press lands on the scrollbar, which then follows drags.</summary>
    public bool StartScrolling(float x, float y) {
        _scrolling = Scrollable && x >= ScrollBarX && x <= ScrollBarX + ScrollbarWidth && y >= Y && y < Bottom;
        return _scrolling;
    }

    public void StopScrolling() => _scrolling = false;

    /// <summary><c>mouseDragged</c> while scrolling: above the list jumps to the top, below to the bottom.</summary>
    public void Drag(float y, float dy) {
        if (!_scrolling) {
            return;
        }
        if (y < Y) {
            SetScrollAmount(0.0);
        }
        else if (y > Bottom) {
            SetScrollAmount(MaxScrollAmount);
        }
        else {
            double max = Math.Max(1, MaxScrollAmount);
            SetScrollAmount(ScrollAmount + dy * Math.Max(1.0, max / (Height - ScrollerHeight)));
        }
    }

    /// <summary><c>mouseScrolled</c>.</summary>
    public void Scroll(double scrollY) => SetScrollAmount(ScrollAmount - scrollY * ScrollRate);
}
