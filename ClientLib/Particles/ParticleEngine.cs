using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Particles;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Physics;
using Minecraft.Schemas;

namespace ClientLib.Particles;

/// <summary>
/// The client's particles: <c>ParticleEngine</c> and the <c>Level.addParticle</c> family that feeds it. Particles
/// are only seen, so the simulation is built to be cheap rather than to repeat vanilla's arithmetic: every
/// particle is a struct in one array, ticked by a switch on its motion, with vanilla's classes as the reference
/// for how each looks and moves. What the server or the player could tell apart is vanilla's: which packets
/// make particles, the Particles option, the distance cut off, and the group and spore blossom limits.
/// <p/>
/// It does nothing until <see cref="Enabled"/>, so a client that draws nothing pays nothing for it.
/// </summary>
public sealed partial class ParticleEngine {
    /// <summary><c>ParticleGroup.MAX_PARTICLES</c>, per group.</summary>
    public const int MaxParticles = 16384;
    private const int ReservoirSize = 4096;
    private const int ReservoirStart = 12288;

    /// <summary><c>ParticleLimit.SPORE_BLOSSOM</c>.</summary>
    public const int SporeBlossomLimit = 1000;

    /// <summary><c>ClientLevel.doAddParticle</c>'s 32 block cut off, squared.</summary>
    public const double MaxDistanceSqr = 1024.0;

    private readonly MinecraftClient _client;
    private ParticleState[] _particles = new ParticleState[256];
    private int _count;
    private ParticleState[] _pending = new ParticleState[64];
    private int _pendingCount;
    private int _quads, _emitters, _elderGuardians, _sporeBlossoms;
    private ClientLevel? _level;

    /// <summary>Items a breaking item particle shows, interned by item so the renderer resolves each once.</summary>
    private readonly List<Minecraft.Schemas.Items.ItemStack> _items = [];
    private readonly Dictionary<Identifier, int> _itemIndex = new();

    /// <summary><c>ParticleEngine.random</c>, which also draws <c>ClientLevel</c>'s and the packet listener's particle numbers.</summary>
    public ParticleRandom Random { get; } = new();

    /// <summary>Off by default: a client with nothing to draw them on ignores every particle.</summary>
    public bool Enabled { get; set; }

    /// <summary>Where the camera was last drawn from, which the distance cut off measures from; the player's eyes when unset.</summary>
    public Vec3d? CameraPosition { get; set; }

    /// <summary>Block tints for the particles that take them; untinted without.</summary>
    public IParticleColours? Colours { get; set; }

    /// <summary>
    /// The live particles, in the order they were added; emitters and elder guardians among them. Waits out an
    /// asynchronous tick, so a renderer reads them in <see cref="AfterTick"/> instead.
    /// </summary>
    public ReadOnlySpan<ParticleState> Particles {
        get {
            WaitForTick();
            return _particles.AsSpan(0, _count);
        }
    }

    /// <summary>The particles made since the last tick, waiting to join at the end of the next.</summary>
    internal ReadOnlySpan<ParticleState> Pending => _pending.AsSpan(0, _pendingCount);

    /// <summary>Increments whenever a tick has changed <see cref="Particles"/>.</summary>
    public int Version { get; private set; }

    public IReadOnlyList<Minecraft.Schemas.Items.ItemStack> Items => _items;

    /// <summary>Increments whenever <see cref="Items"/> is emptied, after which its indices mean other items.</summary>
    public int ItemGeneration { get; private set; }

    /// <summary><c>ParticleEngine.countParticles</c>: the groups' sizes.</summary>
    public (int Quads, int NoRender, int ElderGuardians) Counts => (_quads, _emitters, _elderGuardians);

    /// <summary>The particles entities make on the client, which run at the start of each <see cref="Tick"/>.</summary>
    public EntityParticles Entities { get; }

    public ParticleEngine(MinecraftClient client) {
        _client = client;
        _mainContext = new TickContext(Random, false);
        Entities = new EntityParticles(client, this);
    }

    /// <summary>
    /// The particle at a handle <see cref="CreateParticle"/> returned, until the end of the next tick. Take the
    /// reference again after making another particle, which may move the queue it sits in.
    /// </summary>
    public ref ParticleState this[int handle] => ref _pending[handle];

    #region Level.addParticle

