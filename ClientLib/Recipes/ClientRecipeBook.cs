using Minecraft.Data.RecipeBookCategories;
using Minecraft.Schemas.Recipes;
using RecipeBookType = Minecraft.Packets.Play.ServerBound.ServerBoundChangeRecipeBookSettingsPacket.RecipeBookType;

namespace ClientLib.Recipes;

/// <summary>
/// <c>ClientRecipeBook</c>: the recipes the server has unlocked for this player, which of them are still
/// highlighted as new, and the open and filtering state of each of the four books.
/// </summary>
public sealed class ClientRecipeBook {
    private readonly Dictionary<int, RecipeDisplayEntry> _known = new();
    private readonly JavaHashMapOrder _knownOrder = new();
    private readonly HashSet<int> _highlight = [];
    private readonly RecipeBookSettings.TypeSettings[] _settings = Enumerable.Repeat(RecipeBookSettings.TypeSettings.Default, 4).ToArray();
    private Dictionary<IRecipeBookCategory, List<RecipeCollection>> _byCategory = new();
    private List<RecipeCollection> _all = [];

    public IReadOnlyDictionary<int, RecipeDisplayEntry> Known => _known;

    public bool IsOpen(RecipeBookType type) => _settings[(int)type].Open;

    public void SetOpen(RecipeBookType type, bool open) => _settings[(int)type] = _settings[(int)type] with { Open = open };

    public bool IsFiltering(RecipeBookType type) => _settings[(int)type].Filtering;

    public void SetFiltering(RecipeBookType type, bool filtering) => _settings[(int)type] = _settings[(int)type] with { Filtering = filtering };

    /// <summary><c>setBookSettings</c>, from <c>recipe_book_settings</c>.</summary>
    public void SetBookSettings(RecipeBookSettings settings) {
        _settings[(int)RecipeBookType.Crafting] = settings.Crafting;
        _settings[(int)RecipeBookType.Furnace] = settings.Furnace;
        _settings[(int)RecipeBookType.BlastFurnace] = settings.BlastFurnace;
        _settings[(int)RecipeBookType.Smoker] = settings.Smoker;
    }

    public void Add(RecipeDisplayEntry entry) {
        _known[entry.Id] = entry;
        _knownOrder.Put(entry.Id);
    }

    public void Remove(int id) {
        if (_known.Remove(id)) {
            _knownOrder.Remove(id);
        }
        _highlight.Remove(id);
    }

    public void Clear() {
        _known.Clear();
        _knownOrder.Clear();
        _highlight.Clear();
    }

    public bool WillHighlight(int id) => _highlight.Contains(id);

    public void RemoveHighlight(int id) => _highlight.Remove(id);

    public void AddHighlight(int id) => _highlight.Add(id);

    /// <summary>
    /// <c>rebuildCollections</c>: one collection per ungrouped recipe and one per group, in each category in
    /// the order the known recipes iterate, which is the order of the book's buttons.
    /// </summary>
    public void RebuildCollections() {
        Dictionary<IRecipeBookCategory, List<RecipeCollection>> byCategory = new();
        Dictionary<(IRecipeBookCategory, int), List<RecipeDisplayEntry>> groups = new();
        Dictionary<IRecipeBookCategory, List<List<RecipeDisplayEntry>>> lists = new();
        foreach (int id in _knownOrder.Keys) {
            RecipeDisplayEntry entry = _known[id];
            if (!lists.TryGetValue(entry.Category, out List<List<RecipeDisplayEntry>>? categoryLists)) {
                lists[entry.Category] = categoryLists = [];
            }
            if (entry.Group is not { } group) {
                categoryLists.Add([entry]);
                continue;
            }
            if (!groups.TryGetValue((entry.Category, group), out List<RecipeDisplayEntry>? groupList)) {
                groups[(entry.Category, group)] = groupList = [];
                categoryLists.Add(groupList);
            }
            groupList.Add(entry);
        }
        List<RecipeCollection> all = [];
        foreach ((IRecipeBookCategory category, List<List<RecipeDisplayEntry>> categoryLists) in lists) {
            List<RecipeCollection> collections = categoryLists.Select(list => new RecipeCollection(list)).ToList();
            byCategory[category] = collections;
            all.AddRange(collections);
        }
        _byCategory = byCategory;
        _all = all;
    }

    public IReadOnlyList<RecipeCollection> Collections => _all;

    /// <summary><c>getCollection</c>: a search tab is its categories' collections one after another.</summary>
    public IReadOnlyList<RecipeCollection> Collection(RecipeBookTab tab) => tab switch {
        RecipeBookTab.Single single => _byCategory.GetValueOrDefault(single.Category) ?? [],
        RecipeBookTab.Search search => search.Included.SelectMany(c => _byCategory.GetValueOrDefault(c) ?? []).ToList(),
        _ => []
    };

