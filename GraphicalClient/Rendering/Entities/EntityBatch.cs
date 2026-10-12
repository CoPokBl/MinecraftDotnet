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
    private readonly uint _vao, _vbo;
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
        _vao = gl.CreateVertexArray();
        _vbo = gl.CreateBuffer();
        uint stride = (uint)sizeof(Vertex);
        gl.VertexArrayVertexBuffer(_vao, 0, _vbo, 0, stride);
        void Attribute(uint index, int size, VertexAttribType type, bool normalised, uint offset) {
            gl.EnableVertexArrayAttrib(_vao, index);
            gl.VertexArrayAttribFormat(_vao, index, size, type, normalised, offset);
            gl.VertexArrayAttribBinding(_vao, index, 0);
        }
        Attribute(0, 3, VertexAttribType.Float, false, 0);
        Attribute(1, 2, VertexAttribType.Float, false, 12);
        Attribute(2, 4, VertexAttribType.UnsignedByte, true, 20);
        Attribute(3, 2, VertexAttribType.UnsignedByte, false, 24);
        Attribute(4, 3, VertexAttribType.Byte, true, 26);
        Attribute(5, 2, VertexAttribType.UnsignedByte, true, 29);
    }

    private static uint Abgr(uint argb) => (argb & 0xFF00FF00) | (argb >> 16 & 0xFF) | (argb & 0xFF) << 16;

    private void Add(Vector3 position, Vector2 uv, uint abgr, Vector3 normal, ModelDrawState draw) {
        if (_count == _vertices.Length) {
            Array.Resize(ref _vertices, _vertices.Length * 2);
        }
        _vertices[_count++] = new Vertex {
            Position = position,
            Uv = uv,
            Colour = abgr,
            Sky = (byte)Math.Clamp((int)(draw.SkyLight * 16), 0, 240),
            Block = (byte)Math.Clamp((int)(draw.BlockLight * 16), 0, 240),
            NormalX = (sbyte)(normal.X * 127),
            NormalY = (sbyte)(normal.Y * 127),
            NormalZ = (sbyte)(normal.Z * 127),
            RedOverlay = (byte)(Math.Clamp(draw.RedOverlay, 0, 1) * 255),
            WhiteOverlay = (byte)(Math.Clamp(draw.WhiteOverlay, 0, 1) * 255)
        };
    }

    /// <summary>A textured quad as two triangles; texture coordinates are 0 to 1 within <see cref="ModelDrawState.Texture"/>.</summary>
    public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) {
        if (IsOutline && OutlineColour == 0) {
            return;
        }
        uint colour = Abgr(IsOutline ? OutlineColour : draw.Argb);
        EntityTexture texture = draw.Texture;
        Span<Vector2> mapped = stackalloc Vector2[4];
        for (int i = 0; i < 4; i++) {
            mapped[i] = new Vector2(texture.U(uvs[i].X), texture.V(uvs[i].Y));
        }
        Add(corners[0], mapped[0], colour, normal, draw);
        Add(corners[1], mapped[1], colour, normal, draw);
        Add(corners[2], mapped[2], colour, normal, draw);
        Add(corners[2], mapped[2], colour, normal, draw);
        Add(corners[3], mapped[3], colour, normal, draw);
        Add(corners[0], mapped[0], colour, normal, draw);
        if (Outlines is { OutlineColour: not 0 } outlines && !draw.NoOutline) {
            outlines.Quad(corners, uvs, normal, draw);
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
        glints.Add(corners[0], mapped[0], grey, Vector3.Zero, draw);
        glints.Add(corners[1], mapped[1], grey, Vector3.Zero, draw);
        glints.Add(corners[2], mapped[2], grey, Vector3.Zero, draw);
        glints.Add(corners[2], mapped[2], grey, Vector3.Zero, draw);
        glints.Add(corners[3], mapped[3], grey, Vector3.Zero, draw);
        glints.Add(corners[0], mapped[0], grey, Vector3.Zero, draw);
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
        _gl.BindVertexArray(_vao);
        _gl.DrawArrays(PrimitiveType.Triangles, 0, (uint)_uploaded);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_vbo);
    }
}
