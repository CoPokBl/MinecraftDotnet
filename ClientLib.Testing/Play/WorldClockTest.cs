using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;

namespace ClientLib.Testing.Play;

/// <summary>
/// <c>ClientClockManager</c> and the client's <c>TickRateManager</c>, driven by the packets a server
/// sends, against readings worked from <c>ServerClockManager</c>.
/// </summary>
public class WorldClockTest {
    private static int ClockId(string name) => VanillaRegistry.Data.WorldClocks.GetProtocolId(name);

    private static MinecraftClient Client(string dimension = "minecraft:overworld") {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, dimension, VanillaRegistry.Data.DimensionTypes[dimension], 63, true, 0);
        client.StartOffline(level);
        return client;
    }

    private static ClientBoundUpdateTimePacket Time(long gameTime, params ClientBoundUpdateTimePacket.ClockUpdate[] clocks) =>
        new() { GameTime = gameTime, ClockUpdates = clocks };

    private static ClientBoundUpdateTimePacket FullSync(long gameTime, long overworld, long end, float rate = 1.0F) =>
        Time(gameTime, new(ClockId("minecraft:the_end"), end, 0.0F, rate), new(ClockId("minecraft:overworld"), overworld, 0.0F, rate));

    [Test]
    public void TestTheSkyFollowsTheDimensionsOwnClock() {
        MinecraftClient client = Client();
        // After a time set the two clocks differ, and the end's is not the overworld's day.
        client.Dispatch(FullSync(1000, 18000, 1000));
        Assert.That(client.Level!.DefaultClockTime, Is.EqualTo(18000));

        MinecraftClient end = Client("minecraft:the_end");
        end.Dispatch(FullSync(1000, 18000, 1000));
        Assert.That(end.Level!.DefaultClockTime, Is.EqualTo(1000));
    }

    [Test]
    public void TestClocksRunOnTheClientsTicks() {
        MinecraftClient client = Client();
        client.Dispatch(FullSync(1000, 6000, 0));
        for (int i = 0; i < 20; i++) {
            client.Tick();
        }
        Assert.That(client.Level!.GameTime, Is.EqualTo(1020));
        Assert.That(client.Level.DefaultClockTime, Is.EqualTo(6020));
    }

    [Test]
    public void TestASyncWithNoClocksCarriesThemByTheGameTimeThatPassed() {
        MinecraftClient client = Client();
        client.Dispatch(FullSync(1000, 6000, 0));
        // A server at forty ticks a second is forty ahead after a second of the client's twenty.
        for (int i = 0; i < 20; i++) {
            client.Tick();
        }
        client.Dispatch(Time(1040));
        Assert.That(client.Level!.DefaultClockTime, Is.EqualTo(6040));
    }

    [Test]
    public void TestAPausedClockStaysPut() {
        MinecraftClient client = Client();
        client.Dispatch(FullSync(1000, 6000, 0, rate: 0.0F));
        for (int i = 0; i < 20; i++) {
            client.Tick();
        }
        client.Dispatch(Time(1040));
        Assert.That(client.Level!.DefaultClockTime, Is.EqualTo(6000));
        Assert.That(client.Level.GameTime, Is.EqualTo(1040));
    }

    [Test]
    public void TestAFractionalRateCarriesItsRemainder() {
        ClientClockManager clocks = new();
        clocks.HandleUpdates(0, [("minecraft:overworld", 100L, 0.0F, 0.75F)]);
        clocks.Tick(1);
        Assert.That(clocks.GetTotalTicks("minecraft:overworld"), Is.EqualTo(100));
        clocks.Tick(2);
        Assert.That(clocks.GetTotalTicks("minecraft:overworld"), Is.EqualTo(101));
        Assert.That(clocks.GetTicksAt("minecraft:overworld", 0.0F), Is.EqualTo(101.5).Within(1.0E-6));
    }

    [Test]
    public void TestAFrozenServerStopsTimeAndEntitiesButNotThePlayer() {
        MinecraftClient client = Client();
        client.Dispatch(FullSync(1000, 6000, 0));
        ClientEntity arrow = new() { Id = 10, Type = EntityType.Arrow, MovesFreely = true, DeltaMovement = new Vec3d(1, 0, 0) };
        client.Entities[10] = arrow;
        client.Dispatch(new ClientBoundSetTickingStatePacket { TickRate = 20.0F, IsFrozen = true });

        client.Tick();
        client.Tick();
        Assert.That(client.Level!.GameTime, Is.EqualTo(1000));
        Assert.That(client.Level.DefaultClockTime, Is.EqualTo(6000));
        Assert.That(arrow.Position.X, Is.EqualTo(0.0));
        Assert.That(client.Level.TickRateManager.IsEntityFrozen(client.Player!), Is.False);

        client.Dispatch(new ClientBoundStepTickPacket { TickSteps = 1 });
        client.Tick();
        client.Tick();
        Assert.That(client.Level.GameTime, Is.EqualTo(1001));
        Assert.That(arrow.Position.X, Is.EqualTo(1.0));
    }

    [Test]
    public void TestTheClientFollowsOnlyASlowerTickRate() {
        MinecraftClient client = Client();
        client.Dispatch(new ClientBoundSetTickingStatePacket { TickRate = 10.0F, IsFrozen = false });
        client.Tick();
        Assert.That(client.TickTargetMillis(50.0F), Is.EqualTo(100.0F));

        client.Dispatch(new ClientBoundSetTickingStatePacket { TickRate = 40.0F, IsFrozen = false });
        Assert.That(client.TickTargetMillis(50.0F), Is.EqualTo(50.0F));

        client.Dispatch(new ClientBoundSetTickingStatePacket { TickRate = 10.0F, IsFrozen = true });
        client.Tick();
        Assert.That(client.TickTargetMillis(50.0F), Is.EqualTo(50.0F));
    }
}
