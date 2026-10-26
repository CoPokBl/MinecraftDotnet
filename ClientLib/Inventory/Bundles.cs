using System.Runtime.CompilerServices;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Inventory;

/// <summary>
/// <c>BundleContents</c> over the component's item list. Vanilla keeps the selected item on the component
/// instance, outside its equality, codecs and hash; here it is keyed on the list instance, so a stack the
/// server sends has none selected and a copy of a stack shares its original's, as in vanilla.
/// </summary>
public static class BundleContents {
    public const int NoSelectedItemIndex = -1;

    private static readonly ConditionalWeakTable<ItemStack[], StrongBox<int>> SelectedItems = new();
    private static readonly Fraction BundleInBundleWeight = Fraction.Of(1, 16);

    /// <summary>
    /// <c>get(BUNDLE_CONTENTS)</c>. The generated item defaults leave out every empty list, so the
    /// <c>BundleContents.EMPTY</c> a <c>BundleItem</c> is registered with is restated here.
    /// </summary>
    public static ItemStack[]? Of(ItemStack item) =>
        ItemComponents.Get(item, DataComponent.BundleContents)
        ?? (BundleItem.Is(item.Type) && !item.RemoveComponents.Contains(DataComponent.BundleContents) ? [] : null);

    public static int SelectedItemIndex(ItemStack[] contents) =>
        SelectedItems.TryGetValue(contents, out StrongBox<int>? selected) ? selected.Value : NoSelectedItemIndex;

    public static ItemStack? SelectedItem(ItemStack[] contents) => SelectedItemIndex(contents) is var index and not NoSelectedItemIndex ? contents[index] : null;

    public static int NumberOfItemsToShow(ItemStack[] contents) {
        int numberOfItemStacks = contents.Length;
        int availableItemsToShow = numberOfItemStacks > 12 ? 11 : 12;
        int itemsOnNonFullRow = numberOfItemStacks % 4;
        int emptySpaceOnNonFullRow = itemsOnNonFullRow == 0 ? 0 : 4 - itemsOnNonFullRow;
        return Math.Min(numberOfItemStacks, availableItemsToShow - emptySpaceOnNonFullRow);
    }

    /// <summary><c>weight()</c>, null where vanilla's is an error: a weight that overflows an int fraction.</summary>
    public static Fraction? Weight(ItemStack[] contents) {
        try {
            Fraction weight = Fraction.Zero;
            foreach (ItemStack stack in contents) {
                if (GetWeight(stack) is not { } itemWeight) {
                    return null;
                }
                weight = weight.Add(itemWeight.Multiply(Fraction.Of(stack.Count, 1)));
            }
            return weight;
        }
        catch (ArithmeticException) {
            return null;
        }
    }

    /// <summary><c>getWeight</c>: a bundle weighs its contents and a sixteenth, a hive with bees a whole bundle.</summary>
    private static Fraction? GetWeight(ItemStack item) {
        if (Of(item) is { } bundle) {
            return Weight(bundle) is { } nested ? nested.Add(BundleInBundleWeight) : null;
        }
        return ItemComponents.Get(item, DataComponent.Bees) is { Length: > 0 } ? Fraction.One : Fraction.Of(1, item.GetMaxStackSize());
    }

    private static Fraction? GetWeight(Stack item) => GetWeight(item.ToItemStack());

    public static bool CanItemBeInBundle(Stack itemToAdd) => !itemToAdd.IsEmpty && ItemRules.CanFitInsideContainerItems(itemToAdd);

    /// <summary><c>BundleContents.Mutable</c>.</summary>
    public sealed class Mutable {
        private readonly List<Stack> _items;
        private Fraction _weight;
        private int _selectedItem;

        public Mutable(ItemStack[] contents) {
            if (BundleContents.Weight(contents) is not { } weight) {
                _items = [];
                _weight = Fraction.Zero;
                _selectedItem = NoSelectedItemIndex;
            }
            else {
                _items = contents.Select(Stack.Of).ToList();
                _weight = weight;
                _selectedItem = SelectedItemIndex(contents);
            }
        }

        public Fraction Weight => _weight;

