using System.Collections.Frozen;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.Recipes;

/// <summary>
/// What a recipe accepts in one place, vanilla's <c>Ingredient</c>: a tag name or an explicit list.
/// </summary>
/// <remarks>
/// The set is resolved once and held, since <see cref="RegistryTagContainer.Contains"/> walks the tag
/// on every call and a grid is matched against every recipe on every click.
/// <p/>
/// <b>Equality is over <see cref="Values"/>, not over what it resolved to</b>, which is vanilla's:
/// <c>ShapedRecipePattern</c> compares ingredients to decide symmetry, and a pattern wrongly called
/// symmetrical never gets its mirrored match tried.
/// </remarks>
public sealed class Ingredient : IEquatable<Ingredient> {
    private readonly FrozenSet<Identifier> _items;

    /// <summary>The set as the datapack wrote it, a tag name or a list of item names.</summary>
    public HolderSet Values { get; }

    /// <exception cref="ArgumentException">
    /// The explicit list was empty or named air, as vanilla's constructor throws. A <b>tag</b> that
    /// resolves to nothing is not an error, it is a recipe <see cref="PlacementInfo"/> calls unplaceable.
    /// </exception>
    public Ingredient(HolderSet values, MinecraftRegistry registry) {
        Values = values;

        switch (values) {
            case HolderSet.Direct direct: {
                if (direct.Entries.Length == 0) {
                    throw new ArgumentException("An ingredient cannot be empty.", nameof(values));
                }

                foreach (Identifier entry in direct.Entries) {
                    if (entry == Generated.Item.Air.Identifier) {
                        throw new ArgumentException("An ingredient cannot contain air.", nameof(values));
                    }
                }

                _items = direct.Entries.ToFrozenSet();
                break;
            }

            case HolderSet.Tag tag: {
                _items = registry.Items.Tags.Tags.TryGetValue(tag.TagName, out IRegistryTag? contents)
                    ? contents.GetValueIds(registry).ToFrozenSet()
                    : FrozenSet<Identifier>.Empty;
                break;
            }

            default:
                throw new ArgumentException($"Unknown holder set {values.GetType().Name}.", nameof(values));
        }
    }

    /// <summary>Every item this accepts.</summary>
    public FrozenSet<Identifier> Items => _items;

    /// <summary><c>Ingredient.test</c>. Air is in no ingredient, so an empty stack never matches.</summary>
    public bool Test(ItemStack stack) {
        return _items.Contains(stack.Type.Identifier);
    }

    /// <summary><c>Ingredient.acceptsItem</c>.</summary>
    public bool AcceptsItem(Identifier item) {
        return _items.Contains(item);
    }

    /// <summary><c>Ingredient.isEmpty</c>: a tag that resolved to nothing, so nothing satisfies it.</summary>
    public bool IsEmpty => _items.Count == 0;

    /// <summary>
    /// <c>Ingredient.testOptionalIngredient</c>: absent demands an <b>empty</b> cell rather than
    /// accepting anything, which is what makes the gaps in a shaped pattern mean something.
    /// </summary>
    public static bool TestOptional(Ingredient? ingredient, ItemStack stack) {
        return ingredient?.Test(stack) ?? stack.IsAir();
    }

    public bool Equals(Ingredient? other) {
        return other is not null && Values.Equals(other.Values);
    }

    public override bool Equals(object? obj) {
        return obj is Ingredient other && Equals(other);
    }

    public override int GetHashCode() {
        return Values.GetHashCode();
    }
}
