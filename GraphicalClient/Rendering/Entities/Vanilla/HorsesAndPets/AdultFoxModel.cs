namespace GraphicalClient.Rendering.Entities.Vanilla;

public class AdultFoxModel(ModelPart root) : FoxModel(root) {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(1, 5).AddBox(-3.0F, -2.0F, -5.0F, 8.0F, 6.0F, 6.0F),
            PartPose.Offset(-1.0F, 16.5F, -3.0F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(8, 1).AddBox(-3.0F, -4.0F, -4.0F, 2.0F, 2.0F, 1.0F), PartPose.Zero);
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(15, 1).AddBox(3.0F, -4.0F, -4.0F, 2.0F, 2.0F, 1.0F), PartPose.Zero);
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(6, 18).AddBox(-1.0F, 2.01F, -8.0F, 4.0F, 2.0F, 3.0F), PartPose.Zero);
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(24, 15).AddBox(-3.0F, 3.999F, -3.5F, 6.0F, 11.0F, 6.0F),
            PartPose.OffsetAndRotation(0.0F, 16.0F, -6.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        CubeDeformation fudge = new(0.001F);
        CubeListBuilder leftLeg = CubeListBuilder.Create().TexOffs(4, 24).AddBox(2.0F, 0.5F, -1.0F, 2.0F, 6.0F, 2.0F, fudge);
        CubeListBuilder rightLeg = CubeListBuilder.Create().TexOffs(13, 24).AddBox(2.0F, 0.5F, -1.0F, 2.0F, 6.0F, 2.0F, fudge);
        root.AddOrReplaceChild("right_hind_leg", rightLeg, PartPose.Offset(-5.0F, 17.5F, 7.0F));
        root.AddOrReplaceChild("left_hind_leg", leftLeg, PartPose.Offset(-1.0F, 17.5F, 7.0F));
        root.AddOrReplaceChild("right_front_leg", rightLeg, PartPose.Offset(-5.0F, 17.5F, 0.0F));
        root.AddOrReplaceChild("left_front_leg", leftLeg, PartPose.Offset(-1.0F, 17.5F, 0.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(30, 0).AddBox(2.0F, 0.0F, -1.0F, 4.0F, 9.0F, 5.0F),
            PartPose.OffsetAndRotation(-4.0F, 15.0F, -1.0F, -0.05235988F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 48, 32);
    }

    protected override void SetSittingPose(FoxRenderState state) {
        base.SetSittingPose(state);
        Body.XRot = (float)(Math.PI / 6);
        Body.Y -= 7.0F;
        Body.Z += 3.0F;
        Tail.XRot = (float)(Math.PI / 4);
        Head.Y -= 6.5F;
        Head.Z += 2.75F;
        RightFrontLeg.XRot = (float)(-Math.PI / 12);
        LeftFrontLeg.XRot = (float)(-Math.PI / 12);
        RightHindLeg.XRot = (float)(-Math.PI * 5.0 / 12.0);
        RightHindLeg.Y += 4.0F;
        RightHindLeg.Z -= 0.25F;
        LeftHindLeg.XRot = (float)(-Math.PI * 5.0 / 12.0);
        LeftHindLeg.Y += 4.0F;
        LeftHindLeg.Z -= 0.25F;
        Tail.Z--;
    }

    protected override void SetSleepingPose(FoxRenderState state) {
        base.SetSleepingPose(state);
        Body.ZRot = (float)(-Math.PI / 2);
        Body.Y += 5.0F;
        Tail.XRot = (float)(-Math.PI * 5.0 / 6.0);
        Head.X += 2.0F;
        Head.Y += 2.99F;
        Head.YRot = (float)(-Math.PI * 2.0 / 3.0);
        Head.ZRot = 0.0F;
    }

    protected override void SetWalkingPose(FoxRenderState state) {
        base.SetWalkingPose(state);
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        RightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
        LeftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        RightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * 1.4F * animationSpeed;
        LeftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F) * 1.4F * animationSpeed;
    }

    protected override void SetCrouchingPose(FoxRenderState state) {
        base.SetCrouchingPose(state);
        Body.Y = Body.Y + state.CrouchAmount;
    }

    protected override void SetPouncingPose(FoxRenderState state) {
        base.SetPouncingPose(state);
        float crouch = state.CrouchAmount / 2.0F;
        Body.Y -= crouch;
        Head.Y -= crouch;
    }
}
