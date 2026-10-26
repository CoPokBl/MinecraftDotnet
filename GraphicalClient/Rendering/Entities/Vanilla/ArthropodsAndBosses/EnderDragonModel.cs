namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class EnderDragonModel : EntityModel<EnderDragonRenderState> {
    private readonly ModelPart _head;
    private readonly ModelPart[] _neckParts = new ModelPart[5];
    private readonly ModelPart[] _tailParts = new ModelPart[12];
    private readonly ModelPart _jaw, _body, _leftWing, _leftWingTip, _leftFrontLeg, _leftFrontLegTip, _leftFrontFoot, _leftRearLeg, _leftRearLegTip, _leftRearFoot;
    private readonly ModelPart _rightWing, _rightWingTip, _rightFrontLeg, _rightFrontLegTip, _rightFrontFoot, _rightRearLeg, _rightRearLegTip, _rightRearFoot;

    private static string NeckName(int index) => "neck" + index;

    private static string TailName(int index) => "tail" + index;

    public EnderDragonModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        _jaw = _head.GetChild("jaw");
        for (int i = 0; i < _neckParts.Length; i++) {
            _neckParts[i] = root.GetChild(NeckName(i));
        }
        for (int i = 0; i < _tailParts.Length; i++) {
            _tailParts[i] = root.GetChild(TailName(i));
        }
        _body = root.GetChild("body");
        _leftWing = _body.GetChild("left_wing");
        _leftWingTip = _leftWing.GetChild("left_wing_tip");
        _leftFrontLeg = _body.GetChild("left_front_leg");
        _leftFrontLegTip = _leftFrontLeg.GetChild("left_front_leg_tip");
        _leftFrontFoot = _leftFrontLegTip.GetChild("left_front_foot");
        _leftRearLeg = _body.GetChild("left_hind_leg");
        _leftRearLegTip = _leftRearLeg.GetChild("left_hind_leg_tip");
        _leftRearFoot = _leftRearLegTip.GetChild("left_hind_foot");
        _rightWing = _body.GetChild("right_wing");
        _rightWingTip = _rightWing.GetChild("right_wing_tip");
        _rightFrontLeg = _body.GetChild("right_front_leg");
        _rightFrontLegTip = _rightFrontLeg.GetChild("right_front_leg_tip");
        _rightFrontFoot = _rightFrontLegTip.GetChild("right_front_foot");
        _rightRearLeg = _body.GetChild("right_hind_leg");
        _rightRearLegTip = _rightRearLeg.GetChild("right_hind_leg_tip");
        _rightRearFoot = _rightRearLegTip.GetChild("right_hind_foot");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create()
                .AddBox("upperlip", -6.0F, -1.0F, -24.0F, 12, 5, 16, 176, 44)
                .AddBox("upperhead", -8.0F, -8.0F, -10.0F, 16, 16, 16, 112, 30)
                .Mirror().AddBox("scale", -5.0F, -12.0F, -4.0F, 2, 4, 6, 0, 0)
                .AddBox("nostril", -5.0F, -3.0F, -22.0F, 2, 2, 4, 112, 0)
                .Mirror().AddBox("scale", 3.0F, -12.0F, -4.0F, 2, 4, 6, 0, 0)
                .AddBox("nostril", 3.0F, -3.0F, -22.0F, 2, 2, 4, 112, 0),
            PartPose.Offset(0.0F, 20.0F, -62.0F));
        head.AddOrReplaceChild("jaw", CubeListBuilder.Create().AddBox("jaw", -6.0F, 0.0F, -16.0F, 12, 4, 16, 176, 65), PartPose.Offset(0.0F, 4.0F, -8.0F));
        CubeListBuilder spineCubes = CubeListBuilder.Create()
            .AddBox("box", -5.0F, -5.0F, -5.0F, 10, 10, 10, 192, 104)
            .AddBox("scale", -1.0F, -9.0F, -3.0F, 2, 4, 6, 48, 0);
        for (int i = 0; i < 5; i++) {
            root.AddOrReplaceChild(NeckName(i), spineCubes, PartPose.Offset(0.0F, 20.0F, -12.0F - i * 10.0F));
        }
        for (int i = 0; i < 12; i++) {
            root.AddOrReplaceChild(TailName(i), spineCubes, PartPose.Offset(0.0F, 10.0F, 60.0F + i * 10.0F));
        }
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
                .AddBox("body", -12.0F, 1.0F, -16.0F, 24, 24, 64, 0, 0)
                .AddBox("scale", -1.0F, -5.0F, -10.0F, 2, 6, 12, 220, 53)
                .AddBox("scale", -1.0F, -5.0F, 10.0F, 2, 6, 12, 220, 53)
                .AddBox("scale", -1.0F, -5.0F, 30.0F, 2, 6, 12, 220, 53),
            PartPose.Offset(0.0F, 3.0F, 8.0F));
        PartDefinition leftWing = body.AddOrReplaceChild("left_wing", CubeListBuilder.Create()
                .Mirror().AddBox("bone", 0.0F, -4.0F, -4.0F, 56, 8, 8, 112, 88)
                .AddBox("skin", 0.0F, 0.0F, 2.0F, 56, 0, 56, -56, 88),
            PartPose.Offset(12.0F, 2.0F, -6.0F));
        leftWing.AddOrReplaceChild("left_wing_tip", CubeListBuilder.Create()
                .Mirror().AddBox("bone", 0.0F, -2.0F, -2.0F, 56, 4, 4, 112, 136)
                .AddBox("skin", 0.0F, 0.0F, 2.0F, 56, 0, 56, -56, 144),
            PartPose.Offset(56.0F, 0.0F, 0.0F));
        PartDefinition leftFrontLeg = body.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().AddBox("main", -4.0F, -4.0F, -4.0F, 8, 24, 8, 112, 104),
            PartPose.OffsetAndRotation(12.0F, 17.0F, -6.0F, 1.3F, 0.0F, 0.0F));
        PartDefinition leftFrontLegTip = leftFrontLeg.AddOrReplaceChild("left_front_leg_tip", CubeListBuilder.Create().AddBox("main", -3.0F, -1.0F, -3.0F, 6, 24, 6, 226, 138),
            PartPose.OffsetAndRotation(0.0F, 20.0F, -1.0F, -0.5F, 0.0F, 0.0F));
        leftFrontLegTip.AddOrReplaceChild("left_front_foot", CubeListBuilder.Create().AddBox("main", -4.0F, 0.0F, -12.0F, 8, 4, 16, 144, 104),
            PartPose.OffsetAndRotation(0.0F, 23.0F, 0.0F, 0.75F, 0.0F, 0.0F));
        PartDefinition leftRearLeg = body.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().AddBox("main", -8.0F, -4.0F, -8.0F, 16, 32, 16, 0, 0),
            PartPose.OffsetAndRotation(16.0F, 13.0F, 34.0F, 1.0F, 0.0F, 0.0F));
        PartDefinition leftRearLegTip = leftRearLeg.AddOrReplaceChild("left_hind_leg_tip", CubeListBuilder.Create().AddBox("main", -6.0F, -2.0F, 0.0F, 12, 32, 12, 196, 0),
            PartPose.OffsetAndRotation(0.0F, 32.0F, -4.0F, 0.5F, 0.0F, 0.0F));
        leftRearLegTip.AddOrReplaceChild("left_hind_foot", CubeListBuilder.Create().AddBox("main", -9.0F, 0.0F, -20.0F, 18, 6, 24, 112, 0),
            PartPose.OffsetAndRotation(0.0F, 31.0F, 4.0F, 0.75F, 0.0F, 0.0F));
        PartDefinition rightWing = body.AddOrReplaceChild("right_wing", CubeListBuilder.Create()
                .AddBox("bone", -56.0F, -4.0F, -4.0F, 56, 8, 8, 112, 88)
                .AddBox("skin", -56.0F, 0.0F, 2.0F, 56, 0, 56, -56, 88),
            PartPose.Offset(-12.0F, 2.0F, -6.0F));
        rightWing.AddOrReplaceChild("right_wing_tip", CubeListBuilder.Create()
                .AddBox("bone", -56.0F, -2.0F, -2.0F, 56, 4, 4, 112, 136)
                .AddBox("skin", -56.0F, 0.0F, 2.0F, 56, 0, 56, -56, 144),
            PartPose.Offset(-56.0F, 0.0F, 0.0F));
        PartDefinition rightFrontLeg = body.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().AddBox("main", -4.0F, -4.0F, -4.0F, 8, 24, 8, 112, 104),
            PartPose.OffsetAndRotation(-12.0F, 17.0F, -6.0F, 1.3F, 0.0F, 0.0F));
        PartDefinition rightFrontLegTip = rightFrontLeg.AddOrReplaceChild("right_front_leg_tip", CubeListBuilder.Create().AddBox("main", -3.0F, -1.0F, -3.0F, 6, 24, 6, 226, 138),
            PartPose.OffsetAndRotation(0.0F, 20.0F, -1.0F, -0.5F, 0.0F, 0.0F));
        rightFrontLegTip.AddOrReplaceChild("right_front_foot", CubeListBuilder.Create().AddBox("main", -4.0F, 0.0F, -12.0F, 8, 4, 16, 144, 104),
            PartPose.OffsetAndRotation(0.0F, 23.0F, 0.0F, 0.75F, 0.0F, 0.0F));
        PartDefinition rightRearLeg = body.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().AddBox("main", -8.0F, -4.0F, -8.0F, 16, 32, 16, 0, 0),
            PartPose.OffsetAndRotation(-16.0F, 13.0F, 34.0F, 1.0F, 0.0F, 0.0F));
        PartDefinition rightRearLegTip = rightRearLeg.AddOrReplaceChild("right_hind_leg_tip", CubeListBuilder.Create().AddBox("main", -6.0F, -2.0F, 0.0F, 12, 32, 12, 196, 0),
            PartPose.OffsetAndRotation(0.0F, 32.0F, -4.0F, 0.5F, 0.0F, 0.0F));
        rightRearLegTip.AddOrReplaceChild("right_hind_foot", CubeListBuilder.Create().AddBox("main", -9.0F, 0.0F, -20.0F, 18, 6, 24, 112, 0),
            PartPose.OffsetAndRotation(0.0F, 31.0F, 4.0F, 0.75F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 256, 256);
    }

    public override void SetupAnim(EnderDragonRenderState state) {
        base.SetupAnim(state);
        float flapTime = state.FlapTime * (float)(Math.PI * 2);
        _jaw.XRot = (Mth.Sin(flapTime) + 1.0F) * 0.2F;
        float bounce = Mth.Sin(flapTime - 1.0F) + 1.0F;
        bounce = (bounce * bounce + bounce * 2.0F) * 0.05F;
        Root.Y = (bounce - 2.0F) * 16.0F;
        Root.Z = -48.0F;
        Root.XRot = bounce * 2.0F * (float)(Math.PI / 180.0);
        float xx = _neckParts[0].X;
        float yy = _neckParts[0].Y;
        float zz = _neckParts[0].Z;
        DragonFlightHistory.Sample start = state.GetHistoricalPos(6);
        float rot2 = Mth.WrapDegrees(state.GetHistoricalPos(5).YRot - state.GetHistoricalPos(10).YRot);
        float rot = Mth.WrapDegrees(state.GetHistoricalPos(5).YRot + rot2 / 2.0F);
        for (int i = 0; i < 5; i++) {
            ModelPart neck = _neckParts[i];
            DragonFlightHistory.Sample point = state.GetHistoricalPos(5 - i);
            float neckXRot = Mth.Cos(i * 0.45F + flapTime) * 0.15F;
            neck.YRot = Mth.WrapDegrees(point.YRot - start.YRot) * (float)(Math.PI / 180.0) * 1.5F;
            neck.XRot = neckXRot + state.GetHeadPartYOffset(i, start, point) * (float)(Math.PI / 180.0) * 1.5F * 5.0F;
            neck.ZRot = -Mth.WrapDegrees(point.YRot - rot) * (float)(Math.PI / 180.0) * 1.5F;
            neck.Y = yy;
            neck.Z = zz;
            neck.X = xx;
            xx -= Mth.Sin(neck.YRot) * Mth.Cos(neck.XRot) * 10.0F;
            yy += Mth.Sin(neck.XRot) * 10.0F;
            zz -= Mth.Cos(neck.YRot) * Mth.Cos(neck.XRot) * 10.0F;
        }
        _head.Y = yy;
        _head.Z = zz;
        _head.X = xx;
        DragonFlightHistory.Sample current = state.GetHistoricalPos(0);
        _head.YRot = Mth.WrapDegrees(current.YRot - start.YRot) * (float)(Math.PI / 180.0);
        _head.XRot = Mth.WrapDegrees(state.GetHeadPartYOffset(6, start, current)) * (float)(Math.PI / 180.0) * 1.5F * 5.0F;
        _head.ZRot = -Mth.WrapDegrees(current.YRot - rot) * (float)(Math.PI / 180.0);
        _body.ZRot = -rot2 * 1.5F * (float)(Math.PI / 180.0);
        _leftWing.XRot = 0.125F - Mth.Cos(flapTime) * 0.2F;
        _leftWing.YRot = -0.25F;
        _leftWing.ZRot = -(Mth.Sin(flapTime) + 0.125F) * 0.8F;
        _leftWingTip.ZRot = (Mth.Sin(flapTime + 2.0F) + 0.5F) * 0.75F;
        _rightWing.XRot = _leftWing.XRot;
        _rightWing.YRot = -_leftWing.YRot;
        _rightWing.ZRot = -_leftWing.ZRot;
        _rightWingTip.ZRot = -_leftWingTip.ZRot;
        PoseLimbs(bounce, _leftFrontLeg, _leftFrontLegTip, _leftFrontFoot, _leftRearLeg, _leftRearLegTip, _leftRearFoot);
        PoseLimbs(bounce, _rightFrontLeg, _rightFrontLegTip, _rightFrontFoot, _rightRearLeg, _rightRearLegTip, _rightRearFoot);
        float tailXRot = 0.0F;
        yy = _tailParts[0].Y;
        zz = _tailParts[0].Z;
        xx = _tailParts[0].X;
        start = state.GetHistoricalPos(11);
        for (int i = 0; i < 12; i++) {
            DragonFlightHistory.Sample point = state.GetHistoricalPos(12 + i);
            tailXRot += Mth.Sin(i * 0.45F + flapTime) * 0.05F;
            ModelPart tail = _tailParts[i];
            tail.YRot = (Mth.WrapDegrees(point.YRot - start.YRot) * 1.5F + 180.0F) * (float)(Math.PI / 180.0);
            tail.XRot = tailXRot + (float)(point.Y - start.Y) * (float)(Math.PI / 180.0) * 1.5F * 5.0F;
            tail.ZRot = Mth.WrapDegrees(point.YRot - rot) * (float)(Math.PI / 180.0) * 1.5F;
            tail.Y = yy;
            tail.Z = zz;
            tail.X = xx;
            yy += Mth.Sin(tail.XRot) * 10.0F;
            zz -= Mth.Cos(tail.YRot) * Mth.Cos(tail.XRot) * 10.0F;
            xx -= Mth.Sin(tail.YRot) * Mth.Cos(tail.XRot) * 10.0F;
        }
    }

    private static void PoseLimbs(float bounce, ModelPart frontLeg, ModelPart frontLegTip, ModelPart frontFoot, ModelPart rearLeg, ModelPart rearLegTip,
        ModelPart rearFoot) {
        rearLeg.XRot = 1.0F + bounce * 0.1F;
        rearLegTip.XRot = 0.5F + bounce * 0.1F;
        rearFoot.XRot = 0.75F + bounce * 0.1F;
        frontLeg.XRot = 1.3F + bounce * 0.1F;
        frontLegTip.XRot = -0.5F - bounce * 0.1F;
        frontFoot.XRot = 0.75F + bounce * 0.1F;
    }
}
