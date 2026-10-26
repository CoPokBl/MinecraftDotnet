using Minecraft.Data.Blocks;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Data.Loot;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

using ManagedServer.Loot;
using ManagedServer.Terrain.Data;
using ManagedServer.Testing.Terrain;

namespace ManagedServer.Testing.Blocks;

/// <summary>
/// What the vanilla tables actually give back. The parser only guarantees the table was read;
/// these pin that rolling it produces vanilla's answers.
/// <p/>
/// Most cases are asserted over many rolls rather than one, because a loot table is a distribution:
/// a single roll of leaves is nothing far more often than it is a sapling.
/// </summary>
[TestFixture]
public class BlockLootTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private static IBlock BlockOf(string id) => Registry.Blocks[Identifier.Parse(id)];

    private static ItemStack Tool(string id, params (IEnchantment Enchantment, int Level)[] enchantments) {
        ItemStack stack = new(Registry.Items[Identifier.Parse(id)]);
        return enchantments.Length == 0
            ? stack
            : stack.With(DataComponent.Enchantments, enchantments.Select(e => (e.Enchantment, e.Level)).ToArray());
    }

    /// <summary>
    /// The vanilla tables, read out of the pack rather than generated: a loot table is content, so
    /// nothing here ships one.
    /// </summary>
    private static DatapackBlockLoot Loot => DatapackBlockLoot.Load(VanillaPack.Source);

    /// <summary>One roll of a block's table, with the given tool in hand.</summary>
    private static ItemStack[] Roll(IBlock block, ItemStack tool, RandomSource random) {
        LootTable table = Loot.TableFor(block)
                          ?? throw new AssertionException($"{block.Identifier} has no loot table.");

        return table.GetRandomItems(new LootContext(block, Vec3<int>.Zero, random, Registry) {
            Tool = tool,
            HasBreaker = true
        });
    }

    /// <summary>The items one roll produced, as names, so a case reads as what a player would see.</summary>
    private static string[] Names(ItemStack[] stacks) {
        return stacks.Select(s => s.Type.Identifier.ToString()).ToArray();
    }

    private static RandomSource Seeded(long seed = 1234) => new LegacyRandomSource(seed);

    // ------------------------------------------------------------------ the ordinary cases

    [Test]
    public void TestStoneDropsCobblestone() {
        Assert.That(Names(Roll(Block.Stone, ItemStack.Air, Seeded())), Is.EqualTo(new[] { "minecraft:cobblestone" }));
    }

    [Test]
    public void TestSilkTouchDropsTheBlockItself() {
        ItemStack pick = Tool("diamond_pickaxe", (Enchantment.SilkTouch, 1));
        Assert.That(Names(Roll(Block.Stone, pick, Seeded())), Is.EqualTo(new[] { "minecraft:stone" }));
        Assert.That(Names(Roll(Block.GrassBlock, pick, Seeded())), Is.EqualTo(new[] { "minecraft:grass_block" }));
        Assert.That(Names(Roll(Block.DiamondOre, pick, Seeded())), Is.EqualTo(new[] { "minecraft:diamond_ore" }));
    }

    [Test]
    public void TestGrassBlockDropsDirt() {
        Assert.That(Names(Roll(Block.GrassBlock, ItemStack.Air, Seeded())), Is.EqualTo(new[] { "minecraft:dirt" }));
    }

    [Test]
    public void TestDiamondOreDropsOneDiamondWithoutFortune() {
        ItemStack pick = Tool("diamond_pickaxe");
        RandomSource random = Seeded();

        for (int i = 0; i < 200; i++) {
            ItemStack[] drops = Roll(Block.DiamondOre, pick, random);
            Assert.That(Names(drops), Is.EqualTo(new[] { "minecraft:diamond" }));
            Assert.That(drops[0].Count, Is.EqualTo(1));
        }
    }

    /// <summary>
    /// <c>ore_drops</c> draws its multiplier from <c>[0, level + 2)</c> and takes one off, so Fortune
    /// III is one to four diamonds and every one of those four has to be reachable. A formula that
    /// clamped instead of drawing would still pass a bounds check on its own.
    /// </summary>
    [Test]
    public void TestFortuneMultipliesOreDrops() {
        ItemStack pick = Tool("diamond_pickaxe", (Enchantment.Fortune, 3));
        RandomSource random = Seeded();
        HashSet<int> seen = [];

        for (int i = 0; i < 2000; i++) {
            ItemStack[] drops = Roll(Block.DiamondOre, pick, random);
            Assert.That(Names(drops), Is.EqualTo(new[] { "minecraft:diamond" }));
            seen.Add(drops[0].Count);
        }

        Assert.That(seen, Is.EquivalentTo(new[] { 1, 2, 3, 4 }));
    }

    // ------------------------------------------------------------------ state and tool branches

    [Test]
    public void TestWheatDropsOnlySeedsBeforeItIsGrown() {
        RandomSource random = Seeded();

        for (int i = 0; i < 100; i++) {
            IBlock young = Registry.Blocks["minecraft:wheat"].WithState(new NBT.Tags.CompoundTag(
                ("age", new NBT.Tags.StringTag("3"))));
            Assert.That(Names(Roll(young, ItemStack.Air, random)), Is.EqualTo(new[] { "minecraft:wheat_seeds" }));
        }
    }

    [Test]
    public void TestGrownWheatDropsWheatAndSeeds() {
        IBlock grown = Registry.Blocks["minecraft:wheat"].WithState(new NBT.Tags.CompoundTag(
            ("age", new NBT.Tags.StringTag("7"))));

        RandomSource random = Seeded();
        bool sawSeeds = false;

        for (int i = 0; i < 200; i++) {
            string[] names = Names(Roll(grown, ItemStack.Air, random));
            Assert.That(names, Does.Contain("minecraft:wheat"));
            sawSeeds |= names.Contains("minecraft:wheat_seeds");
        }

        // The seed pool is binomial with three extra rounds at 4/7, so nothing is a real outcome.
        Assert.That(sawSeeds, Is.True);
    }

    [Test]
    public void TestShearsDropLeavesThemselves() {
        ItemStack shears = Tool("shears");
        RandomSource random = Seeded();

        for (int i = 0; i < 100; i++) {
            Assert.That(Names(Roll(Block.OakLeaves, shears, random)), Is.EqualTo(new[] { "minecraft:oak_leaves" }));
        }
    }

    /// <summary>
    /// Leaves by hand are the three pool table: saplings at five percent, sticks at two, apples at a
    /// half, and nothing at all most of the time.
    /// </summary>
    [Test]
    public void TestBareHandedLeavesDropSaplingsSticksAndApples() {
        RandomSource random = Seeded();
        HashSet<string> seen = [];
        int empty = 0;

        for (int i = 0; i < 20000; i++) {
            string[] names = Names(Roll(Block.OakLeaves, ItemStack.Air, random));
            if (names.Length == 0) {
                empty++;
            }

            foreach (string name in names) {
                seen.Add(name);
            }
        }

        Assert.That(seen, Is.EquivalentTo(new[] {
            "minecraft:oak_sapling", "minecraft:stick", "minecraft:apple"
        }));
        Assert.That(empty, Is.GreaterThan(15000), "leaves should usually drop nothing");
    }

    // ------------------------------------------------------------------ the gates

    /// <summary>
    /// Glass has a table and it yields nothing without silk touch. This is also what keeps
    /// <c>BlockDropsFeature</c> and SkyWars' lucky blocks, which are yellow stained glass, out of each
    /// other's way.
    /// </summary>
    [Test]
    public void TestGlassDropsNothingWithoutSilkTouch() {
        RandomSource random = Seeded();

        for (int i = 0; i < 100; i++) {
            Assert.That(Roll(Block.YellowStainedGlass, ItemStack.Air, random), Is.Empty);
        }

        ItemStack pick = Tool("diamond_pickaxe", (Enchantment.SilkTouch, 1));
        Assert.That(Names(Roll(Block.YellowStainedGlass, pick, Seeded())),
            Is.EqualTo(new[] { "minecraft:yellow_stained_glass" }));
    }

    /// <summary>
    /// The wrong tool is not a loot table question at all: iron ore's table hands over an ingot
    /// whatever is in hand, and it is <c>canHarvestBlock</c> in front of it that stops a wooden
    /// pickaxe getting one.
    /// </summary>
    [Test]
    public void TestHarvestGateIsSeparateFromTheTable() {
        Assert.That(BlockUtils.CanHarvest(Tool("wooden_pickaxe"), Block.IronOre, Registry), Is.False);
        Assert.That(BlockUtils.CanHarvest(Tool("stone_pickaxe"), Block.IronOre, Registry), Is.True);
        Assert.That(BlockUtils.CanHarvest(ItemStack.Air, Block.Stone, Registry), Is.False);
        Assert.That(BlockUtils.CanHarvest(ItemStack.Air, Block.Dirt, Registry), Is.True);

        // The table itself does not know about any of that.
        Assert.That(Names(Roll(Block.IronOre, Tool("wooden_pickaxe"), Seeded())),
            Is.EqualTo(new[] { "minecraft:raw_iron" }));
    }

    // ------------------------------------------------------------------ coverage

    /// <summary>
    /// Every block either resolves to a table or is one of the ones vanilla gives
    /// <c>noLootTable()</c>. This is what catches an upstream <c>dropsLike</c> change, which would
    /// otherwise be a block that quietly stops dropping.
    /// </summary>
    [Test]
    public void TestEveryBlockWithATableResolves() {
        List<string> missing = [];
        int withTable = 0;

        foreach (IBlock block in Registry.Blocks.StatesByStateId.Values.DistinctBy(b => b.Identifier.ToString())) {
            if (block.LootTable == null) {
                continue;
            }

            withTable++;
            if (Loot.TableFor(block) == null) {
                missing.Add($"{block.Identifier} -> {block.LootTable}");
            }
        }

        Assert.That(missing, Is.Empty);
        Assert.That(withTable, Is.GreaterThan(1000));
    }

    /// <summary>
    /// A wall variant loots from its standing form, and a block with no table has none. Filename
    /// convention gets the first of these wrong and reads the second as a missing file.
    /// </summary>
    [Test]
    public void TestLootTableIdsComeFromTheJarNotTheName() {
        Assert.That(BlockOf("minecraft:oak_wall_sign").LootTable?.ToString(),
            Is.EqualTo("minecraft:blocks/oak_sign"));
        Assert.That(BlockOf("minecraft:bedrock").LootTable, Is.Null);
        Assert.That(BlockOf("minecraft:air").LootTable, Is.Null);

        Assert.That(Names(Roll(BlockOf("minecraft:oak_wall_sign"), ItemStack.Air, Seeded())),
            Is.EqualTo(new[] { "minecraft:oak_sign" }));
    }

    /// <summary>Ore experience is dumped off the block, not guessed from the name.</summary>
    [Test]
    public void TestOreExperienceRanges() {
        Assert.That(BlockOf("minecraft:diamond_ore").Experience, Is.EqualTo((3, 7)));
        Assert.That(BlockOf("minecraft:coal_ore").Experience, Is.EqualTo((0, 2)));
        Assert.That(BlockOf("minecraft:sculk").Experience, Is.EqualTo((1, 1)));

        // Copper ore really does give none, which is a zero range rather than an absent one.
        Assert.That(BlockOf("minecraft:copper_ore").Experience, Is.EqualTo((0, 0)));
        Assert.That(BlockOf("minecraft:stone").Experience, Is.Null);
    }

    /// <summary>
    /// Rolling every table with an empty hand, a shears and a fortune pick has to be exception free.
    /// Deliberately weak, and it covers the thing the types cannot: a table naming a state property
    /// the block does not have, or an item the registry does not know.
    /// </summary>
    [Test]
    public void TestEveryTableRollsWithoutThrowing() {
        ItemStack[] tools = [
            ItemStack.Air,
            Tool("shears"),
            Tool("diamond_pickaxe", (Enchantment.Fortune, 3)),
            Tool("diamond_pickaxe", (Enchantment.SilkTouch, 1))
        ];

        RandomSource random = Seeded();

        foreach (IBlock block in Registry.Blocks.StatesByStateId.Values) {
            if (Loot.TableFor(block) is not { } table) {
                continue;
            }

            foreach (ItemStack tool in tools) {
                Assert.DoesNotThrow(() => table.GetRandomItems(
                    new LootContext(block, Vec3<int>.Zero, random, Registry) {
                        Tool = tool,
                        HasBreaker = true
                    }), $"{block.Identifier} with {tool.Type.Identifier}");
            }
        }
    }
}
