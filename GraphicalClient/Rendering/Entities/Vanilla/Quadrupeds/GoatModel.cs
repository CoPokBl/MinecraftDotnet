namespace GraphicalClient.Rendering.Entities.Vanilla;

public class GoatModel(ModelPart root) : QuadrupedModel<GoatRenderState>(root) {
    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create()
            .TexOffs(2, 61).AddBox("right ear", -6.0F, -11.0F, -10.0F, 3.0F, 2.0F, 1.0F)
            .TexOffs(2, 61).Mirror().AddBox("left ear", 2.0F, -11.0F, -10.0F, 3.0F, 2.0F, 1.0F)
            .TexOffs(23, 52).AddBox("goatee", -0.5F, -3.0F, -14.0F, 0.0F, 7.0F, 5.0F), PartPose.Offset(1.0F, 14.0F, 0.0F));
        head.AddOrReplaceChild("left_horn", CubeListBuilder.Create().TexOffs(12, 55).AddBox(-0.01F, -16.0F, -10.0F, 2.0F, 7.0F, 2.0F), PartPose.Offset(0.0F, 0.0F, 0.0F));
        head.AddOrReplaceChild("right_horn", CubeListBuilder.Create().TexOffs(12, 55).AddBox(-2.99F, -16.0F, -10.0F, 2.0F, 7.0F, 2.0F),
            PartPose.Offset(0.0F, 0.0F, 0.0F));
        head.AddOrReplaceChild("nose", CubeListBuilder.Create().TexOffs(34, 46).AddBox(-3.0F, -4.0F, -8.0F, 5.0F, 7.0F, 10.0F),
            PartPose.OffsetAndRotation(0.0F, -8.0F, -8.0F, 0.9599F, 0.0F, 0.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(1, 1).AddBox(-4.0F, -17.0F, -7.0F, 9.0F, 11.0F, 16.0F)
            .TexOffs(0, 28).AddBox(-5.0F, -18.0F, -8.0F, 11.0F, 14.0F, 11.0F), PartPose.Offset(0.0F, 24.0F, 0.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(36, 29).AddBox(0.0F, 4.0F, 0.0F, 3.0F, 6.0F, 3.0F), PartPose.Offset(1.0F, 14.0F, 4.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(49, 29).AddBox(0.0F, 4.0F, 0.0F, 3.0F, 6.0F, 3.0F),
            PartPose.Offset(-3.0F, 14.0F, 4.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(49, 2).AddBox(0.0F, 0.0F, 0.0F, 3.0F, 10.0F, 3.0F),
            PartPose.Offset(1.0F, 14.0F, -6.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(35, 2).AddBox(0.0F, 0.0F, 0.0F, 3.0F, 10.0F, 3.0F),
            PartPose.Offset(-3.0F, 14.0F, -6.0F));
        return LayerDefinition.Create(mesh, 64, 64);
    }

    public override void SetupAnim(GoatRenderState state) {
        base.SetupAnim(state);
        Head.GetChild("left_horn").Visible = state.HasLeftHorn;
        Head.GetChild("right_horn").Visible = state.HasRightHorn;
        if (state.RammingXHeadRot != 0.0F) {
            Head.XRot = state.RammingXHeadRot;
        }
    }
}
