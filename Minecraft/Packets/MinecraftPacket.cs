using System.Runtime.InteropServices;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets;

public abstract class MinecraftPacket {
    public abstract Identifier Identifier { get; }
    
    protected abstract DataWriter WriteData(DataWriter w);

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

    public byte[] Serialise(ConnectionState state, int compressionThreshold = -1, MinecraftRegistry? registry = null) {
        int packetId;
        try {
            if (this is UnknownPacket up) {
                packetId = up.Id;
            }
            else {
                packetId = (registry ?? VanillaRegistry.Data).Packets[state, GetType()];
            }
        }
        catch (KeyNotFoundException) {
            throw new NotImplementedException($"Packet {GetType().Name} is not registered for state {state}");
        }
        
        DataWriter data = new DataWriter().Write(WriteData);

        DataWriter typeD = new();
        typeD.WriteVarInt(packetId);
        byte[] typeBytes = typeD.ToArray();

        bool compressionEnabled = compressionThreshold >= 0;
        if (compressionEnabled && typeBytes.Length + data.Length >= compressionThreshold) {
            Span<byte> dataToCompress = CollectionsMarshal.AsSpan(new DataWriter().WriteVarInt(packetId).Write((IWritable)data).GetRaw());
            byte[] compressedData = CompressionHelper.CompressZLib(dataToCompress);

            int dataLengthLength = new DataWriter().WriteVarInt(dataToCompress.Length).ToArray().Length;

            return new DataWriter()
                .WriteVarInt(dataLengthLength + compressedData.Length)
                .WriteVarInt(dataToCompress.Length)
                .Write(compressedData)
                .ToArray();
        }

        int additionalPacketSize = compressionEnabled ? 1 : 0;  // 1 byte for the data length if compression is enabled

        // Don't compress the packet
        DataWriter w = new();
        w.WriteVarInt((int)data.Length + typeBytes.Length + additionalPacketSize);  // packet size
        
        if (compressionEnabled) {
            w.WriteVarInt(0);  // compression format means we need to specify 0 meaning no compression
        }
        
        w.WriteVarInt(packetId);  // packet type
        w.Write((IWritable)data);  // the data
        return w.ToArray();
    }
    
    public static MinecraftPacket Deserialise(byte[] packet, bool clientBound, ConnectionState state, bool compressed = false, bool allowUnknown = true, MinecraftRegistry? registry = null) {
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
        
        registry ??= VanillaRegistry.Data;
        
        // everything left in "r" should be the actual packet data.
        PacketDataDeserialiser? deserialiser = registry.Packets.GetDeserialiserOrDefault(state, clientBound, packetType);
        
        if (deserialiser == null) {
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
        return deserialiser(r, registry);
    }
}
