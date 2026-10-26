using ManagedServer.Interaction;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Vanilla's answers to "what happens when you right click this block". Doors, trapdoors and fence
/// gates open, levers flip, buttons press, a lit candle goes out and a dragon egg jumps away.
/// <p/>
/// A feature rather than core, on exactly the footing of <c>VanillaPlacementRulesFeature</c>: the
/// registry and the click sequence are the apparatus and are inert on their own, and these are the
/// vanilla behaviour definitions that fill them. Not registering it is a supported configuration and
/// means every block is inert when clicked, which is what <c>BlockBehaviour</c> does for a class that
/// overrides neither hook.
/// <p/>
/// Granularity is per rule. Pass the ones you want:
/// <code>
/// new VanillaBlockInteractionsFeature(VanillaBlockInteractions.Except(BlockClass.ButtonBlock))
/// new VanillaBlockInteractionsFeature(VanillaBlockInteractions.Only(BlockClass.DoorBlock))
/// </code>
/// or register your own rule after this feature, where it shadows ours for as long as it is
/// registered. Unregistering takes off exactly the rules this feature put on and no others.
/// <p/>
/// See <see cref="VanillaBlockInteractions"/> for which of the 64 vanilla classes with a hook are
/// transcribed and why the rest are not.
/// </summary>
public class VanillaBlockInteractionsFeature(IReadOnlyList<IBlockInteractionRule> rules) : ScopedFeature {
    /// <summary>All of vanilla's interaction rules.</summary>
    public VanillaBlockInteractionsFeature() : this(VanillaBlockInteractions.All) { }

    public override void Register() {
        foreach (IBlockInteractionRule rule in rules) {
            AddInteractionRule(rule);
        }
    }
}
