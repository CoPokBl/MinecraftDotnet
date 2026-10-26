using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CodRenderer : MobRenderer<LivingEntityRenderState, CodModel> {
    public CodRenderer(EntityRendererContext context) : base(new CodModel(CodModel.CreateBodyLayer().BakeRoot()), 0.3F) { }

    public override string GetTextureLocation(LivingEntityRenderState state) => "minecraft:textures/entity/fish/cod.png";

    public override void ExtractRenderState(ClientEntity entity, LivingEntityRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsInWater = EntityWater.IsInWater(context.Level, entity);
    }

    protected override void SetupRotations(LivingEntityRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        float bodyZRot = 4.3F * Mth.Sin(0.6F * state.AgeInTicks);
        pose.RotateYDegrees(bodyZRot);
        if (!state.IsInWater) {
            pose.Translate(0.1F, 0.1F, -0.1F);
            pose.RotateZDegrees(90.0F);
        }
    }
}
