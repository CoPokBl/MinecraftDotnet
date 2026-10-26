using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>Adults only, with the cracks <c>armorTranslucent</c> over it as it wears.</summary>
public sealed class WolfArmorLayer(LivingEntityRenderer<WolfRenderState, WolfModel> parent, EquipmentLayerRenderer equipmentRenderer)
    : RenderLayer<WolfRenderState, WolfModel>(parent) {
    private static readonly Dictionary<CrackinessLevel, string> ArmorCrackLocations = new() {
        [CrackinessLevel.Low] = "minecraft:textures/entity/wolf/wolf_armor_crackiness_low.png",
        [CrackinessLevel.Medium] = "minecraft:textures/entity/wolf/wolf_armor_crackiness_medium.png",
        [CrackinessLevel.High] = "minecraft:textures/entity/wolf/wolf_armor_crackiness_high.png"
    };

    private readonly WolfModel _adultModel = new AdultWolfModel(AdultWolfModel.CreateBodyLayer(new CubeDeformation(0.2F)).BakeRoot());

    public override void Submit(PoseStack pose, EntityRenderContext context, WolfRenderState state) {
        ItemStack armorItem = state.BodyArmorItem;
        Identifier? assetId = EquipmentLayerRenderer.EquippableAssetId(armorItem);
        if (assetId != null && !state.IsBaby) {
            equipmentRenderer.RenderLayers(EquipmentClientInfo.LayerType.WolfBody, assetId.Value, _adultModel, state, armorItem, pose, context);
            MaybeRenderCracks(pose, context, armorItem, _adultModel, state);
        }
    }

    private static void MaybeRenderCracks(PoseStack pose, EntityRenderContext context, ItemStack armorItem, WolfModel model, WolfRenderState state) {
        CrackinessLevel crackiness = WolfArmorCrackiness(armorItem);
        if (crackiness != CrackinessLevel.None && context.Textures.Get(ArmorCrackLocations[crackiness]) is { } texture) {
            model.SetupAnim(state);
            model.RenderToBuffer(pose, context.TranslucentBatch, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, 0));
        }
    }

    /// <summary><c>Crackiness.Level</c>.</summary>
    private enum CrackinessLevel { None, Low, Medium, High }

    /// <summary><c>Crackiness.WOLF_ARMOR.byDamage</c>, through <c>ItemStack.isDamageableItem</c>.</summary>
    private static CrackinessLevel WolfArmorCrackiness(ItemStack item) {
        if (!item.Has(DataComponent.MaxDamage) || item.Has(DataComponent.Unbreakable) || !item.Has(DataComponent.Damage)) {
            return CrackinessLevel.None;
        }
        int maxDamage = item.Get(DataComponent.MaxDamage);
        // ItemStack.getDamageValue clamps to the item's range.
        int damage = Math.Clamp(item.Get(DataComponent.Damage), 0, maxDamage);
        float fraction = (float)(maxDamage - damage) / maxDamage;
        if (fraction < 0.32F) {
            return CrackinessLevel.High;
        }
        if (fraction < 0.69F) {
            return CrackinessLevel.Medium;
        }
        return fraction < 0.95F ? CrackinessLevel.Low : CrackinessLevel.None;
    }
}
