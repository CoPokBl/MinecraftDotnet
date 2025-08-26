using ManagedServer.Entities.Types;
using ManagedServer.Features.Bundles;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Features;

public interface IFeatureScope {
    public EventNode<IServerEvent> Events { get; }
    public List<PlayerEntity> Players { get; }
    public ManagedMinecraftServer Server { get; }
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
    
    public static T Feature<T>(this IFeatureScope scope) where T : ScopedFeature {
        return scope.FeatureHandler.Feature<T>();
    }
    
    public static ScopedFeature Feature(this IFeatureScope scope, Type type) {
        return scope.FeatureHandler.Feature(type);
    }
}
