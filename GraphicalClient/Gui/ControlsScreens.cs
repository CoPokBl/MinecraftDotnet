using System.Globalization;
using ClientLib;
using Minecraft.Schemas;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>The widgets of vanilla's <c>OptionInstance</c> kinds that the options screens share.</summary>
public static class OptionWidgets {
    private static string T(string key) => Translations.Get(key) ?? key;

    /// <summary><c>Options.genericValueLabel</c>.</summary>
    public static string Generic(string captionKey, string value) => $"{T(captionKey)}: {value}";

    /// <summary><c>OptionInstance.createBoolean</c>'s button: the caption and On or Off.</summary>
    public static CycleButton<bool> Boolean(string captionKey, bool value, float x, float y, Action<bool> set) =>
        new([true, false], value, on => Generic(captionKey, T(on ? "options.on" : "options.off")), x, y, 150, set);

    /// <summary>The toggle options' button, whose caption is a key's name and whose values are Toggle and Hold.</summary>
    public static CycleButton<bool> HoldOrToggle(string keyName, bool value, float x, float y, Action<bool> set) =>
        new([true, false], value, on => Generic(keyName, T(on ? "options.key.toggle" : "options.key.hold")), x, y, 150, set);

    /// <summary>
    /// The <c>narrator</c> option's button, which every screen with one shares: inactive where there is no speech
    /// engine, saying the new setting as it changes. A screen keeps it as its <c>NarratorButton</c> so the hot key
    /// can move it.
    /// </summary>
    public static CycleButton<Narration.NarratorStatus> Narrator(GuiContext context, float x, float y) {
        GameSettings settings = context.Settings!;
        return new CycleButton<Narration.NarratorStatus>(Enum.GetValues<Narration.NarratorStatus>(), settings.Narrator,
            status => Generic("options.narrator", context.Narrator?.OptionLabel(status) ?? T("options.narrator.notavailable")), x, y, 150, status => {
                settings.Narrator = status;
                context.Narrator?.UpdateNarratorStatus(status);
            }) {
            Active = context.Narrator?.IsActive == true
        };
    }

    /// <summary><c>OptionInstance.IntRange</c>'s slider over whole values from <paramref name="min"/> to <paramref name="max"/>.</summary>
    public static Slider IntRange(int min, int max, float x, float y, Func<int> get, Action<int> set, Func<int, string> label) =>
        new(x, y, 150, () => ToSliderValue(get(), min, max), slider => set(FromSliderValue(slider, min, max)), slider => label(FromSliderValue(slider, min, max)));

    /// <summary><c>IntRangeBase.toSliderValue</c>: each step in the middle of its share of the track.</summary>
    public static double ToSliderValue(int value, int min, int max) => value == min ? 0.0
        : value == max ? 1.0
        : (value + 0.5 - min) / (max + 1.0 - min);

    /// <summary><c>IntRangeBase.fromSliderValue</c>.</summary>
    public static int FromSliderValue(double slider, int min, int max) {
        if (slider >= 1.0) {
            slider = 0.99999F;
        }
        return (int)Math.Floor(min + slider * (max + 1.0 - min));
    }
}

/// <summary>Vanilla's <c>ControlsScreen</c>: the mouse and key bind screens, then the movement options.</summary>
public sealed class ControlsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("controls.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        Add(new Button(T("options.mouse_settings"), left, 37, 150, () => context.Open?.Invoke(new MouseSettingsScreen(this))));
        Add(new Button(T("controls.keybinds"), right, 37, 150, () => context.Open?.Invoke(new KeyBindsScreen(this))));
        Add(OptionWidgets.HoldOrToggle("key.sneak", settings.ToggleCrouch, left, 62, on => settings.ToggleCrouch = on));
        Add(OptionWidgets.HoldOrToggle("key.sprint", settings.ToggleSprint, right, 62, on => settings.ToggleSprint = on));
        Add(OptionWidgets.HoldOrToggle("key.attack", settings.ToggleAttack, left, 87, on => settings.ToggleAttack = on));
        Add(OptionWidgets.HoldOrToggle("key.use", settings.ToggleUse, right, 87, on => settings.ToggleUse = on));
        Add(OptionWidgets.Boolean("options.autoJump", settings.AutoJump, left, 112, on => settings.AutoJump = on));
        Add(OptionWidgets.IntRange(0, 10, right, 112, () => settings.SprintWindow, value => settings.SprintWindow = value,
            value => OptionWidgets.Generic("options.sprintWindow", value == 0 ? T("options.off") : Format("options.value", value))));
        // Stored and shown; the creative screen has no operator tab for it to reveal.
        Add(OptionWidgets.Boolean("options.operatorItemsTab", settings.OperatorItemsTab, left, 137, on => settings.OperatorItemsTab = on));
        AddDone(context, width, height);
    }

    private static string Format(string key, int value) => T(key).Replace("%s", value.ToString(CultureInfo.InvariantCulture));
}

