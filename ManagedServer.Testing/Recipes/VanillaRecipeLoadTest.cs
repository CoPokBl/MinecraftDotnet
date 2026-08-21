using ManagedServer.Features.Impl;
using ManagedServer.Recipes;
using Minecraft.Data.Components.Types;
using ManagedServer.Testing.Terrain;
using Minecraft.Data.Generated;
using Minecraft.Data.Recipes;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Testing.Recipes;

/// <summary>
/// Reads every recipe in the vanilla pack, so a format change or a tag that stopped resolving fails
/// here rather than as a block somebody cannot craft.
/// </summary>
/// <remarks>
/// The counts move on a version bump; asserting them just means somebody has to look. The <b>set of
/// reasons a recipe was declined</b> is the part that must not move unnoticed.
/// </remarks>
[TestFixture]
public class VanillaRecipeLoadTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private static DatapackCraftingRecipes Load() {
        return DatapackCraftingRecipes.Load(VanillaPack.Source, Registry);
    }

    [Test]
    public void ReadsEveryCraftingRecipe() {
        DatapackCraftingRecipes recipes = Load();

        Assert.Multiple(() => {
            Assert.That(recipes.Recipes.OfType<ShapedRecipe>().Count(), Is.EqualTo(733));
            Assert.That(recipes.Recipes.OfType<ShapelessRecipe>().Count(), Is.EqualTo(323));
            Assert.That(recipes.Recipes.OfType<TransmuteRecipe>().Count(), Is.EqualTo(33));
        });
    }

    /// <summary>Anything new here is a recipe a player silently cannot make.</summary>
    [Test]
    public void DeclinesOnlyTheTypesWithNoPort() {
        DatapackCraftingRecipes recipes = Load();

        string[] reasons = recipes.Declined
            .Select(declined => declined.Reason)
            .Distinct()
            .Order(StringComparer.Ordinal)
            .ToArray();

        Assert.That(reasons, Is.EqualTo(new[] {
            "recipe type minecraft:blasting",
            "recipe type minecraft:campfire_cooking",
            "recipe type minecraft:crafting_decorated_pot",
            "recipe type minecraft:crafting_dye",
            "recipe type minecraft:crafting_imbue",
            "recipe type minecraft:crafting_special_bannerduplicate",
            "recipe type minecraft:crafting_special_bookcloning",
            "recipe type minecraft:crafting_special_firework_rocket",
            "recipe type minecraft:crafting_special_firework_star",
            "recipe type minecraft:crafting_special_firework_star_fade",
            "recipe type minecraft:crafting_special_mapextending",
            "recipe type minecraft:crafting_special_repairitem",
            "recipe type minecraft:crafting_special_shielddecoration",
            "recipe type minecraft:smelting",
            "recipe type minecraft:smithing_transform",
            "recipe type minecraft:smithing_trim",
            "recipe type minecraft:smoking",
            "recipe type minecraft:stonecutting"
        }));
    }

    /// <summary>
    /// The order ties are broken in: <c>Identifier.compareTo</c>, path before namespace, which is not
    /// the order the ids print in.
    /// </summary>
    [Test]
    public void IsSortedByPathThenNamespace() {
        IReadOnlyList<ICraftingRecipe> recipes = Load().Recipes;

        for (int i = 1; i < recipes.Count; i++) {
            Assert.That(ICraftingRecipeSource.Order(recipes[i - 1].Id, recipes[i].Id),
                Is.LessThan(0),
                $"{recipes[i - 1].Id} should sort before {recipes[i].Id}");
        }
    }

    /// <summary>
    /// A result's data components are read, not merely tolerated. Wither rose stew is the case: the
    /// recipe declines whole if the component has no persistent form, so a recipe that loads proves
    /// nothing on its own, and a result that carries the wrong effect is what this catches.
    /// </summary>
    [Test]
    public void ReadsDataComponentsOnAResult() {
        ShapelessRecipe recipe = Load().Recipes
            .OfType<ShapelessRecipe>()
            .First(candidate => candidate.Id == (Identifier)"minecraft:suspicious_stew_from_wither_rose");

        SuspiciousStewEffectsComponent.Entry[] effects =
            recipe.Result.Get(DataComponent.SuspiciousStewEffects);

        Assert.That(effects, Has.Length.EqualTo(1));
        Assert.Multiple(() => {
            Assert.That(effects[0].Effect.Identifier, Is.EqualTo((Identifier)"minecraft:wither"));
            Assert.That(effects[0].Duration, Is.EqualTo(140));
        });
    }

    /// <summary>Every ingredient resolved to something, so no recipe is unmatchable.</summary>
    [Test]
    public void EveryRecipeCanBePlaced() {
        Identifier[] impossible = Load().Recipes
            .Where(recipe => recipe.PlacementInfo.IsImpossibleToPlace)
            .Select(recipe => recipe.Id)
            .ToArray();

        Assert.That(impossible, Is.Empty);
    }
}
