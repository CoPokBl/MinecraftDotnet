using ClientLib;
using ClientLib.Stats;
using GraphicalClient.Gui.Inventory;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Data.StatisticTypes;
using Minecraft.Registry;
using Minecraft.Schemas.Items;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>StatsScreen</c>: General, Items and Mobs tabs over the player's statistics. It asks the server for them
/// once, when it first opens, and waits under a loading tab until the answer comes. Which rows a list has is
/// fixed then; the values in them are read live.
/// </summary>
public sealed class StatsScreen(Screen parent) : Screen {
    private const int TabBarHeight = 24, FooterHeight = 33, RowWidth = 280;
    private const uint Shaded = 0xFFBABABA, Faded = 0xFF808080;

    private static readonly string[] TabKeys = ["stat.generalButton", "stat.itemsButton", "stat.mobsButton"];

    /// <summary><c>ItemStatisticsList</c>'s block columns then item columns, with their header marks.</summary>
    private static readonly (IStatisticType Type, string Sprite)[] Columns = [
        (StatisticType.Mined, "statistics/block_mined"),
        (StatisticType.Broken, "statistics/item_broken"),
        (StatisticType.Crafted, "statistics/item_crafted"),
        (StatisticType.Used, "statistics/item_used"),
        (StatisticType.PickedUp, "statistics/item_picked_up"),
        (StatisticType.Dropped, "statistics/item_dropped")
    ];

    private const int BlockColumns = 1;

    private readonly SelectionList _general = new(14) { RowWidth = () => RowWidth, Decorated = false };
    private readonly SelectionList _items = new(22) { RowWidth = () => RowWidth, Decorated = false };
    private readonly SelectionList _mobs = new(9 * 4) { RowWidth = () => RowWidth, Decorated = false };

    private List<(Stat Stat, string Name)> _generalRows = [];
    private List<ItemRow> _itemRows = [];
    private List<MobRow> _mobRows = [];

    private bool _requested, _loading = true, _listFocused;
    private int _updatesBefore, _tab;
    private readonly bool[] _tabActive = [true, false, false];
    private int _sortColumn = -1, _sortOrder;

    private sealed record ItemRow(IItem Item, int ItemId, int? BlockId, ItemStack Stack);

    private sealed record MobRow(string Name, Stat Killed, Stat KilledBy);

    public override bool ShowsHud => false;

    protected override string NarrationTitle => Menus.T("gui.stats");

    private SelectionList? CurrentList => _loading ? null : _tab switch {
        0 => _general,
        1 => _items,
        _ => _mobs
    };

    protected override void Init(GuiContext context, int width, int height) {
        if (!_requested) {
            _requested = true;
            _updatesBefore = context.Client.StatsUpdates;
            context.Client.RequestStats();
        }
        Add(new Button(Menus.T("gui.done"), width / 2.0F - 100, height - FooterHeight + (FooterHeight - 20) / 2, 200, () => Close(context)));
        foreach (SelectionList list in (SelectionList[])[_general, _items, _mobs]) {
            list.SetBounds(0, TabBarHeight, width, height - TabBarHeight - FooterHeight);
        }
    }

    public override void Close(GuiContext context) => context.Open?.Invoke(parent);

