using ManagedServer.Ai.Goals;

namespace ManagedServer.Testing.Ai;

/// <summary>
/// <see cref="GoalSelector"/>, over the arbitration rules that decide what a mob does. Every case here
/// is one that looks like it could go the other way, and getting any of them backwards produces a mob
/// that behaves plausibly and wrongly.
/// </summary>
[TestFixture]
public class GoalSelectorTest {
    /// <summary>A goal that runs when told to and records what happened to it.</summary>
    private sealed class SpyGoal : Goal {
        public bool WantsToRun = true;
        public bool KeepRunning = true;
        public bool Interruptable = true;
        public bool EveryTick;

        public int Starts;
        public int Stops;
        public int Ticks;
        public int CanUseCalls;
        public int CanContinueCalls;

        public SpyGoal(GoalFlag flags) {
            SetFlags(flags);
        }

        public override bool CanUse() {
            CanUseCalls++;
            return WantsToRun;
        }

        public override bool CanContinueToUse() {
            CanContinueCalls++;
            return KeepRunning;
        }

        public override bool IsInterruptable => Interruptable;

        public override bool RequiresUpdateEveryTick => EveryTick;

        public override void Start() {
            Starts++;
        }

        public override void Stop() {
            Stops++;
        }

        public override void Tick() {
            Ticks++;
        }
    }

    private static bool IsRunning(GoalSelector selector, Goal goal) {
        foreach (WrappedGoal wrapped in selector.AvailableGoals) {
            if (wrapped.Goal == goal) {
                return wrapped.IsRunning;
            }
        }

        return false;
    }

