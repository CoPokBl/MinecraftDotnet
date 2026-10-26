namespace ManagedServer.Terrain.Density;

/// <summary>
/// A compiled density function, vanilla's <c>DensitySampler</c>.
/// </summary>
/// <remarks>
/// The two paths are not interchangeable. Interpolation, the short circuits in <c>min</c>, <c>max</c>,
/// <c>mul</c> and <c>div</c>, and the noise volume fill all round differently between them, and the
/// terrain fill reads the volume path. Port both exactly.
/// </remarks>
public interface IDensitySampler {
    void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume);

    float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ);

    /// <summary><c>DensitySampler.sampleVolumeNaive</c>: the point path at every position of the volume.</summary>
    static void SampleVolumeNaive(SamplerContext context, DensityBuffer output, DensityVolume volume, IDensitySampler sampler) {
        int index = 0;
        for (int z = 0; z < volume.SizeZ; z++) {
            int blockZ = volume.BlockZ(z);
            for (int x = 0; x < volume.SizeX; x++) {
                int blockX = volume.BlockX(x);
                for (int y = 0; y < volume.SizeY; y++) {
                    output[index++] = sampler.SampleValue(context, blockX, volume.BlockY(y), blockZ);
                }
            }
        }
    }
}

/// <summary>A sampler and the context it runs in, vanilla's <c>DensitySampler.Bound</c>.</summary>
public readonly record struct BoundSampler(IDensitySampler Sampler, SamplerContext Context) {
    public float SampleValue(int blockX, int blockY, int blockZ) => Sampler.SampleValue(Context, blockX, blockY, blockZ);

    public void SampleVolume(DensityBuffer output, DensityVolume volume) => Sampler.SampleVolume(Context, output, volume);

    /// <summary>Samples into a buffer borrowed from the context, which the caller disposes.</summary>
    public ScopedDensityBuffer SampleVolume(DensityVolume volume) {
        ScopedDensityBuffer buffer = Context.AcquireBuffer(volume);
        SampleVolume(buffer, volume);
        return buffer;
    }
}

/// <summary>A typed key for a value a <see cref="SamplerContext"/> carries, vanilla's <c>ContextKey</c>.</summary>
public sealed class SamplerContextKey<T>(string name) where T : class {
    public override string ToString() => name;
}

/// <summary>
/// What a sampler runs against, vanilla's <c>SamplerContext</c>: the values the samplers read from
/// outside the tree, where buffers come from, and, when enabled, the cache cells.
/// </summary>
/// <remarks>
/// A cache cell holds the last volume and the last point it sampled. A point lookup returns the point
/// if it is the same one, then the volume's value if the point lies on that volume's grid, and only
/// then samples. Because the two paths round differently, which of those answers a lookup gets depends
/// on what was sampled before it, and a port that only caches values gets different terrain.
/// </remarks>
public sealed class SamplerContext {
    private const int CacheSizeStep = 16;

    public static readonly SamplerContext EmptyUncached = new(new Dictionary<object, object>(), IDensityBufferArena.Global, false);

    private readonly IReadOnlyDictionary<object, object> _fields;
    private readonly IDensityBufferArena _arena;
    private CacheCell[]? _cacheCells;

    private SamplerContext(IReadOnlyDictionary<object, object> fields, IDensityBufferArena arena, bool enableCaches) {
        _fields = fields;
        _arena = arena;
        _cacheCells = enableCaches ? [] : null;
    }

    public static Builder CreateBuilder() => new();

    public T? GetField<T>(SamplerContextKey<T> key) where T : class {
        return _fields.TryGetValue(key, out object? value) ? (T)value : null;
    }

    public ScopedDensityBuffer AcquireBuffer(DensityVolume volume) => _arena.Acquire(volume.Size);

    private CacheCell? GetCacheCell(int cacheId) {
        if (_cacheCells == null) {
            return null;
        }

        int oldSize = _cacheCells.Length;
        if (cacheId >= oldSize) {
            int newSize = (cacheId + 1 + CacheSizeStep - 1) / CacheSizeStep * CacheSizeStep;
            Array.Resize(ref _cacheCells, newSize);
            for (int i = oldSize; i < newSize; i++) {
                _cacheCells[i] = new CacheCell();
            }
        }

        return _cacheCells[cacheId];
    }

