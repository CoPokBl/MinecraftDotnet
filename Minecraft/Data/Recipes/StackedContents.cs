using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Recipes;

/// <summary>
/// Whether a set of ingredients can be satisfied out of what is available. Vanilla's
/// <c>StackedContents</c>, with <c>StackedItemContents</c>'s accounting folded in.
/// </summary>
/// <remarks>
/// <b>A maximum bipartite matching, not a tally.</b> With ingredients <c>#planks</c> and
/// <c>#logs</c> and an oak log in the grid, the greedy order that hands the log to <c>#planks</c>
/// first fails and the recipe is satisfiable anyway. <see cref="RecipePicker"/> is vanilla's
/// augmenting path search transcribed.
/// <p/>
/// Item order cannot change the answer and vanilla's own is not reproducible:
/// <c>getUniqueAvailableIngredientItems</c> iterates a <c>Reference2IntOpenHashMap</c>, so upstream's
/// is identity hash order. A maximum matching's size does not depend on it. The part that would is
/// the <c>output</c> callback reporting <i>which</i> items were spent, which is not ported.
/// </remarks>
public sealed class StackedContents {
    private readonly Dictionary<Identifier, int> _amounts = [];

    /// <summary><c>StackedContents.account</c>.</summary>
    public void Account(Identifier item, int count) {
        Put(item, count);
    }

    /// <summary><c>StackedItemContents.accountStack</c>: a stack contributes at most <paramref name="maxCount"/>.</summary>
    public void AccountStack(ItemStack stack, int maxCount) {
        if (stack.IsAir()) {
            return;
        }

        Account(stack.Type.Identifier, Math.Min(maxCount, stack.Count));
    }

    public void Clear() {
        _amounts.Clear();
    }

    /// <summary>
    /// <c>StackedContents.tryPick</c>: whether every ingredient can be given <paramref name="amount"/>
    /// of some item, each a different one.
    /// </summary>
    public bool TryPick(IReadOnlyList<Ingredient> ingredients, int amount) {
        return new RecipePicker(this, ingredients).TryPick(amount);
    }

    /// <summary>
    /// <c>StackedContents.tryPickAll</c>: the largest <c>amount</c> <see cref="TryPick"/> still
    /// answers true for.
    /// </summary>
    public int TryPickAll(IReadOnlyList<Ingredient> ingredients, int maxSize) {
        return new RecipePicker(this, ingredients).TryPickAll(maxSize);
    }

    private bool HasAtLeast(Identifier item, int count) {
        return _amounts.GetValueOrDefault(item) >= count;
    }

    private void Take(Identifier item, int amount) {
        int previous = _amounts.GetValueOrDefault(item);

        if (previous < amount) {
            throw new InvalidOperationException($"Took {amount} items, but only had {previous}");
        }

        _amounts[item] = previous - amount;
    }

    private void Put(Identifier item, int count) {
        _amounts[item] = _amounts.GetValueOrDefault(item) + count;
    }

    /// <summary><c>StackedContents.getUniqueAvailableIngredientItems</c>.</summary>
    private List<Identifier> GetUniqueAvailableIngredientItems(IReadOnlyList<Ingredient> ingredients) {
        List<Identifier> result = [];

        foreach ((Identifier item, int count) in _amounts) {
            if (count > 0 && AnyIngredientMatches(ingredients, item)) {
                result.Add(item);
            }
        }

        return result;
    }

