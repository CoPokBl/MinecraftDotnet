using ManagedServer.Events.Attributes;
using ManagedServer.Events.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Implementations.Events;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Events;

/// <summary>
/// An event that occurs when a block in the world changes.
/// <p/>
/// Fired <b>before</b> the write, so <see cref="OldState"/> is still what is in the world and
/// cancelling leaves it there.
/// </summary>
[BuiltinEvent]
public class WorldChangeEvent : IWorldEvent, ICancelableEvent {
    public required World World { get; init; }
    public required Vec3<int> Position { get; init; }
    public required IBlock OldState { get; init; }
    public required IBlock NewState { get; set; }
    public bool Cancelled { get; set; } = false;

    /// <summary>
    /// The <see cref="BlockUpdateFlags"/> the write was made with, which is the only place a listener
    /// can learn what the caller meant by it.
    /// <p/>
    /// <see cref="BlockUpdateFlags.SuppressDrops"/> is the one that matters to a listener today: it is
    /// what <c>World.DestroyBlock(pos, dropResources: false)</c> and a placement cascade set, and
    /// without it here a feature dropping loot on this event cannot tell a break that should drop from
    /// one that should not.
    /// </summary>
    public int Flags { get; init; } = BlockUpdateFlags.Default;

    /// <summary>
    /// Whether this write is <see cref="World.DestroyBlock"/> rather than an ordinary
    /// <see cref="World.SetBlock(Vec3{int},IBlock,IBlockEntityType?,NBT.Tags.INbtTag?,int,int)"/>.
    /// <p/>
    /// Vanilla keeps the two apart and only <c>destroyBlock</c> drops anything, so a consumer writing
    /// air to clear an area is not breaking those blocks and must not be given their loot. Without
    /// this the two are the same write and a feature reading this event cannot tell them apart.
    /// </summary>
    public bool Destroy { get; init; }

    /// <summary>Whether the write asked for the old block's loot, ie. did not suppress drops.</summary>
    public bool DropResources => Destroy && (Flags & BlockUpdateFlags.SuppressDrops) == 0;
}
