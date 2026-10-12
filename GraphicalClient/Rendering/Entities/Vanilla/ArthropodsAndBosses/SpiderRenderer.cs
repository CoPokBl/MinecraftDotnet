namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SpiderRenderer : MobRenderer<LivingEntityRenderState, SpiderModel> {
    public SpiderRenderer(EntityRendererContext context) : this(context, SpiderModel.CreateSpiderBodyLayer()) { }

    protected SpiderRenderer(EntityRendererContext context, LayerDefinition model) : base(new SpiderModel(model.BakeRoot()), 0.8F) {
        AddLayer(new SpiderEyesLayer(this));
    }

    protected override float GetFlipDegrees() => 180.0F;

    public override string GetTextureLocation(LivingEntityRenderState state) => "minecraft:textures/entity/spider/spider.png";
}