    internal void SampleVolumeCached(int cacheId, IDensitySampler input, DensityBuffer output, DensityVolume volume) {
        CacheCell? cell = GetCacheCell(cacheId);
        if (cell == null) {
            input.SampleVolume(this, output, volume);
            return;
        }

        if (cell.Buffer == null || volume != cell.Volume) {
            cell.Buffer?.Dispose();
            cell.Volume = volume;
            cell.Buffer = AcquireBuffer(volume);
            input.SampleVolume(this, cell.Buffer, volume);
        }

        output.CopyFrom(cell.Buffer);
    }

    internal float SampleValueCached(int cacheId, IDensitySampler input, int blockX, int blockY, int blockZ) {
        CacheCell? cell = GetCacheCell(cacheId);
        if (cell == null) {
            return input.SampleValue(this, blockX, blockY, blockZ);
        }

        long cacheKey = BlockPosKey(blockX, blockY, blockZ);
        if (cell.ValueKey == cacheKey && !float.IsNaN(cell.Value)) {
            return cell.Value;
        }

        if (cell.Buffer != null && cell.Volume is { } cachedVolume) {
            int index = cachedVolume.IndexOfBlock(blockX, blockY, blockZ);
            if (index != DensityVolume.NoBlock) {
                return cell.Buffer[index];
            }
        }

        float value = input.SampleValue(this, blockX, blockY, blockZ);
        cell.ValueKey = cacheKey;
        cell.Value = value;
        return value;
    }

    /// <summary><c>BlockPos.asLong</c>. A position outside its 26/12/26 bit packing aliases another, as upstream.</summary>
    private static long BlockPosKey(int x, int y, int z) {
        return ((long)x & 0x3FFFFFF) << 38 | ((long)z & 0x3FFFFFF) << 12 | ((long)y & 0xFFF);
    }

    public sealed class Builder {
        private readonly Dictionary<object, object> _fields = new();
        private IDensityBufferArena _arena = IDensityBufferArena.Global;
        private bool _enableCaches;

        public Builder With<T>(SamplerContextKey<T> key, T? value) where T : class {
            if (value != null) {
                _fields[key] = value;
            }

            return this;
        }

        public Builder UseBufferArena(IDensityBufferArena arena) {
            _arena = arena;
            return this;
        }

        public Builder EnableCaches() {
            _enableCaches = true;
            return this;
        }

        public SamplerContext Build() => new(_fields, _arena, _enableCaches);
    }

    private sealed class CacheCell {
        public DensityVolume? Volume;
        public ScopedDensityBuffer? Buffer;
        public long ValueKey;
        public float Value = float.NaN;
    }
}

/// <summary>The sampler for one deduplicated <c>cache</c> node, vanilla's <c>CachingDensitySampler</c>.</summary>
public sealed record CachingDensitySampler(int Id, IDensitySampler Input) : IDensitySampler {
    public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
        context.SampleVolumeCached(Id, Input, output, volume);
    }

    public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
        return context.SampleValueCached(Id, Input, blockX, blockY, blockZ);
    }
}

/// <summary>
/// A sampler the context supplies, or a fallback when it does not, vanilla's <c>ContextBoundSampler</c>.
/// This is how the beardifier and the blender reach into a tree parsed from data.
/// </summary>
public sealed record ContextBoundSampler(SamplerContextKey<IDensitySampler> Key, IDensitySampler Fallback) : IDensitySampler {
    public void SampleVolume(SamplerContext context, DensityBuffer output, DensityVolume volume) {
        (context.GetField(Key) ?? Fallback).SampleVolume(context, output, volume);
    }

    public float SampleValue(SamplerContext context, int blockX, int blockY, int blockZ) {
        return (context.GetField(Key) ?? Fallback).SampleValue(context, blockX, blockY, blockZ);
    }
}