    /// <summary>
    /// The order <c>java.util.HashMap</c> iterates <c>RecipeDisplayId</c> keys in: buckets in index order and
    /// each bucket in insertion order, over a table that starts at 16 and doubles past three quarters full and
    /// never shrinks. A record of one int hashes to that int. The server numbers displays across its whole
    /// recipe list, so a player who knows a handful of recipes has ids far past the table size and the order is
    /// nothing like ascending. It decides the order of the book's buttons and so of the seen packets a page sends.
    /// </summary>
    /// <remarks>
    /// A bucket of nine or more in a table of 64 or more becomes a tree upstream, whose order for a key that is not
    /// <c>Comparable</c> falls to identity hash codes, so vanilla's own order there differs run to run. That takes
    /// nine displays the server numbered a multiple of the table size apart; insertion order is kept for them.
    /// </remarks>
    private sealed class JavaHashMapOrder {
        private readonly Dictionary<int, long> _sequence = new();
        private int _capacity;
        private long _next;

        public void Put(int key) {
            if (_sequence.ContainsKey(key)) {
                return;
            }
            if (_capacity == 0) {
                _capacity = 16;
            }
            _sequence[key] = _next++;
            if (_sequence.Count > _capacity * 3 / 4) {
                _capacity *= 2;
            }
        }

        public void Remove(int key) => _sequence.Remove(key);

        public void Clear() => _sequence.Clear();

        private static int Spread(int hash) => hash ^ (int)((uint)hash >> 16);

        public IEnumerable<int> Keys => _sequence.Keys
            .OrderBy(key => Spread(key) & (_capacity - 1))
            .ThenBy(key => _sequence[key]);
    }
}

/// <summary><c>RecipeCollection</c>: the recipes one book button stands for, and which of them the open menu can show and make.</summary>
public sealed class RecipeCollection(IReadOnlyList<RecipeDisplayEntry> entries) {
    public static readonly RecipeCollection EmptyCollection = new([]);

    private readonly HashSet<int> _craftable = [];
    private readonly HashSet<int> _selected = [];

    public IReadOnlyList<RecipeDisplayEntry> Recipes => entries;

    /// <summary><c>selectRecipes</c>: which the menu can display, and of those which the contents can make.</summary>
    public void SelectRecipes(Func<RecipeDisplayEntry, bool> canCraft, Func<RecipeDisplay, bool> selector) {
        foreach (RecipeDisplayEntry entry in entries) {
            bool isSelected = selector(entry.Display);
            if (isSelected) {
                _selected.Add(entry.Id);
            }
            else {
                _selected.Remove(entry.Id);
            }
            if (isSelected && canCraft(entry)) {
                _craftable.Add(entry.Id);
            }
            else {
                _craftable.Remove(entry.Id);
            }
        }
    }

    public bool IsCraftable(int id) => _craftable.Contains(id);

    public bool HasCraftable => _craftable.Count > 0;

    public bool HasAnySelected => _selected.Count > 0;

    public List<RecipeDisplayEntry> SelectedRecipes(CraftableStatus status) {
        List<RecipeDisplayEntry> result = [];
        foreach (RecipeDisplayEntry entry in entries) {
            bool keep = status switch {
                CraftableStatus.Any => _selected.Contains(entry.Id),
                CraftableStatus.Craftable => _craftable.Contains(entry.Id),
                _ => _selected.Contains(entry.Id) && !_craftable.Contains(entry.Id)
            };
            if (keep) {
                result.Add(entry);
            }
        }
        return result;
    }

    public enum CraftableStatus {
        Any,
        Craftable,
        NotCraftable
    }
}

/// <summary><c>ExtendedRecipeBookCategory</c>: a book tab, either one category or the search tab over several.</summary>
public abstract record RecipeBookTab {
    public sealed record Single(IRecipeBookCategory Category) : RecipeBookTab;

    /// <summary><c>SearchRecipeBookCategory</c>: the compass tab.</summary>
    public sealed record Search(RecipeBookType Book, IReadOnlyList<IRecipeBookCategory> Included) : RecipeBookTab;

    public static readonly Search CraftingSearch = new(RecipeBookType.Crafting, [
        Minecraft.Data.Generated.RecipeBookCategory.CraftingEquipment, Minecraft.Data.Generated.RecipeBookCategory.CraftingBuildingBlocks,
        Minecraft.Data.Generated.RecipeBookCategory.CraftingMisc, Minecraft.Data.Generated.RecipeBookCategory.CraftingRedstone
    ]);

    public static readonly Search FurnaceSearch = new(RecipeBookType.Furnace, [
        Minecraft.Data.Generated.RecipeBookCategory.FurnaceFood, Minecraft.Data.Generated.RecipeBookCategory.FurnaceBlocks,
        Minecraft.Data.Generated.RecipeBookCategory.FurnaceMisc
    ]);

    public static readonly Search BlastFurnaceSearch = new(RecipeBookType.BlastFurnace, [
        Minecraft.Data.Generated.RecipeBookCategory.BlastFurnaceBlocks, Minecraft.Data.Generated.RecipeBookCategory.BlastFurnaceMisc
    ]);

    public static readonly Search SmokerSearch = new(RecipeBookType.Smoker, [Minecraft.Data.Generated.RecipeBookCategory.SmokerFood]);

    public static IEnumerable<Search> AllSearches => [CraftingSearch, FurnaceSearch, BlastFurnaceSearch, SmokerSearch];
}
