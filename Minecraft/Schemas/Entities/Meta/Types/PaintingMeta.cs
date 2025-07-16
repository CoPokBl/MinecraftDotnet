using Minecraft.Schemas.Blocks.BlockEnums;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record PaintingMeta(Cardinal? Direction = null, int? Variant = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (PaintingMeta)base.LoadFields(container) with {
            Direction = container.GetValue<Cardinal>(8),
            Variant = container.GetValue<int>(9)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Direction, Direction)
            .WithField(9, MetaFieldType.PaintingVariant, Variant);
    }
}
