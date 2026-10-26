namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyGoatModel(ModelPart root) : GoatModel(root) {
    public new static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(29, 12).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(1.5F, 19.5F, 3.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(21, 12).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(-1.5F, 19.5F, 3.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(21, 5).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(-1.5F, 19.5F, -2.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(29, 5).AddBox(-1.0F, -0.5F, -1.0F, 2.0F, 5.0F, 2.0F),
            PartPose.Offset(1.5F, 19.5F, -2.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(0, 10).AddBox(-3.0F, -2.3F, -4.5F, 6.0F, 5.0F, 9.0F)
            .TexOffs(0, 24).AddBox(-2.5F, -2.2F, -4.0F, 5.0F, 4.0F, 8.0F), PartPose.Offset(0.0F, 17.8F, 0.0F));
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.0F, -3.8126F, -5.1548F, 4.0F, 4.0F, 6.0F),
            PartPose.OffsetAndRotation(0.0F, 15.5F, -3.0F, 0.4363F, 0.0F, 0.0F));
        head.AddOrReplaceChild("right_horn", CubeListBuilder.Create().TexOffs(24, 0).Mirror().AddBox(0.0F, -4.5F, 0.0F, 1.0F, 2.0F, 1.0F).Mirror(false),
            PartPose.OffsetAndRotation(-1.5F, -1.5F, -1.0F, -MathF.PI / 8, 0.0F, 0.0F));
        head.AddOrReplaceChild("left_horn", CubeListBuilder.Create().TexOffs(24, 0).Mirror().AddBox(2.0F, -4.5F, 0.0F, 1.0F, 2.0F, 1.0F).Mirror(false),
            PartPose.OffsetAndRotation(-1.5F, -1.5F, -1.0F, -MathF.PI / 8, 0.0F, 0.0F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(0, 12).Mirror().AddBox(-2.0F, -0.5F, -0.5F, 2.0F, 1.0F, 1.0F).Mirror(false),
            PartPose.OffsetAndRotation(-1.7F, -2.3126F, 0.1452F, 0.0F, -0.5236F, 0.0F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(0, 12).AddBox(0.0F, -0.5F, -0.5F, 2.0F, 1.0F, 1.0F),
            PartPose.OffsetAndRotation(1.7F, -2.3126F, 0.1452F, 0.0F, 0.5236F, 0.0F));
        head.AddOrReplaceChild("HeadMain", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.0F, -2.5F, -4.0F, 4.0F, 4.0F, 6.0F),
            PartPose.Offset(0.0F, -1.3126F, -1.1548F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(GoatRenderState state) {
        base.SetupAnim(state);
        if (state.RammingXHeadRot == 0.0F) {
            Head.XRot = MathF.PI / 8;
        }
    }
}
