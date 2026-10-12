using ClientLib.World;
using Minecraft.Data.Generated;

namespace ClientLib.Entities;

/// <summary>
/// An entity nobody steers whose client copy runs its own physics between server updates, as the parts
/// of <c>Entity</c> its <c>tick</c> calls run where <c>isLocalInstanceAuthoritative</c> is false. A
/// position from the server lands at once, as it does for an entity whose <c>getInterpolation</c> is null.
/// The local discards (below the world, an emptied item, an expired fuse or age) are not simulated; the
/// server's removal follows.
/// </summary>
public abstract class SimulatedEntity : PhysicsEntity {
    protected SimulatedEntity(MinecraftClient client) : base(client) {
        InterpolationSteps = 0;
    }

    /// <summary>
    /// <c>ClientLevel.tickNonPassenger</c>. <c>tickEntities</c> only reaches an entity whose chunk is
    /// loaded, so one outside them stands still, old position included.
    /// </summary>
    public sealed override void Tick() {
        ClientLevel? level = Client.Level;
        if (level == null || !level.HasChunk(BlockX >> 4, BlockZ >> 4)) {
            return;
        }
        OldPosition = Position;
        YRotO = YRot;
        XRotO = XRot;
        TickCount++;
        EntityTick();
    }

    /// <summary>The entity class's <c>tick</c>.</summary>
    protected abstract void EntityTick();
}
