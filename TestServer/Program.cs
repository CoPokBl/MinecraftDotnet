using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Implementations.Server.Worlds.Generators;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;

MinecraftServer server = new([
    new PlayerInfoFeature(),
    new SimpleChatFeature(),
    new HeartbeatsFeature(3000),
    new PingRespondFeature(),
    new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket(
        "dotnet",
        connection.Handshake!.ProtocolVersion,
        -6969,
        -69,
        [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
        connection.Handshake!.Hostname switch {
            "copokbl-pc" => "Hello §cAdam/Michael§r, welcome to my server",
            "localhost" => "Hello me, have fun testing",
            _ => $"Hello World! You are using §c{connection.Handshake!.Hostname}§r to connect"
        },
        preventsChatReports: true)),
    new SpawnWorldFeature(new World(new TestingProvider(), 8)),
    new PlayerLoginFeature()
]);

CancellationTokenSource cts = new();
TcpMinecraftListener listener = new(connection => {
    server.AddConnection(connection);
    // cts.Cancel();
}, cts.Token);
await listener.Listen();

await Task.Delay(-1);