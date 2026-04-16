using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Worlds.Lighting;

/// <summary>
/// High-performance BFS lighting provider with per-face directional occlusion
/// and cross-chunk border exchange.
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

    private const int MaxSections  = 24;
    private const int MaxFlatSize  = MaxSections * 4096;   // 98304
    private const int MaxNibbleSize = MaxSections * 2048;  // 49152
    private const int QueueCapacity = 1 << 18;             // 262144
    private const int QueueMask     = QueueCapacity - 1;
    private const int MaxBorderSeeds = 16 * MaxSections * 16 * 4;

    // ── State-ID lookup tables (built once) ─────────────────────────────────
    private readonly byte[] _faceOcclusionTable;
    private readonly byte[] _emissionTable;

    // ── Result cache ────────────────────────────────────────────────────────
    private readonly ConcurrentDictionary<Vec2<int>, LightData> _cache = new();

    // ── Thread-local workspace (avoids ArrayPool rent/return per call) ──────
    [ThreadStatic] static Workspace? t_ws;

    private sealed class Workspace {
        public readonly byte[] FaceFlat      = new byte[MaxFlatSize];
        public readonly byte[] BlockSrcFace  = new byte[MaxFlatSize];
        public readonly byte[] SkyWork       = new byte[MaxFlatSize];   // byte-per-block during BFS
        public readonly byte[] BlockWork     = new byte[MaxFlatSize];   // byte-per-block during BFS
        public readonly int[]  Queue         = new int[QueueCapacity];
        public readonly int[]  SkyDepth      = new int[256]; // per-column lowest sky-lit y
        public readonly List<int> Emitters   = new(512);     // encoded: fi | (em << 17)

        // Border exchange
        public readonly byte[] NFaceFlat     = new byte[MaxFlatSize];
        public readonly byte[] NBlockSrcFace = new byte[MaxFlatSize];
        public readonly byte[] NSkyWork      = new byte[MaxFlatSize];
        public readonly byte[] NBlockWork    = new byte[MaxFlatSize];
        public readonly int[]  SkySeedBuf    = new int[MaxBorderSeeds];
        public readonly int[]  BlockSeedBuf  = new int[MaxBorderSeeds];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Workspace GetWorkspace() => t_ws ??= new Workspace();

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

        Workspace ws = GetWorkspace();
        ChunkSection[] sections = chunk.Sections;
        int numSections = sections.Length;
        int totalHeight = numSections * 16;
        int flatSize = numSections * 4096;

        borderComplete = true;

        // Only clear BlockWork here; SkyWork is handled by ComputeSkyLight
        Array.Clear(ws.BlockWork, 0, flatSize);

        // Phase 1: Build flat arrays + collect emitters in one pass
        BuildFlatArraysAndCollectEmitters(sections, numSections,
            ws.FaceFlat, ws.BlockSrcFace, ws.Emitters,
            _faceOcclusionTable, _emissionTable);

        // Phase 2: Sky light with edge-detected BFS seeding
        if (hasSkyLight)
            ComputeSkyLight(ws.FaceFlat, ws.SkyWork, numSections, totalHeight,
                flatSize, ws.Queue, ws.SkyDepth);

        // Phase 3: Block light — seed from emitter list, then BFS
        int bHead = 0, bTail = 0;
        SeedBlockLight(ws.BlockWork, ws.BlockSrcFace, ws.Emitters, ws.Queue, ref bTail);
        BfsPropagate(ws.BlockSrcFace, ws.FaceFlat, ws.BlockWork, totalHeight,
            ws.Queue, ref bHead, ref bTail);

        // Phase 4: Cross-chunk border exchange
        if (neighborLookup != null)
            ApplyBorderExchange(ws.SkyWork, ws.BlockWork, ws.FaceFlat, ws.BlockSrcFace,
                numSections, totalHeight, flatSize, pos, neighborLookup, hasSkyLight,
                ws, out borderComplete);

        return BuildLightData(ws.SkyWork, ws.BlockWork, numSections, flatSize, hasSkyLight);
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

    private static bool IsFaceCovered(List<Aabb> aabbs, int face) {
        Span<ulong> grid = stackalloc ulong[4];
        grid.Clear();

        const double threshold = 1.0 / 1024.0;

        foreach (Aabb aabb in aabbs) {
            Vec3<double> min = aabb.Position;
            Vec3<double> max = aabb.End;

            bool touches = face switch {
                0 => max.X >= 1.0 - threshold,
                1 => min.X <= threshold,
                2 => max.Y >= 1.0 - threshold,
                3 => min.Y <= threshold,
                4 => max.Z >= 1.0 - threshold,
                5 => min.Z <= threshold,
                _ => false
            };
            if (!touches) continue;

            double uMin, uMax, vMin, vMax;
            switch (face) {
                case 0: case 1:
                    uMin = min.Y; uMax = max.Y; vMin = min.Z; vMax = max.Z; break;
                case 2: case 3:
                    uMin = min.X; uMax = max.X; vMin = min.Z; vMax = max.Z; break;
                default:
                    uMin = min.X; uMax = max.X; vMin = min.Y; vMax = max.Y; break;
            }

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

        return grid[0] == ulong.MaxValue
            && grid[1] == ulong.MaxValue
            && grid[2] == ulong.MaxValue
            && grid[3] == ulong.MaxValue;
    }

    // ── Flat array construction (fused) ─────────────────────────────────────

    /// <summary>
    /// Builds faceFlat, blockSrcFace, and collects emitter positions in a single pass.
    /// For SingleValuePalette sections uses Span.Fill (fast memset).
    /// For IndirectPalette sections uses per-palette-entry pre-lookup.
    /// Eliminates the separate emissionFlat array and BuildEmitterSrcFace pass.
    /// </summary>
    private static void BuildFlatArraysAndCollectEmitters(
        ChunkSection[] sections, int numSections,
        byte[] faceFlat, byte[] blockSrcFace,
        List<int> emitters,
        byte[] faceTable, byte[] emTable) {

        int tableMax = faceTable.Length;
        emitters.Clear();

        // Pre-compute max palette length to stackalloc once outside the loop
        int maxPalLen = 0;
        for (int s = 0; s < numSections; s++) {
            if (sections[s].Palette is IndirectPalette ipScan)
                maxPalLen = Math.Max(maxPalLen, ipScan.PaletteValues.Length);
        }

        Span<byte> palFaceBuf    = maxPalLen > 0 ? stackalloc byte[maxPalLen] : Span<byte>.Empty;
        Span<byte> palSrcFaceBuf = maxPalLen > 0 ? stackalloc byte[maxPalLen] : Span<byte>.Empty;
        Span<byte> palEmBuf      = maxPalLen > 0 ? stackalloc byte[maxPalLen] : Span<byte>.Empty;

        for (int s = 0; s < numSections; s++) {
            int sBase = s * 4096;
            Palette pal = sections[s].Palette;

            if (pal is SingleValuePalette svp) {
                uint sid = svp.Value;
                byte face = sid < (uint)tableMax ? faceTable[sid] : (byte)0;
                byte em   = sid < (uint)tableMax ? emTable[sid]   : (byte)0;
                byte srcFace = em > 0 ? (byte)0 : face;

                faceFlat.AsSpan(sBase, 4096).Fill(face);
                blockSrcFace.AsSpan(sBase, 4096).Fill(srcFace);

                // Rare: entire section of emitters (e.g., all glowstone)
                if (em > 1) {
                    for (int i = 0; i < 4096; i++)
                        emitters.Add((sBase + i) | (em << 17));
                }
                continue;
            }

            if (pal is IndirectPalette ip) {
                ReadOnlySpan<ushort> blocks = ip.Blocks;
                ReadOnlySpan<uint> paletteValues = ip.PaletteValues;
                int palLen = paletteValues.Length;

                // Pre-compute face/emission/srcFace per palette entry (fits in L1)
                Span<byte> palFace    = palFaceBuf[..palLen];
                Span<byte> palSrcFace = palSrcFaceBuf[..palLen];
                Span<byte> palEm      = palEmBuf[..palLen];
                bool hasEmitters = false;

                for (int p = 0; p < palLen; p++) {
                    uint sid = paletteValues[p];
                    byte face = sid < (uint)tableMax ? faceTable[sid] : (byte)0;
                    byte em   = sid < (uint)tableMax ? emTable[sid]   : (byte)0;
                    palFace[p]    = face;
                    palSrcFace[p] = em > 0 ? (byte)0 : face;
                    palEm[p]      = em;
                    if (em > 0) hasEmitters = true;
                }

                ref byte faceRef = ref MemoryMarshal.GetArrayDataReference(faceFlat);
                ref byte srcRef  = ref MemoryMarshal.GetArrayDataReference(blockSrcFace);

                if (hasEmitters) {
                    for (int i = 0; i < 4096; i++) {
                        int pi = blocks[i];
                        Unsafe.Add(ref faceRef, sBase + i) = palFace[pi];
                        Unsafe.Add(ref srcRef,  sBase + i) = palSrcFace[pi];
                        byte em = palEm[pi];
                        if (em > 1)
                            emitters.Add((sBase + i) | (em << 17));
                    }
                } else {
                    for (int i = 0; i < 4096; i++) {
                        int pi = blocks[i];
                        Unsafe.Add(ref faceRef, sBase + i) = palFace[pi];
                        Unsafe.Add(ref srcRef,  sBase + i) = palSrcFace[pi];
                    }
                }
                continue;
            }

            // Fallback: unpacked _blocks form
            FillSectionFallback(sections[s], sBase, faceFlat, blockSrcFace, emitters,
                faceTable, emTable, tableMax);
        }
    }

    private static void FillSectionFallback(
        ChunkSection section, int sBase,
        byte[] faceFlat, byte[] blockSrcFace, List<int> emitters,
        byte[] faceTable, byte[] emTable, int tableMax) {

        for (int y = 0; y < 16; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    int fi = sBase + (y << 8) | (z << 4) | x;
                    uint sid = section.GetBlock(x, y, z);
                    byte face = sid < (uint)tableMax ? faceTable[sid] : (byte)0;
                    byte em   = sid < (uint)tableMax ? emTable[sid]   : (byte)0;
                    faceFlat[fi] = face;
                    blockSrcFace[fi] = em > 0 ? (byte)0 : face;
                    if (em > 1)
                        emitters.Add(fi | (em << 17));
                }
            }
        }
    }

    // ── Sky light (optimized, byte-per-block) ──────────────────────────────

    /// <summary>
    /// Computes sky light using three phases:
    /// 1. Bulk-fill fully transparent sections from the top (memset, no iteration)
    /// 2. Column scan for remaining mixed/opaque sections
    /// 3. Edge-detected BFS seeding — only seed at shadow boundaries
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    private static void ComputeSkyLight(
        byte[] faceFlat, byte[] skyWork,
        int numSections, int totalHeight, int flatSize,
        int[] queue, int[] skyDepth) {

        // Phase 1: Detect how far down we can bulk-fill transparent sections.
        int bulkFilledDownTo = totalHeight;

        for (int s = numSections - 1; s >= 0; s--) {
            int sBase = s * 4096;
            byte firstFace = faceFlat[sBase];

            if (firstFace != 0 || !IsUniformByte(faceFlat, sBase, 4096, 0))
                break;

            bulkFilledDownTo = s * 16;
        }

        // Clear non-bulk-filled portion (may have stale data from previous call)
        int clearBytes = bulkFilledDownTo * 256;
        if (clearBytes > 0)
            Array.Clear(skyWork, 0, clearBytes);

        // Bulk-fill transparent sections with 15
        if (bulkFilledDownTo < totalHeight)
            skyWork.AsSpan(clearBytes, flatSize - clearBytes).Fill(15);

        // Initialize sky depth: all columns start at bulkFilledDownTo
        skyDepth.AsSpan(0, 256).Fill(bulkFilledDownTo);

        // Phase 2: Column scan from bulkFilledDownTo - 1 downward
        if (bulkFilledDownTo > 0) {
            ref byte faceRef = ref MemoryMarshal.GetArrayDataReference(faceFlat);
            ref byte skyRef  = ref MemoryMarshal.GetArrayDataReference(skyWork);

            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    int col = (z << 4) | x;

                    for (int y = bulkFilledDownTo - 1; y >= 0; y--) {
                        int fi = (y << 8) | (z << 4) | x;
                        byte faceMask = Unsafe.Add(ref faceRef, fi);

                        if ((faceMask & UP_BIT) != 0) break;

                        // Set sky = 15 (direct byte write)
                        Unsafe.Add(ref skyRef, fi) = 15;
                        skyDepth[col] = y;

                        if ((faceMask & DOWN_BIT) != 0) break;
                    }
                }
            }
        }

        // Phase 3: Edge-detected BFS seeding.
        int head = 0, tail = 0;

        for (int z = 0; z < 16; z++) {
            for (int x = 0; x < 16; x++) {
                int col = (z << 4) | x;
                int b = skyDepth[col];
                if (b >= totalHeight) continue;

                int highShadow = b > 0 ? b + 1 : 0;

                if (x < 15) { int nb = skyDepth[col + 1];  if (nb > highShadow) highShadow = nb; }
                if (x > 0)  { int nb = skyDepth[col - 1];  if (nb > highShadow) highShadow = nb; }
                if (z < 15) { int nb = skyDepth[col + 16]; if (nb > highShadow) highShadow = nb; }
                if (z > 0)  { int nb = skyDepth[col - 16]; if (nb > highShadow) highShadow = nb; }

                if (highShadow <= b) continue;
                if (highShadow > totalHeight) highShadow = totalHeight;

                ref byte faceRef2 = ref MemoryMarshal.GetArrayDataReference(faceFlat);
                ref int qRef = ref MemoryMarshal.GetArrayDataReference(queue);

                for (int y = b; y < highShadow; y++) {
                    int fi = (y << 8) | (z << 4) | x;
                    if (Unsafe.Add(ref faceRef2, fi) != ALL_FACES)
                        Unsafe.Add(ref qRef, tail++ & QueueMask) = fi | (15 << 17);
                }
            }
        }

        BfsPropagate(faceFlat, faceFlat, skyWork, totalHeight, queue, ref head, ref tail);
    }

    // ── Block light seeding ─────────────────────────────────────────────────

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SeedBlockLight(
        byte[] blockWork, byte[] blockSrcFace,
        List<int> emitters, int[] queue, ref int tail) {

        ref byte workRef = ref MemoryMarshal.GetArrayDataReference(blockWork);
        ref int qRef = ref MemoryMarshal.GetArrayDataReference(queue);

        foreach (int encoded in CollectionsMarshal.AsSpan(emitters)) {
            int fi = encoded & 0x1_FFFF;
            int em = (encoded >> 17) & 0xF;

            // Direct byte write (no nibble packing)
            Unsafe.Add(ref workRef, fi) = (byte)em;
            Unsafe.Add(ref qRef, tail++ & QueueMask) = encoded;
        }
    }

    // ── BFS propagation (byte-per-block — no nibble overhead) ───────────────

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    private static void BfsPropagate(
        byte[] srcFaceFlat, byte[] dstFaceFlat, byte[] lightWork,
        int totalHeight, int[] queue,
        ref int head, ref int tail) {

        ref byte srcRef   = ref MemoryMarshal.GetArrayDataReference(srcFaceFlat);
        ref byte dstRef   = ref MemoryMarshal.GetArrayDataReference(dstFaceFlat);
        ref byte lightRef = ref MemoryMarshal.GetArrayDataReference(lightWork);
        ref int  qRef     = ref MemoryMarshal.GetArrayDataReference(queue);

        int maxFi = (totalHeight - 1) << 8;

        while (head != tail) {
            int encoded = Unsafe.Add(ref qRef, head++ & QueueMask);
            int fi = encoded & 0x1_FFFF;
            int level = (encoded >> 17) & 0xF;

            // Skip stale entries superseded by a higher-level update
            if (Unsafe.Add(ref lightRef, fi) != (byte)level) continue;

            int newLevel = level - 1;
            byte sf = Unsafe.Add(ref srcRef, fi);

            // +X
            if ((fi & 0xF) != 0xF && (sf & EAST_BIT) == 0)
                PropagateUnsafe(ref srcRef, ref dstRef, ref lightRef, ref qRef,
                    fi + 1, newLevel, WEST_BIT, ref tail);
            // -X
            if ((fi & 0xF) != 0 && (sf & WEST_BIT) == 0)
                PropagateUnsafe(ref srcRef, ref dstRef, ref lightRef, ref qRef,
                    fi - 1, newLevel, EAST_BIT, ref tail);
            // +Z
            if ((fi & 0xF0) != 0xF0 && (sf & SOUTH_BIT) == 0)
                PropagateUnsafe(ref srcRef, ref dstRef, ref lightRef, ref qRef,
                    fi + 16, newLevel, NORTH_BIT, ref tail);
            // -Z
            if ((fi & 0xF0) != 0 && (sf & NORTH_BIT) == 0)
                PropagateUnsafe(ref srcRef, ref dstRef, ref lightRef, ref qRef,
                    fi - 16, newLevel, SOUTH_BIT, ref tail);
            // +Y
            if (fi < maxFi && (sf & UP_BIT) == 0)
                PropagateUnsafe(ref srcRef, ref dstRef, ref lightRef, ref qRef,
                    fi + 256, newLevel, DOWN_BIT, ref tail);
            // -Y
            if (fi >= 256 && (sf & DOWN_BIT) == 0)
                PropagateUnsafe(ref srcRef, ref dstRef, ref lightRef, ref qRef,
                    fi - 256, newLevel, UP_BIT, ref tail);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void PropagateUnsafe(
        ref byte srcRef, ref byte dstRef, ref byte lightRef, ref int qRef,
        int nfi, int newLevel, byte entryBit, ref int tail) {

        if ((Unsafe.Add(ref dstRef, nfi) & entryBit) != 0) return;

        // Direct byte read (no nibble decode)
        ref byte lightByte = ref Unsafe.Add(ref lightRef, nfi);
        if (lightByte >= newLevel) return;

        // Direct byte write (no nibble encode)
        lightByte = (byte)newLevel;

        if (newLevel > 1 && Unsafe.Add(ref srcRef, nfi) != ALL_FACES)
            Unsafe.Add(ref qRef, tail++ & QueueMask) = nfi | (newLevel << 17);
    }

    // ── Cross-chunk border exchange ─────────────────────────────────────────

    private void ApplyBorderExchange(
        byte[] skyWork, byte[] blockWork, byte[] faceFlat, byte[] blockSrcFace,
        int numSections, int totalHeight, int flatSize,
        Vec2<int> pos, Func<Vec2<int>, ChunkData?> neighborLookup,
        bool hasSkyLight, Workspace ws,
        out bool allNeighborsPresent) {

        allNeighborsPresent = true;

        ReadOnlySpan<int> borderDx   = [1, -1, 0,  0];
        ReadOnlySpan<int> borderDz   = [0,  0, 1, -1];
        ReadOnlySpan<int> ourFixed   = [15, 0, 15, 0];
        ReadOnlySpan<int> neighFixed = [0, 15, 0, 15];
        ReadOnlySpan<byte> exitBits  = [WEST_BIT, EAST_BIT, NORTH_BIT, SOUTH_BIT];
        ReadOnlySpan<byte> entryBits = [EAST_BIT, WEST_BIT, SOUTH_BIT, NORTH_BIT];
        ReadOnlySpan<bool> isXAxis   = [true, true, false, false];

        int skySeedCount = 0, blockSeedCount = 0;

        for (int b = 0; b < 4; b++) {
            Vec2<int> neighborPos = pos + new Vec2<int>(borderDx[b], borderDz[b]);
            ChunkData? neighborChunk = neighborLookup(neighborPos);
            if (neighborChunk == null) { allNeighborsPresent = false; continue; }
            if (neighborChunk.Sections.Length != numSections) continue;

            Array.Clear(ws.NSkyWork, 0, flatSize);
            Array.Clear(ws.NBlockWork, 0, flatSize);

            BuildFlatArraysAndCollectEmitters(neighborChunk.Sections, numSections,
                ws.NFaceFlat, ws.NBlockSrcFace, ws.Emitters,
                _faceOcclusionTable, _emissionTable);

            if (hasSkyLight)
                ComputeSkyLight(ws.NFaceFlat, ws.NSkyWork, numSections, totalHeight,
                    flatSize, ws.Queue, ws.SkyDepth);

            int nHead = 0, nTail = 0;
            SeedBlockLight(ws.NBlockWork, ws.NBlockSrcFace, ws.Emitters, ws.Queue, ref nTail);
            BfsPropagate(ws.NBlockSrcFace, ws.NFaceFlat, ws.NBlockWork, totalHeight,
                ws.Queue, ref nHead, ref nTail);

            // Collect border seeds
            if (hasSkyLight)
                CollectBorderSeeds(skyWork, faceFlat, faceFlat, ws.NSkyWork, ws.NFaceFlat,
                    ourFixed[b], neighFixed[b], isXAxis[b], exitBits[b], entryBits[b],
                    totalHeight, ws.SkySeedBuf, ref skySeedCount);

            CollectBorderSeeds(blockWork, blockSrcFace, faceFlat, ws.NBlockWork, ws.NBlockSrcFace,
                ourFixed[b], neighFixed[b], isXAxis[b], exitBits[b], entryBits[b],
                totalHeight, ws.BlockSeedBuf, ref blockSeedCount);
        }

        // Apply accumulated border seeds via BFS
        if (skySeedCount > 0) {
            int h = 0, t = 0;
            for (int i = 0; i < skySeedCount; i++)
                ws.Queue[t++ & QueueMask] = ws.SkySeedBuf[i];
            BfsPropagate(faceFlat, faceFlat, skyWork, totalHeight, ws.Queue, ref h, ref t);
        }

        if (blockSeedCount > 0) {
            int h = 0, t = 0;
            for (int i = 0; i < blockSeedCount; i++)
                ws.Queue[t++ & QueueMask] = ws.BlockSeedBuf[i];
            BfsPropagate(blockSrcFace, faceFlat, blockWork, totalHeight, ws.Queue, ref h, ref t);
        }
    }

    private static void CollectBorderSeeds(
        byte[] lightWork, byte[] srcFaceFlat, byte[] dstFaceFlat,
        byte[] nLightWork, byte[] nSrcFaceFlat,
        int cFixed, int nFixed, bool isX, byte exitBit, byte entryBit,
        int totalHeight,
        int[] seeds, ref int seedCount) {

        ref byte lightRef  = ref MemoryMarshal.GetArrayDataReference(lightWork);
        ref byte srcRef    = ref MemoryMarshal.GetArrayDataReference(srcFaceFlat);
        ref byte dstRef    = ref MemoryMarshal.GetArrayDataReference(dstFaceFlat);
        ref byte nLightRef = ref MemoryMarshal.GetArrayDataReference(nLightWork);
        ref byte nSrcRef   = ref MemoryMarshal.GetArrayDataReference(nSrcFaceFlat);

        for (int y = 0; y < totalHeight; y++) {
            for (int v = 0; v < 16; v++) {
                int cFi, nFi;
                if (isX) {
                    cFi = (y << 8) | (v << 4) | cFixed;
                    nFi = (y << 8) | (v << 4) | nFixed;
                } else {
                    cFi = (y << 8) | (cFixed << 4) | v;
                    nFi = (y << 8) | (nFixed << 4) | v;
                }

                if ((Unsafe.Add(ref nSrcRef, nFi) & exitBit) != 0) continue;
                if ((Unsafe.Add(ref dstRef, cFi) & entryBit) != 0) continue;

                // Direct byte read (no nibble decode)
                int nLight = Unsafe.Add(ref nLightRef, nFi);
                int newLevel = nLight - 1;
                if (newLevel <= 0) continue;

                ref byte curByte = ref Unsafe.Add(ref lightRef, cFi);
                if (curByte >= newLevel) continue;

                curByte = (byte)newLevel;

                if (Unsafe.Add(ref srcRef, cFi) != ALL_FACES)
                    seeds[seedCount++] = cFi | (newLevel << 17);
            }
        }
    }

    // ── LightData construction (packs byte-per-block → nibbles) ─────────────

    private static LightData BuildLightData(
        byte[] skyWork, byte[] blockWork,
        int numSections, int flatSize, bool hasSkyLight) {

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
            int sBase = s * 4096;

            if (hasSkyLight && !IsAllZero(skyWork, sBase, 4096)) {
                skyMask.Set(maskBit, true);
                skyArrays.Add(PackSectionToNibbles(skyWork, sBase));
            } else {
                emptySkyMask.Set(maskBit, true);
            }

            if (!IsAllZero(blockWork, sBase, 4096)) {
                blockMask.Set(maskBit, true);
                blockArrays.Add(PackSectionToNibbles(blockWork, sBase));
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

    /// <summary>
    /// Packs 4096 byte-per-block values into a 2048-byte nibble array.
    /// </summary>
    private static byte[] PackSectionToNibbles(byte[] work, int sBase) {
        byte[] nibbles = new byte[2048];

        // Fast path: uniform value (e.g., all-15 sky sections)
        byte first = work[sBase];
        if (first == work[sBase + 1] && IsUniformByte(work, sBase, 4096, first)) {
            byte packed = (byte)(first | (first << 4));
            nibbles.AsSpan().Fill(packed);
            return nibbles;
        }

        ref byte wRef = ref MemoryMarshal.GetArrayDataReference(work);
        ref byte nRef = ref MemoryMarshal.GetArrayDataReference(nibbles);
        for (int i = 0; i < 4096; i += 2) {
            Unsafe.Add(ref nRef, i >> 1) = (byte)(
                (Unsafe.Add(ref wRef, sBase + i) & 0xF) |
                (Unsafe.Add(ref wRef, sBase + i + 1) << 4));
        }
        return nibbles;
    }

    // ── Helpers ─────────────────────────────────────────────────────────────

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsAllZero(byte[] arr, int offset, int length) {
        ReadOnlySpan<byte> span = arr.AsSpan(offset, length);
        ReadOnlySpan<ulong> longs = MemoryMarshal.Cast<byte, ulong>(span[..(length & ~7)]);
        foreach (ulong v in longs)
            if (v != 0) return false;
        for (int i = length & ~7; i < length; i++)
            if (span[i] != 0) return false;
        return true;
    }

    /// <summary>
    /// Checks if all bytes in the range are the specified value.
    /// Used to detect uniform sections for sky light bulk-fill.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsUniformByte(byte[] arr, int offset, int length, byte value) {
        if (value == 0) return IsAllZero(arr, offset, length);
        ReadOnlySpan<byte> span = arr.AsSpan(offset, length);
        ulong fill = value * 0x0101010101010101UL;
        ReadOnlySpan<ulong> longs = MemoryMarshal.Cast<byte, ulong>(span[..(length & ~7)]);
        foreach (ulong v in longs)
            if (v != fill) return false;
        for (int i = length & ~7; i < length; i++)
            if (span[i] != value) return false;
        return true;
    }
}
