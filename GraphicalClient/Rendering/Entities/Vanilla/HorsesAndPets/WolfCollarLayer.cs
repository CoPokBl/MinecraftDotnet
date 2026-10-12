namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>entityCutout</c>, with no hurt overlay.</summary>
public sealed class WolfCollarLayer(LivingEntityRenderer<WolfRenderState, WolfModel> parent) : RenderLayer<WolfRenderState, WolfModel>(parent) {
    public override void Submit(PoseStack pose, EntityRenderContext context, WolfRenderState state) {
        if (state.CollarColor is not { } collarColor || state.IsInvisible) {
            return;
        }
        uint color = TropicalFish.TextureDiffuseColor(collarColor);
        string collarLocation = state.IsBaby ? "minecraft:textures/entity/wolf/wolf_collar_baby.png" : "minecraft:textures/entity/wolf/wolf_collar.png";
        if (context.Textures.Get(collarLocation) is { } texture) {
            Parent.CurrentModel.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, color, state.SkyLight, state.BlockLight, 0));
        }
    }
}
