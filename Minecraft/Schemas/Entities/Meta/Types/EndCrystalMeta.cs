using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record EndCrystalMeta(
    Optional<Vec3<int>>? BeamTarget = null,
    bool? ShowBottom = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (EndCrystalMeta)base.LoadFields(container) with {
            BeamTarget = container.GetValue<Optional<Vec3<int>>>(8),
            ShowBottom = container.GetValue<bool>(9)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.OptionalPosition, BeamTarget)
            .WithField(9, MetaFieldType.Boolean, ShowBottom);
    }
}
