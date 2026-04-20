using Minecraft.Schemas.Blocks.BlockEnums;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record HangingMeta(
    Cardinal? Direction = null) : EntityMeta {

    public override int GetObjectData() => (int)(Direction ?? Cardinal.South);

    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (HangingMeta)base.LoadFields(container) with {
            Direction = container.GetValue<Cardinal>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Direction, Direction);
    }
}
