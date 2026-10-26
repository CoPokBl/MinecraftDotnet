using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Schemas;
using Silk.NET.OpenGL;
using Block = Minecraft.Data.Generated.Block;
using EnvironmentAttribute = Minecraft.Data.Generated.EnvironmentAttribute;
using Mth = Minecraft.Schemas.Mth;
using PotionEffectType = Minecraft.Data.Generated.PotionEffectType;

namespace GraphicalClient.Rendering;

/// <summary><c>FogType</c>, with <c>NONE</c> already turned into <see cref="Atmospheric"/> as <c>FogRenderer.getFogType</c> does.</summary>
public enum FogType {
    Lava,
    Water,
    PowderSnow,
    Atmospheric
}

/// <summary><c>FogData</c>: where each of vanilla's fogs starts and ends, in blocks, and the fog's colour.</summary>
public struct FogData {
    public float EnvironmentalStart;
    public float RenderDistanceStart;
    public float EnvironmentalEnd;
    public float RenderDistanceEnd;
    public float SkyEnd;
    public float CloudEnd;
    public Vector4 Color;
}

/// <summary>What the lighting reads of the frame, gathered by <see cref="GameRenderer"/>.</summary>
/// <param name="RenderDistance"><c>Options.getEffectiveRenderDistance</c>, in chunks.</param>
public readonly record struct LightingFrame(
    MinecraftClient Client,
    ClientLevel Level,
    LocalPlayer Player,
    ClientEntity CameraEntity,
    Camera Camera,
    float PartialTick,
    float DeltaTicks,
    int RenderDistance,
    Weather.WeatherView Weather,
    bool BossFog,
    GameSettings Settings);

/// <summary>
/// The lightmap, the fog and the sky's values for a frame: vanilla's <c>LightmapRenderStateExtractor</c> and
/// <c>lightmap.fsh</c>, <c>FogRenderer</c> and its fog environments, and what <c>SkyRenderer</c> and the cloud
/// renderer read off the camera's attribute probe.
/// </summary>
public sealed unsafe class Lighting : IDisposable {
    private static readonly Vector3 LavaFogColor = ArgbVectors.FromRgb24(-6743808);
    private static readonly Vector3 PowderSnowFogColor = ArgbVectors.FromRgb24(-6308916);

    private readonly GL _gl;
    private readonly byte[] _pixels = new byte[16 * 16 * 4];
    private bool _lightmapChanged;

    private readonly LegacyRandomSource _randomSource = new(Random.Shared.NextInt64());
    private float _blockLightFlicker;
    private bool _needsUpdate;
    private float _bossOverlayWorldDarkening, _bossOverlayWorldDarkeningO;
    private float _rainFogMultiplier;

    public uint LightmapTexture { get; }

    /// <summary><c>UiLightmap</c>: one white texel, which everything drawn in the GUI is lit by.</summary>
    public uint UiLightmapTexture { get; }

    public LightmapState LightmapState { get; private set; }
    public FogType FogType { get; private set; } = FogType.Atmospheric;
    public FogData Fog { get; private set; }

    /// <summary><c>visual/sky_color</c> at the camera: the sky disc's colour.</summary>
    public Vector3 SkyColour { get; private set; }

    /// <summary><c>visual/sunrise_sunset_color</c>.</summary>
    public Vector4 SunriseColour { get; private set; }

    /// <summary><c>visual/sun_angle</c>, <c>moon_angle</c> and <c>star_angle</c> in degrees.</summary>
    public float SunAngle { get; private set; }

    public float MoonAngle { get; private set; }
    public float StarAngle { get; private set; }
    public float StarBrightness { get; private set; }
    public MoonPhase MoonPhase { get; private set; }

    /// <summary><c>EndFlashState</c>'s intensity this frame and where in the end's sky the flash is, in degrees.</summary>
    public float EndFlashIntensity { get; private set; }

    public float EndFlashXAngle { get; private set; }
    public float EndFlashYAngle { get; private set; }

