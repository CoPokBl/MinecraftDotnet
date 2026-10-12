using ClientLib;
using ClientLib.Inventory;
using ClientLib.Player;
using Silk.NET.Input;
using Slot = ClientLib.Inventory.Slot;

namespace GraphicalClient.Gui.Inventory;

/// <summary>
/// Vanilla's <c>AbstractContainerScreen</c>: draws a menu's slots on a panel and turns the mouse into
/// container clicks the way vanilla does. A press with nothing held clicks straight away; a press
/// holding something starts a drag, and what the release does depends on whether the drag crossed
/// any slots. A second press on the same slot within a quarter second is a double click.
/// </summary>
public abstract class ContainerScreen : Screen {
    private const long DoubleClickMs = 250;

    /// <summary>Set once by the window: whether either shift key is down.</summary>
    public static Func<bool> ShiftHeld { get; set; } = () => false;

    protected MinecraftClient Client { get; }
    protected ContainerMenu Menu { get; }

    protected float Left { get; private set; }
    protected float Top { get; private set; }

    public virtual int ImageWidth => 176;
    public virtual int ImageHeight => 166;

    /// <summary>Where "Inventory" goes, or null for menus without the player's inventory.</summary>
    protected virtual (int X, int Y)? InventoryLabel => (8, ImageHeight - 94);
    protected virtual (int X, int Y) TitleLabel => (8, 6);
    protected virtual bool ShowsTitle => true;

    private bool _isQuickCrafting;
    private int _quickCraftingButton;
    private int _quickCraftingType;
    private readonly List<Slot> _quickCraftSlots = [];
    private int _quickCraftingRemainder;
    private bool _skipNextRelease;
    private bool _doubleClick;
    private Slot? _lastClickSlot;
    private long _lastClickTime;
    private int _lastClickButton = -1;
    private Stack _lastQuickMoved = Stack.Empty;

    protected ContainerScreen(MinecraftClient client, ContainerMenu menu) {
        Client = client;
        Menu = menu;
    }

    public override bool ShowsHud => false;

    public override bool IsAllowedInPortal => false;

    protected override void Init(GuiContext context, int width, int height) {
        Left = (width - ImageWidth) / 2;
        Top = (height - ImageHeight) / 2;
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        context.Gui.Rect(0, 0, context.Width, context.Height, 0x80101010);
        DrawBesidePanel(context);
        if (DrawPackBackground(context)) {
            DrawPackOverlay(context);
        }
        else {
            Panel.Draw(context, Left, Top, ImageWidth, ImageHeight);
            DrawBackground(context);
            foreach (Slot slot in Menu.Slots) {
                if (DrawsSlot(slot)) {
                    Panel.Slot(context, Left + slot.X, Top + slot.Y);
                }
            }
        }

        if (Menu.Title != null && ShowsTitle) {
            context.Text.Draw(TextFlattener.Flatten(Menu.Title, (int)(Panel.Label & 0xFFFFFF)), Left + TitleLabel.X, Top + TitleLabel.Y, shadow: false);
        }
        if (InventoryLabel is { } label) {
            context.Text.Draw("Inventory", Left + label.X, Top + label.Y, Panel.Label, false);
        }
        DrawForeground(context);

        Slot? hovered = HoveredSlot(MouseX, MouseY);
        Stack carried = Menu.Carried;
        foreach (Slot slot in Menu.Slots) {
            if (!DrawsSlot(slot)) {
                continue;
            }
            Stack item = slot.Item;
            if (_isQuickCrafting && _quickCraftSlots.Contains(slot) && !carried.IsEmpty) {
                // The count the drag will leave here, drawn as if already placed.
                context.Gui.Rect(Left + slot.X, Top + slot.Y, 16, 16, 0x80FFFFFF);
                GuiItems.Draw(context, carried.CopyWithCount(DragCount(slot, carried)).ToItemStack(), Left + slot.X, Top + slot.Y);
                continue;
            }
            GuiItems.Draw(context, item.ToItemStack(), Left + slot.X, Top + slot.Y, slot.X + slot.Y * ImageWidth, HeldIn(slot));
            DrawSlotOverlay(context, slot);
        }
        if (hovered != null && DrawsSlot(hovered)) {
            context.Gui.Rect(Left + hovered.X, Top + hovered.Y, 16, 16, 0x80FFFFFF);
        }

        DrawOverlay(context);

        if (!carried.IsEmpty) {
            int count = _isQuickCrafting && _quickCraftSlots.Count > 1 ? _quickCraftingRemainder : carried.Count;
            if (count > 0) {
                GuiItems.Draw(context, carried.CopyWithCount(count).ToItemStack(), MouseX - 8, MouseY - 8, carried: true);
            }
        }
        else if (hovered != null && hovered.HasItem) {
            Tooltips.Draw(context, Tooltips.Lines(hovered.Item.ToItemStack()), MouseX, MouseY);
        }
        else {
            DrawHoverTooltip(context);
        }
    }

