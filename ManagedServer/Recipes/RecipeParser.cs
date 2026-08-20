using System.Text.Json;
using Minecraft.Data.Recipes;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Tags;

namespace ManagedServer.Recipes;

/// <summary>
/// A field this build does not know, on a recipe type it does handle. A whole unported <b>type</b> is
/// <see cref="UnportedRecipe"/> instead, which is counted rather than thrown.
/// </summary>
public sealed class UnportedRecipeException(string recipe, string what)
    : InvalidOperationException(
        $"{recipe} uses {what}, which has no port. Add one to Minecraft/Data/Recipes rather than "
        + "letting it slide: a field a recipe carries is a field that changes what it makes.");

/// <summary>
/// A recipe this build declined whole, and why. A declined recipe is a missing behaviour rather than
/// a wrong one, which is safe to carry past only while it stays <b>countable</b>.
/// </summary>
public readonly record struct UnportedRecipe(Identifier Id, string Type, string Reason);

/// <summary>
/// Reads vanilla's crafting recipe JSON into <see cref="ICraftingRecipe"/>.
/// </summary>
/// <remarks>
/// <b>An unknown field on a type this handles throws; an unknown type is declined by name.</b> A
/// field is the silent failure: <c>add_material_count_to_result</c> is absent on 32 of the 33 vanilla
/// transmute recipes and present on the one making firework rockets, so reading it as its default
/// quietly hands back one rocket. A missing whole recipe is not silent.
/// <p/>
/// No conformance harness for the parse, on <c>LootTableParser</c>'s reasoning: the JSON is the source
/// both sides read. <c>CraftingConformanceTest</c> pins the matching instead.
/// <p/>
/// <c>category</c>, <c>group</c> and <c>show_notification</c> are read and dropped: all three are
/// recipe book presentation.
/// </remarks>
public static class RecipeParser {
    /// <summary>Every recipe type this build makes a <see cref="ICraftingRecipe"/> out of.</summary>
    public static readonly IReadOnlySet<string> CraftingTypes = new HashSet<string> {
        "minecraft:crafting_shaped",
        "minecraft:crafting_shapeless",
        "minecraft:crafting_transmute"
    };

    /// <summary>
    /// One recipe, or null with <paramref name="declined"/> set for a type or result with no port.
    /// </summary>
    public static ICraftingRecipe? Parse(JsonElement root, Identifier id, MinecraftRegistry registry,
        out UnportedRecipe? declined) {

        string type = String(root, "type")
            ?? throw new InvalidOperationException($"{id}: recipe with no type.");

        declined = null;

        if (!CraftingTypes.Contains(type)) {
            declined = new UnportedRecipe(id, type, $"recipe type {type}");
            return null;
        }

        try {
            switch (type) {
                case "minecraft:crafting_shaped": {
                    Consumed(root, id, "type", "category", "group", "show_notification", "key",
                        "pattern", "result");

                    return new ShapedRecipe(id,
                        ShapedRecipePattern.Unpack(Key(root, id, registry), Pattern(root, id)),
                        Result(root, id, registry));
                }

                case "minecraft:crafting_shapeless": {
                    Consumed(root, id, "type", "category", "group", "ingredients", "result");

                    return new ShapelessRecipe(id,
                        List(root, "ingredients", element => ParseIngredient(element, id, registry)),
                        Result(root, id, registry));
                }

                case "minecraft:crafting_transmute": {
                    Consumed(root, id, "type", "category", "group", "input", "material",
                        "material_count", "result", "add_material_count_to_result");

                    (int min, int max) = MaterialCount(root, id);

                    return new TransmuteRecipe(id,
                        ParseIngredient(root.GetProperty("input"), id, registry),
                        ParseIngredient(root.GetProperty("material"), id, registry),
                        min, max,
                        Result(root, id, registry),
                        Bool(root, "add_material_count_to_result"));
                }

                default:
                    throw new UnportedRecipeException(id, $"recipe type {type}");
            }
        } catch (UnportedComponentException e) {
            declined = new UnportedRecipe(id, type, e.Message);
            return null;
        }
    }

    /// <summary>
    /// A result naming a data component with no port. Its own type so it can be caught where the
    /// recipe is, rather than confused with a field the parser failed to read.
    /// </summary>
    private sealed class UnportedComponentException(string component)
        : InvalidOperationException($"data component {component}");

    // ------------------------------------------------------------------ shaped

    private static Dictionary<char, Ingredient> Key(JsonElement recipe, Identifier id,
        MinecraftRegistry registry) {

        if (!recipe.TryGetProperty("key", out JsonElement key) || key.ValueKind != JsonValueKind.Object) {
            throw new InvalidOperationException($"{id}: shaped recipe with no key.");
        }

        Dictionary<char, Ingredient> result = [];

        foreach (JsonProperty symbol in key.EnumerateObject()) {
            if (symbol.Name.Length != 1) {
                throw new InvalidOperationException(
                    $"{id}: invalid key entry: '{symbol.Name}' is an invalid symbol "
                    + "(must be 1 character only).");
            }

            if (symbol.Name[0] == ShapedRecipePattern.EmptySlot) {
                throw new InvalidOperationException(
                    $"{id}: invalid key entry: ' ' is a reserved symbol.");
            }

            result[symbol.Name[0]] = ParseIngredient(symbol.Value, id, registry);
        }

        return result;
    }

