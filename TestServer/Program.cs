using Minecraft.Helpers.Server;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;

MinecraftServerConfig config = new() {
    PingResponseSupplier = handshake => new ClientBoundStatusResponsePacket(
        "dotnet",
        handshake.ProtocolVersion,
        -6969,
        -69,
        [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
        handshake.Hostname switch {
            "copokbl-pc" => "Hello §cAdam/Michael§r, welcome to my server",
            "localhost" => "Hello me, have fun testing",
            _ => $"Hello World! You are using §c{handshake.Hostname}§r to connect"
        },
        preventsChatReports: true)
};
MinecraftServer server = new(config);

await server.Start();
