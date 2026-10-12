using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>FishingHookRenderState</c>, without the line's origin, as the line is not drawn.</summary>
public class FishingHookRenderState : EntityRenderState {
    public bool HasPlayerOwner;
}

/// <summary>
/// <c>FishingHookRenderer</c>. The line to the rod is not drawn: it is <c>RenderTypes.lines</c> geometry,
/// screen space lines of a fixed pixel width, which the entity batch has no primitive for.
/// </summary>
public sealed class FishingHookRenderer : EntityRenderer<FishingHookRenderState> {
    private const string TextureLocation = "minecraft:textures/entity/fishing/fishing_hook.png";

    /// <summary><c>FishingHook.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => distanceSqr < 4096.0;

    public override bool AffectedByCulling(ClientEntity entity) => false;

    public override void ExtractRenderState(ClientEntity entity, FishingHookRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // getPlayerOwner: the spawn data names the owner's entity id.
        state.HasPlayerOwner = context.Client.Entities.TryGetValue(entity.SpawnData, out ClientEntity? owner) && owner.Type.Equals(EntityType.Player);
    }

    public override void Submit(FishingHookRenderState state, PoseStack pose, EntityRenderContext context) {
        // shouldRender: nothing without a player holding the rod.
        if (!state.HasPlayerOwner) {
            return;
        }
        pose.Push();
        pose.Scale(0.5F, 0.5F, 0.5F);
        CameraOrientation.Apply(pose, context.Camera);
        // vertex: (x - 0.5, y - 0.5, 0) for each corner.
        context.Batch.FlatQuad(pose, 0.0F - 0.5F, 0 - 0.5F, 1.0F - 0.5F, 1 - 0.5F, 0, 0, 1, 1, new ModelDrawState(context.Texture(TextureLocation), state) { NoOutline = true });
        pose.Pop();
    }
}
