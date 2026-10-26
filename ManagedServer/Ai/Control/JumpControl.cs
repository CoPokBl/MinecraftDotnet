using ManagedServer.Entities.Types;

namespace ManagedServer.Ai.Control;

/// <summary>
/// Vanilla's <c>JumpControl</c>, which is a single latch: something calls <see cref="Jump"/>, the next
/// tick hands it to <see cref="LivingEntity.Jumping"/> and clears it. The jump itself happens in the
/// travel step, and the ten tick cooldown is kept there too, so asking for a jump every tick does not
/// produce one every tick.
/// </summary>
public class JumpControl(Mob mob) {
    protected readonly Mob Mob = mob;

    protected bool WantsToJump;

    public void Jump() {
        WantsToJump = true;
    }

    public virtual void Tick() {
        Mob.Jumping = WantsToJump;
        WantsToJump = false;
    }
}
