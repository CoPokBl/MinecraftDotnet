using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.DimensionType;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ClientLib.World;

/// <summary>
/// The blocks, light and biomes the server has sent for one dimension. Game thread only; anything
/// that wants this data elsewhere (meshing) takes a copy.
/// </summary>
public sealed class ClientLevel {
    private readonly Dictionary<long, ClientChunk> _chunks = new();
    private readonly HashSet<ClientChunk> _blockEntityChunks = [];
    private readonly bool[] _airByState;

    public MinecraftRegistry Registry { get; }
    public Identifier Name { get; }
    public IDimensionType DimensionType { get; }
    public int MinY { get; }
    public int Height { get; }
    public int SectionCount { get; }
    public int MaxY => MinY + Height - 1;
    public int SeaLevel { get; }
    public bool IsFlat { get; }
    public long HashedSeed { get; }

    public long GameTime { get; set; }

    /// <summary>The connection's clocks, which outlive the level as vanilla's live on the packet listener.</summary>
    public ClientClockManager Clocks { get; }

    public TickRateManager TickRateManager { get; } = new();

    public Interaction.BlockPredictions Predictions { get; } = new();

    public WorldBorder WorldBorder { get; } = new();

    /// <summary><c>Level.getDefaultClockTime</c>: the dimension's <c>default_clock</c>, zero for a dimension without one.</summary>
    public long DefaultClockTime => DimensionType.DefaultClock is { } clock ? Clocks.GetTotalTicks(clock) : 0L;

    /// <summary><see cref="DefaultClockTime"/> part way to the next tick, for drawing.</summary>
    public double DefaultClockTimeAt(float partialTick) =>
        DimensionType.DefaultClock is { } clock ? Clocks.GetTicksAt(clock, TickRateManager.RunsNormally ? partialTick : 0.0F) : 0.0;

    /// <summary><c>getRespawnData().globalPos()</c>, as the server last set it; null until it does.</summary>
    public (Identifier Dimension, int X, int Y, int Z)? RespawnPosition { get; set; }

    public float RainLevel { get; set; }
    public float ThunderLevel { get; set; }

    public IReadOnlyCollection<ClientChunk> Chunks => _chunks.Values;

    /// <summary>
    /// The loaded chunks that have held a block entity since they arrived, a superset of those holding
    /// one now. What draws block entities walks this rather than every chunk each frame.
    /// </summary>
    public IReadOnlyCollection<ClientChunk> ChunksWithBlockEntities => _blockEntityChunks;

    /// <summary>A chunk arrived, or was replaced by a newer copy.</summary>
    public event Action<ClientChunk>? ChunkLoaded;

    public event Action<int, int>? ChunkUnloaded;

    /// <summary>A section's blocks or light changed, in section coordinates (y counts from the bottom of the world).</summary>
    public event Action<int, int, int>? SectionChanged;

    public event Action<int, int, int, ushort, ushort>? BlockChanged;

    /// <summary>
    /// <c>levelEvent</c> raised by the client itself rather than by a packet, with the event type, the
    /// position and the event's data. The server leaves the player who caused one of these out.
    /// </summary>
    public event Action<int, int, int, int, int>? LevelEvent;

    public void RaiseLevelEvent(int type, int x, int y, int z, int data) => LevelEvent?.Invoke(type, x, y, z, data);

    public ClientLevel(MinecraftRegistry registry, Identifier name, IDimensionType type, int seaLevel, bool flat, long hashedSeed,
        ClientClockManager? clocks = null) {
        Registry = registry;
        Clocks = clocks ?? new ClientClockManager();
        Name = name;
        DimensionType = type;
        MinY = type.MinY;
        Height = type.Height;
        SectionCount = Height >> 4;
        SeaLevel = seaLevel;
        IsFlat = flat;
        HashedSeed = hashedSeed;
        _airByState = AirTable(registry);
    }

