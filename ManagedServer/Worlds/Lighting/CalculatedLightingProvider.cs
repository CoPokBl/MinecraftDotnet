using System.Buffers;
using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Lighting;

/// <summary>
/// High-performance BFS lighting provider with per-face directional occlusion
/// and cross-chunk border exchange.
///
/// Key features:
/// <list type="bullet">
///   <item>
///     <b>Per-face occlusion</b> — each block state has a 6-bit mask indicating which faces
///     are fully covered by its <see cref="IBlock.OcclusionShape"/>. BFS checks the source
///     block's exit face rather than a simple opaque boolean. This correctly handles stairs,
///     slabs, and other partial blocks.
///   </item>
///   <item>
///     <b>Cross-chunk propagation</b> — after internal BFS, border exchange with up to 4
///     horizontal neighbors seeds light that crosses chunk boundaries.
///   </item>
///   <item>
///     <b>Static lookup tables</b> — built once from the registry; every BFS step does a
///     direct array index.
///   </item>
///   <item>
///     <b>ArrayPool-backed temporaries</b> — zero heap allocation in steady state.
///   </item>
///   <item>
///     <b>Result cache</b> — <see cref="ConcurrentDictionary"/> keyed by chunk position.
///   </item>
/// </list>
/// </summary>
public sealed class CalculatedLightingProvider : ILightingProvider {
    // ── Face direction bits ─────────────────────────────────────────────────
    private const byte EAST_BIT  = 0x01; // +X
    private const byte WEST_BIT  = 0x02; // -X
    private const byte UP_BIT    = 0x04; // +Y
    private const byte DOWN_BIT  = 0x08; // -Y
    private const byte SOUTH_BIT = 0x10; // +Z
    private const byte NORTH_BIT = 0x20; // -Z
    private const byte ALL_FACES = 0x3F;

    // ── State-ID lookup tables ──────────────────────────────────────────────
    private readonly byte[] _faceOcclusionTable; // 6-bit face mask per state ID
    private readonly byte[] _emissionTable;

    // ── Result cache ────────────────────────────────────────────────────────
    private readonly ConcurrentDictionary<Vec2<int>, LightData> _cache = new();

    // ── BFS queue sizing ────────────────────────────────────────────────────
    private const int QueueCapacity = 1 << 18; // 262144
    private const int QueueMask = QueueCapacity - 1;

    public CalculatedLightingProvider(MinecraftRegistry? registry = null) {
        registry ??= VanillaRegistry.Data;
        BuildLookupTables(registry.Blocks.StatesByStateId, out _faceOcclusionTable, out _emissionTable);
    }

    // ── ILightingProvider ───────────────────────────────────────────────────

    public LightData GetLighting(Vec2<int> chunkPos, ChunkData chunk,
        Func<Vec2<int>, ChunkData?>? neighborLookup, MinecraftRegistry registry, bool hasSkyLight) {
        if (_cache.TryGetValue(chunkPos, out LightData? cached))
            return cached;

        LightData result = Compute(chunk, chunkPos, neighborLookup, hasSkyLight, out bool borderComplete);

        // Only cache when every neighbor was available for border exchange.
        // Incomplete results are recomputed on the next call, at which point
        // the missing neighbor may have been loaded.
        if (borderComplete)
            _cache.TryAdd(chunkPos, result);

        return result;
    }

    public void Invalidate(Vec2<int> chunkPos) {
        _cache.TryRemove(chunkPos, out _);
        _cache.TryRemove(chunkPos + new Vec2<int>(1, 0), out _);
        _cache.TryRemove(chunkPos + new Vec2<int>(-1, 0), out _);
        _cache.TryRemove(chunkPos + new Vec2<int>(0, 1), out _);
        _cache.TryRemove(chunkPos + new Vec2<int>(0, -1), out _);
    }

    // ── Core computation ────────────────────────────────────────────────────

