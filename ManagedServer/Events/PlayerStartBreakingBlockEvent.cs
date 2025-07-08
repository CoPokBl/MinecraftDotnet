using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

public class PlayerStartBreakingBlockEvent : ICancelableEvent, IServerEvent {
    public required PlayerEntity Player { get; init; }
    public required IVec3 Position { get; set; }
    public required IBlock Block { get; set; }
    public required World World { get; init; }

    /// <summary>
    /// Whether to do nothing and inform the client that the block break was cancelled.
    /// </summary>
    public bool Cancelled { get; set; } = true;
}
