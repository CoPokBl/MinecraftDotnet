using ClientLib.Interaction;
using ClientLib.Inventory;
using ClientLib.Maths;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Inventory;

/// <summary>
/// <c>BundleContents</c>, <c>BundleItem</c>'s two click overrides through <c>doClick</c>, and
/// <c>BundleMouseActions</c>, each against numbers worked through vanilla's code by hand. The server runs the
/// same clicks, so a slot or cursor that differs here is one it would have to send back.
/// </summary>
public class BundleTest {
    private sealed class User(PlayerInventory inventory) : IMenuUser {
        public bool InfiniteMaterials => false;
        public bool IsCreative => false;
        public int ExperienceLevel => 0;
        public PlayerInventory Inventory { get; } = inventory;
        public List<(ISoundType Sound, float Volume, float Pitch)> Sounds { get; } = [];
        public void Drop(Stack stack) {
        }
        public void PlaySound(ISoundType sound, float volume, float pitch) => Sounds.Add((sound, volume, pitch));
        public RandomSource Random { get; } = new LegacyRandomSource(0);
    }

    private PlayerInventory _inventory = null!;
    private InventoryMenu _menu = null!;
    private User _user = null!;

    [OneTimeSetUp]
    public void InitialiseRegistry() {
        _ = VanillaRegistry.Data;
    }

    [SetUp]
    public void SetUp() {
        _inventory = new PlayerInventory();
        _menu = _inventory.Menu;
        _user = new User(_inventory);
    }

    private static Stack Of(IItem item, int count) => Stack.Of(new ItemStack(item, count));

    private static Stack Bundle(params ItemStack[] contents) =>
        Stack.Of(contents.Length == 0 ? new ItemStack(Item.Bundle) : new ItemStack(Item.Bundle).With(DataComponent.BundleContents, contents));

    private static ItemStack[] Contents(Stack bundle) => BundleContents.Of(bundle.ToItemStack())!;

    private static (string, int)[] Listed(Stack bundle) => Contents(bundle).Select(s => (s.Type.Identifier.Key, s.Count)).ToArray();

    private void Click(int slot, int button) => _menu.Clicked(slot, button, ContainerInput.Pickup, _user);

    [Test]
    public void WeightsAreAFractionOfAStackEach() {
        // 32 of a 64 stack is a half, 8 of a 16 stack another half; a sword fills a bundle alone.
        Assert.That(BundleContents.Weight([new ItemStack(Item.Stone, 32), new ItemStack(Item.EnderPearl, 8)]), Is.EqualTo(Fraction.One));
        Assert.That(BundleContents.Weight([new ItemStack(Item.DiamondSword, 1)]), Is.EqualTo(Fraction.One));
        // A bundle inside weighs what it holds and a sixteenth: 1/2 + 1/16 = 9/16, and an empty one just the sixteenth.
        ItemStack inner = new ItemStack(Item.Bundle).With(DataComponent.BundleContents, [new ItemStack(Item.Stone, 32)]);
        Assert.That(BundleContents.Weight([inner]), Is.EqualTo(Fraction.Of(9, 16)));
        Assert.That(BundleContents.Weight([new ItemStack(Item.RedBundle)]), Is.EqualTo(Fraction.Of(1, 16)));
    }

    [Test]
    public void InsertingStopsAtTheRemainingWeight() {
        // Half full of stone: (1 - 1/2) / (1/16) = 8 pearls go in, the other 8 stay, and the new stack goes first.
        BundleContents.Mutable contents = new([new ItemStack(Item.Stone, 32)]);
        Stack pearls = Of(Item.EnderPearl, 16);
        Assert.That(contents.TryInsert(pearls), Is.EqualTo(8));
        Assert.That(pearls.Count, Is.EqualTo(8));
        Assert.That(contents.Weight, Is.EqualTo(Fraction.One));
        Assert.That(contents.ToImmutable().Select(s => (s.Type.Identifier.Key, s.Count)), Is.EqualTo(new[] { ("ender_pearl", 8), ("stone", 32) }));
        Assert.That(contents.TryInsert(pearls), Is.EqualTo(0));
    }

    [Test]
    public void AMatchingStackMergesAndMovesToTheFront() {
        BundleContents.Mutable contents = new([new ItemStack(Item.Dirt, 3), new ItemStack(Item.Stone, 15)]);
        Assert.That(contents.TryInsert(Of(Item.Stone, 2)), Is.EqualTo(2));
        Assert.That(contents.ToImmutable().Select(s => (s.Type.Identifier.Key, s.Count)), Is.EqualTo(new[] { ("stone", 17), ("dirt", 3) }));
        // 17/64 + 3/64 = 20/64 = 5/16.
        Assert.That(contents.Weight, Is.EqualTo(Fraction.Of(5, 16)));
    }

    [Test]
    public void AShulkerBoxDoesNotFit() {
        BundleContents.Mutable contents = new([]);
        Assert.That(contents.TryInsert(Of(Item.ShulkerBox, 1)), Is.EqualTo(0));
    }

