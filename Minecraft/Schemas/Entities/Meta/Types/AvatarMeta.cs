namespace Minecraft.Schemas.Entities.Meta.Types;

public record AvatarMeta(
    DominantHand? MainHand = null,
    SkinParts? SkinFlags = null) : LivingEntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (AvatarMeta)base.LoadFields(container) with {
            MainHand = container.GetValue<DominantHand>(15),
            SkinFlags = container.GetValue<SkinParts>(16)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(15, MetaFieldType.Byte, MainHand)
            .WithField(16, MetaFieldType.Byte, SkinFlags);
    }
}
