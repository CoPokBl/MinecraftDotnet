using System.Net.Sockets;
using System.Security.Cryptography;

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
                throw new Exception("Failed to read a byte from the stream.");
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
}
