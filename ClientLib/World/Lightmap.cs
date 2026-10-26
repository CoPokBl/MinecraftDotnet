using System.Numerics;
using Minecraft.Schemas;

namespace ClientLib.World;

/// <summary><c>LightmapRenderState</c>: what <c>lightmap.fsh</c> is run with.</summary>
public readonly record struct LightmapState(
    float SkyFactor,
    float BlockFactor,
    float NightVisionFactor,
    float DarknessScale,
    float BossOverlayWorldDarkeningFactor,
    float BrightnessFactor,
    Vector3 BlockLightTint,
    Vector3 SkyLightColor,
    Vector3 AmbientColor,
    Vector3 NightVisionColor);

/// <summary>The lightmap: the 16 by 16 table every surface looks its block and sky light up in.</summary>
public static class Lightmap {
    /// <summary>
    /// <c>lightmap.fsh</c> run over the 16 by 16 texture, x block light and y sky light, written as an <c>RGBA8_UNORM</c>
    /// target stores it: clamped and rounded to the nearest of 256 steps.
    /// </summary>
    /// <remarks>
    /// The GPU evaluates the same arithmetic in single precision and may fuse a multiply into an add where this does
    /// not, so an entry within a rounding of a step boundary can come out one step apart; otherwise the table is the
    /// shader's.
    /// </remarks>
    public static void Compute(in LightmapState state, Span<byte> rgba) {
        for (int sky = 0; sky < 16; sky++) {
            for (int block = 0; block < 16; block++) {
                Vector3 color = LightmapTexel(state, block / 15.0F, sky / 15.0F);
                int i = (sky * 16 + block) * 4;
                rgba[i] = Unorm(color.X);
                rgba[i + 1] = Unorm(color.Y);
                rgba[i + 2] = Unorm(color.Z);
                rgba[i + 3] = 255;
            }
        }
    }

    /// <summary><c>lightmap.fsh</c>'s <c>main</c>, for one block and sky level from 0 to 1.</summary>
    public static Vector3 LightmapTexel(in LightmapState state, float blockLevel, float skyLevel) {
        float blockBrightness = GetBrightness(blockLevel) * state.BlockFactor;
        float skyBrightness = GetBrightness(skyLevel) * state.SkyFactor;
        Vector3 nightVisionColor = state.NightVisionColor * state.NightVisionFactor;
        Vector3 color = Vector3.Max(state.AmbientColor, nightVisionColor);
        color += state.SkyLightColor * skyBrightness;
        Vector3 blockLightColor = Mix(state.BlockLightTint, Vector3.One, 0.9F * ParabolicMixFactor(blockLevel));
        color += blockLightColor * blockBrightness;
        color = Mix(color, color * new Vector3(0.7F, 0.6F, 0.6F), state.BossOverlayWorldDarkeningFactor);
        color -= new Vector3(state.DarknessScale);
        color = Vector3.Clamp(color, Vector3.Zero, Vector3.One);
        return Mix(color, NotGamma(color), state.BrightnessFactor);
    }

    private static float GetBrightness(float level) => level / (4.0F - 3.0F * level);

    private static float ParabolicMixFactor(float level) => (2.0F * level - 1.0F) * (2.0F * level - 1.0F);

    /// <summary>
    /// <c>notGamma</c>: the brightest channel bent up by a quartic, the others scaled with it. A black texel divides
    /// zero by zero, which the target stores as zero, as black is.
    /// </summary>
    private static Vector3 NotGamma(Vector3 color) {
        float maxComponent = Math.Max(Math.Max(color.X, color.Y), color.Z);
        float maxInverted = 1.0F - maxComponent;
        float maxScaled = 1.0F - maxInverted * maxInverted * maxInverted * maxInverted;
        return color * (maxScaled / maxComponent);
    }

    /// <summary>GLSL's <c>mix</c>.</summary>
    private static Vector3 Mix(Vector3 x, Vector3 y, float a) => x * (1.0F - a) + y * a;

    private static byte Unorm(float value) => float.IsNaN(value) ? (byte)0 : (byte)MathF.Round(Math.Clamp(value, 0.0F, 1.0F) * 255.0F);

    /// <summary><c>Lightmap.getBrightness</c>: the curve that makes each level look a step apart, lifted by the dimension's ambient light.</summary>
    public static float Brightness(float ambient, int level) {
        float v = level / 15.0F;
        float curvedV = v / (4.0F - 3.0F * v);
        return Mth.Lerp(ambient, curvedV, 1.0F);
    }
}
