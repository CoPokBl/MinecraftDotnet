namespace GraphicalClient.Rendering.Entities.Vanilla;

public class NautilusModel : EntityModel<NautilusRenderState> {
    protected readonly ModelPart Body, Nautilus;
    private readonly KeyframeAnimation _swimAnimation;

    public NautilusModel(ModelPart root) : base(root) {
        Nautilus = root.GetChild("root");
        Body = Nautilus.GetChild("body");
        _swimAnimation = NautilusAnimation.Swimming.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() => LayerDefinition.Create(CreateBodyMesh(), 128, 128);

    public static MeshDefinition CreateBodyMesh() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition nautilus = partdefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(0.0F, 29.0F, -6.0F));
        nautilus.AddOrReplaceChild("shell", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-7.0F, -10.0F, -7.0F, 14.0F, 10.0F, 16.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 26).AddBox(-7.0F, 0.0F, -7.0F, 14.0F, 8.0F, 20.0F, new CubeDeformation(0.0F))
                .TexOffs(48, 26).AddBox(-7.0F, 0.0F, 6.0F, 14.0F, 8.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -13.0F, 5.0F));
        PartDefinition body = nautilus.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 54).AddBox(-5.0F, -4.51F, -3.0F, 10.0F, 8.0F, 14.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 76).AddBox(-5.0F, -4.51F, 7.0F, 10.0F, 8.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -8.5F, 12.3F));
        body.AddOrReplaceChild("upper_mouth", CubeListBuilder.Create().TexOffs(54, 54).AddBox(-5.0F, -2.0F, 0.0F, 10.0F, 4.0F, 4.0F, new CubeDeformation(-0.001F)),
            PartPose.Offset(0.0F, -2.51F, 7.0F));
        body.AddOrReplaceChild("inner_mouth", CubeListBuilder.Create().TexOffs(54, 70).AddBox(-3.0F, -2.0F, -0.5F, 6.0F, 4.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -0.51F, 7.5F));
        body.AddOrReplaceChild("lower_mouth", CubeListBuilder.Create().TexOffs(54, 62).AddBox(-5.0F, -1.98F, 0.0F, 10.0F, 4.0F, 4.0F, new CubeDeformation(-0.001F)),
            PartPose.Offset(0.0F, 1.49F, 7.0F));
        return meshdefinition;
    }

    public static LayerDefinition CreateBabyBodyLayer() {
        MeshDefinition meshdefinition = new();
        PartDefinition partdefinition = meshdefinition.Root;
        PartDefinition nautilus = partdefinition.AddOrReplaceChild("root", CubeListBuilder.Create(), PartPose.Offset(-0.5F, 28.0F, -0.5F));
        nautilus.AddOrReplaceChild("shell", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-6.0F, -4.0F, -1.0F, 7.0F, 4.0F, 7.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 11).AddBox(-6.0F, 0.0F, -1.0F, 7.0F, 4.0F, 9.0F, new CubeDeformation(0.0F))
                .TexOffs(23, 11).AddBox(-6.0F, 0.0F, 5.0F, 7.0F, 4.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(3.0F, -8.0F, -2.0F));
        PartDefinition body = nautilus.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 24).AddBox(-2.5F, -3.01F, -1.0F, 5.0F, 4.0F, 7.0F, new CubeDeformation(0.0F))
                .TexOffs(0, 35).AddBox(-2.5F, -3.01F, 4.1F, 5.0F, 4.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.5F, -5.0F, 3.0F));
        body.AddOrReplaceChild("upper_mouth", CubeListBuilder.Create().TexOffs(24, 24).AddBox(-2.5F, -1.0F, 0.0F, 5.0F, 2.0F, 2.0F, new CubeDeformation(-0.001F)),
            PartPose.Offset(0.0F, -2.01F, 3.9F));
        body.AddOrReplaceChild("inner_mouth", CubeListBuilder.Create().TexOffs(24, 32).AddBox(-1.5F, -1.0F, -1.0F, 3.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -1.01F, 4.9F));
        body.AddOrReplaceChild("lower_mouth", CubeListBuilder.Create().TexOffs(24, 28).AddBox(-2.5F, -1.0F, 0.0F, 5.0F, 2.0F, 2.0F, new CubeDeformation(-0.001F)),
            PartPose.Offset(0.0F, -0.01F, 3.9F));
        return LayerDefinition.Create(meshdefinition, 64, 64);
    }

    public override void SetupAnim(NautilusRenderState state) {
        base.SetupAnim(state);
        ApplyBodyRotation(state.YRot, state.XRot);
        _swimAnimation.ApplyWalk(state.WalkAnimationPos + state.AgeInTicks / 5.0F, state.WalkAnimationSpeed + 0.2F, 2.0F, 3.0F);
    }

    private void ApplyBodyRotation(float yRot, float xRot) {
        yRot = Mth.Clamp(yRot, -10.0F, 10.0F);
        xRot = Mth.Clamp(xRot, -10.0F, 10.0F);
        Body.YRot = yRot * (float)(Math.PI / 180.0);
        Body.XRot = xRot * (float)(Math.PI / 180.0);
    }
}
