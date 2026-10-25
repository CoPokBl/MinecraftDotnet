using System.Numerics;
using System.Runtime.InteropServices;
using ClientLib.Maths;
using ClientLib.Particles;
using GraphicalClient.Rendering.Entities;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Particles;

/// <summary>
/// The quad particles on the GPU, one instance each. The instances are rebuilt once a tick, when the particles
/// move, on the thread that ticked them; the vertex stage does everything that changes within a tick: the partial
/// tick's position, facing the camera, the size, alpha and light that vanilla works out from the age at each frame.
/// A frame costs one small uniform write and two instanced draws whatever the count, plus one upload when a tick's
/// instances arrive. Vanilla does not sort translucent particles and neither does this.
/// </summary>
public sealed unsafe class ParticleRenderer : IDisposable {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Instance {
        public Vector3 Position;
        public Vector3 Previous;
        public float Size;
        public uint AgeLife;
        public Vector4 Rotation;
        public Vector4 Uv;
        public uint Colour;
        public uint Packed;
    }

    /// <summary>
    /// One tick's instances in a buffer of their own, mapped for good so the thread that builds them writes them
    /// straight to the GPU: opaque from the start, translucent from the end down, relative to the block corner the
    /// camera was in.
    /// </summary>
    private sealed class Built {
        public uint Buffer;
        public Instance* Data;
        public int Capacity;

        /// <summary>Set when the buffer stops being drawn, and waited on before it is written again.</summary>
        public nint Fence;
        public int OpaqueCount, TranslucentCount;
        public Vec3d Origin;
        public int Tick = -1;
    }

    /// <summary>The layer field's value for a quad textured from the entity atlas rather than the block atlas.</summary>
    private const uint EntityAtlasLayer = 0xFFF;
    private const uint FacingCamera = 0, FacingCameraY = 1, FacingFixed = 2;

