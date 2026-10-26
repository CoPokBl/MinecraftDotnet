using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Biomes;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Schemas.Chunks;

namespace ManagedServer.Terrain.Features;

/// <summary>The biome at an absolute block position.</summary>
public delegate IBiome BiomeAtBlock(int x, int y, int z);

/// <summary>
/// The biome stored in a 4x4x4 cell, which is what a chunk's own grid holds.
/// </summary>
/// <remarks>
/// Not the same question as <see cref="BiomeAtBlock"/>, which puts the zoomer in front of this: a
/// level answers a block position through <c>BiomeManager</c> and a cell through the grid.
/// </remarks>
public delegate IBiome BiomeAtQuart(int quartX, int quartY, int quartZ);

/// <summary>
/// A neighbouring chunk's terrain, as the carvers left it.
/// </summary>
/// <remarks>
/// A pure function of the seed and the chunk position. It is what a neighbour's two <c>_WG</c>
/// heightmaps are read off, and what its blocks are underneath whatever has been decorated onto it.
/// </remarks>
public delegate IColumnStates NeighbourTerrain(int chunkX, int chunkZ);

/// <summary>
/// <see cref="IGenerationUnit.ReadNeighbour"/>: a generated neighbour's blocks, or null after
/// replaying what has been forked into one that is not generated yet.
/// </summary>
public delegate ChunkData? NeighbourBlocks(int chunkX, int chunkZ, ForkedBlock forked);

/// <summary>
/// An <see cref="IFeatureLevel"/> over one chunk being generated: the staging column for the chunk
/// itself, a fork for everything written outside it, and the terrain of the neighbours it reads.
/// </summary>
/// <remarks>
/// Writes inside the chunk go into the same <see cref="ChunkColumn"/> the surface pass filled, so a
/// feature sees what the features before it placed, as vanilla's do. Writes outside go through the
/// generation API's dynamic fork, which lands them in the target chunk whether it exists yet or not,
/// and are remembered here so a decorator asking whether the position it just filled is empty is told
/// the truth.
/// <p/>
/// <b>Reads outside the chunk answer the neighbour as the world holds it</b>, which is what vanilla's
/// <c>WorldGenRegion</c> spanning the three by three does: a neighbour that decorated first with its
/// features on, and one that has not with its terrain and whatever other chunks forked into it. A
/// neighbour is never further than its features step in vanilla, so a generated one here can differ
/// only by what a player has since changed. Answering the terrain alone puts an ore blob or a tree
/// crossing the border over a neighbour's dirt or canopy as though it were bare stone and air, and
/// answering air is worse: no ore blob would ever cross a chunk border, and a chunk would come out
/// with about 70% of the blob material vanilla gives it.
/// <p/>
/// <b>Heightmaps split into a frozen pair and a live four</b>, which is vanilla's and not an
/// optimisation. <c>ProtoChunk.setBlockState</c> updates only the heightmaps of the chunk's current
/// status, and by the features step that set no longer holds <c>WORLD_SURFACE_WG</c> or
/// <c>OCEAN_FLOOR_WG</c>. So a placement modifier reading a <c>_WG</c> heightmap gets the terrain
/// surface, and one reading <c>MOTION_BLOCKING</c> gets the surface with the trees already on it.
/// </remarks>
public sealed class ChunkFeatureLevel : IFeatureLevel {
    /// <summary>One per <see cref="HeightmapType"/>, indexed by its value.</summary>
    private const int HeightmapCount = 6;

    private const int NotPrimed = int.MinValue;

    private readonly ChunkColumn _column;
    private readonly IBlockSetter _outside;
    private readonly BiomeAtBlock _biomes;
    private readonly NeighbourTerrain? _neighbours;
    private readonly NeighbourBlocks? _world;
    private readonly int _chunkX;
    private readonly int _chunkZ;
    private readonly int _originX;
    private readonly int _originZ;

    /// <summary>The four heightmaps the features step maintains, over the chunk as it is written.</summary>
    private readonly ColumnHeights _heights;

    /// <summary>
    /// The two <c>_WG</c> heightmaps, over the terrain as the carvers left it.
    /// </summary>
    /// <remarks>
    /// A separate source rather than a separate rule over the same one. <c>ChunkStatus.CARVERS</c> is
    /// the first status whose <c>heightmapsAfter</c> is the final four rather than the worldgen pair,
    /// so these stop being maintained the moment carving ends and answer the raw ground level for the
    /// whole of decoration, whatever is written on top of it and whichever chunk wrote it.
    /// </remarks>
    private readonly ColumnHeights _worldgenHeights;

