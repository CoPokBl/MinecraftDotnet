using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using PolarWorlds;

namespace TestServer.Servers.AnvilTesting;

public static class AnvilTesting {

    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.New(ManagedMinecraftServer.BasicsBundle);
        server.AddFeature(new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket {
            VersionName = "dotnet",
            VersionProtocol = connection.Handshake!.ProtocolVersion,
            OnlinePlayers = 1,
            MaxPlayers = -1,
            SamplePlayers = [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
            Description = "Anvil Testing Server",
            PreventsChatReports = true
        }));
        server.ViewDistance = 16;

        Console.WriteLine("Creating world...");
        // World world = server.CreateWorld(new AnvilLoader("testanvil", VanillaRegistry.Data));
        World world = server.CreateWorld(new PolarLoader("testpolar.polar", VanillaRegistry.Data));
        Console.WriteLine("World created.");
        
        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
            e.GameMode = GameMode.Creative;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(new Vec3<double>(0, 200, 0));
        });

        world.Events.AddListener<EntityMoveEvent>(e => {
            if (e.NewPos.Y < 0) {
                // If the player falls below Y=0, teleport them back to the spawn point
                e.Entity.Teleport(new Vec3<double>(0, 200, 0));
                ((PlayerEntity)e.Entity).Connection.SendSystemMessage("You fell below the world! Teleporting back to spawn.");
            }
        });

        world.Events.AddListener<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundChatMessagePacket chat) {
                return;
            }

            switch (chat.Message) {
                case "gc": {
                    GC.Collect();
                    break;
                }
            }
        });

        await server.ListenTcp(25565);
    }
}