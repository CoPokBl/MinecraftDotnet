using Minecraft.Schemas;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static readonly Dictionary<ConnectionState, Dictionary<Type, int>> PacketTypes = new();

    public static int GetPacketId(Type type, ConnectionState state) {
        return PacketTypes[state][type];
    }

    public static Dictionary<int, (Type, PacketDataDeserialiser)> GetRegistry(bool clientBound, ConnectionState state) {
        if (clientBound) {
            return state switch {
                ConnectionState.None => throw new Exception("State cannot none for client bound packets."),
                ConnectionState.Status => ClientBoundStatus,
                ConnectionState.Login => ClientBoundLogin,
                ConnectionState.Configuration => ClientBoundConfig,
                ConnectionState.Play => ClientBoundPlay,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }
        
        // server bound
        return state switch {
            ConnectionState.None => ServerBoundStateless,
            ConnectionState.Status => ServerBoundStatus,
            ConnectionState.Login => ServerBoundLogin,
            ConnectionState.Configuration => ServerBoundConfig,
            ConnectionState.Play => ServerBoundPlay,
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
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

        Dictionary<ConnectionState, Dictionary<int, (Type, PacketDataDeserialiser)>[]> registries = new() {
            { ConnectionState.None, [ServerBoundStateless] },
            { ConnectionState.Configuration, [ClientBoundConfig, ServerBoundConfig] },
            { ConnectionState.Login, [ClientBoundLogin, ServerBoundLogin] },
            { ConnectionState.Status, [ClientBoundStatus, ServerBoundStatus] },
            { ConnectionState.Play, [ClientBoundPlay, ServerBoundPlay] }
        };

        foreach (KeyValuePair<ConnectionState, Dictionary<int, (Type, PacketDataDeserialiser)>[]> registrySet in registries) {
            Dictionary<Type, int> statePackets = registrySet.Value
                .SelectMany(registry => registry)
                .ToDictionary(kvp => kvp.Value.Item1, kvp => kvp.Key);
            PacketTypes.Add(registrySet.Key, statePackets);
        }
    }
#pragma warning restore CS8601 // Possible null reference assignment.
}
