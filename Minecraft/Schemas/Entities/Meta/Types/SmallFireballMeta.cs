using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record SmallFireballMeta(ItemStack? Item = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (SmallFireballMeta)base.LoadFields(container) with {
            Item = container.GetValue<ItemStack>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Slot, Item);
    }
}
