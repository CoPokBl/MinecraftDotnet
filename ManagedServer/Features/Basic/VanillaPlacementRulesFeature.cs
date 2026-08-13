using ManagedServer.Features;
using ManagedServer.Placement;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Vanilla's answers to "what state does this block go down in, and what does it do when its
/// neighbours change". Stairs face away from you, slabs double, doors get a top half, fences connect,
/// a ladder needs a wall and lets go of one that goes.
/// <p/>
/// A feature rather than core, on the same footing as <c>VanillaMobAiFeature</c>: the registry and
/// the neighbour cascade are the apparatus and are inert on their own, and these are the vanilla
/// behaviour definitions that fill them. Not registering it is a supported configuration, and means
/// every block places its default state, which is exactly what
/// <c>Block.getStateForPlacement</c> does for a class that overrides nothing.
/// <p/>
/// Granularity is per rule. Pass the ones you want:
/// <code>
/// new VanillaPlacementRulesFeature(VanillaPlacementRules.Except(BlockClass.SlabBlock))
/// new VanillaPlacementRulesFeature(VanillaPlacementRules.Only(BlockClass.DoorBlock))
/// </code>
/// or register your own rule after this feature, where it shadows ours for as long as it is
/// registered. Unregistering takes off exactly the rules this feature put on and no others.
/// </summary>
public class VanillaPlacementRulesFeature(IReadOnlyList<IBlockPlacementRule> rules) : ScopedFeature {
    /// <summary>All of vanilla's rules.</summary>
    public VanillaPlacementRulesFeature() : this(VanillaPlacementRules.All) { }

    public override void Register() {
        foreach (IBlockPlacementRule rule in rules) {
            AddPlacementRule(rule);
        }
    }
}
