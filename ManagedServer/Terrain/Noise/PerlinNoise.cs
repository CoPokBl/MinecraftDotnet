using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>One octave of Perlin noise in float, vanilla's <c>PerlinNoise</c>.</summary>
/// <remarks>
/// The volume path caches the corner gradients per y lattice cell and adds <c>gy * relativeY</c> to a
/// precomputed xz dot product. With two non-zero gradient components that is the point path's dot
/// product bit for bit, so the two paths agree here; they diverge only above, in the stack.
/// </remarks>
public class PerlinNoise(RandomSource random) : GradientNoise(random) {
    public static readonly Interval NoiseRange = Interval.OfSymmetric(2.0F);
    public const double StandardDeviation = 0.2702247831245211;

    public override Interval Range => NoiseRange;

    public override float Get(double x, double y) {
        return Get(Wrap(x), 0.0, Wrap(y));
    }

    public override float Get(double x, double y, double z) {
        double px = Wrap(x) + OffsetX;
        double py = Wrap(y) + OffsetY;
        double pz = Wrap(z) + OffsetZ;
        int floorX = Mth.Floor(px);
        int floorY = Mth.Floor(py);
        int floorZ = Mth.Floor(pz);
        float relativeX = (float)(px - floorX);
        float relativeY = (float)(py - floorY);
        float relativeZ = (float)(pz - floorZ);
        return SampleAndLerp(floorX, floorY, floorZ, relativeX, relativeY, relativeZ, relativeY);
    }

    /// <summary>The fade runs on <paramref name="originalRelativeY"/> and the dot products on <paramref name="relativeY"/>, which only differ for the smeared subclass.</summary>
    protected float SampleAndLerp(int x, int y, int z, float relativeX, float relativeY, float relativeZ, float originalRelativeY) {
        int x0 = Permute(x);
        int x1 = Permute(x + 1);
        int xy00 = Permute(x0 + y);
        int xy01 = Permute(x0 + y + 1);
        int xy10 = Permute(x1 + y);
        int xy11 = Permute(x1 + y + 1);
        float d000 = GradDot(Permute(xy00 + z), relativeX, relativeY, relativeZ);
        float d100 = GradDot(Permute(xy10 + z), relativeX - 1.0F, relativeY, relativeZ);
        float d010 = GradDot(Permute(xy01 + z), relativeX, relativeY - 1.0F, relativeZ);
        float d110 = GradDot(Permute(xy11 + z), relativeX - 1.0F, relativeY - 1.0F, relativeZ);
        float d001 = GradDot(Permute(xy00 + z + 1), relativeX, relativeY, relativeZ - 1.0F);
        float d101 = GradDot(Permute(xy10 + z + 1), relativeX - 1.0F, relativeY, relativeZ - 1.0F);
        float d011 = GradDot(Permute(xy01 + z + 1), relativeX, relativeY - 1.0F, relativeZ - 1.0F);
        float d111 = GradDot(Permute(xy11 + z + 1), relativeX - 1.0F, relativeY - 1.0F, relativeZ - 1.0F);
        float xAlpha = Mth.Smoothstep(relativeX);
        float yAlpha = Mth.Smoothstep(originalRelativeY);
        float zAlpha = Mth.Smoothstep(relativeZ);
        return Mth.Lerp3(xAlpha, yAlpha, zAlpha, d000, d100, d010, d110, d001, d101, d011, d111);
    }

