using ClientLib;
using ClientLib.Inventory;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas.Items;
using Silk.NET.Input;

namespace GraphicalClient.Gui.Inventory;

/// <summary>
/// <c>CreativeModeInventoryScreen</c>, as one searchable palette of every item plus the player's
/// inventory. The palette and the cursor live only on the client, as in vanilla; what changes in
/// the player's own slots goes to the server as <c>set_creative_mode_slot</c>, slot by slot, which is
/// what vanilla's creative slot listener sends.
/// </summary>
public sealed class CreativeInventoryScreen : Screen {
    private const int Columns = 9, Rows = 5;
    private const int Width = 195, Height = 136;

    private readonly MinecraftClient _client;
    private readonly List<IItem> _allItems;
    private List<IItem> _filtered;
    private string _search = "";
    private readonly ScrollGrid _palette = new(8, 17, Columns, Rows, 18, 18);
    private bool _inventoryTab;

    /// <summary>
    /// Whether the palette is vanilla's search tab, whose box has the keyboard, rather than an ordinary item tab.
    /// The chat key or a click on the box picks it, as vanilla's chat key and search tab do.
    /// </summary>
    private bool _searchTab;

    /// <summary><c>ignoreTextInput</c>: the key just pressed did something else, so its character is not typed.</summary>
    private bool _ignoreTextInput;
    private float _left, _top;
    private readonly EffectsInInventory _effects = new();

    public CreativeInventoryScreen(MinecraftClient client) {
        _client = client;
        _client.CreativeInventoryOpen = true;
        _allItems = VanillaRegistry.Data.Items.All.Where(i => i.Identifier.Key != "air").ToList();
        _filtered = _allItems;
        _client.Inventory.Menu.Carried = Stack.Empty;
    }

    public override bool ShowsHud => false;

    public override bool IsAllowedInPortal => false;

    public override bool HasFocusedEditBox => _searchTab && !_inventoryTab;

    private Stack Carried {
        get => _client.Inventory.Menu.Carried;
        set => _client.Inventory.Menu.Carried = value;
    }

    protected override void Init(GuiContext context, int width, int height) {
        _left = (width - Width) / 2;
        _top = (height - Height) / 2;
    }

