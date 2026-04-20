using Minecraft.Data.PaintingVariant;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record PaintingMeta(Or<int, IPaintingVariant>? Variant = null, Cardinal? Direction = null) : HangingMeta(Direction) {

    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (PaintingMeta)base.LoadFields(container) with {
            Variant = container.GetValue<Or<int, IPaintingVariant>>(9)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(9, MetaFieldType.PaintingVariant, Variant);
    }
}
