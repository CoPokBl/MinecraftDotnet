using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Basic;

public class PhysicsFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            foreach (World world in e.Server.Worlds) {
                foreach (Entity entity in world.Entities.Entities.ToArray()) {
                    if (entity is PlayerEntity) {
                        continue;
                    }
                    
                    MoveEntity(world, entity, e.TargetDelta.TotalSeconds);
                }
            }
        });
    }

    private void MoveEntity(World world, Entity entity, double delta) {
        if (!world.IsChunkLoaded(world.GetChunkPos(entity.Position))) {
            return;  // entity is in an unloaded chunk, skip physics
        }
        
        if (!(entity.Meta.NoGravity ?? false)) {
            entity.Velocity = entity.Velocity.WithY(entity.Velocity.Y - entity.Type.Acceleration * 20.0 * delta);
        }
        
        double drag = 0.98;
        
        // On ground check
        Vec3<double> groundCheckPos = entity.Position - new Vec3<double>(0, 0.01, 0);
        
        if (world.IsInBounds(groundCheckPos)) {
            IBlock groundBlock = world.GetBlock(groundCheckPos);
            entity.OnGround = groundBlock.CollisionShape.Add(groundCheckPos.ToBlockPos())
                .CollidesWithAabb((Aabb)entity.BoundingBox.Add(entity.Position - new Vec3<double>(0, 0.001, 0)));

            if (entity.OnGround) {
                IBlock frictionBlock = world.GetBlockOr(entity.Position - new Vec3<double>(0, 0.999, 0), Block.Air);
                drag *= frictionBlock.Friction;
            }
        }
        else {
            entity.OnGround = false;
        }
        
        entity.Velocity *= new Vec3<double>(drag, 0.98, drag);

        Vec3<double> size = entity.BoundingBox.Size;
        Vec3<double> newPos = entity.Position + entity.Velocity;

        for (int axis = 0; axis < 3; axis++) {
            double movement = entity.Velocity[axis];

            if (movement == 0) {
                continue;
            }

            Vec3<double> checkPos = entity.Position + Vec3<double>.FromAxis(axis, movement);
            Vec3<double> moveOffset = movement > 0 ? Vec3<double>.FromAxis(axis, size[axis]) : Vec3<double>.Zero;

            // Go through each corner
            for (int otherAxis = 0; otherAxis < 3; otherAxis++) {
                if (otherAxis == axis) {
                    continue;
                }
                
                for (double far = 0; far < 2; far++) {
                    Vec3<double> corner = checkPos + entity.BoundingBox.Position + Vec3<double>.FromAxis(otherAxis, size[otherAxis] * far) + moveOffset;
                    
                    Vec3<int> blockPos = corner.ToBlockPos();
                    IBlock block = world.GetBlockOr(blockPos, Block.Air);
                    if (block.StateId == Block.Air.StateId) {
                        continue;
                    }

                    Aabb? collision = block.CollisionShape.Add(blockPos)
                        .CollidesWhichAabb((Aabb)entity.BoundingBox.Contract(0.01).Add(checkPos));

                    if (collision == null) {
                        continue;
                    }

                    double pos = collision.Position[axis] + (movement > 0 ? -entity.BoundingBox.Size[axis] * 0.5 : collision.Size[axis] + entity.BoundingBox.Size[axis] * 0.5);
                    if (axis == 1) {
                        pos -= entity.BoundingBox.Size[axis] * 0.5;
                    }
                    
                    newPos = newPos.With(axis, pos);
                    checkPos = checkPos.With(axis, pos);
                    entity.Velocity = entity.Velocity.With(axis, 0);
                }
            }
        }

        // Optimisation: if the entity's position hasn't changed, we can skip the move
        if (entity.Position.DistanceSquaredTo(newPos) < 0.001) {
            return;
        }
        entity.Move(newPos);
    }
}
