using ClientLib.Entities;
using Minecraft.Data.ZombieNautilusVariant;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public class NautilusRenderState : LivingEntityRenderState {
    public ItemStack Saddle = ItemStack.Air;
    public ItemStack BodyArmorItem = ItemStack.Air;
    public IZombieNautilusVariant? Variant;

    /// <summary>The saddle and body armour, as both nautilus renderers read them.</summary>
    public static void ExtractEquipment(ClientEntity entity, NautilusRenderState state) {
        state.Saddle = entity.GetItemBySlot(EquipmentSlot.Saddle);
        state.BodyArmorItem = entity.GetItemBySlot(EquipmentSlot.Body);
    }
}

public sealed class NautilusRenderer : AgeableMobRenderer<NautilusRenderState, NautilusModel> {
    public NautilusRenderer(EntityRendererContext context)
        : base(new NautilusModel(NautilusModel.CreateBodyLayer().BakeRoot()), new NautilusModel(NautilusModel.CreateBabyBodyLayer().BakeRoot()), 0.7F) {
        EquipmentLayerRenderer equipment = EquipmentLayerRenderer.For(context);
        AddLayer(new SimpleEquipmentLayer<NautilusRenderState, NautilusModel, NautilusRenderState>(this, equipment,
            EquipmentClientInfo.LayerType.NautilusBody, state => state.BodyArmorItem, new NautilusArmorModel(NautilusArmorModel.CreateBodyLayer().BakeRoot()), null));
        AddLayer(new SimpleEquipmentLayer<NautilusRenderState, NautilusModel, NautilusRenderState>(this, equipment,
            EquipmentClientInfo.LayerType.NautilusSaddle, state => state.Saddle, new NautilusSaddleModel(NautilusSaddleModel.CreateSaddleLayer().BakeRoot()), null));
    }

    public override string GetTextureLocation(NautilusRenderState state) =>
        state.IsBaby ? "minecraft:textures/entity/nautilus/nautilus_baby.png" : "minecraft:textures/entity/nautilus/nautilus.png";

    public override void ExtractRenderState(ClientEntity entity, NautilusRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        NautilusRenderState.ExtractEquipment(entity, state);
    }
}