    /// <summary>
    /// The eight neighbours' terrain, blocks and heightmaps, by <see cref="SlotOf"/>, each built on the
    /// first read into it.
    /// </summary>
    /// <remarks>
    /// Most chunks read one or two of them and a chunk with nothing near its borders reads none, so
    /// none of this is built up front. The centre slot is left empty: the chunk itself is the column.
    /// The blocks are taken once, on that first read, as vanilla's region would see them then.
    /// </remarks>
    private readonly IColumnStates?[] _neighbourTerrain = new IColumnStates[9];
    private readonly IColumnStates?[] _neighbourBlocks = new IColumnStates[9];
    private readonly ColumnHeights?[] _neighbourHeights = new ColumnHeights[9];
    private readonly ColumnHeights?[] _neighbourWorldgenHeights = new ColumnHeights[9];

    /// <summary>What this pass has forked outside the chunk, so a read there sees it.</summary>
    /// <remarks>
    /// The neighbour's terrain answers what was already there; this answers what this pass has put on
    /// top of it. Without it a jungle tree hangs its vines through the leaves it just placed across the
    /// border, because every one of those positions reads as untouched ground.
    /// <p/>
    /// Allocated on the first write outside, since most chunks never make one.
    /// </remarks>
    private Dictionary<long, uint>? _forked;

    public bool HasSkyLight { get; init; } = true;

    public required GenerationHeightContext WorldGeneration { get; init; }

    /// <summary>
    /// The positions marked for post processing, per section from the bottom and in the order they
    /// were marked within one, which is the order <c>postProcessGeneration</c> walks them.
    /// </summary>
    private SortedDictionary<int, List<Vec3<int>>>? _postProcessing;

    public ChunkFeatureLevel(ChunkColumn column, IBlockSetter outside, BiomeAtBlock biomes,
        MinecraftRegistry registry, int chunkX, int chunkZ, int minY, int maxY, int seaLevel, long seed,
        RandomSource levelRandom, NeighbourTerrain? neighbours = null, NeighbourBlocks? world = null) {

        LevelRandom = levelRandom;
        _column = column;
        _outside = outside;
        _biomes = biomes;
        _neighbours = neighbours;
        _world = world;
        _chunkX = chunkX;
        _chunkZ = chunkZ;
        _originX = chunkX << 4;
        _originZ = chunkZ << 4;

        Registry = registry;
        MinY = minY;
        MaxY = maxY;
        SeaLevel = seaLevel;
        Seed = seed;
        Blocks = FeatureBlockData.For(registry);

        _heights = new ColumnHeights(column, this);

        // The terrain, which is where the pair stopped being maintained. A chunk sitting at the
        // carvers step updates the four live maps and not these two, so what a neighbour that
        // decorated first forked in raises MOTION_BLOCKING here and leaves WORLD_SURFACE_WG alone.
        //
        // A level driven without a terrain source falls back to the column, and that copy is filled
        // now rather than on first read: the column is the buffer the features write into, so a
        // position asked about only after something was placed there would answer the ground level
        // with that on top of it.
        if (neighbours is null) {
            _worldgenHeights = new ColumnHeights(column, this);
            _worldgenHeights.PrimeAll();
        } else {
            _worldgenHeights = new ColumnHeights(neighbours(chunkX, chunkZ), this);
        }
    }

    public MinecraftRegistry Registry { get; }
    public int MinY { get; }
    public int MaxY { get; }
    public int SeaLevel { get; }
    public long Seed { get; }
    public RandomSource LevelRandom { get; }
    public FeatureBlockData Blocks { get; }

    /// <summary>
    /// Whether this level can answer the real terrain at a column, vanilla's
    /// <c>WorldGenRegion.hasChunk</c>: the chunk being generated and, once its terrain can be reached,
    /// the ring around it.
    /// </summary>
    public bool IsLoaded(int x, int z) {
        return InChunk(x, z) || (_neighbours is not null && SlotOf(x, z) >= 0);
    }

