namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class AdultTurtleModel : TurtleModel {
    private readonly ModelPart _eggBelly;

    public AdultTurtleModel(ModelPart root) : base(root) {
        _eggBelly = root.GetChild("egg_belly");
    }

    public override void SetupAnim(TurtleRenderState state) {
        base.SetupAnim(state);
        _eggBelly.Visible = state.HasEgg;
        if (_eggBelly.Visible) {
            Root.Y--;
        }
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(3, 0).AddBox(-3.0F, -1.0F, -3.0F, 6.0F, 5.0F, 6.0F), PartPose.Offset(0.0F, 19.0F, -10.0F));
        root.AddOrReplaceChild("body", CubeListBuilder.Create()
            .TexOffs(7, 37).AddBox("shell", -9.5F, 3.0F, -10.0F, 19.0F, 20.0F, 6.0F)
            .TexOffs(31, 1).AddBox("belly", -5.5F, 3.0F, -13.0F, 11.0F, 18.0F, 3.0F), PartPose.OffsetAndRotation(0.0F, 11.0F, -10.0F, MathF.PI / 2, 0.0F, 0.0F));
        root.AddOrReplaceChild("egg_belly", CubeListBuilder.Create().TexOffs(70, 33).AddBox(-4.5F, 3.0F, -14.0F, 9.0F, 18.0F, 1.0F),
            PartPose.OffsetAndRotation(0.0F, 11.0F, -10.0F, MathF.PI / 2, 0.0F, 0.0F));
        root.AddOrReplaceChild("right_hind_leg", CubeListBuilder.Create().TexOffs(1, 23).AddBox(-2.0F, 0.0F, 0.0F, 4.0F, 1.0F, 10.0F),
            PartPose.Offset(-3.5F, 22.0F, 11.0F));
        root.AddOrReplaceChild("left_hind_leg", CubeListBuilder.Create().TexOffs(1, 12).AddBox(-2.0F, 0.0F, 0.0F, 4.0F, 1.0F, 10.0F),
            PartPose.Offset(3.5F, 22.0F, 11.0F));
        root.AddOrReplaceChild("right_front_leg", CubeListBuilder.Create().TexOffs(27, 30).AddBox(-13.0F, 0.0F, -2.0F, 13.0F, 1.0F, 5.0F),
            PartPose.Offset(-5.0F, 21.0F, -4.0F));
        root.AddOrReplaceChild("left_front_leg", CubeListBuilder.Create().TexOffs(27, 24).AddBox(0.0F, 0.0F, -2.0F, 13.0F, 1.0F, 5.0F),
            PartPose.Offset(5.0F, 21.0F, -4.0F));
        return LayerDefinition.Create(mesh, 128, 64);
    }
}
