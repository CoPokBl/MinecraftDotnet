using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Player;

/// <summary>
/// The blocks that move the player from inside them, the pistons that move it from outside, and elytra
/// flight. Each expected figure is vanilla's arithmetic written out: <c>travelInWater</c> keeps 0.8F of the speed
/// and sinks it by gravity / 16, <c>travelInAir</c> takes 0.08 gravity and keeps 0.98F, and the block's
/// <c>entityInside</c> runs after the move.
/// </summary>
public class LocalPlayerMechanicsTest {
    private const int Floor = 16;

    internal static (MinecraftClient Client, LocalPlayer Player) World(Func<int, int, int, uint> blocks, Vec3d start) {
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
        player.Position = start;
        return (client, player);
    }

    /// <summary>A stone floor and a column of bubble column blocks at the origin, the top one at <paramref name="top"/>.</summary>
    private static Func<int, int, int, uint> BubbleColumn(bool drag, int top) => (x, y, z) =>
        y < Floor ? (x == 0 && z == 0 && y == Floor - 1 ? (drag ? Block.MagmaBlock : Block.SoulSand).StateId : Block.Stone.StateId)
        : x == 0 && z == 0 && y <= top ? (Block.BubbleColumn with { Drag = drag }).StateId
        : 0;

    private static List<double> VerticalSpeeds(MinecraftClient client, LocalPlayer player, int ticks) {
        List<double> speeds = [];
        for (int i = 0; i < ticks; i++) {
            client.Tick();
            speeds.Add(player.DeltaMovement.Y);
        }
        return speeds;
    }

