namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class AdultBeeModel : BeeModel {
    private readonly ModelPart _leftAntenna, _rightAntenna;

    public AdultBeeModel(ModelPart root) : base(root) {
        ModelPart body = Bone.GetChild("body");
        _leftAntenna = body.GetChild("left_antenna");
        _rightAntenna = body.GetChild("right_antenna");
    }

    protected override void BobUpAndDown(float speed, float ageInTicks) {
        base.BobUpAndDown(speed, ageInTicks);
        _leftAntenna.XRot = speed * MathF.PI * 0.03F;
        _rightAntenna.XRot = speed * MathF.PI * 0.03F;
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition bone = root.AddOrReplaceChild("bone", CubeListBuilder.Create(), PartPose.Offset(0.0F, 19.0F, 0.0F));
        PartDefinition body = bone.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.5F, -4.0F, -5.0F, 7.0F, 7.0F, 10.0F), PartPose.Zero);
        body.AddOrReplaceChild("stinger", CubeListBuilder.Create().TexOffs(26, 7).AddBox(0.0F, -1.0F, 5.0F, 0.0F, 1.0F, 2.0F), PartPose.Zero);
        body.AddOrReplaceChild("left_antenna", CubeListBuilder.Create().TexOffs(2, 0).AddBox(1.5F, -2.0F, -3.0F, 1.0F, 2.0F, 3.0F), PartPose.Offset(0.0F, -2.0F, -5.0F));
        body.AddOrReplaceChild("right_antenna", CubeListBuilder.Create().TexOffs(2, 3).AddBox(-2.5F, -2.0F, -3.0F, 1.0F, 2.0F, 3.0F),
            PartPose.Offset(0.0F, -2.0F, -5.0F));
        CubeDeformation wingDeformation = new(0.001F);
        bone.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(0, 18).AddBox(-9.0F, 0.0F, 0.0F, 9.0F, 0.0F, 6.0F, wingDeformation),
            PartPose.OffsetAndRotation(-1.5F, -4.0F, -3.0F, 0.0F, -0.2618F, 0.0F));
        bone.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(0, 18).Mirror().AddBox(0.0F, 0.0F, 0.0F, 9.0F, 0.0F, 6.0F, wingDeformation),
            PartPose.OffsetAndRotation(1.5F, -4.0F, -3.0F, 0.0F, 0.2618F, 0.0F));
        bone.AddOrReplaceChild("front_legs", CubeListBuilder.Create().AddBox("front_legs", -5.0F, 0.0F, 0.0F, 7, 2, 0, 26, 1), PartPose.Offset(1.5F, 3.0F, -2.0F));
        bone.AddOrReplaceChild("middle_legs", CubeListBuilder.Create().AddBox("middle_legs", -5.0F, 0.0F, 0.0F, 7, 2, 0, 26, 3), PartPose.Offset(1.5F, 3.0F, 0.0F));
        bone.AddOrReplaceChild("back_legs", CubeListBuilder.Create().AddBox("back_legs", -5.0F, 0.0F, 0.0F, 7, 2, 0, 26, 5), PartPose.Offset(1.5F, 3.0F, 2.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
