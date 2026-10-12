namespace GraphicalClient.Rendering.Entities.Vanilla;

public class AdultChickenModel : ChickenModel {
    private readonly ModelPart _head;

    public AdultChickenModel(ModelPart root) : base(root) {
        _head = root.GetChild("head");
    }

    public override void SetupAnim(ChickenRenderState state) {
        base.SetupAnim(state);
        _head.XRot = state.XRot * (MathF.PI / 180.0F);
        _head.YRot = state.YRot * (MathF.PI / 180.0F);
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateBaseChickenModel();
        return LayerDefinition.Create(mesh, 64, 32);
    }

    protected static MeshDefinition CreateBaseChickenModel() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.0F, -6.0F, -2.0F, 4.0F, 6.0F, 3.0F),
            PartPose.Offset(0.0F, 15.0F, -4.0F));
        head.AddOrReplaceChild("beak", CubeListBuilder.Create().TexOffs(14, 0).AddBox(-2.0F, -4.0F, -4.0F, 4.0F, 2.0F, 2.0F), PartPose.Zero);
        head.AddOrReplaceChild("red_thing", CubeListBuilder.Create().TexOffs(14, 4).AddBox(-1.0F, -2.0F, -3.0F, 2.0F, 2.0F, 2.0F), PartPose.Zero);
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 9).AddBox(-3.0F, -4.0F, -3.0F, 6.0F, 8.0F, 6.0F),
            PartPose.OffsetAndRotation(0.0F, 16.0F, 0.0F, MathF.PI / 2, 0.0F, 0.0F));
        CubeListBuilder leg = CubeListBuilder.Create().TexOffs(26, 0).AddBox(-1.0F, 0.0F, -3.0F, 3.0F, 5.0F, 3.0F);
        root.AddOrReplaceChild("right_leg", leg, PartPose.Offset(-2.0F, 19.0F, 1.0F));
        root.AddOrReplaceChild("left_leg", leg, PartPose.Offset(1.0F, 19.0F, 1.0F));
        root.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(24, 13).AddBox(0.0F, 0.0F, -3.0F, 1.0F, 4.0F, 6.0F), PartPose.Offset(-4.0F, 13.0F, 0.0F));
        root.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(24, 13).AddBox(-1.0F, 0.0F, -3.0F, 1.0F, 4.0F, 6.0F), PartPose.Offset(4.0F, 13.0F, 0.0F));
        return mesh;
    }
}
