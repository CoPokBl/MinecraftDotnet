using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class HappyGhastRenderState : LivingEntityRenderState {
    public ItemStack BodyItem = ItemStack.Air;
    public bool IsRidden, IsLeashHolder;
}

/// <summary>
/// <c>HappyGhastRenderer</c>. Its <c>getBoundingBoxForCulling</c>, which reaches half a height below the
/// box, is not applied: culling is the dispatcher's and takes no box from the renderer.
/// </summary>
public sealed class HappyGhastRenderer : AgeableMobRenderer<HappyGhastRenderState, HappyGhastModel> {
    private const string GhastRopes = "minecraft:textures/entity/ghast/happy_ghast_ropes.png";

    public HappyGhastRenderer(EntityRendererContext context)
        : base(
            new HappyGhastModel(HappyGhastModel.CreateBodyLayer(false, CubeDeformation.None).BakeRoot()),
            new HappyGhastModel(HappyGhastModel.CreateBodyLayer(true, CubeDeformation.None).Apply(HappyGhastModel.BabyTransformer).BakeRoot()),
            2.0F) {
        AddLayer(new SimpleEquipmentLayer<HappyGhastRenderState, HappyGhastModel, HappyGhastRenderState>(
            this,
            EquipmentLayerRenderer.For(context),
            EquipmentClientInfo.LayerType.HappyGhastBody,
            state => state.BodyItem,
            new HappyGhastHarnessModel(HappyGhastHarnessModel.CreateHarnessLayer(false).BakeRoot()),
            // LayerDefinitions applies the baby transformer again on top of the one createHarnessLayer(true) applied.
            new HappyGhastHarnessModel(HappyGhastHarnessModel.CreateHarnessLayer(true).Apply(HappyGhastModel.BabyTransformer).BakeRoot())));
        AddLayer(new RopesLayer(this, GhastRopes));
    }

    public override string GetTextureLocation(HappyGhastRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/ghast/happy_ghast_baby.png" : "minecraft:textures/entity/ghast/happy_ghast.png";

    public override void ExtractRenderState(ClientEntity entity, HappyGhastRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.BodyItem = entity.GetItemBySlot(EquipmentSlot.Body);
        state.IsRidden = entity.Passengers.Length > 0;
        state.IsLeashHolder = entity.Get(EntityDataFields.HappyGhast.IsLeashHolder);
    }
}
