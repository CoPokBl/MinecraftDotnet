using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Recipes;

/// <summary>
/// <c>ShapedRecipe</c>: a fixed arrangement of ingredients making a fixed stack.
/// </summary>
public sealed class ShapedRecipe(Identifier id, ShapedRecipePattern pattern, ItemStack result)
    : ICraftingRecipe {

    public Identifier Id { get; } = id;
    public ShapedRecipePattern Pattern { get; } = pattern;

    /// <summary>What one craft makes. Handed out as is, since an <see cref="ItemStack"/> is immutable.</summary>
    public ItemStack Result { get; } = result;

    public PlacementInfo PlacementInfo { get; } = PlacementInfo.CreateFromOptionals(pattern.Ingredients);

    public bool Matches(CraftingInput input) {
        return Pattern.Matches(input);
    }

    public ItemStack Assemble(CraftingInput input) {
        return Result;
    }
}
