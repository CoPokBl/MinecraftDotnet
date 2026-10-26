using System.Numerics;
using GraphicalClient.Assets;
using Minecraft.Lighting;
using Minecraft.Schemas.Vec;
using static GraphicalClient.Rendering.BlockFaces;

namespace GraphicalClient.Rendering;

public sealed partial class SectionMesher {
    private readonly MeshOption[] _chosen = new MeshOption[64];

    private readonly Vector3[] _boxFace = new Vector3[4];

    /// <summary>
    /// A state the pack has no model for, drawn from its shape as the model with one element per box
    /// would be: each face on the block's boundary culled against its neighbour, smooth lit unless the
    /// block gives off light.
    /// </summary>
    private void MeshShape(SectionSnapshot snap, int x, int y, int z, BlockModel model) {
        (float X, float Y, float Z) offset = OffsetAt(model, snap.SectionX * 16 + x, snap.SectionZ * 16 + z);
        int own = SectionSnapshot.Index(x, y, z);
        bool smooth = AmbientOcclusion && model.LightEmission == 0;
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
                if (onBoundary && Culled(snap, model, x, y, z, face)) {
                    continue;
                }
                for (int c = 0; c < 4; c++) {
                    _boxFace[c] = new Vector3(
                        FaceInfo[face, c, 0] == 0 ? box.MinX : box.MaxX,
                        FaceInfo[face, c, 1] == 0 ? box.MinY : box.MaxY,
                        FaceInfo[face, c, 2] == 0 ? box.MinZ : box.MaxZ);
                }
                if (smooth) {
                    _lighter.PrepareQuadAmbientOcclusion(snap, model, own, _boxFace, face);
                }
                else {
                    int light = onBoundary ? BlockModelLighter.CulledLightCoords(snap, model, own, face) : -1;
                    _lighter.PrepareQuadFlat(snap, model, own, light, _boxFace, face);
                }

                uint tint = (model.TintFaces & (1 << face)) != 0 ? TintOf(snap, model.Tint, x, y, z) : 0xFFFFFF;
                List<BlockVertex> target = Target(model.Layer, face);
                for (int c = 0; c < 4; c++) {
                    Vector3 p = _boxFace[c];
                    (float u, float v) = Uv(face, p.X, p.Y, p.Z);
                    target.Add(Vertex(x + p.X + offset.X, y + p.Y + offset.Y, z + p.Z + offset.Z, u, v, model.TextureLayers[face],
                        _lighter.Light[c], _lighter.Occlusion[c], face, face, tint));
                }
            }
        }
    }

    /// <summary>
    /// A resource pack model's quads, <c>ModelBlockRenderer.tesselateBlock</c>: smooth lit when the option
    /// is on, the block gives off no light and the first part drawn asks for ambient occlusion, else
    /// flat. A quad with a cull face is skipped when that neighbour hides it and, lit flat, takes the
    /// light there; any other quad is lit by <c>BlockModelLighter</c> from its own shape.
    /// </summary>
    private void MeshModel(SectionSnapshot snap, int x, int y, int z, BlockModel model) {
        int wx = snap.SectionX * 16 + x, wy = snap.BaseY + y, wz = snap.SectionZ * 16 + z;
        int parts = Math.Min(model.Parts.Length, _chosen.Length);
        if (parts == 0) {
            return;
        }
        model.Choose(wx, wy, wz, _chosen.AsSpan(0, parts));
        (float ox, float oy, float oz) = OffsetAt(model, wx, wz);
        int own = SectionSnapshot.Index(x, y, z);
        bool smooth = AmbientOcclusion && model.LightEmission == 0 && _chosen[0].AmbientOcclusion;

        for (int p = 0; p < parts; p++) {
            foreach (MeshQuad quad in _chosen[p].Quads) {
                if (quad.Cull >= 0 && Culled(snap, model, x, y, z, quad.Cull)) {
                    continue;
                }
                if (smooth) {
                    _lighter.PrepareQuadAmbientOcclusion(snap, model, own, quad.Positions, quad.Direction);
                }
                else {
                    int light = quad.Cull >= 0 ? BlockModelLighter.CulledLightCoords(snap, model, own, quad.Cull) : -1;
                    _lighter.PrepareQuadFlat(snap, model, own, light, quad.Positions, quad.Direction);
                }

                uint tint = QuadTint(snap, quad, x, y, z);
                List<BlockVertex> target = Target(quad.Layer, quad.Facing);
                byte flags = quad.Plant ? PlantFlag : (byte)0;
                for (int v = 0; v < 4; v++) {
                    Vector3 position = quad.Positions[v];
                    target.Add(Vertex(x + position.X + ox, y + position.Y + oy, z + position.Z + oz, quad.Uvs[v].X, quad.Uvs[v].Y,
                        quad.Texture, LightCoords.WithEmission(_lighter.Light[v], quad.Emission), _lighter.Occlusion[v], quad.Direction,
                        quad.ShadeDirection, tint, flags));
                }
            }
        }
    }

    private void MeshCross(SectionSnapshot snap, int x, int y, int z, BlockModel model) {
        (float ox, float oy, float oz) = OffsetAt(model, snap.SectionX * 16 + x, snap.SectionZ * 16 + z);
        // The cross model is flat lit, its planes facing no face of the block, and shaded as facing up.
        int light = BlockModelLighter.LightCoordsAt(model, snap, SectionSnapshot.Index(x, y, z));
        const int up = (int)Face.Up;
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
            target.Add(Vertex(bx + x0, by, bz + z0, 0, 1, layer, light, 255, 2, up, tint, PlantFlag));
            target.Add(Vertex(bx + x1, by, bz + z1, 1, 1, layer, light, 255, 2, up, tint, PlantFlag));
            target.Add(Vertex(bx + x1, by + top, bz + z1, 1, 0, layer, light, 255, 2, up, tint, PlantFlag));
            target.Add(Vertex(bx + x0, by + top, bz + z0, 0, 0, layer, light, 255, 2, up, tint, PlantFlag));
        }
    }

    private bool Culled(SectionSnapshot snap, BlockModel model, int x, int y, int z, int face) {
        (int dx, int dy, int dz) = Steps[face];
        return !ShouldRenderFace(model, _models[snap.States[SectionSnapshot.Index(x + dx, y + dy, z + dz)]], face);
    }

    /// <summary>
    /// <c>Block.shouldRenderFace</c>: hidden where the neighbour's face toward this block is the full block
    /// shape, where the block's <c>skipRendering</c> says so, or where the neighbour's face covers all of
    /// this block's own face on that side. Leaves skip nothing, as vanilla's do with the cutout leaves
    /// option on, which is its default and the only way this client draws them.
    /// </summary>
    public static bool ShouldRenderFace(BlockModel state, BlockModel neighbour, int direction) {
        int opposite = direction ^ 1;
        if ((neighbour.BlockFaces & (1 << opposite)) != 0) {
            return false;
        }
        if (SkipsRendering(state, neighbour, direction)) {
            return false;
        }
        if ((neighbour.EmptyFaces & (1 << opposite)) != 0 || (state.EmptyFaces & (1 << direction)) != 0) {
            return true;
        }
        return !FaceCoveredBy(state.OcclusionBoxes, direction, neighbour.OcclusionBoxes, opposite);
    }

    private static bool SkipsRendering(BlockModel state, BlockModel neighbour, int direction) {
        bool vertical = direction < 2;
        switch (state.Skip) {
            case SkipRendering.SameBlock:
                return neighbour.BlockKey == state.BlockKey;
            case SkipRendering.MangroveRoots:
                return neighbour.BlockKey == state.BlockKey && vertical;
            case SkipRendering.Bars:
                // Every state in the bars tag has the connection properties, which is what the vanilla test of the opposite one comes to.
                if (neighbour.BlockKey == state.BlockKey || neighbour.InBarsTag && state.InBarsTag) {
                    return vertical || (state.Connections & (1 << direction)) != 0 && (neighbour.Connections & (1 << (direction ^ 1))) != 0;
                }
                return false;
            default:
                return false;
        }
    }

    /// <summary>Whether every part of <paramref name="shape"/>'s face is under <paramref name="occluder"/>'s face against it.</summary>
    private static bool FaceCoveredBy(ModelBox[] shape, int shapeFace, ModelBox[] occluder, int occluderFace) {
        Span<float> edgesA = stackalloc float[2 * (shape.Length + occluder.Length)];
        Span<float> edgesB = stackalloc float[2 * (shape.Length + occluder.Length)];
        int count = 0;
        foreach ((ModelBox[] boxes, int face) in (ReadOnlySpan<(ModelBox[], int)>)[(shape, shapeFace), (occluder, occluderFace)]) {
            foreach (ModelBox box in boxes) {
                if (OnFace(box, face)) {
                    (float a0, float a1, float b0, float b1) = FaceRect(box, face);
                    edgesA[count] = a0;
                    edgesB[count++] = b0;
                    edgesA[count] = a1;
                    edgesB[count++] = b1;
                }
            }
        }
        edgesA = edgesA[..count];
        edgesB = edgesB[..count];
        edgesA.Sort();
        edgesB.Sort();
        for (int i = 0; i + 1 < count; i++) {
            if (edgesA[i + 1] <= edgesA[i]) {
                continue;
            }
            float midA = (edgesA[i] + edgesA[i + 1]) * 0.5F;
            for (int j = 0; j + 1 < count; j++) {
                if (edgesB[j + 1] <= edgesB[j]) {
                    continue;
                }
                float midB = (edgesB[j] + edgesB[j + 1]) * 0.5F;
                if (InFace(shape, shapeFace, midA, midB) && !InFace(occluder, occluderFace, midA, midB)) {
                    return false;
                }
            }
        }
        return true;
    }

    private static bool InFace(ModelBox[] boxes, int face, float a, float b) {
        foreach (ModelBox box in boxes) {
            if (OnFace(box, face)) {
                (float a0, float a1, float b0, float b1) = FaceRect(box, face);
                if (a > a0 && a < a1 && b > b0 && b < b1) {
                    return true;
                }
            }
        }
        return false;
    }

    private static (float X, float Y, float Z) OffsetAt(BlockModel model, int worldX, int worldZ) {
        if (!model.HasOffset) {
            return (0, 0, 0);
        }
        Vec3<double> offset = model.Info.ShapeOffset(new Vec3<int>(worldX, 0, worldZ));
        return ((float)offset.X, (float)offset.Y, (float)offset.Z);
    }
}
