using System.Numerics;
using System.Runtime.InteropServices;
using GraphicalClient.Assets;
using Minecraft.Schemas.Vec;
using static GraphicalClient.Rendering.BlockFaces;

namespace GraphicalClient.Rendering;

public sealed partial class SectionMesher {
    private readonly MeshOption[] _chosen = new MeshOption[64];

    private void MeshShape(SectionSnapshot snap, int x, int y, int z, BlockModel model) {
        (float X, float Y, float Z) offset = OffsetAt(model, snap.SectionX * 16 + x, snap.SectionZ * 16 + z);
        foreach (ModelBox box in model.Boxes) {
            for (int face = 0; face < 6; face++) {
                bool onBoundary = face switch {
                    0 => box.MinY <= 0,
                    1 => box.MaxY >= 1,
                    2 => box.MinZ <= 0,
                    3 => box.MaxZ >= 1,
                    4 => box.MinX <= 0,
                    _ => box.MaxX >= 1
                };
                if (!onBoundary || !Culled(snap, model, x, y, z, face)) {
                    EmitBoxFace(snap, x, y, z, box, face, onBoundary, model, offset);
                }
            }
        }
    }

    private void EmitBoxFace(SectionSnapshot snap, int x, int y, int z, ModelBox box, int face, bool onBoundary, BlockModel model,
        (float X, float Y, float Z) offset) {
        Span<float> sky = stackalloc float[4], block = stackalloc float[4], ao = stackalloc float[4];
        int own = SectionSnapshot.Index(x, y, z), beyond = own + SectionSnapshot.FaceStrides[face];
        if (onBoundary && !model.Emissive) {
            SmoothLight(snap, beyond, face, sky, block, ao);
        }
        else {
            byte light = snap.Light[onBoundary ? beyond : own];
            if (!onBoundary && light == 0) {
                // Inside a block that stores no light of its own, a slab's top half for instance.
                light = snap.Light[beyond];
            }
            FlatLight(light, sky, block, ao);
        }
        if (model.Emissive) {
            block.Fill(15);
        }

        uint tint = (model.TintFaces & (1 << face)) != 0 ? TintOf(snap, model.Tint, x, y, z) : 0xFFFFFF;
        List<BlockVertex> target = Target(model.Layer, face);
        int start = target.Count;
        for (int c = 0; c < 4; c++) {
            float px = Corners[face, c, 0] == 0 ? box.MinX : box.MaxX;
            float py = Corners[face, c, 1] == 0 ? box.MinY : box.MaxY;
            float pz = Corners[face, c, 2] == 0 ? box.MinZ : box.MaxZ;
            (float u, float v) = Uv(face, px, py, pz);
            target.Add(Vertex(x + px + offset.X, y + py + offset.Y, z + pz + offset.Z, u, v, model.TextureLayers[face], sky[c], block[c], ao[c], face, tint));
        }
        FlipToDarkerDiagonal(target, start, ao);
    }

