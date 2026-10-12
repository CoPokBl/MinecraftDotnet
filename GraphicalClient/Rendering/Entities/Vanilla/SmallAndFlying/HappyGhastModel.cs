namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class HappyGhastModel : EntityModel<HappyGhastRenderState> {
    public static readonly MeshTransformer BabyTransformer = MeshTransformers.Scaling(0.2375F);
    private const float BodySqueeze = 0.9375F;
    private readonly ModelPart[] _tentacles = new ModelPart[9];
    private readonly ModelPart _body;

    public HappyGhastModel(ModelPart root) : base(root) {
        _body = root.GetChild("body");
        for (int i = 0; i < _tentacles.Length; i++) {
            _tentacles[i] = _body.GetChild(GhastModel.Tentacle(i));
        }
    }

    public static LayerDefinition CreateBodyLayer(bool isBaby, CubeDeformation deformation) {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition body = root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-8.0F, -8.0F, -8.0F, 16.0F, 16.0F, 16.0F, deformation),
            PartPose.Offset(0.0F, 16.0F, 0.0F));
        if (isBaby) {
            body.AddOrReplaceChild("inner_body", CubeListBuilder.Create().TexOffs(0, 32).AddBox(-8.0F, -16.0F, -8.0F, 16.0F, 16.0F, 16.0F, deformation.Extend(-0.5F)),
                PartPose.Offset(0.0F, 8.0F, 0.0F));
        }
        body.AddOrReplaceChild(GhastModel.Tentacle(0), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F, deformation),
            PartPose.Offset(-3.75F, 7.0F, -5.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(1), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 7.0F, 2.0F, deformation),
            PartPose.Offset(1.25F, 7.0F, -5.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(2), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 4.0F, 2.0F, deformation),
            PartPose.Offset(6.25F, 7.0F, -5.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(3), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F, deformation),
            PartPose.Offset(-6.25F, 7.0F, 0.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(4), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F, deformation),
            PartPose.Offset(-1.25F, 7.0F, 0.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(5), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 7.0F, 2.0F, deformation),
            PartPose.Offset(3.75F, 7.0F, 0.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(6), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 8.0F, 2.0F, deformation),
            PartPose.Offset(-3.75F, 7.0F, 5.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(7), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 8.0F, 2.0F, deformation),
            PartPose.Offset(1.25F, 7.0F, 5.0F));
        body.AddOrReplaceChild(GhastModel.Tentacle(8), CubeListBuilder.Create().TexOffs(0, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 5.0F, 2.0F, deformation),
            PartPose.Offset(6.25F, 7.0F, 5.0F));
        return LayerDefinition.Create(mesh, 64, 64).Apply(MeshTransformers.Scaling(4.0F));
    }

    public override void SetupAnim(HappyGhastRenderState state) {
        base.SetupAnim(state);
        if (!state.BodyItem.IsAir()) {
            _body.XScale = BodySqueeze;
            _body.YScale = BodySqueeze;
            _body.ZScale = BodySqueeze;
        }
        GhastModel.AnimateTentacles(state, _tentacles);
    }
}
