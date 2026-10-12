using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class PhantomRenderState : LivingEntityRenderState {
    public float FlapTime;
    public int Size;
}

public sealed class PhantomRenderer : MobRenderer<PhantomRenderState, PhantomModel> {
    public PhantomRenderer(EntityRendererContext context) : base(new PhantomModel(PhantomModel.CreateBodyLayer().BakeRoot()), 0.75F) {
        AddLayer(new PhantomEyesLayer(this));
    }

    public override string GetTextureLocation(PhantomRenderState state) => "minecraft:textures/entity/phantom/phantom.png";

    /// <summary><c>Phantom.shouldRenderAtSqrDistance</c>: at any distance.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => true;

    public override void ExtractRenderState(ClientEntity entity, PhantomRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // Phantom.getUniqueFlapTickOffset.
        state.FlapTime = entity.Id * 3 + state.AgeInTicks;
        state.Size = entity.Get(EntityDataFields.Phantom.IdSize);
    }

    protected override void Scale(PhantomRenderState state, PoseStack pose) {
        float scale = 1.0F + 0.15F * state.Size;
        pose.Scale(scale, scale, scale);
        pose.Translate(0.0F, 1.3125F, 0.1875F);
    }

    protected override void SetupRotations(PhantomRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        pose.RotateXDegrees(state.XRot);
    }
}
