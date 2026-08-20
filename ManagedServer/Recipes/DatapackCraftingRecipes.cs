using System.Text.Json;
using ManagedServer.Features.Impl;
using ManagedServer.Terrain.Data;
using Minecraft.Data.Recipes;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Recipes;

/// <summary>
/// Every crafting recipe a <see cref="IDatapackSource"/> carries.
/// </summary>
/// <remarks>
/// <b>Read rather than generated, because a recipe is content and not a measured fact</b>, and
/// nothing Mojang wrote ships here. <c>DatapackBlockLoot</c> is the same shape for the same reason.
/// <p/>
/// <b>Sorted here rather than left in directory order</b>, because the id ordering is the tie-break
/// between two recipes that accept one grid.
/// <p/>
/// <b>Recipes this build cannot make are declined by name, not dropped.</b> The pack's 1585 recipes
/// include smelting, stonecutting, smithing and the special crafting types; 17 more are the
/// suspicious stew recipes, whose results carry <c>minecraft:suspicious_stew_effects</c>, which has no
/// port. All land in <see cref="Declined"/>, so what a consumer loses is a number rather than a
/// silence. A handled type still throws on a field it does not know, see <see cref="RecipeParser"/>.
/// <p/>
/// Ingredients resolve their tags against <paramref name="registry"/> as they are built, so a second
/// registry needs its own load.
/// </remarks>
public sealed class DatapackCraftingRecipes : ICraftingRecipeSource {
    private static readonly Dictionary<(IDatapackSource, MinecraftRegistry), DatapackCraftingRecipes> Cache = new();
    private static readonly Lock CacheLock = new();

    private DatapackCraftingRecipes(IDatapackSource source, MinecraftRegistry registry) {
        List<ICraftingRecipe> recipes = [];
        List<UnportedRecipe> declined = [];

        foreach (DatapackEntry entry in source.Entries("recipe")) {
            using Stream stream = source.Open(entry.Path);
            using JsonDocument document = JsonDocument.Parse(stream);

            ICraftingRecipe? recipe = RecipeParser.Parse(document.RootElement, entry.Id, registry,
                out UnportedRecipe? unported);

            if (recipe is not null) {
                recipes.Add(recipe);
            }

            if (unported is { } reason) {
                declined.Add(reason);
            }
        }

        if (recipes.Count == 0) {
            throw new InvalidOperationException(
                $"\"{source.Describe()}\" carries no crafting recipes: it has no "
                + "data/<namespace>/recipe.");
        }

        recipes.Sort((left, right) => ICraftingRecipeSource.Order(left.Id, right.Id));

        Recipes = recipes;
        Declined = declined;
    }

    /// <summary>The recipes in a source, parsed once per registry and shared.</summary>
    public static DatapackCraftingRecipes Load(IDatapackSource source, MinecraftRegistry registry) {
        lock (CacheLock) {
            if (Cache.TryGetValue((source, registry), out DatapackCraftingRecipes? existing)) {
                return existing;
            }

            DatapackCraftingRecipes loaded = new(source, registry);
            Cache[(source, registry)] = loaded;
            return loaded;
        }
    }

    public IReadOnlyList<ICraftingRecipe> Recipes { get; }

    /// <summary>Every recipe this build made nothing of, with the reason. See the note on the class.</summary>
    public IReadOnlyList<UnportedRecipe> Declined { get; }

    /// <summary><see cref="Declined"/> as one line per reason with a count, for logging.</summary>
    public IEnumerable<string> DescribeDeclined() {
        return Declined
            .GroupBy(recipe => recipe.Reason)
            .OrderByDescending(group => group.Count())
            .Select(group => $"{group.Count()} recipes declined: {group.Key}");
    }
}
