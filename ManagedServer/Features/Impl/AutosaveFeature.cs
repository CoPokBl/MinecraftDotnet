using System.Collections.Concurrent;
using ManagedServer.Scheduling;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Saving;
using Minecraft.Implementations.Server.Terrain;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Saves the changed chunks of every world in scope on a timer: all of the server's worlds when
/// registered on the server, or only its own when registered on a world. A world without a
/// <see cref="World.Sink"/> is passed over.
/// </summary>
/// <remarks>
/// Only chunks something has written to or generated are encoded, so a world nobody is building in
/// costs a walk over the loaded set and nothing else, however large it is.
/// <p/>
/// One save per world runs at a time. A tick that arrives while a world's last save is still going
/// skips that world rather than queueing it: two sweeps over the same chunks would encode most of them
/// twice and the second would find them already clean. Each world is guarded on its own, so one slow
/// world does not cost the others their save.
/// </remarks>
public class AutosaveFeature(TimeSpan interval, SaveOptions? options = null) : ScopedFeature {
    private readonly ConcurrentDictionary<World, byte> _running = new();
    private ScheduledTask? _task;
    private Action? _stopped;

    /// <summary>
    /// Raised off the tick once a world's save finishes. Its failures have already been handed to
    /// <see cref="ManagedMinecraftServer.HandleError"/>.
    /// </summary>
    public event Action<World, SaveReport>? Saved;

    public override void Register() {
        _task = Scope.Server.Scheduler.ScheduleRepeatingTask(interval, () => {
            foreach (World world in ScopedWorlds()) {
                SaveWorld(world);
            }

            return true;
        });

        // A world scoped registration is not unregistered by a stop, and its timer would go on saving
        // into a sink the consumer may already have disposed.
        _stopped = Stop;
        Scope.Server.ServerStopped += _stopped;
    }

    public override void Unregister() {
        base.Unregister();
        Stop();
    }

    private void Stop() {
        _task?.Cancel();
        _task = null;

        if (_stopped != null) {
            Scope.Server.ServerStopped -= _stopped;
            _stopped = null;
        }
    }

    private World[] ScopedWorlds() {
        return Scope is World world ? [world] : Scope.Server.Worlds.ToArray();
    }

    private void SaveWorld(World world) {
        // Read once. A sink cleared between a check and the save would throw out of the timer, and the
        // scheduler stops a repeating task for good when it throws.
        IChunkSink? sink = world.Sink;
        if (sink == null || !_running.TryAdd(world, 0)) {
            return;
        }

        world.SaveAsync(sink, options).ContinueWith(save => {
            _running.TryRemove(world, out _);

            if (save.IsFaulted) {
                world.Server.HandleError(save.Exception);
                return;
            }

            foreach (ChunkSaveFailure failure in save.Result.Failures) {
                world.Server.HandleError(failure.Error);
            }

            try {
                Saved?.Invoke(world, save.Result);
            } catch (Exception e) {
                world.Server.HandleError(e);
            }
        }, TaskScheduler.Default);
    }
}
