using System.Numerics;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BreezeWindLayer</c>: the wind model, its texture scrolling sideways with the breeze's age.</summary>
public sealed class BreezeWindLayer : RenderLayer<BreezeRenderState, BreezeModel> {
    private const string TextureLocation = "minecraft:textures/entity/breeze/breeze_wind.png";
    private readonly BreezeModel _model;

    public BreezeWindLayer(LivingEntityRenderer<BreezeRenderState, BreezeModel> parent) : base(parent) {
        _model = new BreezeModel(BreezeModel.CreateWindLayer().BakeRoot());
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, BreezeRenderState state) {
        if (context.Textures.Get(TextureLocation) is not { } texture) {
            return;
        }
        _model.SetupAnim(state);
        Vector2 offset = new(state.AgeInTicks * 0.02F % 1.0F, 0.0F);
        EntityTexture? tiled = TiledTextures.Get(context.Textures, TextureLocation, ScrollingSink.Tiles, ScrollingSink.Tiles);
        _model.RenderToBuffer(pose, new ScrollingSink(context.TranslucentBatch, offset, tiled), new ModelDrawState(texture, state) { NoOutline = true });
    }
}
