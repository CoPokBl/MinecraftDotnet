using ManagedServer.Entities.Types;

namespace ManagedServer.Ai.Sensing;

/// <summary>
/// A mob's memory of what it can see this tick, vanilla's <c>Sensing</c>. Line of sight is a raycast
/// and several goals ask about the same target in the same tick, so the answers are kept until the
/// next <see cref="Tick"/> clears them.
/// <p/>
/// The cache is per tick and not longer on purpose: it is a cost saving, not a delay. A mob that steps
/// behind a wall loses sight of its target on the same tick it steps.
/// </summary>
public class Sensing(Mob mob) {
    private readonly HashSet<int> _seen = [];
    private readonly HashSet<int> _unseen = [];

    /// <summary>Clears both caches. Called first thing in <c>Mob.ServerAiStep</c>.</summary>
    public void Tick() {
        _seen.Clear();
        _unseen.Clear();
    }

    public bool HasLineOfSight(Entity target) {
        int id = target.NetId;
        if (_seen.Contains(id)) {
            return true;
        }

        if (_unseen.Contains(id)) {
            return false;
        }

        bool visible = LineOfSight.Between(mob, target);
        if (visible) {
            _seen.Add(id);
        }
        else {
            _unseen.Add(id);
        }

        return visible;
    }
}
