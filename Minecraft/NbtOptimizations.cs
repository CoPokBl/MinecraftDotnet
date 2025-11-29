using System.Buffers;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;
using NBT;
using NBT.Tags;

namespace Minecraft;

/// <summary>
/// Provides optimized NBT serialization/deserialization utilities
/// with caching and pooling to reduce allocations and improve performance.
/// </summary>
public static class NbtOptimizations {
    private const int MaxCacheSize = 10000;
    private const int PooledBufferSize = 8192;
    
    // Concurrent cache for thread-safe access without locks
    private static readonly ConcurrentDictionary<int, byte[]> _serializationCache = new();
    
    // ArrayPool for temporary buffers to reduce allocations
    private static readonly ArrayPool<byte> _bufferPool = ArrayPool<byte>.Shared;
    
    /// <summary>
    /// Serializes an NBT tag with caching for frequently used tags.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] SerializeWithCache(INbtTag tag) {
        // Simple hash based on object reference and serialized content
        int hash = tag.GetHashCode();
        
        // Fast path: check cache (thread-safe)
        if (_serializationCache.TryGetValue(hash, out byte[]? cached)) {
            return cached;
        }
        
        // Slow path: serialize and potentially cache
        byte[] serialized = tag.Serialise();
        
        // Only cache if not too large and cache isn't full
        if (serialized.Length < 2048 && _serializationCache.Count < MaxCacheSize) {
            _serializationCache.TryAdd(hash, serialized);
        }
        
        return serialized;
    }
    
    /// <summary>
    /// Clears the serialization cache. Useful for memory management.
    /// </summary>
    public static void ClearCache() {
        _serializationCache.Clear();
    }
    
    /// <summary>
    /// Gets cache statistics for monitoring.
    /// </summary>
    public static (int Size, int MaxSize) GetCacheStats() {
        return (_serializationCache.Count, MaxCacheSize);
    }
    

    
    /// <summary>
    /// Rents a buffer from the pool for temporary NBT operations.
    /// MUST be returned using ReturnBuffer after use.
    /// </summary>
    public static byte[] RentBuffer(int minimumSize = PooledBufferSize) {
        return _bufferPool.Rent(minimumSize);
    }
    
    /// <summary>
    /// Returns a rented buffer to the pool.
    /// </summary>
    public static void ReturnBuffer(byte[] buffer, bool clearArray = false) {
        _bufferPool.Return(buffer, clearArray);
    }
    
}