    /// <summary><c>ClientLevel.addParticle</c>: within 32 blocks of the camera, and not on Minimal.</summary>
    public void AddParticle(IParticle options, double x, double y, double z, double xd, double yd, double zd) =>
        DoAddParticle(options, OverridesLimiter(options), false, x, y, z, xd, yd, zd);

    /// <summary><c>ClientLevel.addParticle</c> with the packet's flags: overriding the limiter skips both checks.</summary>
    public void AddParticle(IParticle options, bool overrideLimiter, bool alwaysShow, double x, double y, double z, double xd, double yd, double zd) =>
        DoAddParticle(options, OverridesLimiter(options) || overrideLimiter, alwaysShow, x, y, z, xd, yd, zd);

    /// <summary><c>ClientLevel.addAlwaysVisibleParticle</c>: Minimal still shows one in ten.</summary>
    public void AddAlwaysVisibleParticle(IParticle options, double x, double y, double z, double xd, double yd, double zd) =>
        DoAddParticle(options, false, true, x, y, z, xd, yd, zd);

    /// <inheritdoc cref="AddAlwaysVisibleParticle(IParticle, double, double, double, double, double, double)"/>
    public void AddAlwaysVisibleParticle(IParticle options, bool overrideLimiter, double x, double y, double z, double xd, double yd, double zd) =>
        DoAddParticle(options, OverridesLimiter(options) || overrideLimiter, true, x, y, z, xd, yd, zd);

    private void DoAddParticle(IParticle options, bool overrideLimiter, bool alwaysShow, double x, double y, double z, double xd, double yd, double zd) {
        if (!Enabled) {
            return;
        }
        ParticleStatus status = CalculateParticleLevel(alwaysShow);
        if (overrideLimiter) {
            CreateParticle(options, x, y, z, xd, yd, zd);
        }
        else if (!(Camera.DistanceToSqr(new Vec3d(x, y, z)) > MaxDistanceSqr) && status != ParticleStatus.Minimal) {
            CreateParticle(options, x, y, z, xd, yd, zd);
        }
    }

    private Vec3d Camera => CameraPosition ?? (_client.Player is { } player ? player.Position.Add(0, player.EyeHeight, 0) : Vec3d.Zero);

    /// <summary>
    /// <c>ClientLevel.calculateParticleLevel</c>: Decreased drops a third of what it is asked for to Minimal,
    /// and an always visible particle lifts a tenth of Minimal to Decreased first.
    /// </summary>
    internal ParticleStatus CalculateParticleLevel(bool alwaysShow) {
        ParticleStatus level = _client.Options.Particles;
        if (alwaysShow && level == ParticleStatus.Minimal && Random.NextInt(10) == 0) {
            level = ParticleStatus.Decreased;
        }
        if (level == ParticleStatus.Decreased && Random.NextInt(3) == 0) {
            level = ParticleStatus.Minimal;
        }
        return level;
    }

    /// <summary><c>ClientPacketListener.handleParticleEvent</c>: one particle thrown along the offset, or a gaussian cloud of them.</summary>
    public void HandlePacket(ClientBoundParticlePacket packet) {
        if (!Enabled) {
            return;
        }
        Minecraft.Schemas.Vec.Vec3<float> speed = packet.MaxSpeed;
        if (packet.ParticleCount == 0) {
            double xa = speed.X * packet.Offset.X;
            double ya = speed.Y * packet.Offset.Y;
            double za = speed.Z * packet.Offset.Z;
            AddParticle(packet.Particle, packet.LongDistance, packet.AlwaysVisible, packet.Position.X, packet.Position.Y, packet.Position.Z, xa, ya, za);
            return;
        }
        if (packet.Randomization != ClientBoundParticlePacket.RandomizationType.Default) {
            for (int i = 0; i < packet.ParticleCount; i++) {
                double xVariance = Random.NextDouble() * packet.Offset.X;
                double yVariance = Random.NextDouble() * packet.Offset.Y;
                double zVariance = Random.NextDouble() * packet.Offset.Z;
                double xa = speed.X, ya = speed.Y, za = speed.Z;
                if (packet.Randomization == ClientBoundParticlePacket.RandomizationType.AlternativeWithSpeed) {
                    xa *= Random.NextDouble();
                    ya *= Random.NextDouble();
                    za *= Random.NextDouble();
                }
                AddParticle(packet.Particle, packet.LongDistance, packet.AlwaysVisible,
                    packet.Position.X + xVariance, packet.Position.Y + yVariance, packet.Position.Z + zVariance, xa, ya, za);
            }
            return;
        }
        for (int i = 0; i < packet.ParticleCount; i++) {
            double xVariance = Random.NextGaussian() * packet.Offset.X;
            double yVariance = Random.NextGaussian() * packet.Offset.Y;
            double zVariance = Random.NextGaussian() * packet.Offset.Z;
            double xa = Random.NextGaussian() * speed.X;
            double ya = Random.NextGaussian() * speed.Y;
            double za = Random.NextGaussian() * speed.Z;
            AddParticle(packet.Particle, packet.LongDistance, packet.AlwaysVisible,
                packet.Position.X + xVariance, packet.Position.Y + yVariance, packet.Position.Z + zVariance, xa, ya, za);
        }
    }

