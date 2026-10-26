using System.Numerics;
using Minecraft.Lighting;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>BlockModelLighter</c>: the light coords and the occlusion gray of each corner of a block model
/// quad, read out of a <see cref="SectionSnapshot"/>. Positions are snapshot indices and directions are
/// <see cref="Assets.Face"/>s, which are vanilla's <c>Direction</c> ordinals. The gray is the channel
/// <c>ARGB.gray</c> writes; the directional scale vanilla applies after it is the shader's, from the
/// quad's shade direction. Holds the last quad's results, so one per mesher.
/// </summary>
public sealed class BlockModelLighter(BlockModel[] models) {
    /// <summary>The packed light of each corner, in the quad's vertex order.</summary>
    public readonly int[] Light = new int[4];

    /// <summary>The occlusion gray of each corner, 0 to 255; 255 for a flat lit quad.</summary>
    public readonly byte[] Occlusion = new byte[4];

    private bool _faceCubic;
    private bool _facePartial;
    private readonly float[] _faceShape = new float[12];

    private const int SizeDown = 0, SizeUp = 1, SizeNorth = 2, SizeSouth = 3, SizeWest = 4, SizeEast = 5;
    private const int FlipDown = 6, FlipUp = 7, FlipNorth = 8, FlipSouth = 9, FlipWest = 10, FlipEast = 11;
    private const int Down = 0, Up = 1, North = 2, South = 3, West = 4, East = 5;

    /// <summary><c>AdjacencyInfo.corners</c>, by direction.</summary>
    private static readonly int[][] AdjacentCorners = [
        [West, East, North, South],
        [East, West, North, South],
        [Up, Down, East, West],
        [West, East, Down, Up],
        [Up, Down, North, South],
        [Down, Up, North, South]
    ];

    /// <summary><c>AdjacencyInfo.vert0Weights</c> to <c>vert3Weights</c>, by direction, as <c>SizeInfo</c> indices.</summary>
    private static readonly int[][][] VertexWeights = [
        [
            [FlipWest, SizeSouth, FlipWest, FlipSouth, SizeWest, FlipSouth, SizeWest, SizeSouth],
            [FlipWest, SizeNorth, FlipWest, FlipNorth, SizeWest, FlipNorth, SizeWest, SizeNorth],
            [FlipEast, SizeNorth, FlipEast, FlipNorth, SizeEast, FlipNorth, SizeEast, SizeNorth],
            [FlipEast, SizeSouth, FlipEast, FlipSouth, SizeEast, FlipSouth, SizeEast, SizeSouth]
        ],
        [
            [SizeEast, SizeSouth, SizeEast, FlipSouth, FlipEast, FlipSouth, FlipEast, SizeSouth],
            [SizeEast, SizeNorth, SizeEast, FlipNorth, FlipEast, FlipNorth, FlipEast, SizeNorth],
            [SizeWest, SizeNorth, SizeWest, FlipNorth, FlipWest, FlipNorth, FlipWest, SizeNorth],
            [SizeWest, SizeSouth, SizeWest, FlipSouth, FlipWest, FlipSouth, FlipWest, SizeSouth]
        ],
        [
            [SizeUp, FlipWest, SizeUp, SizeWest, FlipUp, SizeWest, FlipUp, FlipWest],
            [SizeUp, FlipEast, SizeUp, SizeEast, FlipUp, SizeEast, FlipUp, FlipEast],
            [SizeDown, FlipEast, SizeDown, SizeEast, FlipDown, SizeEast, FlipDown, FlipEast],
            [SizeDown, FlipWest, SizeDown, SizeWest, FlipDown, SizeWest, FlipDown, FlipWest]
        ],
        [
            [SizeUp, FlipWest, FlipUp, FlipWest, FlipUp, SizeWest, SizeUp, SizeWest],
            [SizeDown, FlipWest, FlipDown, FlipWest, FlipDown, SizeWest, SizeDown, SizeWest],
            [SizeDown, FlipEast, FlipDown, FlipEast, FlipDown, SizeEast, SizeDown, SizeEast],
            [SizeUp, FlipEast, FlipUp, FlipEast, FlipUp, SizeEast, SizeUp, SizeEast]
        ],
        [
            [SizeUp, SizeSouth, SizeUp, FlipSouth, FlipUp, FlipSouth, FlipUp, SizeSouth],
            [SizeUp, SizeNorth, SizeUp, FlipNorth, FlipUp, FlipNorth, FlipUp, SizeNorth],
            [SizeDown, SizeNorth, SizeDown, FlipNorth, FlipDown, FlipNorth, FlipDown, SizeNorth],
            [SizeDown, SizeSouth, SizeDown, FlipSouth, FlipDown, FlipSouth, FlipDown, SizeSouth]
        ],
        [
            [FlipDown, SizeSouth, FlipDown, FlipSouth, SizeDown, FlipSouth, SizeDown, SizeSouth],
            [FlipDown, SizeNorth, FlipDown, FlipNorth, SizeDown, FlipNorth, SizeDown, SizeNorth],
            [FlipUp, SizeNorth, FlipUp, FlipNorth, SizeUp, FlipNorth, SizeUp, SizeNorth],
            [FlipUp, SizeSouth, FlipUp, FlipSouth, SizeUp, FlipSouth, SizeUp, SizeSouth]
        ]
    ];

