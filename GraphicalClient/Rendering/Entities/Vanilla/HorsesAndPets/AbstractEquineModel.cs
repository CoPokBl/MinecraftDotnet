namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class AbstractEquineModel<T> : EntityModel<T> where T : EquineRenderState {
    protected readonly ModelPart Body;
    protected readonly ModelPart HeadParts;
    protected readonly ModelPart RightHindLeg;
    protected readonly ModelPart LeftHindLeg;
    protected readonly ModelPart RightFrontLeg;
    protected readonly ModelPart LeftFrontLeg;
    private readonly ModelPart _tail;

    protected AbstractEquineModel(ModelPart root) : this(root, root.GetChild("head_parts"), root.GetChild("right_hind_leg"), root.GetChild("right_front_leg"),
        root.GetChild("left_hind_leg"), root.GetChild("left_front_leg"), root.GetChild("body").GetChild("tail")) { }

    protected AbstractEquineModel(ModelPart root, ModelPart headParts, ModelPart rightHindLeg, ModelPart rightFrontLeg, ModelPart leftHindLeg,
        ModelPart leftFrontLeg, ModelPart tail) : base(root) {
        Body = root.GetChild("body");
        HeadParts = headParts;
        RightHindLeg = rightHindLeg;
        LeftHindLeg = leftHindLeg;
        RightFrontLeg = rightFrontLeg;
        LeftFrontLeg = leftFrontLeg;
        _tail = tail;
    }

    public static LayerDefinition CreateBodyLayer(CubeDeformation g) => LayerDefinition.Create(CreateBodyMesh(g), 64, 64);

    public static MeshDefinition CreateBodyMesh(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-5.0F, -8.0F, -17.0F, 10.0F, 10.0F, 22.0F, new CubeDeformation(0.05F)),
            PartPose.Offset(0.0F, 11.0F, 5.0F));
        PartDefinition headParts = root.AddOrReplaceChild("head_parts", CubeListBuilder.Create().TexOffs(0, 35).AddBox(-2.05F, -6.0F, -2.0F, 4.0F, 12.0F, 7.0F),
            PartPose.OffsetAndRotation(0.0F, 4.0F, -12.0F, (float)(Math.PI / 6), 0.0F, 0.0F));
        PartDefinition head = headParts.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 13).AddBox(-3.0F, -11.0F, -2.0F, 6.0F, 5.0F, 7.0F, g),
            PartPose.Zero);
        headParts.AddOrReplaceChild("mane", CubeListBuilder.Create().TexOffs(56, 36).AddBox(-1.0F, -11.0F, 5.01F, 2.0F, 16.0F, 2.0F, g), PartPose.Zero);
        headParts.AddOrReplaceChild("upper_mouth", CubeListBuilder.Create().TexOffs(0, 25).AddBox(-2.0F, -11.0F, -7.0F, 4.0F, 5.0F, 5.0F, g), PartPose.Zero);
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(48, 21).Mirror().AddBox(-3.0F, -1.01F, -1.0F, 4.0F, 11.0F, 4.0F, g),
            PartPose.Offset(4.0F, 14.0F, 7.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(48, 21).AddBox(-1.0F, -1.01F, -1.0F, 4.0F, 11.0F, 4.0F, g),
            PartPose.Offset(-4.0F, 14.0F, 7.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(48, 21).Mirror().AddBox(-3.0F, -1.01F, -1.9F, 4.0F, 11.0F, 4.0F, g),
            PartPose.Offset(4.0F, 14.0F, -10.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(48, 21).AddBox(-1.0F, -1.01F, -1.9F, 4.0F, 11.0F, 4.0F, g),
            PartPose.Offset(-4.0F, 14.0F, -10.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(42, 36).AddBox(-1.5F, 0.0F, 0.0F, 3.0F, 14.0F, 4.0F, g),
            PartPose.OffsetAndRotation(0.0F, -5.0F, 2.0F, (float)(Math.PI / 6), 0.0F, 0.0F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(19, 16).AddBox(0.55F, -13.0F, 4.0F, 2.0F, 3.0F, 1.0F, new CubeDeformation(-0.001F)),
            PartPose.Zero);
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(19, 16).AddBox(-2.55F, -13.0F, 4.0F, 2.0F, 3.0F, 1.0F, new CubeDeformation(-0.001F)),
            PartPose.Zero);
        return mesh;
    }

    public override void SetupAnim(T state) {
        base.SetupAnim(state);
        float clampedYRot = Mth.Clamp(state.YRot, -20.0F, 20.0F);
        float headRotXRad = state.XRot * (float)(Math.PI / 180.0);
        float animationSpeed = state.WalkAnimationSpeed;
        float animationPos = state.WalkAnimationPos;
        if (animationSpeed > 0.2F) {
            headRotXRad += Mth.Cos(animationPos * 0.8F) * 0.15F * animationSpeed;
        }
        float eating = state.EatAnimation;
        float standing = state.StandAnimation;
        float iStanding = 1.0F - standing;
        float feedingAnim = state.FeedingAnimation;
        bool animateTail = state.AnimateTail;
        HeadParts.XRot = (float)(Math.PI / 6) + headRotXRad;
        HeadParts.YRot = clampedYRot * (float)(Math.PI / 180.0);
        float waterMultiplier = state.IsInWater ? 0.2F : 1.0F;
        float legAnim1 = Mth.Cos(waterMultiplier * animationPos * 0.6662F + MathF.PI);
        float legXRotAnim = legAnim1 * 0.8F * animationSpeed;
        float baseHeadAngle = (1.0F - Math.Max(standing, eating)) * ((float)(Math.PI / 6) + headRotXRad + feedingAnim * Mth.Sin(state.AgeInTicks) * 0.05F);
        HeadParts.XRot = standing * ((float)(Math.PI / 12) + headRotXRad) + eating * (2.1816616F + Mth.Sin(state.AgeInTicks) * 0.05F) + baseHeadAngle;
        HeadParts.YRot = standing * clampedYRot * (float)(Math.PI / 180.0) + (1.0F - Math.Max(standing, eating)) * HeadParts.YRot;
        AnimateHeadPartsPlacement(eating, standing);
        Body.XRot = standing * ((float)(-Math.PI / 4)) + iStanding * Body.XRot;
        LeftFrontLeg.Y = LeftFrontLeg.Y - GetLegStandingYOffset() * standing;
        LeftFrontLeg.Z = LeftFrontLeg.Z + GetLegStandingZOffset() * standing;
        RightFrontLeg.Y = LeftFrontLeg.Y;
        RightFrontLeg.Z = LeftFrontLeg.Z;
        float standAngle = GetLegStandAngle() * standing;
        float bobValue = Mth.Cos(state.AgeInTicks * 0.6F + MathF.PI);
        float legStandingXRotOffset = GetLegStandingXRotOffset();
        float rlegRot = (legStandingXRotOffset + bobValue) * standing + legXRotAnim * iStanding;
        float llegRot = (legStandingXRotOffset - bobValue) * standing - legXRotAnim * iStanding;
        LeftHindLeg.XRot = standAngle - legAnim1 * 0.5F * animationSpeed * iStanding;
        RightHindLeg.XRot = standAngle + legAnim1 * 0.5F * animationSpeed * iStanding;
        LeftFrontLeg.XRot = rlegRot;
        RightFrontLeg.XRot = llegRot;
        OffsetLegPositionWhenStanding(standing);
        float ageScale = state.AgeScale;
        _tail.XRot = GetTailXRotOffset() + (float)(Math.PI / 6) + animationSpeed * 0.75F;
        _tail.Y += animationSpeed * ageScale;
        _tail.Z += animationSpeed * 2.0F * ageScale;
        _tail.YRot = animateTail ? Mth.Cos(state.AgeInTicks * 0.7F) : 0.0F;
    }

    protected virtual void OffsetLegPositionWhenStanding(float standing) { }

    protected virtual float GetLegStandAngle() => (float)(Math.PI / 12);

    protected virtual float GetLegStandingYOffset() => 12.0F;

    protected virtual float GetLegStandingZOffset() => 4.0F;

    protected virtual float GetLegStandingXRotOffset() => (float)(-Math.PI / 3);

    protected virtual float GetTailXRotOffset() => 0.0F;

    protected virtual void AnimateHeadPartsPlacement(float eating, float standing) {
        HeadParts.Y = HeadParts.Y + Mth.Lerp(eating, Mth.Lerp(standing, 0.0F, -8.0F), 7.0F);
        HeadParts.Z = Mth.Lerp(standing, HeadParts.Z, -4.0F);
    }
}
