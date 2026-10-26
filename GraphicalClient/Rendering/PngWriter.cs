using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;

namespace GraphicalClient.Rendering;

/// <summary>Just enough PNG to save a screenshot: 8 bit RGBA, no filtering.</summary>
public static class PngWriter {
    public static void Write(string path, int width, int height, byte[] rgbaBottomUp) {
        using FileStream file = File.Create(path);
        file.Write([0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A]);

        byte[] header = new byte[13];
        BinaryPrimitives.WriteInt32BigEndian(header, width);
        BinaryPrimitives.WriteInt32BigEndian(header.AsSpan(4), height);
        header[8] = 8;
        header[9] = 6;
        Chunk(file, "IHDR", header);

        using MemoryStream raw = new();
        using (ZLibStream zlib = new(raw, CompressionLevel.Fastest, true)) {
            for (int y = height - 1; y >= 0; y--) {
                zlib.WriteByte(0);
                zlib.Write(rgbaBottomUp, y * width * 4, width * 4);
            }
        }
        Chunk(file, "IDAT", raw.ToArray());
        Chunk(file, "IEND", []);
    }

    private static void Chunk(Stream stream, string type, byte[] data) {
        Span<byte> word = stackalloc byte[4];
        BinaryPrimitives.WriteInt32BigEndian(word, data.Length);
        stream.Write(word);
        byte[] typeBytes = Encoding.ASCII.GetBytes(type);
        stream.Write(typeBytes);
        stream.Write(data);
        uint crc = Crc(typeBytes, 0xFFFFFFFF);
        crc = Crc(data, crc) ^ 0xFFFFFFFF;
        BinaryPrimitives.WriteUInt32BigEndian(word, crc);
        stream.Write(word);
    }

    private static uint Crc(byte[] data, uint crc) {
        foreach (byte b in data) {
            crc ^= b;
            for (int k = 0; k < 8; k++) {
                crc = (crc & 1) != 0 ? 0xEDB88320 ^ (crc >> 1) : crc >> 1;
            }
        }
        return crc;
    }
}
