using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using ManagedServer.Events;

namespace ManagedServer.Scheduling;

public class ServerScheduler {
    // Used to stop the tasks from being garbage collected
    // ReSharper disable once CollectionNeverQueried.Local
    private readonly List<Timer> _timers = [];
    private readonly List<(ulong tick, ScheduledTask task)> _tickTasks = [];
    // Both lists are mutated from arbitrary threads (chunk loads schedule onto the tick
    // thread from the pool, timer callbacks remove themselves), so every access is guarded.
    private readonly Lock _tickTasksLock = new();
    private readonly Lock _timersLock = new();
    private readonly ManagedMinecraftServer _server;

    /// <summary>
    /// Tasks that take longer than this threshold (ms) are logged to <see cref="ManagedMinecraftServer.LogAction"/>.
    /// Set to 0 to disable slow-task logging.
    /// </summary>
    public int SlowTaskThresholdMs { get; set; } = 5;

    public ServerScheduler(ManagedMinecraftServer server) {
        _server = server;

        server.Events.AddListener<ServerTickEvent>(_ => {
            ulong tick = _server.CurrentTick;
            int threshold = SlowTaskThresholdMs;

            // Take the due tasks out of the list first, then run them with the lock released.
            // Running them inline would mean holding the lock across arbitrary user code, which
            // both re-enters this list (repeating tasks re-add themselves, tasks cancel tasks)
            // and takes other locks.
            List<ScheduledTask>? due = null;
            lock (_tickTasksLock) {
                if (_tickTasks.Count == 0) return;

                for (int i = _tickTasks.Count - 1; i >= 0; i--) {
                    (ulong scheduledTick, ScheduledTask task) = _tickTasks[i];
                    if (scheduledTick > tick) continue;
                    _tickTasks.RemoveAt(i);
                    if (task.Cancelled) continue;
                    (due ??= []).Add(task);
                }
            }

            if (due == null) return;

            // Undo the reverse iteration above so tasks run in the order they were scheduled.
            due.Reverse();
            foreach (ScheduledTask task in due) {
                if (task.Cancelled) continue;
                Stopwatch sw = Stopwatch.StartNew();
                try {
                    task.Run();
                }
                catch (Exception e) {
                    _server.HandleError(e);
                }
                sw.Stop();
                if (threshold > 0 && sw.ElapsedMilliseconds >= threshold) {
                    _server.LogAction($"[SLOW TICK TASK +{sw.ElapsedMilliseconds}ms] {task.Description}");
                }
            }
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
        // ReSharper disable AccessToModifiedClosure
        ScheduledTask task = new(action, () => {
            timer.Dispose();
            lock (_timersLock) _timers.Remove(timer);
        });

        timer = new Timer(_ => {
            // Disposing the timer doesn't recall a callback that has already been dispatched.
            if (task.Cancelled) return;
            action();
            try {
                lock (_timersLock) _timers.Remove(timer);
            }
            catch (Exception e) {
                _server.HandleError(e);
            }
        }, null, delay, Timeout.InfiniteTimeSpan);
        // ReSharper restore AccessToModifiedClosure
        lock (_timersLock) _timers.Add(timer);

        return task;
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
            lock (_timersLock) _timers.Remove(timer);
        }

        ScheduledTask task = new(() => action(), StopTask);

        timer = new Timer(_ => {
            // Disposing the timer doesn't recall a callback that has already been dispatched.
            if (task.Cancelled) return;
            try {
                if (action()) return;
            }
            catch (Exception e) {
                _server.HandleError(e);
            }
            StopTask();
        }, null, delay, delay);
        lock (_timersLock) _timers.Add(timer);

        return task;
    }
    
    /// <summary>
    /// Schedule a task that repeats every <paramref name="tickDelay"/> ticks until
    /// the provided function returns false.
    /// </summary>
    /// <param name="tickDelay">The ticks between each execution of the method.</param>
    /// <param name="action">
    /// The method to execute every <paramref name="tickDelay"/> ticks,
    /// it should return true to continue running or false to stop repeating.</param>
    /// <returns>An action that can be used</returns>
    [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
    public ScheduledTask ScheduleRepeatingTask(int tickDelay, Func<bool> action) {
        if (tickDelay < 0) {
            throw new ArgumentOutOfRangeException(nameof(tickDelay), "Tick delay must be non-negative.");
        }

        ScheduledTask task = null!;
        task = new ScheduledTask(() => {
            if (!action()) return;
            // Cancel() may have run while the action was executing; don't re-queue a dead task.
            if (task.Cancelled) return;
            lock (_tickTasksLock) {
                _tickTasks.Add((_server.CurrentTick + (ulong)tickDelay, task));
            }
        }, () => {
            // Remove the task from the list of scheduled tasks
            lock (_tickTasksLock) {
                _tickTasks.RemoveAll(t => t.task == task);
            }
        });

        lock (_tickTasksLock) {
            _tickTasks.Add((_server.CurrentTick + (ulong)tickDelay, task));
        }

        return task;
    }
    
    public ScheduledTask ScheduleNextTick(Action action) {
        return ScheduleTask(1, action);
    }
    
    public ScheduledTask ScheduleTask(int ticks, Action action) {
        if (ticks < 0) {
            throw new ArgumentOutOfRangeException(nameof(ticks), "Ticks must be non-negative.");
        }

        ScheduledTask task = null!;
        task = new ScheduledTask(action, () => {
            // ReSharper disable once AccessToModifiedClosure
            lock (_tickTasksLock) {
                _tickTasks.RemoveAll(t => t.task == task);
            }
        });
        lock (_tickTasksLock) {
            _tickTasks.Add((_server.CurrentTick + (ulong)ticks, task));
        }
        return task;
    }
}
