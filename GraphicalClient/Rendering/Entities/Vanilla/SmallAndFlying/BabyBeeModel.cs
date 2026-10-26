namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyBeeModel : BeeModel {
    public BabyBeeModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition bone = root.AddOrReplaceChild("bone", CubeListBuilder.Create()
                .TexOffs(6, 12).AddBox(1.0F, -1.6667F, -2.1633F, 1.0F, 2.0F, 2.0F)
                .TexOffs(0, 12).AddBox(-2.0F, -1.6667F, -2.1933F, 1.0F, 2.0F, 2.0F),
            PartPose.Offset(0.0F, 19.6667F, -1.8567F));
        PartDefinition body = bone.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.0F, -2.0F, -2.5F, 4.0F, 4.0F, 5.0F),
            PartPose.Offset(0.0F, 1.3333F, 2.3567F));
        body.AddOrReplaceChild("stinger", CubeListBuilder.Create().TexOffs(13, 2).AddBox(0.0F, -0.5F, 0.0F, 0.0F, 1.0F, 1.0F), PartPose.Offset(0.0F, 0.5F, 2.5F));
        bone.AddOrReplaceChild("right_wing", CubeListBuilder.Create().TexOffs(3, 9).AddBox(-3.0F, 0.0F, 0.0F, 3.0F, 0.0F, 3.0F),
            PartPose.OffsetAndRotation(-1.0F, -0.6667F, 0.8567F, 0.2182F, 0.3491F, 0.0F));
        bone.AddOrReplaceChild("left_wing", CubeListBuilder.Create().TexOffs(-3, 9).Mirror().AddBox(0.0F, 0.0F, 0.0F, 3.0F, 0.0F, 3.0F).Mirror(false),
            PartPose.OffsetAndRotation(1.0F, -0.6667F, 0.8567F, 0.2182F, -0.3491F, 0.0F));
        bone.AddOrReplaceChild("front_legs", CubeListBuilder.Create().TexOffs(13, 0).AddBox(-1.5F, 0.0F, 0.0F, 3.0F, 1.0F, 0.0F),
            PartPose.Offset(0.0F, 3.3333F, 1.8567F));
        bone.AddOrReplaceChild("middle_legs", CubeListBuilder.Create().TexOffs(13, 1).AddBox(-1.5F, 0.0F, 0.0F, 3.0F, 1.0F, 0.0F),
            PartPose.Offset(0.0F, 3.3333F, 2.8567F));
        bone.AddOrReplaceChild("back_legs", CubeListBuilder.Create().TexOffs(13, 2).AddBox(-1.5F, 0.0F, 0.0F, 3.0F, 1.0F, 0.0F), PartPose.Offset(0.0F, 3.3333F, 3.8567F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
