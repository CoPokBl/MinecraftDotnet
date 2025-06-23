using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Managed.Events;

// sensible defaults are set
public class PlayerPreLoginEvent : IServerEvent {
    public GameMode GameMode { get; set; } = GameMode.Survival;
    public bool Hardcore { get; set; } = false;
    public World? World { get; set; } = null;  // will always start null (to be set by event handler)
}