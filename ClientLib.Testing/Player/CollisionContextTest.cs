using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Player;

/// <summary>
/// The shapes <c>EntityCollisionContext</c> gives powder snow and scaffolding for the player, and the
/// world border <c>Entity.collide</c> adds, against where vanilla's arithmetic leaves the player.
/// </summary>
public class CollisionContextTest {
    private const int Top = 16;

    private static (MinecraftClient Client, LocalPlayer Player) World(Func<int, int, int, uint> blocks, Vec3d start) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
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

    /// <summary>Stone up to <c>Top - 1</c>, then a layer of <paramref name="layer"/> whose top is <see cref="Top"/>.</summary>
    private static (MinecraftClient Client, LocalPlayer Player) OnLayer(uint layer, double startY = Top) =>
        World((_, y, _) => y < Top - 1 ? Block.Stone.StateId : y == Top - 1 ? layer : 0u, new Vec3d(0.5, startY, 0.5));

    private static void Tick(MinecraftClient client, LocalPlayer player, PlayerInput input, int ticks) {
        for (int i = 0; i < ticks; i++) {
            player.Input = input;
            client.Tick();
        }
    }

    private static void WearLeatherBoots(MinecraftClient client) => client.Inventory.SetInventorySlot(36, new ItemStack(Item.LeatherBoots, 1));

