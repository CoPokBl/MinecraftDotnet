namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Interface for terrain generators that work with GenerationUnits.
/// Similar to <see cref="ITerrainProvider"/> but provides a higher-level API
/// with support for cross-chunk modifications through forking.
/// </summary>
public interface ITerrainGenerator {
    /// <summary>
    /// Generates terrain for the given generation unit.
    /// </summary>
    /// <param name="unit">The generation unit to generate terrain for.</param>
    void Generate(IGenerationUnit unit);
}
