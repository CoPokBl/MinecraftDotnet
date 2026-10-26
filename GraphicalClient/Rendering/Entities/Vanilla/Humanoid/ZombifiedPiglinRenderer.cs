using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ZombifiedPiglinRenderState</c>.</summary>
public class ZombifiedPiglinRenderState : UndeadRenderState {
    public bool IsAggressive;
}

/// <summary><c>ZombifiedPiglinRenderer</c>.</summary>
public sealed class ZombifiedPiglinRenderer : HumanoidMobRenderer<ZombifiedPiglinRenderState, ZombifiedPiglinModel> {
    private const string ZombifiedPiglinLocation = "minecraft:textures/entity/piglin/zombified_piglin.png";
    private const string BabyZombifiedPiglinLocation = "minecraft:textures/entity/piglin/zombified_piglin_baby.png";

    public ZombifiedPiglinRenderer(EntityRendererContext context)
        : base(context, new AdultZombifiedPiglinModel(AdultZombifiedPiglinModel.CreateBodyLayer().BakeRoot()),
            new BabyZombifiedPiglinModel(BabyZombifiedPiglinModel.CreateBodyLayer().BakeRoot()), 0.5F, PiglinRenderer.PiglinCustomHeadTransforms) {
        AddLayer(new HumanoidArmorLayer<ZombifiedPiglinRenderState, ZombifiedPiglinModel, ZombifiedPiglinModel>(this,
            ArmorModelSet.Bake<ZombifiedPiglinModel>(HumanoidLayers.PiglinArmor(), root => new AdultZombifiedPiglinModel(root)),
            ArmorModelSet.Bake<ZombifiedPiglinModel>(HumanoidLayers.PiglinBabyArmor(), root => new BabyZombifiedPiglinModel(root)),
            EquipmentRenderer));
    }

    public override string GetTextureLocation(ZombifiedPiglinRenderState state) => state.IsBaby ? BabyZombifiedPiglinLocation : ZombifiedPiglinLocation;

    public override void ExtractRenderState(ClientEntity entity, ZombifiedPiglinRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsAggressive = HumanoidEntityData.IsAggressive(entity);
    }
}
