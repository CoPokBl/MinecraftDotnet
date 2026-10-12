using GraphicalClient.Assets;
using static GraphicalClient.Rendering.BlockFaces;

namespace GraphicalClient.Rendering;

/// <summary>
/// Distant terrain, drawn as cells of 2 or 4 blocks a side. Each cell is opaque, leaves, water, glassy
/// or air by majority, looks like the most common block of that kind on its highest layer, and is lit
/// flat from the layer its face looks into. Plants and anything smaller than a block are left out. The
/// result goes through the same merging as full detail, which turns each cell's face back into one
/// rectangle or less.
/// </summary>
public sealed partial class SectionMesher {
    private enum CellKind : byte {
        Air,
        Water,

        /// <summary>A full translucent block, ice or stained glass: drawn as a surface the way water is.</summary>
        Glassy,
        Leaves,
        Opaque
    }

    private readonly CellKind[] _cellKinds = new CellKind[16 * 16 * 16];
    private readonly ushort[] _cellStates = new ushort[16 * 16 * 16];
    private readonly Dictionary<ushort, int> _votes = new();

    /// <summary>
    /// Neighbouring sections can disagree about a cell they each judge from their own side, and a section
    /// at another level of detail always does, so a solid cell draws its faces on the section's edge
    /// whatever it thinks is next door. Seams then show terrain rather than holes, for about a sixth more quads.
    /// </summary>
    private void MeshCoarse(SectionSnapshot snap, int size) {
        int cells = 16 / size;
        for (int cy = 0; cy < cells; cy++) {
            for (int cz = 0; cz < cells; cz++) {
                for (int cx = 0; cx < cells; cx++) {
                    int index = (cy * cells + cz) * cells + cx;
                    int x0 = cx * size, y0 = cy * size, z0 = cz * size;
                    CellKind kind = Classify(snap, x0, y0, z0, x0 + size - 1, y0 + size - 1, z0 + size - 1);
                    _cellKinds[index] = kind;
                    _cellStates[index] = kind == CellKind.Air ? (ushort)0 : TopState(snap, kind, x0, y0, z0, size);
                }
            }
        }

        for (int cy = 0; cy < cells; cy++) {
            for (int cz = 0; cz < cells; cz++) {
                for (int cx = 0; cx < cells; cx++) {
                    int index = (cy * cells + cz) * cells + cx;
                    CellKind kind = _cellKinds[index];
                    if (kind == CellKind.Air) {
                        continue;
                    }
                    int x0 = cx * size, y0 = cy * size, z0 = cz * size;
                    for (int face = 0; face < 6; face++) {
                        int nx = cx + Steps[face].X, ny = cy + Steps[face].Y, nz = cz + Steps[face].Z;
                        bool edge = (uint)nx >= cells || (uint)ny >= cells || (uint)nz >= cells;
                        // Beyond the section, judged from the one layer of the next section the snapshot holds.
                        CellKind beyond = edge ? Classify(snap, LayerBeyond(face, x0, y0, z0, size, y0 + size)) : _cellKinds[(ny * cells + nz) * cells + nx];
                        // Only water's surface: its sides would stand above the sea at a shore, and a
                        // surface on a section's edge would show inside the sea through it. Ice over the
                        // sea is the same sheet, and its sides would stack translucent faces.
                        if (kind is CellKind.Water or CellKind.Glassy && (face != 1 || Hides(beyond, kind))) {
                            continue;
                        }
                        if (!Hides(beyond, kind) || edge) {
                            EmitCoarseFace(snap, kind, _cellStates[index], x0, y0, z0, size, face);
                        }
                    }
                }
            }
        }
    }

    /// <summary>Whether a cell of kind <paramref name="neighbour"/> hides the face of a <paramref name="kind"/> cell against it.</summary>
    private static bool Hides(CellKind neighbour, CellKind kind) => kind switch {
        CellKind.Opaque => neighbour == CellKind.Opaque,
        CellKind.Leaves => neighbour is CellKind.Opaque or CellKind.Leaves,
        _ => neighbour != CellKind.Air
    };

    private static bool IsGlassy(BlockModel model) => model.FullCube && model.Layer == RenderLayer.Translucent && !model.HasWater;

    /// <summary>Whether a block is one of a cell kind's, for picking what the cell looks like.</summary>
    private static bool Counts(CellKind kind, BlockModel model) => kind switch {
        CellKind.Opaque => model.FullCube && model.OccludesFaces == 0x3F,
        CellKind.Leaves => model.FullCube && model.Layer == RenderLayer.Cutout,
        CellKind.Glassy => IsGlassy(model),
        _ => model.HasWater
    };

