using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Storage;

/// <summary>
/// A terrain store built from a format and a place to put it. Every combination of the two is one of
/// these: Anvil chunks in region files, Polar chunks in a bundle, either of them in memory for a test.
/// </summary>
public sealed class CodecTerrainStore(IChunkCodec codec, IChunkBlobStore blobs) : ITerrainStore, IDisposable {
    public IChunkCodec Codec { get; } = codec;
    public IChunkBlobStore Blobs { get; } = blobs;

    public bool TryGetChunk(ref ChunkData chunk) {
        Vec2<int> pos = new(chunk.ChunkX, chunk.ChunkZ);
        if (!Blobs.TryRead(pos, out byte[] data)) {
            return false;
        }

        // The decoded chunk replaces the one passed in rather than being copied into it, which is the
        // same bargain PolarLoader and AnvilLoader make and is why GetChunk takes a reference.
        chunk = Codec.Decode(new DataReader(data), ChunkCodecContext.Of(chunk));
        return true;
    }

    public void PutChunk(ChunkData chunk) {
        DataWriter writer = new();
        Codec.Encode(chunk, writer);
        Blobs.Write(new Vec2<int>(chunk.ChunkX, chunk.ChunkZ), writer.AsSpan());
    }

    public void DeleteChunk(Vec2<int> pos) => Blobs.Delete(pos);

    public void Flush() => Blobs.Flush();

    public IEnumerable<Vec2<int>> EnumerateChunks() => Blobs.EnumerateChunks();

    public void Dispose() => Blobs.Dispose();
}
