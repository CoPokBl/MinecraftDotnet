using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>FireworkRocketRenderState</c>.</summary>
public class FireworkRocketRenderState : EntityRenderState {
    public bool IsShotAtAngle;
    public bool IsAttachedToEntity;
    public ItemStackModel? Item;
}

/// <summary><c>FireworkEntityRenderer</c>.</summary>
public sealed class FireworkEntityRenderer : EntityRenderer<FireworkRocketRenderState> {
    private readonly ItemRenderer _items;

    public FireworkEntityRenderer(EntityRendererContext context) {
        _items = context.Items;
    }

    /// <summary><c>FireworkRocketEntity.isAttachedToEntity</c>.</summary>
    private static bool IsAttachedToEntity(ClientEntity entity) => entity.Get(EntityDataFields.FireworkRocketEntity.AttachedToTarget) is { Present: true };

    /// <summary><c>FireworkRocketEntity.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => distanceSqr < 4096.0 && !IsAttachedToEntity(entity);

    public override void Submit(FireworkRocketRenderState state, PoseStack pose, EntityRenderContext context) {
        // FireworkRocketEntity.shouldRender: one carrying a gliding player is drawn by nothing.
        if (state.IsAttachedToEntity || state.Item is not { } item) {
            return;
        }
        pose.Push();
        CameraOrientation.Apply(pose, context.Camera);
        if (state.IsShotAtAngle) {
            pose.RotateZDegrees(180.0F);
            pose.RotateYDegrees(180.0F);
            pose.RotateXDegrees(90.0F);
        }
        _items.Submit(item, ItemDisplayContext.Ground, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }

    public override void ExtractRenderState(ClientEntity entity, FireworkRocketRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsShotAtAngle = entity.Get(EntityDataFields.FireworkRocketEntity.ShotAtAngle);
        state.IsAttachedToEntity = IsAttachedToEntity(entity);
        // The synced stack, which the server leaves out while it is the default rocket.
        IItem item = entity.Has(EntityDataFields.FireworkRocketEntity.IdFireworksItem)
            ? entity.Get(EntityDataFields.FireworkRocketEntity.IdFireworksItem)?.Type ?? Item.Air
            : Item.FireworkRocket;
        state.Item = item.Equals(Item.Air) ? null : _items.Resolve(item, ItemDisplayContext.Ground);
    }
}
