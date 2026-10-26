using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Coloured lines in camera relative world space, batched per frame: block outlines, fishing lines and
/// the built in art's dig cracks. The pipeline draws them as the <c>lines</c> geometry: as vanilla's lines
/// are, each is a quad of six vertices, both ends twice, that the vertex stage widens on screen.
/// </summary>
public sealed unsafe class OverlayRenderer : IDisposable {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Vertex {
        public Vector3 Position;
        public uint Colour;
        public float Sky, Block;
        public Vector3 Direction;
        public float Width, Side;
    }

    private readonly GL _gl;
    private readonly uint _vbo;
    private uint _vao;
    private Vertex[] _lines = new Vertex[1024];
    private int _lineCount, _uploadedLines, _capacity;

    public OverlayRenderer(GL gl) {
        _gl = gl;
        _vbo = gl.CreateBuffer();
    }

    /// <summary>Made at the first draw: a vertex array belongs to the context that made it, and this may be built on another.</summary>
    private uint VertexArray() {
        if (_vao != 0) {
            return _vao;
        }
        _vao = _gl.GenVertexArray();
        _gl.BindVertexArray(_vao);
        _gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);
        uint stride = (uint)sizeof(Vertex);
        _gl.EnableVertexAttribArray(0);
        _gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, stride, (void*)0);
        _gl.EnableVertexAttribArray(1);
        _gl.VertexAttribPointer(1, 4, VertexAttribPointerType.UnsignedByte, true, stride, (void*)12);
        _gl.EnableVertexAttribArray(2);
        _gl.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, stride, (void*)16);
        _gl.EnableVertexAttribArray(3);
        _gl.VertexAttribPointer(3, 3, VertexAttribPointerType.Float, false, stride, (void*)24);
        _gl.EnableVertexAttribArray(4);
        _gl.VertexAttribPointer(4, 2, VertexAttribPointerType.Float, false, stride, (void*)36);
        return _vao;
    }

    private static uint Abgr(uint argb) => (argb & 0xFF00FF00) | (argb >> 16 & 0xFF) | (argb & 0xFF) << 16;

    /// <summary><c>WindowRenderState.appropriateLineWidth</c>, in pixels, which every line is drawn at.</summary>
    public float LineWidth { get; set; } = 2.5F;

    public void Line(Vector3 a, Vector3 b, uint argb) {
        Vector3 direction = Vector3.Normalize(b - a);
        Line(a, direction, b, direction, argb);
    }

    /// <summary>A line whose ends each carry vanilla's normal: a direction along the line, whichever way it points.</summary>
    public void Line(Vector3 a, Vector3 normalA, Vector3 b, Vector3 normalB, uint argb) {
        if (_lineCount + 6 > _lines.Length) {
            Array.Resize(ref _lines, _lines.Length * 2);
        }
        uint colour = Abgr(argb);
        Vertex Corner(Vector3 position, Vector3 normal, float side) =>
            new() { Position = position, Colour = colour, Sky = 15, Block = 15, Direction = normal, Width = LineWidth, Side = side };
        Vertex a0 = Corner(a, normalA, 1), a1 = Corner(a, normalA, -1), b0 = Corner(b, normalB, 1), b1 = Corner(b, normalB, -1);
        _lines[_lineCount++] = a0;
        _lines[_lineCount++] = a1;
        _lines[_lineCount++] = b0;
        _lines[_lineCount++] = b0;
        _lines[_lineCount++] = a1;
        _lines[_lineCount++] = b1;
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
        _uploadedLines = _lineCount;
        if (_lineCount == 0) {
            return;
        }
        _capacity = Math.Max(_lineCount, _capacity < _lineCount ? _capacity * 2 : _capacity);
        // Fresh storage every frame: the last frame's draws may still be reading the old.
        _gl.NamedBufferData(_vbo, (nuint)(Math.Max(1, _capacity) * sizeof(Vertex)), null, GLEnum.StreamDraw);
        fixed (Vertex* l = _lines) {
            _gl.NamedBufferSubData(_vbo, 0, (nuint)(_lineCount * sizeof(Vertex)), l);
        }
        _lineCount = 0;
    }

    public bool IsEmpty => _uploadedLines == 0;

    public void DrawLines() {
        if (_uploadedLines == 0) {
            return;
        }
        _gl.BindVertexArray(VertexArray());
        _gl.DrawArrays(PrimitiveType.Triangles, 0, (uint)_uploadedLines);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_vbo);
    }
}
