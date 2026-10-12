namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyDolphinModel : DolphinModel {
    public BabyDolphinModel(ModelPart root) : base(root) { }

    public static new LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(20, 0).AddBox(-3.0F, -2.5F, -4.0F, 6.0F, 5.0F, 8.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 21.5F, 0.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -3.5F, -4.0F, 6.0F, 5.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 1.0F, -4.0F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(0, 9).AddBox(-1.0F, -1.0F, -2.0F, 2.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 0.5F, -4.0F));
        body.AddOrReplaceChild("left_fin", CubeListBuilder.Create().TexOffs(34, 18).AddBox(-0.5F, -1.5F, -0.5F, 1.0F, 3.0F, 6.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(1.8F, 0.85F, -2.6F, 0.8727F, 0.0F, 1.7017F));
        body.AddOrReplaceChild("right_fin", CubeListBuilder.Create().TexOffs(48, 18).Mirror().AddBox(-0.5F, -1.5F, -0.5F, 1.0F, 3.0F, 6.0F, new CubeDeformation(0.0F)).Mirror(false),
            PartPose.OffsetAndRotation(-1.8F, 0.85F, -2.6F, 0.8727F, 0.0F, -1.7017F));
        PartDefinition tail = body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(0, 13).AddBox(-2.0F, -1.5F, 0.0F, 4.0F, 3.0F, 7.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 1.0F, 4.0F));
        tail.AddOrReplaceChild("tail_fin", CubeListBuilder.Create().TexOffs(22, 13).AddBox(-4.0F, -0.5F, -1.0F, 8.0F, 1.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 0.0F, 6.0F));
        body.AddOrReplaceChild("back_fin", CubeListBuilder.Create().TexOffs(42, 0).AddBox(-0.5F, -1.0F, 1.0F, 1.0F, 3.0F, 4.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, -1.0F, -2.7F, 0.8727F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