    /// <summary><c>onStatsUpdated</c>, the first time only: the real tabs replace the loading ones.</summary>
    private void OnStatsUpdated(GuiContext context) {
        MinecraftRegistry registry = context.Client.Registry;
        StatsCounter stats = context.Client.Stats;

        _generalRows = registry.CustomStatistics.All
            .Select(custom => (Stat.Custom(custom, registry), Menus.T("stat." + custom.Identifier.ToString().Replace(':', '.'))))
            .OrderBy(row => row.Item2, StringComparer.Ordinal).ToList();
        _general.Clear();
        foreach (var _ in _generalRows) {
            _general.Add();
        }

        // Vanilla gathers these into an identity hash set, so its order is whatever the hashes give; this lists by item id.
        SortedSet<int> itemIds = [];
        foreach (IItem item in registry.Items.All) {
            int id = registry.Items.GetProtocolId(item);
            if (Columns.Skip(BlockColumns).Any(column => stats.GetValue(column.Type, id) > 0)) {
                itemIds.Add(id);
            }
        }
        foreach (Minecraft.Data.Blocks.IBlock block in registry.Blocks.All) {
            if (block.Item is { } item && registry.Items.Contains(item) && stats.GetValue(StatisticType.Mined, registry.Blocks.GetProtocolId(block)) > 0) {
                itemIds.Add(registry.Items.GetProtocolId(item));
            }
        }
        itemIds.Remove(registry.Items.GetProtocolId(Item.Air));
        _itemRows = itemIds.Select(id => {
            IItem item = registry.Items[id];
            int? blockId = item.CorrespondingBlock is { } block && registry.Blocks.Contains(block) ? registry.Blocks.GetProtocolId(block) : null;
            return new ItemRow(item, id, blockId, new ItemStack(item, 1));
        }).ToList();
        _items.Clear();
        if (_itemRows.Count > 0) {
            _items.Add();
            foreach (ItemRow _ in _itemRows) {
                _items.Add();
            }
        }

        _mobRows = [];
        foreach (IEntityType type in registry.EntityTypes.All.OrderBy(type => registry.EntityTypes.GetProtocolId(type))) {
            int id = registry.EntityTypes.GetProtocolId(type);
            Stat killed = new(StatisticType.Killed, id), killedBy = new(StatisticType.KilledBy, id);
            if (stats.GetValue(killed) > 0 || stats.GetValue(killedBy) > 0) {
                _mobRows.Add(new MobRow(TextFlattener.Plain(TextComponent.Translatable($"entity.{type.Identifier.Namespace}.{type.Identifier.Key}")), killed, killedBy));
            }
        }
        _mobs.Clear();
        foreach (MobRow _ in _mobRows) {
            _mobs.Add();
        }

        _tabActive[0] = true;
        _tabActive[1] = _items.Count > 0;
        _tabActive[2] = _mobs.Count > 0;
        _tab = 0;
        _loading = false;
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        if (_loading && context.Client.StatsUpdates != _updatesBefore) {
            OnStatsUpdated(context);
        }
        RenderBackground(context);
        List<List<TextRun>>? tooltip = null;
        float tooltipX = context.MouseX, tooltipY = context.MouseY;
        if (CurrentList is { } list) {
            list.Render(context, context.MouseX, context.MouseY, (row, x, y, w, h, hovered) => {
                switch (_tab) {
                    case 0:
                        RenderGeneralRow(context, row, x + 2, y + 2, w - 4);
                        break;
                    case 1:
                        RenderItemRow(context, row, x + 2, y + 2, ref tooltip, ref tooltipX, ref tooltipY);
                        break;
                    default:
                        RenderMobRow(context, row, x + 2, y + 2);
                        break;
                }
            }, _listFocused);
        }
        else {
            RenderLoading(context);
        }
        RenderTabBar(context, ref tooltip);
        if (!context.Sprites.Blit(context.Gui, "gui/footer_separator", 0, context.Height - FooterHeight, context.Width, 2, 0, 0, context.Width, 2)) {
            context.Gui.Rect(0, context.Height - FooterHeight + 1, context.Width, 1, 0x40FFFFFF);
        }
        RenderWidgets(context);
        if (tooltip != null) {
            Tooltips.Draw(context, tooltip, tooltipX, tooltipY);
        }
    }

    /// <summary><c>extractMenuBackground</c>: the tab header strip, then the menu background under it.</summary>
    private static void RenderBackground(GuiContext context) {
        Menus.Background(context);
        int width = context.Width, height = context.Height;
        if (!context.Sprites.Tiled(context.Gui, "gui/tab_header_background", 0, 0, width, TabBarHeight, 16)) {
            context.Gui.Rect(0, 0, width, TabBarHeight, 0xFF000000);
        }
        string background = context.Client.Level == null ? "gui/menu_background" : "gui/inworld_menu_background";
        if (!context.Sprites.Tiled(context.Gui, background, 0, TabBarHeight, width, height - TabBarHeight, 32)) {
            context.Gui.Rect(0, TabBarHeight, width, height - TabBarHeight, 0x40000000);
        }
    }

    /// <summary><c>LoadingTab</c>'s <c>LoadingDotsWidget</c>, padded 30 below and centred in the tab area.</summary>
    private static void RenderLoading(GuiContext context) {
        int areaHeight = context.Height - FooterHeight - TabBarHeight;
        int top = TabBarHeight + (areaHeight - (2 + 9 + 6 + 9 + 2 + 30)) / 2;
        context.Text.DrawCentred(Menus.T("multiplayer.downloadingStats"), context.Width / 2.0F, top + 2);
        context.Text.DrawCentred(JoinMultiplayerScreen.LoadingDots(Environment.TickCount64), context.Width / 2.0F, top + 2 + 9 + 6, Faded);
    }

