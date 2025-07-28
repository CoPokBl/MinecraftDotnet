using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using PolarWorlds;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public static class SkyWarsLuckyBlock {
    private const int StartTimeSeconds = 5;
    private static readonly Vec3<double> LobbySpawn = new(5, 66, 5);
    
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
        // server.AddFeature(new SimpleBenchmarkFeature());
        
        server.Dimensions.Add("skywars:lobby", new Dimension());
        server.Dimensions.Add("skywars:game", new Dimension());
        
        World lobby = server.CreateWorld(new VoidProvider(), "skywars:lobby");
        SkyWarsGame.LoadWorld();

        NpcEntity billy = new(new PlayerMeta(SkinFlags:SkinParts.All)) {
            Position = LobbySpawn,
            Name = ChatUtils.FormatLegacy("&a&lBilly"),
            Skin = PlayerSkin.FromUsername("Technoblade").Result
        };
        billy.SetWorld(lobby);
        
        Timer? startTimer = null;
        DateTime startTime = DateTime.Now;
        List<PlayerEntity> waitingPlayers = [];

        void StartGame() {
            startTimer?.Dispose();
            startTimer = null;

            lock (waitingPlayers) {
                PlayerEntity[] players = waitingPlayers.ToArray();
                SkyWarsGame game = new(server, players, () => {
                    foreach (PlayerEntity player in players) {
                        EnqueuePlayer(player);
                    }
                });
                game.Start();
                waitingPlayers.Clear();
            }
        }
        
        void EnqueuePlayer(PlayerEntity player) {
            if (player.World != lobby) {
                player.SetWorld(lobby);
            }

            player.GameMode = GameMode.Survival;
            player.Inventory.Clear();
            
            lock (waitingPlayers) {
                waitingPlayers.Add(player);
                player.Connection.Disconnected += () => {
                    lock (waitingPlayers) {
                        waitingPlayers.Remove(player);
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
        }
        
        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = lobby;
            e.GameMode = GameMode.Survival;
            e.Hardcore = true;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            EnqueuePlayer(e.Player);
        });

        lobby.Events.AddListener<PlayerBreakBlockEvent>(e => {
            e.Cancelled = true;
        });

        server.Events.AddListener<PlayerChatEvent>(e => {
            if (!e.RawMessage.StartsWith("skin ")) {
                return;
            }
            
            string skinName = e.RawMessage[5..].Trim();
            if (string.IsNullOrEmpty(skinName)) {
                e.Player.SendMessage("Please provide a skin name.");
                return;
            }

            Task.Run(() => {
                PlayerSkin? skin = PlayerSkin.FromUsername(skinName).Result;
                if (skin == null) {
                    e.Player.SendMessage("Skin not found: " + skinName);
                    return;
                }

                e.Player.Skin = skin;
                e.Player.SendMessage("Skin set to: " + skinName);
            });
            e.Player.SendMessage("Loading skin: " + skinName);
        });

        lobby.Events.AddListener<EntityMoveEvent>(e => {
            if (e.Entity is not PlayerEntity player) {
                return;
            }

            if (e.NewPos.Y < 50) {
                player.Teleport(LobbySpawn);
            }
        });

        Console.WriteLine("Starting SkyWars Lucky Block server...");
        server.Start();
        await server.ListenTcp(25565, CancellationToken.None);
    }
}
