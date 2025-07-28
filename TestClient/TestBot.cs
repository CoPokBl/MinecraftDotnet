using ClientLib;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Client;
using Minecraft.Schemas.Vec;

namespace TestClient;

public class TestBot {

    public static async Task Start() {
        ServerConnection con = await MinecraftClientUtils.ConnectToServer("localhost", 25565);
        MinecraftClient client = new(con);
        client.Login("potato", 25565, ProtocolVersionConstants.ProtocolVersion);
        Console.WriteLine("Finished login");
        
        await Task.Delay(TimeSpan.FromSeconds(5));
        
        // find highest block at current pos
        Console.WriteLine("Starting search");
        int cY = (int)client.Position.Y + 100;
        while (true) {
            cY--;
            if (!client.World.IsInBounds(new Vec3<int>(0, cY, 0))) {
                Console.WriteLine("Failed to find a block, out of bounds");
                break;
            }
            IBlock block = client.World.GetBlock(new Vec3<int>(0, cY, 0));
        
            if (block.Identifier != Block.Air.Identifier) {
                Console.WriteLine(block.Identifier);
                break;
            }
        }

        await Task.Delay(-1);
    }
}