    /// <summary>The inventory menu slots the lower part shows: the hotbar always, the rest on the inventory tab.</summary>
    private IEnumerable<(int MenuSlot, float X, float Y)> PlayerSlots() {
        for (int i = 0; i < 9; i++) {
            yield return (PlayerInventory.HotbarStart + i, 9 + i * 18, 112);
        }
        if (!_inventoryTab) {
            yield break;
        }
        for (int row = 0; row < 3; row++) {
            for (int column = 0; column < 9; column++) {
                yield return (9 + row * 9 + column, 9 + column * 18, 54 + row * 18);
            }
        }
        for (int i = 0; i < 4; i++) {
            yield return (5 + i, 54 + i * 18, 18);
        }
        yield return (PlayerInventory.OffhandSlot, 35, 18);
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        context.Gui.Rect(0, 0, context.Width, context.Height, 0x80101010);
        _effects.Render(context, _left, _top, Width, MouseX, MouseY);
        Panel.Draw(context, _left, _top, Width, Height);

        Button.Draw(context, "Items", _left, _top - 18, 40, 16, !_inventoryTab);
        Button.Draw(context, "Inventory", _left + 42, _top - 18, 56, 16, _inventoryTab);

        context.Gui.Rect(_left + 80, _top + 4, 89, 12, 0xFF000000);
        context.Gui.Rect(_left + 81, _top + 5, 87, 10, 0xFF1A1A1A);
        string shown = _search.Length > 0 ? _search : Translations.Get("itemGroup.search.hint")!;
        float end = context.Text.Draw(shown, _left + 83, _top + 6, _search.Length > 0 ? 0xFFFFFFFFu : 0xFF707070u, false);
        if (HasFocusedEditBox && Environment.TickCount64 / 300 % 2 == 0) {
            context.Text.Draw("_", _search.Length > 0 ? end : _left + 83, _top + 6, 0xFFFFFFFF, false);
        }
        context.Text.Draw(_inventoryTab ? "Inventory" : "All items", _left + 8, _top + 6, Panel.Label, false);

        ItemStack? hoveredStack = null;
        if (!_inventoryTab) {
            int hovered = _palette.CellAt(MouseX - _left, MouseY - _top);
            for (int cell = 0; cell < _palette.Cells; cell++) {
                (float cx, float cy) = _palette.Cell(cell);
                float x = _left + cx + 1, y = _top + cy + 1;
                Panel.Slot(context, x, y);
                int index = _palette.IndexOf(cell);
                if (index >= _filtered.Count) {
                    continue;
                }
                ItemStack stack = new(_filtered[index]);
                GuiItems.Draw(context, stack, x, y);
                if (cell == hovered) {
                    context.Gui.Rect(x, y, 16, 16, 0x80FFFFFF);
                    hoveredStack = stack;
                }
            }
            int rows = (_filtered.Count + Columns - 1) / Columns;
            float track = Rows * 18;
            float thumb = rows <= Rows ? track : Math.Max(8, track * Rows / rows);
            float offset = rows <= Rows ? 0 : (track - thumb) * _palette.Scroll / (rows - Rows);
            context.Gui.Rect(_left + 175, _top + 18, 12, track, 0xFF8B8B8B);
            context.Gui.Rect(_left + 176, _top + 18 + offset, 10, thumb, 0xFFE0E0E0);
        }

        foreach ((int menuSlot, float sx, float sy) in PlayerSlots()) {
            float x = _left + sx, y = _top + sy;
            Panel.Slot(context, x, y);
            Stack item = _client.Inventory.Menu.Slots[menuSlot].Item;
            GuiItems.Draw(context, item.ToItemStack(), x, y);
            if (Inside(MouseX, MouseY, x - 1, y - 1, 18, 18)) {
                context.Gui.Rect(x, y, 16, 16, 0x80FFFFFF);
                if (item.IsEmpty) {
                    continue;
                }
                hoveredStack = item.ToItemStack();
            }
        }

        if (!Carried.IsEmpty) {
            GuiItems.Draw(context, Carried.ToItemStack(), MouseX - 8, MouseY - 8);
        }
        else if (hoveredStack != null) {
            Tooltips.Draw(context, Tooltips.Lines(hoveredStack), MouseX, MouseY);
        }
        _effects.DrawTooltip(context, MouseX, MouseY);
    }

    public override bool ShowsActiveEffects(GuiContext context) => EffectsInInventory.CanSeeEffects(context.Width, _left, Width);

    public override void MouseDown(GuiContext context, float x, float y, MouseButton mouseButton) {
        LayOut(context);
        SetMouse(x, y);
        int button = mouseButton switch {
            MouseButton.Left => 0,
            MouseButton.Right => 1,
            MouseButton.Middle => 2,
            _ => -1
        };
        if (button < 0) {
            return;
        }
        bool shift = ContainerScreen.ShiftHeld();

        if (Inside(x, y, _left, _top - 18, 40, 16)) {
            SelectTab(false, false);
            return;
        }
        if (Inside(x, y, _left + 42, _top - 18, 56, 16)) {
            SelectTab(true, false);
            return;
        }
        if (!_inventoryTab && Inside(x, y, _left + 80, _top + 4, 89, 12)) {
            SelectTab(false, true);
            return;
        }

        if (!_inventoryTab && _palette.CellAt(x - _left, y - _top) is var cell and >= 0) {
            int index = _palette.IndexOf(cell);
            PaletteClicked(index < _filtered.Count ? Stack.Of(new ItemStack(_filtered[index])) : Stack.Empty, button, shift);
            return;
        }

        foreach ((int menuSlot, float sx, float sy) in PlayerSlots()) {
            if (Inside(x, y, _left + sx - 1, _top + sy - 1, 18, 18)) {
                PlayerSlotClicked(menuSlot, button, shift);
                return;
            }
        }

        if (!Inside(x, y, _left, _top, Width, Height) && !Carried.IsEmpty) {
            // handleCreativeModeItemDrop: a throw is a creative slot of -1.
            Stack thrown = button == 0 ? Carried : Carried.Split(1);
            if (button == 0) {
                Carried = Stack.Empty;
            }
            _client.SetCreativeSlot(-1, thrown.ToItemStack());
        }
    }

