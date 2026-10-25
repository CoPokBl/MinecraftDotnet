using ClientLib.Maths;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;

namespace ClientLib.Entities;

/// <summary>
/// <c>Leashable</c> as the client sees it: who holds a lead, and where it ties on at either end. The
/// holder is resolved by id whenever it is asked for, so a holder the client has dropped holds nothing.
/// </summary>
public static class Leashes {
    /// <summary>Whether the type implements <c>Leashable</c>: every mob and every boat.</summary>
    public static bool IsLeashable(ClientEntity entity) => entity.Is(EntityClass.Mob) || entity.Is(EntityClass.AbstractBoat);

    /// <summary><c>Leashable.getLeashHolder</c>.</summary>
    public static ClientEntity? Holder(ClientEntity entity, MinecraftClient client) =>
        entity.LeashHolderId != 0 && client.Entities.TryGetValue(entity.LeashHolderId, out ClientEntity? holder) ? holder : null;

    /// <summary><c>supportQuadLeash</c>: horses but not llamas, boats and sniffers.</summary>
    public static bool SupportQuadLeash(ClientEntity entity) =>
        entity.Is(EntityClass.AbstractHorse) && !entity.Is(EntityClass.Llama) || entity.Is(EntityClass.AbstractBoat) || entity.Is(EntityClass.Sniffer);

    /// <summary><c>Entity.supportQuadLeashAsHolder</c>.</summary>
    public static bool SupportQuadLeashAsHolder(ClientEntity holder) => holder.Is(EntityClass.Ghast) || holder.Is(EntityClass.HappyGhast);

    /// <summary><c>getQuadLeashOffsets</c>.</summary>
    public static Vec3d[] QuadLeashOffsets(ClientEntity entity) =>
        entity.Is(EntityClass.Camel) ? CreateQuadLeashOffsets(entity, 0.02, 0.48, 0.25, 0.82)
        : entity.Is(EntityClass.AbstractChestedHorse) || entity.Is(EntityClass.ZombieHorse) ? CreateQuadLeashOffsets(entity, 0.04, 0.41, 0.18, 0.73)
        : entity.Is(EntityClass.AbstractHorse) ? CreateQuadLeashOffsets(entity, 0.04, 0.52, 0.23, 0.87)
        : entity.Is(EntityClass.AbstractBoat) ? CreateQuadLeashOffsets(entity, 0.0, 0.64, 0.382, 0.88)
        : entity.Is(EntityClass.Sniffer) ? CreateQuadLeashOffsets(entity, -0.01, 0.63, 0.38, 1.15)
        : CreateQuadLeashOffsets(entity, 0.0, 0.5, 0.5, 0.5);

    /// <summary><c>Entity.getQuadLeashHolderOffsets</c>.</summary>
    public static Vec3d[] QuadLeashHolderOffsets(ClientEntity holder) => holder.Is(EntityClass.HappyGhast)
        ? CreateQuadLeashOffsets(holder, -0.03125, 0.4375, 0.46875, 0.03125)
        : CreateQuadLeashOffsets(holder, 0.0, 0.5, 0.5, 0.0);

    /// <summary><c>Leashable.createQuadLeashOffsets</c>.</summary>
    public static Vec3d[] CreateQuadLeashOffsets(ClientEntity entity, double frontOffset, double frontBack, double leftRight, double height) {
        (float width, float bbHeight) = BbSize(entity);
        double frontOffsetScaled = frontOffset * width;
        double frontBackScaled = frontBack * width;
        double leftRightScaled = leftRight * width;
        double heightScaled = height * bbHeight;
        return [
            new Vec3d(-leftRightScaled, heightScaled, frontBackScaled + frontOffsetScaled),
            new Vec3d(-leftRightScaled, heightScaled, -frontBackScaled + frontOffsetScaled),
            new Vec3d(leftRightScaled, heightScaled, -frontBackScaled + frontOffsetScaled),
            new Vec3d(leftRightScaled, heightScaled, frontBackScaled + frontOffsetScaled)
        ];
    }

    /// <summary><c>getLeashOffset(partialTicks)</c>: where the lead ties on, before the body's turn.</summary>
    public static Vec3d LeashOffset(ClientEntity entity, float partialTick) {
        (float width, float height) = BbSize(entity);
        float eye = entity.CurrentEyeHeight;
        if (entity is Vehicles.ClientCamel camel) {
            return camel.LeashOffset(partialTick);
        }
        return entity.Is(EntityClass.IronGolem) ? new Vec3d(0.0, 0.875F * eye, width * 0.4F)
            : entity.Is(EntityClass.Allay) ? new Vec3d(0.0, eye * 0.6, width * 0.1)
            : entity.Is(EntityClass.Ocelot) || entity.Is(EntityClass.Parrot) ? new Vec3d(0.0, 0.5F * eye, width * 0.4F)
            : entity.Is(EntityClass.CopperGolem) ? new Vec3d(0.0, 0.75F * eye, 0.0)
            : entity.Is(EntityClass.Llama) ? new Vec3d(0.0, 0.75 * eye, width * 0.5)
            : entity.Is(EntityClass.Pig) || entity.Is(EntityClass.Wolf) || entity.Is(EntityClass.Strider) || entity.Is(EntityClass.Rabbit)
                ? new Vec3d(0.0, 0.6F * eye, width * 0.4F)
            : entity.Is(EntityClass.Bee) ? new Vec3d(0.0, 0.5F * eye, width * 0.2F)
            : entity.Is(EntityClass.Fox) ? new Vec3d(0.0, 0.55F * eye, width * 0.4F)
            : entity.Is(EntityClass.SnowGolem) ? new Vec3d(0.0, 0.75F * eye, width * 0.4F)
            : entity.Is(EntityClass.HappyGhast) ? Vec3d.Zero
            : entity.Is(EntityClass.SulfurCube) ? new Vec3d(0.0, height / 2.0F, 0.0)
            : entity.Is(EntityClass.AbstractBoat) ? new Vec3d(0.0, 0.88F * height, 0.64F * width)
            : new Vec3d(0.0, eye, width * 0.4F);
    }

