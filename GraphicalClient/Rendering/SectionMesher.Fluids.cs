using GraphicalClient.Assets;
using Minecraft.Lighting;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>FluidRenderer.tesselate</c>. Two things are not vanilla's: the client holds no flowing or overlay
/// sprite, so every face shows the still texture, a side stretched over its height rather than cut
/// from the flowing one; and with no flow worked out, the surface is never turned to follow it.
/// </summary>
public sealed partial class SectionMesher {
    private const float MaxFluidHeight = 0.8888889F;

    private BlockModel ModelAt(SectionSnapshot snap, int x, int y, int z) => _models[snap.States[SectionSnapshot.Index(x, y, z)]];

    private static bool IsSameFluid(BlockModel model, bool lava) => lava ? model.IsLava : model.HasWater;

    /// <summary><c>FluidRenderer.getHeight</c>: -1 for a solid block of something else, 0 for any other.</summary>
    private float FluidHeight(SectionSnapshot snap, int x, int y, int z, bool lava) {
        BlockModel model = ModelAt(snap, x, y, z);
        if (!IsSameFluid(model, lava)) {
            return !model.Solid ? 0.0F : -1.0F;
        }
        if (IsSameFluid(ModelAt(snap, x, y + 1, z), lava)) {
            return 1.0F;
        }
        int level = model.FluidLevel;
        int amount = level == 0 || level >= 8 ? 8 : 8 - level;
        return amount / 9.0F;
    }

    private float CalculateAverageHeight(SectionSnapshot snap, bool lava, float heightSelf, float height2, float height1, int cornerX, int y, int cornerZ) {
        if (height1 >= 1.0F || height2 >= 1.0F) {
            return 1.0F;
        }
        float weighted = 0, weight = 0;
        if (height1 > 0.0F || height2 > 0.0F) {
            float heightCorner = FluidHeight(snap, cornerX, y, cornerZ, lava);
            if (heightCorner >= 1.0F) {
                return 1.0F;
            }
            AddWeightedHeight(ref weighted, ref weight, heightCorner);
        }
        AddWeightedHeight(ref weighted, ref weight, heightSelf);
        AddWeightedHeight(ref weighted, ref weight, height1);
        AddWeightedHeight(ref weighted, ref weight, height2);
        return weighted / weight;
    }

    private static void AddWeightedHeight(ref float weighted, ref float weight, float height) {
        if (height >= 0.8F) {
            weighted += height * 10.0F;
            weight += 10.0F;
        }
        else if (height >= 0.0F) {
            weighted += height;
            weight++;
        }
    }

    /// <summary>
    /// <c>isFaceOccludedByState</c>: whether <paramref name="state"/>'s face toward a fluid looking
    /// <paramref name="direction"/> at it covers that face of a fluid box <paramref name="height"/> tall.
    /// </summary>
    private static bool IsFaceOccludedByState(int direction, float height, BlockModel state) {
        int face = direction ^ 1;
        if ((state.EmptyFaces & (1 << face)) != 0) {
            return false;
        }
        if ((state.BlockFaces & (1 << face)) != 0) {
            return direction != (int)Face.Up || height == 1.0F;
        }
        // Shapes.blockOccludes wants the fluid box to reach the face it is asked about.
        if (direction == (int)Face.Up && height < 1.0F) {
            return false;
        }
        return FaceCovered(state.OcclusionBoxes, face, direction < 2 ? 1.0F : height);
    }

    /// <summary>
    /// Whether the boxes lying on <paramref name="face"/> of their block cover the square of that face,
    /// from the bottom up to <paramref name="top"/> where the face is a side.
    /// </summary>
    private static bool FaceCovered(ModelBox[] boxes, int face, float top) {
        Span<float> edgesA = stackalloc float[2 * boxes.Length + 2];
        Span<float> edgesB = stackalloc float[2 * boxes.Length + 2];
        int countA = 0, countB = 0;
        edgesA[countA++] = 0;
        edgesA[countA++] = 1;
        edgesB[countB++] = 0;
        edgesB[countB++] = top;
        foreach (ModelBox box in boxes) {
            if (OnFace(box, face)) {
                (float a0, float a1, float b0, float b1) = FaceRect(box, face);
                edgesA[countA++] = a0;
                edgesA[countA++] = a1;
                edgesB[countB++] = b0;
                edgesB[countB++] = b1;
            }
        }
        edgesA = edgesA[..countA];
        edgesB = edgesB[..countB];
        edgesA.Sort();
        edgesB.Sort();
        for (int i = 0; i + 1 < edgesA.Length; i++) {
            float midA = (edgesA[i] + edgesA[i + 1]) * 0.5F;
            if (edgesA[i + 1] <= edgesA[i] || midA <= 0 || midA >= 1) {
                continue;
            }
            for (int j = 0; j + 1 < edgesB.Length; j++) {
                float midB = (edgesB[j] + edgesB[j + 1]) * 0.5F;
                if (edgesB[j + 1] <= edgesB[j] || midB <= 0 || midB >= top) {
                    continue;
                }
                bool covered = false;
                foreach (ModelBox box in boxes) {
                    if (OnFace(box, face)) {
                        (float a0, float a1, float b0, float b1) = FaceRect(box, face);
                        covered |= midA > a0 && midA < a1 && midB > b0 && midB < b1;
                    }
                }
                if (!covered) {
                    return false;
                }
            }
        }
        return true;
    }

