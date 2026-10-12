using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BlazeRenderer : MobRenderer<LivingEntityRenderState, BlazeModel> {
    public BlazeRenderer(EntityRendererContext context) : base(new BlazeModel(BlazeModel.CreateBodyLayer().BakeRoot()), 0.5F) { }

    public override string GetTextureLocation(LivingEntityRenderState state) => "minecraft:textures/entity/blaze/blaze.png";

    public override void ExtractRenderState(ClientEntity entity, LivingEntityRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel.
        state.BlockLight = 15;
    }
}
