namespace ManagedServer.Ai.Goals;

/// <summary>
/// What part of a mob a goal takes over while it runs, vanilla's <c>Goal.Flag</c>. Two goals wanting
/// the same part cannot run together, and that is the whole of how a mob's goals arbitrate: a goal
/// that claims nothing runs alongside everything.
/// <p/>
/// A flags enum rather than four separate locks on purpose. <see cref="GoalSelector"/> claims a goal's
/// flags all or nothing (vanilla's <c>goalCanBeReplacedForAllFlags</c>), so a goal that wants both
/// <see cref="Move"/> and <see cref="Look"/> and can only take one does not start at all.
/// </summary>
[Flags]
public enum GoalFlag {
    None = 0,

    /// <summary>Where the mob walks: the move control and the navigation.</summary>
    Move = 1 << 0,

    /// <summary>Where the mob looks: the look control.</summary>
    Look = 1 << 1,

    /// <summary>Whether the mob jumps: the jump control.</summary>
    Jump = 1 << 2,

    /// <summary>What the mob is fighting, i.e. <c>Mob.Target</c>.</summary>
    Target = 1 << 3
}
