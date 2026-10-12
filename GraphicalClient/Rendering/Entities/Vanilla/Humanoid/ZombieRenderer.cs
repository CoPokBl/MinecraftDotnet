using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ZombieRenderState</c>.</summary>
public class ZombieRenderState : UndeadRenderState {
    public bool IsAggressive;
    public bool IsConverting;
}

/// <summary><c>AbstractZombieRenderer</c>.</summary>
public abstract class AbstractZombieRenderer<S, M> : HumanoidMobRenderer<S, M>
    where S : ZombieRenderState, new()
    where M : ZombieModel<S> {
    private const string ZombieLocation = "minecraft:textures/entity/zombie/zombie.png";
    private const string BabyZombieLocation = "minecraft:textures/entity/zombie/zombie_baby.png";

    protected AbstractZombieRenderer(EntityRendererContext context, M model, M babyModel, ArmorModelSet<M> armorSet, ArmorModelSet<M> babyArmorSet)
        : base(context, model, babyModel, 0.5F) {
        AddLayer(new HumanoidArmorLayer<S, M, M>(this, armorSet, babyArmorSet, EquipmentRenderer));
    }

    public override string GetTextureLocation(S state) => state.IsBaby ? BabyZombieLocation : ZombieLocation;

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsAggressive = HumanoidEntityData.IsAggressive(entity);
        // Zombie.isUnderWaterConverting.
        state.IsConverting = entity.Get(EntityDataFields.Zombie.DrownedConversion);
    }

    protected override bool IsShaking(S state) => base.IsShaking(state) || state.IsConverting;

    protected override ArmPose GetArmPose(ClientEntity mob, HumanoidArm arm, EntityRenderContext context) {
        ItemStack other = ArmedEntityRenderState.ItemHeldByArm(mob, ArmedEntityRenderState.Opposite(arm));
        return HumanoidMobRenderer.IsStab(other)
            ? ArmPose.Spear
            : base.GetArmPose(mob, arm, context);
    }
}

/// <summary><c>ZombieRenderer</c>.</summary>
public class ZombieRenderer : AbstractZombieRenderer<ZombieRenderState, ZombieModel<ZombieRenderState>> {
    public ZombieRenderer(EntityRendererContext context)
        : this(context, HumanoidLayers.HumanoidBody(), BabyZombieModel<ZombieRenderState>.CreateBodyLayer(CubeDeformation.None), HumanoidLayers.HumanoidArmor(),
            HumanoidLayers.HumanoidBabyArmor()) { }

    protected ZombieRenderer(EntityRendererContext context, LayerDefinition body, LayerDefinition babyBody, ArmorModelSet<LayerDefinition> armorSet,
        ArmorModelSet<LayerDefinition> babyArmorSet)
        : base(context,
            new ZombieModel<ZombieRenderState>(body.BakeRoot()),
            new BabyZombieModel<ZombieRenderState>(babyBody.BakeRoot()),
            ArmorModelSet.Bake(armorSet, root => new ZombieModel<ZombieRenderState>(root)),
            ArmorModelSet.Bake<ZombieModel<ZombieRenderState>>(babyArmorSet, root => new BabyZombieModel<ZombieRenderState>(root))) { }
}

/// <summary><c>HuskRenderer</c>.</summary>
public sealed class HuskRenderer : ZombieRenderer {
    private const string HuskLocation = "minecraft:textures/entity/zombie/husk.png";
    private const string BabyHuskLocation = "minecraft:textures/entity/zombie/husk_baby.png";

    public HuskRenderer(EntityRendererContext context)
        : base(context, HumanoidLayers.HumanoidBody().Apply(MeshTransformers.Scaling(1.0625F)), BabyZombieModel<ZombieRenderState>.CreateBodyLayer(CubeDeformation.None),
            HumanoidLayers.Scaled(HumanoidLayers.HumanoidArmor(), MeshTransformers.Scaling(1.0625F)), HumanoidLayers.HumanoidBabyArmor()) { }

    public override string GetTextureLocation(ZombieRenderState state) => state.IsBaby ? BabyHuskLocation : HuskLocation;
}
