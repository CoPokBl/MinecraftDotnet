namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyStriderModel : StriderModel {
    private readonly ModelPart _frontBristle;
    private readonly ModelPart _middleBristle;
    private readonly ModelPart _bottomBristle;

    public BabyStriderModel(ModelPart root) : base(root) {
        _frontBristle = Body.GetChild("bristle2");
        _middleBristle = Body.GetChild("bristle1");
        _bottomBristle = Body.GetChild("bristle0");
    }

    protected override void CustomAnimations(float animationPos, float animationSpeed, float ageInTicks) {
        Body.Y = 17.25F;
        Body.Y = Body.Y - 1.0F * Mth.Cos(animationPos * 1.5F) * 2.0F * animationSpeed;
        LeftLeg.Y = 20.0F + 2.0F * Mth.Sin(animationPos * 1.5F * 0.5F + MathF.PI) * 2.0F * animationSpeed;
        RightLeg.Y = 20.0F + 2.0F * Mth.Sin(animationPos * 1.5F * 0.5F) * 2.0F * animationSpeed;
        float bristleFlow = Mth.Cos(animationPos * 1.5F + MathF.PI) * animationSpeed;
        AnimateBristle(ageInTicks, bristleFlow, _frontBristle, _middleBristle, _bottomBristle, (modelPart, rotation) => modelPart.XRot += rotation);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.5F, -3.75F, -4.0F, 7.0F, 7.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 16.75F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(0, 24).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 4.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-1.5F, 20.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(8, 24).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 4.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(1.5F, 20.0F, 0.0F));
        body.AddOrReplaceChild("bristle0", CubeListBuilder.Create().TexOffs(0, 21).AddBox(-3.5F, -2.5F, 0.0F, 7.0F, 3.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -4.25F, 2.0F));
        body.AddOrReplaceChild("bristle1", CubeListBuilder.Create().TexOffs(0, 18).AddBox(-3.5F, -2.5F, 0.0F, 7.0F, 3.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -4.25F, 0.0F));
        body.AddOrReplaceChild("bristle2", CubeListBuilder.Create().TexOffs(0, 15).AddBox(-3.5F, -2.5F, 0.0F, 7.0F, 3.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -4.25F, -2.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
