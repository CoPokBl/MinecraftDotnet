using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Items = Minecraft.Data.Generated.Item;
using Minecraft.Data.Inventories;
using Minecraft.Schemas;
using Minecraft.Text;

namespace ClientLib.Inventory;

/// <summary>Builds the menu the server names in <c>open_screen</c>.</summary>
public static class MenuFactory {
    private delegate ContainerMenu Factory(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data);

    private static readonly Dictionary<Identifier, Factory> Factories = new() {
        [InventoryType.Generic9x1.Identifier] = (w, t, n, i, d) => new ChestMenu(w, t, n, i, d, 1),
        [InventoryType.Generic9x2.Identifier] = (w, t, n, i, d) => new ChestMenu(w, t, n, i, d, 2),
        [InventoryType.Generic9x3.Identifier] = (w, t, n, i, d) => new ChestMenu(w, t, n, i, d, 3),
        [InventoryType.Generic9x4.Identifier] = (w, t, n, i, d) => new ChestMenu(w, t, n, i, d, 4),
        [InventoryType.Generic9x5.Identifier] = (w, t, n, i, d) => new ChestMenu(w, t, n, i, d, 5),
        [InventoryType.Generic9x6.Identifier] = (w, t, n, i, d) => new ChestMenu(w, t, n, i, d, 6),
        [InventoryType.Generic3x3.Identifier] = (w, t, n, i, d) => new DispenserMenu(w, t, n, i, d),
        [InventoryType.Crafter3x3.Identifier] = (w, t, n, i, d) => new CrafterMenu(w, t, n, i, d),
        [InventoryType.Hopper.Identifier] = (w, t, n, i, d) => new HopperMenu(w, t, n, i, d),
        [InventoryType.ShulkerBox.Identifier] = (w, t, n, i, d) => new ShulkerBoxMenu(w, t, n, i, d),
        [InventoryType.Crafting.Identifier] = (w, t, n, i, d) => new CraftingMenu(w, t, n, i, d),
        [InventoryType.Furnace.Identifier] = (w, t, n, i, d) => new FurnaceMenu(w, t, n, i, d, "minecraft:furnace_input"),
        [InventoryType.Smoker.Identifier] = (w, t, n, i, d) => new FurnaceMenu(w, t, n, i, d, "minecraft:smoker_input"),
        [InventoryType.BlastFurnace.Identifier] = (w, t, n, i, d) => new FurnaceMenu(w, t, n, i, d, "minecraft:blast_furnace_input"),
        [InventoryType.BrewingStand.Identifier] = (w, t, n, i, d) => new BrewingStandMenu(w, t, n, i, d),
        [InventoryType.Anvil.Identifier] = (w, t, n, i, d) => new AnvilMenu(w, t, n, i, d),
        [InventoryType.Smithing.Identifier] = (w, t, n, i, d) => new SmithingMenu(w, t, n, i, d),
        [InventoryType.Enchantment.Identifier] = (w, t, n, i, d) => new EnchantmentMenu(w, t, n, i, d),
        [InventoryType.Grindstone.Identifier] = (w, t, n, i, d) => new GrindstoneMenu(w, t, n, i, d),
        [InventoryType.Stonecutter.Identifier] = (w, t, n, i, d) => new StonecutterMenu(w, t, n, i, d),
        [InventoryType.Loom.Identifier] = (w, t, n, i, d) => new LoomMenu(w, t, n, i, d),
        [InventoryType.CartographyTable.Identifier] = (w, t, n, i, d) => new CartographyTableMenu(w, t, n, i, d),
        [InventoryType.Beacon.Identifier] = (w, t, n, i, d) => new BeaconMenu(w, t, n, i, d),
        [InventoryType.Lectern.Identifier] = (w, t, n, _, d) => new LecternMenu(w, t, n, d),
        [InventoryType.Merchant.Identifier] = (w, t, n, i, d) => new MerchantMenu(w, t, n, i, d)
    };

    /// <returns>Null for a menu type this client does not know.</returns>
    public static ContainerMenu? Create(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data) =>
        Factories.TryGetValue(type.Identifier, out Factory? factory) ? factory(windowId, type, title, inventory, data) : null;
}

