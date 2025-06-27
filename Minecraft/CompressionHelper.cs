using System.IO.Compression;

namespace Minecraft;

public static class CompressionHelper {
    
    public static byte[] DecompressZlib(byte[] inputData) {
        using MemoryStream input = new(inputData);
        using ZLibStream zlibStream = new(input, CompressionMode.Decompress);
        using MemoryStream output = new();
        zlibStream.CopyTo(output);
        return output.ToArray();
    }

    public static byte[] CompressZLib(byte[] inputData, CompressionLevel compressionLevel = CompressionLevel.Optimal) {
        using MemoryStream output = new();
        using (ZLibStream zlibStream = new(output, compressionLevel, leaveOpen: true)) {
            zlibStream.Write(inputData, 0, inputData.Length);
        }
        return output.ToArray();
    }
}