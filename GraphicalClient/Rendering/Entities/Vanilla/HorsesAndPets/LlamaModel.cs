namespace GraphicalClient.Rendering.Entities.Vanilla;

public class LlamaModel : EntityModel<LlamaRenderState> {
    private readonly ModelPart _head;
    private readonly ModelPart _rightHindLeg;
    private readonly ModelPart _leftHindLeg;
    private readonly ModelPart _rightFrontLeg;
    private readonly ModelPart _leftFrontLeg;
    private readonly ModelPart _rightChest;
    private readonly ModelPart _leftChest;

    public LlamaModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _rightChest = root.GetChild("right_chest");
        _leftChest = root.GetChild("left_chest");
        _rightHindLeg = root.GetChild("right_hind_leg");
        _leftHindLeg = root.GetChild("left_hind_leg");
        _rightFrontLeg = root.GetChild("right_front_leg");
        _leftFrontLeg = root.GetChild("left_front_leg");
    }

    public static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-2.0F, -14.0F, -10.0F, 4.0F, 4.0F, 9.0F, g)
            .TexOffs(0, 14).AddBox("neck", -4.0F, -16.0F, -6.0F, 8.0F, 18.0F, 6.0F, g)
            .TexOffs(17, 0).AddBox("ear", -4.0F, -19.0F, -4.0F, 3.0F, 3.0F, 2.0F, g)
            .TexOffs(17, 0).AddBox("ear", 1.0F, -19.0F, -4.0F, 3.0F, 3.0F, 2.0F, g), PartPose.Offset(0.0F, 7.0F, -6.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(29, 0).AddBox(-6.0F, -10.0F, -7.0F, 12.0F, 18.0F, 10.0F, g),
            PartPose.OffsetAndRotation(0.0F, 5.0F, 2.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        root.AddOrReplaceChild("right_chest", CubeListBuilder.Create().TexOffs(45, 28).AddBox(-3.0F, 0.0F, 0.0F, 8.0F, 8.0F, 3.0F, g),
            PartPose.OffsetAndRotation(-8.5F, 3.0F, 3.0F, 0.0F, (float)(Math.PI / 2), 0.0F));
        root.AddOrReplaceChild("left_chest", CubeListBuilder.Create().TexOffs(45, 41).AddBox(-3.0F, 0.0F, 0.0F, 8.0F, 8.0F, 3.0F, g),
            PartPose.OffsetAndRotation(5.5F, 3.0F, 3.0F, 0.0F, (float)(Math.PI / 2), 0.0F));
        CubeListBuilder leg = CubeListBuilder.Create().TexOffs(29, 29).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 14.0F, 4.0F, g);
        root.AddOrReplaceChild("right_hind_leg", leg, PartPose.Offset(-3.5F, 10.0F, 6.0F));
        root.AddOrReplaceChild("left_hind_leg", leg, PartPose.Offset(3.5F, 10.0F, 6.0F));
        root.AddOrReplaceChild("right_front_leg", leg, PartPose.Offset(-3.5F, 10.0F, -5.0F));
        root.AddOrReplaceChild("left_front_leg", leg, PartPose.Offset(3.5F, 10.0F, -5.0F));
        return LayerDefinition.Create(mesh, 128, 64);
    }

    public override void SetupAnim(LlamaRenderState state) {
        base.SetupAnim(state);
        _head.XRot = state.XRot * (float)(Math.PI / 180.0);
        _head.YRot = state.YRot * (float)(Math.PI / 180.0);
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        _rightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        _leftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        _rightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        _leftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        _rightChest.Visible = state.HasChest;
        _leftChest.Visible = state.HasChest;
    }
}
