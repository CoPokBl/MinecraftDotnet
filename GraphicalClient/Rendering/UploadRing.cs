using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// A persistently mapped buffer that data is written into and then copied out of on the GPU, so the
/// buffers it fills can be GPU only. Writing those directly needs them created writable from the
/// CPU, and the driver is then free to keep them in host memory, where every draw reads them over
/// the bus.
/// <p/>
/// Space is handed out in a ring. A fence at the end of each frame marks how far that frame wrote,
/// and a write that would reach space a frame still in flight is reading waits for that frame.
/// </summary>
public sealed unsafe class UploadRing : IDisposable {
    private readonly GL _gl;
    private readonly byte* _mapped;
    private readonly Queue<(nint Sync, long End)> _frames = new();
    private long _head;
    private long _tail;
    private long _fenced;

    public uint Buffer { get; }
    public int Size { get; }

    public UploadRing(GL gl, int size) {
        _gl = gl;
        Size = size;
        Buffer = gl.CreateBuffer();
        const BufferStorageMask flags = BufferStorageMask.MapWriteBit | BufferStorageMask.MapPersistentBit | BufferStorageMask.MapCoherentBit;
        gl.NamedBufferStorage(Buffer, (nuint)size, null, flags);
        _mapped = (byte*)gl.MapNamedBufferRange(Buffer, 0, (nuint)size,
            (uint)(MapBufferAccessMask.WriteBit | MapBufferAccessMask.PersistentBit | MapBufferAccessMask.CoherentBit));
    }

    /// <summary>Copies <paramref name="data"/> to <paramref name="destination"/> at a byte offset.</summary>
    public void Copy<T>(ReadOnlySpan<T> data, uint destination, long destinationOffset) where T : unmanaged {
        int bytes = data.Length * sizeof(T);
        if (bytes == 0) {
            return;
        }
        if (bytes > Size / 2) {
            // Larger than the ring sensibly holds: a buffer of its own, gone once the copy has run.
            uint temporary = _gl.CreateBuffer();
            fixed (T* p = data) {
                _gl.NamedBufferStorage(temporary, (nuint)bytes, p, BufferStorageMask.None);
            }
            _gl.CopyNamedBufferSubData(temporary, destination, 0, (nint)destinationOffset, (nuint)bytes);
            _gl.DeleteBuffer(temporary);
            return;
        }

        long aligned = (bytes + 15) & ~15L;
        long start = _head;
        if (start % Size + aligned > Size) {
            start += Size - start % Size;
        }
        WaitFor(start + aligned - Size);
        int offset = (int)(start % Size);
        fixed (T* p = data) {
            System.Buffer.MemoryCopy(p, _mapped + offset, bytes, bytes);
        }
        _gl.CopyNamedBufferSubData(Buffer, destination, offset, (nint)destinationOffset, (nuint)bytes);
        _head = start + aligned;
    }

    /// <summary>Waits until everything written before <paramref name="position"/> has been read.</summary>
    private void WaitFor(long position) {
        while (_tail < position) {
            if (!_frames.TryDequeue(out (nint Sync, long End) frame)) {
                // Written this frame and not fenced yet: fence it now and wait.
                EndFrame();
                continue;
            }
            _gl.ClientWaitSync(frame.Sync, SyncObjectMask.Bit, ulong.MaxValue);
            _gl.DeleteSync(frame.Sync);
            _tail = frame.End;
        }
    }

    /// <summary>Fences what this frame wrote. Call once a frame, after its copies are issued.</summary>
    public void EndFrame() {
        if (_head == _fenced) {
            return;
        }
        _frames.Enqueue((_gl.FenceSync(SyncCondition.SyncGpuCommandsComplete, SyncBehaviorFlags.None), _head));
        _fenced = _head;
        // Retire fences that have already passed, without waiting, so the queue stays short.
        while (_frames.Count > 1) {
            (nint sync, long end) = _frames.Peek();
            GLEnum status = _gl.ClientWaitSync(sync, 0u, 0);
            if (status != GLEnum.AlreadySignaled && status != GLEnum.ConditionSatisfied) {
                break;
            }
            _gl.DeleteSync(sync);
            _tail = end;
            _frames.Dequeue();
        }
    }

    public void Dispose() {
        foreach ((nint sync, _) in _frames) {
            _gl.DeleteSync(sync);
        }
        _gl.UnmapNamedBuffer(Buffer);
        _gl.DeleteBuffer(Buffer);
    }
}