    /// <summary>Shriek's tilt, <c>ShriekParticle.MAGICAL_X_ROT</c>.</summary>
    private static readonly Quaternion ShriekRotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, -1.0472F);

    private readonly GL _gl;
    private readonly ParticleSprites _sprites;
    private readonly EntityTextures _textures;
    private readonly BlockModels _models;
    private readonly ItemRenderer _items;
    private readonly uint _uniforms;
    private uint _vao;

    /// <summary>
    /// Three sets of instances: the one being built after a tick, the newest built one waiting for a frame, and
    /// the one on the GPU. Only the swaps between the last two are shared, under <see cref="_swap"/>.
    /// </summary>
    private Built _building = new(), _waiting = new(), _front = new();
    private readonly object _swap = new();
    private bool _waitingReady;
    private int _drawnOpaque, _drawnTranslucent;
    private Vec3d _nextOrigin;

    /// <summary>Sprites looked up on the main thread before a tick, which building only reads.</summary>
    private readonly Dictionary<uint, (int Layer, bool Translucent)> _blockSprites = new();
    private readonly List<EntityTexture?> _itemSprites = [];
    private int _itemGeneration = -1;
    private (int Layer, bool Translucent) _missingBlockSprite;
    private bool _missingResolved;

    public ParticleRenderer(GL gl, ParticleSprites sprites, EntityTextures textures, BlockModels models, ItemRenderer items) {
        _gl = gl;
        _sprites = sprites;
        _textures = textures;
        _models = models;
        _items = items;
        _uniforms = gl.CreateBuffer();
        gl.NamedBufferStorage(_uniforms, (nuint)sizeof(Vector4), null, BufferStorageMask.DynamicStorageBit);
    }

    /// <summary>The quads drawn last frame, opaque then translucent.</summary>
    public (int Opaque, int Translucent) Drawn => (_drawnOpaque, _drawnTranslucent);

    public bool IsEmpty(bool translucent) => (translucent ? _drawnTranslucent : _drawnOpaque) == 0;

    /// <summary>
    /// On the main thread before a tick: the sprites of the particles about to join, which may need the pack or the
    /// item models, and the block corner the next instances are placed from.
    /// </summary>
    public void Prepare(ParticleEngine engine, ReadOnlySpan<ParticleState> joining, Vec3d camera) {
        _nextOrigin = new Vec3d(Math.Floor(camera.X), Math.Floor(camera.Y), Math.Floor(camera.Z));
        // No tick adds quads but the ones joining, so this many is as many as the build can hold.
        Reserve(_building, engine.Counts.Quads + engine.Counts.ElderGuardians + joining.Length);
        if (engine.ItemGeneration != _itemGeneration) {
            _itemGeneration = engine.ItemGeneration;
            _itemSprites.Clear();
        }
        if (!_missingResolved) {
            _missingBlockSprite = BlockSprite(0);
            _missingResolved = true;
        }
        foreach (ref readonly ParticleState p in joining) {
            switch (p.Texture) {
                case ParticleTexture.Block or ParticleTexture.BlockQuarter:
                    BlockSprite((uint)p.TextureArg);
                    break;
                case ParticleTexture.ItemQuarter:
                    ItemSprite(engine, p.TextureArg);
                    break;
            }
        }
        // A texture that was still loading is asked for again.
        for (int i = 0; i < _itemSprites.Count; i++) {
            if (_itemSprites[i] == null) {
                ItemSprite(engine, i);
            }
        }
    }

    /// <summary>Makes sure the buffer the next build writes is out of the GPU's hands and big enough.</summary>
    private void Reserve(Built built, int count) {
        if (built.Fence != 0) {
            _gl.ClientWaitSync(built.Fence, SyncObjectMask.Bit, ulong.MaxValue);
            _gl.DeleteSync(built.Fence);
            built.Fence = 0;
        }
        if (built.Capacity >= count && built.Buffer != 0) {
            return;
        }
        if (built.Buffer != 0) {
            _gl.DeleteBuffer(built.Buffer);
        }
        built.Capacity = Math.Max(count, Math.Max(1024, built.Capacity * 2));
        built.Buffer = _gl.CreateBuffer();
        nuint size = (nuint)(built.Capacity * sizeof(Instance));
        const BufferStorageMask storage = BufferStorageMask.MapWriteBit | BufferStorageMask.MapPersistentBit | BufferStorageMask.MapCoherentBit;
        _gl.NamedBufferStorage(built.Buffer, size, null, storage);
        built.Data = (Instance*)_gl.MapNamedBufferRange(built.Buffer, 0, size,
            MapBufferAccessMask.WriteBit | MapBufferAccessMask.PersistentBit | MapBufferAccessMask.CoherentBit);
    }

    /// <summary>Turns a tick's particles into instances, on the thread that ticked them. No GL calls.</summary>
    public void Build(ReadOnlySpan<ParticleState> particles, int tick) {
        Built built = _building;
        built.Origin = _nextOrigin;
        built.Tick = tick;
        int opaque = 0, translucent = built.Capacity;
        foreach (ref readonly ParticleState p in particles) {
            if (!p.Visible || opaque == translucent) {
                continue;
            }
            Instance instance = Make(in p, built.Origin, out bool isTranslucent);
            built.Data[isTranslucent ? --translucent : opaque++] = instance;
        }
        built.OpaqueCount = opaque;
        built.TranslucentCount = built.Capacity - translucent;
        lock (_swap) {
            (_building, _waiting) = (_waiting, built);
            _waitingReady = true;
        }
    }

    private Instance Make(in ParticleState p, Vec3d origin, out bool isTranslucent) {
        Vector4 uv;
        uint layer = EntityAtlasLayer;
        bool translucent = p.Translucent;
        switch (p.Texture) {
            case ParticleTexture.Sprite or ParticleTexture.SpriteQuarter: {
                EntityTexture[] frames = _sprites.Set(p.Type);
                EntityTexture texture = frames.Length == 0 ? _textures.Missing : frames[p.Texture == ParticleTexture.SpriteQuarter ? 0 : Frame(in p, frames.Length)];
                uv = p.Texture == ParticleTexture.SpriteQuarter ? Quarter(texture, p.Uo, p.Vo) : new Vector4(texture.U0, texture.V0, texture.U1, texture.V1);
                break;
            }
            case ParticleTexture.Block or ParticleTexture.BlockQuarter: {
                (int blockLayer, bool blockTranslucent) = _blockSprites.GetValueOrDefault((uint)p.TextureArg, _missingBlockSprite);
                layer = (uint)blockLayer;
                translucent = blockTranslucent;
                uv = p.Texture == ParticleTexture.Block ? new Vector4(0, 0, 1, 1) : new Vector4((p.Uo + 1.0F) / 4.0F, p.Vo / 4.0F, p.Uo / 4.0F, (p.Vo + 1.0F) / 4.0F);
                break;
            }
            default: {
                EntityTexture texture = (uint)p.TextureArg < (uint)_itemSprites.Count ? _itemSprites[p.TextureArg] ?? _textures.Missing : _textures.Missing;
                uv = Quarter(texture, p.Uo, p.Vo);
                break;
            }
        }

        Instance instance = new() {
            Position = new Vector3((float)(p.X - origin.X), (float)(p.Y - origin.Y), (float)(p.Z - origin.Z)),
            Previous = new Vector3((float)(p.Xo - origin.X), (float)(p.Yo - origin.Y), (float)(p.Zo - origin.Z)),
            Size = p.Size,
            AgeLife = (uint)Math.Clamp(p.Age, 0, 0xFFFF) | (uint)Math.Clamp(p.Lifetime, 0, 0xFFFF) << 16,
            Rotation = new Vector4(p.RollO, p.Roll, 0, 0),
            Uv = uv,
            Colour = Byte(p.R) | Byte(p.G) << 8 | Byte(p.B) << 16 | Byte(p.A) << 24
        };
        uint facing = p.Facing == ParticleFacing.CameraY ? FacingCameraY : FacingCamera;
        switch (p.Facing) {
            case ParticleFacing.Shriek:
                facing = FacingFixed;
                instance.Rotation = AsVector(ShriekRotation);
                break;
            case ParticleFacing.Vibration: {
                // VibrationSignalParticle.extract: along the way to the target, with a slow sway about the quad's own axis.
                facing = FacingFixed;
                float sway = MathF.Sin((p.Age - MathF.Tau) * 0.05F) * 2.0F;
                float pitch = p.F2 + MathF.PI / 2.0F;
                instance.Rotation = AsVector(Quaternion.CreateFromAxisAngle(Vector3.UnitY, p.F0) * Quaternion.CreateFromAxisAngle(Vector3.UnitX, -pitch)
                    * Quaternion.CreateFromAxisAngle(Vector3.UnitY, sway));
                break;
            }
        }
        instance.Packed = layer | facing << 12 | (uint)p.SizeCurve << 14 | (uint)p.AlphaCurve << 17 | (uint)p.LightMode << 19
            | (uint)(p.SkyLight & 15) << 22 | (uint)(p.BlockLight & 15) << 26;
        isTranslucent = translucent;
        return instance;
    }

    private static Vector4 AsVector(Quaternion q) => new(q.X, q.Y, q.Z, q.W);

    private static uint Byte(float value) => (uint)Math.Clamp((int)(value * 255.0F + 0.5F), 0, 255);

    /// <summary><c>SpriteSet.get</c>: a fixed or random frame, a share of the set, or the share of its life a particle has lived.</summary>
    private static int Frame(in ParticleState p, int frames) => p.SpriteMode switch {
        ParticleSpriteMode.ByAge => Math.Clamp(p.Lifetime <= 0 ? 0 : (int)((long)p.Age * (frames - 1) / p.Lifetime), 0, frames - 1),
        ParticleSpriteMode.Fraction => Math.Clamp(p.SpriteDen <= 0 ? 0 : p.SpriteNum * (frames - 1) / p.SpriteDen, 0, frames - 1),
        _ => (int)((uint)p.SpriteNum % (uint)frames)
    };

    /// <summary><c>TerrainParticle</c> and <c>BreakingItemParticle</c>'s quarter of a sprite, mirrored across as they draw it.</summary>
    private static Vector4 Quarter(EntityTexture texture, float uo, float vo) =>
        new(texture.U((uo + 1.0F) / 4.0F), texture.V(vo / 4.0F), texture.U(uo / 4.0F), texture.V((vo + 1.0F) / 4.0F));

    /// <summary>A block state's particle sprite, and whether it has partly transparent texels, <c>Layer.bySprite</c>.</summary>
    private (int Layer, bool Translucent) BlockSprite(uint state) {
        if (!_blockSprites.TryGetValue(state, out (int, bool) sprite)) {
            (int layer, Assets.ResourcePacks.TextureImage image) = _models.Particle(state);
            bool translucent = false;
            for (int i = 3; i < image.Rgba.Length; i += 4) {
                if (image.Rgba[i] is > 0 and < 255) {
                    translucent = true;
                    break;
                }
            }
            sprite = (layer, translucent);
            _blockSprites[state] = sprite;
        }
        return sprite;
    }

    /// <summary><c>ItemStackRenderState.pickParticleMaterial</c>, taken as the first textured face of the item's model on the ground.</summary>
    private EntityTexture ItemSprite(ParticleEngine engine, int index) {
        while (_itemSprites.Count <= index) {
            _itemSprites.Add(null);
        }
        if (_itemSprites[index] is { } known) {
            return known;
        }
        EntityTexture? texture = null;
        if (index < engine.Items.Count && _items.Resolve(engine.Items[index], ItemDisplayContext.Ground) is { } model) {
            texture = model.Layers.SelectMany(layer => layer.Quads).Select(quad => quad.Texture).FirstOrDefault();
        }
        // A texture still loading is asked for again next time rather than kept.
        if (texture != null && !ReferenceEquals(texture, _textures.Pending)) {
            _itemSprites[index] = texture;
        }
        return texture ?? _textures.Missing;
    }

    /// <summary>
    /// Takes up the newest built instances if a tick has finished since the last frame, and sends where they are
    /// relative to this frame's camera. Until the instances of the latest tick arrive, the ones on the GPU are drawn
    /// where that tick left them, which is where a partial tick of zero puts the particles.
    /// </summary>
    public void Upload(Vec3d camera, float partialTick, int tick) {
        Built? previous = null;
        lock (_swap) {
            if (_waitingReady) {
                previous = _front;
                (_front, _waiting) = (_waiting, _front);
                _waitingReady = false;
            }
        }
        Built front = _front;
        if (previous != null) {
            // Draws already sent may still read the buffer that was in front; the next build into it waits for them.
            if (previous.Buffer != 0 && previous.Fence == 0) {
                previous.Fence = _gl.FenceSync(SyncCondition.SyncGpuCommandsComplete, SyncBehaviorFlags.None);
            }
            _drawnOpaque = front.OpaqueCount;
            _drawnTranslucent = front.TranslucentCount;
            if (_vao != 0 && front.Buffer != 0) {
                _gl.VertexArrayVertexBuffer(_vao, 0, front.Buffer, 0, (uint)sizeof(Instance));
            }
        }
        float partial = front.Tick == tick ? partialTick : 1.0F;
        Vector4 origin = new((float)(front.Origin.X - camera.X), (float)(front.Origin.Y - camera.Y), (float)(front.Origin.Z - camera.Z), partial);
        _gl.NamedBufferSubData(_uniforms, 0, (nuint)sizeof(Vector4), &origin);
    }

    public void Draw(bool translucent) {
        int count = translucent ? _drawnTranslucent : _drawnOpaque;
        if (count == 0) {
            return;
        }
        _gl.BindVertexArray(VertexArray());
        _gl.BindBufferBase(BufferTargetARB.UniformBuffer, 1, _uniforms);
        _gl.DrawArraysInstancedBaseInstance(PrimitiveType.TriangleStrip, 0, 4, (uint)count, translucent ? (uint)(_front.Capacity - count) : 0);
        _gl.BindVertexArray(0);
    }

    /// <summary>Made at the first draw: a vertex array belongs to the context that made it, and the renderer may be built on another.</summary>
    private uint VertexArray() {
        if (_vao != 0) {
            return _vao;
        }
        _vao = _gl.CreateVertexArray();
        _gl.VertexArrayVertexBuffer(_vao, 0, _front.Buffer, 0, (uint)sizeof(Instance));
        _gl.VertexArrayBindingDivisor(_vao, 0, 1);
        Attribute(0, 3, VertexAttribType.Float, false, 0);
        Attribute(1, 3, VertexAttribType.Float, false, 12);
        Attribute(2, 1, VertexAttribType.Float, false, 24);
        IntegerAttribute(3, 28);
        Attribute(4, 4, VertexAttribType.Float, false, 32);
        Attribute(5, 4, VertexAttribType.Float, false, 48);
        Attribute(6, 4, VertexAttribType.UnsignedByte, true, 64);
        IntegerAttribute(7, 68);
        return _vao;

        void Attribute(uint index, int size, VertexAttribType type, bool normalised, uint offset) {
            _gl.EnableVertexArrayAttrib(_vao, index);
            _gl.VertexArrayAttribFormat(_vao, index, size, type, normalised, offset);
            _gl.VertexArrayAttribBinding(_vao, index, 0);
        }

        void IntegerAttribute(uint index, uint offset) {
            _gl.EnableVertexArrayAttrib(_vao, index);
            _gl.VertexArrayAttribIFormat(_vao, index, 1, VertexAttribIType.UnsignedInt, offset);
            _gl.VertexArrayAttribBinding(_vao, index, 0);
        }
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        foreach (Built built in (Built[])[_building, _waiting, _front]) {
            if (built.Fence != 0) {
                _gl.DeleteSync(built.Fence);
            }
            _gl.DeleteBuffer(built.Buffer);
        }
        _gl.DeleteBuffer(_uniforms);
    }
}
