using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>GiantMobRenderer</c>.</summary>
public sealed class GiantMobRenderer : MobRenderer<ZombieRenderState, HumanoidModel<ZombieRenderState>> {
    private const string ZombieLocation = "minecraft:textures/entity/zombie/zombie.png";
    private readonly ItemRenderer _items;

    public GiantMobRenderer(EntityRendererContext context, float scale)
        : base(new GiantZombieModel(HumanoidLayers.HumanoidBody().Apply(MeshTransformers.Scaling(6.0F)).BakeRoot()), 0.5F * scale) {
        _items = context.Items;
        AddLayer(new ItemInHandLayer<ZombieRenderState, HumanoidModel<ZombieRenderState>>(this, context.Items));
        AddLayer(new HumanoidArmorLayer<ZombieRenderState, HumanoidModel<ZombieRenderState>, GiantZombieModel>(this,
            ArmorModelSet.Bake(HumanoidLayers.Scaled(HumanoidLayers.HumanoidArmor(), MeshTransformers.Scaling(6.0F)), root => new GiantZombieModel(root)),
            EquipmentLayerRenderer.For(context)));
    }

    public override void Tick(ClientEntity entity) => HumanoidEntityData.TickFor<HumanoidEntityData>(entity);

    public override string GetTextureLocation(ZombieRenderState state) => ZombieLocation;

    public override void ExtractRenderState(ClientEntity entity, ZombieRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HumanoidMobRenderer.ExtractHumanoidRenderState(entity, state, partialTick, _items, context);
    }
}
