namespace Minecraft.Schemas.Entities.Meta.Types;

public record AbstractArrowMeta(
    ArrowFlag? ArrowFlags = null, 
    sbyte? PiercingLevel = null, 
    bool? InGround = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (AbstractArrowMeta)base.LoadFields(container) with {
            ArrowFlags = container.GetValue<ArrowFlag>(8),
            PiercingLevel = container.GetValue<sbyte>(9),
            InGround = container.GetValue<bool>(10)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Byte, ArrowFlags)
            .WithField(9, MetaFieldType.Byte, PiercingLevel)
            .WithField(10, MetaFieldType.Boolean, InGround);
    }
}
