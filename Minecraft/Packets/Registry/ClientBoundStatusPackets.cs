using Minecraft.Packets.Status.ClientBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ClientBoundStatus { get; private set; } = null!;

    private static void InitializeClientBoundStatus() {
        ClientBoundStatus =  new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ClientBoundStatusResponsePacket), ClientBoundStatusResponsePacket.Deserialiser) },
            { 0x01, (typeof(ClientBoundPingResponsePacket), ClientBoundPingResponsePacket.Deserialiser) }
        };
    }
}