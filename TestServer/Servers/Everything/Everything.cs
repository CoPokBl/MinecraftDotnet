using System.Reflection;
using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Inventories;
using ManagedServer.Scoreboards;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using PolarWorlds;

namespace TestServer.Servers.Everything;

/// <summary>
/// General testing server for various library features.
/// </summary>
public static class Everything {

    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.NewBasic();
        server.AddFeature(new TradingFeature());

        World world = server.CreateWorld(new VoidProvider());

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
        });

        string name = $"{TextComponent.LegacyColorCodePrefix}c{TextComponent.LegacyColorCodePrefix}lsomedude";
        NpcEntity npc = new() {
            // Position = new Vec3<double>(1005, 69, 1024)
            Position = new Vec3<double>(),
            Name = name
        };
        npc.SetWorld(world);
        
        ThreadSafeRef<bool> visible = new(true);
        npc.ViewableRule = _ => visible.Value;

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.ViewableRule = _ => visible.Value;
            
            e.Player.SendPacket(ClientBoundUpdateTeamsPacket.CreateTeam("potato", 
                TextComponent.FromLegacyString("&7[&9MVP&7] "), 
                ClientBoundUpdateTeamsPacket.FriendlyFlag.SeeInvisibleTeammates, 
                ClientBoundUpdateTeamsPacket.NameTagVisibility.Always, 
                ClientBoundUpdateTeamsPacket.CollisionRule.Never, 
                ClientBoundUpdateTeamsPacket.TeamColor.Obfuscated, 
                TextComponent.FromLegacyString("&7[&9MVP&7] "), 
                TextComponent.Text(""), [
                "CoPokBl", name
            ]));
            
            e.Player.SendPacket(new ClientBoundPlayerAbilitiesPacket {
                Flags = ClientBoundPlayerAbilitiesPacket.Abilities.AllowFlying | ClientBoundPlayerAbilitiesPacket.Abilities.Flying,
                FlyingSpeed = 0.1f,
                FovModifier = 1f
            });

            Scoreboard board = new(ClientBoundDisplayObjectivePacket.DisplayPosition.Sidebar);
            board.AddEntry(new ScoreboardEntry("asd", 5, TextComponent.Text("Hello there")));
            board.AddEntry(new ScoreboardEntry("asdas", 10, TextComponent.Text("Hello there 2")));
            
            board.AddViewer(e.Player);

            e.Player.Events.AddListener<PlayerChatEvent>(ce => {
                if (ce.RawMessage == "asd") {
                    board.RemoveViewer(e.Player);
                }

                if (ce.RawMessage == "lb") {
                    e.Player.SetWorld(world);
                    e.Player.Teleport(new Vec3<double>(1005, 69, 1022));
                    e.Player.SendPacket(new ClientBoundPlayerAbilitiesPacket {
                        Flags = ClientBoundPlayerAbilitiesPacket.Abilities.AllowFlying | ClientBoundPlayerAbilitiesPacket.Abilities.Flying,
                        FlyingSpeed = 0.1f,
                        FovModifier = 1f
                    });
                }
                board.AddEntry(new ScoreboardEntry(Guid.NewGuid().ToString(), 5, TextComponent.Text(ce.RawMessage)));
            });
            
            
        });

        server.Events.AddListener<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundClientStatusPacket packet) {
                return;
            }

            if (packet.Action != ServerBoundClientStatusPacket.StatusAction.RequestStats) {
                return;
            }
            
            e.Player.SendPacket(new ClientBoundAwardStatisticsPacket {
                Statistics = [
                    new ClientBoundAwardStatisticsPacket.Entry(StatisticType.Custom, CustomStatistic.AnimalsBred, 69),
                    new ClientBoundAwardStatisticsPacket.Entry(StatisticType.Broken, Item.Netherrack, 6996)
                ]
            });
        });

        server.Events.AddListener<PlayerChatEvent>(e => {
            switch (e.RawMessage) {
                case "l":
                    e.Player.Teleport(new Vec3<double>(1005, 69, 1022));
                    break;
                case "z":
                    e.Player.Teleport(new Vec3<double>());
                    break;
                
                case "vy":
                    visible.Value = true;
                    e.Player.RefreshVisibleEntities();
                    e.Player.SendMessage("NPC visible");
                    break;
                case "vn":
                    visible.Value = false;
                    e.Player.RefreshVisibleEntities();
                    e.Player.SendMessage("NPC invisible");
                    break;
                
                case "t":
                    TradeInventory trade = new(server, [
                        new Trade(
                            new ItemStack(Item.Stone),
                            new ItemStack(Item.TadpoleBucket),
                            null,
                            false,
                            2,
                            10,
                            5,
                            0,
                            1f,
                            0),
                        new Trade(
                            new ItemStack(Item.Stone),
                            new ItemStack(Item.Ladder),
                            null,
                            false,
                            2,
                            10,
                            5,
                            0,
                            1f,
                            0)
                    ], MerchantLevel.Master, 1, true, true);

                    e.Player.OpenInventory = trade;
                    break;
                
                case "s":
                    e.Player.Inventory.AddItem(new ItemStack(Item.Stone, 8));
                    break;
            }
        });
        
        server.Start();
        Console.WriteLine("Server started.");
        await server.ListenTcp(25565);
    }
}
