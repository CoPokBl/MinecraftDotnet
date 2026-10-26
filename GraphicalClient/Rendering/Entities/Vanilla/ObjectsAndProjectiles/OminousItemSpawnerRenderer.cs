using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>OminousItemSpawnerRenderer</c>, its <c>ItemClusterRenderState</c> being the dropped item's.</summary>
public sealed class OminousItemSpawnerRenderer : EntityRenderer<ItemEntityRenderState> {
    private const float RotationSpeed = 40.0F;
    private const int TicksScaling = 50;

    private readonly ItemRenderer _items;

    public OminousItemSpawnerRenderer(EntityRendererContext context) {
        _items = context.Items;
    }

    public override void ExtractRenderState(ClientEntity entity, ItemEntityRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ItemEntityRenderer.ExtractItemGroupRenderState(state, entity.Get(EntityDataFields.OminousItemSpawner.Item), _items, context);
    }

    public override void Submit(ItemEntityRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Item is not { } item) {
            return;
        }
        pose.Push();
        if (state.AgeInTicks <= TicksScaling) {
            float scale = Math.Min(state.AgeInTicks, TicksScaling) / TicksScaling;
            pose.Scale(scale, scale, scale);
        }
        float currentSpin = Mth.WrapDegrees(state.AgeInTicks * RotationSpeed);
        pose.RotateYDegrees(currentSpin);
        (System.Numerics.Vector3 min, System.Numerics.Vector3 max) = item.ModelBoundingBox;
        // Drawn at full brightness, the packed 15728880.
        ItemEntityRenderer.SubmitMultipleFromCount(_items, pose, context.Batch, item, state.Count, state.Seed, max.Z - min.Z, 15, 15);
        pose.Pop();
    }
}
