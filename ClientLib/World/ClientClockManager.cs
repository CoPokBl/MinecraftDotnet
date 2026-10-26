using Minecraft.Schemas;

namespace ClientLib.World;

/// <summary>
/// <c>ClientClockManager</c>: the world clocks, run forward by the game time that passes between the
/// server's updates, so a clock follows the server's tick rate rather than the client's.
/// </summary>
public sealed class ClientClockManager {
    private readonly Dictionary<Identifier, ClockInstance> _clocks = new();
    private long _lastTickGameTime;

    private ClockInstance GetInstance(Identifier clock) {
        if (!_clocks.TryGetValue(clock, out ClockInstance? instance)) {
            instance = new ClockInstance();
            _clocks[clock] = instance;
        }
        return instance;
    }

    public void Tick(long gameTime) {
        long gameTimeDelta = gameTime - _lastTickGameTime;
        _lastTickGameTime = gameTime;
        foreach (ClockInstance instance in _clocks.Values) {
            double newPartialTicks = instance.PartialTick + (double)gameTimeDelta * instance.Rate;
            long fullTicks = (long)Math.Floor(newPartialTicks);
            instance.PartialTick = (float)(newPartialTicks - fullTicks);
            instance.TotalTicks += fullTicks;
        }
    }

    public void HandleUpdates(long gameTime, IEnumerable<(Identifier Clock, long TotalTicks, float PartialTick, float Rate)> updates) {
        Tick(gameTime);
        foreach ((Identifier clock, long totalTicks, float partialTick, float rate) in updates) {
            ClockInstance instance = GetInstance(clock);
            instance.TotalTicks = totalTicks;
            instance.PartialTick = partialTick;
            instance.Rate = rate;
        }
    }

    public long GetTotalTicks(Identifier clock) => GetInstance(clock).TotalTicks;

    /// <summary>
    /// The clock's reading part way to the next tick, for drawing. Vanilla samples whole ticks; this
    /// adds the clock's own fraction and how far it runs over <paramref name="partialTick"/> of a tick.
    /// </summary>
    public double GetTicksAt(Identifier clock, float partialTick) {
        ClockInstance instance = GetInstance(clock);
        return instance.TotalTicks + instance.PartialTick + (double)instance.Rate * partialTick;
    }

    private sealed class ClockInstance {
        public long TotalTicks;
        public float PartialTick;
        public float Rate = 1.0F;
    }
}