    /// <summary>
    /// <c>onInsideBubbleColumn</c> adds 0.06 up to 0.7 for every column block the box is in, after water has
    /// taken its share: two blocks for a box from y + 0 to y + 1.8, three once it reaches past y + 3.
    /// </summary>
    [Test]
    public void AnUpwardColumnLiftsThePlayer() {
        (MinecraftClient client, LocalPlayer player) = World(BubbleColumn(false, Floor + 20), new Vec3d(0.5, Floor + 2, 0.5));
        List<double> speeds = VerticalSpeeds(client, player, 3);
        double first = -0.005 + 0.06 * 2;
        double second = first * 0.8F - 0.005 + 0.06 * 2;
        // The box now ends at Floor + 2 + first + second + 1.8, past Floor + 4.
        double third = second * 0.8F - 0.005 + 0.06 * 3;
        Assert.That(speeds, Is.EqualTo(new[] { first, second, third }).Within(1e-12));
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 2 + first + second).Within(1e-12));
        Assert.That(player.FallDistance, Is.Zero);
    }

    /// <summary>
    /// At the top block, with air above, <c>onAboveBubbleColumn</c> adds 0.1 a tick instead, and once the
    /// box has left the column the player flies on out of the water.
    /// </summary>
    [Test]
    public void TheTopOfAnUpwardColumnThrowsThePlayerOut() {
        int top = Floor + 4;
        (MinecraftClient client, LocalPlayer player) = World(BubbleColumn(false, top), new Vec3d(0.5, top + 0.5, 0.5));
        List<double> speeds = VerticalSpeeds(client, player, 5);
        double v1 = -0.005 + 0.1;
        double v2 = v1 * 0.8F - 0.005 + 0.1;
        double v3 = v2 * 0.8F - 0.005 + 0.1;
        double v4 = v3 * 0.8F - 0.005 + 0.1;
        // Out of the water and past the column: plain gravity.
        double v5 = (v4 - 0.08) * 0.98F;
        Assert.That(speeds, Is.EqualTo(new[] { v1, v2, v3, v4, v5 }).Within(1e-12));
        Assert.That(player.IsInWater, Is.False);
    }

    /// <summary><c>onInsideBubbleColumn</c> drags 0.03 down to 0.3 for every column block the box is in.</summary>
    [Test]
    public void ADownwardColumnSinksThePlayer() {
        (MinecraftClient client, LocalPlayer player) = World(BubbleColumn(true, Floor + 20), new Vec3d(0.5, Floor + 15, 0.5));
        List<double> speeds = VerticalSpeeds(client, player, 2);
        double first = -0.005 - 0.03 * 2;
        // From Floor + 14.935 the box spans three blocks.
        double second = first * 0.8F - 0.005 - 0.03 * 3;
        Assert.That(speeds, Is.EqualTo(new[] { first, second }).Within(1e-12));

        VerticalSpeeds(client, player, 100);
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
    }

    [Test]
    public void AFlyingPlayerIgnoresBubbleColumns() {
        (MinecraftClient client, LocalPlayer player) = World(BubbleColumn(false, Floor + 20), new Vec3d(0.5, Floor + 2, 0.5));
        player.MayFly = true;
        player.Flying = true;
        // Player.travel keeps 0.6 of the speed it started the tick with while flying, which was none.
        client.Tick();
        Assert.That(player.DeltaMovement.Y, Is.Zero);
    }

    /// <summary>
    /// <c>HoneyBlock.doSlideMovement</c> pins the fall at <c>(-0.05 - 0.08) * 0.98F</c> a tick once the
    /// speed it would have had passes 0.08, and resets the fall each tick.
    /// </summary>
    [Test]
    public void SlidingDownAHoneyWall() {
        // The honey's collision box is a sixteenth in from the block, so the player touches it at x = 1 + 1/16 - 0.3.
        double x = 1.0625 - 0.3F;
        (MinecraftClient client, LocalPlayer player) = World(
            (bx, y, z) => y < Floor ? Block.Stone.StateId : bx == 1 && z == 0 && y < Floor + 20 ? Block.HoneyBlock.StateId : 0,
            new Vec3d(x, Floor + 15, 0.5));
        List<double> speeds = VerticalSpeeds(client, player, 3);
        double first = (0.0 - 0.08) * 0.98F;
        double second = (first - 0.08) * 0.98F;
        double slide = (-0.05 - 0.08) * 0.98F;
        Assert.That(speeds, Is.EqualTo(new[] { first, second, slide }).Within(1e-12));

        double before = player.Position.Y;
        client.Tick();
        Assert.That(player.Position.Y - before, Is.EqualTo(slide).Within(1e-12));
        Assert.That(player.DeltaMovement.Y, Is.EqualTo(slide).Within(1e-12));
        Assert.That(player.FallDistance, Is.Zero);
        Assert.That(player.Position.X, Is.EqualTo(x));
    }

    /// <summary>
    /// <c>moveCollidedEntities</c>: an extending head moves the player out of its way by the overlap plus
    /// 0.01 on the first tick, and by the half block it moves plus 0.01 on the second.
    /// </summary>
    [Test]
    public void APistonPushesThePlayerOutOfItsWay() {
        (MinecraftClient client, LocalPlayer player) = World((x, y, z) => y < Floor ? Block.Stone.StateId : 0, new Vec3d(1.5, Floor, 0.5));
        client.Tick();
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, Floor, 0), Block = Block.Piston with { Facing = Cardinal.East } });
        client.Dispatch(new ClientBoundBlockActionPacket {
            Location = new Vec3<int>(0, Floor, 0), Block = Block.Piston, ActionId = 0, ActionParameter = (byte)Cardinal.East
        });

        client.Tick();
        double minX = 1.5 - 0.3F;
        double first = 1.5 - minX + 0.01;
        Assert.That(player.Position.X, Is.EqualTo(1.5 + first).Within(1e-12));
        client.Tick();
        double second = 2.0 - (minX + first) + 0.01;
        Assert.That(player.Position.X, Is.EqualTo(1.5 + first + second).Within(1e-12));
        for (int i = 0; i < 10; i++) {
            client.Tick();
        }
        Assert.That(player.Position.X, Is.EqualTo(1.5 + first + second).Within(1e-12));
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
        Assert.That(player.OnGround, Is.True);
    }

    /// <summary>A slime block pushed up flings what it pushes, and the player rides it up.</summary>
    [Test]
    public void APistonPushedSlimeBlockLaunchesThePlayer() {
        (MinecraftClient client, LocalPlayer player) = World(
            (x, y, z) => y < Floor ? Block.Stone.StateId : x == 0 && z == 0 && y == Floor + 1 ? Block.SlimeBlock.StateId : 0,
            new Vec3d(0.5, Floor + 2, 0.5));
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(0, Floor, 0), Block = Block.Piston with { Facing = Cardinal.Up } });
        client.Tick();
        client.Tick();
        Assert.That(player.OnGround, Is.True);
        client.Dispatch(new ClientBoundBlockActionPacket {
            Location = new Vec3<int>(0, Floor, 0), Block = Block.Piston, ActionId = 0, ActionParameter = (byte)Cardinal.Up
        });
        client.Tick();
        Assert.That(player.DeltaMovement.Y, Is.EqualTo(1.0));
        Assert.That(player.Position.Y, Is.EqualTo(Floor + 2 + 0.51).Within(1e-12));
    }

    /// <summary>
    /// <c>Entity.move</c>'s clip through <c>fall_damage_resetting</c> blocks: a fall that ends in a cobweb
    /// lands having fallen only the last tick's distance.
    /// </summary>
    [Test]
    public void AFallIntoACobwebLandsSoftly() {
        (MinecraftClient client, LocalPlayer player) = World(
            (x, y, z) => y < Floor ? Block.Stone.StateId : x == 0 && z == 0 && y == Floor ? Block.Cobweb.StateId : 0,
            new Vec3d(0.5, Floor + 40, 0.5));
        List<double> landings = [];
        player.FellOn += (_, _, distance) => landings.Add(distance);
        for (int i = 0; i < 60; i++) {
            client.Tick();
        }
        Assert.That(player.Position.Y, Is.EqualTo(Floor));
        Assert.That(landings, Has.Count.EqualTo(1));
        Assert.That(landings[0], Is.LessThan(3.0));
        Assert.That(player.FallDistance, Is.Zero);
    }

    /// <summary>
    /// A cobweb the player falls straight through in one tick still catches it, as the blocks along the
    /// move are visited and not only the ones it ends in.
    /// </summary>
    [Test]
    public void AFastFallThroughACobwebIsCaught() {
        int web = Floor + 10;
        (MinecraftClient client, LocalPlayer player) = World(
            (x, y, z) => y < Floor ? Block.Stone.StateId : x == 0 && z == 0 && y == web ? Block.Cobweb.StateId : 0,
            new Vec3d(0.5, Floor + 60, 0.5));
        while (player.Position.Y >= web + 1) {
            client.Tick();
        }
        // The tick that went into the web ended with the fall reset and the player stuck.
        Assert.That(player.FallDistance, Is.Zero);
        // makeStuckInBlock zeroes the speed on the next move, which it scales by 0.05.
        double stuckFrom = player.Position.Y;
        client.Tick();
        Assert.That(player.DeltaMovement.Y, Is.EqualTo(-0.08 * 0.98F).Within(1e-12));
        Assert.That(player.Position.Y, Is.LessThan(stuckFrom).And.GreaterThan(stuckFrom - 0.2));
    }

    /// <summary><c>SlimeBlock.stepOn</c>: walking on slime keeps 0.4 of the speed each tick.</summary>
    [Test]
    public void WalkingOnSlimeIsSlow() {
        (MinecraftClient client, LocalPlayer player) = World((x, y, z) => y < Floor - 1 ? Block.Stone.StateId : y == Floor - 1 ? Block.SlimeBlock.StateId : 0,
            new Vec3d(0.5, Floor, 0.5));
        for (int i = 0; i < 60; i++) {
            player.Input = new PlayerInput(Forward: true);
            client.Tick();
        }
        double before = player.Position.Z;
        player.Input = new PlayerInput(Forward: true);
        client.Tick();
        // Each tick moves d = v + a and keeps v = d * 0.8F * 0.91F * (0.4 + 0.2 |dy|), dy being the
        // -0.08 * 0.98F a grounded player's speed ends every travelInAir on.
        float speed = 0.1F * (0.21600002F / (0.8F * 0.8F * 0.8F));
        double a = 0.98F * (double)speed;
        double k = 0.8F * 0.91F * (0.4 + Math.Abs(-0.08 * 0.98F) * 0.2);
        Assert.That(player.Position.Z - before, Is.EqualTo(a / (1 - k)).Within(1e-6));
    }

    /// <summary>
    /// A fresh jump in the air with an elytra on starts a glide the same tick, which
    /// <c>updateFallFlyingMovement</c> then steers: looking level, lift takes a quarter of gravity and a
    /// tenth of the fall turns forward.
    /// </summary>
    [Test]
    public void JumpingInTheAirWithAnElytraGlides() {
        (MinecraftClient client, LocalPlayer player) = World((x, y, z) => y < Floor ? Block.Stone.StateId : 0, new Vec3d(0.5, Floor + 30, 0.5));
        client.Inventory.SetInventorySlot(38, new ItemStack(Item.Elytra, 1));
        List<string> sent = [];
        client.PacketSent += packet => {
            if (packet is ServerBoundPlayerCommandPacket command) {
                sent.Add(command.PlayAction.ToString());
            }
        };
        client.Tick();
        client.Tick();
        double falling = player.DeltaMovement.Y;
        player.Input = new PlayerInput(Jump: true);
        client.Tick();

        Assert.That(player.IsFallFlying, Is.True);
        Assert.That(sent, Is.EqualTo(new[] { nameof(PlayerAction.StartElytraFlight) }));
        Assert.That(player.Pose, Is.EqualTo(EntityPose.FallFlying));
        double y = falling + 0.08 * (-1.0 + 1.0 * 0.75);
        double convert = y * -0.1 * 1.0;
        double z = convert + (0.0 - convert) * 0.1;
        Assert.That(player.DeltaMovement.Y, Is.EqualTo((y + convert) * 0.98F).Within(1e-12));
        Assert.That(player.DeltaMovement.Z, Is.EqualTo(z * 0.99F).Within(1e-12));
        Assert.That(player.DeltaMovement.X, Is.Zero);
    }

    /// <summary>
    /// <c>FireworkRocketEntity.tick</c>: a rocket attached to a gliding player pulls its speed halfway to
    /// one and a half times the look vector, plus a tenth of it, after the player's own tick.
    /// </summary>
    [Test]
    public void AnAttachedRocketBoostsAGlide() {
        Vec3d Glide(bool rocket) {
            (MinecraftClient client, LocalPlayer player) = World((x, y, z) => y < Floor ? Block.Stone.StateId : 0, new Vec3d(0.5, Floor + 30, 0.5));
            client.Inventory.SetInventorySlot(38, new ItemStack(Item.Elytra, 1));
            client.Tick();
            client.Tick();
            player.Input = new PlayerInput(Jump: true);
            client.Tick();
            if (rocket) {
                ClientEntity firework = new() { Id = 500, Type = EntityType.FireworkRocket };
                firework.Metadata[EntityDataFields.FireworkRocketEntity.AttachedToTarget.Index] =
                    new MetaField<Optional<int>>(MetaFieldType.OptionalVarInt, new Optional<int>(true, player.Id));
                client.Entities[500] = firework;
            }
            client.Tick();
            return player.DeltaMovement;
        }

        Vec3d plain = Glide(false);
        Vec3d boosted = Glide(true);
        // Looking level along +z, the look vector is (0, 0, 1).
        Assert.That(boosted.X, Is.EqualTo(plain.X + (0.0 - plain.X) * 0.5).Within(1e-12));
        Assert.That(boosted.Y, Is.EqualTo(plain.Y + (0.0 - plain.Y) * 0.5).Within(1e-12));
        Assert.That(boosted.Z, Is.EqualTo(plain.Z + 0.1 + (1.5 - plain.Z) * 0.5).Within(1e-12));
    }
}
