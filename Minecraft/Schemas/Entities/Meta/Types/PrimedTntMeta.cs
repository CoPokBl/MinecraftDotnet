using Minecraft.Data.Blocks;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record PrimedTntMeta(int? FuseTime = null, IBlock? Block = null) : EntityMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (PrimedTntMeta)base.LoadFields(container) with {
            FuseTime = container.GetValue<int>(8),
            Block = container.GetValue<IBlock>(9)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(8, MetaFieldType.VarInt, FuseTime)
            .WithField(9, MetaFieldType.BlockState, Block);
    }
}
