using System.Diagnostics;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Managed;
using Minecraft.Implementations.Server.Managed.Entities.Events;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Implementations.Server.Managed.Events;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.AnvilTesting;

public class AnvilTesting {

    public static async Task Start() {
        ManagedMinecraftServer server = new(
            new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket {
                VersionName = "dotnet",
                VersionProtocol = connection.Handshake!.ProtocolVersion,
                OnlinePlayers = 1,
                MaxPlayers = -1,
                SamplePlayers = [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                Description = "Anvil Testing Server",
                PreventsChatReports = true
        }));

        World world = new(server.Events, new AnvilLoader("testanvil", VanillaRegistry.Data), 8, 64, 1000/20);

        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1; i++) {
            world.GetChunkPacket(new ChunkPosition(0, 0));
        }
        Console.WriteLine($"Chunk packet took {sw.ElapsedMilliseconds}ms");
        
        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
            e.GameMode = GameMode.Creative;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(new Vec3(0, 200, 0));
        });

        world.Events.AddListener<EntityMoveEvent>(e => {
            if (e.NewPos.Y < 0) {
                // If the player falls below Y=0, teleport them back to the spawn point
                e.Entity.Teleport(new Vec3(0, 200, 0));
                ((PlayerEntity)e.Entity).Connection.SendSystemMessage("You fell below the world! Teleporting back to spawn.");
            }
        });

        await server.ListenTcp(25565, CancellationToken.None);
    }
}