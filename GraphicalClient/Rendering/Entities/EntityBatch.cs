using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// The frame's entity geometry, camera relative and textured from <see cref="EntityTextures"/>: models,
/// dropped items, dig cracks, and the built in art's coloured boxes drawn with its white texel. The
/// pipeline draws it as the <c>entities</c> geometry.
/// </summary>
public sealed unsafe class EntityBatch : IModelSink, IDisposable {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Vertex {
        public Vector3 Position;
        public Vector2 Uv;
        public uint Colour;
        public byte Sky, Block;
        public sbyte NormalX, NormalY, NormalZ;
        public byte RedOverlay, WhiteOverlay, Padding;
    }

    private readonly GL _gl;
    private readonly uint _vbo;
    private uint _vao;
    private Vertex[] _vertices = new Vertex[8192];
    private int _count, _uploaded, _capacity;

    public EntityTextures Textures { get; }

    /// <summary>Where the glint over this batch's geometry goes; null where nothing glints.</summary>
    public EntityBatch? Glints { get; init; }

    /// <summary>For a batch of glints: what scrolls their texture coordinates and how strong they are.</summary>
    public EnchantmentGlint? Glint { get; init; }

    /// <summary>Where the glowing outline of this batch's geometry goes; null where nothing outlines.</summary>
    public EntityBatch? Outlines { get; init; }

    /// <summary>A batch of outlines: every quad takes <see cref="OutlineColour"/> instead of its tint.</summary>
    public bool IsOutline { get; init; }

    /// <summary>For a batch of outlines: the opaque colour of the entity being drawn, 0 while it has none, which drops its quads.</summary>
    public uint OutlineColour { get; set; }

    public EntityBatch(GL gl, EntityTextures textures) {
        _gl = gl;
        Textures = textures;
        _vbo = gl.CreateBuffer();
    }

    /// <summary>Made at the first draw: a vertex array belongs to the context that made it, and a batch may be built on another.</summary>
    private uint VertexArray() {
        if (_vao != 0) {
            return _vao;
        }
        _vao = _gl.CreateVertexArray();
        _gl.VertexArrayVertexBuffer(_vao, 0, _vbo, 0, (uint)sizeof(Vertex));
        Attribute(0, 3, VertexAttribType.Float, false, 0);
        Attribute(1, 2, VertexAttribType.Float, false, 12);
        Attribute(2, 4, VertexAttribType.UnsignedByte, true, 20);
        Attribute(3, 2, VertexAttribType.UnsignedByte, false, 24);
        Attribute(4, 3, VertexAttribType.Byte, true, 26);
        Attribute(5, 2, VertexAttribType.UnsignedByte, true, 29);
        return _vao;

        void Attribute(uint index, int size, VertexAttribType type, bool normalised, uint offset) {
            _gl.EnableVertexArrayAttrib(_vao, index);
            _gl.VertexArrayAttribFormat(_vao, index, size, type, normalised, offset);
            _gl.VertexArrayAttribBinding(_vao, index, 0);
        }
    }

    private static uint Abgr(uint argb) => (argb & 0xFF00FF00) | (argb >> 16 & 0xFF) | (argb & 0xFF) << 16;

    /// <summary>Everything but the position and texture coordinates, which a quad's six vertices share.</summary>
    private static Vertex Template(uint abgr, Vector3 normal, in ModelDrawState draw) => new() {
        Colour = abgr,
        Sky = (byte)Math.Clamp((int)(draw.SkyLight * 16), 0, 240),
        Block = (byte)Math.Clamp((int)(draw.BlockLight * 16), 0, 240),
        NormalX = (sbyte)(normal.X * 127),
        NormalY = (sbyte)(normal.Y * 127),
        NormalZ = (sbyte)(normal.Z * 127),
        RedOverlay = (byte)(Math.Clamp(draw.RedOverlay, 0, 1) * 255),
        WhiteOverlay = (byte)(Math.Clamp(draw.WhiteOverlay, 0, 1) * 255)
    };

    private Span<Vertex> Reserve(int count) {
        if (_count + count > _vertices.Length) {
            Array.Resize(ref _vertices, Math.Max(_vertices.Length * 2, _count + count));
        }
        Span<Vertex> span = _vertices.AsSpan(_count, count);
        _count += count;
        return span;
    }

