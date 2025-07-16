using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record LivingEntityMeta(
    HandState? HandStates = null,
    float? Health = null,
    int[]? Particles = null,
    bool? IsPotionAmbient = null,
    int? ArrowsInEntity = null,
    int? BeeStingersInEntity = null,
    Optional<IVec3>? SleepingBed = null) : EntityMeta {

    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (LivingEntityMeta)base.LoadFields(container) with {
            HandStates = container.GetValue<HandState>(8),
            Health = container.GetValue<float>(9),
            Particles = container.GetValue<int[]>(10),
            IsPotionAmbient = container.GetValue<bool>(11),
            ArrowsInEntity = container.GetValue<int>(12),
            BeeStingersInEntity = container.GetValue<int>(13),
            SleepingBed = container.GetValue<Optional<IVec3>>(14)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Byte, HandStates)
            .WithField(9, MetaFieldType.Float, Health)
            .WithField(10, MetaFieldType.Particles, Particles)
            .WithField(11, MetaFieldType.Boolean, IsPotionAmbient)
            .WithField(12, MetaFieldType.VarInt, ArrowsInEntity)
            .WithField(13, MetaFieldType.VarInt, BeeStingersInEntity)
            .WithField(14, MetaFieldType.OptionalPosition, SleepingBed);
    }
}
