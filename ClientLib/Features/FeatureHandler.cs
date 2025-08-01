using System.Reflection;
using ClientLib.Events.Attributes;

namespace ClientLib.Features;

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
}
