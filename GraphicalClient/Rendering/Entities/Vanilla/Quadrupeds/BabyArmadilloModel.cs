namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class BabyArmadilloModel : ArmadilloModel {
    public BabyArmadilloModel(ModelPart root)
        : base(root, BabyArmadilloAnimation.ArmadilloBabyWalk, BabyArmadilloAnimation.ArmadilloBabyRollOut, BabyArmadilloAnimation.ArmadilloBabyRollUp,
            BabyArmadilloAnimation.ArmadilloBabyPeek) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(0, 0).AddBox(-2.5F, -2.0F, -3.5F, 5.0F, 4.0F, 7.0F, new CubeDeformation(0.3F))
            .TexOffs(0, 11).AddBox(-2.5F, -2.0F, -3.0F, 5.0F, 4.0F, 6.0F), PartPose.Offset(0.0F, 20.0F, 0.5F));
        PartDefinition tail = body.AddOrReplaceChild("tail", CubeListBuilder.Create(), PartPose.Offset(0.0F, 0.0F, 3.4F));
        tail.AddOrReplaceChild("right_ear_cube", CubeListBuilder.Create().TexOffs(22, 11).AddBox(-0.5F, -0.5F, -2.0F, 1.0F, 1.0F, 4.0F),
            PartPose.OffsetAndRotation(0.0F, 1.5F, 1.0F, -1.0472F, 0.0F, 0.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create(), PartPose.Offset(0.0F, 0.0F, -3.2F));
        PartDefinition headGroup = head.AddOrReplaceChild("head_cube", CubeListBuilder.Create().TexOffs(20, 17).AddBox(-1.0F, -2.0F, -4.0F, 2.0F, 2.0F, 4.0F),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, 0.7417649F, 0.0F, 0.0F));
        headGroup.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(28, 8).Mirror().AddBox(-1.8F, -2.0F, 0.0F, 2.0F, 3.0F, 0.0F).Mirror(false),
            PartPose.OffsetAndRotation(-1.0F, -2.0F, -0.3F, -0.4363F, -0.1134F, 0.0524F));
        headGroup.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(28, 8).AddBox(-0.2F, -2.0F, 0.0F, 2.0F, 3.0F, 0.0F),
            PartPose.OffsetAndRotation(1.0F, -2.0F, -0.3F, -0.4363F, 0.1134F, -0.0524F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(20, 27).Mirror().AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F).Mirror(false),
            PartPose.Offset(-1.5F, 22.0F, 2.5F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(20, 27).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F),
            PartPose.Offset(1.5F, 22.0F, 2.5F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(20, 23).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F),
            PartPose.Offset(1.5F, 22.0F, -1.5F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(24, 0).Mirror().AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 2.0F, 2.0F).Mirror(false),
            PartPose.Offset(-1.5F, 22.0F, -1.5F));
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 25).AddBox(-3.0F, -3.0F, -3.0F, 6.0F, 6.0F, 6.0F, new CubeDeformation(0.3F)),
            PartPose.Offset(0.0F, 20.7F, 0.5F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
