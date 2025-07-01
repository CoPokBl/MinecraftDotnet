using Minecraft.Packets.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets;

public abstract class MinecraftPacket {
    protected abstract byte[] GetData();

    protected static void AssertLength<T>(T[] arr, int length) {
        if (arr.Length != length) {
            throw new ArgumentException($"Array size must be {length}", nameof(arr));
        }
    }

    protected static void AssertNotNull(object? obj) {
        if (obj == null) {
            throw new ArgumentNullException(nameof(obj), "Object cannot be null");
        }
    }

    protected static void Assert(bool cond, string msg = "Assertion failed") {
        if (!cond) {
            throw new ArgumentException(msg);
        }
    }

    public byte[] Serialise(ConnectionState state, bool compress = false) {
        int packetId;
        try {
            if (this is UnknownPacket up) {
                packetId = up.Id;
            }
            else {
                packetId = PacketRegistry.GetPacketId(GetType(), state);
            }
        }
        catch (KeyNotFoundException) {
            throw new NotImplementedException($"Packet {GetType().Name} is not registered for state {state}");
        }
        byte[] data = GetData();

        DataWriter typeD = new();
        typeD.WriteVarInt(packetId);
        byte[] typeBytes = typeD.ToArray();

        if (compress) {
            byte[] dataToCompress = new DataWriter().WriteVarInt(packetId).Write(data).ToArray();
            byte[] compressedData = CompressionHelper.CompressZLib(dataToCompress);

            int dataLengthLength = new DataWriter().WriteVarInt(dataToCompress.Length).ToArray().Length;

            return new DataWriter()
                .WriteVarInt(dataLengthLength + compressedData.Length)
                .WriteVarInt(dataToCompress.Length)
                .Write(compressedData)
                .ToArray();
        }
        
        // Don't compress the packet
        DataWriter w = new();
        w.WriteVarInt(data.Length + typeBytes.Length);  // packet size
        w.WriteVarInt(packetId);  // packet type
        w.Write(data);  // the data
        return w.ToArray();
    }
    
    public static MinecraftPacket Deserialise(byte[] packet, bool clientBound, ConnectionState state, bool compressed = false, bool allowUnknown = true) {
        DataReader r = new(packet);
        _ = r.ReadVarInt();  // Unneeded packet size

        int packetType;
        if (compressed) {
            int dataLength = r.ReadVarInt();

            if (dataLength == 0) {
                // it's not compressed
                packetType = r.ReadVarInt();
            }
            else {  // compressed packet
                byte[] compressedData = r.ReadRemaining();
                DataReader reader = new(CompressionHelper.DecompressZlib(compressedData));
                packetType = reader.ReadVarInt();
                r = reader;  // so that the packet uses the uncompressed data
            }
        }
        else {
            packetType = r.ReadVarInt();
        }
        
        // everything left in "r" should be the actual packet data.

        Dictionary<int, (Type, PacketDataDeserialiser)> registry = PacketRegistry.GetRegistry(clientBound, state);

        if (!registry.TryGetValue(packetType, out (Type, PacketDataDeserialiser) registryVal)) {
            // For now let's assume that we won't receive invalid packets so any unknown one is a TODO.
            if (allowUnknown) {
                Console.WriteLine($"Invalid packet type: 0x{packetType:X} (Bound to: {(clientBound ? "client" : "server")}, State: {state})");
                return new UnknownPacket {
                    Id = packetType,
                    Data = r.ReadRemaining()
                };
            }
            throw new NotImplementedException($"Invalid packet type: 0x{packetType:X} (Bound to: {(clientBound ? "client" : "server")}, State: {state})");
        }
        PacketDataDeserialiser deserialiser = registryVal.Item2;
        return deserialiser(r);
    }
}