    [Test]
    public void RemoveOneTakesTheSelectedStackElseTheNewest() {
        ItemStack[] items = [new ItemStack(Item.Dirt, 3), new ItemStack(Item.Stone, 17)];
        BundleContents.Mutable contents = new(items);
        Assert.That(contents.RemoveOne()!.ToString(), Is.EqualTo("3 minecraft:dirt"));

        contents = new BundleContents.Mutable(items);
        contents.ToggleSelectedItem(1);
        Assert.That(contents.RemoveOne()!.ToString(), Is.EqualTo("17 minecraft:stone"));
        // 3/64 left, and the selection is gone with the stack.
        Assert.That(contents.Weight, Is.EqualTo(Fraction.Of(3, 64)));
        Assert.That(BundleContents.SelectedItemIndex(contents.ToImmutable()), Is.EqualTo(-1));
    }

    [Test]
    public void ToggleSelectsOrClears() {
        BundleContents.Mutable contents = new([new ItemStack(Item.Dirt, 1), new ItemStack(Item.Stone, 1)]);
        contents.ToggleSelectedItem(1);
        ItemStack[] selected = contents.ToImmutable();
        Assert.That(BundleContents.SelectedItemIndex(selected), Is.EqualTo(1));
        Assert.That(BundleContents.SelectedItem(selected)!.Type, Is.EqualTo(Item.Stone));
        // Selecting the same one again, or one out of range, clears it.
        contents.ToggleSelectedItem(1);
        Assert.That(BundleContents.SelectedItemIndex(contents.ToImmutable()), Is.EqualTo(-1));
        contents.ToggleSelectedItem(2);
        Assert.That(BundleContents.SelectedItemIndex(contents.ToImmutable()), Is.EqualTo(-1));
    }

    [Test]
    public void ItemsShownLeaveNoGapInTheLastRow() {
        // More than 12 stacks keep a cell for "+n": 11, less the 3 a row of 13 % 4 = 1 leaves empty, is 8.
        Assert.That(BundleContents.NumberOfItemsToShow(Enumerable.Repeat(new ItemStack(Item.Dirt, 1), 13).ToArray()), Is.EqualTo(8));
        Assert.That(BundleContents.NumberOfItemsToShow(Enumerable.Repeat(new ItemStack(Item.Dirt, 1), 12).ToArray()), Is.EqualTo(12));
        Assert.That(BundleContents.NumberOfItemsToShow(Enumerable.Repeat(new ItemStack(Item.Dirt, 1), 5).ToArray()), Is.EqualTo(5));
    }

    [Test]
    public void ACarriedBundleSwallowsTheClickedStack() {
        _menu.Carried = Bundle();
        _menu.Slots[10].Set(Of(Item.Stone, 64));
        Click(10, 0);
        Assert.That(_menu.Slots[10].HasItem, Is.False);
        Assert.That(Listed(_menu.Carried), Is.EqualTo(new[] { ("stone", 64) }));
        // BUNDLE_INSERT at 0.8 + nextFloat * 0.4; java.util.Random(0)'s first float is 0.73096776.
        Assert.That(_user.Sounds.Single().Sound, Is.EqualTo(SoundType.BundleInsert));
        Assert.That(_user.Sounds.Single().Pitch, Is.EqualTo(0.8F + 0.73096776F * 0.4F));

        // Full: safeTake(10, 0) takes nothing, the dirt stays and the fail sound plays at 1, 1.
        _menu.Slots[11].Set(Of(Item.Dirt, 10));
        Click(11, 0);
        Assert.That(_menu.Slots[11].Item.Count, Is.EqualTo(10));
        Assert.That(_user.Sounds[^1], Is.EqualTo(((ISoundType)SoundType.BundleInsertFail, 1.0F, 1.0F)));
    }

    [Test]
    public void ACarriedBundleRightClickedOnAnEmptySlotEmptiesItsNewestStack() {
        _menu.Carried = Bundle(new ItemStack(Item.Dirt, 3), new ItemStack(Item.Stone, 5));
        Click(12, 1);
        Assert.That(_menu.Slots[12].Item.ToString(), Is.EqualTo("3 minecraft:dirt"));
        Assert.That(Listed(_menu.Carried), Is.EqualTo(new[] { ("stone", 5) }));
        Assert.That(_user.Sounds.Single().Sound, Is.EqualTo(SoundType.BundleRemoveOne));
    }

    [Test]
    public void AStackClickedOntoABundleGoesIn() {
        _menu.Slots[13].Set(Bundle(new ItemStack(Item.Stone, 48)));
        _menu.Carried = Of(Item.Dirt, 20);
        Click(13, 0);
        // 1 - 48/64 = 1/4 leaves room for 16 dirt; 4 stay on the cursor.
        Assert.That(Listed(_menu.Slots[13].Item), Is.EqualTo(new[] { ("dirt", 16), ("stone", 48) }));
        Assert.That(_menu.Carried.Count, Is.EqualTo(4));
    }

