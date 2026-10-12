namespace GraphicalClient.Rendering.Entities.Vanilla;

public class BabyCatModel : BabyFelineModel<CatRenderState> {
    public static readonly MeshTransformer CollarTransformer = MeshTransformers.Scaling(1.01F);

    public BabyCatModel(ModelPart root) : base(root) { }
}
