using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>VillagerDataHolderRenderState</c>.</summary>
public interface IVillagerDataHolderRenderState {
    VillagerData? GetVillagerData();
}

public class VillagerRenderState : HoldingEntityRenderState, IVillagerDataHolderRenderState {
    public bool IsUnhappy;
    public VillagerData? VillagerData;

    public VillagerData? GetVillagerData() => VillagerData;
}

/// <summary><c>VillagerRenderer</c>.</summary>
public sealed class VillagerRenderer : AgeableMobRenderer<VillagerRenderState, VillagerModel> {
    public static readonly CustomHeadLayer.Transforms CustomHeadTransforms = new(-0.1171875F, -0.07421875F, 1.0F);

    private readonly ItemRenderer _items;

    public VillagerRenderer(EntityRendererContext context)
        : base(new VillagerModel(LayerDefinition.Create(VillagerModel.CreateBodyModel(), 64, 64).Apply(MeshTransformers.Scaling(0.9375F)).BakeRoot()),
            new BabyVillagerModel(LayerDefinition.Create(BabyVillagerModel.CreateBodyModel(), 64, 64).BakeRoot()), 0.5F) {
        _items = context.Items;
        AddLayer(new CustomHeadLayer<VillagerRenderState, VillagerModel>(this, context.Items, CustomHeadTransforms));
        AddLayer(new VillagerProfessionLayer<VillagerRenderState, VillagerModel>(this, context.Pack, "villager",
            new VillagerModel(LayerDefinition.Create(VillagerModel.CreateNoHatModel(), 64, 64).Apply(MeshTransformers.Scaling(0.9375F)).BakeRoot()),
            new BabyVillagerModel(LayerDefinition.Create(BabyVillagerModel.CreateNoHatModel(), 64, 64).BakeRoot())));
        AddLayer(new CrossedArmsItemLayer<VillagerRenderState, VillagerModel>(this, context.Items));
    }

    protected override float GetShadowRadius(VillagerRenderState state) {
        float radius = base.GetShadowRadius(state);
        return state.IsBaby ? radius * 0.5F : radius;
    }

    public override string GetTextureLocation(VillagerRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/villager/villager_baby.png" : "minecraft:textures/entity/villager/villager.png";

    public override void ExtractRenderState(ClientEntity entity, VillagerRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HoldingEntityRenderState.ExtractHoldingEntityRenderState(entity, state, _items);
        state.IsUnhappy = entity.Get(EntityDataFields.AbstractVillager.UnhappyCounter) > 0;
        state.VillagerData = VillagerData.Read(entity, EntityDataFields.Villager.VillagerData, context.Client.Registry);
    }
}
