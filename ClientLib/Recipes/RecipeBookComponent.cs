using ClientLib.Inventory;
using ClientLib.Player;
using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Data.Recipes;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Recipes;
using Minecraft.Schemas.Tags;
using RecipeBookType = Minecraft.Packets.Play.ServerBound.ServerBoundChangeRecipeBookSettingsPacket.RecipeBookType;
using Slot = ClientLib.Inventory.Slot;

namespace ClientLib.Recipes;

/// <summary>A book tab's icons and what it shows: <c>RecipeBookComponent.TabInfo</c>.</summary>
public sealed record RecipeBookTabInfo(IItem PrimaryIcon, IItem? SecondaryIcon, RecipeBookTab Tab);

/// <summary>
/// <c>RecipeBookComponent</c> with <c>RecipeBookPage</c>, <c>RecipeButton</c>, <c>RecipeBookTabButton</c>,
/// <c>OverlayRecipeComponent</c> and <c>GhostSlots</c>: everything but the drawing and the search box. Positions
/// are vanilla's in GUI pixels, so the screen that draws it hit tests the same rectangles.
/// </summary>
/// <remarks>
/// What reaches the server is transcribed: which settings packet goes when, the place packet and when a repeat is
/// refused, and the seen packets a page sends as it shows a highlighted recipe.
/// </remarks>
public abstract class RecipeBookComponent {
    public const int ImageWidth = 147, ImageHeight = 166;
    private const int OffsetXPosition = 86;
    public const int ItemsPerPage = 20;
    public const int ButtonSize = 25;
    public const int TabWidth = 35, TabHeight = 27;
    private const float TicksToSwapSlot = 30.0F;
    private const float AnimationTime = 15.0F;

    protected MinecraftClient Client { get; }
    public ContainerMenu Menu { get; }
    public RecipeBookType BookType { get; }
    public IReadOnlyList<RecipeBookTabInfo> TabInfos { get; }

    /// <summary>The filter button's name while it filters: craftable, smeltable, smokable or blastable.</summary>
    public string FilterNameKey { get; }

    public bool IsFurnaceMenu { get; }

    private ClientRecipeBook Book => Client.RecipeBook;

    private int _xOffset, _width, _height;
    private float _time;
    private int? _lastPlacedRecipe;
    private int? _lastRecipe;
    private RecipeCollection? _lastRecipeCollection;
    private readonly StackedContents _stackedContents = new();
    private readonly HashSet<int> _available = [];
    private long _inventorySignature;
    private string _lastSearch = "";
    private readonly Dictionary<RecipeDisplayEntry, Requirements?> _requirements = new(ReferenceEqualityComparer.Instance);
    private SlotDisplayContext? _displayContext;

    public bool Visible { get; private set; }

    /// <summary>The book was laid out again, which in vanilla is a new search box: the text kept, the focus not.</summary>
    public event Action? VisualsInitialized;
    public bool WidthTooNarrow { get; private set; }

    /// <summary>The search box's text, which the screen's edit box owns; <see cref="CheckSearchStringUpdate"/> reads it.</summary>
    public string SearchText { get; set; } = "";

    /// <summary><c>AbstractWidget.playDownSound</c>, for every widget the book takes a click on.</summary>
    public Action PlayClickSound { get; set; } = () => { };

    public List<TabButton> Tabs { get; } = [];
    public TabButton? SelectedTab { get; private set; }
    public RecipeButton[] Buttons { get; } = Enumerable.Range(0, ItemsPerPage).Select(_ => new RecipeButton()).ToArray();
    public Overlay RecipeOverlay { get; } = new();
    public Dictionary<Slot, GhostSlot> GhostSlots { get; } = new();

    private IReadOnlyList<RecipeCollection> _recipeCollections = [];
    public int TotalPages { get; private set; }
    public int CurrentPage { get; private set; }
    public bool ForwardVisible { get; private set; }
    public bool BackVisible { get; private set; }
    private bool _isFiltering;
    private int? _lastClickedRecipe;
    private RecipeCollection? _lastClickedRecipeCollection;

    protected RecipeBookComponent(MinecraftClient client, ContainerMenu menu, RecipeBookType bookType, IReadOnlyList<RecipeBookTabInfo> tabInfos,
        string filterNameKey, bool furnace) {
        Client = client;
        Menu = menu;
        BookType = bookType;
        TabInfos = tabInfos;
        FilterNameKey = filterNameKey;
        IsFurnaceMenu = furnace;
        _canCraft = CanCraft;
        _canDisplay = CanDisplay;
    }

    private readonly Func<RecipeDisplayEntry, bool> _canCraft;
    private readonly Func<RecipeDisplay, bool> _canDisplay;