    /// <summary><c>getRopeHoldPosition</c>: where a holder's end of the lead is.</summary>
    public static Vec3d RopeHoldPosition(ClientEntity holder, float partialTick) {
        Vec3d position = Position(holder, partialTick);
        if (holder.Is(EntityClass.LeashFenceKnotEntity)) {
            return position + new Vec3d(0.0, 0.2, 0.0);
        }
        if (holder.Is(EntityClass.AbstractVillager)) {
            float villagerYRot = Mth.Lerp(partialTick, holder.YBodyRotO, holder.YBodyRot) * (float)(Math.PI / 180.0);
            Vec3d offset = new(0.0, holder.BoundingBox.MaxY - holder.BoundingBox.MinY - 1.0, 0.2);
            return position + ClientEntity.YRotate(offset, -villagerYRot);
        }
        if (holder.Is(EntityClass.Player)) {
            return position + PlayerRopeHoldOffset(holder, partialTick);
        }
        return position + new Vec3d(0.0, holder.CurrentEyeHeight * 0.7, 0.0);
    }

    /// <summary><c>Player.getRopeHoldPosition</c>, less the position.</summary>
    private static Vec3d PlayerRopeHoldOffset(ClientEntity player, float partialTick) {
        double xOff = 0.22 * (player.Get(EntityDataFields.Avatar.PlayerMainHand, HumanoidArm.Right) == HumanoidArm.Right ? -1.0 : 1.0);
        // The arguments are the other way round from every other lerp of a rotation, as they are in vanilla.
        float xRot = Mth.Lerp(partialTick * 0.5F, player.XRot, player.XRotO) * (float)(Math.PI / 180.0);
        float yRot = Mth.Lerp(partialTick, player.YBodyRotO, player.YBodyRot) * (float)(Math.PI / 180.0);
        bool fallFlying = (player.SharedFlags & 0x80) != 0;
        bool autoSpinAttack = (player.Get(EntityDataFields.LivingEntity.LivingEntityFlags) & 0x04) != 0;
        EntityPose pose = player.Get(EntityDataFields.Entity.Pose, EntityPose.Standing);
        if (fallFlying || autoSpinAttack) {
            Vec3d lookAngle = Interaction.Picking.ViewVector(player, partialTick);
            Vec3d movement = player.DeltaMovement;
            double speedLen = movement.X * movement.X + movement.Z * movement.Z;
            double lookLen = lookAngle.X * lookAngle.X + lookAngle.Z * lookAngle.Z;
            float zRot;
            if (speedLen > 0.0 && lookLen > 0.0) {
                double dot = (movement.X * lookAngle.X + movement.Z * lookAngle.Z) / Math.Sqrt(speedLen * lookLen);
                double sign = movement.X * lookAngle.Z - movement.Z * lookAngle.X;
                zRot = (float)(Math.Sign(sign) * Math.Acos(dot));
            }
            else {
                zRot = 0.0F;
            }
            return ClientEntity.YRotate(ClientEntity.XRotate(ZRotate(new Vec3d(xOff, -0.11, 0.85), -zRot), -xRot), -yRot);
        }
        if (pose == EntityPose.Swimming) {
            return ClientEntity.YRotate(ClientEntity.XRotate(new Vec3d(xOff, 0.2, -0.15), -xRot), -yRot);
        }
        double yOff = player.BoundingBox.MaxY - player.BoundingBox.MinY - 1.0;
        double zOff = pose == EntityPose.Sneaking ? -0.2 : 0.07;
        return ClientEntity.YRotate(new Vec3d(xOff, yOff, zOff), -yRot);
    }

    /// <summary><c>getBbWidth</c> and <c>getBbHeight</c>: the current dimensions, as the box was made from them.</summary>
    private static (float Width, float Height) BbSize(ClientEntity entity) {
        Minecraft.Physics.Box box = entity.BoundingBox;
        return ((float)(box.MaxX - box.MinX), (float)(box.MaxY - box.MinY));
    }

    /// <summary><c>Entity.getPosition(partialTicks)</c>.</summary>
    public static Vec3d Position(ClientEntity entity, float partialTick) => new(
        ClientEntity.Lerp(partialTick, entity.OldPosition.X, entity.Position.X),
        ClientEntity.Lerp(partialTick, entity.OldPosition.Y, entity.Position.Y),
        ClientEntity.Lerp(partialTick, entity.OldPosition.Z, entity.Position.Z));

    /// <summary><c>Entity.getPreciseBodyRotation</c>: the body's yaw for a living entity, the entity's own otherwise.</summary>
    public static float PreciseBodyRotation(ClientEntity entity, float partialTick) => entity.IsLiving
        ? Mth.Lerp(partialTick, entity.YBodyRotO, entity.YBodyRot)
        : Mth.Lerp(partialTick, entity.YRotO, entity.YRot);

    /// <summary><c>Vec3.zRot</c>.</summary>
    private static Vec3d ZRotate(Vec3d v, float radians) {
        float cos = Mth.Cos(radians);
        float sin = Mth.Sin(radians);
        return new Vec3d(v.X * cos + v.Y * sin, v.Y * cos - v.X * sin, v.Z);
    }
}
