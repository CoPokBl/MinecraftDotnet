using Minecraft.Data.Generated;

namespace Minecraft.Lighting;

/// <summary>
/// <c>LightCoordsUtil</c>: the packed light a vertex carries to the lightmap, block light in bits 4
/// to 7 and sky light in bits 20 to 23. Smooth lighting keeps the whole low byte of each half, so a
/// blended value is the level times sixteen with its fraction, 0 to 240.
/// </summary>
public static class LightCoords {
    public const int FullBright = 15728880;
    public const int FullSky = 15728640;
    private const int MaxSmoothLightLevel = 240;

    public static int Pack(int block, int sky) => block << 4 | sky << 20;

    public static int Block(int packed) => packed >> 4 & 15;

    public static int Sky(int packed) => packed >> 20 & 15;

    public static int WithBlock(int coords, int block) => coords & 0xFF0000 | block << 4;

    public static int SmoothPack(int block, int sky) => block & 0xFF | (sky & 0xFF) << 16;

    public static int SmoothBlock(int packed) => packed & 0xFF;

    public static int SmoothSky(int packed) => packed >> 16 & 0xFF;

    public static int AddSmoothBlockEmission(int lightCoords, float blockLightEmission) {
        blockLightEmission = Math.Clamp(blockLightEmission, 0.0F, 1.0F);
        int emittedBlock = (int)(Math.Clamp(blockLightEmission, 0.0F, 1.0F) * 240.0F);
        int block = Math.Min(SmoothBlock(lightCoords) + emittedBlock, MaxSmoothLightLevel);
        return SmoothPack(block, SmoothSky(lightCoords));
    }

    public static int Max(int coords1, int coords2) =>
        Pack(Math.Max(Block(coords1), Block(coords2)), Math.Max(Sky(coords1), Sky(coords2)));

    /// <summary>
    /// What a quad's own <c>light_emission</c> does to its vertices. It raises sky as well as block,
    /// and it reads whole levels, so a smooth value it touches loses its fraction.
    /// </summary>
    public static int WithEmission(int lightCoords, int emission) {
        if (emission == 0) {
            return lightCoords;
        }
        int sky = Math.Max(Sky(lightCoords), emission);
        int block = Math.Max(Block(lightCoords), emission);
        return Pack(block, sky);
    }

    /// <summary>
    /// <c>smoothBlend</c>: the average of a corner's four cells. Around a centre brighter than two, a
    /// neighbour holding no light at all takes the centre's whole value and one holding only block
    /// light takes the centre's sky, which keeps a wall from pulling the corner of a lit face dark.
    /// </summary>
    public static int SmoothBlend(int neighbor1, int neighbor2, int neighbor3, int center) {
        if (Sky(center) > 2 || Block(center) > 2) {
            if (neighbor1 == 0) {
                neighbor1 = center;
            }
            else if (Sky(neighbor1) == 0) {
                neighbor1 |= center & 0xFF0000;
            }

            if (neighbor2 == 0) {
                neighbor2 = center;
            }
            else if (Sky(neighbor2) == 0) {
                neighbor2 |= center & 0xFF0000;
            }

            if (neighbor3 == 0) {
                neighbor3 = center;
            }
            else if (Sky(neighbor3) == 0) {
                neighbor3 |= center & 0xFF0000;
            }
        }

        return ((neighbor1 + neighbor2 + neighbor3 + center) >> 2) & 0xFF00FF;
    }

    /// <summary><c>smoothWeightedBlend</c>, summed in float in this order and truncated, as vanilla does.</summary>
    public static int SmoothWeightedBlend(int coords1, int coords2, int coords3, int coords4, float weight1, float weight2, float weight3, float weight4) {
        int sky = (int)(SmoothSky(coords1) * weight1 + SmoothSky(coords2) * weight2 + SmoothSky(coords3) * weight3 + SmoothSky(coords4) * weight4);
        int block = (int)(SmoothBlock(coords1) * weight1 + SmoothBlock(coords2) * weight2 + SmoothBlock(coords3) * weight3 + SmoothBlock(coords4) * weight4);
        return SmoothPack(block, sky);
    }

    /// <summary>
    /// <c>getLightCoords</c> for a state at a position whose stored light is <paramref name="packedBrightness"/>:
    /// full bright for a state that renders emissive, else the stored light with block raised to the
    /// state's own emission.
    /// </summary>
    public static int Of(bool emissiveRendering, int lightEmission, int packedBrightness) {
        if (emissiveRendering) {
            return FullBright;
        }
        int block = Block(packedBrightness);
        return block < lightEmission ? WithBlock(packedBrightness, lightEmission) : packedBrightness;
    }

    /// <summary><see cref="Of(bool, int, int)"/> for a state id, from the generated tables.</summary>
    public static int Of(uint stateId, int packedBrightness) =>
        Of((BlockRenderTable.FlagsOf(stateId) & BlockRenderTable.EmissiveRendering) != 0, BlockLightTable.EmissionOf(stateId), packedBrightness);
}
