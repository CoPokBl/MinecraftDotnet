using ManagedServer.Damage;
using ManagedServer.Interaction;
using ManagedServer.Placement;
using Minecraft.Implementations.Server.Events;
using Minecraft.Placement;

namespace ManagedServer.Features;

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

    protected void AddEventHandler<T>(Action<T> callback) where T : IServerEvent {
        EventCancelers.Add(Scope.Events.AddListener(callback));
    }
    
    protected void AddEventMutator<T>(Action<T> callback) where T : IServerEvent {
        EventCancelers.Add(Scope.Events.AddListener(callback, true));
    }

    protected void CallEvent<T>(T e) where T : IServerEvent {
        Scope.Events.CallEvent(e);
    }

    /// <summary>
    /// Registers a link in the server's damage reduction chain, scoped the same way the feature's
    /// listeners are: a world scoped feature only reduces hits taken inside its world. It comes back
    /// off with the rest of the feature on unregister.
    /// </summary>
    protected void AddDamageModifier(IDamageModifier modifier) {
        EventCancelers.Add(Scope.Server.DamagePipeline.Add(modifier, Scope));
    }

    /// <summary>
    /// Registers something that stops hits outright before the reductions run, scoped and unregistered
    /// the same way <see cref="AddDamageModifier"/> is. See <see cref="IDamageBlocker"/> for why
    /// blocking is not one of those.
    /// </summary>
    protected void AddDamageBlocker(IDamageBlocker blocker) {
        EventCancelers.Add(Scope.Server.DamagePipeline.AddBlocker(blocker, Scope));
    }

    /// <summary>
    /// Registers a rule for how a block is placed, scoped the same way the feature's listeners are,
    /// so a world scoped feature only changes placement inside its world. It comes back off with the
    /// rest of the feature on unregister.
    /// <p/>
    /// A rule for a vanilla class that already has one shadows it while it is registered, which is
    /// how a server changes what a stair does without touching the rule that came with the game.
    /// </summary>
    protected void AddPlacementRule(IBlockPlacementRule rule) {
        EventCancelers.Add(Scope.Server.BlockPlacementRules.Add(rule, Scope));
    }

    /// <summary>
    /// Registers a rule for what a block does when it is right clicked, scoped the same way the
    /// feature's listeners are, so a world scoped feature only changes interaction inside its world.
    /// It comes back off with the rest of the feature on unregister.
    /// <p/>
    /// A rule for a vanilla class that already has one shadows it while it is registered, the same
    /// bargain <see cref="AddPlacementRule"/> makes.
    /// </summary>
    protected void AddInteractionRule(IBlockInteractionRule rule) {
        EventCancelers.Add(Scope.Server.BlockInteractionRules.Add(rule, Scope));
    }
}
