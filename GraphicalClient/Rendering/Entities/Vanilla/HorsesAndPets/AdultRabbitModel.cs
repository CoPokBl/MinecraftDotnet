namespace GraphicalClient.Rendering.Entities.Vanilla;

public class AdultRabbitModel : RabbitModel {
    public AdultRabbitModel(ModelPart root) : base(root, RabbitAnimation.Hop, RabbitAnimation.IdleHeadTilt) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -6.0F, -9.0F, 8.0F, 6.0F, 10.0F),
            PartPose.OffsetAndRotation(0.0F, 23.0F, 4.0F, -0.3927F, 0.0F, 0.0F));
        body.AddOrReplaceChild("tail", CubeListBuilder.Create().TexOffs(20, 16).AddBox(-2.0F, -3.0084F, -1.0125F, 4.0F, 4.0F, 4.0F),
            PartPose.Offset(0.0F, -4.9916F, 0.0125F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.5F, -3.0F, -4.0F, 5.0F, 5.0F, 5.0F),
            PartPose.OffsetAndRotation(0.0F, -5.2929F, -8.1213F, 0.3927F, 0.0F, 0.0F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-1.0F, -4.2929F, -0.1213F, 2.0F, 5.0F, 1.0F),
            PartPose.Offset(1.5F, -3.7071F, -0.8787F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(26, 0).AddBox(-1.0F, -4.2929F, -0.1213F, 2.0F, 5.0F, 1.0F),
            PartPose.Offset(-1.5F, -3.7071F, -0.8787F));
        PartDefinition frontLegs = body.AddOrReplaceChild("frontlegs", CubeListBuilder.Create(), PartPose.Offset(0.0F, -1.5349F, -6.3108F));
        frontLegs.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(36, 18).AddBox(-0.9F, -1.0F, -0.9F, 2.0F, 4.0F, 2.0F),
            PartPose.OffsetAndRotation(-2.0F, 1.9239F, 0.3827F, 0.3927F, 0.0F, 0.0F));
        frontLegs.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(44, 18).AddBox(-1.0F, -1.0F, -1.0F, 2.0F, 4.0F, 2.0F),
            PartPose.OffsetAndRotation(2.0F, 1.9239F, 0.4827F, 0.3927F, 0.0F, 0.0F));
        PartDefinition backLegs = root.AddOrReplaceChild("backlegs", CubeListBuilder.Create(), PartPose.Offset(0.0F, 23.0F, 4.0F));
        PartDefinition rightBackLeg = backLegs.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create(), PartPose.Offset(-3.0F, 0.5F, 0.0F));
        rightBackLeg.AddOrReplaceChild("right_haunch", CubeListBuilder.Create().TexOffs(20, 24).AddBox(-1.0F, 0.0F, -5.0F, 2.0F, 1.0F, 6.0F),
            PartPose.OffsetAndRotation(0.0F, -0.5F, 0.0F, 0.0F, 0.3927F, 0.0F));
        PartDefinition leftBackLeg = backLegs.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create(), PartPose.Offset(3.0F, 0.5F, 0.0F));
        leftBackLeg.AddOrReplaceChild("left_haunch", CubeListBuilder.Create().TexOffs(36, 24).AddBox(-1.0F, 0.0F, -5.0F, 2.0F, 1.0F, 6.0F),
            PartPose.OffsetAndRotation(0.0F, -0.5F, 0.0F, 0.0F, -0.3927F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }
}
