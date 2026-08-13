using Minecraft.Schemas;

namespace ManagedServer.Ai.Goals;

/// <summary>
/// One thing a mob might be doing, vanilla's <c>Goal</c>. A goal is asked whether it wants to run
/// (<see cref="CanUse"/>), told when it starts and stops, and ticked while it runs. Everything about
/// which goal wins is <see cref="GoalSelector"/>'s, not the goal's.
/// <p/>
/// This is the extension point a game implementation builds its own behaviour on: subclass it, claim
/// the <see cref="Flags"/> the behaviour needs, and add it to a mob's <c>Goals</c>. Nothing about it
/// is vanilla specific.
/// </summary>
public abstract class Goal {
    /// <summary>
    /// Whether the goal wants to start now. Called for every goal that is not already running, every
    /// other tick, so it has to be cheap: this is the one method on the hot path.
    /// </summary>
    public abstract bool CanUse();

    /// <summary>
    /// Whether a running goal should keep running. Defaults to asking <see cref="CanUse"/> again,
    /// which is right for a goal with no state and wrong for most that have any.
    /// </summary>
    public virtual bool CanContinueToUse() {
        return CanUse();
    }

    /// <summary>
    /// Whether a higher priority goal may cut this one off. A goal that returns false holds its flags
    /// until it gives them up itself, which is how something mid animation finishes.
    /// </summary>
    public virtual bool IsInterruptable => true;

    public virtual void Start() { }

    public virtual void Stop() { }

    /// <summary>
    /// Whether the goal is ticked on the off tick as well. The selector runs at half rate, so a goal
    /// that needs every tick has to say so, and one that does not gets half as many
    /// <see cref="Tick"/> calls as ticks.
    /// </summary>
    public virtual bool RequiresUpdateEveryTick => false;

    public virtual void Tick() { }

    /// <summary>
    /// Which parts of the mob the goal takes over while it runs. Set it with <see cref="SetFlags"/>
    /// from the constructor, as vanilla's <c>setFlags</c> is called from there.
    /// </summary>
    public virtual GoalFlag Flags => _flags;

    private GoalFlag _flags = GoalFlag.None;

    /// <summary><c>Goal.setFlags</c>. Replaces the set rather than adding to it, as vanilla's does.</summary>
    protected void SetFlags(GoalFlag flags) {
        _flags = flags;
    }

    /// <summary>
    /// <c>Goal.adjustedTickDelay</c>: a cadence in ticks, corrected for the fact that this goal may
    /// only be ticked every other tick. A goal counting down to its next action has to put its
    /// literal through here or it fires at half the rate vanilla's does.
    /// </summary>
    protected int AdjustedTickDelay(int ticks) {
        return RequiresUpdateEveryTick ? ticks : ReducedTickDelay(ticks);
    }

    /// <summary><c>Goal.reducedTickDelay</c>.</summary>
    protected static int ReducedTickDelay(int ticks) {
        return Mth.PositiveCeilDiv(ticks, 2);
    }

    public override string ToString() {
        return GetType().Name;
    }
}
