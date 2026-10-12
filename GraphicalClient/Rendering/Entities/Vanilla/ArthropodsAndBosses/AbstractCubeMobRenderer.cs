using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SlimeRenderState : LivingEntityRenderState {
    public float Squish;
    public int Size = 1;
}

public abstract class AbstractCubeMobRenderer<S, M> : MobRenderer<S, M> where S : SlimeRenderState, new() where M : EntityModel<S> {
    protected AbstractCubeMobRenderer(M model) : base(model, 0.25F) { }

    /// <summary><c>AbstractCubeMob.targetSquish</c>, <c>squish</c>, <c>oSquish</c> and <c>wasOnGround</c>, which the client counts itself.</summary>
    protected class CubeMobData {
        public float TargetSquish, Squish, OSquish;
        public bool WasOnGround;
    }

    protected virtual CubeMobData CreateData() => new();

    /// <summary><c>AbstractCubeMob.tick</c>'s squish bookkeeping.</summary>
    public override void Tick(ClientEntity entity) {
        CubeMobData data = (CubeMobData)(entity.RendererData ??= CreateData());
        data.OSquish = data.Squish;
        data.Squish = data.Squish + (data.TargetSquish - data.Squish) * 0.5F;
        if (entity.OnGround && !data.WasOnGround) {
            data.TargetSquish = -0.5F;
        }
        else if (!entity.OnGround && data.WasOnGround) {
            data.TargetSquish = 1.0F;
        }
        data.WasOnGround = entity.OnGround;
        data.TargetSquish *= DecreaseSquishFactor;
    }

    /// <summary><c>decreaseSquish</c>'s factor: 0.6 for slimes, 0.9 for a magma cube.</summary>
    protected virtual float DecreaseSquishFactor => 0.6F;

    protected override void Scale(S state, PoseStack pose) {
        base.Scale(state, pose);
        ApplySizeAndSquish(state, pose);
    }

    protected static void DownscaleSlightly(PoseStack pose) {
        pose.Scale(0.999F, 0.999F, 0.999F);
        pose.Translate(0.0F, 0.001F, 0.0F);
    }

    protected virtual void ApplySizeAndSquish(S state, PoseStack pose) {
        float size = state.Size;
        float ss = state.Squish / (size * 0.5F + 1.0F);
        float w = 1.0F / (ss + 1.0F);
        pose.Scale(w * size, 1.0F / w * size, w * size);
    }

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.Squish = entity.RendererData is CubeMobData data ? Mth.Lerp(partialTick, data.OSquish, data.Squish) : 0;
        state.Size = entity.Get(EntityDataFields.AbstractCubeMob.IdSize, 1);
    }
}
