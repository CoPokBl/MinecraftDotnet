namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class WitherBossModel : EntityModel<WitherRenderState> {
    private const float RibcageXRotOffset = 0.065F;
    private const float TailXRotOffset = 0.265F;

    private readonly ModelPart _centerHead, _rightHead, _leftHead, _ribcage, _tail;

    public WitherBossModel(ModelPart root) : base(root) {
        _ribcage = root.GetChild("ribcage");
        _tail = root.GetChild("tail");
        _centerHead = root.GetChild("center_head");
        _rightHead = root.GetChild("right_head");
        _leftHead = root.GetChild("left_head");
    }

    public static LayerDefinition CreateBodyLayer(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("shoulders", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-10.0F, 3.9F, -0.5F, 20.0F, 3.0F, 3.0F, g), PartPose.Zero);
        root.AddOrReplaceChild("ribcage", CubeListBuilder.Create()
                .TexOffs(0, 22).AddBox(0.0F, 0.0F, 0.0F, 3.0F, 10.0F, 3.0F, g)
                .TexOffs(24, 22).AddBox(-4.0F, 1.5F, 0.5F, 11.0F, 2.0F, 2.0F, g)
                .TexOffs(24, 22).AddBox(-4.0F, 4.0F, 0.5F, 11.0F, 2.0F, 2.0F, g)
                .TexOffs(24, 22).AddBox(-4.0F, 6.5F, 0.5F, 11.0F, 2.0F, 2.0F, g),
            PartPose.OffsetAndRotation(-2.0F, 6.9F, -0.5F, 0.20420352F, 0.0F, 0.0F));
        root.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(12, 22).AddBox(0.0F, 0.0F, 0.0F, 3.0F, 6.0F, 3.0F, g),
            PartPose.OffsetAndRotation(-2.0F, 6.9F + Mth.Cos(0.20420352F) * 10.0F, -0.5F + Mth.Sin(0.20420352F) * 10.0F, 0.83252203F, 0.0F, 0.0F));
        root.AddOrReplaceChild("center_head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -4.0F, -4.0F, 8.0F, 8.0F, 8.0F, g), PartPose.Zero);
        CubeListBuilder sideHead = CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -4.0F, -4.0F, 6.0F, 6.0F, 6.0F, g);
        root.AddOrReplaceChild("right_head", sideHead, PartPose.Offset(-8.0F, 4.0F, 0.0F));
        root.AddOrReplaceChild("left_head", sideHead, PartPose.Offset(10.0F, 4.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(WitherRenderState state) {
        base.SetupAnim(state);
        SetupHeadRotation(state, _rightHead, 0);
        SetupHeadRotation(state, _leftHead, 1);
        float anim = Mth.Cos(state.AgeInTicks * 0.1F);
        _ribcage.XRot = (RibcageXRotOffset + 0.05F * anim) * (float)Math.PI;
        _tail.SetPos(-2.0F, 6.9F + Mth.Cos(_ribcage.XRot) * 10.0F, -0.5F + Mth.Sin(_ribcage.XRot) * 10.0F);
        _tail.XRot = (TailXRotOffset + 0.1F * anim) * (float)Math.PI;
        _centerHead.YRot = state.YRot * (float)(Math.PI / 180.0);
        _centerHead.XRot = state.XRot * (float)(Math.PI / 180.0);
    }

    private static void SetupHeadRotation(WitherRenderState state, ModelPart head, int headIndex) {
        head.YRot = (state.YHeadRots[headIndex] - state.BodyRot) * (float)(Math.PI / 180.0);
        head.XRot = state.XHeadRots[headIndex] * (float)(Math.PI / 180.0);
    }
}