    private void Add(Vector3 position, Vector2 uv, uint abgr, Vector3 normal, in ModelDrawState draw) {
        ref Vertex vertex = ref Reserve(1)[0];
        vertex = Template(abgr, normal, draw);
        vertex.Position = position;
        vertex.Uv = uv;
    }

    /// <summary>Two triangles, 0 1 2 and 2 3 0, of corners that share everything in <paramref name="template"/>.</summary>
    private void AddQuad(in Vertex template, ReadOnlySpan<Vector3> corners, Vector2 uv0, Vector2 uv1, Vector2 uv2, Vector2 uv3) {
        Span<Vertex> quad = Reserve(6);
        quad[0] = template;
        quad[0].Position = corners[0];
        quad[0].Uv = uv0;
        quad[1] = template;
        quad[1].Position = corners[1];
        quad[1].Uv = uv1;
        quad[2] = template;
        quad[2].Position = corners[2];
        quad[2].Uv = uv2;
        quad[3] = quad[2];
        quad[4] = template;
        quad[4].Position = corners[3];
        quad[4].Uv = uv3;
        quad[5] = quad[0];
    }

    /// <summary>A textured quad as two triangles; texture coordinates are 0 to 1 within <see cref="ModelDrawState.Texture"/>.</summary>
    public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) {
        if (IsOutline && OutlineColour == 0) {
            return;
        }
        EntityTexture texture = draw.Texture;
        Vertex template = Template(Abgr(IsOutline ? OutlineColour : draw.Argb), normal, draw);
        AddQuad(template, corners, new Vector2(texture.U(uvs[0].X), texture.V(uvs[0].Y)), new Vector2(texture.U(uvs[1].X), texture.V(uvs[1].Y)),
            new Vector2(texture.U(uvs[2].X), texture.V(uvs[2].Y)), new Vector2(texture.U(uvs[3].X), texture.V(uvs[3].Y)));
        if (Outlines is { OutlineColour: not 0 } outlines && !draw.NoOutline) {
            outlines.Quad(corners, uvs, normal, draw);
        }
    }

    /// <summary>A quad whose corners each have their own colour, as vanilla's custom geometry can.</summary>
    public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, ReadOnlySpan<uint> argb, Vector3 normal, ModelDrawState draw) {
        if (IsOutline) {
            return;
        }
        EntityTexture texture = draw.Texture;
        Span<Vector2> mapped = stackalloc Vector2[4];
        Span<uint> colours = stackalloc uint[4];
        for (int i = 0; i < 4; i++) {
            mapped[i] = new Vector2(texture.U(uvs[i].X), texture.V(uvs[i].Y));
            colours[i] = Abgr(argb[i]);
        }
        Add(corners[0], mapped[0], colours[0], normal, draw);
        Add(corners[1], mapped[1], colours[1], normal, draw);
        Add(corners[2], mapped[2], colours[2], normal, draw);
        Add(corners[2], mapped[2], colours[2], normal, draw);
        Add(corners[3], mapped[3], colours[3], normal, draw);
        Add(corners[0], mapped[0], colours[0], normal, draw);
    }

    /// <summary>An untextured triangle with a colour at each corner, drawn with the white texel.</summary>
    public void Triangle(Vector3 a, Vector3 b, Vector3 c, uint argbA, uint argbB, uint argbC, ModelDrawState draw) {
        if (IsOutline) {
            return;
        }
        Vector2 white = new(Textures.White.U(0.5F), Textures.White.V(0.5F));
        Add(a, white, Abgr(argbA), Vector3.Zero, draw);
        Add(b, white, Abgr(argbB), Vector3.Zero, draw);
        Add(c, white, Abgr(argbC), Vector3.Zero, draw);
    }

    /// <summary>
    /// A quad whose texture repeats, as vanilla's samplers repeat it: <paramref name="uvs"/> may run past 0
    /// to 1. The atlas holds one copy of each texture, so the quad is cut wherever a coordinate crosses a
    /// whole number and each piece is drawn inside its own repeat. The texture coordinates must be a
    /// rectangle the corners map affinely, as every model face and every beam's are.
    /// </summary>
    public void RepeatingQuad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, ReadOnlySpan<uint> argb, Vector3 normal, ModelDrawState draw) {
        Span<RepeatCorner> quad = stackalloc RepeatCorner[4];
        for (int i = 0; i < 4; i++) {
            uint c = argb[i];
            quad[i] = new RepeatCorner(corners[i], uvs[i], new Vector4(c >> 16 & 0xFF, c >> 8 & 0xFF, c & 0xFF, c >> 24));
        }
        CutRepeats(quad, 0, normal, draw);
    }

    /// <inheritdoc cref="RepeatingQuad(ReadOnlySpan{Vector3}, ReadOnlySpan{Vector2}, ReadOnlySpan{uint}, Vector3, ModelDrawState)"/>
    public void RepeatingQuad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) =>
        RepeatingQuad(corners, uvs, [draw.Argb, draw.Argb, draw.Argb, draw.Argb], normal, draw);

    private readonly record struct RepeatCorner(Vector3 Position, Vector2 Uv, Vector4 Colour);

    /// <summary>More repeats than this along one axis of one quad are drawn as the last one stretched.</summary>
    private const int MaxRepeats = 4096;

    private void CutRepeats(ReadOnlySpan<RepeatCorner> quad, int axis, Vector3 normal, ModelDrawState draw) {
        float min = float.MaxValue, max = float.MinValue;
        foreach (RepeatCorner corner in quad) {
            float value = corner.Uv[axis];
            min = Math.Min(min, value);
            max = Math.Max(max, value);
        }
        float first = MathF.Floor(min);
        if (max - first <= 1.0F || max - min <= 0.0F) {
            if (axis == 0) {
                CutRepeats(quad, 1, normal, draw);
            }
            else {
                EmitRepeat(quad, normal, draw);
            }
            return;
        }
        Span<RepeatCorner> piece = stackalloc RepeatCorner[4];
        float last = Math.Min(MathF.Ceiling(max), first + MaxRepeats);
        for (float cell = first; cell < last; cell++) {
            float from = Math.Max(min, cell), to = cell + 1 >= last ? max : Math.Min(max, cell + 1);
            if (to <= from) {
                continue;
            }
            for (int i = 0; i < 4; i++) {
                RepeatCorner corner = quad[i];
                // Along the edge to the neighbour on the far side of the rectangle, only this axis changes.
                RepeatCorner other = quad[(i + 1) % 4].Uv[axis] != corner.Uv[axis] ? quad[(i + 1) % 4] : quad[(i + 3) % 4];
                float target = corner.Uv[axis] < other.Uv[axis] ? from : to;
                float t = (target - corner.Uv[axis]) / (other.Uv[axis] - corner.Uv[axis]);
                piece[i] = new RepeatCorner(Vector3.Lerp(corner.Position, other.Position, t), Vector2.Lerp(corner.Uv, other.Uv, t),
                    Vector4.Lerp(corner.Colour, other.Colour, t));
            }
            if (axis == 0) {
                CutRepeats(piece, 1, normal, draw);
            }
            else {
                EmitRepeat(piece, normal, draw);
            }
        }
    }

    private void EmitRepeat(ReadOnlySpan<RepeatCorner> quad, Vector3 normal, ModelDrawState draw) {
        Vector2 cell = new(MathF.Floor(Math.Min(Math.Min(quad[0].Uv.X, quad[1].Uv.X), Math.Min(quad[2].Uv.X, quad[3].Uv.X))),
            MathF.Floor(Math.Min(Math.Min(quad[0].Uv.Y, quad[1].Uv.Y), Math.Min(quad[2].Uv.Y, quad[3].Uv.Y))));
        ReadOnlySpan<Vector3> corners = [quad[0].Position, quad[1].Position, quad[2].Position, quad[3].Position];
        ReadOnlySpan<Vector2> uvs = [quad[0].Uv - cell, quad[1].Uv - cell, quad[2].Uv - cell, quad[3].Uv - cell];
        Span<uint> argb = stackalloc uint[4];
        for (int i = 0; i < 4; i++) {
            Vector4 c = Vector4.Clamp(quad[i].Colour + new Vector4(0.5F), Vector4.Zero, new Vector4(255));
            argb[i] = (uint)c.W << 24 | (uint)c.X << 16 | (uint)c.Y << 8 | (uint)c.Z;
        }
        if (argb[0] == argb[1] && argb[0] == argb[2] && argb[0] == argb[3]) {
            Quad(corners, uvs, normal, draw with { Argb = argb[0] });
        }
        else {
            Quad(corners, uvs, argb, normal, draw);
        }
    }

    /// <summary>
    /// Glint vertices carry their texture coordinates already through this frame's texturing, the glint
    /// strength as their colour, and a red overlay of 1 for the armour glint texture.
    /// </summary>
    void IModelSink.Glint(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, GlintType type) {
        if (Glints is not { Glint: { } glint } glints) {
            return;
        }
        System.Numerics.Matrix3x2 matrix = glint.Matrix(type);
        uint grey = (uint)Math.Clamp((int)(glint.Strength * 255.0F), 0, 255) * 0x010101u | 0xFF000000;
        ModelDrawState draw = new(Textures.White, grey, 15, 15, type == GlintType.Armor ? 1 : 0);
        Span<Vector2> mapped = stackalloc Vector2[4];
        for (int i = 0; i < 4; i++) {
            mapped[i] = Vector2.Transform(uvs[i], matrix);
        }
        glints.AddQuad(Template(grey, Vector3.Zero, draw), corners, mapped[0], mapped[1], mapped[2], mapped[3]);
    }

    /// <summary>A plain coloured box in a model space <paramref name="transform"/> takes to camera relative space.</summary>
    public void Cuboid(Matrix4x4 transform, Vector3 min, Vector3 max, uint argb, float sky, float block, float redOverlay = 0) {
        ModelDrawState draw = new(Textures.White, argb, sky, block, redOverlay);
        Vector3 T(float x, float y, float z) => Vector3.Transform(new Vector3(x, y, z), transform);
        Vector3 N(Vector3 n) => Vector3.Normalize(Vector3.TransformNormal(n, transform));
        Vector3 v000 = T(min.X, min.Y, min.Z), v100 = T(max.X, min.Y, min.Z), v110 = T(max.X, max.Y, min.Z), v010 = T(min.X, max.Y, min.Z);
        Vector3 v001 = T(min.X, min.Y, max.Z), v101 = T(max.X, min.Y, max.Z), v111 = T(max.X, max.Y, max.Z), v011 = T(min.X, max.Y, max.Z);
        ReadOnlySpan<Vector2> uv = [new(0, 0), new(1, 0), new(1, 1), new(0, 1)];
        Quad([v010, v011, v111, v110], uv, N(Vector3.UnitY), draw);
        Quad([v000, v100, v101, v001], uv, N(-Vector3.UnitY), draw);
        Quad([v000, v010, v110, v100], uv, N(-Vector3.UnitZ), draw);
        Quad([v001, v101, v111, v011], uv, N(Vector3.UnitZ), draw);
        Quad([v000, v001, v011, v010], uv, N(-Vector3.UnitX), draw);
        Quad([v100, v110, v111, v101], uv, N(Vector3.UnitX), draw);
    }

    /// <summary>Sends the frame's geometry and any newly packed textures, and empties the batch. The textures are shared and outlive it.</summary>
    public void Upload() {
        Textures.Upload();
        _uploaded = _count;
        if (_count == 0) {
            return;
        }
        if (_capacity < _count) {
            _capacity = Math.Max(_count, _capacity * 2);
        }
        // Fresh storage every frame: the last frame's draws may still be reading the old.
        _gl.NamedBufferData(_vbo, (nuint)(Math.Max(1, _capacity) * sizeof(Vertex)), null, GLEnum.StreamDraw);
        fixed (Vertex* p = _vertices) {
            _gl.NamedBufferSubData(_vbo, 0, (nuint)(_count * sizeof(Vertex)), p);
        }
        _count = 0;
    }

    /// <summary>Whether the last upload had nothing in it, so drawing it would draw nothing.</summary>
    public bool IsEmpty => _uploaded == 0;

    public void Draw() {
        if (_uploaded == 0) {
            return;
        }
        _gl.BindVertexArray(VertexArray());
        _gl.DrawArrays(PrimitiveType.Triangles, 0, (uint)_uploaded);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_vbo);
    }
}
