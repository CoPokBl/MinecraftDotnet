using System.Numerics;

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
    /// <c>Mth.invSqrt</c>: the exact reciprocal square root, which upstream is <c>joml</c>'s
    /// <c>Math.invsqrt</c> and is <c>1.0 / sqrt(x)</c>.
    /// </summary>
    /// <remarks>
    /// <b>Not <see cref="FastInvSqrt"/>.</b> The two names sit next to each other in <c>Mth</c> and
    /// differ by a few parts in a million, which is enough to move a boundary a caller compares
    /// against by a block. Read which one the call site asks for.
    /// </remarks>
    public static double InvSqrt(double value) {
        return 1.0 / Math.Sqrt(value);
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
    /// <c>Mth.nextInt(RandomSource, int, int)</c>: a value in [min, max], <b>inclusive</b> at both
    /// ends, unlike <see cref="RandomSource.NextInt(int, int)"/>.
    /// </summary>
    /// <remarks>
    /// <b>Not <see cref="RandomBetweenInclusive"/>, which is the same range and a different function.</b>
    /// This one answers <paramref name="min"/> without drawing when the range is empty and that one
    /// draws anyway, so picking the wrong one for a caller shifts every value the feature or carver
    /// takes after it. Both are called upstream and there is nothing about a call site that says
    /// which; read the method.
    /// </remarks>
    public static int NextInt(RandomSource random, int min, int max) {
        return min >= max ? min : random.NextInt(max - min + 1) + min;
    }

    /// <summary><c>Mth.nextFloat(RandomSource, float, float)</c>.</summary>
    /// <remarks>The guarded one, as <see cref="NextInt"/> is; <see cref="RandomBetween"/> is the other.</remarks>
    public static float NextFloat(RandomSource random, float min, float max) {
        return min >= max ? min : random.NextFloat() * (max - min) + min;
    }

    /// <summary><c>Mth.nextDouble(RandomSource, double, double)</c>.</summary>
    /// <remarks>The guarded one, as <see cref="NextInt"/> is.</remarks>
    public static double NextDouble(RandomSource random, double min, double max) {
        return min >= max ? min : random.NextDouble() * (max - min) + min;
    }

    /// <summary>
    /// <c>Mth.randomBetweenInclusive</c>: the same closed range as <see cref="NextInt"/> and
    /// <b>always a draw</b>, even where the range holds one value.
    /// </summary>
    /// <remarks>
    /// <c>nextInt(1)</c> is a power of two, so it takes its bits and answers zero; skipping it because
    /// the answer is known moves every later draw of whatever is running. It also throws where
    /// <paramref name="max"/> is below <paramref name="min"/>, which is upstream's own contract and
    /// worth keeping: a caller that can invert its bounds is a caller that has miscomputed them.
    /// </remarks>
    public static int RandomBetweenInclusive(RandomSource random, int min, int max) {
        return random.NextInt(max - min + 1) + min;
    }

    /// <summary><c>Mth.randomBetween</c>: <see cref="NextFloat"/>'s range, always a draw.</summary>
    public static float RandomBetween(RandomSource random, float min, float max) {
        return random.NextFloat() * (max - min) + min;
    }

    /// <summary>
    /// Java's <c>Math.round(float)</c>, which <see cref="Math.Round(double)"/> is not: C# rounds a tie
    /// to the nearest even, so a half comes back as zero rather than as one.
    /// <p/>
    /// Transcribed rather than written as <c>floor(x + 0.5f)</c>, which is what the Java docs say but
    /// not what the method does: adding a half to the float just below it rounds up in the addition
    /// and gives one where Java gives zero.
    /// </summary>
    public static int JavaRound(float value) {
        int bits = BitConverter.SingleToInt32Bits(value);
        int biasedExponent = (bits & 0x7F800000) >> 23;
        int shift = 24 - 2 + 127 - biasedExponent;

        if ((shift & -32) != 0) {
            return (int)value;
        }

        int significand = (bits & 0x007FFFFF) | 0x00800000;
        if (bits < 0) {
            significand = -significand;
        }

        return ((significand >> shift) + 1) >> 1;
    }

    /// <summary>
    /// Java's <c>Math.floorDiv</c>: division rounding towards negative infinity, which C# integer
    /// division does not do. Every worldgen coordinate that becomes a cell index goes through this,
    /// and truncating instead puts two adjacent cells either side of zero into the same index.
    /// </summary>
    public static int FloorDiv(int numerator, int denominator) {
        int quotient = numerator / denominator;
        if (numerator % denominator != 0 && (numerator < 0) != (denominator < 0)) {
            quotient--;
        }

        return quotient;
    }

    /// <summary>Java's <c>Math.floorMod</c>: the remainder that matches <see cref="FloorDiv"/>.</summary>
    public static int FloorMod(int numerator, int denominator) {
        return numerator - FloorDiv(numerator, denominator) * denominator;
    }

    /// <summary><c>Math.floorMod(long, long)</c>, which is never negative for a positive divisor.</summary>
    public static long FloorMod(long numerator, long denominator) {
        long remainder = numerator % denominator;
        if (remainder != 0 && (remainder < 0) != (denominator < 0)) {
            remainder += denominator;
        }

        return remainder;
    }

    /// <summary><c>Mth.quantize</c>: rounded down to a multiple of the resolution.</summary>
    public static int Quantize(double value, int resolution) {
        return Floor(value / resolution) * resolution;
    }

    /// <summary>
    /// Java's <c>Math.round(double)</c>, which breaks a tie <b>upwards</b> rather than to even the way
    /// <see cref="Math.Round(double)"/> does. See <see cref="JavaRound(float)"/> for why it is
    /// transcribed rather than written as a floor of the value plus a half.
    /// </summary>
    public static long JavaRound(double value) {
        long bits = BitConverter.DoubleToInt64Bits(value);
        long biasedExponent = (bits & 0x7FF0000000000000L) >> 52;
        long shift = 53 - 2 + 1023 - biasedExponent;

        if ((shift & -64L) != 0) {
            return (long)value;
        }

        long significand = (bits & 0x000FFFFFFFFFFFFFL) | 0x0010000000000000L;
        if (bits < 0) {
            significand = -significand;
        }

        return ((significand >> (int)shift) + 1) >> 1;
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

    /// <summary>
    /// <c>Mth.ceillog2</c>: the smallest <c>b</c> with <c>2^b &gt;= value</c>, i.e. how many bits an
    /// index into <paramref name="value"/> slots needs.
    /// </summary>
    /// <remarks>
    /// <b>Not</b> <see cref="ExtensionUtils.MinBitsToStore"/>, which is <c>ceil(log2(value + 1))</c>,
    /// how many bits <paramref name="value"/> itself needs. The two agree everywhere except exact
    /// powers of two, where this is one smaller: <c>CeilLog2(32768)</c> is 15 and
    /// <c>MinBitsToStore(32768)</c> is 16.
    /// <p/>
    /// The difference decides the wire, so it is not cosmetic. A direct palette is read by
    /// <c>PalettedContainer.read</c> at <c>Configuration.bitsInMemory()</c> width, which for the
    /// global palette is this function of the block state count, rather than at the width we send.
    /// Using the other helper the day that count lands on a power of two writes a section the client
    /// unpacks at the wrong stride and misparses without erroring.
    /// </remarks>
    public static int CeilLog2(int value) {
        if (value < 0) {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be non-negative.");
        }

        // Vanilla is log2(smallestEncompassingPowerOfTwo(value)); this is the same answer without
        // building the power first, and it keeps ceillog2(0) and ceillog2(1) at 0 as vanilla does.
        return value <= 1 ? 0 : BitOperations.Log2((uint)(value - 1)) + 1;
    }

    #endregion

    #region interpolation

    /// <summary><c>Mth.clampedLerp</c>: <see cref="Lerp(double,double,double)"/> with delta clamped.</summary>
    public static double ClampedLerp(double delta, double start, double end) {
        if (delta < 0.0) {
            return start;
        }

        return delta > 1.0 ? end : Lerp(delta, start, end);
    }

    /// <summary><c>Mth.clampedLerp(float, float, float)</c>.</summary>
    public static float ClampedLerp(float delta, float start, float end) {
        if (delta < 0.0f) {
            return start;
        }

        return delta > 1.0f ? end : Lerp(delta, start, end);
    }

    /// <summary><c>Mth.inverseLerp</c>: where <paramref name="value"/> sits between the two ends.</summary>
    public static double InverseLerp(double value, double min, double max) {
        return (value - min) / (max - min);
    }

    /// <summary><c>Mth.inverseLerp(float, float, float)</c>.</summary>
    public static float InverseLerp(float value, float min, float max) {
        return (value - min) / (max - min);
    }

    /// <summary><c>Mth.map</c>: one range onto another, unclamped.</summary>
    public static double Map(double value, double fromMin, double fromMax, double toMin, double toMax) {
        return Lerp(InverseLerp(value, fromMin, fromMax), toMin, toMax);
    }

    /// <summary><c>Mth.clampedMap</c>: the same, clamped to the target range.</summary>
    public static double ClampedMap(double value, double fromMin, double fromMax, double toMin, double toMax) {
        return ClampedLerp(InverseLerp(value, fromMin, fromMax), toMin, toMax);
    }

    /// <summary><c>Mth.clampedMap(float, float, float, float, float)</c>.</summary>
    /// <remarks>
    /// Both overloads are called upstream and they do not agree: a caller whose arguments are floats
    /// gets this one and widens its answer afterwards, so computing the same expression in double
    /// lands a few parts in a hundred million away. Where the answer is a probability compared
    /// against a <c>nextDouble</c>, that difference is a decision.
    /// </remarks>
    public static float ClampedMap(float value, float fromMin, float fromMax, float toMin, float toMax) {
        return ClampedLerp(InverseLerp(value, fromMin, fromMax), toMin, toMax);
    }

    /// <summary><c>Mth.lerp2</c>: bilinear over the four corners of a square.</summary>
    public static double Lerp2(double alphaX, double alphaY, double x00, double x10, double x01, double x11) {
        return Lerp(alphaY, Lerp(alphaX, x00, x10), Lerp(alphaX, x01, x11));
    }

    /// <summary><c>Mth.lerp3</c>: trilinear over the eight corners of a cube.</summary>
    public static double Lerp3(double alphaX, double alphaY, double alphaZ,
        double x000, double x100, double x010, double x110,
        double x001, double x101, double x011, double x111) {

        return Lerp(alphaZ, Lerp2(alphaX, alphaY, x000, x100, x010, x110),
            Lerp2(alphaX, alphaY, x001, x101, x011, x111));
    }

    /// <summary><c>Mth.lerp2(float...)</c>.</summary>
    public static float Lerp2(float alphaX, float alphaY, float x00, float x10, float x01, float x11) {
        return Lerp(alphaY, Lerp(alphaX, x00, x10), Lerp(alphaX, x01, x11));
    }

    /// <summary><c>Mth.lerp3(float...)</c>.</summary>
    public static float Lerp3(float alphaX, float alphaY, float alphaZ,
        float x000, float x100, float x010, float x110,
        float x001, float x101, float x011, float x111) {

        return Lerp(alphaZ, Lerp2(alphaX, alphaY, x000, x100, x010, x110),
            Lerp2(alphaX, alphaY, x001, x101, x011, x111));
    }

    /// <summary>
    /// <c>Mth.smoothstep</c>, the fifth order fade Perlin noise interpolates with. Not the cubic
    /// <c>3x^2 - 2x^3</c> that goes by the same name elsewhere.
    /// </summary>
    public static float Smoothstep(float x) {
        return x * x * x * (x * (x * 6.0F - 15.0F) + 10.0F);
    }

    /// <summary><c>Mth.smoothstepDerivative</c>.</summary>
    public static float SmoothstepDerivative(float x) {
        return 30.0F * x * x * (x - 1.0F) * (x - 1.0F);
    }

    /// <summary><c>Mth.cube(float)</c>.</summary>
    public static float Cube(float value) {
        return value * value * value;
    }

    /// <summary><c>Mth.lengthSquared(float, float)</c>.</summary>
    public static float LengthSquared(float x, float y) {
        return x * x + y * y;
    }

    /// <summary><c>Mth.lengthSquared(float, float, float)</c>.</summary>
    public static float LengthSquared(float x, float y, float z) {
        return x * x + y * y + z * z;
    }

    /// <summary><c>Mth.length(float, float)</c>.</summary>
    public static float Length(float x, float y) {
        return Sqrt(LengthSquared(x, y));
    }

    /// <summary><c>Mth.length(float, float, float)</c>.</summary>
    public static float Length(float x, float y, float z) {
        return Sqrt(LengthSquared(x, y, z));
    }

    /// <summary><c>Mth.catmullrom</c>, the spline segment cubic spline density functions use.</summary>
    public static float CatmullRom(float alpha, float p0, float p1, float p2, float p3) {
        return 0.5f * (2.0f * p1
            + (p2 - p0) * alpha
            + (2.0f * p0 - 5.0f * p1 + 4.0f * p2 - p3) * alpha * alpha
            + (3.0f * p1 - p0 - 3.0f * p2 + p3) * alpha * alpha * alpha);
    }

    /// <summary>
    /// <c>Mth.getSeed</c>: a position hashed into a seed, which is how every positional random factory
    /// turns a block position into a generator.
    /// </summary>
    /// <remarks>
    /// The first line overflows for most positions and is meant to: <c>x * 3129871</c> is an
    /// <b>int</b> multiply upstream and wraps at 32 bits before it is widened, while
    /// <c>z * 116129781L</c> is a long one and does not. Doing both in long moves every seed.
    /// </remarks>
    public static long GetSeed(int x, int y, int z) {
        long seed = (x * 3129871) ^ (z * 116129781L) ^ y;
        seed = seed * seed * 42317861L + seed * 11L;
        return seed >> 16;
    }

    #endregion
}
