using System.Runtime.CompilerServices;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>EquipmentLayerRenderer</c>, with <c>EquipmentAssetManager</c>'s lookup folded in. Armour trims (a
/// sprite from the trims atlas, which is not loaded) are not drawn.
/// </summary>
public sealed class EquipmentLayerRenderer {
    private static readonly ConditionalWeakTable<ResourcePackSource, EquipmentLayerRenderer> ByPack = new();

    private readonly ResourcePackSource _pack;
    private readonly Dictionary<Identifier, EquipmentClientInfo> _assets = new();

    private EquipmentLayerRenderer(ResourcePackSource pack) {
        _pack = pack;
    }

    /// <summary>The one renderer for this pack, as vanilla's context hands every renderer the same one.</summary>
    public static EquipmentLayerRenderer For(EntityRendererContext context) => ByPack.GetValue(context.Pack, pack => new EquipmentLayerRenderer(pack));

    /// <summary><c>EquipmentAssetManager.get</c>.</summary>
    private EquipmentClientInfo GetAsset(Identifier assetId) {
        if (!_assets.TryGetValue(assetId, out EquipmentClientInfo? info)) {
            byte[]? json = _pack.ReadFile($"assets/{assetId.Namespace}/equipment/{assetId.Key}.json");
            info = json == null ? EquipmentClientInfo.Missing : EquipmentClientInfo.Parse(json);
            _assets[assetId] = info;
        }
        return info;
    }

    /// <summary>Whether the asset has any layer of the type, as <c>CapeLayer.hasLayer</c> asks.</summary>
    public bool HasLayers(Identifier assetId, EquipmentClientInfo.LayerType layerType) => GetAsset(assetId).GetLayers(layerType).Count > 0;

    /// <summary>
    /// <c>renderLayers</c>: each layer is drawn with <c>armorCutoutNoCull</c> and no overlay. A layer that uses the
    /// player's texture takes <paramref name="playerTextureOverride"/> when there is one.
    /// </summary>
    public void RenderLayers<S>(EquipmentClientInfo.LayerType layerType, Identifier equipmentAssetId, EntityModel<S> model, S state, ItemStack itemStack,
        PoseStack pose, EntityRenderContext context, string? playerTextureOverride = null) where S : EntityRenderState {
        IReadOnlyList<EquipmentClientInfo.Layer> layers = GetAsset(equipmentAssetId).GetLayers(layerType);
        if (layers.Count == 0) {
            return;
        }
        int dyeColor = DyedColorOrDefault(itemStack, 0);
        bool renderFoil = ClientLib.Interaction.ItemModelProperties.HasFoil(itemStack);
        bool modelPosed = false;
        foreach (EquipmentClientInfo.Layer layer in layers) {
            int color = GetColorForLayer(layer, dyeColor);
            if (color == 0) {
                continue;
            }
            EntityTexture? texture = context.Textures.Get(layer.UsePlayerTexture && playerTextureOverride != null
                ? playerTextureOverride
                : layer.GetTextureLocation(layerType));
            if (texture == null) {
                continue;
            }
            if (!modelPosed) {
                model.SetupAnim(state);
                modelPosed = true;
            }
            ModelDrawState draw = new(texture, unchecked((uint)color), state.SkyLight, state.BlockLight, 0);
            model.RenderToBuffer(pose, context.Batch, draw);
            // armorEntityGlint over the first layer drawn only.
            if (renderFoil) {
                model.RenderToBuffer(pose, new GlintSink(context.Batch, GlintType.Armor), draw);
            }
            renderFoil = false;
        }
    }

    /// <summary><c>DyedItemColor.getOrDefault</c>.</summary>
    private static int DyedColorOrDefault(ItemStack itemStack, int defaultColor) {
        if (itemStack.IsAir() || !itemStack.Has(DataComponent.DyedColor)) {
            return defaultColor;
        }
        TextColor color = itemStack.Get(DataComponent.DyedColor);
        return Opaque(color.R << 16 | color.G << 8 | color.B);
    }

    private static int Opaque(int rgb) => unchecked((int)0xFF000000) | rgb;

    private static int GetColorForLayer(EquipmentClientInfo.Layer layer, int dyeColor) {
        if (layer.Dyeable != null) {
            int colorWhenUndyed = layer.Dyeable.ColorWhenUndyed is { } undyed ? Opaque(undyed) : 0;
            return dyeColor != 0 ? dyeColor : colorWhenUndyed;
        }
        return -1;
    }

    /// <summary><c>Equippable.assetId</c> of a stack, or null when it has none.</summary>
    public static Identifier? EquippableAssetId(ItemStack itemStack) =>
        !itemStack.IsAir() && itemStack.Has(DataComponent.Equippable) ? itemStack.Get(DataComponent.Equippable).Model : null;
}