    /// <summary>Whether a column is the chunk being generated, which is what may be written into.</summary>
    private bool InChunk(int x, int z) {
        return (x >> 4) == _chunkX && (z >> 4) == _chunkZ;
    }

    /// <summary>
    /// Which of the nine chunks of the region a column belongs to, or -1 for one outside it.
    /// </summary>
    private int SlotOf(int x, int z) {
        int dx = (x >> 4) - _chunkX;
        int dz = (z >> 4) - _chunkZ;

        if (dx is < -1 or > 1 || dz is < -1 or > 1) {
            return -1;
        }

        return ((dx + 1) * 3) + dz + 1;
    }

    /// <remarks>
    /// Only a position in the chunk being generated is kept. Upstream a mark outside it lands in the
    /// neighbour's own list; the only callers here are structure pieces, which clip to this chunk.
    /// </remarks>
    public void MarkForPostProcessing(int x, int y, int z) {
        if (!InChunk(x, z) || y < MinY || y >= MaxY) {
            return;
        }

        _postProcessing ??= [];
        int section = (y - MinY) >> 4;

        if (!_postProcessing.TryGetValue(section, out List<Vec3<int>>? marked)) {
            _postProcessing[section] = marked = [];
        }

        marked.Add(new Vec3<int>(x, y, z));
    }

    /// <summary>
    /// <c>LevelChunk.postProcessGeneration</c>: each marked block settles against its neighbours.
    /// </summary>
    /// <remarks>
    /// <b>A deliberate divergence in timing.</b> Upstream this runs in <c>prepareTickingChunk</c>,
    /// once all eight neighbours are full; here it runs as soon as this chunk has decorated, since the
    /// generator has no stage after its neighbours. A marked block on the border therefore reads a
    /// neighbour that has not decorated yet as bare terrain: a mineshaft fence joins the stone its
    /// neighbour's corridor is about to carve away. Measured against the real server, that is 4 fence
    /// blocks in <c>WorldParityConformanceTest</c>'s plains village and 9 over its nether scenes, every
    /// one on a chunk edge, against 271 interior fences this settles correctly.
    /// <p/>
    /// Each write is <c>UPDATE_KNOWN_SHAPE</c>, so it settles that block alone, and later positions
    /// read the earlier ones' answers. A liquid is ticked upstream rather than reshaped, and the
    /// generator has no fluid ticks.
    /// </remarks>
    public void PostProcess() {
        if (_postProcessing is null) {
            return;
        }

        foreach (List<Vec3<int>> marked in _postProcessing.Values) {
            foreach (Vec3<int> pos in marked) {
                uint state = GetState(pos.X, pos.Y, pos.Z);
                // instanceof LiquidBlock upstream, which BlockState.liquid stands for exactly.
                if (Blocks.IsLiquid(state)) {
                    continue;
                }

                IBlock settled = FeatureShapeUpdate.UpdateFromNeighbourShapes(
                    Registry.Blocks.GetByStateId(state), this, pos);

                if (settled.StateId != state) {
                    SetState(pos.X, pos.Y, pos.Z, settled.StateId);
                }
            }
        }

        _postProcessing = null;
    }

    public uint GetState(int x, int y, int z) {
        if (InChunk(x, z)) {
            return _column.Read(x & 15, y, z & 15);
        }

        // What this pass forked out there sits on top of the terrain, so it is asked about first.
        if (_forked is not null && _forked.TryGetValue(Key(x, y, z), out uint forked)) {
            return forked;
        }

        return BlocksAt(x, z) is { } blocks ? blocks.Read(x & 15, y, z & 15) : AirState;
    }

    public void SetState(int x, int y, int z, uint stateId) {
        if (y < MinY || y >= MaxY) {
            return;
        }

        if (!InChunk(x, z)) {
            _outside.SetBlockState(x, y, z, stateId);
            (_forked ??= [])[Key(x, y, z)] = stateId;

            // Vanilla's WorldGenRegion writes through to the neighbour's own heightmaps, so a feature
            // that fills across a border and then asks how high the ground is there is answered with
            // what it put down. The map is built here if nothing has read it yet: built on a later
            // read it would be primed off the terrain alone and miss this write.
            HeightsAt(x, z)?.Update(x & 15, y, z & 15, stateId);

            Writes++;

            if (CurrentWriter >= 0) {
                Writers[new Vec3<int>(x, y, z)] = CurrentWriter;
            }

            return;
        }

        _column.Write(x & 15, y, z & 15, stateId);
        _heights.Update(x & 15, y, z & 15, stateId);
        Writes++;

        if (CurrentWriter >= 0) {
            Writers[new Vec3<int>(x, y, z)] = CurrentWriter;
        }
    }

