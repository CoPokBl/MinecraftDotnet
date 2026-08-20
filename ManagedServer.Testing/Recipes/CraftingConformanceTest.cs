using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;
using ManagedServer.Features.Impl;
using ManagedServer.Recipes;
using ManagedServer.Testing.Terrain;
using Minecraft.Data.Generated;
using Minecraft.Data.Recipes;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Tags;

namespace ManagedServer.Testing.Recipes;

/// <summary>
/// Holds the crafting matcher against the game's own, over grids the game itself was asked about.
/// </summary>
/// <remarks>
/// <para>
/// Pins <c>shrink</c> and the cropping in <see cref="CraftingInput"/>, the horizontal mirror and the
/// symmetry check that skips it, <see cref="StackedContents"/>, and the <b>order</b> recipes are tried
/// in. Not the parse: the JSON is the source both sides read, so vanilla's codec over it only proves
/// vanilla agrees with itself, and <c>RecipeParser</c>'s unknown field check covers that half.
/// </para>
/// <para>
/// Both sides are restricted to the three recipe types this build implements. The fixture carries the
/// recipe ids it was built from and they are asserted against the port's, so a fixture and a pack that
/// have drifted apart fail here rather than comparing two different sets.
/// </para>
/// <para>Regenerate on a version bump, see Conformance/crafting.sh.</para>
/// </remarks>
[TestFixture]
public class CraftingConformanceTest {
    private const string Fixture = "Recipes/vanilla-crafting.bin.gz";

    /// <summary>How many differing grids to name before a failure message stops being useful.</summary>
    private const int Reported = 20;

    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private sealed record Case(int Width, int Height, Identifier?[] Items, string Recipe,
        Identifier? Result, int ResultCount);

    private sealed record MatcherCase(string Name, Identifier[][] Ingredients, Identifier[] Available,
        int[] Counts, int Capacity, bool Answer);

    private sealed record Remainder(Identifier Item, Identifier Leaves, int Count);

    private sealed record Loaded(string[] RecipeIds, Case[] Cases, MatcherCase[] Matchers,
        Remainder[] Remainders);

    [Test]
    public void MatchesTheSameRecipesVanillaDid() {
        Loaded fixture = Load();
        ICraftingRecipeSource recipes = DatapackCraftingRecipes.Load(VanillaPack.Source, Registry);

        Assert.That(recipes.Recipes.Select(recipe => recipe.Id.ToString()).ToArray(),
            Is.EqualTo(fixture.RecipeIds),
            "the fixture was built from a different set of recipes than the pack under test carries");

        List<string> differences = [];
        int matched = 0;

        foreach (Case expected in fixture.Cases) {
            ItemStack[] items = expected.Items
                .Select(item => item is { } id ? new ItemStack(Registry.Items[id]) : ItemStack.Air)
                .ToArray();

            CraftingInput input = CraftingInput.Of(expected.Width, expected.Height, items);
            ICraftingRecipe? recipe = recipes.Find(input);
            string actualRecipe = recipe?.Id.ToString() ?? "";

            if (actualRecipe != expected.Recipe) {
                Report(differences, expected,
                    $"picked {Describe(actualRecipe)}, vanilla picked {Describe(expected.Recipe)}");
                continue;
            }

            if (recipe is null) {
                continue;
            }

            matched++;
            ItemStack result = recipe.Assemble(input);
            Identifier? actualResult = result.IsAir() ? null : (Identifier?)result.Type.Identifier;

            if (actualResult != expected.Result || (actualResult is not null && result.Count != expected.ResultCount)) {
                Report(differences, expected,
                    $"{expected.Recipe} assembled {Describe(actualResult)} x{result.Count}, "
                    + $"vanilla assembled {Describe(expected.Result)} x{expected.ResultCount}");
            }
        }

        Assert.That(differences, Is.Empty,
            $"{differences.Count} of {fixture.Cases.Length} grids disagree with vanilla."
            + Environment.NewLine + string.Join(Environment.NewLine, differences.Take(Reported)));

        // A fixture whose grids all came out empty would pass everything above.
        Assert.That(matched, Is.GreaterThan(fixture.Cases.Length / 2),
            "the corpus barely matched anything, which means it is not testing the matcher");
    }

    /// <summary>
    /// <see cref="StackedContents"/> against the game's own, on the cases the corpus cannot reach.
    /// </summary>
    /// <remarks>
    /// The only cover the matcher has. Measured on the pack: no vanilla shapeless or transmute recipe
    /// has two ingredients whose item sets overlap without being equal, so a greedy matcher agrees
    /// with the real one on every vanilla grid there is. These are ingredient lists vanilla never
    /// writes, answered by the game rather than by a second reading of the algorithm.
    /// </remarks>
    [Test]
    public void MatchesTheSameIngredientSetsVanillaDid() {
        Loaded fixture = Load();

        Assert.That(fixture.Matchers, Is.Not.Empty,
            "the fixture carries no matcher cases; regenerate it with Conformance/crafting.sh");

        Assert.Multiple(() => {
            foreach (MatcherCase expected in fixture.Matchers) {
                StackedContents contents = new();

                for (int i = 0; i < expected.Available.Length; i++) {
                    contents.Account(expected.Available[i], expected.Counts[i]);
                }

                Ingredient[] ingredients = expected.Ingredients
                    .Select(items => new Ingredient(new HolderSet.Direct(items), Registry))
                    .ToArray();

                Assert.That(contents.TryPick(ingredients, expected.Capacity),
                    Is.EqualTo(expected.Answer), $"matcher case \"{expected.Name}\"");
            }
        });
    }

