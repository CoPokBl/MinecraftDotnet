using Minecraft.Text;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record EntityMeta(
    EntityStatus? Status = null, 
    int? AirTicks = null, 
    Optional<TextComponent>? CustomName = null, 
    bool? CustomNameVisible = null,
    bool? Silent = null,
    bool? NoGravity = null,
    EntityPose? Pose = null,
    int? TicksInPowderedSnow = null) {
    
    public virtual EntityMeta LoadFields(EntityMetaContainer container) {
        return this with {
            Status = container.GetValue<EntityStatus>(0),
            AirTicks = container.GetValue<int>(1),
            CustomName = container.GetValue<Optional<TextComponent>>(2),
            CustomNameVisible = container.GetValue<bool>(3),
            Silent = container.GetValue<bool>(4),
            NoGravity = container.GetValue<bool>(5),
            Pose = container.GetValue<EntityPose>(6),
            TicksInPowderedSnow = container.GetValue<int>(7)
        };
    }
    
    public virtual EntityMetaContainer CreateContainer() {
        return new EntityMetaContainer()
            .WithField(0, MetaFieldType.Byte, (sbyte?)Status)
            .WithField(1, MetaFieldType.VarInt, AirTicks)
            .WithField(2, MetaFieldType.OptionalTextComponent, CustomName)
            .WithField(3, MetaFieldType.Boolean, CustomNameVisible)
            .WithField(4, MetaFieldType.Boolean, Silent)
            .WithField(5, MetaFieldType.Boolean, NoGravity)
            .WithField(6, MetaFieldType.Pose, Pose)
            .WithField(7, MetaFieldType.VarInt, TicksInPowderedSnow);
    }

    public static implicit operator EntityMetaContainer(EntityMeta meta) {
        return meta.CreateContainer();
    }
}
