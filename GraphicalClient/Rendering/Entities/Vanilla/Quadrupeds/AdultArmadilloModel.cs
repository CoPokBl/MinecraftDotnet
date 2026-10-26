namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class AdultArmadilloModel : ArmadilloModel {
    public AdultArmadilloModel(ModelPart root)
        : base(root, ArmadilloAnimation.ArmadilloWalk, ArmadilloAnimation.ArmadilloRollOut, ArmadilloAnimation.ArmadilloRollUp, ArmadilloAnimation.ArmadilloPeek) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(0, 20).AddBox(-4.0F, -7.0F, -10.0F, 8.0F, 8.0F, 12.0F, new CubeDeformation(0.3F))
            .TexOffs(0, 40).AddBox(-4.0F, -7.0F, -10.0F, 8.0F, 8.0F, 12.0F, new CubeDeformation(0.0F)), PartPose.Offset(0.0F, 21.0F, 4.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(44, 53).AddBox(-0.5F, -0.0865F, 0.0933F, 1.0F, 6.0F, 1.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, -3.0F, 1.0F, 0.5061F, 0.0F, 0.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create(), PartPose.Offset(0.0F, -2.0F, -11.0F));
        head.AddOrReplaceChild("head_cube", CubeListBuilder.Create().TexOffs(43, 15).AddBox(-1.5F, -1.0F, -1.0F, 3.0F, 5.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, -0.3927F, 0.0F, 0.0F));
        PartDefinition rightEar = head.AddOrReplaceChild("right_ear", CubeListBuilder.Create(), PartPose.Offset(-1.0F, -1.0F, 0.0F));
        rightEar.AddOrReplaceChild("right_ear_cube", CubeListBuilder.Create().TexOffs(43, 10).AddBox(-2.0F, -3.0F, 0.0F, 2.0F, 5.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(-0.5F, 0.0F, -0.6F, 0.1886F, -0.3864F, -0.0718F));
        PartDefinition leftEar = head.AddOrReplaceChild("left_ear", CubeListBuilder.Create(), PartPose.Offset(1.0F, -2.0F, 0.0F));
        leftEar.AddOrReplaceChild("left_ear_cube", CubeListBuilder.Create().TexOffs(47, 10).AddBox(0.0F, -3.0F, 0.0F, 2.0F, 5.0F, 0.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.5F, 1.0F, -0.6F, 0.1886F, 0.3864F, 0.0718F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(51, 31).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-2.0F, 21.0F, 4.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(42, 31).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.0F, 21.0F, 4.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(51, 43).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(-2.0F, 21.0F, -4.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(42, 43).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(2.0F, 21.0F, -4.0F));
        root.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-5.0F, -10.0F, -6.0F, 10.0F, 10.0F, 10.0F, new CubeDeformation(0.0F)),
            PartPose.Offset(0.0F, 24.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
