using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Lighting;

public class CalculatedLightingProviderTest {
    private CalculatedLightingProvider _provider = null!;

    [SetUp]
    public void Setup() {
        _provider = new CalculatedLightingProvider();
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    /// <summary>
    /// Creates an air-only chunk with the given world height (default 384 = vanilla overworld).
    /// </summary>
    private static ChunkData AirChunk(int worldHeight = 384) => new(worldHeight);

    /// <summary>
    /// Extracts a block light level (0-15) from the LightData at chunk-local (x, y, z).
    /// </summary>
    private static int GetBlockLight(LightData data, int x, int y, int z) {
        int section = y / 16;
        int localY = y % 16;
        int fi = (localY << 8) | (z << 4) | x;
        return GetNibble(data.BlockLightMask, data.BlockLight, section, fi);
    }

    /// <summary>
    /// Extracts a sky light level (0-15) from the LightData at chunk-local (x, y, z).
    /// </summary>
    private static int GetSkyLight(LightData data, int x, int y, int z) {
        int section = y / 16;
        int localY = y % 16;
        int fi = (localY << 8) | (z << 4) | x;
        return GetNibble(data.SkyLightMask, data.SkyLight, section, fi);
    }

    /// <summary>
    /// Reads a 4-bit nibble from the section arrays. Mask bit index is section + 1
    /// (bit 0 is below-world). The arrays are compact: only sections with mask=true
    /// have entries, in order.
    /// </summary>
    private static int GetNibble(System.Collections.BitArray mask, byte[][] arrays, int section, int fi) {
        int maskBit = section + 1;
        if (!mask.Get(maskBit)) return 0;

        int arrayIdx = 0;
        for (int i = 0; i < maskBit; i++) {
            if (mask.Get(i)) arrayIdx++;
        }

        int byteIdx = fi >> 1;
        int shift = (fi & 1) << 2;
        return (arrays[arrayIdx][byteIdx] >> shift) & 0xF;
    }

    private LightData ComputeBlockLightOnly(ChunkData chunk, Vec2<int> pos,
        Func<Vec2<int>, ChunkData?>? neighborLookup = null) {
        return _provider.GetLighting(pos, chunk, neighborLookup,
            VanillaRegistry.Data, hasSkyLight: false);
    }

    private LightData ComputeWithSkyLight(ChunkData chunk, Vec2<int> pos,
        Func<Vec2<int>, ChunkData?>? neighborLookup = null) {
        return _provider.GetLighting(pos, chunk, neighborLookup,
            VanillaRegistry.Data, hasSkyLight: true);
    }

    // ── Block Light Tests ────────────────────────────────────────────────────

    [Test]
    public void AirChunk_HasNoBlockLight() {
        ChunkData chunk = AirChunk();
        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // Spot-check several positions across different sections
        Assert.That(GetBlockLight(light, 0, 0, 0), Is.EqualTo(0));
        Assert.That(GetBlockLight(light, 8, 64, 8), Is.EqualTo(0));
        Assert.That(GetBlockLight(light, 15, 200, 15), Is.EqualTo(0));
    }

    [Test]
    public void SingleTorch_EmitsAtLevel14() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Torch);

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        Assert.That(GetBlockLight(light, 8, 64, 8), Is.EqualTo(14));
    }

    [Test]
    public void Glowstone_EmitsAtLevel15() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Glowstone);

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // Glowstone is a full block with ALL_FACES occlusion but emission > 0
        // means it should still emit (the emitter bypass fix)
        Assert.That(GetBlockLight(light, 8, 64, 8), Is.EqualTo(15));
    }

    [Test]
    public void BlockLight_AttenuatesByOnePerBlock() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Glowstone); // emission = 15

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // Check attenuation along +X axis
        for (int dx = 0; dx <= 7; dx++) {
            int expected = 15 - dx;
            int actual = GetBlockLight(light, 8 + dx, 64, 8);
            Assert.That(actual, Is.EqualTo(expected),
                $"At distance {dx} (+X), expected {expected} but got {actual}");
        }

        // Check attenuation along -Z axis
        for (int dz = 1; dz <= 7; dz++) {
            int expected = 15 - dz;
            int actual = GetBlockLight(light, 8, 64, 8 - dz);
            Assert.That(actual, Is.EqualTo(expected),
                $"At distance {dz} (-Z), expected {expected} but got {actual}");
        }

        // Check attenuation along +Y axis
        for (int dy = 1; dy <= 7; dy++) {
            int expected = 15 - dy;
            int actual = GetBlockLight(light, 8, 64 + dy, 8);
            Assert.That(actual, Is.EqualTo(expected),
                $"At distance {dy} (+Y), expected {expected} but got {actual}");
        }
    }

    [Test]
    public void StoneBlocksLight() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Glowstone); // emission = 15

        // Place a stone wall at x=10 (2 blocks away from glowstone)
        for (int y = 60; y < 70; y++)
        for (int z = 4; z < 13; z++)
            chunk.SetBlock(10, y, z, Block.Stone);

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // Right before the wall: light should be 15 - 1 = 14 (x=9, 1 block from glowstone)
        Assert.That(GetBlockLight(light, 9, 64, 8), Is.EqualTo(14));

        // Right after the wall: stone blocks all faces, so light must go around.
        // Direct path is blocked, light must reach x=11 via a detour.
        // Without the wall, x=11 would have 15-3=12. With the wall, light must
        // go around (at least 2 extra blocks), so it should be less.
        int behindWall = GetBlockLight(light, 11, 64, 8);
        Assert.That(behindWall, Is.LessThan(12),
            "Light behind a stone wall should be less than unobstructed");
    }

    [Test]
    public void GlassDoesNotBlockLight() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Glowstone); // emission = 15

        // Place glass at x=10 (2 blocks from glowstone)
        chunk.SetBlock(10, 64, 8, Block.Glass);

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // Glass has Occludes=false → faceOcclusion=0, light passes straight through.
        // x=9: 15-1=14, glass at x=10: 15-2=13, x=11: 15-3=12
        Assert.That(GetBlockLight(light, 9, 64, 8), Is.EqualTo(14));
        Assert.That(GetBlockLight(light, 10, 64, 8), Is.EqualTo(13));
        Assert.That(GetBlockLight(light, 11, 64, 8), Is.EqualTo(12));
    }

    [Test]
    public void GlowstoneEmitsInAllDirections() {
        // Glowstone has ALL_FACES occlusion but the emitter bypass should
        // allow it to emit in all 6 directions.
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Glowstone);

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // All 6 adjacent blocks should receive light 14
        Assert.That(GetBlockLight(light, 9, 64, 8), Is.EqualTo(14), "+X");
        Assert.That(GetBlockLight(light, 7, 64, 8), Is.EqualTo(14), "-X");
        Assert.That(GetBlockLight(light, 8, 65, 8), Is.EqualTo(14), "+Y");
        Assert.That(GetBlockLight(light, 8, 63, 8), Is.EqualTo(14), "-Y");
        Assert.That(GetBlockLight(light, 8, 64, 9), Is.EqualTo(14), "+Z");
        Assert.That(GetBlockLight(light, 8, 64, 7), Is.EqualTo(14), "-Z");
    }

    [Test]
    public void MultipleEmitters_TakeMaximumLight() {
        ChunkData chunk = AirChunk();
        // Two torches (emission=14) 4 blocks apart
        chunk.SetBlock(6, 64, 8, Block.Torch);
        chunk.SetBlock(10, 64, 8, Block.Torch);

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // Midpoint x=8 is 2 blocks from each torch → max(14-2, 14-2) = 12
        Assert.That(GetBlockLight(light, 8, 64, 8), Is.EqualTo(12));
        // x=7 is 1 from left torch, 3 from right → max(13, 11) = 13
        Assert.That(GetBlockLight(light, 7, 64, 8), Is.EqualTo(13));
    }

    [Test]
    public void LightDecaysToZeroBeyondRange() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Torch); // emission = 14

        LightData light = ComputeBlockLightOnly(chunk, new Vec2<int>(0, 0));

        // At Manhattan distance 14, light should be 0
        Assert.That(GetBlockLight(light, 8, 64, 8), Is.EqualTo(14));
        // 15 blocks away along +X (but we only have 7 blocks to the right edge at x=15)
        // Let's check along -X where we have room: x=8 to x=0 is 8 blocks
        Assert.That(GetBlockLight(light, 0, 64, 8), Is.EqualTo(14 - 8));
        // Also check the corner: far enough away to be dark
        Assert.That(GetBlockLight(light, 0, 64, 0), Is.EqualTo(0)); // 8+8=16 > 14
    }

    // ── Sky Light Tests ──────────────────────────────────────────────────────

    [Test]
    public void SkyLight_FillsAirChunk() {
        ChunkData chunk = AirChunk();

        LightData light = ComputeWithSkyLight(chunk, new Vec2<int>(0, 0));

        // Air chunk with sky light should have sky light 15 everywhere
        Assert.That(GetSkyLight(light, 0, 0, 0), Is.EqualTo(15));
        Assert.That(GetSkyLight(light, 8, 100, 8), Is.EqualTo(15));
        Assert.That(GetSkyLight(light, 15, 383, 15), Is.EqualTo(15));
    }

    [Test]
    public void SkyLight_BlockedByStoneLayer() {
        ChunkData chunk = AirChunk();

        // Place a full stone layer at y=200
        for (int x = 0; x < 16; x++)
        for (int z = 0; z < 16; z++)
            chunk.SetBlock(x, 200, z, Block.Stone);

        LightData light = ComputeWithSkyLight(chunk, new Vec2<int>(0, 0));

        // Above the stone layer: still sky light 15
        Assert.That(GetSkyLight(light, 8, 201, 8), Is.EqualTo(15));

        // Below the stone layer: no sky light can reach (full 16x16 coverage)
        Assert.That(GetSkyLight(light, 8, 199, 8), Is.EqualTo(0));
        Assert.That(GetSkyLight(light, 0, 100, 0), Is.EqualTo(0));
    }

    [Test]
    public void SkyLight_LeaksThroughHole() {
        ChunkData chunk = AirChunk();

        // Place a stone layer at y=200 with one hole at (8, 200, 8)
        for (int x = 0; x < 16; x++)
        for (int z = 0; z < 16; z++)
            if (x != 8 || z != 8)
                chunk.SetBlock(x, 200, z, Block.Stone);

        LightData light = ComputeWithSkyLight(chunk, new Vec2<int>(0, 0));

        // Above the stone: sky light 15
        Assert.That(GetSkyLight(light, 8, 201, 8), Is.EqualTo(15));

        // Directly below the hole: sky light 15 (vertical column)
        Assert.That(GetSkyLight(light, 8, 199, 8), Is.EqualTo(15));

        // One block to the side below the stone: light spreads from the hole
        // but attenuates. At (9, 199, 8), the closest path is through the hole
        // at (8, 200, 8) → down to (8, 199, 8) → sideways to (9, 199, 8) = 15-1=14
        Assert.That(GetSkyLight(light, 9, 199, 8), Is.EqualTo(14));
    }

    [Test]
    public void SkyLight_GlassDoesNotBlock() {
        ChunkData chunk = AirChunk();

        // Full glass layer at y=200
        for (int x = 0; x < 16; x++)
        for (int z = 0; z < 16; z++)
            chunk.SetBlock(x, 200, z, Block.Glass);

        LightData light = ComputeWithSkyLight(chunk, new Vec2<int>(0, 0));

        // Glass is non-occluding, sky light passes through
        Assert.That(GetSkyLight(light, 8, 201, 8), Is.EqualTo(15));
        Assert.That(GetSkyLight(light, 8, 199, 8), Is.EqualTo(15));
    }

    // ── Cross-Chunk Border Exchange Tests ────────────────────────────────────

    [Test]
    public void BorderExchange_LightCrossesFromNeighbor() {
        // Neighbor at +X (1,0) has glowstone at x=0, y=64, z=8
        // Our chunk (0,0) should receive light at x=15, y=64, z=8
        ChunkData ourChunk = AirChunk();
        ChunkData neighborChunk = AirChunk();
        neighborChunk.SetBlock(0, 64, 8, Block.Glowstone);

        ChunkData? Lookup(Vec2<int> pos) {
            if (pos.X == 1 && pos.Y == 0) return neighborChunk;
            return null;
        }

        LightData light = _provider.GetLighting(
            new Vec2<int>(0, 0), ourChunk, Lookup, VanillaRegistry.Data, false);

        // Glowstone at neighbor x=0 emits 15 → crosses border → our x=15 gets 14
        Assert.That(GetBlockLight(light, 15, 64, 8), Is.EqualTo(14),
            "Light should cross chunk border from +X neighbor");

        // And attenuate further inward
        Assert.That(GetBlockLight(light, 14, 64, 8), Is.EqualTo(13),
            "Light should continue attenuating after crossing border");
    }

    [Test]
    public void BorderExchange_LightCrossesFromNegativeXNeighbor() {
        // Neighbor at -X (-1,0) has glowstone at x=15, y=64, z=8
        ChunkData ourChunk = AirChunk();
        ChunkData neighborChunk = AirChunk();
        neighborChunk.SetBlock(15, 64, 8, Block.Glowstone);

        ChunkData? Lookup(Vec2<int> pos) {
            if (pos.X == -1 && pos.Y == 0) return neighborChunk;
            return null;
        }

        LightData light = _provider.GetLighting(
            new Vec2<int>(0, 0), ourChunk, Lookup, VanillaRegistry.Data, false);

        Assert.That(GetBlockLight(light, 0, 64, 8), Is.EqualTo(14),
            "Light should cross chunk border from -X neighbor");
    }

    [Test]
    public void BorderExchange_LightCrossesFromPositiveZNeighbor() {
        // Neighbor at +Z (0,1) has glowstone at x=8, y=64, z=0
        ChunkData ourChunk = AirChunk();
        ChunkData neighborChunk = AirChunk();
        neighborChunk.SetBlock(8, 64, 0, Block.Glowstone);

        ChunkData? Lookup(Vec2<int> pos) {
            if (pos.X == 0 && pos.Y == 1) return neighborChunk;
            return null;
        }

        LightData light = _provider.GetLighting(
            new Vec2<int>(0, 0), ourChunk, Lookup, VanillaRegistry.Data, false);

        Assert.That(GetBlockLight(light, 8, 64, 15), Is.EqualTo(14),
            "Light should cross chunk border from +Z neighbor");
    }

    [Test]
    public void BorderExchange_LightCrossesFromNegativeZNeighbor() {
        // Neighbor at -Z (0,-1) has glowstone at x=8, y=64, z=15
        ChunkData ourChunk = AirChunk();
        ChunkData neighborChunk = AirChunk();
        neighborChunk.SetBlock(8, 64, 15, Block.Glowstone);

        ChunkData? Lookup(Vec2<int> pos) {
            if (pos.X == 0 && pos.Y == -1) return neighborChunk;
            return null;
        }

        LightData light = _provider.GetLighting(
            new Vec2<int>(0, 0), ourChunk, Lookup, VanillaRegistry.Data, false);

        Assert.That(GetBlockLight(light, 8, 64, 0), Is.EqualTo(14),
            "Light should cross chunk border from -Z neighbor");
    }

    // ── Cache Tests ──────────────────────────────────────────────────────────

    [Test]
    public void Invalidate_ClearsCache() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Torch);

        Vec2<int> pos = new(0, 0);
        LightData first = ComputeBlockLightOnly(chunk, pos);

        // Modify the chunk and invalidate
        chunk.SetBlock(8, 64, 8, Block.Air);
        _provider.Invalidate(pos);

        LightData second = ComputeBlockLightOnly(chunk, pos);

        // After removing the torch and invalidating, there should be no block light
        Assert.That(GetBlockLight(first, 8, 64, 8), Is.EqualTo(14), "Before removal");
        Assert.That(GetBlockLight(second, 8, 64, 8), Is.EqualTo(0), "After removal + invalidate");
    }

    [Test]
    public void IncompleteNeighbors_NotCached() {
        ChunkData chunk = AirChunk();
        chunk.SetBlock(8, 64, 8, Block.Torch);

        Vec2<int> pos = new(0, 0);

        // First call with no neighbors (returns null for all)
        LightData first = _provider.GetLighting(pos, chunk,
            _ => null, VanillaRegistry.Data, false);

        // Second call with neighbors available - should recompute (not cached)
        ChunkData neighbor = AirChunk();
        neighbor.SetBlock(0, 64, 8, Block.Glowstone);
        LightData second = _provider.GetLighting(pos, chunk,
            p => p.X == 1 && p.Y == 0 ? neighbor : null,
            VanillaRegistry.Data, false);

        // First call: x=15 has only torch light = 14-7 = 7
        int firstBorder = GetBlockLight(first, 15, 64, 8);
        // Second call: neighbor glowstone adds 14 at x=15
        int secondBorder = GetBlockLight(second, 15, 64, 8);

        Assert.That(secondBorder, Is.GreaterThan(firstBorder),
            "Result without neighbors should not be cached; recompute should pick up neighbor light");
    }
}
