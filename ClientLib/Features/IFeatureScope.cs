using Minecraft.Implementations.Client.Events;
using Minecraft.Implementations.Events;

namespace ClientLib.Features;

public interface IFeatureScope {
    public EventNode<IClientEvent> Events { get; }
    public MinecraftClient Client { get; }
    public FeatureHandler FeatureHandler { get; }
}

public static class FeatureScopeExtensions {
    
    public static void AddFeatures(this IFeatureScope scope, params FeatureBundle[] bundles) {
        foreach (FeatureBundle bundle in bundles) {
            foreach (ScopedFeature feature in bundle.Features) {
                scope.AddFeature(feature);
            }
        }
    }

    public static void AddFeature(this IFeatureScope scope, ScopedFeature feature) {
        scope.FeatureHandler.AddFeature(feature);
    }
}
