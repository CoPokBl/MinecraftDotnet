using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.ZombieNautilusVariant;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ZombieNautilusRenderer : MobRenderer<NautilusRenderState, NautilusModel> {
    private readonly Dictionary<ZombieNautilusVariantModel, NautilusModel> _models;

    public ZombieNautilusRenderer(EntityRendererContext context) : base(new NautilusModel(NautilusModel.CreateBodyLayer().BakeRoot()), 0.7F) {
        EquipmentLayerRenderer equipment = EquipmentLayerRenderer.For(context);
        AddLayer(new SimpleEquipmentLayer<NautilusRenderState, NautilusModel, NautilusRenderState>(this, equipment,
            EquipmentClientInfo.LayerType.NautilusBody, state => state.BodyArmorItem, new NautilusArmorModel(NautilusArmorModel.CreateBodyLayer().BakeRoot()), null));
        AddLayer(new SimpleEquipmentLayer<NautilusRenderState, NautilusModel, NautilusRenderState>(this, equipment,
            EquipmentClientInfo.LayerType.NautilusSaddle, state => state.Saddle, new NautilusSaddleModel(NautilusSaddleModel.CreateSaddleLayer().BakeRoot()), null));
        _models = new Dictionary<ZombieNautilusVariantModel, NautilusModel> {
            [ZombieNautilusVariantModel.Normal] = new NautilusModel(NautilusModel.CreateBodyLayer().BakeRoot()),
            [ZombieNautilusVariantModel.Warm] = new ZombieNautilusCoralModel(ZombieNautilusCoralModel.CreateBodyLayer().BakeRoot())
        };
    }

    public override void Submit(NautilusRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Variant != null) {
            Model = _models[state.Variant.Model];
            base.Submit(state, pose, context);
        }
    }

    // The null branch is unreachable, since Submit draws nothing without a variant; vanilla names the missing texture there.
    public override string GetTextureLocation(NautilusRenderState state) =>
        state.Variant == null ? "minecraft:missingno" : SyncedVariants.TexturePath(state.Variant.AssetId);

    public override void ExtractRenderState(ClientEntity entity, NautilusRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        NautilusRenderState.ExtractEquipment(entity, state);
        state.Variant = SyncedVariants.Resolve(context.Level.Registry.ZombieNautilusVariants, entity, EntityDataFields.ZombieNautilus.Variant, "minecraft:temperate");
    }
}
