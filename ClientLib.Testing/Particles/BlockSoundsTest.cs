using ClientLib.Maths;
using ClientLib.Particles;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Sound;

namespace ClientLib.Testing.Particles;

/// <summary>The sounds the block and fluid <c>animateTick</c>s play, and the particle engine standing still with the tick rate frozen.</summary>
public class BlockSoundsTest {
    private const int Floor = 16;

    /// <summary>Stone below <see cref="Floor"/>, air above, the player standing on it at the origin.</summary>
    private static (MinecraftClient Client, ClientLevel Level, List<AnimateTickSound> Sounds) World() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
                    uint[] states = new uint[ClientSection.Volume];
                    for (int y = 0; y < 16; y++) {
                        if (baseY + y < Floor) {
                            Array.Fill(states, Block.Stone.StateId, y << 8, 256);
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        client.Particles.Enabled = true;
        List<AnimateTickSound> sounds = [];
        client.AnimateTicks.SoundPlayed += sounds.Add;
        return (client, level, sounds);
    }

    private static void Set(ClientLevel level, int x, int y, int z, IBlock block) => level.SetState(x, y, z, (ushort)block.StateId);

    private static void Tag(MinecraftClient client, Identifier tag, params IBlock[] blocks) {
        if (!client.Tags.TryGetValue("minecraft:block", out Dictionary<Identifier, int[]>? tags)) {
            client.Tags["minecraft:block"] = tags = new Dictionary<Identifier, int[]>();
        }
        tags[tag] = blocks.Select(b => VanillaRegistry.Data.Blocks.GetProtocolId(b)).ToArray();
    }

    /// <summary>The sounds of so many animate ticks of one position, of one type.</summary>
    private static List<AnimateTickSound> Animate(MinecraftClient client, List<AnimateTickSound> sounds, int x, int y, int z, int times, ISoundType? only = null) {
        sounds.Clear();
        for (int i = 0; i < times; i++) {
            client.AnimateTicks.AnimateAt(x, y, z);
        }
        return only == null ? [..sounds] : sounds.Where(s => s.Sound.Identifier == only.Identifier).ToList();
    }

    [Test]
    public void FireCracklesOnceInTwentyFourTicks() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Set(level, 0, Floor, 3, Block.Fire);
        const int Tries = 24000;
        List<AnimateTickSound> made = Animate(client, sounds, 0, Floor, 3, Tries);
        Assert.That(made.Select(s => s.Sound.Identifier).Distinct(), Is.EqualTo(new[] { SoundType.FireAmbient.Identifier }));
        Assert.That(made, Has.Count.EqualTo(Tries / 24).Within(Tries / 24 / 4));
        Assert.That(made, Has.All.Matches<AnimateTickSound>(s => s.Category == SoundCategory.Blocks && s.X == 0.5 && s.Y == Floor + 0.5 && s.Z == 3.5
                                                                  && s.Volume is >= 1.0F and < 2.0F && s.Pitch is >= 0.3F and < 1.0F && !s.AtPlayer));
    }

    [TestCaseSource(nameof(Plain))]
    public void BlocksPlayTheirOwnSoundWhereVanillaPutsIt(IBlock block, ISoundType sound, SoundCategory category, double dx, double dy, double dz) {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Set(level, 0, Floor, 3, block);
        List<AnimateTickSound> made = Animate(client, sounds, 0, Floor, 3, 5000, sound);
        Assert.That(made, Is.Not.Empty);
        Assert.That(made, Has.All.Matches<AnimateTickSound>(s => s.Category == category && s.X == dx && s.Y == Floor + dy && s.Z == 3 + dz));
    }

    private static IEnumerable<object[]> Plain() => [
        [Block.Furnace.WithLit(true), SoundType.FurnaceFireCrackle, SoundCategory.Blocks, 0.5, 0.0, 0.5],
        [Block.BlastFurnace.WithLit(true), SoundType.BlastfurnaceFireCrackle, SoundCategory.Blocks, 0.5, 0.0, 0.5],
        [Block.Smoker.WithLit(true), SoundType.SmokerSmoke, SoundCategory.Blocks, 0.5, 0.0, 0.5],
        [Block.Campfire.WithLit(true), SoundType.CampfireCrackle, SoundCategory.Blocks, 0.5, 0.5, 0.5],
        [Block.SoulCampfire.WithLit(true), SoundType.CampfireCrackle, SoundCategory.Blocks, 0.5, 0.5, 0.5],
        [Block.RespawnAnchor with { Charges = 1 }, SoundType.RespawnAnchorAmbient, SoundCategory.Blocks, 0.5, 0.5, 0.5],
        [Block.NetherPortal, SoundType.PortalAmbient, SoundCategory.Blocks, 0.5, 0.5, 0.5],
        [Block.BubbleColumn with { Drag = true }, SoundType.BubbleColumnWhirlpoolAmbient, SoundCategory.Blocks, 0.0, 0.0, 0.0],
        [Block.BubbleColumn with { Drag = false }, SoundType.BubbleColumnUpwardsAmbient, SoundCategory.Blocks, 0.0, 0.0, 0.0],
        [Block.DriedGhast.WithWaterlogged(true), SoundType.DriedGhastAmbientWater, SoundCategory.Blocks, 0.5, 0.5, 0.5],
        // The candle's sound sits half a block on from its flame, which is the middle of the block.
        [Block.Candle.WithLit(true), SoundType.CandleAmbient, SoundCategory.Blocks, 1.0, 1.0, 1.0],
        [Block.Water with { Level = 3 }, SoundType.WaterAmbient, SoundCategory.Ambient, 0.5, 0.5, 0.5],
        [Block.Lava, SoundType.LavaAmbient, SoundCategory.Ambient, 0.0, 0.0, 0.0]
    ];

