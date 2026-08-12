using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ManagedServer.Testing.Blocks;

/// <summary>
/// Break times have to agree with the client: the client decides on its own whether a block is
/// instamined, so a server that disagrees either rejects a break the client already played or
/// hands out a free one.
/// <p/>
/// Every expected value below was produced by running vanilla's own <c>ItemStack.getDestroySpeed</c>
/// and <c>BlockBehaviour.getDestroyProgress</c> out of the 26.2 server jar, the way
/// <c>LpVec3Test</c> pins its encodings, and is committed as a regression case. They are a readable
/// subset of a run over every block against 20 items, all 23920 of which matched exactly.
/// </summary>
[TestFixture]
public class BlockBreakSpeedTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private static int BreakTicks(string item, string block, bool eyeInWater = false, bool onGround = true,
        float miningEfficiency = 0f, float blockBreakSpeed = 1f, float submergedMiningSpeed = 0.2f,
        int digSpeedAmplifier = -1, int miningFatigueAmplifier = -1, GameMode gameMode = GameMode.Survival) {
        ItemStack stack = new(Registry.Items[Identifier.Parse(item)]);
        IBlock state = Registry.Blocks[Identifier.Parse(block)];
        return BlockUtils.GetBreakSpeed(Registry, gameMode, state, stack, eyeInWater, onGround, miningEfficiency,
            blockBreakSpeed, submergedMiningSpeed, digSpeedAmplifier, miningFatigueAmplifier);
    }

    /// <summary>Bare hand, a pickaxe of every tier, and the tools that carry their own rules.</summary>
    private static readonly (string Item, string Block, int Ticks)[] Vanilla = [
        ("air", "stone", 150),
        ("air", "dirt", 15),
        ("air", "gravel", 18),
        ("air", "glass", 9),
        ("air", "oak_log", 60),
        ("air", "iron_ore", 300),
        ("air", "cobweb", 400),
        ("air", "obsidian", 5000),
        ("air", "bedrock", -1),
        ("stick", "stone", 150),  // an item with no tool component is the same as a bare hand
        ("wooden_pickaxe", "stone", 23),
        ("wooden_pickaxe", "iron_ore", 150),  // mines faster than a hand even though it drops nothing
        ("wooden_pickaxe", "obsidian", 2500),
        ("iron_pickaxe", "stone", 8),
        ("iron_pickaxe", "iron_ore", 15),
        ("iron_pickaxe", "obsidian", 834),
        ("diamond_pickaxe", "stone", 6),
        ("diamond_pickaxe", "iron_ore", 12),
        ("diamond_pickaxe", "obsidian", 188),
        ("diamond_pickaxe", "deepslate", 12),
        ("netherite_pickaxe", "obsidian", 167),
        ("golden_pickaxe", "stone", 4),
        ("golden_pickaxe", "iron_ore", 25),  // fast, but the wrong tier, so the 100 divisor applies
        ("wooden_axe", "oak_log", 30),
        ("diamond_axe", "oak_log", 8),
        ("iron_shovel", "gravel", 3),
        ("diamond_shovel", "dirt", 2),
        ("diamond_hoe", "nether_wart_block", 4),
        ("shears", "white_wool", 5),
        ("shears", "oak_leaves", 0),
        ("shears", "cobweb", 8),
        ("diamond_sword", "cobweb", 8),
        ("diamond_sword", "oak_leaves", 4),
        ("wooden_sword", "bamboo", 0),  // the sword_instantly_mines rule, not a hardcoded case
        ("wooden_sword", "bamboo_sapling", 0),
        ("torch", "glass", 9),
        ("trident", "stone", 150),
        ("mace", "stone", 150)
    ];

    [TestCaseSource(nameof(Vanilla))]
    public void TestBreakTimeMatchesVanilla((string Item, string Block, int Ticks) test) {
        Assert.That(BreakTicks(test.Item, test.Block), Is.EqualTo(test.Ticks));
    }

    [Test]
    public void TestOffGroundIsFiveTimesSlower() {
        Assert.That(BreakTicks("diamond_pickaxe", "stone", onGround: false), Is.EqualTo(29));
    }

    [Test]
    public void TestSubmergedUsesTheAttributeRatherThanAFixedPenalty() {
        Assert.That(BreakTicks("diamond_pickaxe", "stone", eyeInWater: true), Is.EqualTo(29));
        Assert.That(BreakTicks("diamond_pickaxe", "stone", eyeInWater: true, onGround: false), Is.EqualTo(141));

        // Aqua affinity is the attribute being 1 rather than a branch that gets skipped.
        Assert.That(BreakTicks("diamond_pickaxe", "stone", eyeInWater: true, submergedMiningSpeed: 1f),
            Is.EqualTo(6));
    }

    [Test]
    public void TestHasteAndConduitPowerSpeedUpBreaking() {
        Assert.That(BreakTicks("diamond_pickaxe", "stone", digSpeedAmplifier: 0), Is.EqualTo(5));
        Assert.That(BreakTicks("diamond_pickaxe", "stone", digSpeedAmplifier: 4), Is.EqualTo(3));
        Assert.That(BreakTicks("air", "stone", digSpeedAmplifier: 0), Is.EqualTo(125));
    }

    [Test]
    public void TestMiningFatigueUsesVanillasTable() {
        Assert.That(BreakTicks("diamond_pickaxe", "stone", miningFatigueAmplifier: 0), Is.EqualTo(19));
        Assert.That(BreakTicks("diamond_pickaxe", "stone", miningFatigueAmplifier: 1), Is.EqualTo(63));
        // Level three drops by a factor of 33, not 3, in vanilla.
        Assert.That(BreakTicks("diamond_pickaxe", "stone", miningFatigueAmplifier: 2), Is.EqualTo(2084));
        Assert.That(BreakTicks("diamond_pickaxe", "stone", miningFatigueAmplifier: 5), Is.EqualTo(6945));
    }

    [Test]
    public void TestMiningEfficiencyOnlyAppliesToAToolThatIsAlreadyFasterThanAHand() {
        Assert.That(BreakTicks("diamond_pickaxe", "stone", miningEfficiency: 5f), Is.EqualTo(4));
        Assert.That(BreakTicks("shears", "white_wool", miningEfficiency: 5f), Is.EqualTo(3));

        // A bare hand is exactly 1, so the attribute is dropped.
        Assert.That(BreakTicks("air", "stone", miningEfficiency: 5f), Is.EqualTo(150));
    }

    [Test]
    public void TestBlockBreakSpeedScalesTheWholeThing() {
        Assert.That(BreakTicks("diamond_pickaxe", "stone", blockBreakSpeed: 2f), Is.EqualTo(3));

        // No progress is ever made, so the block can't be broken at all.
        Assert.That(BreakTicks("diamond_pickaxe", "stone", blockBreakSpeed: 0f), Is.EqualTo(-1));
    }

    [Test]
    public void TestCreativeIgnoresHardness() {
        Assert.That(BreakTicks("air", "obsidian", gameMode: GameMode.Creative), Is.EqualTo(0));
        Assert.That(BreakTicks("air", "bedrock", gameMode: GameMode.Creative), Is.EqualTo(0));
        Assert.That(BreakTicks("diamond_pickaxe", "obsidian", gameMode: GameMode.Creative), Is.EqualTo(0));
    }

    [Test]
    public void TestToolsThatOptOutBreakNothingInCreative() {
        foreach (string item in new[] { "diamond_sword", "trident", "mace" }) {
            Assert.That(BreakTicks(item, "stone", gameMode: GameMode.Creative), Is.EqualTo(-1), item);
        }
    }
}
