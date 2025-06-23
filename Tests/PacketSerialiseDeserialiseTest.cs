using System.Diagnostics;
using Minecraft.Packets;
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
        ClientBoundStatusResponsePacket statusResponse = new(
            "Potato",
            69,
            5,
            1,
            [new SamplePlayer("CopokBl", "a")],
            "Welcome to my server!", preventsChatReports: true);
        
        SerialiseAndDeserialise(statusResponse, true, PlayerConnectionState.Status);

        ClientBoundLoginPacket login = new();
        SerialiseAndDeserialise(login, true, PlayerConnectionState.Play);

        ServerBoundChatMessagePacket cm = new();
        SerialiseAndDeserialise(cm, false, PlayerConnectionState.Play);

        MinecraftPacket upi = new ClientBoundPlayerInfoUpdatePacket(
            new ClientBoundPlayerInfoUpdatePacket.PlayerData(
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
                }));
        SerialiseAndDeserialise(upi, true, PlayerConnectionState.Play);

        ChunkData cd = new();
        cd.SetBlock(10, 100, 10, 10);
        cd.SetBlock(1, 2, 3, 11);
        cd.SetBlock(7, 53, 2, 5);
        ClientBoundChunkDataAndUpdateLightPacket chunk = new(0, 0, cd, LightData.FullBright);
        ClientBoundChunkDataAndUpdateLightPacket chunkDe = SerialiseAndDeserialise(chunk, true, PlayerConnectionState.Play);
        Assert.That(chunkDe.Data.GetBlock(10, 100, 10), Is.EqualTo(10));
        Assert.That(chunkDe.Data.GetBlock(1, 2, 3), Is.EqualTo(11));
        Assert.That(chunkDe.Data.GetBlock(7, 53, 2), Is.EqualTo(5));
        Assert.That(chunkDe.Data.GetBlock(2, 7, 3), Is.EqualTo(0));
    }

    private static T SerialiseAndDeserialise<T>(T packet, bool clientBound, PlayerConnectionState state) where T : MinecraftPacket {
        MinecraftPacket de = MinecraftPacket.Deserialise(packet.Serialise(), clientBound, state);
        Console.WriteLine(de.GetType().FullName);
        Console.WriteLine(JsonConvert.SerializeObject(de));
        if (de is T t) return t;
        Assert.Fail();
        return null;
    }

    [Test]
    public void TestSerialiseSpeed() {
        ClientBoundStatusResponsePacket statusResponse = new(
            "Potato",
            69,
            5,
            1,
            [new SamplePlayer("CopokBl", "a")],
            "Welcome to my server!", preventsChatReports: true);
        
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 20_000; i++) {
            statusResponse.Serialise(true);
        }
        Console.WriteLine($"Serialise: {sw.ElapsedMilliseconds}ms");
    }
    
    [Test]
    public void TestDeSerialiseSpeed() {
        ClientBoundStatusResponsePacket statusResponse = new(
            "Potato",
            69,
            5,
            1,
            [new SamplePlayer("CopokBl", "a")],
            "Welcome to my server!", preventsChatReports: true);
        byte[] dat = statusResponse.Serialise(true);
        
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 20_000; i++) {
            MinecraftPacket.Deserialise(dat, true, PlayerConnectionState.Status, true);
        }
        Console.WriteLine($"Serialise: {sw.ElapsedMilliseconds}ms");
    }
}