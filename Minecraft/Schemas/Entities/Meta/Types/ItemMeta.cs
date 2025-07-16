using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record ItemMeta(ItemStack? Item = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (ItemMeta)base.LoadFields(container) with {
            Item = container.GetValue<ItemStack>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Slot, Item);
    }
}