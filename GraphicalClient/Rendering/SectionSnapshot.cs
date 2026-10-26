using ClientLib.World;

namespace GraphicalClient.Rendering;

/// <summary>
/// The blocks and light of one section and a <see cref="Border"/> around it, captured on the game thread
/// and copied out on a worker, so the worker can mesh it without touching the level.
/// </summary>
public sealed class SectionSnapshot {
    /// <summary>
    /// Two blocks, because smooth light for a face on the block's boundary asks whether the corner
    /// cells one step further out along the face direction let light through.
    /// </summary>
    public const int Border = 2;

    public const int Width = 16 + 2 * Border;
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

    public static int Index(int x, int y, int z) => (y + Border) * Width * Width + (z + Border) * Width + (x + Border);

    private static int Nibble(byte[] layer, int index) => layer[index >> 1] >> ((index & 1) << 2) & 15;

    /// <summary>The 27 sections a snapshot reads, by <see cref="Piece"/>; null outside the world or the loaded chunks.</summary>
    private readonly SectionStates?[] _blocks = new SectionStates?[27];
    private readonly byte[]?[] _blockLight = new byte[]?[27];
    private readonly byte[]?[] _skyLight = new byte[]?[27];

    /// <summary>Whether a piece's sky layer is the nearest stored one above it, read by its bottom row.</summary>
    private readonly bool[] _skyBottomRow = new bool[27];

    /// <summary>The sky light, already in the high nibble, for a piece with no sky layer.</summary>
    private readonly byte[] _flatSky = new byte[27];

    private static int Piece(int cx, int cy, int cz) => (cx + 1) * 9 + (cz + 1) * 3 + cy + 1;

    /// <summary>
    /// Takes what <see cref="Fill"/> reads, on the game thread. Nothing is copied but the biomes: block
    /// arrays are shared copy on write and light layers are replaced rather than written, so a worker
    /// can read both later.
    /// </summary>
    public void Capture(ClientLevel level, int sx, int sy, int sz) {
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
                for (int cy = -1; cy <= 1; cy++) {
                    int piece = Piece(cx, cy, cz);
                    int section = sy + cy;
                    bool inWorld = section >= 0 && section < level.SectionCount;
                    _blocks[piece] = chunk != null && inWorld ? chunk.Sections[section].Share() : null;
                    _blockLight[piece] = chunk != null && inWorld ? chunk.BlockLight[section + 1] : null;
                    // An empty sky layer takes the bottom row of the nearest stored one above it.
                    byte[]? skyLayer = null;
                    bool skyBottomRow = false;
                    if (chunk != null && hasSky && section >= 0) {
                        int layerIndex = Math.Min(section + 1, chunk.SkyLight.Length - 1);
                        skyLayer = chunk.SkyLight[layerIndex];
                        for (int above = layerIndex + 1; skyLayer == null && above < chunk.SkyLight.Length; above++) {
                            skyLayer = chunk.SkyLight[above];
                            skyBottomRow = skyLayer != null;
                        }
                    }
                    _skyLight[piece] = skyLayer;
                    _skyBottomRow[piece] = skyBottomRow;
                    _flatSky[piece] = (byte)(section < 0 || !hasSky ? 0 : 0xF0);
                }
            }
        }
    }

    /// <summary>Copies the captured section and its border, resolving vanilla's light storage rules as it goes.</summary>
    public void Fill() {
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                int x0 = cx < 0 ? 16 - Border : 0, x1 = cx > 0 ? Border - 1 : 15;
                int z0 = cz < 0 ? 16 - Border : 0, z1 = cz > 0 ? Border - 1 : 15;
                int count = x1 - x0 + 1;
                for (int cy = -1; cy <= 1; cy++) {
                    int piece = Piece(cx, cy, cz);
                    SectionStates? blocks = _blocks[piece];
                    byte[]? blockLight = _blockLight[piece], skyLayer = _skyLight[piece];
                    bool skyBottomRow = _skyBottomRow[piece];
                    byte flatSky = _flatSky[piece];
                    int y0 = cy < 0 ? 16 - Border : 0, y1 = cy > 0 ? Border - 1 : 15;
                    for (int ly = y0; ly <= y1; ly++) {
                        int py = ly + cy * 16;
                        for (int lz = z0; lz <= z1; lz++) {
                            int index = Index(x0 + cx * 16, py, lz + cz * 16);
                            int blockIndex = ly << 8 | lz << 4 | x0;
                            Span<ushort> states = States.AsSpan(index, count);
                            if (blocks is { } view) {
                                view.CopyTo(blockIndex, states);
                            }
                            else {
                                states.Clear();
                            }

                            Span<byte> light = Light.AsSpan(index, count);
                            if (skyLayer == null) {
                                light.Fill(flatSky);
                            }
                            else {
                                int skyIndex = skyBottomRow ? lz << 4 | x0 : blockIndex;
                                for (int i = 0; i < count; i++) {
                                    light[i] = (byte)(Nibble(skyLayer, skyIndex + i) << 4);
                                }
                            }
                            if (blockLight != null) {
                                for (int i = 0; i < count; i++) {
                                    light[i] |= (byte)Nibble(blockLight, blockIndex + i);
                                }
                            }
                        }
                    }
                }
            }
        }
        // A pooled snapshot would otherwise keep superseded arrays alive until it is next used.
        Array.Clear(_blocks);
        Array.Clear(_blockLight);
        Array.Clear(_skyLight);
    }
}
