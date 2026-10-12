using ClientLib;
using Minecraft.Data.Blocks;

namespace TestClient;

public class TestBot {

    public static async Task Start() {
        MinecraftClient client = new(new ClientOptions { Username = "potato" });
        client.Log += Console.WriteLine;
        await client.Connect("localhost", 25565);

        // Packets are handled and ticks run on this thread, as a game loop would.
        bool reported = false;
        while (client.Phase != ClientPhase.Disconnected) {
            client.ProcessPackets();
            client.Tick();

            if (!reported && client.ClientLoaded && client.Player != null && client.Level != null) {
                reported = true;
                int x = (int)Math.Floor(client.Player.Position.X);
                int z = (int)Math.Floor(client.Player.Position.Z);
                for (int y = client.Level.MaxY; y >= client.Level.MinY; y--) {
                    IBlock block = client.Level.GetBlock(x, y, z);
                    if (!block.Air) {
                        Console.WriteLine($"Highest block under the player: {block} at y {y}");
                        break;
                    }
                }
            }

            await Task.Delay(50);
        }
        Console.WriteLine($"Disconnected: {client.DisconnectReason}");
    }
}
