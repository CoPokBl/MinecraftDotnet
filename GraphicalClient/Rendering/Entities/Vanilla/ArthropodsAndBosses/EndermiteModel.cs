namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class EndermiteModel : EntityModel<LivingEntityRenderState> {
    private static readonly int[][] BodySizes = [[4, 3, 2], [6, 4, 5], [3, 3, 1], [1, 2, 1]];
    private static readonly int[][] BodyTexs = [[0, 0], [0, 5], [0, 14], [0, 18]];

    private readonly ModelPart[] _bodyParts = new ModelPart[4];

    public EndermiteModel(ModelPart root) : base(root) {
        for (int i = 0; i < 4; i++) {
            _bodyParts[i] = root.GetChild(CreateSegmentName(i));
        }
    }

    private static string CreateSegmentName(int i) => "segment" + i;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        float placement = -3.5F;
        for (int i = 0; i < 4; i++) {
            root.AddOrReplaceChild(CreateSegmentName(i), CubeListBuilder.Create().TexOffs(BodyTexs[i][0], BodyTexs[i][1]).AddBox(BodySizes[i][0] * -0.5F, 0.0F, BodySizes[i][2] * -0.5F, BodySizes[i][0], BodySizes[i][1], BodySizes[i][2]),
                PartPose.Offset(0.0F, 24 - BodySizes[i][1], placement));
            if (i < 3) {
                placement += (BodySizes[i][2] + BodySizes[i + 1][2]) * 0.5F;
            }
        }
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(LivingEntityRenderState state) {
        base.SetupAnim(state);
        for (int i = 0; i < _bodyParts.Length; i++) {
            _bodyParts[i].YRot = Mth.Cos(state.AgeInTicks * 0.9F + i * 0.15F * (float)Math.PI) * (float)Math.PI * 0.01F * (1 + Math.Abs(i - 2));
            _bodyParts[i].X = Mth.Sin(state.AgeInTicks * 0.9F + i * 0.15F * (float)Math.PI) * (float)Math.PI * 0.1F * Math.Abs(i - 2);
        }
    }
}
