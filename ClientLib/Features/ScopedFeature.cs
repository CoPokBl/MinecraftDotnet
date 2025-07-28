using Minecraft.Implementations.Client.Events;

namespace ClientLib.Features;

public abstract class ScopedFeature {
    public IFeatureScope Scope { get; set; } = null!;

    /// <summary>
    /// Controls the behaviour of the feature when it is registered while it is already registered.
    /// If true, then the existing feature will remain registered and the new one will not be added.
    /// If false, then an error will be thrown.
    /// </summary>
    public virtual bool IgnoreDuplicateRegistration => true;
    
    protected readonly List<Action> EventCancelers = [];

    public virtual void Register() {
        
    }

    public virtual void Unregister() {
        foreach (Action eventCanceler in EventCancelers) {
            eventCanceler();
        }
    }

    protected void AddEventListener<T>(Action<T> callback) where T : IClientEvent {
        EventCancelers.Add(Scope.Events.AddListener(callback));
    }

    protected void CallEvent<T>(T e) where T : IClientEvent {
        Scope.Events.CallEvent(e);
    }
}