    private LightData Compute(ChunkData chunk, Vec2<int> pos,
        Func<Vec2<int>, ChunkData?>? neighborLookup, bool hasSkyLight,
        out bool borderComplete) {

        ChunkSection[] sections = chunk.Sections;
        int numSections = sections.Length;
        int totalHeight = numSections * 16;
        int flatSize = numSections * 4096;
        int nibbleSize = numSections * 2048;

        byte[] faceFlat = ArrayPool<byte>.Shared.Rent(flatSize);
        byte[] emissionFlat = ArrayPool<byte>.Shared.Rent(flatSize);
        byte[] blockSrcFace = ArrayPool<byte>.Shared.Rent(flatSize);
        byte[] skyNibbles = ArrayPool<byte>.Shared.Rent(nibbleSize);
        byte[] blockNibbles = ArrayPool<byte>.Shared.Rent(nibbleSize);
        int[] queue = ArrayPool<int>.Shared.Rent(QueueCapacity);
        uint[] sectionBuf = ArrayPool<uint>.Shared.Rent(4096);

        borderComplete = true;

        try {
            Array.Clear(skyNibbles, 0, nibbleSize);
            Array.Clear(blockNibbles, 0, nibbleSize);

            BuildFlatArrays(sections, numSections, sectionBuf, faceFlat, emissionFlat,
                _faceOcclusionTable, _emissionTable);

            // Light-emitting blocks ignore their own face occlusion when propagating
            // (matching Minestom's isOccluded: if lightEmission > 0, skip source face check)
            BuildEmitterSrcFace(blockSrcFace, faceFlat, emissionFlat, flatSize);

            // Phase 1: internal BFS
            if (hasSkyLight)
                ComputeSkyLight(faceFlat, skyNibbles, totalHeight, queue);

            ComputeBlockLight(blockSrcFace, faceFlat, emissionFlat, blockNibbles, flatSize, totalHeight, queue);

            // Phase 2: cross-chunk border exchange
            if (neighborLookup != null)
                ApplyBorderExchange(skyNibbles, blockNibbles, faceFlat, blockSrcFace,
                    numSections, totalHeight, flatSize, pos, neighborLookup, hasSkyLight,
                    queue, sectionBuf, out borderComplete);

            return BuildLightData(skyNibbles, blockNibbles, numSections, nibbleSize, hasSkyLight);
        }
        finally {
            ArrayPool<byte>.Shared.Return(faceFlat);
            ArrayPool<byte>.Shared.Return(emissionFlat);
            ArrayPool<byte>.Shared.Return(blockSrcFace);
            ArrayPool<byte>.Shared.Return(skyNibbles);
            ArrayPool<byte>.Shared.Return(blockNibbles);
            ArrayPool<int>.Shared.Return(queue);
            ArrayPool<uint>.Shared.Return(sectionBuf);
        }
    }

    // ── Lookup table construction ───────────────────────────────────────────

    private static void BuildLookupTables(
        IReadOnlyDictionary<uint, IBlock> stateMap,
        out byte[] faceOcclusion,
        out byte[] emission) {

        uint maxId = 0;
        foreach (uint id in stateMap.Keys)
            if (id > maxId) maxId = id;

        faceOcclusion = new byte[maxId + 1];
        emission = new byte[maxId + 1];

        // Deduplicate face occlusion computation by block type (OcclusionShape is per-type)
        Dictionary<IBlock, byte> blockFaceCache = new(ReferenceEqualityComparer.Instance);

        foreach ((uint id, IBlock block) in stateMap) {
            emission[id] = (byte)block.LightEmission;

            if (!block.Occludes) {
                faceOcclusion[id] = 0;
                continue;
            }

            if (!blockFaceCache.TryGetValue(block, out byte faceMask)) {
                faceMask = ComputeFaceOcclusion(block.OcclusionShape);
                blockFaceCache[block] = faceMask;
            }
            faceOcclusion[id] = faceMask;
        }
    }

