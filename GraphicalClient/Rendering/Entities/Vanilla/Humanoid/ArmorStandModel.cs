using System.Numerics;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ArmorStandArmorModel</c>.</summary>
public class ArmorStandArmorModel : HumanoidModel<ArmorStandRenderState> {
    public ArmorStandArmorModel(ModelPart root) : base(root) { }

    public static ArmorModelSet<LayerDefinition> CreateArmorLayerSet(CubeDeformation innerDeformation, CubeDeformation outerDeformation) =>
        CreateArmorMeshSet(CreateBaseMesh, AdultArmorPartsPerSlot, innerDeformation, outerDeformation).Map(mesh => LayerDefinition.Create(mesh, 64, 32));

    private static MeshDefinition CreateBaseMesh(CubeDeformation g) {
        MeshDefinition mesh = CreateMesh(g, 0.0F);
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, g),
            PartPose.Offset(0.0F, 1.0F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, g.Extend(0.5F)), PartPose.Zero);
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g.Extend(-0.1F)),
            PartPose.Offset(-1.9F, 11.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 16).Mirror().AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 12.0F, 4.0F, g.Extend(-0.1F)),
            PartPose.Offset(1.9F, 11.0F, 0.0F));
        return mesh;
    }

    public override void SetupAnim(ArmorStandRenderState state) {
        base.SetupAnim(state);
        SetRotationDegrees(HeadPart, state.HeadPose);
        SetRotationDegrees(Body, state.BodyPose);
        SetRotationDegrees(LeftArm, state.LeftArmRotations);
        SetRotationDegrees(RightArm, state.RightArmRotations);
        SetRotationDegrees(LeftLeg, state.LeftLegPose);
        SetRotationDegrees(RightLeg, state.RightLegPose);
    }

    /// <summary>Each of x, y and z times <c>(float)(Math.PI / 180.0)</c>, as vanilla writes the three lines out.</summary>
    protected static void SetRotationDegrees(ModelPart part, Vector3 degrees) {
        const float d = (float)(Math.PI / 180.0);
        part.SetRotation(d * degrees.X, d * degrees.Y, d * degrees.Z);
    }
}

/// <summary><c>ArmorStandModel</c>.</summary>
public sealed class ArmorStandModel : ArmorStandArmorModel {
    private readonly ModelPart _rightBodyStick;
    private readonly ModelPart _leftBodyStick;
    private readonly ModelPart _shoulderStick;
    private readonly ModelPart _basePlate;

    public ArmorStandModel(ModelPart root) : base(root) {
        _rightBodyStick = root.GetChild("right_body_stick");
        _leftBodyStick = root.GetChild("left_body_stick");
        _shoulderStick = root.GetChild("shoulder_stick");
        _basePlate = root.GetChild("base_plate");
        Hat.Visible = false;
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateMesh(CubeDeformation.None, 0.0F);
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, -7.0F, -1.0F, 2.0F, 7.0F, 2.0F), PartPose.Offset(0.0F, 1.0F, 0.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 26).AddBox(-6.0F, 0.0F, -1.5F, 12.0F, 3.0F, 3.0F), PartPose.Zero);
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(24, 0).AddBox(-2.0F, -2.0F, -1.0F, 2.0F, 12.0F, 2.0F), PartPose.Offset(-5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(32, 16).Mirror().AddBox(0.0F, -2.0F, -1.0F, 2.0F, 12.0F, 2.0F),
            PartPose.Offset(5.0F, 2.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(8, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 11.0F, 2.0F), PartPose.Offset(-1.9F, 12.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(40, 16).Mirror().AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 11.0F, 2.0F),
            PartPose.Offset(1.9F, 12.0F, 0.0F));
        root.AddOrReplaceChild("right_body_stick", CubeListBuilder.Create().TexOffs(16, 0).AddBox(-3.0F, 3.0F, -1.0F, 2.0F, 7.0F, 2.0F), PartPose.Zero);
        root.AddOrReplaceChild("left_body_stick", CubeListBuilder.Create().TexOffs(48, 16).AddBox(1.0F, 3.0F, -1.0F, 2.0F, 7.0F, 2.0F), PartPose.Zero);
        root.AddOrReplaceChild("shoulder_stick", CubeListBuilder.Create().TexOffs(0, 48).AddBox(-4.0F, 10.0F, -1.0F, 8.0F, 2.0F, 2.0F), PartPose.Zero);
        root.AddOrReplaceChild("base_plate", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-6.0F, 11.0F, -6.0F, 12.0F, 1.0F, 12.0F), PartPose.Offset(0.0F, 12.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(ArmorStandRenderState state) {
        base.SetupAnim(state);
        _basePlate.YRot = (float)(Math.PI / 180.0) * -state.ArmorStandYRot;
        LeftArm.Visible = state.ShowArms;
        RightArm.Visible = state.ShowArms;
        _basePlate.Visible = state.ShowBasePlate;
        SetRotationDegrees(_rightBodyStick, state.BodyPose);
        SetRotationDegrees(_leftBodyStick, state.BodyPose);
        SetRotationDegrees(_shoulderStick, state.BodyPose);
    }

    public override void TranslateToHand(ArmorStandRenderState state, HumanoidArm arm, PoseStack pose) {
        ModelPart modelPart = GetArm(arm);
        bool handVisible = modelPart.Visible;
        modelPart.Visible = true;
        base.TranslateToHand(state, arm, pose);
        modelPart.Visible = handVisible;
    }
}
