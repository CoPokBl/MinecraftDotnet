using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ServerBound;

namespace Minecraft.Packets.Registry;

// This packet registry is up to date with the Notchian protocol v1.21.6
public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ServerBoundConfig { get; private set; } = null!;

    private static void InitializeServerBoundConfig() {
        ServerBoundConfig =  new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ServerBoundClientInformationPacket), ServerBoundClientInformationPacket.Deserialiser) },
            { 0x01, (typeof(ServerBoundCookieResponsePacket), ServerBoundCookieResponsePacket.Deserialiser) },
            { 0x02, (typeof(ServerBoundPluginMessagePacket), ServerBoundPluginMessagePacket.Deserialiser) },
            { 0x03, (typeof(ServerBoundAcknowledgeFinishConfigurationPacket), ServerBoundAcknowledgeFinishConfigurationPacket.Deserialiser) },
            { 0x04, (typeof(ServerBoundKeepAlivePacket), ServerBoundKeepAlivePacket.Deserialiser) },
            { 0x05, (typeof(ServerBoundPongPacket), ServerBoundPongPacket.Deserialiser) },
            { 0x06, (typeof(ServerBoundResourcePackResponsePacket), ServerBoundResourcePackResponsePacket.Deserialiser) },
            { 0x07, (typeof(ServerBoundKnownPacksPacket), ServerBoundKnownPacksPacket.Deserialiser) },
            { 0x08, (typeof(ServerBoundCustomClickActionPacket), ServerBoundCustomClickActionPacket.Deserialiser) }
        };
    }
}