    /// <summary><c>visual/cloud_color</c> floored to eight bits a channel, as <c>LevelExtractor</c> packs it, and <c>cloud_height</c>.</summary>
    public Vector4 CloudColour { get; private set; }

    public float CloudHeight { get; private set; }

    /// <summary>Toward the sun as <c>SkyRenderer</c> draws it: turned about the x axis by the sun angle, after a quarter turn about y.</summary>
    public Vector3 SunDirection { get; private set; } = Vector3.UnitY;

    /// <summary>
    /// <c>gameplay/sky_light_level</c> over fifteen, or one where the dimension has no sky: what packs read as
    /// daylight, from one at noon to about a quarter at night, lower in rain.
    /// </summary>
    public float Daylight { get; private set; } = 1.0F;

    /// <summary><c>Level.getSkyDarken</c>.</summary>
    public int SkyDarkening { get; private set; }

    public Lighting(GL gl) {
        _gl = gl;
        Array.Fill(_pixels, (byte)0xFF);
        LightmapTexture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, LightmapTexture);
        // Lightmap's texture starts cleared to white; it is sampled clamped and linear, as RenderSetup binds Sampler2.
        fixed (byte* p = _pixels) {
            gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, 16, 16, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        SetSampler();
        UiLightmapTexture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, UiLightmapTexture);
        uint white = 0xFFFFFFFF;
        gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, 1, 1, 0, PixelFormat.Rgba, PixelType.UnsignedByte, &white);
        SetSampler();
    }

    private void SetSampler() {
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
    }

    /// <summary>
    /// The lighting's part of <c>GameRenderer.tick</c>: <c>LightmapRenderStateExtractor.tick</c>'s flicker, which asks
    /// for the lightmap again, then the boss overlay's darkening while the level runs.
    /// </summary>
    public void Tick(bool runsNormally, bool darkenScreen) {
        _blockLightFlicker += (_randomSource.NextFloat() - _randomSource.NextFloat()) * _randomSource.NextFloat() * _randomSource.NextFloat() * 0.1F;
        _blockLightFlicker *= 0.9F;
        _needsUpdate = true;
        if (!runsNormally) {
            return;
        }
        _bossOverlayWorldDarkeningO = _bossOverlayWorldDarkening;
        if (darkenScreen) {
            _bossOverlayWorldDarkening += 0.05F;
            if (_bossOverlayWorldDarkening > 1.0F) {
                _bossOverlayWorldDarkening = 1.0F;
            }
        }
        else if (_bossOverlayWorldDarkening > 0.0F) {
            _bossOverlayWorldDarkening -= 0.0125F;
        }
    }

    /// <summary><c>GameRenderer.bossOverlayWorldDarkening</c>.</summary>
    public float BossOverlayWorldDarkening(float partialTick) => Mth.Lerp(partialTick, _bossOverlayWorldDarkeningO, _bossOverlayWorldDarkening);

    /// <summary>
    /// <c>GameRenderer.extract</c>'s order: the lightmap if a tick asked for it, then the camera's fog, then the sky's
    /// and the clouds' values.
    /// </summary>
    public void Update(in LightingFrame frame) {
        ClientLevel level = frame.Level;
        EnvironmentAttributeProbe probe = frame.Camera.AttributeProbe;
        SkyDarkening = level.SkyDarken;
        ExtractLightmap(frame);

        FogType = GetFogType(level, frame.Camera, frame.Settings.Fov);
        Fog = SetupFog(frame);

        float partialTick = frame.PartialTick;
        SkyColour = probe.GetValue(EnvironmentAttribute.VisualSkyColor, partialTick);
        SunriseColour = probe.GetValue(EnvironmentAttribute.VisualSunriseSunsetColor, partialTick);
        SunAngle = probe.GetValue(EnvironmentAttribute.VisualSunAngle, partialTick);
        MoonAngle = probe.GetValue(EnvironmentAttribute.VisualMoonAngle, partialTick);
        StarAngle = probe.GetValue(EnvironmentAttribute.VisualStarAngle, partialTick);
        StarBrightness = probe.GetValue(EnvironmentAttribute.VisualStarBrightness, partialTick);
        MoonPhase = probe.GetValue(EnvironmentAttribute.VisualMoonPhase, partialTick);
        float sunRadians = SunAngle * (float)(Math.PI / 180.0);
        SunDirection = new Vector3(-MathF.Sin(sunRadians), MathF.Cos(sunRadians), 0.0F);
        Daylight = level.DimensionType.HasSkyLight ? probe.GetValue(EnvironmentAttribute.GameplaySkyLightLevel, partialTick) / 15.0F : 1.0F;
        if (level.Environment.EndFlash is { } endFlash) {
            EndFlashIntensity = endFlash.GetIntensity(partialTick);
            EndFlashXAngle = endFlash.XAngle;
            EndFlashYAngle = endFlash.YAngle;
        }
        else {
            EndFlashIntensity = 0.0F;
        }

        int cloudColor = ArgbVectors.ToArgb32(probe.GetValue(EnvironmentAttribute.VisualCloudColor, partialTick));
        CloudColour = new Vector4((cloudColor >> 16 & 0xFF) / 255.0F, (cloudColor >> 8 & 0xFF) / 255.0F, (cloudColor & 0xFF) / 255.0F,
            (int)((uint)cloudColor >> 24) / 255.0F);
        if (CloudColour.W > 0.0F) {
            CloudHeight = probe.GetValue(EnvironmentAttribute.VisualCloudHeight, partialTick);
        }
    }

    #region Lightmap

    /// <summary>
    /// <c>LightmapRenderStateExtractor.extract</c>, which <c>GameRenderer</c> calls with a partial tick of one, so the
    /// lightmap is the tick's own and is worked out once per tick.
    /// </summary>
    private void ExtractLightmap(in LightingFrame frame) {
        if (!_needsUpdate) {
            return;
        }
        const float partialTicks = 1.0F;
        EnvironmentAttributeProbe probe = frame.Camera.AttributeProbe;
        LocalPlayer player = frame.Player;
        float blockFactor = _blockLightFlicker + 1.4F;
        Vector3 blockLightTint = probe.GetValue(EnvironmentAttribute.VisualBlockLightTint, partialTicks);
        float skyFactor = probe.GetValue(EnvironmentAttribute.VisualSkyLightFactor, partialTicks);
        Vector3 skyLightColor = probe.GetValue(EnvironmentAttribute.VisualSkyLightColor, partialTicks);
        if (frame.Level.Environment.EndFlash is { } endFlash && !frame.Settings.HideLightningFlashes) {
            float intensity = endFlash.GetIntensity(partialTicks);
            skyFactor += frame.BossFog ? intensity / 3.0F : intensity;
        }
        Vector3 ambientColor = probe.GetValue(EnvironmentAttribute.VisualAmbientLightColor, partialTicks);
        float brightnessOption = (float)frame.Settings.Gamma;
        float darknessEffectScaleOption = (float)frame.Settings.DarknessEffectScale;
        float darknessEffectBrightnessModifier = player.GetEffectBlendFactor(PotionEffectType.Darkness, partialTicks) * darknessEffectScaleOption;
        float brightness = Math.Max(0.0F, brightnessOption - darknessEffectBrightnessModifier);
        float darknessEffectScale = CalculateDarknessScale(player, darknessEffectBrightnessModifier, partialTicks) * darknessEffectScaleOption;
        float waterVision = player.WaterVision;
        float nightVisionEffectIntensity = player.HasEffect(PotionEffectType.NightVision) ? NightVisionScale(player, partialTicks)
            : waterVision > 0.0F && player.HasEffect(PotionEffectType.ConduitPower) ? waterVision
            : 0.0F;
        Vector3 nightVisionColor = probe.GetValue(EnvironmentAttribute.VisualNightVisionColor, partialTicks);
        LightmapState = new LightmapState(skyFactor, blockFactor, nightVisionEffectIntensity, darknessEffectScale, BossOverlayWorldDarkening(partialTicks),
            brightness, blockLightTint, skyLightColor, ambientColor, nightVisionColor);
        Lightmap.Compute(LightmapState, _pixels);
        _lightmapChanged = true;
        _needsUpdate = false;
    }

    /// <summary><c>LightmapRenderStateExtractor.calculateDarknessScale</c>: the darkness effect's pulse.</summary>
    private static float CalculateDarknessScale(ClientEntity camera, float darknessGamma, float partialTickTime) {
        float darkness = 0.45F * darknessGamma;
        return Math.Max(0.0F, Mth.Cos((camera.TickCount - partialTickTime) * (float)Math.PI * 0.025F) * darkness);
    }

    /// <summary><c>GameRenderer.nightVisionScale</c>: full, flickering through the last ten seconds.</summary>
    public static float NightVisionScale(ClientEntity camera, float a) {
        MobEffectInstance nightVision = camera.GetEffect(PotionEffectType.NightVision)!;
        return !nightVision.EndsWithin(200) ? 1.0F : 0.7F + Mth.Sin((nightVision.Duration - a) * (float)Math.PI * 0.2F) * 0.3F;
    }

    public void Upload() {
        if (!_lightmapChanged) {
            return;
        }
        _lightmapChanged = false;
        _gl.BindTexture(TextureTarget.Texture2D, LightmapTexture);
        fixed (byte* p = _pixels) {
            _gl.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, 16, 16, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
    }

    #endregion

    #region Fog

    /// <summary>
    /// <c>Camera.getFluidInCamera</c>: water if the camera is under the surface of the water in its block, else lava or
    /// powder snow at the middle or a corner of the near plane, at the field of view option rather than the eased one.
    /// </summary>
    public static FogType GetFogType(ClientLevel level, Camera camera, int fovOption) {
        Vec3d position = camera.Position;
        int bx = Mth.Floor(position.X), by = Mth.Floor(position.Y), bz = Mth.Floor(position.Z);
        MovementBlocks.Entry fluidState1 = MovementBlocks.Get(level.Registry, level.GetState(bx, by, bz));
        if (fluidState1.Fluid == FluidKind.Water && position.Y < by + HeightForCamera(level, fluidState1, bx, by, bz)) {
            return FogType.Water;
        }
        Vector3 forward = camera.Forward;
        Vector3 up = camera.Up;
        Vector3 left = Vector3.Cross(up, forward);
        double planeHeight = Math.Tan(fovOption * (float)(Math.PI / 180.0) / 2.0) * Camera.NearPlane;
        double planeWidth = planeHeight * camera.Aspect;
        Vec3d forwards = new Vec3d(forward.X, forward.Y, forward.Z) * Camera.NearPlane;
        Vec3d leftVec = new Vec3d(left.X, left.Y, left.Z) * planeWidth;
        Vec3d upVec = new Vec3d(up.X, up.Y, up.Z) * planeHeight;
        Span<Vec3d> points = [forwards, forwards + upVec + leftVec, forwards + upVec - leftVec, forwards - upVec + leftVec, forwards - upVec - leftVec];
        foreach (Vec3d point in points) {
            Vec3d offsetPos = position + point;
            int x = Mth.Floor(offsetPos.X), y = Mth.Floor(offsetPos.Y), z = Mth.Floor(offsetPos.Z);
            uint stateId = level.GetState(x, y, z);
            MovementBlocks.Entry fluidState = MovementBlocks.Get(level.Registry, stateId);
            if (fluidState.Fluid == FluidKind.Lava) {
                if (offsetPos.Y <= HeightForCamera(level, fluidState, x, y, z) + y) {
                    return FogType.Lava;
                }
            }
            else if (level.Registry.Blocks.GetByStateId(stateId).Identifier == Block.PowderSnow.Identifier) {
                return FogType.PowderSnow;
            }
        }
        return FogType.Atmospheric;
    }

    /// <summary><c>FluidState.getHeightForCamera</c>: a source under a sturdy ceiling is full, else <c>getHeight</c>.</summary>
    private static float HeightForCamera(ClientLevel level, MovementBlocks.Entry fluid, int x, int y, int z) {
        if (fluid.FluidAmount == 8 && !fluid.FluidFalling) {
            MovementBlocks.Entry above = MovementBlocks.Get(level.Registry, level.GetState(x, y + 1, z));
            if ((above.SturdyFaces & 1 << (int)Face.Down) != 0) {
                return 1.0F;
            }
        }
        return FluidInteraction.FluidHeight(level, x, y, z, fluid);
    }

    private enum FogEnvironment {
        Lava,
        PowderSnow,
        Blindness,
        Darkness,
        Water,
        Atmospheric
    }

    /// <summary><c>FogRenderer.FOG_ENVIRONMENTS</c>, in the order the first that applies wins.</summary>
    private static readonly FogEnvironment[] FogEnvironments = [
        FogEnvironment.Lava, FogEnvironment.PowderSnow, FogEnvironment.Blindness, FogEnvironment.Darkness, FogEnvironment.Water, FogEnvironment.Atmospheric
    ];

    private static bool IsApplicable(FogEnvironment environment, FogType fogType, ClientEntity entity) => environment switch {
        FogEnvironment.Lava => fogType == FogType.Lava,
        FogEnvironment.PowderSnow => fogType == FogType.PowderSnow,
        FogEnvironment.Blindness => entity.IsLiving && entity.HasEffect(PotionEffectType.Blindness),
        FogEnvironment.Darkness => entity.IsLiving && entity.HasEffect(PotionEffectType.Darkness),
        FogEnvironment.Water => fogType == FogType.Water,
        _ => fogType == FogType.Atmospheric
    };

    /// <summary><c>MobEffectFogEnvironment</c>: gives no colour of its own, and modifies the darkness.</summary>
    private static bool IsMobEffect(FogEnvironment environment) => environment is FogEnvironment.Blindness or FogEnvironment.Darkness;

    /// <summary><c>FogRenderer.setupFog</c>: the colour, then the first environment that applies, then the render distance's fog.</summary>
    private FogData SetupFog(in LightingFrame frame) {
        float renderDistanceInBlocks = frame.RenderDistance * 16;
        FogData fog = new() {
            Color = ComputeFogColor(frame, FogType, BossOverlayWorldDarkening(frame.PartialTick))
        };
        foreach (FogEnvironment environment in FogEnvironments) {
            if (IsApplicable(environment, FogType, frame.CameraEntity)) {
                SetupFog(environment, ref fog, frame, renderDistanceInBlocks);
                break;
            }
        }
        float renderDistanceFogSpan = Math.Clamp(renderDistanceInBlocks / 10.0F, 4.0F, 64.0F);
        fog.RenderDistanceStart = renderDistanceInBlocks - renderDistanceFogSpan;
        fog.RenderDistanceEnd = renderDistanceInBlocks;
        return fog;
    }

    private static bool IsSpectator(in LightingFrame frame, ClientEntity entity) =>
        entity is LocalPlayer local ? local.IsSpectator : frame.Client.PlayerInfoOf(entity)?.GameMode == GameMode.Spectator;

    private void SetupFog(FogEnvironment environment, ref FogData fog, in LightingFrame frame, float renderDistance) {
        ClientEntity entity = frame.CameraEntity;
        EnvironmentAttributeProbe probe = frame.Camera.AttributeProbe;
        float partialTicks = frame.PartialTick;
        switch (environment) {
            case FogEnvironment.Lava:
                if (IsSpectator(frame, entity)) {
                    fog.EnvironmentalStart = -8.0F;
                    fog.EnvironmentalEnd = renderDistance * 0.5F;
                }
                else if (entity.IsLiving && entity.HasEffect(PotionEffectType.FireResistance)) {
                    fog.EnvironmentalStart = 0.0F;
                    fog.EnvironmentalEnd = 5.0F;
                }
                else {
                    fog.EnvironmentalStart = 0.25F;
                    fog.EnvironmentalEnd = 1.0F;
                }
                fog.SkyEnd = fog.EnvironmentalEnd;
                fog.CloudEnd = fog.EnvironmentalEnd;
                break;
            case FogEnvironment.PowderSnow:
                if (IsSpectator(frame, entity)) {
                    fog.EnvironmentalStart = -8.0F;
                    fog.EnvironmentalEnd = renderDistance * 0.5F;
                }
                else {
                    fog.EnvironmentalStart = 0.0F;
                    fog.EnvironmentalEnd = 2.0F;
                }
                fog.SkyEnd = fog.EnvironmentalEnd;
                fog.CloudEnd = fog.EnvironmentalEnd;
                break;
            case FogEnvironment.Blindness:
                if (entity.GetEffect(PotionEffectType.Blindness) is { } blindness) {
                    float distance = blindness.IsInfiniteDuration ? 5.0F : Mth.Lerp(Math.Min(1.0F, blindness.Duration / 20.0F), renderDistance, 5.0F);
                    fog.EnvironmentalStart = distance * 0.25F;
                    fog.EnvironmentalEnd = distance;
                    fog.SkyEnd = distance * 0.8F;
                    fog.CloudEnd = distance * 0.8F;
                }
                break;
            case FogEnvironment.Darkness:
                if (entity.GetEffect(PotionEffectType.Darkness) is { } darkness) {
                    float distance = Mth.Lerp(darkness.BlendFactor(entity.IsRemoved, partialTicks), renderDistance, 15.0F);
                    fog.EnvironmentalStart = distance * 0.75F;
                    fog.EnvironmentalEnd = distance;
                    fog.SkyEnd = distance;
                    fog.CloudEnd = distance;
                }
                break;
            case FogEnvironment.Water:
                fog.EnvironmentalStart = probe.GetValue(EnvironmentAttribute.VisualWaterFogStartDistance, partialTicks);
                fog.EnvironmentalEnd = probe.GetValue(EnvironmentAttribute.VisualWaterFogEndDistance, partialTicks);
                if (entity is LocalPlayer player) {
                    fog.EnvironmentalEnd *= Math.Max(0.25F, player.WaterVision);
                }
                fog.SkyEnd = fog.EnvironmentalEnd;
                fog.CloudEnd = fog.EnvironmentalEnd;
                break;
            default:
                UpdateRainFogState(frame);
                fog.EnvironmentalStart = probe.GetValue(EnvironmentAttribute.VisualFogStartDistance, partialTicks);
                fog.EnvironmentalEnd = probe.GetValue(EnvironmentAttribute.VisualFogEndDistance, partialTicks);
                fog.EnvironmentalStart += -160.0F * _rainFogMultiplier;
                float minRainFogEnd = Math.Min(96.0F, fog.EnvironmentalEnd);
                fog.EnvironmentalEnd = Math.Max(minRainFogEnd, fog.EnvironmentalEnd + -256.0F * _rainFogMultiplier);
                fog.SkyEnd = Math.Min(renderDistance, probe.GetValue(EnvironmentAttribute.VisualSkyFogEndDistance, partialTicks));
                fog.CloudEnd = Math.Min(frame.Settings.CloudRange * 16, probe.GetValue(EnvironmentAttribute.VisualCloudFogEndDistance, partialTicks));
                if (frame.BossFog) {
                    fog.EnvironmentalStart = Math.Min(fog.EnvironmentalStart, 10.0F);
                    fog.EnvironmentalEnd = Math.Min(fog.EnvironmentalEnd, 96.0F);
                    fog.SkyEnd = fog.EnvironmentalEnd;
                    fog.CloudEnd = fog.EnvironmentalEnd;
                }
                break;
        }
    }

    /// <summary>
    /// <c>AtmosphericFogEnvironment.updateRainFogState</c>: rain pulls the fog in by up to its offsets, by how much sky
    /// the camera's block sees, half as far where the zoomed biome has no rain, easing a fifth of the way each tick.
    /// </summary>
    private void UpdateRainFogState(in LightingFrame frame) {
        Vec3d position = frame.Camera.Position;
        int x = Mth.Floor(position.X), y = Mth.Floor(position.Y), z = Mth.Floor(position.Z);
        ClientLevel level = frame.Level;
        bool rainsInBiome = BiomeClimate.Biome(level, x, y, z).HasPrecipitation;
        float skyLightLevelMultiplier = Math.Clamp((level.GetSkyLight(x, y, z) - 8.0F) / 7.0F, 0.0F, 1.0F);
        float targetRainFogMultiplier = frame.Weather.Rain * skyLightLevelMultiplier * (rainsInBiome ? 1.0F : 0.5F);
        _rainFogMultiplier += (targetRainFogMultiplier - _rainFogMultiplier) * frame.DeltaTicks * 0.2F;
    }

    /// <summary>
    /// <c>FogRenderer.computeFogColor</c>: the first colour giving environment's colour, darkened toward the void and
    /// by a darkening effect, darkened by the boss overlay, then brightened toward its brightest channel by night
    /// vision or by eyes adjusted to water.
    /// </summary>
    private static Vector4 ComputeFogColor(in LightingFrame frame, FogType fogType, float darkenWorldAmount) {
        ClientEntity entity = frame.CameraEntity;
        FogEnvironment colorSourceEnvironment = FogEnvironment.Atmospheric;
        bool foundColorSource = false;
        FogEnvironment? darknessModifyingEnvironment = null;
        foreach (FogEnvironment environment in FogEnvironments) {
            if (IsApplicable(environment, fogType, entity)) {
                if (!foundColorSource && !IsMobEffect(environment)) {
                    colorSourceEnvironment = environment;
                    foundColorSource = true;
                }
                if (darknessModifyingEnvironment == null && IsMobEffect(environment)) {
                    darknessModifyingEnvironment = environment;
                }
            }
        }
        float partialTicks = frame.PartialTick;
        Vector3 color = BaseColor(colorSourceEnvironment, frame);
        ClientLevel level = frame.Level;
        float voidDarknessOnsetRange = level.IsFlat ? 1.0F : 32.0F;
        float darkness = Math.Clamp((voidDarknessOnsetRange + level.MinY - (float)frame.Camera.Position.Y) / voidDarknessOnsetRange, 0.0F, 1.0F);
        if (darknessModifyingEnvironment is { } modifying) {
            darkness = ModifiedDarkness(modifying, entity, darkness, partialTicks);
        }
        float fogRed = color.X;
        float fogGreen = color.Y;
        float fogBlue = color.Z;
        if (darkness > 0.0F && fogType != FogType.Lava && fogType != FogType.PowderSnow) {
            float brightness = Mth.Square(1.0F - darkness);
            fogRed *= brightness;
            fogGreen *= brightness;
            fogBlue *= brightness;
        }
        if (darkenWorldAmount > 0.0F) {
            fogRed = Mth.Lerp(darkenWorldAmount, fogRed, fogRed * 0.7F);
            fogGreen = Mth.Lerp(darkenWorldAmount, fogGreen, fogGreen * 0.6F);
            fogBlue = Mth.Lerp(darkenWorldAmount, fogBlue, fogBlue * 0.6F);
        }
        float brightenFactor;
        if (fogType == FogType.Water) {
            brightenFactor = entity is LocalPlayer localPlayer ? localPlayer.WaterVision : 1.0F;
        }
        else if (entity.IsLiving && entity.HasEffect(PotionEffectType.NightVision) && !entity.HasEffect(PotionEffectType.Darkness)) {
            brightenFactor = NightVisionScale(entity, partialTicks);
        }
        else {
            brightenFactor = 0.0F;
        }
        if (fogRed != 0.0F && fogGreen != 0.0F && fogBlue != 0.0F) {
            float targetScale = 1.0F / Math.Max(fogRed, Math.Max(fogGreen, fogBlue));
            fogRed = Mth.Lerp(brightenFactor, fogRed, fogRed * targetScale);
            fogGreen = Mth.Lerp(brightenFactor, fogGreen, fogGreen * targetScale);
            fogBlue = Mth.Lerp(brightenFactor, fogBlue, fogBlue * targetScale);
        }
        return new Vector4(fogRed, fogGreen, fogBlue, 1.0F);
    }

    /// <summary><c>BlindnessFogEnvironment</c> and <c>DarknessFogEnvironment.getModifiedDarkness</c>.</summary>
    private static float ModifiedDarkness(FogEnvironment environment, ClientEntity entity, float darkness, float partialTickTime) {
        if (environment == FogEnvironment.Blindness) {
            if (entity.GetEffect(PotionEffectType.Blindness) is { } instance) {
                darkness = instance.EndsWithin(19) ? Math.Max(instance.Duration / 20.0F, darkness) : 1.0F;
            }
            return darkness;
        }
        return entity.GetEffect(PotionEffectType.Darkness) is { } darknessEffect
            ? Math.Max(darknessEffect.BlendFactor(entity.IsRemoved, partialTickTime), darkness)
            : darkness;
    }

    private static Vector3 BaseColor(FogEnvironment environment, in LightingFrame frame) {
        EnvironmentAttributeProbe probe = frame.Camera.AttributeProbe;
        float partialTicks = frame.PartialTick;
        switch (environment) {
            case FogEnvironment.Lava:
                return LavaFogColor;
            case FogEnvironment.PowderSnow:
                return PowderSnowFogColor;
            case FogEnvironment.Water:
                return probe.GetValue(EnvironmentAttribute.VisualWaterFogColor, partialTicks);
        }
        // AtmosphericFogEnvironment.getBaseColor: toward the sunrise's colour looking at the sun's side of the sky,
        // then toward the sky's own colour by how near the sky's fog ends.
        Vector3 fogColor = probe.GetValue(EnvironmentAttribute.VisualFogColor, partialTicks);
        if (frame.RenderDistance >= 4) {
            float sunAngle = probe.GetValue(EnvironmentAttribute.VisualSunAngle, partialTicks) * (float)(Math.PI / 180.0);
            float sunX = Mth.Sin(sunAngle) > 0.0F ? -1.0F : 1.0F;
            Vector3 forwardVector = frame.Camera.Forward;
            float lookingAtTheSunFactor = forwardVector.X * sunX + (forwardVector.Y * 0.0F + forwardVector.Z * 0.0F);
            if (lookingAtTheSunFactor > 0.0F) {
                Vector4 color = probe.GetValue(EnvironmentAttribute.VisualSunriseSunsetColor, partialTicks);
                float alpha = color.W;
                if (alpha > 0.0F) {
                    fogColor = ArgbVectors.SrgbLerp(lookingAtTheSunFactor * alpha, fogColor, new Vector3(color.X, color.Y, color.Z));
                }
            }
        }
        Vector3 skyColor = probe.GetValue(EnvironmentAttribute.VisualSkyColor, partialTicks);
        skyColor = ApplyWeatherDarken(skyColor, frame.Weather.Rain, frame.Weather.Thunder);
        float skyFogEnd = Math.Min(probe.GetValue(EnvironmentAttribute.VisualSkyFogEndDistance, partialTicks) / 16.0F, frame.RenderDistance);
        float skyColorMixFactor = Mth.ClampedLerp(skyFogEnd / 32.0F, 0.25F, 1.0F);
        skyColorMixFactor = 1.0F - (float)Math.Pow(skyColorMixFactor, 0.25);
        return ArgbVectors.SrgbLerp(skyColorMixFactor, fogColor, skyColor);
    }

    private static Vector3 ApplyWeatherDarken(Vector3 color, float rainLevel, float thunderLevel) {
        if (rainLevel > 0.0F) {
            float rainColorModifier = 1.0F - rainLevel * 0.5F;
            float rainBlueColorModifier = 1.0F - rainLevel * 0.4F;
            color = ArgbVectors.ScaleRgb(color, rainColorModifier, rainColorModifier, rainBlueColorModifier);
        }
        if (thunderLevel > 0.0F) {
            color = ArgbVectors.ScaleRgb(color, 1.0F - thunderLevel * 0.5F);
        }
        return color;
    }

    #endregion

    public void Dispose() {
        _gl.DeleteTexture(LightmapTexture);
        _gl.DeleteTexture(UiLightmapTexture);
    }
}
