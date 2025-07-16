using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record FallingBlockMeta(IVec3? SpawnPosition = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (FallingBlockMeta)base.LoadFields(container) with {
            SpawnPosition = container.GetValue<IVec3>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Position, SpawnPosition);
    }
}