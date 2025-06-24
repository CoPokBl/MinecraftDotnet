namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static readonly Dictionary<int, (Type, PacketDataDeserialiser)>[] Registries;
    public static readonly Dictionary<Type, int> PacketTypes = new();

    public static int GetPacketId(Type type) {
        return PacketTypes[type];
    }
    
#pragma warning disable CS8601 // Possible null reference assignment. Not actually possible.
    static PacketRegistry() {
        InitializeClientBoundConfig();
        InitializeClientBoundStatus();
        InitializeClientBoundLogin();
        InitializeClientBoundPlay();
        
        InitializeServerBoundStateless();
        InitializeServerBoundConfig();
        InitializeServerBoundStatus();
        InitializeServerBoundLogin();
        InitializeServerBoundPlay();
        
        Registries = [
            ClientBoundConfig,
            ClientBoundLogin,
            ClientBoundStatus,
            ClientBoundPlay,
            
            ServerBoundStateless,
            ServerBoundConfig,
            ServerBoundLogin,
            ServerBoundStatus,
            ServerBoundPlay
        ];

        foreach (Dictionary<int, (Type, PacketDataDeserialiser)> registry in Registries) {
            foreach (KeyValuePair<int, (Type, PacketDataDeserialiser)> kvp in registry) {
                PacketTypes.Add(kvp.Value.Item1, kvp.Key);
            }
        }
    }
#pragma warning restore CS8601 // Possible null reference assignment.
}