    /// <summary>The book for a menu vanilla gives one, null for the rest: the crafter, for one, has none.</summary>
    public static RecipeBookComponent? For(MinecraftClient client, ContainerMenu menu) => menu switch {
        InventoryMenu => new CraftingRecipeBookComponent(client, menu, 2, 2),
        CraftingMenu => new CraftingRecipeBookComponent(client, menu, 3, 3),
        FurnaceMenu when menu.Type?.Identifier == InventoryType.Smoker.Identifier => new FurnaceRecipeBookComponent(client, menu, RecipeBookType.Smoker,
            "gui.recipebook.toggleRecipes.smokable", [new(Item.Compass, null, RecipeBookTab.SmokerSearch), new(Item.Porkchop, null, new RecipeBookTab.Single(RecipeBookCategory.SmokerFood))]),
        FurnaceMenu when menu.Type?.Identifier == InventoryType.BlastFurnace.Identifier => new FurnaceRecipeBookComponent(client, menu, RecipeBookType.BlastFurnace,
            "gui.recipebook.toggleRecipes.blastable", [
                new(Item.Compass, null, RecipeBookTab.BlastFurnaceSearch),
                new(Item.RedstoneOre, null, new RecipeBookTab.Single(RecipeBookCategory.BlastFurnaceBlocks)),
                new(Item.IronShovel, Item.GoldenLeggings, new RecipeBookTab.Single(RecipeBookCategory.BlastFurnaceMisc))
            ]),
        FurnaceMenu => new FurnaceRecipeBookComponent(client, menu, RecipeBookType.Furnace, "gui.recipebook.toggleRecipes.smeltable", [
            new(Item.Compass, null, RecipeBookTab.FurnaceSearch),
            new(Item.Porkchop, null, new RecipeBookTab.Single(RecipeBookCategory.FurnaceFood)),
            new(Item.Stone, null, new RecipeBookTab.Single(RecipeBookCategory.FurnaceBlocks)),
            new(Item.LavaBucket, Item.Emerald, new RecipeBookTab.Single(RecipeBookCategory.FurnaceMisc))
        ]),
        _ => null
    };

    public int XOrigin => (_width - ImageWidth) / 2 - _xOffset;
    public int YOrigin => (_height - ImageHeight) / 2;

    public (int X, int Y, int W, int H) SearchBox => (XOrigin + 25, YOrigin + 13, 81, 9 + 5);
    private (int X, int Y, int W, int H) MagnifierIcon => (XOrigin + 8, YOrigin + 13, 25, 9 + 5);
    public (int X, int Y, int W, int H) FilterButton => (XOrigin + 110, YOrigin + 12, 26, 16);
    public (int X, int Y, int W, int H) ForwardButton => (XOrigin + 93, YOrigin + 137, 12, 17);
    public (int X, int Y, int W, int H) BackButton => (XOrigin + 38, YOrigin + 137, 12, 17);

    /// <summary><c>Mth.floor(time / 30)</c>: which of a cycling slot's items is shown.</summary>
    public int CurrentIndex => (int)MathF.Floor(_time / TicksToSwapSlot);

    public bool IsFiltering => Book.IsFiltering(BookType);

    public bool IsOffsetNextToMainGui => _xOffset == OffsetXPosition;

    private bool Spectator => Client.Player?.IsSpectator ?? false;

    public void Init(int width, int height, bool widthTooNarrow) {
        _width = width;
        _height = height;
        WidthTooNarrow = widthTooNarrow;
        _inventorySignature = InventorySignature();
        Visible = Book.IsOpen(BookType);
        if (Visible) {
            InitVisuals();
        }
    }

    private void InitVisuals() {
        bool isFiltering = IsFiltering;
        _xOffset = WidthTooNarrow ? 0 : OffsetXPosition;
        FillStackedContents();
        InitPage(XOrigin, YOrigin);
        RecipeBookTab? selected = SelectedTab?.Info.Tab;
        Tabs.Clear();
        foreach (RecipeBookTabInfo info in TabInfos) {
            Tabs.Add(new TabButton(info));
        }
        SelectedTab = selected == null ? null : Tabs.FirstOrDefault(t => t.Info.Tab.Equals(selected));
        SelectedTab ??= Tabs[0];
        SelectedTab.Selected = true;
        VisualsInitialized?.Invoke();
        SelectMatchingRecipes();
        UpdateTabs(isFiltering);
        UpdateCollections(false, isFiltering);
    }

    /// <summary><c>updateScreenPosition</c>: the container's left edge, moved right while the book sits beside it.</summary>
    public int UpdateScreenPosition(int width, int imageWidth) =>
        Visible && !WidthTooNarrow ? 177 + (width - imageWidth - 200) / 2 : (width - imageWidth) / 2;

    public void ToggleVisibility() => SetVisible(!Visible);

    protected void SetVisible(bool visible) {
        if (visible) {
            InitVisuals();
        }
        Visible = visible;
        Book.SetOpen(BookType, visible);
        if (!visible) {
            RecipeOverlay.IsVisible = false;
        }
        SendUpdateSettings();
    }

    protected abstract bool IsCraftingSlot(Slot slot);

    /// <summary><c>slotClicked</c>: any click on the grid or the result forgets the last placed recipe and its ghost.</summary>
    public void SlotClicked(Slot? slot) {
        if (slot != null && IsCraftingSlot(slot)) {
            _lastPlacedRecipe = null;
            GhostSlots.Clear();
            if (Visible) {
                UpdateStackedContents();
            }
        }
    }

