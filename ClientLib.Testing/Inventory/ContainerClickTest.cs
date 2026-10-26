using ClientLib.Inventory;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace ClientLib.Testing.Inventory;

/// <summary>
/// Clicks through the ported <c>AbstractContainerMenu.doClick</c>. Each expectation follows vanilla's
/// code path for that click by hand; the server runs the same code, so a divergence here is a slot the
/// server would have to correct.
/// </summary>
public class ContainerClickTest {
    private sealed class User(PlayerInventory inventory, bool creative = false) : IMenuUser {
        public bool InfiniteMaterials => creative;
        public bool IsCreative => creative;
        public int ExperienceLevel => 0;
        public PlayerInventory Inventory { get; } = inventory;
        public List<Stack> Dropped { get; } = [];
        public void Drop(Stack stack) => Dropped.Add(stack.Copy());
        public void PlaySound(Minecraft.Data.Sounds.ISoundType sound, float volume, float pitch) {
        }
        public Minecraft.Schemas.RandomSource Random { get; } = new Minecraft.Schemas.LegacyRandomSource(0);
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

    private static Stack Of(Minecraft.Data.Items.IItem item, int count) => Stack.Of(new ItemStack(item, count));

    private void Put(int menuSlot, Minecraft.Data.Items.IItem item, int count) => _menu.Slots[menuSlot].Set(Of(item, count));

    private (string Item, int Count) At(int menuSlot) => (_menu.Slots[menuSlot].Item.Item.Identifier.Key, _menu.Slots[menuSlot].Item.Count);

    private void Click(int slot, int button, ContainerInput input) => _menu.Clicked(slot, button, input, _user);

    [Test]
    public void LeftClickPicksUpTheWholeStack() {
        Put(36, Item.Stone, 10);
        Click(36, 0, ContainerInput.Pickup);
        Assert.That(_menu.Carried.Count, Is.EqualTo(10));
        Assert.That(_menu.Slots[36].HasItem, Is.False);
    }

    [Test]
    public void RightClickTakesTheLargerHalf() {
        Put(36, Item.Stone, 9);
        Click(36, 1, ContainerInput.Pickup);
        Assert.That(_menu.Carried.Count, Is.EqualTo(5));
        Assert.That(At(36), Is.EqualTo(("stone", 4)));
    }

    [Test]
    public void RightClickPlacesOneAndLeftClickTopsUp() {
        _menu.Carried = Of(Item.Stone, 5);
        Click(10, 1, ContainerInput.Pickup);
        Assert.That(At(10), Is.EqualTo(("stone", 1)));
        Assert.That(_menu.Carried.Count, Is.EqualTo(4));

        Put(11, Item.Stone, 62);
        Click(11, 0, ContainerInput.Pickup);
        Assert.That(At(11), Is.EqualTo(("stone", 64)));
        Assert.That(_menu.Carried.Count, Is.EqualTo(2));
    }

    [Test]
    public void DifferentItemsSwap() {
        Put(11, Item.Stone, 4);
        _menu.Carried = Of(Item.Dirt, 3);
        Click(11, 0, ContainerInput.Pickup);
        Assert.That(At(11), Is.EqualTo(("dirt", 3)));
        Assert.That(_menu.Carried.Item.Identifier.Key, Is.EqualTo("stone"));
        Assert.That(_menu.Carried.Count, Is.EqualTo(4));
    }

    [Test]
    public void NumberKeySwapsWithTheHotbar() {
        _inventory.Set(2, Of(Item.Stone, 10));
        Put(9, Item.Dirt, 5);
        Click(9, 2, ContainerInput.Swap);
        Assert.That(At(9), Is.EqualTo(("stone", 10)));
        Assert.That(_inventory.Get(2).Item.Identifier.Key, Is.EqualTo("dirt"));
        Assert.That(At(38), Is.EqualTo(("dirt", 5)));
    }

    [Test]
    public void ShiftClickMovesBetweenHotbarAndInventory() {
        Put(36, Item.Stone, 10);
        Click(36, 0, ContainerInput.QuickMove);
        Assert.That(At(9), Is.EqualTo(("stone", 10)));
        Assert.That(_menu.Slots[36].HasItem, Is.False);

        Click(9, 0, ContainerInput.QuickMove);
        Assert.That(At(36), Is.EqualTo(("stone", 10)));
    }

    [Test]
    public void ShiftClickMergesBeforeFillingEmptySlots() {
        Put(36, Item.Stone, 40);
        Put(12, Item.Stone, 60);
        Click(36, 0, ContainerInput.QuickMove);
        Assert.That(At(12), Is.EqualTo(("stone", 64)));
        Assert.That(At(9), Is.EqualTo(("stone", 36)));
    }

    [Test]
    public void ShiftClickPutsArmourOn() {
        Put(10, Item.IronChestplate, 1);
        Click(10, 0, ContainerInput.QuickMove);
        Assert.That(At(6), Is.EqualTo(("iron_chestplate", 1)));
    }

