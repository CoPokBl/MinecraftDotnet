using System.Collections.Concurrent;
using ManagedServer.Features;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Interaction;

/// <summary>
/// Which rule speaks for which block when it is right clicked, vanilla's virtual dispatch of
/// <c>BlockBehaviour.useItemOn</c> and <c>useWithoutItem</c>.
/// <p/>
/// There is one per server and it always exists, exactly like
/// <see cref="Placement.BlockPlacementRules"/> and <see cref="Damage.DamagePipeline"/>, and like
/// both of those it starts <b>empty</b>. A server that registers nothing has blocks that do nothing
/// when clicked, which is not a broken server: it is <c>BlockBehaviour</c>'s two default bodies,
/// precisely what vanilla does for a block whose class overrides neither. The vanilla transcriptions
/// are a feature a consumer asks for, one rule at a time if they want.
/// <p/>
/// Resolution is an <b>override, not a chain</b>, for the same reason placement is: vanilla has a
/// single pair of these methods per block, so there is no ordering between rules to model and no
/// stage enum. The narrowest rule in scope wins, and among equals the most recently registered.
/// <p/>
/// A listener on <c>PlayerBlockInteractEvent</c> sees whatever the rule answered and can overrule
/// it, which is the coarser of the two seams and the one a minigame usually wants.
/// </summary>
public class BlockInteractionRules {
    /// <summary>
    /// Registered rules, most recent last. Replaced wholesale under the lock so the lookup path
    /// walks an array nothing is mutating.
    /// </summary>
    private readonly List<Entry> _entries = [];
    private Entry[] _snapshot = [];

    /// <summary>
    /// The resolved rule per block, worth caching because resolving one walks a class chain and then
    /// the whole registration list. Keyed by block identifier rather than by state id: a rule belongs
    /// to a block, not to one of its states. Thrown away whenever registrations change.
    /// <p/>
    /// Only usable while every rule is server wide, since a scoped one resolves differently per
    /// world. See <see cref="_scopedRules"/>.
    /// </summary>
    private ConcurrentDictionary<Identifier, IBlockInteractionRule?> _resolved = new();

    /// <summary>
    /// How many registered rules are scoped to something narrower than the server. Zero for a server
    /// that only has the vanilla rules, which is the case worth keeping fast and the only case the
    /// resolution cache is valid for.
    /// </summary>
    private int _scopedRules;

    /// <summary>
    /// Adds a rule and returns the action that takes it back off, in the shape
    /// <c>EventNode.AddListener</c> uses. Prefer <c>ScopedFeature.AddInteractionRule</c>, which passes
    /// the feature's own scope and unregisters it with the feature's listeners.
    /// <p/>
    /// A rule for a class that already has one shadows it while it is registered, which is how a
    /// minigame changes what a door does without touching the vanilla rule.
    /// </summary>
    public Action Add(IBlockInteractionRule rule, IFeatureScope? scope = null) {
        Entry entry = new(rule, scope is ManagedMinecraftServer ? null : scope);
        lock (_entries) {
            _entries.Add(entry);
            Refresh();
        }

        return () => {
            lock (_entries) {
                if (_entries.Remove(entry)) {
                    Refresh();
                }
            }
        };
    }

    /// <summary>Rebuilds the lookup path's view of the list. Call under the lock.</summary>
    private void Refresh() {
        _snapshot = _entries.ToArray();
        _scopedRules = _entries.Count(e => e.Scope is not null);
        _resolved = new ConcurrentDictionary<Identifier, IBlockInteractionRule?>();
    }

    /// <summary>
    /// The rule for a block, or null when nothing speaks for it, which means clicking it does
    /// nothing and the click falls through to the held item.
    /// <p/>
    /// Resolution walks the block's Java class chain nearest first and takes the first class anything
    /// is registered for, which is what makes one <c>DoorBlock</c> rule cover every door in the game.
    /// </summary>
    public IBlockInteractionRule? For(IBlock block, World world) {
        // The cache only holds while every rule is server wide, since a world scoped rule is a
        // different answer for the same block in a different world.
        return _scopedRules == 0
            ? _resolved.GetOrAdd(block.Identifier, id => Resolve(id, null))
            : Resolve(block.Identifier, world);
    }

    private IBlockInteractionRule? Resolve(Identifier block, World? world) {
        Entry[] entries = _snapshot;
        foreach (BlockClass className in BlockClasses.Of(block)) {
            // Most recent registration first, so a feature's rule shadows the vanilla one.
            for (int i = entries.Length - 1; i >= 0; i--) {
                if (entries[i].Rule.VanillaClass == className && InScope(entries[i].Scope, world)) {
                    return entries[i].Rule;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Whether a rule applies where the block is. A null scope is the whole server; a world scope
    /// only its own world. An entity scope never matches, because a block is clicked in a world and
    /// not on an entity, and silently applying such a rule everywhere would be worse than not
    /// applying it.
    /// </summary>
    private static bool InScope(IFeatureScope? scope, World? world) {
        return scope is null || (world is not null && ReferenceEquals(scope, world));
    }

    /// <summary>Takes a rule back off, wherever it was registered. False if it was not there.</summary>
    public bool Remove(IBlockInteractionRule rule) {
        lock (_entries) {
            int at = _entries.FindIndex(e => ReferenceEquals(e.Rule, rule));
            if (at < 0) {
                return false;
            }

            _entries.RemoveAt(at);
            Refresh();
            return true;
        }
    }

    /// <summary>
    /// Takes off every rule speaking for a class, whoever registered it, and returns how many went.
    /// The blunt instrument for "I want the vanilla set except doors" after the fact; preferring
    /// <see cref="VanillaBlockInteractions.Except"/> up front is tidier, since this cannot tell a
    /// consumer's rule from ours.
    /// </summary>
    public int RemoveAll(BlockClass vanillaClass) {
        lock (_entries) {
            int removed = _entries.RemoveAll(e => e.Rule.VanillaClass == vanillaClass);
            if (removed > 0) {
                Refresh();
            }

            return removed;
        }
    }

    /// <summary>Empties the registry, leaving every block inert when clicked.</summary>
    public void Clear() {
        lock (_entries) {
            if (_entries.Count == 0) {
                return;
            }

            _entries.Clear();
            Refresh();
        }
    }

    /// <summary>Every registered rule, oldest first, so the last one to claim a class is the last.</summary>
    public IReadOnlyList<IBlockInteractionRule> Registered {
        get {
            Entry[] entries = _snapshot;
            IBlockInteractionRule[] rules = new IBlockInteractionRule[entries.Length];
            for (int i = 0; i < entries.Length; i++) {
                rules[i] = entries[i].Rule;
            }

            return rules;
        }
    }

    /// <summary>
    /// Whether nothing is registered, which means every block answers its vanilla default body and
    /// the click falls through to the held item.
    /// <p/>
    /// The sequence does not read this: <see cref="For"/> is cheap enough on an empty registry that
    /// short circuiting it would only add a branch. It is here for the same reason
    /// <c>BlockPlacementRules.IsEmpty</c> is, so a test can pin that a bare server registered nothing.
    /// </summary>
    public bool IsEmpty => _snapshot.Length == 0;

    /// <summary>A rule and where it applies. A null scope is the whole server.</summary>
    private record Entry(IBlockInteractionRule Rule, IFeatureScope? Scope);
}