    /// <summary>
    /// A resource pack model's quads, the way <c>ModelBlockRenderer</c> draws them: a quad with a cull
    /// face is skipped when that neighbour hides it, and light is smooth with ambient occlusion unless
    /// the model or the block's own light turns that off. Smooth light is worked out for the block face
    /// the quad lies along and interpolated to each corner by where the corner sits on it, which is how
    /// a slab's side or a stair's step gets the right shading part way up a face.
    /// </summary>
    private void MeshModel(SectionSnapshot snap, int x, int y, int z, BlockModel model) {
        int wx = snap.SectionX * 16 + x, wy = snap.BaseY + y, wz = snap.SectionZ * 16 + z;
        int parts = Math.Min(model.Parts.Length, _chosen.Length);
        model.Choose(wx, wy, wz, _chosen.AsSpan(0, parts));
        (float ox, float oy, float oz) = OffsetAt(model, wx, wz);
        int own = SectionSnapshot.Index(x, y, z);

        Span<float> cornerSky = stackalloc float[4], cornerBlock = stackalloc float[4], cornerAo = stackalloc float[4];
        Span<float> sky = stackalloc float[4], block = stackalloc float[4], ao = stackalloc float[4];
        for (int p = 0; p < parts; p++) {
            MeshOption option = _chosen[p];
            bool smooth = option.AmbientOcclusion && model.LightEmission == 0;
            foreach (MeshQuad quad in option.Quads) {
                if (quad.Cull >= 0 && Culled(snap, model, x, y, z, quad.Cull)) {
                    continue;
                }

                int face = quad.Facing;
                if (smooth && face < 6) {
                    // Inside the block the face is lit as if the block itself were the cell it looks into.
                    SmoothLight(snap, quad.OnBoundary ? own + SectionSnapshot.FaceStrides[face] : own, face, cornerSky, cornerBlock, cornerAo);
                    int axis = Axis(face), t1 = (axis + 1) % 3, t2 = (axis + 2) % 3;
                    for (int v = 0; v < 4; v++) {
                        float f1 = Math.Clamp(Component(quad.Positions[v], t1), 0, 1), f2 = Math.Clamp(Component(quad.Positions[v], t2), 0, 1);
                        sky[v] = block[v] = ao[v] = 0;
                        for (int c = 0; c < 4; c++) {
                            float weight = (Corners[face, c, t1] == 1 ? f1 : 1 - f1) * (Corners[face, c, t2] == 1 ? f2 : 1 - f2);
                            sky[v] += cornerSky[c] * weight;
                            block[v] += cornerBlock[c] * weight;
                            ao[v] += cornerAo[c] * weight;
                        }
                    }
                }
                else {
                    int toward = own + SectionSnapshot.FaceStrides[quad.Direction];
                    byte light = snap.Light[quad.OnBoundary || quad.Cull >= 0 ? toward : own];
                    if (light == 0) {
                        light = snap.Light[toward];
                    }
                    FlatLight(light, sky, block, ao);
                }
                if (quad.Emission > 0) {
                    for (int v = 0; v < 4; v++) {
                        block[v] = Math.Max(block[v], quad.Emission);
                    }
                }

                uint tint = QuadTint(snap, quad, x, y, z);
                List<BlockVertex> target = Target(quad.Layer, face);
                byte flags = quad.Shade ? (byte)0 : PlantFlag;
                int start = target.Count;
                for (int v = 0; v < 4; v++) {
                    Vector3 position = quad.Positions[v];
                    target.Add(Vertex(x + position.X + ox, y + position.Y + oy, z + position.Z + oz, quad.Uvs[v].X, quad.Uvs[v].Y,
                        quad.Texture, sky[v], block[v], ao[v], quad.Direction, tint, flags));
                }
                FlipToDarkerDiagonal(target, start, ao);
            }
        }
    }

    private void MeshCross(SectionSnapshot snap, int x, int y, int z, BlockModel model) {
        (float ox, float oy, float oz) = OffsetAt(model, snap.SectionX * 16 + x, snap.SectionZ * 16 + z);
        byte light = snap.Light[SectionSnapshot.Index(x, y, z)];
        float sky = light >> 4;
        float blockLight = model.Emissive ? 15 : light & 15;
        ushort layer = model.TextureLayers[0];
        List<BlockVertex> target = Target(RenderLayer.Cutout, SectionMesh.Unaligned);
        uint tint = TintOf(snap, model.Tint, x, y, z);

        // Vanilla's cross model inset: the planes run corner to corner of a square 0.8 wide.
        const float a = 0.1F, b = 0.9F;
        float bx = x + ox, by = y + oy, bz = z + oz;
        float top = 1.0F;
        Span<(float X0, float Z0, float X1, float Z1)> planes = [(a, a, b, b), (a, b, b, a)];
        // One winding each: cutout geometry is drawn without back face culling, which halves what a
        // field of plants costs against emitting both sides.
        foreach ((float x0, float z0, float x1, float z1) in planes) {
            target.Add(Vertex(bx + x0, by, bz + z0, 0, 1, layer, sky, blockLight, 1.0F, 2, tint, PlantFlag));
            target.Add(Vertex(bx + x1, by, bz + z1, 1, 1, layer, sky, blockLight, 1.0F, 2, tint, PlantFlag));
            target.Add(Vertex(bx + x1, by + top, bz + z1, 1, 0, layer, sky, blockLight, 1.0F, 2, tint, PlantFlag));
            target.Add(Vertex(bx + x0, by + top, bz + z0, 0, 0, layer, sky, blockLight, 1.0F, 2, tint, PlantFlag));
        }
    }

