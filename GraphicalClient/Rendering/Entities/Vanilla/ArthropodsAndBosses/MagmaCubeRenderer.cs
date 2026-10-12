using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class MagmaCubeRenderer : AbstractCubeMobRenderer<SlimeRenderState, MagmaCubeModel> {
    public MagmaCubeRenderer(EntityRendererContext context) : base(new MagmaCubeModel(MagmaCubeModel.CreateBodyLayer().BakeRoot())) { }

    /// <summary><c>MagmaCube.decreaseSquish</c>.</summary>
    protected override float DecreaseSquishFactor => 0.9F;

    public override void ExtractRenderState(ClientEntity entity, SlimeRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getBlockLightLevel.
        state.BlockLight = 15;
    }

    public override string GetTextureLocation(SlimeRenderState state) => "minecraft:textures/entity/slime/magmacube.png";
}