    /// <summary>
    /// Computes a 6-bit face coverage mask from an occlusion shape.
    /// A bit is set if the shape's AABBs fully cover that face of the unit cube.
    /// </summary>
    private static byte ComputeFaceOcclusion(ICollisionBox shape) {
        List<Aabb> aabbs = [];
        CollectAabbs(shape, aabbs);
        if (aabbs.Count == 0) return 0;

        byte mask = 0;
        if (IsFaceCovered(aabbs, 0)) mask |= EAST_BIT;
        if (IsFaceCovered(aabbs, 1)) mask |= WEST_BIT;
        if (IsFaceCovered(aabbs, 2)) mask |= UP_BIT;
        if (IsFaceCovered(aabbs, 3)) mask |= DOWN_BIT;
        if (IsFaceCovered(aabbs, 4)) mask |= SOUTH_BIT;
        if (IsFaceCovered(aabbs, 5)) mask |= NORTH_BIT;
        return mask;
    }

    private static void CollectAabbs(ICollisionBox box, List<Aabb> result) {
        if (box is Aabb aabb) {
            result.Add(aabb);
        } else if (box is CompositeBox composite) {
            foreach (ICollisionBox child in composite.Children)
                CollectAabbs(child, result);
        }
    }

    /// <summary>
    /// Checks if the given face of the unit cube [0,1]^3 is fully covered by the
    /// union of projected AABBs. Uses a 16×16 bit grid for coverage testing.
    /// face: 0=+X, 1=-X, 2=+Y, 3=-Y, 4=+Z, 5=-Z
    /// </summary>
    private static bool IsFaceCovered(List<Aabb> aabbs, int face) {
        // 16×16 = 256 bits = 4 ulongs
        Span<ulong> grid = stackalloc ulong[4];
        grid.Clear();

        const double threshold = 1.0 / 1024.0;

        foreach (Aabb aabb in aabbs) {
            Vec3<double> min = aabb.Position;
            Vec3<double> max = aabb.End;

            // Check if this AABB touches the face plane
            bool touches = face switch {
                0 => max.X >= 1.0 - threshold, // +X (East)
                1 => min.X <= threshold,        // -X (West)
                2 => max.Y >= 1.0 - threshold, // +Y (Up)
                3 => min.Y <= threshold,        // -Y (Down)
                4 => max.Z >= 1.0 - threshold, // +Z (South)
                5 => min.Z <= threshold,        // -Z (North)
                _ => false
            };
            if (!touches) continue;

            // Project onto the face plane → get 2D [u,v] ranges in [0,1]
            double uMin, uMax, vMin, vMax;
            switch (face) {
                case 0: case 1: // ±X → project onto YZ
                    uMin = min.Y; uMax = max.Y;
                    vMin = min.Z; vMax = max.Z;
                    break;
                case 2: case 3: // ±Y → project onto XZ
                    uMin = min.X; uMax = max.X;
                    vMin = min.Z; vMax = max.Z;
                    break;
                default: // ±Z → project onto XY
                    uMin = min.X; uMax = max.X;
                    vMin = min.Y; vMax = max.Y;
                    break;
            }

            // Quantize to 16×16 grid
            int gu0 = Math.Max(0, (int)(uMin * 16));
            int gu1 = Math.Min(16, (int)Math.Ceiling(uMax * 16));
            int gv0 = Math.Max(0, (int)(vMin * 16));
            int gv1 = Math.Min(16, (int)Math.Ceiling(vMax * 16));

            for (int v = gv0; v < gv1; v++) {
                for (int u = gu0; u < gu1; u++) {
                    int bit = v * 16 + u;
                    grid[bit >> 6] |= 1UL << (bit & 63);
                }
            }
        }

        // Check all 256 bits are set
        return grid[0] == ulong.MaxValue
            && grid[1] == ulong.MaxValue
            && grid[2] == ulong.MaxValue
            && grid[3] == ulong.MaxValue;
    }

    // ── Flat array construction ─────────────────────────────────────────────

    private static void BuildFlatArrays(
        ChunkSection[] sections, int numSections,
        uint[] sectionBuf,
        byte[] faceFlat, byte[] emissionFlat,
        byte[] faceOcclusionTable, byte[] emissionTable) {

        int tableMax = faceOcclusionTable.Length;
        Span<uint> span = sectionBuf.AsSpan(0, 4096);

        for (int s = 0; s < numSections; s++) {
            sections[s].FillFlatStateIds(span);
            int sBase = s * 4096;
            for (int i = 0; i < 4096; i++) {
                uint sid = span[i];
                if (sid < (uint)tableMax) {
                    faceFlat[sBase + i] = faceOcclusionTable[sid];
                    emissionFlat[sBase + i] = emissionTable[sid];
                } else {
                    faceFlat[sBase + i] = 0;
                    emissionFlat[sBase + i] = 0;
                }
            }
        }
    }