    /// <summary>Drawn before the panel, for what sits beside it such as the effect list.</summary>
    protected virtual void DrawBesidePanel(GuiContext context) {
    }

    /// <summary>Panel art behind the slots: progress arrows, flames, text boxes.</summary>
    protected virtual void DrawBackground(GuiContext context) {
    }

    /// <summary>
    /// The vanilla background texture this screen's layout matches, which replaces the built in panel
    /// and slot frames when a resource pack has it.
    /// </summary>
    protected virtual string? PackBackground => null;

    /// <summary>Draws the pack's background, true when it could. A screen whose texture is laid out in pieces overrides it.</summary>
    protected virtual bool DrawPackBackground(GuiContext context) =>
        PackBackground is { } texture && context.Sprites.Region(context.Gui, texture, Left, Top, 0, 0, ImageWidth, ImageHeight);

    /// <summary>Over a pack background: the parts that change, from the pack's own sprites.</summary>
    protected virtual void DrawPackOverlay(GuiContext context) {
    }

    /// <summary>Labels and widgets over the panel, before the items.</summary>
    protected virtual void DrawForeground(GuiContext context) {
    }

    /// <summary>Anything drawn over a slot's item, such as a crafter slot being switched off.</summary>
    protected virtual void DrawSlotOverlay(GuiContext context, Slot slot) {
    }

    /// <summary>Drawn after the items and before the cursor.</summary>
    protected virtual void DrawOverlay(GuiContext context) {
    }

    /// <summary>A tooltip for a widget the cursor is over, when it is not over an item.</summary>
    protected virtual void DrawHoverTooltip(GuiContext context) {
    }

    protected virtual bool DrawsSlot(Slot slot) => !slot.IsFake || slot.HasItem;

    /// <summary>Whether the menu's result slot holds something, which lights the arrow into it.</summary>
    protected bool ResultShown {
        get {
            foreach (Slot slot in Menu.Slots) {
                if (slot is OutputSlot or CraftingResultSlot && slot.HasItem) {
                    return true;
                }
            }
            return false;
        }
    }

    private Slot? HoveredSlot(float x, float y) {
        foreach (Slot slot in Menu.Slots) {
            if (!DrawsSlot(slot)) {
                continue;
            }
            float sx = x - Left, sy = y - Top;
            if (sx >= slot.X - 1 && sx < slot.X + 17 && sy >= slot.Y - 1 && sy < slot.Y + 17) {
                return slot;
            }
        }
        return null;
    }

    protected virtual bool ClickedOutside(float x, float y) => x < Left || y < Top || x >= Left + ImageWidth || y >= Top + ImageHeight;

    /// <summary>A click the screen's own widgets take before slots see it.</summary>
    protected virtual bool WidgetClicked(GuiContext context, float x, float y, MouseButton button) => ClickWidgets(context, x, y, button);

    private static int ButtonOf(MouseButton button) => button switch {
        MouseButton.Left => 0,
        MouseButton.Right => 1,
        MouseButton.Middle => 2,
        _ => (int)button
    };

