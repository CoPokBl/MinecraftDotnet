using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Storage;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Implementations.AnvilWorld;

/// <summary>
/// A world directory in the Anvil format, read and written.
/// </summary>
/// <remarks>
/// Keep in mind that worlds that are outdated may not load properly.
/// If you are missing chunks then try loading the world in a newer version of Minecraft
/// and trying again.
/// <p/>
/// This is a world directory: <c>level</c> beside a <c>region</c> folder. A consumer that wants the
/// format somewhere else pairs <see cref="AnvilChunkCodec"/> with a different
/// <see cref="IChunkBlobStore"/>, and one that wants a different format in a region directory pairs a
/// different codec with <see cref="AnvilRegionBlobStore"/>.
/// </remarks>
public class AnvilLoader : ITerrainStore, IDisposable {
    private readonly AnvilRegionBlobStore _regions;
    private readonly AnvilChunkCodec _codec;
    private readonly int _minY;

    public AnvilWorldInfo? WorldInfo { get; private init; }

    /// <param name="minY">
    /// The lowest block y of the world these chunks belong to. Anvil numbers its sections from the
    /// world's floor, so this decides which section of the file a stored one is.
    /// </param>
    /// <param name="writable">
    /// Whether saving into this directory is allowed. Off by default: opening someone's world to look
    /// at it should not be able to write to it.
    /// </param>
    public AnvilLoader(string path, MinecraftRegistry registry, int minY = -64, bool writable = false) {
        if (minY % 16 != 0) {
            throw new ArgumentException("minY must be a multiple of 16.", nameof(minY));
        }

        _minY = minY;
        _codec = new AnvilChunkCodec(registry);

        string levelDatPath = Path.Join(path, "level");
        if (File.Exists(levelDatPath)) {
            WorldInfo = ReadWorldInfo(File.ReadAllBytes(levelDatPath));
        }

        string regionPath = Path.Join(path, "region");
        if (!writable && !Directory.Exists(regionPath)) {
            throw new Exception("Invalid world: region directory not found.");
        }

        _regions = new AnvilRegionBlobStore(regionPath, writable);
    }

    private static AnvilWorldInfo ReadWorldInfo(byte[] data) {
        if (NbtReader.ReadNbt(data, true) is not CompoundTag levelDataRoot) {
            throw new Exception("Invalid world: level.dat does not contain a valid CompoundTag.");
        }

        CompoundTag levelData = levelDataRoot[""].ThrowIfNull().GetCompound()["Data"].ThrowIfNull()
            as CompoundTag ?? throw new InvalidOperationException();

        return new AnvilWorldInfo(
            Hardcore: levelData["hardcore"].ThrowIfNull().GetBoolean(),
            Raining: levelData["raining"].ThrowIfNull().GetBoolean(),
            Thundering: levelData["thundering"].ThrowIfNull().GetBoolean(),
            GameType: levelData["GameType"].ThrowIfNull().GetInteger(),
            RainTicks: levelData["rainTime"].ThrowIfNull().GetInteger(),
            Spawn: new Vec3<int>(levelData["SpawnX"].ThrowIfNull().GetInteger(),
                levelData["SpawnY"].ThrowIfNull().GetInteger(),
                levelData["SpawnZ"].ThrowIfNull().GetInteger()),
            ThunderTicks: levelData["thunderTime"].ThrowIfNull().GetInteger(),
            Version: levelData["version"].ThrowIfNull().GetInteger(),
            LastPlayed: levelData["LastPlayed"].ThrowIfNull().GetLong(),
            Time: levelData["Time"].ThrowIfNull().GetLong(),
            LevelName: levelData["LevelName"].ThrowIfNull().GetString());
    }

    public bool TryGetChunk(ref ChunkData chunk) {
        Vec2<int> pos = new(chunk.ChunkX, chunk.ChunkZ);
        if (!_regions.TryRead(pos, out byte[] data)) {
            return false;
        }

        // The loader's own floor rather than the chunk's, so a chunk asked for through GetAllChunks,
        // which has nothing to stamp one from, still lands its sections where they belong.
        chunk = _codec.Decode(new DataReader(data), new ChunkCodecContext {
            Position = pos,
            WorldHeight = chunk.WorldHeight,
            MinY = _minY
        });

        return true;
    }

    public void GetChunk(ref ChunkData data) {
        TryGetChunk(ref data);
    }

    public void GetChunks(int start, int count, ChunkData[] chunks) {
        for (int i = start; i < start + count; i++) {
            GetChunk(ref chunks[i]);
        }
    }

    public void PutChunk(ChunkData chunk) {
        DataWriter writer = new();
        _codec.Encode(chunk, writer);
        _regions.Write(new Vec2<int>(chunk.ChunkX, chunk.ChunkZ), writer.AsSpan());
    }

    public void DeleteChunk(Vec2<int> pos) => _regions.Delete(pos);

    public void Flush() => _regions.Flush();

    public IEnumerable<Vec2<int>> EnumerateChunks() => _regions.EnumerateChunks();

    /// <summary>
    /// Every chunk in the world, decoded. A whole world at once, so it is for converting one rather
    /// than for serving it.
    /// </summary>
    public ChunkData[] GetAllChunks() {
        List<ChunkData> chunks = [];
        foreach (Vec2<int> pos in _regions.EnumerateChunks()) {
            ChunkData chunk = new(ChunkData.VanillaOverworldHeight) {
                ChunkX = pos.X,
                ChunkZ = pos.Y,
                MinY = _minY
            };

            if (TryGetChunk(ref chunk)) {
                chunks.Add(chunk);
            }
        }

        return chunks.ToArray();
    }

    public record AnvilWorldInfo(
        bool Hardcore,
        bool Raining,
        bool Thundering,
        int GameType,
        int RainTicks,
        Vec3<int> Spawn,
        int ThunderTicks,
        int Version,
        long LastPlayed,
        long Time,
        string LevelName);

    public void Dispose() {
        _regions.Dispose();
        GC.SuppressFinalize(this);
    }
}
