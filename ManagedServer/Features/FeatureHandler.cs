using System.Reflection;
using ManagedServer.Events.Attributes;

namespace ManagedServer.Features;

public class FeatureHandler(IFeatureScope scope) {
    public readonly List<ScopedFeature> Features = [];
    public HashSet<Type> CallableEventTypes { get; } = [];
    
    public void AddFeature(ScopedFeature feature) {
        if (Features.Contains(feature)) {
            if (!feature.IgnoreDuplicateRegistration) {
                throw new InvalidOperationException($"Feature {feature.GetType().Name} is already registered.");
            }
            return;
        }
        
        CallsEventAttribute? callsEventAttribute = feature.GetType().GetCustomAttribute<CallsEventAttribute>();
        if (callsEventAttribute != null) {
            lock (CallableEventTypes) foreach (Type eventType in callsEventAttribute.EventTypes) {
                CallableEventTypes.Add(eventType);
            }
        }
        
        Features.Add(feature);
        feature.Scope = scope;
        feature.Register();
    }
    
    public T Feature<T>() where T : ScopedFeature {
        return (T)Features.First(f => f is T);
    }
    
    public ScopedFeature Feature(Type type) {
        return Features.First(f => f.GetType() == type);
    }
}
