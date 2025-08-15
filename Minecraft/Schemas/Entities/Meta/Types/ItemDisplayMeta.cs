using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record ItemDisplayMeta(
    ItemStack? DisplayedItem = null,
    ItemDisplayMeta.DisplayType? ItemDisplayType = null) : DisplayMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (ItemDisplayMeta)base.LoadFields(container) with {
            DisplayedItem = container.GetValue<ItemStack>(23),
            ItemDisplayType = container.GetValue<DisplayType>(24)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(23, MetaFieldType.Slot, DisplayedItem)
            .WithField(24, MetaFieldType.Byte, (sbyte?)ItemDisplayType);
    }
    
    public enum DisplayType : sbyte {
        None = 0,
        ThirdPersonLeftHand = 1,
        ThirdPersonRightHand = 2,
        FirstPersonLeftHand = 3,
        FirstPersonRightHand = 4,
        Head = 5,
        Gui = 6,
        Ground = 7,
        Fixed = 8
    }
}