    private static bool[] AirTable(MinecraftRegistry registry) {
        bool[] table = new bool[registry.Blocks.StatesCount];
        for (uint i = 0; i < table.Length; i++) {
            table[i] = registry.Blocks.GetByStateId(i).Air;
        }
        return table;
    }

    public ClientLight Light => _light ??= new ClientLight(this);
    private ClientLight? _light;

    /// <summary><c>ClientLevel.tickTime</c>.</summary>
    public void TickTime() {
        GameTime++;
        Clocks.Tick(GameTime);
    }

    public bool IsAir(uint state) => state < _airByState.Length && _airByState[state];

    public static long Key(int x, int z) => (long)x << 32 | (uint)z;

    public ClientChunk? GetChunk(int x, int z) => _chunks.GetValueOrDefault(Key(x, z));

    public bool HasChunk(int x, int z) => _chunks.ContainsKey(Key(x, z));

    public void AddChunk(ClientChunk chunk) {
        if (_chunks.TryGetValue(Key(chunk.X, chunk.Z), out ClientChunk? old)) {
            ClearBlockEntities(old);
        }
        _chunks[Key(chunk.X, chunk.Z)] = chunk;
        foreach (ClientBlockEntity blockEntity in chunk.BlockEntities.Values) {
            Register(chunk, blockEntity);
        }
        ChunkLoaded?.Invoke(chunk);
    }

    public void RemoveChunk(int x, int z) {
        if (_chunks.Remove(Key(x, z), out ClientChunk? chunk)) {
            ClearBlockEntities(chunk);
            ChunkUnloaded?.Invoke(x, z);
        }
    }

    public void Clear() {
        foreach (ClientChunk chunk in _chunks.Values.ToArray()) {
            RemoveChunk(chunk.X, chunk.Z);
        }
    }

    /// <summary>Air outside the world and in chunks that are not loaded, as vanilla's empty chunk answers.</summary>
    public ushort GetState(int x, int y, int z) {
        int section = (y - MinY) >> 4;
        if ((uint)section >= (uint)SectionCount) {
            return 0;
        }
        ClientChunk? chunk = GetChunk(x >> 4, z >> 4);
        return chunk?.Sections[section].Get(x & 15, y & 15, z & 15) ?? 0;
    }

    public IBlock GetBlock(int x, int y, int z) => Registry.Blocks.GetByStateId(GetState(x, y, z));

    /// <returns>False when the position is not in a loaded chunk.</returns>
    public bool SetState(int x, int y, int z, ushort state) {
        int section = (y - MinY) >> 4;
        if ((uint)section >= (uint)SectionCount) {
            return false;
        }
        ClientChunk? chunk = GetChunk(x >> 4, z >> 4);
        if (chunk == null) {
            return false;
        }

        ClientSection s = chunk.Sections[section];
        int index = (y & 15) << 8 | (z & 15) << 4 | (x & 15);
        ushort old = s.Get(index);
        if (old == state) {
            return true;
        }

        s.Set(index, state, IsAir(old), IsAir(state));
        UpdateBlockEntity(chunk, x, y, z, Registry.Blocks.GetByStateId(old), Registry.Blocks.GetByStateId(state));
        Light.BlockChanged(x, z, old, state);
        BlockChanged?.Invoke(x, y, z, old, state);
        MarkBlockDirty(x, y, z);
        return true;
    }

    /// <summary>The section holding the block, and any neighbour whose faces or smooth light it touches.</summary>
    public void MarkBlockDirty(int x, int y, int z) {
        int sx = x >> 4, sz = z >> 4, sy = (y - MinY) >> 4;
        int lx = x & 15, ly = (y - MinY) & 15, lz = z & 15;
        for (int dx = lx == 0 ? -1 : 0; dx <= (lx == 15 ? 1 : 0); dx++) {
            for (int dy = ly == 0 ? -1 : 0; dy <= (ly == 15 ? 1 : 0); dy++) {
                for (int dz = lz == 0 ? -1 : 0; dz <= (lz == 15 ? 1 : 0); dz++) {
                    MarkSectionDirty(sx + dx, sy + dy, sz + dz);
                }
            }
        }
    }

