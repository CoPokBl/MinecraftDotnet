using ManagedServer.Entities.Types;
using ManagedServer.Events;

namespace ManagedServer.Features.Impl;

public class DropItemsOnGroundFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerDropItemEvent>(e => {
            if (e.Cancelled) {
                return;
            }

            PlayerEntity player = e.Player;
            
            Entity itemEntity = e.World.DropItem(player.Position.WithY(player.Position.Y + player.EyeHeight - 0.3), e.Item);
            // TODO: set thrower

            itemEntity.Velocity = player.Direction.Multiply(0.4);

            // double yaw = player.Pitch.Radians;
            // double pitch = player.Pitch.Radians;
            //
            // double yVel = Math.Sin(pitch);
            // double forwardVel = Math.Cos(pitch);
            // double xVel = Math.Sin(yaw);
            // double zVel = Math.Cos(yaw);
            // double angleOffset = Random.Shared.NextDouble() * Math.Tau;
            // double angleOffsetMultiplier = 0.02 * Random.Shared.NextDouble();
            //
            // itemEntity.Velocity = new Vec3(
            //     -xVel * forwardVel * 0.3 + Math.Cos(angleOffset) * angleOffsetMultiplier,
            //     -yVel * 0.3 + 0.1 + (Random.Shared.NextDouble() - Random.Shared.NextDouble()) * 0.1,
            //     zVel * forwardVel * 0.3 + Math.Sin(angleOffset) * angleOffsetMultiplier
            // );
        });
    }
}
