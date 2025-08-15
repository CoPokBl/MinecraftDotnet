using Minecraft.Data.Blocks;

namespace Minecraft.Schemas.Entities.Meta.Types;

public record BlockDisplayMeta(IBlock? DisplayedBlockState = null) : DisplayMeta {
    
    public override EntityMeta LoadFields(EntityMetaContainer container) {
        return (BlockDisplayMeta)base.LoadFields(container) with {
            DisplayedBlockState = container.GetValue<IBlock>(23)
        };
    }
    
    public override EntityMetaContainer CreateContainer() {
        return base.CreateContainer()
            .WithField(23, MetaFieldType.BlockState, DisplayedBlockState);
    }
}
