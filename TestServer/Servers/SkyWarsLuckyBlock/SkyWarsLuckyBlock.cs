using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public static class SkyWarsLuckyBlock {
    private static readonly Vec3[] MapSpawns = [
        new(-20.5, 25, -24.5),
        new(23.5, 25, -24.5),
        new(29.5, 25, 0.5),
        new(21.5, 25, 25.5),
        new(-22.5, 25, 25.5),
        new(-28.5, 25, 0.5)
    ];
    
    private static readonly Vec3 SpecSpawn = new(0.5, 25, 0.5);

    private const string MapFolder = "ramen";
    private const int StartTimeSeconds = 5;
    
    private static Queue<Vec3> CreateRandomSpawns() {
        Queue<Vec3> spawns = new();
        List<Vec3> spawnList = MapSpawns.ToList();
        
        while (spawnList.Count > 0) {
            int index = Random.Shared.Next(spawnList.Count);
            spawns.Enqueue(spawnList[index]);
            spawnList.RemoveAt(index);
        }
        
        return spawns;
    }
    
    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.NewBasic();
        server.AddFeatures(new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket {
            VersionName = "dotnet",
            VersionProtocol = connection.Handshake!.ProtocolVersion,
            OnlinePlayers = 1,
            MaxPlayers = 1,
            SamplePlayers = [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
            Description = TextComponent.FromLegacyString("&a&lSkyWars"),
            PreventsChatReports = true
        }));

        World lobby = server.CreateWorld(new TestingProvider());

        ITerrainProvider gameMap = new AnvilLoader(MapFolder, VanillaRegistry.Data);
        
        Timer? startTimer = null;
        DateTime startTime = DateTime.Now;
        List<PlayerEntity> waitingPlayers = [];

        void StartGame() {
            startTimer?.Dispose();
            startTimer = null;
            
            World gameWorld = server.CreateWorld(gameMap);
            gameWorld.AddFeature(new SimpleCombatFeature(500));
            gameWorld.AddFeature(new SkyWarsChestsFeature());
            List<PlayerEntity> remainingPlayers = [];
            lock (waitingPlayers) {
                Queue<Vec3> spawns = CreateRandomSpawns();
                
                foreach (PlayerEntity player in waitingPlayers) {
                    remainingPlayers.Add(player);
                    player.SetWorld(gameWorld);
                    player.Teleport(spawns.Dequeue());
                    player.SendMessage(TextComponent.FromLegacyString("&a&lGame Started! Good luck!"));
                }
            }

            gameWorld.Events.AddListener<EntityMoveEvent>(e => {
                if (e.NewPos.Y > -10) {
                    return;
                }

                // death
                if (e.Entity is not PlayerEntity player) {
                    return;
                }

                player.SendMessage(TextComponent.FromLegacyString("&cYou fell out of the world!"));
                player.GameMode = GameMode.Spectator;
                player.Teleport(SpecSpawn);
                lock (remainingPlayers) {
                    remainingPlayers.Remove(player);
                    if (remainingPlayers.Count != 1) return;
                    // Winner
                    PlayerEntity winner = remainingPlayers[0];
                    winner.SendMessage(TextComponent.FromLegacyString("&a&lYou won the game!"));
                    winner.Teleport(SpecSpawn);
                        
                    gameWorld.SendTitle(
                        TextComponent.FromLegacyString("&a&lGame Over!"),
                        TextComponent.FromLegacyString("&7Winner: " + winner.Name), 10, 70, 20);
                }
            });
        }
        
        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = lobby;
            e.GameMode = GameMode.Survival;
            e.Hardcore = true;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            lock (waitingPlayers) {
                waitingPlayers.Add(e.Player);
                e.Player.Connection.Disconnected += () => {
                    lock (waitingPlayers) {
                        waitingPlayers.Remove(e.Player);
                    }
                };

                if (waitingPlayers.Count >= 2 && startTimer == null) {
                    startTime = DateTime.Now.AddSeconds(StartTimeSeconds);
                    startTimer = new Timer(_ => {
                        int secondsLeft = (int)(startTime - DateTime.Now).TotalSeconds;
                        if (secondsLeft <= 0) {
                            StartGame();
                            return;
                        }
                        
                        lobby.SendTitle(
                            TextComponent.FromLegacyString("&a&lGame Starting!"), 
                            TextComponent.FromLegacyString("&7Starting in " + secondsLeft + " seconds"), 0);
                    }, null, TimeSpan.FromSeconds(0.5), TimeSpan.FromSeconds(0.5));
                }
            }
        });

        Console.WriteLine("Starting SkyWars Lucky Block server...");
        await server.ListenTcp(25565, CancellationToken.None);
    }
}
