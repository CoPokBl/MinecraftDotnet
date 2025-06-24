using Minecraft.Packets.Config.ServerBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ServerBoundConfig { get; private set; } = null!;

    private static void InitializeServerBoundConfig() {
        ServerBoundConfig =  new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ServerBoundClientInformationPacketConfig), ServerBoundClientInformationPacketConfig.Deserialiser) },
            { 0x02, (typeof(ServerBoundPluginMessagePacketConfig), ServerBoundPluginMessagePacketConfig.Deserialiser) },
            { 0x03, (typeof(ServerBoundAcknowledgeFinishConfigurationPacket), ServerBoundAcknowledgeFinishConfigurationPacket.Deserialiser) },
            { 0x07, (typeof(ServerBoundKnownPacksPacket), ServerBoundKnownPacksPacket.Deserialiser) }
        };
    }
}
