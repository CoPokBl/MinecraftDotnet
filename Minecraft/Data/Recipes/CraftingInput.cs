using Minecraft.Schemas.Items;

namespace Minecraft.Data.Recipes;

/// <summary>
/// The contents of a crafting grid as a recipe sees them, vanilla's <c>CraftingInput</c>.
/// </summary>
/// <remarks>
/// <b>This is the shrunk grid, not the window's.</b> <see cref="OfPositioned"/> crops away every
/// empty row and column, so a two by two shape placed in the bottom right of a crafting table
/// arrives here as a two by two input, and a shaped recipe can compare sizes directly instead of
/// sliding its pattern around. <see cref="Positioned.Left"/> and <see cref="Positioned.Top"/> carry
/// where the crop came from, which is what lets the consumption step find the window slot an input
/// item came out of.
/// </remarks>
public sealed class CraftingInput {
    public static readonly CraftingInput Empty = new(0, 0, []);

    private readonly ItemStack[] _items;

    private CraftingInput(int width, int height, ItemStack[] items) {
        Width = width;
        Height = height;
        _items = items;

        int ingredientCount = 0;
        foreach (ItemStack item in items) {
            if (item.IsAir()) {
                continue;
            }

            ingredientCount++;

            // One per slot rather than the stack's whole count, since a craft spends one item from
            // each cell however tall the stack in it is. Built here rather than per recipe because
            // one grid is matched against every recipe there is.
            StackedContents.AccountStack(item, 1);
        }

        IngredientCount = ingredientCount;
    }

    public int Width { get; }
    public int Height { get; }

    /// <summary>How many slots hold something, which is a shaped recipe's first and cheapest rejection.</summary>
    public int IngredientCount { get; }

    /// <summary>
    /// What is in the grid as counts per item, which is what a shapeless recipe matches against.
    /// Vanilla builds it on the input for the same reason: it is the same tally for every recipe the
    /// grid is tried against.
    /// </summary>
    public StackedContents StackedContents { get; } = new();

    public int Size => _items.Length;
    public bool IsEmpty => IngredientCount == 0;

    public ItemStack this[int index] => _items[index];
    public ItemStack this[int x, int y] => _items[x + y * Width];

    /// <summary>The items in grid order, for a caller that wants to walk them itself.</summary>
    public IReadOnlyList<ItemStack> Items => _items;

    /// <summary><c>CraftingInput.of</c>: the cropped grid, with where it was cropped from thrown away.</summary>
    public static CraftingInput Of(int width, int height, IReadOnlyList<ItemStack> items) {
        return OfPositioned(width, height, items).Input;
    }

    /// <summary><c>CraftingInput.ofPositioned</c>.</summary>
    public static Positioned OfPositioned(int width, int height, IReadOnlyList<ItemStack> items) {
        if (width == 0 || height == 0) {
            return Positioned.EmptyPositioned;
        }

        int left = width - 1;
        int right = 0;
        int top = height - 1;
        int bottom = 0;

        for (int y = 0; y < height; y++) {
            bool rowEmpty = true;

            for (int x = 0; x < width; x++) {
                if (items[x + y * width].IsAir()) {
                    continue;
                }

                left = Math.Min(left, x);
                right = Math.Max(right, x);
                rowEmpty = false;
            }

            if (!rowEmpty) {
                top = Math.Min(top, y);
                bottom = Math.Max(bottom, y);
            }
        }

        int newWidth = right - left + 1;
        int newHeight = bottom - top + 1;

        if (newWidth <= 0 || newHeight <= 0) {
            return Positioned.EmptyPositioned;
        }

        if (newWidth == width && newHeight == height) {
            return new Positioned(new CraftingInput(width, height, items.ToArray()), left, top);
        }

        ItemStack[] cropped = new ItemStack[newWidth * newHeight];
        for (int y = 0; y < newHeight; y++) {
            for (int x = 0; x < newWidth; x++) {
                cropped[x + y * newWidth] = items[x + left + (y + top) * width];
            }
        }

        return new Positioned(new CraftingInput(newWidth, newHeight, cropped), left, top);
    }

    /// <summary>
    /// A cropped input and the corner of the original grid it was cropped from.
    /// </summary>
    public readonly record struct Positioned(CraftingInput Input, int Left, int Top) {
        public static readonly Positioned EmptyPositioned = new(Empty, 0, 0);
    }
}
