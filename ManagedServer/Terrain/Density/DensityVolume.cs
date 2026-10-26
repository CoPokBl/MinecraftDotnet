using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// A regular grid of block positions a sampler fills in one call, vanilla's <c>DensityVolume</c>.
/// </summary>
/// <remarks>
/// Buffers are indexed y fastest, then x, then z. Equality is over all nine fields, and a cache treats
/// two volumes as the same only when it holds, so a volume built with a different step over the same
/// blocks is a miss.
/// </remarks>
public readonly record struct DensityVolume {
    public const int NoBlock = -1;

    public DensityVolume(int sizeX, int sizeY, int sizeZ, int minBlockX, int minBlockY, int minBlockZ,
        int stepBlockX = 1, int stepBlockY = 1, int stepBlockZ = 1) {

        if (sizeX <= 0 || sizeY <= 0 || sizeZ <= 0) {
            throw new ArgumentException($"Size must be positive, was: {sizeX}x{sizeY}x{sizeZ}");
        }

        if (stepBlockX <= 0 || stepBlockY <= 0 || stepBlockZ <= 0) {
            throw new ArgumentException($"Step must be positive, was: {stepBlockX}; {stepBlockY}; {stepBlockZ}");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        SizeZ = sizeZ;
        MinBlockX = minBlockX;
        MinBlockY = minBlockY;
        MinBlockZ = minBlockZ;
        StepBlockX = stepBlockX;
        StepBlockY = stepBlockY;
        StepBlockZ = stepBlockZ;
    }

    public int SizeX { get; }
    public int SizeY { get; }
    public int SizeZ { get; }
    public int MinBlockX { get; }
    public int MinBlockY { get; }
    public int MinBlockZ { get; }
    public int StepBlockX { get; }
    public int StepBlockY { get; }
    public int StepBlockZ { get; }

    public int IndexUnchecked(int indexX, int indexY, int indexZ) {
        return indexY + (indexX + indexZ * SizeX) * SizeY;
    }

    public int BlockX(int x) => MinBlockX + x * StepBlockX;

    public int BlockY(int y) => MinBlockY + y * StepBlockY;

    public int BlockZ(int z) => MinBlockZ + z * StepBlockZ;

    public int MaxBlockX => MinBlockX + SizeX * StepBlockX - 1;

    public int MaxBlockY => MinBlockY + SizeY * StepBlockY - 1;

    public int MaxBlockZ => MinBlockZ + SizeZ * StepBlockZ - 1;

    public int Size => SizeX * SizeY * SizeZ;

    public bool Intersects(int minX, int minY, int minZ, int maxX, int maxY, int maxZ) {
        return maxX >= MinBlockX && minX <= MaxBlockX
            && maxZ >= MinBlockZ && minZ <= MaxBlockZ
            && maxY >= MinBlockY && minY <= MaxBlockY;
    }

    private bool ContainsBlockRelative(int relativeX, int relativeY, int relativeZ) {
        return relativeX >= 0 && relativeY >= 0 && relativeZ >= 0
            && relativeX < SizeX * StepBlockX && relativeY < SizeY * StepBlockY && relativeZ < SizeZ * StepBlockZ
            && Mth.FloorMod(relativeX, StepBlockX) == 0
            && Mth.FloorMod(relativeY, StepBlockY) == 0
            && Mth.FloorMod(relativeZ, StepBlockZ) == 0;
    }

    /// <summary>The buffer index of a block, or <see cref="NoBlock"/> when the grid does not land on it.</summary>
    public int IndexOfBlock(int blockX, int blockY, int blockZ) {
        int relativeX = blockX - MinBlockX;
        int relativeY = blockY - MinBlockY;
        int relativeZ = blockZ - MinBlockZ;

        if (StepBlockX == 1 && StepBlockY == 1 && StepBlockZ == 1) {
            if (relativeX >= 0 && relativeY >= 0 && relativeZ >= 0 && relativeX < SizeX && relativeY < SizeY && relativeZ < SizeZ) {
                return IndexUnchecked(relativeX, relativeY, relativeZ);
            }
        } else if (ContainsBlockRelative(relativeX, relativeY, relativeZ)) {
            return IndexUnchecked(
                Mth.FloorDiv(relativeX, StepBlockX), Mth.FloorDiv(relativeY, StepBlockY), Mth.FloorDiv(relativeZ, StepBlockZ));
        }

        return NoBlock;
    }
}

/// <summary>The float values of one <see cref="DensityVolume"/>, vanilla's <c>DensityBuffer</c>.</summary>
public class DensityBuffer {
    protected readonly float[] Values;

    protected DensityBuffer(int capacity, int size) {
        Values = new float[capacity];
        Size = size;
    }

    public static DensityBuffer CreateUnpooled(int size) => new(size, size);

    public int Size { get; protected set; }

    public int Capacity => Values.Length;

    public float this[int index] {
        get => Values[index];
        set => Values[index] = value;
    }

    public void SetRange(int index, int size, float value) {
        Array.Fill(Values, value, index, size);
    }

    public void AddTo(int index, float value) {
        Values[index] += value;
    }

    public void Fill(float value) {
        Array.Fill(Values, value, 0, Size);
    }

    public void CopyFrom(DensityBuffer other) {
        if (Size != other.Size) {
            throw new ArgumentException($"Cannot copy from buffer with size={other.Size}, expected{Size}");
        }

        Array.Copy(other.Values, Values, Size);
    }
}

/// <summary>
/// A buffer borrowed from an arena and returned to it on dispose, vanilla's <c>ScopedDensityBuffer</c>.
/// </summary>
public sealed class ScopedDensityBuffer : DensityBuffer, IDisposable {
    private readonly IDensityBufferArena _arena;
    private int _age;
    private bool _closed;

    internal ScopedDensityBuffer(IDensityBufferArena arena, int capacity, int size) : base(capacity, size) {
        _arena = arena;
    }

    internal void Restore(int size) {
        if (size > Values.Length) {
            throw new ArgumentException("Cannot set size larger than buffer capacity");
        }

        if (!_closed) {
            throw new ArgumentException("Buffer is already in use");
        }

        _age = 0;
        _closed = false;
        Size = size;
    }

    internal int IncrementAge() => ++_age;

    public void Dispose() {
        if (!_closed) {
            _closed = true;
            _arena.Release(this);
        }
    }
}

/// <summary>Where samplers get their scratch buffers, vanilla's <c>DensityBufferArena</c>.</summary>
public interface IDensityBufferArena {
    /// <summary>Allocates every buffer fresh and drops it on release.</summary>
    static readonly IDensityBufferArena Global = new GlobalArena();

    ScopedDensityBuffer Acquire(int size);

    void Release(ScopedDensityBuffer buffer);

    private sealed class GlobalArena : IDensityBufferArena {
        public ScopedDensityBuffer Acquire(int size) => new(this, size, size);

        public void Release(ScopedDensityBuffer buffer) { }
    }
}

/// <summary>
/// Reuses released buffers of a close enough capacity, vanilla's <c>DensityBufferPool</c>. Not thread
/// safe: one pool belongs to one chunk being generated.
/// </summary>
public sealed class DensityBufferPool(int maxAge) : IDensityBufferArena {
    private const int BufferSizeIncrement = 16;
    private const int MaxReuseSizeFactor = 2;

    private readonly List<ScopedDensityBuffer> _buffers = [];

    public ScopedDensityBuffer Acquire(int size) {
        int roundedMinSize = Mth.PositiveCeilDiv(size, BufferSizeIncrement) * BufferSizeIncrement;
        ScopedDensityBuffer? buffer = TryTakeBest(roundedMinSize, roundedMinSize * MaxReuseSizeFactor);
        if (buffer == null) {
            return new ScopedDensityBuffer(this, roundedMinSize, size);
        }

        buffer.Restore(size);
        return buffer;
    }

    private ScopedDensityBuffer? TryTakeBest(int minCapacity, int maxCapacity) {
        int bestIndex = -1;
        int bestCapacity = maxCapacity + 1;

        for (int i = _buffers.Count - 1; i >= 0; i--) {
            int capacity = _buffers[i].Capacity;
            if (capacity == minCapacity) {
                ScopedDensityBuffer exact = _buffers[i];
                _buffers.RemoveAt(i);
                return exact;
            }

            if (capacity > minCapacity && capacity < bestCapacity) {
                bestIndex = i;
                bestCapacity = capacity;
            }
        }

        if (bestIndex == -1) {
            return null;
        }

        ScopedDensityBuffer best = _buffers[bestIndex];
        _buffers.RemoveAt(bestIndex);
        return best;
    }

    public void Release(ScopedDensityBuffer buffer) {
        _buffers.Add(buffer);
    }

    public void GarbageCollect() {
        _buffers.RemoveAll(buffer => buffer.IncrementAge() > maxAge);
    }

    public void Clear() {
        _buffers.Clear();
    }

    public bool IsEmpty => _buffers.Count == 0;
}