    /// <summary><c>MenuTabBar.arrangeElements</c>: three equal tabs, each rounded up to an even width.</summary>
    private static (int Left, int TabWidth) TabLayout(int width) {
        int tabsWidth = Math.Min(400, width) - 28;
        return (RoundToward((width - tabsWidth) / 2, 2), RoundToward(tabsWidth / TabKeys.Length, 2));
    }

    /// <summary><c>Mth.roundToward</c>, which rounds up.</summary>
    private static int RoundToward(int input, int multiple) => -(int)Math.Floor(-input / (double)multiple) * multiple;

    private int TabAt(GuiContext context, float x, float y) {
        (int left, int tabWidth) = TabLayout(context.Width);
        if (y < 0 || y >= TabBarHeight || x < left) {
            return -1;
        }
        int tab = (int)(x - left) / tabWidth;
        return tab < TabKeys.Length ? tab : -1;
    }

    /// <summary><c>MenuTabBar</c> and its <c>MenuTabButton</c>s, with the separator either side of them.</summary>
    private void RenderTabBar(GuiContext context, ref List<List<TextRun>>? tooltip) {
        (int left, int tabWidth) = TabLayout(context.Width);
        int right = left + tabWidth * TabKeys.Length;
        if (!context.Sprites.Blit(context.Gui, "gui/header_separator", 0, TabBarHeight - 2, left, 2, 0, 0, left, 2)
            | !context.Sprites.Blit(context.Gui, "gui/header_separator", right, TabBarHeight - 2, context.Width - right, 2, 0, 0, context.Width - right, 2)) {
            context.Gui.Rect(0, TabBarHeight - 2, left, 1, 0x40FFFFFF);
            context.Gui.Rect(right, TabBarHeight - 2, context.Width - right, 1, 0x40FFFFFF);
        }
        int hovered = TabAt(context, context.MouseX, context.MouseY);
        for (int i = 0; i < TabKeys.Length; i++) {
            int x = left + i * tabWidth;
            bool selected = i == _tab, highlighted = i == hovered;
            string sprite = (selected ? "widget/tab_selected" : "widget/tab") + (highlighted ? "_highlighted" : "");
            if (!context.Sprites.NineSliced(context.Gui, sprite, x, 0, tabWidth, TabBarHeight, 2)) {
                context.Gui.Rect(x, 0, tabWidth, TabBarHeight, highlighted ? 0xFFFFFFFF : 0xFF000000);
                context.Gui.Rect(x + 1, 1, tabWidth - 2, TabBarHeight - 1, selected ? 0xFF3C3C3C : 0xFF262626);
            }
            uint colour = _tabActive[i] ? 0xFFFFFFFF : 0xFFA0A0A0;
            string label = Menus.T(TabKeys[i]);
            int labelWidth = context.Text.Width(label);
            if (selected) {
                if (!context.Sprites.Tiled(context.Gui, "gui/menu_background", x + 2, 2, tabWidth - 4, TabBarHeight - 2, 32)) {
                    context.Gui.Rect(x + 2, 2, tabWidth - 4, TabBarHeight - 2, 0xFF303030);
                }
                int underline = Math.Min(labelWidth, tabWidth - 4);
                context.Gui.Rect(x + (tabWidth - underline) / 2, TabBarHeight - 2, underline, 1, colour);
            }
            int top = selected ? 0 : 3;
            context.Text.Draw(label, (x + 1 + x + tabWidth - 1) / 2 - labelWidth / 2, (top + TabBarHeight - 9) / 2 + 1, colour);
            if (highlighted && !_tabActive[i] && !_loading) {
                tooltip = [[TextRun.Of(Menus.T("gui.stats.none_found"), new RunStyle(TextFlattener.DefaultRgb))]];
            }
        }
    }

    private void RenderGeneralRow(GuiContext context, int row, int x, int y, int width) {
        (Stat stat, string name) = _generalRows[row];
        uint colour = row % 2 == 0 ? 0xFFFFFFFF : Shaded;
        int textY = y + (_general.RowHeight(row) - 4) / 2 - 9 / 2;
        context.Text.Draw(name, x + 2, textY, colour);
        string value = StatFormatter.Format(stat, context.Client.Stats.GetValue(stat), context.Client.Registry);
        context.Text.Draw(value, x + width - context.Text.Width(value) - 4, textY, colour);
    }

    /// <summary><c>getColumnX</c>: the right edge of a column's values.</summary>
    private static int ColumnX(int column) => 75 + 40 * column;

