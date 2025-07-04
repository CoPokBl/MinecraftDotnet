using System.Diagnostics;
using Minecraft.Packets;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Newtonsoft.Json;

namespace Tests;

public class PacketSerialiseDeserialiseTest {

    [Test]
    public void TestPackets() {
        ClientBoundStatusResponsePacket statusResponse = new() {
            VersionName = "Potato",
            VersionProtocol = 69,
            MaxPlayers = 5,
            OnlinePlayers = 1,
            SamplePlayers = [new SamplePlayer("CopokBl", "a")],
            Description = "Welcome to my server!",
            PreventsChatReports = true
        };
        
        SerialiseAndDeserialise(statusResponse, true, ConnectionState.Status);

        ClientBoundLoginPacket login = new() {
            DimensionName = "hell",
            Dimensions = ["hell", "overworld"],
            DimensionType = 1,
            DoLimitedCrafting = false,
            EnableRespawnScreen = false,
            EnforcesSecureChat = false,
            EntityId = 69,
            GameMode = GameMode.Creative,
            HashedSeed = 0,
            IsDebug = false,
            IsFlat = false,
            IsHardcore = false,
            SeaLevel = 8,
            PortalCooldown = 14,
            PreviousGameMode = GameMode.Spectator,
            ReducedDebugInfo = false,
            SimulationDistance = 5,
            ViewDistance = 6,
            MaxPlayers = 1
        };
        SerialiseAndDeserialise(login, true, ConnectionState.Play);
        
        ClientBoundLoginPacket login2 = new() {
            DimensionName = "minecraft:overworld",
            Dimensions = [],
            DimensionType = 3,
            DoLimitedCrafting = false,
            EnableRespawnScreen = true,
            EnforcesSecureChat = true,
            EntityId = 2,
            GameMode = GameMode.Adventure,
            HashedSeed = 0,
            IsDebug = false,
            IsFlat = true,
            IsHardcore = false,
            SeaLevel = 63,
            PortalCooldown = 0,
            PreviousGameMode = GameMode.Undefined,
            ReducedDebugInfo = false,
            SimulationDistance = 8,
            ViewDistance = 8,
            MaxPlayers = 0
        };
        SerialiseAndDeserialise(login2, true, ConnectionState.Play);

        ServerBoundChatMessagePacket cm = new() {
            Acknowledged = [0, 0, 0],
            Checksum = 1,
            Message = "Hello, world!",
            MessageCount = 1,
            Salt = 1,
            Signature = new byte[256],
            Timestamp = 5L
        };
        SerialiseAndDeserialise(cm, false, ConnectionState.Play);

        MinecraftPacket upi = new ClientBoundPlayerInfoUpdatePacket {
            Data = new ClientBoundPlayerInfoUpdatePacket.PlayerData(
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.AddPlayer,
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.InitializeChat,
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateLatency,
                    ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListed)
                .WithPlayer(Guid.NewGuid(), new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                    Name = "Potato Man",
                    Properties = []
                }, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateLatency {
                    Latency = 5
                }, new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateListed {
                    Listed = false
                }, new ClientBoundPlayerInfoUpdatePacket.PlayerData.InitializeChat {
                    ChatSessionId = Guid.NewGuid(),
                    EncodedPublicKey = [0,0,0,0,0,0],
                    HasData = true,
                    PublicKeyExpiryTime = 100L,
                    PublicKeySignature = [0,0,01,0,05,9]
                })
        };
        SerialiseAndDeserialise(upi, true, ConnectionState.Play);

        SerialiseAndDeserialise(new ServerBoundLoginStartPacket {
            Uuid = Guid.NewGuid(),
            Name = "TestPlayer"
        }, false, ConnectionState.Login);

        ChunkData cd = new();
        cd.SetBlock(10, 100, 10, 10);
        cd.SetBlock(1, 2, 3, 11);
        cd.SetBlock(7, 53, 2, 5);
        ClientBoundChunkDataAndUpdateLightPacket chunk = new() {
            ChunkX = 0,
            ChunkZ = 0,
            Data = cd,
            Light = LightData.FullBright
        };
        ClientBoundChunkDataAndUpdateLightPacket chunkDe = SerialiseAndDeserialise(chunk, true, ConnectionState.Play);
        Assert.That(chunkDe.Data.GetBlock(10, 100, 10), Is.EqualTo(10));
        Assert.That(chunkDe.Data.GetBlock(1, 2, 3), Is.EqualTo(11));
        Assert.That(chunkDe.Data.GetBlock(7, 53, 2), Is.EqualTo(5));
        Assert.That(chunkDe.Data.GetBlock(2, 7, 3), Is.EqualTo(0));

        ClientBoundPlayerInfoUpdatePacket badPacket = new() {
            Data = null!
        };
        Assert.Throws<NotImplementedException>(() => SerialiseAndDeserialise(badPacket, false, ConnectionState.Configuration));

        UnknownPacket up = new() {
            Id = 123,
            Data = [1, 2, 3, 4, 5]
        };
        UnknownPacket upDe = SerialiseAndDeserialise(up, true, ConnectionState.Play);
        Assert.That(upDe.Id, Is.EqualTo(123));
    }

    private static T SerialiseAndDeserialise<T>(T packet, bool clientBound, ConnectionState state) where T : MinecraftPacket {
        MinecraftPacket de = MinecraftPacket.Deserialise(packet.Serialise(state, 10), clientBound, state, true);
        Console.WriteLine(de.GetType().FullName);
        Console.WriteLine(JsonConvert.SerializeObject(de));
        if (de is T t) return t;
        Assert.Fail();
        return null;
    }

    [Test]
    public void TestSerialiseSpeed() {
        const int tests = 1_000;
        ChunkData cd = new();
        cd.FillRandom();
        ClientBoundChunkDataAndUpdateLightPacket packet = new() {
            ChunkX = 0,
            ChunkZ = 0,
            Data = cd,
            Light = LightData.FullBright
        };
        
        int[] times = new int[tests];
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < tests; i++) {
            sw.Restart();
            packet.Serialise(ConnectionState.Play, 10);
            times[i] = (int)sw.ElapsedMilliseconds;
        }
        Console.WriteLine($"Serialise speed: average: {times.Average()}ms");
    }
    
    [Test]
    public void TestDeSerialiseSpeed() {
        ClientBoundStatusResponsePacket statusResponse = new() {
            VersionName = "Potato",
            VersionProtocol = 69,
            MaxPlayers = 5,
            OnlinePlayers = 1,
            SamplePlayers = [new SamplePlayer("CopokBl", "a")],
            Description = "Welcome to my server!",
            PreventsChatReports = true
        };
        
        byte[] dat = statusResponse.Serialise(ConnectionState.Status);
        
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 20_000; i++) {
            MinecraftPacket.Deserialise(dat, true, ConnectionState.Status, true);
        }
        Console.WriteLine($"Serialise: {sw.ElapsedMilliseconds}ms");
    }
}