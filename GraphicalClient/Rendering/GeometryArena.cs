using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// One GPU buffer holding every section's vertices, handed out in ranges. Keeping all terrain in one
/// buffer is what lets a whole pass be one indirect draw: commands differ only by base vertex.
/// <p/>
/// Ranges come from a first fit free list that merges neighbours as they are freed. When nothing
/// fits the buffer grows and its contents are copied across on the GPU, so offsets already handed
/// out stay valid.
/// </summary>
public sealed unsafe class GeometryArena : IDisposable {
    private readonly GL _gl;
    private readonly int _stride;
    private readonly UploadRing _uploads;
    private readonly List<(int Offset, int Size)> _free = [];
    private static readonly Comparer<(int Offset, int Size)> ByOffset = Comparer<(int Offset, int Size)>.Create((a, b) => a.Offset.CompareTo(b.Offset));

    public uint Buffer { get; private set; }

    /// <summary>Capacity in elements.</summary>
    private int _capacity;

    /// <summary>Raised after the buffer is replaced by a larger one, so whoever binds it can rebind.</summary>
    public event Action? Grown;

    public GeometryArena(GL gl, UploadRing uploads, int stride, int initialCapacity) {
        _gl = gl;
        _uploads = uploads;
        _stride = stride;
        _capacity = initialCapacity;
        Buffer = Create(initialCapacity);
        _free.Add((0, initialCapacity));
    }

    private uint Create(int capacity) {
        uint buffer = _gl.CreateBuffer();
        // Not writable from the CPU, so the driver keeps it in video memory; writes come through the ring.
        _gl.NamedBufferStorage(buffer, (nuint)((long)capacity * _stride), null, BufferStorageMask.None);
        return buffer;
    }

    public int Allocate(int size) {
        for (int i = 0; i < _free.Count; i++) {
            (int offset, int free) = _free[i];
            if (free < size) {
                continue;
            }
            if (free == size) {
                _free.RemoveAt(i);
            }
            else {
                _free[i] = (offset + size, free - size);
            }
            return offset;
        }

        Grow(Math.Max(_capacity + size, _capacity * 3 / 2));
        return Allocate(size);
    }

    public void Free(int offset, int size) {
        int index = _free.BinarySearch((offset, size), ByOffset);
        index = index < 0 ? ~index : index;
        _free.Insert(index, (offset, size));

        if (index + 1 < _free.Count && _free[index].Offset + _free[index].Size == _free[index + 1].Offset) {
            _free[index] = (_free[index].Offset, _free[index].Size + _free[index + 1].Size);
            _free.RemoveAt(index + 1);
        }
        if (index > 0 && _free[index - 1].Offset + _free[index - 1].Size == _free[index].Offset) {
            _free[index - 1] = (_free[index - 1].Offset, _free[index - 1].Size + _free[index].Size);
            _free.RemoveAt(index);
        }
    }

    public void Upload<T>(int offset, ReadOnlySpan<T> data) where T : unmanaged {
        _uploads.Copy(data, Buffer, (long)offset * _stride);
    }

    private void Grow(int capacity) {
        uint larger = Create(capacity);
        _gl.CopyNamedBufferSubData(Buffer, larger, 0, 0, (nuint)((long)_capacity * _stride));
        _gl.DeleteBuffer(Buffer);
        Buffer = larger;

        if (_free.Count > 0 && _free[^1].Offset + _free[^1].Size == _capacity) {
            _free[^1] = (_free[^1].Offset, _free[^1].Size + capacity - _capacity);
        }
        else {
            _free.Add((_capacity, capacity - _capacity));
        }
        _capacity = capacity;
        Grown?.Invoke();
    }

    public void Dispose() => _gl.DeleteBuffer(Buffer);
}