    private static bool AnyIngredientMatches(IReadOnlyList<Ingredient> ingredients, Identifier item) {
        foreach (Ingredient ingredient in ingredients) {
            if (ingredient.AcceptsItem(item)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// <c>StackedContents.getResultUpperBound</c>. Ignores that two ingredients may want the same
    /// item, so it only bounds the search in <see cref="RecipePicker.TryPickAll"/>.
    /// </summary>
    private int GetResultUpperBound(IReadOnlyList<Ingredient> ingredients) {
        int min = int.MaxValue;

        foreach (Ingredient ingredient in ingredients) {
            int max = 0;

            foreach ((Identifier item, int itemCount) in _amounts) {
                if (itemCount <= max) {
                    continue;
                }

                if (ingredient.AcceptsItem(item)) {
                    max = itemCount;
                }

                if (max >= min) {
                    goto next;
                }
            }

            min = max;

            if (max == 0) {
                break;
            }

            next: ;
        }

        return min;
    }

    /// <summary>
    /// <c>StackedContents.RecipePicker</c>: the augmenting path search over the ingredient to item
    /// graph. The five flag arrays vanilla packs into one <c>BitSet</c> keep that layout, since the
    /// offset arithmetic is what the method bodies are written in terms of.
    /// </summary>
    private sealed class RecipePicker {
        private readonly StackedContents _contents;
        private readonly IReadOnlyList<Ingredient> _ingredients;
        private readonly int _ingredientCount;
        private readonly List<Identifier> _items;
        private readonly int _itemCount;
        private readonly bool[] _data;
        private readonly List<int> _path = [];

        public RecipePicker(StackedContents contents, IReadOnlyList<Ingredient> ingredients) {
            _contents = contents;
            _ingredients = ingredients;
            _ingredientCount = ingredients.Count;
            _items = contents.GetUniqueAvailableIngredientItems(ingredients);
            _itemCount = _items.Count;
            _data = new bool[VisitedIngredientCount + VisitedItemCount + SatisfiedCount
                + ConnectionCount + ResidualCount];

            SetInitialConnections();
        }

        private void SetInitialConnections() {
            for (int ingredient = 0; ingredient < _ingredientCount; ingredient++) {
                Ingredient ingredientInfo = _ingredients[ingredient];

                for (int item = 0; item < _itemCount; item++) {
                    if (ingredientInfo.AcceptsItem(_items[item])) {
                        SetConnection(item, ingredient);
                    }
                }
            }
        }

        public bool TryPick(int capacity) {
            if (capacity <= 0) {
                return true;
            }

            int satisfiedIngredientCount = 0;

            while (true) {
                List<int>? path = TryAssigningNewItem(capacity);

                if (path is null) {
                    bool isValidAssignment = satisfiedIngredientCount == _ingredientCount;
                    ClearAllVisited();
                    ClearSatisfied();

                    // Everything taken goes back either way: the picker answers a question rather
                    // than consuming anything.
                    for (int ingredient = 0; ingredient < _ingredientCount; ingredient++) {
                        for (int item = 0; item < _itemCount; item++) {
                            if (!IsAssigned(item, ingredient)) {
                                continue;
                            }

                            Unassign(item, ingredient);
                            _contents.Put(_items[item], capacity);
                            break;
                        }
                    }

                    return isValidAssignment;
                }

                int assignedItem = path[0];
                _contents.Take(_items[assignedItem], capacity);
                int satisfiedIngredient = path.Count - 1;
                SetSatisfied(path[satisfiedIngredient]);
                satisfiedIngredientCount++;

                // The path alternates item, ingredient: even steps assign, odd ones undo the
                // assignment that was in the way.
                for (int i = 0; i < path.Count - 1; i++) {
                    if (IsPathIndexItem(i)) {
                        Assign(path[i], path[i + 1]);
                    } else {
                        Unassign(path[i + 1], path[i]);
                    }
                }
            }
        }

        public int TryPickAll(int maxSize) {
            int min = 0;
            int max = Math.Min(maxSize, _contents.GetResultUpperBound(_ingredients)) + 1;

            while (true) {
                int mid = (min + max) / 2;

                if (TryPick(mid)) {
                    if (max - min <= 1) {
                        return mid;
                    }

                    min = mid;
                } else {
                    max = mid;
                }
            }
        }

        private static bool IsPathIndexItem(int index) {
            return (index & 1) == 0;
        }

        private List<int>? TryAssigningNewItem(int capacity) {
            ClearAllVisited();

            for (int item = 0; item < _itemCount; item++) {
                if (!_contents.HasAtLeast(_items[item], capacity)) {
                    continue;
                }

                List<int>? path = FindNewItemAssignmentPath(item);

                if (path is not null) {
                    return path;
                }
            }

            return null;
        }

        private List<int>? FindNewItemAssignmentPath(int startingItem) {
            _path.Clear();
            VisitItem(startingItem);
            _path.Add(startingItem);

            while (_path.Count > 0) {
                int pathLength = _path.Count;

                if (IsPathIndexItem(pathLength - 1)) {
                    int itemToAssign = _path[pathLength - 1];

                    for (int ingredient = 0; ingredient < _ingredientCount; ingredient++) {
                        if (HasVisitedIngredient(ingredient) || !HasConnection(itemToAssign, ingredient)
                            || IsAssigned(itemToAssign, ingredient)) {

                            continue;
                        }

                        VisitIngredient(ingredient);
                        _path.Add(ingredient);
                        break;
                    }
                } else {
                    int lastAssignedIngredient = _path[pathLength - 1];

                    if (!IsSatisfied(lastAssignedIngredient)) {
                        return _path;
                    }

                    for (int item = 0; item < _itemCount; item++) {
                        if (HasVisitedItem(item) || !IsAssigned(item, lastAssignedIngredient)) {
                            continue;
                        }

                        VisitItem(item);
                        _path.Add(item);
                        break;
                    }
                }

                // Nothing was added, so this end is a dead end and is backed out of.
                if (_path.Count == pathLength) {
                    _path.RemoveAt(_path.Count - 1);
                }
            }

            return null;
        }

        private int VisitedIngredientOffset => 0;
        private int VisitedIngredientCount => _ingredientCount;
        private int VisitedItemOffset => VisitedIngredientOffset + VisitedIngredientCount;
        private int VisitedItemCount => _itemCount;
        private int SatisfiedOffset => VisitedItemOffset + VisitedItemCount;
        private int SatisfiedCount => _ingredientCount;
        private int ConnectionOffset => SatisfiedOffset + SatisfiedCount;
        private int ConnectionCount => _ingredientCount * _itemCount;
        private int ResidualOffset => ConnectionOffset + ConnectionCount;
        private int ResidualCount => _ingredientCount * _itemCount;

        private bool IsSatisfied(int ingredient) => _data[SatisfiedOffset + ingredient];
        private void SetSatisfied(int ingredient) => _data[SatisfiedOffset + ingredient] = true;
        private void ClearSatisfied() => ClearRange(SatisfiedOffset, SatisfiedCount);

        private void SetConnection(int item, int ingredient) =>
            _data[ConnectionOffset + item * _ingredientCount + ingredient] = true;

        private bool HasConnection(int item, int ingredient) =>
            _data[ConnectionOffset + item * _ingredientCount + ingredient];

        private bool IsAssigned(int item, int ingredient) =>
            _data[ResidualOffset + item * _ingredientCount + ingredient];

        private void Assign(int item, int ingredient) =>
            _data[ResidualOffset + item * _ingredientCount + ingredient] = true;

        private void Unassign(int item, int ingredient) =>
            _data[ResidualOffset + item * _ingredientCount + ingredient] = false;

        private void VisitIngredient(int ingredient) => _data[VisitedIngredientOffset + ingredient] = true;
        private bool HasVisitedIngredient(int ingredient) => _data[VisitedIngredientOffset + ingredient];
        private void VisitItem(int item) => _data[VisitedItemOffset + item] = true;
        private bool HasVisitedItem(int item) => _data[VisitedItemOffset + item];

        private void ClearAllVisited() {
            ClearRange(VisitedIngredientOffset, VisitedIngredientCount);
            ClearRange(VisitedItemOffset, VisitedItemCount);
        }

        private void ClearRange(int offset, int count) {
            Array.Clear(_data, offset, count);
        }
    }
}
