using ManagedServer.Entities.Types;
using ManagedServer.Features;

namespace ManagedServer.Damage;

/// <summary>
/// The reduction chain <see cref="LivingEntity.Damage(DamageSource, float)"/> runs a hit through,
/// vanilla's <c>LivingEntity.actuallyHurt</c> split into the parts a feature can own.
/// <p/>
/// There is one per server and it always exists, because damage is not optional the way flowing
/// water is: a server with nowhere to send a hit is not a configuration, it is damage silently doing
/// nothing. What <b>is</b> optional is every link in it. An empty pipeline deals hits whole, which is
/// what most minigames want, and registering <c>ArmourFeature</c> is what makes armour count.
/// <p/>
/// Modifiers run in <see cref="DamageStage"/> order, and in registration order within a stage. That
/// is enough ordering because the stages are the only place vanilla's order is load bearing; see
/// <see cref="DamageStage"/> for why.
/// </summary>
public class DamagePipeline {
    private readonly List<Entry> _entries = [];

    /// <summary>
    /// Read without a lock on the damage path, replaced wholesale under one when the list changes,
    /// so a modifier registering another from inside a hit cannot break the walk.
    /// </summary>
    private Entry[] _snapshot = [];

    private readonly List<BlockerEntry> _blockers = [];
    private BlockerEntry[] _blockerSnapshot = [];

    private static readonly DamageStage[] Stages = Enum.GetValues<DamageStage>();

    /// <summary>
    /// Adds a modifier and returns the action that takes it back off, in the shape
    /// <c>EventNode.AddListener</c> uses. Prefer <c>ScopedFeature.AddDamageModifier</c>, which calls
    /// this with the feature's own scope and unregisters it along with the feature's listeners.
    /// <p/>
    /// A null <paramref name="scope"/> applies the modifier to every entity on the server. A world or
    /// entity scope applies it only to hits on entities inside it, so a per world armour rule stays
    /// in its world.
    /// </summary>
    public Action Add(IDamageModifier modifier, IFeatureScope? scope = null) {
        Entry entry = new(modifier, scope);
        lock (_entries) {
            _entries.Add(entry);
            _snapshot = _entries.ToArray();
        }

        return () => {
            lock (_entries) {
                if (_entries.Remove(entry)) {
                    _snapshot = _entries.ToArray();
                }
            }
        };
    }

    /// <summary>
    /// Adds a blocker and returns the action that takes it back off, scoped the same way
    /// <see cref="Add"/> is. Prefer <c>ScopedFeature.AddDamageBlocker</c>.
    /// </summary>
    public Action AddBlocker(IDamageBlocker blocker, IFeatureScope? scope = null) {
        BlockerEntry entry = new(blocker, scope);
        lock (_blockers) {
            _blockers.Add(entry);
            _blockerSnapshot = _blockers.ToArray();
        }

        return () => {
            lock (_blockers) {
                if (_blockers.Remove(entry)) {
                    _blockerSnapshot = _blockers.ToArray();
                }
            }
        };
    }

    /// <summary>
    /// How much of the hit the entity's held items stop, vanilla's <c>applyItemBlocking</c>. Runs
    /// ahead of the reductions and of the invulnerable window; see <see cref="IDamageBlocker"/>.
    /// <p/>
    /// Vanilla has one blocking item, so more than one blocker in scope is ours to define: they add
    /// up, clamped to the hit, which is what a single one already does to its own reductions.
    /// </summary>
    public BlockOutcome ApplyBlocking(LivingEntity entity, DamageSource source, float amount) {
        if (amount <= 0) {
            return BlockOutcome.None;
        }

        float blocked = 0;
        List<IDamageBlocker>? by = null;
        foreach (BlockerEntry entry in _blockerSnapshot) {
            if (!InScope(entry.Scope, entity)) {
                continue;
            }

            float stopped = entry.Blocker.Block(entity, source, amount);
            if (stopped <= 0) {
                continue;
            }

            blocked += stopped;
            by ??= [];
            by.Add(entry.Blocker);
        }

        return new BlockOutcome(Math.Clamp(blocked, 0, amount), by);
    }

    /// <summary>
    /// What blocking took off a hit, and which blockers to tell about it once the hit is settled. The
    /// list is null rather than empty for the usual case of nothing blocking, so an unblocked hit
    /// allocates nothing.
    /// </summary>
    public readonly record struct BlockOutcome(float Blocked, List<IDamageBlocker>? By) {
        public static readonly BlockOutcome None = new(0, null);

        /// <summary>
        /// Tells every blocker that stopped part of the hit that it was a fresh one. Vanilla only does
        /// this for a hit outside the invulnerable window, since it is what the block looks like rather
        /// than what it was worth.
        /// </summary>
        public void ReportBlocked(LivingEntity entity, DamageSource source) {
            if (By == null) {
                return;
            }

            foreach (IDamageBlocker blocker in By) {
                blocker.OnBlocked(entity, source);
            }
        }
    }

    /// <summary>
    /// The damage left after every modifier in scope for <paramref name="entity"/> has had it. Never
    /// negative: a modifier that overshoots takes the hit to zero rather than healing.
    /// </summary>
    public float Apply(LivingEntity entity, DamageSource source, float amount) {
        Entry[] entries = _snapshot;
        foreach (DamageStage stage in Stages) {
            foreach (Entry entry in entries) {
                if (entry.Modifier.Stage != stage || !InScope(entry.Scope, entity)) {
                    continue;
                }

                amount = entry.Modifier.Modify(entity, source, amount);
            }
        }

        return Math.Max(0, amount);
    }

    private static bool InScope(IFeatureScope? scope, LivingEntity entity) {
        return scope is null
               || ReferenceEquals(scope, entity)
               || ReferenceEquals(scope, entity.World)
               || ReferenceEquals(scope, entity.Server);
    }

    private record Entry(IDamageModifier Modifier, IFeatureScope? Scope);

    private record BlockerEntry(IDamageBlocker Blocker, IFeatureScope? Scope);
}
