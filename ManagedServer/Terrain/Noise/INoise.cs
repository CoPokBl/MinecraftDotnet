using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>A sampled noise field, vanilla's <c>synth.Noise</c>. Values are float, positions double.</summary>
public interface INoise {
    Interval Range { get; }

    float Get(double x, double y);

    float Get(double x, double y, double z);

    /// <summary>
    /// Adds <paramref name="amplitude"/> times the noise at every position of the volume to the buffer.
    /// The coordinates are <c>block * scale</c>, so a stack passes <c>scale * frequency</c> down where its
    /// point path computes <c>(block * scale) * frequency</c>, and the two can differ in the last bit.
    /// </summary>
    void AddToVolume(DensityBuffer buffer, DensityVolume volume, double xzScale, double yScale, float amplitude) {
        AddToVolumeByPoints(this, buffer, volume, xzScale, yScale, amplitude);
    }

    /// <summary>The default <c>Noise.addToVolume</c>: the point path at every position.</summary>
    static void AddToVolumeByPoints(INoise noise, DensityBuffer buffer, DensityVolume volume, double xzScale, double yScale, float amplitude) {
        int index = 0;
        for (int indexZ = 0; indexZ < volume.SizeZ; indexZ++) {
            double z = volume.BlockZ(indexZ) * xzScale;
            for (int indexX = 0; indexX < volume.SizeX; indexX++) {
                double x = volume.BlockX(indexX) * xzScale;
                for (int indexY = 0; indexY < volume.SizeY; indexY++) {
                    double y = volume.BlockY(indexY) * yScale;
                    buffer.AddTo(index, amplitude * noise.Get(x, y, z));
                    index++;
                }
            }
        }
    }
}

/// <summary>
/// The offsets and permutation table every lattice noise starts from, vanilla's <c>GradientNoise</c>.
/// </summary>
/// <remarks>
/// Construction draws three doubles then 256 swaps, and that draw count is part of the noise's
/// identity: a stack built from one generator in sequence relies on each layer taking exactly this.
/// </remarks>
public abstract class GradientNoise : INoise {
    protected static readonly Gradient[] Gradients = [
        new(1, 1, 0), new(-1, 1, 0), new(1, -1, 0), new(-1, -1, 0),
        new(1, 0, 1), new(-1, 0, 1), new(1, 0, -1), new(-1, 0, -1),
        new(0, 1, 1), new(0, -1, 1), new(0, 1, -1), new(0, -1, -1),
        new(1, 1, 0), new(0, -1, 1), new(-1, 1, 0), new(0, -1, -1)
    ];

    private const double RoundOff = 3.3554432E7;
    private static readonly double HalfRoundOff = Math.BitDecrement(1.6777216E7);

    protected readonly byte[] Perms = new byte[256];
    protected readonly double OffsetX;
    protected readonly double OffsetY;
    protected readonly double OffsetZ;

    protected GradientNoise(RandomSource random, double noiseOffsetScale = 256.0) {
        OffsetX = random.NextDouble() * noiseOffsetScale;
        OffsetY = random.NextDouble() * noiseOffsetScale;
        OffsetZ = random.NextDouble() * noiseOffsetScale;

        for (int i = 0; i < 256; i++) {
            Perms[i] = (byte)i;
        }

        for (int i = 0; i < 256; i++) {
            int offset = random.NextInt(256 - i);
            (Perms[i], Perms[offset + i]) = (Perms[offset + i], Perms[i]);
        }
    }

    public abstract Interval Range { get; }

    public abstract float Get(double x, double y);

    public abstract float Get(double x, double y, double z);

    public virtual void AddToVolume(DensityBuffer buffer, DensityVolume volume, double xzScale, double yScale, float amplitude) {
        INoise.AddToVolumeByPoints(this, buffer, volume, xzScale, yScale, amplitude);
    }

    protected int Permute(int x) => Perms[x & 0xFF];

    protected Gradient PermuteToGrad(int x) => Gradients[Permute(x) & 15];

    protected static float GradDot(int hash, float x, float y, float z) => Gradients[hash & 15].Dot(x, y, z);

    /// <summary>
    /// Folds a coordinate into the range the lattice can still resolve. Leaving small coordinates alone
    /// is not an optimisation of the formula but a different rounding of it, so the bound is exact.
    /// </summary>
    protected static double Wrap(double x) {
        return x >= -HalfRoundOff && x < HalfRoundOff ? x : x - Math.Floor(x / RoundOff + 0.5) * RoundOff;
    }

    protected readonly record struct Gradient(int X, int Y, int Z) {
        public double Dot(double x, double y, double z) => X * x + Y * y + Z * z;

        public float Dot(float x, float y, float z) => X * x + Y * y + Z * z;

        public float DotXz(float x, float z) => X * x + Z * z;
    }
}
