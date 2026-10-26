using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Attributes;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ClientLib.Testing.Player;

/// <summary>
/// The local player's movement against the figures vanilla's own arithmetic settles on. Each one is
/// the fixed point of <c>v = (v + a) * f</c> for the input acceleration <c>a</c> and friction
/// <c>f</c> the vanilla code path computes, which is also the speed the game is known to move at.
/// </summary>
public class LocalPlayerMovementTest {
    private const int Floor = 16;

    private static (MinecraftClient Client, LocalPlayer Player) FlatWorld(Func<int, int, int, uint>? blocks = null) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        ushort stone = (ushort)Block.Stone.StateId;
        for (int cx = -4; cx <= 4; cx++) {
            for (int cz = -4; cz <= 4; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
                    if (blocks == null) {
                        sections[i] = baseY < Floor ? new ClientSection(stone, false) : new ClientSection(0, true);
                        continue;
                    }
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
        // One idle tick lets the first fall of zero settle onto the floor.
        Tick(client, player, PlayerInput.None, 2);
        Assert.That(player.OnGround, Is.True);
        return (client, player);
    }

    private static void Tick(MinecraftClient client, LocalPlayer player, PlayerInput input, int ticks) {
        for (int i = 0; i < ticks; i++) {
            player.Input = input;
            client.Tick();
        }
    }

    private static double StepLength(MinecraftClient client, LocalPlayer player, PlayerInput input) {
        Vec3d before = player.Position;
        Tick(client, player, input, 1);
        return Math.Sqrt((player.Position - before).HorizontalDistanceSqr());
    }

    [Test]
    public void WalkingSettlesAtVanillaSpeed() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        Tick(client, player, new PlayerInput(Forward: true), 60);
        double step = StepLength(client, player, new PlayerInput(Forward: true));
        // a = 0.98 * 0.1, f = 0.6 * 0.91
        Assert.That(step * 20, Is.EqualTo(4.317).Within(0.001));
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
    }

