using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>WorldCarver</c>: a carver read from <c>worldgen/carver</c>, and the shared ellipsoid cutter every
/// shape is built from.
/// </summary>
/// <remarks>
/// A carver is a walk that cuts an ellipsoid of the chunk at each step it reaches. Every chunk within
/// eight replays its own carvers over this one, because a tunnel that started there may reach here;
/// <see cref="CanReach"/> and the distance test at the top of <see cref="CarveEllipsoid"/> are what
/// keep that affordable.
/// </remarks>
public interface IWorldCarver {
    /// <summary>How many chunks out a carver may reach. Every carver's is four.</summary>
    int Range => 4;

    bool IsStartChunk(RandomSource random);

    /// <summary>Runs one source chunk's carver over the chunk being generated, marking the mask.</summary>
    void Carve(GenerationHeightContext context, RandomSource random, int chunkX, int chunkZ, int sourceChunkX, int sourceChunkZ,
        CarvingMask output);
}

/// <summary>Whether a position in an ellipsoid's bounding box is outside the shape itself.</summary>
public delegate bool CarveSkipChecker(double xd, double yd, double zd, int blockY);

/// <summary>The static half of vanilla's <c>WorldCarver</c>.</summary>
public static class WorldCarver {
    /// <summary>
    /// Marks one ellipsoid. The y loop is top down and excludes its lower bound, which is off by one
    /// against the x and z loops as upstream.
    /// </summary>
    public static void CarveEllipsoid(int chunkX, int chunkZ, double x, double y, double z, double horizontalRadius,
        double verticalRadius, CarvingMask output, CarveSkipChecker skipChecker) {

        double centerX = chunkX * 16 + 8;
        double centerZ = chunkZ * 16 + 8;
        double maxDelta = 16.0 + horizontalRadius * 2.0;
        if (Math.Abs(x - centerX) > maxDelta || Math.Abs(z - centerZ) > maxDelta) {
            return;
        }

        int chunkMinX = chunkX * 16;
        int chunkMinZ = chunkZ * 16;
        int minXIndex = Math.Max(Mth.Floor(x - horizontalRadius) - chunkMinX - 1, 0);
        int maxXIndex = Math.Min(Mth.Floor(x + horizontalRadius) - chunkMinX, 15);
        int minY = Math.Max(Mth.Floor(y - verticalRadius) - 1, output.MinY);
        int maxY = Math.Min(Mth.Floor(y + verticalRadius) + 1, output.MaxY);
        int minZIndex = Math.Max(Mth.Floor(z - horizontalRadius) - chunkMinZ - 1, 0);
        int maxZIndex = Math.Min(Mth.Floor(z + horizontalRadius) - chunkMinZ, 15);

        for (int xIndex = minXIndex; xIndex <= maxXIndex; xIndex++) {
            double xd = (chunkMinX + xIndex + 0.5 - x) / horizontalRadius;
            for (int zIndex = minZIndex; zIndex <= maxZIndex; zIndex++) {
                double zd = (chunkMinZ + zIndex + 0.5 - z) / horizontalRadius;
                if (xd * xd + zd * zd >= 1.0) {
                    continue;
                }

                for (int worldY = maxY; worldY > minY; worldY--) {
                    double yd = (worldY - 0.5 - y) / verticalRadius;
                    if (!skipChecker(xd, yd, zd, worldY)) {
                        output.Carve(xIndex, worldY, zIndex);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Whether a walk could still touch the chunk if it went straight at it from now on, which is what
    /// turns 289 replayed chunks of carvers into a handful that do any work.
    /// </summary>
    public static bool CanReach(int chunkX, int chunkZ, double x, double z, int currentStep, int totalSteps, float thickness) {
        double xd = x - (chunkX * 16 + 8);
        double zd = z - (chunkZ * 16 + 8);
        double remaining = totalSteps - currentStep;
        double reach = thickness + 2.0F + 16.0F;
        return xd * xd + zd * zd - remaining * remaining <= reach * reach;
    }
}
