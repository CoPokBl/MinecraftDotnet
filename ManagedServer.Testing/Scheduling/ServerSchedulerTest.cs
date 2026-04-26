using System.Reflection;
using ManagedServer.Events;
using ManagedServer.Scheduling;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Testing.Scheduling;

public class ServerSchedulerTest {
    private ManagedMinecraftServer _server = null!;
    private ServerScheduler _scheduler = null!;

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer();
        _server.LogAction = _ => { }; // suppress console output
        _scheduler = _server.Scheduler;
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    /// <summary>
    /// Sets the server's CurrentTick via reflection (it has a private setter).
    /// </summary>
    private void SetCurrentTick(ulong tick) {
        typeof(ManagedMinecraftServer)
            .GetProperty(nameof(ManagedMinecraftServer.CurrentTick))!
            .SetValue(_server, tick);
    }

    /// <summary>
    /// Fires a <see cref="ServerTickEvent"/> on the server's event node.
    /// </summary>
    private void FireTick() {
        _server.Events.CallEvent(new ServerTickEvent {
            Delta = TimeSpan.FromMilliseconds(50),
            TargetDelta = TimeSpan.FromMilliseconds(50),
            Server = _server,
        });
    }

    /// <summary>
    /// Advances the tick counter by the given amount, firing a tick event at each step.
    /// </summary>
    private void AdvanceTicks(int count) {
        for (int i = 0; i < count; i++) {
            ulong next = _server.CurrentTick + 1;
            SetCurrentTick(next);
            FireTick();
        }
    }

    // ── ScheduleTask(int ticks, Action) ─────────────────────────────────────

    [Test]
    public void ScheduleTask_Ticks_RunsAfterCorrectNumberOfTicks() {
        bool ran = false;
        _scheduler.ScheduleTask(3, () => ran = true);

        AdvanceTicks(2);
        Assert.That(ran, Is.False, "Should not run before target tick");

        AdvanceTicks(1);
        Assert.That(ran, Is.True, "Should run on the target tick");
    }

    [Test]
    public void ScheduleTask_ZeroTicks_RunsOnCurrentTick() {
        bool ran = false;
        _scheduler.ScheduleTask(0, () => ran = true);

        FireTick();
        Assert.That(ran, Is.True);
    }

