using ClientLib.Entities;
using Minecraft.Data.CowVariant;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class CowRenderState : LivingEntityRenderState {
    public ICowVariant? Variant;
}

public sealed class CowRenderer() : MobRenderer<CowRenderState, CowModel<CowRenderState>>(Bake(CowModel.CreateBodyLayer()), 0.7F) {
    private readonly Dictionary<CowVariantModel, (CowModel<CowRenderState> Adult, CowModel<CowRenderState> Baby)> _models = new() {
        [CowVariantModel.Normal] = (Bake(CowModel.CreateBodyLayer()), Bake(BabyCowModel.CreateBodyLayer())),
        [CowVariantModel.Warm] = (Bake(WarmCowModel.CreateBodyLayer()), Bake(BabyCowModel.CreateBodyLayer())),
        [CowVariantModel.Cold] = (Bake(ColdCowModel.CreateBodyLayer()), Bake(BabyCowModel.CreateBodyLayer()))
    };

    private static CowModel<CowRenderState> Bake(LayerDefinition layer) => new(layer.BakeRoot());

    public override string GetTextureLocation(CowRenderState state) =>
        state.Variant == null ? "minecraft:missingno" : SyncedVariants.TexturePath(state.IsBaby ? state.Variant.BabyAssetId : state.Variant.AssetId);

    public override void ExtractRenderState(ClientEntity entity, CowRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.Variant = SyncedVariants.Resolve(context.Level.Registry.CowVariants, entity, EntityDataFields.Cow.Variant, CowVariant.Temperate.Identifier);
    }

    public override void Submit(CowRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Variant != null) {
            (CowModel<CowRenderState> adult, CowModel<CowRenderState> baby) = _models[state.Variant.Model];
            Model = state.IsBaby ? baby : adult;
            base.Submit(state, pose, context);
        }
    }
}
