using System.Numerics;
using System.Runtime.InteropServices;
using ClientLib.Sky;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Pipeline;
using Minecraft.Data.DimensionType;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>What <c>SkyRenderer.extractRenderState</c> and <c>LevelRenderer.addSkyPass</c> read off the level and the camera.</summary>
/// <param name="Blocked">
/// <c>addSkyPass</c> leaves the sky out in lava or powder snow, under blindness or darkness, and when a boss bar
/// asks for world fog; the frame keeps the fog colour it was cleared to.
/// </param>
/// <param name="DarkDisc"><c>shouldRenderDarkDisc</c>: the player's eye is below the horizon and not under water.</param>
public readonly record struct SkyState(Skybox Skybox, bool Blocked, bool DarkDisc, float EndFlashIntensity, float EndFlashXAngle, float EndFlashYAngle);

/// <summary>
/// <c>SkyRenderer</c>, drawn as the <c>sky</c> geometry: vanilla's meshes in one buffer, built once, and each frame
/// the transform and <c>ColorModulator</c> of every draw <c>render</c> would make, in its order. Each part keeps
/// vanilla's own blend in the default pack's program; the pass blends premultiplied, which can express all three.
/// </summary>
public sealed unsafe class SkyRenderer : IDisposable {
    /// <summary>Where both stages of a <c>sky</c> pass find <c>celestialAtlas</c>.</summary>
    public const int TextureUnit = 29;

    /// <summary>Where the <c>sky</c> geometry's helpers find each part's transform and modulator.</summary>
    public const int UniformBinding = 4;

    /// <summary>The parts, which the vertex helpers and the GLSL defines number alike.</summary>
    public enum Part : byte { Disc, Sunrise, Sun, Moon, Stars, DarkDisc, EndSky, EndFlash }

    private const int PartCount = 8;

    /// <summary><c>SUN_SIZE</c>, <c>MOON_SIZE</c>, <c>END_FLASH_SCALE</c> and the height all three are drawn at.</summary>
    private const float SunSize = 30.0F, MoonSize = 20.0F, EndFlashScale = 60.0F, CelestialHeight = 100.0F;

    /// <summary>The sprites of vanilla's <c>celestials</c> atlas, its <c>environment/celestial</c> directory, in the order they are packed.</summary>
    private static readonly string[] Sprites = [
        "sun", "end_flash",
        "moon/full_moon", "moon/waning_gibbous", "moon/third_quarter", "moon/waning_crescent",
        "moon/new_moon", "moon/waxing_crescent", "moon/first_quarter", "moon/waxing_gibbous"
    ];

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Vertex {
        public Vector3 Position;
        public Vector2 Uv;

        /// <summary>RGBA bytes.</summary>
        public uint Colour;
        public uint Part;
    }

