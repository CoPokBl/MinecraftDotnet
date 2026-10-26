namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SlimeRenderer : AbstractCubeMobRenderer<SlimeRenderState, SlimeModel> {
    public const string SlimeLocation = "minecraft:textures/entity/slime/slime.png";

    public SlimeRenderer(EntityRendererContext context) : base(new SlimeModel(SlimeModel.CreateInnerBodyLayer().BakeRoot())) {
        AddLayer(new SlimeOuterLayer(this));
    }

    protected override void Scale(SlimeRenderState state, PoseStack pose) {
        DownscaleSlightly(pose);
        base.Scale(state, pose);
    }

    public override string GetTextureLocation(SlimeRenderState state) => SlimeLocation;
}
