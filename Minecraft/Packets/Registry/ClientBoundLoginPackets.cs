using Minecraft.Packets.Login.ClientBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ClientBoundLogin { get; private set; } = null!;

    private static void InitializeClientBoundLogin() {
        ClientBoundLogin =  new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x02, (typeof(ClientBoundLoginSuccessPacket), ClientBoundLoginSuccessPacket.Deserialiser) },
            { 0x03, (typeof(ClientBoundSetCompressionPacket), ClientBoundSetCompressionPacket.Deserialiser) }
        };
    }
}
