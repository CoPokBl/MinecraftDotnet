using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record ItemFrameMeta(
    Cardinal? Direction = null, 
    ItemStack? Item = null, 
    int? Rotation = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (ItemFrameMeta)base.LoadFields(container) with {
            Direction = container.GetValue<Cardinal>(8),
            Item = container.GetValue<ItemStack>(9),
            Rotation = container.GetValue<int>(10)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Direction, Direction)
            .WithField(9, MetaFieldType.Slot, Item)
            .WithField(10, MetaFieldType.VarInt, Rotation);
    }
}