    /// <summary>
    /// <c>Block.shouldRenderFace</c> as far as the snapshot can tell: the neighbour covers the whole face
    /// toward this block, or it is the same full block and neither is solid, glass against glass.
    /// </summary>
    private bool Culled(SectionSnapshot snap, BlockModel model, int x, int y, int z, int face) {
        (int dx, int dy, int dz) = Steps[face];
        BlockModel neighbour = _models[snap.States[SectionSnapshot.Index(x + dx, y + dy, z + dz)]];
        return (neighbour.OccludesFaces & (1 << (face ^ 1))) != 0
               || model.Layer != RenderLayer.Solid && neighbour.BlockKey == model.BlockKey && neighbour.FullCube && model.FullCube;
    }

    /// <summary>
    /// <c>ModelBlockRenderer.AmbientOcclusionRenderStorage.calculate</c> for a face looking into the cell at
    /// <paramref name="cell"/>: each corner averages that cell with its two edge neighbours and the diagonal,
    /// and the diagonal is ignored when both edges are opaque.
    /// </summary>
    private void SmoothLight(SectionSnapshot snap, int cell, int face, Span<float> sky, Span<float> block, Span<float> ao) {
        int axis = Axis(face), t1 = (axis + 1) % 3, t2 = (axis + 2) % 3;
        int step1 = SectionSnapshot.AxisStrides[t1], step2 = SectionSnapshot.AxisStrides[t2];
        int centre = snap.Light[cell];
        float centreShade = Shade(snap, cell);
        for (int c = 0; c < 4; c++) {
            int side1 = cell + (Corners[face, c, t1] == 0 ? -step1 : step1);
            int side2 = cell + (Corners[face, c, t2] == 0 ? -step2 : step2);
            int light1 = snap.Light[side1], light2 = snap.Light[side2];
            float shade1 = Shade(snap, side1), shade2 = Shade(snap, side2);
            bool diagonal = shade1 > 0.5F || shade2 > 0.5F;
            int corner = side1 + side2 - cell;
            int cornerLight = diagonal ? snap.Light[corner] : light1;
            float cornerShade = diagonal ? Shade(snap, corner) : shade1;
            (sky[c], block[c]) = Blend(light1, light2, cornerLight, centre);
            ao[c] = (shade1 + shade2 + cornerShade + centreShade) * 0.25F;
        }
    }

    /// <summary><c>ModelBlockRenderer.blend</c>: a zero neighbour borrows the centre's value instead of pulling the corner dark.</summary>
    private static (float Sky, float Block) Blend(int a, int b, int c, int centre) {
        if (a == 0) a = centre;
        if (b == 0) b = centre;
        if (c == 0) c = centre;
        float sky = ((a >> 4) + (b >> 4) + (c >> 4) + (centre >> 4)) * 0.25F;
        float blockLight = ((a & 15) + (b & 15) + (c & 15) + (centre & 15)) * 0.25F;
        return (sky, blockLight);
    }

    private float Shade(SectionSnapshot snap, int index) => _models[snap.States[index]].AoShade;

    private static void FlatLight(byte light, Span<float> sky, Span<float> block, Span<float> ao) {
        for (int c = 0; c < 4; c++) {
            sky[c] = light >> 4;
            block[c] = light & 15;
            ao[c] = 1.0F;
        }
    }

    /// <summary>Flips the quad's diagonal toward the darker pair, as vanilla does, so occlusion gradients do not crease.</summary>
    private static void FlipToDarkerDiagonal(List<BlockVertex> target, int start, ReadOnlySpan<float> ao) {
        if (ao[0] + ao[2] > ao[1] + ao[3]) {
            Span<BlockVertex> quad = CollectionsMarshal.AsSpan(target).Slice(start, 4);
            BlockVertex first = quad[0];
            quad[0] = quad[1];
            quad[1] = quad[2];
            quad[2] = quad[3];
            quad[3] = first;
        }
    }

    private static (float X, float Y, float Z) OffsetAt(BlockModel model, int worldX, int worldZ) {
        if (!model.HasOffset) {
            return (0, 0, 0);
        }
        Vec3<double> offset = model.Info.ShapeOffset(new Vec3<int>(worldX, 0, worldZ));
        return ((float)offset.X, (float)offset.Y, (float)offset.Z);
    }
}
