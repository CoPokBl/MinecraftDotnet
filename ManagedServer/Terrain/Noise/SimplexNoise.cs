using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// Vanilla's <c>SimplexNoise</c>. Only the two dimensional sampler is ported, since the one thing in
/// worldgen still using this rather than <see cref="PerlinNoise"/> is the end's island placement, and
/// that reads a plane.
/// </summary>
public sealed class SimplexNoise {
    private static readonly int[][] Gradient = [
        [1, 1, 0], [-1, 1, 0], [1, -1, 0], [-1, -1, 0],
        [1, 0, 1], [-1, 0, 1], [1, 0, -1], [-1, 0, -1],
        [0, 1, 1], [0, -1, 1], [0, 1, -1], [0, -1, -1],
        [1, 1, 0], [0, -1, 1], [-1, 1, 0], [0, -1, -1]
    ];

    private static readonly double Sqrt3 = Math.Sqrt(3.0);
    private static readonly double F2 = 0.5 * (Sqrt3 - 1.0);
    private static readonly double G2 = (3.0 - Sqrt3) / 6.0;

    private readonly int[] _p = new int[512];

    public readonly double Xo;
    public readonly double Yo;
    public readonly double Zo;

    public SimplexNoise(RandomSource random) {
        Xo = random.NextDouble() * 256.0;
        Yo = random.NextDouble() * 256.0;
        Zo = random.NextDouble() * 256.0;

        for (int i = 0; i < 256; i++) {
            _p[i] = i;
        }

        for (int i = 0; i < 256; i++) {
            int offset = random.NextInt(256 - i);
            (_p[i], _p[i + offset]) = (_p[i + offset], _p[i]);
        }
    }

    private int P(int x) => _p[x & 0xFF];

    private static double Dot(int[] g, double x, double y, double z) {
        return g[0] * x + g[1] * y + g[2] * z;
    }

    private static double CornerNoise(int index, double x, double y, double z, double basis) {
        double t = basis - x * x - y * y - z * z;
        if (t < 0.0) {
            return 0.0;
        }

        t *= t;
        return t * t * Dot(Gradient[index], x, y, z);
    }

    public double GetValue(double xin, double yin) {
        double s = (xin + yin) * F2;
        int i = Mth.Floor(xin + s);
        int j = Mth.Floor(yin + s);

        double t = (i + j) * G2;
        double x0 = xin - (i - t);
        double y0 = yin - (j - t);

        // Which of the two triangles in the skewed cell the point landed in.
        int i1 = x0 > y0 ? 1 : 0;
        int j1 = x0 > y0 ? 0 : 1;

        double x1 = x0 - i1 + G2;
        double y1 = y0 - j1 + G2;
        double x2 = x0 - 1.0 + 2.0 * G2;
        double y2 = y0 - 1.0 + 2.0 * G2;

        int ii = i & 0xFF;
        int jj = j & 0xFF;

        // The modulo is over twelve while the gradient table holds sixteen, so the last four are
        // unreachable here. That is vanilla's, not an oversight to tidy up.
        int gi0 = P(ii + P(jj)) % 12;
        int gi1 = P(ii + i1 + P(jj + j1)) % 12;
        int gi2 = P(ii + 1 + P(jj + 1)) % 12;

        return 70.0 * (CornerNoise(gi0, x0, y0, 0.0, 0.5)
            + CornerNoise(gi1, x1, y1, 0.0, 0.5)
            + CornerNoise(gi2, x2, y2, 0.0, 0.5));
    }
}
