namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>CreeperModel</c>.</summary>
public sealed class CreeperModel : EntityModel<CreeperRenderState> {
    private readonly ModelPart _head;
    private readonly ModelPart _rightHindLeg, _leftHindLeg, _rightFrontLeg, _leftFrontLeg;

    public CreeperModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        // Crossed on purpose, as vanilla's constructor crosses them: each field holds the part named for the other side.
        _leftHindLeg = root.GetChild("right_hind_leg");
        _rightHindLeg = root.GetChild("left_hind_leg");
        _leftFrontLeg = root.GetChild("right_front_leg");
        _rightFrontLeg = root.GetChild("left_front_leg");
    }

    public static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, g), PartPose.Offset(0.0F, 6.0F, 0.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(16, 16).AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F, g), PartPose.Offset(0.0F, 6.0F, 0.0F));
        CubeListBuilder leg = CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 6.0F, 4.0F, g);
        root.AddOrReplaceChild("right_hind_leg", leg, PartPose.Offset(-2.0F, 18.0F, 4.0F));
        root.AddOrReplaceChild("left_hind_leg", leg, PartPose.Offset(2.0F, 18.0F, 4.0F));
        root.AddOrReplaceChild("right_front_leg", leg, PartPose.Offset(-2.0F, 18.0F, -4.0F));
        root.AddOrReplaceChild("left_front_leg", leg, PartPose.Offset(2.0F, 18.0F, -4.0F));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(CreeperRenderState state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        _rightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        _leftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        _rightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        _leftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
    }
}
