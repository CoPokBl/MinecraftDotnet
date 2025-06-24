using Minecraft.Packets.Config.ClientBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ClientBoundConfig { get; private set; } = null!;

    private static void InitializeClientBoundConfig() {
        ClientBoundConfig = new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x03, (typeof(ClientBoundFinishConfigurationPacket), ClientBoundFinishConfigurationPacket.Deserialiser) },
            { 0x07, (typeof(ClientBoundRegistryDataPacket), ClientBoundRegistryDataPacket.Deserialiser) },
            { 0x0E, (typeof(ClientBoundKnownPacksPacket), ClientBoundKnownPacksPacket.Deserialiser) }
        };
    }
}