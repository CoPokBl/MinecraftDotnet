using System.IO.Compression;
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

    public byte[] Serialise(ConnectionState state, bool compress = false) {
        byte[] data = GetData();
        int packetId = PacketRegistry.GetPacketId(GetType(), state);

        DataWriter typeD = new();
        typeD.WriteVarInt(packetId);
        byte[] typeBytes = typeD.ToArray();

        if (compress) {
            byte[] dataToCompress = new DataWriter().WriteVarInt(packetId).Write(data).ToArray();
            byte[] compressedData = CompressZLib(dataToCompress);

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
    
    public static MinecraftPacket Deserialise(byte[] packet, bool clientBound, ConnectionState state, bool compressed = false) {
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
                DataReader reader = new(DecompressZlib(compressedData));
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
            throw new NotImplementedException($"Invalid packet type: 0x{packetType:X} (Bound to: {(clientBound ? "client" : "server")}, State: {state})");
        }
        PacketDataDeserialiser deserialiser = registryVal.Item2;
        return deserialiser(r);
    }
    
    private static byte[] DecompressZlib(byte[] inputData) {
        using MemoryStream input = new(inputData);
        using ZLibStream zlibStream = new(input, CompressionMode.Decompress);
        using MemoryStream output = new();
        zlibStream.CopyTo(output);
        return output.ToArray();
    }

    private static byte[] CompressZLib(byte[] inputData, CompressionLevel compressionLevel = CompressionLevel.Optimal) {
        using MemoryStream output = new();
        using (ZLibStream zlibStream = new(output, compressionLevel, leaveOpen: true)) {
            zlibStream.Write(inputData, 0, inputData.Length);
        }
        return output.ToArray();
    }
}
