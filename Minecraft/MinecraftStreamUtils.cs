using System.Security.Cryptography;
using Minecraft.Implementations;
using Minecraft.Implementations.Client;
using Minecraft.Packets;

namespace Minecraft;

public static class MinecraftStreamUtils {
    
    public static async Task<int> ReadVarInt(this Stream stream) {
        int value = 0;
        int position = 0;

        while (true) {
            // Get one byte from the stream as it becomes available
            byte[] oneByte = new byte[1];
            int bytesRead = await stream.ReadAsync(oneByte.AsMemory(0, 1));
            if (bytesRead != 1) {
                throw new Exception("Failed to read a byte from the stream. (Got " + bytesRead + " bytes)");
            }

            if (stream is CryptoStream) {
                Console.WriteLine("READ ONE BYTE FROM CRYPTO STREAM");
            }
            byte currentByte = oneByte[0];
            
            value |= (currentByte & ProtocolConstants.SegmentBits) << position;

            if ((currentByte & ProtocolConstants.ContinueBit) == 0) break;

            position += 7;

            if (position >= 32) throw new Exception("VarInt is too big");
        }

        return value;
    }

    /// <summary>
    /// Reads a Minecraft packet from the stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="connection">The connection that the stream is associated with.</param>
    /// <param name="buffer">A buffer to read into, should be big enough to contain a packet.</param>
    /// <param name="ct">Token to cancel reading.</param>
    /// <returns>The read <see cref="MinecraftPacket"/>.</returns>
    /// <exception cref="Exception">When reading fails.</exception>
    /// <exception cref="NotImplementedException">When the packet type could not be determined.</exception>
    public static async Task<MinecraftPacket> ReadMinecraftPacket(this Stream stream, MinecraftConnection connection, byte[] buffer, CancellationToken ct = default) {
        int packetSize = await stream.ReadVarInt();
        if (packetSize > buffer.Length) {
            throw new Exception($"Packet size exceeds buffer size, size: {packetSize}");
        }
        int offset = 0;
        while (offset < packetSize) {
            int bytesRead = await stream.ReadAsync(buffer.AsMemory(offset, packetSize - offset), ct);
            if (bytesRead == 0) {
                // connection dropped
                throw new Exception("Received no data, broken connection?");
            }
            offset += bytesRead;
        }
                
        // buffer now contains the full packet
        // prepend the packet size varint, TODO: remove this requirement
        DataWriter data = new();
        data.WriteVarInt(packetSize);
        data.Write(buffer[..packetSize]);

        return MinecraftPacket.Deserialise(
            data.ToArray(), 
            connection is ServerConnection, 
            connection.State, 
            connection.CompressionEnabled, 
            connection.AllowUnknownPackets);
    }
}
