using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Physics;
using ManagedServer.Worlds;

namespace ManagedServer.Features.Basic;

/// <summary>
/// Runs vanilla entity movement, see <see cref="EntityPhysics"/>, for every entity in every world
/// each tick.
/// <p/>
/// Players are never simulated: their own client owns their movement and sends us the result, so
/// simulating them here would fight the client rather than agree with it.
/// </summary>
public class PhysicsFeature(Func<Entity, bool>? entityFilter = null) : ScopedFeature {
    private Func<Entity, bool> EntityFilter { get; } = entityFilter ?? (_ => true);

    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            foreach (World world in e.Server.Worlds) {
                foreach (Entity entity in world.Entities.GetEntities()) {
                    if (entity is Player || !EntityFilter(entity)) {
                        continue;
                    }

                    EntityPhysics.Tick(world, entity);
                }
            }
        });
    }
}
