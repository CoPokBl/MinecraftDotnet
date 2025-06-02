using Minecraft.Packets;
using Minecraft.Packets.Status.ClientBound;

namespace Minecraft.Helpers.Server;

public record MinecraftServerConfig(
    int Port, 
    Func<ServerBoundHandshakePacket, ClientBoundStatusResponsePacket> PingResponseSupplier,
    int HeartbeatFrequency) {

    public MinecraftServerConfig() : this(
        25565, 
        _ => new ClientBoundStatusResponsePacket("dotnet", 770, 1, 1),
        3000) { }
}