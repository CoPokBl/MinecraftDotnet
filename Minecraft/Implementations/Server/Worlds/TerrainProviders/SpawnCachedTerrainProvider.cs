using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Worlds.TerrainProviders;

/// <summary>
/// Caches an existing terrain provider.
/// If chunks change, you must tell us.
/// <p/>
/// WARNING: This will remove any optimisation brought from the <see cref="GetChunks"/> call.
/// </summary>
public class SpawnCachedTerrainProvider : ITerrainProvider {
    public ITerrainProvider Child { get; }
    public int Distance { get; }
    public ChunkPosition Center { get; }
    private readonly ChunkData[][] _cache;
    
    public SpawnCachedTerrainProvider(ITerrainProvider child, int distance = 32, ChunkPosition? center = null) {
        Child = child;
        Distance = distance;
        _cache = new ChunkData[distance * 2 + 1][];
        
        // Load spawn area
        Center = center ?? new ChunkPosition(0, 0);

        ChunkPosition[] chunks = new ChunkPosition[(distance * 2 + 1) * (distance * 2 + 1)];
        int i = 0;
        for (int x = 0; x < distance * 2 + 1; x++) {
            _cache[x] = new ChunkData[distance * 2 + 1];
            for (int z = 0; z < distance * 2 + 1; z++) {
                chunks[i++] = new ChunkPosition(x + Center.X - distance, z + Center.Z - distance);
            }
        }

        foreach (ChunkData data in Child.GetChunks(chunks.Length, chunks)) {
            _cache[data.ChunkX - Center.X + distance][data.ChunkZ - Center.Z + distance] = data;
        }
    }

    public ChunkData GetChunk(ChunkPosition chunk) {
        if (Distance >= Math.Abs(chunk.X - Center.X) && Distance >= Math.Abs(chunk.Z - Center.Z)) {
            return _cache[chunk.X - Center.X + Distance][chunk.Z - Center.Z + Distance];
        }
        
        return Child.GetChunk(chunk);
    }

    // this poses no optimisation, it removes any optimisation present.
    public IEnumerable<ChunkData> GetChunks(int count, params ChunkPosition[] poses) {
        ChunkData[] chunks = new ChunkData[count];
        for (int i = 0; i < count; i++) {
            chunks[i] = GetChunk(poses[i]);
        }

        return chunks;
    }
}