using System.Runtime.CompilerServices;
using Minecraft.Data.DimensionType;
using Minecraft.Data.Timelines;
using Minecraft.Registry;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary><c>EnvironmentAttributeSystem.addDefaultLayers</c>, over what a level is made of rather than a level.</summary>
public static class EnvironmentAttributeLevel {
    private static readonly ConditionalWeakTable<IDimensionType, BakedAttributeMap> DimensionAttributes = new();

    /// <summary>The dimension type's <c>attributes</c>, read once per dimension type.</summary>
    public static BakedAttributeMap Dimension(IDimensionType type, MinecraftRegistry registry) =>
        DimensionAttributes.GetValue(type, dimension => dimension.Attributes is { } attributes
            ? BakedAttributeMap.Of(EnvironmentAttributeMap.FromNbt(attributes, registry), registry)
            : BakedAttributeMap.Empty);

    /// <summary>
    /// The static layers, the dimension's and the biomes', then the dynamic ones: each of the dimension's timelines on
    /// its clock, and the weather where the level can have any, which <paramref name="weather"/> being null says it cannot.
    /// </summary>
    public static EnvironmentAttributeSystem.Builder AddDefaultLayers(this EnvironmentAttributeSystem.Builder builder, IDimensionType type,
        MinecraftRegistry registry, IEnvironmentBiomeSource biomes, IEnumerable<ITimeline> timelines, IClockSource clocks, IWeatherAccess? weather) {
        builder.AddConstantLayer(Dimension(type, registry));
        builder.AddBiomeLayer(registry.Biomes.All.Select(biome => BakedAttributeMap.Of(biome.Attributes, registry)), biomes);
        foreach (ITimeline timeline in timelines) {
            builder.AddTimelineLayer(BakedTimeline.Of(timeline, registry), clocks);
        }
        if (weather != null) {
            WeatherAttributes.AddBuiltinLayers(builder, weather);
        }
        return builder;
    }
}
