using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ClientLib.Testing.Player;

/// <summary>
/// <c>LocalPlayer.updateAutoJump</c>, walking along +z on stone at y 16 towards an obstacle at z 2, from standing
/// on the ground. On stone a tick from rest moves 0.098, then 0.151508, 0.180723 and 0.196675 (0.98 input times
/// 0.1 times 0.216 over the stone's 0.6 cubed, the velocity kept at 0.546 a tick). The look ahead runs 0.7 past
/// the position after the move plus the move, so the 0.51 high segments reach the block at z 2 once that passes
/// 1.3: from z 0.5 that is the fourth tick (1.126906 + 0.196675), and the jump, 0.42 up, is the fifth tick's.
/// </summary>
public class AutoJumpTest {
    private const int Floor = 16;
    private const double JumpedY = Floor + (double)0.42F;

    private static (MinecraftClient Client, LocalPlayer Player) World(Func<int, int, int, uint> obstacle, double startZ = 0.5) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
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
                                int wx = cx * 16 + x, wy = baseY + y, wz = cz * 16 + z;
                                states[y << 8 | z << 4 | x] = wy < Floor ? Block.Stone.StateId : obstacle(wx, wy, wz);
                            }
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, startZ);
        player.OldPosition = player.Position;
        // Two ticks standing still: the first move is gravity's zero, the second lands, so the walk starts on the ground.
        for (int i = 0; i < 2; i++) {
            player.AutoJumpOption = true;
            player.Input = PlayerInput.None;
            client.Tick();
        }
        return (client, player);
    }

    private static uint Step(int x, int y, int z) => x == 0 && y == Floor && z == 2 ? Block.Stone.StateId : 0u;

    /// <summary>The Y after each of <paramref name="ticks"/> ticks walking forward.</summary>
    private static List<double> Walk(MinecraftClient client, LocalPlayer player, int ticks, bool option, Action<int>? before = null) {
        List<double> heights = [];
        for (int i = 0; i < ticks; i++) {
            before?.Invoke(i);
            player.AutoJumpOption = option;
            player.Input = new PlayerInput(Forward: true);
            client.Tick();
            heights.Add(player.Position.Y);
        }
        return heights;
    }

    [Test]
    public void TestAFullBlockStepIsJumpedTheTickAfterItIsSeen() {
        (MinecraftClient client, LocalPlayer player) = World(Step);
        List<double> heights = Walk(client, player, 5, true);
        Assert.That(heights, Is.EqualTo(new[] { Floor, Floor, Floor, Floor, JumpedY }).Within(1.0E-9));
    }

    [Test]
    public void TestWithTheOptionOffThePlayerWalksIntoTheStep() {
        (MinecraftClient client, LocalPlayer player) = World(Step);
        List<double> heights = Walk(client, player, 10, false);
        Assert.That(heights, Is.All.EqualTo(Floor));
        Assert.That(player.Position.Z, Is.EqualTo(1.7).Within(1.0E-7));
    }

    /// <summary>
    /// <c>autoJumpEnabled</c> takes the option only at the end of <c>sendPosition</c>: from z 1.25 the step is seen in
    /// the first tick's move (1.348 + 0.098 past 1.3), before that tick's option off has been read.
    /// </summary>
    [Test]
    public void TestTheOptionIsReadAfterTheMovementPacket() {
        (MinecraftClient client, LocalPlayer player) = World(Step, 1.25);
        Assert.That(Walk(client, player, 2, false), Is.EqualTo(new[] { Floor, JumpedY }).Within(1.0E-9));
    }

    [Test]
    public void TestTurningTheOptionOffTheTickTheStepIsSeenStillJumps() {
        (MinecraftClient client, LocalPlayer player) = World(Step);
        bool option = true;
        List<double> heights = [];
        for (int i = 0; i < 5; i++) {
            option = i < 3;
            heights.AddRange(Walk(client, player, 1, option));
        }
        Assert.That(heights, Is.EqualTo(new[] { Floor, Floor, Floor, Floor, JumpedY }).Within(1.0E-9));
    }

    /// <summary>A bottom slab is 0.5 high, which is not more than 0.5, so the step up takes it instead.</summary>
    [Test]
    public void TestAHalfSlabIsNotJumped() {
        (MinecraftClient client, LocalPlayer player) = World((x, y, z) =>
            x == 0 && y == Floor && z == 2 ? (Block.StoneSlab with { Type = SlabType.Bottom }).StateId : 0u);
        List<double> heights = Walk(client, player, 4, true);
        Assert.That(heights, Is.All.LessThanOrEqualTo(Floor + 0.5));
    }

    /// <summary>The two blocks over the head are checked first: one at y 18, above the 1.8 tall player, stops it.</summary>
    [Test]
    public void TestACeilingStopsTheJump() {
        (MinecraftClient client, LocalPlayer player) = World((x, y, z) =>
            Step(x, y, z) != 0 || y == Floor + 2 && z is 0 or 1 ? Block.Stone.StateId : 0u);
        List<double> heights = Walk(client, player, 6, true);
        Assert.That(heights, Is.All.EqualTo(Floor));
    }

    /// <summary>Two blocks high is more than the 1.2 a jump reaches, which the climb from the obstacle up finds.</summary>
    [Test]
    public void TestATwoBlockWallIsNotJumped() {
        (MinecraftClient client, LocalPlayer player) = World((x, y, z) => x == 0 && z == 2 && y is Floor or Floor + 1 ? Block.Stone.StateId : 0u);
        List<double> heights = Walk(client, player, 6, true);
        Assert.That(heights, Is.All.EqualTo(Floor));
    }
}
