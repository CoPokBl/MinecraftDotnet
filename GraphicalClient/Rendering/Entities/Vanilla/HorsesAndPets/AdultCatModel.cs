namespace GraphicalClient.Rendering.Entities.Vanilla;

public class AdultCatModel : AdultFelineModel<CatRenderState> {
    public static readonly MeshTransformer CatTransformer = MeshTransformers.Scaling(0.8F);
    public static readonly CubeDeformation CollarDeformation = new(0.01F);

    public AdultCatModel(ModelPart root) : base(root) { }
}
