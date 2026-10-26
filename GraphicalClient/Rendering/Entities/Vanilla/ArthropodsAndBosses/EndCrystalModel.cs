namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class EndCrystalModel : EntityModel<EndCrystalRenderState> {
    private static readonly float Sin45 = (float)Math.Sin(Math.PI / 4);

    public readonly ModelPart Base, OuterGlass, InnerGlass, Cube;

    public EndCrystalModel(ModelPart root) : base(root) {
        Base = root.GetChild("base");
        OuterGlass = root.GetChild("outer_glass");
        InnerGlass = OuterGlass.GetChild("inner_glass");
        Cube = InnerGlass.GetChild("cube");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        CubeListBuilder glassCube = CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -4.0F, -4.0F, 8.0F, 8.0F, 8.0F);
        PartDefinition outerGlass = root.AddOrReplaceChild("outer_glass", glassCube, PartPose.Offset(0.0F, 24.0F, 0.0F));
        PartDefinition innerGlass = outerGlass.AddOrReplaceChild("inner_glass", glassCube, PartPose.Zero.WithScale(0.875F));
        innerGlass.AddOrReplaceChild("cube", CubeListBuilder.Create().TexOffs(32, 0).AddBox(-4.0F, -4.0F, -4.0F, 8.0F, 8.0F, 8.0F), PartPose.Zero.WithScale(0.765625F));
        root.AddOrReplaceChild("base", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-6.0F, 0.0F, -6.0F, 12.0F, 4.0F, 12.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(EndCrystalRenderState state) {
        base.SetupAnim(state);
        Base.Visible = state.ShowsBottom;
        float animationSpeed = state.AgeInTicks * 3.0F;
        float crystalY = EndCrystalRenderer.GetY(state.AgeInTicks) * 16.0F;
        OuterGlass.Y += crystalY / 2.0F;
        OuterGlass.RotateBy(ModelPartRotateBy.Quat.RotationYDegrees(animationSpeed).RotateAxis((float)(Math.PI / 3), Sin45, 0.0F, Sin45));
        InnerGlass.RotateBy(ModelPartRotateBy.Quat.AngleAxis((float)(Math.PI / 3), Sin45, 0.0F, Sin45).RotateY(animationSpeed * (float)(Math.PI / 180.0)));
        Cube.RotateBy(ModelPartRotateBy.Quat.AngleAxis((float)(Math.PI / 3), Sin45, 0.0F, Sin45).RotateY(animationSpeed * (float)(Math.PI / 180.0)));
    }
}
