using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Storage;

/// <summary>
/// A store in front of a generator: a chunk that has been saved comes back as it was left, and one
/// that has not is generated. This is what makes a world persistent without making it a fixed map.
/// </summary>
/// <remarks>
/// The generator is only consulted on a miss, so a saved chunk never regenerates and a change to the
/// generator never rewrites terrain a player has already seen. That cuts both ways: a saved world is
/// pinned to the generator it was made with, and pointing this at a different one leaves a seam
/// wherever the two meet.
/// </remarks>
public sealed class PersistentTerrainProvider(ITerrainStore store, ITerrainProvider generator)
    : ITerrainStore {

    private ITerrainHost? _host;

    public ITerrainStore Store { get; } = store;
    public ITerrainProvider Generator { get; } = generator;

    /// <summary>
    /// <c>false</c> when the chunk was generated rather than read back, which is what tells the world
    /// it holds terrain nothing has stored yet. That is the same state a block write leaves a chunk
    /// in, so a freshly generated chunk is saved by the next pass over changed chunks without anything
    /// having to ask for it.
    /// </summary>
    /// <remarks>
    /// A stored chunk that fails to read as damaged, which is an <see cref="IOException"/> or an
    /// <see cref="InvalidDataException"/>, is reported to the host and generated again, and the next
    /// save writes over it. That is <c>ChunkMap.handleChunkLoadFailure</c>, which does the same for an
    /// <c>IOException</c> or an <c>NbtException</c> and lets anything else crash the server. Anything
    /// else is let out here too, so a fault in a codec fails the load rather than replacing a world
    /// with fresh terrain.
    /// </remarks>
    public bool TryGetChunk(ref ChunkData chunk) {
        int chunkX = chunk.ChunkX, chunkZ = chunk.ChunkZ, worldHeight = chunk.WorldHeight, minY = chunk.MinY;

        try {
            if (Store.TryGetChunk(ref chunk)) {
                return true;
            }
        } catch (Exception e) when (e is IOException or InvalidDataException) {
            _host?.ReportError(new InvalidDataException(
                $"Stored chunk {chunkX}, {chunkZ} could not be read, so it is being generated again and " +
                "the next save will replace it.", e));

            chunk = new ChunkData(worldHeight) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = minY };
        }

        Generator.GetChunk(ref chunk);
        return false;
    }

    public void PutChunk(ChunkData chunk) => Store.PutChunk(chunk);

    public void DeleteChunk(Vec2<int> pos) => Store.DeleteChunk(pos);

    public void Flush() => Store.Flush();

    public void Attach(ITerrainHost host) {
        _host = host;
        Store.Attach(host);
        Generator.Attach(host);
    }
}
