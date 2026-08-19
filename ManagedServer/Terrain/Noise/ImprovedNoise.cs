using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// One octave of Perlin noise, vanilla's <c>ImprovedNoise</c>.
/// </summary>
/// <remarks>
/// The permutation table is shuffled by the generator it is handed, so the offsets and the table
/// together are the whole of an octave's identity: two octaves seeded the same way are the same noise.
/// <p/>
/// <see cref="Noise(double,double,double,double,double)"/> carries a y fudge that only
/// <see cref="BlendedNoise"/> uses. It is <c>@Deprecated</c> upstream and quantises the sample's y to
/// a multiple of <c>yScale</c>, which is what smears the old terrain noise vertically.
/// </remarks>
public sealed class ImprovedNoise {
    /// <summary>The sixteen gradient vectors, <c>SimplexNoise.GRADIENT</c>. Four are duplicates.</summary>
    private static readonly int[][] Gradient = [
        [1, 1, 0], [-1, 1, 0], [1, -1, 0], [-1, -1, 0],
        [1, 0, 1], [-1, 0, 1], [1, 0, -1], [-1, 0, -1],
        [0, 1, 1], [0, -1, 1], [0, 1, -1], [0, -1, -1],
        [1, 1, 0], [0, -1, 1], [-1, 1, 0], [0, -1, -1]
    ];

    private readonly byte[] _p = new byte[256];

    public readonly double Xo;
    public readonly double Yo;
    public readonly double Zo;

    public ImprovedNoise(RandomSource random) {
        Xo = random.NextDouble() * 256.0;
        Yo = random.NextDouble() * 256.0;
        Zo = random.NextDouble() * 256.0;

        for (int i = 0; i < 256; i++) {
            _p[i] = (byte)i;
        }

        for (int i = 0; i < 256; i++) {
            int offset = random.NextInt(256 - i);
            (_p[i], _p[i + offset]) = (_p[i + offset], _p[i]);
        }
    }

    public double Noise(double x, double y, double z) {
        return Noise(x, y, z, 0.0, 0.0);
    }

    public double Noise(double x, double y, double z, double yScale, double yFudge) {
        double px = x + Xo;
        double py = y + Yo;
        double pz = z + Zo;

        int xf = Mth.Floor(px);
        int yf = Mth.Floor(py);
        int zf = Mth.Floor(pz);

        double xr = px - xf;
        double yr = py - yf;
        double zr = pz - zf;

        double yrFudge = 0.0;
        if (yScale != 0.0) {
            double limit = yFudge >= 0.0 && yFudge < yr ? yFudge : yr;

            // The epsilon is a float upstream and widens here, which moves the floor for a limit that
            // lands exactly on a multiple of the scale.
            yrFudge = Mth.Floor(limit / yScale + 1.0E-7f) * yScale;
        }

        // The fade still runs on the unfudged y: the sample moves, the interpolation weight does not.
        return SampleAndLerp(xf, yf, zf, xr, yr - yrFudge, zr, yr);
    }

    private static double GradDot(int hash, double x, double y, double z) {
        int[] g = Gradient[hash & 15];
        return g[0] * x + g[1] * y + g[2] * z;
    }

    private int P(int x) {
        return _p[x & 0xFF] & 0xFF;
    }

    private double SampleAndLerp(int x, int y, int z, double xr, double yr, double zr, double yrOriginal) {
        int x0 = P(x);
        int x1 = P(x + 1);
        int xy00 = P(x0 + y);
        int xy01 = P(x0 + y + 1);
        int xy10 = P(x1 + y);
        int xy11 = P(x1 + y + 1);

        double d000 = GradDot(P(xy00 + z), xr, yr, zr);
        double d100 = GradDot(P(xy10 + z), xr - 1.0, yr, zr);
        double d010 = GradDot(P(xy01 + z), xr, yr - 1.0, zr);
        double d110 = GradDot(P(xy11 + z), xr - 1.0, yr - 1.0, zr);
        double d001 = GradDot(P(xy00 + z + 1), xr, yr, zr - 1.0);
        double d101 = GradDot(P(xy10 + z + 1), xr - 1.0, yr, zr - 1.0);
        double d011 = GradDot(P(xy01 + z + 1), xr, yr - 1.0, zr - 1.0);
        double d111 = GradDot(P(xy11 + z + 1), xr - 1.0, yr - 1.0, zr - 1.0);

        return Mth.Lerp3(Mth.Smoothstep(xr), Mth.Smoothstep(yrOriginal), Mth.Smoothstep(zr),
            d000, d100, d010, d110, d001, d101, d011, d111);
    }
}