        private int FindStackIndex(Stack itemsToAdd) {
            if (!itemsToAdd.IsStackable) {
                return -1;
            }
            for (int i = 0; i < _items.Count; i++) {
                if (Stack.IsSameItemSameComponents(_items[i], itemsToAdd)) {
                    return i;
                }
            }
            return -1;
        }

        private int GetMaxAmountToAdd(Fraction itemWeight) {
            Fraction remainingWeight = Fraction.One.Subtract(_weight);
            return Math.Max(remainingWeight.Divide(itemWeight).IntValue, 0);
        }

        /// <summary><c>tryInsert</c>: how many of <paramref name="itemsToAdd"/> went in, taken off it.</summary>
        public int TryInsert(Stack itemsToAdd) {
            if (!CanItemBeInBundle(itemsToAdd) || GetWeight(itemsToAdd) is not { } itemWeight) {
                return 0;
            }
            int amountToAdd = Math.Min(itemsToAdd.Count, GetMaxAmountToAdd(itemWeight));
            if (amountToAdd == 0) {
                return 0;
            }
            _weight = _weight.Add(itemWeight.Multiply(Fraction.Of(amountToAdd, 1)));
            int stackIndex = FindStackIndex(itemsToAdd);
            if (stackIndex != -1) {
                Stack removedStack = _items[stackIndex];
                _items.RemoveAt(stackIndex);
                Stack mergedStack = removedStack.CopyWithCount(removedStack.Count + amountToAdd);
                itemsToAdd.Shrink(amountToAdd);
                _items.Insert(0, mergedStack);
            }
            else {
                _items.Insert(0, itemsToAdd.Split(amountToAdd));
            }
            return amountToAdd;
        }

        /// <summary><c>tryTransfer</c>: as much of the slot's stack as fits, taken through the slot.</summary>
        public int TryTransfer(Slot slot, IMenuUser player) {
            Stack other = slot.Item;
            if (GetWeight(other) is not { } itemWeight) {
                return 0;
            }
            int maxAmount = GetMaxAmountToAdd(itemWeight);
            return CanItemBeInBundle(other) ? TryInsert(slot.SafeTake(other.Count, maxAmount, player)) : 0;
        }

        public void ToggleSelectedItem(int selectedItem) {
            _selectedItem = _selectedItem != selectedItem && !IndexIsOutsideAllowedBounds(selectedItem) ? selectedItem : NoSelectedItemIndex;
        }

        private bool IndexIsOutsideAllowedBounds(int selectedItem) => selectedItem < 0 || selectedItem >= _items.Count;

        /// <summary><c>removeOne</c>: the selected stack, else the newest, or null from an empty bundle.</summary>
        public Stack? RemoveOne() {
            if (_items.Count == 0) {
                return null;
            }
            int removeIndex = IndexIsOutsideAllowedBounds(_selectedItem) ? 0 : _selectedItem;
            Stack stack = _items[removeIndex].Copy();
            _items.RemoveAt(removeIndex);
            _weight = _weight.Subtract(GetWeight(stack)!.Value.Multiply(Fraction.Of(stack.Count, 1)));
            ToggleSelectedItem(NoSelectedItemIndex);
            return stack;
        }

        public ItemStack[] ToImmutable() {
            ItemStack[] items = new ItemStack[_items.Count];
            for (int i = 0; i < items.Length; i++) {
                items[i] = _items[i].ToItemStack();
            }
            if (_selectedItem != NoSelectedItemIndex) {
                SelectedItems.AddOrUpdate(items, new StrongBox<int>(_selectedItem));
            }
            return items;
        }
    }
}

/// <summary><c>BundleItem</c>: what clicking with or on a bundle does in a menu, and its selected item.</summary>
public static class BundleItem {
    /// <summary>The items that are <c>BundleItem</c>s: the bundle and its sixteen dyes.</summary>
    private static readonly HashSet<Identifier> Bundles = [
        Item.Bundle.Identifier, Item.WhiteBundle.Identifier, Item.OrangeBundle.Identifier, Item.MagentaBundle.Identifier,
        Item.LightBlueBundle.Identifier, Item.YellowBundle.Identifier, Item.LimeBundle.Identifier, Item.PinkBundle.Identifier,
        Item.GrayBundle.Identifier, Item.LightGrayBundle.Identifier, Item.CyanBundle.Identifier, Item.PurpleBundle.Identifier,
        Item.BlueBundle.Identifier, Item.BrownBundle.Identifier, Item.GreenBundle.Identifier, Item.RedBundle.Identifier, Item.BlackBundle.Identifier
    ];