    /// <summary>The one block thick layer just outside a face of a cube, inclusive, with the layer above it at <paramref name="above"/>.</summary>
    private static (int X0, int Y0, int Z0, int X1, int Y1, int Z1) LayerBeyond(int face, int x0, int y0, int z0, int size, int above) {
        int x1 = x0 + size - 1, y1 = y0 + size - 1, z1 = z0 + size - 1;
        switch (face) {
            case 0: y0 = y1 = y0 - 1; break;
            case 1: y0 = y1 = above; break;
            case 2: z0 = z1 = z0 - 1; break;
            case 3: z0 = z1 = z0 + size; break;
            case 4: x0 = x1 = x0 - 1; break;
            default: x0 = x1 = x0 + size; break;
        }
        return (x0, y0, z0, x1, y1, z1);
    }

    private CellKind Classify(SectionSnapshot snap, (int X0, int Y0, int Z0, int X1, int Y1, int Z1) box) =>
        Classify(snap, box.X0, box.Y0, box.Z0, box.X1, box.Y1, box.Z1);

    private CellKind Classify(SectionSnapshot snap, int x0, int y0, int z0, int x1, int y1, int z1) {
        int opaque = 0, leaves = 0, water = 0, glassy = 0;
        for (int y = y0; y <= y1; y++) {
            for (int z = z0; z <= z1; z++) {
                for (int x = x0; x <= x1; x++) {
                    BlockModel model = ModelAt(snap, x, y, z);
                    if (IsGlassy(model)) {
                        glassy++;
                    }
                    else if (model.FullCube && model.OccludesFaces == 0x3F) {
                        opaque++;
                    }
                    else if (model.FullCube && model.Layer == RenderLayer.Cutout) {
                        leaves++;
                    }
                    else if (model.HasWater) {
                        water++;
                    }
                }
            }
        }
        int half = ((x1 - x0 + 1) * (y1 - y0 + 1) * (z1 - z0 + 1) + 1) / 2;
        return opaque >= half ? CellKind.Opaque
            : opaque + leaves >= half ? leaves > 0 ? CellKind.Leaves : CellKind.Opaque
            : opaque + leaves + water + glassy >= half
                ? glassy > 0 && glassy >= water ? CellKind.Glassy : water > 0 ? CellKind.Water : leaves > 0 ? CellKind.Leaves : CellKind.Opaque
            : CellKind.Air;
    }

    /// <summary>The most common block of a cell's kind on the highest layer that has any, which is the layer seen from above.</summary>
    private ushort TopState(SectionSnapshot snap, CellKind kind, int x0, int y0, int z0, int size) {
        for (int y = y0 + size - 1; y >= y0; y--) {
            _votes.Clear();
            for (int z = z0; z < z0 + size; z++) {
                for (int x = x0; x < x0 + size; x++) {
                    ushort state = snap.States[SectionSnapshot.Index(x, y, z)];
                    if (Counts(kind, _models[state])) {
                        _votes[state] = _votes.GetValueOrDefault(state) + 1;
                    }
                }
            }
            if (_votes.Count > 0) {
                return MostVoted().State;
            }
        }
        return 0;
    }

    /// <summary>The first state with the most votes, in the order they were first counted.</summary>
    private (ushort State, int Votes) MostVoted() {
        (ushort State, int Votes) best = (0, 0);
        foreach ((ushort state, int votes) in _votes) {
            if (votes > best.Votes) {
                best = (state, votes);
            }
        }
        return best;
    }

    /// <summary>The highest layer of a cell holding a block of its kind, or the bottom layer if none above it does.</summary>
    private int Highest(SectionSnapshot snap, CellKind kind, int x0, int y0, int z0, int size) {
        for (int y = y0 + size - 1; y > y0; y--) {
            for (int z = z0; z < z0 + size; z++) {
                for (int x = x0; x < x0 + size; x++) {
                    if (Counts(kind, ModelAt(snap, x, y, z))) {
                        return y;
                    }
                }
            }
        }
        return y0;
    }