    /// <summary>The palette half of vanilla's <c>slotClicked</c>.</summary>
    private void PaletteClicked(Stack clicked, int button, bool shift) {
        Stack carried = Carried;
        if (button == 2) {
            if (carried.IsEmpty && !clicked.IsEmpty) {
                Carried = clicked.CopyWithCount(clicked.MaxStackSize);
            }
            return;
        }
        if (!carried.IsEmpty && !clicked.IsEmpty && Stack.IsSameItemSameComponents(carried, clicked)) {
            if (button == 0) {
                if (shift) {
                    carried.Count = carried.MaxStackSize;
                }
                else if (carried.Count < carried.MaxStackSize) {
                    carried.Grow(1);
                }
            }
            else {
                carried.Shrink(1);
            }
        }
        else if (!clicked.IsEmpty && carried.IsEmpty) {
            Carried = clicked.CopyWithCount(shift ? clicked.MaxStackSize : clicked.Count);
        }
        else if (button == 0) {
            Carried = Stack.Empty;
        }
        else if (!carried.IsEmpty) {
            carried.Shrink(1);
        }
    }

    /// <summary>
    /// A click on one of the player's slots runs the inventory menu's own click, then sends each slot
    /// it changed, which is what the creative listener on vanilla's inventory menu does.
    /// </summary>
    private void PlayerSlotClicked(int menuSlot, int button, bool shift) =>
        PlayerSlotClicked(menuSlot, button, button == 2 ? ContainerInput.Clone : shift ? ContainerInput.QuickMove : ContainerInput.Pickup);

    private void PlayerSlotClicked(int menuSlot, int button, ContainerInput input) {
        InventoryMenu menu = _client.Inventory.Menu;
        Stack[] before = menu.Slots.Select(s => s.Item.Copy()).ToArray();
        menu.Clicked(menuSlot, button, input, _client.MenuUser);
        for (int i = 0; i < menu.Slots.Count; i++) {
            if (!Stack.Matches(before[i], menu.Slots[i].Item)) {
                _client.SetCreativeSlot(i, menu.Slots[i].Item.ToItemStack());
            }
        }
    }

    public override void Scroll(GuiContext context, float delta) => _palette.ScrollBy(delta, _filtered.Count);

    /// <summary><c>charTyped</c>: only the search tab's box takes characters, and not one whose key did something else.</summary>
    public override void Char(GuiContext context, char c) {
        if (_ignoreTextInput || !HasFocusedEditBox || !EditBox.IsAllowedChatCharacter(c) || _search.Length >= 50) {
            return;
        }
        _search += c;
        Refilter();
    }