/// <summary>Vanilla's <c>MouseSettingsScreen</c>, raw input included where the window can give it.</summary>
public sealed class MouseSettingsScreen(Screen parent) : OptionsPage(parent) {
    /// <summary>Whether the window can turn raw mouse motion on, as <c>InputConstants.isRawMouseInputSupported</c> asks.</summary>
    public static bool RawMouseInputSupported { get; set; } = true;

    protected override string Title => T("options.mouse_settings.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        Add(new Slider(left, 37, 150, () => settings.Sensitivity, value => settings.Sensitivity = value, SensitivityLabel));
        // IntRange(-200, 100) mapped through logMouse and unlogMouse.
        Add(OptionWidgets.IntRange(-200, 100, right, 37, () => (int)Math.Floor(Math.Log10(settings.MouseWheelSensitivity) * 100.0),
            value => settings.MouseWheelSensitivity = Math.Pow(10.0, value / 100.0),
            value => OptionWidgets.Generic("options.mouseWheelSensitivity", Math.Pow(10.0, value / 100.0).ToString("F2", CultureInfo.InvariantCulture))));
        Add(OptionWidgets.Boolean("options.discrete_mouse_scroll", settings.DiscreteMouseScroll, left, 62, on => settings.DiscreteMouseScroll = on));
        Add(OptionWidgets.Boolean("options.invertMouseX", settings.InvertMouseX, right, 62, on => settings.InvertMouseX = on));
        Add(OptionWidgets.Boolean("options.invertMouseY", settings.InvertMouseY, left, 87, on => settings.InvertMouseY = on));
        // Stored and shown; this client never changes the cursor's shape for it to allow.
        Add(OptionWidgets.Boolean("options.allowCursorChanges", settings.AllowCursorChanges, right, 87, on => settings.AllowCursorChanges = on));
        if (RawMouseInputSupported) {
            Add(OptionWidgets.Boolean("options.rawMouseInput", settings.RawMouseInput, left, 112, on => {
                settings.RawMouseInput = on;
                context.RawMouseInputChanged?.Invoke();
            }));
        }
        AddDone(context, width, height);
    }

    /// <summary>The <c>options.sensitivity</c> label: a percentage of the default, with names for the ends.</summary>
    private static string SensitivityLabel(double value) => value switch {
        0.0 => $"{T("options.sensitivity")}: {T("options.sensitivity.min")}",
        1.0 => $"{T("options.sensitivity")}: {T("options.sensitivity.max")}",
        _ => Percent(T("options.sensitivity"), 2.0 * value)
    };
}

/// <summary>
/// Vanilla's <c>KeyBindsScreen</c> and its <c>KeyBindsList</c>: every mapping by category, a click on one
/// waiting for the key or mouse button to bind it to, with Escape unbinding it.
/// </summary>
public sealed class KeyBindsScreen(Screen parent) : OptionsPage(parent) {
    private const int ItemHeight = 20, RowWidth = 340, ScrollbarWidth = 6, HeaderHeight = 33, FooterHeight = 33;

    private readonly List<(KeyCategory? Category, KeyBind? Bind)> _rows = [];
    private KeyBind? _selected;
    private double _scroll;
    private bool _draggingScrollbar;
    private Button? _resetAll;

    /// <summary><c>lastKeySelection</c>: the window lets a key that just bound one reach no other use.</summary>
    public long LastKeySelection { get; private set; }

    protected override string Title => T("controls.keybinds.title");

    protected override void Init(GuiContext context, int width, int height) {
        if (_rows.Count == 0) {
            KeyCategory? previous = null;
            foreach (KeyBind bind in context.Settings!.Keys.All.OrderBy(b => b, Comparer<KeyBind>.Create((a, b) => a.CompareTo(b)))) {
                if (bind.Category != previous) {
                    previous = bind.Category;
                    _rows.Add((bind.Category, null));
                }
                _rows.Add((null, bind));
            }
        }
        // The footer's two buttons, 150 wide and 8 apart, centred in its 33 pixels.
        float footerY = height - FooterHeight + (FooterHeight - 20) / 2;
        Add(_resetAll = new Button(T("controls.resetAll"), width / 2.0F - 154, footerY, 150, () => {
            foreach (KeyBind bind in context.Settings!.Keys.All) {
                bind.Key = bind.Default;
            }
        }));
        Add(new Button(T("gui.done"), width / 2.0F + 4, footerY, 150, () => Back(context)));
        SetScroll(context, _scroll);
    }

