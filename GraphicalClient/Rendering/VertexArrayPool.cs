using System.Collections.Concurrent;
using System.Numerics;

namespace GraphicalClient.Rendering;

/// <summary>
/// Vertex arrays rented by the meshers and returned by the game thread once uploaded, in power of two
/// lengths. Not <c>ArrayPool.Shared</c>: returning to it takes a lock a mesher may be holding.
/// </summary>
internal sealed class VertexArrayPool {
    private const int MinShift = 8;
    private const int MaxShift = 20;

    /// <summary>What a bucket may hold before returned arrays are left to the collector.</summary>
    private const long BucketBytes = 8 << 20;

    private readonly ConcurrentQueue<BlockVertex[]>[] _buckets =
        Enumerable.Range(0, MaxShift - MinShift + 1).Select(_ => new ConcurrentQueue<BlockVertex[]>()).ToArray();

    public BlockVertex[] Rent(int length) {
        if (length == 0) {
            return [];
        }
        int shift = Math.Max(MinShift, BitOperations.Log2((uint)length - 1) + 1);
        if (shift > MaxShift) {
            return new BlockVertex[length];
        }
        return _buckets[shift - MinShift].TryDequeue(out BlockVertex[]? array) ? array : new BlockVertex[1 << shift];
    }

    public void Return(BlockVertex[] array) {
        if (array.Length == 0 || !BitOperations.IsPow2(array.Length)) {
            return;
        }
        int shift = BitOperations.Log2((uint)array.Length);
        if (shift is < MinShift or > MaxShift) {
            return;
        }
        ConcurrentQueue<BlockVertex[]> bucket = _buckets[shift - MinShift];
        if ((long)bucket.Count * array.Length * BlockVertex.Size < BucketBytes) {
            bucket.Enqueue(array);
        }
    }
}