    /// <summary><c>AmbientVertexRemap</c>: which quad vertex each of the four blended corners lands on, by direction.</summary>
    private static readonly int[][] VertexRemap = [
        [0, 1, 2, 3],
        [2, 3, 0, 1],
        [3, 0, 1, 2],
        [0, 1, 2, 3],
        [3, 0, 1, 2],
        [1, 2, 3, 0]
    ];

    private static int Step(int direction) => SectionSnapshot.FaceStrides[direction];

    /// <summary><c>Cache.getLightCoords</c>: the light stored at a cell, as the given state there would have it.</summary>
    public static int LightCoordsAt(BlockModel state, SectionSnapshot snap, int index) {
        byte stored = snap.Light[index];
        return LightCoords.Of(state.EmissiveRendering, state.LightEmission, LightCoords.Pack(stored & 15, stored >> 4));
    }

    private BlockModel StateAt(SectionSnapshot snap, int index) => models[snap.States[index]];

    private int LightAt(SectionSnapshot snap, int index) => LightCoordsAt(StateAt(snap, index), snap, index);

    private float ShadeAt(SectionSnapshot snap, int index) => StateAt(snap, index).ShadeBrightness;

    /// <summary><c>prepareQuadAmbientOcclusion</c>, for the quad <paramref name="positions"/> of <paramref name="state"/> at <paramref name="center"/>.</summary>
    public void PrepareQuadAmbientOcclusion(SectionSnapshot snap, BlockModel state, int center, ReadOnlySpan<Vector3> positions, int direction) {
        PrepareQuadShape(state, positions, direction, true);
        int basePosition = _faceCubic ? center + Step(direction) : center;
        int[] corners = AdjacentCorners[direction];
        int pos0 = basePosition + Step(corners[0]), pos1 = basePosition + Step(corners[1]);
        int pos2 = basePosition + Step(corners[2]), pos3 = basePosition + Step(corners[3]);
        int light0 = LightAt(snap, pos0);
        float shade0 = ShadeAt(snap, pos0);
        int light1 = LightAt(snap, pos1);
        float shade1 = ShadeAt(snap, pos1);
        int light2 = LightAt(snap, pos2);
        float shade2 = ShadeAt(snap, pos2);
        int light3 = LightAt(snap, pos3);
        float shade3 = ShadeAt(snap, pos3);
        int outward = Step(direction);
        bool lightPermeable0 = StateAt(snap, pos0 + outward).LightPermeable;
        bool lightPermeable1 = StateAt(snap, pos1 + outward).LightPermeable;
        bool lightPermeable2 = StateAt(snap, pos2 + outward).LightPermeable;
        bool lightPermeable3 = StateAt(snap, pos3 + outward).LightPermeable;

        // A diagonal hidden behind two solid edges takes the first edge's values, light0 and shade0
        // in every case, as vanilla's does.
        float shadeCorner02, shadeCorner03, shadeCorner12, shadeCorner13;
        int lightCorner02, lightCorner03, lightCorner12, lightCorner13;
        if (!lightPermeable2 && !lightPermeable0) {
            shadeCorner02 = shade0;
            lightCorner02 = light0;
        }
        else {
            int corner = pos0 + Step(corners[2]);
            shadeCorner02 = ShadeAt(snap, corner);
            lightCorner02 = LightAt(snap, corner);
        }
        if (!lightPermeable3 && !lightPermeable0) {
            shadeCorner03 = shade0;
            lightCorner03 = light0;
        }
        else {
            int corner = pos0 + Step(corners[3]);
            shadeCorner03 = ShadeAt(snap, corner);
            lightCorner03 = LightAt(snap, corner);
        }
        if (!lightPermeable2 && !lightPermeable1) {
            shadeCorner12 = shade0;
            lightCorner12 = light0;
        }
        else {
            int corner = pos1 + Step(corners[2]);
            shadeCorner12 = ShadeAt(snap, corner);
            lightCorner12 = LightAt(snap, corner);
        }
        if (!lightPermeable3 && !lightPermeable1) {
            shadeCorner13 = shade0;
            lightCorner13 = light0;
        }
        else {
            int corner = pos1 + Step(corners[3]);
            shadeCorner13 = ShadeAt(snap, corner);
            lightCorner13 = LightAt(snap, corner);
        }

        int lightCenter = LightCoordsAt(state, snap, center);
        int next = center + outward;
        BlockModel nextState = StateAt(snap, next);
        if (_faceCubic || !nextState.SolidRender) {
            lightCenter = LightCoordsAt(nextState, snap, next);
        }

        float shadeCenter = _faceCubic ? ShadeAt(snap, basePosition) : ShadeAt(snap, center);
        int[] remap = VertexRemap[direction];
        if (_facePartial) {
            float tempShade1 = (shade3 + shade0 + shadeCorner03 + shadeCenter) * 0.25F;
            float tempShade2 = (shade2 + shade0 + shadeCorner02 + shadeCenter) * 0.25F;
            float tempShade3 = (shade2 + shade1 + shadeCorner12 + shadeCenter) * 0.25F;
            float tempShade4 = (shade3 + shade1 + shadeCorner13 + shadeCenter) * 0.25F;
            int tc1 = LightCoords.SmoothBlend(light3, light0, lightCorner03, lightCenter);
            int tc2 = LightCoords.SmoothBlend(light2, light0, lightCorner02, lightCenter);
            int tc3 = LightCoords.SmoothBlend(light2, light1, lightCorner12, lightCenter);
            int tc4 = LightCoords.SmoothBlend(light3, light1, lightCorner13, lightCenter);
            int[][] weights = VertexWeights[direction];
            for (int v = 0; v < 4; v++) {
                int[] w = weights[v];
                float weight01 = _faceShape[w[0]] * _faceShape[w[1]];
                float weight23 = _faceShape[w[2]] * _faceShape[w[3]];
                float weight45 = _faceShape[w[4]] * _faceShape[w[5]];
                float weight67 = _faceShape[w[6]] * _faceShape[w[7]];
                Occlusion[remap[v]] = Gray(Math.Clamp(tempShade1 * weight01 + tempShade2 * weight23 + tempShade3 * weight45 + tempShade4 * weight67, 0.0F, 1.0F));
                Light[remap[v]] = LightCoords.SmoothWeightedBlend(tc1, tc2, tc3, tc4, weight01, weight23, weight45, weight67);
            }
        }
        else {
            Light[remap[0]] = LightCoords.SmoothBlend(light3, light0, lightCorner03, lightCenter);
            Light[remap[1]] = LightCoords.SmoothBlend(light2, light0, lightCorner02, lightCenter);
            Light[remap[2]] = LightCoords.SmoothBlend(light2, light1, lightCorner12, lightCenter);
            Light[remap[3]] = LightCoords.SmoothBlend(light3, light1, lightCorner13, lightCenter);
            Occlusion[remap[0]] = Gray((shade3 + shade0 + shadeCorner03 + shadeCenter) * 0.25F);
            Occlusion[remap[1]] = Gray((shade2 + shade0 + shadeCorner02 + shadeCenter) * 0.25F);
            Occlusion[remap[2]] = Gray((shade2 + shade1 + shadeCorner12 + shadeCenter) * 0.25F);
            Occlusion[remap[3]] = Gray((shade3 + shade1 + shadeCorner13 + shadeCenter) * 0.25F);
        }
    }

