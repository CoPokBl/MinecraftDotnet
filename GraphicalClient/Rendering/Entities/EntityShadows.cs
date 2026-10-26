using System.Numerics;
using System.Runtime.InteropServices;
using ClientLib.Maths;
using GraphicalClient.Assets.ResourcePacks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// The round shadows on the ground under entities, the <c>entity_shadows</c> geometry: one instance per entity,
/// the box below its feet that the shadow can fall in. Vanilla cuts the shadow into a quad on top of each full
/// block under the entity; here the shader pack finds the ground inside the box from the depth it has drawn, so
/// the CPU pays one instance whatever is below and a pack decides what the shadow lies on.
/// </summary>
public sealed unsafe class EntityShadows : IDisposable {
    [StructLayout(LayoutKind.Sequential)]
    private struct Instance {
        public Vector4 CentreRadius;
        public Vector4 PowerBottom;
        public Vector4 Uv;
    }

    private readonly GL _gl;
    private readonly EntityTextures _textures;
    private readonly uint _buffer;
    private uint _vao;
    private Instance[] _instances = new Instance[64];
    private int _count, _uploaded, _capacity;
    private Vector4 _uv;
    private bool _textureReady;
    private ClientLib.World.ClientLevel? _level;
    private int _skyDarken;

    public EntityShadows(GL gl, EntityTextures textures) {
        _gl = gl;
        _textures = textures;
        _buffer = gl.CreateBuffer();
    }

    /// <summary>
    /// Starts a frame's shadows with the pack's <c>textures/misc/shadow.png</c>, or the built in blob without one.
    /// <paramref name="skyDarken"/> is <c>Level.getSkyDarken</c>, which the brightness under each shadow is taken down by.
    /// </summary>
    public void Begin(ClientLib.World.ClientLevel level, int skyDarken) {
        _count = 0;
        _level = level;
        _skyDarken = skyDarken;
        EntityTexture? texture = _textures.Get("minecraft:textures/misc/shadow.png") ?? _textures.Get("shadow:blob", Blob);
        _textureReady = texture != null && texture != _textures.Pending;
        if (_textureReady) {
            _uv = new Vector4(texture!.U0, texture.V0, texture.U1, texture.V1);
        }
    }

    /// <summary>
    /// One entity's shadow at a world position. <paramref name="power"/> is vanilla's <c>pow</c>, the type's strength
    /// fading to nothing 16 blocks from the camera; it sets how dark the shadow is and how far down it reaches.
    /// </summary>
    public void Add(double x, double y, double z, Vec3d camera, float radius, float power) {
        if (!_textureReady || _level == null) {
            return;
        }
        // extractShadowPiece's getMaxLocalRawBrightness and Lightmap.getBrightness, which vanilla takes per block above
        // each top the shadow lies on; here once, at the block the feet are in, which is that block for an entity on
        // the ground and differs only where the light changes under a wide or a falling shadow.
        int bx = (int)Math.Floor(x), by = (int)Math.Floor(y), bz = (int)Math.Floor(z);
        int raw = Math.Max(_level.GetBlockLight(bx, by, bz), _level.GetSkyLight(bx, by, bz) - _skyDarken);
        if (raw <= 3) {
            return;
        }
        float level = raw / 15.0F;
        float brightness = Minecraft.Schemas.Mth.Lerp(_level.DimensionType.AmbientLight, level / (4.0F - 3.0F * level), 1.0F);
        // extractShadow's depth: the shadow lies on the tops of blocks from floor(y - depth) up to the feet. Vanilla
        // has none at all once that floor is above the feet's block, far off and on a slab; here the block under the
        // feet always takes one.
        float depth = Math.Max(0.0F, Math.Min(power / 0.5F - 1.0F, radius));
        double bottom = Math.Floor(y - depth);
        if (_count == _instances.Length) {
            Array.Resize(ref _instances, _count * 2);
        }
        _instances[_count++] = new Instance {
            CentreRadius = new Vector4((float)(x - camera.X), (float)(y - camera.Y), (float)(z - camera.Z), radius),
            PowerBottom = new Vector4(power, (float)(bottom - camera.Y) - 0.01F, brightness, 0),
            Uv = _uv
        };
    }

    /// <summary>A soft disc, darkest in the middle, for a client without a resource pack.</summary>
    private static TextureImage Blob() {
        const int size = 32;
        byte[] rgba = new byte[size * size * 4];
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                float dx = (x + 0.5F) / size * 2 - 1, dy = (y + 0.5F) / size * 2 - 1;
                float d = MathF.Sqrt(dx * dx + dy * dy);
                float alpha = Math.Clamp(1.0F - d, 0.0F, 1.0F);
                rgba[(y * size + x) * 4 + 3] = (byte)(MathF.Sqrt(alpha) * 255.0F);
            }
        }
        return new TextureImage(size, size, rgba);
    }

    public bool IsEmpty => _uploaded == 0;

    public void Upload() {
        _uploaded = _count;
        if (_count == 0) {
            return;
        }
        if (_capacity < _count) {
            _capacity = Math.Max(_count, _capacity * 2);
        }
        // Fresh storage every frame: the last frame's draws may still be reading the old.
        _gl.NamedBufferData(_buffer, (nuint)(_capacity * sizeof(Instance)), null, GLEnum.StreamDraw);
        fixed (Instance* p = _instances) {
            _gl.NamedBufferSubData(_buffer, 0, (nuint)(_count * sizeof(Instance)), p);
        }
    }

    /// <summary>Each shadow's box as 36 vertices the pack's vertex helpers place from the instance.</summary>
    public void Draw() {
        if (_uploaded == 0) {
            return;
        }
        if (_vao == 0) {
            // Made at the first draw: a vertex array belongs to the context that made it.
            _vao = _gl.CreateVertexArray();
            _gl.VertexArrayBindingDivisor(_vao, 0, 1);
            for (uint i = 0; i < 3; i++) {
                _gl.EnableVertexArrayAttrib(_vao, i);
                _gl.VertexArrayAttribFormat(_vao, i, 4, VertexAttribType.Float, false, i * 16);
                _gl.VertexArrayAttribBinding(_vao, i, 0);
            }
        }
        _gl.VertexArrayVertexBuffer(_vao, 0, _buffer, 0, (uint)sizeof(Instance));
        _gl.BindVertexArray(_vao);
        _gl.DrawArraysInstanced(PrimitiveType.Triangles, 0, 36, (uint)_uploaded);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_buffer);
    }
}
