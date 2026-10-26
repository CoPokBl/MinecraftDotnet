using ManagedServer.Terrain.Density;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Noise;

/// <summary>
/// The old terrain noise, vanilla's <c>BlendedNoise</c> (<c>old_blended_noise</c>): two limit stacks
/// interpolated by a third, all of smeared Perlin octaves drawn from one generator in sequence.
/// </summary>
/// <remarks>
/// It compiles to <c>lerp(clamp(main + 0.5, 0, 1), min, max)</c> over three noise samplers, so both
/// limit stacks are sampled wherever the alpha is not exactly zero or one, and the volume path samples
/// all three everywhere.
/// </remarks>
public sealed record BlendedNoise(double XzScale, double YScale, double XzFactor, double YFactor, double SmearScaleMultiplier)
    : IDensityFunction {

    private const double BaseScale = 684.412;
    private const double LimitFactor = 0.99998474F;
    private const double MainFactor = 12.75;
    private const int LimitFirstOctave = -15;
    private const int MainFirstOctave = -7;

    public static readonly Identifier NoiseSeed = Identifier.Parse("minecraft:terrain");

    private double XzMultiplier => BaseScale * XzScale;

    private double YMultiplier => BaseScale * YScale;

    public static NoiseStack CreateFbm(RandomSource random, int firstOctave, double smearScaleY, double valueFactor) {
        if (firstOctave > 0) {
            throw new ArgumentException("firstOctave>0");
        }

        int octaves = -firstOctave + 1;
        double factor = 1.0;
        valueFactor /= Math.Pow(2.0, octaves) - 1.0;
        NoiseStack.Builder stack = NoiseStack.CreateBuilder();
        for (int i = octaves - 1; i >= 0; i--) {
            stack.Add(new SmearedPerlinNoise(random, smearScaleY * factor), factor, (float)valueFactor);
            factor /= 2.0;
            valueFactor *= 2.0;
        }

        return stack.Build();
    }

    private static Interval ComputeFbmRange(int firstOctave, double smearScaleY, double valueFactor) {
        int octaves = -firstOctave + 1;
        double factor = 1.0;
        valueFactor /= Math.Pow(2.0, octaves) - 1.0;
        Interval range = Interval.OfExact(0.0F);
        for (int i = octaves - 1; i >= 0; i--) {
            range = Interval.Add(range, Interval.Mul(SmearedPerlinNoise.RangeFor(smearScaleY * factor), Interval.OfExact((float)valueFactor)));
            factor /= 2.0;
            valueFactor *= 2.0;
        }

        return range;
    }

    public IDensitySampler CompileSampler(ICompileContext context) => CompileSampler(context.CreateRandom(NoiseSeed));

    public IDensitySampler CompileSampler(RandomSource random) {
        double limitSmearScaleY = YMultiplier * SmearScaleMultiplier;
        double mainSmearScaleY = limitSmearScaleY / YFactor;
        NoiseStack minLimit = CreateFbm(random, LimitFirstOctave, limitSmearScaleY, LimitFactor);
        NoiseStack maxLimit = CreateFbm(random, LimitFirstOctave, limitSmearScaleY, LimitFactor);
        NoiseStack main = CreateFbm(random, MainFirstOctave, mainSmearScaleY, MainFactor);

        IDensitySampler minLimitNoise = new NoiseFunction.Sampler(minLimit, XzMultiplier, YMultiplier);
        IDensitySampler maxLimitNoise = new NoiseFunction.Sampler(maxLimit, XzMultiplier, YMultiplier);
        IDensitySampler mainNoise = new NoiseFunction.Sampler(main, XzMultiplier / XzFactor, YMultiplier / YFactor);
        IDensitySampler choice = new ClampFunction.Sampler(new BinaryFunction.ConstAddSampler(mainNoise, 0.5F), 0.0F, 1.0F);
        return new LerpFunction.Sampler(choice, minLimitNoise, maxLimitNoise);
    }

    public Interval Range => ComputeFbmRange(LimitFirstOctave, YMultiplier * SmearScaleMultiplier, LimitFactor);

    public int DomainAxes => DensityAxes.All;

    public IDensityFunction RewriteChildren(IDfRewriteRule rule) => this;
}
