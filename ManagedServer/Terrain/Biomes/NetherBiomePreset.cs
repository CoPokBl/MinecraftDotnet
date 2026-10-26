using Minecraft.Data.Biomes;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Biomes;

/// <summary>
/// <c>MultiNoiseBiomeSourceParameterList.Preset.NETHER</c>: the nether's five climate points.
/// </summary>
/// <remarks>
/// Transcribed for the same reason as <see cref="OverworldBiomeBuilder"/>: the datapack file names a
/// preset and the preset is code in the jar.
/// <p/>
/// Points rather than ranges, and only two of the six coordinates are ever non zero, so the nether's
/// biome is decided by temperature and humidity alone. Warped forest and basalt deltas carry an offset,
/// which is what keeps them rarer than the three that do not.
/// <p/>
/// Nothing here changes that this build's nether comes out as one biome: the table is right and the
/// two noises feeding it are not ported, which is written up on <c>VanillaTerrainGenerator.Nether</c>.
/// </remarks>
public static class NetherBiomePreset {
    public static List<(ClimateParameterPoint Point, Identifier Biome)> Build() {
        return [
            Point(0.0f, 0.0f, 0.0f, Biome.NetherWastes),
            Point(0.0f, -0.5f, 0.0f, Biome.SoulSandValley),
            Point(0.4f, 0.0f, 0.0f, Biome.CrimsonForest),
            Point(0.0f, 0.5f, 0.375f, Biome.WarpedForest),
            Point(-0.5f, 0.0f, 0.175f, Biome.BasaltDeltas)
        ];
    }

    /// <summary>
    /// <c>Climate.parameters</c>'s all-float overload, which makes every coordinate a point.
    /// </summary>
    private static (ClimateParameterPoint, Identifier) Point(float temperature, float humidity,
        float offset, IBiome biome) {

        ClimateParameter zero = ClimateParameter.Point(0.0f);

        return (new ClimateParameterPoint(ClimateParameter.Point(temperature),
            ClimateParameter.Point(humidity), zero, zero, zero, zero,
            ClimateParameter.Quantize(offset)), biome.Identifier);
    }
}