    /// <summary>
    /// <c>selectMatchingRecipes</c> over every tab. The search tab holds the other tabs' collections again, and selecting
    /// one twice gives the same answer, so each is selected once.
    /// </summary>
    private void SelectMatchingRecipes() {
        HashSet<RecipeCollection> selected = new(ReferenceEqualityComparer.Instance);
        foreach (RecipeBookTabInfo info in TabInfos) {
            foreach (RecipeCollection collection in Book.Collection(info.Tab)) {
                if (selected.Add(collection)) {
                    collection.SelectRecipes(_canCraft, _canDisplay);
                }
            }
        }
    }

    protected abstract bool CanDisplay(RecipeDisplay display);

    private void UpdateCollections(bool resetPage, bool isFiltering) {
        List<RecipeCollection> collections = Book.Collection(SelectedTab!.Info.Tab).Where(c => c.HasAnySelected).ToList();
        if (SearchText.Length > 0) {
            HashSet<RecipeCollection> found = Client.RecipeSearch.Search(SearchText.ToLowerInvariant()).ToHashSet();
            collections.RemoveAll(c => !found.Contains(c));
        }
        if (isFiltering) {
            collections.RemoveAll(c => !c.HasCraftable);
        }
        UpdatePageCollections(collections, resetPage, isFiltering);
    }

    private void UpdateTabs(bool isFiltering) {
        int x = (_width - ImageWidth) / 2 - _xOffset - 30;
        int y = (_height - ImageHeight) / 2 + 3;
        int index = 0;
        foreach (TabButton tab in Tabs) {
            if (tab.Info.Tab is RecipeBookTab.Search) {
                tab.Visible = true;
                (tab.X, tab.Y) = (x, y + 27 * index++);
            }
            else if (tab.UpdateVisibility(Book)) {
                (tab.X, tab.Y) = (x, y + 27 * index++);
                tab.StartAnimation(Book, isFiltering);
            }
        }
    }

    /// <summary><c>tick</c>: follows the book's open state, and re-reads the inventory whenever it changed.</summary>
    public void Tick() {
        bool shouldBeVisible = Book.IsOpen(BookType);
        if (Visible != shouldBeVisible) {
            SetVisible(shouldBeVisible);
        }
        if (Visible) {
            long signature = InventorySignature();
            if (signature != _inventorySignature) {
                UpdateStackedContents();
                _inventorySignature = signature;
            }
        }
    }

    /// <summary>
    /// Stands in for <c>Inventory.getTimesChanged</c>, which counts writes to the player's inventory. Comparing what
    /// the inventory holds misses only a write that put back what was there, and the refresh that one would trigger
    /// finds the same contents and changes nothing.
    /// </summary>
    private long InventorySignature() {
        PlayerInventory inventory = Client.Inventory;
        HashCode hash = new();
        for (int i = 0; i < inventory.Size; i++) {
            Stack stack = inventory.Get(i);
            hash.Add(stack.Count);
            hash.Add(stack.Item.Identifier);
            hash.Add(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(stack.Template));
        }
        return hash.ToHashCode();
    }

    private void UpdateStackedContents() {
        FillStackedContents();
        SelectMatchingRecipes();
        UpdateCollections(false, IsFiltering);
    }

    /// <summary><c>Inventory.fillStackedContents</c> over the 36 main slots, then the menu's own crafting slots.</summary>
    private void FillStackedContents() {
        _stackedContents.Clear();
        _available.Clear();
        PlayerInventory inventory = Client.Inventory;
        for (int i = 0; i < 36; i++) {
            AccountSimpleStack(inventory.Get(i));
        }
        FillCraftSlotsStackedContents();
    }

    protected abstract void FillCraftSlotsStackedContents();

    /// <summary><c>StackedItemContents.accountSimpleStack</c>: only what <c>Inventory.isUsableForCrafting</c> allows.</summary>
    protected void AccountSimpleStack(Stack stack) {
        if (!stack.IsDamaged && !(stack.Get(DataComponent.Enchantments) is { Length: > 0 }) && !stack.Has(DataComponent.CustomName)) {
            AccountStack(stack);
        }
    }

    /// <summary><c>StackedItemContents.accountStack</c>, capped at the stack's own maximum.</summary>
    protected void AccountStack(Stack stack) {
        if (!stack.IsEmpty) {
            _stackedContents.Account(stack.Item.Identifier, Math.Min(stack.MaxStackSize, stack.Count));
            _available.Add(Client.Registry.Items.GetProtocolId(stack.Item));
        }
    }

    /// <summary><c>RecipeDisplayEntry.canCraft</c>: no requirements means it can never be placed.</summary>
    private bool CanCraft(RecipeDisplayEntry entry) {
        if (!_requirements.TryGetValue(entry, out Requirements? requirements)) {
            _requirements[entry] = requirements = ResolveRequirements(entry);
        }
        if (requirements == null) {
            return false;
        }
        // An ingredient no held item satisfies fails the matching outright, so most recipes are answered here
        // without building the matcher.
        foreach (int[] ids in requirements.ItemIds) {
            if (!AnyAvailable(ids)) {
                return false;
            }
        }
        return _stackedContents.TryPick(requirements.Ingredients, 1);
    }

    private bool AnyAvailable(int[] ids) {
        foreach (int id in ids) {
            if (_available.Contains(id)) {
                return true;
            }
        }
        return false;
    }

