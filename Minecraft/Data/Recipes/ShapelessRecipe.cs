using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Recipes;

/// <summary>
/// <c>ShapelessRecipe</c>: a bag of ingredients, in any arrangement, making a fixed stack. Matching
/// is a maximum matching rather than a per ingredient search, see <see cref="StackedContents"/>.
/// </summary>
public sealed class ShapelessRecipe(Identifier id, IReadOnlyList<Ingredient> ingredients, ItemStack result)
    : ICraftingRecipe {

    public Identifier Id { get; } = id;
    public IReadOnlyList<Ingredient> Ingredients { get; } = ingredients;

    /// <summary>What one craft makes. Handed out as is, since an <see cref="ItemStack"/> is immutable.</summary>
    public ItemStack Result { get; } = result;

    public PlacementInfo PlacementInfo { get; } = PlacementInfo.Create(ingredients);

    public bool Matches(CraftingInput input) {
        if (input.IngredientCount != Ingredients.Count) {
            return false;
        }

        if (input.Size == 1 && Ingredients.Count == 1) {
            return Ingredients[0].Test(input[0]);
        }

        if (PlacementInfo.IsImpossibleToPlace) {
            return false;
        }

        return input.StackedContents.TryPick(PlacementInfo.Ingredients, 1);
    }

    public ItemStack Assemble(CraftingInput input) {
        return Result;
    }
}
