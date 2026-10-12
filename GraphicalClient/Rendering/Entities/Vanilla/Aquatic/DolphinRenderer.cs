using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class DolphinRenderState : HoldingEntityRenderState {
    public bool IsMoving;
}

public sealed class DolphinRenderer : AgeableMobRenderer<DolphinRenderState, DolphinModel> {
    private readonly ItemRenderer _items;

    public DolphinRenderer(EntityRendererContext context)
        : base(new DolphinModel(DolphinModel.CreateBodyLayer().BakeRoot()), new DolphinModel(BabyDolphinModel.CreateBodyLayer().BakeRoot()), 0.7F) {
        _items = context.Items;
        AddLayer(new DolphinCarryingItemLayer(this, context.Items));
    }

    public override string GetTextureLocation(DolphinRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/dolphin/dolphin_baby.png" : "minecraft:textures/entity/dolphin/dolphin.png";

    public override void ExtractRenderState(ClientEntity entity, DolphinRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // Dolphin.getAgeScale.
        state.AgeScale = state.IsBaby ? 0.65F : 1.0F;
        HoldingEntityRenderState.ExtractHoldingEntityRenderState(entity, state, _items);
        state.IsMoving = entity.DeltaMovement.HorizontalDistanceSqr() > 1.0E-7;
    }
}
