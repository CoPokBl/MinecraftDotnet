using ClientLib.Interaction;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Interaction;

/// <summary>An axe's and a honeycomb's <c>useOn</c>, read through vanilla's strip, weathering and wax tables.</summary>
public class ToolUseOnTest {
    private static readonly Identifier Axe = Item.IronAxe.Identifier, Honeycomb = Item.Honeycomb.Identifier;

    [Test]
    public void APairWhoseNamesShareNoPrefixIsStillAPair() {
        Assert.That(ToolUseOn.Classify(Axe, Block.ExposedLightningRod, Block.LightningRod), Is.EqualTo(ToolBlockChange.Scrape));
        Assert.That(ToolUseOn.Classify(Axe, Block.WaxedLightningRod, Block.LightningRod), Is.EqualTo(ToolBlockChange.WaxOff));
        Assert.That(ToolUseOn.Classify(Honeycomb, Block.CopperChain, Block.WaxedCopperChain), Is.EqualTo(ToolBlockChange.WaxOn));
    }

    [Test]
    public void AChangeOutsideTheToolsTableIsNotTheTool() {
        // Something else turned the log into planks; an axe strips it to its stripped log only.
        Assert.That(ToolUseOn.Classify(Axe, Block.OakLog, Block.OakPlanks), Is.EqualTo(ToolBlockChange.None));
        // Weathering goes forwards on its own; only a step back is a scrape.
        Assert.That(ToolUseOn.Classify(Axe, Block.CopperBlock, Block.ExposedCopper), Is.EqualTo(ToolBlockChange.None));
        Assert.That(ToolUseOn.Classify(Honeycomb, Block.WaxedCopperBlock, Block.CopperBlock), Is.EqualTo(ToolBlockChange.None));
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
    [TestCase("minecraft:exposed_cut_copper_stairs", true)]
    [TestCase("minecraft:waxed_copper_block", true)]
    // The first stage has nothing to scrape back to and no wax to take off.
    [TestCase("minecraft:copper_block", false)]
    [TestCase("minecraft:copper_ore", false)]
    [TestCase("minecraft:stripped_oak_log", false)]
    [TestCase("minecraft:stone", false)]
    public void AnAxeIsPredictedToActOnWhatItsTablesHold(string block, bool consumes) {
        IBlock target = VanillaRegistry.Data.Blocks[block];
        Assert.That(UsePrediction.ItemUseOnConsumes(new ItemStack(Item.IronAxe), target), Is.EqualTo(consumes));
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