/// <summary><c>InventoryMenu</c>: the 2x2 grid, armour, inventory and offhand, always window 0.</summary>
public sealed class InventoryMenu : ContainerMenu {
    private static readonly EquippableComponent.Slot[] Armour =
        [EquippableComponent.Slot.Head, EquippableComponent.Slot.Chest, EquippableComponent.Slot.Legs, EquippableComponent.Slot.Feet];

    private readonly ResultContainer _result = new();

    public InventoryMenu(PlayerInventory inventory, MenuData data) : base(0, null, null, data) {
        SimpleContainer grid = new(4);
        AddSlot(new CraftingResultSlot(grid, _result, 154, 28));
        AddSlotGrid(grid, 2, 2, 98, 18);
        for (int i = 0; i < 4; i++) {
            AddSlot(new ArmorSlot(inventory, Armour[i], 39 - i, 8, 8 + i * 18));
        }
        AddStandardInventorySlots(inventory, 8, 84);
        AddSlot(new Slot(inventory, PlayerInventory.OffhandIndex, 77, 62));
    }

    public override bool CanTakeItemForPickAll(Stack carried, Slot target) => target.Container != _result;

    protected override bool QuickMove(int slotIndex, Stack stack) {
        EquippableComponent.Slot equipment = ItemRules.EquipmentSlotFor(stack);
        if (slotIndex == 0) {
            return MoveItemStackTo(stack, 9, 45, true);
        }
        if (slotIndex is >= 1 and < 9) {
            return MoveItemStackTo(stack, 9, 45, false);
        }
        if (ItemRules.IsArmour(equipment) && !Slots[ItemRules.ArmourMenuSlot(equipment)].HasItem) {
            int pos = ItemRules.ArmourMenuSlot(equipment);
            return MoveItemStackTo(stack, pos, pos + 1, false);
        }
        if (equipment == EquippableComponent.Slot.OffHand && !Slots[45].HasItem) {
            return MoveItemStackTo(stack, 45, 46, false);
        }
        return MoveWithinInventory(stack, slotIndex, 9, true);
    }
}

/// <summary>A container's grid of slots then the player's inventory, with the quick move all of these share.</summary>
public abstract class GridMenu : ContainerMenu {
    private readonly int _size;

    protected GridMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data,
        int columns, int rows, int left, int top, int inventoryTop) : base(windowId, type, title, data) {
        _size = columns * rows;
        AddSlotGrid(new SimpleContainer(_size), columns, rows, left, top, create: CreateGridSlot);
        AddStandardInventorySlots(inventory, 8, inventoryTop);
    }

    /// <summary>Called from the constructor, before the subclass's own fields are set.</summary>
    protected virtual Slot CreateGridSlot(Container container, int index, int x, int y) => new(container, index, x, y);

    protected override bool QuickMove(int slotIndex, Stack stack) => slotIndex < _size
        ? MoveItemStackTo(stack, _size, _size + 36, true)
        : MoveItemStackTo(stack, 0, _size, false);
}

/// <summary><c>ChestMenu</c>: a grid of rows of nine.</summary>
public sealed class ChestMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data, int rows)
    : GridMenu(windowId, type, title, inventory, data, 9, rows, 8, 18, 18 + rows * 18 + 13) {
    public int Rows { get; } = rows;

    protected override bool QuickMoveTakes => false;
}

/// <summary><c>DispenserMenu</c>, the 3x3 of dispensers and droppers.</summary>
public sealed class DispenserMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
    : GridMenu(windowId, type, title, inventory, data, 3, 3, 62, 17, 84);

/// <summary><c>HopperMenu</c>: five slots in a row.</summary>
public sealed class HopperMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
    : GridMenu(windowId, type, title, inventory, data, 5, 1, 44, 20, 51) {
    protected override bool QuickMoveTakes => false;
}

/// <summary><c>ShulkerBoxMenu</c>: like a three row chest, but refusing shulker boxes.</summary>
public sealed class ShulkerBoxMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
    : GridMenu(windowId, type, title, inventory, data, 9, 3, 8, 18, 84) {
    protected override bool QuickMoveTakes => false;

    protected override Slot CreateGridSlot(Container container, int index, int x, int y) =>
        new FilteredSlot(container, index, x, y, ItemRules.CanFitInsideContainerItems);
}

