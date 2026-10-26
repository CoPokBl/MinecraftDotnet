namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// Vanilla's <c>Mth</c> as model code calls it: the table sine and cosine are the shared ones, so a
/// transcribed <c>setupAnim</c> swings limbs exactly as far as the game's do.
/// </summary>
public static class Mth {
    public const float Pi = MathF.PI;
    public const float HalfPi = MathF.PI / 2;
    public const float TwoPi = MathF.PI * 2;
    public const float DegToRad = MathF.PI / 180.0F;
    public const float RadToDeg = 180.0F / MathF.PI;

    public static float Sin(float radians) => Minecraft.Schemas.Mth.Sin(radians);
    public static float Cos(float radians) => Minecraft.Schemas.Mth.Cos(radians);
    public static float Sqrt(float value) => MathF.Sqrt(value);
    public static float Abs(float value) => Math.Abs(value);
    public static float Square(float value) => value * value;
    public static float Cube(float value) => value * value * value;
    public static int Floor(float value) => (int)MathF.Floor(value);
    public static float Frac(float value) => value - MathF.Floor(value);
    public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;
    public static float Lerp(float delta, float start, float end) => start + delta * (end - start);
    public static double Lerp(double delta, double start, double end) => start + delta * (end - start);
    public static float ClampedLerp(float factor, float min, float max) => factor < 0 ? min : factor > 1 ? max : Lerp(factor, min, max);
    public static float RotLerp(float delta, float start, float end) => start + delta * WrapDegrees(end - start);
    public static float RotLerpRad(float delta, float start, float end) {
        float difference = end - start;
        while (difference < -MathF.PI) difference += TwoPi;
        while (difference >= MathF.PI) difference -= TwoPi;
        return start + delta * difference;
    }
    public static float WrapDegrees(float degrees) => Minecraft.Schemas.Mth.WrapDegrees(degrees);
    public static float Atan2(double y, double x) => (float)Math.Atan2(y, x);

    /// <summary><c>Mth.triangleWave</c>.</summary>
    public static float TriangleWave(float index, float period) => (Math.Abs(index % period - period * 0.5F) - period * 0.25F) / (period * 0.25F);

    /// <summary><c>Mth.catmullrom</c>.</summary>
    public static float CatmullRom(float alpha, float p0, float p1, float p2, float p3) =>
        0.5F * (2.0F * p1 + (p2 - p0) * alpha + (2.0F * p0 - 5.0F * p1 + 4.0F * p2 - p3) * alpha * alpha + (3.0F * p1 - p0 - 3.0F * p2 + p3) * alpha * alpha * alpha);

    /// <summary><c>Mth.binarySearch</c>: the first index in [from, to) the predicate holds for, or <paramref name="to"/>.</summary>
    public static int BinarySearch(int from, int to, Func<int, bool> condition) {
        int length = to - from;
        while (length > 0) {
            int half = length / 2;
            int middle = from + half;
            if (condition(middle)) {
                length = half;
            }
            else {
                from = middle + 1;
                length -= half + 1;
            }
        }
        return from;
    }
}
