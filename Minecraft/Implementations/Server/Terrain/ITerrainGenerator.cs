namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// Interface for terrain generators that work with GenerationUnits.
/// Extends <see cref="ITerrainProvider"/> to provide a higher-level API
/// with support for cross-chunk modifications through forking.
/// </summary>
public interface ITerrainGenerator : ITerrainProvider {
    /// <summary>
    /// Generates terrain for the given generation unit.
    /// The generation unit may span multiple chunks when GetChunks is called.
    /// </summary>
    /// <param name="unit">The generation unit to generate terrain for.</param>
    void Generate(IGenerationUnit unit);
    
    /// <summary>
    /// The minimum Y coordinate of the world (e.g., -64 for vanilla overworld).
    /// Used to convert between absolute and chunk-local coordinates.
    /// </summary>
    int MinY { get; }
}
