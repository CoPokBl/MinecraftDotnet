using ClientLib.Maths;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class GuardianModel : EntityModel<GuardianRenderState> {
    public static readonly MeshTransformer ElderGuardianScale = MeshTransformers.Scaling(2.35F);
    private static readonly float[] SpikeXRot = [1.75F, 0.25F, 0.0F, 0.0F, 0.5F, 0.5F, 0.5F, 0.5F, 1.25F, 0.75F, 0.0F, 0.0F];
    private static readonly float[] SpikeYRot = [0.0F, 0.0F, 0.0F, 0.0F, 0.25F, 1.75F, 1.25F, 0.75F, 0.0F, 0.0F, 0.0F, 0.0F];
    private static readonly float[] SpikeZRot = [0.0F, 0.0F, 0.25F, 1.75F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.75F, 1.25F];
    private static readonly float[] SpikeX = [0.0F, 0.0F, 8.0F, -8.0F, -8.0F, 8.0F, 8.0F, -8.0F, 0.0F, 0.0F, 8.0F, -8.0F];
    private static readonly float[] SpikeY = [-8.0F, -8.0F, -8.0F, -8.0F, 0.0F, 0.0F, 0.0F, 0.0F, 8.0F, 8.0F, 8.0F, 8.0F];
    private static readonly float[] SpikeZ = [8.0F, -8.0F, 0.0F, 0.0F, -8.0F, -8.0F, 8.0F, 8.0F, 8.0F, -8.0F, 0.0F, 0.0F];
    private readonly ModelPart _head, _eye;
    private readonly ModelPart[] _spikeParts = new ModelPart[12];
    private readonly ModelPart[] _tailParts;

    public GuardianModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
        for (int i = 0; i < _spikeParts.Length; i++) {
            _spikeParts[i] = _head.GetChild(CreateSpikeName(i));
        }
        _eye = _head.GetChild("eye");
        _tailParts = new ModelPart[3];
        _tailParts[0] = _head.GetChild("tail0");
        _tailParts[1] = _tailParts[0].GetChild("tail1");
        _tailParts[2] = _tailParts[1].GetChild("tail2");
    }

    private static string CreateSpikeName(int i) => "spike" + i;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create()
                .TexOffs(0, 0).AddBox(-6.0F, 10.0F, -8.0F, 12.0F, 12.0F, 16.0F)
                .TexOffs(0, 28).AddBox(-8.0F, 10.0F, -6.0F, 2.0F, 12.0F, 12.0F)
                .TexOffs(0, 28).AddBox(6.0F, 10.0F, -6.0F, 2.0F, 12.0F, 12.0F, true)
                .TexOffs(16, 40).AddBox(-6.0F, 8.0F, -6.0F, 12.0F, 2.0F, 12.0F)
                .TexOffs(16, 40).AddBox(-6.0F, 22.0F, -6.0F, 12.0F, 2.0F, 12.0F),
            PartPose.Zero);
        CubeListBuilder spike = CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, -4.5F, -1.0F, 2.0F, 9.0F, 2.0F);
        for (int i = 0; i < 12; i++) {
            float x = GetSpikeX(i, 0.0F, 0.0F);
            float y = GetSpikeY(i, 0.0F, 0.0F);
            float z = GetSpikeZ(i, 0.0F, 0.0F);
            float xRot = (float)Math.PI * SpikeXRot[i];
            float yRot = (float)Math.PI * SpikeYRot[i];
            float zRot = (float)Math.PI * SpikeZRot[i];
            head.AddOrReplaceChild(CreateSpikeName(i), spike, PartPose.OffsetAndRotation(x, y, z, xRot, yRot, zRot));
        }
        head.AddOrReplaceChild("eye", CubeListBuilder.Create().TexOffs(8, 0).AddBox(-1.0F, 15.0F, 0.0F, 2.0F, 2.0F, 1.0F), PartPose.Offset(0.0F, 0.0F, -8.25F));
        PartDefinition tailPart0 = head.AddOrReplaceChild("tail0", CubeListBuilder.Create().TexOffs(40, 0).AddBox(-2.0F, 14.0F, 7.0F, 4.0F, 4.0F, 8.0F), PartPose.Zero);
        PartDefinition tailPart1 = tailPart0.AddOrReplaceChild("tail1", CubeListBuilder.Create().TexOffs(0, 54).AddBox(0.0F, 14.0F, 0.0F, 3.0F, 3.0F, 7.0F),
            PartPose.Offset(-1.5F, 0.5F, 14.0F));
        tailPart1.AddOrReplaceChild("tail2", CubeListBuilder.Create()
                .TexOffs(41, 32).AddBox(0.0F, 14.0F, 0.0F, 2.0F, 2.0F, 6.0F)
                .TexOffs(25, 19).AddBox(1.0F, 10.5F, 3.0F, 1.0F, 9.0F, 9.0F),
            PartPose.Offset(0.5F, 0.5F, 6.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public static LayerDefinition CreateElderGuardianLayer() => CreateBodyLayer().Apply(ElderGuardianScale);

    public override void SetupAnim(GuardianRenderState state) {
        base.SetupAnim(state);
        _head.YRot = state.YRot * (float)(Math.PI / 180.0);
        _head.XRot = state.XRot * (float)(Math.PI / 180.0);
        float withdrawal = (1.0F - state.SpikesAnimation) * 0.55F;
        SetupSpikes(state.AgeInTicks, withdrawal);
        if (state.LookAtPosition is { } lookAtPosition && state.LookDirection is { } lookDirection) {
            double dy = lookAtPosition.Y - state.EyePosition.Y;
            _eye.Y = dy > 0.0 ? 0.0F : 1.0F;
            Vec3d viewVector = new(lookDirection.X, 0.0, lookDirection.Z);
            Vec3d delta = YRot(new Vec3d(state.EyePosition.X - lookAtPosition.X, 0.0, state.EyePosition.Z - lookAtPosition.Z).Normalize(), (float)(Math.PI / 2));
            double dot = viewVector.X * delta.X + viewVector.Y * delta.Y + viewVector.Z * delta.Z;
            _eye.X = Mth.Sqrt((float)Math.Abs(dot)) * 2.0F * Math.Sign(dot);
        }
        _eye.Visible = true;
        float swim = state.TailAnimation;
        _tailParts[0].YRot = Mth.Sin(swim) * (float)Math.PI * 0.05F;
        _tailParts[1].YRot = Mth.Sin(swim) * (float)Math.PI * 0.1F;
        _tailParts[2].YRot = Mth.Sin(swim) * (float)Math.PI * 0.15F;
    }

    /// <summary><c>Vec3.yRot</c>.</summary>
    private static Vec3d YRot(Vec3d v, float radians) {
        float cos = Mth.Cos(radians);
        float sin = Mth.Sin(radians);
        return new Vec3d(v.X * cos + v.Z * sin, v.Y, v.Z * cos - v.X * sin);
    }

    private void SetupSpikes(float ageInTicks, float withdrawal) {
        for (int i = 0; i < 12; i++) {
            _spikeParts[i].X = GetSpikeX(i, ageInTicks, withdrawal);
            _spikeParts[i].Y = GetSpikeY(i, ageInTicks, withdrawal);
            _spikeParts[i].Z = GetSpikeZ(i, ageInTicks, withdrawal);
        }
    }

    private static float GetSpikeOffset(int spike, float ageInTicks, float withdrawal) => 1.0F + Mth.Cos(ageInTicks * 1.5F + spike) * 0.01F - withdrawal;

    private static float GetSpikeX(int spike, float ageInTicks, float withdrawal) => SpikeX[spike] * GetSpikeOffset(spike, ageInTicks, withdrawal);

    private static float GetSpikeY(int spike, float ageInTicks, float withdrawal) => 16.0F + SpikeY[spike] * GetSpikeOffset(spike, ageInTicks, withdrawal);

    private static float GetSpikeZ(int spike, float ageInTicks, float withdrawal) => SpikeZ[spike] * GetSpikeOffset(spike, ageInTicks, withdrawal);
}
