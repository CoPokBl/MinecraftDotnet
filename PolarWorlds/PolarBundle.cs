using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Storage;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using ZstdSharp;

namespace PolarWorlds;

/// <summary>
/// A whole Polar file: one header, one compressed stream, and every chunk in the world inside it.
/// </summary>
/// <remarks>
/// Chunks are stored back to back with no length in front of any of them, so the file is split into
/// per chunk records once when it is read and reassembled whole when it is written. Nothing can be
/// updated in place: a save rewrites the file. That is the format's bargain and it is the right one
/// for a map small enough to hold in memory, which is what Polar is for.
/// <p/>
/// Records are kept encoded and only decoded when a chunk is actually asked for, so opening a large
/// map costs a decompression and a walk rather than a full parse.
/// </remarks>
public sealed class PolarBundle : IChunkBlobStore {
    private const int MagicNumber = 0x506F6C72;
    private const short LatestVersion = 7;
    private const int DataVersion = GameVersion.DataVersion;

    private readonly Dictionary<Vec2<int>, byte[]> _records = [];
    private readonly object _lock = new();

    /// <summary>Held across a flush, since two would each write the same temporary file.</summary>
    private readonly object _flushLock = new();

    /// <summary>Bumped by anything that changes what <see cref="Save(CompressionType)"/> would produce.</summary>
    private long _version;
    private long _flushedVersion;

    private byte[] _userData = [];
    private string? _path;

    /// <summary>The lowest and the highest section the file covers, both inclusive.</summary>
    public int MinSection { get; private set; }
    public int MaxSection { get; private set; }

    public int SectionCount => MaxSection - MinSection + 1;
    public int WorldHeight => SectionCount * ChunkSection.Size;
    public int MinY => MinSection * ChunkSection.Size;

    public byte[] UserData {
        get => _userData;
        set {
            lock (_lock) {
                _userData = value;
                _version++;
            }
        }
    }

    /// <summary>Where <see cref="Flush"/> writes. Null for a bundle that is only ever saved by hand.</summary>
    public string? Path {
        get => _path;
        set {
            lock (_lock) {
                _path = value;
                _flushedVersion = -1;
            }
        }
    }

    /// <param name="minY">
    /// The world's floor, written into the header. A Polar reader places sections from it, so a file
    /// written with the wrong one loads shifted.
    /// </param>
    public PolarBundle(int worldHeight, int minY) {
        if ((minY & 15) != 0) {
            throw new ArgumentException($"A world's min y must be a multiple of 16; this one is {minY}.",
                nameof(minY));
        }

        MinSection = minY >> 4;
        MaxSection = MinSection + worldHeight / ChunkSection.Size - 1;
    }

    public PolarBundle(byte[] data) {
        Load(data);
    }

    public static PolarBundle Open(string path) {
        PolarBundle bundle = new(File.ReadAllBytes(path)) { Path = path };

        // Already what is on disk, so a flush with nothing written since has nothing to do.
        bundle._flushedVersion = bundle._version;
        return bundle;
    }

    public int Count {
        get {
            lock (_lock) {
                return _records.Count;
            }
        }
    }

    public bool TryRead(Vec2<int> pos, out byte[] data) {
        lock (_lock) {
            return _records.TryGetValue(pos, out data!);
        }
    }

    public void Write(Vec2<int> pos, ReadOnlySpan<byte> data) {
        byte[] record = data.ToArray();
        lock (_lock) {
            _records[pos] = record;
            _version++;
        }
    }

    public void Delete(Vec2<int> pos) {
        lock (_lock) {
            if (_records.Remove(pos)) {
                _version++;
            }
        }
    }

    public IEnumerable<Vec2<int>> EnumerateChunks() {
        lock (_lock) {
            return _records.Keys.ToArray();
        }
    }

