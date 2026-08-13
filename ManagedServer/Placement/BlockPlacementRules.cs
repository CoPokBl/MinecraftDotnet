using System.Collections.Concurrent;
using ManagedServer.Features;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Placement;

/// <summary>
/// Which rule speaks for which block, vanilla's virtual dispatch of <c>getStateForPlacement</c> and
/// its siblings.
/// <p/>
/// There is one per server and it always exists, exactly like <see cref="Damage.DamagePipeline"/>,
/// and like that pipeline it starts <b>empty</b>. A server that registers nothing places every block
/// in its default state and reacts to no neighbour, which is not a broken server, it is
/// <c>Block.getStateForPlacement</c> and the default <c>updateShape</c>: precisely what vanilla does
/// for a block whose class overrides neither. The vanilla transcriptions are a feature a consumer
/// asks for, one rule at a time if they want.
/// <p/>
/// Resolution is an <b>override, not a chain</b>. A block has exactly one
/// <c>getStateForPlacement</c> in vanilla, so there is no ordering between rules to model and no
/// stage enum: the narrowest rule in scope wins, and among equals the most recently registered. That
/// is also what lets a consumer's rule replace one of ours by being registered after it.
/// </summary>
public class BlockPlacementRules {
    /// <summary>
    /// Registered rules, most recent last. Replaced wholesale under the lock so the lookup path
    /// walks an array nothing is mutating.
    /// </summary>
    private readonly List<Entry> _entries = [];
    private Entry[] _snapshot = [];

    /// <summary>
    /// The resolved rule per block, which is worth caching because resolving one walks a class chain
    /// and then the whole registration list. Keyed by block identifier rather than by state id: a
    /// rule belongs to a block, not to one of its states. Thrown away whenever registrations change.
    /// <p/>
    /// Only usable while every rule is server wide, since a scoped one resolves differently per
    /// world. See <see cref="_scopedRules"/>.
    /// </summary>
    private ConcurrentDictionary<Identifier, IBlockPlacementRule?> _resolved = new();

    /// <summary>
    /// How many registered rules are scoped to something narrower than the server. Zero for a server
    /// that only has the vanilla rules, which is the case worth keeping fast, and the only case the
    /// resolution cache is valid for.
    /// </summary>
    private int _scopedRules;

    /// <summary>
    /// Adds a rule and returns the action that takes it back off, in the shape
    /// <c>EventNode.AddListener</c> uses. Prefer <c>ScopedFeature.AddPlacementRule</c>, which passes
    /// the feature's own scope and unregisters it with the feature's listeners.
    /// <p/>
    /// A rule for a class that already has one shadows it while it is registered, which is how a
    /// minigame replaces what a stair does without touching the vanilla rule.
    /// </summary>
    public Action Add(IBlockPlacementRule rule, IFeatureScope? scope = null) {
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
        _resolved = new ConcurrentDictionary<Identifier, IBlockPlacementRule?>();
    }

    /// <summary>
    /// The rule for a block, or null when nothing speaks for it, which means it places its default
    /// state and reacts to nothing.
    /// <p/>
    /// Resolution walks the block's Java class chain nearest first and takes the first class anything
    /// is registered for. That is what makes a single <c>StairBlock</c> rule cover all 60 stairs and
    /// the copper ones that weather, and a <c>FaceAttachedHorizontalDirectionalBlock</c> rule cover
    /// buttons, levers and the grindstone without listing them.
    /// </summary>
    public IBlockPlacementRule? For(IBlock block, World world) {
        // The cache only holds while every rule is server wide, since a world scoped rule is a
        // different answer for the same block in a different world.
        return _scopedRules == 0
            ? _resolved.GetOrAdd(block.Identifier, id => Resolve(id, null))
            : Resolve(block.Identifier, world);
    }

    private IBlockPlacementRule? Resolve(Identifier block, World? world) {
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
    /// Whether a rule applies where the block is going. A null scope is the whole server; a world
    /// scope only its own world. An entity scope never matches, because a block is placed in a world
    /// and not on an entity, and silently applying such a rule everywhere would be worse than not
    /// applying it.
    /// </summary>
    private static bool InScope(IFeatureScope? scope, World? world) {
        return scope is null || (world is not null && ReferenceEquals(scope, world));
    }

    /// <summary>Takes a rule back off, wherever it was registered. False if it was not there.</summary>
    public bool Remove(IBlockPlacementRule rule) {
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
    /// The blunt instrument for "I want the vanilla set except stairs" after the fact; preferring
    /// <c>VanillaPlacementRules.Except</c> up front is tidier, since this cannot tell a consumer's
    /// rule from ours.
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

    /// <summary>Empties the registry, leaving every block placing its default state.</summary>
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
    public IReadOnlyList<IBlockPlacementRule> Registered {
        get {
            Entry[] entries = _snapshot;
            IBlockPlacementRule[] rules = new IBlockPlacementRule[entries.Length];
            for (int i = 0; i < entries.Length; i++) {
                rules[i] = entries[i].Rule;
            }

            return rules;
        }
    }

    /// <summary>
    /// Whether nothing is registered. The neighbour cascade reads this to skip its whole walk, since
    /// with no rules there is nothing any of it could change.
    /// </summary>
    public bool IsEmpty => _snapshot.Length == 0;

    /// <summary>A rule and where it applies. A null scope is the whole server.</summary>
    private record Entry(IBlockPlacementRule Rule, IFeatureScope? Scope);
}
