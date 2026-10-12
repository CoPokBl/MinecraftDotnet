using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>SkeletonRenderState</c>.</summary>
public class SkeletonRenderState : HumanoidRenderState {
    public bool IsAggressive;
    public bool IsShaking;
    public bool IsHoldingBow;
}

/// <summary><c>AbstractSkeletonRenderer</c>.</summary>
public abstract class AbstractSkeletonRenderer<S> : HumanoidMobRenderer<S, SkeletonModel<S>> where S : SkeletonRenderState, new() {
    protected AbstractSkeletonRenderer(EntityRendererContext context, LayerDefinition body, ArmorModelSet<LayerDefinition> armorSet)
        : this(context, armorSet, new SkeletonModel<S>(body.BakeRoot())) { }

    protected AbstractSkeletonRenderer(EntityRendererContext context, ArmorModelSet<LayerDefinition> armorSet, SkeletonModel<S> bodyModel)
        : base(context, bodyModel, 0.5F) {
        AddLayer(new HumanoidArmorLayer<S, SkeletonModel<S>, SkeletonModel<S>>(this, ArmorModelSet.Bake(armorSet, root => new SkeletonModel<S>(root)), EquipmentRenderer));
    }

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsAggressive = HumanoidEntityData.IsAggressive(entity);
        state.IsShaking = IsShaking(entity);
        state.IsHoldingBow = entity.ItemInHand(Hand.MainHand).Is(Item.Bow);
    }

    /// <summary>
    /// <c>AbstractSkeleton.isShaking</c>, being fully frozen, which <c>Skeleton</c> overrides with whether
    /// it is turning into a stray.
    /// </summary>
    private static bool IsShaking(ClientEntity entity) =>
        entity.Is(EntityClass.Skeleton) ? entity.Get(EntityDataFields.Skeleton.StrayConversion) : entity.IsFullyFrozen;

    protected override bool IsShaking(S state) => state.IsShaking;

    protected override ArmPose GetArmPose(ClientEntity mob, HumanoidArm arm, EntityRenderContext context) =>
        ArmedEntityRenderState.MainArmOf(mob) == arm && HumanoidEntityData.IsAggressive(mob) && mob.ItemInHand(Hand.MainHand).Is(Item.Bow)
            ? ArmPose.BowAndArrow
            : base.GetArmPose(mob, arm, context);
}

/// <summary><c>SkeletonRenderer</c>.</summary>
public sealed class SkeletonRenderer : AbstractSkeletonRenderer<SkeletonRenderState> {
    private const string SkeletonLocation = "minecraft:textures/entity/skeleton/skeleton.png";

    public SkeletonRenderer(EntityRendererContext context) : base(context, SkeletonModel<SkeletonRenderState>.CreateBodyLayer(), HumanoidLayers.HumanoidArmor()) { }

    public override string GetTextureLocation(SkeletonRenderState state) => SkeletonLocation;
}

/// <summary><c>StrayRenderer</c>.</summary>
public sealed class StrayRenderer : AbstractSkeletonRenderer<SkeletonRenderState> {
    private const string StraySkeletonLocation = "minecraft:textures/entity/skeleton/stray.png";
    private const string StrayClothesLocation = "minecraft:textures/entity/skeleton/stray_overlay.png";

    public StrayRenderer(EntityRendererContext context) : base(context, SkeletonModel<SkeletonRenderState>.CreateBodyLayer(), HumanoidLayers.HumanoidArmor()) {
        AddLayer(new SkeletonClothingLayer<SkeletonRenderState, SkeletonModel<SkeletonRenderState>>(this,
            LayerDefinition.Create(HumanoidModel<SkeletonRenderState>.CreateMesh(new CubeDeformation(0.25F), 0.0F), 64, 32), StrayClothesLocation));
    }

    public override string GetTextureLocation(SkeletonRenderState state) => StraySkeletonLocation;
}

/// <summary><c>WitherSkeletonRenderer</c>.</summary>
public sealed class WitherSkeletonRenderer : AbstractSkeletonRenderer<SkeletonRenderState> {
    private const string WitherSkeletonLocation = "minecraft:textures/entity/skeleton/wither_skeleton.png";

    public WitherSkeletonRenderer(EntityRendererContext context)
        : base(context, SkeletonModel<SkeletonRenderState>.CreateBodyLayer().Apply(MeshTransformers.Scaling(1.2F)),
            HumanoidLayers.Scaled(HumanoidLayers.HumanoidArmor(), MeshTransformers.Scaling(1.2F))) { }

    public override string GetTextureLocation(SkeletonRenderState state) => WitherSkeletonLocation;
}

/// <summary><c>ParchedRenderer</c>.</summary>
public sealed class ParchedRenderer : AbstractSkeletonRenderer<SkeletonRenderState> {
    private const string ParchedSkeletonLocation = "minecraft:textures/entity/skeleton/parched.png";

    public ParchedRenderer(EntityRendererContext context)
        : base(context, SkeletonModel<SkeletonRenderState>.CreateSingleModelDualBodyLayer(), HumanoidLayers.HumanoidArmor()) { }

    public override string GetTextureLocation(SkeletonRenderState state) => ParchedSkeletonLocation;
}

/// <summary><c>SkeletonClothingLayer</c>.</summary>
public sealed class SkeletonClothingLayer<S, M> : RenderLayer<S, M> where S : SkeletonRenderState, new() where M : EntityModel<S> {
    private readonly SkeletonModel<S> _layerModel;
    private readonly string _clothesLocation;

    public SkeletonClothingLayer(LivingEntityRenderer<S, M> renderer, LayerDefinition layer, string clothesLocation) : base(renderer) {
        _clothesLocation = clothesLocation;
        _layerModel = new SkeletonModel<S>(layer.BakeRoot());
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) =>
        RenderColoredCutoutModel(_layerModel, _clothesLocation, pose, context, state, 0xFFFFFFFF);
}
