using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>A carpet, or a trader llama's own decor when it wears none.</summary>
public sealed class LlamaDecorLayer(LivingEntityRenderer<LlamaRenderState, LlamaModel> parent, EquipmentLayerRenderer equipmentRenderer)
    : RenderLayer<LlamaRenderState, LlamaModel>(parent) {
    private static readonly Identifier TraderLlama = "minecraft:trader_llama";
    private static readonly Identifier TraderLlamaBaby = "minecraft:trader_llama_baby";

    private readonly LlamaModel _adultModel = new(LlamaModel.CreateBodyLayer(new CubeDeformation(0.5F)).BakeRoot());
    private readonly LlamaModel _babyModel = new BabyLlamaModel(BabyLlamaModel.CreateBodyLayer(new CubeDeformation(0.2F)).BakeRoot());

    public override void Submit(PoseStack pose, EntityRenderContext context, LlamaRenderState state) {
        Identifier? assetId = EquipmentLayerRenderer.EquippableAssetId(state.BodyItem);
        if (assetId != null && !state.IsBaby) {
            RenderEquipment(pose, context, state, state.BodyItem, assetId.Value);
        }
        else if (state.IsTraderLlama) {
            RenderEquipment(pose, context, state, ItemStack.Air, state.IsBaby ? TraderLlamaBaby : TraderLlama);
        }
    }

    private void RenderEquipment(PoseStack pose, EntityRenderContext context, LlamaRenderState state, ItemStack itemStack, Identifier equipmentAssetId) {
        LlamaModel model = state.IsBaby ? _babyModel : _adultModel;
        equipmentRenderer.RenderLayers(EquipmentClientInfo.LayerType.LlamaBody, equipmentAssetId, model, state, itemStack, pose, context);
    }
}