    /// <summary>
    /// <see cref="CraftingRemainders"/> against every item in the game, which is what makes a hand
    /// written table safe. An item gaining a remainder upstream would otherwise silently start being
    /// eaten by every recipe that uses it.
    /// </summary>
    [Test]
    public void KnowsEveryCraftingRemainderVanillaHas() {
        Loaded fixture = Load();

        Dictionary<string, string> expected = fixture.Remainders
            .ToDictionary(remainder => remainder.Item.ToString(),
                remainder => $"{remainder.Leaves} x{remainder.Count}");

        Dictionary<string, string> actual = CraftingRemainders.All
            .ToDictionary(entry => entry.Key.ToString(),
                entry => $"{entry.Value.Type.Identifier} x{entry.Value.Count}");

        Assert.That(actual, Is.EqualTo(expected));
    }

    private static void Report(List<string> differences, Case expected, string what) {
        if (differences.Count >= Reported) {
            differences.Add("...");
            return;
        }

        string grid = string.Join(", ", expected.Items.Select(item => item?.ToString() ?? "-"));
        differences.Add($"  {expected.Width}x{expected.Height} [{grid}]: {what}");
    }

    private static string Describe(string? id) => string.IsNullOrEmpty(id) ? "nothing" : id;
    private static string Describe(Identifier? id) => id?.ToString() ?? "nothing";

    // ---------------------------------------------------------------- reading

    private static Loaded Load() {
        string path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture);
        Assert.That(File.Exists(path), Is.True,
            $"{Fixture} is missing. Regenerate it with Conformance/crafting.sh.");

        using FileStream file = File.OpenRead(path);
        using GZipStream unzipped = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(unzipped);

        string magic = Encoding.ASCII.GetString(reader.ReadBytes(8));
        Assert.That(magic, Is.EqualTo("MCCRAFT1"), "unexpected fixture format");

        string[] recipeIds = new string[ReadInt(reader)];
        for (int i = 0; i < recipeIds.Length; i++) {
            recipeIds[i] = ReadJavaUtf(reader);
        }

        Identifier[] palette = new Identifier[ReadInt(reader)];
        for (int i = 0; i < palette.Length; i++) {
            palette[i] = ReadJavaUtf(reader);
        }

        Case[] cases = new Case[ReadInt(reader)];
        for (int i = 0; i < cases.Length; i++) {
            int width = reader.ReadByte();
            int height = reader.ReadByte();
            Identifier?[] items = new Identifier?[reader.ReadByte()];

            for (int cell = 0; cell < items.Length; cell++) {
                short index = ReadShort(reader);
                items[cell] = index < 0 ? null : (Identifier?)palette[index];
            }

            string recipe = ReadJavaUtf(reader);
            short result = ReadShort(reader);
            cases[i] = new Case(width, height, items, recipe,
                result < 0 ? null : (Identifier?)palette[result], reader.ReadByte());
        }

        MatcherCase[] matchers = new MatcherCase[ReadInt(reader)];
        for (int i = 0; i < matchers.Length; i++) {
            string name = ReadJavaUtf(reader);
            int capacity = reader.ReadByte();
            bool answer = reader.ReadByte() != 0;

            Identifier[][] ingredients = new Identifier[reader.ReadByte()][];
            for (int ingredient = 0; ingredient < ingredients.Length; ingredient++) {
                ingredients[ingredient] = new Identifier[reader.ReadByte()];
                for (int item = 0; item < ingredients[ingredient].Length; item++) {
                    ingredients[ingredient][item] = ReadJavaUtf(reader);
                }
            }

            Identifier[] available = new Identifier[reader.ReadByte()];
            int[] counts = new int[available.Length];
            for (int item = 0; item < available.Length; item++) {
                available[item] = ReadJavaUtf(reader);
                counts[item] = reader.ReadByte();
            }

            matchers[i] = new MatcherCase(name, ingredients, available, counts, capacity, answer);
        }

        Remainder[] remainders = new Remainder[ReadInt(reader)];
        for (int i = 0; i < remainders.Length; i++) {
            remainders[i] = new Remainder(ReadJavaUtf(reader), ReadJavaUtf(reader), reader.ReadByte());
        }

        return new Loaded(recipeIds, cases, matchers, remainders);
    }

    /// <summary>
    /// Java's <c>writeUTF</c>: big endian two byte length, then bytes. <c>BinaryReader.ReadString</c>
    /// reads a 7 bit encoded length and would silently desynchronise the stream.
    /// </summary>
    private static string ReadJavaUtf(BinaryReader reader) {
        int length = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    /// <summary>The fixture is big endian, as everything Java writes is.</summary>
    private static int ReadInt(BinaryReader reader) {
        return BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));
    }

    private static short ReadShort(BinaryReader reader) {
        return BinaryPrimitives.ReadInt16BigEndian(reader.ReadBytes(2));
    }
}
