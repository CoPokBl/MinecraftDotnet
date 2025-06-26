using Minecraft.Packets.Login.ServerBound;

namespace Minecraft.Packets.Registry;

// This packet registry is up to date with the Notchian protocol v1.21.6
public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ServerBoundLogin { get; private set; } = null!;

    private static void InitializeServerBoundLogin() {
        ServerBoundLogin = new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ServerBoundLoginStartPacket), ServerBoundLoginStartPacket.Deserialiser) },
            { 0x01, (typeof(ServerBoundEncryptionResponsePacket), ServerBoundEncryptionResponsePacket.Deserialiser) },
            { 0x02, (typeof(ServerBoundLoginPluginResponsePacket), ServerBoundLoginPluginResponsePacket.Deserialiser) },
            { 0x03, (typeof(ServerBoundLoginAcknowledgedPacket), ServerBoundLoginAcknowledgedPacket.Deserialiser) },
            { 0x04, (typeof(ServerBoundCookieResponsePacket), ServerBoundCookieResponsePacket.Deserialiser) }
        };
    }
}
