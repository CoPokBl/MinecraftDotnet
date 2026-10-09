using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Storage;

/// <summary>
/// Where an encoded chunk's bytes live. The other half of storage from <see cref="IChunkCodec"/>.
/// </summary>
/// <remarks>
/// Keyed by chunk position rather than by an opaque key, because every layout that exists groups by
/// it: a region file is thirty two by thirty two, a directory is one file per chunk, a bundle is one
/// file for all of them.
/// <p/>
/// Implementations are called from several threads at once and must be safe against that. A write
/// must be atomic against a concurrent read of the same position: a reader either sees the whole
/// previous value or the whole new one, never half a file.
/// </remarks>
public interface IChunkBlobStore : IDisposable {
    public bool TryRead(Vec2<int> pos, out byte[] data);

    public void Write(Vec2<int> pos, ReadOnlySpan<byte> data);

    public void Delete(Vec2<int> pos);

    /// <summary>
    /// Makes everything written so far durable. A store that batches in memory writes here and
    /// nowhere else, so a save that never flushes is a save that never happened.
    /// </summary>
    public void Flush();

    /// <summary>Every position this store holds something for.</summary>
    public IEnumerable<Vec2<int>> EnumerateChunks();
}
