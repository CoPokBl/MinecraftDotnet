using Minecraft.Data.Generated;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>What <c>WeatherAttributes</c> reads off a level: <c>getRainLevel(1)</c>, and <c>getThunderLevel(1)</c>, which is already scaled by the rain.</summary>
public interface IWeatherAccess {
    float RainLevel { get; }
    float ThunderLevel { get; }
}

/// <summary><c>WeatherAttributes</c>: the rain's layer, then the thunder's, each blended in by how much of it there is.</summary>
public static class WeatherAttributes {
    /// <summary><c>Timelines.NIGHT_SKY_LIGHT_COLOR</c>.</summary>
    public static readonly int NightSkyLightColor = ArgbVectors.ColorFromFloat(1.0F, 0.48F, 0.48F, 1.0F);

    public static readonly BakedAttributeMap Rain = BakedAttributeMap.Build(map => map
        .Modify(EnvironmentAttribute.VisualSkyColor, AttributeModifiers.BlendToGrayRgb, new BlendToGray(0.6F, 0.75F))
        .Modify(EnvironmentAttribute.VisualFogColor, AttributeModifiers.MultiplyRgb, ArgbVectors.FromRgb24(ArgbVectors.ColorFromFloat(1.0F, 0.5F, 0.5F, 0.6F)))
        .Modify(EnvironmentAttribute.VisualCloudColor, AttributeModifiers.BlendToGrayArgb, new BlendToGray(0.24F, 0.5F))
        .Modify(EnvironmentAttribute.GameplaySkyLightLevel, AttributeModifiers.FloatAlphaBlend, new FloatWithAlpha(4.0F, 0.3125F))
        .Modify(EnvironmentAttribute.VisualSkyLightColor, AttributeModifiers.AlphaBlendRgb,
            ArgbVectors.FromArgb32(ArgbVectors.WithAlpha(0.3125F, NightSkyLightColor)))
        .Modify(EnvironmentAttribute.VisualSkyLightFactor, AttributeModifiers.FloatAlphaBlend, new FloatWithAlpha(0.24F, 0.3125F))
        .Set(EnvironmentAttribute.VisualStarBrightness, 0.0F)
        .Modify(EnvironmentAttribute.VisualSunriseSunsetColor, AttributeModifiers.MultiplyArgb,
            ArgbVectors.FromArgb32(ArgbVectors.ColorFromFloat(1.0F, 0.5F, 0.5F, 0.6F)))
        .Set(EnvironmentAttribute.GameplayBeesStayInHive, true));

    public static readonly BakedAttributeMap Thunder = BakedAttributeMap.Build(map => map
        .Modify(EnvironmentAttribute.VisualSkyColor, AttributeModifiers.BlendToGrayRgb, new BlendToGray(0.24F, 0.94F))
        .Modify(EnvironmentAttribute.VisualFogColor, AttributeModifiers.MultiplyRgb, ArgbVectors.FromRgb24(ArgbVectors.ColorFromFloat(1.0F, 0.25F, 0.25F, 0.3F)))
        .Modify(EnvironmentAttribute.VisualCloudColor, AttributeModifiers.BlendToGrayArgb, new BlendToGray(0.095F, 0.94F))
        .Modify(EnvironmentAttribute.GameplaySkyLightLevel, AttributeModifiers.FloatAlphaBlend, new FloatWithAlpha(4.0F, 0.52734375F))
        .Modify(EnvironmentAttribute.VisualSkyLightColor, AttributeModifiers.AlphaBlendRgb,
            ArgbVectors.FromArgb32(ArgbVectors.WithAlpha(0.52734375F, NightSkyLightColor)))
        .Modify(EnvironmentAttribute.VisualSkyLightFactor, AttributeModifiers.FloatAlphaBlend, new FloatWithAlpha(0.24F, 0.52734375F))
        .Set(EnvironmentAttribute.VisualStarBrightness, 0.0F)
        .Modify(EnvironmentAttribute.VisualSunriseSunsetColor, AttributeModifiers.MultiplyArgb,
            ArgbVectors.FromArgb32(ArgbVectors.ColorFromFloat(1.0F, 0.25F, 0.25F, 0.3F)))
        .Set(EnvironmentAttribute.GameplayBeesStayInHive, true));

    public static void AddBuiltinLayers(EnvironmentAttributeSystem.Builder system, IWeatherAccess weatherAccess) {
        AddLayer(system, weatherAccess, EnvironmentAttribute.VisualSkyColor);
        AddLayer(system, weatherAccess, EnvironmentAttribute.VisualFogColor);
        AddLayer(system, weatherAccess, EnvironmentAttribute.VisualCloudColor);
        AddLayer(system, weatherAccess, EnvironmentAttribute.GameplaySkyLightLevel);
        AddLayer(system, weatherAccess, EnvironmentAttribute.VisualSkyLightColor);
        AddLayer(system, weatherAccess, EnvironmentAttribute.VisualSkyLightFactor);
        AddLayer(system, weatherAccess, EnvironmentAttribute.VisualStarBrightness);
        AddLayer(system, weatherAccess, EnvironmentAttribute.VisualSunriseSunsetColor);
        AddLayer(system, weatherAccess, EnvironmentAttribute.GameplayBeesStayInHive);
    }

    private static void AddLayer<T>(EnvironmentAttributeSystem.Builder system, IWeatherAccess weatherAccess, EnvironmentAttribute<T> attribute) {
        AttributeMapEntry<T>? rainEntry = Rain.Get(attribute);
        AttributeMapEntry<T>? thunderEntry = Thunder.Get(attribute);
        system.AddTimeBasedLayer(attribute, (result, _) => {
            float thunderLevel = weatherAccess.ThunderLevel;
            float rainLevel = weatherAccess.RainLevel - thunderLevel;
            if (rainEntry != null && rainLevel > 0.0F) {
                T rainValue = rainEntry.ApplyModifier(result);
                result = attribute.Type.StateChangeLerp(rainLevel, result, rainValue);
            }
            if (thunderEntry != null && thunderLevel > 0.0F) {
                T thunderValue = thunderEntry.ApplyModifier(result);
                result = attribute.Type.StateChangeLerp(thunderLevel, result, thunderValue);
            }
            return result;
        });
    }
}
