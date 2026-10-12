using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.PigVariant;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class PigRenderState : LivingEntityRenderState {
    public ItemStack Saddle = ItemStack.Air;
    public IPigVariant? Variant;
}

public sealed class PigRenderer : MobRenderer<PigRenderState, PigModel> {
    private readonly Dictionary<PigVariantModel, (PigModel Adult, PigModel Baby)> _models = new() {
        [PigVariantModel.Normal] = (new PigModel(PigModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()), BakeBaby()),
        [PigVariantModel.Cold] = (new ColdPigModel(ColdPigModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()), BakeBaby())
    };

    public PigRenderer(EntityRendererContext context) : base(new PigModel(PigModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()), 0.7F) {
        AddLayer(new SimpleEquipmentLayer<PigRenderState, PigModel, PigRenderState>(this, EquipmentLayerRenderer.For(context),
            EquipmentClientInfo.LayerType.PigSaddle, state => state.Saddle, new PigModel(PigModel.CreateBodyLayer(new CubeDeformation(0.5F)).BakeRoot()), null));
    }

    private static BabyPigModel BakeBaby() => new(BabyPigModel.CreateBodyLayer(CubeDeformation.None).BakeRoot());

    public override void Submit(PigRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Variant != null) {
            (PigModel adult, PigModel baby) = _models[state.Variant.Model];
            Model = state.IsBaby ? baby : adult;
            base.Submit(state, pose, context);
        }
    }

    public override string GetTextureLocation(PigRenderState state) =>
        state.Variant == null ? "minecraft:missingno" : SyncedVariants.TexturePath(state.IsBaby ? state.Variant.BabyAssetId : state.Variant.AssetId);

    public override void ExtractRenderState(ClientEntity entity, PigRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.Saddle = entity.GetItemBySlot(EquipmentSlot.Saddle);
        state.Variant = SyncedVariants.Resolve(context.Level.Registry.PigVariants, entity, EntityDataFields.Pig.Variant, PigVariant.Temperate.Identifier);
    }
}