/// <summary>
/// <c>CrafterMenu</c>: a 3x3 whose slots can be switched off, and a preview the player cannot touch.
/// A slot's data value of 1 is disabled.
/// </summary>
public sealed class CrafterMenu : GridMenu {
    public CrafterMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, inventory, data, 3, 3, 26, 17, 84) {
        AddSlot(new PreviewSlot(new ResultContainer(), 0, 134, 35));
    }

    public bool IsSlotDisabled(int slot) => slot is >= 0 and < 9 && Property(slot) == 1;

    /// <summary>Data slot 9: whether the crafter is powered, which only changes the art.</summary>
    public bool IsPowered => Property(9) == 1;

    protected override Slot CreateGridSlot(Container container, int index, int x, int y) => new CrafterSlot(this, container, index, x, y);

    private sealed class CrafterSlot(CrafterMenu menu, Container container, int containerSlot, int x, int y)
        : Slot(container, containerSlot, x, y) {
        public override bool MayPlace(Stack stack) => !menu.IsSlotDisabled(Index) && base.MayPlace(stack);
    }
}

/// <summary><c>CraftingMenu</c>: the crafting table's 3x3.</summary>
public sealed class CraftingMenu : ContainerMenu {
    private readonly ResultContainer _result = new();

    public CraftingMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        SimpleContainer grid = new(9);
        AddSlot(new CraftingResultSlot(grid, _result, 124, 35));
        AddSlotGrid(grid, 3, 3, 30, 17);
        AddStandardInventorySlots(inventory, 8, 84);
    }

    public override bool CanTakeItemForPickAll(Stack carried, Slot target) => target.Container != _result;

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 0) {
            return MoveItemStackTo(stack, 10, 46, true);
        }
        if (slotIndex is >= 10 and < 46) {
            return MoveItemStackTo(stack, 1, 10, false) || MoveWithinInventory(stack, slotIndex, 10);
        }
        return MoveItemStackTo(stack, 10, 46, false);
    }
}

/// <summary>
/// <c>AbstractFurnaceMenu</c> for all three furnaces; they differ only in which of the item sets
/// <c>update_recipes</c> sends decides what can be smelted. Data 0 to 3: lit time, lit duration,
/// cooking progress, cooking total.
/// </summary>
public sealed class FurnaceMenu : ContainerMenu {
    private readonly Identifier _inputSet;

    public FurnaceMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data, Identifier inputSet)
        : base(windowId, type, title, data) {
        _inputSet = inputSet;
        SimpleContainer container = new(3);
        AddSlot(new Slot(container, 0, 56, 17));
        AddSlot(new FuelSlot(this, container, 1, 56, 53));
        AddSlot(new OutputSlot(container, 2, 116, 35));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    private bool IsFuel(Stack stack) => ItemRules.IsFuel(stack, Data);

    public float BurnProgress => Property(3) != 0 && Property(2) != 0 ? Math.Clamp((float)Property(2) / Property(3), 0, 1) : 0;
    public float LitProgress => Property(1) == 0 ? 0 : Math.Clamp((float)Property(0) / Property(1), 0, 1);
    public bool IsLit => Property(0) > 0;

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 2) {
            return MoveItemStackTo(stack, 3, 39, true);
        }
        if (slotIndex is 0 or 1) {
            return MoveItemStackTo(stack, 3, 39, false);
        }
        if (Data.InItemSet(stack, _inputSet)) {
            return MoveItemStackTo(stack, 0, 1, false);
        }
        if (IsFuel(stack)) {
            return MoveItemStackTo(stack, 1, 2, false);
        }
        return MoveWithinInventory(stack, slotIndex, 3);
    }

    private sealed class FuelSlot(FurnaceMenu menu, Container container, int containerSlot, int x, int y) : Slot(container, containerSlot, x, y) {
        public override bool MayPlace(Stack stack) => menu.IsFuel(stack) || stack.Is(Items.Bucket);
        public override int MaxStackSizeFor(Stack stack) => stack.Is(Items.Bucket) ? 1 : base.MaxStackSizeFor(stack);
    }
}

