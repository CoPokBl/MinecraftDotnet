namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class AdultStriderModel : StriderModel {
    private readonly ModelPart _rightBottomBristle;
    private readonly ModelPart _rightMiddleBristle;
    private readonly ModelPart _rightTopBristle;
    private readonly ModelPart _leftTopBristle;
    private readonly ModelPart _leftMiddleBristle;
    private readonly ModelPart _leftBottomBristle;

    public AdultStriderModel(ModelPart root) : base(root) {
        _rightBottomBristle = Body.GetChild("right_bottom_bristle");
        _rightMiddleBristle = Body.GetChild("right_middle_bristle");
        _rightTopBristle = Body.GetChild("right_top_bristle");
        _leftTopBristle = Body.GetChild("left_top_bristle");
        _leftMiddleBristle = Body.GetChild("left_middle_bristle");
        _leftBottomBristle = Body.GetChild("left_bottom_bristle");
    }

    protected override void CustomAnimations(float animationPos, float animationSpeed, float ageInTicks) {
        _rightBottomBristle.ZRot = -1.2217305F;
        _rightMiddleBristle.ZRot = -1.134464F;
        _rightTopBristle.ZRot = -0.87266463F;
        _leftTopBristle.ZRot = 0.87266463F;
        _leftMiddleBristle.ZRot = 1.134464F;
        _leftBottomBristle.ZRot = 1.2217305F;
        float bristleFlow = Mth.Cos(animationPos * 1.5F + MathF.PI) * animationSpeed;
        AnimateBristle(ageInTicks, bristleFlow, _rightTopBristle, _rightMiddleBristle, _rightBottomBristle, (modelPart, rotation) => modelPart.ZRot += rotation);
        AnimateBristle(ageInTicks, bristleFlow, _leftTopBristle, _leftMiddleBristle, _leftBottomBristle, (modelPart, rotation) => modelPart.ZRot += rotation);
        Body.Y = 2.0F;
        Body.Y = Body.Y - 2.0F * Mth.Cos(animationPos * 1.5F) * 2.0F * animationSpeed;
        LeftLeg.Y = 8.0F + 2.0F * Mth.Sin(animationPos * 1.5F * 0.5F + MathF.PI) * 2.0F * animationSpeed;
        RightLeg.Y = 8.0F + 2.0F * Mth.Sin(animationPos * 1.5F * 0.5F) * 2.0F * animationSpeed;
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 16.0F, 4.0F), PartPose.Offset(-4.0F, 8.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(0, 55).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 16.0F, 4.0F), PartPose.Offset(4.0F, 8.0F, 0.0F));
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -6.0F, -8.0F, 16.0F, 14.0F, 16.0F),
            PartPose.Offset(0.0F, 1.0F, 0.0F));
        body.AddOrReplaceChild("right_bottom_bristle", CubeListBuilder.Create().TexOffs(16, 65).AddBox(-12.0F, 0.0F, 0.0F, 12.0F, 0.0F, 16.0F, true),
            PartPose.OffsetAndRotation(-8.0F, 4.0F, -8.0F, 0.0F, 0.0F, -1.2217305F));
        body.AddOrReplaceChild("right_middle_bristle", CubeListBuilder.Create().TexOffs(16, 49).AddBox(-12.0F, 0.0F, 0.0F, 12.0F, 0.0F, 16.0F, true),
            PartPose.OffsetAndRotation(-8.0F, -1.0F, -8.0F, 0.0F, 0.0F, -1.134464F));
        body.AddOrReplaceChild("right_top_bristle", CubeListBuilder.Create().TexOffs(16, 33).AddBox(-12.0F, 0.0F, 0.0F, 12.0F, 0.0F, 16.0F, true),
            PartPose.OffsetAndRotation(-8.0F, -5.0F, -8.0F, 0.0F, 0.0F, -0.87266463F));
        body.AddOrReplaceChild("left_top_bristle", CubeListBuilder.Create().TexOffs(16, 33).AddBox(0.0F, 0.0F, 0.0F, 12.0F, 0.0F, 16.0F),
            PartPose.OffsetAndRotation(8.0F, -6.0F, -8.0F, 0.0F, 0.0F, 0.87266463F));
        body.AddOrReplaceChild("left_middle_bristle", CubeListBuilder.Create().TexOffs(16, 49).AddBox(0.0F, 0.0F, 0.0F, 12.0F, 0.0F, 16.0F),
            PartPose.OffsetAndRotation(8.0F, -2.0F, -8.0F, 0.0F, 0.0F, 1.134464F));
        body.AddOrReplaceChild("left_bottom_bristle", CubeListBuilder.Create().TexOffs(16, 65).AddBox(0.0F, 0.0F, 0.0F, 12.0F, 0.0F, 16.0F),
            PartPose.OffsetAndRotation(8.0F, 3.0F, -8.0F, 0.0F, 0.0F, 1.2217305F));
        return LayerDefinition.Create(mesh, 64, 128);
    }
}
