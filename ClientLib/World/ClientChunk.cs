using System.Collections;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ClientLib.World;

/// <summary>
/// One column as the client holds it. Light is stored per light section, of which there are two more
/// than block sections: vanilla keeps one below the world and one above it, and the masks on the wire
/// count from the one below.
/// </summary>
public sealed class ClientChunk {
    /// <summary>A light layer the server said is all zero, shared rather than allocated per section.</summary>
    public static readonly byte[] EmptyLight = new byte[2048];

    public int X { get; }
    public int Z { get; }
    public ClientSection[] Sections { get; }

    /// <summary>Biome ids per section, 64 cells in <c>y &lt;&lt; 4 | z &lt;&lt; 2 | x</c> order.</summary>
    public ushort[][] Biomes { get; }

    /// <summary>Null where the server has sent nothing, which for sky light means "ask the section above".</summary>
    public byte[]?[] SkyLight { get; }
    public byte[]?[] BlockLight { get; }

    /// <summary><c>LevelChunk.blockEntities</c>, by absolute position.</summary>
    public Dictionary<Vec3<int>, BlockEntities.ClientBlockEntity> BlockEntities { get; } = new();

    /// <summary>The level the chunk was built for, whose height and air table its sections follow.</summary>
    public ClientLevel? Level { get; init; }

    public ClientChunk(int x, int z, ClientSection[] sections, ushort[][] biomes) {
        X = x;
        Z = z;
        Sections = sections;
        Biomes = biomes;
        SkyLight = new byte[]?[sections.Length + 2];
        BlockLight = new byte[]?[sections.Length + 2];
    }

    /// <summary><c>ClientPacketListener.applyLightData</c> and its <c>readSectionList</c>.</summary>
    /// <returns>Bits of the block sections whose light changed, for the renderer to rebuild.</returns>
    public ulong ApplyLight(LightData light) =>
        ReadSectionList(SkyLight, light.SkyLightMask, light.EmptySkyLightMask, light.SkyLight, false)
        | ReadSectionList(BlockLight, light.BlockLightMask, light.EmptyBlockLightMask, light.BlockLight, false);

    /// <summary>Light this client worked out itself, replacing what it holds.</summary>
    /// <returns>Bits of the block sections whose light is actually different, for the renderer to rebuild.</returns>
    public ulong ReplaceLight(LightData light) =>
        ReadSectionList(SkyLight, light.SkyLightMask, light.EmptySkyLightMask, light.SkyLight, true)
        | ReadSectionList(BlockLight, light.BlockLightMask, light.EmptyBlockLightMask, light.BlockLight, true);

    private static ulong ReadSectionList(byte[]?[] layers, BitArray mask, BitArray emptyMask, byte[][] updates, bool onlyDifferent) {
        ulong changed = 0;
        int next = 0;
        for (int i = 0; i < layers.Length; i++) {
            bool haveData = i < mask.Length && mask[i];
            bool haveEmpty = i < emptyMask.Length && emptyMask[i];
            if (!haveData && !haveEmpty) {
                continue;
            }
            byte[] layer = haveData ? updates[next++] : EmptyLight;
            if (!onlyDifferent || layers[i] == null || !layers[i].AsSpan().SequenceEqual(layer)) {
                changed |= 1UL << Math.Max(0, i - 1);
            }
            layers[i] = layer;
        }
        return changed;
    }

    /// <param name="section">Block section index, counting from the bottom of the world.</param>
    public int GetBlockLight(int x, int section, int y, int z) {
        byte[]? layer = BlockLight[section + 1];
        return layer == null ? 0 : Nibble(layer, x, y, z);
    }

    /// <summary>
    /// <c>SkyLightSectionStorage.getLightValue</c>: a section with no data reads the bottom row of the
    /// nearest section above that has some, and the open sky when there is none.
    /// </summary>
    public int GetSkyLight(int x, int section, int y, int z) {
        int index = section + 1;
        byte[]? layer = SkyLight[index];
        if (layer != null) {
            return Nibble(layer, x, y, z);
        }
        for (index++; index < SkyLight.Length; index++) {
            layer = SkyLight[index];
            if (layer != null) {
                return Nibble(layer, x, 0, z);
            }
        }
        return 15;
    }

    private static int Nibble(byte[] layer, int x, int y, int z) {
        int index = y << 8 | z << 4 | x;
        return layer[index >> 1] >> ((index & 1) << 2) & 15;
    }

    public ushort GetBiome(int x, int section, int y, int z) {
        return Biomes[section][(y >> 2) << 4 | (z >> 2) << 2 | x >> 2];
    }
}
