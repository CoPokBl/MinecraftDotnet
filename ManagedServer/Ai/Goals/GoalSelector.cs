namespace ManagedServer.Ai.Goals;

/// <summary>
/// The arbitrator, vanilla's <c>GoalSelector</c>. It holds a mob's goals, decides each tick which of
/// them run, and ticks those. A mob has two of these: one for what it is doing and one for what it is
/// fighting, and they arbitrate independently.
/// <p/>
/// Four rules here are easy to get wrong and all four change what a mob does:
/// <list type="bullet">
/// <item>Priority is a plain int and <b>lower wins, strictly</b>. Equal priorities never preempt.</item>
/// <item>Goals are considered in <b>insertion order</b>, never sorted by priority.</item>
/// <item>A goal claims <b>every</b> flag it wants or none of them.</item>
/// <item>Being evicted calls <see cref="Goal.Stop"/>, so a goal can stop without
/// <see cref="Goal.CanContinueToUse"/> ever returning false.</item>
/// </list>
/// </summary>
public class GoalSelector {
    /// <summary>
    /// The placeholder an unheld flag maps to, vanilla's <c>NO_GOAL</c>. Its priority is
    /// <see cref="int.MaxValue"/> so anything outranks it and it is never running, so the cleanup pass
    /// drops it out of the flag table.
    /// </summary>
    private static readonly WrappedGoal NoGoal = new(int.MaxValue, new NoGoalDummy());

    private sealed class NoGoalDummy : Goal {
        public override bool CanUse() {
            return false;
        }
    }

    /// <summary>Insertion ordered: <see cref="Tick"/> walks it in the order goals were added.</summary>
    private readonly List<WrappedGoal> _availableGoals = [];

    private readonly Dictionary<GoalFlag, WrappedGoal> _lockedFlags = [];

    private GoalFlag _disabledFlags = GoalFlag.None;

    /// <summary>The four flags, so the claim loop does not have to enumerate the enum every tick.</summary>
    private static readonly GoalFlag[] AllFlags = [GoalFlag.Move, GoalFlag.Look, GoalFlag.Jump, GoalFlag.Target];

    public IReadOnlyList<WrappedGoal> AvailableGoals => _availableGoals;

    /// <summary>
    /// Whether nothing has been added. <c>VanillaMobAiFeature</c> reads it to decide whether a mob has
    /// already been given behaviour, which is how adding a goal by hand suppresses the vanilla set.
    /// </summary>
    public bool IsEmpty => _availableGoals.Count == 0;

    /// <param name="priority">Lower runs in preference to higher. Ties never preempt each other.</param>
    public void AddGoal(int priority, Goal goal) {
        _availableGoals.Add(new WrappedGoal(priority, goal));
    }

    public void RemoveGoal(Goal goal) {
        RemoveAllGoals(candidate => candidate == goal);
    }

    public void RemoveAllGoals(Predicate<Goal> matches) {
        foreach (WrappedGoal wrapped in _availableGoals) {
            if (matches(wrapped.Goal) && wrapped.IsRunning) {
                wrapped.Stop();
            }
        }

        _availableGoals.RemoveAll(wrapped => matches(wrapped.Goal));
    }

    /// <summary>
    /// Turns a whole class of behaviour off. Vanilla uses it for a ridden mob, whose rider takes the
    /// movement; a game implementation can use it to freeze a mob without stripping its goals.
    /// </summary>
    public void SetControlFlag(GoalFlag flag, bool enabled) {
        if (enabled) {
            _disabledFlags &= ~flag;
        }
        else {
            _disabledFlags |= flag;
        }
    }

    /// <summary>
    /// The full pass: stop what should stop, start what can start, then tick everything running.
    /// Runs on every other tick, offset by entity id (see <c>Mob.ServerAiStep</c>).
    /// </summary>
    public void Tick() {
        // Cleanup. Note the two reasons a goal stops here are different: its flags being disabled is
        // not the goal's decision, and it never gets to say no to it.
        foreach (WrappedGoal wrapped in _availableGoals) {
            if (!wrapped.IsRunning) {
                continue;
            }

            if ((wrapped.Flags & _disabledFlags) != 0 || !wrapped.CanContinueToUse()) {
                wrapped.Stop();
            }
        }

        foreach (GoalFlag flag in AllFlags) {
            if (_lockedFlags.TryGetValue(flag, out WrappedGoal? holder) && !holder.IsRunning) {
                _lockedFlags.Remove(flag);
            }
        }

        // Start. Insertion order, and the flag claim is checked before CanUse is even asked, so a goal
        // that cannot take its flags is never given the chance to say it wants to run.
        foreach (WrappedGoal wrapped in _availableGoals) {
            if (wrapped.IsRunning || (wrapped.Flags & _disabledFlags) != 0) {
                continue;
            }

            if (!CanBeReplacedForAllFlags(wrapped) || !wrapped.CanUse()) {
                continue;
            }

            foreach (GoalFlag flag in AllFlags) {
                if ((wrapped.Flags & flag) == 0) {
                    continue;
                }

                if (_lockedFlags.TryGetValue(flag, out WrappedGoal? holder)) {
                    holder.Stop();
                }

                _lockedFlags[flag] = wrapped;
            }

            wrapped.Start();
        }

        TickRunningGoals(true);
    }

    /// <summary>
    /// Ticks the goals that are running and nothing else. The off tick calls this with
    /// <paramref name="tickAllRunning"/> false, which ticks only the goals that asked for every tick.
    /// </summary>
    public void TickRunningGoals(bool tickAllRunning) {
        foreach (WrappedGoal wrapped in _availableGoals) {
            if (wrapped.IsRunning && (tickAllRunning || wrapped.RequiresUpdateEveryTick)) {
                wrapped.Tick();
            }
        }
    }

    /// <summary>
    /// <c>goalCanBeReplacedForAllFlags</c>: all or nothing. A goal wanting Move and Look that can only
    /// evict the holder of Move does not start, and does not take Move either.
    /// </summary>
    private bool CanBeReplacedForAllFlags(WrappedGoal candidate) {
        foreach (GoalFlag flag in AllFlags) {
            if ((candidate.Flags & flag) == 0) {
                continue;
            }

            WrappedGoal holder = _lockedFlags.GetValueOrDefault(flag, NoGoal);
            if (!holder.CanBeReplacedBy(candidate)) {
                return false;
            }
        }

        return true;
    }
}
