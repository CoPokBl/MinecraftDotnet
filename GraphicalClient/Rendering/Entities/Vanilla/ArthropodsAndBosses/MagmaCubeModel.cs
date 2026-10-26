namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class MagmaCubeModel : EntityModel<SlimeRenderState> {
    private readonly ModelPart[] _bodyCubes = new ModelPart[8];

    public MagmaCubeModel(ModelPart root) : base(root) {
        for (int i = 0; i < _bodyCubes.Length; i++) {
            _bodyCubes[i] = root.GetChild(GetSegmentName(i));
        }
    }

    private static string GetSegmentName(int i) => "cube" + i;

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        for (int i = 0; i < 8; i++) {
            int u = 0;
            int v = 0;
            if (i > 0 && i < 4) {
                v += 9 * i;
            }
            else if (i > 3) {
                u = 32;
                v += 9 * i - 36;
            }
            root.AddOrReplaceChild(GetSegmentName(i), CubeListBuilder.Create().TexOffs(u, v).AddBox(-4.0F, 16 + i, -4.0F, 8.0F, 1.0F, 8.0F), PartPose.Zero);
        }
        root.AddOrReplaceChild("inside_cube", CubeListBuilder.Create().TexOffs(24, 40).AddBox(-2.0F, 18.0F, -2.0F, 4.0F, 4.0F, 4.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(SlimeRenderState state) {
        base.SetupAnim(state);
        float slimeSquish = Math.Max(0.0F, state.Squish);
        for (int i = 0; i < _bodyCubes.Length; i++) {
            _bodyCubes[i].Y = -(4 - i) * slimeSquish * 1.7F;
        }
    }
}
