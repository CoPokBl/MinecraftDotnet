using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Biomes;
using Minecraft.Data.Generated;

namespace ClientLib.Testing.Player;

/// <summary>
/// The local player's own <c>remainingFireTicks</c>: set by the blocks it stands in after each tick's
/// move and cleared by the next <c>baseTick</c>, so it reads as burning between ticks.
/// </summary>
public class LocalPlayerFireTest {
    private const int Floor = 16;

    private static (MinecraftClient Client, LocalPlayer Player) World(Func<int, int, int, uint> blocks, IBiome? biome = null) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        ushort biomeId = biome == null ? (ushort)0 : (ushort)level.Registry.Biomes.GetProtocolId(biome);
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = Enumerable.Repeat(biomeId, 64).ToArray();
                    uint[] states = new uint[ClientSection.Volume];
                    for (int y = 0; y < 16; y++) {
                        for (int z = 0; z < 16; z++) {
                            for (int x = 0; x < 16; x++) {
                                states[y << 8 | z << 4 | x] = blocks(cx * 16 + x, baseY + y, cz * 16 + z);
                            }
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        return (client, player);
    }

    /// <summary>
    /// A stone floor, with <paramref name="feet"/> where the player stands, <paramref name="head"/> above it
    /// and <paramref name="roof"/> two blocks over the head.
    /// </summary>
    private static Func<int, int, int, uint> StandingIn(uint feet, uint head = 0, uint roof = 0) => (x, y, z) =>
        y < Floor ? Block.Stone.StateId
        : x == 0 && z == 0 && y == Floor ? feet
        : x == 0 && z == 0 && y == Floor + 1 ? head
        : x == 0 && z == 0 && y == Floor + 3 ? roof
        : 0;

    [Test]
    public void FireIgnitesForEightSeconds() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId));
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.EqualTo(160));
        Assert.That(player.IsOnFire, Is.True);
    }

    [Test]
    public void LeavingTheFireClearsItOnTheNextTick() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId));
        client.Tick();
        player.Position = new Vec3d(3.5, Floor, 3.5);
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.Zero);
        Assert.That(player.IsOnFire, Is.False);
    }

    [Test]
    public void AnInvulnerablePlayerBurnsForOneTick() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId));
        player.Invulnerable = true;
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.EqualTo(1));
        Assert.That(player.IsOnFire, Is.True);
    }

    [Test]
    public void LavaIgnitesForFifteenSeconds() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Lava.StateId));
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.EqualTo(300));
    }

    [Test]
    public void WaterPutsOutFireInTheSameTick() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId, Block.Water.StateId));
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.Zero);
        Assert.That(player.IsOnFire, Is.False);
    }

    /// <summary>
    /// <c>applyEffectsFromBlocks</c> lights the fire, then <c>isInRain</c> clears it: plains is 0.8 degrees,
    /// over <c>warmEnoughToRain</c>'s 0.15, and nothing in the column blocks motion above the feet.
    /// </summary>
    [Test]
    public void RainPutsOutFireInTheSameTick() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId), Biome.Plains);
        client.Level!.RainLevel = 1.0F;
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.Zero);
    }

    /// <summary>Stone at y 19 puts the <c>MOTION_BLOCKING</c> height at 20, over both 16 and the head's 17.</summary>
    [Test]
    public void RainDoesNotReachUnderARoof() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId, roof: Block.Stone.StateId), Biome.Plains);
        client.Level!.RainLevel = 1.0F;
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.EqualTo(160));
    }

    /// <summary>
    /// Lava is a fluid, so it raises the column's <c>MOTION_BLOCKING</c> height to 17 and the feet at 16 are
    /// dry; the top of the box is at 17.8, block 17, which the height does not cover.
    /// </summary>
    [Test]
    public void RainOnTheHeadPutsOutLava() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Lava.StateId), Biome.Plains);
        client.Level!.RainLevel = 1.0F;
        Assert.That(client.Level.GetHeight(Minecraft.Schemas.Chunks.HeightmapType.MotionBlocking, 0, 0), Is.EqualTo(Floor + 1));
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.Zero);
    }

    [Test]
    public void SnowDoesNotPutOutFire() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId), Biome.SnowyPlains);
        client.Level!.RainLevel = 1.0F;
        client.Tick();
        Assert.That(player.RemainingFireTicks, Is.EqualTo(160));
    }
}