    private void RenderItemRow(GuiContext context, int row, int x, int y, ref List<List<TextRun>>? tooltip, ref float tooltipX, ref float tooltipY) {
        bool overList = _items.IsMouseOver(context.MouseX, context.MouseY);
        if (row == 0) {
            for (int column = 0; column < Columns.Length; column++) {
                float bx = x + ColumnX(column) - 18, by = y + 1;
                if (!context.Sprites.Sprite(context.Gui, "statistics/header", bx, by, 18, 18)) {
                    context.Gui.Rect(bx, by, 18, 18, 0xFF8B8B8B);
                }
                context.Sprites.Sprite(context.Gui, Columns[column].Sprite, bx, by, 18, 18);
                if (overList && Inside(context.MouseX, context.MouseY, bx, by, 18, 18)) {
                    tooltip = [[TextRun.Of(Menus.T("stat_type." + Columns[column].Type.Identifier.ToString().Replace(':', '.')), new RunStyle(TextFlattener.DefaultRgb))]];
                    (tooltipX, tooltipY) = (context.MouseX, context.MouseY);
                }
            }
            if (_sortColumn >= 0) {
                context.Sprites.Sprite(context.Gui, _sortOrder == 1 ? "statistics/sort_up" : "statistics/sort_down", x + ColumnX(_sortColumn) - 36, y + 1, 18, 18);
            }
            return;
        }
        ItemRow item = _itemRows[row - 1];
        if (!context.Sprites.Sprite(context.Gui, "container/slot", x, y, 18, 18)) {
            context.Gui.Rect(x, y, 18, 18, 0xFF373737);
            context.Gui.Rect(x + 1, y + 1, 17, 17, 0xFFFFFFFF);
            context.Gui.Rect(x + 1, y + 1, 16, 16, 0xFF8B8B8B);
        }
        GuiItems.Draw(context, item.Stack, x + 1, y + 1);
        if (overList && Inside(context.MouseX, context.MouseY, x, y, 18, 18)) {
            tooltip = Tooltips.Lines(item.Stack);
            (tooltipX, tooltipY) = (x + 18, y + 18);
        }
        StatsCounter stats = context.Client.Stats;
        uint colour = row % 2 == 0 ? 0xFFFFFFFF : Shaded;
        int textY = y + (22 - 4) / 2 - 9 / 2;
        for (int column = 0; column < Columns.Length; column++) {
            int? id = column < BlockColumns ? item.BlockId : item.ItemId;
            string value = id is { } valueId ? StatFormatter.Default(stats.GetValue(Columns[column].Type, valueId)) : Menus.T("stats.none");
            context.Text.Draw(value, x + ColumnX(column) - context.Text.Width(value), textY, colour);
        }
    }

    private void RenderMobRow(GuiContext context, int row, int x, int y) {
        MobRow mob = _mobRows[row];
        StatsCounter stats = context.Client.Stats;
        int kills = stats.GetValue(mob.Killed), killedBy = stats.GetValue(mob.KilledBy);
        TextComponent name = TextComponent.Text(mob.Name);
        string killsLine = TextFlattener.Plain(kills == 0
            ? Menus.Translatable("stat_type.minecraft.killed.none", name)
            : Menus.Translatable("stat_type.minecraft.killed", TextComponent.Text(kills.ToString()), name));
        string killedByLine = TextFlattener.Plain(killedBy == 0
            ? Menus.Translatable("stat_type.minecraft.killed_by.none", name)
            : Menus.Translatable("stat_type.minecraft.killed_by", name, TextComponent.Text(killedBy.ToString())));
        context.Text.Draw(mob.Name, x + 2, y + 1);
        context.Text.Draw(killsLine, x + 2 + 10, y + 1 + 9, kills == 0 ? Faded : Shaded);
        context.Text.Draw(killedByLine, x + 2 + 10, y + 1 + 9 * 2, killedBy == 0 ? Faded : Shaded);
    }

    /// <summary><c>TabNavigationBar.selectTab</c> through <c>TabManager.setCurrentTab</c>: an inactive tab is not taken, and only a change clicks.</summary>
    private void SelectTab(GuiContext context, int tab, bool playSound) {
        if (!_tabActive[tab] || tab == _tab) {
            return;
        }
        _tab = tab;
        if (playSound) {
            PlayDownSound(context);
        }
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (button == MouseButton.Left && TabAt(context, x, y) is var tab and >= 0) {
            _listFocused = false;
            if (!_loading) {
                SelectTab(context, tab, true);
            }
            return;
        }
        if (ClickWidgets(context, x, y, button)) {
            _listFocused = false;
            return;
        }
        if (button != MouseButton.Left || CurrentList is not { } list || !list.IsMouseOver(x, y)) {
            return;
        }
        if (list.StartScrolling(x, y)) {
            return;
        }
        int row = list.EntryAt(x, y);
        if (row < 0) {
            return;
        }
        if (_tab == 1) {
            if (row == 0) {
                ClickHeader(context, x - (list.RowLeft + 2), y - (list.RowTop(0) + 2));
            }
            return;
        }
        list.Selected = row;
        _listFocused = true;
    }

