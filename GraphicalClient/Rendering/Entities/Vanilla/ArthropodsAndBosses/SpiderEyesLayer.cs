namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SpiderEyesLayer : EyesLayer<LivingEntityRenderState, SpiderModel> {
    public SpiderEyesLayer(LivingEntityRenderer<LivingEntityRenderState, SpiderModel> parent) : base(parent) { }

    public override string Texture => "minecraft:textures/entity/spider/spider_eyes.png";
}