/// <summary><c>BrewingStandMenu</c>: three bottles, an ingredient and blaze powder. Data 0 brew time, 1 fuel.</summary>
public sealed class BrewingStandMenu : ContainerMenu {
    private readonly Slot _ingredient;

    public BrewingStandMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        SimpleContainer container = new(5);
        AddSlot(new FilteredSlot(container, 0, 56, 51, ItemRules.IsPotionContainer, 1));
        AddSlot(new FilteredSlot(container, 1, 79, 58, ItemRules.IsPotionContainer, 1));
        AddSlot(new FilteredSlot(container, 2, 102, 51, ItemRules.IsPotionContainer, 1));
        _ingredient = AddSlot(new FilteredSlot(container, 3, 79, 17, ItemRules.IsBrewingIngredient));
        AddSlot(new FilteredSlot(container, 4, 17, 17, IsBrewingFuel));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    private bool IsBrewingFuel(Stack stack) => Data.InTag(stack, "minecraft:brewing_fuel");

    public int BrewTime => Property(0);
    public int Fuel => Property(1);

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex is >= 0 and <= 4) {
            return MoveItemStackTo(stack, 5, 41, true);
        }
        if (IsBrewingFuel(stack)) {
            // Vanilla's own: fuel that did move reports nothing moved.
            return !(MoveItemStackTo(stack, 4, 5, false) || _ingredient.MayPlace(stack) && !MoveItemStackTo(stack, 3, 4, false));
        }
        if (_ingredient.MayPlace(stack)) {
            return MoveItemStackTo(stack, 3, 4, false);
        }
        if (ItemRules.IsPotionContainer(stack)) {
            return MoveItemStackTo(stack, 0, 3, false);
        }
        return MoveWithinInventory(stack, slotIndex, 5, true);
    }
}

/// <summary>
/// <c>ItemCombinerMenu</c>: inputs, one result, then the inventory. Anvil and smithing table differ
/// in their inputs' rules and in what taking the result costs.
/// </summary>
public abstract class ItemCombinerMenu : ContainerMenu {
    private readonly int _resultSlot;

    protected SimpleContainer Inputs { get; }

    protected ItemCombinerMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data,
        (int X, int Y, Func<Stack, bool> MayPlace)[] inputs, int resultX, int resultY) : base(windowId, type, title, data) {
        Inputs = new SimpleContainer(inputs.Length);
        for (int i = 0; i < inputs.Length; i++) {
            AddSlot(new FilteredSlot(Inputs, i, inputs[i].X, inputs[i].Y, inputs[i].MayPlace));
        }
        _resultSlot = inputs.Length;
        AddSlot(new OutputSlot(new ResultContainer(), 0, resultX, resultY, OnTakeResult, MayPickupResult));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    protected virtual bool MayPickupResult(IMenuUser user) => true;
    protected abstract void OnTakeResult(IMenuUser user, Stack carried);
    protected virtual bool CanMoveIntoInputSlots(Stack stack) => true;

    protected override bool QuickMove(int slotIndex, Stack stack) {
        int inventoryStart = _resultSlot + 1, inventoryEnd = inventoryStart + 36;
        if (slotIndex == _resultSlot) {
            return MoveItemStackTo(stack, inventoryStart, inventoryEnd, true);
        }
        if (slotIndex < _resultSlot) {
            return MoveItemStackTo(stack, inventoryStart, inventoryEnd, false);
        }
        if (CanMoveIntoInputSlots(stack) && slotIndex >= inventoryStart && slotIndex < inventoryEnd) {
            return MoveItemStackTo(stack, 0, _resultSlot, false);
        }
        return MoveWithinInventory(stack, slotIndex, inventoryStart);
    }

    /// <summary><c>ItemCombinerMenu.shrinkStackInSlot</c>.</summary>
    protected void ShrinkInput(int slot) {
        Stack stack = Inputs.Get(slot);
        if (!stack.IsEmpty) {
            stack.Shrink(1);
            Inputs.Set(slot, stack);
        }
    }
}

