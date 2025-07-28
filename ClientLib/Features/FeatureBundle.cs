namespace ClientLib.Features;

public record FeatureBundle(params ScopedFeature[] Features) {
    
    public FeatureBundle With(ScopedFeature other) {
        return new FeatureBundle(Features.Append(other).ToArray());
    }
    
    public FeatureBundle Without(ScopedFeature other) {
        return new FeatureBundle(Features.Where(f => f != other).ToArray());
    }
    
    public FeatureBundle Without<T>() {
        return Without(typeof(T));
    }
    
    public FeatureBundle Without(Type type) {
        return new FeatureBundle(Features.Where(f => f.GetType() != type).ToArray());
    }
    
    public FeatureBundle With(FeatureBundle other) {
        return new FeatureBundle(Features.Concat(other.Features).ToArray());
    }
    
    public FeatureBundle Without(FeatureBundle other) {
        return new FeatureBundle(Features.Where(f => !other.Features.Contains(f)).ToArray());
    }
    
    public static FeatureBundle operator +(FeatureBundle bundle, ScopedFeature other) {
        return bundle.With(other);
    }
    
    public static FeatureBundle operator -(FeatureBundle bundle, ScopedFeature other) {
        return bundle.Without(other);
    }
    
    public static FeatureBundle operator -(FeatureBundle bundle, Type type) {
        return bundle.Without(type);
    }
    
    public static FeatureBundle operator +(FeatureBundle bundle, FeatureBundle other) {
        return bundle.With(other);
    }
    
    public static FeatureBundle operator -(FeatureBundle bundle, FeatureBundle other) {
        return bundle.Without(other);
    }
    
    public static implicit operator FeatureBundle(ScopedFeature feature) {
        return new FeatureBundle(feature);
    }
}
