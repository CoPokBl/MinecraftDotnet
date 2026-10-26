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
/// The held item acting on the block that was clicked: <c>ItemStack.useOn</c>, the second stage of
/// <see cref="BlockInteraction.UseItemOn"/>. This is where <c>BlockItem.place</c> lives, so
/// <c>BlockPlacingFeature</c> listens here.
/// <p/>
/// It only runs when <see cref="PlayerBlockInteractEvent"/> did not consume the click, which is the
/// whole ordering guarantee: a listener here cannot outrun one there, whatever order the features
/// were registered in. Pairs with <see cref="PlayerUseItemEvent"/>, which is <c>ItemStack.use</c>,
/// the click that hit no block.
/// <p/>
/// A listener should start with <c>if (e.Result.ConsumesAction) return;</c>, since vanilla has one
/// <c>useOn</c> per item.
/// </summary>
[BuiltinEvent]
public class PlayerUseItemOnBlockEvent : IPlayerEvent {
    public required Player Player { get; init; }
    public required World World { get; init; }

    /// <summary>The block that was clicked, not the one a placement would go into.</summary>
    public required Vec3<int> Position { get; init; }

    public required IBlock Block { get; init; }
    public required BlockFace Face { get; init; }

    /// <summary>The hit point as a world coordinate. See <see cref="PlayerBlockInteractEvent.ClickLocation"/>.</summary>
    public required Vec3<double> ClickLocation { get; init; }

    public required bool InsideBlock { get; init; }
    public required Hand Hand { get; init; }
    public required ItemStack Item { get; init; }

    /// <summary>
    /// Starts at <c>Pass</c>, which is <c>Item.useOn</c>'s default body. Set it to say the item
    /// answered.
    /// </summary>
    public required InteractionResult Result { get; set; }

    public Entity Entity {
        get => Player;
        init { }
    }
}
