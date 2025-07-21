using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using TestServer.Servers.BlockSumo;

namespace TestServer.Servers.BlockSumoFFA;

public static class BlockSumoFfa {
    private const int Port = 25565;

    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.NewBasic();
        server.AddFeatures(new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket {
                VersionName = "dotnet",
                VersionProtocol = connection.Handshake!.ProtocolVersion,
                OnlinePlayers = 1,
                MaxPlayers = 1,
                SamplePlayers = [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                Description = TextComponent.FromLegacyString("&b&lBlock Sumo FFA"),
                PreventsChatReports = true
            }),
            new OpenToLanAdFeature("Block Sumo FFA over LAN", Port),
            new TabListFeature(
                updatePeriod:1000, 
                headerProvider:_ => TextComponent.Text("Block Sumo FFA").WithColor(TextColor.Hex("#EE7026")).WithBold(), 
                footerProvider:_ => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic()));
        
        server.Dimensions.Add("minecraft:potatoland", new Dimension());
        
        CancellationTokenSource cts = new();

        bool run = true;
        Console.CancelKeyPress += (_, _) => {
            Console.WriteLine("Stopping...");
            run = false;
        };

        ItemStack blockItem = new ItemStack(64, Item.BambooBlock)
            .With(DataComponent.CustomName, TextComponent.Text("Michael's Bamboo").WithColor(TextColor.Green).WithBold().WithItalic(false))
            .With(DataComponent.Damage, 10)
            .With(DataComponent.Rarity, ItemRarity.Epic)
            .With(DataComponent.MaxDamage, 100)
            .With(DataComponent.TooltipDisplay, new TooltipDisplayComponent.Info(true));
        
        PlayerPosition spawn = new(new Vec3(0, 0, 0), Vec3.Zero, Angle.FromDegrees(-90), Angle.Zero);
        ITerrainProvider terrain = new BlockSumoMapProvider(12);
        World world = server.CreateWorld(terrain);
        world.AddFeature(new SimpleCombatFeature(500));
        // new BlockBreakingFeature(false).Register(world);

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

        const float disappearTime = 5f;
        world.Events.AddListener<PlayerPlaceBlockEvent>(e => {
            e.Cancelled = false;
            e.Block = blocks[Random.Shared.Next(blocks.Length)];
            e.Player.HeldItem = blockItem;

            if (e.Position.Y > 1) {
                e.Cancelled = true;
                return;
            }
            
            AtomicCounter count = new(-1);
            int breakingEntity = Random.Shared.Next();
            server.ScheduleRepeatingTask(TimeSpan.FromSeconds(disappearTime/9), () => {
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

        world.Events.AddListener<PlayerBreakBlockEvent>(e => {
            e.Cancelled = false;
        });

        world.Events.AddListener<PlayerStartBreakingBlockEvent>(e => {
            e.Cancelled = false;
        });
        
        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.GameMode = GameMode.Survival;
            e.Hardcore = true;
            e.World = world;

            MinecraftPacket links = new ClientBoundServerLinksPacket {
                Links = [
                    ClientBoundServerLinksPacket.ServerLink.Override(ClientBoundServerLinksPacket.BuiltinLabel.Feedback, "https://serble.net")
                ]
            };
            e.Connection.SendPacket(links);
        });
        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(spawn);
            e.Player.Inventory.SetHotbarItem(0, blockItem);
            Console.WriteLine("Teleported joining player");
            server.SendMessage(TextComponent.FromLegacyString("&7[&a+&7] " + e.Player.Name + " &7joined the game!"));
            e.Player.Connection.Disconnected += () => {
                server.SendMessage(
                    TextComponent.FromLegacyString("&7[&c-&7] " + e.Player.Name + " &7left the game :("));
            };
        });
        
        
        TcpMinecraftListener listener = new(connection => {
            Console.WriteLine("Got new connection");
            server.AddConnection(connection);
        }, cts.Token);
        
        const int dieLevel = -10;
        world.Events.AddListener<EntityMoveEvent>(e => {
            if (!(e.NewPos.Y < dieLevel)) return;
            
            // die
            e.Entity.Teleport(spawn);
            if (e.Entity is PlayerEntity player) {
                player.GameMode = GameMode.Spectator;
                player.Connection.SendTitle(TextComponent.FromLegacyString("&c&lNoob"), TextComponent.Empty());

                server.ScheduleTask(TimeSpan.FromSeconds(2), () => {
                    player.GameMode = GameMode.Survival;
                    player.Teleport(spawn);
                });
            }
            ((PlayerEntity)e.Entity).Inventory.SetHotbarItem(0, blockItem);
            
            TextComponent msg = $"{((PlayerEntity)e.Entity).Name} was killed";
            world.StrikeLightning(e.NewPos);
            server.SendMessage(msg);
        });
        
        Console.WriteLine("Server ready, listening...");
        await listener.Listen(Port);
    }
}