    private static bool OnFace(ModelBox box, int face) => face switch {
        0 => box.MinY <= 1.0E-7F,
        1 => box.MaxY >= 1 - 1.0E-7F,
        2 => box.MinZ <= 1.0E-7F,
        3 => box.MaxZ >= 1 - 1.0E-7F,
        4 => box.MinX <= 1.0E-7F,
        _ => box.MaxX >= 1 - 1.0E-7F
    };

    /// <summary>A box's extent across a face: x then z for a top or bottom, the horizontal axis then y for a side.</summary>
    private static (float A0, float A1, float B0, float B1) FaceRect(ModelBox box, int face) => face switch {
        0 or 1 => (box.MinX, box.MaxX, box.MinZ, box.MaxZ),
        2 or 3 => (box.MinX, box.MaxX, box.MinY, box.MaxY),
        _ => (box.MinZ, box.MaxZ, box.MinY, box.MaxY)
    };

    /// <summary><c>shouldRenderFace</c>: not against the same fluid, and not where the block holding the fluid closes that face itself.</summary>
    private static bool ShouldRenderFluidFace(bool lava, BlockModel state, int direction, BlockModel neighbour) =>
        !IsSameFluid(neighbour, lava) && !IsFaceOccludedByState(direction ^ 1, 1.0F, state);

    /// <summary><c>FluidRenderer.getLightCoords</c>: the brighter of the cell and the one above it, each as its own state lights itself.</summary>
    private int FluidLight(SectionSnapshot snap, int index) {
        int above = index + SectionSnapshot.FaceStrides[(int)Face.Up];
        return LightCoords.Max(BlockModelLighter.LightCoordsAt(_models[snap.States[index]], snap, index),
            BlockModelLighter.LightCoordsAt(_models[snap.States[above]], snap, above));
    }

    /// <summary><c>FluidState.shouldRenderBackwardUpFace</c>, asked of the cell above the surface.</summary>
    private bool ShouldRenderBackwardUpFace(SectionSnapshot snap, int x, int y, int z, bool lava) {
        for (int ox = -1; ox <= 1; ox++) {
            for (int oz = -1; oz <= 1; oz++) {
                BlockModel model = ModelAt(snap, x + ox, y, z + oz);
                if (!IsSameFluid(model, lava) && !model.SolidRender) {
                    return true;
                }
            }
        }
        return false;
    }

