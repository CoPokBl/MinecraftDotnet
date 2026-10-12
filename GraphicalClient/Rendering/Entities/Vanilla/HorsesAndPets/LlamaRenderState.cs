using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class LlamaRenderState : LivingEntityRenderState {
    public LlamaVariant Variant = LlamaVariant.Creamy;
    public bool HasChest;
    public ItemStack BodyItem = ItemStack.Air;
    public bool IsTraderLlama;
}