    [Test]
    public void ShiftClickIntoAndOutOfAChest() {
        ChestMenu chest = new(1, InventoryType.Generic9x3, TextComponent.Text("Chest"), _inventory, _inventory.Data, 3);
        _inventory.Set(0, Of(Item.Stone, 10));
        Assert.That(chest.Slots[54].Item.Count, Is.EqualTo(10), "hotbar 0 is menu slot 54 in a three row chest");

        chest.Clicked(54, 0, ContainerInput.QuickMove, _user);
        Assert.That(chest.Slots[0].Item.Count, Is.EqualTo(10));

        chest.Clicked(0, 0, ContainerInput.QuickMove, _user);
        Assert.That(chest.Slots[62].Item.Count, Is.EqualTo(10), "out of the chest fills the inventory from the end");
    }

    [Test]
    public void LeftDragSplitsEvenly() {
        _menu.Carried = Of(Item.Stone, 10);
        Click(-999, ContainerMenu.QuickcraftMask(0, 0), ContainerInput.QuickCraft);
        foreach (int slot in new[] { 9, 10, 11 }) {
            Click(slot, ContainerMenu.QuickcraftMask(1, 0), ContainerInput.QuickCraft);
        }
        Click(-999, ContainerMenu.QuickcraftMask(2, 0), ContainerInput.QuickCraft);

        Assert.That(At(9).Count, Is.EqualTo(3));
        Assert.That(At(10).Count, Is.EqualTo(3));
        Assert.That(At(11).Count, Is.EqualTo(3));
        Assert.That(_menu.Carried.Count, Is.EqualTo(1));
    }

    [Test]
    public void RightDragPlacesOneEach() {
        _menu.Carried = Of(Item.Stone, 10);
        Click(-999, ContainerMenu.QuickcraftMask(0, 1), ContainerInput.QuickCraft);
        foreach (int slot in new[] { 9, 10, 11 }) {
            Click(slot, ContainerMenu.QuickcraftMask(1, 1), ContainerInput.QuickCraft);
        }
        Click(-999, ContainerMenu.QuickcraftMask(2, 1), ContainerInput.QuickCraft);

        Assert.That(At(10).Count, Is.EqualTo(1));
        Assert.That(_menu.Carried.Count, Is.EqualTo(7));
    }

    [Test]
    public void DragOverOneSlotIsAPlainClick() {
        _menu.Carried = Of(Item.Stone, 10);
        Click(-999, ContainerMenu.QuickcraftMask(0, 0), ContainerInput.QuickCraft);
        Click(9, ContainerMenu.QuickcraftMask(1, 0), ContainerInput.QuickCraft);
        Click(-999, ContainerMenu.QuickcraftMask(2, 0), ContainerInput.QuickCraft);
        Assert.That(At(9).Count, Is.EqualTo(10));
        Assert.That(_menu.Carried.IsEmpty, Is.True);
    }

    [Test]
    public void DoubleClickCollectsPartialStacksFirst() {
        _menu.Carried = Of(Item.Stone, 5);
        Put(9, Item.Stone, 30);
        Put(10, Item.Stone, 64);
        Put(11, Item.Dirt, 3);
        Click(12, 0, ContainerInput.PickupAll);
        Assert.That(_menu.Carried.Count, Is.EqualTo(64));
        Assert.That(_menu.Slots[9].HasItem, Is.False);
        Assert.That(At(10).Count, Is.EqualTo(35));
        Assert.That(At(11), Is.EqualTo(("dirt", 3)));
    }

    [Test]
    public void ThrowDropsOneOrAll() {
        Put(9, Item.Stone, 10);
        Click(9, 0, ContainerInput.Throw);
        Assert.That(At(9).Count, Is.EqualTo(9));
        Click(9, 1, ContainerInput.Throw);
        Assert.That(_menu.Slots[9].HasItem, Is.False);
        Assert.That(_user.Dropped.Sum(s => s.Count), Is.EqualTo(10));
    }

    [Test]
    public void CloneNeedsCreative() {
        Put(9, Item.Stone, 3);
        Click(9, 2, ContainerInput.Clone);
        Assert.That(_menu.Carried.IsEmpty, Is.True);

        _menu.Clicked(9, 2, ContainerInput.Clone, new User(_inventory, creative: true));
        Assert.That(_menu.Carried.Count, Is.EqualTo(64));
    }

    [Test]
    public void ArmourSlotRefusesTheWrongPiece() {
        _menu.Carried = Of(Item.IronHelmet, 1);
        Click(6, 0, ContainerInput.Pickup);
        Assert.That(_menu.Slots[6].HasItem, Is.False);
        Click(5, 0, ContainerInput.Pickup);
        Assert.That(At(5), Is.EqualTo(("iron_helmet", 1)));
    }

    [Test]
    public void TakingACraftUsesOneOfEachIngredient() {
        Put(1, Item.OakPlanks, 3);
        Put(2, Item.OakPlanks, 3);
        _menu.Slots[0].Set(Of(Item.Stick, 4));
        Click(0, 0, ContainerInput.Pickup);
        Assert.That(_menu.Carried.Count, Is.EqualTo(4));
        Assert.That(At(1).Count, Is.EqualTo(2));
        Assert.That(At(2).Count, Is.EqualTo(2));
    }
}