    public override void AddToVolume(DensityBuffer buffer, DensityVolume volume, double xzScale, double yScale, float amplitude) {
        Corners corners = default;
        int index = 0;

        for (int indexZ = 0; indexZ < volume.SizeZ; indexZ++) {
            double z = Wrap(volume.BlockZ(indexZ) * xzScale) + OffsetZ;
            int floorZ = Mth.Floor(z);
            float relativeZ = (float)(z - floorZ);
            float alphaZ = Mth.Smoothstep(relativeZ);

            for (int indexX = 0; indexX < volume.SizeX; indexX++) {
                double x = Wrap(volume.BlockX(indexX) * xzScale) + OffsetX;
                int floorX = Mth.Floor(x);
                float relativeX = (float)(x - floorX);
                int x0 = Permute(floorX);
                int x1 = Permute(floorX + 1);
                float alphaX = Mth.Smoothstep(relativeX);
                int lastFloorY = int.MinValue;

                for (int indexY = 0; indexY < volume.SizeY; indexY++) {
                    double y = Wrap(volume.BlockY(indexY) * yScale) + OffsetY;
                    int floorY = Mth.Floor(y);
                    float relativeY = (float)(y - floorY);
                    float alphaY = Mth.Smoothstep(relativeY);
                    if (lastFloorY != floorY) {
                        corners = Corners.At(this, x0, x1, floorY, floorZ, relativeX, relativeZ);
                        lastFloorY = floorY;
                    }

                    buffer.AddTo(index, amplitude * corners.Lerp(alphaX, alphaY, alphaZ, relativeY));
                    index++;
                }
            }
        }
    }

    /// <summary>The eight corners' xz dot products and y gradients, reused while y stays in one lattice cell.</summary>
    protected struct Corners {
        private float _d000Xz, _d100Xz, _d010Xz, _d110Xz, _d001Xz, _d101Xz, _d011Xz, _d111Xz;
        private float _g000Y, _g100Y, _g010Y, _g110Y, _g001Y, _g101Y, _g011Y, _g111Y;

        public static Corners At(PerlinNoise noise, int x0, int x1, int floorY, int floorZ, float relativeX, float relativeZ) {
            int xy00 = noise.Permute(x0 + floorY);
            int xy01 = noise.Permute(x0 + floorY + 1);
            int xy10 = noise.Permute(x1 + floorY);
            int xy11 = noise.Permute(x1 + floorY + 1);
            Corners c = default;
            Gradient g000 = noise.PermuteToGrad(xy00 + floorZ);
            c._d000Xz = g000.DotXz(relativeX, relativeZ);
            c._g000Y = g000.Y;
            Gradient g100 = noise.PermuteToGrad(xy10 + floorZ);
            c._d100Xz = g100.DotXz(relativeX - 1.0F, relativeZ);
            c._g100Y = g100.Y;
            Gradient g010 = noise.PermuteToGrad(xy01 + floorZ);
            c._d010Xz = g010.DotXz(relativeX, relativeZ);
            c._g010Y = g010.Y;
            Gradient g110 = noise.PermuteToGrad(xy11 + floorZ);
            c._d110Xz = g110.DotXz(relativeX - 1.0F, relativeZ);
            c._g110Y = g110.Y;
            Gradient g001 = noise.PermuteToGrad(xy00 + floorZ + 1);
            c._d001Xz = g001.DotXz(relativeX, relativeZ - 1.0F);
            c._g001Y = g001.Y;
            Gradient g101 = noise.PermuteToGrad(xy10 + floorZ + 1);
            c._d101Xz = g101.DotXz(relativeX - 1.0F, relativeZ - 1.0F);
            c._g101Y = g101.Y;
            Gradient g011 = noise.PermuteToGrad(xy01 + floorZ + 1);
            c._d011Xz = g011.DotXz(relativeX, relativeZ - 1.0F);
            c._g011Y = g011.Y;
            Gradient g111 = noise.PermuteToGrad(xy11 + floorZ + 1);
            c._d111Xz = g111.DotXz(relativeX - 1.0F, relativeZ - 1.0F);
            c._g111Y = g111.Y;
            return c;
        }

