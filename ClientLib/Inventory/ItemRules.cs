using Minecraft.Data.Components.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Items = Minecraft.Data.Generated.Item;
using Minecraft.Data.Items;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Inventory;

/// <summary>
/// The data a menu's placement rules ask about that the server synchronises: tags, and the item sets
/// <c>update_recipes</c> carries (furnace inputs, smithing parts, stonecutter inputs).
/// </summary>
public sealed class MenuData {
    public MinecraftRegistry Registry { get; set; } = VanillaRegistry.Data;
    public Dictionary<Identifier, Dictionary<Identifier, int[]>> Tags { get; set; } = new();
    public Dictionary<Identifier, HashSet<Identifier>> ItemSets { get; } = new();
    public HashSet<Identifier> StonecutterInputs { get; } = [];

    private static readonly Identifier ItemRegistry = "minecraft:item";

    public bool InTag(Stack stack, Identifier tag) {
        if (stack.IsEmpty || !Tags.TryGetValue(ItemRegistry, out Dictionary<Identifier, int[]>? tags) || !tags.TryGetValue(tag, out int[]? ids)) {
            return false;
        }
        int id = Registry.Items.GetProtocolId(stack.Item);
        return Array.IndexOf(ids, id) >= 0;
    }

    public bool InItemSet(Stack stack, Identifier set) {
        return !stack.IsEmpty && ItemSets.TryGetValue(set, out HashSet<Identifier>? items) && items.Contains(stack.Item.Identifier);
    }
}

/// <summary>Item properties the menus decide placement and quick moves by.</summary>
public static class ItemRules {
    /// <summary>
    /// <c>LivingEntity.getEquipmentSlotForItem</c> for a player: the equippable component's slot where
    /// a player can wear it, otherwise the main hand.
    /// </summary>
    public static EquippableComponent.Slot EquipmentSlotFor(Stack stack) {
        if (stack.IsEmpty || !stack.Has(DataComponent.Equippable)) {
            return EquippableComponent.Slot.MainHand;
        }
        EquippableComponent.Slot slot = stack.Template.Get(DataComponent.Equippable).Slot;
        return slot is EquippableComponent.Slot.Body or EquippableComponent.Slot.Saddle ? EquippableComponent.Slot.MainHand : slot;
    }

    /// <summary>Which of the inventory menu's armour slots, 5 to 8 head to feet, an armour slot is.</summary>
    public static int ArmourMenuSlot(EquippableComponent.Slot slot) => slot switch {
        EquippableComponent.Slot.Head => 5,
        EquippableComponent.Slot.Chest => 6,
        EquippableComponent.Slot.Legs => 7,
        EquippableComponent.Slot.Feet => 8,
        _ => -1
    };

    public static bool IsArmour(EquippableComponent.Slot slot) => ArmourMenuSlot(slot) >= 0;

    public static bool HasEnchantment(Stack stack, IEnchantment enchantment) =>
        !stack.IsEmpty && stack.Has(DataComponent.Enchantments)
        && stack.Template.Get(DataComponent.Enchantments).Any(present => present.Item1.Identifier == enchantment.Identifier);

    private static bool HasAnyEnchantments(Stack stack) =>
        !stack.IsEmpty && (stack.Has(DataComponent.Enchantments) && stack.Template.Get(DataComponent.Enchantments).Length > 0
                           || stack.Has(DataComponent.StoredEnchantments) && stack.Template.Get(DataComponent.StoredEnchantments).Length > 0);

    /// <summary><c>Item.getCraftingRemainder</c>, which five items in vanilla have.</summary>
    public static Stack CraftingRemainder(Stack stack) {
        if (stack.IsEmpty) {
            return Stack.Empty;
        }
        if (stack.Is(Items.WaterBucket) || stack.Is(Items.LavaBucket) || stack.Is(Items.MilkBucket)) {
            return Stack.Of(new ItemStack(Items.Bucket));
        }
        if (stack.Is(Items.DragonBreath) || stack.Is(Items.HoneyBottle)) {
            return Stack.Of(new ItemStack(Items.GlassBottle));
        }
        return Stack.Empty;
    }

    /// <summary><c>Item.canFitInsideContainerItems</c>: false for shulker boxes alone.</summary>
    public static bool CanFitInsideContainerItems(Stack stack) => !IsBlockItemOf(stack, BlockClass.ShulkerBoxBlock);

    private static bool IsBlockItemOf(Stack stack, BlockClass type) => stack.Item.CorrespondingBlock is { } block && BlockClasses.Is(block, type);

    /// <summary><c>AbstractFurnaceMenu.isFuel</c>: whatever burns has <c>cooking_fuel</c>.</summary>
    public static bool IsFuel(Stack stack) => stack.Has(DataComponent.CookingFuel);

    /// <summary><c>instanceof BannerItem</c>.</summary>
    public static bool IsBanner(Stack stack) => !stack.IsEmpty && IsBlockItemOf(stack, BlockClass.BannerBlock);

    public static bool IsDamageableOrEnchanted(Stack stack) => stack.IsDamageable || HasAnyEnchantments(stack);

    private static HashSet<Identifier> Ids(params IItem[] items) => items.Select(item => item.Identifier).ToHashSet();
}