    protected void SlotClicked(Slot? slot, int slotId, int button, ContainerInput input) {
        if (slot != null) {
            slotId = slot.Index;
        }
        Client.ClickContainer(slotId, button, input);
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton mouseButton) {
        LayOut(context);
        SetMouse(x, y);
        if (WidgetClicked(context, x, y, mouseButton)) {
            return;
        }
        int button = ButtonOf(mouseButton);

        long now = Environment.TickCount64;
        bool cloning = button == 2 && Client.MenuUser.InfiniteMaterials;
        Slot? slot = HoveredSlot(x, y);
        bool doubleClick = button == _lastClickButton && now - _lastClickTime < DoubleClickMs;
        _doubleClick = _lastClickSlot == slot && doubleClick;
        _lastClickTime = now;
        _lastClickButton = button;
        _skipNextRelease = false;

        if (button != 0 && button != 1 && !cloning) {
            _lastClickSlot = slot;
            return;
        }

        int slotId = slot?.Index ?? -1;
        if (ClickedOutside(x, y)) {
            slotId = -999;
        }

        if (slotId != -1 && !_isQuickCrafting) {
            if (Menu.Carried.IsEmpty) {
                if (cloning) {
                    SlotClicked(slot, slotId, button, ContainerInput.Clone);
                }
                else {
                    bool quickKey = slotId != -999 && ShiftHeld();
                    ContainerInput input = ContainerInput.Pickup;
                    if (quickKey) {
                        _lastQuickMoved = slot is { HasItem: true } ? slot.Item.Copy() : Stack.Empty;
                        input = ContainerInput.QuickMove;
                    }
                    else if (slotId == -999) {
                        input = ContainerInput.Throw;
                    }
                    if (!OverridesClick(context, slot, button, input)) {
                        SlotClicked(slot, slotId, button, input);
                    }
                }
                _skipNextRelease = true;
            }
            else {
                _isQuickCrafting = true;
                _quickCraftingButton = button;
                _quickCraftSlots.Clear();
                _quickCraftingType = Math.Min(button, 2);
            }
        }
        _lastClickSlot = slot;
    }

    /// <summary>A screen that does something other than a click on a slot, as the crafter's toggles do.</summary>
    protected virtual bool OverridesClick(GuiContext context, Slot? slot, int button, ContainerInput input) => false;

    /// <summary><c>mouseDragged</c>: a held press crossing slots adds them to the drag.</summary>
    public override void MouseMove(GuiContext context, float x, float y) {
        SetMouse(x, y);
        if (!_isQuickCrafting) {
            return;
        }
        Slot? slot = HoveredSlot(x, y);
        Stack carried = Menu.Carried;
        if (slot != null && ShouldAddToQuickCraft(slot, carried) && !_quickCraftSlots.Contains(slot)) {
            _quickCraftSlots.Add(slot);
            RecalculateQuickCraftRemaining();
        }
    }

    private bool ShouldAddToQuickCraft(Slot slot, Stack carried) {
        return !carried.IsEmpty && (carried.Count > _quickCraftSlots.Count || _quickCraftingType == 2)
               && ContainerMenu.CanItemQuickReplace(slot, carried, true) && slot.MayPlace(carried) && Menu.CanDragTo(slot);
    }

    private void RecalculateQuickCraftRemaining() {
        Stack carried = Menu.Carried;
        if (carried.IsEmpty || !_isQuickCrafting) {
            return;
        }
        if (_quickCraftingType == 2) {
            _quickCraftingRemainder = carried.MaxStackSize;
            return;
        }
        _quickCraftingRemainder = carried.Count;
        foreach (Slot slot in _quickCraftSlots) {
            _quickCraftingRemainder -= DragCount(slot, carried) - (slot.Item.IsEmpty ? 0 : slot.Item.Count);
        }
    }

    /// <summary>What a slot will hold once the drag places into it.</summary>
    private int DragCount(Slot slot, Stack carried) {
        int carry = slot.Item.IsEmpty ? 0 : slot.Item.Count;
        int max = Math.Min(carried.MaxStackSize, slot.MaxStackSizeFor(carried));
        return Math.Min(ContainerMenu.QuickCraftPlaceCount(_quickCraftSlots.Count, _quickCraftingType, carried) + carry, max);
    }

