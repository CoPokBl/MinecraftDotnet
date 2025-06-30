using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Play.ClientBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ClientBoundConfig { get; private set; } = null!;

    private static void InitializeClientBoundConfig() {
        ClientBoundConfig = new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ClientBoundCookieRequestPacket), ClientBoundCookieRequestPacket.Deserialiser) },
            { 0x01, (typeof(ClientBoundPluginMessagePacket), ClientBoundPluginMessagePacket.Deserialiser) },
            { 0x02, (typeof(ClientBoundDisconnectPacket), ClientBoundDisconnectPacket.Deserialiser) },
            { 0x03, (typeof(ClientBoundFinishConfigurationPacket), ClientBoundFinishConfigurationPacket.Deserialiser) },
            { 0x04, (typeof(ClientBoundKeepAlivePacket), ClientBoundKeepAlivePacket.Deserialiser) },
            { 0x05, (typeof(ClientBoundPingPacket), ClientBoundPingPacket.Deserialiser) },
            { 0x06, (typeof(ClientBoundResetChatPacket), ClientBoundResetChatPacket.Deserialiser) },
            { 0x07, (typeof(ClientBoundRegistryDataPacket), ClientBoundRegistryDataPacket.Deserialiser) },
            { 0x08, (typeof(ClientBoundRemoveResourcePackPacket), ClientBoundRemoveResourcePackPacket.Deserialiser) },
            { 0x09, (typeof(ClientBoundAddResourcePackPacket), ClientBoundAddResourcePackPacket.Deserialiser) },
            { 0x0A, (typeof(ClientBoundStoreCookiePacket), ClientBoundStoreCookiePacket.Deserialiser) },
            { 0x0B, (typeof(ClientBoundTransferPacket), ClientBoundTransferPacket.Deserialiser) },
            { 0x0C, (typeof(ClientBoundFeatureFlagsPacket), ClientBoundFeatureFlagsPacket.Deserialiser) },
            { 0x0D, (typeof(ClientBoundUpdateTagsPacket), ClientBoundUpdateTagsPacket.Deserialiser) },
            { 0x0E, (typeof(ClientBoundKnownPacksPacket), ClientBoundKnownPacksPacket.Deserialiser) },
            { 0x0F, (typeof(ClientBoundCustomReportDetailsPacket), ClientBoundCustomReportDetailsPacket.Deserialiser) },
            { 0x10, (typeof(ClientBoundServerLinksPacket), ClientBoundServerLinksPacket.Deserialiser) },
            { 0x11, (typeof(ClientBoundClearDialogPacket), ClientBoundClearDialogPacket.Deserialiser) }
        };
    }
}
