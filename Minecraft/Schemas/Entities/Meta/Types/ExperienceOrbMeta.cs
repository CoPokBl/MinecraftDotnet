namespace Minecraft.Schemas.Entities.Meta.Types;

public record ExperienceOrbMeta(int? Experience = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (ExperienceOrbMeta)base.LoadFields(container) with {
            Experience = container.GetValue<int>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.VarInt, Experience);
    }
}
