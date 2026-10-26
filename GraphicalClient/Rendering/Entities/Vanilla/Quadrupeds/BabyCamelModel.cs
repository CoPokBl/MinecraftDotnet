namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyCamelModel : CamelModel {
    public BabyCamelModel(ModelPart root)
        : base(root, CamelBabyAnimation.CamelBabyWalk, CamelBabyAnimation.CamelBabySit, CamelBabyAnimation.CamelBabySitPose, CamelBabyAnimation.CamelBabyStandup,
            CamelBabyAnimation.CamelBabyIdle, CamelBabyAnimation.CamelBabyDash) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 14).AddBox(-4.5F, -4.0F, -8.0F, 9.0F, 8.0F, 16.0F),
            PartPose.Offset(0.0F, 7.0F, 0.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(50, 38).AddBox(-1.5F, -0.5F, 0.0F, 3.0F, 9.0F, 0.0F), PartPose.Offset(0.0F, -1.5F, 8.05F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(20, 0).AddBox(-2.5F, -3.0F, -7.5F, 5.0F, 5.0F, 7.0F)
            .TexOffs(0, 0).AddBox(-2.5F, -12.0F, -7.5F, 5.0F, 9.0F, 5.0F)
            .TexOffs(0, 14).AddBox(-2.5F, -12.0F, -10.5F, 5.0F, 4.0F, 3.0F), PartPose.Offset(0.0F, 1.0F, -7.5F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(37, 0).AddBox(-3.0F, -0.5F, -1.0F, 3.0F, 1.0F, 2.0F), PartPose.Offset(-2.5F, -11.0F, -4.0F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(47, 0).AddBox(0.0F, -0.5F, -1.0F, 3.0F, 1.0F, 2.0F), PartPose.Offset(2.5F, -11.0F, -4.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(36, 14).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 13.0F, 3.0F),
            PartPose.Offset(-3.0F, 11.5F, -5.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(48, 14).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 13.0F, 3.0F),
            PartPose.Offset(3.0F, 11.5F, -5.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(12, 38).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 13.0F, 3.0F),
            PartPose.Offset(3.0F, 11.5F, 5.5F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 38).AddBox(-1.5F, -0.5F, -1.5F, 3.0F, 13.0F, 3.0F),
            PartPose.Offset(-3.0F, 11.5F, 5.5F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
