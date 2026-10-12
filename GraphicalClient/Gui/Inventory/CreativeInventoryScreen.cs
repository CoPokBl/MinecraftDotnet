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
        context.Text.Draw(_search.Length > 0 ? _search : Translations.Get("itemGroup.search.hint")!, _left + 83, _top + 6, _search.Length > 0 ? 0xFFFFFFFFu : 0xFF707070u, false);
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
            _inventoryTab = false;
            return;
        }
        if (Inside(x, y, _left + 42, _top - 18, 56, 16)) {
            _inventoryTab = true;
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
    private void PlayerSlotClicked(int menuSlot, int button, bool shift) {
        InventoryMenu menu = _client.Inventory.Menu;
        Stack[] before = menu.Slots.Select(s => s.Item.Copy()).ToArray();
        ContainerInput input = button == 2 ? ContainerInput.Clone : shift ? ContainerInput.QuickMove : ContainerInput.Pickup;
        menu.Clicked(menuSlot, button, input, _client.MenuUser);
        for (int i = 0; i < menu.Slots.Count; i++) {
            if (!Stack.Matches(before[i], menu.Slots[i].Item)) {
                _client.SetCreativeSlot(i, menu.Slots[i].Item.ToItemStack());
            }
        }
    }

    public override void Scroll(GuiContext context, float delta) => _palette.ScrollBy(delta, _filtered.Count);

    public override void Char(GuiContext context, char c) {
        if (c < ' ' || _search.Length >= 50) {
            return;
        }
        _search += c;
        Refilter();
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        switch (key) {
            case Key.Backspace when _search.Length > 0:
                _search = _search[..^1];
                Refilter();
                return;
            case Key.E when _search.Length == 0:
            case Key.Escape:
                Close(context);
                return;
        }
    }

    private void Refilter() {
        _inventoryTab = false;
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