    /// <summary>
    /// Writes the whole file to <see cref="Path"/> if anything has changed since it was last written.
    /// A bundle with no path has nowhere to go and flushing it does nothing, which is what an in memory
    /// map wants.
    /// </summary>
    /// <remarks>
    /// The check is what keeps an autosave affordable: this compresses and rewrites every chunk in the
    /// world, and a save that found nothing to write still ends in a flush.
    /// </remarks>
    public void Flush() {
        lock (_flushLock) {
            string? path;
            lock (_lock) {
                path = _path;
                if (path == null || _version == _flushedVersion) {
                    return;
                }
            }

            byte[] file = Save(CompressionType.Zstd, out long version);

            // Through a temporary, because a crash partway through would otherwise leave the map
            // truncated rather than merely out of date.
            string temporary = path + ".tmp";
            File.WriteAllBytes(temporary, file);
            File.Move(temporary, path, true);

            lock (_lock) {
                if (ReferenceEquals(path, _path)) {
                    _flushedVersion = version;
                }
            }
        }
    }

    public byte[] Save(CompressionType compression = CompressionType.Zstd) => Save(compression, out _);

    /// <param name="version">What the returned file holds, as of <see cref="_version"/>.</param>
    private byte[] Save(CompressionType compression, out long version) {
        DataWriter payload = new();
        payload.WriteByte(MinSection);
        payload.WriteByte(MaxSection);

        lock (_lock) {
            version = _version;
            payload.WritePrefixedArray(_userData, (b, w) => w.Write(b));
            payload.WriteVarInt(_records.Count);
            foreach (byte[] record in _records.Values) {
                payload.Write(record);
            }
        }

        byte[] raw = payload.ToArray();

        DataWriter writer = new();
        writer.WriteInteger(MagicNumber);
        writer.WriteShort(LatestVersion);
        writer.WriteVarInt(DataVersion);
        writer.WriteByte((int)compression);
        writer.WriteVarInt(raw.Length);
        writer.Write(compression == CompressionType.Zstd ? CompressZstd(raw) : raw);
        return writer.ToArray();
    }

    private void Load(byte[] data) {
        DataReader reader = new(data);

        if (reader.ReadInteger() != MagicNumber) {
            throw new InvalidDataException("Invalid magic number for Polar data.");
        }

        short version = reader.ReadShort();
        if (version > LatestVersion) {
            throw new InvalidDataException(
                $"Unsupported Polar version: {version}. Latest supported version is {LatestVersion}.");
        }

        reader.ReadVarInt();  // Data version

        CompressionType compression = (CompressionType)reader.ReadByte();
        int rawLength = reader.ReadVarInt();

        if (compression == CompressionType.Zstd) {
            DecompressZstd(reader, rawLength);
        }

        MinSection = reader.ReadByte();
        MaxSection = reader.ReadByte();
        if (MinSection >= MaxSection) {
            throw new InvalidDataException($"Invalid section range: {MinSection} to {MaxSection}.");
        }

        _userData = reader.ReadPrefixedArray(r => r.Read());

        int chunkCount = reader.ReadVarInt();
        for (int i = 0; i < chunkCount; i++) {
            int start = (int)reader.Position;
            int chunkX = reader.ReadVarInt();
            int chunkZ = reader.ReadVarInt();
            reader.Position = start;

            PolarChunkCodec.Skip(reader, SectionCount);

            int end = (int)reader.Position;
            reader.Position = start;
            _records[new Vec2<int>(chunkX, chunkZ)] = reader.Read(end - start);
        }
    }

    private static void DecompressZstd(DataReader reader, int length) {
        using Decompressor decompressor = new();
        byte[] output = new byte[length];
        int count = decompressor.Unwrap(reader.ReadRemaining(), output);
        if (count > length) {
            throw new InvalidDataException($"Decompressed data length {count} exceeds expected length {length}.");
        }

        Array.Resize(ref output, count);
        reader.Position = 0;
        reader.UpdateData(output);
    }

    private static byte[] CompressZstd(ReadOnlySpan<byte> data) {
        using Compressor compressor = new();
        return compressor.Wrap(data).ToArray();
    }

    public void Dispose() { }

    public enum CompressionType : sbyte {
        None = 0,
        Zstd = 1
    }
}
