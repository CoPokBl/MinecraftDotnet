using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ThrownItemRenderState</c>.</summary>
public class ThrownItemRenderState : EntityRenderState {
    public ItemStackModel? Item;
}

/// <summary>
/// <c>ThrownItemRenderer</c>. <c>ItemSupplier.getItem</c> is the class's synced stack, which the server
/// leaves out of the spawn data while it is the class's default item, so that default is passed in.
/// </summary>
public sealed class ThrownItemRenderer : EntityRenderer<ThrownItemRenderState> {
    private readonly ItemRenderer _items;
    private readonly EntityDataField<ItemStack> _itemField;
    private readonly IItem _defaultItem;
    private readonly float _scale;
    private readonly bool _fullBright;
    private readonly Func<ClientEntity, double, bool?>? _shouldRenderAtSqrDistance;

    public ThrownItemRenderer(EntityRendererContext context, EntityDataField<ItemStack> itemField, IItem defaultItem, float scale = 1.0F, bool fullBright = false,
        Func<ClientEntity, double, bool?>? shouldRenderAtSqrDistance = null) {
        _items = context.Items;
        _itemField = itemField;
        _defaultItem = defaultItem;
        _scale = scale;
        _fullBright = fullBright;
        _shouldRenderAtSqrDistance = shouldRenderAtSqrDistance;
    }

    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => _shouldRenderAtSqrDistance?.Invoke(entity, distanceSqr);

    /// <summary><c>AbstractHurtingProjectile.shouldRenderAtSqrDistance</c>: four times the usual distance, whatever the view scale.</summary>
    public static bool? HurtingProjectileShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) {
        double size = BoxSize(entity) * 4.0;
        size *= 64.0;
        return distanceSqr < size * size;
    }

    /// <summary>
    /// <c>ThrowableProjectile.shouldRenderAtSqrDistance</c> and its copies in <c>EyeOfEnder</c>, <c>Fireball</c> and
    /// <c>WindCharge</c>: hidden for its first ticks while it is still in the thrower's face.
    /// </summary>
    public static bool? HiddenWhileCloseThenHurtingProjectile(ClientEntity entity, double distanceSqr) =>
        entity.TickCount < 2 && distanceSqr < 12.25 ? false : HurtingProjectileShouldRenderAtSqrDistance(entity, distanceSqr);

    public override void Submit(ThrownItemRenderState state, PoseStack pose, EntityRenderContext context) {
        if (state.Item is not { } item) {
            return;
        }
        pose.Push();
        pose.Scale(_scale, _scale, _scale);
        CameraOrientation.Apply(pose, context.Camera);
        _items.Submit(item, ItemDisplayContext.Ground, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }

    public override void ExtractRenderState(ClientEntity entity, ThrownItemRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        if (_fullBright) {
            state.BlockLight = 15;
        }
        IItem item = entity.Has(_itemField) ? entity.Get(_itemField)?.Type ?? Item.Air : _defaultItem;
        state.Item = item.Equals(Item.Air) ? null : _items.Resolve(item, ItemDisplayContext.Ground);
    }
}
