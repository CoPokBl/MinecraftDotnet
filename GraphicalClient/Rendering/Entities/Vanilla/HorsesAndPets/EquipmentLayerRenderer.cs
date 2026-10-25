using System.Runtime.CompilerServices;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>EquipmentLayerRenderer</c>, with <c>EquipmentAssetManager</c>'s lookup folded in.</summary>
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
        if (layerType != EquipmentClientInfo.LayerType.HumanoidBaby && itemStack.GetOrNull(DataComponent.Trim) is { } trim) {
            List<string> textures = [];
            List<uint> colors = [];
            foreach (EquipmentClientInfo.Layer layer in layers) {
                int color = GetColorForLayer(layer, dyeColor);
                if (color != 0) {
                    textures.Add(layer.UsePlayerTexture && playerTextureOverride != null ? playerTextureOverride : layer.GetTextureLocation(layerType));
                    colors.Add(unchecked((uint)color));
                }
            }
            RenderTrimmed(textures, colors, TrimSpriteId(trim, layerType, equipmentAssetId), trim.Pattern.Decal, renderFoil, model, state, pose, context);
            return;
        }
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

    /// <summary><c>TrimSpriteKey.spriteId</c>, through <c>ArmorTrim.layerAssetId</c>.</summary>
    private static Identifier TrimSpriteId(TrimComponent.Data trim, EquipmentClientInfo.LayerType layerType, Identifier equipmentAssetId) {
        string suffix = trim.Material.OverrideArmorAssets.TryGetValue(equipmentAssetId, out string? asset) ? asset : trim.Material.AssetName;
        Identifier pattern = trim.Pattern.AssetId;
        return new Identifier(pattern.Namespace, $"{EquipmentClientInfo.TrimAssetPrefix(layerType)}/{pattern.Key}_{suffix}");
    }

    /// <summary>
    /// The layers and then the trim sprite from the <c>armor_trims</c> atlas, as one texture drawn once: vanilla
    /// draws each as the same model again and the later wins its depth test, which a coplanar redraw here
    /// would lose. Each is <c>armorCutoutNoCull</c>, so a texel under alpha 0.1 leaves what is beneath; a decal
    /// pattern tests for equal depth, so it only covers texels a layer drew. A trim sprite the atlas lacks is
    /// the missing checks over the whole model, as vanilla's atlas answers.
    /// </summary>
    private void RenderTrimmed<S>(List<string> textures, List<uint> colors, Identifier trimSprite, bool decal, bool renderFoil, EntityModel<S> model, S state,
        PoseStack pose, EntityRenderContext context) where S : EntityRenderState {
        System.Text.StringBuilder key = new("trimmed:");
        for (int i = 0; i < textures.Count; i++) {
            key.Append(textures[i]).Append('#').Append(colors[i].ToString("X8")).Append('|');
        }
        key.Append(trimSprite).Append(decal ? "|decal" : "");
        EntityTextures entityTextures = context.Textures;
        EntityTexture? texture = entityTextures.Get(key.ToString(), () => {
            List<(TextureImage Image, uint Color)> layers = [];
            for (int i = 0; i < textures.Count; i++) {
                if (entityTextures.LoadIdentifier(textures[i]) is { } image) {
                    layers.Add((image, colors[i]));
                }
            }
            TextureImage trim = _pack.AtlasPermutation("armor_trims", trimSprite) ?? EntityTextures.MissingImage();
            return ComposeTrimmed(layers, trim, decal);
        });
        if (texture == null) {
            return;
        }
        model.SetupAnim(state);
        ModelDrawState draw = new(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, 0);
        model.RenderToBuffer(pose, context.Batch, draw);
        if (renderFoil && textures.Count > 0) {
            model.RenderToBuffer(pose, new GlintSink(context.Batch, GlintType.Armor), draw);
        }
    }

    /// <summary>The image <see cref="RenderTrimmed{S}"/> draws, at the first layer's size; images of other sizes are sampled across it.</summary>
    public static TextureImage ComposeTrimmed(IReadOnlyList<(TextureImage Image, uint Color)> layers, TextureImage trim, bool decal) {
        int width = layers.Count > 0 ? layers[0].Image.Width : trim.Width, height = layers.Count > 0 ? layers[0].Image.Height : trim.Height;
        byte[] rgba = new byte[width * height * 4];
        foreach ((TextureImage image, uint color) in layers) {
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    int from = Texel(image, x, y, width, height), to = (y * width + x) * 4;
                    if (image.Rgba[from + 3] < CutoutAlpha) {
                        continue;
                    }
                    for (int c = 0; c < 3; c++) {
                        rgba[to + c] = (byte)((image.Rgba[from + c] * (int)(color >> (16 - c * 8) & 0xFF) + 127) / 255);
                    }
                    rgba[to + 3] = image.Rgba[from + 3];
                }
            }
        }
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                int from = Texel(trim, x, y, width, height), to = (y * width + x) * 4;
                if (trim.Rgba[from + 3] >= CutoutAlpha && (!decal || rgba[to + 3] >= CutoutAlpha)) {
                    Array.Copy(trim.Rgba, from, rgba, to, 4);
                }
            }
        }
        return new TextureImage(width, height, rgba);
    }

    /// <summary>The least alpha, out of 255, that passes the armour pipelines' <c>ALPHA_CUTOUT</c> of 0.1.</summary>
    private const int CutoutAlpha = 26;

    private static int Texel(TextureImage image, int x, int y, int width, int height) =>
        (y * image.Height / height * image.Width + x * image.Width / width) * 4;

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
