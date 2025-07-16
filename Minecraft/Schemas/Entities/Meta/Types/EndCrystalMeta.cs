using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record EndCrystalMeta(
    Optional<IVec3>? BeamTarget = null,
    bool? ShowBottom = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (EndCrystalMeta)base.LoadFields(container) with {
            BeamTarget = container.GetValue<Optional<IVec3>>(8),
            ShowBottom = container.GetValue<bool>(9)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.OptionalPosition, BeamTarget)
            .WithField(9, MetaFieldType.Boolean, ShowBottom);
    }
}