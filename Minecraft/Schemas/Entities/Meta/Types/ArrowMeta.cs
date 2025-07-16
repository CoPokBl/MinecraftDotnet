namespace Minecraft.Schemas.Entities.Meta.Types;

// colour is -1 for no particles
public record ArrowMeta(int? Color = null) : AbstractArrowMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (ArrowMeta)base.LoadFields(container) with {
            Color = container.GetValue<int>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.VarInt, Color);
    }
}
