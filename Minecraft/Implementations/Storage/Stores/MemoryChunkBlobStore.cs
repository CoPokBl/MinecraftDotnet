using System.Collections.Concurrent;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Storage.Stores;

/// <summary>
/// Encoded chunks held in memory. What a test round trips through, and what a world that is saved
/// once at the end rather than continuously writes into.
/// </summary>
public sealed class MemoryChunkBlobStore : IChunkBlobStore {
    private readonly ConcurrentDictionary<Vec2<int>, byte[]> _blobs = new();

    public int Count => _blobs.Count;

    public bool TryRead(Vec2<int> pos, out byte[] data) => _blobs.TryGetValue(pos, out data!);

    public void Write(Vec2<int> pos, ReadOnlySpan<byte> data) => _blobs[pos] = data.ToArray();

    public void Delete(Vec2<int> pos) => _blobs.TryRemove(pos, out _);

    public void Flush() { }

    public IEnumerable<Vec2<int>> EnumerateChunks() => _blobs.Keys;

    public void Dispose() { }
}