    private void EmitCoarseFace(SectionSnapshot snap, CellKind kind, ushort state, int x0, int y0, int z0, int size, int face) {
        ushort drawn = kind == CellKind.Water ? (ushort)WaterState : state;
        BlockModel model = _models[drawn];
        RenderLayer layer = kind switch {
            CellKind.Water or CellKind.Glassy => RenderLayer.Translucent,
            CellKind.Leaves => RenderLayer.Cutout,
            _ => model.Layer
        };

        // Water's surface sits where the highest water in the cell ends rather than at the cell's top,
        // so the sea is level with the full detail sea next to it.
        float top = 1.0F;
        int topY = y0 + size - 1;
        if (face == 1 && kind is CellKind.Water or CellKind.Glassy) {
            topY = Highest(snap, kind, x0, y0, z0, size);
            top = kind == CellKind.Water ? 8.0F / 9.0F : 1.0F;
        }

        // Lit by the brightest block of the layer the face looks into: a cell's open side is often only
        // partly open, and one block picked from it can be the rock behind.
        (int lx0, int ly0, int lz0, int lx1, int ly1, int lz1) = LayerBeyond(face, x0, y0, z0, size, topY + 1);
        int brightestSky = 0, brightestBlock = 0;
        for (int ly = ly0; ly <= ly1; ly++) {
            for (int lz = lz0; lz <= lz1; lz++) {
                for (int lx = lx0; lx <= lx1; lx++) {
                    byte cellLight = snap.Light[SectionSnapshot.Index(lx, ly, lz)];
                    brightestSky = Math.Max(brightestSky, cellLight >> 4);
                    brightestBlock = Math.Max(brightestBlock, cellLight & 15);
                }
            }
        }
        float sky = brightestSky, block = model.Emissive ? 15 : brightestBlock;
        uint tint = kind == CellKind.Water
            ? TintOf(snap, TintKind.Water, Math.Clamp((lx0 + lx1) / 2, 0, 15), Math.Clamp((ly0 + ly1) / 2, 0, 15), Math.Clamp((lz0 + lz1) / 2, 0, 15))
            : FaceTint(snap, model, face, x0, y0, z0);
        ushort texture = model.TextureLayers[face];
        if (face == 1 && kind is CellKind.Opaque or CellKind.Leaves && Cover(snap, x0, topY + 1, z0, size) is { } cover) {
            (texture, tint) = UpFace(snap, cover, x0, Math.Min(topY + 1, 15), z0);
        }
        byte flags = kind == CellKind.Water && face == 1 ? FluidSurfaceFlag : (byte)0;
        _materialBits = MaterialBits(snap.Materials.Of(drawn));
        List<BlockVertex> target = Target(layer, face);

        // One unit face per block of the cell's side, all alike, which merging turns into one rectangle.
        int axis = Axis(face);
        bool positive = (face & 1) != 0;
        for (int a = 0; a < size; a++) {
            for (int b = 0; b < size; b++) {
                int bx = x0, by = y0, bz = z0;
                switch (axis) {
                    case 0: bx += positive ? size - 1 : 0; by += a; bz += b; break;
                    case 1: by = positive ? topY : y0; bx += a; bz += b; break;
                    default: bz += positive ? size - 1 : 0; bx += a; by += b; break;
                }
                for (int c = 0; c < 4; c++) {
                    float px = Corners[face, c, 0];
                    float py = Corners[face, c, 1] == 0 ? 0 : face == 1 ? top : 1;
                    float pz = Corners[face, c, 2];
                    (float u, float v) = Uv(face, px, Corners[face, c, 1], pz);
                    target.Add(Vertex(bx + px, by + py, bz + pz, u, v, texture, sky, block, 1.0F, face, tint, flags));
                }
            }
        }
    }

    /// <summary>
    /// The thin block lying over most of a cell's top, snow or a carpet, which is what that face shows
    /// from afar although the cell leaves it out for not being a full block.
    /// </summary>
    private BlockModel? Cover(SectionSnapshot snap, int x0, int y, int z0, int size) {
        if (y > 16) {
            return null;
        }
        _votes.Clear();
        for (int z = z0; z < z0 + size; z++) {
            for (int x = x0; x < x0 + size; x++) {
                ushort state = snap.States[SectionSnapshot.Index(x, y, z)];
                if (IsCover(_models[state])) {
                    _votes[state] = _votes.GetValueOrDefault(state) + 1;
                }
            }
        }
        (ushort best, int most) = MostVoted();
        return most * 2 >= size * size ? _models[best] : null;
    }

    private static bool IsCover(BlockModel model) =>
        !model.FullCube && model.Boxes.Length > 0 && model.Boxes.All(b => b.MaxY <= 0.5F)
        && model.Boxes.Any(b => b.MinX <= 0 && b.MinZ <= 0 && b.MaxX >= 1 && b.MaxZ >= 1);

    /// <summary>A block's upward face texture and colour, from its model's first quad facing up where it has one.</summary>
    private static (ushort Texture, uint Tint) UpFace(SectionSnapshot snap, BlockModel model, int x, int y, int z) {
        if (model.Parts.Length > 0) {
            foreach (MeshQuad quad in model.Parts[0].Options[0].Quads) {
                if (quad.Facing == 1) {
                    return (quad.Texture, QuadTint(snap, quad, x, y, z));
                }
            }
        }
        return (model.TextureLayers[1], FaceTint(snap, model, 1, x, y, z));
    }
}
