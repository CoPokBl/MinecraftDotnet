namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class AdultAxolotlModel : EntityModel<AxolotlRenderState> {
    private const float SwimmingLegXRot = 1.8849558F;
    private readonly ModelPart _tail, _leftHindLeg, _rightHindLeg, _leftFrontLeg, _rightFrontLeg, _body, _head, _topGills, _leftGills, _rightGills;

    public AdultAxolotlModel(ModelPart root) : base(root) {
        _body = root.GetChild("body");
        _head = _body.GetChild("head");
        _rightHindLeg = _body.GetChild("right_hind_leg");
        _leftHindLeg = _body.GetChild("left_hind_leg");
        _rightFrontLeg = _body.GetChild("right_front_leg");
        _leftFrontLeg = _body.GetChild("left_front_leg");
        _tail = _body.GetChild("tail");
        _topGills = _head.GetChild("top_gills");
        _leftGills = _head.GetChild("left_gills");
        _rightGills = _head.GetChild("right_gills");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .TexOffs(0, 11).AddBox(-4.0F, -2.0F, -9.0F, 8.0F, 4.0F, 10.0F)
                .TexOffs(2, 17).AddBox(0.0F, -3.0F, -8.0F, 0.0F, 5.0F, 9.0F),
            PartPose.Offset(0.0F, 19.5F, 5.0F));
        CubeDeformation fudge = new(0.001F);
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 1).AddBox(-4.0F, -3.0F, -5.0F, 8.0F, 5.0F, 5.0F, fudge),
            PartPose.Offset(0.0F, 0.0F, -9.0F));
        CubeListBuilder topGills = CubeListBuilder.Create().TexOffs(3, 37).AddBox(-4.0F, -3.0F, 0.0F, 8.0F, 3.0F, 0.0F, fudge);
        CubeListBuilder leftGills = CubeListBuilder.Create().TexOffs(0, 40).AddBox(-3.0F, -5.0F, 0.0F, 3.0F, 7.0F, 0.0F, fudge);
        CubeListBuilder rightGills = CubeListBuilder.Create().TexOffs(11, 40).AddBox(0.0F, -5.0F, 0.0F, 3.0F, 7.0F, 0.0F, fudge);
        head.AddOrReplaceChild("top_gills", topGills, PartPose.Offset(0.0F, -3.0F, -1.0F));
        head.AddOrReplaceChild("left_gills", leftGills, PartPose.Offset(-4.0F, 0.0F, -1.0F));
        head.AddOrReplaceChild("right_gills", rightGills, PartPose.Offset(4.0F, 0.0F, -1.0F));
        CubeListBuilder leftLeg = CubeListBuilder.Create().TexOffs(2, 13).AddBox(-1.0F, 0.0F, 0.0F, 3.0F, 5.0F, 0.0F, fudge);
        CubeListBuilder rightLeg = CubeListBuilder.Create().TexOffs(2, 13).AddBox(-2.0F, 0.0F, 0.0F, 3.0F, 5.0F, 0.0F, fudge);
        body.AddOrReplaceChild("right_hind_leg", rightLeg, PartPose.Offset(-3.5F, 1.0F, -1.0F));
        body.AddOrReplaceChild("left_hind_leg", leftLeg, PartPose.Offset(3.5F, 1.0F, -1.0F));
        body.AddOrReplaceChild("right_front_leg", rightLeg, PartPose.Offset(-3.5F, 1.0F, -8.0F));
        body.AddOrReplaceChild("left_front_leg", leftLeg, PartPose.Offset(3.5F, 1.0F, -8.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(2, 19).AddBox(0.0F, -3.0F, 0.0F, 0.0F, 5.0F, 12.0F), PartPose.Offset(0.0F, 0.0F, 1.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(AxolotlRenderState state) {
        base.SetupAnim(state);
        float playingDeadFactor = state.PlayingDeadFactor;
        float inWaterFactor = state.InWaterFactor;
        float onGroundFactor = state.OnGroundFactor;
        float movingFactor = state.MovingFactor;
        float notMovingFactor = 1.0F - movingFactor;
        float mirroredLegsFactor = 1.0F - Math.Min(onGroundFactor, movingFactor);
        _body.YRot = _body.YRot + state.YRot * (MathF.PI / 180.0F);
        SetupSwimmingAnimation(state.AgeInTicks, state.XRot, Math.Min(movingFactor, inWaterFactor));
        SetupWaterHoveringAnimation(state.AgeInTicks, Math.Min(notMovingFactor, inWaterFactor));
        SetupGroundCrawlingAnimation(state.AgeInTicks, Math.Min(movingFactor, onGroundFactor));
        SetupLayStillOnGroundAnimation(state.AgeInTicks, Math.Min(notMovingFactor, onGroundFactor));
        SetupPlayDeadAnimation(playingDeadFactor);
        ApplyMirrorLegRotations(mirroredLegsFactor);
    }

    private void SetupLayStillOnGroundAnimation(float ageInTicks, float factor) {
        if (!(factor <= 1.0E-5F)) {
            float animMoveSpeed = ageInTicks * 0.09F;
            float sineSway = Mth.Sin(animMoveSpeed);
            float cosineSway = Mth.Cos(animMoveSpeed);
            float movement = sineSway * sineSway - 2.0F * sineSway;
            float movement2 = cosineSway * cosineSway - 3.0F * sineSway;
            _head.XRot += -0.09F * movement * factor;
            _head.ZRot += -0.2F * factor;
            _tail.YRot += (-0.1F + 0.1F * movement) * factor;
            float gillAngle = (0.6F + 0.05F * movement2) * factor;
            _topGills.XRot += gillAngle;
            _leftGills.YRot -= gillAngle;
            _rightGills.YRot += gillAngle;
            _leftHindLeg.XRot += 1.1F * factor;
            _leftHindLeg.YRot += 1.0F * factor;
            _leftFrontLeg.XRot += 0.8F * factor;
            _leftFrontLeg.YRot += 2.3F * factor;
            _leftFrontLeg.ZRot -= 0.5F * factor;
        }
    }

    private void SetupGroundCrawlingAnimation(float ageInTicks, float factor) {
        if (!(factor <= 1.0E-5F)) {
            float animMoveSpeed = ageInTicks * 0.11F;
            float cosineSway = Mth.Cos(animMoveSpeed);
            float hindLegYRotSway = (cosineSway * cosineSway - 2.0F * cosineSway) / 5.0F;
            float frontLegYRotSway = 0.7F * cosineSway;
            float headAndTailYRot = 0.09F * cosineSway * factor;
            _head.YRot += headAndTailYRot;
            _tail.YRot += headAndTailYRot;
            float gillAngle = (0.6F - 0.08F * (cosineSway * cosineSway + 2.0F * Mth.Sin(animMoveSpeed))) * factor;
            _topGills.XRot += gillAngle;
            _leftGills.YRot -= gillAngle;
            _rightGills.YRot += gillAngle;
            float hindLegXRot = 0.9424779F * factor;
            float frontLegXRot = 1.0995574F * factor;
            _leftHindLeg.XRot += hindLegXRot;
            _leftHindLeg.YRot += (1.5F - hindLegYRotSway) * factor;
            _leftHindLeg.ZRot += -0.1F * factor;
            _leftFrontLeg.XRot += frontLegXRot;
            _leftFrontLeg.YRot += (MathF.PI / 2 - frontLegYRotSway) * factor;
            _rightHindLeg.XRot += hindLegXRot;
            _rightHindLeg.YRot += (-1.0F - hindLegYRotSway) * factor;
            _rightFrontLeg.XRot += frontLegXRot;
            _rightFrontLeg.YRot += (-MathF.PI / 2 - frontLegYRotSway) * factor;
        }
    }

    private void SetupWaterHoveringAnimation(float ageInTicks, float factor) {
        if (!(factor <= 1.0E-5F)) {
            float animMoveSpeed = ageInTicks * 0.075F;
            float cosineSway = Mth.Cos(animMoveSpeed);
            float sineSway = Mth.Sin(animMoveSpeed) * 0.15F;
            float bodyXRot = (-0.15F + 0.075F * cosineSway) * factor;
            _body.XRot += bodyXRot;
            _body.Y -= sineSway * factor;
            _head.XRot -= bodyXRot;
            _topGills.XRot += 0.2F * cosineSway * factor;
            float gillYRot = (-0.3F * cosineSway - 0.19F) * factor;
            _leftGills.YRot += gillYRot;
            _rightGills.YRot -= gillYRot;
            _leftHindLeg.XRot += ((float)(Math.PI * 3.0 / 4.0) - cosineSway * 0.11F) * factor;
            _leftHindLeg.YRot += 0.47123894F * factor;
            _leftHindLeg.ZRot += 1.7278761F * factor;
            _leftFrontLeg.XRot += (MathF.PI / 4 - cosineSway * 0.2F) * factor;
            _leftFrontLeg.YRot += 2.042035F * factor;
            _tail.YRot += 0.5F * cosineSway * factor;
        }
    }

    private void SetupSwimmingAnimation(float ageInTicks, float xRot, float factor) {
        if (!(factor <= 1.0E-5F)) {
            float animMoveSpeed = ageInTicks * 0.33F;
            float sineSway = Mth.Sin(animMoveSpeed);
            float cosineSway = Mth.Cos(animMoveSpeed);
            float bodySway = 0.13F * sineSway;
            _body.XRot += (xRot * (MathF.PI / 180.0F) + bodySway) * factor;
            _head.XRot -= bodySway * 1.8F * factor;
            _body.Y -= 0.45F * cosineSway * factor;
            _topGills.XRot += (-0.5F * sineSway - 0.8F) * factor;
            float gillYRot = (0.3F * sineSway + 0.9F) * factor;
            _leftGills.YRot += gillYRot;
            _rightGills.YRot -= gillYRot;
            _tail.YRot = _tail.YRot + 0.3F * Mth.Cos(animMoveSpeed * 0.9F) * factor;
            _leftHindLeg.XRot += SwimmingLegXRot * factor;
            _leftHindLeg.YRot += -0.4F * sineSway * factor;
            _leftHindLeg.ZRot += MathF.PI / 2 * factor;
            _leftFrontLeg.XRot += SwimmingLegXRot * factor;
            _leftFrontLeg.YRot += (-0.2F * cosineSway - 0.1F) * factor;
            _leftFrontLeg.ZRot += MathF.PI / 2 * factor;
        }
    }

    private void SetupPlayDeadAnimation(float factor) {
        if (!(factor <= 1.0E-5F)) {
            _leftHindLeg.XRot += 1.4137167F * factor;
            _leftHindLeg.YRot += 1.0995574F * factor;
            _leftHindLeg.ZRot += MathF.PI / 4 * factor;
            _leftFrontLeg.XRot += MathF.PI / 4 * factor;
            _leftFrontLeg.YRot += 2.042035F * factor;
            _body.XRot += -0.15F * factor;
            _body.ZRot += 0.35F * factor;
        }
    }

    private void ApplyMirrorLegRotations(float factor) {
        if (!(factor <= 1.0E-5F)) {
            _rightHindLeg.XRot = _rightHindLeg.XRot + _leftHindLeg.XRot * factor;
            _rightHindLeg.YRot = _rightHindLeg.YRot + -_leftHindLeg.YRot * factor;
            _rightHindLeg.ZRot = _rightHindLeg.ZRot + -_leftHindLeg.ZRot * factor;
            _rightFrontLeg.XRot = _rightFrontLeg.XRot + _leftFrontLeg.XRot * factor;
            _rightFrontLeg.YRot = _rightFrontLeg.YRot + -_leftFrontLeg.YRot * factor;
            _rightFrontLeg.ZRot = _rightFrontLeg.ZRot + -_leftFrontLeg.ZRot * factor;
        }
    }
}
