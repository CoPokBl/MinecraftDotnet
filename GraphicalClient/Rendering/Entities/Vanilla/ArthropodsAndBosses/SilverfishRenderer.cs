namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SilverfishRenderer : MobRenderer<LivingEntityRenderState, SilverfishModel> {
    public SilverfishRenderer(EntityRendererContext context) : base(new SilverfishModel(SilverfishModel.CreateBodyLayer().BakeRoot()), 0.3F) { }

    protected override float GetFlipDegrees() => 180.0F;

    public override string GetTextureLocation(LivingEntityRenderState state) => "minecraft:textures/entity/silverfish/silverfish.png";
}
