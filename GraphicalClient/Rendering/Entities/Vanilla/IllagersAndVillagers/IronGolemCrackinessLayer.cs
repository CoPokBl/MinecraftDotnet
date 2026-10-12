namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class IronGolemCrackinessLayer : RenderLayer<IronGolemRenderState, IronGolemModel> {
    public IronGolemCrackinessLayer(LivingEntityRenderer<IronGolemRenderState, IronGolemModel> parent) : base(parent) { }

    private static string? Identifier(CrackinessLevel level) => level switch {
        CrackinessLevel.Low => "minecraft:textures/entity/iron_golem/iron_golem_crackiness_low.png",
        CrackinessLevel.Medium => "minecraft:textures/entity/iron_golem/iron_golem_crackiness_medium.png",
        CrackinessLevel.High => "minecraft:textures/entity/iron_golem/iron_golem_crackiness_high.png",
        _ => null
    };

    public override void Submit(PoseStack pose, EntityRenderContext context, IronGolemRenderState state) {
        if (state.IsInvisible || Identifier(state.Crackiness) is not { } damageTexture) {
            return;
        }
        RenderColoredCutoutModel(Parent.CurrentModel, damageTexture, pose, context, state, 0xFFFFFFFF);
    }
}
