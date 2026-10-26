namespace GraphicalClient.Rendering.Entities.Vanilla;

public class DonkeyModel : AbstractEquineModel<DonkeyRenderState> {
    // Mutates the mesh it is given rather than copying it, as vanilla's does.
    private static readonly MeshTransformer DonkeyTransformer = mesh => {
        ModifyMesh(mesh.Root);
        return mesh;
    };

    private readonly ModelPart _leftChest;
    private readonly ModelPart _rightChest;

    public DonkeyModel(ModelPart root) : this(root, root.GetChild("head_parts"), root.GetChild("right_hind_leg"), root.GetChild("right_front_leg"),
        root.GetChild("left_hind_leg"), root.GetChild("left_front_leg"), root.GetChild("body").GetChild("tail")) { }

    public DonkeyModel(ModelPart root, ModelPart headParts, ModelPart rightHindLeg, ModelPart rightFrontLeg, ModelPart leftHindLeg, ModelPart leftFrontLeg,
        ModelPart tail) : base(root, headParts, rightHindLeg, rightFrontLeg, leftHindLeg, leftFrontLeg, tail) {
        _leftChest = Body.GetChild("left_chest");
        _rightChest = Body.GetChild("right_chest");
    }

    public static LayerDefinition CreateBodyLayer(float scale) =>
        CreateBodyLayer(CubeDeformation.None).Apply(DonkeyTransformer).Apply(MeshTransformers.Scaling(scale));

    public static LayerDefinition CreateSaddleLayer(float scale) =>
        EquineSaddleModel.CreateSaddleLayer().Apply(DonkeyTransformer).Apply(MeshTransformers.Scaling(scale));

    private static void ModifyMesh(PartDefinition root) {
        PartDefinition body = root.GetChild("body");
        CubeListBuilder chest = CubeListBuilder.Create().TexOffs(26, 21).AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 8.0F, 3.0F);
        body.AddOrReplaceChild("left_chest", chest, PartPose.OffsetAndRotation(6.0F, -8.0F, 0.0F, 0.0F, (float)(-Math.PI / 2), 0.0F));
        body.AddOrReplaceChild("right_chest", chest, PartPose.OffsetAndRotation(-6.0F, -8.0F, 0.0F, 0.0F, (float)(Math.PI / 2), 0.0F));
        PartDefinition head = root.GetChild("head_parts").GetChild("head");
        CubeListBuilder ear = CubeListBuilder.Create().TexOffs(0, 12).AddBox(-1.0F, -7.0F, 0.0F, 2.0F, 7.0F, 1.0F);
        head.AddOrReplaceChild("left_ear", ear, PartPose.OffsetAndRotation(1.25F, -10.0F, 4.0F, (float)(Math.PI / 12), 0.0F, (float)(Math.PI / 12)));
        head.AddOrReplaceChild("right_ear", ear, PartPose.OffsetAndRotation(-1.25F, -10.0F, 4.0F, (float)(Math.PI / 12), 0.0F, (float)(-Math.PI / 12)));
    }

    public override void SetupAnim(DonkeyRenderState state) {
        base.SetupAnim(state);
        _leftChest.Visible = state.HasChest;
        _rightChest.Visible = state.HasChest;
    }
}
