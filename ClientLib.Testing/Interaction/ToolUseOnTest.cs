using ClientLib.Interaction;
using Minecraft;
using NBT;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Interaction;

/// <summary>
/// An axe's <c>block_transformer</c> and a honeycomb's <c>useOn</c>, read through the transformer registry
/// and vanilla's weathering and wax tables.
/// </summary>
public class ToolUseOnTest {
    private static readonly MinecraftClient Client = new(new ClientOptions { Username = "Test" });

    /// <summary>The use as acknowledged at a block in an otherwise empty level.</summary>
    private static ToolUse? Classify(IItem item, IBlock before, IBlock after) {
        UseOnOutcome use = new(Hand.MainHand, new ItemStack(item), (0, 64, 0), BlockFace.PosY,
            (ushort)before.StateId, (ushort)after.StateId, (0, 65, 0), 0, 0);
        return ToolUseOn.Classify(Client.Interactions.Transforms, new World.ClientLevel(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0), use);
    }

    [Test]
    public void APairWhoseNamesShareNoPrefixIsStillAPair() {
        Assert.That(Classify(Item.IronAxe, Block.ExposedLightningRod, Block.LightningRod)?.LevelEvent, Is.EqualTo(3005));
        Assert.That(Classify(Item.IronAxe, Block.WaxedLightningRod, Block.LightningRod)?.LevelEvent, Is.EqualTo(3004));
        Assert.That(Classify(Item.Honeycomb, Block.CopperChain, Block.WaxedCopperChain)?.LevelEvent, Is.EqualTo(3003));
    }

    [Test]
    public void AStripPlaysItsSoundAndRaisesNoEvent() {
        ToolUse? strip = Classify(Item.IronAxe, Block.OakLog, Block.StrippedOakLog);
        Assert.That(strip?.LevelEvent, Is.EqualTo(0));
        Assert.That(strip?.Sound?.Identifier, Is.EqualTo(SoundType.AxeStrip.Identifier));
    }

    [Test]
    public void AChangeOutsideTheToolsTableIsNotTheTool() {
        // Something else turned the log into planks; an axe strips it to its stripped log only.
        Assert.That(Classify(Item.IronAxe, Block.OakLog, Block.OakPlanks), Is.Null);
        // Weathering goes forwards on its own; only a step back is a scrape.
        Assert.That(Classify(Item.IronAxe, Block.CopperBlock, Block.ExposedCopper), Is.Null);
        Assert.That(Classify(Item.Honeycomb, Block.WaxedCopperBlock, Block.CopperBlock), Is.Null);
        Assert.That(Classify(Item.Stick, Block.ExposedCopper, Block.CopperBlock), Is.Null);
    }

    [Test]
    public void TheInversesAreTheirTablesReadBackwards() {
        foreach ((Identifier from, IBlock to) in BlockConversions.WeatheringNext) {
            Assert.That(BlockConversions.WeatheringPrevious[to.Identifier].Identifier, Is.EqualTo(from));
        }
        foreach ((Identifier from, IBlock to) in BlockConversions.Waxables) {
            Assert.That(BlockConversions.WaxOff[to.Identifier].Identifier, Is.EqualTo(from));
        }
        Assert.That(BlockConversions.WeatheringPrevious, Has.Count.EqualTo(BlockConversions.WeatheringNext.Count));
        Assert.That(BlockConversions.WaxOff, Has.Count.EqualTo(BlockConversions.Waxables.Count));
    }

    [TestCase("minecraft:oak_log", true)]
    [TestCase("minecraft:bamboo_block", true)]
    [TestCase("minecraft:crimson_hyphae", true)]
    [TestCase("minecraft:poplar_log", true)]
    [TestCase("minecraft:exposed_cut_copper_stairs", true)]
    [TestCase("minecraft:waxed_copper_block", true)]
    // The first stage has nothing to scrape back to and no wax to take off.
    [TestCase("minecraft:copper_block", false)]
    [TestCase("minecraft:copper_ore", false)]
    [TestCase("minecraft:stripped_oak_log", false)]
    [TestCase("minecraft:stone", false)]
    public void AnAxeActsOnWhatItsTransformerAnswers(string block, bool consumes) {
        ushort target = (ushort)VanillaRegistry.Data.Blocks[block].StateId;
        BlockTransforms.Match? match = Client.Interactions.Transforms.Find(new ItemStack(Item.IronAxe), 0, 64, 0, BlockFace.PosY, (_, _, _) => target);
        Assert.That(match != null, Is.EqualTo(consumes));
    }

    [Test]
    public void AStripKeepsTheLogsAxis() {
        IBlock log = Block.OakLog.WithState(new NBT.Tags.CompoundTag(("axis", new NBT.Tags.StringTag("x"))));
        BlockTransforms.Match? match = Client.Interactions.Transforms.Find(new ItemStack(Item.IronAxe), 0, 64, 0, BlockFace.PosY,
            (_, _, _) => (ushort)log.StateId);
        Assert.That(match?.Result.ToStateNbt()["axis"]?.GetString(), Is.EqualTo("x"));
    }

    [TestCase("minecraft:copper_block", true)]
    [TestCase("minecraft:oxidized_copper_bulb", true)]
    [TestCase("minecraft:waxed_copper_block", false)]
    [TestCase("minecraft:stone", false)]
    public void AHoneycombIsPredictedToActOnlyOnWhatItWaxes(string block, bool consumes) {
        IBlock target = VanillaRegistry.Data.Blocks[block];
        Assert.That(UsePrediction.ItemUseOnConsumes(new ItemStack(Item.Honeycomb), target), Is.EqualTo(consumes));
    }
}
