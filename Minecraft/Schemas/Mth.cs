namespace Minecraft.Schemas;

/// <summary>
/// Vanilla's <c>net.minecraft.util.Mth</c>, as far as anything here needs it.
/// <p/>
/// <see cref="Sin"/> and <see cref="Cos"/> are <b>not</b> <see cref="Math.Sin"/> and
/// <see cref="Math.Cos"/>: vanilla reads them out of a 65536 entry table of floats, which is wrong by
/// up to about 1e-4 against the real thing. Anywhere the game compares an angle against a threshold
/// (a shield's blocking arc) or turns one into a direction, the table is what decided it, so a port
/// that calls the accurate function disagrees with the client near every boundary.
/// </summary>
public static class Mth {
    /// <summary>Entries per radian: <c>65536 / (2 * pi)</c>, as vanilla's own constant.</summary>
    private const double SinScale = 10430.378350470453;

    private static readonly float[] SinTable = BuildSinTable();

    private static float[] BuildSinTable() {
        float[] table = new float[65536];
        for (int i = 0; i < table.Length; i++) {
            table[i] = (float)Math.Sin(i / SinScale);
        }

        return table;
    }

    /// <summary>
    /// <c>Mth.sin</c>. The index is masked as a long before it is narrowed, so a negative or very large
    /// angle wraps rather than overflowing to zero the way a cast to int would.
    /// </summary>
    public static float Sin(double radians) {
        return SinTable[(int)((long)(radians * SinScale) & 65535L)];
    }

    /// <summary><c>Mth.cos</c>, which is the same table a quarter turn along.</summary>
    public static float Cos(double radians) {
        return SinTable[(int)((long)(radians * SinScale + 16384.0) & 65535L)];
    }

    #region atan2

    // Vanilla's atan2 is its own approximation rather than Math.atan2, built on a 257 entry arcsine
    // table and a reciprocal square root that starts from a magic constant. It is what turned a
    // mob's offset from its target into the yaw the client was then told about, so a port that calls
    // the accurate function makes every mob face fractionally differently from the one upstream.
    // Transcribed from Mth.atan2 and Mth.fastInvSqrt; the tables are built exactly as the static
    // initialiser builds them.

    private static readonly double FracBias = BitConverter.Int64BitsToDouble(4805340802404319232L);

    private static readonly double[] AsinTable = new double[257];
    private static readonly double[] CosTable = new double[257];

    static Mth() {
        for (int i = 0; i < 257; i++) {
            double asin = Math.Asin(i / 256.0);
            CosTable[i] = Math.Cos(asin);
            AsinTable[i] = asin;
        }
    }

    /// <summary>
    /// <c>Mth.fastInvSqrt</c>: the sixty four bit form of the reciprocal square root trick, one
    /// Newton step off the magic constant. Accurate to a few parts in a million, which is the error
    /// <see cref="Atan2"/> is built on top of.
    /// </summary>
    public static double FastInvSqrt(double value) {
        double half = 0.5 * value;
        long bits = 6910469410427058090L - (BitConverter.DoubleToInt64Bits(value) >> 1);
        double guess = BitConverter.Int64BitsToDouble(bits);
        return guess * (1.5 - half * guess * guess);
    }

    /// <summary>
    /// <c>Mth.atan2</c>. Note the argument order is vanilla's, which is <c>Math.atan2</c>'s: y then x.
    /// </summary>
    public static double Atan2(double y, double x) {
        double lengthSquared = x * x + y * y;
        if (double.IsNaN(lengthSquared)) {
            return double.NaN;
        }

        bool negativeY = y < 0.0;
        if (negativeY) {
            y = -y;
        }

        bool negativeX = x < 0.0;
        if (negativeX) {
            x = -x;
        }

        // Fold into the octant the table covers, and remember to fold back out at the end.
        bool steep = y > x;
        if (steep) {
            (y, x) = (x, y);
        }

        double invLength = FastInvSqrt(lengthSquared);
        x *= invLength;
        y *= invLength;

        // Adding y to the bias puts the table index in the low bits of the double, which is what the
        // truncation to int reads back out. C# is unchecked by default here, matching Java's (int) of
        // a long, but say so rather than leave it to the compiler switch.
        double biased = FracBias + y;
        int index = unchecked((int)BitConverter.DoubleToInt64Bits(biased));
        double asin = AsinTable[index];
        double cos = CosTable[index];

        double residual = biased - FracBias;
        double sinDelta = y * cos - x * residual;
        double correction = (6.0 + sinDelta * sinDelta) * sinDelta * 0.16666666666666666;

        double result = asin + correction;
        if (steep) {
            result = 1.5707963267948966 - result;
        }

        if (negativeX) {
            result = 3.141592653589793 - result;
        }

        return negativeY ? -result : result;
    }

    #endregion

    #region degrees

    /// <summary>
    /// <c>Mth.wrapDegrees</c>: fold an angle into (-180, 180]. Note this is <b>not</b> what
    /// <see cref="Angle"/> does, which stores whatever it is given, so an angle built from a
    /// difference of two yaws has to come through here first.
    /// </summary>
    public static float WrapDegrees(float degrees) {
        float wrapped = degrees % 360.0f;
        if (wrapped >= 180.0f) {
            wrapped -= 360.0f;
        }

        if (wrapped < -180.0f) {
            wrapped += 360.0f;
        }

        return wrapped;
    }

    /// <summary><c>Mth.wrapDegrees(double)</c>.</summary>
    public static double WrapDegrees(double degrees) {
        double wrapped = degrees % 360.0;
        if (wrapped >= 180.0) {
            wrapped -= 360.0;
        }

        if (wrapped < -180.0) {
            wrapped += 360.0;
        }

        return wrapped;
    }

