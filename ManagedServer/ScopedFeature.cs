using Minecraft.Implementations.Server.Events;

namespace ManagedServer;

public abstract class ScopedFeature {
    public IFeatureScope Scope { get; set; } = null!;
    
    protected readonly List<Action> EventCancelers = [];

    public virtual void Register() {
        
    }

    public virtual void Unregister() {
        foreach (Action eventCanceler in EventCancelers) {
            eventCanceler();
        }
    }

    protected void AddEventListener<T>(Action<T> callback) where T : IServerEvent {
        EventCancelers.Add(Scope.Events.AddListener(callback));
    }

    protected void CallEvent<T>(T e) where T : IServerEvent {
        Scope.Events.CallEvent(e);
    }
}
