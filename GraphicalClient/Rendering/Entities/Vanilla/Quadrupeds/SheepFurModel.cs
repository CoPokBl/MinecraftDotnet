namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class SheepFurModel(ModelPart root) : QuadrupedModel<SheepRenderState>(root) {
    public static LayerDefinition CreateFurLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -4.0F, -4.0F, 6.0F, 6.0F, 6.0F, new CubeDeformation(0.6F)),
            PartPose.Offset(0.0F, 6.0F, -8.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(28, 8).AddBox(-4.0F, -10.0F, -7.0F, 8.0F, 16.0F, 6.0F, new CubeDeformation(1.75F)),
            PartPose.OffsetAndRotation(0.0F, 5.0F, 2.0F, MathF.PI / 2, 0.0F, 0.0F));
        CubeListBuilder leg = CubeListBuilder.Create().TexOffs(0, 16).AddBox(-2.0F, 0.0F, -2.0F, 4.0F, 6.0F, 4.0F, new CubeDeformation(0.5F));
        root.AddOrReplaceChild("right_hind_leg", leg, PartPose.Offset(-3.0F, 12.0F, 7.0F));
        root.AddOrReplaceChild("left_hind_leg", leg, PartPose.Offset(3.0F, 12.0F, 7.0F));
        root.AddOrReplaceChild("right_front_leg", leg, PartPose.Offset(-3.0F, 12.0F, -5.0F));
        root.AddOrReplaceChild("left_front_leg", leg, PartPose.Offset(3.0F, 12.0F, -5.0F));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(SheepRenderState state) {
        base.SetupAnim(state);
        Head.Y = Head.Y + state.HeadEatPositionScale * 9.0F * state.AgeScale;
        Head.XRot = state.HeadEatAngleScale;
    }
}
