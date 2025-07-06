using ManagedServer;
using ManagedServer.Entities.Events;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using TestServer.Servers.BlockSumo;
using TestServer.Servers.MlgRush;

namespace TestServer.Servers.BlockSumoFFA;

public static class BlockSumoFfa {
    private const int Port = 25565;

    public static async Task Start() {
        ManagedMinecraftServer mServer = new(
            new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket {
                VersionName = "dotnet",
                VersionProtocol = connection.Handshake!.ProtocolVersion,
                OnlinePlayers = 1,
                MaxPlayers = 1,
                SamplePlayers = [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                Description = "Block Sumo FFA",
                PreventsChatReports = true
            }),
            new PingRespondFeature(),
            new SimpleChatFeature(),
            new OpenToLanAdFeature("Block Sumo FFA over LAN", Port),
            new TabListFeature(
                updatePeriod:1000, 
                headerProvider:_ => TextComponent.Text("Block Sumo FFA").WithColor(TextColor.Hex("#EE7026")).WithBold(), 
                footerProvider:_ => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic()));

        CancellationTokenSource cts = new();

        bool run = true;
        Console.CancelKeyPress += (_, _) => {
            Console.WriteLine("Stopping...");
            run = false;
        };
        
        ClientBoundSetContainerSlotPacket giveItemPacket = new() {
            WindowId = 0,
            StateId = 0,
            SlotId = 36,
            Data = new ItemStack(64, Item.BambooBlock).With(DataComponent.CustomName with {
                Value = TextComponent.Text("Michael's Bamboo").WithColor(TextColor.Green).WithBold()
            }).With(DataComponent.Damage with {
                Value = 10
            }).With(DataComponent.Rarity with {
                Value = ItemRarity.Epic
            }).With(DataComponent.MaxDamage with {
                Value = 100
            }).With(DataComponent.CreativeSlotLock)
            .With(DataComponent.TooltipDisplay with {
                Value = new TooltipDisplayComponent.Info(true)
            })
        };
        PlayerPosition spawn = new(new Vec3(0, 0, 0), Vec3.Zero, Angle.FromDegrees(-90), Angle.Zero);
        ITerrainProvider terrain = new BlockSumoMapProvider(12);
        World world = mServer.CreateWorld(terrain);
        new SimpleCombatFeature(500).Register(world);
        new BlockBreakingFeature(false).Register(world);

        IBlock[] blocks = [
            Block.WhiteConcretePowder,
            Block.OrangeConcretePowder,
            Block.MagentaConcretePowder,
            Block.LightBlueConcretePowder,  
            Block.YellowConcretePowder,
            Block.LimeConcretePowder,
            Block.PinkConcretePowder,
            Block.GrayConcretePowder,
            Block.LightGrayConcretePowder,
            Block.CyanConcretePowder,
            Block.PurpleConcretePowder,
            Block.BlueConcretePowder,
            Block.BrownConcretePowder,
            Block.GreenConcretePowder,
            Block.RedConcretePowder,
            Block.BlackConcretePowder
        ];
        
        new PlaceOneBlockFeature(c => {
            c.SendPacket(giveItemPacket);
            return blocks[Random.Shared.Next(blocks.Length)];
        }, 5).Register(world);
        
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
        
        void BroadcastMsg(TextComponent msg) {
            foreach (PlayerEntity player in world.Players) player.Connection.SendSystemMessage(msg);
        }
        
        TcpMinecraftListener listener = new(connection => {
            Console.WriteLine("Got new connection");
            mServer.AddConnection(connection);
            connection.Events.OnFirst<PlayerPreLoginEvent>(e => {
                e.GameMode = GameMode.Survival;
                e.Hardcore = true;
                e.World = world;

                MinecraftPacket links = new ClientBoundServerLinksPacket {
                    Links = [
                        ClientBoundServerLinksPacket.ServerLink.Override(ClientBoundServerLinksPacket.BuiltinLabel.Feedback, "https://serble.net")
                    ]
                };
                connection.SendPacket(links);
            });
            connection.Events.OnFirst<PlayerLoginEvent>(e => {
                e.Player.Teleport(new Vec3(0, 100, 0));
                e.Player.Connection.SendPacket(giveItemPacket);
                Console.WriteLine("Teleported joining player in lobby");
                
                // e.Player.Connection.Disconnected += () => {
                //     Console.WriteLine($"Player {e.Player.Name} disconnected");
                //     world.Entities.Despawn(e.Player);
                // };
            });
            connection.Events.AddListener<PacketSendingEvent>(e => {
                if (e.Connection.State != ConnectionState.Play) {
                    return;
                }
                if (PlayerInfoFeature.GetInfo(e.Connection).Username == "iVec4") {
                    // if (Random.Shared.Next(5) == 0) {
                    //     e.Cancelled = true;
                    // }
                    // Thread.Sleep(200);
                }
            });
            connection.Events.AddListener<PacketReceiveEvent>(e => {
                if (e.Connection.State != ConnectionState.Play) {
                    return;
                }
                if (PlayerInfoFeature.GetInfo(e.Connection).Username == "iVec4") {
                    // if (Random.Shared.Next(5) == 0) {
                    //     e.Cancelled = true;
                    // }
                    // Thread.Sleep(200);
                }
            });
        }, cts.Token);
        
        const int dieLevel = -10;
        List<Timer> timers = [];
        world.Events.AddListener<EntityMoveEvent>(e => {
            if (!(e.NewPos.Y < dieLevel)) return;
                
            // Move them away for the other player to prevent tp blocking breaking
            e.Entity.SendToViewers(new ClientBoundTeleportEntityPacket {
                EntityId = e.Entity.NetId,
                Position = new Vec3(0, -100, 0),
                Velocity = Vec3.Zero,
                Yaw = Angle.Zero,
                Pitch = Angle.Zero,
                OnGround = false
            });
                
            e.Entity.Teleport(spawn);
            if (e.Entity is PlayerEntity player) {
                player.GameMode = GameMode.Spectator;
                player.Connection.SendTitle(TextComponent.FromLegacyString("&c&lNoob"), TextComponent.Empty());

                Timer t = null!;
                t = new Timer(_ => {
                    player.GameMode = GameMode.Survival;
                    player.Teleport(spawn);
                    timers.Remove(t);
                }, null, TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);
                timers.Add(t);
            }
            ((PlayerEntity)e.Entity).Connection.SendPacket(giveItemPacket);
                
            TextComponent msg = $"{((PlayerEntity)e.Entity).Name} was killed";
            // Entity lightning = new(74);
            // world.Spawn(lightning);
            // lightning.Teleport(e.Entity.Position);
            world.StrikeLightning(e.NewPos);
            BroadcastSound(820);  // lightning
            BroadcastMsg(msg);
        });
        
        Console.WriteLine("Server ready, listening...");
        await listener.Listen(Port);
    }
}
