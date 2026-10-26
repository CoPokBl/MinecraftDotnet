namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CaveSpiderRenderer : SpiderRenderer {
    public CaveSpiderRenderer(EntityRendererContext context) : base(context, SpiderModel.CreateSpiderBodyLayer().Apply(MeshTransformers.Scaling(0.7F))) {
        ShadowRadius = 0.56F;
    }

    public override string GetTextureLocation(LivingEntityRenderState state) => "minecraft:textures/entity/spider/cave_spider.png";
}
