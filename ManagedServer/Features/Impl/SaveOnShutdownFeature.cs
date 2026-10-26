using ManagedServer.Worlds;
using ManagedServer.Worlds.Saving;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Saves a world when the server stops.
/// </summary>
/// <remarks>
/// Synchronously, and on the thread calling <c>Stop</c>, because the process may not outlive the
/// call: handing the work to the pool here is how a shutdown save silently does not happen.
/// <p/>
/// Hung off <c>ServerStopped</c> rather than off this feature's own unregister, since a world scoped
/// feature is not unregistered by a stop. An autosave still running at that point is waited for rather
/// than raced, because a world only saves once at a time.
/// </remarks>
public class SaveOnShutdownFeature(SaveOptions? options = null) : ScopedFeature {
    private Action? _handler;

    public override void Register() {
        World world = Scope as World ?? throw new InvalidOperationException(
            $"{nameof(SaveOnShutdownFeature)} is world scoped: register it on a World, not on the server.");

        _handler = () => {
            if (world.Sink is not { } sink) {
                return;
            }

            SaveReport report = world.Save(sink, options);
            world.Server.LogAction($"Saved world {world.DimensionId}: {report}");

            foreach (ChunkSaveFailure failure in report.Failures) {
                world.Server.HandleError(failure.Error);
            }
        };

        world.Server.ServerStopped += _handler;
    }

    public override void Unregister() {
        base.Unregister();

        if (_handler != null && Scope is World world) {
            world.Server.ServerStopped -= _handler;
            _handler = null;
        }
    }
}