    [Test]
    public void ABundleRightClickedWithAnEmptyCursorHandsOverItsNewestStack() {
        _menu.Slots[14].Set(Bundle(new ItemStack(Item.Dirt, 3)));
        Click(14, 1);
        Assert.That(_menu.Carried.ToString(), Is.EqualTo("3 minecraft:dirt"));
        Assert.That(Contents(_menu.Slots[14].Item), Is.Empty);
        // Emptied, the contents equal the bundle's default, so they leave the stack's patch as they do in vanilla.
        Assert.That(_menu.Slots[14].Item.Template.Components.ContainsKey(DataComponent.BundleContents), Is.False);
    }

    [Test]
    public void ABundleLeftClickedWithAnEmptyCursorLosesItsSelectionAndIsPickedUp() {
        Stack bundle = Bundle(new ItemStack(Item.Dirt, 3), new ItemStack(Item.Stone, 5));
        BundleItem.ToggleSelectedItem(bundle, 1);
        _menu.Slots[15].Set(bundle);
        Click(15, 0);
        Assert.That(_menu.Slots[15].HasItem, Is.False);
        Assert.That(BundleItem.GetSelectedItemIndex(_menu.Carried.ToItemStack()), Is.EqualTo(-1));
        Assert.That(Listed(_menu.Carried), Is.EqualTo(new[] { ("dirt", 3), ("stone", 5) }));
    }

    [Test]
    public void SelectionIsNotPartOfTheStacksEquality() {
        Stack bundle = Bundle(new ItemStack(Item.Dirt, 3), new ItemStack(Item.Stone, 5));
        Stack before = bundle.Copy();
        BundleItem.ToggleSelectedItem(bundle, 1);
        Assert.That(Stack.Matches(before, bundle), Is.True);
        Assert.That(BundleItem.GetSelectedItemIndex(bundle.ToItemStack()), Is.EqualTo(1));
        Assert.That(BundleItem.GetSelectedItemIndex(before.ToItemStack()), Is.EqualTo(-1));
    }

    [Test]
    public void TheWheelStepsBackwardsAndWraps() {
        // Up from nothing: -1 - 1 clamps to -1, then wraps to the last of 5.
        Assert.That(ScrollWheelHandler.GetNextScrollWheelSelection(1, -1, 5), Is.EqualTo(4));
        Assert.That(ScrollWheelHandler.GetNextScrollWheelSelection(-1, -1, 5), Is.EqualTo(0));
        Assert.That(ScrollWheelHandler.GetNextScrollWheelSelection(1, 0, 5), Is.EqualTo(4));
        Assert.That(ScrollWheelHandler.GetNextScrollWheelSelection(-1, 4, 5), Is.EqualTo(0));
    }

    [Test]
    public void ScrollingSelectsOnWholeNotchesAndLeavingClears() {
        List<(int Slot, int Item)> sent = [];
        BundleMouseActions actions = new(stack => BundleItem.Is(stack.Item), (slot, item) => sent.Add((slot, item)));
        Stack bundle = Bundle(new ItemStack(Item.Dirt, 1), new ItemStack(Item.Stone, 1), new ItemStack(Item.Sand, 1));
        _menu.Slots[20].Set(bundle);

        // Half a notch is nothing yet; the second half makes one notch up, wrapping to the last of 3.
        Assert.That(actions.OnMouseScrolled(0.0, 0.5, 20, bundle), Is.True);
        Assert.That(sent, Is.Empty);
        actions.OnMouseScrolled(0.0, 0.5, 20, bundle);
        Assert.That(sent, Is.EqualTo(new[] { (20, 2) }));
        Assert.That(BundleItem.GetSelectedItemIndex(bundle.ToItemStack()), Is.EqualTo(2));

        // A notch down steps forward and wraps to 0.
        actions.OnMouseScrolled(0.0, -1.0, 20, bundle);
        Assert.That(sent[^1], Is.EqualTo((20, 0)));

        actions.OnStopHovering(_menu.Slots[20]);
        Assert.That(sent[^1], Is.EqualTo((20, -1)));
        Assert.That(BundleItem.GetSelectedItemIndex(bundle.ToItemStack()), Is.EqualTo(-1));
        // Leaving sends even with nothing selected.
        actions.OnStopHovering(_menu.Slots[20]);
        Assert.That(sent, Has.Count.EqualTo(4));
    }

    [Test]
    public void AnEmptyBundleTakesNoScroll() {
        BundleMouseActions actions = new(_ => true, (_, _) => Assert.Fail("sent"));
        Assert.That(actions.OnMouseScrolled(0.0, 1.0, 20, Bundle()), Is.False);
    }

    [Test]
    public void TheBarFollowsTheSharedWeight() {
        // An empty bundle inside weighs 1/16: 1 + (1 * 12 / 16) = 1.
        ItemStack bundle = new ItemStack(Item.Bundle).With(DataComponent.BundleContents, [new ItemStack(Item.Bundle)]);
        Assert.That(ItemBars.GetBarWidth(bundle), Is.EqualTo(1));
        Assert.That(ItemBars.IsBarVisible(bundle), Is.True);
    }
}