        public readonly float Lerp(float alphaX, float alphaY, float alphaZ, float relativeY) {
            return Mth.Lerp3(alphaX, alphaY, alphaZ,
                _d000Xz + _g000Y * relativeY,
                _d100Xz + _g100Y * relativeY,
                _d010Xz + _g010Y * (relativeY - 1.0F),
                _d110Xz + _g110Y * (relativeY - 1.0F),
                _d001Xz + _g001Y * relativeY,
                _d101Xz + _g101Y * relativeY,
                _d011Xz + _g011Y * (relativeY - 1.0F),
                _d111Xz + _g111Y * (relativeY - 1.0F));
        }
    }
}

/// <summary>
/// Perlin noise with its y quantised to a multiple of a scale, vanilla's <c>SmearedPerlinNoise</c>. It
/// is what smears the old terrain noise vertically, and only <see cref="BlendedNoise"/> builds it.
/// </summary>
public sealed class SmearedPerlinNoise(RandomSource random, double fudgeYScale) : PerlinNoise(random) {
    private const float ShiftUpEpsilon = 1.0E-7F;

    public static Interval RangeFor(double fudgeYScale) => Interval.OfSymmetric((float)(Math.Abs(fudgeYScale) + 2.0));

    public override Interval Range => RangeFor(fudgeYScale);

    public override float Get(double x, double y, double z) {
        double px = Wrap(x) + OffsetX;
        double py = Wrap(y) + OffsetY;
        double pz = Wrap(z) + OffsetZ;
        int floorX = Mth.Floor(px);
        int floorY = Mth.Floor(py);
        int floorZ = Mth.Floor(pz);
        float relativeX = (float)(px - floorX);
        double relativeY = py - floorY;
        float relativeZ = (float)(pz - floorZ);
        float fudgedRelativeY = (float)(relativeY - ComputeFudgeY(y, relativeY));
        return SampleAndLerp(floorX, floorY, floorZ, relativeX, fudgedRelativeY, relativeZ, (float)relativeY);
    }

    /// <summary>The epsilon is a float upstream and widens to double here, which moves the floor of a limit landing exactly on a multiple.</summary>
    private double ComputeFudgeY(double originalY, double relativeY) {
        double fudgeLimit = originalY >= 0.0 && originalY < relativeY ? originalY : relativeY;
        return Mth.Floor(fudgeLimit / fudgeYScale + ShiftUpEpsilon) * fudgeYScale;
    }

    public override void AddToVolume(DensityBuffer buffer, DensityVolume volume, double xzScale, double yScale, float amplitude) {
        Corners corners = default;
        int index = 0;

        for (int indexZ = 0; indexZ < volume.SizeZ; indexZ++) {
            double z = Wrap(volume.BlockZ(indexZ) * xzScale) + OffsetZ;
            int floorZ = Mth.Floor(z);
            float relativeZ = (float)(z - floorZ);
            float alphaZ = Mth.Smoothstep(relativeZ);

            for (int indexX = 0; indexX < volume.SizeX; indexX++) {
                double x = Wrap(volume.BlockX(indexX) * xzScale) + OffsetX;
                int floorX = Mth.Floor(x);
                float relativeX = (float)(x - floorX);
                int x0 = Permute(floorX);
                int x1 = Permute(floorX + 1);
                float alphaX = Mth.Smoothstep(relativeX);
                int lastFloorY = int.MinValue;

                for (int indexY = 0; indexY < volume.SizeY; indexY++) {
                    double originalY = volume.BlockY(indexY) * yScale;
                    double y = Wrap(originalY) + OffsetY;
                    int floorY = Mth.Floor(y);
                    double relativeY = y - floorY;
                    float alphaY = Mth.Smoothstep((float)relativeY);
                    if (lastFloorY != floorY) {
                        corners = Corners.At(this, x0, x1, floorY, floorZ, relativeX, relativeZ);
                        lastFloorY = floorY;
                    }

                    float fudgedRelativeY = (float)(relativeY - ComputeFudgeY(originalY, relativeY));
                    buffer.AddTo(index, amplitude * corners.Lerp(alphaX, alphaY, alphaZ, fudgedRelativeY));
                    index++;
                }
            }
        }
    }
}
