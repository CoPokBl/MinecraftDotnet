using System.Collections;
using System.Collections.Concurrent;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Lighting;

/// <summary>
/// Computes block and sky light the way the vanilla light engine does, a chunk at a time.
/// <para>
/// Vanilla spreads light with a breadth first search, taking <c>max(1, getLightDampening())</c>
/// off a level for each block it crosses into and stopping where <c>Shapes.faceShapeOccludes</c>
/// holds for the two faces meeting at the boundary. Sky light is that same search seeded from the
/// column sources: everything from the top of the world down to the first occluded edge holds
/// fifteen. All of the block data that decides those comes off <see cref="BlockLightTable"/>,
/// which CodeGen writes out of the server jar, so what lives here is only the search.
/// </para>
/// <para>
/// Light reaches fifteen blocks, so a chunk's light depends on the three by three of chunks around
/// it and on nothing further out: a source beyond that ring is at least sixteen steps from every
/// block in the middle chunk. The nine are lit together as one region for that reason. Lighting
/// them one at a time and trading levels along the borders is cheaper but cannot be right, because
/// it never sees a torch in a diagonal neighbour whose light arrives through the chunk between
/// them.
/// </para>
/// <para>
/// The one thing deliberately not modelled is vanilla dropping the light data for an all air
/// section whose twenty six neighbours are air as well, which stops light entering or crossing it.
/// It cannot change what a client sees: such a section is sixteen blocks across, so no path
/// through one arrives anywhere with a level left, and a path that only dips into it is never
/// shorter than one along its edge. Which sections hold light is decided by the client from the
/// blocks it already has, exactly as the server decides it, and the rest are inferred.
/// </para>
/// </summary>
public sealed class CalculatedLightingProvider : ILightingProvider {
    // Faces and the directions light travels through them, in BlockLightTable's order.
    private const int FaceEast = 0;
    private const int FaceWest = 1;
    private const int FaceUp = 2;
    private const int FaceDown = 3;
    private const int FaceSouth = 4;
    private const int FaceNorth = 5;

    private const int EastBit = 1 << FaceEast;
    private const int WestBit = 1 << FaceWest;
    private const int UpBit = 1 << FaceUp;
    private const int DownBit = 1 << FaceDown;
    private const int SouthBit = 1 << FaceSouth;
    private const int NorthBit = 1 << FaceNorth;
    private const int AllDirections = 0x3F;

    // Slots are the nine chunks of the region, row major from the north west corner. A slot's slab
    // is where its blocks sit in the workspace: its own index when the chunk is loaded, the shared
    // void slab when it isn't.
    private const int SlotCount = 9;
    private const int CentreSlot = 4;
    private const int VoidSlab = 9;
    private const int SlabCount = 10;

    /// <summary>
    /// A queue entry holds a block's index within its slab in seventeen bits, which puts the
    /// ceiling at thirty two sections. Twice the height of the vanilla overworld.
    /// </summary>
    private const int MaxSections = 32;

    // Queue entry: the directions still worth trying from a block, and where it is. The level it
    // was queued at is the bucket it sits in.
    private const int IndexShift = 6;
    private const int SlabShift = 23;
    private const int IndexMask = 0x1FFFF;

    // Which leaves the top of an int free to carry an emitter's level around until it is seeded.
    private const int EmissionShift = 27;
    private const int EmitterEntryMask = (1 << EmissionShift) - 1;

    /// <summary>The region's columns, with a border of columns that never hold a sky source.</summary>
    private const int ColumnGrid = 3 * 16 + 2;

    /// <summary>
    /// A column whose sources run past the bottom of the world, which is vanilla's negative
    /// infinity: no block in it is the lowest source, and nothing beside it is in its shadow.
    /// </summary>
    private const int SourcesBelowWorld = -1;

    private readonly ConcurrentDictionary<Vec2<int>, CacheEntry> _cache = new();

    [ThreadStatic] private static Workspace? _workspace;

    /// <summary>
    /// An entry outlives the light it holds, because <see cref="Invalidate"/> has to be visible to a
    /// <see cref="Compute"/> that is already running. <see cref="Stamp"/> is what makes it visible:
    /// a computation reads it before it starts and only publishes if it has not moved, so a result
    /// that was already stale by the time it finished is thrown away instead of installed over the
    /// invalidation. Removing the entry instead loses that, and the loser wins.
    /// </summary>
    private sealed class CacheEntry {
        public readonly Lock Lock = new();
        public LightData? Data;
        public bool HasSkyLight;
        public int Stamp;
    }