    /// <summary>Null when it can never be placed, or when one of the sets names no item, which nothing can satisfy.</summary>
    private Requirements? ResolveRequirements(RecipeDisplayEntry entry) {
        if (entry.CraftingRequirements is not { } sets) {
            return null;
        }
        Ingredient[] ingredients = new Ingredient[sets.Length];
        int[][] ids = new int[sets.Length][];
        for (int i = 0; i < sets.Length; i++) {
            Minecraft.Schemas.Identifier[] items = Client.ResolveItemSet(sets[i]).Where(id => id != Item.Air.Identifier).ToArray();
            if (items.Length == 0) {
                return null;
            }
            ingredients[i] = new Ingredient(new HolderSet.Direct(items), Client.Registry);
            ids[i] = items.Select(Client.Registry.Items.GetProtocolId).ToArray();
        }
        return new Requirements(ingredients, ids);
    }

    private sealed record Requirements(Ingredient[] Ingredients, int[][] ItemIds);

    /// <summary><c>AbstractRecipeBookScreen.extractRenderState</c>'s clock: real ticks, held while Control is down.</summary>
    public void AdvanceTime(float ticks, bool controlDown) {
        if (Visible && !controlDown) {
            _time += ticks;
        }
        foreach (TabButton tab in Tabs) {
            tab.AnimationTime = Math.Max(0, tab.AnimationTime - ticks);
        }
        foreach (RecipeButton button in Buttons) {
            button.AnimationTime = Math.Max(0, button.AnimationTime - ticks);
        }
    }

    /// <summary>
    /// <c>mouseClicked</c>. True when the book took the click. <paramref name="searchFocus"/> is what the click does
    /// to the search box's focus, null where it leaves it alone.
    /// </summary>
    public bool MouseClicked(double x, double y, int button, bool shift, out bool? searchFocus) {
        searchFocus = null;
        if (!Visible || Spectator) {
            return false;
        }
        if (PageMouseClicked(x, y, button)) {
            int? recipe = _lastClickedRecipe;
            RecipeCollection? collection = _lastClickedRecipeCollection;
            if (recipe is { } id && collection != null) {
                if (!TryPlaceRecipe(collection, id, shift)) {
                    return false;
                }
                _lastRecipeCollection = collection;
                _lastRecipe = id;
                if (!IsOffsetNextToMainGui) {
                    SetVisible(false);
                }
            }
            return true;
        }
        (int mx, int my, int mw, int mh) = MagnifierIcon;
        (int sx, int sy, int sw, int sh) = SearchBox;
        int fx = (int)Math.Floor(x), fy = (int)Math.Floor(y);
        if (Inside(fx, fy, mx, my, mw, mh) || (button == 0 && Inside(x, y, sx, sy, sw, sh))) {
            searchFocus = true;
            return true;
        }
        searchFocus = false;
        (int bx, int by, int bw, int bh) = FilterButton;
        if (button == 0 && Inside(x, y, bx, by, bw, bh)) {
            PlayClickSound();
            bool value = !IsFiltering;
            ToggleFiltering();
            SendUpdateSettings();
            UpdateCollections(false, value);
            return true;
        }
        foreach (TabButton tab in Tabs) {
            if (button == 0 && tab.Visible && Inside(x, y, tab.X, tab.Y, TabWidth, TabHeight)) {
                PlayClickSound();
                if (SelectedTab != tab) {
                    SelectedTab!.Selected = false;
                    tab.Selected = true;
                    SelectedTab = tab;
                    UpdateCollections(true, IsFiltering);
                }
                return true;
            }
        }
        return false;
    }

    /// <summary><c>keyPressed</c>'s selection key: the last recipe placed again, as many as possible with Shift.</summary>
    public bool PlaceLastRecipe(bool shift) {
        if (_lastRecipeCollection == null || _lastRecipe is not { } id) {
            return false;
        }
        PlayClickSound();
        return TryPlaceRecipe(_lastRecipeCollection, id, shift);
    }

    /// <summary><c>keyPressed</c>'s Escape: a book drawn over the container closes before the container does.</summary>
    public bool CloseOnEscape() {
        if (!Visible || Spectator || IsOffsetNextToMainGui) {
            return false;
        }
        SetVisible(false);
        return true;
    }

    /// <summary>Whether the book takes keys at all, which a spectator's does not.</summary>
    public bool TakesInput => Visible && !Spectator;

    /// <summary>
    /// <c>tryPlaceRecipe</c>: refused only when the same recipe was the last placed and cannot be made now, so a
    /// click on a greyed recipe shows its ghost once rather than on every click.
    /// </summary>
    private bool TryPlaceRecipe(RecipeCollection collection, int recipe, bool useMaxItems) {
        if (!collection.IsCraftable(recipe) && recipe == _lastPlacedRecipe) {
            return false;
        }
        _lastPlacedRecipe = recipe;
        GhostSlots.Clear();
        Client.PlaceRecipe(Client.ActiveMenu.WindowId, recipe, useMaxItems);
        return true;
    }

    private void ToggleFiltering() => Book.SetFiltering(BookType, !Book.IsFiltering(BookType));

