using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record ArmorStandMeta(
    ArmorStandState? State = null,
    Vec3<float>? HeadRotation = null,
    Vec3<float>? BodyRotation = null,
    Vec3<float>? LeftArmRotation = null,
    Vec3<float>? RightArmRotation = null,
    Vec3<float>? LeftLegRotation = null,
    Vec3<float>? RightLegRotation = null) : LivingEntityMeta {

    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (ArmorStandMeta)base.LoadFields(container) with
        {
            State = (ArmorStandState?)container.GetValue<sbyte>(15),
            HeadRotation = container.GetValue<Vec3<float>>(16),
            BodyRotation = container.GetValue<Vec3<float>>(17),
            LeftArmRotation = container.GetValue<Vec3<float>>(18),
            RightArmRotation = container.GetValue<Vec3<float>>(19),
            LeftLegRotation = container.GetValue<Vec3<float>>(20),
            RightLegRotation = container.GetValue<Vec3<float>>(21)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(15, MetaFieldType.Byte, State)
            .WithField(16, MetaFieldType.Rotations, HeadRotation)
            .WithField(17, MetaFieldType.Rotations, BodyRotation)
            .WithField(18, MetaFieldType.Rotations, LeftArmRotation)
            .WithField(19, MetaFieldType.Rotations, RightArmRotation)
            .WithField(20, MetaFieldType.Rotations, LeftLegRotation)
            .WithField(21, MetaFieldType.Rotations, RightLegRotation);
    }
}

