using System.Buffers.Binary;
using System.IO.Compression;
using NBT;

namespace Minecraft.Implementations.AnvilWorld;

/// <summary>
/// One <c>r.x.z.mca</c>: up to 1024 chunks packed into 4 KiB sectors behind a two sector header of
/// offsets and timestamps. A port of vanilla's <c>RegionFile</c>.
/// </summary>
/// <remarks>
/// A write keeps <c>RegionFile.write</c>'s order: the new run is allocated while the old one is still
/// marked used, the header entry moves only once the payload is down, and the old run is freed last.
/// So a process dying at any point leaves a header naming a complete chunk, old or new.
/// <p/>
/// Nothing is forced to disk until <see cref="Flush"/>, which a save calls once at its end. Vanilla
/// opens the file <c>DSYNC</c> under <c>sync-chunk-writes</c>, its dedicated server default, so it
/// survives power loss mid save where this only survives the process dying.
/// </remarks>
public class AnvilRegionFile : IDisposable {
    private const int SectorSize = 4096; // 4 KiB
    private const int MaxEntryCount = 1024; // 1024 entries per region file
    private const int HeaderSectors = 2;

    /// <summary>
    /// A chunk's length is stored in a byte of sectors, so anything past this has to live in a
    /// separate <c>.mcc</c> file. Nothing here writes one.
    /// </summary>
    private const int MaxSectors = 255;

    /// <summary>
    /// <c>RegionFile.EXTERNAL_STREAM_FLAG</c>, set on the compression byte of a chunk kept in a
    /// <c>.mcc</c>.
    /// </summary>
    private const byte ExternalStreamFlag = 0x80;

    private static readonly byte[] Padding = new byte[SectorSize];

    private readonly string _path;
    private readonly List<bool> _freeSectors = [];
    private readonly int[] _locations = new int[MaxEntryCount]; // Locations of entries in the region file
    private readonly int[] _timestamps = new int[MaxEntryCount]; // Timestamps of entries in the region file
    private readonly FileStream _file;
    private bool _unflushed;

    public AnvilRegionFile(string filePath) : this(filePath, false) { }

    /// <param name="writable">
    /// Opens the file for writing, creating it if it does not exist. A read only region never creates
    /// a file, and refuses to write rather than failing partway through one.
    /// </param>
    public AnvilRegionFile(string filePath, bool writable) {
        _path = filePath;
        _file = File.Open(filePath, writable ? FileMode.OpenOrCreate : FileMode.Open,
            writable ? FileAccess.ReadWrite : FileAccess.Read, FileShare.Read);

        if (writable && _file.Length < HeaderSectors * SectorSize) {
            _file.SetLength(HeaderSectors * SectorSize);
        }

        ReadHeader();
    }

    /// <summary>
    /// The header as <c>RegionFile</c>'s constructor reads it. A header shorter than two sectors is read
    /// as far as it goes with the rest taken as zero, and an entry overlapping the header, sized zero, or
    /// starting past the end of the file is dropped, so a damaged region loses those chunks rather than
    /// failing to open. Vanilla logs each of these; nothing here has a log to write to.
    /// </summary>
    private void ReadHeader() {
        long length = _file.Length;
        byte[] header = new byte[HeaderSectors * SectorSize];
        _file.Seek(0, SeekOrigin.Begin);
        _file.ReadAtLeast(header, header.Length, false);

        long totalSectors = Math.Max(HeaderSectors, (length + SectorSize - 1) / SectorSize);
        for (int i = 0; i < totalSectors; i++) _freeSectors.Add(true);
        _freeSectors[0] = false;  // First sector is locations
        _freeSectors[1] = false;  // Second sector is timestamps

        for (int i = 0; i < MaxEntryCount; i++) {
            _timestamps[i] = BinaryPrimitives.ReadInt32BigEndian(header.AsSpan(SectorSize + i * 4));

            int location = BinaryPrimitives.ReadInt32BigEndian(header.AsSpan(i * 4));
            if (location == 0) {
                continue;
            }

            if (SectorStart(location) < HeaderSectors || SectorCount(location) == 0
                || (long)SectorStart(location) * SectorSize > length) {
                continue;
            }

            _locations[i] = location;
            MarkLocation(location, false);
        }
    }