    [Test]
    public void LeatherBootsStandOnPowderSnow() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.PowderSnow.StateId);
        WearLeatherBoots(client);
        Tick(client, player, PlayerInput.None, 20);
        Assert.That(player.Position.Y, Is.EqualTo(Top));
        Assert.That(player.OnGround, Is.True);

        Tick(client, player, new PlayerInput(Forward: true), 20);
        Assert.That(player.Position.Y, Is.EqualTo(Top));
    }

    [Test]
    public void WithoutBootsPowderSnowSinks() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.PowderSnow.StateId);
        Tick(client, player, PlayerInput.None, 40);
        Assert.That(player.Position.Y, Is.EqualTo(Top - 1));
    }

    /// <summary><c>isDescending</c> takes the shape away even in boots, and the boots then climb back out.</summary>
    [Test]
    public void SneakingSinksIntoPowderSnowAndBootsClimbOut() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.PowderSnow.StateId);
        WearLeatherBoots(client);
        Tick(client, player, PlayerInput.None, 2);
        Tick(client, player, new PlayerInput(Shift: true), 40);
        Assert.That(player.Position.Y, Is.EqualTo(Top - 1));

        Tick(client, player, new PlayerInput(Jump: true), 20);
        Assert.That(player.Position.Y, Is.GreaterThanOrEqualTo(Top));
    }

    /// <summary>
    /// <c>handleRelativeFrictionAndCalculateMovement</c> climbs on <c>wasInPowderSnow</c>, which the swept
    /// <c>checkInsideBlocks</c> sets from where the tick's move started. So the tick that carries the feet out of
    /// the snow still counts as in it, and boots climb once more after it: 0.1176 = (0.2 - 0.08) * 0.98F twice,
    /// then 0.036848 = (0.1176 - 0.08) * 0.98F.
    /// </summary>
    [Test]
    public void BootsClimbOneTickPastTheSnowsSurface() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.PowderSnow.StateId);
        WearLeatherBoots(client);
        Tick(client, player, PlayerInput.None, 2);
        Tick(client, player, new PlayerInput(Shift: true), 40);
        Assert.That(player.Position.Y, Is.EqualTo(Top - 1));

        double climb = (0.2 - 0.08) * 0.98F;
        for (int i = 0; i < 20 && player.Position.Y <= Top; i++) {
            Tick(client, player, new PlayerInput(Jump: true), 1);
        }
        Assert.That(player.Position.Y, Is.GreaterThan(Top));
        double before = player.Position.Y;
        Tick(client, player, new PlayerInput(Jump: true), 1);
        Assert.That(player.Position.Y - before, Is.EqualTo(climb).Within(1.0E-9));
        Assert.That(player.DeltaMovement.Y, Is.EqualTo(climb).Within(1.0E-9));
        Tick(client, player, new PlayerInput(Jump: true), 1);
        Assert.That(player.DeltaMovement.Y, Is.EqualTo((climb - 0.08) * 0.98F).Within(1.0E-9));
    }

    /// <summary>Past 2.5 blocks of fall the snow catches the player on a 0.9 high shape, and the landing that ends the fall drops them in.</summary>
    [Test]
    public void FallingOntoPowderSnowLandsOnTheFallingShape() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.PowderSnow.StateId, Top + 5);
        bool caught = false;
        for (int i = 0; i < 60; i++) {
            Tick(client, player, PlayerInput.None, 1);
            if (player.OnGround && Math.Abs(player.Position.Y - (Top - 1 + (double)0.9F)) < 1.0E-9) {
                caught = true;
            }
        }
        Assert.That(caught, Is.True);
        Assert.That(player.Position.Y, Is.EqualTo(Top - 1));
    }

    [Test]
    public void ShortFallIntoPowderSnowIsNotCaught() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.PowderSnow.StateId, Top + 2);
        for (int i = 0; i < 40; i++) {
            Tick(client, player, PlayerInput.None, 1);
            Assert.That(player.OnGround && player.Position.Y > Top - 1, Is.False);
        }
    }

    [Test]
    public void ScaffoldingHoldsUntilSneaking() {
        uint scaffolding = (Block.Scaffolding with { Distance = 0, Bottom = false }).StateId;
        (MinecraftClient client, LocalPlayer player) = OnLayer(scaffolding);
        Tick(client, player, PlayerInput.None, 20);
        Assert.That(player.Position.Y, Is.EqualTo(Top));
        Assert.That(player.OnGround, Is.True);

        Tick(client, player, new PlayerInput(Shift: true), 40);
        Assert.That(player.Position.Y, Is.EqualTo(Top - 1));
    }

    /// <summary>An unsupported bottom scaffolding keeps <c>SHAPE_UNSTABLE_BOTTOM</c> under an entity inside it.</summary>
    [Test]
    public void UnstableScaffoldingKeepsItsBottomSlab() {
        uint scaffolding = (Block.Scaffolding with { Distance = 1, Bottom = true }).StateId;
        (MinecraftClient client, LocalPlayer player) = World(
            (_, y, _) => y < Top - 3 ? Block.Stone.StateId : y == Top - 1 ? scaffolding : 0u, new Vec3d(0.5, Top - 0.5, 0.5));
        Tick(client, player, PlayerInput.None, 20);
        Assert.That(player.Position.Y, Is.EqualTo(Top - 1 + 0.125).Within(1.0E-9));
        Assert.That(player.OnGround, Is.True);
    }

    private static void SetBorder(MinecraftClient client, double size, long lerpTicks = 0, double oldSize = 0) {
        client.Dispatch(new ClientBoundInitialiseWorldBorderPacket {
            X = 0, Z = 0, OldDiameter = lerpTicks > 0 ? oldSize : size, NewDiameter = size, Speed = lerpTicks,
            PortalTeleportBoundary = 29999984, WarningBlocks = 5, WarningTime = 15
        });
    }

    [Test]
    public void WalkingIntoTheWorldBorderStopsAtIt() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.Stone.StateId);
        SetBorder(client, 10);
        player.YRot = -90.0F;
        Tick(client, player, new PlayerInput(Forward: true, Sprint: true), 60);
        Assert.That(player.BoundingBox.MaxX, Is.EqualTo(5.0).Within(1.0E-9));
        Assert.That(player.Position.Y, Is.EqualTo(Top));
    }

    /// <summary>
    /// <c>MovingBorderExtent</c>: the size moves linearly, the bounds trail it by a tick, and the
    /// collision shape rounds the bounds out to whole blocks.
    /// </summary>
    [Test]
    public void ShrinkingBorderMovesEachTick() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.Stone.StateId);
        SetBorder(client, 10, 20, 20);
        WorldBorder border = client.Level!.WorldBorder;
        Assert.That(border.Size, Is.EqualTo(20));

        Tick(client, player, PlayerInput.None, 10);
        Assert.That(border.Size, Is.EqualTo(15));
        Assert.That(border.MaxX, Is.EqualTo(7.75));

        player.YRot = -90.0F;
        Tick(client, player, new PlayerInput(Forward: true), 10);
        Assert.That(border.Size, Is.EqualTo(10));
        Assert.That(border.MaxX, Is.EqualTo(5));
        Tick(client, player, new PlayerInput(Forward: true), 40);
        Assert.That(player.BoundingBox.MaxX, Is.EqualTo(5.0).Within(1.0E-9));
    }

    /// <summary>A border that has shrunk past the player leaves it outside, where it no longer collides.</summary>
    [Test]
    public void BorderDoesNotHoldAPlayerOutsideIt() {
        (MinecraftClient client, LocalPlayer player) = OnLayer(Block.Stone.StateId);
        player.Position = new Vec3d(8.5, Top, 0.5);
        SetBorder(client, 10);
        player.YRot = -90.0F;
        Tick(client, player, new PlayerInput(Forward: true), 20);
        Assert.That(player.Position.X, Is.GreaterThan(9.5));
    }
}