    /// <summary>
    /// <c>Mth.degreesDifference</c>: how far <paramref name="to"/> is from <paramref name="from"/>,
    /// signed, taking the short way round.
    /// </summary>
    public static float DegreesDifference(float from, float to) {
        return WrapDegrees(to - from);
    }

    /// <summary><c>Mth.degreesDifferenceAbs</c>.</summary>
    public static float DegreesDifferenceAbs(float from, float to) {
        return Math.Abs(DegreesDifference(from, to));
    }

    /// <summary>
    /// <c>Mth.rotateIfNecessary</c>, which reads backwards until you know what it is for: it returns
    /// <paramref name="target"/> pulled back towards <paramref name="toRotate"/> so the two are no
    /// more than <paramref name="maxDelta"/> apart. Within the limit it returns
    /// <paramref name="toRotate"/> unchanged. This is what clamps a head to its body rather than what
    /// steps an angle towards another, which is <see cref="ApproachDegrees"/>.
    /// </summary>
    public static float RotateIfNecessary(float toRotate, float target, float maxDelta) {
        float difference = DegreesDifference(toRotate, target);
        return target - Clamp(difference, -maxDelta, maxDelta);
    }

    /// <summary><c>Mth.approach</c>: step <paramref name="value"/> towards a target by at most a step.</summary>
    public static float Approach(float value, float target, float step) {
        step = Math.Abs(step);
        return value < target
            ? Clamp(value + step, value, target)
            : Clamp(value - step, target, value);
    }

    /// <summary><c>Mth.approachDegrees</c>: the same, the short way round a circle.</summary>
    public static float ApproachDegrees(float value, float target, float step) {
        float difference = DegreesDifference(value, target);
        return Approach(value, value + difference, step);
    }

    /// <summary>
    /// <c>Mth.rotLerp</c>: interpolate between two angles the short way round. Arguments are vanilla's
    /// order, delta first.
    /// </summary>
    public static float RotLerp(float delta, float start, float end) {
        return start + delta * WrapDegrees(end - start);
    }

    /// <summary><c>Mth.rotLerp(double, double, double)</c>.</summary>
    public static double RotLerp(double delta, double start, double end) {
        return start + delta * WrapDegrees(end - start);
    }

    #endregion

    #region arithmetic

    /// <summary><c>Mth.sqrt(float)</c>, which widens to compute and narrows back.</summary>
    public static float Sqrt(float value) {
        return (float)Math.Sqrt(value);
    }

    /// <summary><c>Mth.floor(float)</c>. It goes through double upstream, so it does here.</summary>
    public static int Floor(float value) {
        return (int)Math.Floor((double)value);
    }

    /// <summary><c>Mth.floor(double)</c>.</summary>
    public static int Floor(double value) {
        return (int)Math.Floor(value);
    }

    /// <summary><c>Mth.lfloor</c>.</summary>
    public static long LFloor(double value) {
        return (long)Math.Floor(value);
    }

    /// <summary><c>Mth.ceil(float)</c>.</summary>
    public static int Ceil(float value) {
        return (int)Math.Ceiling((double)value);
    }

    /// <summary><c>Mth.ceil(double)</c>.</summary>
    public static int Ceil(double value) {
        return (int)Math.Ceiling(value);
    }

    /// <summary><c>Mth.clamp(int, int, int)</c>.</summary>
    public static int Clamp(int value, int min, int max) {
        return Math.Min(Math.Max(value, min), max);
    }

    /// <summary>
    /// <c>Mth.clamp(float, float, float)</c>. Vanilla's is not symmetric: the lower bound is a plain
    /// comparison and the upper one is <c>Math.min</c>, so a NaN comes back as NaN rather than as the
    /// minimum.
    /// </summary>
    public static float Clamp(float value, float min, float max) {
        return value < min ? min : Math.Min(value, max);
    }

    /// <summary><c>Mth.clamp(double, double, double)</c>.</summary>
    public static double Clamp(double value, double min, double max) {
        return value < min ? min : Math.Min(value, max);
    }

    /// <summary><c>Mth.lerp(float, float, float)</c>, delta first.</summary>
    public static float Lerp(float delta, float start, float end) {
        return start + delta * (end - start);
    }

    /// <summary><c>Mth.lerp(double, double, double)</c>, delta first.</summary>
    public static double Lerp(double delta, double start, double end) {
        return start + delta * (end - start);
    }

    /// <summary><c>Mth.square(float)</c>.</summary>
    public static float Square(float value) {
        return value * value;
    }

    /// <summary><c>Mth.square(double)</c>.</summary>
    public static double Square(double value) {
        return value * value;
    }

    /// <summary><c>Mth.sign</c>.</summary>
    public static int Sign(double value) {
        if (value == 0.0) {
            return 0;
        }

        return value > 0.0 ? 1 : -1;
    }

    /// <summary>
    /// <c>Mth.positiveCeilDiv</c>: divide rounding away from zero on the positive side. Vanilla writes
    /// it as a negated floor division, which is what makes it right for negative numerators too.
    /// <p/>
    /// This is what <c>Goal.adjustedTickDelay</c> uses to halve a cadence, so it is on the hot path of
    /// every goal that counts ticks.
    /// </summary>
    public static int PositiveCeilDiv(int numerator, int denominator) {
        // Java's Math.floorDiv, which rounds towards negative infinity rather than towards zero the
        // way C# integer division does.
        int quotient = -numerator / denominator;
        if (-numerator % denominator != 0 && (-numerator < 0) != (denominator < 0)) {
            quotient--;
        }

        return -quotient;
    }

    #endregion
}
