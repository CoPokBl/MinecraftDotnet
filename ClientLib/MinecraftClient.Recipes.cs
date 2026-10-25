using ClientLib.Inventory;
using ClientLib.Recipes;
using Minecraft.Data.Items;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Recipes;
using Minecraft.Schemas.Tags;
using RecipeBookType = Minecraft.Packets.Play.ServerBound.ServerBoundChangeRecipeBookSettingsPacket.RecipeBookType;

namespace ClientLib;

/// <summary>The recipe book: what the server has unlocked, and the packets the book screens send about it.</summary>
public sealed partial class MinecraftClient {
    private Task<RecipeSearchTree>? _recipeSearch;
    private CancellationTokenSource? _recipeSearchCancel;
    private int _recipeSearchLanguage;
    private (Dictionary<Identifier, Dictionary<Identifier, int[]>> Tags, IReadOnlyList<IItem> Items)? _fuelItems;

    /// <summary>
    /// <c>LocalPlayer.getRecipeBook</c>. Vanilla hands the book from one player to the next on a respawn and makes
    /// a new one only on a login, which is when this one is replaced.
    /// </summary>
    public ClientRecipeBook RecipeBook { get; private set; } = new();

    /// <summary>
    /// <c>refreshRecipeBook</c>'s <c>recipesUpdated</c>: the book changed, so an open book screen should look again.
    /// </summary>
    public event Action? RecipesUpdated;

    /// <summary><c>handlePlaceRecipe</c>: the server's ghost of a recipe the open menu could not fill.</summary>
    public event Action<RecipeDisplay>? GhostRecipePlaced;

    /// <summary><c>RecipeToast.addOrUpdate</c>, once for each recipe the server added with its notification flag.</summary>
    public event Action<RecipeDisplay>? RecipeToastRequested;

    /// <summary>
    /// The tooltip lines the recipe search matches a result by. Set by the host to its own tooltip builder; by default
    /// the item's name.
    /// </summary>
    public Func<ItemStack, IEnumerable<string>> RecipeSearchLines { get; set; } = stack => [TextFlattener.Plain(ItemNames.HoverName(stack)).Trim()];

    /// <summary>
    /// <c>SessionSearchTrees.recipes</c>, built when first searched after the book changed, or after the language did,
    /// as <c>rebuildAfterLanguageChange</c> rebuilds it.
    /// </summary>
    public RecipeSearchTree RecipeSearch {
        get {
            if (_recipeSearch == null || _recipeSearchLanguage != Translations.Generation) {
                StartRecipeSearchBuild();
            }
            return _recipeSearch!.GetAwaiter().GetResult();
        }
    }

    private bool HandleRecipePacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundRecipeBookAddPacket add:
                if (add.Replace) {
                    RecipeBook.Clear();
                }
                foreach (ClientBoundRecipeBookAddPacket.Entry entry in add.Entries) {
                    RecipeBook.Add(entry.Contents);
                    if (entry.Highlight) {
                        RecipeBook.AddHighlight(entry.Contents.Id);
                    }
                    if (entry.Notification) {
                        RecipeToastRequested?.Invoke(entry.Contents.Display);
                    }
                }
                RefreshRecipeBook();
                return true;

            case ClientBoundRecipeBookRemovePacket remove:
                foreach (int id in remove.RecipeIds) {
                    RecipeBook.Remove(id);
                }
                RefreshRecipeBook();
                return true;

            case ClientBoundRecipeBookSettingsPacket settings:
                RecipeBook.SetBookSettings(settings.Settings);
                RefreshRecipeBook();
                return true;

            case ClientBoundPlaceGhostRecipePacket ghost:
                if (ActiveMenu.WindowId == ghost.WindowId) {
                    GhostRecipePlaced?.Invoke(ghost.Recipe);
                }
                return true;

