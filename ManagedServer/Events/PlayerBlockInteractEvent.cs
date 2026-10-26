using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Interaction;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

/// <summary>
/// A player right clicking a block: <c>BlockState.useItemOn</c> and <c>BlockState.useWithoutItem</c>,
/// the first stage of <see cref="BlockInteraction.UseItemOn"/>. Pairs with
/// <see cref="PlayerEntityInteractEvent"/>, and comes before <see cref="PlayerUseItemOnBlockEvent"/>,
/// which is where block placement lives.
/// <p/>
/// Answer by setting <see cref="Result"/> to one of the <c>Success</c> constants. The sequence stops
/// there, so the item stage never runs and no block is placed. That, rather than a listener
/// registering earlier than another, is what makes opening a chest beat placing a block.
/// <p/>
/// A listener should start with <c>if (e.Result.ConsumesAction) return;</c>, because vanilla has one
/// interaction method per block and the first answer is the only answer.
/// <p/>
/// Deliberately not <c>ICancelableEvent</c>: <see cref="Result"/> already says stop, and a
/// <c>Cancelled</c> beside <c>ConsumesAction</c> would be two ways to spell one thing that could
/// disagree.
/// </summary>
[BuiltinEvent]
public class PlayerBlockInteractEvent : IPlayerEvent {
    public required Player Player { get; init; }
    public required World World { get; init; }

    /// <summary>Which of the two vanilla methods this is. See <see cref="InteractStage"/>.</summary>
    public required InteractStage Stage { get; init; }

    /// <summary>The block that was clicked, not the one a placement would go into.</summary>
    public required Vec3<int> Position { get; init; }

    public required IBlock Block { get; init; }
    public required BlockFace Face { get; init; }

    /// <summary>
    /// The hit point as a world coordinate, vanilla's <c>BlockHitResult.getLocation</c>. The packet
    /// carries a fraction of the clicked block; this has the block position added back on.
    /// </summary>
    public required Vec3<double> ClickLocation { get; init; }

    public required bool InsideBlock { get; init; }
    public required Hand Hand { get; init; }

    /// <summary>
    /// What is in <see cref="Hand"/>. Still carried on the <see cref="InteractStage.UseWithoutItem"/>
    /// stage, where vanilla's method does not take it, because a consumer often wants to know.
    /// </summary>
    public required ItemStack Item { get; init; }

    /// <summary>
    /// Starts at whatever the rule for this block answered, or at the vanilla method's default body
    /// when no rule speaks for it: <c>TryWithEmptyHand</c> for <see cref="InteractStage.UseItemOn"/>
    /// and <c>Pass</c> for <see cref="InteractStage.UseWithoutItem"/>.
    /// <p/>
    /// Setting it to a <c>Success</c> overrides the rule, which is how a minigame replaces what a
    /// block does without unregistering anything.
    /// </summary>
    public required InteractionResult Result { get; set; }

    public Entity Entity {
        get => Player;
        init { }
    }
}
