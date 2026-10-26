namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class EndermiteRenderer : MobRenderer<LivingEntityRenderState, EndermiteModel> {
    public EndermiteRenderer(EntityRendererContext context) : base(new EndermiteModel(EndermiteModel.CreateBodyLayer().BakeRoot()), 0.3F) { }

    protected override float GetFlipDegrees() => 180.0F;

    public override string GetTextureLocation(LivingEntityRenderState state) => "minecraft:textures/entity/endermite/endermite.png";
}
