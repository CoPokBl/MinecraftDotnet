namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BabyRabbitModel : RabbitModel {
    public BabyRabbitModel(ModelPart root) : base(root, BabyRabbitAnimation.Hop, BabyRabbitAnimation.IdleHeadTilt) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create(), PartPose.Offset(0.0F, 23.0F, 1.6F));
        body.AddOrReplaceChild("body_r1", CubeListBuilder.Create().TexOffs(0, 8).AddBox(-2.0F, -2.0F, -3.0F, 4.0F, 3.0F, 6.0F),
            PartPose.OffsetAndRotation(0.0F, -2.0F, -1.6F, -0.5236F, 0.0F, 0.0F));
        PartDefinition tail = body.AddOrReplaceChild("tail", CubeListBuilder.Create(), PartPose.Offset(0.0F, -2.2F, 2.0F));
        tail.AddOrReplaceChild("tail_r1", CubeListBuilder.Create().TexOffs(0, 21).AddBox(-1.4F, -2.0268F, -1.0177F, 3.0F, 3.0F, 3.0F),
            PartPose.OffsetAndRotation(-0.1F, 0.0F, 0.0F, -0.5236F, 0.0F, 0.0F));
        PartDefinition head = body.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-2.5F, -3.0F, -3.0F, 5.0F, 4.0F, 4.0F),
            PartPose.Offset(0.0F, -5.0F, -2.6F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(18, 0).AddBox(-1.0F, -3.5F, -0.5F, 2.0F, 4.0F, 1.0F), PartPose.Offset(-1.5F, -3.5F, -0.5F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(24, 0).AddBox(-1.0F, -3.5F, -0.5F, 2.0F, 4.0F, 1.0F), PartPose.Offset(1.5F, -3.5F, -0.5F));
        PartDefinition frontLegs = body.AddOrReplaceChild("frontlegs", CubeListBuilder.Create(), PartPose.Offset(0.0F, -2.5F, -2.6F));
        PartDefinition leftFrontLeg = frontLegs.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create(),
            PartPose.OffsetAndRotation(1.0F, 1.0F, -0.5F, 0.3927F, 0.0F, 0.0F));
        leftFrontLeg.AddOrReplaceChild("left_front_leg_r1", CubeListBuilder.Create().TexOffs(18, 8).AddBox(-0.5F, -1.5F, -0.5F, 1.0F, 3.0F, 1.0F),
            PartPose.OffsetAndRotation(0.0F, 1.0F, 0.0F, -0.3927F, 0.0F, 0.0F));
        PartDefinition rightFrontLeg = frontLegs.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create(),
            PartPose.OffsetAndRotation(-1.0F, 1.0F, -0.5F, 0.3927F, 0.0F, 0.0F));
        rightFrontLeg.AddOrReplaceChild("right_front_leg_r1", CubeListBuilder.Create().TexOffs(14, 8).AddBox(-0.5F, -1.5F, -0.5F, 1.0F, 3.0F, 1.0F),
            PartPose.OffsetAndRotation(0.0F, 1.0F, 0.0F, -0.3927F, 0.0F, 0.0F));
        PartDefinition backLegs = root.AddOrReplaceChild("backlegs", CubeListBuilder.Create(), PartPose.Offset(0.0F, 23.0F, 2.0F));
        PartDefinition leftBackLeg = backLegs.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create(),
            PartPose.OffsetAndRotation(1.5F, 0.5F, 0.5F, 0.0F, 3.1416F, 0.0F));
        leftBackLeg.AddOrReplaceChild("left_haunch", CubeListBuilder.Create().TexOffs(10, 17).AddBox(-2.0F, -0.5F, 0.0F, 2.0F, 1.0F, 3.0F),
            PartPose.OffsetAndRotation(1.0F, 0.0F, 0.5F, 0.0F, -0.7854F, 0.0F));
        PartDefinition rightBackLeg = backLegs.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create(),
            PartPose.OffsetAndRotation(-1.5F, 0.5F, 0.5F, 0.0F, 3.1416F, 0.0F));
        rightBackLeg.AddOrReplaceChild("right_haunch", CubeListBuilder.Create().TexOffs(0, 17).AddBox(-2.0F, -0.5F, 0.0F, 2.0F, 1.0F, 3.0F),
            PartPose.OffsetAndRotation(0.5F, 0.0F, -0.9F, 0.0F, 0.7854F, 0.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