    /// <summary><c>hasClickedOutside</c>: a click on the book is not outside the container, so it throws nothing.</summary>
    public bool HasClickedOutside(double x, double y, int leftPos, int topPos, int imageWidth, int imageHeight) {
        if (!Visible) {
            return true;
        }
        bool clickedOutside = x < leftPos || y < topPos || x >= leftPos + imageWidth || y >= topPos + imageHeight;
        bool clickedOnRecipeBook = leftPos - ImageWidth < x && x < leftPos && topPos < y && y < topPos + imageHeight;
        return clickedOutside && !clickedOnRecipeBook && !(SelectedTab != null && Inside(x, y, SelectedTab.X, SelectedTab.Y, TabWidth, TabHeight));
    }

    /// <summary><c>checkSearchStringUpdate</c>, after the search box took a key or a character.</summary>
    public void CheckSearchStringUpdate() {
        string searchText = SearchText.ToLowerInvariant();
        if (searchText != _lastSearch) {
            UpdateCollections(false, IsFiltering);
            _lastSearch = searchText;
        }
    }

    /// <summary><c>recipesUpdated</c>, when the server changed the book.</summary>
    public void RecipesUpdated() {
        _requirements.Clear();
        SelectMatchingRecipes();
        UpdateTabs(IsFiltering);
        if (Visible) {
            UpdateCollections(false, IsFiltering);
        }
    }

    /// <summary><c>recipeShown</c>, through <c>LocalPlayer.removeRecipeHighlight</c>.</summary>
    private void RecipeShown(int id) => Client.RemoveRecipeHighlight(id);

    /// <summary><c>fillGhostRecipe</c>, from <c>place_ghost_recipe</c>.</summary>
    public void FillGhostRecipe(RecipeDisplay recipe) {
        GhostSlots.Clear();
        FillGhostRecipe(recipe, DisplayContext);
    }

    protected abstract void FillGhostRecipe(RecipeDisplay recipe, SlotDisplayContext context);

    protected void SetGhost(Slot slot, SlotDisplayContext context, SlotDisplay contents, bool isResult) {
        List<ItemStack> entries = contents.ResolveForStacks(context);
        if (entries.Count > 0) {
            GhostSlots[slot] = new GhostSlot(entries, isResult);
        }
    }

    protected SlotDisplayContext DisplayContext => _displayContext ??= Client.SlotDisplayContext();

    private void SendUpdateSettings() => Client.SendRecipeBookSettings(BookType);

    private static bool Inside(double x, double y, int left, int top, int w, int h) => x >= left && y >= top && x < left + w && y < top + h;

    // RecipeBookPage.

    private void InitPage(int xo, int yo) {
        for (int i = 0; i < Buttons.Length; i++) {
            (Buttons[i].X, Buttons[i].Y) = (xo + 11 + 25 * (i % 5), yo + 31 + 25 * (i / 5));
        }
    }

    private void UpdatePageCollections(IReadOnlyList<RecipeCollection> collections, bool resetPage, bool isFiltering) {
        _recipeCollections = collections;
        _isFiltering = isFiltering;
        TotalPages = (int)Math.Ceiling(collections.Count / 20.0);
        if (TotalPages <= CurrentPage || resetPage) {
            CurrentPage = 0;
        }
        UpdateButtonsForPage();
    }

    private void UpdateButtonsForPage() {
        int startOffset = ItemsPerPage * CurrentPage;
        for (int i = 0; i < Buttons.Length; i++) {
            RecipeButton button = Buttons[i];
            if (startOffset + i < _recipeCollections.Count) {
                InitButton(button, _recipeCollections[startOffset + i]);
                button.Visible = true;
            }
            else {
                button.Visible = false;
            }
        }
        ForwardVisible = TotalPages > 1 && CurrentPage < TotalPages - 1;
        BackVisible = TotalPages > 1 && CurrentPage > 0;
    }

    /// <summary><c>RecipeButton.init</c>: showing a highlighted recipe is what marks it seen.</summary>
    private void InitButton(RecipeButton button, RecipeCollection collection) {
        button.Collection = collection;
        List<RecipeDisplayEntry> fitting = collection.SelectedRecipes(_isFiltering ? RecipeCollection.CraftableStatus.Craftable : RecipeCollection.CraftableStatus.Any);
        button.SelectedEntries = fitting.Select(entry => (entry.Id, entry.Display.Result.ResolveForStacks(DisplayContext))).ToList();
        button.AllRecipesHaveSameResultDisplay = AllSameResultDisplay(button.SelectedEntries);
        List<int> newlyShown = fitting.Select(entry => entry.Id).Where(Book.WillHighlight).ToList();
        if (newlyShown.Count > 0) {
            newlyShown.ForEach(RecipeShown);
            button.AnimationTime = AnimationTime;
        }
    }

