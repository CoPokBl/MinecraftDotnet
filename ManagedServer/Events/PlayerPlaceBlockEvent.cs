using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Implementations.Events;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class PlayerPlaceBlockEvent : ICancelableEvent, IPlayerEvent {
    public required PlayerEntity Player { get; init; }
    public required IVec3 Position { get; set; }
    public required IBlock Block { get; set; }
    public bool ConsumeItem { get; set; } = true;
    public required ItemStack UsedItem { get; init; }
    public required World World { get; init; }

    /// <summary>
    /// Whether to do nothing and inform the client that the block placement was cancelled.
    /// </summary>
    public bool Cancelled { get; set; }
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