    /// <summary>The <c>SkyFrame</c> block: a transform and a modulator for each part.</summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct Frame {
        public fixed float Poses[PartCount * 16];
        public fixed float Modulators[PartCount * 4];
    }

    private readonly GL _gl;
    private readonly uint _vbo, _ibo, _uniforms;
    private uint _vao;

    /// <summary>Each part's first index and index count; the moon's covers one phase, the first.</summary>
    private readonly (int First, int Count)[] _ranges = new (int, int)[PartCount];
    private readonly List<(int First, int Count)> _draws = [];
    private Frame _frame = new();

    /// <summary>The sun, the end flash and the moon's phases packed into one texture, nearest and clamped as vanilla's atlas.</summary>
    public uint CelestialTexture { get; }

    public bool IsEmpty => _draws.Count == 0;

    public SkyRenderer(GL gl, ResourcePackSource? pack) {
        _gl = gl;
        TextureImage[] images = Sprites.Select(name => pack?.LoadFirstFrame($"assets/minecraft/textures/environment/celestial/{name}.png") ?? name switch {
            "sun" => SkyArt.Sun(),
            "end_flash" => SkyArt.EndFlash(),
            _ => SkyArt.Moon(Array.IndexOf(Sprites, name) - 2)
        }).ToArray();
        (CelestialTexture, Vector4[] uvs) = Pack(images);

        List<Vertex> vertices = [];
        List<uint> indices = [];
        Fan(Part.Disc, SkyMeshes.SkyDisc(16.0F).Select(p => new SkyVertex(p, Vector2.Zero, 0xFFFFFFFF)).ToArray());
        Fan(Part.DarkDisc, SkyMeshes.SkyDisc(-16.0F).Select(p => new SkyVertex(p, Vector2.Zero, 0xFFFFFFFF)).ToArray());
        Fan(Part.Sunrise, SkyMeshes.SunriseFan());
        Quads(Part.Sun, SkyMeshes.CelestialQuad(uvs[0].X, uvs[0].Y, uvs[0].Z, uvs[0].W));
        Quads(Part.EndFlash, SkyMeshes.CelestialQuad(uvs[1].X, uvs[1].Y, uvs[1].Z, uvs[1].W));
        Quads(Part.Moon, Enumerable.Range(2, 8).SelectMany(i => SkyMeshes.MoonQuad(uvs[i].X, uvs[i].Y, uvs[i].Z, uvs[i].W)).ToArray());
        _ranges[(int)Part.Moon].Count = 6;
        Quads(Part.Stars, SkyMeshes.Stars().Select(p => new SkyVertex(p, Vector2.Zero, 0xFFFFFFFF)).ToArray());
        Quads(Part.EndSky, SkyMeshes.EndSky());

        _vbo = gl.CreateBuffer();
        _ibo = gl.CreateBuffer();
        Vertex[] vertexArray = vertices.ToArray();
        uint[] indexArray = indices.ToArray();
        fixed (Vertex* v = vertexArray) {
            gl.NamedBufferStorage(_vbo, (nuint)(vertexArray.Length * sizeof(Vertex)), v, BufferStorageMask.None);
        }
        fixed (uint* i = indexArray) {
            gl.NamedBufferStorage(_ibo, (nuint)(indexArray.Length * sizeof(uint)), i, BufferStorageMask.None);
        }
        _uniforms = gl.CreateBuffer();
        gl.NamedBufferStorage(_uniforms, (nuint)sizeof(Frame), null, BufferStorageMask.DynamicStorageBit);
        return;

        uint Add(Part part, SkyVertex vertex) {
            uint c = vertex.Colour;
            vertices.Add(new Vertex {
                Position = vertex.Position, Uv = vertex.Uv, Part = (uint)part,
                Colour = (c >> 16 & 0xFF) | (c >> 8 & 0xFF) << 8 | (c & 0xFF) << 16 | (c >> 24) << 24
            });
            return (uint)vertices.Count - 1;
        }

        // A triangle fan as triangles, each (centre, i, i + 1): the cyclic order, and so the winding, GL's own fan gives.
        void Fan(Part part, SkyVertex[] fan) {
            _ranges[(int)part] = (indices.Count, (fan.Length - 2) * 3);
            uint centre = Add(part, fan[0]);
            for (int i = 1; i < fan.Length; i++) {
                Add(part, fan[i]);
            }
            for (uint i = 1; i < fan.Length - 1; i++) {
                indices.AddRange([centre, centre + i, centre + i + 1]);
            }
        }

        // RenderSystem's sequential quad indices: 0, 1, 2, 2, 3, 0.
        void Quads(Part part, SkyVertex[] quads) {
            _ranges[(int)part] = (indices.Count, quads.Length / 4 * 6);
            for (int q = 0; q < quads.Length; q += 4) {
                uint first = Add(part, quads[q]);
                Add(part, quads[q + 1]);
                Add(part, quads[q + 2]);
                Add(part, quads[q + 3]);
                indices.AddRange([first, first + 1, first + 2, first + 2, first + 3, first]);
            }
        }
    }

    /// <summary>Lays the sprites side by side in rows; each comes back as u0, v0, u1, v1, at its texels' edges as an atlas sprite's are.</summary>
    private (uint Texture, Vector4[] Uvs) Pack(TextureImage[] images) {
        const int maxWidth = 4096;
        (int X, int Y)[] at = new (int, int)[images.Length];
        int x = 0, y = 0, rowHeight = 0, width = 0;
        for (int i = 0; i < images.Length; i++) {
            if (x > 0 && x + images[i].Width > maxWidth) {
                (x, y, rowHeight) = (0, y + rowHeight, 0);
            }
            at[i] = (x, y);
            x += images[i].Width;
            width = Math.Max(width, x);
            rowHeight = Math.Max(rowHeight, images[i].Height);
        }
        int height = y + rowHeight;
        uint texture = _gl.CreateTexture(TextureTarget.Texture2D);
        _gl.TextureStorage2D(texture, 1, SizedInternalFormat.Rgba8, (uint)width, (uint)height);
        Vector4[] uvs = new Vector4[images.Length];
        for (int i = 0; i < images.Length; i++) {
            TextureImage image = images[i];
            fixed (byte* p = image.Rgba) {
                _gl.TextureSubImage2D(texture, 0, at[i].X, at[i].Y, (uint)image.Width, (uint)image.Height, PixelFormat.Rgba, PixelType.UnsignedByte, p);
            }
            uvs[i] = new Vector4((float)at[i].X / width, (float)at[i].Y / height, (float)(at[i].X + image.Width) / width, (float)(at[i].Y + image.Height) / height);
        }
        _gl.TextureParameter(texture, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        _gl.TextureParameter(texture, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        _gl.TextureParameter(texture, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        _gl.TextureParameter(texture, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
        return (texture, uvs);
    }

    /// <summary>
    /// <c>SkyRenderer.render</c>'s draws for this frame, from the frame's sky colour, sunrise colour, celestial angles,
    /// star brightness, rain and moon phase. Poses leave out the camera's rotation, which the pack's view matrix holds.
    /// </summary>
    public void Update(SkyState state, in FrameUniforms frame) {
        _draws.Clear();
        if (state.Blocked || state.Skybox == Skybox.None) {
            return;
        }
        if (state.Skybox == Skybox.End) {
            Set(Part.EndSky, Matrix4x4.Identity, Vector4.One);
            if (state.EndFlashIntensity > 1.0E-5F) {
                float intensity = state.EndFlashIntensity;
                Set(Part.EndFlash,
                    Celestial(EndFlashScale) * RotationX(Degrees(-90.0F - state.EndFlashXAngle)) * RotationY(Degrees(180.0F - state.EndFlashYAngle)),
                    new Vector4(intensity));
            }
            Upload();
            return;
        }

        float sunAngle = frame.Celestial.X * (float)(Math.PI / 180.0);
        float moonAngle = frame.Celestial.Y * (float)(Math.PI / 180.0);
        float starAngle = frame.Celestial.Z * (float)(Math.PI / 180.0);
        float starBrightness = frame.Celestial.W;
        float rainBrightness = 1.0F - frame.Weather.X;
        Vector4 sunrise = frame.SunriseColour;
        Matrix4x4 turn = RotationY(Degrees(-90.0F));

        Set(Part.Disc, Matrix4x4.Identity, new Vector4(frame.SkyColour.X, frame.SkyColour.Y, frame.SkyColour.Z, 1.0F));
        if (!(sunrise.W <= 0.001F)) {
            float angle = Minecraft.Schemas.Mth.Sin(sunAngle) < 0.0F ? 180.0F : 0.0F;
            Set(Part.Sunrise, Matrix4x4.CreateScale(1.0F, 1.0F, sunrise.W) * RotationZ(Degrees(angle + 90.0F)) * RotationX(Degrees(90.0F)), sunrise);
        }
        Set(Part.Sun, Celestial(SunSize) * RotationX(sunAngle) * turn, new Vector4(1.0F, 1.0F, 1.0F, rainBrightness));
        int phase = Math.Clamp((int)frame.Counters.Z, 0, 7);
        Set(Part.Moon, Celestial(MoonSize) * RotationX(moonAngle) * turn, new Vector4(1.0F, 1.0F, 1.0F, rainBrightness), phase * 6);
        if (starBrightness > 0.0F) {
            Set(Part.Stars, RotationX(starAngle) * turn, new Vector4(starBrightness));
        }
        if (state.DarkDisc) {
            Set(Part.DarkDisc, Matrix4x4.CreateTranslation(0.0F, 12.0F, 0.0F), new Vector4(0.0F, 0.0F, 0.0F, 1.0F));
        }
        Upload();
    }

    /// <summary><c>applyCelestialBodyTransform</c>'s lift and squash, applied before the pose.</summary>
    private static Matrix4x4 Celestial(float scale) => Matrix4x4.CreateScale(scale, 1.0F, scale) * Matrix4x4.CreateTranslation(0.0F, CelestialHeight, 0.0F);

    private static float Degrees(float degrees) => degrees * (float)(Math.PI / 180.0);

    // Row vector matrices, so a chain reads in the order the transforms apply: vanilla's pose.rotate(a).rotate(b)
    // applies b first and is b * a here.
    private static Matrix4x4 RotationX(float radians) => Matrix4x4.CreateRotationX(radians);
    private static Matrix4x4 RotationY(float radians) => Matrix4x4.CreateRotationY(radians);
    private static Matrix4x4 RotationZ(float radians) => Matrix4x4.CreateRotationZ(radians);

    private void Set(Part part, Matrix4x4 pose, Vector4 modulator, int indexOffset = 0) {
        int p = (int)part;
        fixed (float* poses = _frame.Poses, modulators = _frame.Modulators) {
            *(Matrix4x4*)(poses + p * 16) = pose;
            *(Vector4*)(modulators + p * 4) = modulator;
        }
        _draws.Add((_ranges[p].First + indexOffset, _ranges[p].Count));
    }

    private void Upload() {
        Frame frame = _frame;
        _gl.NamedBufferSubData(_uniforms, 0, (nuint)sizeof(Frame), &frame);
    }

    /// <summary>Made at the first draw: a vertex array belongs to the context that made it, and this may be built on another.</summary>
    private uint VertexArray() {
        if (_vao != 0) {
            return _vao;
        }
        _vao = _gl.CreateVertexArray();
        _gl.VertexArrayVertexBuffer(_vao, 0, _vbo, 0, (uint)sizeof(Vertex));
        _gl.VertexArrayElementBuffer(_vao, _ibo);
        _gl.EnableVertexArrayAttrib(_vao, 0);
        _gl.VertexArrayAttribFormat(_vao, 0, 3, VertexAttribType.Float, false, 0);
        _gl.VertexArrayAttribBinding(_vao, 0, 0);
        _gl.EnableVertexArrayAttrib(_vao, 1);
        _gl.VertexArrayAttribFormat(_vao, 1, 2, VertexAttribType.Float, false, 12);
        _gl.VertexArrayAttribBinding(_vao, 1, 0);
        _gl.EnableVertexArrayAttrib(_vao, 2);
        _gl.VertexArrayAttribFormat(_vao, 2, 4, VertexAttribType.UnsignedByte, true, 20);
        _gl.VertexArrayAttribBinding(_vao, 2, 0);
        _gl.EnableVertexArrayAttrib(_vao, 3);
        _gl.VertexArrayAttribIFormat(_vao, 3, 1, VertexAttribIType.UnsignedInt, 24);
        _gl.VertexArrayAttribBinding(_vao, 3, 0);
        return _vao;
    }

    public void Draw() {
        if (_draws.Count == 0) {
            return;
        }
        _gl.BindVertexArray(VertexArray());
        _gl.BindBufferBase(BufferTargetARB.UniformBuffer, UniformBinding, _uniforms);
        _gl.BindTextureUnit(TextureUnit, CelestialTexture);
        foreach ((int first, int count) in _draws) {
            _gl.DrawElements(PrimitiveType.Triangles, (uint)count, DrawElementsType.UnsignedInt, (void*)(first * sizeof(uint)));
        }
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_vbo);
        _gl.DeleteBuffer(_ibo);
        _gl.DeleteBuffer(_uniforms);
        _gl.DeleteTexture(CelestialTexture);
    }
}