    public void MarkSectionDirty(int x, int sectionY, int z) {
        if ((uint)sectionY < (uint)SectionCount) {
            SectionChanged?.Invoke(x, sectionY, z);
        }
    }

    public int GetSkyLight(int x, int y, int z) {
        if (!DimensionType.HasSkyLight) {
            return 0;
        }
        int section = (y - MinY) >> 4;
        if (section >= SectionCount) {
            return 15;
        }
        if (section < 0) {
            return 0;
        }
        ClientChunk? chunk = GetChunk(x >> 4, z >> 4);
        return chunk?.GetSkyLight(x & 15, section, y & 15, z & 15) ?? 15;
    }

    public int GetBlockLight(int x, int y, int z) {
        int section = (y - MinY) >> 4;
        if ((uint)section >= (uint)SectionCount) {
            return 0;
        }
        ClientChunk? chunk = GetChunk(x >> 4, z >> 4);
        return chunk?.GetBlockLight(x & 15, section, y & 15, z & 15) ?? 0;
    }

    public ushort GetBiome(int x, int y, int z) {
        int section = Math.Clamp((y - MinY) >> 4, 0, SectionCount - 1);
        ClientChunk? chunk = GetChunk(x >> 4, z >> 4);
        return chunk?.GetBiome(x & 15, section, (y - MinY) & 15, z & 15) ?? 0;
    }

    /// <summary><c>Level.canHaveWeather</c>, which tests the level key against the end's; the end is named as its dimension type is.</summary>
    public bool CanHaveWeather => DimensionType.HasSkyLight && !DimensionType.HasCeiling && Name != Minecraft.Data.Generated.DimensionType.TheEnd.Identifier;

    /// <summary><c>Level.isRaining</c>.</summary>
    public bool IsRaining => CanHaveWeather && RainLevel > 0.2;

    /// <summary><c>BlockAndLightGetter.canSeeSky</c>.</summary>
    public bool CanSeeSky(int x, int y, int z) => GetSkyLight(x, y, z) >= 15;

    /// <summary>
    /// <c>LevelReader.getMaxLocalRawBrightness(pos, skyDarkening)</c>: the sky light less the darkening, or
    /// the block light, whichever is brighter; full outside the world's horizontal limit.
    /// </summary>
    public int MaxLocalRawBrightness(int x, int y, int z, int skyDarkening) =>
        x >= -30000000 && z >= -30000000 && x < 30000000 && z < 30000000
            ? Math.Max(GetSkyLight(x, y, z) - skyDarkening, GetBlockLight(x, y, z))
            : 15;

