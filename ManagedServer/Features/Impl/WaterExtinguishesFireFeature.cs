using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features.Basic;
using ManagedServer.Fluids;
using ManagedServer.Worlds;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Water puts a burning entity out, vanilla's <c>WaterFluid.entityInside</c> applying
/// <c>InsideBlockEffectType.EXTINGUISH</c>.
/// <p/>
/// Fire <i>blocks</i> need nothing here: fire holds fluid like any other block a fluid passes through,
/// so <see cref="FluidSimulation"/> already replaces one that water reaches, and pouring a bucket over
/// it goes down the same path. Fire standing merely <i>beside</i> water is left alone, which is what
/// vanilla does too, see <c>FireBlock.canSurvive</c>.
/// <p/>
/// Needs a <see cref="LiquidsFeature"/> registered, which is what knows where the water is.
/// </summary>
public class WaterExtinguishesFireFeature : ScopedFeature {
    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            LiquidsFeature? liquids = e.Server.FeatureHandler.Features.OfType<LiquidsFeature>().FirstOrDefault();
            if (liquids == null) {
                return;
            }

            foreach (World world in e.Server.Worlds) {
                FluidSimulation fluids = liquids.GetSimulation(world);
                foreach (Entity entity in world.Entities.GetEntities()) {
                    if (EntityFluids.FireTicks(entity) > 0 && EntityFluids.IsIn(fluids, entity, FluidKind.Water)) {
                        EntityFluids.ClearFire(entity);
                    }
                }
            }
        });
    }
}
