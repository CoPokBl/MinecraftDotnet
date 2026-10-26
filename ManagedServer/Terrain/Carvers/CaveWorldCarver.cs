using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>CaveWorldCarver</c>: the branching tunnels and the rooms some open with, the overworld's and the
/// nether's alike, which differ only in data.
/// </summary>
/// <remarks>
/// A tunnel splits once, at a point drawn from its own seed, into two leaving at right angles and
/// returns rather than continuing, so a tunnel is a binary tree. Every tunnel is reseeded from a long
/// its parent drew, so its shape does not depend on what was cut before it.
/// </remarks>
public sealed record CaveWorldCarver(float Probability, HeightProvider Y, IIntProvider Count, IFloatProvider Thickness,
    bool WeirdThicknessBias, IFloatProvider RoomVerticalRadiusMultiplier, IFloatProvider HorizontalRadiusMultiplier,
    IFloatProvider VerticalRadiusMultiplier, IFloatProvider StartVerticalRadiusMultiplier, IFloatProvider FloorLevel) : IWorldCarver {

    public bool IsStartChunk(RandomSource random) => random.NextFloat() <= Probability;

    public void Carve(GenerationHeightContext context, RandomSource random, int chunkX, int chunkZ, int sourceChunkX, int sourceChunkZ,
        CarvingMask output) {

        int maxDistance = (((IWorldCarver)this).Range * 2 - 1) << 4;
        int caveCount = Count.Sample(random);

        for (int cave = 0; cave < caveCount; cave++) {
            double x = sourceChunkX * 16 + random.NextInt(16);
            double y = Y.Sample(random, context);
            double z = sourceChunkZ * 16 + random.NextInt(16);
            double horizontalRadiusMultiplier = HorizontalRadiusMultiplier.Sample(random);
            double verticalRadiusMultiplier = VerticalRadiusMultiplier.Sample(random);
            double startVerticalRadiusMultiplier = StartVerticalRadiusMultiplier.Sample(random);
            double floorLevel = FloorLevel.Sample(random);
            CarveSkipChecker skipChecker = (xd, yd, zd, _) => ShouldSkip(xd, yd, zd, floorLevel);
            int tunnels = 1;
            if (random.NextInt(4) == 0) {
                double yScale = RoomVerticalRadiusMultiplier.Sample(random);
                float thickness = 1.0F + random.NextFloat() * 6.0F;
                CreateRoom(chunkX, chunkZ, x, y, z, thickness, yScale, output, skipChecker);
                tunnels += random.NextInt(4);
            }

            for (int i = 0; i < tunnels; i++) {
                float horizontalRotation = random.NextFloat() * (float)(Math.PI * 2);
                float verticalRotation = (random.NextFloat() - 0.5F) / 4.0F;
                float thickness = GetThickness(random);
                int distance = maxDistance - random.NextInt(maxDistance / 4);
                CreateTunnel(chunkX, chunkZ, random.NextLong(), x, y, z, horizontalRadiusMultiplier, verticalRadiusMultiplier,
                    thickness, horizontalRotation, verticalRotation, 0, distance, startVerticalRadiusMultiplier, output, skipChecker);
            }
        }
    }

    private float GetThickness(RandomSource random) {
        float thickness = Thickness.Sample(random);
        if (WeirdThicknessBias && random.NextInt(10) == 0) {
            thickness *= random.NextFloat() * random.NextFloat() * 3.0F + 1.0F;
        }

        return thickness;
    }

    /// <summary>The angle is cast to float before the sine table reads it, as in the jar.</summary>
    private static void CreateRoom(int chunkX, int chunkZ, double x, double y, double z, float thickness, double yScale,
        CarvingMask output, CarveSkipChecker skipChecker) {

        double horizontalRadius = 1.5 + Mth.Sin((float)(Math.PI / 2)) * thickness;
        double verticalRadius = horizontalRadius * yScale;
        WorldCarver.CarveEllipsoid(chunkX, chunkZ, x + 1.0, y, z, horizontalRadius, verticalRadius, output, skipChecker);
    }

    private static void CreateTunnel(int chunkX, int chunkZ, long tunnelSeed, double x, double y, double z,
        double horizontalRadiusMultiplier, double verticalRadiusMultiplier, float thickness, float horizontalRotation,
        float verticalRotation, int step, int distance, double yScale, CarvingMask output, CarveSkipChecker skipChecker) {

        RandomSource random = new LegacyRandomSource(tunnelSeed);
        int splitPoint = random.NextInt(distance / 2) + distance / 4;
        bool steep = random.NextInt(6) == 0;
        float yRota = 0.0F;
        float xRota = 0.0F;

        for (int currentStep = step; currentStep < distance; currentStep++) {
            double horizontalRadius = 1.5 + Mth.Sin((float)Math.PI * currentStep / distance) * thickness;
            double verticalRadius = horizontalRadius * yScale;
            float cosX = Mth.Cos(verticalRotation);
            x += Mth.Cos(horizontalRotation) * cosX;
            y += Mth.Sin(verticalRotation);
            z += Mth.Sin(horizontalRotation) * cosX;
            verticalRotation *= steep ? 0.92F : 0.7F;
            verticalRotation += xRota * 0.1F;
            horizontalRotation += yRota * 0.1F;
            xRota *= 0.9F;
            yRota *= 0.75F;
            xRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 2.0F;
            yRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 4.0F;
            if (currentStep == splitPoint && thickness > 1.0F) {
                CreateTunnel(chunkX, chunkZ, random.NextLong(), x, y, z, horizontalRadiusMultiplier, verticalRadiusMultiplier,
                    random.NextFloat() * 0.5F + 0.5F, horizontalRotation - (float)(Math.PI / 2), verticalRotation / 3.0F,
                    currentStep, distance, 1.0, output, skipChecker);
                CreateTunnel(chunkX, chunkZ, random.NextLong(), x, y, z, horizontalRadiusMultiplier, verticalRadiusMultiplier,
                    random.NextFloat() * 0.5F + 0.5F, horizontalRotation + (float)(Math.PI / 2), verticalRotation / 3.0F,
                    currentStep, distance, 1.0, output, skipChecker);
                return;
            }

            if (random.NextInt(4) != 0) {
                if (!WorldCarver.CanReach(chunkX, chunkZ, x, z, currentStep, distance, thickness)) {
                    return;
                }

                WorldCarver.CarveEllipsoid(chunkX, chunkZ, x, y, z, horizontalRadius * horizontalRadiusMultiplier,
                    verticalRadius * verticalRadiusMultiplier, output, skipChecker);
            }
        }
    }

    /// <summary>A sphere flattened off below the floor level, so a tunnel has something to walk on.</summary>
    private static bool ShouldSkip(double xd, double yd, double zd, double floorLevel) {
        return yd <= floorLevel || xd * xd + yd * yd + zd * zd >= 1.0;
    }
}
