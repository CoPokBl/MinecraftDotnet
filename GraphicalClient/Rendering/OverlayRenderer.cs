using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Coloured lines in camera relative world space, batched per frame: block outlines and the built in
/// art's dig cracks. The pipeline draws them as the <c>lines</c> geometry.
/// </summary>
public sealed unsafe class OverlayRenderer : IDisposable {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Vertex {
        public Vector3 Position;
        public uint Colour;
        public float Sky, Block;
    }

    private readonly GL _gl;
    private readonly uint _vao, _vbo;
    private Vertex[] _lines = new Vertex[1024];
    private int _lineCount, _uploadedLines, _capacity;

    public OverlayRenderer(GL gl) {
        _gl = gl;
        _vao = gl.GenVertexArray();
        gl.BindVertexArray(_vao);
        _vbo = gl.GenBuffer();
        gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);
        uint stride = (uint)sizeof(Vertex);
        gl.EnableVertexAttribArray(0);
        gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, stride, (void*)0);
        gl.EnableVertexAttribArray(1);
        gl.VertexAttribPointer(1, 4, VertexAttribPointerType.UnsignedByte, true, stride, (void*)12);
        gl.EnableVertexAttribArray(2);
        gl.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, stride, (void*)16);
        gl.BindVertexArray(0);
    }

    private static uint Abgr(uint argb) => (argb & 0xFF00FF00) | (argb >> 16 & 0xFF) | (argb & 0xFF) << 16;

    public void Line(Vector3 a, Vector3 b, uint argb) {
        if (_lineCount + 2 > _lines.Length) {
            Array.Resize(ref _lines, _lines.Length * 2);
        }
        uint colour = Abgr(argb);
        _lines[_lineCount++] = new Vertex { Position = a, Colour = colour, Sky = 15, Block = 15 };
        _lines[_lineCount++] = new Vertex { Position = b, Colour = colour, Sky = 15, Block = 15 };
    }

    /// <summary>The twelve edges of a box, camera relative.</summary>
    public void BoxEdges(Vector3 min, Vector3 max, uint argb) {
        Span<Vector3> c = [
            new(min.X, min.Y, min.Z), new(max.X, min.Y, min.Z), new(max.X, min.Y, max.Z), new(min.X, min.Y, max.Z),
            new(min.X, max.Y, min.Z), new(max.X, max.Y, min.Z), new(max.X, max.Y, max.Z), new(min.X, max.Y, max.Z)
        ];
        for (int i = 0; i < 4; i++) {
            Line(c[i], c[(i + 1) % 4], argb);
            Line(c[i + 4], c[(i + 1) % 4 + 4], argb);
            Line(c[i], c[i + 4], argb);
        }
    }

    /// <summary>Sends the frame's lines to the GPU and empties the batch.</summary>
    public void Upload() {
        _capacity = Math.Max(_lineCount, _capacity < _lineCount ? _capacity * 2 : _capacity);
        // Fresh storage every frame: the last frame's draws may still be reading the old.
        _gl.NamedBufferData(_vbo, (nuint)(Math.Max(1, _capacity) * sizeof(Vertex)), null, GLEnum.StreamDraw);
        fixed (Vertex* l = _lines) {
            _gl.NamedBufferSubData(_vbo, 0, (nuint)(_lineCount * sizeof(Vertex)), l);
        }
        _uploadedLines = _lineCount;
        _lineCount = 0;
    }

    public void DrawLines() {
        if (_uploadedLines == 0) {
            return;
        }
        _gl.BindVertexArray(_vao);
        _gl.DrawArrays(PrimitiveType.Lines, 0, (uint)_uploadedLines);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_vbo);
    }
}
