using ManagedServer.Terrain.Surface;

namespace ManagedServer.Terrain;

/// <summary>
/// The shape of a dimension's noise grid, vanilla's <c>NoiseSettings</c>.
/// </summary>
/// <remarks>
/// <paramref name="SizeHorizontal"/> and <paramref name="SizeVertical"/> are in quarters, so the
/// overworld's 1 and 2 mean a cell 4 blocks wide and 8 tall. Density is sampled at cell corners and
/// interpolated between them, so those two numbers set both how much detail terrain has and how much
/// generating it costs.
/// </remarks>
public sealed record NoiseSettings(int MinY, int Height, int SizeHorizontal, int SizeVertical) {
    public int CellWidth => SizeHorizontal * 4;

    public int CellHeight => SizeVertical * 4;

    /// <summary>
    /// Trimmed to a world that is shallower than the dimension the settings were written for, so a
    /// generator does not try to fill sections that do not exist.
    /// </summary>
    public NoiseSettings ClampToWorld(int worldMinY, int worldHeight) {
        int newMinY = Math.Max(MinY, worldMinY);
        int newHeight = Math.Min(MinY + Height, worldMinY + worldHeight) - newMinY;
        return new NoiseSettings(newMinY, newHeight, SizeHorizontal, SizeVertical);
    }
}

/// <summary>
/// Everything one dimension's noise terrain is described by, vanilla's <c>NoiseGeneratorSettings</c>
/// and the contents of a <c>worldgen/noise_settings</c> file.
/// </summary>
/// <remarks>
/// <see cref="DefaultBlock"/> is not decoration: the surface rules only replace blocks equal to it, so
/// changing it without changing them produces terrain the rules never touch.
/// </remarks>
public sealed record NoiseGeneratorSettings(
    NoiseSettings NoiseSettings,
    uint DefaultBlock,
    uint DefaultFluid,
    NoiseRouter NoiseRouter,
    ISurfaceRuleSource SurfaceRule,
    int SeaLevel,
    bool AquifersEnabled,
    bool OreVeinsEnabled,
    bool UseLegacyRandomSource);
