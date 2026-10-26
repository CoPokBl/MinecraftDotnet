using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class StriderRenderState : LivingEntityRenderState {
    public ItemStack Saddle = ItemStack.Air;
    public bool IsSuffocating;
    public bool IsRidden;
}

public sealed class StriderRenderer : AgeableMobRenderer<StriderRenderState, StriderModel> {
    public StriderRenderer(EntityRendererContext context)
        : base(new AdultStriderModel(AdultStriderModel.CreateBodyLayer().BakeRoot()), new BabyStriderModel(BabyStriderModel.CreateBodyLayer().BakeRoot()), 0.5F) {
        AddLayer(new SimpleEquipmentLayer<StriderRenderState, StriderModel, StriderRenderState>(this, EquipmentLayerRenderer.For(context),
            EquipmentClientInfo.LayerType.StriderSaddle, state => state.Saddle, new AdultStriderModel(AdultStriderModel.CreateBodyLayer().BakeRoot()), null));
    }

    protected override float GetShadowRadius(StriderRenderState state) {
        float radius = base.GetShadowRadius(state);
        return state.IsBaby ? radius * 0.5F : radius;
    }

    public override string GetTextureLocation(StriderRenderState state) =>
        state.IsSuffocating
            ? state.IsBaby ? "minecraft:textures/entity/strider/strider_cold_baby.png" : "minecraft:textures/entity/strider/strider_cold.png"
            : state.IsBaby ? "minecraft:textures/entity/strider/strider_baby.png" : "minecraft:textures/entity/strider/strider.png";

    public override void ExtractRenderState(ClientEntity entity, StriderRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.Saddle = entity.GetItemBySlot(EquipmentSlot.Saddle);
        state.IsSuffocating = entity.Get(EntityDataFields.Strider.Suffocating);
        state.IsRidden = entity.Passengers.Length > 0;
    }

    protected override bool IsShaking(StriderRenderState state) => base.IsShaking(state) || state.IsSuffocating;
}
