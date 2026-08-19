using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.BlockSumoFFA;

/// <summary>
/// A single disc of copper to knock each other off.
/// </summary>
/// <remarks>
/// Writes the disc rather than asking about every position in the chunk and looking each one up, and
/// in game y rather than protocol y.
/// </remarks>
public class BlockSumoMapProvider(int radius) : IGenerator {
    private static readonly uint PlatformBlock = Block.RawCopperBlock.StateId;

    /// <summary>Where the disc sits, in game y.</summary>
    private const int PlatformY = -4;

    public void Generate(IGenerationUnit unit) {
        if (PlatformY < unit.AbsoluteStart.Y || PlatformY >= unit.AbsoluteEnd.Y) {
            return;
        }

        Vec3<int> start = unit.AbsoluteStart;
        Vec3<int> end = unit.AbsoluteEnd;

        int minX = Math.Max(-radius, start.X), maxX = Math.Min(radius, end.X);
        int minZ = Math.Max(-radius, start.Z), maxZ = Math.Min(radius, end.Z);

        for (int x = minX; x < maxX; x++) {
            for (int z = minZ; z < maxZ; z++) {
                if (new Vec3<int>(x, 0, z).DistanceTo(Vec3<int>.Zero) > radius) {
                    continue;
                }

                unit.Modifier.SetBlockState(x, PlatformY, z, PlatformBlock);
            }
        }
    }
}
