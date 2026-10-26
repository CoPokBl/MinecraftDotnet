using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Recipes;

/// <summary>
/// Something makeable in a crafting grid, vanilla's <c>CraftingRecipe</c>.
/// </summary>
/// <remarks>
/// <see cref="Matches"/> and <see cref="Assemble"/> are separate because the result is not always
/// fixed: a transmute recipe carries the input's components onto its result.
/// </remarks>
public interface ICraftingRecipe {
    /// <summary>
    /// The registry id. <b>Ties between matching recipes are broken by it</b>, so it is part of the
    /// answer rather than a label; <c>ICraftingRecipeSource</c> imposes the ordering.
    /// </summary>
    Identifier Id { get; }

    /// <summary>The flattened ingredients. Cached on the recipe, as vanilla caches it.</summary>
    PlacementInfo PlacementInfo { get; }

    /// <summary>Whether this grid is this recipe.</summary>
    bool Matches(CraftingInput input);

    /// <summary>What this grid makes. Only meaningful when <see cref="Matches"/> said yes.</summary>
    ItemStack Assemble(CraftingInput input);

    /// <summary>
    /// <c>CraftingRecipe.getRemainingItems</c>: what each cell leaves behind after one craft, air
    /// where it leaves nothing. The default is each item's own remainder, the empty bucket a cake
    /// recipe hands back.
    /// </summary>
    ItemStack[] GetRemainingItems(CraftingInput input) {
        return DefaultCraftingRemainder(input);
    }

    /// <summary><c>CraftingRecipe.defaultCraftingReminder</c>.</summary>
    static ItemStack[] DefaultCraftingRemainder(CraftingInput input) {
        ItemStack[] result = new ItemStack[input.Size];

        for (int slot = 0; slot < result.Length; slot++) {
            result[slot] = CraftingRemainders.For(input[slot].Type.Identifier) ?? ItemStack.Air;
        }

        return result;
    }
}
