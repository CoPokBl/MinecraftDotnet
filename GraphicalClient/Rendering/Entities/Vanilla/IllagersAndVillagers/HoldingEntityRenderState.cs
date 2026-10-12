using ClientLib.Entities;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class HoldingEntityRenderState : LivingEntityRenderState {
    public ItemStackModel? HeldItem;
    public ItemStack HeldItemStack = ItemStack.Air;

    /// <summary><c>HoldingEntityRenderState.extractHoldingEntityRenderState</c>: the main hand item, posed as on the ground.</summary>
    public static void ExtractHoldingEntityRenderState(ClientEntity entity, HoldingEntityRenderState state, ItemRenderer items) {
        state.HeldItemStack = entity.ItemInHand(Hand.MainHand);
        state.HeldItem = state.HeldItemStack.IsAir() ? null : items.Resolve(state.HeldItemStack, ItemDisplayContext.Ground, entity, Hand.MainHand);
    }
}