    /// <summary>
    /// How many blocks have been written through this level, which is how the parity dump tells the
    /// structure pass's writes from the feature pass's without either knowing about the other.
    /// </summary>
    public int Writes { get; private set; }

    /// <summary>
    /// Which feature is writing, and where each write went, so a parity difference can name the
    /// feature on this side as well as vanilla's.
    /// </summary>
    /// <remarks>
    /// Sparse rather than an array over the region: a decoration pass writes a few thousand positions
    /// out of a million, and only the parity dump ever reads this.
    /// </remarks>
    public int CurrentWriter { get; set; } = -1;

    public Dictionary<Vec3<int>, int> Writers { get; } = [];

    public int GetHeight(HeightmapType type, int x, int z) {
        if (InChunk(x, z)) {
            return Frozen(type)
                ? _worldgenHeights.Get(type, x & 15, z & 15)
                : _heights.Get(type, x & 15, z & 15);
        }

        ColumnHeights? heights = Frozen(type) ? WorldgenHeightsAt(x, z) : HeightsAt(x, z);

        // The bottom of the world, which reads as "nothing here". HeightmapPlacement drops a position
        // whose height is not above the minimum, so a feature scattered past the region is skipped
        // rather than placed at the void.
        return heights?.Get(type, x & 15, z & 15) ?? MinY;
    }

    public IBiome GetBiome(int x, int y, int z) => _biomes(x, y, z);

    private uint AirState => Minecraft.Data.Generated.Block.Air.StateId;

    /// <summary>
    /// Whether a heightmap stopped being maintained when the chunk reached its carvers step.
    /// </summary>
    private static bool Frozen(HeightmapType type) {
        return type is HeightmapType.WorldSurfaceWorldgen or HeightmapType.OceanFloorWorldgen;
    }

    /// <summary>The neighbour's terrain, built on the first read into it.</summary>
    private IColumnStates? TerrainAt(int x, int z) {
        if (_neighbours is null) {
            return null;
        }

        int slot = SlotOf(x, z);
        if (slot < 0) {
            return null;
        }

        return _neighbourTerrain[slot] ??= _neighbours((x >> 4), (z >> 4));
    }

    /// <summary>The neighbour as the world holds it, taken on the first read into it.</summary>
    private IColumnStates? BlocksAt(int x, int z) {
        if (TerrainAt(x, z) is not { } terrain) {
            return null;
        }

        int slot = SlotOf(x, z);
        if (_neighbourBlocks[slot] is { } blocks) {
            return blocks;
        }

        if (_world is null) {
            return _neighbourBlocks[slot] = terrain;
        }

        Dictionary<int, uint>? forked = null;
        ChunkData? generated = _world(x >> 4, z >> 4, (forkX, forkY, forkZ, state) =>
            (forked ??= [])[OverlaidColumns.Index(forkX & 15, forkY, forkZ & 15)] = state);

        return _neighbourBlocks[slot] = generated is not null
            ? new GeneratedColumns(generated, MinY, MaxY)
            : forked is not null
                ? new OverlaidColumns(terrain, forked)
                : terrain;
    }

    /// <summary>
    /// The four live heightmaps over a neighbour as the world holds it, which vanilla primes off the
    /// blocks there on the first ask and keeps up with every write after.
    /// </summary>
    private ColumnHeights? HeightsAt(int x, int z) {
        if (BlocksAt(x, z) is not { } blocks) {
            return null;
        }

        int originX = x & ~15;
        int originZ = z & ~15;

        return _neighbourHeights[SlotOf(x, z)] ??= new ColumnHeights(blocks, this,
            (localX, y, localZ) => GetState(originX + localX, y, originZ + localZ));
    }

    /// <summary>The two <c>_WG</c> heightmaps over a neighbour, which stopped at its terrain.</summary>
    private ColumnHeights? WorldgenHeightsAt(int x, int z) {
        if (TerrainAt(x, z) is not { } terrain) {
            return null;
        }

        return _neighbourWorldgenHeights[SlotOf(x, z)] ??= new ColumnHeights(terrain, this);
    }

