using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using EquippableSlot = Minecraft.Data.Components.Types.EquippableComponent.Slot;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>HumanoidArmorLayer</c>'s statics.</summary>
public static class HumanoidArmorLayer {
    /// <summary><c>shouldRender</c>: an equippable with an asset, for this slot.</summary>
    public static bool ShouldRender(ItemStack itemStack, EquipmentSlot slot) {
        if (itemStack.IsAir() || !itemStack.Has(DataComponent.Equippable)) {
            return false;
        }
        Minecraft.Data.Components.Types.EquippableComponent.Data equippable = itemStack.Get(DataComponent.Equippable);
        return equippable.Model != null && equippable.Slot == ToEquippableSlot(slot);
    }

    public static EquippableSlot ToEquippableSlot(EquipmentSlot slot) => slot switch {
        EquipmentSlot.MainHand => EquippableSlot.MainHand,
        EquipmentSlot.OffHand => EquippableSlot.OffHand,
        EquipmentSlot.Boots => EquippableSlot.Feet,
        EquipmentSlot.Leggings => EquippableSlot.Legs,
        EquipmentSlot.Chestplate => EquippableSlot.Chest,
        EquipmentSlot.Helmet => EquippableSlot.Head,
        EquipmentSlot.Body => EquippableSlot.Body,
        _ => EquippableSlot.Saddle
    };
}

/// <summary><c>HumanoidArmorLayer</c>.</summary>
public sealed class HumanoidArmorLayer<S, M, A> : RenderLayer<S, M>
    where S : HumanoidRenderState, new()
    where M : EntityModel<S>
    where A : HumanoidModel<S> {
    private readonly ArmorModelSet<A> _modelSet;
    private readonly ArmorModelSet<A> _babyModelSet;
    private readonly EquipmentLayerRenderer _equipmentRenderer;

    public HumanoidArmorLayer(LivingEntityRenderer<S, M> renderer, ArmorModelSet<A> modelSet, EquipmentLayerRenderer equipmentRenderer)
        : this(renderer, modelSet, modelSet, equipmentRenderer) { }

    public HumanoidArmorLayer(LivingEntityRenderer<S, M> renderer, ArmorModelSet<A> modelSet, ArmorModelSet<A> babyModelSet, EquipmentLayerRenderer equipmentRenderer)
        : base(renderer) {
        _modelSet = modelSet;
        _babyModelSet = babyModelSet;
        _equipmentRenderer = equipmentRenderer;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
        RenderArmorPiece(pose, context, state.ChestEquipment, EquipmentSlot.Chestplate, state);
        RenderArmorPiece(pose, context, state.LegsEquipment, EquipmentSlot.Leggings, state);
        RenderArmorPiece(pose, context, state.FeetEquipment, EquipmentSlot.Boots, state);
        RenderArmorPiece(pose, context, state.HeadEquipment, EquipmentSlot.Helmet, state);
    }

    private void RenderArmorPiece(PoseStack pose, EntityRenderContext context, ItemStack itemStack, EquipmentSlot slot, S state) {
        if (!HumanoidArmorLayer.ShouldRender(itemStack, slot)) {
            return;
        }
        Identifier assetId = itemStack.Get(DataComponent.Equippable).Model!.Value;
        A model = GetArmorModel(state, slot);
        EquipmentClientInfo.LayerType layerType = state.IsBaby && state.EntityType != EntityType.ArmorStand
            ? EquipmentClientInfo.LayerType.HumanoidBaby
            : UsesInnerModel(slot) ? EquipmentClientInfo.LayerType.HumanoidLeggings : EquipmentClientInfo.LayerType.Humanoid;
        _equipmentRenderer.RenderLayers(layerType, assetId, model, state, itemStack, pose, context);
    }

    private A GetArmorModel(S state, EquipmentSlot slot) => (state.IsBaby ? _babyModelSet : _modelSet).Get(slot);

    private static bool UsesInnerModel(EquipmentSlot slot) => slot == EquipmentSlot.Leggings;
}

/// <summary><c>ArmorModelSet</c>.</summary>
public sealed record ArmorModelSet<T>(T Head, T Chest, T Legs, T Feet) {
    public T Get(EquipmentSlot slot) => slot switch {
        EquipmentSlot.Helmet => Head,
        EquipmentSlot.Chestplate => Chest,
        EquipmentSlot.Leggings => Legs,
        EquipmentSlot.Boots => Feet,
        _ => throw new InvalidOperationException("No model for slot: " + slot)
    };

    public ArmorModelSet<U> Map<U>(Func<T, U> mapper) => new(mapper(Head), mapper(Chest), mapper(Legs), mapper(Feet));
}

public static class ArmorModelSet {
    /// <summary><c>ArmorModelSet.bake</c>.</summary>
    public static ArmorModelSet<M> Bake<M>(ArmorModelSet<LayerDefinition> layers, Func<ModelPart, M> factory) => layers.Map(layer => factory(layer.BakeRoot()));
}

/// <summary><c>PartDefinition</c>'s armour mesh trimming, which the framework's port leaves out.</summary>
public static class PartDefinitionRetain {
    /// <summary><c>retainPartsAndChildren</c>: every part not named is emptied of cubes, keeping its children.</summary>
    public static void RetainPartsAndChildren(this PartDefinition part, IReadOnlySet<string> parts) {
        foreach ((string name, PartDefinition child) in part.Children.ToList()) {
            if (!parts.Contains(name)) {
                part.AddOrReplaceChild(name, CubeListBuilder.Create(), child.Pose).RetainPartsAndChildren(parts);
            }
        }
    }

    /// <summary><c>retainExactParts</c>: a named part keeps its cubes but its children are emptied; every other part is emptied.</summary>
    public static void RetainExactParts(this PartDefinition part, IReadOnlySet<string> parts) {
        foreach ((string name, PartDefinition child) in part.Children.ToList()) {
            if (parts.Contains(name)) {
                child.ClearRecursively();
            }
            else {
                part.AddOrReplaceChild(name, CubeListBuilder.Create(), child.Pose).RetainExactParts(parts);
            }
        }
    }
}
