using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>WanderingTraderRenderer</c>. Its <c>CustomHeadLayer</c> is not ported.</summary>
public sealed class WanderingTraderRenderer : MobRenderer<VillagerRenderState, VillagerModel> {
    private readonly ItemRenderer _items;

    public WanderingTraderRenderer(EntityRendererContext context)
        : base(new VillagerModel(LayerDefinition.Create(VillagerModel.CreateBodyModel(), 64, 64).Apply(MeshTransformers.Scaling(0.9375F)).BakeRoot()), 0.5F) {
        _items = context.Items;
        AddLayer(new CrossedArmsItemLayer<VillagerRenderState, VillagerModel>(this, context.Items));
    }

    public override string GetTextureLocation(VillagerRenderState state) => "minecraft:textures/entity/wandering_trader/wandering_trader.png";

    public override void ExtractRenderState(ClientEntity entity, VillagerRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HoldingEntityRenderState.ExtractHoldingEntityRenderState(entity, state, _items);
        state.IsUnhappy = entity.Get(EntityDataFields.AbstractVillager.UnhappyCounter) > 0;
    }
}
