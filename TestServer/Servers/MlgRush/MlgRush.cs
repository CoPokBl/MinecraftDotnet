using Minecraft;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Managed;
using Minecraft.Implementations.Server.Managed.Entities.Events;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Implementations.Server.Managed.Events;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Implementations.Server.Worlds.Features;
using Minecraft.Implementations.Server.Worlds.TerrainProviders;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Particles;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.MlgRush;

public static class MlgRush {
    private const int Port = 25565;
    private const bool LifeAfterBed = true;
    private const bool CanBreakOwnBed = true;

    public static async Task Start() {
        ManagedMinecraftServer mServer = new(
            new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket {
                VersionName = "dotnet",
                VersionProtocol = connection.Handshake!.ProtocolVersion,
                OnlinePlayers = 1,
                MaxPlayers = 1,
                SamplePlayers = [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                Description = "MLG Rush",
                PreventsChatReports = true
            }),
            new PingRespondFeature(),
            new SimpleChatFeature(),
            new OpenToLanAdFeature("MLG Rush over LAN", Port),
            new TabListFeature(
                updatePeriod:1000, 
                headerProvider:c => TextComponent.Text("MLG Rush").WithColor(TextColor.Hex("#EE7026")).WithBold(), 
                footerProvider:c => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic()));

        CancellationTokenSource cts = new();

        bool run = true;
        Console.CancelKeyPress += (_, _) => {
            Console.WriteLine("Stopping...");
            run = false;
        };
        
        ManualResetEvent gotPlayers = new(false);
        object queuePlayersLock = new();
        List<PlayerEntity> connectionQueue = [];

        World lobbyWorld = new(mServer.Events, new TestingProvider());
        
        TcpMinecraftListener listener = new(connection => {
            Console.WriteLine("Got new connection");
            mServer.AddConnection(connection);
            connection.Events.OnFirst<PlayerPreLoginEvent>(e => {
                e.GameMode = GameMode.Survival;
                e.Hardcore = true;
                e.World = lobbyWorld;

                MinecraftPacket links = new ClientBoundServerLinksPacket {
                    Links = [
                        ClientBoundServerLinksPacket.ServerLink.Override(ClientBoundServerLinksPacket.BuiltinLabel.Feedback, "https://serble.net")
                    ]
                };
                connection.SendPacket(links);
            });
            connection.Events.OnFirst<PlayerLoginEvent>(e => {
                e.Player.Teleport(new Vec3(0, 100, 0));
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
        }, cts.Token);
        
        Console.WriteLine("Server ready, listening...");
        _ = listener.Listen(Port);

        ITerrainProvider terrain = new MlgRushMapProvider();
        while (run) {
            World world = new(new EventNode<IServerEvent>(), terrain, 4, 2, 10);
            new SimpleCombatFeature(500).Register(world);
            new BlockBreakingFeature(false).Register(world);
            
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
            
            // c1 and c2 need to be declared.
            new PlaceOneBlockFeature(con => {
                return con == c1 ? 2104 : 2107;  // c1: blue, c2: red
            }, 5).Register(world);
            
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

            void BroadcastParticle(IParticle particle, int count, Vec3 pos) {
                MinecraftPacket packet = new ClientBoundParticlePacket {
                    AlwaysVisible = true,
                    LongDistance = true,
                    MaxSpeed = 1f,
                    Offset = FVec3.Zero,
                    Position = pos,
                    ParticleCount = count,
                    Particle = particle
                };
                c1.SendPacket(packet);
                c2.SendPacket(packet);
            }

            void BroadcastSound(int id) {
                foreach (PlayerEntity player in world.Players) {
                    player.Connection.SendPacket(new ClientBoundEntitySoundEffectPacket {
                        Category = SoundCategory.Master,
                        EntityId = player.NetId,
                        Event = null,
                        Id = id,
                        Pitch = 1f,
                        Volume = 1f,
                        Seed = 0L
                    });
                }
            }

            bool p1HasBed = true;
            bool p2HasBed = true;

            PlayerPosition p1Spawn = new(new Vec3(MlgRushMapProvider.P1SpawnX, 0, 0.5), Vec3.Zero, Angle.FromDegrees(-90), Angle.Zero);
            PlayerPosition p2Spawn = new(new Vec3(MlgRushMapProvider.P2SpawnX, 0, 0.5), Vec3.Zero, Angle.FromDegrees(90), Angle.Zero);
            
            // Start the game
            p1.SetWorld(world);
            p2.SetWorld(world);
            
            p1.Teleport(p1Spawn);
            p2.Teleport(p2Spawn);
            
            // Give them both blocks
            ClientBoundSetContainerSlotPacket giveItemPacket = new() {
                WindowId = 0,
                StateId = 0,
                SlotId = 36,
                Data = new Slot(64, 175)
            };
            c1.SendPacket(giveItemPacket);
            c2.SendPacket(giveItemPacket);

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
                    Position = new Vec3(0, -100, 0),
                    Velocity = Vec3.Zero,
                    Yaw = Angle.Zero,
                    Pitch = Angle.Zero,
                    OnGround = false
                });
                
                e.Entity.Teleport(e.Entity == p1 ? p1Spawn : p2Spawn);
                ((PlayerEntity)e.Entity).Connection.SendPacket(giveItemPacket);
                
                // play nice sound
                PlayerEntity killer = e.Entity == p1 ? p2 : p1;
                killer.Connection.SendPacket(new ClientBoundEntitySoundEffectPacket {
                    Category = SoundCategory.Players,
                    EntityId = e.Entity.NetId,
                    Id = 525,  // sound id for xp level up
                    Volume = 1f,
                    Pitch = 1f,
                    Seed = 0L
                });

                TextComponent msg = $"{((PlayerEntity)e.Entity).Name} was killed by {killer.Name}";
                Entity lightning = new(74);
                world.Spawn(lightning);
                lightning.Teleport(e.Entity.Position);
                BroadcastSound(820);  // lightning
                BroadcastMsg(msg);
            });
            
            // Win condition
            world.Events.AddListener<BlockBreakingFeature.BlockBreakEvent>(e => {
                if (!(e.Position.Equals(MlgRushMapProvider.P1BedPosClient) || e.Position.Equals(MlgRushMapProvider.P2BedPosClient))) {
                    return;  // not a bed
                }

                bool p1Bed = e.Position.Equals(MlgRushMapProvider.P1BedPosClient);

                if (!CanBreakOwnBed && (p1Bed && e.Connection == c1 || !p1Bed && e.Connection == c2)) {  // they broke their own bed
                    e.Connection.SendSystemMessage(TextComponent.Text("You can't break your own bed idiot")
                        .WithColor(TextColor.Red)
                        .WithBold());
                    e.Connection.SendPacket(new ClientBoundBlockUpdatePacket {
                        Location = e.Position,
                        BlockId = (int)MlgRushMapProvider.WhiteWool
                    });
                    e.Cancelled = true;
                    return;
                }
                
                // play some fun
                BroadcastParticle(IParticle.DefaultOfType("minecraft:explosion"), 10, e.Position);
                BroadcastParticle(IParticle.DefaultOfType("minecraft:firework"), 50, e.Position);
                BroadcastParticle(IParticle.DefaultOfType("minecraft:lava"), 100, e.Position);
                
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
                
                BroadcastSound(496);  // dragon growl
                BroadcastSound(544);  // fire extinguish
            });
            
        }
        
        Console.WriteLine("Bye!");
    }
}