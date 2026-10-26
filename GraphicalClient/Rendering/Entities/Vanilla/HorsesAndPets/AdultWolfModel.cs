namespace GraphicalClient.Rendering.Entities.Vanilla;

public class AdultWolfModel : WolfModel {
    private readonly ModelPart _realHead;
    private readonly ModelPart _realTail;
    private readonly ModelPart _upperBody;

    public AdultWolfModel(ModelPart root) : base(root) {
        _realHead = Head.GetChild("real_head");
        _upperBody = root.GetChild("upper_body");
        _realTail = Tail.GetChild("real_tail");
    }

    public static LayerDefinition CreateBodyLayer(CubeDeformation g) => LayerDefinition.Create(CreateBodyMesh(g), 64, 32);

    public static MeshDefinition CreateBodyMesh(CubeDeformation g) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create(), PartPose.Offset(-1.0F, 13.5F, -7.0F));
        head.AddOrReplaceChild("real_head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-2.0F, -3.0F, -2.0F, 6.0F, 6.0F, 4.0F, g)
            .TexOffs(16, 14).AddBox(-2.0F, -5.0F, 0.0F, 2.0F, 2.0F, 1.0F, g)
            .TexOffs(16, 14).AddBox(2.0F, -5.0F, 0.0F, 2.0F, 2.0F, 1.0F, g)
            .TexOffs(0, 10).AddBox(-0.5F, -0.001F, -5.0F, 3.0F, 3.0F, 4.0F, g), PartPose.Zero);
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(18, 14).AddBox(-3.0F, -2.0F, -3.0F, 6.0F, 9.0F, 6.0F, g),
            PartPose.OffsetAndRotation(0.0F, 14.0F, 2.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        root.AddOrReplaceChild("upper_body", CubeListBuilder.Create().TexOffs(21, 0).AddBox(-3.0F, -3.0F, -3.0F, 8.0F, 6.0F, 7.0F, g),
            PartPose.OffsetAndRotation(-1.0F, 14.0F, -3.0F, (float)(Math.PI / 2), 0.0F, 0.0F));
        CubeListBuilder leftLeg = CubeListBuilder.Create().TexOffs(0, 18).AddBox(0.0F, 0.0F, -1.0F, 2.0F, 8.0F, 2.0F, g);
        CubeListBuilder rightLeg = CubeListBuilder.Create().Mirror().TexOffs(0, 18).AddBox(0.0F, 0.0F, -1.0F, 2.0F, 8.0F, 2.0F, g);
        root.AddOrReplaceChild("right_hind_leg", rightLeg, PartPose.Offset(-2.5F, 16.0F, 7.0F));
        root.AddOrReplaceChild("left_hind_leg", leftLeg, PartPose.Offset(0.5F, 16.0F, 7.0F));
        root.AddOrReplaceChild("right_front_leg", rightLeg, PartPose.Offset(-2.5F, 16.0F, -4.0F));
        root.AddOrReplaceChild("left_front_leg", leftLeg, PartPose.Offset(0.5F, 16.0F, -4.0F));
        PartDefinition tail = root.AddOrReplaceChild("tail", CubeListBuilder.Create(), PartPose.OffsetAndRotation(-1.0F, 12.0F, 8.0F, (float)(Math.PI / 5), 0.0F, 0.0F));
        tail.AddOrReplaceChild("real_tail", CubeListBuilder.Create().TexOffs(9, 18).AddBox(0.0F, 0.0F, -1.0F, 2.0F, 8.0F, 2.0F, g), PartPose.Zero);
        return mesh;
    }

    protected override void SetSittingPose(WolfRenderState state) {
        base.SetSittingPose(state);
        _upperBody.Y += 2.0F;
        _upperBody.XRot = (float)(Math.PI * 2.0 / 5.0);
        _upperBody.YRot = 0.0F;
    }

    protected override void ShakeOffWater(WolfRenderState state) {
        base.ShakeOffWater(state);
        _realHead.ZRot = state.HeadRollAngle + state.GetBodyRollAngle(0.0F);
        _upperBody.ZRot = state.GetBodyRollAngle(-0.08F);
        _realTail.ZRot = state.GetBodyRollAngle(-0.2F);
    }
}
