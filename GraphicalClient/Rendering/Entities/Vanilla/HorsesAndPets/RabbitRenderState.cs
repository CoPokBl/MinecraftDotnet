using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class RabbitRenderState : LivingEntityRenderState {
    public float JumpCompletion;
    public bool IsToast;
    public RabbitVariant Variant = RabbitVariant.Brown;
    public AnimationState HopAnimationState = new();
    public AnimationState IdleHeadTiltAnimationState = new();
}
