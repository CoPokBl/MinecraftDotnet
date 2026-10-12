namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ZombieNautilusCoralModel : NautilusModel {
    private readonly ModelPart _corals;

    public ZombieNautilusCoralModel(ModelPart root) : base(root) {
        ModelPart shell = Nautilus.GetChild("shell");
        _corals = shell.GetChild("corals");
    }

    public static new LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateBodyMesh();
        PartDefinition corals = mesh.Root.GetChild("root").GetChild("shell").AddOrReplaceChild("corals", CubeListBuilder.Create(), PartPose.Offset(8.0F, 4.5F, -8.0F));
        PartDefinition yellowCoral = corals.AddOrReplaceChild("yellow_coral", CubeListBuilder.Create(), PartPose.Offset(0.0F, -11.0F, 11.0F));
        yellowCoral.AddOrReplaceChild("yellow_coral_second", CubeListBuilder.Create().TexOffs(0, 85).AddBox(-4.5F, -3.5F, 0.0F, 6.0F, 8.0F, 0.0F),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 2.0F, 0.0F, -0.7854F, 0.0F));
        yellowCoral.AddOrReplaceChild("yellow_coral_first", CubeListBuilder.Create().TexOffs(0, 85).AddBox(-4.5F, -3.5F, 0.0F, 6.0F, 8.0F, 0.0F),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, 0.0F, 0.7854F, 0.0F));
        PartDefinition pinkCoral = corals.AddOrReplaceChild("pink_coral", CubeListBuilder.Create().TexOffs(-8, 94).AddBox(-4.5F, 4.5F, 0.0F, 6.0F, 0.0F, 8.0F),
            PartPose.Offset(-12.5F, -18.0F, 11.0F));
        pinkCoral.AddOrReplaceChild("pink_coral_second", CubeListBuilder.Create().TexOffs(-8, 94).AddBox(-3.0F, 0.0F, -4.0F, 6.0F, 0.0F, 8.0F),
            PartPose.OffsetAndRotation(-1.5F, 4.5F, 4.0F, 0.0F, 0.0F, 1.5708F));
        PartDefinition blueCoral = corals.AddOrReplaceChild("blue_coral", CubeListBuilder.Create(), PartPose.Offset(-14.0F, 0.0F, 5.5F));
        blueCoral.AddOrReplaceChild("blue_second", CubeListBuilder.Create().TexOffs(0, 102).AddBox(-3.5F, -5.5F, 0.0F, 5.0F, 10.0F, 0.0F),
            PartPose.OffsetAndRotation(0.0F, 0.0F, -2.0F, 0.0F, 0.7854F, 0.0F));
        blueCoral.AddOrReplaceChild("blue_first", CubeListBuilder.Create().TexOffs(0, 102).AddBox(-3.5F, -5.5F, 0.0F, 5.0F, 10.0F, 0.0F),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, 0.0F, -0.7854F, 0.0F));
        PartDefinition redCoral = corals.AddOrReplaceChild("red_coral", CubeListBuilder.Create(), PartPose.Offset(0.0F, 0.0F, 0.0F));
        redCoral.AddOrReplaceChild("red_coral_second", CubeListBuilder.Create().TexOffs(0, 112).AddBox(-2.5F, -5.5F, 0.0F, 4.0F, 10.0F, 0.0F),
            PartPose.OffsetAndRotation(-0.5F, -1.0F, 1.5F, 0.0F, -0.829F, 0.0F));
        redCoral.AddOrReplaceChild("red_coral_first", CubeListBuilder.Create().TexOffs(0, 112).AddBox(-4.5F, -5.5F, 0.0F, 6.0F, 10.0F, 0.0F),
            PartPose.OffsetAndRotation(0.0F, 0.0F, 0.0F, 0.0F, 0.7854F, 0.0F));
        return LayerDefinition.Create(mesh, 128, 128);
    }

    public override void SetupAnim(NautilusRenderState state) {
        base.SetupAnim(state);
        _corals.Visible = state.BodyArmorItem.IsAir();
    }
}
