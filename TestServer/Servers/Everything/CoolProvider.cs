using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;

namespace TestServer.Servers.Everything;

/// <summary>
/// Rolling hills from a pair of sine waves. The simplest thing that is not flat, and what the
/// generation API's column path is meant to look like from a consumer's side.
/// </summary>
public class CoolProvider : IGenerator {
    private static readonly uint Stone = Block.Stone.StateId;

    public void Generate(IGenerationUnit unit) {
        for (int x = unit.AbsoluteStart.X; x < unit.AbsoluteEnd.X; x++) {
            for (int z = unit.AbsoluteStart.Z; z < unit.AbsoluteEnd.Z; z++) {
                // Everything below the surface, which for a column is one call and, for the sections
                // wholly under it, one palette write each.
                unit.Modifier.FillState(
                    new(x, unit.MinY, z),
                    new(x + 1, Math.Min(Height(x, z), unit.MaxY), z + 1),
                    Stone);
            }
        }
    }

    /// <summary>The surface height in game y.</summary>
    private static int Height(int x, int z) {
        const double len = 50;
        const double amp = 50;
        return (int)(amp*Math.Sin(x*(1/len)) + amp*Math.Sin(z*(1/len)) + 2*amp + 1);
    }
}
