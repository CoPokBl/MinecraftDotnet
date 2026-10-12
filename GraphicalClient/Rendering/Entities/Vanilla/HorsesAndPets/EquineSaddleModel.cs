namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>EquineSaddleModel</c>: the reins show only while ridden.</summary>
public class EquineSaddleModel : AbstractEquineModel<EquineRenderState> {
    private readonly ModelPart[] _ridingParts;

    public EquineSaddleModel(ModelPart root) : base(root) {
        ModelPart leftSaddleLine = HeadParts.GetChild("left_saddle_line");
        ModelPart rightSaddleLine = HeadParts.GetChild("right_saddle_line");
        _ridingParts = [leftSaddleLine, rightSaddleLine];
    }

    public static LayerDefinition CreateSaddleLayer() {
        MeshDefinition mesh = CreateBodyMesh(CubeDeformation.None);
        PartDefinition root = mesh.Root;
        PartDefinition body = root.GetChild("body");
        PartDefinition headParts = root.GetChild("head_parts");
        body.AddOrReplaceChild("saddle", CubeListBuilder.Create().TexOffs(26, 0).AddBox(-5.0F, -8.0F, -9.0F, 10.0F, 9.0F, 9.0F, new CubeDeformation(0.5F)),
            PartPose.Zero);
        headParts.AddOrReplaceChild("left_saddle_mouth", CubeListBuilder.Create().TexOffs(29, 5).AddBox(2.0F, -9.0F, -6.0F, 1.0F, 2.0F, 2.0F), PartPose.Zero);
        headParts.AddOrReplaceChild("right_saddle_mouth", CubeListBuilder.Create().TexOffs(29, 5).AddBox(-3.0F, -9.0F, -6.0F, 1.0F, 2.0F, 2.0F), PartPose.Zero);
        headParts.AddOrReplaceChild("left_saddle_line", CubeListBuilder.Create().TexOffs(32, 2).AddBox(3.1F, -6.0F, -8.0F, 0.0F, 3.0F, 16.0F),
            PartPose.Rotation((float)(-Math.PI / 6), 0.0F, 0.0F));
        headParts.AddOrReplaceChild("right_saddle_line", CubeListBuilder.Create().TexOffs(32, 2).AddBox(-3.1F, -6.0F, -8.0F, 0.0F, 3.0F, 16.0F),
            PartPose.Rotation((float)(-Math.PI / 6), 0.0F, 0.0F));
        headParts.AddOrReplaceChild("head_saddle", CubeListBuilder.Create().TexOffs(1, 1).AddBox(-3.0F, -11.0F, -1.9F, 6.0F, 5.0F, 6.0F, new CubeDeformation(0.22F)),
            PartPose.Zero);
        headParts.AddOrReplaceChild("mouth_saddle_wrap", CubeListBuilder.Create().TexOffs(19, 0).AddBox(-2.0F, -11.0F, -4.0F, 4.0F, 5.0F, 2.0F, new CubeDeformation(0.2F)),
            PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(EquineRenderState state) {
        base.SetupAnim(state);
        foreach (ModelPart part in _ridingParts) {
            part.Visible = state.IsRidden;
        }
    }
}
