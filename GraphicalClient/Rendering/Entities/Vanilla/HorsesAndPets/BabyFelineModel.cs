namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BabyFelineModel</c>. Its <c>Mth.rotLerp</c> calls wrap radians as though they were degrees, as vanilla's do.</summary>
public class BabyFelineModel<S> : AbstractFelineModel<S> where S : FelineRenderState {
    protected BabyFelineModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBabyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-2.5F, -3.0F, -2.875F, 5.0F, 4.0F, 4.0F)
            .TexOffs(18, 0).AddBox(-2.0F, -4.0F, -0.875F, 1.0F, 1.0F, 2.0F)
            .TexOffs(24, 0).AddBox(1.0F, -4.0F, -0.875F, 1.0F, 1.0F, 2.0F)
            .TexOffs(18, 3).AddBox(-1.5F, -1.0F, -3.875F, 3.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, 20.0F, -3.125F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(18, 18).AddBox(-0.5F, 0.0F, -1.0F, 1.0F, 2.0F, 2.0F),
            PartPose.Offset(1.0F, 22.0F, -1.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(12, 18).AddBox(-0.5F, 0.0F, -1.0F, 1.0F, 2.0F, 2.0F),
            PartPose.Offset(-1.0F, 22.0F, -1.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(18, 22).AddBox(-0.5F, 0.0F, -1.0F, 1.0F, 2.0F, 2.0F),
            PartPose.Offset(1.0F, 22.0F, 2.5F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 8).AddBox(-2.0F, -1.5F, -3.5F, 4.0F, 3.0F, 7.0F), PartPose.Offset(0.0F, 20.5F, 0.5F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(12, 22).AddBox(-0.5F, 0.0F, -1.0F, 1.0F, 2.0F, 2.0F),
            PartPose.Offset(-1.0F, 22.0F, 2.5F));
        root.AddOrReplaceChild("tail1", CubeListBuilder.Create().TexOffs(0, 18).AddBox(-0.5F, -0.107F, 0.0849F, 1.0F, 1.0F, 5.0F),
            PartPose.OffsetAndRotation(0.0F, 19.107F, 3.9151F, -0.567232F, 0.0F, 0.0F));
        root.AddOrReplaceChild("tail2", CubeListBuilder.Create(), PartPose.Zero);
        return LayerDefinition.Create(mesh, 32, 32);
    }

    public override void SetupAnim(S state) {
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
        else if (state.IsSitting) {
            Body.XRot += -0.43633232F;
            Body.Y++;
            Head.Z += 0.75F;
            Tail1.XRot += 0.5454154F;
            Tail1.Y += 4.0F;
            Tail1.Z -= 0.9F;
            LeftHindLeg.Z -= 0.9F;
            RightHindLeg.Z -= 0.9F;
        }
        if (state.LieDownAmount > 0.0F) {
            Body.X++;
            Head.XRot = Mth.RotLerp(state.LieDownAmount, Head.XRot, (float)(Math.PI / 18));
            Head.ZRot = Mth.RotLerp(state.LieDownAmount, Head.ZRot, (float)(-Math.PI * 5.0 / 12.0));
            Head.X++;
            Head.Y += 0.75F;
            Head.Z -= 0.5F;
            RightFrontLeg.XRot = (float)(-Math.PI / 4);
            RightFrontLeg.X += 3.5F;
            RightFrontLeg.Y -= 0.5F;
            RightFrontLeg.Z += 0.0F;
            LeftFrontLeg.XRot = (float)(-Math.PI / 2);
            LeftFrontLeg.X++;
            LeftFrontLeg.Y--;
            LeftFrontLeg.Z -= 2.0F;
            RightHindLeg.XRot = (float)(Math.PI * 2.0 / 9.0);
            RightHindLeg.YRot = (float)(Math.PI / 9);
            RightHindLeg.ZRot = (float)(-Math.PI / 9);
            RightHindLeg.X += 2.5F;
            RightHindLeg.Y -= 0.25F;
            RightHindLeg.Z += 0.5F;
            LeftHindLeg.X++;
            LeftHindLeg.Z--;
            // Each adds the lerp to the angle it lerps from, as vanilla's does.
            Tail1.XRot = Tail1.XRot + Mth.RotLerp(state.LieDownAmountTail, Tail1.XRot, (float)(-Math.PI / 6));
            Tail1.YRot = Tail1.YRot + Mth.RotLerp(state.LieDownAmountTail, Tail1.YRot, 0.0F);
            Tail1.ZRot = Tail1.ZRot + Mth.RotLerp(state.LieDownAmountTail, Tail1.ZRot, (float)(-Math.PI / 18));
            Tail1.X++;
            Tail1.Y += 0.5F;
            Tail1.Z -= 0.25F;
        }
        if (state.RelaxStateOneAmount > 0.0F) {
            Head.XRot = Mth.RotLerp(state.RelaxStateOneAmount, Head.XRot, -0.58177644F);
        }
    }
}