    /// <summary>
    /// <c>prepareQuadFlat</c>. <paramref name="lightCoords"/> is what <c>tesselateFlat</c> worked out for a
    /// culled quad's direction, or -1 to look it up from the quad's own shape.
    /// </summary>
    public void PrepareQuadFlat(SectionSnapshot snap, BlockModel state, int center, int lightCoords, ReadOnlySpan<Vector3> positions, int direction) {
        if (lightCoords == -1) {
            PrepareQuadShape(state, positions, direction, false);
            lightCoords = LightCoordsAt(state, snap, _faceCubic ? center + Step(direction) : center);
        }
        for (int v = 0; v < 4; v++) {
            Light[v] = lightCoords;
            Occlusion[v] = 255;
        }
    }

    /// <summary><c>tesselateFlat</c>'s light for the quads culled against <paramref name="direction"/>: the rendered state, at the neighbour.</summary>
    public static int CulledLightCoords(SectionSnapshot snap, BlockModel state, int center, int direction) =>
        LightCoordsAt(state, snap, center + Step(direction));

    private void PrepareQuadShape(BlockModel state, ReadOnlySpan<Vector3> positions, int direction, bool ambientOcclusion) {
        float minX = 32.0F, minY = 32.0F, minZ = 32.0F, maxX = -32.0F, maxY = -32.0F, maxZ = -32.0F;
        for (int i = 0; i < 4; i++) {
            Vector3 position = positions[i];
            minX = Math.Min(minX, position.X);
            minY = Math.Min(minY, position.Y);
            minZ = Math.Min(minZ, position.Z);
            maxX = Math.Max(maxX, position.X);
            maxY = Math.Max(maxY, position.Y);
            maxZ = Math.Max(maxZ, position.Z);
        }

        if (ambientOcclusion) {
            _faceShape[SizeWest] = minX;
            _faceShape[SizeEast] = maxX;
            _faceShape[SizeDown] = minY;
            _faceShape[SizeUp] = maxY;
            _faceShape[SizeNorth] = minZ;
            _faceShape[SizeSouth] = maxZ;
            _faceShape[FlipWest] = 1.0F - minX;
            _faceShape[FlipEast] = 1.0F - maxX;
            _faceShape[FlipDown] = 1.0F - minY;
            _faceShape[FlipUp] = 1.0F - maxY;
            _faceShape[FlipNorth] = 1.0F - minZ;
            _faceShape[FlipSouth] = 1.0F - maxZ;
        }

        _facePartial = direction switch {
            Down or Up => minX >= 1.0E-4F || minZ >= 1.0E-4F || maxX <= 0.9999F || maxZ <= 0.9999F,
            North or South => minX >= 1.0E-4F || minY >= 1.0E-4F || maxX <= 0.9999F || maxY <= 0.9999F,
            _ => minY >= 1.0E-4F || minZ >= 1.0E-4F || maxY <= 0.9999F || maxZ <= 0.9999F
        };

        _faceCubic = direction switch {
            Down => minY == maxY && (minY < 1.0E-4F || state.CollisionShapeFullBlock),
            Up => minY == maxY && (maxY > 0.9999F || state.CollisionShapeFullBlock),
            North => minZ == maxZ && (minZ < 1.0E-4F || state.CollisionShapeFullBlock),
            South => minZ == maxZ && (maxZ > 0.9999F || state.CollisionShapeFullBlock),
            West => minX == maxX && (minX < 1.0E-4F || state.CollisionShapeFullBlock),
            _ => minX == maxX && (maxX > 0.9999F || state.CollisionShapeFullBlock)
        };
    }

    /// <summary><c>ARGB.gray</c>'s channel, <c>as8BitChannel</c>: the float times 255, floored.</summary>
    public static byte Gray(float brightness) => (byte)(int)MathF.Floor(brightness * 255.0F);
}