    public static bool Is(IItem item) => Bundles.Contains(item.Identifier);

    /// <summary><c>overrideStackedOnOther</c>: a bundle on the cursor clicked onto a slot.</summary>
    public static bool OverrideStackedOnOther(Stack self, Slot slot, bool primary, IMenuUser player) {
        if (Contents(self) is not { } initialContents) {
            return false;
        }
        Stack other = slot.Item;
        BundleContents.Mutable contents = new(initialContents);
        if (primary && !other.IsEmpty) {
            if (contents.TryTransfer(slot, player) > 0) {
                PlayInsertSound(player);
            }
            else {
                PlayInsertFailSound(player);
            }
            SetContents(self, contents);
            return true;
        }
        if (!primary && other.IsEmpty) {
            if (contents.RemoveOne() is { } itemStack) {
                Stack remainder = slot.SafeInsert(itemStack);
                if (remainder.Count > 0) {
                    contents.TryInsert(remainder);
                }
                else {
                    PlayRemoveOneSound(player);
                }
            }
            SetContents(self, contents);
            return true;
        }
        return false;
    }

    /// <summary><c>overrideOtherStackedOnMe</c>: a slot holding a bundle clicked with <paramref name="other"/> on the cursor.</summary>
    public static bool OverrideOtherStackedOnMe(Stack self, Stack other, Slot slot, bool primary, IMenuUser player, ContainerMenu carriedItem) {
        if (primary && other.IsEmpty) {
            ToggleSelectedItem(self, BundleContents.NoSelectedItemIndex);
            return false;
        }
        if (Contents(self) is not { } initialContents) {
            return false;
        }
        BundleContents.Mutable contents = new(initialContents);
        if (primary && !other.IsEmpty) {
            if (slot.AllowModification(player) && contents.TryInsert(other) > 0) {
                PlayInsertSound(player);
            }
            else {
                PlayInsertFailSound(player);
            }
            SetContents(self, contents);
            return true;
        }
        if (!primary && other.IsEmpty) {
            if (slot.AllowModification(player) && contents.RemoveOne() is { } removed) {
                PlayRemoveOneSound(player);
                carriedItem.Carried = removed;
            }
            SetContents(self, contents);
            return true;
        }
        ToggleSelectedItem(self, BundleContents.NoSelectedItemIndex);
        return false;
    }

    public static void ToggleSelectedItem(Stack stack, int selectedItem) {
        if (Contents(stack) is { } initialContents) {
            BundleContents.Mutable contents = new(initialContents);
            contents.ToggleSelectedItem(selectedItem);
            SetContents(stack, contents);
        }
    }

    private static ItemStack[]? Contents(Stack stack) => stack.IsEmpty ? null : BundleContents.Of(stack.Template);

    private static void SetContents(Stack stack, BundleContents.Mutable contents) =>
        stack.Set(DataComponent.BundleContents, contents.ToImmutable(), Is(stack.Item) ? [] : null);

    public static int GetSelectedItemIndex(ItemStack stack) =>
        BundleContents.Of(stack) is { } contents ? BundleContents.SelectedItemIndex(contents) : BundleContents.NoSelectedItemIndex;

    public static ItemStack? GetSelectedItem(ItemStack stack) =>
        BundleContents.Of(stack) is { } contents ? BundleContents.SelectedItem(contents) : null;

    public static int GetNumberOfItemsToShow(ItemStack stack) => BundleContents.NumberOfItemsToShow(BundleContents.Of(stack) ?? []);

    private static void PlayRemoveOneSound(IMenuUser player) => player.PlaySound(SoundType.BundleRemoveOne, 0.8F, 0.8F + player.Random.NextFloat() * 0.4F);

    private static void PlayInsertSound(IMenuUser player) => player.PlaySound(SoundType.BundleInsert, 0.8F, 0.8F + player.Random.NextFloat() * 0.4F);

    private static void PlayInsertFailSound(IMenuUser player) => player.PlaySound(SoundType.BundleInsertFail, 1.0F, 1.0F);
}