    public INbtTag? ReadChunkData(int chunkX, int chunkZ) {
        byte[]? data = ReadChunkBytes(chunkX, chunkZ);
        return data == null ? null : NbtReader.ReadNbt(data, true).GetCompound()[""];
    }

    /// <summary>
    /// A chunk's NBT, decompressed but not parsed. What a codec wants, since parsing is its job.
    /// </summary>
    /// <remarks>
    /// <c>RegionFile.getChunkDataInputStream</c>: a run whose stream is empty or shorter than it claims
    /// is a missing chunk, not an error. A chunk in a format this cannot read yet throws
    /// <see cref="NotSupportedException"/> instead, because it is not damaged and must not be treated as
    /// though it were.
    /// </remarks>
    public byte[]? ReadChunkBytes(int chunkX, int chunkZ) {
        lock (_file) {
            int location = _locations[GetChunkIndex(chunkX, chunkZ)];
            if (location == 0) return null;

            byte[] run = new byte[SectorCount(location) * SectorSize];
            _file.Seek((long)SectorStart(location) * SectorSize, SeekOrigin.Begin);
            int read = _file.ReadAtLeast(run, run.Length, false);
            if (read < 5) return null;

            int length = BinaryPrimitives.ReadInt32BigEndian(run);
            byte compressionType = run[4];
            if (length == 0) return null;

            if ((compressionType & ExternalStreamFlag) != 0) {
                throw new NotSupportedException($"Chunk {chunkX}, {chunkZ} in '{_path}' is stored in an " +
                                                "external .mcc file, which is not supported.");
            }

            int payload = length - 1;
            if (payload > read - 5 || payload < 0) return null;

            return compressionType switch {
                1 => Decompress(new GZipStream(new MemoryStream(run, 5, payload), CompressionMode.Decompress)),
                2 => Decompress(new ZLibStream(new MemoryStream(run, 5, payload), CompressionMode.Decompress)),
                3 => run.AsSpan(5, payload).ToArray(),
                _ => throw new NotSupportedException("Unsupported compression type: " + compressionType)
            };
        }
    }

    /// <param name="data">The chunk's NBT with its root name, uncompressed.</param>
    public void WriteChunkBytes(int chunkX, int chunkZ, ReadOnlySpan<byte> data) {
        EnsureWritable();

        byte[] compressed = CompressZLib(data);
        int payload = compressed.Length + 5;  // the length prefix and the compression byte
        int sectors = (payload + SectorSize - 1) / SectorSize;

        if (sectors > MaxSectors) {
            throw new IOException(
                $"Chunk {chunkX}, {chunkZ} compresses to {compressed.Length} bytes, past the " +
                $"{MaxSectors * SectorSize} a region entry can address.");
        }

        lock (_file) {
            int index = GetChunkIndex(chunkX, chunkZ);
            int previous = _locations[index];
            int start = Allocate(sectors);

            _file.Seek((long)start * SectorSize, SeekOrigin.Begin);
            WriteInteger(_file, compressed.Length + 1);
            _file.WriteByte(2);  // ZLib
            _file.Write(compressed);

            // Padded out so the file always ends on a sector boundary, which is what makes the next
            // allocation's length arithmetic hold.
            _file.Write(Padding, 0, sectors * SectorSize - payload);
            _file.Flush();

            _locations[index] = (start << 8) | sectors;
            _timestamps[index] = Timestamp();
            MarkLocation(_locations[index], false);
            WriteHeaderEntry(index);

            if (previous != 0) {
                MarkLocation(previous, true);
            }

            _unflushed = true;
        }
    }

    /// <summary><c>RegionFile.clear</c>, which stamps the emptied entry with the time rather than zero.</summary>
    public void DeleteChunk(int chunkX, int chunkZ) {
        EnsureWritable();

        lock (_file) {
            int index = GetChunkIndex(chunkX, chunkZ);
            int previous = _locations[index];
            if (previous == 0) return;

            _locations[index] = 0;
            _timestamps[index] = Timestamp();
            WriteHeaderEntry(index);
            MarkLocation(previous, true);

            _unflushed = true;
        }
    }