    /// <summary>A position packed into a long, on <c>BlockPos</c>'s own field widths.</summary>
    private static long Key(int x, int y, int z) {
        return ((long)(x & 0x3FFFFFF) << 38) | ((long)(z & 0x3FFFFFF) << 12) | (uint)(y & 0xFFF);
    }

    /// <summary>
    /// The six heightmaps over one chunk's blocks, primed per column on first use.
    /// </summary>
    /// <remarks>
    /// One of these covers the chunk being generated and one covers each neighbour that is read into.
    /// Per column rather than up front, because most of a chunk's 256 columns are never asked about: a
    /// chunk runs a couple of dozen placements and each reads one column.
    /// <p/>
    /// The two <c>_WG</c> maps are primed like the rest and then never updated. They stop being
    /// maintained when a chunk reaches the carvers step, which is what makes them the raw ground level
    /// rather than the top of whatever has been decorated onto it.
    /// </remarks>
    private sealed class ColumnHeights {
        private readonly IColumnStates _states;
        private readonly ChunkFeatureLevel _level;
        private readonly Func<int, int, int, uint> _current;
        private readonly int[] _values = new int[HeightmapCount * 256];
        private readonly bool[] _primed = new bool[256];

        /// <param name="current">
        /// The column as it stands now, for the rescan after a top block is taken away. A neighbour's
        /// terrain is the column before this pass forked anything into it, which is right for priming
        /// and wrong for that.
        /// </param>
        public ColumnHeights(IColumnStates states, ChunkFeatureLevel level,
            Func<int, int, int, uint>? current = null) {

            _states = states;
            _level = level;
            _current = current ?? states.Read;

            Array.Fill(_values, NotPrimed);
        }

        /// <summary>Fills every column now, for a map whose source is about to be written into.</summary>
        public void PrimeAll() {
            for (int local = 0; local < 256; local++) {
                Prime(local);
            }
        }

        public int Get(HeightmapType type, int localX, int localZ) {
            int local = (localX << 4) | localZ;
            Prime(local);
            return _values[((int)type * 256) + local];
        }

        /// <summary><c>Heightmap.update</c> for the four heightmaps the features step maintains.</summary>
        public void Update(int localX, int y, int localZ, uint stateId) {
            int local = (localX << 4) | localZ;
            Prime(local);

            byte flags = HeightmapStates.FlagsOf(stateId, _level.Registry);

            Update(HeightmapType.WorldSurface, local, localX, localZ, y,
                (flags & HeightmapStates.NotAir) != 0);
            Update(HeightmapType.OceanFloor, local, localX, localZ, y,
                _level.Blocks.BlocksMotionInHeightmapAt(stateId));
            Update(HeightmapType.MotionBlocking, local, localX, localZ, y,
                (flags & HeightmapStates.MotionBlocking) != 0);
            Update(HeightmapType.MotionBlockingNoLeaves, local, localX, localZ, y,
                (flags & HeightmapStates.MotionBlockingNoLeaves) != 0);
        }

        /// <summary>
        /// Fills a column's six heightmaps, scanning down from the highest block the terrain passes
        /// wrote rather than from the top of the world.
        /// </summary>
        private void Prime(int local) {
            if (_primed[local]) {
                return;
            }

            int localX = local >> 4;
            int localZ = local & 15;
            int minY = _level.MinY;

            int worldSurface = minY;
            int oceanFloor = minY;
            int motionBlocking = minY;
            int motionBlockingNoLeaves = minY;

            bool haveSurface = false;
            bool haveFloor = false;
            bool haveMotion = false;
            bool haveNoLeaves = false;

            for (int y = _states.HighestWritten(localX, localZ) - 1; y >= minY; y--) {
                uint state = _states.Read(localX, y, localZ);
                byte flags = HeightmapStates.FlagsOf(state, _level.Registry);

                if (!haveSurface && (flags & HeightmapStates.NotAir) != 0) {
                    worldSurface = y + 1;
                    haveSurface = true;
                }

                if (!haveFloor && _level.Blocks.BlocksMotionInHeightmapAt(state)) {
                    oceanFloor = y + 1;
                    haveFloor = true;
                }

                if (!haveMotion && (flags & HeightmapStates.MotionBlocking) != 0) {
                    motionBlocking = y + 1;
                    haveMotion = true;
                }

                if (!haveNoLeaves && (flags & HeightmapStates.MotionBlockingNoLeaves) != 0) {
                    motionBlockingNoLeaves = y + 1;
                    haveNoLeaves = true;
                }

                if (haveSurface && haveFloor && haveMotion && haveNoLeaves) {
                    break;
                }
            }

            Store(HeightmapType.WorldSurfaceWorldgen, local, worldSurface);
            Store(HeightmapType.WorldSurface, local, worldSurface);
            Store(HeightmapType.OceanFloorWorldgen, local, oceanFloor);
            Store(HeightmapType.OceanFloor, local, oceanFloor);
            Store(HeightmapType.MotionBlocking, local, motionBlocking);
            Store(HeightmapType.MotionBlockingNoLeaves, local, motionBlockingNoLeaves);

            _primed[local] = true;
        }

