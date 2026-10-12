namespace GraphicalClient.Rendering.Entities.Vanilla;

public class SheepModel(ModelPart root) : QuadrupedModel<SheepRenderState>(root) {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateBodyMesh(12, false, true, CubeDeformation.None);
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -4.0F, -6.0F, 6.0F, 6.0F, 8.0F), PartPose.Offset(0.0F, 6.0F, -8.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(28, 8).AddBox(-4.0F, -10.0F, -7.0F, 8.0F, 16.0F, 6.0F),
            PartPose.OffsetAndRotation(0.0F, 5.0F, 2.0F, MathF.PI / 2, 0.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(SheepRenderState state) {
        base.SetupAnim(state);
        Head.Y = Head.Y + state.HeadEatPositionScale * 9.0F * state.AgeScale;
        Head.XRot = state.HeadEatAngleScale;
    }
}
