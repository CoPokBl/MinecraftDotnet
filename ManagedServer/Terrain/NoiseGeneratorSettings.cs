using ManagedServer.Terrain.Material;

namespace ManagedServer.Terrain;

/// <summary>
/// The vertical extent of a dimension's terrain, vanilla's <c>NoiseSettings</c>. Cell sizes are no
/// longer here: each <c>interpolated</c> node carries its own.
/// </summary>
public sealed record NoiseSettings(int MinY, int Height) {
    /// <summary><c>clampToHeightAccessor</c>: trimmed to a world shallower than the dimension.</summary>
    public NoiseSettings ClampToWorld(int worldMinY, int worldHeight) {
        int newMinY = Math.Max(MinY, worldMinY);
        int newHeight = Math.Min(MinY + Height, worldMinY + worldHeight) - newMinY;
        return new NoiseSettings(newMinY, newHeight);
    }
}

/// <summary>
/// Everything one dimension's noise terrain is described by, vanilla's <c>NoiseGeneratorSettings</c>
/// and the contents of a <c>worldgen/noise_settings</c> file.
/// </summary>
/// <param name="Aquifers">Null for the disabled aquifer.</param>
public sealed record NoiseGeneratorSettings(
    NoiseSettings NoiseSettings,
    uint DefaultBlock,
    uint DefaultFluid,
    NoiseRouter NoiseRouter,
    IMaterialRule MaterialRule,
    int SeaLevel,
    bool DisableMobGeneration,
    AquiferConfig? Aquifers,
    bool UseLegacyRandomSource);