    /// <param name="registry">
    /// Unused. What light needs is the dampening and face shapes of a state, and
    /// <see cref="BlockLightTable"/> is the only place either exists: the blocks in a registry
    /// carry neither. Kept so callers that pass one still compile.
    /// </param>
    public CalculatedLightingProvider(MinecraftRegistry? registry = null) {
    }

    // ── ILightingProvider ───────────────────────────────────────────────────

    public LightData GetLighting(Vec2<int> chunkPos, ChunkData chunk,
        Func<Vec2<int>, ChunkData?>? neighborLookup, MinecraftRegistry registry, bool hasSkyLight) {

        CacheEntry entry = _cache.GetOrAdd(chunkPos, static _ => new CacheEntry());

        int stamp;
        lock (entry.Lock) {
            if (entry.Data != null && entry.HasSkyLight == hasSkyLight) {
                return entry.Data;
            }
            stamp = entry.Stamp;
        }

        LightData result = Compute(chunkPos, chunk, neighborLookup, hasSkyLight, out bool complete);

        // Light computed while a neighbour was missing is the best answer available now, but not
        // the one the chunk settles on once that neighbour loads, so it isn't kept. Neither is one
        // whose stamp moved while it ran: something changed under it and this answer is already old.
        if (complete) {
            lock (entry.Lock) {
                if (entry.Stamp == stamp) {
                    entry.Data = result;
                    entry.HasSkyLight = hasSkyLight;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Drops the chunk and the eight around it. A block change moves light up to fifteen blocks
    /// out, which reaches diagonally as well as along the axes.
    /// </summary>
    /// <remarks>
    /// Only positions that already have an entry are touched, and that is enough: an entry is
    /// created by <see cref="GetLighting"/> before it computes, so anything in flight has one, and a
    /// position with no entry has neither cached light nor a computation to invalidate.
    /// </remarks>
    public void Invalidate(Vec2<int> chunkPos) {
        for (int dz = -1; dz <= 1; dz++) {
            for (int dx = -1; dx <= 1; dx++) {
                if (!_cache.TryGetValue(chunkPos + new Vec2<int>(dx, dz), out CacheEntry? entry)) {
                    continue;
                }

                lock (entry.Lock) {
                    entry.Data = null;
                    entry.Stamp++;
                }
            }
        }
    }

    // ── The region ──────────────────────────────────────────────────────────

    private static LightData Compute(Vec2<int> pos, ChunkData chunk,
        Func<Vec2<int>, ChunkData?>? neighborLookup, bool hasSkyLight, out bool complete) {

        int sections = chunk.Sections.Length;
        if (sections > MaxSections) {
            throw new NotSupportedException(
                $"CalculatedLightingProvider handles up to {MaxSections} sections, this world has {sections}.");
        }

        Workspace ws = GetWorkspace(sections);
        int totalHeight = sections * 16;
        complete = true;

        ws.Emitters.Clear();
        ws.Queue.Reset();
        ws.Lowest.AsSpan().Fill(SourcesBelowWorld);

        for (int slot = 0; slot < SlotCount; slot++) {
            ChunkData? data = slot == CentreSlot
                ? chunk
                : neighborLookup?.Invoke(pos + new Vec2<int>(slot % 3 - 1, slot / 3 - 1));

            // A neighbour that isn't loaded, or that disagrees about the world height, becomes
            // void: light neither enters nor leaves it, which is what vanilla does with a section
            // it holds no light for.
            if (data == null || data.Sections.Length != sections) {
                ws.SlabOfSlot[slot] = VoidSlab;
                complete = false;
                continue;
            }

            ws.SlabOfSlot[slot] = slot;
            BuildSlab(data, slot, ws);

            if (hasSkyLight) {
                FindSkySources(data, slot, ws, totalHeight);
            }
        }

        ws.LinkSlabs();

        if (hasSkyLight) {
            SeedSkySources(ws, totalHeight);
            Propagate(ws, ws.Sky);
        }

        SeedEmitters(ws);
        Propagate(ws, ws.Block);

        return BuildLightData(ws, sections, hasSkyLight);
    }

    /// <summary>
    /// Fills a chunk's slab with the light class of every block in it and notes the ones that give
    /// light off. A section's palette is resolved once rather than per block, which is what keeps
    /// this to a table read and a store for each of the four thousand blocks.
    /// </summary>
    private static void BuildSlab(ChunkData chunk, int slab, Workspace ws) {
        ChunkSection[] sections = chunk.Sections;
        byte[] cls = ws.Cls;
        int slabBase = ws.SlabBase[slab];

        Array.Clear(ws.Block, slabBase, ws.SlabStride);

        for (int s = 0; s < sections.Length; s++) {
            int sectionIndex = s << 12;
            int sectionBase = slabBase + sectionIndex;
            Palette palette = sections[s].Palette;

            if (palette is SingleValuePalette single) {
                uint state = single.Value;
                cls.AsSpan(sectionBase, 4096).Fill(BlockLightTable.ClassOf(state));

                byte emission = BlockLightTable.EmissionOf(state);
                if (emission > 0) {
                    for (int i = 0; i < 4096; i++) {
                        ws.Emitters.Add(Emitter(slab, sectionIndex | i, emission));
                    }
                }
                continue;
            }

            if (palette is IndirectPalette indirect) {
                ReadOnlySpan<uint> values = indirect.PaletteValues;
                ReadOnlySpan<ushort> blocks = indirect.Blocks;

                Span<byte> classes = ws.PaletteScratch(values.Length, out Span<byte> emissions);
                bool anyEmission = false;
                for (int p = 0; p < values.Length; p++) {
                    classes[p] = BlockLightTable.ClassOf(values[p]);
                    emissions[p] = BlockLightTable.EmissionOf(values[p]);
                    anyEmission |= emissions[p] > 0;
                }

                ref byte target = ref MemoryMarshal.GetArrayDataReference(cls);
                if (anyEmission) {
                    for (int i = 0; i < 4096; i++) {
                        int entry = blocks[i];
                        Unsafe.Add(ref target, sectionBase + i) = classes[entry];
                        if (emissions[entry] > 0) {
                            ws.Emitters.Add(Emitter(slab, sectionIndex | i, emissions[entry]));
                        }
                    }
                }
                else {
                    for (int i = 0; i < 4096; i++) {
                        Unsafe.Add(ref target, sectionBase + i) = classes[blocks[i]];
                    }
                }
                continue;
            }

            for (int y = 0; y < 16; y++) {
                for (int z = 0; z < 16; z++) {
                    for (int x = 0; x < 16; x++) {
                        int index = (y << 8) | (z << 4) | x;
                        uint state = sections[s].GetBlock(x, y, z);
                        cls[sectionBase + index] = BlockLightTable.ClassOf(state);

                        byte emission = BlockLightTable.EmissionOf(state);
                        if (emission > 0) {
                            ws.Emitters.Add(Emitter(slab, sectionIndex | index, emission));
                        }
                    }
                }
            }
        }
    }

    // ── Sky light sources ───────────────────────────────────────────────────

    /// <summary>
    /// Vanilla's <c>ChunkSkyLightSources</c>: for each column, the lowest block the sky still
    /// reaches at full strength. It walks down from above the highest section holding anything and
    /// stops at the first edge that occludes, which is either a block that dampens light at all or
    /// a pair of faces that close the gap between them.
    /// <para>
    /// Walked a layer at a time rather than a column at a time. It is the same scan, but this way
    /// the classes are read in the order they sit in memory, and which columns are still open
    /// lives in a bitmap instead of costing a stride through the whole slab per column.
    /// </para>
    /// </summary>
    private static void FindSkySources(ChunkData chunk, int slab, Workspace ws, int totalHeight) {
        byte[] cls = ws.Cls;
        byte[] sky = ws.Sky;
        int slabBase = ws.SlabBase[slab];

        Array.Clear(sky, slabBase, ws.SlabStride);

        // Everything above the highest section with blocks in it is open sky, which is also where
        // vanilla starts its walk, with air above the first block it looks at.
        int topSection = chunk.Sections.Length - 1;
        while (topSection >= 0 && IsAllAir(chunk.Sections[topSection])) {
            topSection--;
        }

        int openTop = (topSection + 1) * 16;
        if (openTop < totalHeight) {
            sky.AsSpan(slabBase + (openTop << 8), (totalHeight - openTop) << 8).Fill(15);
        }

        Span<ulong> open = stackalloc ulong[4];
        open.Fill(ulong.MaxValue);
        int openColumns = 256;

        byte air = BlockLightTable.ClassOf(0);
        int columnBase = SlotColumnBase(slab);

        for (int y = openTop - 1; y >= 0 && openColumns > 0; y--) {
            int layer = slabBase + (y << 8);
            int layerAbove = layer + 256;

            for (int word = 0; word < 4; word++) {
                ulong bits = open[word];
                while (bits != 0) {
                    int bit = BitOperations.TrailingZeroCount(bits);
                    bits &= bits - 1;

                    int column = (word << 6) | bit;
                    byte below = cls[layer + column];
                    byte above = y + 1 < totalHeight ? cls[layerAbove + column] : air;

                    if (EdgeOccluded(above, below)) {
                        open[word] &= ~(1UL << bit);
                        openColumns--;
                        ws.Lowest[columnBase + (column >> 4) * ColumnGrid + (column & 15)] = y + 1;
                    }
                    else {
                        sky[layer + column] = 15;
                    }
                }
            }
        }

        // Columns still open run past the bottom of the world and keep the sentinel they started
        // with, which is what vanilla reports for them.
    }

    /// <summary>
    /// Whether the sky stops at the boundary between a block and the one under it. Vanilla's
    /// <c>ChunkSkyLightSources.isEdgeOccluded</c>.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool EdgeOccluded(byte above, byte below) {
        if (BlockLightTable.ClassDampens[below]) {
            return true;
        }

        int down = BlockLightTable.ClassFaceIds[above * BlockLightTable.FacesPerClass + FaceDown];
        int up = BlockLightTable.ClassFaceIds[below * BlockLightTable.FacesPerClass + FaceUp];
        return (BlockLightTable.FaceOccludes[down] >> up & 1) != 0;
    }

    /// <summary>
    /// Queues the sources worth spreading from, as vanilla's
    /// <c>SkyLightEngine.propagateLightSources</c> does: a source only heads down if it is the
    /// lowest in its column, and only sideways into a column whose own sources stop higher up.
    /// Every other direction out of a source already holds fifteen.
    /// </summary>
    private static void SeedSkySources(Workspace ws, int totalHeight) {
        for (int slot = 0; slot < SlotCount; slot++) {
            int slab = ws.SlabOfSlot[slot];
            if (slab == VoidSlab) {
                continue;
            }

            int slabBase = ws.SlabBase[slab];
            int columnBase = SlotColumnBase(slot);

            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    int column = columnBase + z * ColumnGrid + x;
                    int lowest = ws.Lowest[column];

                    int east = ws.Lowest[column + 1];
                    int west = ws.Lowest[column - 1];
                    int south = ws.Lowest[column + ColumnGrid];
                    int north = ws.Lowest[column - ColumnGrid];

                    // Above this, every neighbouring column is lit to fifteen as well and there is
                    // nothing for a source to hand over.
                    int shadowed = Math.Max(Math.Max(east, west), Math.Max(south, north));
                    if (shadowed > totalHeight) {
                        shadowed = totalHeight;
                    }

                    // Fifteen is the most a source has, so a column further out than that cannot
                    // reach the chunk being lit however clear the way is.
                    int index = (z << 4) | x;
                    if (DistanceToCentre[(slab << 8) | index] >= 15) {
                        continue;
                    }

                    for (int y = lowest < 0 ? 0 : lowest; y < shadowed; y++) {
                        int directions = 0;
                        if (y < east) directions |= EastBit;
                        if (y < west) directions |= WestBit;
                        if (y < south) directions |= SouthBit;
                        if (y < north) directions |= NorthBit;
                        if (y == lowest) directions |= DownBit;

                        ws.Queue.Push(15, Entry(slab, (y << 8) | index, directions));
                    }

                    // The lowest source lights what is under it even where no column beside it is
                    // in shadow.
                    if (lowest >= shadowed && lowest >= 0) {
                        ws.Queue.Push(15, Entry(slab, (lowest << 8) | index, DownBit));
                    }

                    if (lowest >= totalHeight) {
                        LightFromAboveWorld(ws, slab, slabBase, index, totalHeight);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Lights the top block of a column that isn't a source itself.
    /// <para>
    /// Vanilla keeps a section of light above the world as well as inside it, and every block in
    /// that section is a sky source, so a column whose sources stop at the world's ceiling still
    /// has fifteen directly above its top block. It only shows on a block that dampens light
    /// without closing the boundary above it, water at the height limit being the ordinary case:
    /// the sources stop, but a level still comes down into it rather than only in from the side.
    /// Nothing else in that section can reach further, since everything around it holds fifteen
    /// already.
    /// </para>
    /// </summary>
    private static void LightFromAboveWorld(Workspace ws, int slab, int slabBase, int column, int totalHeight) {
        int index = ((totalHeight - 1) << 8) | column;
        int top = slabBase + index;

        int info = BlockLightTable.ClassInfo[ws.Cls[top]];
        int level = 15 - (info & BlockLightTable.AttenuationMask);
        if (level <= ws.Sky[top]) {
            return;
        }

        // What is above is open air, whose faces are empty, so only this block's own can occlude.
        if (((info >> BlockLightTable.OccludesAloneShift) & UpBit) != 0) {
            return;
        }

        ws.Sky[top] = (byte)level;
        if (level > 1) {
            ws.Queue.Push(level, Entry(slab, index, AllDirections & ~UpBit));
        }
    }

    // ── Block light sources ─────────────────────────────────────────────────

    /// <summary>
    /// Vanilla's <c>increaseLightFromEmission</c>. A block that gives off light holds at least
    /// that level itself, including the ones that emit a single level and have nothing to pass on.
    /// </summary>
    private static void SeedEmitters(Workspace ws) {
        byte[] block = ws.Block;
        foreach (int emitter in CollectionsMarshal.AsSpan(ws.Emitters)) {
            int entry = emitter & EmitterEntryMask;
            int level = emitter >>> EmissionShift;
            int index = ws.SlabBase[entry >>> SlabShift] + ((entry >> IndexShift) & IndexMask);

            if (block[index] < level) {
                block[index] = (byte)level;

                // One is as far as it goes: everything around it costs at least that much, and so
                // does every block between it and the chunk being lit.
                if (level > 1 && level > DistanceToCentre[(entry >>> SlabShift << 8) | (entry >> IndexShift & 0xFF)]) {
                    ws.Queue.Push(level, entry);
                }
            }
        }
    }

    // ── Propagation ─────────────────────────────────────────────────────────

    /// <summary>
    /// Vanilla's <c>propagateIncrease</c> across the whole region, taking the blocks in order of
    /// the level they hold rather than the order they were queued in. Both settle on the same
    /// light: it is the highest level reachable at each block either way. This order just gets
    /// there having written each block once.
    /// </summary>
    private static void Propagate(Workspace ws, byte[] light) {
        Search search = default;
        search.Cls = ref MemoryMarshal.GetArrayDataReference(ws.Cls);
        search.Light = ref MemoryMarshal.GetArrayDataReference(light);
        search.SlabBase = ref MemoryMarshal.GetArrayDataReference(ws.SlabBase);
        search.Info = ref MemoryMarshal.GetArrayDataReference(BlockLightTable.ClassInfo);
        search.FaceIds = ref MemoryMarshal.GetArrayDataReference(BlockLightTable.ClassFaceIds);
        search.FaceOccludes = ref MemoryMarshal.GetArrayDataReference(BlockLightTable.FaceOccludes);
        search.Reach = ref MemoryMarshal.GetArrayDataReference(DistanceToCentre);
        search.Buckets = ws.Queue.Buckets;
        search.Counts = ref MemoryMarshal.GetArrayDataReference(ws.Queue.Counts);

        ref int neighbour = ref MemoryMarshal.GetArrayDataReference(ws.SlabNeighbour);
        int top = ws.SlabStride - 256;

        // Highest level first. Everything a block at this level can reach lands in a lower bucket,
        // so a block is written the once, at the level it ends up with, and never queued for a
        // level it is about to be raised past. A block at one has nothing to give.
        for (int level = 15; level > 1; level--) {
            int[] bucket = search.Buckets[level];

            // Fixed for the walk: only a higher level can add to this one, and those are done.
            int count = Unsafe.Add(ref search.Counts, level);

            for (int i = 0; i < count; i++) {
                int entry = bucket[i];
                int directions = entry & AllDirections;
                int index = (entry >> IndexShift) & IndexMask;
                int slab = entry >>> SlabShift;

                int at = Unsafe.Add(ref search.SlabBase, slab) + index;

                // Only a source queued below what something else went on to give it fails this.
                if (Unsafe.Add(ref search.Light, at) != level) {
                    continue;
                }

                // A face that covers its square on its own occludes whatever meets it, so it
                // settles the boundary without reading the block on the other side.
                int from = Unsafe.Add(ref search.Cls, at);
                int occludes = Unsafe.Add(ref search.Info, from) >> BlockLightTable.OccludesAloneShift;

                if ((directions & EastBit) != 0 && (occludes & EastBit) == 0) {
                    if ((index & 15) == 15) {
                        Step(ref search, from, FaceEast, FaceWest, level,
                            Unsafe.Add(ref neighbour, slab * 6 + FaceEast), index - 15);
                    }
                    else {
                        Step(ref search, from, FaceEast, FaceWest, level, slab, index + 1);
                    }
                }

                if ((directions & WestBit) != 0 && (occludes & WestBit) == 0) {
                    if ((index & 15) == 0) {
                        Step(ref search, from, FaceWest, FaceEast, level,
                            Unsafe.Add(ref neighbour, slab * 6 + FaceWest), index + 15);
                    }
                    else {
                        Step(ref search, from, FaceWest, FaceEast, level, slab, index - 1);
                    }
                }

                if ((directions & SouthBit) != 0 && (occludes & SouthBit) == 0) {
                    if ((index & 0xF0) == 0xF0) {
                        Step(ref search, from, FaceSouth, FaceNorth, level,
                            Unsafe.Add(ref neighbour, slab * 6 + FaceSouth), index - 240);
                    }
                    else {
                        Step(ref search, from, FaceSouth, FaceNorth, level, slab, index + 16);
                    }
                }

                if ((directions & NorthBit) != 0 && (occludes & NorthBit) == 0) {
                    if ((index & 0xF0) == 0) {
                        Step(ref search, from, FaceNorth, FaceSouth, level,
                            Unsafe.Add(ref neighbour, slab * 6 + FaceNorth), index + 240);
                    }
                    else {
                        Step(ref search, from, FaceNorth, FaceSouth, level, slab, index - 16);
                    }
                }

                // Nothing sits above the top of the world or below its bottom for light to cross into.
                if ((directions & UpBit) != 0 && (occludes & UpBit) == 0 && index < top) {
                    Step(ref search, from, FaceUp, FaceDown, level, slab, index + 256);
                }

                if ((directions & DownBit) != 0 && (occludes & DownBit) == 0 && index >= 256) {
                    Step(ref search, from, FaceDown, FaceUp, level, slab, index - 256);
                }
            }
        }

        ws.Queue.Reset();
    }

    /// <summary>
    /// One block of propagation, tested in vanilla's order: the most the level could possibly
    /// become, then what crossing into the block actually costs, then the shapes. The shape test
    /// is last because it is the only one that has to look at both faces.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Step(ref Search search, int fromClass, int face, int oppositeFace,
        int level, int slab, int index) {

        int to = Unsafe.Add(ref search.SlabBase, slab) + index;
        ref byte toLight = ref Unsafe.Add(ref search.Light, to);
        if (level - 1 <= toLight) {
            return;
        }

        int toClass = Unsafe.Add(ref search.Cls, to);
        int toInfo = Unsafe.Add(ref search.Info, toClass);
        int newLevel = level - (toInfo & BlockLightTable.AttenuationMask);
        if (newLevel <= toLight) {
            return;
        }

        // Two empty faces never occlude, which is the answer for nearly every pair of blocks and
        // is worth having before the matrix read.
        int shapes = (Unsafe.Add(ref search.Info, fromClass) >> (BlockLightTable.FaceNotEmptyShift + face))
                     | (toInfo >> (BlockLightTable.FaceNotEmptyShift + oppositeFace));
        if ((shapes & 1) != 0) {
            int leaving = Unsafe.Add(ref search.FaceIds, fromClass * BlockLightTable.FacesPerClass + face);
            int entering = Unsafe.Add(ref search.FaceIds, toClass * BlockLightTable.FacesPerClass + oppositeFace);
            if ((Unsafe.Add(ref search.FaceOccludes, leaving) >> entering & 1) != 0) {
                return;
            }
        }

        toLight = (byte)newLevel;

        // A level of one has nothing left to give: every neighbour costs at least that much. The
        // direction it came from is dropped, which vanilla does as well; going back would only
        // ever meet a level higher than the one being offered.
        //
        // Nor is a level worth spreading when it cannot reach the chunk being lit: getting there
        // costs a level per block, so anything at or below its distance from the middle chunk dies
        // on the way. That leaves the far side of the ring holding levels lower than the real ones,
        // which is why only the middle chunk is ever read out.
        if (newLevel > 1 && newLevel > Unsafe.Add(ref search.Reach, (slab << 8) | (index & 0xFF))) {
            int[] bucket = search.Buckets[newLevel];
            ref int count = ref Unsafe.Add(ref search.Counts, newLevel);
            if (count == bucket.Length) {
                bucket = BucketQueue.Grow(search.Buckets, newLevel, count);
            }

            Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(bucket), count++) =
                Entry(slab, index, AllDirections & ~(1 << oppositeFace));
        }
    }

    /// <summary>
    /// What the search runs on, by reference: the arrays are indexed once per block of light and
    /// the bounds are already known to hold, so this is the difference between one read and a read
    /// with a branch on it.
    /// </summary>
    private ref struct Search {
        public ref byte Cls;
        public ref byte Light;
        public ref int SlabBase;
        public ref ushort Info;
        public ref byte FaceIds;
        public ref ulong FaceOccludes;

        public ref byte Reach;
        public int[][] Buckets;
        public ref int Counts;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int Entry(int slab, int index, int directions) {
        return (slab << SlabShift) | (index << IndexShift) | directions;
    }

    /// <summary>A queue entry with the level the block gives off kept above it until seeding.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int Emitter(int slab, int index, int emission) {
        return Entry(slab, index, AllDirections) | (emission << EmissionShift);
    }

    /// <summary>
    /// How many blocks each column of the region is from the chunk being lit, by slab and by the
    /// column's place in it. Zero throughout the middle slab, and up to thirty one out in the
    /// corners. A level has to beat this to be worth spreading: every block on the way costs one.
    /// </summary>
    private static readonly byte[] DistanceToCentre = BuildDistanceToCentre();

    private static byte[] BuildDistanceToCentre() {
        byte[] distance = new byte[SlabCount * 256];
        for (int slab = 0; slab < SlotCount; slab++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    int regionX = slab % 3 * 16 + x;
                    int regionZ = slab / 3 * 16 + z;
                    int awayX = Math.Max(0, Math.Max(16 - regionX, regionX - 31));
                    int awayZ = Math.Max(0, Math.Max(16 - regionZ, regionZ - 31));
                    distance[(slab << 8) | (z << 4) | x] = (byte)(awayX + awayZ);
                }
            }
        }

        // Nothing is ever queued in the void slab, and this keeps it from looking close by.
        distance.AsSpan(VoidSlab << 8, 256).Fill(15);
        return distance;
    }

    /// <summary>Where a slot's own columns start in the region wide grid of sky sources.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int SlotColumnBase(int slot) {
        return (slot / 3 * 16 + 1) * ColumnGrid + slot % 3 * 16 + 1;
    }

    /// <summary>
    /// Whether a section is nothing but air, which is what decides where the sky source walk
    /// starts. Only the palette is checked: a section that holds air in some other form costs a
    /// few more layers of scanning and lands on the same answer.
    /// </summary>
    private static bool IsAllAir(ChunkSection section) {
        return section.Palette is SingleValuePalette { Value: 0 };
    }

    // ── Output ──────────────────────────────────────────────────────────────

    private static LightData BuildLightData(Workspace ws, int sections, bool hasSkyLight) {
        int maskLength = sections + 2;
        BitArray skyMask = new(maskLength);
        BitArray blockMask = new(maskLength);
        BitArray emptySkyMask = new(maskLength);
        BitArray emptyBlockMask = new(maskLength);

        List<byte[]> skyArrays = new(sections + 1);
        List<byte[]> blockArrays = new(sections);

        emptySkyMask.Set(0, true);
        emptyBlockMask.Set(0, true);

        int centre = ws.SlabBase[CentreSlot];

        for (int s = 0; s < sections; s++) {
            int bit = s + 1;
            int sectionBase = centre + (s << 12);

            if (hasSkyLight && !IsAllZero(ws.Sky, sectionBase)) {
                skyMask.Set(bit, true);
                skyArrays.Add(PackNibbles(ws.Sky, sectionBase));
            }
            else {
                emptySkyMask.Set(bit, true);
            }

            if (!IsAllZero(ws.Block, sectionBase)) {
                blockMask.Set(bit, true);
                blockArrays.Add(PackNibbles(ws.Block, sectionBase));
            }
            else {
                emptyBlockMask.Set(bit, true);
            }
        }

        if (hasSkyLight) {
            byte[] above = new byte[2048];
            above.AsSpan().Fill(0xFF);
            skyMask.Set(sections + 1, true);
            skyArrays.Add(above);
        }
        else {
            emptySkyMask.Set(sections + 1, true);
        }
        emptyBlockMask.Set(sections + 1, true);

        return new LightData {
            SkyLightMask = skyMask,
            BlockLightMask = blockMask,
            EmptySkyLightMask = emptySkyMask,
            EmptyBlockLightMask = emptyBlockMask,
            SkyLight = skyArrays.ToArray(),
            BlockLight = blockArrays.ToArray()
        };
    }

    /// <summary>Packs a section's byte per block levels into the nibble pairs the packet wants.</summary>
    private static byte[] PackNibbles(byte[] light, int sectionBase) {
        byte[] nibbles = new byte[2048];

        byte first = light[sectionBase];
        if (IsUniform(light, sectionBase, first)) {
            nibbles.AsSpan().Fill((byte)(first | (first << 4)));
            return nibbles;
        }

        ref byte source = ref MemoryMarshal.GetArrayDataReference(light);
        ref byte packed = ref MemoryMarshal.GetArrayDataReference(nibbles);
        for (int i = 0; i < 4096; i += 2) {
            Unsafe.Add(ref packed, i >> 1) = (byte)(
                Unsafe.Add(ref source, sectionBase + i) |
                (Unsafe.Add(ref source, sectionBase + i + 1) << 4));
        }
        return nibbles;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsAllZero(byte[] light, int sectionBase) {
        foreach (ulong word in MemoryMarshal.Cast<byte, ulong>(light.AsSpan(sectionBase, 4096))) {
            if (word != 0) {
                return false;
            }
        }
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsUniform(byte[] light, int sectionBase, byte value) {
        ulong fill = value * 0x0101010101010101UL;
        foreach (ulong word in MemoryMarshal.Cast<byte, ulong>(light.AsSpan(sectionBase, 4096))) {
            if (word != fill) {
                return false;
            }
        }
        return true;
    }

    // ── Workspace ───────────────────────────────────────────────────────────

    private static Workspace GetWorkspace(int sections) {
        Workspace workspace = _workspace ??= new Workspace();
        workspace.Resize(sections);
        return workspace;
    }

    /// <summary>
    /// The region's arrays, held per thread and reused across chunks. Ten slabs of one chunk each:
    /// the nine of the region, and the void that every unloaded neighbour shares. Three bytes a
    /// block, so about three megabytes for a world as tall as the overworld, on each thread that
    /// has ever lit a chunk.
    /// </summary>
    private sealed class Workspace {
        public byte[] Cls = [];
        public byte[] Sky = [];
        public byte[] Block = [];
        public readonly BucketQueue Queue = new();

        public readonly int[] SlabBase = new int[SlabCount];
        public readonly int[] SlabOfSlot = new int[SlotCount];

        /// <summary>Where each slab's four horizontal neighbours live, by face.</summary>
        public readonly int[] SlabNeighbour = new int[SlabCount * 6];

        /// <summary>The lowest sky source of every column of the region, inside a border.</summary>
        public readonly int[] Lowest = new int[ColumnGrid * ColumnGrid];

        public readonly List<int> Emitters = new(512);

        private byte[] _paletteClasses = new byte[256];
        private byte[] _paletteEmissions = new byte[256];

        public int SlabStride { get; private set; }

        /// <summary>
        /// Room to resolve a section's palette into, off the heap rather than the stack: a section
        /// can hold four thousand distinct states, and there are hundreds of sections in a region.
        /// </summary>
        public Span<byte> PaletteScratch(int length, out Span<byte> emissions) {
            if (_paletteClasses.Length < length) {
                _paletteClasses = new byte[length];
                _paletteEmissions = new byte[length];
            }

            emissions = _paletteEmissions.AsSpan(0, length);
            return _paletteClasses.AsSpan(0, length);
        }

        public void Resize(int sections) {
            int stride = sections * 4096;
            if (stride == SlabStride) {
                return;
            }

            SlabStride = stride;
            Cls = new byte[stride * SlabCount];
            Sky = new byte[stride * SlabCount];
            Block = new byte[stride * SlabCount];

            for (int slab = 0; slab < SlabCount; slab++) {
                SlabBase[slab] = slab * stride;
            }

            // Written the once. Nothing ever propagates into the void slab, so it stays this way.
            Cls.AsSpan(SlabBase[VoidSlab], stride).Fill(BlockLightTable.VoidClass);
        }

        /// <summary>
        /// Points every slab at the slabs around it, which turns crossing a chunk border in the
        /// search into a table read rather than working out where the block landed.
        /// </summary>
        public void LinkSlabs() {
            for (int slot = 0; slot < SlotCount; slot++) {
                int slab = SlabOfSlot[slot];
                if (slab == VoidSlab) {
                    continue;
                }

                int x = slot % 3;
                int z = slot / 3;
                SlabNeighbour[slab * 6 + FaceEast] = x < 2 ? SlabOfSlot[slot + 1] : VoidSlab;
                SlabNeighbour[slab * 6 + FaceWest] = x > 0 ? SlabOfSlot[slot - 1] : VoidSlab;
                SlabNeighbour[slab * 6 + FaceSouth] = z < 2 ? SlabOfSlot[slot + 3] : VoidSlab;
                SlabNeighbour[slab * 6 + FaceNorth] = z > 0 ? SlabOfSlot[slot - 3] : VoidSlab;
            }
        }
    }

    /// <summary>
    /// One list of blocks to spread from per light level, which is what lets the search take them
    /// in the order that finishes each block on the first write. The lists grow rather than
    /// wrapping, so nothing is dropped on the chunks that queue the most.
    /// </summary>
    private sealed class BucketQueue {
        public readonly int[][] Buckets = new int[16][];
        public readonly int[] Counts = new int[16];

        public BucketQueue() {
            for (int level = 0; level < Buckets.Length; level++) {
                Buckets[level] = new int[1024];
            }
        }

        public void Reset() {
            Array.Clear(Counts);
        }

        public void Push(int level, int entry) {
            int[] bucket = Buckets[level];
            if (Counts[level] == bucket.Length) {
                bucket = Grow(Buckets, level, Counts[level]);
            }

            bucket[Counts[level]++] = entry;
        }

        public static int[] Grow(int[][] buckets, int level, int count) {
            int[] grown = new int[buckets[level].Length * 2];
            Array.Copy(buckets[level], grown, count);
            buckets[level] = grown;
            return grown;
        }
    }
}