    // ── Sky light ───────────────────────────────────────────────────────────

    private static void ComputeSkyLight(
        byte[] faceFlat, byte[] skyNibbles, int totalHeight, int[] queue) {

        int head = 0, tail = 0;

        for (int z = 0; z < 16; z++) {
            for (int x = 0; x < 16; x++) {
                for (int y = totalHeight - 1; y >= 0; y--) {
                    int fi = (y << 8) | (z << 4) | x;
                    byte faceMask = faceFlat[fi];

                    // If this block's UP face is covered, sky light can't enter from above
                    if ((faceMask & UP_BIT) != 0) break;

                    int byteIdx = fi >> 1;
                    int shift = (fi & 1) << 2;
                    if (((skyNibbles[byteIdx] >> shift) & 0xF) < 15) {
                        skyNibbles[byteIdx] |= (byte)(15 << shift);
                        // Only enqueue if this block can propagate (has open faces)
                        if (faceMask != ALL_FACES)
                            queue[tail++ & QueueMask] = fi | (15 << 17);
                    }

                    // If this block's DOWN face is covered, sky light can't continue down
                    if ((faceMask & DOWN_BIT) != 0) break;
                }
            }
        }

        BfsPropagate(faceFlat, faceFlat, skyNibbles, totalHeight, queue, ref head, ref tail);
    }

    // ── Block light ─────────────────────────────────────────────────────────

    private static void ComputeBlockLight(
        byte[] srcFaceFlat, byte[] dstFaceFlat, byte[] emissionFlat,
        byte[] blockNibbles, int flatSize, int totalHeight, int[] queue) {

        int head = 0, tail = 0;

        for (int i = 0; i < flatSize; i++) {
            byte em = emissionFlat[i];
            if (em == 0) continue;

            int byteIdx = i >> 1;
            int shift = (i & 1) << 2;
            if (((blockNibbles[byteIdx] >> shift) & 0xF) < em) {
                blockNibbles[byteIdx] = (byte)((blockNibbles[byteIdx] & ~(0xF << shift)) | (em << shift));
                if (srcFaceFlat[i] != ALL_FACES)
                    queue[tail++ & QueueMask] = i | (em << 17);
            }
        }

        BfsPropagate(srcFaceFlat, dstFaceFlat, blockNibbles, totalHeight, queue, ref head, ref tail);
    }

    // ── BFS propagation ─────────────────────────────────────────────────────

