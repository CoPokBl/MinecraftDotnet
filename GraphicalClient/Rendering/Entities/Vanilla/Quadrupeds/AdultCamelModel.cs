namespace GraphicalClient.Rendering.Entities.Vanilla;

public class AdultCamelModel : CamelModel {
    public AdultCamelModel(ModelPart root)
        : base(root, CamelAnimation.CamelWalk, CamelAnimation.CamelSit, CamelAnimation.CamelSitPose, CamelAnimation.CamelStandup, CamelAnimation.CamelIdle,
            CamelAnimation.CamelDash) { }

    public static LayerDefinition CreateBodyLayer() => LayerDefinition.Create(CreateBodyMesh(), 128, 128);

    protected static MeshDefinition CreateBodyMesh() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 25).AddBox(-7.5F, -12.0F, -23.5F, 15.0F, 12.0F, 27.0F),
            PartPose.Offset(0.0F, 4.0F, 9.5F));
        body.AddOrReplaceChild("hump", CubeListBuilder.Create().TexOffs(74, 0).AddBox(-4.5F, -5.0F, -5.5F, 9.0F, 5.0F, 11.0F), PartPose.Offset(0.0F, -12.0F, -10.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(122, 0).AddBox(-1.5F, 0.0F, 0.0F, 3.0F, 14.0F, 0.0F), PartPose.Offset(0.0F, -9.0F, 3.5F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(60, 24).AddBox(-3.5F, -7.0F, -15.0F, 7.0F, 8.0F, 19.0F)
            .TexOffs(21, 0).AddBox(-3.5F, -21.0F, -15.0F, 7.0F, 14.0F, 7.0F)
            .TexOffs(50, 0).AddBox(-2.5F, -21.0F, -21.0F, 5.0F, 5.0F, 6.0F), PartPose.Offset(0.0F, -3.0F, -19.5F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(45, 0).AddBox(-0.5F, 0.5F, -1.0F, 3.0F, 1.0F, 2.0F), PartPose.Offset(2.5F, -21.0F, -9.5F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(67, 0).AddBox(-2.5F, 0.5F, -1.0F, 3.0F, 1.0F, 2.0F), PartPose.Offset(-2.5F, -21.0F, -9.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(58, 16).AddBox(-2.5F, 2.0F, -2.5F, 5.0F, 21.0F, 5.0F),
            PartPose.Offset(4.9F, 1.0F, 9.5F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(94, 16).AddBox(-2.5F, 2.0F, -2.5F, 5.0F, 21.0F, 5.0F),
            PartPose.Offset(-4.9F, 1.0F, 9.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.5F, 2.0F, -2.5F, 5.0F, 21.0F, 5.0F),
            PartPose.Offset(4.9F, 1.0F, -10.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 26).AddBox(-2.5F, 2.0F, -2.5F, 5.0F, 21.0F, 5.0F),
            PartPose.Offset(-4.9F, 1.0F, -10.5F));
        return mesh;
    }
}