    private void MeshFluid(SectionSnapshot snap, int x, int y, int z, BlockModel state) {
        bool lava = state.IsLava;
        BlockModel down = ModelAt(snap, x, y - 1, z), up = ModelAt(snap, x, y + 1, z);
        BlockModel north = ModelAt(snap, x, y, z - 1), south = ModelAt(snap, x, y, z + 1);
        BlockModel west = ModelAt(snap, x - 1, y, z), east = ModelAt(snap, x + 1, y, z);
        bool renderUp = !IsSameFluid(up, lava);
        bool renderDown = ShouldRenderFluidFace(lava, state, (int)Face.Down, down) && !IsFaceOccludedByState((int)Face.Down, MaxFluidHeight, down);
        bool renderNorth = ShouldRenderFluidFace(lava, state, (int)Face.North, north);
        bool renderSouth = ShouldRenderFluidFace(lava, state, (int)Face.South, south);
        bool renderWest = ShouldRenderFluidFace(lava, state, (int)Face.West, west);
        bool renderEast = ShouldRenderFluidFace(lava, state, (int)Face.East, east);
        if (!(renderUp || renderDown || renderEast || renderWest || renderNorth || renderSouth)) {
            return;
        }

        ushort layer = (lava ? state : _models[WaterState]).TextureLayers[0];
        RenderLayer fluidLayer = lava ? RenderLayer.Solid : RenderLayer.Translucent;
        uint tint = lava ? 0xFFFFFF : TintOf(snap, TintKind.Water, x, y, z);

        float heightSelf = FluidHeight(snap, x, y, z, lava);
        float heightNorthEast, heightNorthWest, heightSouthEast, heightSouthWest;
        if (heightSelf >= 1.0F) {
            heightNorthEast = heightNorthWest = heightSouthEast = heightSouthWest = 1.0F;
        }
        else {
            float heightNorth = FluidHeight(snap, x, y, z - 1, lava);
            float heightSouth = FluidHeight(snap, x, y, z + 1, lava);
            float heightEast = FluidHeight(snap, x + 1, y, z, lava);
            float heightWest = FluidHeight(snap, x - 1, y, z, lava);
            heightNorthEast = CalculateAverageHeight(snap, lava, heightSelf, heightNorth, heightEast, x + 1, y, z - 1);
            heightNorthWest = CalculateAverageHeight(snap, lava, heightSelf, heightNorth, heightWest, x - 1, y, z - 1);
            heightSouthEast = CalculateAverageHeight(snap, lava, heightSelf, heightSouth, heightEast, x + 1, y, z + 1);
            heightSouthWest = CalculateAverageHeight(snap, lava, heightSelf, heightSouth, heightWest, x - 1, y, z + 1);
        }

        int own = SectionSnapshot.Index(x, y, z);
        float bottomOffs = renderDown ? 0.001F : 0.0F;
        if (renderUp && !IsFaceOccludedByState((int)Face.Up,
                Math.Min(Math.Min(heightNorthWest, heightSouthWest), Math.Min(heightSouthEast, heightNorthEast)), up)) {
            heightNorthWest -= 0.001F;
            heightSouthWest -= 0.001F;
            heightSouthEast -= 0.001F;
            heightNorthEast -= 0.001F;
            // The surface goes with the faces that look up, even sloped, so it takes its place in their
            // back to front order rather than being drawn over the ice above it.
            AddFace((int)Face.Up, (int)Face.Up,
                (x, y + heightNorthWest, z, 0, 0), (x, y + heightSouthWest, z + 1, 0, 1),
                (x + 1, y + heightSouthEast, z + 1, 1, 1), (x + 1, y + heightNorthEast, z, 1, 0),
                FluidLight(snap, own), ShouldRenderBackwardUpFace(snap, x, y + 1, z, lava), FluidSurfaceFlag);
        }

        if (renderDown) {
            AddFace((int)Face.Down, (int)Face.Down,
                (x, y + bottomOffs, z, 0, 0), (x + 1, y + bottomOffs, z, 1, 0),
                (x + 1, y + bottomOffs, z + 1, 1, 1), (x, y + bottomOffs, z + 1, 0, 1),
                FluidLight(snap, own + SectionSnapshot.FaceStrides[(int)Face.Down]), false, 0);
        }

        int sideLight = FluidLight(snap, own);
        float fx = x, fz = z;
        // Plane.HORIZONTAL's order: north, east, south, west.
        for (int side = 0; side < 4; side++) {
            (int face, float hh0, float hh1, float x0, float x1, float z0, float z1, bool renderCondition, BlockModel faceState) = side switch {
                0 => ((int)Face.North, heightNorthWest, heightNorthEast, fx, fx + 1.0F, fz + 0.001F, fz + 0.001F, renderNorth, north),
                1 => ((int)Face.East, heightNorthEast, heightSouthEast, fx + 1.0F - 0.001F, fx + 1.0F - 0.001F, fz, fz + 1.0F, renderEast, east),
                2 => ((int)Face.South, heightSouthEast, heightSouthWest, fx + 1.0F, fx, fz + 1.0F - 0.001F, fz + 1.0F - 0.001F, renderSouth, south),
                _ => ((int)Face.West, heightSouthWest, heightNorthWest, fx + 0.001F, fx + 0.001F, fz + 1.0F, fz, renderWest, west)
            };
            if (!renderCondition || IsFaceOccludedByState(face, Math.Max(hh0, hh1), faceState)) {
                continue;
            }
            // Where water shows its overlay sprite, against glass and leaves, the side has no back.
            bool overlay = !lava && faceState.Overlay;
            int shade = face is (int)Face.North or (int)Face.South ? FluidSideZShade : FluidSideXShade;
            AddFace(face, shade,
                (x0, y + hh0, z0, 0, 1 - hh0), (x1, y + hh1, z1, 1, 1 - hh1),
                (x1, y + bottomOffs, z1, 1, 1), (x0, y + bottomOffs, z0, 0, 1),
                sideLight, !overlay, 0);
        }

        void AddFace(int face, int shade,
            (float X, float Y, float Z, float U, float V) v0, (float X, float Y, float Z, float U, float V) v1,
            (float X, float Y, float Z, float U, float V) v2, (float X, float Y, float Z, float U, float V) v3,
            int light, bool addBackFace, byte flags) {
            List<BlockVertex> front = Target(fluidLayer, face);
            Add(front, v0, face);
            Add(front, v1, face);
            Add(front, v2, face);
            Add(front, v3, face);
            if (addBackFace) {
                List<BlockVertex> back = Target(fluidLayer, face ^ 1);
                Add(back, v0, face ^ 1);
                Add(back, v3, face ^ 1);
                Add(back, v2, face ^ 1);
                Add(back, v1, face ^ 1);
            }

            void Add(List<BlockVertex> target, (float X, float Y, float Z, float U, float V) v, int facing) =>
                target.Add(Vertex(v.X, v.Y, v.Z, v.U, v.V, layer, light, 255, facing, shade, tint, flags));
        }
    }
}
