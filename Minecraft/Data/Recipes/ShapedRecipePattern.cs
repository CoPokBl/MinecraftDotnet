namespace Minecraft.Data.Recipes;

/// <summary>
/// A shaped recipe's grid, vanilla's <c>ShapedRecipePattern</c>. One nullable ingredient per cell,
/// where null means the cell must be empty.
/// </summary>
/// <remarks>
/// Stored already shrunk, so <c>[" # ", " # ", "   "]</c> and <c>["#", "#"]</c> are one pattern.
/// <see cref="CraftingInput"/> crops the grid the same way.
/// </remarks>
public sealed class ShapedRecipePattern {
    /// <summary>Vanilla's <c>MAX_SIZE</c>.</summary>
    public const int MaxSize = 3;

    /// <summary>Vanilla's <c>EMPTY_SLOT</c>, the one symbol a key may not define.</summary>
    public const char EmptySlot = ' ';

    private readonly bool _symmetrical;

    public ShapedRecipePattern(int width, int height, Ingredient?[] ingredients) {
        if (ingredients.Length != width * height) {
            throw new ArgumentException(
                $"A {width}x{height} pattern needs {width * height} cells, got {ingredients.Length}.",
                nameof(ingredients));
        }

        Width = width;
        Height = height;
        Ingredients = ingredients;

        int ingredientCount = 0;
        foreach (Ingredient? ingredient in ingredients) {
            if (ingredient is not null) {
                ingredientCount++;
            }
        }

        IngredientCount = ingredientCount;
        _symmetrical = IsSymmetrical(width, height, ingredients);
    }

    public int Width { get; }
    public int Height { get; }

    /// <summary>One entry per cell, row major. Null is a cell that must be empty.</summary>
    public IReadOnlyList<Ingredient?> Ingredients { get; }

    public int IngredientCount { get; }

    /// <summary>
    /// Whether the pattern reads the same mirrored, so <see cref="Matches"/> can skip the flip.
    /// Over-reporting it loses real matches, which is why <see cref="Ingredient"/> compares the sets
    /// a recipe named rather than what they resolved to.
    /// </summary>
    public bool Symmetrical => _symmetrical;

    /// <summary><c>ShapedRecipePattern.unpack</c>: the key and pattern turned into cells.</summary>
    /// <exception cref="ArgumentException">
    /// A symbol the key does not define, or a key entry the pattern never uses. Both are vanilla's
    /// errors; the first would otherwise silently become an empty cell.
    /// </exception>
    public static ShapedRecipePattern Unpack(IReadOnlyDictionary<char, Ingredient> key,
        IReadOnlyList<string> pattern) {

        string[] shrunk = Shrink(pattern);

        if (shrunk.Length == 0) {
            throw new ArgumentException("A pattern cannot be entirely empty.", nameof(pattern));
        }

        int width = shrunk[0].Length;
        int height = shrunk.Length;
        Ingredient?[] ingredients = new Ingredient?[width * height];
        HashSet<char> unused = [..key.Keys];
        int cell = 0;

        foreach (string line in shrunk) {
            foreach (char symbol in line) {
                if (symbol == EmptySlot) {
                    ingredients[cell++] = null;
                } else {
                    if (!key.TryGetValue(symbol, out Ingredient? ingredient)) {
                        throw new ArgumentException(
                            $"Pattern references symbol '{symbol}' but it's not defined in the key",
                            nameof(pattern));
                    }

                    ingredients[cell++] = ingredient;
                }

                unused.Remove(symbol);
            }
        }

        if (unused.Count > 0) {
            throw new ArgumentException(
                "Key defines symbols that aren't used in pattern: " + string.Join(", ", unused.Order()),
                nameof(key));
        }

        return new ShapedRecipePattern(width, height, ingredients);
    }

    /// <summary>
    /// <c>ShapedRecipePattern.shrink</c>: the pattern with its blank border taken off. The horizontal
    /// bounds are for the <b>whole</b> pattern rather than per row, so the rows stay equal length.
    /// </summary>
    public static string[] Shrink(IReadOnlyList<string> pattern) {
        int left = int.MaxValue;
        int right = 0;
        int top = 0;
        int bottom = 0;

        for (int i = 0; i < pattern.Count; i++) {
            string line = pattern[i];
            left = Math.Min(left, FirstNonEmpty(line));
            int lastNonSpace = LastNonEmpty(line);
            right = Math.Max(right, lastNonSpace);

            if (lastNonSpace < 0) {
                // A blank row counts towards the top crop only while every row so far was blank.
                if (top == i) {
                    top++;
                }

                bottom++;
            } else {
                bottom = 0;
            }
        }

        if (pattern.Count == bottom) {
            return [];
        }

        string[] result = new string[pattern.Count - bottom - top];
        for (int line = 0; line < result.Length; line++) {
            result[line] = pattern[line + top].Substring(left, right + 1 - left);
        }

        return result;
    }

    private static int FirstNonEmpty(string line) {
        int index = 0;
        while (index < line.Length && line[index] == EmptySlot) {
            index++;
        }

        return index;
    }

    private static int LastNonEmpty(string line) {
        int index = line.Length - 1;
        while (index >= 0 && line[index] == EmptySlot) {
            index--;
        }

        return index;
    }

    /// <summary><c>Util.isSymmetrical</c>.</summary>
    private static bool IsSymmetrical(int width, int height, Ingredient?[] ingredients) {
        if (width == 1) {
            return true;
        }

        int centerX = width / 2;

        for (int y = 0; y < height; y++) {
            for (int leftX = 0; leftX < centerX; leftX++) {
                int rightX = width - 1 - leftX;
                Ingredient? left = ingredients[leftX + y * width];
                Ingredient? right = ingredients[rightX + y * width];

                if (!Equals(left, right)) {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// <c>ShapedRecipePattern.matches</c>: the input as written or <b>mirrored horizontally</b>.
    /// </summary>
    /// <remarks>
    /// The count check is not an optimisation. Both sides are cropped to the same size, so without it
    /// an extra item outside the pattern would go unseen.
    /// </remarks>
    public bool Matches(CraftingInput input) {
        if (input.IngredientCount != IngredientCount) {
            return false;
        }

        if (input.Width != Width || input.Height != Height) {
            return false;
        }

        return (!_symmetrical && Matches(input, true)) || Matches(input, false);
    }

    private bool Matches(CraftingInput input, bool xFlip) {
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                Ingredient? expected = xFlip
                    ? Ingredients[Width - x - 1 + y * Width]
                    : Ingredients[x + y * Width];

                if (!Ingredient.TestOptional(expected, input[x, y])) {
                    return false;
                }
            }
        }

        return true;
    }
}