    /// <summary>
    /// <c>keyPressed</c>. On the search tab the box has the keyboard and takes every key but Escape, a number
    /// over an item or the hotbar excepted, which swaps instead. On another tab the chat key opens the search
    /// tab and the keys are a container screen's.
    /// </summary>
    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        _ignoreTextInput = false;
        KeyBinds binds = context.Settings!.Keys;
        int cell = HoveredCell();
        int? playerSlot = HoveredPlayerSlot();
        if (!HasFocusedEditBox) {
            if (!_inventoryTab && binds.Chat.Matches(key)) {
                _ignoreTextInput = true;
                SelectTab(false, true);
                return;
            }
            ContainerKeyPressed(context, binds, key, control, cell, playerSlot);
            return;
        }
        bool doQuickSwap = cell < 0 || PaletteItem(cell) != null;
        bool pressingNumber = key is >= Key.Number0 and <= Key.Number9 or >= Key.Keypad0 and <= Key.Keypad9;
        if (doQuickSwap && pressingNumber && CheckHotbarKeyPressed(binds, key, cell, playerSlot)) {
            _ignoreTextInput = true;
            return;
        }
        if (key == Key.Backspace && _search.Length > 0) {
            _search = _search[..^1];
            Refilter();
        }
        if (key == Key.Escape) {
            Close(context);
        }
    }

    public override void KeyUp(GuiContext context, Key key) => _ignoreTextInput = false;

    /// <summary><c>AbstractContainerScreen.keyPressed</c> on an ordinary tab.</summary>
    private void ContainerKeyPressed(GuiContext context, KeyBinds binds, Key key, bool control, int cell, int? playerSlot) {
        if (key == Key.Escape || binds.Inventory.Matches(key)) {
            Close(context);
            return;
        }
        CheckHotbarKeyPressed(binds, key, cell, playerSlot);
        if (playerSlot is not { } menuSlot || _client.Inventory.Menu.Slots[menuSlot].Item.IsEmpty) {
            if (PaletteItem(cell) is { } item && binds.Drop.Matches(key)) {
                // The palette's THROW: a copy goes, nothing leaves the palette.
                Stack copy = Stack.Of(new ItemStack(item));
                _client.SetCreativeSlot(-1, copy.CopyWithCount(control ? copy.MaxStackSize : 1).ToItemStack());
            }
            else if (PaletteItem(cell) is { } picked && binds.PickItem.Matches(key) && Carried.IsEmpty) {
                Stack copy = Stack.Of(new ItemStack(picked));
                Carried = copy.CopyWithCount(copy.MaxStackSize);
            }
            return;
        }
        if (binds.PickItem.Matches(key)) {
            PlayerSlotClicked(menuSlot, 0, ContainerInput.Clone);
        }
        else if (binds.Drop.Matches(key)) {
            // The inventory tab's THROW: the dropped part as a drop, then what is left in its slot. Vanilla's other
            // tabs throw a hotbar item through the picker menu instead; this client has only the one path.
            Slot slot = _client.Inventory.Menu.Slots[menuSlot];
            Stack toDrop = slot.Item.Split(control ? slot.Item.MaxStackSize : 1);
            _client.SetCreativeSlot(-1, toDrop.ToItemStack());
            _client.SetCreativeSlot(menuSlot, slot.Item.ToItemStack());
        }
    }

    /// <summary>
    /// <c>checkHotbarKeyPressed</c> over the hovered slot while nothing is carried: a palette item copied whole into
    /// the slot of the key, or a player slot swapped with it through the inventory menu.
    /// </summary>
    private bool CheckHotbarKeyPressed(KeyBinds binds, Key key, int cell, int? playerSlot) {
        if (!Carried.IsEmpty || cell < 0 && playerSlot == null) {
            return false;
        }
        int button = binds.SwapOffhand.Matches(key) ? 40 : Array.FindIndex(binds.Hotbar, b => b.Matches(key));
        if (button < 0) {
            return false;
        }
        if (playerSlot is { } menuSlot) {
            PlayerSlotClicked(menuSlot, button, ContainerInput.Swap);
        }
        else if (PaletteItem(cell) is { } item) {
            Stack copy = Stack.Of(new ItemStack(item));
            int target = button == 40 ? PlayerInventory.OffhandSlot : PlayerInventory.HotbarStart + button;
            _client.Inventory.Menu.Slots[target].Set(copy.CopyWithCount(copy.MaxStackSize));
            _client.SetCreativeSlot(target, _client.Inventory.Menu.Slots[target].Item.ToItemStack());
        }
        return true;
    }

    private int HoveredCell() => _inventoryTab ? -1 : _palette.CellAt(MouseX - _left, MouseY - _top);

    private IItem? PaletteItem(int cell) => cell >= 0 && _palette.IndexOf(cell) < _filtered.Count ? _filtered[_palette.IndexOf(cell)] : null;

    private int? HoveredPlayerSlot() {
        foreach ((int menuSlot, float sx, float sy) in PlayerSlots()) {
            if (Inside(MouseX, MouseY, _left + sx - 1, _top + sy - 1, 18, 18)) {
                return menuSlot;
            }
        }
        return null;
    }

    /// <summary><c>selectTab</c>: changing tab empties the search, and only the search tab has the box focused.</summary>
    private void SelectTab(bool inventory, bool search) {
        if (inventory != _inventoryTab || search != _searchTab) {
            _search = "";
            _filtered = _allItems;
            _palette.Reset();
        }
        _inventoryTab = inventory;
        _searchTab = search;
    }

    private void Refilter() {
        _palette.Reset();
        string query = _search.Trim().ToLowerInvariant();
        _filtered = query.Length == 0
            ? _allItems
            : _allItems.Where(item => item.Identifier.Key.Replace('_', ' ').Contains(query)
                                      || TextFlattener.Plain(ItemNames.HoverName(new ItemStack(item, 1))).Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    /// <summary>Vanilla's creative screen is a container screen, so closing it sends a close for window 0.</summary>
    public override void Close(GuiContext context) {
        _client.CreativeInventoryOpen = false;
        Carried = Stack.Empty;
        _client.CloseContainer();
        base.Close(context);
    }
}
