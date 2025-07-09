using ManagedServer.Entities.Types;
using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Implementations.Events;
using Minecraft.Text;

namespace ManagedServer.Events;

[NotCalledByDefault]
public class PlayerChatEvent : IPlayerEvent, ICancelableEvent {
    public required World World { get; init; }
    public required PlayerEntity Player { get; init; }
    public required string RawMessage { get; init; }
    public required TextComponent Message { get; set; }
    public required IAudience Audience { get; set; }
    
    public Entity Entity {
        get => Player;
        init { }
    }

    public bool Cancelled { get; set; }
}
