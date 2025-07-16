using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record FireworkRocketMeta(
    ItemStack? FireworkItem = null, 
    Optional<int>? UserId = null, 
    bool? ShotAtAngle = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (FireworkRocketMeta)base.LoadFields(container) with {
            FireworkItem = container.GetValue<ItemStack>(8),
            UserId = container.GetValue<Optional<int>>(9),
            ShotAtAngle = container.GetValue<bool>(10)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Slot, FireworkItem)
            .WithField(9, MetaFieldType.OptionalVarInt, UserId)
            .WithField(10, MetaFieldType.Boolean, ShotAtAngle);
    }
}