    private int ListBottom(GuiContext context) => context.Height - FooterHeight;

    private int ListHeight(GuiContext context) => ListBottom(context) - HeaderHeight;

    private int MaxScroll(GuiContext context) => Math.Max(0, _rows.Count * ItemHeight + 4 - ListHeight(context));

    private void SetScroll(GuiContext context, double scroll) => _scroll = Math.Clamp(scroll, 0.0, MaxScroll(context));

    private int RowLeft(GuiContext context) => context.Width / 2 - RowWidth / 2;

    private int ScrollBarX(GuiContext context) => RowLeft(context) + RowWidth + ScrollbarWidth + 2;

    private int RowTop(int row) => HeaderHeight + 2 - (int)_scroll + row * ItemHeight;

    /// <summary>The change and reset buttons of a row: the reset one 10 short of the scroll bar, the change one 5 left of it.</summary>
    private (int ChangeX, int ResetX, int Y) RowButtons(GuiContext context, int row) {
        int resetX = ScrollBarX(context) - 50 - 10;
        return (resetX - 5 - 75, resetX, RowTop(row) + 2 - 2);
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        context.Gui.Rect(0, 0, context.Width, context.Height, 0xC8101010);
        context.Text.DrawCentred(Title, context.Width / 2.0F, TitleY, 0xFFFFFFFF);
        GameSettings settings = context.Settings!;
        int top = HeaderHeight, bottom = ListBottom(context);
        context.Sprites.Blit(context.Gui, "gui/inworld_menu_list_background", 0, top, context.Width, bottom - top, context.Width, bottom + (int)_scroll,
            context.Width, bottom - top);
        context.Gui.EnableScissor(0, top, context.Width, bottom);
        bool overList = MouseY >= top && MouseY < bottom;
        string? tooltip = null;
        for (int row = 0; row < _rows.Count; row++) {
            int y = RowTop(row);
            if (y + ItemHeight < top || y > bottom) {
                continue;
            }
            (KeyCategory? category, KeyBind? bind) = _rows[row];
            if (category is { } c) {
                // A FocusableTextWidget, 4 pixels of padding round the text, at the bottom of the row's content.
                context.Text.DrawCentred(T("key.category.minecraft." + c.ToString().ToLowerInvariant()), context.Width / 2.0F, y + 5);
                continue;
            }
            (int changeX, int resetX, int buttonY) = RowButtons(context, row);
            bool resetHovered = overList && Inside(MouseX, MouseY, resetX, buttonY, 50, 20) && !bind!.IsDefault;
            Button.Draw(context, T("controls.reset"), resetX, buttonY, 50, 20, resetHovered, !bind!.IsDefault);
            List<KeyBind> conflicts = settings.Keys.Conflicts(bind).ToList();
            bool changeHovered = overList && Inside(MouseX, MouseY, changeX, buttonY, 75, 20);
            Button.Draw(context, ChangeLabel(bind, conflicts.Count > 0), changeX, buttonY, 75, 20, changeHovered);
            context.Text.Draw(T(bind.Name), RowLeft(context) + 2, y + 2 + (ItemHeight - 4) / 2 - 9 / 2, 0xFFFFFFFF);
            if (conflicts.Count > 0) {
                context.Gui.Rect(changeX - 6, y + 2 - 1, 3, ItemHeight - 4 + 1, 0xFFFFFF00);
                if (changeHovered) {
                    tooltip = T("controls.keybinds.duplicateKeybinds").Replace("%s", string.Join(", ", conflicts.Select(o => T(o.Name))));
                }
            }
        }
        context.Gui.DisableScissor();
        RenderScrollbar(context, top, bottom);
        _resetAll!.Active = settings.Keys.All.Any(b => !b.IsDefault);
        RenderWidgets(context);
        if (tooltip != null) {
            Inventory.Tooltips.Draw(context, tooltip.Split('\n').Select(line => ClientLib.TextFlattener.Formatted(line)).ToList(), MouseX, MouseY);
        }
    }

    private void RenderScrollbar(GuiContext context, int top, int bottom) {
        int max = MaxScroll(context);
        if (max == 0) {
            return;
        }
        int height = bottom - top;
        int scrollerHeight = Math.Clamp(height * height / (_rows.Count * ItemHeight + 4), 32, height - 8);
        int scrollerY = Math.Max(top, (int)_scroll * (height - scrollerHeight) / max + top);
        int x = ScrollBarX(context);
        if (!context.Sprites.Sliced(context.Gui, "widget/scroller_background", x, top, ScrollbarWidth, height, 1)) {
            context.Gui.Rect(x, top, ScrollbarWidth, height, 0xFF000000);
        }
        if (!context.Sprites.Sliced(context.Gui, "widget/scroller", x, scrollerY, ScrollbarWidth, scrollerHeight, 1)) {
            context.Gui.Rect(x, scrollerY, ScrollbarWidth, scrollerHeight, 0xFFC0C0C0);
        }
    }