/// <summary>
/// <c>AnvilMenu</c>. Data 0 is the level cost. Only the server knows how much of the second input a
/// repair uses, so taking the result empties both, as vanilla's prediction does for a repair count of
/// zero, and the server's slot update puts back what it did not use.
/// </summary>
public sealed class AnvilMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
    : ItemCombinerMenu(windowId, type, title, inventory, data, [(27, 47, _ => true), (76, 47, _ => true)], 134, 47) {
    public int Cost => Property(0);

    protected override bool MayPickupResult(IMenuUser user) => (user.InfiniteMaterials || user.ExperienceLevel >= Cost) && Cost > 0;

    protected override void OnTakeResult(IMenuUser user, Stack carried) {
        Inputs.Set(0, Stack.Empty);
        Inputs.Set(1, Stack.Empty);
        Properties[0] = 0;
    }
}

/// <summary><c>SmithingMenu</c>: template, base and addition, each used once.</summary>
public sealed class SmithingMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
    : ItemCombinerMenu(windowId, type, title, inventory, data, [
        (8, 48, s => data.InItemSet(s, TemplateSet)),
        (26, 48, s => data.InItemSet(s, BaseSet)),
        (44, 48, s => data.InItemSet(s, AdditionSet))
    ], 98, 48) {
    private static readonly Identifier TemplateSet = "minecraft:smithing_template";
    private static readonly Identifier BaseSet = "minecraft:smithing_base";
    private static readonly Identifier AdditionSet = "minecraft:smithing_addition";

    protected override void OnTakeResult(IMenuUser user, Stack carried) {
        ShrinkInput(0);
        ShrinkInput(1);
        ShrinkInput(2);
    }

    protected override bool CanMoveIntoInputSlots(Stack stack) =>
        Data.InItemSet(stack, TemplateSet) && !Slots[0].HasItem
        || Data.InItemSet(stack, BaseSet) && !Slots[1].HasItem
        || Data.InItemSet(stack, AdditionSet) && !Slots[2].HasItem;
}

/// <summary>
/// <c>EnchantmentMenu</c>: the item and the lapis. Data 0 to 2 the level costs, 3 the seed, 4 to 6
/// the clue enchantments, 7 to 9 their levels. Enchanting is a button click.
/// </summary>
public sealed class EnchantmentMenu : ContainerMenu {
    public EnchantmentMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        SimpleContainer container = new(2);
        AddSlot(new FilteredSlot(container, 0, 15, 47, _ => true, 1));
        AddSlot(new FilteredSlot(container, 1, 35, 47, s => s.Is(Items.LapisLazuli)));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    public int Cost(int option) => Property(option);

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex is 0 or 1) {
            return MoveItemStackTo(stack, 2, 38, true);
        }
        if (stack.Is(Items.LapisLazuli)) {
            return MoveItemStackTo(stack, 1, 2, true);
        }
        if (Slots[0].HasItem || !Slots[0].MayPlace(stack)) {
            return false;
        }
        Stack single = stack.CopyWithCount(1);
        stack.Shrink(1);
        Slots[0].SetByPlayer(single);
        return true;
    }
}

/// <summary><c>GrindstoneMenu</c>: two inputs that must be damageable or enchanted; taking the result clears both.</summary>
public sealed class GrindstoneMenu : ContainerMenu {
    private readonly SimpleContainer _inputs = new(2);

    public GrindstoneMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        AddSlot(new FilteredSlot(_inputs, 0, 49, 19, ItemRules.IsDamageableOrEnchanted));
        AddSlot(new FilteredSlot(_inputs, 1, 49, 40, ItemRules.IsDamageableOrEnchanted));
        AddSlot(new OutputSlot(new ResultContainer(), 0, 129, 34, (_, _) => _inputs.Clear()));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 2) {
            return MoveItemStackTo(stack, 3, 39, true);
        }
        if (slotIndex is 0 or 1) {
            return MoveItemStackTo(stack, 3, 39, false);
        }
        if (!_inputs.Get(0).IsEmpty && !_inputs.Get(1).IsEmpty) {
            return MoveWithinInventory(stack, slotIndex, 3);
        }
        return MoveItemStackTo(stack, 0, 2, false);
    }
}