    /// <summary>
    /// Forces what has been written to disk. Free when nothing has been written since the last one.
    /// </summary>
    public void Flush() {
        lock (_file) {
            if (!_unflushed) return;

            _file.Flush(true);
            _unflushed = false;
        }
    }

    /// <summary>Every chunk this region holds, as offsets within it.</summary>
    public IEnumerable<(int X, int Z)> EnumerateChunks() {
        List<(int X, int Z)> chunks = [];
        lock (_file) {
            for (int i = 0; i < MaxEntryCount; i++) {
                if (_locations[i] != 0) {
                    chunks.Add((i & 0x1F, i >> 5));
                }
            }
        }

        return chunks;
    }

    /// <summary>
    /// The first run of <paramref name="sectors"/> free sectors, growing the file if none is long
    /// enough. First fit rather than best fit: a region is rewritten in place for years and the
    /// alternative is to walk the whole table on every write to save a few kilobytes.
    /// </summary>
    private int Allocate(int sectors) {
        int run = 0;
        for (int i = HeaderSectors; i < _freeSectors.Count; i++) {
            if (!_freeSectors[i]) {
                run = 0;
                continue;
            }

            if (++run == sectors) {
                return i - sectors + 1;
            }
        }

        // The tail may already be partly free, so only the shortfall is added.
        int start = _freeSectors.Count - run;
        while (_freeSectors.Count < start + sectors) _freeSectors.Add(true);
        _file.SetLength((long)(start + sectors) * SectorSize);
        return start;
    }

    private void WriteHeaderEntry(int index) {
        _file.Seek(index * 4L, SeekOrigin.Begin);
        WriteInteger(_file, _locations[index]);
        _file.Seek(SectorSize + index * 4L, SeekOrigin.Begin);
        WriteInteger(_file, _timestamps[index]);
        _file.Flush();
    }

    private void EnsureWritable() {
        if (!_file.CanWrite) {
            throw new InvalidOperationException($"Region file '{_path}' was opened read only.");
        }
    }

    public bool HasChunkData(int chunkX, int chunkZ) {
        int index = GetChunkIndex(chunkX, chunkZ);
        return _locations[index] != 0;
    }

    private static int GetChunkIndex(int x, int z) {
        return (x & 0x1F) + ((z & 0x1F) << 5);
    }

    private static int ChunkToRegion(int coord) {
        return coord >> 5; // Divide by 32
    }

    private static int SectorStart(int location) => (location >> 8) & 0xFFFFFF;

    private static int SectorCount(int location) => location & 0xFF;

    private static int Timestamp() => (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

    private void MarkLocation(int location, bool free) {
        int sectorStart = SectorStart(location);
        int sectorEnd = sectorStart + SectorCount(location);
        for (int i = sectorStart; i < sectorEnd; i++) {
            while (_freeSectors.Count <= i) _freeSectors.Add(true);
            _freeSectors[i] = free;
        }
    }

    private static byte[] Decompress(Stream stream) {
        using (stream) {
            using MemoryStream output = new();
            stream.CopyTo(output);
            return output.ToArray();
        }
    }

    private static byte[] CompressZLib(ReadOnlySpan<byte> data) {
        using MemoryStream output = new();
        using (ZLibStream stream = new(output, CompressionLevel.Fastest, true)) {
            stream.Write(data);
        }

        return output.ToArray();
    }

    private static void WriteInteger(FileStream file, int value) {
        Span<byte> buffer = stackalloc byte[4];
        BinaryPrimitives.WriteInt32BigEndian(buffer, value);
        file.Write(buffer);
    }

    public static byte ReadByte(FileStream file) {
        int value = file.ReadByte();
        if (value == -1) throw new EndOfStreamException("Unexpected end of stream while reading byte.");
        return (byte)value;
    }

    public void Dispose() {
        _file.Dispose();
        GC.SuppressFinalize(this);
    }
}
