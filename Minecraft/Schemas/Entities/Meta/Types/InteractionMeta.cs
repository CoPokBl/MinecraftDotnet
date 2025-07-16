namespace Minecraft.Schemas.Entities.Meta.Types;

public record InteractionMeta(
    float? Width = null, 
    float? Height = null, 
    bool? Responsive = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (InteractionMeta)base.LoadFields(container) with {
            Width = container.GetValue<float>(8),
            Height = container.GetValue<float>(9),
            Responsive = container.GetValue<bool>(10)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Float, Width)
            .WithField(9, MetaFieldType.Float, Height)
            .WithField(10, MetaFieldType.Boolean, Responsive);
    }
}