/// <summary><c>StonecutterMenu</c>. Data 0 is the selected recipe; choosing one is a button click.</summary>
public sealed class StonecutterMenu : ContainerMenu {
    public StonecutterMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        SimpleContainer input = new(1);
        AddSlot(new Slot(input, 0, 20, 33));
        AddSlot(new OutputSlot(new ResultContainer(), 0, 143, 33, (_, _) => input.Remove(0, 1)));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    public int SelectedRecipe => Properties.GetValueOrDefault(0, -1);

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 1) {
            return MoveItemStackTo(stack, 2, 38, true);
        }
        if (slotIndex == 0) {
            return MoveItemStackTo(stack, 2, 38, false);
        }
        if (Data.StonecutterInputs.Contains(stack.Item.Identifier)) {
            return MoveItemStackTo(stack, 0, 1, false);
        }
        return MoveWithinInventory(stack, slotIndex, 2);
    }
}

/// <summary><c>LoomMenu</c>: banner, dye and pattern; taking the result uses a banner and a dye.</summary>
public sealed class LoomMenu : ContainerMenu {
    public LoomMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        SimpleContainer inputs = new(3);
        AddSlot(new FilteredSlot(inputs, 0, 13, 26, ItemRules.IsBanner));
        AddSlot(new FilteredSlot(inputs, 1, 33, 26, IsDye));
        AddSlot(new FilteredSlot(inputs, 2, 23, 45, IsPattern));
        AddSlot(new OutputSlot(new ResultContainer(), 0, 143, 57, (_, _) => {
            Slots[0].Remove(1);
            Slots[1].Remove(1);
        }));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    public int SelectedPattern => Properties.GetValueOrDefault(0, -1);

    private bool IsDye(Stack stack) => Data.InTag(stack, "minecraft:loom_dyes") && stack.Has(DataComponent.Dye);
    private bool IsPattern(Stack stack) => Data.InTag(stack, "minecraft:loom_patterns") && stack.Has(DataComponent.ProvidesBannerPatterns);

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 3) {
            return MoveItemStackTo(stack, 4, 40, true);
        }
        if (slotIndex is 0 or 1 or 2) {
            return MoveItemStackTo(stack, 4, 40, false);
        }
        if (ItemRules.IsBanner(stack)) {
            return MoveItemStackTo(stack, 0, 1, false);
        }
        if (IsDye(stack)) {
            return MoveItemStackTo(stack, 1, 2, false);
        }
        if (IsPattern(stack)) {
            return MoveItemStackTo(stack, 2, 3, false);
        }
        return MoveWithinInventory(stack, slotIndex, 4);
    }
}

/// <summary><c>CartographyTableMenu</c>: a map and paper, a map or glass; taking the result uses one of each.</summary>
public sealed class CartographyTableMenu : ContainerMenu {
    public CartographyTableMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        SimpleContainer inputs = new(2);
        AddSlot(new FilteredSlot(inputs, 0, 15, 15, s => s.Has(DataComponent.MapId)));
        AddSlot(new FilteredSlot(inputs, 1, 15, 52, IsAddition));
        AddSlot(new OutputSlot(new ResultContainer(), 0, 145, 39, (_, _) => {
            Slots[0].Remove(1);
            Slots[1].Remove(1);
        }));
        AddStandardInventorySlots(inventory, 8, 84);
    }

    private static bool IsAddition(Stack stack) => stack.Is(Items.Paper) || stack.Is(Items.Map) || stack.Is(Items.GlassPane);

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 2) {
            return MoveItemStackTo(stack, 3, 39, true);
        }
        if (slotIndex is 0 or 1) {
            return MoveItemStackTo(stack, 3, 39, false);
        }
        if (stack.Has(DataComponent.MapId)) {
            return MoveItemStackTo(stack, 0, 1, false);
        }
        return IsAddition(stack) ? MoveItemStackTo(stack, 1, 2, false) : MoveWithinInventory(stack, slotIndex, 3);
    }
}

/// <summary><c>BeaconMenu</c>: one payment slot. Data 0 is the levels.</summary>
public sealed class BeaconMenu : ContainerMenu {
    private readonly Slot _payment;