    [Test]
    public void TestLowerPriorityPreempts() {
        GoalSelector selector = new();
        SpyGoal low = new(GoalFlag.Move);
        SpyGoal high = new(GoalFlag.Move);

        // Added in the order that makes the weaker one claim the flag first, so the eviction is what
        // is being measured rather than the insertion order.
        selector.AddGoal(5, low);
        selector.AddGoal(1, high);

        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(IsRunning(selector, high), Is.True, "the lower priority number should win");
            Assert.That(IsRunning(selector, low), Is.False);
            Assert.That(low.Stops, Is.EqualTo(1), "the evicted goal is stopped, not just dropped");
        });
    }

    /// <summary>
    /// <c>canBeReplacedBy</c> is a strict less than, so two goals at the same priority never take the
    /// flag off each other. A mob with two equal goals sticks with whichever got there first.
    /// </summary>
    [Test]
    public void TestEqualPriorityDoesNotPreempt() {
        GoalSelector selector = new();
        SpyGoal first = new(GoalFlag.Move);
        SpyGoal second = new(GoalFlag.Move);

        selector.AddGoal(3, first);
        selector.AddGoal(3, second);

        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(IsRunning(selector, first), Is.True);
            Assert.That(IsRunning(selector, second), Is.False);
            Assert.That(first.Stops, Is.Zero);
        });
    }

    /// <summary>
    /// An uninterruptable goal holds its flags whatever wants them, which is how something mid
    /// animation gets to finish.
    /// </summary>
    [Test]
    public void TestUninterruptableGoalHoldsItsFlag() {
        GoalSelector selector = new();
        SpyGoal holder = new(GoalFlag.Move) {
            Interruptable = false
        };
        SpyGoal challenger = new(GoalFlag.Move);

        selector.AddGoal(5, holder);
        selector.AddGoal(1, challenger);

        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(IsRunning(selector, holder), Is.True);
            Assert.That(IsRunning(selector, challenger), Is.False);
        });
    }

    /// <summary>
    /// The all-or-nothing claim. A goal wanting Move and Look, able to take Move but not Look, must not
    /// start <b>and must not take Move either</b>: modelling the flags as independent locks passes the
    /// first half of this and fails the second.
    /// </summary>
    [Test]
    public void TestPartialFlagClaimTakesNothing() {
        GoalSelector selector = new();
        SpyGoal moveHolder = new(GoalFlag.Move);
        SpyGoal lookHolder = new(GoalFlag.Look) {
            Interruptable = false
        };
        SpyGoal candidate = new(GoalFlag.Move | GoalFlag.Look);

        selector.AddGoal(5, moveHolder);
        selector.AddGoal(5, lookHolder);
        selector.AddGoal(1, candidate);

        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(IsRunning(selector, candidate), Is.False, "it cannot take Look, so it cannot start");
            Assert.That(IsRunning(selector, moveHolder), Is.True, "and must not have taken Move on the way");
            Assert.That(moveHolder.Stops, Is.Zero);
        });
    }

    /// <summary>
    /// A goal that cannot take its flags is never asked whether it wants to run. That ordering is what
    /// keeps the expensive half of <c>CanUse</c> (a target search, a pathfind) off the hot path.
    /// </summary>
    [Test]
    public void TestBlockedGoalIsNotAsked() {
        GoalSelector selector = new();
        SpyGoal holder = new(GoalFlag.Move) {
            Interruptable = false
        };

        SpyGoal candidate = new(GoalFlag.Move);

        selector.AddGoal(1, holder);
        selector.AddGoal(2, candidate);
        selector.Tick();

        Assert.That(candidate.CanUseCalls, Is.Zero,
            "the flag claim is checked before CanUse, so a blocked goal never runs its search");
    }

    [Test]
    public void TestGoalStopsWhenItCannotContinue() {
        GoalSelector selector = new();
        SpyGoal goal = new(GoalFlag.Move);

        selector.AddGoal(1, goal);
        selector.Tick();
        Assert.That(IsRunning(selector, goal), Is.True);

        goal.KeepRunning = false;
        goal.WantsToRun = false;
        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(IsRunning(selector, goal), Is.False);
            Assert.That(goal.Stops, Is.EqualTo(1));
        });
    }

    /// <summary>
    /// Disabling a flag stops a running goal without asking it, and stops a stopped one from starting.
    /// Both halves matter: the first is how a ridden mob loses control of its own movement.
    /// </summary>
    [Test]
    public void TestDisabledFlagBlocksStartAndContinue() {
        GoalSelector selector = new();
        SpyGoal goal = new(GoalFlag.Move);

        selector.AddGoal(1, goal);
        selector.Tick();
        Assert.That(IsRunning(selector, goal), Is.True);

        int askedBefore = goal.CanContinueCalls;
        selector.SetControlFlag(GoalFlag.Move, false);
        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(IsRunning(selector, goal), Is.False, "a running goal is stopped");
            Assert.That(goal.Stops, Is.EqualTo(1));
            Assert.That(goal.CanContinueCalls, Is.EqualTo(askedBefore),
                "and was not asked whether it wanted to keep going: the disable is not its decision");
        });

        selector.Tick();
        Assert.That(goal.Starts, Is.EqualTo(1), "and cannot start again while the flag is off");

        selector.SetControlFlag(GoalFlag.Move, true);
        selector.Tick();
        Assert.That(goal.Starts, Is.EqualTo(2));
    }

    /// <summary>
    /// The off tick ticks only the goals that asked for every tick. This is the other half of
    /// <c>Goal.AdjustedTickDelay</c>: get one right and the other wrong and every countdown in the
    /// goal library runs at half or double speed.
    /// </summary>
    [Test]
    public void TestOffTickOnlyTicksEveryTickGoals() {
        GoalSelector selector = new();
        SpyGoal halfRate = new(GoalFlag.Move);
        SpyGoal everyTick = new(GoalFlag.Look) {
            EveryTick = true
        };

        selector.AddGoal(1, halfRate);
        selector.AddGoal(1, everyTick);

        selector.Tick();
        Assert.Multiple(() => {
            Assert.That(halfRate.Ticks, Is.EqualTo(1));
            Assert.That(everyTick.Ticks, Is.EqualTo(1));
        });

        selector.TickRunningGoals(false);
        Assert.Multiple(() => {
            Assert.That(halfRate.Ticks, Is.EqualTo(1), "the half rate goal is skipped on the off tick");
            Assert.That(everyTick.Ticks, Is.EqualTo(2));
        });
    }

    /// <summary>
    /// A goal is considered in insertion order, not priority order, so a later-added better goal only
    /// wins by eviction. Adding the strong one first and the weak one second must leave the weak one
    /// out: it cannot evict, and it never gets a look in.
    /// </summary>
    [Test]
    public void TestIterationIsInsertionOrder() {
        GoalSelector selector = new();
        SpyGoal strongFirst = new(GoalFlag.Move);
        SpyGoal weakSecond = new(GoalFlag.Move);

        selector.AddGoal(1, strongFirst);
        selector.AddGoal(9, weakSecond);
        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(IsRunning(selector, strongFirst), Is.True);
            Assert.That(IsRunning(selector, weakSecond), Is.False);
        });
    }

    /// <summary>Removing a running goal stops it rather than leaving it holding a flag forever.</summary>
    [Test]
    public void TestRemovingARunningGoalStopsIt() {
        GoalSelector selector = new();
        SpyGoal goal = new(GoalFlag.Move);
        SpyGoal waiting = new(GoalFlag.Move);

        selector.AddGoal(1, goal);
        selector.AddGoal(2, waiting);
        selector.Tick();

        selector.RemoveGoal(goal);
        Assert.That(goal.Stops, Is.EqualTo(1));

        // The flag table still names the removed goal until the cleanup pass drops it, and the pass
        // drops it because it is no longer running. If it did not, nothing could ever take Move again.
        selector.Tick();
        Assert.That(IsRunning(selector, waiting), Is.True);
    }

    [Test]
    public void TestGoalsAreRestartedAfterTheyStop() {
        GoalSelector selector = new();
        SpyGoal goal = new(GoalFlag.Move);

        selector.AddGoal(1, goal);
        selector.Tick();

        goal.KeepRunning = false;
        selector.Tick();

        goal.KeepRunning = true;
        selector.Tick();

        Assert.Multiple(() => {
            Assert.That(goal.Starts, Is.EqualTo(2));
            Assert.That(IsRunning(selector, goal), Is.True);
        });
    }
}