    private static void BfsPropagate(
        byte[] srcFaceFlat, byte[] dstFaceFlat, byte[] lightArray,
        int totalHeight, int[] queue,
        ref int head, ref int tail) {

        while (head != tail) {
            int encoded = queue[head++ & QueueMask];
            int fi = encoded & 0x1_FFFF;
            int level = (encoded >> 17) & 0xF;
            if (level <= 1) continue;

            int newLevel = level - 1;
            int x = fi & 0xF;
            int z = (fi >> 4) & 0xF;
            int y = fi >> 8;
            byte srcFace = srcFaceFlat[fi];

            if (x < 15 && (srcFace & EAST_BIT)  == 0) TryPropagate(srcFaceFlat, dstFaceFlat, lightArray, fi + 1,   newLevel, WEST_BIT,  queue, ref tail);
            if (x > 0  && (srcFace & WEST_BIT)  == 0) TryPropagate(srcFaceFlat, dstFaceFlat, lightArray, fi - 1,   newLevel, EAST_BIT,  queue, ref tail);
            if (z < 15 && (srcFace & SOUTH_BIT) == 0) TryPropagate(srcFaceFlat, dstFaceFlat, lightArray, fi + 16,  newLevel, NORTH_BIT, queue, ref tail);
            if (z > 0  && (srcFace & NORTH_BIT) == 0) TryPropagate(srcFaceFlat, dstFaceFlat, lightArray, fi - 16,  newLevel, SOUTH_BIT, queue, ref tail);
            if (y < totalHeight - 1 && (srcFace & UP_BIT)   == 0) TryPropagate(srcFaceFlat, dstFaceFlat, lightArray, fi + 256, newLevel, DOWN_BIT,  queue, ref tail);
            if (y > 0               && (srcFace & DOWN_BIT) == 0) TryPropagate(srcFaceFlat, dstFaceFlat, lightArray, fi - 256, newLevel, UP_BIT,    queue, ref tail);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void TryPropagate(
        byte[] srcFaceFlat, byte[] dstFaceFlat, byte[] lightArray,
        int nfi, int newLevel, byte entryBit, int[] queue, ref int tail) {

        byte dstFace = dstFaceFlat[nfi];

        // Check destination block's entry face is not occluded
        if ((dstFace & entryBit) != 0) return;

        int nb = nfi >> 1;
        int ns = (nfi & 1) << 2;
        int cur = (lightArray[nb] >> ns) & 0xF;
        if (cur >= newLevel) return;

        lightArray[nb] = (byte)((lightArray[nb] & ~(0xF << ns)) | (newLevel << ns));

        // Enqueue if target can propagate (use srcFaceFlat: emitters always propagate)
        if (srcFaceFlat[nfi] != ALL_FACES)
            queue[tail++ & QueueMask] = nfi | (newLevel << 17);
    }

    // ── Cross-chunk border exchange ─────────────────────────────────────────

    private void ApplyBorderExchange(
        byte[] skyNibbles, byte[] blockNibbles, byte[] faceFlat, byte[] blockSrcFace,
        int numSections, int totalHeight, int flatSize,
        Vec2<int> pos, Func<Vec2<int>, ChunkData?> neighborLookup,
        bool hasSkyLight, int[] queue, uint[] sectionBuf,
        out bool allNeighborsPresent) {

        allNeighborsPresent = true;
        int nibbleSize = numSections * 2048;
        int maxBorderSeeds = 16 * totalHeight * 4; // 4 borders

        byte[] nFaceFlat = ArrayPool<byte>.Shared.Rent(flatSize);
        byte[] nEmissionFlat = ArrayPool<byte>.Shared.Rent(flatSize);
        byte[] nBlockSrcFace = ArrayPool<byte>.Shared.Rent(flatSize);
        byte[] nSkyNibbles = ArrayPool<byte>.Shared.Rent(nibbleSize);
        byte[] nBlockNibbles = ArrayPool<byte>.Shared.Rent(nibbleSize);
        int[] skySeeds = ArrayPool<int>.Shared.Rent(maxBorderSeeds);
        int[] blockSeeds = ArrayPool<int>.Shared.Rent(maxBorderSeeds);

        try {
            int skySeedCount = 0, blockSeedCount = 0;

            // Border definitions: (dx, dz, ourFixed, neighborFixed, isXAxis, neighborExitBit, ourEntryBit)
            ReadOnlySpan<int> borderDx    = [1, -1, 0,  0];
            ReadOnlySpan<int> borderDz    = [0,  0, 1, -1];
            ReadOnlySpan<int> ourFixed    = [15, 0, 15, 0];
            ReadOnlySpan<int> neighFixed  = [0, 15, 0, 15];
            ReadOnlySpan<byte> exitBits   = [WEST_BIT, EAST_BIT, NORTH_BIT, SOUTH_BIT];
            ReadOnlySpan<byte> entryBits  = [EAST_BIT, WEST_BIT, SOUTH_BIT, NORTH_BIT];
            ReadOnlySpan<bool> isXAxis    = [true, true, false, false];

            for (int b = 0; b < 4; b++) {
                Vec2<int> neighborPos = pos + new Vec2<int>(borderDx[b], borderDz[b]);
                ChunkData? neighborChunk = neighborLookup(neighborPos);
                if (neighborChunk == null) { allNeighborsPresent = false; continue; }
                if (neighborChunk.Sections.Length != numSections) continue;

                // Compute neighbor's internal light
                Array.Clear(nSkyNibbles, 0, nibbleSize);
                Array.Clear(nBlockNibbles, 0, nibbleSize);
                BuildFlatArrays(neighborChunk.Sections, numSections, sectionBuf,
                    nFaceFlat, nEmissionFlat, _faceOcclusionTable, _emissionTable);

                BuildEmitterSrcFace(nBlockSrcFace, nFaceFlat, nEmissionFlat, flatSize);

                if (hasSkyLight)
                    ComputeSkyLight(nFaceFlat, nSkyNibbles, totalHeight, queue);

                ComputeBlockLight(nBlockSrcFace, nFaceFlat, nEmissionFlat, nBlockNibbles, flatSize, totalHeight, queue);

                // Collect border seeds
                if (hasSkyLight)
                    CollectBorderSeeds(skyNibbles, faceFlat, faceFlat, nSkyNibbles, nFaceFlat,
                        ourFixed[b], neighFixed[b], isXAxis[b], exitBits[b], entryBits[b],
                        totalHeight, skySeeds, ref skySeedCount);

                CollectBorderSeeds(blockNibbles, blockSrcFace, faceFlat, nBlockNibbles, nBlockSrcFace,
                    ourFixed[b], neighFixed[b], isXAxis[b], exitBits[b], entryBits[b],
                    totalHeight, blockSeeds, ref blockSeedCount);
            }

            // Apply accumulated border seeds via BFS
            if (skySeedCount > 0) {
                int h = 0, t = 0;
                for (int i = 0; i < skySeedCount; i++)
                    queue[t++ & QueueMask] = skySeeds[i];
                BfsPropagate(faceFlat, faceFlat, skyNibbles, totalHeight, queue, ref h, ref t);
            }

            if (blockSeedCount > 0) {
                int h = 0, t = 0;
                for (int i = 0; i < blockSeedCount; i++)
                    queue[t++ & QueueMask] = blockSeeds[i];
                BfsPropagate(blockSrcFace, faceFlat, blockNibbles, totalHeight, queue, ref h, ref t);
            }
        }
        finally {
            ArrayPool<byte>.Shared.Return(nFaceFlat);
            ArrayPool<byte>.Shared.Return(nEmissionFlat);
            ArrayPool<byte>.Shared.Return(nBlockSrcFace);
            ArrayPool<byte>.Shared.Return(nSkyNibbles);
            ArrayPool<byte>.Shared.Return(nBlockNibbles);
            ArrayPool<int>.Shared.Return(skySeeds);
            ArrayPool<int>.Shared.Return(blockSeeds);
        }
    }

    /// <summary>
    /// Reads light values from the neighbor's border and seeds the current chunk
    /// where the neighbor provides higher light.
    /// </summary>
    private static void CollectBorderSeeds(
        byte[] lightNib, byte[] srcFaceFlat, byte[] dstFaceFlat,
        byte[] nLightNib, byte[] nSrcFaceFlat,
        int cFixed, int nFixed, bool isX, byte exitBit, byte entryBit,
        int totalHeight,
        int[] seeds, ref int seedCount) {

        for (int y = 0; y < totalHeight; y++) {
            for (int v = 0; v < 16; v++) {
                int cFi, nFi;
                if (isX) {
                    // X-axis border: v = z coordinate, cFixed/nFixed = x coordinate
                    cFi = (y << 8) | (v << 4) | cFixed;
                    nFi = (y << 8) | (v << 4) | nFixed;
                } else {
                    // Z-axis border: v = x coordinate, cFixed/nFixed = z coordinate
                    cFi = (y << 8) | (cFixed << 4) | v;
                    nFi = (y << 8) | (nFixed << 4) | v;
                }

                // Check neighbor's exit face toward us (emitters skip this via srcFace=0)
                if ((nSrcFaceFlat[nFi] & exitBit) != 0) continue;

                // Check our entry face from neighbor (always uses real face mask)
                if ((dstFaceFlat[cFi] & entryBit) != 0) continue;

                // Read neighbor's light level
                int nLight = (nLightNib[nFi >> 1] >> ((nFi & 1) << 2)) & 0xF;
                int newLevel = nLight - 1;
                if (newLevel <= 0) continue;

                // Read current chunk's light level
                int cByteIdx = cFi >> 1;
                int cShift = (cFi & 1) << 2;
                int curLight = (lightNib[cByteIdx] >> cShift) & 0xF;
                if (curLight >= newLevel) continue;

                // Update current chunk's light
                lightNib[cByteIdx] = (byte)((lightNib[cByteIdx] & ~(0xF << cShift)) | (newLevel << cShift));

                // Add seed if current block can propagate (emitters always can)
                if (srcFaceFlat[cFi] != ALL_FACES)
                    seeds[seedCount++] = cFi | (newLevel << 17);
            }
        }
    }

    // ── LightData construction ──────────────────────────────────────────────

    private static LightData BuildLightData(
        byte[] skyNibbles, byte[] blockNibbles,
        int numSections, int nibbleSize, bool hasSkyLight) {

        int maskLen = numSections + 2;
        BitArray skyMask = new(maskLen);
        BitArray blockMask = new(maskLen);
        BitArray emptySkyMask = new(maskLen);
        BitArray emptyBlockMask = new(maskLen);

        List<byte[]> skyArrays = new(numSections + 1);
        List<byte[]> blockArrays = new(numSections);

        emptySkyMask.Set(0, true);
        emptyBlockMask.Set(0, true);

        for (int s = 0; s < numSections; s++) {
            int maskBit = s + 1;
            int offset = s * 2048;

            if (hasSkyLight && !IsAllZero(skyNibbles, offset, 2048)) {
                skyMask.Set(maskBit, true);
                byte[] arr = new byte[2048];
                Buffer.BlockCopy(skyNibbles, offset, arr, 0, 2048);
                skyArrays.Add(arr);
            } else {
                emptySkyMask.Set(maskBit, true);
            }

            if (!IsAllZero(blockNibbles, offset, 2048)) {
                blockMask.Set(maskBit, true);
                byte[] arr = new byte[2048];
                Buffer.BlockCopy(blockNibbles, offset, arr, 0, 2048);
                blockArrays.Add(arr);
            } else {
                emptyBlockMask.Set(maskBit, true);
            }
        }

        if (hasSkyLight) {
            byte[] aboveSky = new byte[2048];
            Array.Fill(aboveSky, (byte)0xFF);
            skyMask.Set(numSections + 1, true);
            skyArrays.Add(aboveSky);
        } else {
            emptySkyMask.Set(numSections + 1, true);
        }
        emptyBlockMask.Set(numSections + 1, true);

        return new LightData {
            SkyLightMask = skyMask,
            BlockLightMask = blockMask,
            EmptySkyLightMask = emptySkyMask,
            EmptyBlockLightMask = emptyBlockMask,
            SkyLight = skyArrays.ToArray(),
            BlockLight = blockArrays.ToArray()
        };
    }

    // ── Helpers ─────────────────────────────────────────────────────────────

    /// <summary>
    /// Builds a source-face array for block light BFS where light-emitting blocks
    /// have their face occlusion cleared to 0. This matches Minestom's isOccluded
    /// behavior: when <c>lightEmission &gt; 0</c>, the source block's own face
    /// occlusion is ignored, allowing it to emit light in all directions.
    /// </summary>
    private static void BuildEmitterSrcFace(byte[] dst, byte[] faceFlat, byte[] emissionFlat, int flatSize) {
        Buffer.BlockCopy(faceFlat, 0, dst, 0, flatSize);
        for (int i = 0; i < flatSize; i++) {
            if (emissionFlat[i] > 0)
                dst[i] = 0;
        }
    }

    private static bool IsAllZero(byte[] arr, int offset, int length) {
        ReadOnlySpan<byte> span = arr.AsSpan(offset, length);
        ReadOnlySpan<ulong> longs = MemoryMarshal.Cast<byte, ulong>(span[..(length & ~7)]);
        foreach (ulong v in longs)
            if (v != 0) return false;
        for (int i = length & ~7; i < length; i++)
            if (span[i] != 0) return false;
        return true;
    }
}

