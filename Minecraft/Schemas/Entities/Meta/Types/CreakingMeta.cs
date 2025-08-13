using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record CreakingMeta(
    bool? CanMove = null, bool? IsActive = null, bool? IsTearingDown = null, Vec3<int>? Home = null) : MobMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (CreakingMeta)base.LoadFields(container) with {
            CanMove = container.GetValue<bool>(16),
            IsActive = container.GetValue<bool>(17),
            IsTearingDown = container.GetValue<bool>(18),
            Home = container.GetValue<Vec3<int>>(19)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(16, MetaFieldType.Boolean, CanMove)
            .WithField(17, MetaFieldType.Boolean, IsActive)
            .WithField(18, MetaFieldType.Boolean, IsTearingDown)
            .WithField(19, MetaFieldType.Position, Home);
    }
}
