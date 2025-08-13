using ManagedServer;
using ManagedServer.Commands;
using ManagedServer.Commands.Arguments;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Commands;
using Minecraft.Commands.NodeTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Schemas.Vec.Relative;
using Minecraft.Text;

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
            new OpenToLanAdFeature("Block Sumo FFA over LAN", Port)
            // new TabListFeature(
            //     updatePeriod:1000, 
            //     headerProvider:_ => TextComponent.Text("Block Sumo FFA").WithColor(TextColor.Hex("#EE7026")).WithBold(), 
            //     footerProvider:_ => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic())
            );
        
        server.Dimensions.Add("minecraft:potatoland", new Dimension());
        
        server.Commands.Add(new CommandBuilder("helloworld")
            .WithDefaultSyntax((player, _) => {
                player.SendMessage("Hello world!");
            }, _ => true)
            .WithSyntax(new CommandSyntax((player, context) => {
                player.SendMessage("Hello there, you entered the number: " + context.GetArgument<double>("numer"));
            }, new Argument<double>("numer", CommandArgumentType.Double)))
            .WithSubcommand(new CommandBuilder("alsosay")
                .WithSyntax(new CommandSyntax((player, context) => {
                    player.SendMessage("You alsosayed said: " + context.GetArgument<RelativeVec3<int>>("message")
                        .GetValue(new Vec3<int>(1, 1, 1)));
                    player.SendMessage("Your rancol is: " +
                                       (context.GetArgument<NamedTextColor?>("rancol")?.GetName() ?? "none"));
                    
                    player.SendMessage("Swizzle: " + context.GetArgument<(bool X, bool Y, bool Z)>("swiz"));
                    
                    player.SendMessage("Block: " + CommandArgumentType.BlockState.Format(context.GetArgument<IBlock>("block")));
                }, 
                    new Argument<RelativeVec3<int>>("message", CommandArgumentType.BlockPos), 
                    new Argument<NamedTextColor?>("rancol", CommandArgumentType.Color),
                    new Argument<(bool X, bool Y, bool Z)>("swiz", CommandArgumentType.Swizzle),
                    new Argument<IBlock>("block", CommandArgumentType.BlockState)))
                .Build())
            .Build());
        
        CancellationTokenSource cts = new();

        bool run = true;
        Console.CancelKeyPress += (_, _) => {
            Console.WriteLine("Stopping...");
            run = false;
        };

        ItemStack blockItem = new ItemStack(Item.BambooBlock, 64)
            .With(DataComponent.CustomName, TextComponent.Text("Michael's Bamboo").WithColor(TextColor.Green).WithBold().WithItalic(false))
            .With(DataComponent.Damage, 10)
            .With(DataComponent.Rarity, ItemRarity.Epic)
            .With(DataComponent.MaxDamage, 100)
            .With(DataComponent.TooltipDisplay, new TooltipDisplayComponent.Info(true));
        
        PlayerPosition spawn = new(new Vec3<double>(0, 0, 0), Vec3<double>.Zero, Angle.FromDegrees(-90), Angle.Zero);
        ITerrainProvider terrain = new BlockSumoMapProvider(12);
        World world = server.CreateWorld(terrain, "minecraft:potatoland");
        world.AddFeature(new SimpleCombatFeature(500));

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
            e.ConsumeItem = false;

            if (e.Position.Y > 1) {
                e.Cancelled = true;
                return;
            }
            
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
        }, true);

        world.Events.AddListener<PlayerBreakBlockEvent>(e => {
            e.Cancelled = false;
        }, true);

        world.Events.AddListener<PlayerStartBreakingBlockEvent>(e => {
            e.Cancelled = false;
        }, true);
        
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
        }, true);
        
        ClientBoundCommandsPacket cmds = new() {
            Nodes = [
                new RootNode(CommandNodeFlag.RootType, [1], null, null),
                // new LiteralNode(CommandNodeFlag.LiteralType | CommandNodeFlag.IsExecutable, [], null, "helloworld", null)
                new LiteralNode(CommandNodeFlag.LiteralType | CommandNodeFlag.IsExecutable | CommandNodeFlag.HasRedirect, [], 0, "execute", null)
            ],
            RootIndex = 0
        };
        
        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(spawn);
            e.Player.Inventory.SetHotbarItem(0, blockItem);
            Console.WriteLine("Teleported joining player");
            server.SendMessage(TextComponent.FromLegacyString("&7[&a+&7] " + e.Player.Name + " &7joined the game!"));
            e.Player.Connection.Disconnected += () => {
                server.SendMessage(
                    TextComponent.FromLegacyString("&7[&c-&7] " + e.Player.Name + " &7left the game :("));
            };
            
            e.Player.SendPacket(new ClientBoundEntityEffectPacket {
                EntityId = e.Player.NetId,
                Amplifier = 0,
                Duration = -1,
                Effect = PotionEffectType.Darkness,
                EffectFlags = ClientBoundEntityEffectPacket.Flags.ShowIcon
            });
            // e.Player.SendPacket(cmds);
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
            if (e.Entity is not PlayerEntity player) return;
            player.GameMode = GameMode.Spectator;
            player.Connection.SendTitle(TextComponent.FromLegacyString("&c&lNoob"), TextComponent.Empty());

            server.Scheduler.ScheduleTask(TimeSpan.FromSeconds(2), () => {
                player.GameMode = GameMode.Survival;
                player.Teleport(spawn);
            });
                
            player.Inventory.SetHotbarItem(0, blockItem);
                
            TextComponent msg = $"{player.Name} was killed";
            world.StrikeLightning(e.NewPos);
            server.SendMessage(msg);
        });
        
        server.Start();
        
        Console.WriteLine("Server ready, listening...");
        await listener.Listen(Port);
    }
}
