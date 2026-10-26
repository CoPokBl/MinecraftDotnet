namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CamelSaddleModel : AdultCamelModel {
    private readonly ModelPart _reins;

    public CamelSaddleModel(ModelPart root) : base(root) {
        _reins = Head.GetChild("reins");
    }

    public static LayerDefinition CreateSaddleLayer() {
        MeshDefinition mesh = CreateBodyMesh();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.GetChild("body");
        PartDefinition head = body.GetChild("head");
        CubeDeformation inflate = new(0.05F);
        body.AddOrReplaceChild("saddle", CubeListBuilder.Create()
            .TexOffs(74, 64).AddBox(-4.5F, -17.0F, -15.5F, 9.0F, 5.0F, 11.0F, inflate)
            .TexOffs(92, 114).AddBox(-3.5F, -20.0F, -15.5F, 7.0F, 3.0F, 11.0F, inflate)
            .TexOffs(0, 89).AddBox(-7.5F, -12.0F, -23.5F, 15.0F, 12.0F, 27.0F, inflate), PartPose.Offset(0.0F, 0.0F, 0.0F));
        head.AddOrReplaceChild("reins", CubeListBuilder.Create()
            .TexOffs(98, 42).AddBox(3.51F, -18.0F, -17.0F, 0.0F, 7.0F, 15.0F)
            .TexOffs(84, 57).AddBox(-3.5F, -18.0F, -2.0F, 7.0F, 7.0F, 0.0F)
            .TexOffs(98, 42).AddBox(-3.51F, -18.0F, -17.0F, 0.0F, 7.0F, 15.0F), PartPose.Offset(0.0F, 0.0F, 0.0F));
        head.AddOrReplaceChild("bridle", CubeListBuilder.Create()
            .TexOffs(60, 87).AddBox(-3.5F, -7.0F, -15.0F, 7.0F, 8.0F, 19.0F, inflate)
            .TexOffs(21, 64).AddBox(-3.5F, -21.0F, -15.0F, 7.0F, 14.0F, 7.0F, inflate)
            .TexOffs(50, 64).AddBox(-2.5F, -21.0F, -21.0F, 5.0F, 5.0F, 6.0F, inflate)
            .TexOffs(74, 70).AddBox(2.5F, -19.0F, -18.0F, 1.0F, 2.0F, 2.0F)
            .TexOffs(74, 70).Mirror().AddBox(-3.5F, -19.0F, -18.0F, 1.0F, 2.0F, 2.0F), PartPose.Offset(0.0F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 128, 128);
    }

    public override void SetupAnim(CamelRenderState state) {
        base.SetupAnim(state);
        _reins.Visible = state.IsRidden;
    }
}