        private void Store(HeightmapType type, int local, int height) {
            _values[((int)type * 256) + local] = height;
        }

        private void Update(HeightmapType type, int local, int localX, int localZ, int y, bool matches) {
            int index = ((int)type * 256) + local;
            int firstAvailable = _values[index];

            if (y <= firstAvailable - 2) {
                return;
            }

            if (matches) {
                if (y >= firstAvailable) {
                    _values[index] = y + 1;
                }

                return;
            }

            if (firstAvailable - 1 != y) {
                return;
            }

            // The top block of the column was taken away, so the next one down has to be found.
            // Vanilla rescans for the same reason and this is the only branch that costs anything.
            for (int below = y - 1; below >= _level.MinY; below--) {
                if (_level.Matches(type, _current(localX, below, localZ))) {
                    _values[index] = below + 1;
                    return;
                }
            }

            _values[index] = _level.MinY;
        }
    }

    private bool Matches(HeightmapType type, uint stateId) {
        byte flags = HeightmapStates.FlagsOf(stateId, Registry);

        return type switch {
            HeightmapType.WorldSurface or HeightmapType.WorldSurfaceWorldgen =>
                (flags & HeightmapStates.NotAir) != 0,
            HeightmapType.OceanFloor or HeightmapType.OceanFloorWorldgen => Blocks.BlocksMotionInHeightmapAt(stateId),
            HeightmapType.MotionBlocking => (flags & HeightmapStates.MotionBlocking) != 0,
            HeightmapType.MotionBlockingNoLeaves => (flags & HeightmapStates.MotionBlockingNoLeaves) != 0,
            _ => false
        };
    }

    /// <summary>A generated neighbour's blocks, read off a frozen copy of the chunk.</summary>
    private sealed class GeneratedColumns(ChunkData chunk, int minY, int maxY) : IColumnStates {
        public uint Read(int localX, int blockY, int localZ) {
            return blockY < minY || blockY >= maxY
                ? Minecraft.Data.Generated.Block.Air.StateId
                : chunk.GetBlock(localX, blockY - minY, localZ);
        }

        public int HighestWritten(int localX, int localZ) => maxY;
    }

    /// <summary>A neighbour not generated yet: its terrain, under what other chunks forked into it.</summary>
    private sealed class OverlaidColumns : IColumnStates {
        private readonly IColumnStates _terrain;
        private readonly Dictionary<int, uint> _forked;
        private readonly int[] _highest = new int[256];

        public OverlaidColumns(IColumnStates terrain, Dictionary<int, uint> forked) {
            _terrain = terrain;
            _forked = forked;

            Array.Fill(_highest, int.MinValue);
            foreach (int index in forked.Keys) {
                int column = index & 0xFF;
                _highest[column] = Math.Max(_highest[column], (index >> 8) + 1);
            }
        }

        public static int Index(int localX, int blockY, int localZ) {
            return (blockY << 8) | (localZ << 4) | localX;
        }

        public uint Read(int localX, int blockY, int localZ) {
            return _forked.TryGetValue(Index(localX, blockY, localZ), out uint state)
                ? state
                : _terrain.Read(localX, blockY, localZ);
        }

        public int HighestWritten(int localX, int localZ) {
            return Math.Max(_terrain.HighestWritten(localX, localZ), _highest[(localZ << 4) | localX]);
        }
    }
}
