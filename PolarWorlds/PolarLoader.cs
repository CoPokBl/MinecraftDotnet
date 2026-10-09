using Minecraft;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Storage;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace PolarWorlds;

/// <summary>
/// A Polar map held in memory and served as terrain.
/// </summary>
/// <remarks>
/// Every chunk is decoded when the file is opened, because <see cref="Chunks"/> hands them all out.
/// A map that would rather decode a chunk when something asks for it uses <see cref="PolarBundle"/>
/// with a <see cref="CodecTerrainStore"/> instead, which is the same format either way.
/// </remarks>
public class PolarLoader : ITerrainStore {
    /// <summary>
    /// The decoded map. Reads and writes from outside this class are not guarded by anything, so they
    /// must not overlap a world loading from or saving into this loader.
    /// </summary>
    public Dictionary<Vec2<int>, ChunkData> Chunks = null!;

    private readonly MinecraftRegistry _registry;
    private readonly PolarChunkCodec _codec;
    private PolarBundle _bundle = null!;

    /// <summary>
    /// Guards <see cref="Chunks"/> and keeps it in step with the bundle. A world loads chunks on
    /// several threads at once and saves on several more, and a <see cref="Dictionary{TKey,TValue}"/>
    /// written concurrently can corrupt itself rather than merely lose a write.
    /// </summary>
    private readonly object _lock = new();

    public PolarLoader(string path, MinecraftRegistry registry) : this(File.ReadAllBytes(path), registry) { }

    public PolarLoader(byte[] data, MinecraftRegistry registry) {
        _registry = registry;
        _codec = new PolarChunkCodec(registry);
        Load(data);
    }

    public static byte[] CreateWorld(AnvilLoader anvilWorld) {
        ChunkData[] chunks = anvilWorld.GetAllChunks();
        if (chunks.Length == 0) {
            throw new InvalidOperationException("No chunks found in the Anvil world.");
        }

        return CreateWorld(chunks);
    }

    public static byte[] CreateWorld(ChunkData[] chunks, MinecraftRegistry? registry = null) {
        registry ??= VanillaRegistry.Data;

        PolarBundle bundle = new(chunks[0].WorldHeight, chunks[0].MinY);
        CodecTerrainStore store = new(new PolarChunkCodec(registry), bundle);
        foreach (ChunkData chunk in chunks) {
            store.PutChunk(chunk);
        }

        return bundle.Save();
    }

    public void Load(byte[] data) {
        PolarBundle bundle = new(data);

        Dictionary<Vec2<int>, ChunkData> chunks = [];
        foreach (Vec2<int> pos in bundle.EnumerateChunks()) {
            if (!bundle.TryRead(pos, out byte[] record)) {
                continue;
            }

            chunks[pos] = _codec.Decode(new DataReader(record), new ChunkCodecContext {
                Position = pos,
                WorldHeight = bundle.WorldHeight,
                MinY = bundle.MinY
            });
        }

        lock (_lock) {
            _bundle = bundle;
            Chunks = chunks;
        }
    }

    /// <summary>
    /// Called for a chunk the file does not contain, which is left empty. Off by default, because a
    /// map smaller than a player's view distance is the normal case rather than an error: a four
    /// chunk lobby at view distance eight is asked for 289 and answers 285 of them with nothing.
    /// Logging that unconditionally put hundreds of writes, on the joining thread and under the
    /// console lock, in the middle of every join.
    /// </summary>
    public Action<Vec2<int>>? MissingChunk { get; set; }

    public bool TryGetChunk(ref ChunkData chunk) {
        Vec2<int> pos = new(chunk.ChunkX, chunk.ChunkZ);

        ChunkData? data;
        lock (_lock) {
            Chunks.TryGetValue(pos, out data);
        }

        if (data == null) {
            MissingChunk?.Invoke(pos);
            return false;
        }

        chunk = data.Clone();
        return true;
    }

    public void GetChunk(ref ChunkData chunk) {
        TryGetChunk(ref chunk);
    }

    public void GetChunks(int start, int count, ChunkData[] chunks) {
        for (int i = start; i < start + count; i++) {
            Vec2<int> pos = new(chunks[i].ChunkX, chunks[i].ChunkZ);

            ChunkData? data;
            lock (_lock) {
                Chunks.TryGetValue(pos, out data);
            }

            if (data != null) {
                chunks[i] = data;
            } else {
                MissingChunk?.Invoke(pos);
            }
        }
    }

    public void PutChunk(ChunkData chunk) {
        Vec2<int> pos = new(chunk.ChunkX, chunk.ChunkZ);

        // Encoded outside the lock so saves still run in parallel, and stored under it so the map and
        // the bundle agree on which of two writes to the same chunk won.
        DataWriter writer = new();
        _codec.Encode(chunk, writer);

        lock (_lock) {
            Chunks[pos] = chunk;
            _bundle.Write(pos, writer.AsSpan());
        }
    }

    public void DeleteChunk(Vec2<int> pos) {
        lock (_lock) {
            Chunks.Remove(pos);
            _bundle.Delete(pos);
        }
    }

    /// <summary>The whole map as a Polar file, with everything <see cref="PutChunk"/> has taken.</summary>
    public byte[] Save() => _bundle.Save();

    public void Flush() => _bundle.Flush();

    public static int GetXFromIndex(int index) {
        return index & 0xF;  // 0-3 bits
    }

    public static int GetYFromIndex(int index) {
        int y = (index & 0x07FFFFF0) >>> 4;
        if ((index & 0x08000000) != 0) y = -y;  // bit 28 indicates negative Y
        return y;  // 4-28 bits
    }

    public static int GetZFromIndex(int index) {
        return (index >>> 28) & 0xF;  // bits 28-31
    }

    public static int GetIndexFromCoords(int x, int y, int z) {
        if (x < 0 || x > 15 || y < -2048 || y > 2047 || z < 0 || z > 15) {
            throw new ArgumentOutOfRangeException(nameof(x), "Coordinates out of range for Polar chunk indexing.");
        }

        int index = 0;
        index |= x & 0xF;  // 0-3 bits for X
        index |= (z & 0xF) << 28;
        if (y < 0) {
            index |= 0x08000000;  // Set bit 28 if Y is negative
            index |= ((-y) << 4) & 0x07FFFFF0;  // 4-28 bits for Y, shifted left by 4
        }
        else {
            index |= (y << 4) & 0x07FFFFF0;  // 4-28 bits for Y, shifted left by 4
        }

        return index;
    }
}
