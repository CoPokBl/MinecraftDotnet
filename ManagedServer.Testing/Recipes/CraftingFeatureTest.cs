using ManagedServer.Entities.Types;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Impl;
using ManagedServer.Inventories;
using ManagedServer.Testing.Interaction;
using Minecraft.Data.Recipes;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Registry;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Tags;
using Item = Minecraft.Data.Generated.Item;
using VanillaRegistry = Minecraft.Data.Generated.VanillaRegistry;

namespace ManagedServer.Testing.Recipes;

/// <summary>
/// What the feature does to the two grids: fills the result slot, spends the inputs, hands back what
/// an input leaves behind, and refuses to let anything into the result slot.
/// </summary>
/// <remarks>
/// Hand written recipes, so nothing here moves when Mojang change one. Whether the matcher agrees with
/// vanilla is <see cref="CraftingConformanceTest"/>'s question.
/// <p/>
/// Clicks go through <see cref="Player.HandlePacket"/> with <see cref="InventoryClickFeature"/>
/// registered, because the result slot is only correct as a <b>pair</b>: testing either half alone
/// passes with the other broken.
/// </remarks>
[TestFixture]
public class CraftingFeatureTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private static Ingredient Of(params string[] items) {
        return new Ingredient(new HolderSet.Direct(items.Select(item => (Minecraft.Schemas.Identifier)item).ToArray()),
            Registry);
    }

    /// <summary>Two sticks stacked vertically make a torch.</summary>
    private static ShapedRecipe TwoSticks() {
        return new ShapedRecipe("test:two_sticks",
            ShapedRecipePattern.Unpack(new Dictionary<char, Ingredient> { ['#'] = Of("minecraft:stick") },
                ["#", "#"]),
            new ItemStack(Item.Torch, 4));
    }

    /// <summary>A bucket of water and a wheat, so one input leaves an empty bucket behind.</summary>
    private static ShapelessRecipe BucketAndWheat() {
        return new ShapelessRecipe("test:bucket_and_wheat",
            [Of("minecraft:water_bucket"), Of("minecraft:wheat")],
            new ItemStack(Item.Cake));
    }

    private static CraftingRecipes Recipes() {
        return new CraftingRecipes([TwoSticks(), BucketAndWheat()]);
    }

    private static InteractionScene Scene() {
        return new InteractionScene(new InventoryClickFeature(), new InventoryClosingFeature(),
            new CraftingFeature(Recipes()));
    }

    /// <summary>A click on a window's slot, exactly as a vanilla client sends one.</summary>
    private static void Click(Player player, int windowId, int slot, int mode = 0, sbyte button = 0) {
        player.HandlePacket(new ServerBoundClickContainerPacket {
            WindowId = windowId,
            StateId = 0,
            Slot = (short)slot,
            Button = button,
            Mode = mode,
            ChangedSlots = [],
            CursorItem = null
        });
    }

    // ---------------------------------------------------------------- the player's own two by two

    [Test]
    public void FillingThePlayerGridFillsTheResultSlot() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 3);
        Assert.That(inventory[PlayerInventory.CraftingOutputSlot].IsAir(), Is.True,
            "one stick is not a recipe");

        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 3);

        Assert.Multiple(() => {
            Assert.That(inventory[PlayerInventory.CraftingOutputSlot].Type.Identifier,
                Is.EqualTo(Item.Torch.Identifier));
            Assert.That(inventory[PlayerInventory.CraftingOutputSlot].Count, Is.EqualTo(4));
        });
    }

    /// <summary>Cells are 1, 2 on the top row and 3, 4 on the bottom, so a vertical pair is 1 and 3.</summary>
    [Test]
    public void TheGridIsTwoWideNotFourLong() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 3);
        inventory[PlayerInventory.CraftingInput2Slot] = new ItemStack(Item.Stick, 3);

        Assert.That(inventory[PlayerInventory.CraftingOutputSlot].IsAir(), Is.True);
    }

    [Test]
    public void TakingTheResultSpendsOneOfEachInput() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 3);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 1);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot);

        Assert.Multiple(() => {
            Assert.That(scene.Player.CursorItem.Type.Identifier, Is.EqualTo(Item.Torch.Identifier));
            Assert.That(scene.Player.CursorItem.Count, Is.EqualTo(4));
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Count, Is.EqualTo(2));
            Assert.That(inventory[PlayerInventory.CraftingInput3Slot].IsAir(), Is.True,
                "the last of a stack leaves an empty cell");
            Assert.That(inventory[PlayerInventory.CraftingOutputSlot].IsAir(), Is.True,
                "the grid no longer makes anything");
        });
    }

    [Test]
    public void TakingTheResultOntoAFullCursorDoesNothing() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 3);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 3);
        scene.Player.CursorItem = new ItemStack(Item.Diamond, 5);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot);

        Assert.Multiple(() => {
            Assert.That(scene.Player.CursorItem.Type.Identifier, Is.EqualTo(Item.Diamond.Identifier));
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Count, Is.EqualTo(3),
                "nothing was spent");
        });
    }

    /// <summary>The result slot takes nothing, however the click is spelled.</summary>
    [Test]
    public void NothingCanBePutIntoTheResultSlot() {
        InteractionScene scene = Scene();
        scene.Player.CursorItem = new ItemStack(Item.Diamond, 5);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot);

        Assert.Multiple(() => {
            Assert.That(scene.Player.Inventory[PlayerInventory.CraftingOutputSlot].IsAir(), Is.True);
            Assert.That(scene.Player.CursorItem.Count, Is.EqualTo(5));
        });
    }

    // ---------------------------------------------------------------- remainders

    [Test]
    public void AnInputWithARemainderLeavesItInTheCell() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.WaterBucket);
        inventory[PlayerInventory.CraftingInput2Slot] = new ItemStack(Item.Wheat, 2);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot);

        Assert.Multiple(() => {
            Assert.That(scene.Player.CursorItem.Type.Identifier, Is.EqualTo(Item.Cake.Identifier));
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Type.Identifier,
                Is.EqualTo(Item.Bucket.Identifier), "the water bucket left an empty bucket");
            Assert.That(inventory[PlayerInventory.CraftingInput2Slot].Count, Is.EqualTo(1));
        });
    }

    // ---------------------------------------------------------------- shift clicking

    [Test]
    public void ShiftClickingCraftsUntilTheGridRunsOut() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 5);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 3);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot, mode: 1);

        int torches = Enumerable.Range(PlayerInventory.RegularInventoryStartIndex,
                PlayerInventory.HotbarSlot9 + 1 - PlayerInventory.RegularInventoryStartIndex)
            .Select(slot => inventory[slot])
            .Where(stack => stack.Type.Identifier == Item.Torch.Identifier)
            .Sum(stack => stack.Count);

        Assert.Multiple(() => {
            Assert.That(torches, Is.EqualTo(12), "three crafts of four, limited by the shorter stack");
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Count, Is.EqualTo(2));
            Assert.That(inventory[PlayerInventory.CraftingInput3Slot].IsAir(), Is.True);
        });
    }

    // ---------------------------------------------------------------- number keys and the drop key

    [Test]
    public void ANumberKeyPutsOneCraftInThatHotbarSlot() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 2);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 2);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot, mode: 2, button: 3);

        Assert.Multiple(() => {
            Assert.That(inventory.GetHotbarItem(3).Type.Identifier, Is.EqualTo(Item.Torch.Identifier));
            Assert.That(inventory.GetHotbarItem(3).Count, Is.EqualTo(4));
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Count, Is.EqualTo(1));
        });
    }

    /// <summary>A swap never moves the hotbar's stack into a result slot.</summary>
    [Test]
    public void ANumberKeyAimedAtAFullSlotDoesNothing() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 2);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 2);
        inventory.SetHotbarItem(3, new ItemStack(Item.Diamond, 1));

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot, mode: 2, button: 3);

        Assert.Multiple(() => {
            Assert.That(inventory.GetHotbarItem(3).Type.Identifier, Is.EqualTo(Item.Diamond.Identifier));
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Count, Is.EqualTo(2),
                "nothing was spent");
        });
    }

    [Test]
    public void TheDropKeyThrowsOneCraftAndSpendsTheGrid() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        List<ItemStack> dropped = [];
        scene.Server.Events.AddListener<ManagedServer.Events.PlayerDropItemEvent>(e => dropped.Add(e.Item));

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 2);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 2);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot, mode: 4);

        Assert.Multiple(() => {
            Assert.That(dropped, Has.Count.EqualTo(1));
            Assert.That(dropped[0].Type.Identifier, Is.EqualTo(Item.Torch.Identifier));
            Assert.That(dropped[0].Count, Is.EqualTo(4));
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Count, Is.EqualTo(1));
        });
    }

    /// <summary>The drop key is gated on an empty cursor.</summary>
    [Test]
    public void TheDropKeyWithAFullCursorDoesNothing() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 2);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 2);
        scene.Player.CursorItem = new ItemStack(Item.Diamond, 1);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot, mode: 4);

        Assert.That(inventory[PlayerInventory.CraftingInput1Slot].Count, Is.EqualTo(2));
    }

    // ---------------------------------------------------------------- the crafting table window

    [Test]
    public void TheTableGridIsThreeWide() {
        InteractionScene scene = Scene();
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        // Slots 1 and 4 are the left column's top two cells of a three wide grid.
        table[CraftingInventory.FirstGridSlot] = new ItemStack(Item.Stick, 2);
        table[CraftingInventory.FirstGridSlot + CraftingInventory.GridWidth] = new ItemStack(Item.Stick, 2);

        Assert.That(table[CraftingInventory.ResultSlot].Type.Identifier,
            Is.EqualTo(Item.Torch.Identifier));

        Click(scene.Player, table.WindowId, CraftingInventory.ResultSlot);

        Assert.Multiple(() => {
            Assert.That(scene.Player.CursorItem.Count, Is.EqualTo(4));
            Assert.That(table[CraftingInventory.FirstGridSlot].Count, Is.EqualTo(1));
        });
    }

    /// <summary>The same shape in the far corner, which is what the cropping and its offset are for.</summary>
    [Test]
    public void AShapeInTheCornerIsTheSameShape() {
        InteractionScene scene = Scene();
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        int bottomRight = CraftingInventory.FirstGridSlot + 8;
        int middleRight = bottomRight - CraftingInventory.GridWidth;

        table[middleRight] = new ItemStack(Item.Stick, 2);
        table[bottomRight] = new ItemStack(Item.Stick, 2);

        Assert.That(table[CraftingInventory.ResultSlot].Type.Identifier,
            Is.EqualTo(Item.Torch.Identifier));

        Click(scene.Player, table.WindowId, CraftingInventory.ResultSlot);

        Assert.Multiple(() => {
            Assert.That(table[middleRight].Count, Is.EqualTo(1), "the right cells were spent");
            Assert.That(table[bottomRight].Count, Is.EqualTo(1));
            Assert.That(table[CraftingInventory.FirstGridSlot].IsAir(), Is.True,
                "and not the top left ones");
        });
    }

    [Test]
    public void ClosingTheWindowGivesTheGridBack() {
        InteractionScene scene = Scene();
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        table[CraftingInventory.FirstGridSlot] = new ItemStack(Item.Diamond, 7);

        scene.Player.HandlePacket(new ServerBoundCloseContainerPacket { WindowId = table.WindowId });

        int diamonds = Enumerable.Range(0, scene.Player.Inventory.Size)
            .Select(slot => scene.Player.Inventory[slot])
            .Where(stack => stack.Type.Identifier == Item.Diamond.Identifier)
            .Sum(stack => stack.Count);

        Assert.Multiple(() => {
            Assert.That(table[CraftingInventory.FirstGridSlot].IsAir(), Is.True);
            Assert.That(diamonds, Is.EqualTo(7));
        });
    }

    // ---------------------------------------------------------------- quick move destinations

    /// <summary>
    /// A window's slot numbering for a player inventory slot: the thirty six storage slots follow the
    /// window's own, so the player's slot nine is the window's tenth.
    /// </summary>
    private static int WindowSlotOf(CraftingInventory table, int playerSlot) {
        return playerSlot - PlayerInventory.RegularInventoryStartIndex + table.PlayerInventoryStartIndex;
    }

    /// <summary>
    /// A shift click into the table aims at the nine cells. The result slot is not one of them, or
    /// the click would be a way to put items into it.
    /// </summary>
    [Test]
    public void ShiftClickingIntoTheTableFillsTheGridNotTheResult() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        inventory[PlayerInventory.RegularInventoryStartIndex] = new ItemStack(Item.Stick, 6);

        Click(scene.Player, table.WindowId,
            WindowSlotOf(table, PlayerInventory.RegularInventoryStartIndex), mode: 1);

        Assert.Multiple(() => {
            Assert.That(table[CraftingInventory.FirstGridSlot].Type.Identifier,
                Is.EqualTo(Item.Stick.Identifier), "the first cell of the grid");
            Assert.That(table[CraftingInventory.FirstGridSlot].Count, Is.EqualTo(6));
            Assert.That(table[CraftingInventory.ResultSlot].IsAir(), Is.True,
                "one cell of sticks is not a recipe, and nothing was moved into the result slot");
            Assert.That(inventory[PlayerInventory.RegularInventoryStartIndex].IsAir(), Is.True);
        });
    }

    /// <summary>
    /// The same, when the result slot holds a part stack of exactly what is being moved: a search
    /// that only refuses to fill an <b>empty</b> result slot tops this one up instead.
    /// </summary>
    [Test]
    public void AResultSlotIsNotToppedUpByAShiftClick() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        // A full grid of something that is not a recipe, so the result slot is the only slot in the
        // window with room, and something in it for the stacking pass to find.
        for (int cell = 0; cell < CraftingInventory.GridWidth * CraftingInventory.GridHeight; cell++) {
            table[CraftingInventory.FirstGridSlot + cell] = new ItemStack(Item.Diamond, 64);
        }
        table[CraftingInventory.ResultSlot] = new ItemStack(Item.Diamond, 60);

        inventory[PlayerInventory.RegularInventoryStartIndex] = new ItemStack(Item.Diamond, 8);

        Click(scene.Player, table.WindowId,
            WindowSlotOf(table, PlayerInventory.RegularInventoryStartIndex), mode: 1);

        Assert.Multiple(() => {
            Assert.That(table[CraftingInventory.ResultSlot].Count, Is.EqualTo(60), "untouched");
            Assert.That(inventory[PlayerInventory.HotbarSlot1].Count, Is.EqualTo(8),
                "the window refused them, so they crossed the player's own halves");
        });
    }

    /// <summary>
    /// A grid that will not take the stack sends it across the player's own two halves instead,
    /// which a chest does not do.
    /// </summary>
    [Test]
    public void AGridThatWillNotTakeItMovesItToTheHotbarInstead() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        for (int cell = 0; cell < CraftingInventory.GridWidth * CraftingInventory.GridHeight; cell++) {
            table[CraftingInventory.FirstGridSlot + cell] = new ItemStack(Item.Diamond, 64);
        }

        inventory[PlayerInventory.RegularInventoryStartIndex] = new ItemStack(Item.Stick, 6);

        Click(scene.Player, table.WindowId,
            WindowSlotOf(table, PlayerInventory.RegularInventoryStartIndex), mode: 1);

        Assert.Multiple(() => {
            Assert.That(inventory[PlayerInventory.RegularInventoryStartIndex].IsAir(), Is.True);
            Assert.That(inventory[PlayerInventory.HotbarSlot1].Type.Identifier,
                Is.EqualTo(Item.Stick.Identifier), "the first hotbar slot, forwards");
        });
    }

    /// <summary>
    /// A result fills the player's inventory <b>backwards</b>, so the last hotbar slot gets it. The
    /// client draws the same, so the order is what makes the stack stay where it appeared.
    /// </summary>
    [Test]
    public void AShiftClickedResultLandsInTheLastHotbarSlot() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 1);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 1);

        Click(scene.Player, 0, PlayerInventory.CraftingOutputSlot, mode: 1);

        Assert.Multiple(() => {
            Assert.That(inventory[PlayerInventory.HotbarSlot9].Type.Identifier,
                Is.EqualTo(Item.Torch.Identifier));
            Assert.That(inventory[PlayerInventory.HotbarSlot9].Count, Is.EqualTo(4));
            Assert.That(inventory[PlayerInventory.HotbarSlot1].IsAir(), Is.True,
                "not the first hotbar slot, which is where AddItem's own order would have put it");
        });
    }

    /// <summary>The table's result slot lands in the same place.</summary>
    [Test]
    public void ATableResultLandsInTheLastHotbarSlotToo() {
        InteractionScene scene = Scene();
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        table[CraftingInventory.FirstGridSlot] = new ItemStack(Item.Stick, 1);
        table[CraftingInventory.FirstGridSlot + CraftingInventory.GridWidth] = new ItemStack(Item.Stick, 1);

        Click(scene.Player, table.WindowId, CraftingInventory.ResultSlot, mode: 1);

        Assert.That(scene.Player.Inventory[PlayerInventory.HotbarSlot9].Count, Is.EqualTo(4));
    }

    /// <summary>
    /// An input cell is the other direction, so taking the grid back fills the main inventory first.
    /// </summary>
    [Test]
    public void AGridCellEmptiesIntoTheMainInventoryFirst() {
        InteractionScene scene = Scene();
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        table[CraftingInventory.FirstGridSlot] = new ItemStack(Item.Stick, 5);

        Click(scene.Player, table.WindowId, CraftingInventory.FirstGridSlot, mode: 1);

        Assert.Multiple(() => {
            Assert.That(table[CraftingInventory.FirstGridSlot].IsAir(), Is.True);
            Assert.That(scene.Player.Inventory[PlayerInventory.RegularInventoryStartIndex].Count,
                Is.EqualTo(5), "the first main inventory slot, not the hotbar");
        });
    }

    /// <summary>The player's own two by two empties into the main inventory as well.</summary>
    [Test]
    public void ThePlayerGridEmptiesIntoTheMainInventoryFirst() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 5);

        Click(scene.Player, 0, PlayerInventory.CraftingInput1Slot, mode: 1);

        Assert.Multiple(() => {
            Assert.That(inventory[PlayerInventory.CraftingInput1Slot].IsAir(), Is.True);
            Assert.That(inventory[PlayerInventory.RegularInventoryStartIndex].Count, Is.EqualTo(5));
        });
    }

    /// <summary>
    /// The last empty slot in the main inventory is slot nine's row mate, and an off by one in the
    /// backwards walk is invisible until every other slot is full.
    /// </summary>
    [Test]
    public void TheFirstMainInventorySlotIsAValidDestination() {
        InteractionScene scene = Scene();
        PlayerInventory inventory = scene.Player.Inventory;
        CraftingInventory table = new(scene.Server);
        scene.Player.OpenInventory = table;

        foreach (int slot in PlayerInventory.QuickMoveSlots) {
            if (slot != PlayerInventory.RegularInventoryStartIndex) {
                inventory[slot] = new ItemStack(Item.Diamond, 64);
            }
        }

        table[CraftingInventory.FirstGridSlot] = new ItemStack(Item.Stick, 5);

        Click(scene.Player, table.WindowId, CraftingInventory.FirstGridSlot, mode: 1);

        Assert.That(inventory[PlayerInventory.RegularInventoryStartIndex].Type.Identifier,
            Is.EqualTo(Item.Stick.Identifier));
    }

    // ---------------------------------------------------------------- opting out

    /// <summary>A server with no crafting feature has an inert grid.</summary>
    [Test]
    public void WithoutTheFeatureTheGridDoesNothing() {
        InteractionScene scene = new(new InventoryClickFeature(), new InventoryClosingFeature());
        PlayerInventory inventory = scene.Player.Inventory;

        inventory[PlayerInventory.CraftingInput1Slot] = new ItemStack(Item.Stick, 3);
        inventory[PlayerInventory.CraftingInput3Slot] = new ItemStack(Item.Stick, 3);

        Assert.That(inventory[PlayerInventory.CraftingOutputSlot].IsAir(), Is.True);
    }
}
