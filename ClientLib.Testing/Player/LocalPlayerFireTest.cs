using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace ClientLib.Testing.Player;

/// <summary>
/// The local player's own <c>remainingFireTicks</c>: set by the blocks it stands in after each tick's
/// move and cleared by the next <c>baseTick</c>, so it reads as burning between ticks.
/// </summary>
public class LocalPlayerFireTest {
    private const int Floor = 16;

    private static (MinecraftClient Client, LocalPlayer Player) World(Func<int, int, int, uint> blocks) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
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

    /// <summary>A stone floor, with <paramref name="feet"/> where the player stands and <paramref name="head"/> above it.</summary>
    private static Func<int, int, int, uint> StandingIn(uint feet, uint head = 0) => (x, y, z) =>
        y < Floor ? Block.Stone.StateId
        : x == 0 && z == 0 && y == Floor ? feet
        : x == 0 && z == 0 && y == Floor + 1 ? head
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
}
