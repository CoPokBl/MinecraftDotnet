using ClientLib.Entities;
using Minecraft.Data.Blocks;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>FallingBlockRenderState</c> with the part of its <c>MovingBlockRenderState</c> this client draws from.</summary>
public class FallingBlockRenderState : EntityRenderState {
    public IBlock? BlockState;
    public bool SameAsLevel;
}

/// <summary>
/// <c>FallingBlockRenderer</c>. <c>submitMovingBlock</c> lights and tints the block as if placed at its
/// position, smooth lighting and biome colours included; this draws it lit by the entity's own light
/// and with the default tints, which is flatter in a corner and wrong for grass away from plains.
/// </summary>
public sealed class FallingBlockRenderer : EntityRenderer<FallingBlockRenderState> {
    private readonly BlockModelRenderer _blocks;

    public FallingBlockRenderer(EntityRendererContext context) {
        ShadowRadius = 0.5F;
        _blocks = context.Blocks;
    }

    public override void ExtractRenderState(ClientEntity entity, FallingBlockRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // The spawn packet's data is Block.getId of the falling state.
        state.BlockState = context.Client.Registry.Blocks.StatesByStateId.GetValueOrDefault((uint)entity.SpawnData);
        // shouldRender: nothing is drawn once the level holds the same state where the entity is, so a
        // block that has landed is not drawn twice.
        int x = (int)Math.Floor(entity.Position.X), y = (int)Math.Floor(entity.Position.Y), z = (int)Math.Floor(entity.Position.Z);
        state.SameAsLevel = state.BlockState != null && context.Level.GetState(x, y, z) == state.BlockState.StateId;
    }

    public override void Submit(FallingBlockRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.BlockState is not { } block || state.SameAsLevel) {
            return;
        }
        pose.Push();
        pose.Translate(-0.5F, 0.0F, -0.5F);
        _blocks.Render(block, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
