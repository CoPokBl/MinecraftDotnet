using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class WitchRenderState : HoldingEntityRenderState {
    public int EntityId;
    public bool IsHoldingItem, IsHoldingPotion;
}

public sealed class WitchRenderer : MobRenderer<WitchRenderState, WitchModel> {
    private readonly ItemRenderer _items;

    public WitchRenderer(EntityRendererContext context)
        : base(new WitchModel(WitchModel.CreateBodyLayer().Apply(MeshTransformers.Scaling(0.9375F)).BakeRoot()), 0.5F) {
        _items = context.Items;
        AddLayer(new WitchItemLayer(this, context.Items));
    }

    public override string GetTextureLocation(WitchRenderState state) => "minecraft:textures/entity/witch/witch.png";

    public override void ExtractRenderState(ClientEntity entity, WitchRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HoldingEntityRenderState.ExtractHoldingEntityRenderState(entity, state, _items);
        state.EntityId = entity.Id;
        Minecraft.Schemas.Items.ItemStack mainHandItem = entity.ItemInHand(Hand.MainHand);
        state.IsHoldingItem = !mainHandItem.IsAir();
        state.IsHoldingPotion = mainHandItem.Type.Identifier == Item.Potion.Identifier;
    }
}