    [Test]
    public void ScheduleTask_NegativeTicks_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _scheduler.ScheduleTask(-1, () => { }));
    }

    [Test]
    public void ScheduleTask_Ticks_ReturnsNonNullScheduledTask() {
        ScheduledTask task = _scheduler.ScheduleTask(5, () => { });
        Assert.That(task, Is.Not.Null);
    }

    [Test]
    public void ScheduleTask_Ticks_MultipleTasksSameTick() {
        int counter = 0;
        _scheduler.ScheduleTask(1, () => counter++);
        _scheduler.ScheduleTask(1, () => counter++);
        _scheduler.ScheduleTask(1, () => counter++);

        AdvanceTicks(1);
        Assert.That(counter, Is.EqualTo(3));
    }

    [Test]
    public void ScheduleTask_Ticks_DoesNotRunTwice() {
        int counter = 0;
        _scheduler.ScheduleTask(1, () => counter++);

        AdvanceTicks(1);
        AdvanceTicks(1);
        Assert.That(counter, Is.EqualTo(1));
    }

    // ── ScheduleNextTick ────────────────────────────────────────────────────

    [Test]
    public void ScheduleNextTick_RunsOnNextTick() {
        bool ran = false;
        _scheduler.ScheduleNextTick(() => ran = true);

        AdvanceTicks(1);
        Assert.That(ran, Is.True);
    }

    [Test]
    public void ScheduleNextTick_DoesNotRunOnCurrentTick() {
        bool ran = false;
        _scheduler.ScheduleNextTick(() => ran = true);

        FireTick(); // fire without advancing
        Assert.That(ran, Is.False);
    }

    // ── ScheduleRepeatingTask(int tickDelay, Func<bool>) ────────────────────

    [Test]
    public void ScheduleRepeatingTask_Ticks_RepeatsWhileReturningTrue() {
        int counter = 0;
        _scheduler.ScheduleRepeatingTask(1, () => {
            counter++;
            return counter < 3;
        });

        AdvanceTicks(5);
        Assert.That(counter, Is.EqualTo(3));
    }

    [Test]
    public void ScheduleRepeatingTask_Ticks_StopsWhenReturningFalse() {
        int counter = 0;
        _scheduler.ScheduleRepeatingTask(2, () => {
            counter++;
            return false;
        });

        AdvanceTicks(6);
        Assert.That(counter, Is.EqualTo(1));
    }

    [Test]
    public void ScheduleRepeatingTask_Ticks_RespectsTickDelay() {
        List<ulong> executedAtTicks = [];
        _scheduler.ScheduleRepeatingTask(3, () => {
            executedAtTicks.Add(_server.CurrentTick);
            return executedAtTicks.Count < 3;
        });

        AdvanceTicks(10);
        // Should have run at ticks 3, 6, 9
        Assert.That(executedAtTicks, Has.Count.EqualTo(3));
        Assert.That(executedAtTicks[1] - executedAtTicks[0], Is.EqualTo(3));
        Assert.That(executedAtTicks[2] - executedAtTicks[1], Is.EqualTo(3));
    }

    [Test]
    public void ScheduleRepeatingTask_NegativeTickDelay_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _scheduler.ScheduleRepeatingTask(-1, () => true));
    }

    [Test]
    public void ScheduleRepeatingTask_Ticks_CancelStopsRepeating() {
        int counter = 0;
        ScheduledTask task = _scheduler.ScheduleRepeatingTask(1, () => {
            counter++;
            return true;
        });

        AdvanceTicks(3);
        int afterThree = counter;

        task.Cancel();
        AdvanceTicks(3);
        Assert.That(counter, Is.EqualTo(afterThree), "Should not run after cancellation");
    }

    // ── ScheduleTask(TimeSpan, Action) ──────────────────────────────────────

    [Test]
    public async Task ScheduleTask_TimeSpan_RunsAfterDelay() {
        TaskCompletionSource tcs = new();
        _scheduler.ScheduleTask(TimeSpan.FromMilliseconds(50), () => tcs.SetResult());

        Task completed = await Task.WhenAny(tcs.Task, Task.Delay(2000));
        Assert.That(completed, Is.EqualTo(tcs.Task), "Task should have completed");
    }

    [Test]
    public async Task ScheduleTask_TimeSpan_CancelPreventsExecution() {
        bool ran = false;
        ScheduledTask task = _scheduler.ScheduleTask(TimeSpan.FromMilliseconds(200), () => ran = true);

        task.Cancel();
        await Task.Delay(400);
        Assert.That(ran, Is.False, "Cancelled task should not run");
        Assert.That(task.Cancelled, Is.True);
    }

    [Test]
    public async Task ScheduleTask_TimeSpan_ReturnsNonNullScheduledTask() {
        ScheduledTask task = _scheduler.ScheduleTask(TimeSpan.FromMilliseconds(100), () => { });
        Assert.That(task, Is.Not.Null);
        task.Cancel();
        await Task.Delay(10);
    }

    // ── ScheduleRepeatingTask(TimeSpan, Func<bool>) ────────────────────────

    [Test]
    public async Task ScheduleRepeatingTask_TimeSpan_RepeatsWhileReturningTrue() {
        int counter = 0;
        TaskCompletionSource tcs = new();
        _scheduler.ScheduleRepeatingTask(TimeSpan.FromMilliseconds(50), () => {
            counter++;
            if (counter >= 3) {
                tcs.TrySetResult();
                return false;
            }
            return true;
        });

        Task completed = await Task.WhenAny(tcs.Task, Task.Delay(3000));
        Assert.That(completed, Is.EqualTo(tcs.Task), "Should have completed 3 iterations");
        Assert.That(counter, Is.EqualTo(3));
    }

    [Test]
    public async Task ScheduleRepeatingTask_TimeSpan_StopsWhenReturningFalse() {
        int counter = 0;
        _scheduler.ScheduleRepeatingTask(TimeSpan.FromMilliseconds(50), () => {
            counter++;
            return false;
        });

        await Task.Delay(300);
        Assert.That(counter, Is.EqualTo(1));
    }

    [Test]
    public async Task ScheduleRepeatingTask_TimeSpan_CancelStopsRepeating() {
        int counter = 0;
        ScheduledTask task = _scheduler.ScheduleRepeatingTask(TimeSpan.FromMilliseconds(50), () => {
            counter++;
            return true;
        });

        await Task.Delay(200);
        int afterSome = counter;
        Assert.That(afterSome, Is.GreaterThan(0), "Should have run at least once");

        task.Cancel();
        await Task.Delay(200);
        Assert.That(counter, Is.EqualTo(afterSome), "Should not run after cancellation");
    }

    // ── Error handling ──────────────────────────────────────────────────────

    [Test]
    public void ScheduleTask_Ticks_ExceptionInActionIsHandled() {
        string? loggedError = null;
        _server.LogAction = msg => loggedError = msg;

        _scheduler.ScheduleTask(1, () => throw new InvalidOperationException("test error"));

        Assert.DoesNotThrow(() => AdvanceTicks(1));
        Assert.That(loggedError, Does.Contain("test error"));
    }

    [Test]
    public void ScheduleRepeatingTask_Ticks_ExceptionInActionIsHandled() {
        List<string> logs = [];
        _server.LogAction = msg => logs.Add(msg);

        _scheduler.ScheduleRepeatingTask(1, () => throw new InvalidOperationException("repeat error"));

        Assert.DoesNotThrow(() => AdvanceTicks(1));
        Assert.That(logs, Has.Some.Matches<string>(m => m.Contains("repeat error")));
    }

    // ── Slow task logging ───────────────────────────────────────────────────

    [Test]
    public void SlowTaskThresholdMs_DefaultIsFive() {
        Assert.That(_scheduler.SlowTaskThresholdMs, Is.EqualTo(5));
    }

    [Test]
    public void ScheduleTask_Ticks_SlowTaskIsLogged() {
        List<string> logs = [];
        _server.LogAction = msg => logs.Add(msg);
        _scheduler.SlowTaskThresholdMs = 1;

        _scheduler.ScheduleTask(1, () => Thread.Sleep(20));

        AdvanceTicks(1);
        Assert.That(logs, Has.Some.Matches<string>(m => m.Contains("SLOW TICK TASK")));
    }

    [Test]
    public void ScheduleTask_Ticks_SlowTaskLoggingDisabledWhenZero() {
        List<string> logs = [];
        _server.LogAction = msg => logs.Add(msg);
        _scheduler.SlowTaskThresholdMs = 0;

        _scheduler.ScheduleTask(1, () => Thread.Sleep(20));

        AdvanceTicks(1);
        Assert.That(logs, Has.None.Matches<string>(m => m.Contains("SLOW TICK TASK")));
    }

    // ── ScheduledTask properties ────────────────────────────────────────────

    [Test]
    public void ScheduledTask_CancelSetsCancelledFlag() {
        ScheduledTask task = _scheduler.ScheduleTask(100, () => { });
        Assert.That(task.Cancelled, Is.False);

        task.Cancel();
        Assert.That(task.Cancelled, Is.True);
    }

    [Test]
    public void ScheduledTask_HasDescription() {
        ScheduledTask task = _scheduler.ScheduleTask(1, () => { });
        Assert.That(task.Description, Is.Not.Null.And.Not.Empty);
    }

    // ── Cancellation (tick-based one-shot) ─────────────────────────────────

    [Test]
    public void ScheduleTask_Ticks_CancelPreventsExecution() {
        bool ran = false;
        ScheduledTask task = _scheduler.ScheduleTask(2, () => ran = true);

        task.Cancel();
        AdvanceTicks(3);
        Assert.That(ran, Is.False, "Cancelled tick task should not run");
        Assert.That(task.Cancelled, Is.True);
    }

    [Test]
    public void ScheduleNextTick_CancelPreventsExecution() {
        bool ran = false;
        ScheduledTask task = _scheduler.ScheduleNextTick(() => ran = true);

        task.Cancel();
        AdvanceTicks(2);
        Assert.That(ran, Is.False, "Cancelled next-tick task should not run");
    }

    [Test]
    public void ScheduleTask_Ticks_CancelAfterRunIsHarmless() {
        bool ran = false;
        ScheduledTask task = _scheduler.ScheduleTask(1, () => ran = true);

        AdvanceTicks(1);
        Assert.That(ran, Is.True);

        Assert.DoesNotThrow(() => task.Cancel());
    }

    [Test]
    public void ScheduleRepeatingTask_Ticks_CancelBeforeFirstRun() {
        int counter = 0;
        ScheduledTask task = _scheduler.ScheduleRepeatingTask(2, () => {
            counter++;
            return true;
        });

        task.Cancel();
        AdvanceTicks(6);
        Assert.That(counter, Is.EqualTo(0), "Should never run if cancelled before first tick");
    }

    [Test]
    public async Task ScheduleTask_TimeSpan_CancelAfterRunIsHarmless() {
        TaskCompletionSource tcs = new();
        ScheduledTask task = _scheduler.ScheduleTask(TimeSpan.FromMilliseconds(50), () => tcs.SetResult());

        await Task.WhenAny(tcs.Task, Task.Delay(2000));
        Assert.DoesNotThrow(() => task.Cancel());
    }

    [Test]
    public async Task ScheduleRepeatingTask_TimeSpan_CancelBeforeFirstRun() {
        int counter = 0;
        ScheduledTask task = _scheduler.ScheduleRepeatingTask(TimeSpan.FromMilliseconds(100), () => {
            counter++;
            return true;
        });

        task.Cancel();
        await Task.Delay(400);
        Assert.That(counter, Is.EqualTo(0), "Should never run if cancelled immediately");
    }

    // ── Edge cases ──────────────────────────────────────────────────────────

    [Test]
    public void ScheduleTask_Ticks_TaskAtExactCurrentTick_RunsOnNextFireTick() {
        // Schedule at 0 ticks when current tick is 0; should run on the next FireTick
        SetCurrentTick(5);
        bool ran = false;
        _scheduler.ScheduleTask(0, () => ran = true);

        // Fire tick at current tick (5) — task is scheduled at tick 5, so it should run
        FireTick();
        Assert.That(ran, Is.True);
    }

    [Test]
    public void MultipleScheduledTasks_DifferentTicks_RunInCorrectOrder() {
        List<int> order = [];
        _scheduler.ScheduleTask(3, () => order.Add(3));
        _scheduler.ScheduleTask(1, () => order.Add(1));
        _scheduler.ScheduleTask(2, () => order.Add(2));

        AdvanceTicks(3);
        Assert.That(order, Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void ScheduleRepeatingTask_Ticks_ZeroDelay_RunsEveryTick() {
        int counter = 0;
        _scheduler.ScheduleRepeatingTask(0, () => {
            counter++;
            return counter < 3;
        });

        // With 0 delay, it should run on every tick
        FireTick(); // runs once at tick 0 (scheduled at tick 0+0=0, current=0)
        Assert.That(counter, Is.GreaterThanOrEqualTo(1));
    }
}
