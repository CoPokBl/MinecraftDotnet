using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Newtonsoft.Json.Linq;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>Hud.extractCameraOverlays</c>: the vignette, the spyglass scope or what is worn over the eyes, the
/// powder snow frost, then the nether portal or nausea's overlay.
/// </summary>
public sealed unsafe class CameraOverlays : IDisposable {
    private static readonly Identifier PumpkinBlur = "minecraft:misc/pumpkinblur";

    /// <summary><c>EquipmentSlot.values()</c>, the order equipped camera overlays are drawn in.</summary>
    private static readonly (EquipmentSlot Slot, EquippableComponent.Slot Equippable)[] EquipmentSlots = [
        (EquipmentSlot.MainHand, EquippableComponent.Slot.MainHand), (EquipmentSlot.OffHand, EquippableComponent.Slot.OffHand),
        (EquipmentSlot.Boots, EquippableComponent.Slot.Feet), (EquipmentSlot.Leggings, EquippableComponent.Slot.Legs),
        (EquipmentSlot.Chestplate, EquippableComponent.Slot.Chest), (EquipmentSlot.Helmet, EquippableComponent.Slot.Head),
        (EquipmentSlot.Body, EquippableComponent.Slot.Body), (EquipmentSlot.Saddle, EquippableComponent.Slot.Saddle)
    ];

    private readonly GL _gl;
    private readonly ResourcePackSource? _pack;
    private readonly EntityAtlasSprite _portal;
    private readonly uint _atlas;
    private readonly uint _vignette, _spyglassScope, _powderSnowOutline, _nausea;
    private readonly Dictionary<Identifier, uint> _equippedOverlays = new();

    /// <summary><c>Hud.vignetteBrightness</c>.</summary>
    private float _vignetteBrightness = 1.0F;

    /// <summary><c>Hud.scopeScale</c>.</summary>
    private float _scopeScale;

    public CameraOverlays(GL gl, ResourcePackSource? pack, EntityTextures atlas, TextureAnimator animator, BlockModels models) {
        _gl = gl;
        _pack = pack;
        _portal = new EntityAtlasSprite(atlas, animator, models, models.Particle(Block.NetherPortal.StateId));
        _atlas = atlas.Handle;
        _vignette = LoadTexture(gl, pack, "assets/minecraft/textures/misc/vignette.png", DevArt.Vignette, true);
        _spyglassScope = LoadTexture(gl, pack, "assets/minecraft/textures/misc/spyglass_scope.png", DevArt.SpyglassScope, false);
        _powderSnowOutline = LoadTexture(gl, pack, "assets/minecraft/textures/misc/powder_snow_outline.png", DevArt.PowderSnowOutline, false);
        _nausea = LoadTexture(gl, pack, "assets/minecraft/textures/misc/nausea.png", DevArt.Nausea, true);
    }

