namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>NoopRenderer</c>: for an entity that has nothing to draw, so it does not fall back to the built in art.</summary>
public sealed class NoopRenderer : EntityRenderer<EntityRenderState> {
    public override void Submit(EntityRenderState state, PoseStack pose, EntityRenderContext context) { }
}
