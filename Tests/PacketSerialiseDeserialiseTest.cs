using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
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
    }

    private static void SerialiseAndDeserialise(MinecraftPacket packet, bool clientBound, PlayerConnectionState state) {
        MinecraftPacket de = MinecraftPacket.Deserialise(packet.Serialise(), clientBound, state);
        Console.WriteLine(de.GetType().FullName);
        Console.WriteLine(JsonConvert.SerializeObject(de));
    }
}