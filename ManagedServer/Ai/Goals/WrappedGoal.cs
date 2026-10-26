namespace ManagedServer.Ai.Goals;

/// <summary>
/// A goal plus the priority it was registered at and whether it is currently running, vanilla's
/// <c>WrappedGoal</c>. The selector only ever deals in these; the goal itself never learns its own
/// priority, which is why the same goal instance can sit at different priorities on different mobs.
/// <p/>
/// It is itself a <see cref="Goal"/> upstream and forwards everything, so this keeps that shape.
/// </summary>
public class WrappedGoal(int priority, Goal goal) : Goal {
    public Goal Goal { get; } = goal;
    public int Priority { get; } = priority;
    public bool IsRunning { get; private set; }

    /// <summary>
    /// Whether <paramref name="other"/> may take this goal's flags. <b>Lower priority wins, and
    /// strictly</b>: two goals registered at the same number never preempt each other, so a mob with
    /// two goals at priority 3 runs whichever asked first until it gives up.
    /// </summary>
    public bool CanBeReplacedBy(WrappedGoal other) {
        return IsInterruptable && other.Priority < Priority;
    }

    public override bool CanUse() {
        return Goal.CanUse();
    }

    public override bool CanContinueToUse() {
        return Goal.CanContinueToUse();
    }

    public override bool IsInterruptable => Goal.IsInterruptable;

    public override bool RequiresUpdateEveryTick => Goal.RequiresUpdateEveryTick;

    public override GoalFlag Flags => Goal.Flags;

    public override void Start() {
        if (IsRunning) {
            return;
        }

        IsRunning = true;
        Goal.Start();
    }

    public override void Stop() {
        if (!IsRunning) {
            return;
        }

        IsRunning = false;
        Goal.Stop();
    }

    public override void Tick() {
        Goal.Tick();
    }

    public override string ToString() {
        return Goal.ToString();
    }
}
