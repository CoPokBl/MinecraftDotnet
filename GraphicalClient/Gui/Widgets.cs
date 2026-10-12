namespace GraphicalClient.Gui;

/// <summary>A vanilla widget at vanilla's size, sprites and sounds, which a <see cref="Screen"/> lays out and clicks.</summary>
public abstract class Widget(float x, float y, float w, float h) {
    public float X { get; } = x;
    public float Y { get; } = y;
    public float W { get; } = w;
    public float H { get; } = h;

    /// <summary>A hidden widget is neither drawn nor clicked.</summary>
    public bool Visible { get; set; } = true;

    /// <summary>An inactive widget is drawn greyed and takes no click.</summary>
    public bool Active { get; set; } = true;

    public bool Contains(float mx, float my) => Screen.Inside(mx, my, X, Y, W, H);

    public abstract void Render(GuiContext context, bool hovered);

    public abstract void OnClick(GuiContext context, float mouseX);

    /// <summary><c>mouseScrolled</c>: whether the widget took the scroll.</summary>
    public virtual bool MouseScrolled(double scrollY) => false;

    protected static void Label(GuiContext context, string text, float x, float y, float w, float h) =>
        context.Text.DrawCentred(text, x + w / 2, y + (h - 8) / 2, 0xFFFFFFFF);
}

/// <summary><c>Button</c>, which clicks on press.</summary>
public sealed class Button(string label, float x, float y, float w, Action onPress, float h = 20) : Widget(x, y, w, h) {
    /// <summary><c>playDownSound</c>, which a book's page buttons replace with a page turn.</summary>
    public Action<GuiContext> DownSound { get; init; } = Screen.PlayDownSound;

    public override void Render(GuiContext context, bool hovered) => Draw(context, label, X, Y, W, H, hovered, Active);

    public override void OnClick(GuiContext context, float mouseX) {
        DownSound(context);
        onPress();
    }

    public static void Draw(GuiContext context, string label, float x, float y, float w, float h, bool highlighted, bool active = true) {
        string sprite = !active ? "widget/button_disabled" : highlighted ? "widget/button_highlighted" : "widget/button";
        if (!context.Sprites.Sliced(context.Gui, sprite, x, y, w, h, 3)) {
            context.Gui.Rect(x, y, w, h, active && highlighted ? 0xFFFFFFFF : 0xFF000000);
            context.Gui.Rect(x + 1, y + 1, w - 2, h - 2, active ? 0xFF6F6F6F : 0xFF2C2C2C);
            context.Gui.Rect(x + 1, y + h - 2, w - 2, 1, active ? 0xFF4A4A4A : 0xFF1E1E1E);
        }
        if (active) {
            Label(context, label, x, y, w, h);
        }
        else {
            context.Text.DrawCentred(label, x + w / 2, y + (h - 8) / 2, 0xFFA0A0A0);
        }
    }
}

/// <summary><c>CycleButton</c> built with <c>displayOnlyValue</c>: a click steps to the next value, with Shift to the previous.</summary>
public sealed class CycleButton<T>(IReadOnlyList<T> values, T value, Func<T, string> label, float x, float y, float w, Action<T> onValueChange)
    : Widget(x, y, w, 20) {
    private int _index = Math.Max(0, IndexOf(values, value));

    public T Value { get; private set; } = value;

    public override void Render(GuiContext context, bool hovered) => Button.Draw(context, label(Value), X, Y, W, H, hovered, Active);

    public override void OnClick(GuiContext context, float mouseX) {
        Screen.PlayDownSound(context);
        Cycle(Inventory.ContainerScreen.ShiftHeld() ? -1 : 1);
    }

    public override bool MouseScrolled(double scrollY) {
        if (scrollY > 0.0) {
            Cycle(-1);
        }
        else if (scrollY < 0.0) {
            Cycle(1);
        }
        return true;
    }

    private void Cycle(int delta) {
        _index = ((_index + delta) % values.Count + values.Count) % values.Count;
        Value = values[_index];
        onValueChange(Value);
    }

    /// <summary><c>setValue</c>: a value not in the list is shown but leaves the cycle where it was.</summary>
    public void SetValue(T newValue) {
        int newIndex = IndexOf(values, newValue);
        if (newIndex != -1) {
            _index = newIndex;
        }
        Value = newValue;
    }

    private static int IndexOf(IReadOnlyList<T> list, T item) {
        for (int i = 0; i < list.Count; i++) {
            if (EqualityComparer<T>.Default.Equals(list[i], item)) {
                return i;
            }
        }
        return -1;
    }
}

/// <summary><c>AbstractSliderButton</c>: a 0 to 1 value, set from where the mouse is across the track.</summary>
public sealed class Slider(float x, float y, float w, Func<double> get, Action<double> set, Func<double, string> label) : Widget(x, y, w, 20) {
    private const int HandleWidth = 8;

    /// <summary><c>setValueFromMouse</c>: the handle's centre follows the mouse.</summary>
    public void SetFromMouse(float mouseX) => set(Math.Clamp((mouseX - (X + HandleWidth / 2.0)) / (W - HandleWidth), 0.0, 1.0));

    public override void OnClick(GuiContext context, float mouseX) => SetFromMouse(mouseX);

    public override void Render(GuiContext context, bool hovered) {
        double value = get();
        float handleX = X + (int)(value * (W - HandleWidth));
        bool drawn = context.Sprites.Sliced(context.Gui, "widget/slider", X, Y, W, H, 1);
        drawn &= context.Sprites.Sliced(context.Gui, hovered ? "widget/slider_handle_highlighted" : "widget/slider_handle", handleX, Y, HandleWidth, H, 2);
        if (!drawn) {
            context.Gui.Rect(X, Y, W, H, 0xFF000000);
            context.Gui.Rect(X + 1, Y + 1, W - 2, H - 2, 0xFF3A3A3A);
            context.Gui.Rect(handleX, Y, HandleWidth, H, hovered ? 0xFFFFFFFF : 0xFFA0A0A0);
            context.Gui.Rect(handleX + 1, Y + 1, HandleWidth - 2, H - 2, 0xFF7A7A7A);
        }
        Label(context, label(value), X, Y, W, H);
    }
}

/// <summary>
/// A scrolling grid of equal cells, the shape of the stonecutter's recipes, the loom's patterns, the
/// merchant's trades and the creative palette. Cell positions are relative to the screen's panel.
/// </summary>
public sealed class ScrollGrid(float x, float y, int columns, int rows, float cellWidth, float cellHeight) {
    /// <summary>How many rows are scrolled past.</summary>
    public int Scroll { get; private set; }

    public int Cells => columns * rows;

    /// <summary>The index into the whole list of the item in a visible cell.</summary>
    public int IndexOf(int cell) => Scroll * columns + cell;

    public (float X, float Y) Cell(int cell) => (x + cell % columns * cellWidth, y + cell / columns * cellHeight);

    /// <summary>The visible cell under a point relative to the panel, or -1.</summary>
    public int CellAt(float mx, float my) {
        for (int cell = 0; cell < Cells; cell++) {
            (float cx, float cy) = Cell(cell);
            if (Screen.Inside(mx, my, cx, cy, cellWidth, cellHeight)) {
                return cell;
            }
        }
        return -1;
    }

    public void ScrollBy(float delta, int count) {
        int total = (count + columns - 1) / columns;
        Scroll = Math.Clamp(Scroll - Math.Sign(delta), 0, Math.Max(0, total - rows));
    }

    public void Reset() => Scroll = 0;
}