            default:
                return false;
        }
    }

    private void RefreshRecipeBook() {
        RecipeBook.RebuildCollections();
        StartRecipeSearchBuild();
        RecipesUpdated?.Invoke();
    }

    /// <summary>
    /// <c>SessionSearchTrees.updateRecipes</c>: the tree is built off the main thread, a few tens of milliseconds for a
    /// full book, from a snapshot of the tags and fuels, and a newer build cancels the one before it.
    /// </summary>
    private void StartRecipeSearchBuild() {
        _recipeSearchCancel?.Cancel();
        CancellationTokenSource cancel = _recipeSearchCancel = new CancellationTokenSource();
        _recipeSearchLanguage = Translations.Generation;
        Dictionary<Identifier, int[]> itemTags = Tags.TryGetValue("minecraft:item", out Dictionary<Identifier, int[]>? tags) ? new(tags) : new();
        IReadOnlyList<IItem> fuels = FuelItems();
        SlotDisplayContext context = new(Registry, tag => itemTags.GetValueOrDefault(tag), () => fuels);
        IReadOnlyList<RecipeCollection> collections = RecipeBook.Collections;
        Func<ItemStack, IEnumerable<string>> lines = RecipeSearchLines;
        _recipeSearch = Task.Run(() => BuildRecipeSearch(collections, context, lines, cancel.Token));
    }

    private static RecipeSearchTree BuildRecipeSearch(IReadOnlyList<RecipeCollection> collections, SlotDisplayContext context,
        Func<ItemStack, IEnumerable<string>> lines, CancellationToken cancel) {
        Dictionary<RecipeCollection, List<ItemStack>> results = new(ReferenceEqualityComparer.Instance);
        List<ItemStack> Results(RecipeCollection collection) {
            if (!results.TryGetValue(collection, out List<ItemStack>? stacks)) {
                cancel.ThrowIfCancellationRequested();
                results[collection] = stacks = collection.Recipes.SelectMany(entry => entry.Display.Result.ResolveForStacks(context)).ToList();
            }
            return stacks;
        }
        try {
            return new RecipeSearchTree(collections,
                collection => Results(collection).SelectMany(lines),
                collection => Results(collection).Select(stack => stack.Type.Identifier));
        }
        catch (OperationCanceledException) {
            return RecipeSearchTree.Empty;
        }
    }

    /// <summary><c>SlotDisplayContext.fromLevel</c>: this connection's registries, its item tags and its fuels.</summary>
    public SlotDisplayContext SlotDisplayContext() => new(Registry, tag => TagMembers("minecraft:item", tag), FuelItems);

    /// <summary>
    /// <c>FuelValues.fuelItems</c>, in item registry order. Only what a slot cycles through depends on the order, and
    /// only membership reaches the server, through what a furnace's fuel slot accepts.
    /// </summary>
    private IReadOnlyList<IItem> FuelItems() {
        if (_fuelItems is { } cached && ReferenceEquals(cached.Tags, Tags)) {
            return cached.Items;
        }
        SyncMenuData();
        List<IItem> items = [];
        for (int id = 0; id < Registry.Items.Count; id++) {
            IItem item = Registry.Items[id];
            if (ItemRules.IsFuel(Stack.Of(new ItemStack(item)), Inventory.Data)) {
                items.Add(item);
            }
        }
        _fuelItems = (Tags, items);
        return items;
    }

    /// <summary>The items an <see cref="IdSet"/> names, a tag resolved against the server's tags.</summary>
    public IEnumerable<Identifier> ResolveItemSet(IdSet set) => ResolveItems(set);

    /// <summary><c>RecipeBookComponent.sendUpdateSettings</c>: one book's open and filtering state as it now stands.</summary>
    public void SendRecipeBookSettings(RecipeBookType type) {
        Send(new ServerBoundChangeRecipeBookSettingsPacket { BookType = type, Open = RecipeBook.IsOpen(type), Filtering = RecipeBook.IsFiltering(type) });
    }

    /// <summary><c>MultiPlayerGameMode.handlePlaceRecipe</c>.</summary>
    public void PlaceRecipe(int containerId, int recipe, bool useMaxItems) {
        Send(new ServerBoundPlaceRecipePacket { WindowId = containerId, RecipeId = recipe, UseMaxItems = useMaxItems });
    }

    /// <summary><c>LocalPlayer.removeRecipeHighlight</c>: the seen packet goes once, the first time the book shows it.</summary>
    public void RemoveRecipeHighlight(int recipe) {
        if (RecipeBook.WillHighlight(recipe)) {
            RecipeBook.RemoveHighlight(recipe);
            Send(new ServerBoundSetSeenRecipePacket { RecipeId = recipe });
        }
    }

    private void ResetRecipeBookForLogin() {
        RecipeBook = new ClientRecipeBook();
        _recipeSearchCancel?.Cancel();
        _recipeSearch = null;
    }
}