    private static bool AllSameResultDisplay(List<(int Id, List<ItemStack> DisplayItems)> entries) {
        ItemStack? first = null;
        foreach ((_, List<ItemStack> items) in entries) {
            foreach (ItemStack item in items) {
                if (first == null) {
                    first = item;
                }
                else if (!Stack.IsSameItemSameComponents(Stack.Of(first), Stack.Of(item))) {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary><c>RecipeBookPage.mouseClicked</c>: an open overlay takes every click, closing on one that misses it.</summary>
    private bool PageMouseClicked(double x, double y, int button) {
        _lastClickedRecipe = null;
        _lastClickedRecipeCollection = null;
        if (RecipeOverlay.IsVisible) {
            if (button == 0 && RecipeOverlay.Buttons.FirstOrDefault(b => Inside(x, y, b.X, b.Y, 24, 24)) is { } clicked) {
                PlayClickSound();
                _lastClickedRecipe = clicked.Recipe;
                _lastClickedRecipeCollection = RecipeOverlay.Collection;
            }
            else {
                RecipeOverlay.IsVisible = false;
            }
            return true;
        }
        if (button == 0 && ForwardVisible && Inside(x, y, ForwardButton.X, ForwardButton.Y, ForwardButton.W, ForwardButton.H)) {
            PlayClickSound();
            CurrentPage++;
            UpdateButtonsForPage();
            return true;
        }
        if (button == 0 && BackVisible && Inside(x, y, BackButton.X, BackButton.Y, BackButton.W, BackButton.H)) {
            PlayClickSound();
            CurrentPage--;
            UpdateButtonsForPage();
            return true;
        }
        foreach (RecipeButton recipeButton in Buttons) {
            if (!recipeButton.Visible || button is not (0 or 1) || !Inside(x, y, recipeButton.X, recipeButton.Y, ButtonSize, ButtonSize)) {
                continue;
            }
            PlayClickSound();
            if (button == 0) {
                _lastClickedRecipe = recipeButton.CurrentRecipe(CurrentIndex);
                _lastClickedRecipeCollection = recipeButton.Collection;
            }
            else if (!RecipeOverlay.IsVisible && !recipeButton.IsOnlyOption) {
                InitOverlay(recipeButton, XOrigin + ImageWidth / 2, YOrigin + 13 + ImageHeight / 2);
            }
            return true;
        }
        return false;
    }

    /// <summary><c>OverlayRecipeComponent.init</c>: craftable first, then the rest unless filtering, kept on the book.</summary>
    private void InitOverlay(RecipeButton button, int centerX, int centerY) {
        RecipeCollection collection = button.Collection;
        List<RecipeDisplayEntry> craftable = collection.SelectedRecipes(RecipeCollection.CraftableStatus.Craftable);
        List<RecipeDisplayEntry> unCraftable = _isFiltering ? [] : collection.SelectedRecipes(RecipeCollection.CraftableStatus.NotCraftable);
        int craftables = craftable.Count;
        int total = craftables + unCraftable.Count;
        int maxRow = total <= 16 ? 4 : 5;
        int rows = (int)MathF.Ceiling((float)total / maxRow);
        const float buttonWidth = ButtonSize;
        int ox = button.X, oy = button.Y;
        float rightPos = ox + Math.Min(total, maxRow) * 25;
        float maxLeftPos = centerX + 50;
        if (rightPos > maxLeftPos) {
            ox = (int)(ox - buttonWidth * (int)((rightPos - maxLeftPos) / buttonWidth));
        }
        float bottomPos = oy + rows * 25;
        float maxBottomPos = centerY + 50;
        if (bottomPos > maxBottomPos) {
            oy = (int)(oy - buttonWidth * (int)MathF.Ceiling((bottomPos - maxBottomPos) / buttonWidth));
        }
        float topPos = oy;
        float maxTopPos = centerY - 100;
        if (topPos < maxTopPos) {
            oy = (int)(oy - buttonWidth * (int)MathF.Ceiling((topPos - maxTopPos) / buttonWidth));
        }
        RecipeOverlay.IsVisible = true;
        RecipeOverlay.X = ox;
        RecipeOverlay.Y = oy;
        RecipeOverlay.Collection = collection;
        RecipeOverlay.Buttons.Clear();
        for (int i = 0; i < total; i++) {
            bool canCraft = i < craftables;
            RecipeDisplayEntry recipe = canCraft ? craftable[i] : unCraftable[i - craftables];
            RecipeOverlay.Buttons.Add(new OverlayButton(ox + 4 + 25 * (i % maxRow), oy + 5 + 25 * (i / maxRow), recipe.Id, canCraft,
                IsFurnaceMenu ? SmeltingIngredientPositions(recipe.Display) : CraftingIngredientPositions(recipe.Display)));
        }
    }

    private List<OverlayButton.Pos> CraftingIngredientPositions(RecipeDisplay recipe) {
        List<OverlayButton.Pos> result = [];
        switch (recipe) {
            case RecipeDisplay.ShapedCrafting shaped:
                PlaceRecipeHelper.PlaceRecipe(3, 3, shaped.Width, shaped.Height, shaped.Ingredients, (ingredient, _, gx, gy) => {
                    List<ItemStack> items = ingredient.ResolveForStacks(DisplayContext);
                    if (items.Count > 0) {
                        result.Add(OverlayButton.Pos.Grid(gx, gy, items));
                    }
                });
                break;
            case RecipeDisplay.ShapelessCrafting shapeless:
                for (int i = 0; i < shapeless.Ingredients.Length; i++) {
                    List<ItemStack> items = shapeless.Ingredients[i].ResolveForStacks(DisplayContext);
                    if (items.Count > 0) {
                        result.Add(OverlayButton.Pos.Grid(i % 3, i / 3, items));
                    }
                }
                break;
        }
        return result;
    }

    private List<OverlayButton.Pos> SmeltingIngredientPositions(RecipeDisplay recipe) =>
        recipe is RecipeDisplay.Furnace furnace && furnace.Ingredient.ResolveForStacks(DisplayContext) is { Count: > 0 } items
            ? [OverlayButton.Pos.Grid(1, 1, items)]
            : [];

    /// <summary>The recipe button under the cursor, for its tooltip; none while the overlay is open.</summary>
    public RecipeButton? HoveredButton(double x, double y) => RecipeOverlay.IsVisible
        ? null
        : Buttons.FirstOrDefault(b => b.Visible && Inside(x, y, b.X, b.Y, ButtonSize, ButtonSize));

    public sealed class TabButton(RecipeBookTabInfo info) {
        public RecipeBookTabInfo Info { get; } = info;
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public bool Selected { get; set; }
        public float AnimationTime { get; set; }

        /// <summary><c>startAnimation</c>: the tab bounces while it holds a highlighted recipe the book would show.</summary>
        public void StartAnimation(ClientRecipeBook book, bool isFiltering) {
            RecipeCollection.CraftableStatus show = isFiltering ? RecipeCollection.CraftableStatus.Craftable : RecipeCollection.CraftableStatus.Any;
            if (book.Collection(Info.Tab).Any(c => c.SelectedRecipes(show).Any(r => book.WillHighlight(r.Id)))) {
                AnimationTime = 15.0F;
            }
        }

        public bool UpdateVisibility(ClientRecipeBook book) {
            Visible = book.Collection(Info.Tab).Any(c => c.HasAnySelected);
            return Visible;
        }
    }

    public sealed class RecipeButton {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public float AnimationTime { get; set; }
        public RecipeCollection Collection { get; set; } = RecipeCollection.EmptyCollection;
        public List<(int Id, List<ItemStack> DisplayItems)> SelectedEntries { get; set; } = [];
        public bool AllRecipesHaveSameResultDisplay { get; set; }

        public bool HasMultipleRecipes => SelectedEntries.Count > 1;
        public bool IsOnlyOption => SelectedEntries.Count == 1;

        public int CurrentRecipe(int currentIndex) => SelectedEntries[currentIndex % SelectedEntries.Count].Id;

        /// <summary><c>getDisplayStack</c>: each recipe in turn, and each recipe's next result on the next round.</summary>
        public ItemStack DisplayStack(int currentIndex) {
            int entryCount = SelectedEntries.Count;
            if (entryCount == 0) {
                return ItemStack.Air;
            }
            int offsetIndex = currentIndex / entryCount;
            int entryIndex = currentIndex - entryCount * offsetIndex;
            List<ItemStack> items = SelectedEntries[entryIndex].DisplayItems;
            return items.Count == 0 ? ItemStack.Air : items[offsetIndex % items.Count];
        }
    }

    public sealed class Overlay {
        public bool IsVisible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public RecipeCollection Collection { get; set; } = RecipeCollection.EmptyCollection;
        public List<OverlayButton> Buttons { get; } = [];
    }

    public sealed record OverlayButton(int X, int Y, int Recipe, bool IsCraftable, List<OverlayButton.Pos> Slots) {
        /// <summary>An ingredient drawn at three eighths size, offset into the 24 pixel button.</summary>
        public sealed record Pos(int X, int Y, List<ItemStack> Ingredients) {
            public static Pos Grid(int gridX, int gridY, List<ItemStack> items) => new(3 + gridX * 7, 3 + gridY * 7, items);

            public ItemStack Select(int currentIndex) => Ingredients[currentIndex % Ingredients.Count];
        }
    }

    public sealed record GhostSlot(List<ItemStack> Items, bool IsResult) {
        public ItemStack Item(int index) => Items.Count == 0 ? ItemStack.Air : Items[index % Items.Count];
    }
}

/// <summary><c>CraftingRecipeBookComponent</c>, for the inventory's 2x2 and the crafting table's 3x3.</summary>
public sealed class CraftingRecipeBookComponent(MinecraftClient client, ContainerMenu menu, int gridWidth, int gridHeight)
    : RecipeBookComponent(client, menu, RecipeBookType.Crafting, [
        new(Item.Compass, null, RecipeBookTab.CraftingSearch),
        new(Item.IronAxe, Item.GoldenSword, new RecipeBookTab.Single(RecipeBookCategory.CraftingEquipment)),
        new(Item.Bricks, null, new RecipeBookTab.Single(RecipeBookCategory.CraftingBuildingBlocks)),
        new(Item.LavaBucket, Item.Apple, new RecipeBookTab.Single(RecipeBookCategory.CraftingMisc)),
        new(Item.Redstone, null, new RecipeBookTab.Single(RecipeBookCategory.CraftingRedstone))
    ], "gui.recipebook.toggleRecipes.craftable", false) {
    private Slot ResultSlot => Menu.Slots[0];
    private IEnumerable<Slot> InputGridSlots => Menu.Slots.Skip(1).Take(gridWidth * gridHeight);

    protected override bool IsCraftingSlot(Slot slot) => slot == ResultSlot || InputGridSlots.Contains(slot);

    protected override bool CanDisplay(RecipeDisplay display) => display switch {
        RecipeDisplay.ShapedCrafting shaped => gridWidth >= shaped.Width && gridHeight >= shaped.Height,
        RecipeDisplay.ShapelessCrafting shapeless => gridWidth * gridHeight >= shapeless.Ingredients.Length,
        _ => false
    };

    /// <summary><c>TransientCraftingContainer.fillStackedContents</c>.</summary>
    protected override void FillCraftSlotsStackedContents() {
        foreach (Slot slot in InputGridSlots) {
            AccountSimpleStack(slot.Item);
        }
    }

    protected override void FillGhostRecipe(RecipeDisplay recipe, SlotDisplayContext context) {
        SetGhost(ResultSlot, context, recipe.Result, true);
        List<Slot> inputSlots = InputGridSlots.ToList();
        switch (recipe) {
            case RecipeDisplay.ShapedCrafting shaped:
                PlaceRecipeHelper.PlaceRecipe(gridWidth, gridHeight, shaped.Width, shaped.Height, shaped.Ingredients,
                    (ingredient, gridIndex, _, _) => SetGhost(inputSlots[gridIndex], context, ingredient, false));
                break;
            case RecipeDisplay.ShapelessCrafting shapeless:
                int slotCount = Math.Min(shapeless.Ingredients.Length, inputSlots.Count);
                for (int i = 0; i < slotCount; i++) {
                    SetGhost(inputSlots[i], context, shapeless.Ingredients[i], false);
                }
                break;
        }
    }
}

/// <summary><c>FurnaceRecipeBookComponent</c>, for the furnace, the smoker and the blast furnace.</summary>
public sealed class FurnaceRecipeBookComponent(MinecraftClient client, ContainerMenu menu, RecipeBookType bookType, string filterNameKey,
    IReadOnlyList<RecipeBookTabInfo> tabs) : RecipeBookComponent(client, menu, bookType, tabs, filterNameKey, true) {
    protected override bool IsCraftingSlot(Slot slot) => slot.Index is 0 or 1 or 2;

    protected override bool CanDisplay(RecipeDisplay display) => display is RecipeDisplay.Furnace;

    /// <summary><c>SimpleContainer.fillStackedContents</c>: all three slots, the result too, with no usability check.</summary>
    protected override void FillCraftSlotsStackedContents() {
        for (int i = 0; i < 3; i++) {
            AccountStack(Menu.Slots[i].Item);
        }
    }

    protected override void FillGhostRecipe(RecipeDisplay recipe, SlotDisplayContext context) {
        SetGhost(Menu.Slots[2], context, recipe.Result, true);
        if (recipe is RecipeDisplay.Furnace furnace) {
            SetGhost(Menu.Slots[0], context, furnace.Ingredient, false);
            Slot fuelSlot = Menu.Slots[1];
            if (!fuelSlot.HasItem) {
                SetGhost(fuelSlot, context, furnace.Fuel, false);
            }
        }
    }
}

/// <summary><c>PlaceRecipeHelper.placeRecipe</c>: a recipe narrower or shorter than half the grid is centred in it.</summary>
public static class PlaceRecipeHelper {
    public static void PlaceRecipe<T>(int gridWidth, int gridHeight, int recipeWidth, int recipeHeight, IReadOnlyList<T> entries, Action<T, int, int, int> output) {
        int next = 0;
        int gridIndex = 0;
        for (int gridYPos = 0; gridYPos < gridHeight; gridYPos++) {
            bool shouldCenterRecipe = recipeHeight < gridHeight / 2.0F;
            int startPosCenterRecipe = (int)MathF.Floor(gridHeight / 2.0F - recipeHeight / 2.0F);
            if (shouldCenterRecipe && startPosCenterRecipe > gridYPos) {
                gridIndex += gridWidth;
                gridYPos++;
            }
            for (int gridXPos = 0; gridXPos < gridWidth; gridXPos++) {
                if (next >= entries.Count) {
                    return;
                }
                shouldCenterRecipe = recipeWidth < gridWidth / 2.0F;
                startPosCenterRecipe = (int)MathF.Floor(gridWidth / 2.0F - recipeWidth / 2.0F);
                int totalRecipeWidthInGrid = recipeWidth;
                bool addIngredientToSlot = gridXPos < recipeWidth;
                if (shouldCenterRecipe) {
                    totalRecipeWidthInGrid = startPosCenterRecipe + recipeWidth;
                    addIngredientToSlot = startPosCenterRecipe <= gridXPos && gridXPos < startPosCenterRecipe + recipeWidth;
                }
                if (addIngredientToSlot) {
                    output(entries[next++], gridIndex, gridXPos, gridYPos);
                }
                else if (totalRecipeWidthInGrid == gridXPos) {
                    gridIndex += gridWidth - gridXPos;
                    break;
                }
                gridIndex++;
            }
        }
    }
}
