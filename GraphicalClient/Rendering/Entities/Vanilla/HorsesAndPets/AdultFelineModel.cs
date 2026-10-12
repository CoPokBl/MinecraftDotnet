namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>AdultFelineModel</c>. Its <c>Mth.rotLerp</c> calls wrap radians as though they were degrees, as vanilla's do.</summary>
public class AdultFelineModel<T>(ModelPart root) : AbstractFelineModel<T>(root) where T : FelineRenderState {
    public static LayerDefinition CreateBodyLayer(CubeDeformation g) => LayerDefinition.Create(CreateBodyMesh(g), 64, 32);

    public static MeshDefinition CreateBodyMesh(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        CubeDeformation tailG = new(-0.02F);
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .AddBox("main", -2.5F, -2.0F, -3.0F, 5.0F, 4.0F, 5.0F, g)
            .AddBox("nose", -1.5F, -0.001F, -4.0F, 3, 2, 2, g, 0, 24)
            .AddBox("ear1", -2.0F, -3.0F, 0.0F, 1, 1, 2, g, 0, 10)
            .AddBox("ear2", 1.0F, -3.0F, 0.0F, 1, 1, 2, g, 6, 10), PartPose.Offset(0.0F, 15.0F, -9.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(20, 0).AddBox(-2.0F, 3.0F, -8.0F, 4.0F, 16.0F, 6.0F, g),
            PartPose.OffsetAndRotation(0.0F, 12.0F, -10.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        root.AddOrReplaceChild("tail1", CubeListBuilder.Create().TexOffs(0, 15).AddBox(-0.5F, 0.0F, 0.0F, 1.0F, 8.0F, 1.0F, g),
            PartPose.OffsetAndRotation(0.0F, 15.0F, 8.0F, 0.9F, 0.0F, 0.0F));
        root.AddOrReplaceChild("tail2", CubeListBuilder.Create().TexOffs(4, 15).AddBox(-0.5F, 0.0F, 0.0F, 1.0F, 8.0F, 1.0F, tailG), PartPose.Offset(0.0F, 20.0F, 14.0F));
        CubeListBuilder hindLeg = CubeListBuilder.Create().TexOffs(8, 13).AddBox(-1.0F, 0.0F, 1.0F, 2.0F, 6.0F, 2.0F, g);
        root.AddOrReplaceChild("left_hind_leg", hindLeg, PartPose.Offset(1.1F, 18.0F, 5.0F));
        root.AddOrReplaceChild("right_hind_leg", hindLeg, PartPose.Offset(-1.1F, 18.0F, 5.0F));
        CubeListBuilder frontLeg = CubeListBuilder.Create().TexOffs(40, 0).AddBox(-1.0F, 0.0F, 0.0F, 2.0F, 10.0F, 2.0F, g);
        root.AddOrReplaceChild("left_front_leg", frontLeg, PartPose.Offset(1.2F, 14.1F, -5.0F));
        root.AddOrReplaceChild("right_front_leg", frontLeg, PartPose.Offset(-1.2F, 14.1F, -5.0F));
        return mesh;
    }

    public override void SetupAnim(T state) {
        base.SetupAnim(state);
        float ageScale = state.AgeScale;
        if (state.IsCrouching) {
            Body.Y += 1.0F * ageScale;
            Head.Y += 2.0F * ageScale;
            Tail1.Y += 1.0F * ageScale;
            Tail2.Y += -4.0F * ageScale;
            Tail2.Z += 2.0F * ageScale;
            Tail1.XRot = (float)(Math.PI / 2);
            Tail2.XRot = (float)(Math.PI / 2);
        }
        else if (state.IsSprinting) {
            Tail2.Y = Tail1.Y;
            Tail2.Z += 2.0F * ageScale;
            Tail1.XRot = (float)(Math.PI / 2);
            Tail2.XRot = (float)(Math.PI / 2);
        }
        Head.XRot = state.XRot * (float)(Math.PI / 180.0);
        Head.YRot = state.YRot * (float)(Math.PI / 180.0);
        if (!state.IsSitting) {
            Body.XRot = (float)(Math.PI / 2);
            float animationSpeed = state.WalkAnimationSpeed;
            float animationPos = state.WalkAnimationPos;
            if (state.IsSprinting) {
                LeftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * animationSpeed;
                RightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + 0.3F) * animationSpeed;
                LeftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI + 0.3F) * animationSpeed;
                RightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * animationSpeed;
                Tail2.XRot = 1.7278761F + (float)(Math.PI / 10) * Mth.Cos(animationPos) * animationSpeed;
            }
            else {
                LeftHindLeg.XRot = Mth.Cos(animationPos * 0.6662F) * animationSpeed;
                RightHindLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * animationSpeed;
                LeftFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F + MathF.PI) * animationSpeed;
                RightFrontLeg.XRot = Mth.Cos(animationPos * 0.6662F) * animationSpeed;
                if (!state.IsCrouching) {
                    Tail2.XRot = 1.7278761F + (float)(Math.PI / 4) * Mth.Cos(animationPos) * animationSpeed;
                }
                else {
                    Tail2.XRot = 1.7278761F + 0.47123894F * Mth.Cos(animationPos) * animationSpeed;
                }
            }
        }
        if (state.IsSitting) {
            Body.XRot = (float)(Math.PI / 4);
            Body.Y += -4.0F * ageScale;
            Body.Z += 5.0F * ageScale;
            Head.Y += -3.3F * ageScale;
            Head.Z += 1.0F * ageScale;
            Tail1.Y += 8.0F * ageScale;
            Tail1.Z += -2.0F * ageScale;
            Tail2.Y += 2.0F * ageScale;
            Tail2.Z += -0.8F * ageScale;
            Tail1.XRot = 1.7278761F;
            Tail2.XRot = 2.670354F;
            LeftFrontLeg.XRot = (float)(-Math.PI / 20);
            LeftFrontLeg.Y += 2.0F * ageScale;
            LeftFrontLeg.Z -= 2.0F * ageScale;
            RightFrontLeg.XRot = (float)(-Math.PI / 20);
            RightFrontLeg.Y += 2.0F * ageScale;
            RightFrontLeg.Z -= 2.0F * ageScale;
            LeftHindLeg.XRot = (float)(-Math.PI / 2);
            LeftHindLeg.Y += 3.0F * ageScale;
            LeftHindLeg.Z -= 4.0F * ageScale;
            RightHindLeg.XRot = (float)(-Math.PI / 2);
            RightHindLeg.Y += 3.0F * ageScale;
            RightHindLeg.Z -= 4.0F * ageScale;
        }
        if (state.LieDownAmount > 0.0F) {
            Head.ZRot = Mth.RotLerp(state.LieDownAmount, Head.ZRot, -1.2707963F);
            Head.YRot = Mth.RotLerp(state.LieDownAmount, Head.YRot, 1.2707963F);
            LeftFrontLeg.XRot = -1.2707963F;
            RightFrontLeg.XRot = -0.47079635F;
            RightFrontLeg.ZRot = -0.2F;
            RightFrontLeg.X += ageScale;
            LeftHindLeg.XRot = -0.4F;
            RightHindLeg.XRot = 0.5F;
            RightHindLeg.ZRot = -0.5F;
            RightHindLeg.X += 0.8F * ageScale;
            RightHindLeg.Y += 2.0F * ageScale;
            Tail1.XRot = Mth.RotLerp(state.LieDownAmountTail, Tail1.XRot, 0.8F);
            Tail2.XRot = Mth.RotLerp(state.LieDownAmountTail, Tail2.XRot, -0.4F);
        }
        if (state.RelaxStateOneAmount > 0.0F) {
            Head.XRot = Mth.RotLerp(state.RelaxStateOneAmount, Head.XRot, -0.58177644F);
        }
    }
}
