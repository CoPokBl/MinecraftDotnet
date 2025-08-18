using Minecraft.Packets;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class PacketRegistry : ISubRegistry<PacketRegistry> {
    private readonly Dictionary<ConnectionState, Dictionary<Type, int>> _packetTypes = new();
    private readonly Dictionary<ConnectionState, Dictionary<bool, Dictionary<int, PacketDataDeserialiser>>> _packetDeserialisers = new();
    private readonly Dictionary<bool, HashSet<Type>> _packetTypesByClientBound = new() {
        { true, [] },
        { false, [] }
    };

    public int this[ConnectionState state, Type type] => _packetTypes[state][type];
    public int this[ConnectionState state, MinecraftPacket packet] => GetPacketId(state, packet);

    public int GetPacketId(ConnectionState state, MinecraftPacket packet) {
        if (packet is UnknownPacket unknown) {
            return unknown.Id;
        }
        
        return _packetTypes[state][packet.GetType()];
    }
    
    public PacketDataDeserialiser? GetDeserialiserOrDefault(ConnectionState state, bool clientBound, int id) {
        return _packetDeserialisers.GetValueOrDefault(state)?.GetValueOrDefault(clientBound)?.GetValueOrDefault(id);
    }

    public ISet<Type> GetPacketTypes(bool clientBound) {
        return _packetTypesByClientBound[clientBound];
    }

    public void Add(ConnectionState state, bool clientBound, int id, Type type, PacketDataDeserialiser deserialiser) {
        if (!_packetTypes.TryGetValue(state, out Dictionary<Type, int>? value)) {
            value = new Dictionary<Type, int>();
            _packetTypes.Add(state, value);
        }

        value.Add(type, id);
        
        if (!_packetDeserialisers.TryGetValue(state, out Dictionary<bool, Dictionary<int, PacketDataDeserialiser>>? value2)) {
            value2 = new Dictionary<bool, Dictionary<int, PacketDataDeserialiser>>();
            _packetDeserialisers.Add(state, value2);
        }
        if (!value2.ContainsKey(clientBound)) {
            value2.Add(clientBound, new Dictionary<int, PacketDataDeserialiser>());
        }
        value2[clientBound].Add(id, deserialiser);
        
        _packetTypesByClientBound[clientBound].Add(type);
    }

    public PacketRegistry Clone() {
        PacketRegistry clone = new();
        foreach (KeyValuePair<ConnectionState, Dictionary<Type, int>> pair in _packetTypes) {
            clone._packetTypes.Add(pair.Key, new Dictionary<Type, int>(pair.Value));
        }
        foreach (KeyValuePair<ConnectionState, Dictionary<bool, Dictionary<int, PacketDataDeserialiser>>> pair in _packetDeserialisers) {
            clone._packetDeserialisers.Add(pair.Key, new Dictionary<bool, Dictionary<int, PacketDataDeserialiser>>(pair.Value));
        }
        foreach (KeyValuePair<bool, HashSet<Type>> pair in _packetTypesByClientBound) {
            clone._packetTypesByClientBound.Add(pair.Key, [..pair.Value]);
        }
        return clone;
    }

    public void Clear() {
        _packetTypes.Clear();
        _packetDeserialisers.Clear();
        _packetTypesByClientBound[true].Clear();
        _packetTypesByClientBound[false].Clear();
    }
}