    /// <summary>
    /// A <c>ReloadableTexture</c>: the pack's file, sampled as its <c>.mcmeta</c> asks, or else the developer
    /// art, blurred where vanilla's own file asks for it.
    /// </summary>
    internal static uint LoadTexture(GL gl, ResourcePackSource? pack, string file, Func<TextureImage> devArt, bool devArtBlur) {
        bool blur = devArtBlur, clamp = false;
        TextureImage? image = pack?.LoadFirstFrame(file);
        if (image != null) {
            (blur, clamp) = Sampler(pack!.ReadFile(file + ".mcmeta"));
        }
        image ??= devArt();
        uint texture = gl.CreateTexture(TextureTarget.Texture2D);
        gl.TextureStorage2D(texture, 1, SizedInternalFormat.Rgba8, (uint)image.Width, (uint)image.Height);
        fixed (byte* p = image.Rgba) {
            gl.TextureSubImage2D(texture, 0, 0, 0, (uint)image.Width, (uint)image.Height, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        int filter = (int)(blur ? TextureMinFilter.Linear : TextureMinFilter.Nearest);
        int wrap = (int)(clamp ? TextureWrapMode.ClampToEdge : TextureWrapMode.Repeat);
        gl.TextureParameter(texture, TextureParameterName.TextureMinFilter, filter);
        gl.TextureParameter(texture, TextureParameterName.TextureMagFilter, filter);
        gl.TextureParameter(texture, TextureParameterName.TextureWrapS, wrap);
        gl.TextureParameter(texture, TextureParameterName.TextureWrapT, wrap);
        return texture;
    }

    /// <summary><c>TextureMetadataSection</c>'s <c>blur</c> and <c>clamp</c>, both false when the file or the key is missing.</summary>
    private static (bool Blur, bool Clamp) Sampler(byte[]? meta) {
        if (meta == null) {
            return (false, false);
        }
        try {
            JToken? texture = JObject.Parse(System.Text.Encoding.UTF8.GetString(meta))["texture"];
            return (texture?.Value<bool?>("blur") ?? false, texture?.Value<bool?>("clamp") ?? false);
        }
        catch (Exception e) when (e is Newtonsoft.Json.JsonException or InvalidCastException or FormatException) {
            return (false, false);
        }
    }

    /// <summary>Brings the portal sprite to the frame the texture array shows; after each animator tick.</summary>
    public void Update() => _portal.Update();

    /// <summary><c>Hud.tick</c>'s <c>updateVignetteBrightness</c>: the vignette eases a hundredth of the way towards the dark at the camera's eyes.</summary>
    public void Tick(ClientEntity camera, ClientLevel level, int skyDarkening) {
        int x = (int)Math.Floor(camera.Position.X), y = (int)Math.Floor(camera.Position.Y + camera.CurrentEyeHeight), z = (int)Math.Floor(camera.Position.Z);
        float levelBrightness = Lighting.Brightness(level.DimensionType.AmbientLight, level.MaxLocalRawBrightness(x, y, z, skyDarkening));
        float brightness = Math.Clamp(1.0F - levelBrightness, 0.0F, 1.0F);
        _vignetteBrightness += (brightness - _vignetteBrightness) * 0.01F;
    }

    /// <param name="deltaTicks"><c>DeltaTracker.getGameTimeDeltaTicks</c>: the ticks this frame took.</param>
    public void Render(GuiRenderer gui, LocalPlayer player, ClientLevel level, ClientEntity? camera, bool firstPerson, bool vignette,
        float screenEffectScale, float deltaTicks, float partialTick) {
        if (vignette) {
            RenderVignette(gui, level.WorldBorder, camera);
        }
        _scopeScale = Entities.Mth.Lerp(0.5F * deltaTicks, _scopeScale, 1.125F);
        if (firstPerson) {
            if (player.IsScoping) {
                RenderSpyglassOverlay(gui, _scopeScale);
            }
            else {
                _scopeScale = 0.5F;
                foreach ((EquipmentSlot slot, EquippableComponent.Slot equippableSlot) in EquipmentSlots) {
                    ItemStack item = player.EquippedItem(slot);
                    if (ItemComponents.Get(item, DataComponent.Equippable) is { CameraOverlay: { } overlay } equippable && equippable.Slot == equippableSlot) {
                        RenderTextureOverlay(gui, EquippedOverlay(overlay), 1.0F);
                    }
                }
            }
        }
        if (player.TicksFrozen > 0) {
            RenderTextureOverlay(gui, _powderSnowOutline, player.PercentFrozen);
        }
        float portalIntensity = Entities.Mth.Lerp(partialTick, player.OPortalEffectIntensity, player.PortalEffectIntensity);
        float nauseaIntensity = player.GetEffectBlendFactor(PotionEffectType.Nausea, partialTick);
        if (portalIntensity > 0.0F) {
            RenderPortalOverlay(gui, portalIntensity);
        }
        else if (nauseaIntensity > 0.0F) {
            if (screenEffectScale < 1.0F) {
                float overlayStrength = nauseaIntensity * (1.0F - screenEffectScale);
                RenderConfusionOverlay(gui, overlayStrength);
            }
        }
        // Drawn now, so the crosshair's inverting blend that follows takes none of it.
        gui.Flush();
    }

    /// <summary>An equippable's <c>camera_overlay</c>, <c>textures/</c> and the id's path, loaded the first time it is worn.</summary>
    private uint EquippedOverlay(Identifier overlay) {
        if (!_equippedOverlays.TryGetValue(overlay, out uint texture)) {
            string file = $"assets/{overlay.Namespace}/textures/{overlay.Key}.png";
            texture = LoadTexture(_gl, _pack, file, overlay.Equals(PumpkinBlur) ? DevArt.PumpkinBlur : EntityTextures.MissingImage, overlay.Equals(PumpkinBlur));
            _equippedOverlays[overlay] = texture;
        }
        return texture;
    }

    /// <summary><c>extractTextureOverlay</c>.</summary>
    private static void RenderTextureOverlay(GuiRenderer gui, uint texture, float alpha) =>
        gui.Textured(texture, 0, 0, gui.ScaledWidth, gui.ScaledHeight, 0, 0, 1, 1, Channel(alpha) << 24 | 0xFFFFFF);

    /// <summary><c>extractSpyglassOverlay</c>: the scope, square in the middle, and black around it.</summary>
    private void RenderSpyglassOverlay(GuiRenderer gui, float scale) {
        int guiWidth = gui.ScaledWidth, guiHeight = gui.ScaledHeight;
        float srcWidth = Math.Min(guiWidth, guiHeight);
        float ratio = Math.Min(guiWidth / srcWidth, guiHeight / srcWidth) * scale;
        int width = (int)Math.Floor(srcWidth * ratio);
        int height = (int)Math.Floor(srcWidth * ratio);
        int left = (guiWidth - width) / 2;
        int top = (guiHeight - height) / 2;
        int right = left + width;
        int bottom = top + height;
        gui.Textured(_spyglassScope, left, top, width, height, 0, 0, 1, 1);
        gui.Rect(0, bottom, guiWidth, guiHeight - bottom, 0xFF000000);
        gui.Rect(0, 0, guiWidth, top, 0xFF000000);
        gui.Rect(0, top, left, bottom - top, 0xFF000000);
        gui.Rect(right, top, guiWidth - right, bottom - top, 0xFF000000);
    }

    /// <summary>
    /// <c>extractVignette</c>: the screen's edges darkened by how dark it is at the camera, and tinted red
    /// as the camera nears the world border or the border nears it.
    /// </summary>
    private void RenderVignette(GuiRenderer gui, WorldBorder worldBorder, ClientEntity? camera) {
        float borderWarningStrength = 0.0F;
        if (camera != null) {
            float distToBorder = (float)worldBorder.DistanceToBorder(camera.Position.X, camera.Position.Z);
            double movingBlocksThreshold = Math.Min(worldBorder.LerpSpeed * worldBorder.WarningTime, Math.Abs(worldBorder.LerpTarget - worldBorder.Size));
            double warningDistance = Math.Max((double)worldBorder.WarningBlocks, movingBlocksThreshold);
            if (distToBorder < warningDistance) {
                borderWarningStrength = 1.0F - (float)(distToBorder / warningDistance);
            }
        }
        float brightness = Math.Clamp(_vignetteBrightness, 0.0F, 1.0F);
        uint color;
        if (borderWarningStrength > 0.0F) {
            borderWarningStrength = Math.Clamp(borderWarningStrength, 0.0F, 1.0F);
            float red = brightness * (1.0F - borderWarningStrength);
            float greenBlue = brightness + (1.0F - brightness) * borderWarningStrength;
            color = 0xFF000000 | Channel(red) << 16 | Channel(greenBlue) << 8 | Channel(greenBlue);
        }
        else {
            color = 0xFF000000 | Channel(brightness) << 16 | Channel(brightness) << 8 | Channel(brightness);
        }
        gui.TexturedVignette(_vignette, 0, 0, gui.ScaledWidth, gui.ScaledHeight, color);
    }

    /// <summary><c>extractPortalOverlay</c>: the nether portal model's particle sprite over the screen.</summary>
    private void RenderPortalOverlay(GuiRenderer gui, float alpha) {
        if (alpha < 1.0F) {
            alpha *= alpha;
            alpha *= alpha;
            alpha = alpha * 0.8F + 0.2F;
        }
        EntityTexture sprite = _portal.Texture;
        gui.Textured(_atlas, 0, 0, gui.ScaledWidth, gui.ScaledHeight, sprite.U(0), sprite.V(0), sprite.U(1), sprite.V(1), Channel(alpha) << 24 | 0xFFFFFF);
    }

    /// <summary><c>extractConfusionOverlay</c>: scaled about the centre from twice the screen at no strength to the screen at full.</summary>
    private void RenderConfusionOverlay(GuiRenderer gui, float strength) {
        float screenWidth = gui.ScaledWidth, screenHeight = gui.ScaledHeight;
        float size = Entities.Mth.Lerp(strength, 2.0F, 1.0F);
        float red = 0.2F * strength;
        float green = 0.4F * strength;
        float blue = 0.2F * strength;
        gui.TexturedAdditive(_nausea, screenWidth / 2.0F * (1.0F - size), screenHeight / 2.0F * (1.0F - size), screenWidth * size, screenHeight * size,
            0xFF000000 | Channel(red) << 16 | Channel(green) << 8 | Channel(blue));
    }

    /// <summary><c>ARGB.as8BitChannel</c>.</summary>
    private static uint Channel(float value) => (uint)(int)Math.Floor(value * 255.0F);

    public void Dispose() {
        _gl.DeleteTexture(_vignette);
        _gl.DeleteTexture(_spyglassScope);
        _gl.DeleteTexture(_powderSnowOutline);
        _gl.DeleteTexture(_nausea);
        foreach (uint texture in _equippedOverlays.Values) {
            _gl.DeleteTexture(texture);
        }
    }
}