    public BeaconMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        _payment = AddSlot(new FilteredSlot(new SimpleContainer(1), 0, 136, 110, s => data.InTag(s, "minecraft:beacon_payment_items"), 1));
        AddStandardInventorySlots(inventory, 36, 137);
    }

    public int Levels => Property(0);

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 0) {
            return MoveItemStackTo(stack, 1, 37, true);
        }
        if (!_payment.HasItem && _payment.MayPlace(stack) && stack.Count == 1) {
            return MoveItemStackTo(stack, 0, 1, false);
        }
        return MoveWithinInventory(stack, slotIndex, 1, true);
    }
}

/// <summary><c>LecternMenu</c>: the book, nothing of the player's. Data 0 is the page; turning is a button click.</summary>
public sealed class LecternMenu : ContainerMenu {
    public const int ButtonPreviousPage = 1, ButtonNextPage = 2, ButtonTakeBook = 3, ButtonPageBase = 100;

    public LecternMenu(int windowId, IInventoryType type, TextComponent title, MenuData data) : base(windowId, type, title, data) {
        AddSlot(new Slot(new SimpleContainer(1), 0, 0, 0));
    }

    public int Page => Property(0);

    protected override bool QuickMove(int slotIndex, Stack stack) => false;
}

/// <summary>
/// <c>MerchantMenu</c>: two payments and the result. The trades come from <c>merchant_offers</c>
/// and choosing one is <c>select_trade</c>, after which the server fills the payment slots. Taking
/// the result pays the chosen trade's costs out of the payment slots.
/// </summary>
public sealed class MerchantMenu : ContainerMenu {
    private readonly SimpleContainer _payments = new(2);

    public MerchantMenu(int windowId, IInventoryType type, TextComponent title, PlayerInventory inventory, MenuData data)
        : base(windowId, type, title, data) {
        AddSlot(new Slot(_payments, 0, 136, 37));
        AddSlot(new Slot(_payments, 1, 162, 37));
        AddSlot(new OutputSlot(new ResultContainer(), 0, 220, 37, (_, _) => PayForTrade()));
        AddStandardInventorySlots(inventory, 108, 84);
    }

    public Minecraft.Packets.Play.ClientBound.ClientBoundMerchantOffersPacket? Offers { get; set; }
    public int SelectedOffer { get; set; } = -1;

    /// <summary><c>MerchantOffer.take</c>: pays both costs out of whichever slot holds each.</summary>
    private void PayForTrade() {
        if (Offers == null || SelectedOffer < 0 || SelectedOffer >= Offers.Trades.Length) {
            return;
        }
        Trade offer = Offers.Trades[SelectedOffer];
        Take(offer.InputItem1.Item, ModifiedCostCount(offer));
        if (offer.InputItem2 != null) {
            Take(offer.InputItem2.Item, offer.InputItem2.Item.Count);
        }
    }

    /// <summary><c>MerchantOffer.getModifiedCostCount</c>: the first cost after demand and discounts.</summary>
    public static int ModifiedCostCount(Trade offer) {
        int basePrice = offer.InputItem1.Item.Count;
        int demandDiff = Math.Max(0, (int)MathF.Floor(basePrice * offer.Demand * offer.PriceMultiplier));
        return Math.Clamp(basePrice + demandDiff + offer.SpecialPrice, 1, offer.InputItem1.Item.GetMaxStackSize());
    }

    private void Take(Minecraft.Schemas.Items.ItemStack cost, int count) {
        for (int i = 0; i < 2 && count > 0; i++) {
            Stack stack = _payments.Get(i);
            if (!stack.IsEmpty && stack.Item.Identifier == cost.Type.Identifier) {
                int taken = Math.Min(count, stack.Count);
                stack.Shrink(taken);
                count -= taken;
            }
        }
    }

    protected override bool QuickMove(int slotIndex, Stack stack) {
        if (slotIndex == 2) {
            return MoveItemStackTo(stack, 3, 39, true);
        }
        if (slotIndex is 0 or 1) {
            return MoveItemStackTo(stack, 3, 39, false);
        }
        return MoveWithinInventory(stack, slotIndex, 3);
    }
}
