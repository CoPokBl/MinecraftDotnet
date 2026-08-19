using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>CanyonWorldCarver</c>: the ravines.
/// </summary>
/// <remarks>
/// One walk per source chunk that starts one, with no rooms and no splitting, so a ravine is a single
/// unbranched gash. What makes it a gash rather than a wide tunnel is the cross section: the horizontal
/// term is multiplied by a width factor that is <b>drawn per height</b> and held for a run of heights,
/// and the vertical term is divided by six, so the shape is narrow, tall, and ridged down its walls.
/// <p/>
/// The rotations are damped harder than a cave's and nudged half as much, which is why a ravine runs
/// close to straight while a tunnel wanders.
/// </remarks>
public sealed class CanyonWorldCarver : WorldCarver<CanyonCarverConfiguration> {
    public override bool IsStartChunk(CanyonCarverConfiguration configuration, RandomSource random) {
        return random.NextFloat() <= configuration.Probability;
    }

    public override void Carve(CarvingContext context, CanyonCarverConfiguration configuration,
        RandomSource random, int sourceChunkX, int sourceChunkZ) {

        int maxDistance = (Range * 2 - 1) * 16;

        double x = sourceChunkX * 16 + random.NextInt(16);
        int y = configuration.Y.Sample(random, context.Heights);
        double z = sourceChunkZ * 16 + random.NextInt(16);

        float horizontalRotation = random.NextFloat() * (float)(Math.PI * 2);
        float verticalRotation = configuration.VerticalRotation.Sample(random);
        double yScale = configuration.YScale.Sample(random);
        float thickness = configuration.Shape.Thickness.Sample(random);
        int distance = (int)(maxDistance * configuration.Shape.DistanceFactor.Sample(random));

        DoCarve(context, configuration, random.NextLong(), x, y, z, thickness, horizontalRotation,
            verticalRotation, 0, distance, yScale);
    }

    private void DoCarve(CarvingContext context, CanyonCarverConfiguration configuration, long walkSeed,
        double x, double y, double z, float thickness, float horizontalRotation, float verticalRotation,
        int step, int distance, double yScale) {

        RandomSource random = new LegacyRandomSource(walkSeed);

        float[] widthFactorPerHeight = InitWidthFactors(context, configuration, random);

        // Neither the widths nor the context move once the walk has started, so the checker outlives
        // the step vanilla rebuilds it in.
        CarveSkipChecker skipChecker =
            (_, xd, yd, zd, blockY) => ShouldSkip(context, widthFactorPerHeight, xd, yd, zd, blockY);

        float yRota = 0.0f;
        float xRota = 0.0f;

        for (int currentStep = step; currentStep < distance; currentStep++) {
            double horizontalRadius = 1.5 + Mth.Sin(currentStep * (float)Math.PI / distance) * thickness;
            double verticalRadius = horizontalRadius * yScale;

            horizontalRadius *= configuration.Shape.HorizontalRadiusFactor.Sample(random);
            verticalRadius = UpdateVerticalRadius(configuration, random, verticalRadius, distance, currentStep);

            float xc = Mth.Cos(verticalRotation);
            float xs = Mth.Sin(verticalRotation);
            x += Mth.Cos(horizontalRotation) * xc;
            y += xs;
            z += Mth.Sin(horizontalRotation) * xc;

            verticalRotation *= 0.7f;
            verticalRotation += xRota * 0.05f;
            horizontalRotation += yRota * 0.05f;
            xRota *= 0.8f;
            yRota *= 0.5f;
            xRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 2.0f;
            yRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 4.0f;

            if (random.NextInt(4) == 0) {
                continue;
            }

            if (!CanReach(context.ChunkX, context.ChunkZ, x, z, currentStep, distance, thickness)) {
                return;
            }

            CarveEllipsoid(context, configuration, x, y, z, horizontalRadius, verticalRadius,
                (_, xd, yd, zd, blockY) => ShouldSkip(context, widthFactorPerHeight, xd, yd, zd, blockY));
        }
    }

    /// <summary>
    /// The width of the ravine at every height of the world, drawn once for the whole walk.
    /// </summary>
    /// <remarks>
    /// A new factor is drawn only where <c>widthSmoothness</c> says so, and the one before it is held
    /// otherwise, so the walls step in and out in bands rather than per block. The stored value is
    /// <b>squared</b>, since the shape test compares against a squared distance.
    /// <p/>
    /// Drawn for the full world height whatever part of it the ravine occupies, which keeps the draw
    /// count independent of where the ravine landed.
    /// </remarks>
    private static float[] InitWidthFactors(CarvingContext context, CanyonCarverConfiguration configuration,
        RandomSource random) {

        int depth = context.GenDepth;
        float[] widthFactorPerHeight = new float[depth];
        float widthFactor = 1.0f;

        for (int yIndex = 0; yIndex < depth; yIndex++) {
            if (yIndex == 0 || random.NextInt(configuration.Shape.WidthSmoothness) == 0) {
                widthFactor = 1.0f + random.NextFloat() * random.NextFloat();
            }

            widthFactorPerHeight[yIndex] = widthFactor * widthFactor;
        }

        return widthFactorPerHeight;
    }

    /// <summary>
    /// The vertical radius at one step: a taper towards both ends, then a jitter.
    /// </summary>
    /// <remarks>
    /// The distance and the step arrive as <b>floats</b>, so the ratio is a float division. The vanilla
    /// overworld's centre factor is zero, which makes the taper term vanish and the factor exactly the
    /// default, so a ravine there is the same height throughout and only the jitter varies it.
    /// </remarks>
    private static double UpdateVerticalRadius(CanyonCarverConfiguration configuration, RandomSource random,
        double verticalRadius, float distance, float currentStep) {

        float verticalMultiplier = 1.0f - Math.Abs(0.5f - currentStep / distance) * 2.0f;
        float factor = configuration.Shape.VerticalRadiusDefaultFactor
            + configuration.Shape.VerticalRadiusCenterFactor * verticalMultiplier;

        return factor * verticalRadius * Mth.RandomBetween(random, 0.75f, 1.0f);
    }

    private static bool ShouldSkip(CarvingContext context, float[] widthFactorPerHeight, double xd,
        double yd, double zd, int blockY) {

        int yIndex = blockY - context.MinGenY;
        return (xd * xd + zd * zd) * widthFactorPerHeight[yIndex - 1] + yd * yd / 6.0 >= 1.0;
    }
}
