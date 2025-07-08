namespace ManagedServer;

public abstract class ScopedFeature {
    public IFeatureScope Scope { get; set; } = null!;

    public virtual void Register() {
        
    }

    public virtual void Unregister() {
        
    }
}
