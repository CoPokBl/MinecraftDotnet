using ManagedServer.Events.Attributes;
using ManagedServer.Worlds;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas;

namespace ManagedServer.Events;

// sensible defaults are set
[BuiltinEvent]
public class PlayerPreLoginEvent : IServerEvent {
    public GameMode GameMode { get; set; } = GameMode.Survival;
    public bool Hardcore { get; set; }
    public World? World { get; set; } // will always start null (to be set by event handler)
    public required PlayerConnection Connection { get; init; }
}