    #endregion

    #region ParticleEngine

    /// <summary>
    /// <c>ParticleEngine.createParticle</c>, with no distance or option check: the particle joins at the end
    /// of the next tick. Returns a handle for <see cref="this[int]"/>, or -1 when the type makes nothing here.
    /// </summary>
    public int CreateParticle(IParticle options, double x, double y, double z, double xd, double yd, double zd) {
        if (!Ready() || !Providers.TryGetValue(options.Identifier, out Provider? provider)) {
            return -1;
        }
        return provider(this, options, x, y, z, xd, yd, zd);
    }

    /// <summary><c>ParticleEngine.createTrackingEmitter</c>: sixteen tries a tick for <paramref name="lifetime"/> ticks around the entity.</summary>
    public void CreateTrackingEmitter(ClientEntity entity, IParticle options, int lifetime = 3) {
        if (!Ready()) {
            return;
        }
        Box box = entity.BoundingBox;
        int handle = NewNoRender(entity.Position.X, entity.Position.Y + (box.MaxY - box.MinY) * 0.5, entity.Position.Z,
            entity.DeltaMovement.X, entity.DeltaMovement.Y, entity.DeltaMovement.Z);
        // Ticked as a copy: the particles its first tick makes may move the queue it sits in.
        ParticleState emitter = _pending[handle];
        emitter.Motion = ParticleMotion.TrackingEmitter;
        emitter.I0 = entity.Id;
        emitter.Lifetime = lifetime;
        emitter.TextureArg = InternEmitted(options);
        // The constructor ticks once.
        TickTrackingEmitter(ref emitter);
        _pending[handle] = emitter;
    }

    /// <summary>
    /// What tracking emitters spawn, by <see cref="ParticleState.TextureArg"/>; emptied whenever none is left. Only
    /// ever appended to between clears, by a new array when it grows, so the worker can read it while one is added.
    /// </summary>
    private IParticle[] _emitted = new IParticle[8];
    private int _emittedCount;
    private readonly Dictionary<IParticle, int> _emittedIndex = new();

    private int InternEmitted(IParticle options) {
        if (!_emittedIndex.TryGetValue(options, out int index)) {
            index = _emittedCount;
            if (index == _emitted.Length) {
                IParticle[] grown = new IParticle[index * 2];
                _emitted.CopyTo(grown, 0);
                _emitted = grown;
            }
            _emitted[index] = options;
            _emittedCount = index + 1;
            _emittedIndex[options] = index;
        }
        return index;
    }

    private void ForgetEmittedIfUnused() {
        if (_emitters > 0 || _emittedCount == 0) {
            return;
        }
        foreach (ref readonly ParticleState p in _pending.AsSpan(0, _pendingCount)) {
            if (p.Motion == ParticleMotion.TrackingEmitter) {
                return;
            }
        }
        Array.Clear(_emitted, 0, _emittedCount);
        _emittedCount = 0;
        _emittedIndex.Clear();
    }

    /// <summary>Whether particles can be made: enabled and in a level, a new level having cleared the old one's away.</summary>
    private bool Ready() {
        if (!ReferenceEquals(_level, _client.Level)) {
            WaitForTick();
            Publish();
            if (_level != null) {
                _level.LevelEvent -= LevelEvent;
            }
            _level = _client.Level;
            if (_level != null) {
                _shapes = new Box[(int)_level.Registry.Blocks.StatesCount][];
                _emission = BuildEmission(_level);
                _level.LevelEvent += LevelEvent;
            }
            Clear();
        }
        _mainContext.ChunkKey = long.MinValue;
        return Enabled && _level != null;
    }

