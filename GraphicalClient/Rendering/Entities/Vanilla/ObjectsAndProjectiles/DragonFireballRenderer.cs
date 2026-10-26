using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>DragonFireballRenderer</c>.</summary>
public sealed class DragonFireballRenderer : EntityRenderer<EntityRenderState> {
    private const string TextureLocation = "minecraft:textures/entity/enderdragon/dragon_fireball.png";

    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => ThrownItemRenderer.HurtingProjectileShouldRenderAtSqrDistance(entity, distanceSqr);

    public override void ExtractRenderState(ClientEntity entity, EntityRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.BlockLight = 15;
    }

    public override void Submit(EntityRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Scale(2.0F, 2.0F, 2.0F);
        CameraOrientation.Apply(pose, context.Camera);
        // vertex: (x - 0.5, y - 0.25, 0) for each corner.
        context.Batch.FlatQuad(pose, 0.0F - 0.5F, 0 - 0.25F, 1.0F - 0.5F, 1 - 0.25F, 0, 0, 1, 1, new ModelDrawState(context.Texture(TextureLocation), state));
        pose.Pop();
    }
}
