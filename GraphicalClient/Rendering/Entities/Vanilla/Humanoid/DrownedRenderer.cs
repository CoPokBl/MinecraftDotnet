using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>DrownedRenderer</c>.</summary>
public sealed class DrownedRenderer : AbstractZombieRenderer<ZombieRenderState, DrownedModel> {
    private const string DrownedLocation = "minecraft:textures/entity/zombie/drowned.png";
    private const string BabyDrownedLocation = "minecraft:textures/entity/zombie/drowned_baby.png";

    public DrownedRenderer(EntityRendererContext context)
        : base(context,
            new DrownedModel(DrownedModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()),
            new BabyDrownedModel(BabyDrownedModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()),
            ArmorModelSet.Bake(HumanoidLayers.HumanoidArmor(), root => new DrownedModel(root)),
            ArmorModelSet.Bake<DrownedModel>(HumanoidLayers.HumanoidBabyArmor(), root => new BabyDrownedModel(root))) {
        AddLayer(new DrownedOuterLayer(this));
    }

    public override string GetTextureLocation(ZombieRenderState state) => state.IsBaby ? BabyDrownedLocation : DrownedLocation;

    protected override void SetupRotations(ZombieRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        float swimAmount = state.SwimAmount;
        if (swimAmount > 0.0F) {
            float targetRotationX = -10.0F - state.XRot;
            float rotationX = Mth.Lerp(swimAmount, 0.0F, targetRotationX);
            // rotateAround: the turn is about the middle of the bounding box.
            float pivotY = state.BoundingBoxHeight / 2.0F / entityScale;
            pose.Translate(0.0F, pivotY, 0.0F);
            pose.RotateXDegrees(rotationX);
            pose.Translate(0.0F, -pivotY, 0.0F);
        }
    }

    protected override ArmPose GetArmPose(ClientEntity mob, HumanoidArm arm, EntityRenderContext context) {
        Minecraft.Schemas.Items.ItemStack item = ArmedEntityRenderState.ItemHeldByArm(mob, arm);
        return ArmedEntityRenderState.MainArmOf(mob) == arm && HumanoidEntityData.IsAggressive(mob) && item.Is(Item.Trident)
            ? ArmPose.ThrowTrident
            : base.GetArmPose(mob, arm, context);
    }
}

/// <summary><c>DrownedModel</c>.</summary>
public class DrownedModel : ZombieModel<ZombieRenderState> {
    public DrownedModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = CreateMesh(g, 0.0F);
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(32, 48).AddBox(-1.0F, -2.0F, -2.0F, 4.0F, 12.0F, 4.0F, g), PartPose.Offset(5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(16, 48).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g), PartPose.Offset(1.9F, 12.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(ZombieRenderState state) {
        base.SetupAnim(state);
        if (state.LeftArmPose == ArmPose.ThrowTrident) {
            LeftArm.XRot = LeftArm.XRot * 0.5F - (float)Math.PI;
            LeftArm.YRot = 0.0F;
        }
        if (state.RightArmPose == ArmPose.ThrowTrident) {
            RightArm.XRot = RightArm.XRot * 0.5F - (float)Math.PI;
            RightArm.YRot = 0.0F;
        }
        float swimAmount = state.SwimAmount;
        if (swimAmount > 0.0F) {
            RightArm.XRot = Mth.RotLerpRad(swimAmount, RightArm.XRot, (float)(-Math.PI * 4.0 / 5.0)) + swimAmount * 0.35F * Mth.Sin(0.1F * state.AgeInTicks);
            LeftArm.XRot = Mth.RotLerpRad(swimAmount, LeftArm.XRot, (float)(-Math.PI * 4.0 / 5.0)) - swimAmount * 0.35F * Mth.Sin(0.1F * state.AgeInTicks);
            RightArm.ZRot = Mth.RotLerpRad(swimAmount, RightArm.ZRot, -0.15F);
            LeftArm.ZRot = Mth.RotLerpRad(swimAmount, LeftArm.ZRot, 0.15F);
            LeftLeg.XRot -= swimAmount * 0.55F * Mth.Sin(0.1F * state.AgeInTicks);
            RightLeg.XRot += swimAmount * 0.55F * Mth.Sin(0.1F * state.AgeInTicks);
            HeadPart.XRot = 0.0F;
        }
    }
}

/// <summary><c>BabyDrownedModel</c>.</summary>
public sealed class BabyDrownedModel : DrownedModel {
    public BabyDrownedModel(ModelPart root) : base(root) { }

    public new static LayerDefinition CreateBodyLayer(CubeDeformation g) => BabyZombieModel<ZombieRenderState>.CreateBodyLayer(g);
}

/// <summary><c>DrownedOuterLayer</c>.</summary>
public sealed class DrownedOuterLayer : RenderLayer<ZombieRenderState, DrownedModel> {
    private const string DrownedOuterLayerLocation = "minecraft:textures/entity/zombie/drowned_outer_layer.png";
    private const string BabyDrownedOuterLayerLocation = "minecraft:textures/entity/zombie/drowned_outer_layer_baby.png";
    private readonly DrownedModel _model;
    private readonly DrownedModel _babyModel;

    public DrownedOuterLayer(LivingEntityRenderer<ZombieRenderState, DrownedModel> renderer) : base(renderer) {
        _model = new DrownedModel(DrownedModel.CreateBodyLayer(new CubeDeformation(0.25F)).BakeRoot());
        _babyModel = new BabyDrownedModel(BabyDrownedModel.CreateBodyLayer(new CubeDeformation(0.25F)).BakeRoot());
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, ZombieRenderState state) {
        DrownedModel model = state.IsBaby ? _babyModel : _model;
        string layerLocation = state.IsBaby ? BabyDrownedOuterLayerLocation : DrownedOuterLayerLocation;
        RenderColoredCutoutModel(model, layerLocation, pose, context, state, 0xFFFFFFFF);
    }
}
