using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>Vanilla's <c>SimplexNoise</c>: the end's island placement and the biome temperature noises.</summary>
/// <remarks>
/// <c>discardNoiseOffset</c> still draws the three offset doubles and multiplies them by zero, so the
/// draws after it are the same either way.
/// </remarks>
public sealed class SimplexNoise(RandomSource random, bool discardNoiseOffset = false)
    : GradientNoise(random, discardNoiseOffset ? 0.0 : 256.0) {

    public static readonly Interval NoiseRange = Interval.OfSymmetric(2.0F);
    public const double StandardDeviation = 0.42544;

    private static readonly double Sqrt3 = Math.Sqrt(3.0);
    private static readonly double F2 = 0.5 * (Sqrt3 - 1.0);
    private static readonly double G2 = (3.0 - Sqrt3) / 6.0;

    public override Interval Range => NoiseRange;

    private static double GetCornerNoise3D(int index, double x, double y, double z, double baseValue) {
        double t0 = baseValue - x * x - y * y - z * z;
        if (t0 < 0.0) {
            return 0.0;
        }

        t0 *= t0;
        return t0 * t0 * Gradients[index].Dot(x, y, z);
    }

    public override float Get(double x, double y) {
        double xin = x + OffsetX;
        double yin = y + OffsetY;
        double s = (xin + yin) * F2;
        int i = Mth.Floor(xin + s);
        int j = Mth.Floor(yin + s);
        double t = (i + j) * G2;
        double x0 = xin - (i - t);
        double y0 = yin - (j - t);
        int i1;
        int j1;
        if (x0 > y0) {
            i1 = 1;
            j1 = 0;
        } else {
            i1 = 0;
            j1 = 1;
        }

        double x1 = x0 - i1 + G2;
        double y1 = y0 - j1 + G2;
        double x2 = x0 - 1.0 + 2.0 * G2;
        double y2 = y0 - 1.0 + 2.0 * G2;
        int ii = i & 0xFF;
        int jj = j & 0xFF;
        int gi0 = Permute(ii + Permute(jj)) % 12;
        int gi1 = Permute(ii + i1 + Permute(jj + j1)) % 12;
        int gi2 = Permute(ii + 1 + Permute(jj + 1)) % 12;
        double n0 = GetCornerNoise3D(gi0, x0, y0, 0.0, 0.5);
        double n1 = GetCornerNoise3D(gi1, x1, y1, 0.0, 0.5);
        double n2 = GetCornerNoise3D(gi2, x2, y2, 0.0, 0.5);
        return (float)(70.0 * (n0 + n1 + n2));
    }

    public override float Get(double x, double y, double z) {
        double xin = x + OffsetX;
        double yin = y + OffsetY;
        double zin = z + OffsetZ;
        double s = (xin + yin + zin) * 0.3333333333333333;
        int i = Mth.Floor(xin + s);
        int j = Mth.Floor(yin + s);
        int k = Mth.Floor(zin + s);
        double t = (i + j + k) * 0.16666666666666666;
        double x0 = xin - (i - t);
        double y0 = yin - (j - t);
        double z0 = zin - (k - t);
        int i1, j1, k1, i2, j2, k2;
        if (x0 >= y0) {
            if (y0 >= z0) {
                (i1, j1, k1, i2, j2, k2) = (1, 0, 0, 1, 1, 0);
            } else if (x0 >= z0) {
                (i1, j1, k1, i2, j2, k2) = (1, 0, 0, 1, 0, 1);
            } else {
                (i1, j1, k1, i2, j2, k2) = (0, 0, 1, 1, 0, 1);
            }
        } else if (y0 < z0) {
            (i1, j1, k1, i2, j2, k2) = (0, 0, 1, 0, 1, 1);
        } else if (x0 < z0) {
            (i1, j1, k1, i2, j2, k2) = (0, 1, 0, 0, 1, 1);
        } else {
            (i1, j1, k1, i2, j2, k2) = (0, 1, 0, 1, 1, 0);
        }

        double x1 = x0 - i1 + 0.16666666666666666;
        double y1 = y0 - j1 + 0.16666666666666666;
        double z1 = z0 - k1 + 0.16666666666666666;
        double x2 = x0 - i2 + 0.3333333333333333;
        double y2 = y0 - j2 + 0.3333333333333333;
        double z2 = z0 - k2 + 0.3333333333333333;
        double x3 = x0 - 1.0 + 0.5;
        double y3 = y0 - 1.0 + 0.5;
        double z3 = z0 - 1.0 + 0.5;
        int ii = i & 0xFF;
        int jj = j & 0xFF;
        int kk = k & 0xFF;
        int gi0 = Permute(ii + Permute(jj + Permute(kk))) % 12;
        int gi1 = Permute(ii + i1 + Permute(jj + j1 + Permute(kk + k1))) % 12;
        int gi2 = Permute(ii + i2 + Permute(jj + j2 + Permute(kk + k2))) % 12;
        int gi3 = Permute(ii + 1 + Permute(jj + 1 + Permute(kk + 1))) % 12;
        double n0 = GetCornerNoise3D(gi0, x0, y0, z0, 0.6);
        double n1 = GetCornerNoise3D(gi1, x1, y1, z1, 0.6);
        double n2 = GetCornerNoise3D(gi2, x2, y2, z2, 0.6);
        double n3 = GetCornerNoise3D(gi3, x3, y3, z3, 0.6);
        return (float)(32.0 * (n0 + n1 + n2 + n3));
    }
}
