using Minecraft.Packets.Status.ServerBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ServerBoundStatus { get; private set; } = null!;

    private static void InitializeServerBoundStatus() {
        ServerBoundStatus =  new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ServerBoundStatusRequestPacket), ServerBoundStatusRequestPacket.Deserialiser) },
            { 0x01, (typeof(ServerBoundPingRequestPacket), ServerBoundPingRequestPacket.Deserialiser) }
        };
    }
}
