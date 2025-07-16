namespace Minecraft.Schemas.Entities.Meta.Types;

public record WitherSkullMeta(bool? IsInvulnerable = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (WitherSkullMeta)base.LoadFields(container) with {
            IsInvulnerable = container.GetValue<bool>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Boolean, IsInvulnerable);
    }
}
