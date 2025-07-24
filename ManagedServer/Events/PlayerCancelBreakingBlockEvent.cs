using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class PlayerCancelBreakingBlockEvent : IPlayerEvent {
    public required PlayerEntity Player { get; init; }
    public required Vec3<int> Position { get; set; }
    public required IBlock Block { get; set; }
    public required World World { get; init; }
    
    public Entity Entity {
        get => Player;
        init { }
    }
}
