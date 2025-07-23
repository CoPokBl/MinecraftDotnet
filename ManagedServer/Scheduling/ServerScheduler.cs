using System.Diagnostics.CodeAnalysis;
using ManagedServer.Events;

namespace ManagedServer.Scheduling;

public class ServerScheduler {
    // Used to stop the tasks from being garbage collected
    // ReSharper disable once CollectionNeverQueried.Local
    private readonly List<Timer> _timers = [];
    private readonly List<(ulong tick, ScheduledTask task)> _tickTasks = [];
    private readonly ManagedMinecraftServer _server;

    public ServerScheduler(ManagedMinecraftServer server) {
        _server = server;
        
        server.Events.AddListener<ServerTickEvent>(_ => {
            // Execute all next tick actions
            if (_tickTasks.Count == 0) return;
            
            ulong tick = _server.CurrentTick;
            _tickTasks.RemoveAll(schedule => {
                if (schedule.tick > tick) return false;
                schedule.task.Run();
                return true;
            });
        });
    }

    /// <summary>
    /// Schedule a task to run after <paramref name="delay"/>.
    /// </summary>
    /// <param name="delay">The delay before this task is executed.</param>
    /// <param name="action">The task to execute after the delay.</param>
    /// <returns>
    /// An action that cancels task. If the returned action is invoked, then the task will not be executed.
    /// </returns>
    public ScheduledTask ScheduleTask(TimeSpan delay, Action action) {
        Timer timer = null!;
        timer = new Timer(_ => {
            action();
            // ReSharper disable once AccessToModifiedClosure
            try {
                _timers.Remove(timer);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }, null, delay, Timeout.InfiniteTimeSpan);
        _timers.Add(timer);

        return new ScheduledTask(action, () => {
            timer.Dispose();
            _timers.Remove(timer);
        });
    }
    
    /// <summary>
    /// Schedule a task that repeats every <paramref name="delay"/> until
    /// the provided function returns false.
    /// </summary>
    /// <param name="delay">The time between each execution of the method.</param>
    /// <param name="action">
    /// The method to execute every <paramref name="delay"/>,
    /// it should return true to continue running or false to stop repeating.</param>
    /// <returns>An action that can be used</returns>
    public ScheduledTask ScheduleRepeatingTask(TimeSpan delay, Func<bool> action) {
        Timer timer = null!;

        // timer is supposed to be modified in the outer scope. that's the point.
        [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
        void StopTask() {
            timer.Dispose();
            _timers.Remove(timer);
        }

        timer = new Timer(_ => {
            if (action()) return;
            StopTask();
        }, null, delay, delay);
        _timers.Add(timer);

        return new ScheduledTask(() => action(), StopTask);
    }
    
    public ScheduledTask ScheduleNextTick(Action action) {
        return ScheduleTask(1, action);
    }
    
    public ScheduledTask ScheduleTask(int ticks, Action action) {
        if (ticks < 0) {
            throw new ArgumentOutOfRangeException(nameof(ticks), "Ticks must be non-negative.");
        }

        ScheduledTask task = new(action);
        _tickTasks.Add((_server.CurrentTick + (ulong)ticks, task));
        return task;
    }
}
