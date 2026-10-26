namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class HorseMarkingLayer(LivingEntityRenderer<HorseRenderState, HorseModel<HorseRenderState>> parent)
    : RenderLayer<HorseRenderState, HorseModel<HorseRenderState>>(parent) {
    private static readonly Dictionary<HorseMarkings, (string Adult, string Baby)> LocationByMarkings = new() {
        [HorseMarkings.White] = ("minecraft:textures/entity/horse/horse_markings_white.png", "minecraft:textures/entity/horse/horse_markings_white_baby.png"),
        [HorseMarkings.WhiteField] = ("minecraft:textures/entity/horse/horse_markings_whitefield.png", "minecraft:textures/entity/horse/horse_markings_whitefield_baby.png"),
        [HorseMarkings.WhiteDots] = ("minecraft:textures/entity/horse/horse_markings_whitedots.png", "minecraft:textures/entity/horse/horse_markings_whitedots_baby.png"),
        [HorseMarkings.BlackDots] = ("minecraft:textures/entity/horse/horse_markings_blackdots.png", "minecraft:textures/entity/horse/horse_markings_blackdots_baby.png")
    };

    /// <summary>Drawn <c>entityTranslucent</c>, so into the translucent batch; <c>NONE</c> is vanilla's invisible texture.</summary>
    public override void Submit(PoseStack pose, EntityRenderContext context, HorseRenderState state) {
        if (!LocationByMarkings.TryGetValue(state.Markings, out (string Adult, string Baby) variant) || state.IsInvisible) {
            return;
        }
        if (context.Textures.Get(state.IsBaby ? variant.Baby : variant.Adult) is { } resolved) {
            Parent.CurrentModel.RenderToBuffer(pose, context.TranslucentBatch,
                new ModelDrawState(resolved, 0xFFFFFFFF, state.SkyLight, state.BlockLight, state.HasRedOverlay ? 1 : 0));
        }
    }
}
