namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BabyWolfModel(ModelPart root) : WolfModel(root) {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(0, 12).AddBox(-2.99F, -3.25F, -3.0F, 6.0F, 5.0F, 5.0F, new CubeDeformation(0.025F))
            .TexOffs(17, 12).AddBox(-1.5F, -0.24F, -5.0F, 3.0F, 2.0F, 2.0F, new CubeDeformation(0.0F)), PartPose.Offset(0.0F, 18.25F, -4.0F));
        head.AddOrReplaceChild("right_ear", CubeListBuilder.Create().TexOffs(0, 5).AddBox(-1.0F, -1.0F, -0.5F, 2.0F, 2.0F, 1.0F), PartPose.Offset(-2.0F, -4.25F, -0.5F));
        head.AddOrReplaceChild("left_ear", CubeListBuilder.Create().TexOffs(20, 5).AddBox(-1.0F, -1.0F, -0.5F, 2.0F, 2.0F, 1.0F), PartPose.Offset(2.0F, -4.25F, -0.5F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -2.0F, -4.0F, 6.0F, 4.0F, 8.0F), PartPose.Offset(0.0F, 19.0F, 0.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(0, 22).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F),
            PartPose.Offset(-1.5F, 21.0F, 3.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(8, 22).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F), PartPose.Offset(1.5F, 21.0F, 3.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F),
            PartPose.Offset(-1.5F, 21.0F, -3.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(20, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 3.0F, 2.0F),
            PartPose.Offset(1.5F, 21.0F, -3.0F));
        PartDefinition tail = root.AddOrReplaceChild("tail", CubeListBuilder.Create(), PartPose.OffsetAndRotation(0.0F, 19.0F, 3.0F, -0.5236F, 0.0F, 0.0F));
        tail.AddOrReplaceChild("tail_r1", CubeListBuilder.Create().TexOffs(22, 16).AddBox(-1.0F, -5.7F, -1.0F, 2.0F, 6.0F, 2.0F, new CubeDeformation(0.0F)),
            PartPose.OffsetAndRotation(0.0F, -0.6F, 0.2F, -3.1F, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 32, 32);
    }

    protected override void ShakeOffWater(WolfRenderState state) {
        base.ShakeOffWater(state);
        Head.ZRot = state.HeadRollAngle + state.GetBodyRollAngle(0.0F);
        Tail.ZRot = state.GetBodyRollAngle(-0.2F);
    }

    protected override void SetSittingPose(WolfRenderState state) {
        base.SetSittingPose(state);
        Body.XRot--;
    }
}
