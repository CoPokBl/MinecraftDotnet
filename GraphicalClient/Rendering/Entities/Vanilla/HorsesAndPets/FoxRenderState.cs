using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class FoxRenderState : HoldingEntityRenderState {
    public float HeadRollAngle;
    public float CrouchAmount;
    public bool IsCrouching;
    public bool IsSleeping;
    public bool IsSitting;
    public bool IsFaceplanted;
    public bool IsPouncing;
    public FoxVariant Variant = FoxVariant.Red;
}
