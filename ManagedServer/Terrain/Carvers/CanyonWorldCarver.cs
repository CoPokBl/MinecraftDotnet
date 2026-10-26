using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>CanyonWorldCarver.Shape</c>. <see cref="WidthSmoothness"/> is a divisor of a draw, not a
/// distance: the width factor is redrawn at one height in every <c>WidthSmoothness</c>.
/// </summary>
public sealed record CanyonShape(IFloatProvider DistanceFactor, IFloatProvider Thickness, int WidthSmoothness,
    IFloatProvider HorizontalRadiusFactor, float VerticalRadiusDefaultFactor, float VerticalRadiusCenterFactor, IFloatProvider YScale);

/// <summary>
/// <c>CanyonWorldCarver</c>: the ravines. One unbranched walk per start, its cross section a width
/// factor drawn per height and a vertical term divided by six, so it is narrow, tall and ridged.
/// </summary>
public sealed record CanyonWorldCarver(float Probability, HeightProvider Y, IFloatProvider VerticalRotation, CanyonShape Shape)
    : IWorldCarver {

    public bool IsStartChunk(RandomSource random) => random.NextFloat() <= Probability;

    public void Carve(GenerationHeightContext context, RandomSource random, int chunkX, int chunkZ, int sourceChunkX, int sourceChunkZ,
        CarvingMask output) {

        int maxDistance = (((IWorldCarver)this).Range * 2 - 1) * 16;
        double x = sourceChunkX * 16 + random.NextInt(16);
        int y = Y.Sample(random, context);
        double z = sourceChunkZ * 16 + random.NextInt(16);
        float horizontalRotation = random.NextFloat() * (float)(Math.PI * 2);
        float verticalRotation = VerticalRotation.Sample(random);
        double yScale = Shape.YScale.Sample(random);
        float thickness = Shape.Thickness.Sample(random);
        int distance = (int)(maxDistance * Shape.DistanceFactor.Sample(random));
        DoCarve(context, chunkX, chunkZ, random.NextLong(), x, y, z, thickness, horizontalRotation, verticalRotation, 0, distance,
            yScale, output);
    }

    private void DoCarve(GenerationHeightContext context, int chunkX, int chunkZ, long tunnelSeed, double x, double y, double z,
        float thickness, float horizontalRotation, float verticalRotation, int step, int distance, double yScale, CarvingMask output) {

        RandomSource random = new LegacyRandomSource(tunnelSeed);
        float[] widthFactorPerHeight = InitWidthFactors(context, random);
        CarveSkipChecker skipChecker = (xd, yd, zd, blockY) => ShouldSkip(context, widthFactorPerHeight, xd, yd, zd, blockY);
        float yRota = 0.0F;
        float xRota = 0.0F;

        for (int currentStep = step; currentStep < distance; currentStep++) {
            double horizontalRadius = 1.5 + Mth.Sin(currentStep * (float)Math.PI / distance) * thickness;
            double verticalRadius = horizontalRadius * yScale;
            horizontalRadius *= Shape.HorizontalRadiusFactor.Sample(random);
            verticalRadius = UpdateVerticalRadius(random, verticalRadius, distance, currentStep);
            float xc = Mth.Cos(verticalRotation);
            float xs = Mth.Sin(verticalRotation);
            x += Mth.Cos(horizontalRotation) * xc;
            y += xs;
            z += Mth.Sin(horizontalRotation) * xc;
            verticalRotation *= 0.7F;
            verticalRotation += xRota * 0.05F;
            horizontalRotation += yRota * 0.05F;
            xRota *= 0.8F;
            yRota *= 0.5F;
            xRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 2.0F;
            yRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 4.0F;
            if (random.NextInt(4) != 0) {
                if (!WorldCarver.CanReach(chunkX, chunkZ, x, z, currentStep, distance, thickness)) {
                    return;
                }

                WorldCarver.CarveEllipsoid(chunkX, chunkZ, x, y, z, horizontalRadius, verticalRadius, output, skipChecker);
            }
        }
    }

    /// <summary>Drawn for the full world height whatever part of it the ravine occupies; stored squared.</summary>
    private float[] InitWidthFactors(GenerationHeightContext context, RandomSource random) {
        int depth = context.GenDepth;
        float[] widthFactorPerHeight = new float[depth];
        float widthFactor = 1.0F;
        for (int yIndex = 0; yIndex < depth; yIndex++) {
            if (yIndex == 0 || random.NextInt(Shape.WidthSmoothness) == 0) {
                widthFactor = 1.0F + random.NextFloat() * random.NextFloat();
            }

            widthFactorPerHeight[yIndex] = widthFactor * widthFactor;
        }

        return widthFactorPerHeight;
    }

    /// <summary>The distance and the step arrive as floats, so the ratio is a float division.</summary>
    private double UpdateVerticalRadius(RandomSource random, double verticalRadius, float distance, float currentStep) {
        float verticalMultiplier = 1.0F - Math.Abs(0.5F - currentStep / distance) * 2.0F;
        float factor = Shape.VerticalRadiusDefaultFactor + Shape.VerticalRadiusCenterFactor * verticalMultiplier;
        return factor * verticalRadius * Mth.RandomBetween(random, 0.75F, 1.0F);
    }

    private static bool ShouldSkip(GenerationHeightContext context, float[] widthFactorPerHeight, double xd, double yd, double zd,
        int blockY) {

        int yIndex = blockY - context.MinGenY;
        return (xd * xd + zd * zd) * widthFactorPerHeight[yIndex - 1] + yd * yd / 6.0 >= 1.0;
    }
}
