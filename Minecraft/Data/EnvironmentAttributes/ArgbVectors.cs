using System.Numerics;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// The vector half of vanilla's <c>ARGB</c>: colours as floats from 0 to 1, red, green and blue in x, y and z and
/// alpha in w, as JOML's <c>Vector3f</c> and <c>Vector4f</c> carry them.
/// </summary>
/// <remarks>
/// <see cref="Vector3.Lerp(Vector3, Vector3, float)"/> is <c>a * (1 - t) + b * t</c>, which rounds differently from
/// JOML's <c>(b - a) * t + a</c>, so every lerp here is written out by component.
/// </remarks>
public static class ArgbVectors {
    public static Vector3 FromRgb24(int color) => new(Red(color) / 255.0F, Green(color) / 255.0F, Blue(color) / 255.0F);

    public static Vector4 FromArgb32(int color) =>
        new(Red(color) / 255.0F, Green(color) / 255.0F, Blue(color) / 255.0F, (int)((uint)color >> 24) / 255.0F);

    /// <summary><c>ARGB.colorFromVector4f</c>: each channel floored to eight bits.</summary>
    public static int ToArgb32(Vector4 color) => Color(As8BitChannel(color.W), As8BitChannel(color.X), As8BitChannel(color.Y), As8BitChannel(color.Z));

    /// <summary><c>ARGB.colorFromFloat</c>.</summary>
    public static int ColorFromFloat(float alpha, float red, float green, float blue) =>
        Color(As8BitChannel(alpha), As8BitChannel(red), As8BitChannel(green), As8BitChannel(blue));

    /// <summary><c>ARGB.color(float alpha, int rgb)</c>.</summary>
    public static int WithAlpha(float alpha, int rgb) => As8BitChannel(alpha) << 24 | rgb & 0xFFFFFF;

    public static int As8BitChannel(float value) => (int)MathF.Floor(value * 255.0F);

    private static int Color(int alpha, int red, int green, int blue) => (alpha & 0xFF) << 24 | (red & 0xFF) << 16 | (green & 0xFF) << 8 | blue & 0xFF;

    private static int Red(int color) => color >> 16 & 0xFF;

    private static int Green(int color) => color >> 8 & 0xFF;

    private static int Blue(int color) => color & 0xFF;

    public static Vector3 SrgbLerp(float alpha, Vector3 from, Vector3 to) =>
        new((to.X - from.X) * alpha + from.X, (to.Y - from.Y) * alpha + from.Y, (to.Z - from.Z) * alpha + from.Z);

    public static Vector4 SrgbLerp(float alpha, Vector4 from, Vector4 to) =>
        new((to.X - from.X) * alpha + from.X, (to.Y - from.Y) * alpha + from.Y, (to.Z - from.Z) * alpha + from.Z, (to.W - from.W) * alpha + from.W);

    public static Vector3 Multiply(Vector3 lhs, Vector3 rhs) => lhs == Vector3.One ? rhs : rhs == Vector3.One ? lhs : lhs * rhs;

    public static Vector4 Multiply(Vector4 lhs, Vector4 rhs) => lhs == Vector4.One ? rhs : rhs == Vector4.One ? lhs : lhs * rhs;

    public static Vector3 AddRgb(Vector3 lhs, Vector3 rhs) =>
        new(Math.Min(lhs.X + rhs.X, 1.0F), Math.Min(lhs.Y + rhs.Y, 1.0F), Math.Min(lhs.Z + rhs.Z, 1.0F));

    public static Vector4 AddRgb(Vector4 lhs, Vector3 rhs) =>
        new(Math.Min(lhs.X + rhs.X, 1.0F), Math.Min(lhs.Y + rhs.Y, 1.0F), Math.Min(lhs.Z + rhs.Z, 1.0F), lhs.W);

    public static Vector3 SubtractRgb(Vector3 lhs, Vector3 rhs) =>
        new(Math.Max(lhs.X - rhs.X, 0.0F), Math.Max(lhs.Y - rhs.Y, 0.0F), Math.Max(lhs.Z - rhs.Z, 0.0F));

    public static Vector4 SubtractRgb(Vector4 lhs, Vector3 rhs) =>
        new(Math.Max(lhs.X - rhs.X, 0.0F), Math.Max(lhs.Y - rhs.Y, 0.0F), Math.Max(lhs.Z - rhs.Z, 0.0F), lhs.W);

    public static Vector3 ScaleRgb(Vector3 color, float scaleR, float scaleG, float scaleB) =>
        new(Math.Clamp(color.X * scaleR, 0.0F, 1.0F), Math.Clamp(color.Y * scaleG, 0.0F, 1.0F), Math.Clamp(color.Z * scaleB, 0.0F, 1.0F));

    public static Vector3 ScaleRgb(Vector3 color, float scale) => ScaleRgb(color, scale, scale, scale);

    public static Vector4 ScaleRgb(Vector4 color, float scale) =>
        new(Math.Clamp(color.X * scale, 0.0F, 1.0F), Math.Clamp(color.Y * scale, 0.0F, 1.0F), Math.Clamp(color.Z * scale, 0.0F, 1.0F), color.W);

    public static Vector3 Greyscale(Vector3 color) => new(color.X * 0.3F + color.Y * 0.59F + color.Z * 0.11F);

    public static Vector4 Greyscale(Vector4 color) {
        float greyscale = color.X * 0.3F + color.Y * 0.59F + color.Z * 0.11F;
        return new Vector4(greyscale, greyscale, greyscale, color.W);
    }

    /// <summary><c>ARGB.alphaBlend(Vector3fc, Vector4fc)</c>: toward the source's colour by its alpha.</summary>
    public static Vector3 AlphaBlend(Vector3 destination, Vector4 source) {
        float sourceAlpha = source.W;
        return sourceAlpha == 0.0F ? destination : SrgbLerp(sourceAlpha, destination, new Vector3(source.X, source.Y, source.Z));
    }

    public static Vector4 AlphaBlend(Vector4 destination, Vector4 source) {
        float destinationAlpha = destination.W;
        float sourceAlpha = source.W;
        if (sourceAlpha == 1.0F) {
            return source;
        }
        if (sourceAlpha == 0.0F) {
            return destination;
        }
        float alpha = sourceAlpha + destinationAlpha * (1.0F - sourceAlpha);
        return new Vector4(
            AlphaBlendChannel(alpha, sourceAlpha, destination.X, source.X),
            AlphaBlendChannel(alpha, sourceAlpha, destination.Y, source.Y),
            AlphaBlendChannel(alpha, sourceAlpha, destination.Z, source.Z),
            alpha);
    }

    private static float AlphaBlendChannel(float resultAlpha, float sourceAlpha, float destination, float source) =>
        (source * sourceAlpha + destination * (resultAlpha - sourceAlpha)) / resultAlpha;
}
