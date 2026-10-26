using Minecraft.Data.Components;
using Minecraft.Data.Items;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Recipes;

/// <summary>
/// <c>TransmuteResult</c>: the item, count and component patch a transmute makes. A null
/// <see cref="Item"/> is <c>KEEP_INPUT_ITEM</c>'s shape, the item that went in, which is how map
/// cloning makes more of whatever map it was given.
/// </summary>
public sealed record TransmuteResult(
    IItem? Item,
    int Count,
    IReadOnlyDictionary<IDataComponent, object> Components,
    IReadOnlyCollection<IDataComponent> RemoveComponents) {

    /// <summary><c>TransmuteResult.resolve</c>: this result made of <paramref name="inputItem"/> if it names no item.</summary>
    public ItemStack Resolve(IItem inputItem) {
        return new ItemStack(Item ?? inputItem, Count, Components.ToDictionary(), RemoveComponents.ToArray());
    }
}
