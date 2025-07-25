using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Implementations.Events;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

/// <summary>
/// An event that occurs when a block in the world changes.
/// </summary>
[BuiltinEvent]
public class WorldChangeEvent : IWorldEvent, ICancelableEvent {
    public required World World { get; init; }
    public required Vec3<int> Position { get; init; }
    public required IBlock OldState { get; init; }
    public required IBlock NewState { get; set; }
    public bool Cancelled { get; set; } = false;
}
