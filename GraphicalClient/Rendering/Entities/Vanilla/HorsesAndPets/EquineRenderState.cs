using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class EquineRenderState : LivingEntityRenderState {
    public ItemStack Saddle = ItemStack.Air;
    public ItemStack BodyArmorItem = ItemStack.Air;
    public bool IsRidden;
    public bool AnimateTail;
    public float EatAnimation;
    public float StandAnimation;
    public float FeedingAnimation;
}
