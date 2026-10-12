using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>TntRenderState</c>.</summary>
public class TntRenderState : EntityRenderState {
    public float FuseRemainingInTicks;
    public IBlock? BlockState;
}

/// <summary><c>TntRenderer</c>.</summary>
public sealed class TntRenderer : EntityRenderer<TntRenderState> {
    private readonly BlockModelRenderer _blocks;

    public TntRenderer(EntityRendererContext context) {
        ShadowRadius = 0.5F;
        _blocks = context.Blocks;
    }

    /// <summary><c>PrimedTnt.tick</c> counts its fuse down on the client's own copy of the synced value.</summary>
    public override void Tick(ClientEntity entity) {
        LocalEntityData<int> fuse = (LocalEntityData<int>)(entity.RendererData ??= new LocalEntityData<int>(EntityDataFields.PrimedTnt.Fuse, 80));
        fuse.Value = fuse.Sync(entity) - 1;
    }

    public override void Submit(TntRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Translate(0.0F, 0.5F, 0.0F);
        float fuse = state.FuseRemainingInTicks;
        if (fuse < 10.0F) {
            float scale = 1.0F + GetSwellAmount(fuse);
            pose.Scale(scale, scale, scale);
        }
        pose.RotateYDegrees(-90.0F);
        pose.Translate(-0.5F, -0.5F, 0.5F);
        pose.RotateYDegrees(90.0F);
        if (state.BlockState is { } block) {
            TntMinecartRenderer.SubmitWhiteSolidBlock(_blocks, block, pose, context, state.SkyLight, state.BlockLight, IsLit(fuse));
        }
        pose.Pop();
    }

    public static float GetSwellAmount(float fuse) {
        float g = 1.0F - fuse / 10.0F;
        g = Mth.Clamp(g, 0.0F, 1.0F);
        g *= g;
        g *= g;
        return g * 0.3F;
    }

    public static bool IsLit(float fuse) => fuse >= 0.0F && (int)(fuse / 5.0F) % 2 == 0;

    public override void ExtractRenderState(ClientEntity entity, TntRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        int fuse = entity.RendererData is LocalEntityData<int> local ? local.Value : entity.Get(EntityDataFields.PrimedTnt.Fuse, 80);
        state.FuseRemainingInTicks = fuse - partialTick + 1.0F;
        state.BlockState = entity.Get(EntityDataFields.PrimedTnt.BlockState) ?? Block.Tnt;
    }
}
