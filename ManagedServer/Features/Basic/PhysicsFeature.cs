using System.Drawing;
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
        AddEventListener<ServerTickEvent>(e => {
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
        // entity.Velocity = entity.Velocity.WithY(entity.Velocity.Y - entity.Type.Acceleration * 20.0 * delta);
        Vec3 newPos = entity.Position + entity.Velocity;
        
        double drag = 0.98;
        
        // On ground check
        Vec3 groundCheckPos = entity.Position - new Vec3(0, 0.01, 0);
        
        if (world.IsInBounds(groundCheckPos)) {
            IBlock groundBlock = world.GetBlock(groundCheckPos);
            entity.OnGround = groundBlock.CollisionShape.Add(groundCheckPos.ToBlockPos())
                .CollidesWithAabb((Aabb)entity.BoundingBox.Add(entity.Position - new Vec3(0, 0.001, 0)));

            if (entity.OnGround) {
                IBlock frictionBlock = world.GetBlockOr(entity.Position - new Vec3(0, 0.999, 0), Block.Air);
                drag *= frictionBlock.Friction;
            }
        }
        else {
            entity.OnGround = false;
        }
        
        entity.Velocity *= new Vec3(drag, 0.98, drag);

        Vec3 size = entity.BoundingBox.Size;

        for (int axis = 0; axis < 3; axis++) {
            double movement = entity.Velocity[axis];

            if (movement == 0) {
                continue;
            }

            Vec3 checkPos = entity.Position + Vec3.FromAxis(axis, movement);
            Vec3 moveOffset = movement > 0 ? Vec3.FromAxis(axis, size[axis]) : Vec3.Zero;

            // Go through each corner
            for (int otherAxis = 0; otherAxis < 3; otherAxis++) {
                if (otherAxis == axis) {
                    continue;
                }
                
                for (double far = 0; far < 2; far++) {
                    Vec3 corner = checkPos + entity.BoundingBox.Position + Vec3.FromAxis(otherAxis, size[otherAxis] * far) + moveOffset;
                    
                    IVec3 blockPos = corner.ToBlockPos();
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
                    newPos = newPos.With(axis, pos);
                    checkPos = checkPos.With(axis, pos);
                    entity.Velocity = entity.Velocity.With(axis, 0);
                }
            }
        }
        
        entity.Move(newPos);
    }
}