    /// <summary><c>ParticleEngine.setLevel</c> and <c>clearParticles</c>.</summary>
    public void Clear() {
        WaitForTick();
        Publish();
        _count = 0;
        _pendingCount = 0;
        _quads = _emitters = _elderGuardians = _sporeBlossoms = 0;
        _publishedGuardians.Clear();
        Array.Clear(_emitted, 0, _emittedCount);
        _emittedCount = 0;
        _emittedIndex.Clear();
        _items.Clear();
        _itemIndex.Clear();
        ItemGeneration++;
        Version++;
    }

    /// <summary>
    /// <c>ParticleEngine.tick</c>: every particle ticks and the dead ones go, then what was added since the
    /// last tick joins its group, refused past the group's limit and ever more often within its reservoir.
    /// </summary>
    /// <remarks>
    /// When <see cref="Asynchronous"/>, this waits for and publishes the last tick if it is still running, then
    /// starts the next on the worker and returns.
    /// </remarks>
    public void Tick() {
        if (!Ready()) {
            return;
        }
        Entities.Tick(_level!);
        // What a frozen level's unfrozen entities make waits in the queue, as vanilla's particlesToAdd does.
        if (!_level!.TickRateManager.RunsNormally) {
            return;
        }
        TickCount++;
        if (Asynchronous) {
            WaitForTick();
            Publish();
            StartTick();
            return;
        }
        BeforeTick?.Invoke(_pending.AsSpan(0, _pendingCount), TickCount);
        Simulate(false);
        (_publishedGuardians, _workerGuardians) = (_workerGuardians, _publishedGuardians);
        ForgetEmittedIfUnused();
        Version++;
        AfterTick?.Invoke(_particles.AsSpan(0, _count), TickCount);
    }

    private bool JoinGroup(ref ParticleState p) {
        ref int size = ref p.Has(ParticleFlags.NoRender) ? ref _emitters : ref p.IsElderGuardian ? ref _elderGuardians : ref _quads;
        if (size >= MaxParticles) {
            return false;
        }
        if (size >= ReservoirStart) {
            float freeSpace = (MaxParticles - size) / (float)ReservoirSize;
            if (Context.Random.NextFloat() >= freeSpace * freeSpace) {
                return false;
            }
        }
        size++;
        return true;
    }

    private void Forget(ref ParticleState p) {
        if (p.Has(ParticleFlags.SporeLimited)) {
            Interlocked.Decrement(ref _sporeBlossoms);
        }
        if (p.Has(ParticleFlags.NoRender)) {
            _emitters--;
        }
        else if (p.IsElderGuardian) {
            _elderGuardians--;
        }
        else {
            _quads--;
        }
    }

    #endregion

    #region Making particles

    /// <summary>A handle to a fresh slot in the queue of particles waiting to join.</summary>
    private int Allocate() {
        if (_pendingCount == _pending.Length) {
            Array.Resize(ref _pending, _pending.Length * 2);
        }
        _pending[_pendingCount] = default;
        return _pendingCount++;
    }

    /// <summary><c>Particle(level, x, y, z)</c> and <c>SingleQuadParticle</c>'s size.</summary>
    internal int New(double x, double y, double z) {
        int handle = Allocate();
        ref ParticleState p = ref _pending[handle];
        p.Width = p.Height = 0.2F;
        p.X = p.Xo = x;
        p.Y = p.Yo = y;
        p.Z = p.Zo = z;
        p.Lifetime = (int)(4.0F / (Random.NextFloat() * 0.9F + 0.1F));
        p.Friction = 0.98F;
        p.Flags = ParticleFlags.HasPhysics;
        p.R = p.G = p.B = p.A = 1.0F;
        p.Size = 0.1F * (Random.NextFloat() * 0.5F + 0.5F) * 2.0F;
        p.SkyLight = 15;
        return handle;
    }

