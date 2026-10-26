using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Item = Minecraft.Data.Generated.Item;

namespace Minecraft.Data.Recipes;

/// <summary>
/// What an item leaves behind when a recipe consumes it, vanilla's <c>Item.getCraftingRemainder</c>.
/// </summary>
/// <remarks>
/// <b>A hand table, because the value is an <c>Item.Properties</c> constructor argument</b> in
/// <c>Items.java</c>: neither the data generator's reports nor <c>Dumper.java</c> can see it. Same
/// bargain <c>OpensByHand</c> makes. Dumping <c>Item.Properties</c> is the fix.
/// <p/>
/// These five are the whole of it in 26.2, measured by walking <c>BuiltInRegistries.ITEM</c>;
/// <c>CraftingConformanceTest</c> is the backstop. Without it a cake recipe eats three buckets.
/// </remarks>
public static class CraftingRemainders {
    private static readonly Dictionary<Identifier, ItemStack> Table = new() {
        [Item.WaterBucket.Identifier] = new ItemStack(Item.Bucket),
        [Item.LavaBucket.Identifier] = new ItemStack(Item.Bucket),
        [Item.MilkBucket.Identifier] = new ItemStack(Item.Bucket),
        [Item.DragonBreath.Identifier] = new ItemStack(Item.GlassBottle),
        [Item.HoneyBottle.Identifier] = new ItemStack(Item.GlassBottle)
    };

    /// <summary>Every item with a remainder.</summary>
    public static IReadOnlyDictionary<Identifier, ItemStack> All => Table;

    /// <summary>What <paramref name="item"/> leaves behind, or null. Nullable as vanilla's is.</summary>
    public static ItemStack? For(Identifier item) {
        return Table.GetValueOrDefault(item);
    }
}
