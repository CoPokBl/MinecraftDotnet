using ClientLib.Interaction;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace ClientLib;

/// <summary>An item stack's name, the way <c>ItemStack</c> gives it to everything that shows one.</summary>
public static class ItemNames {
    /// <summary><c>ItemStack.getHoverName</c>.</summary>
    public static TextComponent HoverName(ItemStack stack) => CustomName(stack) ?? ItemName(stack);

    /// <summary><c>ItemStack.getCustomName</c>: the custom name, else a written book's title.</summary>
    public static TextComponent? CustomName(ItemStack stack) {
        if (ItemComponents.Get(stack, DataComponent.CustomName) is { } customName) {
            return customName;
        }
        if (ItemComponents.Get(stack, DataComponent.WrittenBookContent) is { } content && !string.IsNullOrWhiteSpace(content.Title.Raw)) {
            return TextComponent.Text(content.Title.Raw);
        }
        return null;
    }

    /// <summary>
    /// <c>Item.getName</c> and the overrides that name an item from its components. The potion items'
    /// override is left out: it names the potion by <c>Potion.name</c>, which the generated potion
    /// table does not carry, so a potion keeps its <c>item_name</c>.
    /// </summary>
    public static TextComponent ItemName(ItemStack stack) {
        string item = stack.Type.TranslationKey;
        if (stack.Type.Identifier == Item.Compass.Identifier && ItemComponents.Has(stack, DataComponent.LodestoneTracker)) {
            return TextComponent.Translatable("item.minecraft.lodestone_compass");
        }
        if (stack.Type.Identifier == Item.PlayerHead.Identifier && ItemComponents.Get(stack, DataComponent.Profile) is { Name: { } owner }) {
            return TextComponent.Translatable(item + ".named", null, [TextComponent.Text(owner)]);
        }
        if (stack.Type.Identifier == Item.Shield.Identifier && ItemComponents.Has(stack, DataComponent.BaseColor)) {
            return TextComponent.Translatable(item + "." + DyeName(ItemComponents.Get(stack, DataComponent.BaseColor)));
        }
        return ItemComponents.Get(stack, DataComponent.ItemName) ?? TextComponent.Text("");
    }

    /// <summary><c>DyeColor.getName</c>: the constant's name in snake case.</summary>
    private static string DyeName(DyeColor colour) =>
        string.Concat(colour.ToString().Select((c, i) => char.IsUpper(c) && i > 0 ? "_" + char.ToLowerInvariant(c) : char.ToLowerInvariant(c).ToString()));

    /// <summary><c>ItemStack.getRarity</c>: an enchanted stack goes up one, to at most epic.</summary>
    public static ItemRarity Rarity(ItemStack stack) {
        ItemRarity baseRarity = ItemComponents.Get(stack, DataComponent.Rarity);
        (IEnchantment, int)[]? enchantments = ItemComponents.Get(stack, DataComponent.Enchantments);
        if (enchantments is not { Length: > 0 }) {
            return baseRarity;
        }
        return baseRarity switch {
            ItemRarity.Common or ItemRarity.Uncommon => ItemRarity.Rare,
            ItemRarity.Rare => ItemRarity.Epic,
            _ => baseRarity
        };
    }

    /// <summary><c>Rarity.color</c>.</summary>
    public static TextColor RarityColour(ItemRarity rarity) => rarity switch {
        ItemRarity.Uncommon => TextColor.Yellow,
        ItemRarity.Rare => TextColor.Aqua,
        ItemRarity.Epic => TextColor.LightPurple,
        _ => TextColor.White
    };

    /// <summary><c>ItemStack.getStyledHoverName</c>: the hover name in the rarity's colour, italic when custom named.</summary>
    public static TextComponent StyledHoverName(ItemStack stack) {
        TextComponent hoverName = TextComponent.Empty().With(HoverName(stack)).WithColor(RarityColour(Rarity(stack)));
        if (ItemComponents.Has(stack, DataComponent.CustomName)) {
            hoverName.WithItalic();
        }
        return hoverName;
    }
}
