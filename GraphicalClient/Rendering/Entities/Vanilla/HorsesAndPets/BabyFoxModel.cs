namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BabyFoxModel</c>: walks by keyframe animation rather than by swinging its legs.</summary>
public class BabyFoxModel : FoxModel {
    private readonly KeyframeAnimation _babyWalkAnimation;

    public BabyFoxModel(ModelPart root) : base(root) {
        _babyWalkAnimation = FoxBabyAnimation.FoxBabyWalk.Bake(root);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-3.0F, -2.125F, -5.125F, 6.0F, 5.0F, 5.0F, new CubeDeformation(0.0F))
            .TexOffs(18, 20).AddBox(-1.0F, 0.875F, -7.125F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F))
            .TexOffs(22, 8).AddBox(-3.0F, -4.125F, -4.125F, 2.0F, 2.0F, 1.0F, new CubeDeformation(0.0F))
            .TexOffs(22, 11).AddBox(1.0F, -4.125F, -4.125F, 2.0F, 2.0F, 1.0F, new CubeDeformation(0.0F)), PartPose.Offset(0.0F, 18.125F, 0.125F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(22, 4).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-1.5F, 22.0F, 4.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(22, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(1.5F, 22.0F, 4.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(22, 4).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-1.5F, 22.0F, 0.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(22, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(1.5F, 22.0F, 0.0F));
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 10).AddBox(-2.5F, -2.0F, -3.0F, 5.0F, 4.0F, 6.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 20.0F, 2.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(0, 20).AddBox(-1.5F, -1.48F, -1.0F, 3.0F, 3.0F, 6.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, -0.5F, 3.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }

    protected override void SetSittingPose(FoxRenderState state) {
        base.SetSittingPose(state);
        Body.XRot = -0.959931F;
        Body.Z = Body.Z - 4.5F * state.AgeScale;
        Body.Y = Body.Y + 3.0F * state.AgeScale;
        Tail.Y -= 0.6F;
        Tail.Z = Tail.Z - 2.0F * state.AgeScale;
        Tail.XRot = 0.95993114F;
        Head.Y -= 0.75F;
        Head.Z += 0.0F;
        RightFrontLeg.XRot = (float)(-Math.PI / 12);
        LeftFrontLeg.XRot = (float)(-Math.PI / 12);
        RightFrontLeg.Z--;
        LeftFrontLeg.Z--;
        RightFrontLeg.X += 0.01F;
        LeftFrontLeg.X -= 0.01F;
        RightHindLeg.Z -= 3.75F;
        LeftHindLeg.Z -= 3.75F;
        RightHindLeg.X += 0.01F;
        LeftHindLeg.X -= 0.01F;
    }

    protected override void SetSleepingPose(FoxRenderState state) {
        base.SetSleepingPose(state);
        Body.ZRot = (float)(-Math.PI / 2);
        Body.XRot = (float)(-Math.PI / 18);
        Body.Y++;
        Body.Z--;
        Body.X--;
        Tail.XRot = (float)(-Math.PI * 5.0 / 6.0);
        Tail.XRot = -2.1816616F;
        Tail.X -= 0.7F;
        Tail.Z += 0.6F;
        Tail.Y += 0.9F;
        Head.X -= 2.0F;
        Head.Y += 2.8F;
        Head.Z -= 4.0F;
        Head.YRot = (float)(-Math.PI * 2.0 / 3.0);
        Head.ZRot = 0.0F;
    }

    protected override void SetWalkingPose(FoxRenderState state) {
        base.SetWalkingPose(state);
        _babyWalkAnimation.ApplyWalk(state.WalkAnimationPos, state.WalkAnimationSpeed, 1.0F, 2.5F);
    }

    protected override void SetCrouchingPose(FoxRenderState state) {
        base.SetCrouchingPose(state);
        Body.Y = Body.Y + state.CrouchAmount / 6.0F;
    }
}
