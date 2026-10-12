namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BabyDonkeyModel</c>: the legs, neck and tail hang off the body rather than the root.</summary>
public class BabyDonkeyModel : DonkeyModel {
    public BabyDonkeyModel(ModelPart root) : base(root,
        root.GetChild("body").GetChild("head_parts"),
        root.GetChild("body").GetChild("right_hind_leg"),
        root.GetChild("body").GetChild("right_front_leg"),
        root.GetChild("body").GetChild("left_hind_leg"),
        root.GetChild("body").GetChild("left_front_leg"),
        root.GetChild("body").GetChild("tail")) { }

    public static LayerDefinition CreateBabyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 13).AddBox(-5.0F, -3.0F, -7.0F, 8.0F, 6.0F, 14.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(1.0F, 14.0F, 0.0F));
        PartDefinition tail = body.AddOrReplaceChild("tail", CubeListBuilder.Create(), PartPose.Offset(0.0F, -1.5F, 6.5F));
        tail.AddOrReplaceChild("tail_r1", CubeListBuilder.Create().TexOffs(24, 33).AddBox(-2.5F, -1.0F, -0.5F, 3.0F, 3.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, -0.7418F, 0.0F, 0.0F));
        body.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(12, 44).AddBox(-2.5F, -1.5F, -1.5F, 3.0F, 8.0F, 3.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.25F, 3.5F, 5.25F));
        body.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 44).AddBox(-2.5F, -1.5F, -1.5F, 3.0F, 8.0F, 3.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-2.4F, 3.5F, 5.4F));
        body.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(12, 33).AddBox(-2.5F, -1.5F, -1.5F, 3.0F, 8.0F, 3.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.4F, 3.5F, -5.3F));
        body.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 33).AddBox(-2.5F, -1.5F, -1.5F, 3.0F, 8.0F, 3.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-2.4F, 3.5F, -5.4F));
        PartDefinition neck = body.AddOrReplaceChild("head_parts", CubeListBuilder.Create(), PartPose.Offset(0.0F, -3.0F, -5.0F));
        neck.AddOrReplaceChild("neck_r1", CubeListBuilder.Create().TexOffs(30, 9).AddBox(-3.0F, -6.0F, -3.0F, 4.0F, 8.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, 0.3927F, 0.0F, 0.0F));
        PartDefinition head = neck.AddOrReplaceChild("head", CubeListBuilder.Create(), PartPose.Offset(0.0F, -5.0F, -3.0F));
        head.AddOrReplaceChild("head_r1", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -3.6F, -8.4F, 6.0F, 4.0F, 9.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, -1.0F, 1.0F, 0.3927F, 0.0F, 0.0F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.0F, -6.5F, -0.3F, 2.0F, 7.0F, 1.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(2.0F, -3.5F, -1.0F, 0.48F, 0.0F, 0.48F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(22, 0).Mirror().AddBox(-2.0F, -6.5F, -0.3F, 2.0F, 7.0F, 1.0F, new CubeDeformation(0.0F)).Mirror(false),
            PartPose.OffsetAndRotation(-2.0F, -3.5F, -1.0F, 0.48F, 0.0F, -0.48F));
        body.AddOrReplaceChild("right_chest", CubeListBuilder.Create(), PartPose.Offset(-1.0F, 10.0F, 0.0F));
        body.AddOrReplaceChild("left_chest", CubeListBuilder.Create(), PartPose.Offset(-1.0F, 10.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(DonkeyRenderState state) {
        base.SetupAnim(state);
        // Written back to the shared state, as vanilla writes it; any layer posed after this sees it.
        state.XRot = -30.0F;
        float headRotXRad = state.XRot * (float)(Math.PI / 180.0);
        float eating = state.EatAnimation;
        float standing = state.StandAnimation;
        float feedingAnim = state.FeedingAnimation;
        float baseHeadAngle = (1.0F - Math.Max(standing, eating)) * ((float)(Math.PI / 6) + headRotXRad + feedingAnim * Mth.Sin(state.AgeInTicks) * 0.05F);
        HeadParts.XRot = standing * ((float)(Math.PI / 12) + headRotXRad)
            + eating * ((float)(Math.PI / 2) + Mth.Sin(state.AgeInTicks) * 0.05F)
            + baseHeadAngle;
    }

    protected override void OffsetLegPositionWhenStanding(float standing) {
        LeftHindLeg.Y = Mth.Lerp(standing, LeftHindLeg.Y, -0.3F);
        // Reads the left leg on purpose: vanilla's does.
        RightHindLeg.Y = Mth.Lerp(standing, LeftHindLeg.Y, -0.3F);
    }

    protected override float GetLegStandAngle() => (float)(Math.PI / 3);

    protected override float GetLegStandingYOffset() => 1.0F;

    protected override float GetLegStandingZOffset() => 0.5F;

    protected override float GetLegStandingXRotOffset() => 0.0F;

    protected override float GetTailXRotOffset() => (float)(-Math.PI / 4);

    protected override void AnimateHeadPartsPlacement(float eating, float standing) {
        HeadParts.Y = Mth.Lerp(eating, HeadParts.Y, -1.2F);
        HeadParts.Z = Mth.Lerp(standing, HeadParts.Z, -3.6F);
    }
}
