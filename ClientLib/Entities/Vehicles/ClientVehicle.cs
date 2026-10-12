using ClientLib.Maths;
using ClientLib.World;

namespace ClientLib.Entities.Vehicles;

/// <summary>
/// An entity the local player can steer. While nobody on this client steers it, it is interpolated
/// toward the server's positions like any other entity; once <c>isLocalInstanceAuthoritative</c>
/// holds, the client runs its movement and tells the server where it went, which is the only way a
/// steered vehicle moves at all, since the server stops simulating it.
/// </summary>
public abstract class ClientVehicle(MinecraftClient client) : PhysicsEntity(client) {
    /// <summary>
    /// <c>ClientLevel.tickNonPassenger</c>. A vehicle nobody here steers keeps the plain interpolated
    /// tick; one the player steers runs its class's <c>tick</c> where the server would.
    /// </summary>
    public sealed override void Tick() {
        ClientLevel? level = Client.Level;
        if (level == null || !IsLocalInstanceAuthoritative) {
            base.Tick();
            CommonTick();
            return;
        }
        TickCount++;
        OldPosition = Position;
        YRotO = YRot;
        XRotO = XRot;
        YHeadRotO = YHeadRot;
        if (!level.HasChunk(BlockX >> 4, BlockZ >> 4)) {
            return;
        }
        ControlledTick();
        CommonTick();
    }

    /// <summary>The class's <c>tick</c>, run only while the local player steers it.</summary>
    protected abstract void ControlledTick();

    /// <summary>The part of the class's <c>tick</c> that runs whoever steers it.</summary>
    protected virtual void CommonTick() {
    }

    /// <summary><c>Entity.moveRelative</c> through <c>getInputVector</c>.</summary>
    protected void MoveRelative(float speed, Vec3d input) {
        DeltaMovement += Player.LocalPlayer.InputVector(input, speed, YRot);
    }
}
