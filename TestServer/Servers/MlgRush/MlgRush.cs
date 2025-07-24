using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Data.Sounds;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.MlgRush;

public static class MlgRush {
    private const int Port = 25565;
    private const bool LifeAfterBed = true;
    private const bool CanBreakOwnBed = true;

    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.NewBasic();
        server.AddFeatures(
            new OpenToLanAdFeature("MLG Rush over LAN", Port),
            new TabListFeature(
                updatePeriod:1000, 
                headerProvider:c => TextComponent.Text("MLG Rush").WithColor(TextColor.Hex("#EE7026")).WithBold(), 
                footerProvider:c => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic()),
            new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket {
                VersionName = "dotnet",
                VersionProtocol = connection.Handshake!.ProtocolVersion,
                OnlinePlayers = 1,
                MaxPlayers = 1,
                SamplePlayers = [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                Description = "MLG Rush",
                PreventsChatReports = true
            })
        );

        CancellationTokenSource cts = new();

        bool run = true;
        Console.CancelKeyPress += (_, _) => {
            Console.WriteLine("Stopping...");
            run = false;
        };
        
        ManualResetEvent gotPlayers = new(false);
        object queuePlayersLock = new();
        List<PlayerEntity> connectionQueue = [];

        World lobbyWorld = server.CreateWorld(new TestingProvider());
        
        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.GameMode = GameMode.Adventure;
            e.Hardcore = true;
            e.World = lobbyWorld;

