using ClientLib.Inventory;
using Minecraft.Data.Inventories;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace ClientLib.Player;

/// <summary>Vanilla's <c>ContainerInput</c>, the click types a container click packet names.</summary>
public enum ContainerInput {
    Pickup = 0,
    QuickMove = 1,
    Swap = 2,
    Clone = 3,
    Throw = 4,
    QuickCraft = 5,
    PickupAll = 6
}

/// <summary>
/// Vanilla's <c>AbstractContainerMenu</c> as the client runs it: the slots of an open screen and
/// the prediction of what a click does to them, so the click packet can say what changed. The click
/// logic is a transcription; the server runs the same code and corrects any slot that disagrees.
/// </summary>
public abstract class ContainerMenu(int windowId, IInventoryType? type, TextComponent? title, MenuData data) {
    private readonly List<Slot> _slots = [];
    private int _quickcraftType = -1;
    private int _quickcraftStatus;
    private readonly List<Slot> _quickcraftSlots = [];

    public int WindowId { get; } = windowId;
    public IInventoryType? Type { get; } = type;
    public TextComponent? Title { get; } = title;
    public IReadOnlyList<Slot> Slots => _slots;
    public Stack Carried { get; set; } = Stack.Empty;
    public int StateId { get; set; }

    /// <summary>The menu's data slots, set by <c>container_set_data</c>: furnace progress, anvil cost and the like.</summary>
    public Dictionary<int, int> Properties { get; } = new();

    protected MenuData Data { get; } = data;

    public int Property(int id) => Properties.GetValueOrDefault(id);

    protected Slot AddSlot(Slot slot) {
        slot.Index = _slots.Count;
        _slots.Add(slot);
        return slot;
    }

