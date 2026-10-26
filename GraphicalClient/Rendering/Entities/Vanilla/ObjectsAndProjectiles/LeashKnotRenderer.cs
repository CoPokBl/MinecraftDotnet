using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>LeashKnotRenderer</c>. The leash itself, which <c>EntityRenderer</c> draws from the leashed mob, is not drawn here.</summary>
public sealed class LeashKnotRenderer : EntityRenderer<EntityRenderState> {
    private const string KnotLocation = "minecraft:textures/entity/lead_knot/lead_knot.png";

    private readonly LeashKnotModel _model = new(LeashKnotModel.CreateBodyLayer().BakeRoot());

    /// <summary><c>LeashFenceKnotEntity.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => distanceSqr < 1024.0;

    public override void Submit(EntityRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Scale(-1.0F, -1.0F, 1.0F);
        _model.SetupAnim(state);
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(context.Texture(KnotLocation), state));
        pose.Pop();
    }
}

/// <summary><c>LeashKnotModel</c>.</summary>
public sealed class LeashKnotModel : EntityModel<EntityRenderState> {
    public LeashKnotModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("knot", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-3.0F, -8.0F, -3.0F, 6.0F, 8.0F, 6.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
