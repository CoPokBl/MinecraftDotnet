namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ServerBoundStateless { get; private set; } = null!;

    private static void InitializeServerBoundStateless() {
        ServerBoundStateless = new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ServerBoundHandshakePacket), ServerBoundHandshakePacket.Deserialiser) }
        };
    }
}
