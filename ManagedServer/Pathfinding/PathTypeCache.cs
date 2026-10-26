using Minecraft.Data.Generated;

namespace ManagedServer.Pathfinding;

/// <summary>
/// A fixed size cache of what the classification made of a position, vanilla's
/// <c>PathTypeCache</c>.
/// <p/>
/// This caches by <b>position</b>, which <see cref="BlockPathData"/> cannot: it holds
/// <c>getPathTypeFromState</c>, and the thing being avoided is the block lookup rather than the
/// classification. One entry per slot with no chaining, so a collision simply evicts; vanilla
/// accepts that because a search hammers a few hundred positions over and over.
/// <p/>
/// Vanilla keeps one per level and invalidates on block change. Kept per world here for the same
/// reason.
/// </summary>
public class PathTypeCache {
    private const int Size = 4096;
    private const int Mask = 4095;

    private readonly long[] _positions = new long[Size];
    private readonly PathType?[] _pathTypes = new PathType?[Size];

    public PathType GetOrCompute(PathfindingContext context, int x, int y, int z) {
        long key = Key(x, y, z);
        int index = Index(key);

        if (_positions[index] == key && _pathTypes[index] is { } cached) {
            return cached;
        }

        PathType computed = context.ClassifyUncached(x, y, z);
        _positions[index] = key;
        _pathTypes[index] = computed;
        return computed;
    }

    public void Invalidate(int x, int y, int z) {
        long key = Key(x, y, z);
        int index = Index(key);

        if (_positions[index] == key) {
            _pathTypes[index] = null;
        }
    }

    public void Clear() {
        Array.Clear(_pathTypes);
        Array.Clear(_positions);
    }

    /// <summary><c>BlockPos.asLong</c>: 26 bits of x, 12 of y, 26 of z.</summary>
    private static long Key(int x, int y, int z) {
        return ((long)x & 0x3FFFFFF) << 38 | ((long)z & 0x3FFFFFF) << 12 | ((long)y & 0xFFF);
    }

    /// <summary>
    /// <c>HashCommon.mix</c>, fastutil's murmur finaliser. Vanilla indexes with exactly this, and a
    /// different hash would evict a different set of positions; that changes nothing about
    /// correctness but everything about which lookups are cheap.
    /// </summary>
    private static int Index(long key) {
        const ulong intPhi = 0x9E3779B97F4A7C15UL;
        ulong h = (ulong)key * intPhi;
        h ^= h >> 32;
        h ^= h >> 16;
        return (int)h & Mask;
    }
}
