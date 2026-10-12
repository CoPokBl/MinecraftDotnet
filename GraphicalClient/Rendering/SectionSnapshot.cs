using ClientLib.World;

namespace GraphicalClient.Rendering;

/// <summary>
/// The blocks and light of one section and a one block border around it, copied on the game thread
/// so a worker can mesh it without touching the level.
/// </summary>
public sealed class SectionSnapshot {
    public const int Width = 18;
    public const int Volume = Width * Width * Width;

    /// <summary>What <see cref="Index"/> moves by for one step toward each <see cref="Assets.Face"/>.</summary>
    public static readonly int[] FaceStrides = [-Width * Width, Width * Width, -Width, Width, -1, 1];

    /// <summary>What <see cref="Index"/> moves by for one step along x, y and z.</summary>
    public static readonly int[] AxisStrides = [1, Width * Width, Width];

    public readonly ushort[] States = new ushort[Volume];

    /// <summary>Sky light in the high nibble, block light in the low one.</summary>
    public readonly byte[] Light = new byte[Volume];

    public int SectionX, SectionY, SectionZ;
    public int Version;

    /// <summary>World y of the section's lowest block, which a model's random variant is seeded with.</summary>
    public int BaseY;

    /// <summary>Level of detail to mesh at: 0 is every block, then cells of 2 and 4 blocks a side.</summary>
    public int Lod;

    /// <summary>The section's 4x4x4 biome cells, <c>y &lt;&lt; 4 | z &lt;&lt; 2 | x</c>.</summary>
    public readonly ushort[] Biomes = new ushort[64];

    /// <summary>Tint colours by biome id, shared by every snapshot of the level.</summary>
    public BiomeColours.Tints[] Tints = [];

    /// <summary>The shader pack's material numbers, shared by every snapshot taken while that pack is loaded.</summary>
    public Pipeline.BlockMaterials Materials = Pipeline.BlockMaterials.None;

    public static int Index(int x, int y, int z) => (y + 1) * Width * Width + (z + 1) * Width + (x + 1);

    /// <summary>Copies a section and its one block border, resolving vanilla's light storage rules as it goes.</summary>
    public void Fill(ClientLevel level, int sx, int sy, int sz) {
        SectionX = sx;
        SectionY = sy;
        SectionZ = sz;
        bool hasSky = level.DimensionType.HasSkyLight;
        if (level.GetChunk(sx, sz) is { } centre) {
            Array.Copy(centre.Biomes[sy], Biomes, 64);
        }

        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientChunk? chunk = level.GetChunk(sx + cx, sz + cz);
                int x0 = cx < 0 ? 15 : 0, x1 = cx > 0 ? 0 : 15;
                int z0 = cz < 0 ? 15 : 0, z1 = cz > 0 ? 0 : 15;
                for (int cy = -1; cy <= 1; cy++) {
                    int section = sy + cy;
                    int y0 = cy < 0 ? 15 : 0, y1 = cy > 0 ? 0 : 15;
                    bool inWorld = section >= 0 && section < level.SectionCount;
                    ClientSection? blocks = chunk != null && inWorld ? chunk.Sections[section] : null;
                    byte[]? blockLight = chunk != null && inWorld ? chunk.BlockLight[section + 1] : null;
                    // An empty sky layer takes the bottom row of the nearest stored one above it.
                    byte[]? skyLayer = null;
                    bool skyBottomRow = false;
                    if (chunk != null && hasSky) {
                        int layerIndex = Math.Clamp(section + 1, 0, chunk.SkyLight.Length - 1);
                        skyLayer = chunk.SkyLight[layerIndex];
                        for (int above = layerIndex + 1; skyLayer == null && above < chunk.SkyLight.Length; above++) {
                            skyLayer = chunk.SkyLight[above];
                            skyBottomRow = skyLayer != null;
                        }
                    }

                    for (int ly = y0; ly <= y1; ly++) {
                        int py = ly + cy * 16;
                        for (int lz = z0; lz <= z1; lz++) {
                            int pz = lz + cz * 16;
                            int rowIndex = Index(0, py, pz) - 1;
                            for (int lx = x0; lx <= x1; lx++) {
                                int index = rowIndex + lx + cx * 16 + 1;
                                int blockIndex = ly << 8 | lz << 4 | lx;
                                States[index] = blocks?.Get(blockIndex) ?? 0;
                                int b = blockLight == null ? 0 : blockLight[blockIndex >> 1] >> ((blockIndex & 1) << 2) & 15;
                                int s;
                                if (skyLayer == null) {
                                    s = hasSky ? 15 : 0;
                                }
                                else {
                                    int skyIndex = skyBottomRow ? lz << 4 | lx : blockIndex;
                                    s = skyLayer[skyIndex >> 1] >> ((skyIndex & 1) << 2) & 15;
                                }
                                if (section < 0) {
                                    s = 0;
                                }
                                Light[index] = (byte)(s << 4 | b);
                            }
                        }
                    }
                }
            }
        }
    }
}
