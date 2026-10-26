namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SilverfishModel : EntityModel<LivingEntityRenderState> {
    private static readonly int[][] BodySizes = [[3, 2, 2], [4, 3, 2], [6, 4, 3], [3, 3, 3], [2, 2, 3], [2, 1, 2], [1, 1, 2]];
    private static readonly int[][] BodyTexs = [[0, 0], [0, 4], [0, 9], [0, 16], [0, 22], [11, 0], [13, 4]];

    private readonly ModelPart[] _bodyParts = new ModelPart[7];
    private readonly ModelPart[] _bodyLayers = new ModelPart[3];

    public SilverfishModel(ModelPart root) : base(root) {
        for (int i = 0; i < _bodyParts.Length; i++) {
            _bodyParts[i] = root.GetChild(GetSegmentName(i));
        }
        for (int i = 0; i < _bodyLayers.Length; i++) {
            _bodyLayers[i] = root.GetChild(GetLayerName(i));
        }
    }

    private static string GetLayerName(int i) => "layer" + i;

    private static string GetSegmentName(int i) => "segment" + i;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        float[] zPlacement = new float[7];
        float placement = -3.5F;
        for (int i = 0; i < 7; i++) {
            root.AddOrReplaceChild(GetSegmentName(i), CubeListBuilder.Create().TexOffs(BodyTexs[i][0], BodyTexs[i][1]).AddBox(BodySizes[i][0] * -0.5F, 0.0F, BodySizes[i][2] * -0.5F, BodySizes[i][0], BodySizes[i][1], BodySizes[i][2]),
                PartPose.Offset(0.0F, 24 - BodySizes[i][1], placement));
            zPlacement[i] = placement;
            if (i < 6) {
                placement += (BodySizes[i][2] + BodySizes[i + 1][2]) * 0.5F;
            }
        }
        root.AddOrReplaceChild(GetLayerName(0), CubeListBuilder.Create().TexOffs(20, 0).AddBox(-5.0F, 0.0F, BodySizes[2][2] * -0.5F, 10.0F, 8.0F, BodySizes[2][2]),
            PartPose.Offset(0.0F, 16.0F, zPlacement[2]));
        root.AddOrReplaceChild(GetLayerName(1), CubeListBuilder.Create().TexOffs(20, 11).AddBox(-3.0F, 0.0F, BodySizes[4][2] * -0.5F, 6.0F, 4.0F, BodySizes[4][2]),
            PartPose.Offset(0.0F, 20.0F, zPlacement[4]));
        root.AddOrReplaceChild(GetLayerName(2), CubeListBuilder.Create().TexOffs(20, 18).AddBox(-3.0F, 0.0F, BodySizes[4][2] * -0.5F, 6.0F, 5.0F, BodySizes[1][2]),
            PartPose.Offset(0.0F, 19.0F, zPlacement[1]));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(LivingEntityRenderState state) {
        base.SetupAnim(state);
        for (int i = 0; i < _bodyParts.Length; i++) {
            _bodyParts[i].YRot = Mth.Cos(state.AgeInTicks * 0.9F + i * 0.15F * (float)Math.PI) * (float)Math.PI * 0.05F * (1 + Math.Abs(i - 2));
            _bodyParts[i].X = Mth.Sin(state.AgeInTicks * 0.9F + i * 0.15F * (float)Math.PI) * (float)Math.PI * 0.2F * Math.Abs(i - 2);
        }
        _bodyLayers[0].YRot = _bodyParts[2].YRot;
        _bodyLayers[1].YRot = _bodyParts[4].YRot;
        _bodyLayers[1].X = _bodyParts[4].X;
        _bodyLayers[2].YRot = _bodyParts[1].YRot;
        _bodyLayers[2].X = _bodyParts[1].X;
    }
}
