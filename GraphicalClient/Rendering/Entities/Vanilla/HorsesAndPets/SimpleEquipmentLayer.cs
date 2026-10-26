using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <typeparamref name="ES"/> is the state the equipment model is posed by, which may be a base of the parent's
/// state, as vanilla's <c>EntityModel&lt;? super S&gt;</c> allows.
/// </summary>
public class SimpleEquipmentLayer<S, M, ES>(LivingEntityRenderer<S, M> parent, EquipmentLayerRenderer equipmentRenderer, EquipmentClientInfo.LayerType layer,
    Func<S, ItemStack> itemGetter, EntityModel<ES> adultModel, EntityModel<ES>? babyModel) : RenderLayer<S, M>(parent)
    where S : LivingEntityRenderState, ES, new()
    where M : EntityModel<S>
    where ES : EntityRenderState {
    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        ItemStack equipment = itemGetter(state);
        Identifier? assetId = EquipmentLayerRenderer.EquippableAssetId(equipment);
        if (assetId != null && (!state.IsBaby || babyModel != null)) {
            EntityModel<ES> model = state.IsBaby ? babyModel! : adultModel;
            equipmentRenderer.RenderLayers<ES>(layer, assetId.Value, model, state, equipment, pose, context);
        }
    }
}