    [TestCaseSource(nameof(Silent))]
    public void BlocksOutOfTheirSoundingStateAreSilent(IBlock block) {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Set(level, 0, Floor, 3, block);
        Assert.That(Animate(client, sounds, 0, Floor, 3, 5000), Is.Empty);
    }

    private static IEnumerable<object[]> Silent() => [
        [Block.Furnace.WithLit(false)],
        [Block.Campfire.WithLit(false)],
        [Block.RespawnAnchor with { Charges = 0 }],
        // Source and falling water bubble instead.
        [Block.Water],
        [Block.Water with { Level = 8 }],
        // A dry ghast out of water needs a block under it that the tag names.
        [Block.DriedGhast.WithWaterlogged(false)],
        [Block.PotentSulfur.WithPotentSulfurState(PotentSulfurState.Wet)],
        [Block.CreakingHeart],
        [Block.ClosedEyeblossom]
    ];

    [Test]
    public void LavaPopsWhereItsParticleJumps() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Set(level, 0, Floor, 3, Block.Lava);
        List<AnimateTickSound> pops = Animate(client, sounds, 0, Floor, 3, 5000, SoundType.LavaPop);
        Assert.That(pops, Is.Not.Empty);
        Assert.That(pops, Has.All.Matches<AnimateTickSound>(s => s.Y == Floor + 1.0 && s.X is >= 0.0 and < 1.0 && s.Z is >= 3.0 and < 4.0
                                                                 && s.Category == SoundCategory.Ambient));
        Set(level, 0, Floor + 1, 3, Block.Stone);
        Assert.That(Animate(client, sounds, 0, Floor, 3, 5000), Is.Empty);
    }

    [Test]
    public void PotentSulfurHissesUnderStandingWater() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Set(level, 0, Floor, 3, Block.PotentSulfur.WithPotentSulfurState(PotentSulfurState.Wet));
        Set(level, 0, Floor + 1, 3, Block.Water);
        List<AnimateTickSound> made = Animate(client, sounds, 0, Floor, 3, 500);
        Assert.That(made.Select(s => s.Sound.Identifier).Distinct(), Is.EqualTo(new[] { SoundType.PotentSulfurNoxiousGas.Identifier }));
    }

    [Test]
    public void ADryGhastOnItsTaggedBlocksRustles() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Tag(client, "minecraft:triggers_ambient_dried_ghast_block_sounds", Block.Stone);
        Set(level, 0, Floor, 3, Block.DriedGhast.WithWaterlogged(false));
        Assert.That(Animate(client, sounds, 0, Floor, 3, 2000, SoundType.DriedGhastAmbient), Is.Not.Empty);
    }

    [Test]
    public void HangingMossOnlySoundsUnderPaleOak() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Tag(client, "minecraft:pale_oak_logs", Block.PaleOakLog);
        Set(level, 0, Floor + 3, 3, Block.PaleHangingMoss);
        Set(level, 0, Floor + 4, 3, Block.OakLog);
        Assert.That(Animate(client, sounds, 0, Floor + 3, 3, 10000), Is.Empty);
        Set(level, 0, Floor + 4, 3, Block.PaleOakLog);
        List<AnimateTickSound> made = Animate(client, sounds, 0, Floor + 3, 3, 10000, SoundType.PaleHangingMossIdle);
        Assert.That(made, Is.Not.Empty);
        Assert.That(made, Has.All.Matches<AnimateTickSound>(s => s.X == 0.0 && s.Y == Floor + 3 && s.Z == 3.0 && s.Category == SoundCategory.Ambient));
    }

    [Test]
    public void AnOpenEyeblossomOnPaleMossMurmurs() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Set(level, 0, Floor - 1, 3, Block.PaleMossBlock);
        Set(level, 0, Floor, 3, Block.OpenEyeblossom);
        Assert.That(Animate(client, sounds, 0, Floor, 3, 10000, SoundType.EyeblossomIdle), Is.Not.Empty);
    }

    [Test]
    public void DryGrassIsHeardWhereThePlayerIs() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Tag(client, "minecraft:triggers_ambient_desert_dry_vegetation_block_sounds", Block.Stone);
        Set(level, 4, Floor, 3, Block.ShortDryGrass);
        List<AnimateTickSound> made = Animate(client, sounds, 4, Floor, 3, 4000);
        Assert.That(made, Is.Not.Empty);
        Assert.That(made, Has.All.Matches<AnimateTickSound>(s => s.AtPlayer && s.Sound.Identifier == SoundType.DryGrassAmbient.Identifier
                                                                 && s.X == 0.5 && s.Y == Floor && s.Z == 0.5));
    }

    [Test]
    public void ADeadBushIsQuieterOnTerracotta() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Tag(client, "minecraft:triggers_ambient_desert_dry_vegetation_block_sounds", Block.Stone, Block.Terracotta);
        Tag(client, "minecraft:terracotta", Block.Terracotta);
        Set(level, 0, Floor, 3, Block.DeadBush);
        const int Tries = 130 * 300;
        int onStone = Animate(client, sounds, 0, Floor, 3, Tries, SoundType.DeadbushIdle).Count;
        Set(level, 0, Floor - 1, 3, Block.Terracotta);
        int onTerracotta = Animate(client, sounds, 0, Floor, 3, Tries, SoundType.DeadbushIdle).Count;
        Assert.That(onStone, Is.EqualTo(300).Within(90));
        Assert.That(onTerracotta, Is.EqualTo(100).Within(45));
    }

    /// <summary>The four columns eight blocks off: all of them have to hold the tagged block, for the post increment.</summary>
    [TestCase(false, ExpectedResult = true)]
    [TestCase(true, ExpectedResult = false)]
    public bool SandSoundsOnlyInTheMiddleOfMoreSand(bool oneSideIsNot) {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Tag(client, "minecraft:triggers_ambient_desert_sand_block_sounds", Block.Stone);
        Set(level, 0, Floor - 1, 3, Block.Sand);
        if (oneSideIsNot) {
            Set(level, -8, Floor - 1, 3, Block.Dirt);
        }
        return Animate(client, sounds, 0, Floor - 1, 3, 2100 * 10, SoundType.SandIdle).Count > 0;
    }

    [Test]
    public void ACreakingHeartCreaksOnlyAtNightAmongPaleOakLogs() {
        (MinecraftClient client, ClientLevel level, List<AnimateTickSound> sounds) = World();
        Tag(client, "minecraft:pale_oak_logs", Block.PaleOakLog);
        client.Tags["minecraft:timeline"] = new Dictionary<Identifier, int[]> {
            ["minecraft:in_overworld"] = [VanillaRegistry.Data.Timelines.GetProtocolId("minecraft:day")]
        };
        const int x = 0, y = Floor + 4, z = 3;
        foreach ((int dx, int dy, int dz) in new[] { (1, 0, 0), (-1, 0, 0), (0, 1, 0), (0, -1, 0), (0, 0, 1), (0, 0, -1) }) {
            Set(level, x + dx, y + dy, z + dz, Block.PaleOakLog);
        }
        Set(level, x, y, z, Block.CreakingHeart.WithCreakingHeartState(CreakingHeartState.Awake));
        level.Clocks.HandleUpdates(0, [("minecraft:overworld", 6000L, 0.0F, 1.0F)]);
        Assert.That(Animate(client, sounds, x, y, z, 2000), Is.Empty);
        level.Clocks.HandleUpdates(0, [("minecraft:overworld", 24000L * 3 + 18000L, 0.0F, 1.0F)]);
        List<AnimateTickSound> made = Animate(client, sounds, x, y, z, 2000, SoundType.CreakingHeartIdle);
        Assert.That(made, Has.Count.EqualTo(2000 / 16).Within(40));
        Set(level, x, y + 1, z, Block.OakLog);
        Assert.That(Animate(client, sounds, x, y, z, 2000), Is.Empty);
    }

    [Test]
    public void ParticlesHoldStillWhileTheTickRateIsFrozen() {
        (MinecraftClient client, ClientLevel level, _) = World();
        ParticleEngine engine = client.Particles;
        engine.AddParticle(Particle.Flame, 0.5, Floor + 1, 3.5, 0.0, 0.0, 0.0);
        level.TickRateManager.IsFrozen = true;
        level.TickRateManager.Tick();
        engine.Tick();
        Assert.That(engine.Particles.Length, Is.Zero);
        Assert.That(engine.Pending.Length, Is.EqualTo(1));
        level.TickRateManager.IsFrozen = false;
        level.TickRateManager.Tick();
        engine.Tick();
        Assert.That(engine.Particles.Length, Is.EqualTo(1));
    }
}
