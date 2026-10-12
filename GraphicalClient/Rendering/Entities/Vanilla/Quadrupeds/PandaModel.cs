namespace GraphicalClient.Rendering.Entities.Vanilla;

public class PandaModel(ModelPart root) : QuadrupedModel<PandaRenderState>(root) {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 6).AddBox(-6.5F, -5.0F, -4.0F, 13.0F, 10.0F, 9.0F)
            .TexOffs(45, 16).AddBox("nose", -3.5F, 0.0F, -6.0F, 7.0F, 5.0F, 2.0F)
            .TexOffs(52, 25).AddBox("left_ear", 3.5F, -8.0F, -1.0F, 5.0F, 4.0F, 1.0F)
            .TexOffs(52, 25).AddBox("right_ear", -8.5F, -8.0F, -1.0F, 5.0F, 4.0F, 1.0F), PartPose.Offset(0.0F, 11.5F, -17.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 25).AddBox(-9.5F, -13.0F, -6.5F, 19.0F, 26.0F, 13.0F),
            PartPose.OffsetAndRotation(0.0F, 10.0F, 0.0F, MathF.PI / 2, 0.0F, 0.0F));
        CubeListBuilder leg = CubeListBuilder.Create().TexOffs(40, 0).AddBox(-3.0F, 0.0F, -3.0F, 6.0F, 9.0F, 6.0F);
        root.AddOrReplaceChild("right_hind_leg", leg, PartPose.Offset(-5.5F, 15.0F, 9.0F));
        root.AddOrReplaceChild("left_hind_leg", leg, PartPose.Offset(5.5F, 15.0F, 9.0F));
        root.AddOrReplaceChild("right_front_leg", leg, PartPose.Offset(-5.5F, 15.0F, -9.0F));
        root.AddOrReplaceChild("left_front_leg", leg, PartPose.Offset(5.5F, 15.0F, -9.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(PandaRenderState state) {
        base.SetupAnim(state);
        if (state.IsUnhappy) {
            Head.YRot = 0.35F * Mth.Sin(0.6F * state.AgeInTicks);
            Head.ZRot = 0.35F * Mth.Sin(0.6F * state.AgeInTicks);
            RightFrontLeg.XRot = -0.75F * Mth.Sin(0.3F * state.AgeInTicks);
            LeftFrontLeg.XRot = 0.75F * Mth.Sin(0.3F * state.AgeInTicks);
        }
        else {
            Head.ZRot = 0.0F;
        }
        if (state.IsSneezing) {
            if (state.SneezeTime < 15) {
                Head.XRot = -MathF.PI / 4 * state.SneezeTime / 14.0F;
            }
            else if (state.SneezeTime < 20) {
                // Integer division, as vanilla's: it is 0 until the last tick.
                float internalSneezePos = (state.SneezeTime - 15) / 5;
                Head.XRot = -MathF.PI / 4 + MathF.PI / 4 * internalSneezePos;
            }
        }
        if (state.SitAmount > 0.0F) {
            AnimateSitting(state);
            if (state.IsEating) {
                Head.XRot = MathF.PI / 2 + 0.2F * Mth.Sin(state.AgeInTicks * 0.6F);
                RightFrontLeg.XRot = -0.4F - 0.2F * Mth.Sin(state.AgeInTicks * 0.6F);
                LeftFrontLeg.XRot = -0.4F - 0.2F * Mth.Sin(state.AgeInTicks * 0.6F);
            }
            if (state.IsScared) {
                Head.XRot = 2.1707964F;
                RightFrontLeg.XRot = -0.9F;
                LeftFrontLeg.XRot = -0.9F;
            }
        }
        else {
            RightHindLeg.ZRot = 0.0F;
            LeftHindLeg.ZRot = 0.0F;
            RightFrontLeg.ZRot = 0.0F;
            LeftFrontLeg.ZRot = 0.0F;
        }
        if (state.LieOnBackAmount > 0.0F) {
            RightHindLeg.XRot = -0.6F * Mth.Sin(state.AgeInTicks * 0.15F);
            LeftHindLeg.XRot = 0.6F * Mth.Sin(state.AgeInTicks * 0.15F);
            RightFrontLeg.XRot = 0.3F * Mth.Sin(state.AgeInTicks * 0.25F);
            LeftFrontLeg.XRot = -0.3F * Mth.Sin(state.AgeInTicks * 0.25F);
            Head.XRot = Mth.RotLerpRad(state.LieOnBackAmount, Head.XRot, MathF.PI / 2);
        }
        if (state.RollAmount > 0.0F) {
            Head.XRot = Mth.RotLerpRad(state.RollAmount, Head.XRot, 2.0561945F);
            RightHindLeg.XRot = -0.5F * Mth.Sin(state.AgeInTicks * 0.5F);
            LeftHindLeg.XRot = 0.5F * Mth.Sin(state.AgeInTicks * 0.5F);
            RightFrontLeg.XRot = 0.5F * Mth.Sin(state.AgeInTicks * 0.5F);
            LeftFrontLeg.XRot = -0.5F * Mth.Sin(state.AgeInTicks * 0.5F);
        }
    }

    protected virtual void AnimateSitting(PandaRenderState state) {
        Body.XRot = Mth.RotLerpRad(state.SitAmount, Body.XRot, 1.7407963F);
        Head.XRot = Mth.RotLerpRad(state.SitAmount, Head.XRot, MathF.PI / 2);
        RightFrontLeg.ZRot = -0.27079642F;
        LeftFrontLeg.ZRot = 0.27079642F;
        RightHindLeg.ZRot = 0.5707964F;
        LeftHindLeg.ZRot = -0.5707964F;
    }
}
