using System.Buffers.Binary;
using System.IO.Compression;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>An image as 8 bit RGBA rows, top first.</summary>
public sealed record TextureImage(int Width, int Height, byte[] Rgba) {
    /// <summary>The rectangle whose top left corner is at <paramref name="x"/>, <paramref name="y"/>, as animation frames are cut.</summary>
    public TextureImage Region(int x, int y, int width, int height) {
        byte[] rgba = new byte[width * height * 4];
        for (int row = 0; row < height; row++) {
            Array.Copy(Rgba, ((y + row) * Width + x) * 4, rgba, row * width * 4, width * 4);
        }
        return new TextureImage(width, height, rgba);
    }

    /// <summary>Nearest neighbour scaling to <paramref name="size"/> square, for packing textures of different sizes into one array.</summary>
    public TextureImage Resized(int size) {
        if (Width == size && Height == size) {
            return this;
        }
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            int sy = y * Height / size;
            for (int x = 0; x < size; x++) {
                int sx = x * Width / size;
                Array.Copy(Rgba, (sy * Width + sx) * 4, rgba, (y * size + x) * 4, 4);
            }
        }
        return new TextureImage(size, size, rgba);
    }
}

/// <summary>
/// A PNG decoder covering what packs contain: every colour type, bit depths 1 to 16, palette and
/// <c>tRNS</c> transparency, and Adam7 interlacing. Gamma and colour profile chunks are ignored, as
/// the game ignores them.
/// </summary>
public static class Png {
    private static readonly byte[] Signature = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];

    public static TextureImage Decode(byte[] file) {
        if (file.Length < 8 || !file.AsSpan(0, 8).SequenceEqual(Signature)) {
            throw new InvalidDataException("Not a PNG");
        }
        int width = 0, height = 0, depth = 0, type = 0, interlace = 0;
        byte[]? palette = null, transparency = null;
        using MemoryStream compressed = new();
        int at = 8;
        while (at + 8 <= file.Length) {
            int length = BinaryPrimitives.ReadInt32BigEndian(file.AsSpan(at));
            string chunk = System.Text.Encoding.ASCII.GetString(file, at + 4, 4);
            ReadOnlySpan<byte> data = file.AsSpan(at + 8, length);
            switch (chunk) {
                case "IHDR":
                    width = BinaryPrimitives.ReadInt32BigEndian(data);
                    height = BinaryPrimitives.ReadInt32BigEndian(data[4..]);
                    depth = data[8];
                    type = data[9];
                    interlace = data[12];
                    break;
                case "PLTE":
                    palette = data.ToArray();
                    break;
                case "tRNS":
                    transparency = data.ToArray();
                    break;
                case "IDAT":
                    compressed.Write(data);
                    break;
            }
            if (chunk == "IEND") {
                break;
            }
            at += 12 + length;
        }
        if (width <= 0 || height <= 0) {
            throw new InvalidDataException("PNG has no header");
        }

        compressed.Position = 0;
        using ZLibStream inflate = new(compressed, CompressionMode.Decompress);
        using MemoryStream raw = new();
        inflate.CopyTo(raw);
        byte[] filtered = raw.ToArray();

        int channels = type switch { 0 => 1, 2 => 3, 3 => 1, 4 => 2, 6 => 4, _ => throw new InvalidDataException($"PNG colour type {type}") };
        int bitsPerPixel = channels * depth;
        byte[] rgba = new byte[width * height * 4];
        if (interlace == 0) {
            Unfilter(filtered, 0, width, height, bitsPerPixel, (x, y, row, bitOffset) => Store(rgba, width, x, y, row, bitOffset, type, depth, palette, transparency));
        }
        else {
            // Adam7: seven passes over sparser and sparser grids, each filtered on its own.
            int[] startX = [0, 4, 0, 2, 0, 1, 0], startY = [0, 0, 4, 0, 2, 0, 1];
            int[] stepX = [8, 8, 4, 4, 2, 2, 1], stepY = [8, 8, 8, 4, 4, 2, 2];
            int offset = 0;
            for (int pass = 0; pass < 7; pass++) {
                int passWidth = (width - startX[pass] + stepX[pass] - 1) / stepX[pass];
                int passHeight = (height - startY[pass] + stepY[pass] - 1) / stepY[pass];
                if (passWidth <= 0 || passHeight <= 0) {
                    continue;
                }
                int p = pass;
                offset = Unfilter(filtered, offset, passWidth, passHeight, bitsPerPixel, (x, y, row, bitOffset) =>
                    Store(rgba, width, startX[p] + x * stepX[p], startY[p] + y * stepY[p], row, bitOffset, type, depth, palette, transparency));
            }
        }
        return new TextureImage(width, height, rgba);
    }

    private delegate void PixelSink(int x, int y, byte[] row, int bitOffset);

    /// <summary>Reverses the per row filters and hands each pixel's bits on; returns where the next pass starts.</summary>
    private static int Unfilter(byte[] data, int offset, int width, int height, int bitsPerPixel, PixelSink sink) {
        int stride = (width * bitsPerPixel + 7) / 8;
        int bpp = Math.Max(1, bitsPerPixel / 8);
        byte[] previous = new byte[stride], current = new byte[stride];
        for (int y = 0; y < height; y++) {
            byte filter = data[offset];
            Array.Copy(data, offset + 1, current, 0, stride);
            offset += 1 + stride;
            for (int i = 0; i < stride; i++) {
                int left = i >= bpp ? current[i - bpp] : 0;
                int up = previous[i];
                int upLeft = i >= bpp ? previous[i - bpp] : 0;
                current[i] = filter switch {
                    0 => current[i],
                    1 => (byte)(current[i] + left),
                    2 => (byte)(current[i] + up),
                    3 => (byte)(current[i] + (left + up) / 2),
                    4 => (byte)(current[i] + Paeth(left, up, upLeft)),
                    _ => throw new InvalidDataException($"PNG filter {filter}")
                };
            }
            for (int x = 0; x < width; x++) {
                sink(x, y, current, x * bitsPerPixel);
            }
            (previous, current) = (current, previous);
        }
        return offset;
    }

    private static int Paeth(int a, int b, int c) {
        int p = a + b - c;
        int pa = Math.Abs(p - a), pb = Math.Abs(p - b), pc = Math.Abs(p - c);
        return pa <= pb && pa <= pc ? a : pb <= pc ? b : c;
    }

    /// <summary>One sample of <paramref name="depth"/> bits, scaled to 8.</summary>
    private static int Sample(byte[] row, int bitOffset, int depth, out int raw) {
        switch (depth) {
            case 8:
                raw = row[bitOffset / 8];
                return raw;
            case 16:
                raw = row[bitOffset / 8] << 8 | row[bitOffset / 8 + 1];
                return row[bitOffset / 8];
            default:
                int shift = 8 - depth - bitOffset % 8;
                raw = row[bitOffset / 8] >> shift & ((1 << depth) - 1);
                return raw * 255 / ((1 << depth) - 1);
        }
    }

    private static void Store(byte[] rgba, int width, int x, int y, byte[] row, int bitOffset, int type, int depth, byte[]? palette, byte[]? trns) {
        int o = (y * width + x) * 4;
        int raw;
        switch (type) {
            case 0: {
                int grey = Sample(row, bitOffset, depth, out raw);
                bool clear = trns is { Length: >= 2 } && raw == (trns[0] << 8 | trns[1]);
                rgba[o] = rgba[o + 1] = rgba[o + 2] = (byte)grey;
                rgba[o + 3] = clear ? (byte)0 : (byte)255;
                break;
            }
            case 2: {
                int r = Sample(row, bitOffset, depth, out int rr);
                int g = Sample(row, bitOffset + depth, depth, out int rg);
                int b = Sample(row, bitOffset + depth * 2, depth, out int rb);
                bool clear = trns is { Length: >= 6 } && rr == (trns[0] << 8 | trns[1]) && rg == (trns[2] << 8 | trns[3]) && rb == (trns[4] << 8 | trns[5]);
                rgba[o] = (byte)r;
                rgba[o + 1] = (byte)g;
                rgba[o + 2] = (byte)b;
                rgba[o + 3] = clear ? (byte)0 : (byte)255;
                break;
            }
            case 3: {
                Sample(row, bitOffset, depth, out raw);
                if (palette != null && raw * 3 + 2 < palette.Length) {
                    rgba[o] = palette[raw * 3];
                    rgba[o + 1] = palette[raw * 3 + 1];
                    rgba[o + 2] = palette[raw * 3 + 2];
                }
                rgba[o + 3] = trns != null && raw < trns.Length ? trns[raw] : (byte)255;
                break;
            }
            case 4:
                rgba[o] = rgba[o + 1] = rgba[o + 2] = (byte)Sample(row, bitOffset, depth, out _);
                rgba[o + 3] = (byte)Sample(row, bitOffset + depth, depth, out _);
                break;
            default:
                for (int c = 0; c < 4; c++) {
                    rgba[o + c] = (byte)Sample(row, bitOffset + depth * c, depth, out _);
                }
                break;
        }
    }
}
