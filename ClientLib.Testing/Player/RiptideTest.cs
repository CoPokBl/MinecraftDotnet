using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Biomes;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Testing.Player;

/// <summary>
/// <c>TridentItem.releaseUsing</c>'s riptide launch, run on the client as vanilla's is so the server's
/// copy of the move agrees. Riptide's strength is <c>1.5 + 0.75 * (level - 1)</c>, three at level III,
/// pushed along the look vector built from <c>Mth.sin</c>'s table.
/// </summary>
public class RiptideTest {
    private const int Floor = 16;
    private const int PigId = 20;

    private static ItemStack Trident(int riptide) =>
        new ItemStack(Item.Trident, 1).With(DataComponent.Enchantments, [(Enchantment.Riptide, riptide)]);

    /// <param name="water">Layers of water source on the floor, under every column of the world.</param>
    private static (MinecraftClient Client, LocalPlayer Player) World(IBiome biome, int water, ItemStack held,
        Action<ClientLevel>? build = null) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        ushort biomeId = (ushort)level.Registry.Biomes.GetProtocolId(biome);
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = Enumerable.Repeat(biomeId, 64).ToArray();
                    sections[i] = level.MinY + i * 16 < Floor ? new ClientSection((ushort)Block.Stone.StateId, false) : new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        for (int x = -32; x < 48; x++) {
            for (int z = -32; z < 48; z++) {
                for (int y = Floor; y < Floor + water; y++) {
                    level.SetState(x, y, z, (ushort)Block.Water.StateId);
                }
            }
        }
        build?.Invoke(level);

        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        client.Inventory.SetInventorySlot(0, held);
        Tick(client, player, false, 5);
        return (client, player);
    }

    private static void Tick(MinecraftClient client, LocalPlayer player, bool useHeld, int ticks) {
        for (int i = 0; i < ticks; i++) {
            player.Input = PlayerInput.None;
            client.Interactions.Keys.Use.SetDown(useHeld);
            client.Interactions.Tick();
            client.Tick();
        }
    }

    /// <summary>
    /// Holds use for <paramref name="held"/> ticks, then lets go: only the interaction half of the next
    /// tick runs, which is where vanilla's <c>releaseUsingItem</c> sits, before the player's own tick.
    /// </summary>
    private static (Vec3d Push, Vec3d Moved) Release(MinecraftClient client, LocalPlayer player, int held, float yRot, float xRot) {
        player.YRot = yRot;
        player.XRot = xRot;
        Tick(client, player, true, held);
        Vec3d delta = player.DeltaMovement;
        Vec3d position = player.Position;
        client.Interactions.Keys.Use.SetDown(false);
        client.Interactions.Tick();
        return (player.DeltaMovement - delta, player.Position - position);
    }

    private static void AssertVec(Vec3d actual, double x, double y, double z) {
        Assert.That(actual.X, Is.EqualTo(x).Within(1.0E-9), "x");
        Assert.That(actual.Y, Is.EqualTo(y).Within(1.0E-9), "y");
        Assert.That(actual.Z, Is.EqualTo(z).Within(1.0E-9), "z");
    }

    [TestCase(1, 1.5)]
    [TestCase(3, 3.0)]
    public void LaunchesStraightUpInWater(int level, double strength) {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 3, Trident(level));
        (Vec3d push, _) = Release(client, player, 10, 0.0F, -90.0F);
        AssertVec(push, 0.0, strength, 0.0);
        Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(20));
    }

    [Test]
    public void LaunchesForwardInWater() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 3, Trident(3));
        (Vec3d push, _) = Release(client, player, 10, 0.0F, 0.0F);
        AssertVec(push, 0.0, 0.0, 3.0);
    }

    /// <summary>
    /// At 45 degrees up, <c>Mth.cos</c>'s index is -8192.000003 + 16384, which truncates to 8191, one step
    /// short of the sine's, so the launch leans up: (0, 0.70710677, 0.70703906) scaled to length three.
    /// </summary>
    [Test]
    public void LaunchAtFortyFiveDegreesLeansOnTheSineTable() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 3, Trident(3));
        (Vec3d push, _) = Release(client, player, 10, 0.0F, -45.0F);
        AssertVec(push, 0.0, 2.121422052383423, 2.121218681335449);
    }

    /// <summary><c>timeHeld</c> is <c>getUseDuration</c> less the remaining ticks, which must reach ten.</summary>
    [Test]
    public void NineTicksHeldDoNotLaunch() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 3, Trident(3));
        (Vec3d push, _) = Release(client, player, 9, 0.0F, -90.0F);
        AssertVec(push, 0.0, 0.0, 0.0);
        Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(0));
    }

    /// <summary>On the ground the launch also moves the player up 1.1999999F before any tick runs.</summary>
    [Test]
    public void OnGroundAddsTheLift() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 1, Trident(3));
        Assert.That(player.OnGround, Is.True);
        Assert.That(player.IsInWater, Is.True);
        (Vec3d push, Vec3d moved) = Release(client, player, 10, 0.0F, -90.0F);
        AssertVec(push, 0.0, 3.0, 0.0);
        AssertVec(moved, 0.0, 1.1999999284744263, 0.0);
    }

    [Test]
    public void NoUseOrLaunchOutOfWaterAndRain() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 0, Trident(3));
        (Vec3d push, Vec3d moved) = Release(client, player, 20, 0.0F, -90.0F);
        Assert.That(player.IsUsingItem, Is.False);
        AssertVec(push, 0.0, 0.0, 0.0);
        AssertVec(moved, 0.0, 0.0, 0.0);
    }

    /// <summary>A trident without riptide is thrown by the server; the client does not move.</summary>
    [Test]
    public void PlainTridentDoesNotLaunch() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 3, new ItemStack(Item.Trident, 1));
        (Vec3d push, _) = Release(client, player, 20, 0.0F, -90.0F);
        AssertVec(push, 0.0, 0.0, 0.0);
    }

    [Test]
    public void LaunchesInRainUnderOpenSky() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 0, Trident(3));
        client.Level!.RainLevel = 1.0F;
        Assert.That(player.IsInWaterOrRain, Is.True);
        (Vec3d push, Vec3d moved) = Release(client, player, 10, 0.0F, -90.0F);
        AssertVec(push, 0.0, 3.0, 0.0);
        AssertVec(moved, 0.0, 1.1999999284744263, 0.0);
    }

    /// <summary><c>Level.isRaining</c> compares the float rain level to the double 0.2, which 0.2F is above.</summary>
    [TestCase(0.19F, false)]
    [TestCase(0.2F, true)]
    public void RainCountsAboveTwoTenths(float rainLevel, bool raining) {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 0, Trident(3));
        client.Level!.RainLevel = rainLevel;
        Assert.That(player.IsInWaterOrRain, Is.EqualTo(raining));
    }

    /// <summary>The roof is above the <c>MOTION_BLOCKING</c> height of both columns <c>isInRain</c> asks about.</summary>
    [Test]
    public void NoLaunchInRainUnderARoof() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 0, Trident(3),
            level => level.SetState(0, Floor + 3, 0, (ushort)Block.Stone.StateId));
        client.Level!.RainLevel = 1.0F;
        Assert.That(client.Level.GetHeight(Minecraft.Schemas.Chunks.HeightmapType.MotionBlocking, 0, 0), Is.EqualTo(Floor + 4));
        (Vec3d push, _) = Release(client, player, 20, 0.0F, -90.0F);
        Assert.That(player.IsUsingItem, Is.False);
        AssertVec(push, 0.0, 0.0, 0.0);
    }

    /// <summary>Snowy plains is 0.0 degrees, under <c>warmEnoughToRain</c>'s 0.15: it snows, and snow is not rain.</summary>
    [Test]
    public void NoLaunchInSnow() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.SnowyPlains, 0, Trident(3));
        client.Level!.RainLevel = 1.0F;
        Assert.That(client.Level.PrecipitationAt(0, Floor, 0), Is.EqualTo(BiomeClimate.Precipitation.Snow));
        (Vec3d push, _) = Release(client, player, 20, 0.0F, -90.0F);
        AssertVec(push, 0.0, 0.0, 0.0);
    }

    /// <summary>Above sea level plus seventeen the temperature drops 0.05 per 40 blocks, plus the noise, so plains snows high enough.</summary>
    [Test]
    public void PlainsSnowsHighUp() {
        (MinecraftClient client, _) = World(Biome.Plains, 0, Trident(3));
        client.Level!.RainLevel = 1.0F;
        Assert.That(client.Level.PrecipitationAt(0, Floor, 0), Is.EqualTo(BiomeClimate.Precipitation.Rain));
        // 0.8 - (y - 80) * 0.05 / 40 falls under 0.15 at y = 600, past the noise's few blocks either way.
        Assert.That(BiomeClimate.PrecipitationAt(Biome.Plains, 0, 640, 0, 63), Is.EqualTo(BiomeClimate.Precipitation.Snow));
        Assert.That(BiomeClimate.PrecipitationAt(Biome.Plains, 0, 500, 0, 63), Is.EqualTo(BiomeClimate.Precipitation.Rain));
    }

    [Test]
    public void SpinAttackCountsDownFromTwenty() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 3, Trident(3));
        Release(client, player, 10, 0.0F, -90.0F);
        Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(20));
        client.Tick();
        Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(19));
        Tick(client, player, false, 18);
        Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(1));
        Tick(client, player, false, 1);
        Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(0));
    }

    [Test]
    public void SpinAttackEndsAgainstAWall() {
        (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 1, Trident(3), level => {
            for (int x = -2; x <= 2; x++) {
                for (int y = Floor; y < Floor + 5; y++) {
                    level.SetState(x, y, 3, (ushort)Block.Stone.StateId);
                }
            }
        });
        Release(client, player, 10, 0.0F, 0.0F);
        client.Tick();
        Assert.That(player.HorizontalCollision, Is.True);
        Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(0));
    }

    /// <summary>
    /// Touching a living entity ends the spin and sends the player back at a fifth of the speed
    /// <c>travel</c> left it with, which a second world without the pig gives. The pig floats above the
    /// eye line, so the use is not taken by it, and in the box the lift carries the player into.
    /// </summary>
    [Test]
    public void SpinAttackBouncesOffALivingEntity() {
        Vec3d Launch(bool pig) {
            (MinecraftClient client, LocalPlayer player) = World(Biome.Plains, 1, Trident(3));
            if (pig) {
                client.HandleSpawn(new ClientBoundSpawnEntityPacket {
                    Id = PigId,
                    Uuid = Guid.NewGuid(),
                    EntityType = EntityType.Pig,
                    Position = new Vec3<double>(0.5, Floor + 2.0, 2.5),
                    Pitch = Angle.FromDegrees(0),
                    Yaw = Angle.FromDegrees(0),
                    HeadYaw = Angle.FromDegrees(0),
                    Data = 0,
                    Velocity = new Vec3<double>(0, 0, 0)
                });
            }
            Release(client, player, 10, 0.0F, 0.0F);
            client.Tick();
            Assert.That(player.AutoSpinAttackTicks, Is.EqualTo(pig ? 0 : 19));
            return player.DeltaMovement;
        }

        Vec3d free = Launch(false);
        Vec3d bounced = Launch(true);
        Assert.That(free.Z, Is.GreaterThan(1.0));
        AssertVec(bounced, free.X * -0.2, free.Y * -0.2, free.Z * -0.2);
    }
}