    /// <summary>
    /// <c>Level.getHeight</c> for a heightmap the server sends. This client keeps no heightmaps, so the
    /// column is scanned for the map's own predicate, which the sent map and <c>Heightmap.update</c> both hold to.
    /// </summary>
    public int GetHeight(HeightmapType type, int x, int z) {
        if (x < -30000000 || z < -30000000 || x >= 30000000 || z >= 30000000) {
            return SeaLevel + 1;
        }
        ClientChunk? chunk = GetChunk(x >> 4, z >> 4);
        if (chunk == null) {
            return MinY;
        }
        byte predicate = type switch {
            HeightmapType.WorldSurface => HeightmapStates.NotAir,
            HeightmapType.MotionBlocking => HeightmapStates.MotionBlocking,
            HeightmapType.MotionBlockingNoLeaves => HeightmapStates.MotionBlockingNoLeaves,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "The server sends no such heightmap")
        };
        for (int section = chunk.Sections.Length - 1; section >= 0; section--) {
            ClientSection blocks = chunk.Sections[section];
            if (blocks.NonAirCount == 0) {
                continue;
            }
            for (int y = 15; y >= 0; y--) {
                if ((HeightmapStates.FlagsOf(blocks.Get(x & 15, y, z & 15), Registry) & predicate) != 0) {
                    return MinY + (section << 4) + y + 1;
                }
            }
        }
        return MinY;
    }

    /// <summary><c>Level.precipitationAt</c>: what falls on the block while it rains, if it is open to the sky.</summary>
    public BiomeClimate.Precipitation PrecipitationAt(int x, int y, int z) {
        if (!IsRaining || !CanSeeSky(x, y, z) || GetHeight(HeightmapType.MotionBlocking, x, z) > y) {
            return BiomeClimate.Precipitation.None;
        }
        return BiomeClimate.PrecipitationAt(BiomeClimate.Biome(this, x, y, z), x, y, z, SeaLevel);
    }

    /// <summary><c>Level.isRainingAt</c>.</summary>
    public bool IsRainingAt(int x, int y, int z) => PrecipitationAt(x, y, z) == BiomeClimate.Precipitation.Rain;

    /// <summary><c>ClientLevel.getPrecipitationAt</c>: the biome's precipitation in a loaded chunk, whatever the weather.</summary>
    public BiomeClimate.Precipitation GetPrecipitationAt(int x, int y, int z) =>
        HasChunk(x >> 4, z >> 4)
            ? BiomeClimate.PrecipitationAt(BiomeClimate.Biome(this, x, y, z), x, y, z, SeaLevel)
            : BiomeClimate.Precipitation.None;

    /// <summary><c>Level.blockEntityTickers</c>, in the order the block entities arrived.</summary>
    private readonly List<ClientBlockEntity> _tickers = [];
    private readonly HashSet<ClientBlockEntity> _ticking = [];

    /// <summary>A block entity arrived with a chunk or a block, or was replaced; the renderer drops anything it kept for the old one.</summary>
    public event Action<ClientBlockEntity>? BlockEntityAdded;

    /// <summary>
    /// <c>Level.getBlockEntity</c>, which on the client is <c>LevelChunk.getBlockEntity(pos, IMMEDIATE)</c>:
    /// a block that should have one and has none gets a fresh one.
    /// </summary>
    public ClientBlockEntity? GetBlockEntity(int x, int y, int z) {
        if ((uint)((y - MinY) >> 4) >= (uint)SectionCount || GetChunk(x >> 4, z >> 4) is not { } chunk) {
            return null;
        }
        if (chunk.BlockEntities.TryGetValue(new Vec3<int>(x, y, z), out ClientBlockEntity? existing)) {
            return existing;
        }
        if (ClientBlockEntity.Create(Registry, x, y, z, GetBlock(x, y, z)) is not { } created) {
            return null;
        }
        chunk.BlockEntities[new Vec3<int>(x, y, z)] = created;
        Register(chunk, created);
        return created;
    }

    /// <summary><c>removeBlockEntity</c>.</summary>
    public void RemoveBlockEntity(int x, int y, int z) {
        if (GetChunk(x >> 4, z >> 4) is { } chunk && chunk.BlockEntities.Remove(new Vec3<int>(x, y, z), out ClientBlockEntity? removed)) {
            removed.Removed = true;
        }
    }

    /// <summary><c>setBlockEntity</c> for one the client made itself, such as a piston's moving block; false when the block cannot hold it.</summary>
    public bool SetBlockEntity(ClientBlockEntity blockEntity) {
        if (GetChunk(blockEntity.X >> 4, blockEntity.Z >> 4) is not { } chunk || !ClientBlockEntity.IsValid(blockEntity.Type, GetBlock(blockEntity.X, blockEntity.Y, blockEntity.Z))) {
            return false;
        }
        blockEntity.State = GetBlock(blockEntity.X, blockEntity.Y, blockEntity.Z);
        Vec3<int> position = new(blockEntity.X, blockEntity.Y, blockEntity.Z);
        if (chunk.BlockEntities.TryGetValue(position, out ClientBlockEntity? previous) && previous != blockEntity) {
            previous.Removed = true;
        }
        chunk.BlockEntities[position] = blockEntity;
        Register(chunk, blockEntity);
        return true;
    }

    /// <summary>
    /// <c>Level.blockEvent</c>: the block's <c>triggerEvent</c>, a piston's own or, for a block entity
    /// block, its block entity's. The other blocks with one (note blocks) only make sounds and particles.
    /// </summary>
    public bool BlockEvent(int x, int y, int z, int b0, int b1) {
        IBlock state = GetBlock(x, y, z);
        if (state is Minecraft.Data.Generated.BlockTypes.PistonBlock or Minecraft.Data.Generated.BlockTypes.StickyPistonBlock) {
            return PistonEvents.TriggerEvent(this, x, y, z, state, b0, b1);
        }
        return GetBlockEntity(x, y, z)?.TriggerEvent(b0, b1) ?? false;
    }

    /// <summary><c>Level.tickBlockEntities</c>: a frozen tick rate drops the removed tickers but runs none.</summary>
    public void TickBlockEntities(BlockEntityTickContext context, bool runsNormally = true) {
        for (int i = 0; i < _tickers.Count; i++) {
            ClientBlockEntity blockEntity = _tickers[i];
            if (blockEntity.Removed || !blockEntity.HasClientTicker) {
                _tickers.RemoveAt(i--);
                _ticking.Remove(blockEntity);
                continue;
            }
            if (runsNormally) {
                blockEntity.Tick(context);
            }
        }
    }

    private void Register(ClientChunk chunk, ClientBlockEntity blockEntity) {
        _blockEntityChunks.Add(chunk);
        blockEntity.Level = this;
        blockEntity.Removed = false;
        UpdateTicker(blockEntity);
        BlockEntityAdded?.Invoke(blockEntity);
    }

    /// <summary><c>updateBlockEntityTicker</c>: whether the state's ticker exists can change with the state.</summary>
    private void UpdateTicker(ClientBlockEntity blockEntity) {
        if (blockEntity.HasClientTicker && _ticking.Add(blockEntity)) {
            _tickers.Add(blockEntity);
        }
    }

    private void ClearBlockEntities(ClientChunk chunk) {
        _blockEntityChunks.Remove(chunk);
        foreach (ClientBlockEntity blockEntity in chunk.BlockEntities.Values) {
            blockEntity.Removed = true;
        }
    }

    /// <summary>The block entity half of <c>LevelChunk.setBlockState</c>.</summary>
    private void UpdateBlockEntity(ClientChunk chunk, int x, int y, int z, IBlock oldState, IBlock state) {
        Vec3<int> position = new(x, y, z);
        bool blockChanged = !oldState.Identifier.Equals(state.Identifier);
        if (blockChanged && oldState.BlockEntity != null && !KeepsBlockEntity(state, oldState)) {
            RemoveBlockEntity(x, y, z);
        }
        if (state.BlockEntity == null) {
            return;
        }
        if (chunk.BlockEntities.TryGetValue(position, out ClientBlockEntity? blockEntity) && !ClientBlockEntity.IsValid(blockEntity.Type, state)) {
            RemoveBlockEntity(x, y, z);
            blockEntity = null;
        }
        if (blockEntity == null) {
            if (ClientBlockEntity.Create(Registry, x, y, z, state) is { } created) {
                chunk.BlockEntities[position] = created;
                Register(chunk, created);
            }
            return;
        }
        blockEntity.State = state;
        UpdateTicker(blockEntity);
    }

    /// <summary>
    /// <c>shouldChangedStateKeepBlockEntity</c>: a copper chest or statue weathering keeps its contents.
    /// The <c>copper_chests</c> and <c>copper_golem_statues</c> tags are exactly the blocks of those classes.
    /// </summary>
    private static bool KeepsBlockEntity(IBlock state, IBlock oldState) =>
        BlockClasses.Is(state.Identifier, BlockClass.CopperChestBlock) && BlockClasses.Is(oldState.Identifier, BlockClass.CopperChestBlock)
        || BlockClasses.Is(state.Identifier, BlockClass.CopperGolemStatueBlock) && BlockClasses.Is(oldState.Identifier, BlockClass.CopperGolemStatueBlock);
}
