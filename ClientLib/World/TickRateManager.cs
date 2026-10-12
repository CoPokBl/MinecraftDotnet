using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace ClientLib.World;

/// <summary><c>TickRateManager</c> on the client: the server's tick rate and freeze, from <c>ticking_state</c> and <c>ticking_step</c>.</summary>
public sealed class TickRateManager {
    public float TickRate { get; private set; } = 20.0F;
    public long NanosecondsPerTick { get; private set; } = 1_000_000_000L / 20L;
    public int FrozenTicksToRun { get; set; }
    public bool RunsNormally { get; private set; } = true;
    public bool IsFrozen { get; set; }

    public bool IsSteppingForward => FrozenTicksToRun > 0;

    public float MillisecondsPerTick => NanosecondsPerTick / 1_000_000.0F;

    public void SetTickRate(float rate) {
        TickRate = Math.Max(rate, 1.0F);
        NanosecondsPerTick = (long)(1_000_000_000.0 / TickRate);
    }

    public void Tick() {
        RunsNormally = !IsFrozen || FrozenTicksToRun > 0;
        if (FrozenTicksToRun > 0) {
            FrozenTicksToRun--;
        }
    }

    public bool IsEntityFrozen(ClientEntity entity) => !RunsNormally && !entity.Is(EntityClass.Player) && CountPlayerPassengers(entity) <= 0;

    /// <summary><c>Entity.countPlayerPassengers</c>, over every passenger however deep.</summary>
    private static int CountPlayerPassengers(ClientEntity entity) {
        int count = 0;
        foreach (ClientEntity passenger in entity.PassengerList) {
            if (passenger.Is(EntityClass.Player)) {
                count++;
            }
            count += CountPlayerPassengers(passenger);
        }
        return count;
    }
}
