using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;

namespace GraphicalClient.Rendering.BlockEntities;

public sealed class PistonHeadRenderState : BlockEntityRenderState {
    public IBlock? Block, Base;
    public float XOffset, YOffset, ZOffset;
}

/// <summary>
/// <c>PistonHeadRenderer</c>: the block a piston is moving, between where it was and where it is going.
/// The moving block is lit as the piston's own position is, where vanilla lights each vertex from the
/// level; it is drawn only with a resource pack, as every block model outside the terrain is.
/// </summary>
public sealed class PistonHeadRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<PistonMovingBlockEntity, PistonHeadRenderState> {
    public override int ViewDistance => 68;

    public override void ExtractRenderState(PistonMovingBlockEntity blockEntity, PistonHeadRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        (state.XOffset, state.YOffset, state.ZOffset) = blockEntity.GetOffset(partialTick);
        IBlock blockState = blockEntity.MovedState;
        if (blockState.Air) {
            return;
        }
        float progress = blockEntity.GetProgress(partialTick);
        if (blockState is PistonHeadBlock head && progress <= 4.0F) {
            state.Block = head with { Short = progress <= 0.5F };
        }
        else if (blockEntity.IsSourcePiston && !blockEntity.Extending && blockState is PistonBlock or StickyPistonBlock) {
            bool sticky = blockState is StickyPistonBlock;
            Minecraft.Schemas.Blocks.BlockEnums.Cardinal facing = blockState is PistonBlock piston ? piston.Facing : ((StickyPistonBlock)blockState).Facing;
            state.Block = (PistonHeadBlock)Minecraft.Data.Generated.Block.PistonHead with {
                TypeValue = sticky ? PistonHeadBlock.Type.Sticky : PistonHeadBlock.Type.Normal, Facing = facing, Short = progress >= 0.5F
            };
            state.Base = blockState switch {
                PistonBlock p => p with { Extended = true },
                StickyPistonBlock p => p with { Extended = true },
                _ => blockState
            };
        }
        else {
            state.Block = blockState;
        }
    }

    public override void Submit(PistonHeadRenderState state, PoseStack pose, EntityRenderContext render) {
        if (state.Block == null) {
            return;
        }
        pose.Push();
        pose.Translate(state.XOffset, state.YOffset, state.ZOffset);
        context.Blocks.Render(state.Block, pose, render.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
        if (state.Base != null) {
            context.Blocks.Render(state.Base, pose, render.Batch, state.SkyLight, state.BlockLight);
        }
    }
}
