using ManagedServer.Worlds;
using Minecraft.Implementations.Server.Terrain;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Gives a world somewhere to save to. On its own it saves nothing and never will: it sets
/// <see cref="World.Sink"/> and stops, so <c>world.SaveAsync()</c> has a destination and a consumer
/// decides when to call it.
/// </summary>
/// <remarks>
/// When to save is a separate registration on purpose. <see cref="AutosaveFeature"/> and
/// <see cref="SaveOnShutdownFeature"/> are each one policy, and a server that wants a save only when
/// its own round ends registers neither.
/// <p/>
/// A world never takes its sink from its terrain provider, so a store the world also loads from is
/// handed over here like any other.
/// </remarks>
public class WorldPersistenceFeature(IChunkSink sink) : ScopedFeature {
    private IChunkSink? _previous;

    public IChunkSink Sink => sink;

    public override void Register() {
        World world = RequireWorld();
        _previous = world.Sink;
        world.Sink = sink;
    }

    public override void Unregister() {
        base.Unregister();

        if (Scope is World world) {
            world.Sink = _previous;
        }
    }

    private World RequireWorld() {
        return Scope as World ?? throw new InvalidOperationException(
            $"{nameof(WorldPersistenceFeature)} is world scoped: register it on a World, not on the server.");
    }
}