    [Test]
    public void SprintingSettlesAtVanillaSpeed() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        Tick(client, player, new PlayerInput(Forward: true, Sprint: true), 60);
        Assert.That(player.Sprinting, Is.True);
        double step = StepLength(client, player, new PlayerInput(Forward: true, Sprint: true));
        Assert.That(step * 20, Is.EqualTo(5.612).Within(0.001));
    }

    [Test]
    public void SneakingSettlesAtVanillaSpeed() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        Tick(client, player, new PlayerInput(Forward: true, Shift: true), 60);
        Assert.That(player.Pose, Is.EqualTo(EntityPose.Crouching));
        double step = StepLength(client, player, new PlayerInput(Forward: true, Shift: true));
        Assert.That(step * 20, Is.EqualTo(1.295).Within(0.001));
    }

    /// <summary>
    /// <c>modifyInputSpeedForSquareMovement</c> stretches a diagonal to the corner of the unit square,
    /// which it caps at 1, so a diagonal walks at the full input where a straight line walks at 0.98.
    /// </summary>
    [Test]
    public void DiagonalInputReachesTheCornerOfTheSquare() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        Tick(client, player, new PlayerInput(Forward: true, Left: true), 60);
        double step = StepLength(client, player, new PlayerInput(Forward: true, Left: true));
        Assert.That(step * 20, Is.EqualTo(4.317 / 0.98).Within(0.001));
    }

    [Test]
    public void JumpPeaksAtVanillaHeight() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        double peak = 0;
        Tick(client, player, new PlayerInput(Jump: true), 1);
        for (int i = 0; i < 30; i++) {
            peak = Math.Max(peak, player.Position.Y - Floor);
            Tick(client, player, PlayerInput.None, 1);
        }
        Assert.That(peak, Is.EqualTo(1.2522).Within(0.0001));
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
        Assert.That(player.OnGround, Is.True);
    }

    [Test]
    public void SneakingDoesNotWalkOffAnEdge() {
        // A one block wide strip running along z, so walking along +x leaves it.
        (MinecraftClient client, LocalPlayer player) = FlatWorld((x, y, z) => y < Floor && x == 0 ? Block.Stone.StateId : 0u);
        player.YRot = -90.0F;
        Tick(client, player, new PlayerInput(Forward: true, Shift: true), 80);
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
        Assert.That(player.Position.X, Is.LessThan(1.3).And.GreaterThan(1.0));
    }

    /// <summary>
    /// <c>LocalPlayer.aiStep</c> sets <c>crouching</c> from the keys before <c>input.tick()</c> reads this tick's,
    /// so the sneak slowdown starts and ends a tick after the shift key, while the edge back-off, which asks
    /// <c>isShiftKeyDown</c> during the move, follows the key at once.
    /// </summary>
    [Test]
    public void SneakSlowdownLagsTheShiftKeyByATick() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        Tick(client, player, new PlayerInput(Forward: true), 40);
        double walk = (double)0.98F * 0.1F;
        double sneak = (double)(0.98F * 0.3F) * 0.1F;
        Assert.That(Acceleration(client, player, new PlayerInput(Forward: true, Shift: true)), Is.EqualTo(walk).Within(1.0E-9));
        Assert.That(Acceleration(client, player, new PlayerInput(Forward: true, Shift: true)), Is.EqualTo(sneak).Within(1.0E-9));
        Assert.That(Acceleration(client, player, new PlayerInput(Forward: true)), Is.EqualTo(sneak).Within(1.0E-9));
        Assert.That(Acceleration(client, player, new PlayerInput(Forward: true)), Is.EqualTo(walk).Within(1.0E-9));
    }

    /// <summary>What a tick on flat ground adds to the velocity it starts with, the step being both together.</summary>
    private static double Acceleration(MinecraftClient client, LocalPlayer player, PlayerInput input) {
        double velocity = player.DeltaMovement.Z;
        double z = player.Position.Z;
        Tick(client, player, input, 1);
        return player.Position.Z - z - velocity;
    }

    /// <summary>
    /// <c>travelInAir</c> on the client: where no chunk is loaded under the player it sinks at 0.1 a tick instead
    /// of falling. The first tick after the move still asks the chunk under the old supporting block, which
    /// <c>getOnPos</c> keeps until the move clears it.
    /// </summary>
    [Test]
    public void AnUnloadedChunkSinksThePlayerSteadily() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        player.Position = new Vec3d(500.5, Floor, 0.5);
        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.DeltaMovement.Y, Is.EqualTo((-0.0784000015258789 - 0.08) * 0.98F).Within(1.0E-12));
        Tick(client, player, PlayerInput.None, 1);
        Assert.That(player.DeltaMovement.Y, Is.EqualTo(-0.1 * 0.98F).Within(1.0E-12));
        double y = player.Position.Y;
        Tick(client, player, PlayerInput.None, 5);
        Assert.That(player.Position.Y, Is.EqualTo(y - 5 * (0.1 * 0.98F)).Within(1.0E-9));
    }

    [Test]
    public void WalkingOffAnEdgeFalls() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld((x, y, z) => y < Floor && x == 0 ? Block.Stone.StateId : 0u);
        player.YRot = -90.0F;
        Tick(client, player, new PlayerInput(Forward: true), 40);
        Assert.That(player.Position.Y, Is.LessThan(Floor - 1));
    }

    [Test]
    public void StepsUpASlabWithoutJumping() {
        ushort slab = (ushort)Block.StoneSlab.StateId;
        (MinecraftClient client, LocalPlayer player) = FlatWorld((x, y, z) => y < Floor ? Block.Stone.StateId : y == Floor && z >= 3 ? slab : 0u);
        Tick(client, player, new PlayerInput(Forward: true), 40);
        Assert.That(player.Position.Z, Is.GreaterThan(4.0));
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 0.5));
    }

    [Test]
    public void FlyingSettlesAtVanillaSpeed() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld();
        player.MayFly = true;
        player.Flying = true;
        player.Position = player.Position.Add(0, 5, 0);
        player.YRot = 180.0F;
        Tick(client, player, new PlayerInput(Forward: true), 200);
        double step = StepLength(client, player, new PlayerInput(Forward: true));
        // a = 0.98 * 0.05, f = 0.91 in the air
        Assert.That(step * 20, Is.EqualTo(0.98 * 0.05F / (1 - 0.91F) * 20).Within(0.001));
        Assert.That(step * 20, Is.EqualTo(10.89).Within(0.01));
    }

    [Test]
    public void SquareMovementScalesDiagonalsToTheUnitSquare() {
        float d = 0.98F * MathF.Sqrt(0.5F);
        (float x, float y) = LocalPlayer.ModifyInputSpeedForSquareMovement(d, d);
        Assert.That(x, Is.EqualTo(MathF.Sqrt(0.5F)).Within(1e-6));
        Assert.That(y, Is.EqualTo(MathF.Sqrt(0.5F)).Within(1e-6));

        (float sx, float sy) = LocalPlayer.ModifyInputSpeedForSquareMovement(0.0F, 0.98F);
        Assert.That(sx, Is.EqualTo(0.0F));
        Assert.That(sy, Is.EqualTo(0.98F));
    }

    [Test]
    public void AttributeModifiersFoldInVanillaOrder() {
        Entities.AttributeMap map = new(EntityType.Player);
        Entities.AttributeMap.Instance speed = map.GetOrCreate(Attribute.MovementSpeed);
        Assert.That(speed.Value, Is.EqualTo(0.10000000149011612));

        speed.AddModifier(new AttributeModifier("minecraft:sprinting", 0.3F, Minecraft.Schemas.AttributeOperation.AddMultipliedTotal));
        speed.AddModifier(new AttributeModifier("minecraft:effect.speed", 0.2, Minecraft.Schemas.AttributeOperation.AddMultipliedBase));
        speed.AddModifier(new AttributeModifier("test:flat", 0.05, Minecraft.Schemas.AttributeOperation.Add));
        // (0.1 + 0.05) then + 0.15 * 0.2, then * 1.3
        double expected = (0.10000000149011612 + 0.05);
        expected = (expected + expected * 0.2) * (1.0 + 0.3F);
        Assert.That(speed.Value, Is.EqualTo(expected).Within(1e-15));
    }
}
