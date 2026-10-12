using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class TadpoleRenderer : MobRenderer<LivingEntityRenderState, TadpoleModel> {
    public TadpoleRenderer(EntityRendererContext context) : base(new TadpoleModel(TadpoleModel.CreateBodyLayer().BakeRoot()), 0.14F) { }

    public override string GetTextureLocation(LivingEntityRenderState state) => "minecraft:textures/entity/tadpole/tadpole.png";

    public override void ExtractRenderState(ClientEntity entity, LivingEntityRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // LivingEntityRenderer.extractRenderState's isInWater, which the shared extraction leaves unset.
        state.IsInWater = EntityWater.IsInWater(context.Level, entity);
    }
}
