using ClientLib.Stats;
using ClientLib.World;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ClientLib.Testing.Play;

/// <summary>
/// <c>handleAwardStats</c> into the <c>StatsCounter</c> a login makes and a respawn keeps, the request
/// <c>StatsScreen.init</c> sends, and <c>StatFormatter</c>'s text.
/// </summary>
public class StatsTest {
    private static (MinecraftClient Client, List<MinecraftPacket> Sent) Joined() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        client.StartOffline(new ClientLevel(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0));
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, sent);
    }

    private static Stat Jumps => Stat.Custom(CustomStatistic.Jump, VanillaRegistry.Data);

    private static Stat MinedStone => new(StatisticType.Mined, VanillaRegistry.Data.Blocks.GetProtocolId(Block.Stone));

    private static ClientBoundAwardStatisticsPacket Award(params (Stat Stat, int Value)[] stats) => new() {
        Statistics = stats.Select(s => new ClientBoundAwardStatisticsPacket.Entry(s.Stat.Type, s.Stat.Value, s.Value)).ToArray()
    };

    [Test]
    public void TestTheRequestIsClientCommandOne() {
        (MinecraftClient client, List<MinecraftPacket> sent) = Joined();
        client.RequestStats();
        ServerBoundClientStatusPacket request = sent.OfType<ServerBoundClientStatusPacket>().Single();
        // Length, packet id, then ServerboundClientCommandPacket.Action.REQUEST_STATS's ordinal.
        byte[] wire = request.Serialise(ConnectionState.Play);
        Assert.That(wire[^1], Is.EqualTo(1));
        Assert.That(wire, Has.Length.EqualTo(3));
    }

    [Test]
    public void TestTheAwardCodecIsTypeThenValueThenCount() {
        // ClientboundAwardStatsPacket: a map of Stat.STREAM_CODEC, which dispatches on the stat type's id and reads
        // the value through that type's registry, to a var int.
        DataWriter writer = new DataWriter().WriteVarInt(2)
            .WriteVarInt(VanillaRegistry.Data.StatisticTypes.GetProtocolId(StatisticType.Custom)).WriteVarInt(Jumps.Value).WriteVarInt(300)
            .WriteVarInt(VanillaRegistry.Data.StatisticTypes.GetProtocolId(StatisticType.Mined)).WriteVarInt(MinedStone.Value).WriteVarInt(7);
        DataReader reader = new(writer.ToArray());
        ClientBoundAwardStatisticsPacket packet = (ClientBoundAwardStatisticsPacket)ClientBoundAwardStatisticsPacket.Deserialiser(reader, VanillaRegistry.Data);
        Assert.That(reader.HasRemaining, Is.False);
        (MinecraftClient client, _) = Joined();
        client.Dispatch(packet);
        Assert.That(client.Stats.GetValue(Jumps), Is.EqualTo(300));
        Assert.That(client.Stats.GetValue(MinedStone), Is.EqualTo(7));
    }

    [Test]
    public void TestAValueReplacesTheOneHeldAndAnUnsentStatReadsZero() {
        (MinecraftClient client, _) = Joined();
        client.Dispatch(Award((Jumps, 10), (MinedStone, 4)));
        int updates = client.StatsUpdates;
        client.Dispatch(Award((Jumps, 3)));
        Assert.That(client.Stats.GetValue(Jumps), Is.EqualTo(3));
        Assert.That(client.Stats.GetValue(MinedStone), Is.EqualTo(4));
        Assert.That(client.Stats.GetValue(new Stat(StatisticType.Mined, VanillaRegistry.Data.Blocks.GetProtocolId(Block.Dirt))), Is.Zero);
        Assert.That(client.StatsUpdates, Is.EqualTo(updates + 1));
    }

    [Test]
    public void TestARespawnKeepsTheCounterAndALoginReplacesIt() {
        (MinecraftClient client, _) = Joined();
        client.Dispatch(Award((Jumps, 10)));
        client.Dispatch(new ClientBoundRespawnPacket {
            DimensionType = VanillaRegistry.Data.DimensionTypes.GetProtocolId("minecraft:overworld"), DimensionName = "minecraft:overworld",
            HashedSeed = 0, GameMode = GameMode.Survival, PreviousGameMode = GameMode.Undefined, IsDebug = false, IsFlat = true,
            PortalCooldown = 0, SeaLevel = 63, DataKept = 0
        });
        Assert.That(client.Stats.GetValue(Jumps), Is.EqualTo(10));
        client.Dispatch(new ClientBoundLoginPacket {
            EntityId = 1, IsHardcore = false, Dimensions = ["minecraft:overworld"], MaxPlayers = 20, ViewDistance = 8, SimulationDistance = 8,
            ReducedDebugInfo = false, EnableRespawnScreen = true, DoLimitedCrafting = false,
            DimensionType = VanillaRegistry.Data.DimensionTypes.GetProtocolId("minecraft:overworld"), DimensionName = "minecraft:overworld",
            HashedSeed = 0, GameMode = GameMode.Survival, PreviousGameMode = GameMode.Undefined, IsDebug = false, IsFlat = true,
            PortalCooldown = 0, SeaLevel = 63, EnforcesSecureChat = false
        });
        Assert.That(client.Stats.GetValue(Jumps), Is.Zero);
    }

    [TestCase(0, "0 cm")]
    [TestCase(50, "50 cm")]
    [TestCase(51, "0.51 m")]
    [TestCase(50000, "500.00 m")]
    [TestCase(50001, "0.50 km")]
    // 1.125 km is an exact tie, which DecimalFormat's HALF_EVEN takes down to the even digit.
    [TestCase(112500, "1.12 km")]
    [TestCase(137500, "1.38 km")]
    public void TestDistance(int cm, string expected) => Assert.That(StatFormatter.Distance(cm), Is.EqualTo(expected));

    [TestCase(0, "0.0 s")]
    [TestCase(1, "0.05 s")]
    [TestCase(3, "0.15 s")]
    [TestCase(20, "1.0 s")]
    // Half a minute is not more than half, so it stays in seconds.
    [TestCase(600, "30.0 s")]
    [TestCase(601, "0.50 min")]
    [TestCase(72000, "1.00 h")]
    [TestCase(1728000, "1.00 d")]
    [TestCase(int.MaxValue, "3.40 y")]
    public void TestTime(int ticks, string expected) => Assert.That(StatFormatter.Time(ticks), Is.EqualTo(expected));

    [Test]
    public void TestPlainAndTenths() {
        Assert.That(StatFormatter.Default(1234567), Is.EqualTo("1,234,567"));
        Assert.That(StatFormatter.Default(-1234), Is.EqualTo("-1,234"));
        Assert.That(StatFormatter.DivideByTen(15), Is.EqualTo("1.50"));
        Assert.That(StatFormatter.DivideByTen(3), Is.EqualTo("0.30"));
    }

    [Test]
    public void TestOnlyCustomStatsHaveTheirOwnFormatter() {
        Assert.That(StatFormatter.Format(Stat.Custom(CustomStatistic.WalkOneCm, VanillaRegistry.Data), 150, VanillaRegistry.Data), Is.EqualTo("1.50 m"));
        Assert.That(StatFormatter.Format(Stat.Custom(CustomStatistic.PlayTime, VanillaRegistry.Data), 20, VanillaRegistry.Data), Is.EqualTo("1.0 s"));
        Assert.That(StatFormatter.Format(Stat.Custom(CustomStatistic.DamageTaken, VanillaRegistry.Data), 25, VanillaRegistry.Data), Is.EqualTo("2.50"));
        Assert.That(StatFormatter.Format(Jumps, 1500, VanillaRegistry.Data), Is.EqualTo("1,500"));
        Assert.That(StatFormatter.Format(MinedStone, 1500, VanillaRegistry.Data), Is.EqualTo("1,500"));
    }
}
