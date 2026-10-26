namespace Minecraft.Data.Recipes;

/// <summary>
/// A recipe's ingredients flattened for the shapeless matcher, vanilla's <c>PlacementInfo</c>.
/// </summary>
/// <remarks>
/// <see cref="IsImpossibleToPlace"/> is the answer for a recipe naming a tag that resolved to
/// nothing, which a consumer's pack can do. It has to be checked: an ingredient accepting nothing
/// would otherwise leave an empty ingredient list that matches an empty grid.
/// </remarks>
public sealed class PlacementInfo {
    public static readonly PlacementInfo NotPlaceable = new([], []);

    /// <summary>Vanilla's <c>EMPTY_SLOT</c>: a cell that takes no ingredient.</summary>
    public const int EmptySlot = -1;

    private PlacementInfo(Ingredient[] ingredients, int[] slotsToIngredientIndex) {
        Ingredients = ingredients;
        SlotsToIngredientIndex = slotsToIngredientIndex;
    }

    public IReadOnlyList<Ingredient> Ingredients { get; }

    /// <summary>Per cell, its index into <see cref="Ingredients"/> or <see cref="EmptySlot"/>.</summary>
    public IReadOnlyList<int> SlotsToIngredientIndex { get; }

    public bool IsImpossibleToPlace => SlotsToIngredientIndex.Count == 0;

    /// <summary><c>PlacementInfo.create(List)</c>.</summary>
    public static PlacementInfo Create(IReadOnlyList<Ingredient> ingredients) {
        int[] slots = new int[ingredients.Count];

        for (int i = 0; i < ingredients.Count; i++) {
            if (ingredients[i].IsEmpty) {
                return NotPlaceable;
            }

            slots[i] = i;
        }

        return new PlacementInfo(ingredients.ToArray(), slots);
    }

    /// <summary><c>PlacementInfo.createFromOptionals</c>, for a shaped pattern's cells.</summary>
    public static PlacementInfo CreateFromOptionals(IReadOnlyList<Ingredient?> ingredients) {
        List<Ingredient> present = new(ingredients.Count);
        int[] slots = new int[ingredients.Count];
        int placementIndex = 0;

        for (int i = 0; i < ingredients.Count; i++) {
            if (ingredients[i] is not { } ingredient) {
                slots[i] = EmptySlot;
                continue;
            }

            if (ingredient.IsEmpty) {
                return NotPlaceable;
            }

            present.Add(ingredient);
            slots[i] = placementIndex++;
        }

        return new PlacementInfo(present.ToArray(), slots);
    }
}
