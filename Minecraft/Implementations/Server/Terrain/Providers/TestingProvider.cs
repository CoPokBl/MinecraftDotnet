using Minecraft.Data.Generated;

namespace Minecraft.Implementations.Server.Terrain.Providers;

/// <summary>A cone of waterlogged barriers around the origin, for benchmarking and eyeballing.</summary>
public class TestingProvider : PerBlockTerrainProvider {
    /// <summary>
    /// Resolved once: reading <c>.StateId</c> off a <c>with</c> expression inside
    /// <see cref="GetBlock"/> would allocate a record for every position in the chunk.
    /// </summary>
    private static readonly uint WaterloggedBarrier = (Block.Barrier with { Waterlogged = true }).StateId;

    public override uint GetBlock(int x, int y, int z) {
        int height = (int)Math.Sqrt(x*x + z*z);
        return y >= height ? 0 : WaterloggedBarrier;
    }
}