    private static string[] Pattern(JsonElement recipe, Identifier id) {
        string[] rows = List(recipe, "pattern", row => row.GetString()!);

        if (rows.Length == 0) {
            throw new InvalidOperationException($"{id}: invalid pattern: empty pattern not allowed");
        }

        if (rows.Length > ShapedRecipePattern.MaxSize) {
            throw new InvalidOperationException(
                $"{id}: invalid pattern: too many rows, {ShapedRecipePattern.MaxSize} is maximum");
        }

        foreach (string row in rows) {
            if (row.Length > ShapedRecipePattern.MaxSize) {
                throw new InvalidOperationException(
                    $"{id}: invalid pattern: too many columns, {ShapedRecipePattern.MaxSize} is maximum");
            }

            if (row.Length != rows[0].Length) {
                throw new InvalidOperationException(
                    $"{id}: invalid pattern: each row must be the same width");
            }
        }

        return rows;
    }

    // ------------------------------------------------------------------ transmute

    /// <summary>
    /// <c>material_count</c> as a pair. Absent is <c>exactly(1)</c> rather than the full range, which
    /// is why a bundle recipe takes one dye and not up to eight.
    /// </summary>
    private static (int Min, int Max) MaterialCount(JsonElement recipe, Identifier id) {
        if (!recipe.TryGetProperty("material_count", out JsonElement bounds)) {
            return (TransmuteRecipe.DefaultMinMaterialCount, TransmuteRecipe.DefaultMinMaterialCount);
        }

        if (bounds.ValueKind == JsonValueKind.Number) {
            int exact = bounds.GetInt32();
            return (exact, exact);
        }

        Consumed(bounds, id, "min", "max");

        int min = Int(bounds, "min", TransmuteRecipe.DefaultMinMaterialCount);
        int max = Int(bounds, "max", TransmuteRecipe.DefaultMaxMaterialCount);

        // Vanilla's MATERIAL_COUNT_BOUNDS. Rejected rather than clamped: a count of zero makes a
        // recipe that matches its own input alone.
        if (min < TransmuteRecipe.DefaultMinMaterialCount || max > TransmuteRecipe.DefaultMaxMaterialCount
            || min > max) {

            throw new InvalidOperationException(
                $"{id}: material_count {min}..{max} is outside "
                + $"{TransmuteRecipe.DefaultMinMaterialCount}..{TransmuteRecipe.DefaultMaxMaterialCount}.");
        }

        return (min, max);
    }

    // ------------------------------------------------------------------ ingredients and results

    /// <summary>An item name, a <c>#tag</c> name, or a list of item names.</summary>
    private static Ingredient ParseIngredient(JsonElement ingredient, Identifier id,
        MinecraftRegistry registry) {

        if (ingredient.ValueKind == JsonValueKind.Array) {
            Identifier[] entries = ingredient.EnumerateArray()
                .Select(element => ItemId(element.GetString()!, id, registry))
                .ToArray();

            return new Ingredient(new HolderSet.Direct(entries), registry);
        }

        string value = ingredient.GetString()
            ?? throw new InvalidOperationException($"{id}: ingredient is neither a name nor a list.");

        return value.StartsWith('#')
            ? new Ingredient(new HolderSet.Tag(value[1..]), registry)
            : new Ingredient(new HolderSet.Direct([ItemId(value, id, registry)]), registry);
    }

    /// <summary>
    /// The result stack. A component with no port declines the whole recipe rather than producing a
    /// stack missing it.
    /// </summary>
    private static ItemStack Result(JsonElement recipe, Identifier id, MinecraftRegistry registry) {
        if (!recipe.TryGetProperty("result", out JsonElement result)) {
            throw new InvalidOperationException($"{id}: recipe with no result.");
        }

        if (result.ValueKind == JsonValueKind.String) {
            return new ItemStack(registry.Items[ItemId(result.GetString()!, id, registry)]);
        }

        Consumed(result, id, "id", "count", "components");

        if (result.TryGetProperty("components", out JsonElement components)) {
            foreach (JsonProperty component in components.EnumerateObject()) {
                throw new UnportedComponentException(component.Name);
            }
        }

        return new ItemStack(registry.Items[ItemId(String(result, "id")!, id, registry)],
            Int(result, "count", 1));
    }

    private static Identifier ItemId(string name, Identifier id, MinecraftRegistry registry) {
        Identifier item = name;

        if (!registry.Items.Contains(item)) {
            throw new InvalidOperationException($"{id}: no item called \"{name}\".");
        }

        return item;
    }

    // ------------------------------------------------------------------ helpers

    private static T[] List<T>(JsonElement node, string name, Func<JsonElement, T> map) {
        if (!node.TryGetProperty(name, out JsonElement array)
            || array.ValueKind != JsonValueKind.Array) {

            return [];
        }

        return array.EnumerateArray().Select(map).ToArray();
    }

    private static string? String(JsonElement node, string name) {
        return node.TryGetProperty(name, out JsonElement value) ? value.GetString() : null;
    }

    private static int Int(JsonElement node, string name, int fallback) {
        return node.TryGetProperty(name, out JsonElement value) ? value.GetInt32() : fallback;
    }

    private static bool Bool(JsonElement node, string name) {
        return node.TryGetProperty(name, out JsonElement value) && value.GetBoolean();
    }

    /// <summary>Asserts a node has no key beyond the ones just read. See the note on the class.</summary>
    private static void Consumed(JsonElement node, Identifier id, params string[] read) {
        foreach (JsonProperty property in node.EnumerateObject()) {
            if (!read.Contains(property.Name)) {
                throw new UnportedRecipeException(id, $"field {property.Name}");
            }
        }
    }
}
