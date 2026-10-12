namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ParrotModel : EntityModel<ParrotRenderState> {
    private readonly ModelPart _body, _tail, _leftWing, _rightWing, _head, _leftLeg, _rightLeg;

    public ParrotModel(ModelPart root) : base(root) {
        _body = root.GetChild("body");
        _tail = root.GetChild("tail");
        _leftWing = root.GetChild("left_wing");
        _rightWing = root.GetChild("right_wing");
        _head = root.GetChild("head");
        _leftLeg = root.GetChild("left_leg");
        _rightLeg = root.GetChild("right_leg");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(2, 8).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.OffsetAndRotation(0.0F, 16.5F, -3.0F, 0.4937F, 0.0F, 0.0F));
        root.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(22, 1).AddBox(-1.5F, -1.0F, -1.0F, 3.0F, 4.0F, 1.0F),
            PartPose.OffsetAndRotation(0.0F, 21.07F, 1.16F, 1.015F, 0.0F, 0.0F));
        root.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(19, 8).AddBox(-0.5F, 0.0F, -1.5F, 1.0F, 5.0F, 3.0F),
            PartPose.OffsetAndRotation(1.5F, 16.94F, -2.76F, -0.6981F, -MathF.PI, 0.0F));
        root.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(19, 8).AddBox(-0.5F, 0.0F, -1.5F, 1.0F, 5.0F, 3.0F),
            PartPose.OffsetAndRotation(-1.5F, 16.94F, -2.76F, -0.6981F, -MathF.PI, 0.0F));
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(2, 2).AddBox(-1.0F, -1.5F, -1.0F, 2.0F, 3.0F, 2.0F),
            PartPose.Offset(0.0F, 15.69F, -2.76F));
        head.AddOrReplaceChild("head2", CubeListBuilder.Create().TexOffs(10, 0).AddBox(-1.0F, -0.5F, -2.0F, 2.0F, 1.0F, 4.0F), PartPose.Offset(0.0F, -2.0F, -1.0F));
        head.AddOrReplaceChild("beak1", CubeListBuilder.Create().TexOffs(11, 7).AddBox(-0.5F, -1.0F, -0.5F, 1.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, -0.5F, -1.5F));
        head.AddOrReplaceChild("beak2", CubeListBuilder.Create().TexOffs(16, 7).AddBox(-0.5F, 0.0F, -0.5F, 1.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, -1.75F, -2.45F));
        head.AddOrReplaceChild("feather", CubeListBuilder.Create().TexOffs(2, 18).AddBox(0.0F, -4.0F, -2.0F, 0.0F, 5.0F, 4.0F),
            PartPose.OffsetAndRotation(0.0F, -2.15F, 0.15F, -0.2214F, 0.0F, 0.0F));
        CubeListBuilder leg = CubeListBuilder.Create().TexOffs(14, 18).AddBox(-0.5F, 0.0F, -0.5F, 1.0F, 2.0F, 1.0F);
        root.AddOrReplaceChild("left_leg", leg, PartPose.OffsetAndRotation(1.0F, 22.0F, -1.05F, -0.0299F, 0.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", leg, PartPose.OffsetAndRotation(-1.0F, 22.0F, -1.05F, -0.0299F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }

    /// <remarks>
    /// Vanilla's switch falls through: <c>STANDING</c> into the bobbing shared with <c>FLYING</c>,
    /// <c>ON_SHOULDER</c> and the default, which stops at <c>SITTING</c>; <c>PARTY</c> stands alone.
    /// </remarks>
    public override void SetupAnim(ParrotRenderState state) {
        base.SetupAnim(state);
        Prepare(state.Pose);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
        if (state.Pose == ParrotPose.Standing) {
            _leftLeg.XRot = _leftLeg.XRot + Mth.Cos(state.WalkAnimationPos * 0.6662F) * 1.4F * state.WalkAnimationSpeed;
            _rightLeg.XRot = _rightLeg.XRot + Mth.Cos(state.WalkAnimationPos * 0.6662F + MathF.PI) * 1.4F * state.WalkAnimationSpeed;
        }
        if (state.Pose is not ParrotPose.Sitting and not ParrotPose.Party) {
            float bobbingBody = state.FlapAngle * 0.3F;
            _head.Y += bobbingBody;
            _tail.XRot = _tail.XRot + Mth.Cos(state.WalkAnimationPos * 0.6662F) * 0.3F * state.WalkAnimationSpeed;
            _tail.Y += bobbingBody;
            _body.Y += bobbingBody;
            _leftWing.ZRot = -0.0873F - state.FlapAngle;
            _leftWing.Y += bobbingBody;
            _rightWing.ZRot = 0.0873F + state.FlapAngle;
            _rightWing.Y += bobbingBody;
            _leftLeg.Y += bobbingBody;
            _rightLeg.Y += bobbingBody;
        }
        if (state.Pose == ParrotPose.Party) {
            float xPos = Mth.Cos(state.AgeInTicks);
            float yPos = Mth.Sin(state.AgeInTicks);
            _head.X += xPos;
            _head.Y += yPos;
            _head.XRot = 0.0F;
            _head.YRot = 0.0F;
            _head.ZRot = Mth.Sin(state.AgeInTicks) * 0.4F;
            _body.X += xPos;
            _body.Y += yPos;
            _leftWing.ZRot = -0.0873F - state.FlapAngle;
            _leftWing.X += xPos;
            _leftWing.Y += yPos;
            _rightWing.ZRot = 0.0873F + state.FlapAngle;
            _rightWing.X += xPos;
            _rightWing.Y += yPos;
            _tail.X += xPos;
            _tail.Y += yPos;
        }
    }

    private void Prepare(ParrotPose pose) {
        switch (pose) {
            case ParrotPose.Flying:
                _leftLeg.XRot += (float)(Math.PI * 2.0 / 9.0);
                _rightLeg.XRot += (float)(Math.PI * 2.0 / 9.0);
                break;
            case ParrotPose.Sitting:
                _head.Y++;
                _tail.XRot += MathF.PI / 6;
                _tail.Y++;
                _body.Y++;
                _leftWing.ZRot = -0.0873F;
                _leftWing.Y++;
                _rightWing.ZRot = 0.0873F;
                _rightWing.Y++;
                _leftLeg.Y++;
                _rightLeg.Y++;
                _leftLeg.XRot++;
                _rightLeg.XRot++;
                break;
            case ParrotPose.Party:
                _leftLeg.ZRot = -MathF.PI / 9;
                _rightLeg.ZRot = MathF.PI / 9;
                break;
        }
    }
}

/// <summary><c>ParrotModel.Pose</c>.</summary>
public enum ParrotPose {
    Flying,
    Standing,
    Sitting,
    Party,
    OnShoulder
}