            MinecraftPacket links = new ClientBoundServerLinksPacket {
                Links = [
                    ClientBoundServerLinksPacket.ServerLink.Override(ClientBoundServerLinksPacket.BuiltinLabel.Feedback, "https://serble.net")
                ]
            };
            e.Connection.SendPacket(links);
        });
        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(new Vec3<double>(0, 100, 0));
            Console.WriteLine("Teleported joining player in lobby");

            lock (queuePlayersLock) {
                connectionQueue.Add(e.Player);
                if (connectionQueue.Count >= 2) {
                    gotPlayers.Set();
                }
            }

            e.Player.Connection.Disconnected += () => {
                lock (queuePlayersLock) {
                    connectionQueue.Remove(e.Player);
                }
            };
        });
        
        TcpMinecraftListener listener = new(connection => {
            Console.WriteLine("Got new connection");
            server.AddConnection(connection);
        }, cts.Token);
        
        Console.WriteLine("Server ready, listening...");
        _ = listener.Listen(Port);

        ITerrainProvider terrain = new MlgRushMapProvider();
        while (run) {
            World world = server.CreateWorld(terrain);
            world.AddFeature(new SimpleCombatFeature(500));
            
            PlayerEntity p1 = null!;
            PlayerEntity p2 = null!;
            
            // Remove them from the queue
            // Get two players in
            gotPlayers.WaitOne();
            lock (queuePlayersLock) {
                gotPlayers.Reset();

                p1 = connectionQueue[0];
                p2 = connectionQueue[1];
                
                connectionQueue.RemoveAt(0);
                connectionQueue.RemoveAt(0);
            }
            
            PlayerConnection c1 = p1.Connection;
            PlayerConnection c2 = p2.Connection;
            
            // TODO: Tab list
            // server.Feature<TabListFeature>()!.RegisterPlayer(c1);
            // server.Feature<TabListFeature>()!.RegisterPlayer(c2);

            void Win(bool p1Won) {
                PlayerConnection winner = p1Won ? c1 : c2;
                PlayerConnection loser = p1Won ? c2 : c1;
                
                winner.Kick(TextComponent.Text("YOU WON!!!!").WithBold().WithColor(TextColor.Gold));
                loser.Kick(TextComponent.Text("You lose, L").WithBold().WithColor(TextColor.Red));
            }

            void BroadcastMsg(TextComponent msg) {
                c1.SendSystemMessage(msg);
                c2.SendSystemMessage(msg);
            }

            void BroadcastTitle(TextComponent msg, TextComponent subtitle) {
                c1.SendTitle(msg, subtitle);
                c2.SendTitle(msg, subtitle);
            }

            void BroadcastPacket(MinecraftPacket packet) {
                c1.SendPacket(packet);
                c2.SendPacket(packet);
            }

            void BroadcastParticle(IParticle particle, int count, Vec3<double> pos) {
                MinecraftPacket packet = new ClientBoundParticlePacket {
                    AlwaysVisible = true,
                    LongDistance = true,
                    MaxSpeed = 1f,
                    Offset = Vec3<float>.Zero,
                    Position = pos,
                    ParticleCount = count,
                    Particle = particle
                };
                c1.SendPacket(packet);
                c2.SendPacket(packet);
            }

            void BroadcastSound(ISoundType id) {
                foreach (PlayerEntity player in world.Players) {
                    player.Connection.SendPacket(new ClientBoundEntitySoundEffectPacket {
                        Category = SoundCategory.Master,
                        EntityId = player.NetId,
                        Event = null,
                        Type = id,
                        Pitch = 1f,
                        Volume = 1f,
                        Seed = 0L
                    });
                }
            }

            bool p1HasBed = true;
            bool p2HasBed = true;

            PlayerPosition p1Spawn = new(new Vec3<double>(MlgRushMapProvider.P1SpawnX, 0, 0.5), Vec3<double>.Zero, Angle.FromDegrees(-90), Angle.Zero);
            PlayerPosition p2Spawn = new(new Vec3<double>(MlgRushMapProvider.P2SpawnX, 0, 0.5), Vec3<double>.Zero, Angle.FromDegrees(90), Angle.Zero);
            
            // Start the game
            p1.SetWorld(world);
            p2.SetWorld(world);
            
            p1.Teleport(p1Spawn);
            p2.Teleport(p2Spawn);
            
            BroadcastPacket(new ClientBoundGameEventPacket {
                Event = GameEvent.ChangeGameMode,
                Value = 0
            });
            
            // Give them both blocks
            ItemStack item = new(64, Item.BambooBlock);
            p1.Inventory.SetHotbarItem(0, item);
            p2.Inventory.SetHotbarItem(0, item);

            const int dieLevel = -10;
            world.Events.AddListener<EntityMoveEvent>(e => {
                if (!(e.NewPos.Y < dieLevel)) return;

                if (LifeAfterBed) {  // check for final kill
                    if ((e.Entity == p1 && !p1HasBed) || (e.Entity == p2 && !p2HasBed)) {
                        Win(e.Entity == p2);
                    }
                }
                
                // Move them away for the other player to prevent tp blocking breaking
                e.Entity.SendToViewers(new ClientBoundTeleportEntityPacket {
                    EntityId = e.Entity.NetId,
                    Position = new Vec3<double>(0, -100, 0),
                    Velocity = Vec3<double>.Zero,
                    Yaw = Angle.Zero,
                    Pitch = Angle.Zero,
                    OnGround = false
                });
                
                e.Entity.Teleport(e.Entity == p1 ? p1Spawn : p2Spawn);
                
                // play nice sound
                PlayerEntity killer = e.Entity == p1 ? p2 : p1;
                killer.Connection.SendPacket(new ClientBoundEntitySoundEffectPacket {
                    Category = SoundCategory.Players,
                    EntityId = e.Entity.NetId,
                    Type = SoundType.PlayerLevelup,  // sound id for xp level up
                    Volume = 1f,
                    Pitch = 1f,
                    Seed = 0L
                });

                TextComponent msg = $"{((PlayerEntity)e.Entity).Name} was killed by {killer.Name}";
                world.StrikeLightning(e.NewPos);
                BroadcastMsg(msg);
            });
            
            // Win condition
            world.Events.AddListener<PlayerBreakBlockEvent>(e => {
                if (!(e.Position.Equals(MlgRushMapProvider.P1BedPosClient) || e.Position.Equals(MlgRushMapProvider.P2BedPosClient))) {
                    return;  // not a bed
                }

                bool p1Bed = e.Position.Equals(MlgRushMapProvider.P1BedPosClient);

                if ((p1Bed && !p1HasBed) || (!p1Bed && !p2HasBed)) {
                    return;  // someone placed a block where the bed was, we can ignore it
                }

                if (!CanBreakOwnBed && (p1Bed && e.Player == p1 || !p1Bed && e.Player == p2)) {  // they broke their own bed
                    e.Player.SendMessage(TextComponent.Text("You can't break your own bed idiot")
                        .WithColor(TextColor.Red)
                        .WithBold());
                    e.Cancelled = true;
                    return;
                }
                
                // play some fun
                BroadcastParticle(Particle.Explosion, 10, e.Position);
                BroadcastParticle(Particle.Firework, 50, e.Position);
                BroadcastParticle(Particle.Lava, 100, e.Position);
                
                // a bed broke and it was the player person
                if (!LifeAfterBed) {
                    Win(!p1Bed);
                    return;
                }
                
                // remove the bed
                if (p1Bed) {
                    p1HasBed = false;
                    BroadcastMsg($"{p1.Name} has lost their bed!");
                }
                else {
                    p2HasBed = false;
                    BroadcastMsg($"{p2.Name} has lost their bed!");
                }

                (p1Bed ? c1 : c2).SendTitle(
                    TextComponent.Text("You have lost your bed").WithColor(TextColor.Red),
                    TextComponent.Text("You will no longer respawn").WithColor(TextColor.White));
                
                (p1Bed ? c2 : c1).SendTitle(
                    TextComponent.Text($"{(p1Bed ? p1 : p2).Name}").WithBold()
                        .With(TextComponent.Text(" has lost their bed!").WithBold(false).WithColor(p1Bed ? TextColor.Aqua : TextColor.Red)),
                    TextComponent.Empty());
                
                BroadcastSound(SoundType.EnderDragonGrowl);
                BroadcastSound(SoundType.FireExtinguish);
            });
            
            const float disappearTime = 5f;
            world.Events.AddListener<PlayerPlaceBlockEvent>(e => {
                e.Cancelled = false;
                e.Block = e.Player == p1 ? Block.BlueWool : Block.RedWool;

                if (e.Position.Y > 1) {
                    e.Cancelled = true;
                    return;
                }
                
                e.Player.Inventory.SetHotbarItem(0, item);
            
                AtomicCounter count = new(-1);
                int breakingEntity = Random.Shared.Next();
                server.Scheduler.ScheduleRepeatingTask(TimeSpan.FromSeconds(disappearTime/9), () => {
                    count.Increment();
                    if (count.Value == 9) {
                        e.World.SendPacket(new ClientBoundSetBlockDestroyStagePacket {
                            EntityId = breakingEntity,
                            Block = e.Position,
                            Stage = 16
                        });
                        e.World.SetBlock(e.Position, Block.Air);
                        return false;
                    }
                
                    e.World.SendPacket(new ClientBoundSetBlockDestroyStagePacket {
                        EntityId = breakingEntity,
                        Block = e.Position,
                        Stage = (byte)count.Value
                    });
                    return true;
                });
            });
        }
        
        Console.WriteLine("Bye!");
    }
}
