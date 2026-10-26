namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyHoglinModel(ModelPart root) : HoglinModel(root) {
    protected override void AnimateHeadbutt(float headbuttLerpFactor) {
        base.AnimateHeadbutt(headbuttLerpFactor);
        Head.Y += headbuttLerpFactor * 2.5F;
    }

    public new static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-5.0F, -2.2605F, -10.547F, 10.0F, 4.0F, 12.0F)
            .TexOffs(44, 29).AddBox(-7.0F, -4.0981F, -8.4879F, 2.0F, 5.0F, 2.0F)
            .TexOffs(52, 29).AddBox(5.0F, -4.0981F, -8.4879F, 2.0F, 5.0F, 2.0F), PartPose.OffsetAndRotation(0.0F, 13.0F, -7.0F, 0.8727F, 0.0F, 0.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(0, 16).AddBox(-4.0F, -14.0F, -7.0F, 8.0F, 8.0F, 14.0F, new CubeDeformation(0.02F))
            .TexOffs(24, 39).AddBox(0.0F, -18.0F, -8.0F, 0.0F, 6.0F, 11.0F, new CubeDeformation(0.02F)), PartPose.Offset(0.0F, 24.0F, 0.0F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(32, 5).AddBox(-5.1F, -0.5F, -2.0F, 6.0F, 1.0F, 4.0F),
            PartPose.OffsetAndRotation(-5.0F, -1.0F, -1.5F, 0.0F, 0.0F, -0.8727F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(32, 0).Mirror().AddBox(-0.9F, -0.5F, -2.0F, 6.0F, 1.0F, 4.0F).Mirror(false),
            PartPose.OffsetAndRotation(5.0F, -1.0F, -1.5F, 0.0F, 0.0F, 0.8727F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 47).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(-2.5F, 18.0F, 4.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(12, 47).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(2.5F, 18.0F, 4.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 38).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(-2.5F, 18.0F, -4.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(12, 38).AddBox(-1.5F, 0.0F, -1.5F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(2.5F, 18.0F, -4.5F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
