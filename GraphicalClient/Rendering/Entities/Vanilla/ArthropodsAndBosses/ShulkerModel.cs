namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ShulkerModel : EntityModel<ShulkerRenderState> {
    private readonly ModelPart _lid, _head;

    public ShulkerModel(ModelPart root) : base(root) {
        _lid = root.GetChild("lid");
        _head = root.GetChild("head");
    }

    private static MeshDefinition CreateShellMesh() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("lid", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -16.0F, -8.0F, 16.0F, 12.0F, 16.0F), PartPose.Offset(0.0F, 24.0F, 0.0F));
        root.AddOrReplaceChild("base", CubeListBuilder.Create().TexOffs(0, 28).AddBox(-8.0F, -8.0F, -8.0F, 16.0F, 8.0F, 16.0F), PartPose.Offset(0.0F, 24.0F, 0.0F));
        return mesh;
    }

    /// <summary><c>createBoxLayer</c>: the shell alone, which the shulker box draws.</summary>
    public static LayerDefinition CreateBoxLayer() => LayerDefinition.Create(CreateShellMesh(), 64, 64);

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateShellMesh();
        mesh.Root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 52).AddBox(-3.0F, 0.0F, -3.0F, 6.0F, 6.0F, 6.0F), PartPose.Offset(0.0F, 12.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(ShulkerRenderState state) {
        base.SetupAnim(state);
        float bs = (0.5F + state.PeekAmount) * (float)Math.PI;
        float q = -1.0F + Mth.Sin(bs);
        float extra = 0.0F;
        if (bs > (float)Math.PI) {
            extra = Mth.Sin(state.AgeInTicks * 0.1F) * 0.7F;
        }
        _lid.SetPos(0.0F, 16.0F + Mth.Sin(bs) * 8.0F + extra, 0.0F);
        if (state.PeekAmount > 0.3F) {
            _lid.YRot = q * q * q * q * (float)Math.PI * 0.125F;
        }
        else {
            _lid.YRot = 0.0F;
        }
        _head.XRot = state.XRot * (float)(Math.PI / 180.0);
        _head.YRot = (state.YHeadRot - 180.0F - state.YBodyRot) * (float)(Math.PI / 180.0);
    }
}
