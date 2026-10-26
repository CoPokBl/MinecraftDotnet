using ClientLib;
using ClientLib.Packs;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>LanguageSelectScreen</c>: the packs' languages, filtered by the search box. Done with a new one picked
/// reloads the resources, and leaving saves the options, which tells the server the new language.
/// </summary>
public sealed class LanguageSelectScreen(Screen lastScreen) : FocusScreen {
    private const int HeaderHeight = 36, FooterHeight = 53, EntryHeight = 18;

    /// <summary><c>options.languageAccuracyWarning</c>'s colour.</summary>
    private const uint WarningColor = 0xFFBABABA;

    private readonly SelectionList _list = new(EntryHeight) { RowWidth = () => 270 };
    private List<(string Code, LanguageInfo Info)> _entries = [];
    private EditBox _search = null!;
    private (int Row, long Time)? _lastClick;
    private Assets.ResourcePacks.LanguageManager? _languages;

    private string CurrentCode => _languages?.Selected ?? Assets.ResourcePacks.LanguageManager.DefaultCode;

    private IEnumerable<KeyValuePair<string, LanguageInfo>> Languages => _languages?.Languages ?? [];

    protected override string NarrationTitle => Menus.T("options.language.title");

    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        _languages = context.Resources?.Languages;
        string filter = first ? "" : _search.Value;
        _search = AddChild(new EditBox(context.Text, width / 2 - 100, 4 + 9 + 4, 200, 15) {
            Hint = [new TextRun(Menus.T("gui.language.search"), 0xAAAAAA, Italic: true)]
        });
        _search.SetResponder(FilterEntries);
        int buttonsY = height - FooterHeight + (FooterHeight - (9 + 8 + 20)) / 2 + 9 + 8;
        AddChild(new Button(Menus.T("options.font"), width / 2 - 154, buttonsY, 150, () => context.Open?.Invoke(new FontOptionsScreen(this))));
        AddChild(new Button(Menus.T("gui.done"), width / 2 + 4, buttonsY, 150, () => OnDone(context)));
        _list.SetBounds(0, HeaderHeight, width, height - HeaderHeight - FooterHeight);
        if (first) {
            FilterEntries("");
            if (_list.Selected >= 0) {
                _list.CenterScrollOn(_list.Selected);
            }
        }
        else {
            _search.Value = filter;
            FilterEntries(filter);
        }
        SetFocus(_search);
    }

    /// <summary><c>LanguageSelectionList.filterEntries</c>: by name or region, ignoring case.</summary>
    private void FilterEntries(string filter) {
        string selected = _list.Selected >= 0 && _list.Selected < _entries.Count ? _entries[_list.Selected].Code : CurrentCode;
        string lower = filter.ToLowerInvariant();
        _entries = Languages.Where(entry => filter.Length == 0 || entry.Value.Name.ToLowerInvariant().Contains(lower)
                                                              || entry.Value.Region.ToLowerInvariant().Contains(lower))
            .Select(entry => (entry.Key, entry.Value)).ToList();
        _list.Clear();
        foreach ((string code, _) in _entries) {
            int row = _list.Add();
            if (code == selected) {
                _list.Selected = row;
            }
        }
        _list.RefreshScrollAmount();
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        Menus.Background(context);
        int width = context.Width, height = context.Height;
        context.Text.DrawCentred(Menus.T("options.language.title"), width / 2.0F, 4);
        _list.Render(context, MouseX, MouseY, (row, x, y, w, h, _) =>
            context.Text.DrawCentred(_entries[row].Info.Display, _list.Width / 2.0F, y + 2 + (h - 4) / 2 - 9 / 2));
        _search.Render(context);
        context.Text.DrawCentred(Menus.Runs(Minecraft.Text.TextComponent.Translatable("options.languageAccuracyWarning"), (int)(WarningColor & 0xFFFFFF)),
            width / 2.0F, height - FooterHeight + (FooterHeight - (9 + 8 + 20)) / 2);
        RenderButtons(context);
    }

    /// <summary>
    /// <c>onDone</c>: a different language is selected and the resources reload, then the screen goes back,
    /// which saves the options as <c>OptionsSubScreen.removed</c> does.
    /// </summary>
    private void OnDone(GuiContext context) {
        if (_list.Selected >= 0 && context.Resources is { } resources && context.Settings is { } settings) {
            string code = _entries[_list.Selected].Code;
            if (code != resources.Languages.Selected) {
                resources.Languages.Selected = code;
                settings.Language = code;
                resources.RequestReload();
            }
        }
        context.Settings?.Save();
        context.Open?.Invoke(lastScreen);
    }

    public override void Close(GuiContext context) {
        context.Settings?.Save();
        context.Open?.Invoke(lastScreen);
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (ClickChildren(context, x, y, button) || button != MouseButton.Left) {
            return;
        }
        if (_list.StartScrolling(x, y)) {
            return;
        }
        int row = _list.EntryAt(x, y);
        if (row < 0) {
            return;
        }
        long now = Environment.TickCount64;
        bool doubleClick = _lastClick is { } last && last.Row == row && now - last.Time < 250;
        _lastClick = (row, now);
        _list.Selected = row;
        _list.ScrollToEntry(row);
        SetFocus(null);
        if (doubleClick) {
            OnDone(context);
        }
    }

    public override void MouseMove(GuiContext context, float x, float y) {
        LayOut(context);
        float dy = y - MouseY;
        base.MouseMove(context, x, y);
        _list.Drag(y, dy);
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        base.MouseUp(context, x, y, button);
        _list.StopScrolling();
    }

    public override void Scroll(GuiContext context, float delta) {
        LayOut(context);
        if (_list.IsMouseOver(MouseX, MouseY)) {
            _list.Scroll(delta);
        }
    }

    /// <summary>The list takes the arrows and Enter, <c>Entry.keyPressed</c>'s selection choosing the language.</summary>
    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        switch (key) {
            case Key.Up or Key.Down when _entries.Count > 0:
                int next = _list.Selected < 0 ? key == Key.Down ? 0 : _entries.Count - 1 : Math.Clamp(_list.Selected + (key == Key.Down ? 1 : -1), 0, _entries.Count - 1);
                _list.Selected = next;
                _list.ScrollToEntry(next);
                return;
            case Key.Enter or Key.KeypadEnter when _list.Selected >= 0:
                OnDone(context);
                return;
        }
        KeyToChildren(context, key, control);
    }
}

/// <summary>
/// <c>FontOptionsScreen</c>: unifont for everything, and the Japanese glyph shapes. Vanilla rebuilds only its
/// fonts on a change; here the resources reload, which rebuilds them with the rest.
/// </summary>
public sealed class FontOptionsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.font.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        Add(Toggle(context, "options.forceUnicodeFont", settings.ForceUnicodeFont, on => settings.ForceUnicodeFont = on, width / 2.0F - 155));
        Add(Toggle(context, "options.japaneseGlyphVariants", settings.JapaneseGlyphVariants, on => settings.JapaneseGlyphVariants = on, width / 2.0F + 5));
        AddDone(context, width, height);
    }

    private static CycleButton<bool> Toggle(GuiContext context, string key, bool value, Action<bool> set, float x) =>
        new([true, false], value, on => $"{T(key)}: {T(on ? "options.on" : "options.off")}", x, 37, 150, on => {
            set(on);
            context.Resources?.RequestReload();
        });
}
