namespace Minecraft.Schemas.Entities.Meta.Types;

public record MobMeta(MobFlag? MobFlags = null) : LivingEntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (MobMeta)base.LoadFields(container) with {
            MobFlags = container.GetValue<MobFlag>(15)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(15, MetaFieldType.Byte, (sbyte?)MobFlags);
    }
}
