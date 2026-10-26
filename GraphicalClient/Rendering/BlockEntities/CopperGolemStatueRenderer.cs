using System.Numerics;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary><c>CopperGolemStatueBlock.Pose</c>.</summary>
public enum CopperGolemStatuePose { Standing, Sitting, Running, Star }

/// <summary><c>CopperGolemStatueModel</c>: a copper golem layer, stood on its head as the block draws it.</summary>
public sealed class CopperGolemStatueModel(ModelPart root) : EntityModel<EntityRenderState>(root) {
    public void SetupAnim() {
        ResetPose();
        Root.Y = 0.0F;
        Root.ZRot = MathF.PI;
    }

    /// <summary><c>getModel</c>'s layer for each pose.</summary>
    public static LayerDefinition Layer(CopperGolemStatuePose pose) => pose switch {
        CopperGolemStatuePose.Running => CreateRunningPoseBodyLayer(),
        CopperGolemStatuePose.Sitting => CreateSittingPoseBodyLayer(),
        CopperGolemStatuePose.Star => CreateStarPoseBodyLayer(),
        _ => CopperGolemModel.CreateBodyLayer()
    };

    /// <summary><c>CopperGolemModel.createRunningPoseBodyLayer</c>.</summary>
    public static LayerDefinition CreateRunningPoseBodyLayer() {
        MeshDefinition mesh = new MeshDefinition().Transformed(p => p.Translated(0.0F, 0.0F, 0.0F));
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create(), PartPose.Offset(-1.064F, -5.0F, 0.0F));
        body.AddOrReplaceChild("body_r1", CubeListBuilder.Create().TexOffs(0, 15).AddBox(-4.02F, -6.116F, -3.5F, 8.0F, 6.0F, 6.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(1.1F, 0.1F, 0.7F, 0.1204F, -0.0064F, -0.0779F));
        body.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-4.0F, -5.1F, -5.0F, 8.0F, 5.0F, 10.0F, new CubeDeformation(0.0F))
                .TexOffs(56, 0).AddBox(-1.02F, -2.1F, -6.0F, 2.0F, 3.0F, 2.0F, new CubeDeformation(0.0F))
                .TexOffs(37, 8).AddBox(-1.02F, -9.1F, -1.0F, 2.0F, 4.0F, 2.0F, new CubeDeformation(-0.015F))
                .TexOffs(37, 0).AddBox(-2.0F, -13.1F, -2.0F, 4.0F, 4.0F, 4.0F, new CubeDeformation(-0.015F)),
            PartPose.Offset(0.7F, -5.6F, -1.8F));
        PartDefinition rightArm = body.AddOrReplaceChild("right_arm", CubeListBuilder.Create(), PartPose.Offset(-4.0F, -6.0F, 0.0F));
        rightArm.AddOrReplaceChild("right_arm_r1", CubeListBuilder.Create().TexOffs(36, 16).AddBox(-3.052F, -1.11F, -2.036F, 3.0F, 10.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.7F, -0.248F, -1.62F, 1.0036F, 0.0F, 0.0F));
        PartDefinition leftArm = body.AddOrReplaceChild("left_arm", CubeListBuilder.Create(), PartPose.Offset(4.0F, -6.0F, 0.0F));
        leftArm.AddOrReplaceChild("left_arm_r1", CubeListBuilder.Create().TexOffs(50, 16).AddBox(0.032F, -1.1F, -2.0F, 3.0F, 10.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.732F, 0.0F, 0.0F, -0.8715F, -0.0535F, -0.0449F));
        PartDefinition rightLeg = root.AddOrReplaceChild("right_leg", CubeListBuilder.Create(), PartPose.Offset(-3.064F, -5.0F, 0.0F));
        rightLeg.AddOrReplaceChild("right_leg_r1", CubeListBuilder.Create().TexOffs(0, 27).AddBox(-1.856F, -0.1F, -1.09F, 4.0F, 5.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(1.048F, 0.0F, -0.9F, -0.8727F, 0.0F, 0.0F));
        PartDefinition leftLeg = root.AddOrReplaceChild("left_leg", CubeListBuilder.Create(), PartPose.Offset(0.936F, -5.0F, 0.0F));
        leftLeg.AddOrReplaceChild("left_leg_r1", CubeListBuilder.Create().TexOffs(16, 27).AddBox(-2.088F, -0.1F, -2.0F, 4.0F, 5.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(1.0F, 0.0F, 0.0F, 0.7854F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    /// <summary><c>CopperGolemModel.createSittingPoseBodyLayer</c>.</summary>
    public static LayerDefinition CreateSittingPoseBodyLayer() {
        MeshDefinition mesh = new MeshDefinition().Transformed(p => p.Translated(0.0F, 0.0F, 0.0F));
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(3, 19).AddBox(-3.0F, -4.0F, -4.525F, 6.0F, 1.0F, 6.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 15).AddBox(-4.0F, -3.0F, -3.525F, 8.0F, 6.0F, 6.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -3.0F, 2.325F));
        body.AddOrReplaceChild("body_r1", CubeListBuilder.Create().TexOffs(3, 18).AddBox(-4.0F, -3.0F, -2.2F, 8.0F, 6.0F, 3.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, -1.0F, -4.325F, 0.0F, 0.0F, -3.1416F));
        body.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(37, 8).AddBox(-1.0F, -7.0F, -3.3F, 2.0F, 4.0F, 2.0F, new CubeDeformation(-0.015F))
                .TexOffs(37, 0).AddBox(-2.0F, -11.0F, -4.3F, 4.0F, 4.0F, 4.0F, new CubeDeformation(-0.015F))
                .TexOffs(0, 0).AddBox(-4.0F, -3.0F, -7.325F, 8.0F, 5.0F, 10.0F, new CubeDeformation(0.0F))
                .TexOffs(56, 0).AddBox(-1.0F, 0.0F, -8.325F, 2.0F, 3.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -6.0F, -0.2F));
        PartDefinition rightArm = body.AddOrReplaceChild("right_arm", CubeListBuilder.Create(), PartPose.OffsetAndRotation(-4.0F, -5.6F, -1.8F, 0.4363F, 0.0F, 0.0F));
        rightArm.AddOrReplaceChild("right_arm_r1", CubeListBuilder.Create().TexOffs(36, 16).AddBox(-3.075F, -0.9733F, -1.9966F, 3.0F, 10.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, 0.0893F, 0.1198F, -1.0472F, 0.0F, 0.0F));
        PartDefinition leftArm = body.AddOrReplaceChild("left_arm", CubeListBuilder.Create(), PartPose.OffsetAndRotation(4.0F, -5.6F, -1.7F, 0.4363F, 0.0F, 0.0F));
        leftArm.AddOrReplaceChild("left_arm_r1", CubeListBuilder.Create().TexOffs(50, 16).AddBox(0.075F, -1.0443F, -1.8997F, 3.0F, 10.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, -0.0015F, -0.0808F, -1.0472F, 0.0F, 0.0F));
        PartDefinition rightLeg = root.AddOrReplaceChild("right_leg", CubeListBuilder.Create(), PartPose.Offset(-2.1F, -2.1F, -2.075F));
        rightLeg.AddOrReplaceChild("right_leg_r1", CubeListBuilder.Create().TexOffs(0, 27).AddBox(-2.0F, 0.975F, 0.0F, 4.0F, 5.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.05F, -1.9F, 1.075F, -1.5708F, 0.0F, 0.0F));
        PartDefinition leftLeg = root.AddOrReplaceChild("left_leg", CubeListBuilder.Create(), PartPose.Offset(2.0F, -2.0F, -2.075F));
        leftLeg.AddOrReplaceChild("left_leg_r1", CubeListBuilder.Create().TexOffs(16, 27).AddBox(-2.0F, 0.975F, 0.0F, 4.0F, 5.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.05F, -2.0F, 1.075F, -1.5708F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    /// <summary><c>CopperGolemModel.createStarPoseBodyLayer</c>.</summary>
    public static LayerDefinition CreateStarPoseBodyLayer() {
        MeshDefinition mesh = new MeshDefinition().Transformed(p => p.Translated(0.0F, 0.0F, 0.0F));
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 15).AddBox(-4.0F, -6.0F, -3.0F, 8.0F, 6.0F, 6.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -5.0F, 0.0F));
        body.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-4.0F, -5.0F, -5.0F, 8.0F, 5.0F, 10.0F, new CubeDeformation(0.0F))
                .TexOffs(56, 0).AddBox(-1.0F, -2.0F, -6.0F, 2.0F, 3.0F, 2.0F, new CubeDeformation(0.0F))
                .TexOffs(37, 8).AddBox(-1.0F, -9.0F, -1.0F, 2.0F, 4.0F, 2.0F, new CubeDeformation(-0.015F))
                .TexOffs(37, 0).AddBox(-2.0F, -13.0F, -2.0F, 4.0F, 4.0F, 4.0F, new CubeDeformation(-0.015F)),
            PartPose.Offset(0.0F, -6.0F, 0.0F));
        PartDefinition rightArm = body.AddOrReplaceChild("right_arm", CubeListBuilder.Create(), PartPose.Offset(-4.0F, -6.0F, 0.0F));
        rightArm.AddOrReplaceChild("right_arm_r1", CubeListBuilder.Create().TexOffs(36, 16).AddBox(-1.5F, -5.0F, -2.0F, 3.0F, 10.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(1.0F, 1.0F, 0.0F, 0.0F, 0.0F, 1.9199F));
        rightArm.AddOrReplaceChild("rightItem", CubeListBuilder.Create(), PartPose.Offset(-1.0F, 7.4F, -1.0F));
        PartDefinition leftArm = body.AddOrReplaceChild("left_arm", CubeListBuilder.Create(), PartPose.Offset(4.0F, -6.0F, 0.0F));
        leftArm.AddOrReplaceChild("left_arm_r1", CubeListBuilder.Create().TexOffs(50, 16).AddBox(-1.5F, -5.0F, -2.0F, 3.0F, 10.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(-1.0F, 1.0F, 0.0F, 0.0F, 0.0F, -1.9199F));
        PartDefinition rightLeg = root.AddOrReplaceChild("right_leg", CubeListBuilder.Create(), PartPose.Offset(-3.0F, -5.0F, 0.0F));
        rightLeg.AddOrReplaceChild("right_leg_r1", CubeListBuilder.Create().TexOffs(0, 27).AddBox(-2.0F, -2.5F, -2.0F, 4.0F, 5.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.35F, 2.0F, 0.01F, 0.0F, 0.0F, 0.2618F));
        PartDefinition leftLeg = root.AddOrReplaceChild("left_leg", CubeListBuilder.Create(), PartPose.Offset(1.0F, -5.0F, 0.0F));
        leftLeg.AddOrReplaceChild("left_leg_r1", CubeListBuilder.Create().TexOffs(16, 27).AddBox(-2.0F, -2.5F, -2.0F, 4.0F, 5.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(1.65F, 2.0F, 0.0F, 0.0F, 0.0F, -0.2618F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}

public sealed class CopperGolemStatueRenderState : BlockEntityRenderState {
    public Direction Direction = Direction.North;
    public CopperGolemStatuePose Pose;
    public int OxidationState;
}

/// <summary><c>CopperGolemStatueBlockRenderer</c>.</summary>
public sealed class CopperGolemStatueRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<ClientBlockEntity, CopperGolemStatueRenderState> {
    private readonly Dictionary<CopperGolemStatuePose, CopperGolemStatueModel> _models = Enum.GetValues<CopperGolemStatuePose>()
        .ToDictionary(pose => pose, pose => new CopperGolemStatueModel(CopperGolemStatueModel.Layer(pose).BakeRoot()));

    /// <summary><c>CopperGolemOxidationLevels.getOxidationLevel(state).texture()</c>.</summary>
    public static Identifier TexturePath(int oxidation) => oxidation switch {
        1 => "minecraft:textures/entity/copper_golem/copper_golem_exposed.png",
        2 => "minecraft:textures/entity/copper_golem/copper_golem_weathered.png",
        3 => "minecraft:textures/entity/copper_golem/copper_golem_oxidized.png",
        _ => "minecraft:textures/entity/copper_golem/copper_golem.png"
    };

    public static SpriteId Texture(int oxidation) => Sheets.TextureSprite(TexturePath(oxidation));

    /// <summary>The block's pose and <c>getWeatheringState</c>; every weathering stage is its own block class.</summary>
    private static (CopperGolemStatuePose Pose, int Oxidation) PoseAndOxidation(IBlock state) => state switch {
        CopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 0),
        WaxedCopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 0),
        ExposedCopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 1),
        WaxedExposedCopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 1),
        WeatheredCopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 2),
        WaxedWeatheredCopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 2),
        OxidizedCopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 3),
        WaxedOxidizedCopperGolemStatueBlock s => ((CopperGolemStatuePose)s.CopperGolemPoseValue, 3),
        _ => (CopperGolemStatuePose.Standing, 0)
    };

    public override void ExtractRenderState(ClientBlockEntity blockEntity, CopperGolemStatueRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.Direction = blockEntity.State is IHorizontalFacing facing ? facing.Facing : Direction.North;
        (state.Pose, state.OxidationState) = PoseAndOxidation(blockEntity.State);
    }

    public override void Submit(CopperGolemStatueRenderState state, PoseStack pose, EntityRenderContext render) {
        pose.Push();
        pose.MulPose(ModelTransformation(state.Direction));
        CopperGolemStatueModel model = _models[state.Pose];
        model.SetupAnim();
        model.RenderToBuffer(pose, render.Batch, Draw(context.Sprites.Get(Texture(state.OxidationState)), state));
        pose.Pop();
    }

    /// <summary><c>createModelTransformation</c>.</summary>
    public static Matrix4x4 ModelTransformation(Direction facing) =>
        BlockEntityTransforms.RotationYDegrees(-DirectionUtil.ToYRot(DirectionUtil.Opposite(facing))) * Matrix4x4.CreateTranslation(0.5F, 0.0F, 0.5F);
}
