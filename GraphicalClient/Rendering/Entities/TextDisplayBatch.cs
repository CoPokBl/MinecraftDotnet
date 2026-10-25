using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using ClientLib;
using GraphicalClient.Gui;
using GraphicalClient.Rendering.Entities.Vanilla;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// Text displays, drawn the way <c>TextDisplayRenderer</c> lays them out. Each display's text becomes a mesh in
/// font pixels that stays on the GPU until its text, line width or style changes; a frame only sends each
/// visible display's pose, light, text opacity and background colour, and draws every display of a geometry
/// with one indirect call, back to front.
/// </summary>
public sealed unsafe class TextDisplayBatch : IDisposable {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Vertex {
        public Vector3 Position;
        public Vector2 Uv;

        /// <summary>RGBA bytes: the run's colour, and in alpha the layer, 0 for the background.</summary>
        public uint Colour;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Instance {
        public Vector4 Row0, Row1, Row2;
        public uint Background;

        /// <summary>The text's alpha in the low byte, then sky and block light, four bits each.</summary>
        public uint Light;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct Command {
        public uint Count, InstanceCount, First, BaseInstance;
    }

    /// <summary>Vanilla's three depths for a glyph, its shadow and the background, as layers drawn over each other.</summary>
    private const byte BackgroundLayer = 0, ShadowLayer = 1, TextLayer = 2;

    /// <summary>A mesh unused for this many frames is dropped; its display is out of range, culled or gone.</summary>
    private const int EvictAfterFrames = 600;

    private sealed class Mesh {
        public required object Text;
        public int LineWidth;
        public byte Flags;
        public EntityTexture Atlas = null!;

        /// <summary>Built from a random pick of glyphs, so built again every frame it is drawn.</summary>
        public bool Obfuscated;
        public Vertex[] Vertices = [];
        public int Count;
        public int First = -1;
        public bool Dirty;
        public int Width, Height;
        public long LastUsed;

        /// <summary>The lines in visual order with their widths, kept so an obfuscated mesh only picks new glyphs each frame.</summary>
        public List<(IReadOnlyList<TextRun> Runs, int Width)> Lines = [];
    }

    private readonly record struct Draw(Mesh Mesh, Instance Instance, float DistanceSqr);

    private readonly GL _gl;
    private readonly Font _font;
    private readonly EntityTextures _textures;
    private readonly StringSplitter _splitter;
    private readonly Random _obfuscation = new();
    private readonly Dictionary<int, Mesh> _meshes = new();
    private readonly List<Draw> _depthTested = [], _seeThrough = [];
    private readonly List<Vertex> _building = [];
    private readonly uint _arena, _instances, _commands;
    private uint _vao;
    private int _arenaCapacity, _arenaUsed, _arenaFree;
    private Instance[] _instanceData = new Instance[64];
    private Command[] _commandData = new Command[64];
    private int _instanceCapacity, _drawnDepthTested, _drawnSeeThrough;
    private long _frame;
    private int _copiedFontVersion = -1;
    private EntityTexture? _atlas;
    private Frustum _frustum;

    /// <summary>The colour of a display using the default background: the text background opacity option's black.</summary>
    public uint DefaultBackground { get; set; } = 0x3F000000;

    public TextDisplayBatch(GL gl, Font font, EntityTextures textures) {
        _gl = gl;
        _font = font;
        _textures = textures;
        _splitter = new StringSplitter((codepoint, style) => {
            Glyph glyph = _font[codepoint];
            return glyph.Advance + (style.Bold ? glyph.ShadowOffset : 0);
        });
        _arena = gl.CreateBuffer();
        _instances = gl.CreateBuffer();
        _commands = gl.CreateBuffer();
    }

    /// <summary>
    /// Starts a frame: forgets the last one's draws and brings the copy of the font in the entity atlas up to
    /// date with any unifont glyph drawn into the font since, which signs read too.
    /// </summary>
    public void Begin(Frustum frustum) {
        _frame++;
        _frustum = frustum;
        _depthTested.Clear();
        _seeThrough.Clear();
        EntityTexture? atlas = _textures.Get("font:default", () => _font.Atlas);
        if (atlas == null || atlas == _textures.Pending) {
            _atlas = null;
            return;
        }
        if (_atlas == null) {
            _copiedFontVersion = _font.AtlasVersion;
        }
        _atlas = atlas;
        if (_copiedFontVersion != _font.AtlasVersion) {
            _copiedFontVersion = _font.AtlasVersion;
            _textures.Replace(atlas, _font.Atlas.Rgba);
        }
    }

    /// <summary>
    /// <c>TextDisplayRenderer.submitInner</c> for one display, at the pose its transformation leaves, which the
    /// text's own turn, scale and centring go on top of.
    /// </summary>
    public void Submit(int entityId, DisplayRenderer.TextRenderState state, float progress, Matrix4x4 pose, float skyLight, float blockLight) {
        if (_atlas is not { } atlas) {
            return;
        }
        byte flags = state.Flags;
        bool seeThrough = (flags & 2) != 0;
        bool useDefaultBackground = (flags & 4) != 0;
        byte textOpacity = (byte)state.TextOpacity(progress);
        uint background = useDefaultBackground ? DefaultBackground : (uint)state.BackgroundColor(progress);
        Mesh mesh = MeshFor(entityId, state, atlas);
        if (mesh.Count == 0) {
            return;
        }

        // pose.rotate(PI, 0, 1, 0), scale(-0.025), translate(1 - width / 2, -height, 0).
        Matrix4x4 matrix = Matrix4x4.CreateTranslation(1.0F - mesh.Width / 2.0F, -mesh.Height, 0.0F) * Matrix4x4.CreateScale(-0.025F)
            * Matrix4x4.CreateRotationY(MathF.PI) * pose;
        if (!InView(mesh, matrix)) {
            return;
        }
        Instance instance = new() {
            Row0 = new Vector4(matrix.M11, matrix.M21, matrix.M31, matrix.M41),
            Row1 = new Vector4(matrix.M12, matrix.M22, matrix.M32, matrix.M42),
            Row2 = new Vector4(matrix.M13, matrix.M23, matrix.M33, matrix.M43),
            Background = background,
            Light = textOpacity | (uint)Math.Clamp((int)skyLight, 0, 15) << 8 | (uint)Math.Clamp((int)blockLight, 0, 15) << 12
        };
        // The text's middle, where the sort measures from.
        Vector3 centre = Vector3.Transform(new Vector3(mesh.Width / 2.0F, mesh.Height / 2.0F, 0.0F), matrix);
        (seeThrough ? _seeThrough : _depthTested).Add(new Draw(mesh, instance, centre.LengthSquared()));
    }

    /// <summary>Whether the background's rectangle, which holds every glyph, can be on screen.</summary>
    private bool InView(Mesh mesh, Matrix4x4 matrix) {
        Vector3 a = Vector3.Transform(new Vector3(-1, -1, 0), matrix), b = Vector3.Transform(new Vector3(mesh.Width + 1, -1, 0), matrix);
        Vector3 c = Vector3.Transform(new Vector3(-1, mesh.Height + 1, 0), matrix), d = Vector3.Transform(new Vector3(mesh.Width + 1, mesh.Height + 1, 0), matrix);
        return _frustum.Intersects(Vector3.Min(Vector3.Min(a, b), Vector3.Min(c, d)), Vector3.Max(Vector3.Max(a, b), Vector3.Max(c, d)));
    }

    private Mesh MeshFor(int entityId, DisplayRenderer.TextRenderState state, EntityTexture atlas) {
        // The shadow flag and the alignment change the mesh; the rest is per draw.
        byte layoutFlags = (byte)(state.Flags & (1 | 8 | 16));
        if (!_meshes.TryGetValue(entityId, out Mesh? mesh) || !ReferenceEquals(mesh.Text, state.Text) || mesh.LineWidth != state.LineWidth
            || mesh.Flags != layoutFlags || mesh.Atlas != atlas) {
            if (mesh != null) {
                Free(mesh);
            }
            mesh = new Mesh { Text = state.Text, LineWidth = state.LineWidth, Flags = layoutFlags, Atlas = atlas };
            _meshes[entityId] = mesh;
            Build(mesh, state);
        }
        else if (mesh.Obfuscated && mesh.LastUsed != _frame) {
            Emit(mesh, state);
        }
        mesh.LastUsed = _frame;
        return mesh;
    }

    /// <summary>
    /// <c>splitLines</c> and the line loop of <c>submitInner</c>: the text wrapped at the line width into lines in
    /// visual order, each aligned within the widest, ten pixels apart, over a background one pixel bigger.
    /// </summary>
    private void Build(Mesh mesh, DisplayRenderer.TextRenderState state) {
        List<List<TextRun>> lines = _splitter.SplitLines(TextFlattener.Decode(TextFlattener.Flatten(state.Text)), state.LineWidth);
        mesh.Lines = new List<(IReadOnlyList<TextRun> Runs, int Width)>(lines.Count);
        int width = 0;
        foreach (List<TextRun> line in lines) {
            IReadOnlyList<TextRun> visual = BidiReorder.Reorder(line, Translations.DefaultRightToLeft);
            int lineWidth = (int)MathF.Ceiling(_splitter.StringWidth(visual));
            width = Math.Max(width, lineWidth);
            mesh.Lines.Add((visual, lineWidth));
        }
        mesh.Width = width;
        mesh.Height = lines.Count * LineSpacing - 1;
        Emit(mesh, state);
    }

    private const int LineSpacing = TextRenderer.LineHeight + 1;

    /// <summary>The mesh's vertices from its laid out lines.</summary>
    private void Emit(Mesh mesh, DisplayRenderer.TextRenderState state) {
        int width = mesh.Width, height = mesh.Height;
        bool shadow = (state.Flags & 1) != 0;
        int alignment = (state.Flags & 8) != 0 ? -1 : (state.Flags & 16) != 0 ? 1 : 0;

        _building.Clear();
        bool obfuscated = false;
        EntityTexture white = _textures.White;
        Rect(-1.0F, -1.0F, width, height, white, 0, BackgroundLayer);
        float y = 0.0F;
        foreach ((IReadOnlyList<TextRun> runs, int lineWidth) in mesh.Lines) {
            float offset = alignment switch {
                -1 => 0.0F,
                1 => width - lineWidth,
                _ => width / 2.0F - lineWidth / 2.0F
            };
            obfuscated |= Line(runs, offset, y, shadow, mesh.Atlas);
            y += LineSpacing;
        }
        int previousCount = mesh.Count;
        if (mesh.Vertices.Length == _building.Count) {
            _building.CopyTo(mesh.Vertices);
        }
        else {
            mesh.Vertices = _building.ToArray();
        }
        mesh.Count = mesh.Vertices.Length;
        mesh.Obfuscated = obfuscated;
        if (mesh.First >= 0 && previousCount != mesh.Count) {
            _arenaFree += previousCount;
            mesh.First = -1;
        }
        mesh.Dirty = true;
    }

    /// <summary>
    /// <c>Font.PreparedTextBuilder</c> and <c>BakedSheetGlyph.renderChar</c> for one line: each glyph's shadow then the
    /// glyph, a bold glyph twice and thickened, underline and strikethrough over them. Returns whether a run was obfuscated.
    /// </summary>
    private bool Line(IReadOnlyList<TextRun> runs, float x, float y, bool shadow, EntityTexture atlas) {
        bool obfuscated = false;
        bool first = true;
        foreach (TextRun run in runs) {
            uint colour = Rgb(run.Rgb);
            // ARGB.scaleRGB(colour, 0.25F).
            uint shadowColour = Rgb((run.Rgb >> 16 & 0xFF) / 4 << 16 | (run.Rgb >> 8 & 0xFF) / 4 << 8 | (run.Rgb & 0xFF) / 4);
            obfuscated |= run.Obfuscated;
            float effectStart = first ? x - 1.0F : x;
            float shadowOffset = 1.0F;
            foreach (Rune rune in run.Text.EnumerateRunes()) {
                Glyph glyph = _font[rune.Value];
                shadowOffset = glyph.ShadowOffset;
                if (run.Obfuscated && rune.Value != ' ') {
                    glyph = _font.RandomGlyph(_obfuscation, (int)MathF.Ceiling(glyph.Advance));
                }
                float boldOffset = run.Bold ? glyph.ShadowOffset : 0.0F;
                // An obfuscated run keeps a quad for every glyph, drawn or not, so its mesh keeps its size as the picks change.
                if (glyph.Width > 0 || run.Obfuscated) {
                    if (shadow) {
                        GlyphQuad(glyph, x + glyph.ShadowOffset, y + glyph.ShadowOffset, run, atlas, shadowColour, ShadowLayer);
                        if (run.Bold) {
                            GlyphQuad(glyph, x + boldOffset + glyph.ShadowOffset, y + glyph.ShadowOffset, run, atlas, shadowColour, ShadowLayer);
                        }
                    }
                    GlyphQuad(glyph, x, y, run, atlas, colour, TextLayer);
                    if (run.Bold) {
                        GlyphQuad(glyph, x + boldOffset, y, run, atlas, colour, TextLayer);
                    }
                }
                x += glyph.Advance + boldOffset;
                first = false;
            }
            if (run.Strikethrough) {
                Effect(effectStart, y + 4.5F - 1.0F, x, y + 4.5F, shadow, shadowOffset, colour, shadowColour);
            }
            if (run.Underlined) {
                Effect(effectStart, y + 9.0F - 1.0F, x, y + 9.0F, shadow, shadowOffset, colour, shadowColour);
            }
        }
        return obfuscated;
    }

    /// <summary><c>BakedSheetGlyph.render</c>: italic leans the quad by its shear at its top and bottom edge, bold widens it by a tenth.</summary>
    private void GlyphQuad(Glyph glyph, float x, float y, TextRun run, EntityTexture atlas, uint colour, byte layer) {
        float thickness = run.Bold ? 0.1F : 0.0F;
        float x0 = x - thickness, x1 = x + glyph.Width + thickness;
        float y0 = y + glyph.Top - thickness, y1 = y + glyph.Top + glyph.Height + thickness;
        float shearTop = run.Italic ? 1.0F - 0.25F * glyph.Top : 0.0F;
        float shearBottom = run.Italic ? 1.0F - 0.25F * (glyph.Top + glyph.Height) : 0.0F;
        Quad(x0 + shearTop, x0 + shearBottom, x1 + shearBottom, x1 + shearTop, y0, y1, atlas.U(glyph.U0), atlas.V(glyph.V0), atlas.U(glyph.U1), atlas.V(glyph.V1),
            colour | (uint)layer << 24);
    }

    /// <summary><c>BakedSheetGlyph.renderEffect</c>: the line, after its shadow when the text has one.</summary>
    private void Effect(float x0, float y0, float x1, float y1, bool shadow, float shadowOffset, uint colour, uint shadowColour) {
        if (shadow) {
            Rect(x0 + shadowOffset, y0 + shadowOffset, x1 + shadowOffset, y1 + shadowOffset, _textures.White, shadowColour, ShadowLayer);
        }
        Rect(x0, y0, x1, y1, _textures.White, colour, TextLayer);
    }

    private void Rect(float x0, float y0, float x1, float y1, EntityTexture texture, uint colour, byte layer) {
        float u = texture.U(0.5F), v = texture.V(0.5F);
        Quad(x0, x0, x1, x1, y0, y1, u, v, u, v, colour | (uint)layer << 24);
    }

    /// <summary>Two triangles; the top edge runs from <paramref name="topLeft"/> to <paramref name="topRight"/> and the bottom from the other two.</summary>
    private void Quad(float topLeft, float bottomLeft, float bottomRight, float topRight, float y0, float y1, float u0, float v0, float u1, float v1, uint colour) {
        Vertex a = new() { Position = new Vector3(topLeft, y0, 0), Uv = new Vector2(u0, v0), Colour = colour };
        Vertex b = new() { Position = new Vector3(bottomLeft, y1, 0), Uv = new Vector2(u0, v1), Colour = colour };
        Vertex c = new() { Position = new Vector3(bottomRight, y1, 0), Uv = new Vector2(u1, v1), Colour = colour };
        Vertex d = new() { Position = new Vector3(topRight, y0, 0), Uv = new Vector2(u1, v0), Colour = colour };
        _building.Add(a);
        _building.Add(b);
        _building.Add(c);
        _building.Add(c);
        _building.Add(d);
        _building.Add(a);
    }

    /// <summary>A packed RGB as the vertex's red, green and blue bytes.</summary>
    private static uint Rgb(int rgb) => (uint)(rgb >> 16 & 0xFF) | (uint)(rgb >> 8 & 0xFF) << 8 | (uint)(rgb & 0xFF) << 16;

    private void Free(Mesh mesh) {
        if (mesh.First >= 0) {
            _arenaFree += mesh.Count;
            mesh.First = -1;
        }
    }

    public bool IsEmpty(bool seeThrough) => (seeThrough ? _drawnSeeThrough : _drawnDepthTested) == 0;

    /// <summary>Places new and changed meshes, then sends this frame's draws, each geometry's back to front.</summary>
    public void Upload() {
        foreach ((int id, Mesh mesh) in _meshes) {
            if (_frame - mesh.LastUsed > EvictAfterFrames) {
                Free(mesh);
                _meshes.Remove(id);
            }
        }
        PlaceMeshes();
        _depthTested.Sort(static (a, b) => b.DistanceSqr.CompareTo(a.DistanceSqr));
        _seeThrough.Sort(static (a, b) => b.DistanceSqr.CompareTo(a.DistanceSqr));
        int total = _depthTested.Count + _seeThrough.Count;
        _drawnDepthTested = _depthTested.Count;
        _drawnSeeThrough = _seeThrough.Count;
        if (total == 0) {
            return;
        }
        if (_instanceData.Length < total) {
            Array.Resize(ref _instanceData, Math.Max(total, _instanceData.Length * 2));
            Array.Resize(ref _commandData, _instanceData.Length);
        }
        int i = 0;
        foreach (Draw draw in _depthTested) {
            Add(draw);
        }
        foreach (Draw draw in _seeThrough) {
            Add(draw);
        }
        if (_instanceCapacity < total) {
            _instanceCapacity = Math.Max(total, _instanceCapacity * 2);
        }
        // Fresh storage every frame: the last frame's draws may still be reading the old.
        _gl.NamedBufferData(_instances, (nuint)(_instanceCapacity * sizeof(Instance)), null, GLEnum.StreamDraw);
        _gl.NamedBufferData(_commands, (nuint)(_instanceCapacity * sizeof(Command)), null, GLEnum.StreamDraw);
        fixed (Instance* p = _instanceData) {
            _gl.NamedBufferSubData(_instances, 0, (nuint)(total * sizeof(Instance)), p);
        }
        fixed (Command* p = _commandData) {
            _gl.NamedBufferSubData(_commands, 0, (nuint)(total * sizeof(Command)), p);
        }

        void Add(Draw draw) {
            _instanceData[i] = draw.Instance;
            _commandData[i] = new Command { Count = (uint)draw.Mesh.Count, InstanceCount = 1, First = (uint)draw.Mesh.First, BaseInstance = (uint)i };
            i++;
        }
    }

    /// <summary>
    /// Gives every mesh without a place one at the end of the arena, packing the arena again when it is full or
    /// mostly holes, and sends the vertices that changed.
    /// </summary>
    private void PlaceMeshes() {
        int needed = 0;
        foreach (Mesh mesh in _meshes.Values) {
            if (mesh.First < 0) {
                needed += mesh.Count;
            }
        }
        if (_arenaUsed + needed > _arenaCapacity || _arenaFree > 65536 && _arenaFree > _arenaUsed / 2) {
            int live = 0;
            foreach (Mesh mesh in _meshes.Values) {
                live += mesh.Count;
            }
            _arenaCapacity = Math.Max(16384, live * 2);
            // New storage under the same name, which the vertex array keeps reading.
            _gl.NamedBufferData(_arena, (nuint)(_arenaCapacity * sizeof(Vertex)), null, GLEnum.DynamicDraw);
            _arenaUsed = 0;
            _arenaFree = 0;
            foreach (Mesh mesh in _meshes.Values) {
                mesh.First = -1;
            }
        }
        foreach (Mesh mesh in _meshes.Values) {
            if (mesh.First < 0) {
                mesh.First = _arenaUsed;
                _arenaUsed += mesh.Count;
                mesh.Dirty = true;
            }
            if (mesh.Dirty) {
                mesh.Dirty = false;
                fixed (Vertex* p = mesh.Vertices) {
                    _gl.NamedBufferSubData(_arena, (nint)(mesh.First * sizeof(Vertex)), (nuint)(mesh.Count * sizeof(Vertex)), p);
                }
            }
        }
    }

    /// <summary>Made at the first draw: a vertex array belongs to the context that made it.</summary>
    private uint VertexArray() {
        if (_vao != 0) {
            return _vao;
        }
        _vao = _gl.CreateVertexArray();
        _gl.VertexArrayVertexBuffer(_vao, 0, _arena, 0, (uint)sizeof(Vertex));
        _gl.VertexArrayVertexBuffer(_vao, 1, _instances, 0, (uint)sizeof(Instance));
        _gl.VertexArrayBindingDivisor(_vao, 1, 1);
        Attribute(0, 3, VertexAttribType.Float, false, 0, 0);
        Attribute(1, 2, VertexAttribType.Float, false, 12, 0);
        Attribute(2, 4, VertexAttribType.UnsignedByte, true, 20, 0);
        Attribute(3, 4, VertexAttribType.Float, false, 0, 1);
        Attribute(4, 4, VertexAttribType.Float, false, 16, 1);
        Attribute(5, 4, VertexAttribType.Float, false, 32, 1);
        _gl.EnableVertexArrayAttrib(_vao, 6);
        _gl.VertexArrayAttribIFormat(_vao, 6, 2, VertexAttribIType.UnsignedInt, 48);
        _gl.VertexArrayAttribBinding(_vao, 6, 1);
        return _vao;

        void Attribute(uint index, int size, VertexAttribType type, bool normalised, uint offset, uint binding) {
            _gl.EnableVertexArrayAttrib(_vao, index);
            _gl.VertexArrayAttribFormat(_vao, index, size, type, normalised, offset);
            _gl.VertexArrayAttribBinding(_vao, index, binding);
        }
    }

    /// <summary>The <c>text</c> geometry, or with <paramref name="seeThrough"/> the <c>text_see_through</c> one.</summary>
    public void DrawText(bool seeThrough) {
        int count = seeThrough ? _drawnSeeThrough : _drawnDepthTested;
        if (count == 0) {
            return;
        }
        int first = seeThrough ? _drawnDepthTested : 0;
        _gl.BindVertexArray(VertexArray());
        // The vertex array reads the instance buffer by name, and the storage behind it is made again each frame.
        _gl.VertexArrayVertexBuffer(_vao, 1, _instances, 0, (uint)sizeof(Instance));
        _gl.BindBuffer(BufferTargetARB.DrawIndirectBuffer, _commands);
        _gl.MultiDrawArraysIndirect(PrimitiveType.Triangles, (void*)(first * sizeof(Command)), (uint)count, (uint)sizeof(Command));
        _gl.BindBuffer(BufferTargetARB.DrawIndirectBuffer, 0);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_arena);
        _gl.DeleteBuffer(_instances);
        _gl.DeleteBuffer(_commands);
    }
}