    /// <summary><c>KeyEntry.refreshEntry</c>'s message: the key, bracketed in yellow on a conflict, pointed at while being chosen.</summary>
    private string ChangeLabel(KeyBind bind, bool conflict) {
        string label = bind.Key.DisplayName;
        if (conflict) {
            label = $"\u00a7e[ \u00a7f{label}\u00a7e ]";
        }
        if (_selected == bind) {
            label = conflict ? $"\u00a7e> \u00a7f\u00a7n[ {bind.Key.DisplayName} ]\u00a7r\u00a7e <" : $"\u00a7e> \u00a7f\u00a7n{label}\u00a7r\u00a7e <";
        }
        return label;
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        if (_selected != null) {
            _selected.Key = InputKey.Mouse(button);
            _selected = null;
            return;
        }
        if (button == MouseButton.Left && y >= HeaderHeight && y < ListBottom(context)) {
            if (MaxScroll(context) > 0 && x >= ScrollBarX(context) && x <= ScrollBarX(context) + ScrollbarWidth) {
                _draggingScrollbar = true;
                return;
            }
            for (int row = 0; row < _rows.Count; row++) {
                if (_rows[row].Bind is not { } bind) {
                    continue;
                }
                (int changeX, int resetX, int buttonY) = RowButtons(context, row);
                if (Pressed(context, x, y, changeX, buttonY, 75, 20)) {
                    _selected = bind;
                    return;
                }
                if (Pressed(context, x, y, resetX, buttonY, 50, 20, !bind.IsDefault)) {
                    bind.Key = bind.Default;
                    return;
                }
            }
        }
        base.MouseDown(context, x, y, button);
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        _draggingScrollbar = false;
        base.MouseUp(context, x, y, button);
    }

    public override void MouseMove(GuiContext context, float x, float y) {
        float lastY = MouseY;
        base.MouseMove(context, x, y);
        if (_draggingScrollbar) {
            int height = ListHeight(context);
            int scrollerHeight = Math.Clamp(height * height / (_rows.Count * ItemHeight + 4), 32, height - 8);
            double perPixel = Math.Max(1, MaxScroll(context)) / (double)(height - scrollerHeight);
            SetScroll(context, _scroll + (y - lastY) * perPixel);
        }
    }

    /// <summary><c>AbstractScrollArea.mouseScrolled</c> at the list's rate of half a row.</summary>
    public override void Scroll(GuiContext context, float delta) => SetScroll(context, _scroll - delta * (ItemHeight / 2));

    /// <summary><c>keyPressed</c> while a mapping waits for its key; whether it took the key.</summary>
    public bool KeyPressed(Key key, int scancode) {
        if (_selected == null) {
            return false;
        }
        _selected.Key = key == Key.Escape ? InputKey.Unknown : InputKey.FromEvent(key, scancode);
        _selected = null;
        LastKeySelection = Environment.TickCount64;
        return true;
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (!KeyPressed(key, 0)) {
            base.KeyDown(context, key, control);
        }
    }
}

/// <summary>Vanilla's <c>SkinCustomizationScreen</c>: each model part on or off, then the main hand.</summary>
public sealed class SkinCustomizationScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.skinCustomisation.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        for (int i = 0; i <= GameSettings.ModelPartIds.Length; i++) {
            float x = i % 2 == 0 ? left : right, y = 37 + i / 2 * 25;
            if (i == GameSettings.ModelPartIds.Length) {
                Add(new CycleButton<DominantHand>([DominantHand.Left, DominantHand.Right], settings.MainHand,
                    hand => OptionWidgets.Generic("options.mainHand", T(hand == DominantHand.Left ? "options.mainHand.left" : "options.mainHand.right")),
                    x, y, 150, hand => settings.MainHand = hand));
                continue;
            }
            (SkinParts part, string id) = GameSettings.ModelPartIds[i];
            // CycleButton.onOffBuilder, its caption the part's name.
            Add(new CycleButton<bool>([true, false], (settings.ModelParts & part) != 0,
                on => OptionWidgets.Generic("options.modelPart." + id, T(on ? "options.on" : "options.off")), x, y, 150,
                on => settings.ModelParts = on ? settings.ModelParts | part : settings.ModelParts & ~part));
        }
        AddDone(context, width, height);
    }
}