    /// <summary><c>mouseReleased</c>.</summary>
    public override void MouseUp(GuiContext context, float x, float y, MouseButton mouseButton) {
        LayOut(context);
        SetMouse(x, y);
        int button = ButtonOf(mouseButton);
        Slot? slot = HoveredSlot(x, y);
        int slotId = slot?.Index ?? -1;
        if (ClickedOutside(x, y)) {
            slotId = -999;
        }

        if (_doubleClick && slot != null && button == 0 && Menu.CanTakeItemForPickAll(Stack.Empty, slot)) {
            if (ShiftHeld()) {
                if (!_lastQuickMoved.IsEmpty) {
                    foreach (Slot target in Menu.Slots) {
                        if (target.MayPickup(Client.MenuUser) && target.HasItem && target.Container == slot.Container
                            && ContainerMenu.CanItemQuickReplace(target, _lastQuickMoved, true)) {
                            SlotClicked(target, target.Index, button, ContainerInput.QuickMove);
                        }
                    }
                }
            }
            else {
                SlotClicked(slot, slotId, button, ContainerInput.PickupAll);
            }
            _doubleClick = false;
        }
        else {
            if (_isQuickCrafting && _quickCraftingButton != button) {
                _isQuickCrafting = false;
                _quickCraftSlots.Clear();
                _skipNextRelease = true;
                return;
            }
            if (_skipNextRelease) {
                _skipNextRelease = false;
                return;
            }
            if (_isQuickCrafting && _quickCraftSlots.Count > 0) {
                SlotClicked(null, -999, ContainerMenu.QuickcraftMask(0, _quickCraftingType), ContainerInput.QuickCraft);
                foreach (Slot target in _quickCraftSlots) {
                    SlotClicked(target, target.Index, ContainerMenu.QuickcraftMask(1, _quickCraftingType), ContainerInput.QuickCraft);
                }
                SlotClicked(null, -999, ContainerMenu.QuickcraftMask(2, _quickCraftingType), ContainerInput.QuickCraft);
            }
            else if (!Menu.Carried.IsEmpty) {
                if (button == 2 && Client.MenuUser.InfiniteMaterials) {
                    SlotClicked(slot, slotId, button, ContainerInput.Clone);
                }
                else {
                    bool quickKey = slotId != -999 && ShiftHeld();
                    if (quickKey) {
                        _lastQuickMoved = slot is { HasItem: true } ? slot.Item.Copy() : Stack.Empty;
                    }
                    SlotClicked(slot, slotId, button, quickKey ? ContainerInput.QuickMove : ContainerInput.Pickup);
                }
            }
        }
        _isQuickCrafting = false;
        _quickCraftSlots.Clear();
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (key is Key.Escape or Key.E) {
            Close(context);
            return;
        }
        Slot? hovered = HoveredSlot(MouseX, MouseY);
        if (Menu.Carried.IsEmpty && hovered != null) {
            if (key == Key.F) {
                SlotClicked(hovered, hovered.Index, 40, ContainerInput.Swap);
                return;
            }
            if (key is >= Key.Number1 and <= Key.Number9) {
                SlotClicked(hovered, hovered.Index, key - Key.Number1, ContainerInput.Swap);
                return;
            }
        }
        if (hovered is { HasItem: true } && key == Key.Q) {
            SlotClicked(hovered, hovered.Index, control ? 1 : 0, ContainerInput.Throw);
        }
    }

    /// <summary>Closing from the client tells the server, as <c>LocalPlayer.closeContainer</c> does.</summary>
    public override void Close(GuiContext context) {
        Client.CloseContainer();
        base.Close(context);
    }

    /// <summary>The server closed the menu itself; nothing is sent back.</summary>
    public void ClosedByServer() => Closed = true;

    /// <summary>The player's hand a slot's stack is in, for item models that ask whether the player holds or uses it.</summary>
    private static Minecraft.Schemas.Hand? HeldIn(Slot slot) => slot.Container is PlayerInventory inventory
        ? slot.ContainerSlot == inventory.SelectedSlot ? Minecraft.Schemas.Hand.MainHand
        : slot.ContainerSlot == PlayerInventory.OffhandIndex ? Minecraft.Schemas.Hand.OffHand : null
        : null;
}
