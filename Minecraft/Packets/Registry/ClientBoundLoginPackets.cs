using Minecraft.Packets.Login.ClientBound;

namespace Minecraft.Packets.Registry;

// This packet registry is up to date with the Notchian protocol v1.21.6
public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ClientBoundLogin { get; private set; } = null!;

    private static void InitializeClientBoundLogin() {
        ClientBoundLogin =  new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ClientBoundLoginDisconnectPacket), ClientBoundLoginDisconnectPacket.Deserialiser) },
            { 0x01, (typeof(ClientBoundEncryptionRequestPacket), ClientBoundEncryptionRequestPacket.Deserialiser) },
            { 0x02, (typeof(ClientBoundLoginSuccessPacket), ClientBoundLoginSuccessPacket.Deserialiser) },
            { 0x03, (typeof(ClientBoundSetCompressionPacket), ClientBoundSetCompressionPacket.Deserialiser) },
            { 0x04, (typeof(ClientBoundLoginPluginRequestPacket), ClientBoundLoginPluginRequestPacket.Deserialiser) },
            { 0x05, (typeof(ClientBoundCookieRequestPacket), ClientBoundCookieRequestPacket.Deserialiser) }
        };
    }
}
