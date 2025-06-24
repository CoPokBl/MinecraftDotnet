using Minecraft.Packets.Login.ServerBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ServerBoundLogin { get; private set; } = null!;

    private static void InitializeServerBoundLogin() {
        ServerBoundLogin = new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ServerBoundLoginStartPacket), ServerBoundLoginStartPacket.Deserialiser) },
            { 0x03, (typeof(ServerBoundLoginAcknowledgedPacket), ServerBoundLoginAcknowledgedPacket.Deserialiser) }
        };
    }
}