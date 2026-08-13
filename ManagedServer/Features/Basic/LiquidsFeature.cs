using System.Collections.Concurrent;
using ManagedServer.Events;
using ManagedServer.Fluids;
using ManagedServer.Worlds;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Makes water and lava flow, a port of vanilla's fluid engine. See <see cref="FluidSimulation"/> for
/// what it does; this only owns one of those per world and drives it off the server tick.
/// <p/>
/// Nothing else has to be registered for a fluid to move: the simulation watches
/// <see cref="WorldChangeEvent"/>, so a block placed or broken by any other feature starts a flow the
/// same way a bucket does.
/// </summary>
public class LiquidsFeature(
    bool fastLava = false,
    bool dropDestroyedBlocks = false,
    bool waterSourceConversion = true,
    bool lavaSourceConversion = false) : ScopedFeature {

    // Reached from the tick thread and from whatever thread wrote a block, so it cannot be a plain
    // dictionary.
    private readonly ConcurrentDictionary<World, FluidSimulation> _simulations = new();

    /// <summary>Nether style lava: half the drop off, twice the range and three times the speed.</summary>
    public bool FastLava { get; set; } = fastLava;

    /// <summary>Whether a block washed away by water drops its item.</summary>
    public bool DropDestroyedBlocks { get; set; } = dropDestroyedBlocks;

    /// <summary>Vanilla's <c>waterSourceConversion</c> game rule: two sources beside each other make a third.</summary>
    public bool WaterSourceConversion { get; set; } = waterSourceConversion;

    /// <summary>Vanilla's <c>lavaSourceConversion</c> game rule, off there too.</summary>
    public bool LavaSourceConversion { get; set; } = lavaSourceConversion;

    public FluidSimulation GetSimulation(World world) {
        return _simulations.GetOrAdd(world, static (w, self) => new FluidSimulation(w) {
            FastLava = self.FastLava,
            DropDestroyedBlocks = self.DropDestroyedBlocks,
            WaterSourceConversion = self.WaterSourceConversion,
            LavaSourceConversion = self.LavaSourceConversion
        }, this);
    }

    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            foreach (World world in e.Server.Worlds) {
                GetSimulation(world).Tick(e.Server.CurrentTick);
            }
        });

        AddEventHandler<WorldChangeEvent>(e => {
            FluidSimulation simulation = GetSimulation(e.World);
            if (simulation.Writing) {
                return;  // the simulation runs its own neighbour updates inline, after the write
            }

            simulation.QueueExternalChange(e.Position);
        });
    }

    public override void Unregister() {
        base.Unregister();
        _simulations.Clear();
    }
}
