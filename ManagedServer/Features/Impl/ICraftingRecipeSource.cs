using Minecraft.Data.Recipes;
using Minecraft.Schemas;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Where <see cref="CraftingFeature"/> gets its recipes from.
/// </summary>
/// <remarks>
/// The seam instead of a registry on the server, for the same reason <see cref="IBlockLootSource"/>
/// is: a recipe is data with no consumer inside core. Nothing here ships the vanilla ones, since a
/// recipe is authored content rather than measured fact; <c>DatapackCraftingRecipes</c> reads them at
/// runtime and <c>CraftingRecipes</c> is a list written by hand.
/// </remarks>
public interface ICraftingRecipeSource {
    /// <summary>
    /// Every recipe, <b>in the order ties are broken</b>. Vanilla takes the first that matches out of
    /// a <c>TreeMap</c> keyed by id, so the order is part of the answer. <see cref="Order"/> is it.
    /// </summary>
    IReadOnlyList<ICraftingRecipe> Recipes { get; }

    /// <summary>The first recipe this grid is, or null. An empty grid is never a recipe.</summary>
    ICraftingRecipe? Find(CraftingInput input) {
        if (input.IsEmpty) {
            return null;
        }

        foreach (ICraftingRecipe recipe in Recipes) {
            if (recipe.Matches(input)) {
                return recipe;
            }
        }

        return null;
    }

    /// <summary>
    /// <c>Identifier.compareTo</c>: <b>path first, then namespace</b>, which is not the order ids
    /// print in. Ordinal, since Java's <c>String.compareTo</c> compares UTF-16 code units.
    /// </summary>
    static int Order(Identifier left, Identifier right) {
        int result = string.CompareOrdinal(left.Key, right.Key);
        return result != 0 ? result : string.CompareOrdinal(left.Namespace, right.Namespace);
    }
}

/// <summary>
/// Recipes given directly, sorted into the order ties are broken in. Layering is by id: a recipe
/// replaces an earlier one with the same id, which is <c>OverriddenBlockLoot</c>'s bargain.
/// </summary>
public sealed class CraftingRecipes : ICraftingRecipeSource {
    public CraftingRecipes(params IEnumerable<ICraftingRecipe>[] layers) {
        Dictionary<Identifier, ICraftingRecipe> byId = [];

        foreach (IEnumerable<ICraftingRecipe> layer in layers) {
            foreach (ICraftingRecipe recipe in layer) {
                byId[recipe.Id] = recipe;
            }
        }

        Recipes = byId.Values
            .OrderBy(recipe => recipe.Id, Comparer<Identifier>.Create(ICraftingRecipeSource.Order))
            .ToArray();
    }

    /// <summary>Sources layered in the order given, later ones winning by id.</summary>
    public static CraftingRecipes Layered(params ICraftingRecipeSource[] sources) {
        return new CraftingRecipes(sources.Select(source => source.Recipes).ToArray());
    }

    public IReadOnlyList<ICraftingRecipe> Recipes { get; }
}