    /// <summary>A grid of slots 18 pixels apart over consecutive container slots from <paramref name="first"/>.</summary>
    protected void AddSlotGrid(Container container, int columns, int rows, int left, int top, int first = 0,
        Func<Container, int, int, int, Slot>? create = null) {
        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < columns; x++) {
                int index = first + x + y * columns, slotX = left + x * 18, slotY = top + y * 18;
                AddSlot(create?.Invoke(container, index, slotX, slotY) ?? new Slot(container, index, slotX, slotY));
            }
        }
    }

    /// <summary><c>addStandardInventorySlots</c>: the three main rows, then the hotbar 58 pixels below them.</summary>
    protected void AddStandardInventorySlots(PlayerInventory inventory, int left, int top) {
        AddSlotGrid(inventory, 9, 3, left, top, 9);
        AddSlotGrid(inventory, 9, 1, left, top + 58);
    }

    /// <summary><c>initializeContents</c>, from <c>container_set_content</c>.</summary>
    public void InitializeContents(int stateId, IReadOnlyList<ItemStack> items, ItemStack carried) {
        for (int i = 0; i < items.Count && i < _slots.Count; i++) {
            _slots[i].Set(Stack.Of(items[i]));
        }
        Carried = Stack.Of(carried);
        StateId = stateId;
    }

    /// <summary><c>setItem</c>, from <c>container_set_slot</c>.</summary>
    public void SetItem(int slot, int stateId, ItemStack item) {
        if (slot >= 0 && slot < _slots.Count) {
            _slots[slot].Set(Stack.Of(item));
        }
        StateId = stateId;
    }

    /// <summary><c>quickMoveStack</c>: the prologue and tail every menu shares around the menu's own branches.</summary>
    public Stack QuickMoveStack(IMenuUser user, int slotIndex) {
        Slot slot = Slots[slotIndex];
        if (!slot.HasItem) {
            return Stack.Empty;
        }
        Stack stack = slot.Item;
        Stack clicked = stack.Copy();
        if (!QuickMove(slotIndex, stack)) {
            return Stack.Empty;
        }
        if (stack.IsEmpty) {
            slot.SetByPlayer(Stack.Empty);
        }
        if (!QuickMoveTakes) {
            return clicked;
        }
        if (stack.Count == clicked.Count) {
            return Stack.Empty;
        }
        slot.OnTake(user, stack);
        return clicked;
    }

    /// <summary>The menu's own <c>quickMoveStack</c> branches; false is one of vanilla's early <c>return ItemStack.EMPTY</c>s.</summary>
    protected abstract bool QuickMove(int slotIndex, Stack stack);

    /// <summary>False for the menus whose <c>quickMoveStack</c> ends without the count check and the slot's take.</summary>
    protected virtual bool QuickMoveTakes => true;

    /// <summary>
    /// The fallback most <c>quickMoveStack</c>s end with, for an inventory whose 27 main slots start at
    /// <paramref name="start"/>: main rows to the hotbar and back. Any other slot moves nowhere, or with
    /// <paramref name="orAnywhere"/> into the whole inventory.
    /// </summary>
    protected bool MoveWithinInventory(Stack stack, int slotIndex, int start, bool orAnywhere = false) {
        int hotbar = start + 27, end = hotbar + 9;
        if (slotIndex >= start && slotIndex < hotbar) {
            return MoveItemStackTo(stack, hotbar, end, false);
        }
        if (slotIndex >= hotbar && slotIndex < end) {
            return MoveItemStackTo(stack, start, hotbar, false);
        }
        return !orAnywhere || MoveItemStackTo(stack, start, end, false);
    }

    public virtual bool CanTakeItemForPickAll(Stack carried, Slot target) => true;

    public virtual bool CanDragTo(Slot slot) => true;

    /// <summary><c>AbstractContainerMenu.doClick</c>.</summary>
    public void Clicked(int slotIndex, int buttonNum, ContainerInput input, IMenuUser user) {
        PlayerInventory inventory = user.Inventory;
        if (input == ContainerInput.QuickCraft) {
            int expectedStatus = _quickcraftStatus;
            _quickcraftStatus = QuickcraftHeader(buttonNum);
            if ((expectedStatus != 1 || _quickcraftStatus != 2) && expectedStatus != _quickcraftStatus) {
                ResetQuickCraft();
            }
            else if (Carried.IsEmpty) {
                ResetQuickCraft();
            }
            else if (_quickcraftStatus == 0) {
                _quickcraftType = QuickcraftTypeOf(buttonNum);
                if (IsValidQuickcraftType(_quickcraftType, user)) {
                    _quickcraftStatus = 1;
                    _quickcraftSlots.Clear();
                }
                else {
                    ResetQuickCraft();
                }
            }
            else if (_quickcraftStatus == 1) {
                Slot slot = _slots[slotIndex];
                Stack carried = Carried;
                if (CanItemQuickReplace(slot, carried, true) && slot.MayPlace(carried)
                    && (_quickcraftType == 2 || carried.Count > _quickcraftSlots.Count) && CanDragTo(slot)
                    && !_quickcraftSlots.Contains(slot)) {
                    _quickcraftSlots.Add(slot);
                }
            }
            else if (_quickcraftStatus == 2) {
                if (_quickcraftSlots.Count > 0) {
                    if (_quickcraftSlots.Count == 1) {
                        int single = _quickcraftSlots[0].Index;
                        ResetQuickCraft();
                        Clicked(single, _quickcraftType, ContainerInput.Pickup, user);
                        return;
                    }

                    Stack source = Carried.Copy();
                    if (source.IsEmpty) {
                        ResetQuickCraft();
                        return;
                    }

                    int remaining = Carried.Count;
                    foreach (Slot slot in _quickcraftSlots) {
                        Stack carried = Carried;
                        if (CanItemQuickReplace(slot, carried, true) && slot.MayPlace(carried)
                            && (_quickcraftType == 2 || carried.Count >= _quickcraftSlots.Count) && CanDragTo(slot)) {
                            int carry = slot.HasItem ? slot.Item.Count : 0;
                            int maxSize = Math.Min(source.MaxStackSize, slot.MaxStackSizeFor(source));
                            int newCount = Math.Min(QuickCraftPlaceCount(_quickcraftSlots.Count, _quickcraftType, source) + carry, maxSize);
                            remaining -= newCount - carry;
                            slot.SetByPlayer(source.CopyWithCount(newCount));
                        }
                    }

                    source.Count = remaining;
                    Carried = source;
                }
                ResetQuickCraft();
            }
            else {
                ResetQuickCraft();
            }
        }
        else if (_quickcraftStatus != 0) {
            ResetQuickCraft();
        }
        else if (input is ContainerInput.Pickup or ContainerInput.QuickMove && buttonNum is 0 or 1) {
            bool primary = buttonNum == 0;
            if (slotIndex == -999) {
                if (!Carried.IsEmpty) {
                    if (primary) {
                        user.Drop(Carried);
                        Carried = Stack.Empty;
                    }
                    else {
                        user.Drop(Carried.Split(1));
                    }
                }
            }
            else if (input == ContainerInput.QuickMove) {
                if (slotIndex < 0) {
                    return;
                }
                Slot slot = _slots[slotIndex];
                if (!slot.MayPickup(user)) {
                    return;
                }
                Stack clicked = QuickMoveStack(user, slotIndex);
                while (!clicked.IsEmpty && Stack.IsSameItem(slot.Item, clicked)) {
                    clicked = QuickMoveStack(user, slotIndex);
                }
            }
            else {
                if (slotIndex < 0) {
                    return;
                }
                Slot slot = _slots[slotIndex];
                Stack clicked = slot.Item;
                Stack carried = Carried;
                // tryItemClickBehaviourOverride is bundles stacking onto and out of slots, which is not ported.
                if (clicked.IsEmpty) {
                    if (!carried.IsEmpty) {
                        int amount = primary ? carried.Count : 1;
                        Carried = slot.SafeInsert(carried, amount);
                    }
                }
                else if (slot.MayPickup(user)) {
                    if (carried.IsEmpty) {
                        int amount = primary ? clicked.Count : (clicked.Count + 1) / 2;
                        Stack? taken = slot.TryRemove(amount, int.MaxValue, user);
                        if (taken != null) {
                            Carried = taken;
                            slot.OnTake(user, taken);
                        }
                    }
                    else if (slot.MayPlace(carried)) {
                        if (Stack.IsSameItemSameComponents(clicked, carried)) {
                            int amount = primary ? carried.Count : 1;
                            Carried = slot.SafeInsert(carried, amount);
                        }
                        else if (carried.Count <= slot.MaxStackSizeFor(carried)) {
                            Carried = clicked;
                            slot.SetByPlayer(carried);
                        }
                    }
                    else if (Stack.IsSameItemSameComponents(clicked, carried)) {
                        Stack? taken = slot.TryRemove(clicked.Count, carried.MaxStackSize - carried.Count, user);
                        if (taken != null) {
                            carried.Grow(taken.Count);
                            slot.OnTake(user, taken);
                        }
                    }
                }
            }
        }
        else if (input == ContainerInput.Swap && (buttonNum is >= 0 and < 9 || buttonNum == 40)) {
            Stack source = inventory.Get(buttonNum);
            Slot target = _slots[slotIndex];
            Stack targetStack = target.Item;
            if (!source.IsEmpty || !targetStack.IsEmpty) {
                if (source.IsEmpty) {
                    if (target.MayPickup(user)) {
                        inventory.Set(buttonNum, targetStack);
                        target.SetByPlayer(Stack.Empty);
                        target.OnTake(user, targetStack);
                    }
                }
                else if (targetStack.IsEmpty) {
                    if (target.MayPlace(source)) {
                        int maxStackSize = target.MaxStackSizeFor(source);
                        if (source.Count > maxStackSize) {
                            target.SetByPlayer(source.Split(maxStackSize));
                        }
                        else {
                            inventory.Set(buttonNum, Stack.Empty);
                            target.SetByPlayer(source);
                        }
                    }
                }
                else if (target.MayPickup(user) && target.MayPlace(source)) {
                    int maxStackSize = target.MaxStackSizeFor(source);
                    if (source.Count > maxStackSize) {
                        target.SetByPlayer(source.Split(maxStackSize));
                        target.OnTake(user, targetStack);
                        if (!inventory.Add(targetStack)) {
                            user.Drop(targetStack);
                        }
                    }
                    else {
                        inventory.Set(buttonNum, targetStack);
                        target.SetByPlayer(source);
                        target.OnTake(user, targetStack);
                    }
                }
            }
        }
        else if (input == ContainerInput.Clone && user.InfiniteMaterials && Carried.IsEmpty && slotIndex >= 0) {
            Slot slot = _slots[slotIndex];
            if (slot.HasItem) {
                Carried = slot.SafeClone(user);
            }
        }
        else if (input == ContainerInput.Throw && Carried.IsEmpty && slotIndex >= 0) {
            Slot slot = _slots[slotIndex];
            int amount = buttonNum == 0 ? 1 : slot.Item.Count;
            Stack stack = slot.SafeTake(amount, int.MaxValue, user);
            user.Drop(stack);
            if (buttonNum == 1) {
                while (!stack.IsEmpty && Stack.IsSameItem(slot.Item, stack)) {
                    stack = slot.SafeTake(amount, int.MaxValue, user);
                    user.Drop(stack);
                }
            }
        }
        else if (input == ContainerInput.PickupAll && slotIndex >= 0) {
            Slot slot = _slots[slotIndex];
            Stack carried = Carried;
            if (!carried.IsEmpty && (!slot.HasItem || !slot.MayPickup(user))) {
                int start = buttonNum == 0 ? 0 : _slots.Count - 1;
                int step = buttonNum == 0 ? 1 : -1;
                for (int pass = 0; pass < 2; pass++) {
                    for (int i = start; i >= 0 && i < _slots.Count && carried.Count < carried.MaxStackSize; i += step) {
                        Slot target = _slots[i];
                        if (target.HasItem && CanItemQuickReplace(target, carried, true) && target.MayPickup(user) && CanTakeItemForPickAll(carried, target)) {
                            Stack stack = target.Item;
                            if (pass != 0 || stack.Count != stack.MaxStackSize) {
                                Stack removed = target.SafeTake(stack.Count, carried.MaxStackSize - carried.Count, user);
                                carried.Grow(removed.Count);
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary><c>moveItemStackTo</c>: fills matching stacks first, then the first empty slot.</summary>
    protected bool MoveItemStackTo(Stack stack, int startSlot, int endSlot, bool backwards) {
        bool anythingChanged = false;
        int destSlot = backwards ? endSlot - 1 : startSlot;

        if (stack.IsStackable) {
            while (!stack.IsEmpty && (backwards ? destSlot >= startSlot : destSlot < endSlot)) {
                Slot slot = _slots[destSlot];
                Stack target = slot.Item;
                if (!target.IsEmpty && Stack.IsSameItemSameComponents(stack, target)) {
                    int total = target.Count + stack.Count;
                    int maxStackSize = slot.MaxStackSizeFor(target);
                    if (total <= maxStackSize) {
                        stack.Count = 0;
                        target.Count = total;
                        anythingChanged = true;
                    }
                    else if (target.Count < maxStackSize) {
                        stack.Shrink(maxStackSize - target.Count);
                        target.Count = maxStackSize;
                        anythingChanged = true;
                    }
                }
                destSlot += backwards ? -1 : 1;
            }
        }

        if (!stack.IsEmpty) {
            destSlot = backwards ? endSlot - 1 : startSlot;
            while (backwards ? destSlot >= startSlot : destSlot < endSlot) {
                Slot slot = _slots[destSlot];
                if (slot.Item.IsEmpty && slot.MayPlace(stack)) {
                    int maxStackSize = slot.MaxStackSizeFor(stack);
                    slot.SetByPlayer(stack.Split(Math.Min(stack.Count, maxStackSize)));
                    anythingChanged = true;
                    break;
                }
                destSlot += backwards ? -1 : 1;
            }
        }
        return anythingChanged;
    }

    public static int QuickcraftTypeOf(int mask) => mask >> 2 & 3;
    public static int QuickcraftHeader(int mask) => mask & 3;
    public static int QuickcraftMask(int header, int type) => header & 3 | (type & 3) << 2;

    public static bool IsValidQuickcraftType(int type, IMenuUser user) => type is 0 or 1 || (type == 2 && user.InfiniteMaterials);

    private void ResetQuickCraft() {
        _quickcraftStatus = 0;
        _quickcraftSlots.Clear();
    }

    public static bool CanItemQuickReplace(Slot? slot, Stack stack, bool ignoreSize) {
        bool slotIsEmpty = slot == null || !slot.HasItem;
        return !slotIsEmpty && Stack.IsSameItemSameComponents(stack, slot!.Item)
            ? slot.Item.Count + (ignoreSize ? 0 : stack.Count) <= stack.MaxStackSize
            : slotIsEmpty;
    }

    public static int QuickCraftPlaceCount(int slots, int type, Stack stack) => type switch {
        0 => (int)MathF.Floor((float)stack.Count / slots),
        1 => 1,
        2 => stack.MaxStackSize,
        _ => stack.Count
    };
}

/// <summary>
/// Vanilla's <c>Inventory</c>: 0 to 8 the hotbar, 9 to 35 the rest, 36 to 39 armour feet to head, 40
/// the offhand, 41 body and 42 saddle. <c>set_player_inventory</c> addresses it by these numbers.
/// </summary>
public sealed class PlayerInventory : Container {
    public const int HotbarStart = 36;
    public const int OffhandSlot = 45;
    public const int OffhandIndex = 40;

    private readonly Stack[] _items = Enumerable.Range(0, 43).Select(_ => Stack.Empty).ToArray();

    public override int Size => _items.Length;
    public override Stack Get(int index) => index >= 0 && index < _items.Length ? _items[index] : Stack.Empty;
    public override void Set(int index, Stack stack) {
        if (index >= 0 && index < _items.Length) {
            _items[index] = stack;
        }
    }

    public int SelectedSlot { get; set; }

    /// <summary>The player's own menu, window 0, which is open whenever nothing else is.</summary>
    public InventoryMenu Menu { get; }

    /// <summary>The synchronised tags and item sets every menu of this inventory asks its rules of.</summary>
    public MenuData Data { get; }

    /// <summary>Whichever menu is open, whose carried stack is the cursor.</summary>
    public ContainerMenu ActiveMenu { get; set; }

    public PlayerInventory() : this(new MenuData()) {
    }

    public PlayerInventory(MenuData data) {
        Data = data;
        Menu = new InventoryMenu(this, data);
        ActiveMenu = Menu;
    }

    public ItemStack Hotbar(int index) => _items[index].ToItemStack();
    public ItemStack MainHand => Hotbar(SelectedSlot);
    public ItemStack Offhand => _items[OffhandIndex].ToItemStack();

    public ItemStack Cursor {
        get => ActiveMenu.Carried.ToItemStack();
        set => ActiveMenu.Carried = Stack.Of(value);
    }

    public void SetInventorySlot(int slot, ItemStack item) => Set(slot, Stack.Of(item));

    /// <summary><c>Inventory.add</c>, for what a swap or a craft pushes back into the inventory.</summary>
    public bool Add(Stack stack) {
        if (stack.IsEmpty) {
            return false;
        }
        if (stack.IsDamaged) {
            int free = FreeSlot();
            if (free < 0) {
                return false;
            }
            _items[free] = stack.Copy();
            stack.Count = 0;
            return true;
        }
        int lastSize;
        do {
            lastSize = stack.Count;
            stack.Count = AddResource(stack);
        } while (!stack.IsEmpty && stack.Count < lastSize);
        return stack.Count < lastSize;
    }

    private int FreeSlot() {
        for (int i = 0; i < 36; i++) {
            if (_items[i].IsEmpty) {
                return i;
            }
        }
        return -1;
    }

    private bool HasRemainingSpaceFor(Stack slot, Stack stack) {
        return !slot.IsEmpty && Stack.IsSameItemSameComponents(slot, stack) && slot.IsStackable && slot.Count < Math.Min(MaxStackSize, slot.MaxStackSize);
    }

    private int SlotWithRemainingSpace(Stack stack) {
        if (HasRemainingSpaceFor(_items[SelectedSlot], stack)) {
            return SelectedSlot;
        }
        if (HasRemainingSpaceFor(_items[OffhandIndex], stack)) {
            return OffhandIndex;
        }
        for (int i = 0; i < 36; i++) {
            if (HasRemainingSpaceFor(_items[i], stack)) {
                return i;
            }
        }
        return -1;
    }

    private int AddResource(Stack stack) {
        int slot = SlotWithRemainingSpace(stack);
        if (slot == -1) {
            slot = FreeSlot();
        }
        if (slot == -1) {
            return stack.Count;
        }
        Stack inSlot = _items[slot];
        if (inSlot.IsEmpty) {
            inSlot = stack.CopyWithCount(0);
            _items[slot] = inSlot;
        }
        int toAdd = Math.Min(stack.Count, Math.Min(MaxStackSize, inSlot.MaxStackSize) - inSlot.Count);
        inSlot.Grow(toAdd);
        return stack.Count - toAdd;
    }
}
