using Minecraft.Schemas.Vec;

namespace ManagedServer.Fluids;

/// <summary>
/// Vanilla's <c>LevelTicks</c>, narrowed to fluids.
/// <p/>
/// Two details of it matter and both are load bearing. A position that already has a tick pending for
/// the same fluid keeps the one it has, which is what stops a block surrounded by updates from ticking
/// once per update; and the ticks due this pass are taken out before any of them run, so a tick that
/// reschedules itself waits for the next pass rather than looping.
/// </summary>
public sealed class FluidTicks {
    /// <param name="Source">
    /// Part of the key because vanilla schedules the fluid's <i>type</i>, and a source and its flowing
    /// form are two types. A tick scheduled by a source is dropped if the block has become flowing by
    /// the time it runs, see <c>ServerLevel.tickFluid</c>.
    /// </param>
    public readonly record struct Key(Vec3<int> Pos, FluidKind Kind, bool Source);

    private readonly Dictionary<ulong, List<Key>> _byTick = [];
    private readonly HashSet<Key> _pending = [];
    private readonly List<ulong> _dueBuckets = [];

    public int PendingCount => _pending.Count;

    public void Schedule(Key key, ulong tick) {
        if (!_pending.Add(key)) {
            return;
        }

        if (!_byTick.TryGetValue(tick, out List<Key>? bucket)) {
            bucket = [];
            _byTick[tick] = bucket;
        }

        bucket.Add(key);
    }

    public bool IsPending(Key key) => _pending.Contains(key);

    /// <summary>Takes every tick due at or before <paramref name="currentTick"/>, oldest first.</summary>
    public List<Key> TakeDue(ulong currentTick) {
        List<Key> due = [];
        if (_byTick.Count == 0) {
            return due;
        }

        _dueBuckets.Clear();
        foreach (ulong tick in _byTick.Keys) {
            if (tick <= currentTick) {
                _dueBuckets.Add(tick);
            }
        }

        _dueBuckets.Sort();
        foreach (ulong tick in _dueBuckets) {
            foreach (Key key in _byTick[tick]) {
                _pending.Remove(key);
                due.Add(key);
            }

            _byTick.Remove(tick);
        }

        return due;
    }

    public void Clear() {
        _byTick.Clear();
        _pending.Clear();
    }
}
