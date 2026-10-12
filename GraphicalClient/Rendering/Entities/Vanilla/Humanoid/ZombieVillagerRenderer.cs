using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ZombieVillagerRenderState</c>.</summary>
public class ZombieVillagerRenderState : ZombieRenderState, IVillagerDataHolderRenderState {
    public VillagerData? VillagerData;

    public VillagerData? GetVillagerData() => VillagerData;
}

/// <summary><c>ZombieVillagerRenderer</c>.</summary>
public sealed class ZombieVillagerRenderer : HumanoidMobRenderer<ZombieVillagerRenderState, ZombieVillagerModel<ZombieVillagerRenderState>> {
    private const string ZombieVillagerLocation = "minecraft:textures/entity/zombie_villager/zombie_villager.png";
    private const string BabyZombieVillagerLocation = "minecraft:textures/entity/zombie_villager/zombie_villager_baby.png";

    /// <summary><c>VillagerRenderer.CUSTOM_HEAD_TRANSFORMS</c>.</summary>
    public static readonly CustomHeadLayer.Transforms VillagerCustomHeadTransforms = new(-0.1171875F, -0.07421875F, 1.0F);

    public ZombieVillagerRenderer(EntityRendererContext context)
        : base(context,
            new ZombieVillagerModel<ZombieVillagerRenderState>(ZombieVillagerModel<ZombieVillagerRenderState>.CreateBodyLayer().BakeRoot()),
            new BabyZombieVillagerModel<ZombieVillagerRenderState>(BabyZombieVillagerModel<ZombieVillagerRenderState>.CreateBodyLayer().BakeRoot()),
            0.5F,
            VillagerCustomHeadTransforms) {
        AddLayer(new HumanoidArmorLayer<ZombieVillagerRenderState, ZombieVillagerModel<ZombieVillagerRenderState>, ZombieVillagerModel<ZombieVillagerRenderState>>(
            this,
            ArmorModelSet.Bake(ZombieVillagerModel<ZombieVillagerRenderState>.CreateArmorLayerSet(HumanoidLayers.InnerArmorDeformation, HumanoidLayers.OuterArmorDeformation),
                root => new ZombieVillagerModel<ZombieVillagerRenderState>(root)),
            ArmorModelSet.Bake<ZombieVillagerModel<ZombieVillagerRenderState>>(HumanoidLayers.HumanoidBabyArmor(),
                root => new BabyZombieVillagerModel<ZombieVillagerRenderState>(root)),
            EquipmentRenderer));
        AddLayer(new VillagerProfessionLayer<ZombieVillagerRenderState, ZombieVillagerModel<ZombieVillagerRenderState>>(
            this,
            context.Pack,
            "zombie_villager",
            new ZombieVillagerModel<ZombieVillagerRenderState>(ZombieVillagerModel<ZombieVillagerRenderState>.CreateNoHatLayer().BakeRoot()),
            new BabyZombieVillagerModel<ZombieVillagerRenderState>(BabyZombieVillagerModel<ZombieVillagerRenderState>.CreateNoHatLayer().BakeRoot())));
    }

    public override string GetTextureLocation(ZombieVillagerRenderState state) => state.IsBaby ? BabyZombieVillagerLocation : ZombieVillagerLocation;

    public override void ExtractRenderState(ClientEntity entity, ZombieVillagerRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsConverting = entity.Get(EntityDataFields.ZombieVillager.Converting);
        state.VillagerData = VillagerData.Read(entity, EntityDataFields.ZombieVillager.VillagerData, context.Client.Registry);
        state.IsAggressive = HumanoidEntityData.IsAggressive(entity);
    }

    protected override bool IsShaking(ZombieVillagerRenderState state) => base.IsShaking(state) || state.IsConverting;
}
