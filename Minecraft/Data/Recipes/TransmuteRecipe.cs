using Minecraft.Data.Components;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Recipes;

/// <summary>
/// <c>TransmuteRecipe</c>: one input plus some material, making a result that <b>keeps the input's
/// components</b>. Dyeing a shulker box has to keep the contents of the one that went in, which is
/// why <see cref="Assemble"/> reads the grid rather than returning a stored stack.
/// </summary>
/// <remarks>
/// The material count is a range because of firework rockets, the one vanilla recipe using the wide
/// form: one to eight gunpowder, with the count carried onto the result.
/// </remarks>
public sealed class TransmuteRecipe(
    Identifier id,
    Ingredient input,
    Ingredient material,
    int minMaterialCount,
    int maxMaterialCount,
    TransmuteResult result,
    bool addMaterialCountToResult) : ICraftingRecipe {

    /// <summary>Vanilla's <c>MIN_MATERIAL_COUNT</c>, and the default when the range is absent.</summary>
    public const int DefaultMinMaterialCount = 1;

    /// <summary>Vanilla's <c>MAX_MATERIAL_COUNT</c>, and an open ended range's top.</summary>
    public const int DefaultMaxMaterialCount = 8;

    public Identifier Id { get; } = id;
    public Ingredient Input { get; } = input;
    public Ingredient Material { get; } = material;
    public int MinMaterialCount { get; } = minMaterialCount;
    public int MaxMaterialCount { get; } = maxMaterialCount;
    public TransmuteResult Result { get; } = result;
    public bool AddMaterialCountToResult { get; } = addMaterialCountToResult;

    public PlacementInfo PlacementInfo { get; } =
        PlacementInfo.Create([input, ..Enumerable.Repeat(material, maxMaterialCount)]);

    public bool Matches(CraftingInput input) {
        if (input.IngredientCount < MinMaterialCount + 1 || input.IngredientCount > MaxMaterialCount + 1) {
            return false;
        }

        ItemStack? foundInput = null;
        int materialCount = 0;

        for (int slot = 0; slot < input.Size; slot++) {
            ItemStack stack = input[slot];

            if (stack.IsAir()) {
                continue;
            }

            // The input is tried first, so an item both accept counts as the input; only a second
            // such item makes the grid ambiguous.
            if (Input.Test(stack)) {
                if (foundInput is not null) {
                    return false;
                }

                foundInput = stack;
            } else {
                if (!Material.Test(stack)) {
                    return false;
                }

                if (++materialCount > MaxMaterialCount) {
                    return false;
                }
            }
        }

        if (foundInput is null || foundInput.IsAir() || materialCount < MinMaterialCount
            || materialCount > MaxMaterialCount) {

            return false;
        }

        // A result identical to the input is not a recipe. This is what stops a white bundle plus
        // white dye offering a white bundle back.
        if (ComputeResultSize(materialCount) != 1) {
            return true;
        }

        ItemStack result = ComputeResult(foundInput, 0);
        return !result.IsAir() && !foundInput.CanStackWith(result);
    }

    public ItemStack Assemble(CraftingInput input) {
        if (!AddMaterialCountToResult) {
            for (int slot = 0; slot < input.Size; slot++) {
                ItemStack stack = input[slot];

                if (!stack.IsAir() && Input.Test(stack)) {
                    return ComputeResult(stack, 0);
                }
            }

            return ItemStack.Air;
        }

        int materialCount = 0;
        ItemStack inputIngredient = ItemStack.Air;

        for (int slot = 0; slot < input.Size; slot++) {
            ItemStack stack = input[slot];

            if (stack.IsAir()) {
                continue;
            }

            if (Input.Test(stack)) {
                inputIngredient = stack;
            } else if (Material.Test(stack)) {
                materialCount++;
            }
        }

        return ComputeResult(inputIngredient, materialCount);
    }

    private int ComputeResultSize(int materialCount) {
        return AddMaterialCountToResult ? materialCount + Result.Count : Result.Count;
    }

    private ItemStack ComputeResult(ItemStack inputIngredient, int materialCount) {
        return CreateWithOriginalComponents(Result.Resolve(inputIngredient.Type), inputIngredient, materialCount);
    }

    /// <summary>
    /// <c>TransmuteRecipe.createWithOriginalComponents</c>: the input's component patch under the
    /// result's own, so the result wins where both name a component.
    /// </summary>
    public static ItemStack CreateWithOriginalComponents(ItemStack result, ItemStack input,
        int extraCount) {

        Dictionary<IDataComponent, object> components = input.Components.ToDictionary();
        HashSet<IDataComponent> removed = [..input.RemoveComponents];

        foreach ((IDataComponent component, object value) in result.Components) {
            components[component] = value;
            removed.Remove(component);
        }

        foreach (IDataComponent component in result.RemoveComponents) {
            components.Remove(component);
            removed.Add(component);
        }

        return new ItemStack(result.Type, result.Count + extraCount, components, removed.ToArray());
    }
}