    private void ClickHeader(GuiContext context, float relX, float relY) {
        for (int column = 0; column < Columns.Length; column++) {
            if (Inside(relX, relY, ColumnX(column) - 18, 1, 18, 18)) {
                PlayDownSound(context);
                SortByColumn(context.Client.Stats, column);
                return;
            }
        }
    }

    /// <summary><c>sortByColumn</c>: down, then up, then unsorted, which leaves the rows where the last sort put them.</summary>
    private void SortByColumn(StatsCounter stats, int column) {
        if (column != _sortColumn) {
            _sortColumn = column;
            _sortOrder = -1;
        }
        else if (_sortOrder == -1) {
            _sortOrder = 1;
        }
        else {
            _sortColumn = -1;
            _sortOrder = 0;
        }
        // List.sort is stable, which the unsorted step relies on to keep the order; OrderBy is stable too.
        _itemRows = _itemRows.OrderBy(row => row, Comparer<ItemRow>.Create((one, two) => CompareRows(stats, one, two))).ToList();
    }

    /// <summary><c>ItemRowComparator</c>: by the column's value, then by item id, both in the sort's direction; no block reads -1.</summary>
    private int CompareRows(StatsCounter stats, ItemRow one, ItemRow two) {
        if (_sortColumn < 0) {
            return 0;
        }
        int key1, key2;
        IStatisticType type = Columns[_sortColumn].Type;
        if (_sortColumn < BlockColumns) {
            key1 = one.BlockId is { } block1 ? stats.GetValue(type, block1) : -1;
            key2 = two.BlockId is { } block2 ? stats.GetValue(type, block2) : -1;
        }
        else {
            key1 = stats.GetValue(type, one.ItemId);
            key2 = stats.GetValue(type, two.ItemId);
        }
        return key1 == key2 ? _sortOrder * one.ItemId.CompareTo(two.ItemId) : _sortOrder * key1.CompareTo(key2);
    }

    public override void MouseMove(GuiContext context, float x, float y) {
        float dy = y - MouseY;
        base.MouseMove(context, x, y);
        CurrentList?.Drag(y, dy);
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        base.MouseUp(context, x, y, button);
        CurrentList?.StopScrolling();
    }

    public override void Scroll(GuiContext context, float delta) {
        LayOut(context);
        if (CurrentList is { } list && list.IsMouseOver(MouseX, MouseY)) {
            list.Scroll(delta);
        }
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (control && !_loading && NextTab(key) is var next and >= 0) {
            SelectTab(context, Math.Clamp(next, 0, TabKeys.Length - 1), true);
            return;
        }
        if (_listFocused && _tab != 1 && CurrentList is { Count: > 0 } list && key is Key.Up or Key.Down) {
            list.Selected = Math.Clamp(list.Selected + (key == Key.Up ? -1 : 1), 0, list.Count - 1);
            list.ScrollToEntry(list.Selected);
            return;
        }
        base.KeyDown(context, key, control);
    }

    /// <summary><c>getNextTabIndex</c>: a digit picks that tab, Tab steps to the next active one, with Shift back.</summary>
    private int NextTab(Key key) {
        if (key is >= Key.Number0 and <= Key.Number9) {
            int digit = key - Key.Number0;
            return ((digit - 1) % 10 + 10) % 10;
        }
        if (key != Key.Tab) {
            return -1;
        }
        int step = ContainerScreen.ShiftHeld() ? -1 : 1;
        int index = _tab;
        for (int i = 0; i < TabKeys.Length; i++) {
            index = ((index + step) % TabKeys.Length + TabKeys.Length) % TabKeys.Length;
            if (_tabActive[index]) {
                return index;
            }
        }
        return -1;
    }

    protected override void UpdateNarrationState(Narration.INarrationOutput output) {
        output.Add(Narration.NarratedElementType.Title, TextComponent.Text(NarrationTitle));
        if (_tab == 0 && !_loading && _general.Selected >= 0 && _general.Selected < _generalRows.Count) {
            output.Add(Narration.NarratedElementType.Title, TextComponent.Translatable("narrator.select", null, [TextComponent.Text(_generalRows[_general.Selected].Name)]));
        }
        UpdateNarratedWidget(output);
    }
}
