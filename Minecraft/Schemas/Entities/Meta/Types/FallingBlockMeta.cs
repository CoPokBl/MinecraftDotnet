using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record FallingBlockMeta(Vec3<int>? SpawnPosition = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (FallingBlockMeta)base.LoadFields(container) with {
            SpawnPosition = container.GetValue<Vec3<int>>(8)
        };
    }

    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.Position, SpawnPosition);
    }
}