    /// <summary><c>Particle(level, x, y, z, xa, ya, za)</c>: the given motion, jittered and rescaled to a small random speed with a lift.</summary>
    internal int New(double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z);
        ref ParticleState p = ref _pending[handle];
        p.Xd = xa + (Random.NextFloat() * 2.0F - 1.0F) * 0.4F;
        p.Yd = ya + (Random.NextFloat() * 2.0F - 1.0F) * 0.4F;
        p.Zd = za + (Random.NextFloat() * 2.0F - 1.0F) * 0.4F;
        double speed = (Random.NextFloat() + Random.NextFloat() + 1.0F) * 0.15F;
        double dd = Math.Sqrt(p.Xd * p.Xd + p.Yd * p.Yd + p.Zd * p.Zd);
        p.Xd = p.Xd / dd * speed * 0.4F;
        p.Yd = p.Yd / dd * speed * 0.4F + 0.1F;
        p.Zd = p.Zd / dd * speed * 0.4F;
        return handle;
    }

    private int NewNoRender(double x, double y, double z, double xa, double ya, double za) {
        int handle = New(x, y, z, xa, ya, za);
        _pending[handle].Flags |= ParticleFlags.NoRender;
        return handle;
    }

    /// <summary><c>ParticleEngine.add</c>'s limit check, for a particle that counts against the spore blossom limit.</summary>
    internal bool TakeSporeBlossom() {
        if (Volatile.Read(ref _sporeBlossoms) >= SporeBlossomLimit) {
            return false;
        }
        Interlocked.Increment(ref _sporeBlossoms);
        return true;
    }

    internal int InternItem(Minecraft.Schemas.Items.ItemStack stack) {
        Identifier id = stack.Type.Identifier;
        if (!_itemIndex.TryGetValue(id, out int index)) {
            index = _items.Count;
            _items.Add(stack);
            _itemIndex[id] = index;
        }
        return index;
    }

    internal static int TypeId(IParticle options) => Minecraft.Data.Generated.VanillaRegistry.Data.Particles.GetProtocolId(options);

    #endregion

    #region The level

    /// <summary>Filled as states are met, sized for every state at once so either thread can fill it.</summary>
    private Box[]?[] _shapes = [];

    /// <summary>
    /// Each state's light emission, or <see cref="EmissiveRendering"/> for one that renders emissive: what
    /// <c>LightCoordsUtil.getLightCoords</c> reads off the block where a particle is.
    /// </summary>
    private byte[] _emission = [];

    private const byte EmissiveRendering = 255;

    /// <summary>Magma is the one block that always renders emissive; an active sculk sensor does too and is taken at its emission.</summary>
    private static byte[] BuildEmission(ClientLib.World.ClientLevel level) {
        byte[] emission = new byte[(int)level.Registry.Blocks.StatesCount];
        for (int state = 0; state < emission.Length; state++) {
            emission[state] = (byte)level.Registry.Blocks.GetByStateId((uint)state).LightEmission;
        }
        uint magma = Minecraft.Data.Generated.Block.MagmaBlock.StateId;
        if (magma < emission.Length) {
            emission[magma] = EmissiveRendering;
        }
        return emission;
    }

    private ClientChunk? ChunkAt(TickContext context, int x, int z) {
        long key = ClientLevel.Key(x >> 4, z >> 4);
        if (key != context.ChunkKey) {
            context.ChunkKey = key;
            context.Chunk = _level!.GetChunk(x >> 4, z >> 4);
        }
        return context.Chunk;
    }

    internal ushort StateAt(int x, int y, int z) => StateAt(Context, x, y, z);

    private ushort StateAt(TickContext context, int x, int y, int z) {
        int section = (y - _level!.MinY) >> 4;
        if ((uint)section >= (uint)_level.SectionCount) {
            return 0;
        }
        return ChunkAt(context, x, z)?.Sections[section].Get(x & 15, y & 15, z & 15) ?? 0;
    }

    internal IBlock BlockAt(int x, int y, int z) => _level!.Registry.Blocks.GetByStateId(StateAt(x, y, z));

    private static int Floor(double value) => (int)Math.Floor(value);

    /// <summary>The block's collision boxes, ignoring what <c>CollisionContext</c> could change, cached by state.</summary>
    private Box[] CollisionOf(ushort state) {
        Box[]?[] shapes = _shapes;
        if (state >= shapes.Length) {
            return BlockPhysicsData.Get(_level!.Registry, state).Collision;
        }
        return shapes[state] ??= BlockPhysicsData.Get(_level!.Registry, state).Collision;
    }

    /// <summary>
    /// <c>Particle.getLightCoords</c> at its tick: <c>LightCoordsUtil.getLightCoords</c> where it is, raised to the block's
    /// own emission, and full sky with no block light outside loaded chunks.
    /// </summary>
    private void SampleLight(TickContext context, ref ParticleState p) {
        int x = Floor(p.X), y = Floor(p.Y), z = Floor(p.Z);
        if (ChunkAt(context, x, z) is not { } chunk) {
            p.BlockLight = 0;
            p.SkyLight = 15;
            return;
        }
        // ClientLevel.GetBlockLight and GetSkyLight on the chunk already in hand.
        int section = (y - _level!.MinY) >> 4;
        if ((uint)section < (uint)_level.SectionCount) {
            p.BlockLight = (byte)chunk.GetBlockLight(x & 15, section, y & 15, z & 15);
            p.SkyLight = _level.DimensionType.HasSkyLight ? (byte)chunk.GetSkyLight(x & 15, section, y & 15, z & 15) : (byte)0;
            ushort state = chunk.Sections[section].Get(x & 15, y & 15, z & 15);
            byte emission = state < _emission.Length ? _emission[state] : (byte)0;
            if (emission == EmissiveRendering) {
                p.SkyLight = 15;
                p.BlockLight = 15;
            }
            else if (p.BlockLight < emission) {
                p.BlockLight = emission;
            }
        }
        else {
            p.BlockLight = 0;
            p.SkyLight = _level.DimensionType.HasSkyLight && section >= _level.SectionCount ? (byte)15 : (byte)0;
        }
    }

    /// <summary>Water, lava or nothing at a position, and how high it stands in its block.</summary>
    internal (byte Fluid, float Height) FluidAt(int x, int y, int z) {
        IBlock block = BlockAt(x, y, z);
        if (block.Fluid is not { } fluid) {
            return (0, 0);
        }
        byte kind = fluid.Key is "water" or "flowing_water" ? FluidWater : fluid.Key is "lava" or "flowing_lava" ? FluidLava : (byte)0;
        int level = block switch {
            Minecraft.Data.Generated.BlockTypes.WaterBlock water => water.Level,
            Minecraft.Data.Generated.BlockTypes.LavaBlock lava => lava.Level,
            _ => 0
        };
        // FlowingFluid.getOwnHeight on the amount, a falling fluid counting as a source.
        return (kind, level is 0 or >= 8 ? 8.0F / 9.0F : (8 - level) / 9.0F);
    }

    internal const byte FluidWater = 1, FluidLava = 2;

    internal bool InWater(double x, double y, double z) => FluidAt(Floor(x), Floor(y), Floor(z)).Fluid == FluidWater;

    internal bool IsAirAt(double x, double y, double z) => _level!.IsAir(StateAt(Floor(x), Floor(y), Floor(z)));

    #endregion

    #region Movement

    /// <summary>
    /// <c>Particle.move</c>. Collision sweeps the particle's box through the collision boxes of the blocks it
    /// passes, Y first and then the larger horizontal axis as <c>Entity.collideBoundingBox</c> does, but with
    /// each block's plain collision shape: no entities, no world border, and no shape a <c>CollisionContext</c>
    /// changes (scaffolding, powder snow and fluids answer as they would to nothing in particular). A fence's
    /// raised top is only found from above, the one place a particle meets it.
    /// </summary>
    internal void Move(ref ParticleState p, double xa, double ya, double za) {
        if (p.Has(ParticleFlags.StoppedByCollision)) {
            return;
        }
        double originalXa = xa, originalYa = ya, originalZa = za;
        if (p.HasPhysics && (xa != 0.0 || ya != 0.0 || za != 0.0) && xa * xa + ya * ya + za * za < 10000.0) {
            TickContext context = Context;
            double half = p.Width / 2.0;
            double minX = p.X - half, minY = p.Y, minZ = p.Z - half;
            double maxX = p.X + half, maxY = p.Y + p.Height, maxZ = p.Z + half;
            if (ya != 0.0) {
                ya = Sweep(context, 1, ya, minX, minY, minZ, maxX, maxY, maxZ);
                minY += ya;
                maxY += ya;
            }
            if (Math.Abs(xa) < Math.Abs(za)) {
                if (za != 0.0) {
                    za = Sweep(context, 2, za, minX, minY, minZ, maxX, maxY, maxZ);
                    minZ += za;
                    maxZ += za;
                }
                if (xa != 0.0) {
                    xa = Sweep(context, 0, xa, minX, minY, minZ, maxX, maxY, maxZ);
                }
            }
            else {
                if (xa != 0.0) {
                    xa = Sweep(context, 0, xa, minX, minY, minZ, maxX, maxY, maxZ);
                    minX += xa;
                    maxX += xa;
                }
                if (za != 0.0) {
                    za = Sweep(context, 2, za, minX, minY, minZ, maxX, maxY, maxZ);
                }
            }
        }
        p.X += xa;
        p.Y += ya;
        p.Z += za;
        if (Math.Abs(originalYa) >= 1.0E-5F && Math.Abs(ya) < 1.0E-5F) {
            p.Flags |= ParticleFlags.StoppedByCollision;
        }
        p.Set(ParticleFlags.OnGround, originalYa != ya && originalYa < 0.0);
        if (originalXa != xa) {
            p.Xd = 0.0;
        }
        if (originalZa != za) {
            p.Zd = 0.0;
        }
    }

    /// <summary>
    /// How far a box can go along one axis before a block's collision box stops it: <c>Shapes.collide</c> over the
    /// blocks the move passes through.
    /// </summary>
    private double Sweep(TickContext context, int axis, double distance, double minX, double minY, double minZ, double maxX, double maxY, double maxZ) {
        const double epsilon = 1.0E-7;
        double sweptMinX = minX, sweptMaxX = maxX, sweptMinY = minY, sweptMaxY = maxY, sweptMinZ = minZ, sweptMaxZ = maxZ;
        switch (axis) {
            case 0: if (distance < 0) sweptMinX += distance; else sweptMaxX += distance; break;
            case 1: if (distance < 0) sweptMinY += distance; else sweptMaxY += distance; break;
            default: if (distance < 0) sweptMinZ += distance; else sweptMaxZ += distance; break;
        }
        int x0 = Floor(sweptMinX - epsilon), x1 = Floor(sweptMaxX + epsilon);
        int y0 = Floor(sweptMinY - epsilon) - (axis == 1 && distance < 0 ? 1 : 0), y1 = Floor(sweptMaxY + epsilon);
        int z0 = Floor(sweptMinZ - epsilon), z1 = Floor(sweptMaxZ + epsilon);
        for (int y = y0; y <= y1; y++) {
            for (int z = z0; z <= z1; z++) {
                for (int x = x0; x <= x1; x++) {
                    ushort state = StateAt(context, x, y, z);
                    if (state == 0) {
                        continue;
                    }
                    foreach (Box local in CollisionOf(state)) {
                        double bMinX = local.MinX + x, bMaxX = local.MaxX + x;
                        double bMinY = local.MinY + y, bMaxY = local.MaxY + y;
                        double bMinZ = local.MinZ + z, bMaxZ = local.MaxZ + z;
                        switch (axis) {
                            case 0:
                                if (maxY - epsilon <= bMinY || minY + epsilon >= bMaxY || maxZ - epsilon <= bMinZ || minZ + epsilon >= bMaxZ) {
                                    continue;
                                }
                                distance = Clip(distance, minX, maxX, bMinX, bMaxX);
                                break;
                            case 1:
                                if (maxX - epsilon <= bMinX || minX + epsilon >= bMaxX || maxZ - epsilon <= bMinZ || minZ + epsilon >= bMaxZ) {
                                    continue;
                                }
                                distance = Clip(distance, minY, maxY, bMinY, bMaxY);
                                break;
                            default:
                                if (maxX - epsilon <= bMinX || minX + epsilon >= bMaxX || maxY - epsilon <= bMinY || minY + epsilon >= bMaxY) {
                                    continue;
                                }
                                distance = Clip(distance, minZ, maxZ, bMinZ, bMaxZ);
                                break;
                        }
                        if (Math.Abs(distance) < epsilon) {
                            return 0.0;
                        }
                    }
                }
            }
        }
        return distance;
    }

    private static double Clip(double distance, double min, double max, double boxMin, double boxMax) {
        const double epsilon = 1.0E-7;
        if (distance > 0.0 && max - epsilon <= boxMin) {
            return Math.Min(distance, boxMin - max);
        }
        if (distance < 0.0 && min + epsilon >= boxMax) {
            return Math.Max(distance, boxMax - min);
        }
        return distance;
    }

    #endregion
}
