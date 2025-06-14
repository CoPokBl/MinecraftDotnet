using Minecraft;
using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Entities;
using Minecraft.Implementations.Server.Entities.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Implementations.Server.Worlds.TerrainProviders;
using Minecraft.NBT.Text;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;

namespace TestServer.Servers.MlgRush;

public static class MlgRush {

    public static async Task Start() {
        Console.WriteLine("Creating world...");
        // World world = new(new TestingProvider(), 32, 2, 10);
        World world = new(new SpawnCachedTerrainProvider(new MlgRushMapProvider(), 4), 4, 2, 10);
        Console.WriteLine("World created!");

        Func<MinecraftServer, MinecraftServer> serverProvider = server => new MinecraftServer([
            new PlayerInfoFeature(),
            new SimpleChatFeature(),
            new HeartbeatsFeature(3000),
            new TabListFeature(
                updatePeriod:1000, 
                headerProvider:() => TextComponent.Text("MLG Rush").WithColor(TextColor.Hex("#EE7026")).WithBold(true), 
                footerProvider:() => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic(true)),
            new SimpleEntitiesFeature(),
            new BlockBreakingFeature(false),
            new PlaceOneBlockFeature(11),
            new SimpleCombatFeature(500)
        ]);

        Dictionary<PlayerConnection, int> playerIds = new();

        MinecraftServer lobby = new([
            new PlayerInfoFeature(),
            new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket(
                "dotnet",
                connection.Handshake!.ProtocolVersion,
                1,
                1,
                [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                "MLG Rush",
                preventsChatReports: true)),
            new PlayerLoginFeature(loginPacketProvider:con => {
                int id = Random.Shared.Next();
                playerIds.Add(con, id);
                con.Disconnected += () => playerIds.Remove(con);
                return new ClientBoundLoginPacket(
                    id,
                    true,
                    ["minecraft:overworld"],
                    5,
                    32,
                    8,
                    false,
                    true,
                    false,
                    0,
                    "minecraft:overworld",
                    0,
                    0x00,
                    0x00,
                    false,
                    false,
                    null,
                    4,
                    64,
                    false
                );
            }),
            new PingRespondFeature()
        ]);

        CancellationTokenSource cts = new();

        bool run = true;
        Console.CancelKeyPress += (_, _) => {
            Console.WriteLine("Stopping...");
            run = false;
        };
        
        ManualResetEvent gotPlayer = new(false);

        Queue<PlayerConnection> connectionQueue = new();
        TcpMinecraftListener listener = new(connection => {
            lobby.AddConnection(connection);
            connection.Events.OnFirst<PlayerLoginFeature.PlayerLoginEvent>(e => {
                connectionQueue.Enqueue(e.Connection);
                gotPlayer.Set();
            });
        }, cts.Token);
        
        Console.WriteLine("Server ready, listening...");
        _ = listener.Listen();
        
        while (run) {
            MinecraftServer server = null!;
            server = serverProvider.Invoke(server);
            server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
                e.Connection.SendPackets(
                    new ClientBoundSynchronisePlayerPositionPacket(0, new PlayerPosition(new Vec3(0, -100, 0), Vec3.Zero, Angle.Zero, Angle.Zero), TeleportFlags.None));
            });

            // Get two players in
            for (int i = 0; i < 2; i++) {
                while (true) {
                    gotPlayer.WaitOne();
                    gotPlayer.Reset();
                    if (!connectionQueue.TryDequeue(out PlayerConnection? con)) continue;
                    server.AddConnection(con);
                    break;
                }
            }

            PlayerConnection c1 = server.Connections[0];
            PlayerConnection c2 = server.Connections[1];
            
            world.AddPlayer(c1);
            world.AddPlayer(c2);
            
            server.Feature<TabListFeature>()!.RegisterPlayer(c1);
            server.Feature<TabListFeature>()!.RegisterPlayer(c2);

            SimpleEntitiesFeature entities = server.Feature<SimpleEntitiesFeature>()!;
            
            // Create players
            PlayerEntity p1 = new(c1, PlayerInfoFeature.GetInfo(c1).Username.ThrowIfNull());
            PlayerEntity p2 = new(c2, PlayerInfoFeature.GetInfo(c2).Username.ThrowIfNull());
            entities.Spawn(p1, playerIds[c1]);
            entities.Spawn(p2, playerIds[c2]);
            
            await entities.InformNewPlayer(c1);
            await entities.InformNewPlayer(c2);

            PlayerPosition p1Spawn = new(new Vec3(MlgRushMapProvider.P1SpawnX, 0, 0.5), Vec3.Zero, Angle.FromDegrees(-90), Angle.Zero);
            PlayerPosition p2Spawn = new(new Vec3(MlgRushMapProvider.P2SpawnX, 0, 0.5), Vec3.Zero, Angle.FromDegrees(90), Angle.Zero);
            
            // Start the game
            p1.Teleport(p1Spawn);
            p2.Teleport(p2Spawn);

            const int dieLevel = -10;
            p1.Events.AddListener<EntityMoveEvent>(e => {
                if (e.NewPos.Y < dieLevel) {
                    e.Entity.Teleport(e.Entity == p1 ? p1Spawn : p2Spawn);
                }
            });
            p2.Events.AddListener<EntityMoveEvent>(e => {
                if (e.NewPos.Y < dieLevel) {
                    e.Entity.Teleport(e.Entity == p1 ? p1Spawn : p2Spawn);
                }
            });
            
            // Win condition
            server.Events.AddListener<BlockBreakingFeature.BlockBreakEvent>(e => {
                Console.WriteLine("FDSJLKFDJSLF");
                e.Connection.SendSystemMessage(TextComponent.Text(e.Position.ToString()));
                
                if (!(e.Position.Equals(MlgRushMapProvider.P1BedPosClient) || e.Position.Equals(MlgRushMapProvider.P2BedPosClient))) {
                    return;  // not a bed
                }

                bool p1Bed = e.Position.Equals(MlgRushMapProvider.P1BedPosClient);

                if (p1Bed && e.Connection == c1) {  // they broke their own bed
                    c1.SendSystemMessage(TextComponent.Text("You can't break your own bed, it is now only broken for you."));
                    e.Cancelled = true;
                    return;
                }

                if (!p1Bed && e.Connection == c2) {
                    c2.SendSystemMessage(TextComponent.Text("You can't break your own bed, it is now only broken for you."));
                    e.Cancelled = true;
                    return;
                }
                
                // a bed broke and it was the player person
                PlayerConnection winner = p1Bed ? c2 : c1;
                PlayerConnection loser = p1Bed ? c1 : c2;

                winner.Kick(TextComponent.Text("YOU WON!!!!").WithBold(true).WithColor(TextColor.Gold));
                loser.Kick(TextComponent.Text("You lose, L").WithBold(true).WithColor(TextColor.Red));
            });
            
        }
        
        Console.WriteLine("Bye!");
    }
}