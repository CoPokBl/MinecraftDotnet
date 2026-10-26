using ClientLib.Inventory;
using ClientLib.Recipes;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Recipes;
using Minecraft.Schemas.Tags;
using RecipeBookType = Minecraft.Packets.Play.ServerBound.ServerBoundChangeRecipeBookSettingsPacket.RecipeBookType;

namespace ClientLib.Testing.Recipes;

/// <summary>
/// The book the recipe packets build, <c>ClientRecipeBook</c>, and what the book screens send: the settings packet,
/// the place packet and when a repeat is refused, and the seen packet a page sends for a highlighted recipe.
/// </summary>
public class RecipeBookTest {
    private static (MinecraftClient Client, List<MinecraftPacket> Sent) Client() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        client.StartOffline(level);
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, sent);
    }

    private static int Id(Minecraft.Data.Items.IItem item) => VanillaRegistry.Data.Items.GetProtocolId(item);

    /// <summary>A stick from two planks, made from exactly what it lists.</summary>
    private static RecipeDisplayEntry Sticks(int id, int? group = null) => new() {
        Id = id,
        Display = new RecipeDisplay.ShapedCrafting(1, 2,
            [new SlotDisplay.Item(Item.OakPlanks), new SlotDisplay.Item(Item.OakPlanks)],
            new SlotDisplay.Stack(new ItemStack(Item.Stick, 4)), new SlotDisplay.Item(Item.CraftingTable)),
        Group = group,
        Category = RecipeBookCategory.CraftingMisc,
        CraftingRequirements = [new IdSet.Ids([Id(Item.OakPlanks)]), new IdSet.Ids([Id(Item.OakPlanks)])]
    };

    private static RecipeDisplayEntry Table(int id) => new() {
        Id = id,
        Display = new RecipeDisplay.ShapedCrafting(3, 3, Enumerable.Repeat<SlotDisplay>(new SlotDisplay.Item(Item.OakPlanks), 9).ToArray(),
            new SlotDisplay.Item(Item.CraftingTable), new SlotDisplay.Item(Item.CraftingTable)),
        Category = RecipeBookCategory.CraftingMisc,
        CraftingRequirements = Enumerable.Repeat<IdSet>(new IdSet.Ids([Id(Item.OakPlanks)]), 9).ToArray()
    };

    private static ClientBoundRecipeBookAddPacket Add(bool replace, params (RecipeDisplayEntry Entry, bool Notify, bool Highlight)[] entries) => new() {
        Entries = entries.Select(e => new ClientBoundRecipeBookAddPacket.Entry(e.Entry, e.Notify, e.Highlight)).ToArray(),
        Replace = replace
    };

    private static RecipeBookSettings Settings(bool craftingOpen, bool craftingFiltering = false) => RecipeBookSettings.Default with {
        Crafting = new RecipeBookSettings.TypeSettings(craftingOpen, craftingFiltering)
    };

    [Test]
    public void TestAddKeepsHighlightsAndAsksForAToastPerNotification() {
        (MinecraftClient client, _) = Client();
        List<RecipeDisplay> toasts = [];
        client.RecipeToastRequested += toasts.Add;
        client.Dispatch(Add(false, (Sticks(5), true, true), (Table(6), false, false)));
        Assert.That(client.RecipeBook.Known.Keys, Is.EquivalentTo(new[] { 5, 6 }));
        Assert.That(client.RecipeBook.WillHighlight(5), Is.True);
        Assert.That(client.RecipeBook.WillHighlight(6), Is.False);
        Assert.That(toasts, Has.Count.EqualTo(1));
    }

    [Test]
    public void TestReplaceClearsTheBookAndItsHighlights() {
        (MinecraftClient client, _) = Client();
        client.Dispatch(Add(false, (Sticks(5), false, true)));
        client.Dispatch(Add(true, (Table(6), false, false)));
        Assert.That(client.RecipeBook.Known.Keys, Is.EquivalentTo(new[] { 6 }));
        Assert.That(client.RecipeBook.WillHighlight(5), Is.False);
    }

    [Test]
    public void TestRemoveTakesTheHighlightWithIt() {
        (MinecraftClient client, _) = Client();
        client.Dispatch(Add(false, (Sticks(5), false, true)));
        client.Dispatch(new ClientBoundRecipeBookRemovePacket { RecipeIds = [5] });
        Assert.That(client.RecipeBook.Known, Is.Empty);
        Assert.That(client.RecipeBook.WillHighlight(5), Is.False);
    }

    [Test]
    public void TestAGhostRecipeIsOnlyForTheOpenMenu() {
        (MinecraftClient client, _) = Client();
        int ghosts = 0;
        client.GhostRecipePlaced += _ => ghosts++;
        client.Dispatch(new ClientBoundPlaceGhostRecipePacket { WindowId = 3, Recipe = Sticks(1).Display });
        client.Dispatch(new ClientBoundPlaceGhostRecipePacket { WindowId = 0, Recipe = Sticks(1).Display });
        Assert.That(ghosts, Is.EqualTo(1));
    }

    /// <summary>
    /// <c>HashMap</c> order over the display ids, in a table of 16: 17 and 33 share bucket 1 in the order they came,
    /// then 3, then 100 in bucket 4. Each ungrouped recipe is its own button, in that order.
    /// </summary>
    [Test]
    public void TestCollectionsFollowJavaHashMapOrder() {
        (MinecraftClient client, _) = Client();
        client.Dispatch(Add(false, (Sticks(100), false, false), (Sticks(3), false, false), (Sticks(17), false, false), (Sticks(33), false, false)));
        int[] order = client.RecipeBook.Collection(new RecipeBookTab.Single(RecipeBookCategory.CraftingMisc)).Select(c => c.Recipes[0].Id).ToArray();
        Assert.That(order, Is.EqualTo(new[] { 17, 33, 3, 100 }));
    }

    [Test]
    public void TestAGroupIsOneCollection() {
        (MinecraftClient client, _) = Client();
        client.Dispatch(Add(false, (Sticks(1, group: 4), false, false), (Sticks(2, group: 4), false, false), (Table(3), false, false)));
        IReadOnlyList<RecipeCollection> misc = client.RecipeBook.Collection(RecipeBookTab.CraftingSearch);
        Assert.That(misc.Select(c => c.Recipes.Count), Is.EqualTo(new[] { 2, 1 }));
    }

    [Test]
    public void TestToggleSendsTheBooksSettings() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        book.ToggleVisibility();
        ServerBoundChangeRecipeBookSettingsPacket packet = sent.OfType<ServerBoundChangeRecipeBookSettingsPacket>().Single();
        Assert.That((packet.BookType, packet.Open, packet.Filtering), Is.EqualTo((RecipeBookType.Crafting, true, false)));
    }

    /// <summary><c>tick</c> follows the book's open state, and setting it visible sends the settings straight back.</summary>
    [Test]
    public void TestTheServerOpeningTheBookIsEchoed() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true, true) });
        Assert.That(sent.OfType<ServerBoundChangeRecipeBookSettingsPacket>(), Is.Empty);
        book.Tick();
        Assert.That(book.Visible, Is.True);
        ServerBoundChangeRecipeBookSettingsPacket echo = sent.OfType<ServerBoundChangeRecipeBookSettingsPacket>().Single();
        Assert.That((echo.Open, echo.Filtering), Is.EqualTo((true, true)));
    }

    [Test]
    public void TestShowingAHighlightedRecipeSendsSeenOnce() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true) });
        client.Dispatch(Add(false, (Sticks(5), false, true), (Table(6), false, false)));
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        book.RecipesUpdated();
        Assert.That(sent.OfType<ServerBoundSetSeenRecipePacket>().Select(p => p.RecipeId), Is.EqualTo(new[] { 5 }));
    }

    /// <summary>The 2x2 grid cannot show the 3x3 table recipe, so only the sticks get a button.</summary>
    [Test]
    public void TestTheInventoryBookShowsOnlyWhatFitsItsGrid() {
        (MinecraftClient client, _) = Client();
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true) });
        client.Dispatch(Add(false, (Sticks(5), false, false), (Table(6), false, false)));
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        Assert.That(book.Buttons.Count(b => b.Visible), Is.EqualTo(1));
        Assert.That(book.Buttons[0].Collection.Recipes[0].Id, Is.EqualTo(5));
    }

    /// <summary>
    /// <c>tryPlaceRecipe</c>: an uncraftable recipe is placed once for its ghost, and clicking it again sends nothing
    /// until a crafting slot is clicked. Shift asks for as many as possible.
    /// </summary>
    [Test]
    public void TestPlacingAnUncraftableRecipeTwiceSendsOnce() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true) });
        client.Dispatch(Add(false, (Sticks(5), false, false)));
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        RecipeBookComponent.RecipeButton button = book.Buttons[0];

        Assert.That(book.MouseClicked(button.X + 1, button.Y + 1, 0, true, out _), Is.True);
        Assert.That(book.MouseClicked(button.X + 1, button.Y + 1, 0, false, out _), Is.False);
        ServerBoundPlaceRecipePacket place = sent.OfType<ServerBoundPlaceRecipePacket>().Single();
        Assert.That((place.WindowId, place.RecipeId, place.UseMaxItems), Is.EqualTo((0, 5, true)));

        book.SlotClicked(client.Inventory.Menu.Slots[1]);
        Assert.That(book.MouseClicked(button.X + 1, button.Y + 1, 0, false, out _), Is.True);
        Assert.That(sent.OfType<ServerBoundPlaceRecipePacket>().Count(), Is.EqualTo(2));
    }

    [Test]
    public void TestACraftableRecipeIsPlacedEveryClick() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        client.Inventory.Set(9, Stack.Of(new ItemStack(Item.OakPlanks, 4)));
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true) });
        client.Dispatch(Add(false, (Sticks(5), false, false)));
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        Assert.That(book.Buttons[0].Collection.HasCraftable, Is.True);
        RecipeBookComponent.RecipeButton button = book.Buttons[0];
        book.MouseClicked(button.X + 1, button.Y + 1, 0, false, out _);
        book.MouseClicked(button.X + 1, button.Y + 1, 0, false, out _);
        Assert.That(sent.OfType<ServerBoundPlaceRecipePacket>().Count(), Is.EqualTo(2));
    }

    [Test]
    public void TestDamagedEnchantedOrNamedItemsDoNotCount() {
        (MinecraftClient client, _) = Client();
        client.Inventory.Set(9, Stack.Of(new ItemStack(Item.OakPlanks, 4).With(DataComponent.CustomName, Minecraft.Text.TextComponent.Text("named"))));
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true) });
        client.Dispatch(Add(false, (Sticks(5), false, false)));
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        Assert.That(book.Buttons[0].Collection.HasCraftable, Is.False);
    }

    [Test]
    public void TestFilterTogglesAndSendsSettings() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Client();
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true) });
        client.Dispatch(Add(false, (Sticks(5), false, false)));
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        (int x, int y, _, _) = book.FilterButton;
        book.MouseClicked(x + 1, y + 1, 0, false, out _);
        ServerBoundChangeRecipeBookSettingsPacket packet = sent.OfType<ServerBoundChangeRecipeBookSettingsPacket>().Single();
        Assert.That((packet.Open, packet.Filtering), Is.EqualTo((true, true)));
        Assert.That(book.Buttons.Count(b => b.Visible), Is.EqualTo(0));
    }

    /// <summary>A click on the book beside the container is not outside it, so it does not throw the carried stack.</summary>
    [Test]
    public void TestAClickOnTheBookIsNotOutside() {
        (MinecraftClient client, _) = Client();
        client.Dispatch(new ClientBoundRecipeBookSettingsPacket { Settings = Settings(true) });
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        int left = book.UpdateScreenPosition(480, 176), top = (270 - 166) / 2;
        Assert.That(book.HasClickedOutside(left - 20, top + 50, left, top, 176, 166), Is.False);
        Assert.That(book.HasClickedOutside(left - 200, top + 50, left, top, 176, 166), Is.True);
    }

    [Test]
    public void TestTheCrafterHasNoBook() {
        (MinecraftClient client, _) = Client();
        CrafterMenu crafter = new(1, InventoryType.Crafter3x3, Minecraft.Text.TextComponent.Text(""), client.Inventory, client.Inventory.Data);
        Assert.That(RecipeBookComponent.For(client, crafter), Is.Null);
    }

    /// <summary><c>PlaceRecipeHelper</c> centres a recipe under half the grid's size: one item lands in the middle.</summary>
    [Test]
    public void TestASmallRecipeIsCentred() {
        List<int> indices = [];
        PlaceRecipeHelper.PlaceRecipe(3, 3, 1, 1, new[] { "x" }, (_, index, _, _) => indices.Add(index));
        Assert.That(indices, Is.EqualTo(new[] { 4 }));

        indices.Clear();
        PlaceRecipeHelper.PlaceRecipe(3, 3, 2, 2, new[] { "a", "b", "c", "d" }, (_, index, _, _) => indices.Add(index));
        Assert.That(indices, Is.EqualTo(new[] { 0, 1, 3, 4 }));
    }

    [Test]
    public void TestGhostFillsTheGridFromTheDisplay() {
        (MinecraftClient client, _) = Client();
        RecipeBookComponent book = RecipeBookComponent.For(client, client.Inventory.Menu)!;
        book.Init(480, 270, false);
        book.FillGhostRecipe(Sticks(5).Display);
        Assert.That(book.GhostSlots.Keys.Select(s => s.Index).Order(), Is.EqualTo(new[] { 0, 1, 3 }));
        Assert.That(book.GhostSlots[client.Inventory.Menu.Slots[0]].IsResult, Is.True);
    }

    [Test]
    public void TestSearchMatchesNamesAndIds() {
        RecipeCollection sticks = new([Sticks(1)]), table = new([Table(2)]);
        RecipeSearchTree tree = new([sticks, table], c => c == sticks ? ["Stick"] : ["Crafting Table"],
            c => [c == sticks ? Item.Stick.Identifier : Item.CraftingTable.Identifier]);
        Assert.That(tree.Search("tab"), Is.EqualTo(new[] { table }));
        Assert.That(tree.Search("minecraft:stick"), Is.EqualTo(new[] { sticks }));
        Assert.That(tree.Search("other:stick"), Is.Empty);
    }
}
