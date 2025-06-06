using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Entities;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Implementations.Server.Worlds.TerrainProviders;
using Minecraft.NBT.Text;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;

namespace TestServer.Servers.MlgRush;

public class MlgRush {

    public static async Task Start() {
        Console.WriteLine("Creating world...");
        // World world = new(new TestingProvider(), 32, 2, 10);
        World world = new(new SpawnCachedTerrainProvider(new MlgRushMapProvider(), 4), 4, 2, 10);
        Console.WriteLine("World created!");

        MinecraftServer server = null!;
        server = new MinecraftServer([
            new PlayerInfoFeature(),
            new SimpleChatFeature(),
            new HeartbeatsFeature(3000),
            new PingRespondFeature(),
            new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket(
                "dotnet",
                connection.Handshake!.ProtocolVersion,
                server.Connections.Count(c => c.State == PlayerConnectionState.Play)+1,
                server.Connections.Count(c => c.State == PlayerConnectionState.Play),
                [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                "MLG Rush",
                preventsChatReports: true)),
            new SpawnWorldFeature(world),
            new PlayerLoginFeature(),
            new TabListFeature(
                updatePeriod:1000, 
                headerProvider:() => TextComponent.Text("MLG Rush").WithColor(TextColor.Hex("#EE7026")).WithBold(true), 
                footerProvider:() => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic(true)),
            new SimpleEntitiesFeature(),
            new SimplePlayerEntitiesFeature(),
            new BlockBreakingFeature()
        ]);

        CancellationTokenSource cts = new();
        TcpMinecraftListener listener = new(connection => {
            server.AddConnection(connection);
            // cts.Cancel();
        }, cts.Token);

        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            e.Connection.SendPackets(
                new ServerBoundSetPlayerPositionPacket(new Vec3(0, 0, 0), MovePlayerFlags.None));
        });

        Console.WriteLine("Server ready, listening...");
        await listener.Listen();
    }
}