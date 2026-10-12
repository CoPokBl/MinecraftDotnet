namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SquidModel : EntityModel<SquidRenderState> {
    public static readonly MeshTransformer BabyTransformer = MeshTransformers.Scaling(0.5F);
    private readonly ModelPart[] _tentacles = new ModelPart[8];

    public SquidModel(ModelPart root) : base(root) {
        for (int i = 0; i < _tentacles.Length; i++) {
            _tentacles[i] = root.GetChild(CreateTentacleName(i));
        }
    }

    protected static string CreateTentacleName(int i) => "tentacle" + i;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        CubeDeformation g = new(0.02F);
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-6.0F, -8.0F, -6.0F, 12.0F, 16.0F, 12.0F, g), PartPose.Offset(0.0F, 8.0F, 0.0F));
        CubeListBuilder tentacle = CubeListBuilder.Create().TexOffs(48, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 18.0F, 2.0F);
        for (int i = 0; i < 8; i++) {
            double angle = i * Math.PI * 2.0 / 8.0;
            float x = (float)Math.Cos(angle) * 5.0F;
            float z = (float)Math.Sin(angle) * 5.0F;
            angle = i * Math.PI * -2.0 / 8.0 + Math.PI / 2;
            float yRot = (float)angle;
            root.AddOrReplaceChild(CreateTentacleName(i), tentacle, PartPose.OffsetAndRotation(x, 15.0F, z, 0.0F, yRot, 0.0F));
        }
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(SquidRenderState state) {
        base.SetupAnim(state);
        foreach (ModelPart tentacle in _tentacles) {
            tentacle.XRot = state.TentacleAngle;
        }
    }
}
