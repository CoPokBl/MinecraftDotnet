using System.Numerics;
using ClientLib.World;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Time of day, sky and fog colours, and the lightmap: the 16 by 16 table every surface looks its
/// sky and block light up in. Vanilla's <c>LightTexture</c> rebuilds the same table each frame.
/// </summary>
public sealed unsafe class Lighting : IDisposable {
    private readonly GL _gl;
    private readonly byte[] _pixels = new byte[16 * 16 * 4];
    private float _bossOverlayWorldDarkening, _bossOverlayWorldDarkeningO;

    public Vector3 SkyColour { get; private set; }
    public Vector3 FogColour { get; private set; }
    public Vector3 SunDirection { get; private set; }
    public float SkyDarken { get; private set; } = 1.0F;

    /// <summary><c>Level.getSkyDarken</c>: how many levels the sky light is taken down by.</summary>
    public int SkyDarkening { get; private set; }
    public float FogStart { get; private set; }
    public float FogEnd { get; private set; }

    public uint LightmapTexture { get; }

    /// <summary>Vanilla's default brightness option, halfway between moody and bright.</summary>
    private const float Gamma = 0.5F;

    public Lighting(GL gl) {
        _gl = gl;
        LightmapTexture = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, LightmapTexture);
        gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, 16, 16, 0, PixelFormat.Rgba, PixelType.UnsignedByte, null);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
    }

    /// <summary>The sun's angle through the day as a fraction, the classic <c>DimensionType.timeOfDay</c> curve.</summary>
    public static float TimeOfDay(double dayTime) {
        double d = dayTime / 24000.0 - 0.25;
        d -= Math.Floor(d);
        double e = 0.5 - Math.Cos(d * Math.PI) / 2.0;
        return (float)(d * 2.0 + e) / 3.0F;
    }

    /// <summary>The boss overlay half of <c>GameRenderer.tick</c>.</summary>
    public void TickBossOverlay(bool darkenScreen) {
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

    /// <param name="skyRgb">The biome's sky colour at full daylight.</param>
    /// <param name="fogRgb">The fog colour at full daylight, from the biome or else the dimension.</param>
    /// <param name="waterFogRgb">The fog colour under water.</param>
    /// <param name="bossFog">A boss bar asks for world fog, <c>BossHealthOverlay.shouldCreateWorldFog</c>.</param>
    public void Update(ClientLevel? level, float partialTick, int renderDistance, bool underwater, uint skyRgb, uint fogRgb, uint waterFogRgb, bool bossFog = false) {
        float ambient = level?.DimensionType.AmbientLight ?? 0.0F;
        bool hasSky = level?.DimensionType.HasSkyLight ?? true;
        float rain = level?.RainLevel ?? 0.0F;
        float thunder = level?.ThunderLevel ?? 0.0F;
        float angle = TimeOfDay(level?.DefaultClockTimeAt(partialTick) ?? 6000);

        // Level.getSkyDarken, as a brightness rather than a darkness.
        float darken = 1.0F - (MathF.Cos(angle * MathF.PI * 2.0F) * 2.0F + 0.2F);
        darken = Math.Clamp(darken, 0.0F, 1.0F);
        darken = 1.0F - darken;
        darken *= 1.0F - rain * 5.0F / 16.0F;
        darken *= 1.0F - thunder * 5.0F / 16.0F;
        SkyDarken = hasSky ? darken * 0.8F + 0.2F : 1.0F;
        // The dimension's sky_light_level comes from the day timeline, which this client does not run; this
        // curve agrees with it at full day and full night, in rain and thunder, and differs only through dusk and dawn.
        SkyDarkening = hasSky ? (int)((1.0F - darken) * 11.0F) : 0;

        float skyBrightness = Math.Clamp(MathF.Cos(angle * MathF.PI * 2.0F) * 2.0F + 0.5F, 0.0F, 1.0F);
        Vector3 baseSky = Rgb(skyRgb);
        Vector3 baseFog = Rgb(fogRgb);
        if (!hasSky) {
            baseSky = baseFog;
            skyBrightness = 1.0F;
        }
        Vector3 grey = new(0.6F);
        Vector3 sky = baseSky * skyBrightness;
        Vector3 fog = baseFog * (skyBrightness * 0.94F + 0.06F);
        sky = Vector3.Lerp(sky, grey * skyBrightness, rain * 0.6F);
        fog = Vector3.Lerp(fog, grey * skyBrightness, rain * 0.6F);
        if (underwater) {
            fog = Rgb(waterFogRgb) * (SkyDarken * 0.8F + 0.2F);
            sky = fog;
        }
        SkyColour = sky;
        FogColour = fog;
        float sunAngle = angle * MathF.PI * 2.0F;
        SunDirection = Vector3.Normalize(new Vector3(-MathF.Sin(sunAngle), MathF.Cos(sunAngle), 0.0F));

        float distance = renderDistance * 16.0F;
        FogEnd = underwater ? 24.0F : distance;
        FogStart = underwater ? 0.0F : distance * 0.75F;
        // AtmosphericFogEnvironment.setupFog. Vanilla also pulls the sky and cloud fog in to the same end
        // and skips the sky pass; the sky here belongs to the shader pack and is left alone.
        if (bossFog && !underwater) {
            FogStart = Math.Min(FogStart, 10.0F);
            FogEnd = Math.Min(FogEnd, 96.0F);
        }

        BuildLightmap(ambient, hasSky, _bossOverlayWorldDarkeningO + partialTick * (_bossOverlayWorldDarkening - _bossOverlayWorldDarkeningO));
    }

    private static Vector3 Rgb(uint rgb) => new(((rgb >> 16) & 0xFF) / 255.0F, ((rgb >> 8) & 0xFF) / 255.0F, (rgb & 0xFF) / 255.0F);

    /// <summary><c>LightTexture.updateLightTexture</c>, without the night vision and darkness effects.</summary>
    private void BuildLightmap(float ambient, bool hasSky, float bossOverlayWorldDarkening) {
        float skyFactor = hasSky ? SkyDarken * 0.95F + 0.05F : 0.0F;
        Vector3 skyTint = Vector3.Lerp(new Vector3(SkyDarken), Vector3.One, 0.35F);
        for (int sky = 0; sky < 16; sky++) {
            for (int block = 0; block < 16; block++) {
                float skyLevel = Brightness(ambient, sky) * skyFactor;
                float blockLevel = Brightness(ambient, block) * 1.5F;
                Vector3 colour = new(blockLevel, blockLevel * ((blockLevel * 0.6F + 0.4F) * 0.6F + 0.4F), blockLevel * (blockLevel * blockLevel * 0.6F + 0.4F));
                colour += skyTint * skyLevel;
                colour = Vector3.Lerp(colour, new Vector3(0.75F), 0.04F);
                if (bossOverlayWorldDarkening > 0.0F) {
                    colour = Vector3.Lerp(colour, colour * new Vector3(0.7F, 0.6F, 0.6F), bossOverlayWorldDarkening);
                }
                colour = Vector3.Clamp(colour, Vector3.Zero, Vector3.One);
                Vector3 bright = new(NotGamma(colour.X), NotGamma(colour.Y), NotGamma(colour.Z));
                colour = Vector3.Lerp(colour, bright, Gamma);
                colour = Vector3.Lerp(colour, new Vector3(0.75F), 0.04F);
                colour = Vector3.Clamp(colour, Vector3.Zero, Vector3.One);
                int i = (sky * 16 + block) * 4;
                _pixels[i] = (byte)(colour.X * 255.0F);
                _pixels[i + 1] = (byte)(colour.Y * 255.0F);
                _pixels[i + 2] = (byte)(colour.Z * 255.0F);
                _pixels[i + 3] = 255;
            }
        }
    }

    public void Upload() {
        _gl.BindTexture(TextureTarget.Texture2D, LightmapTexture);
        fixed (byte* p = _pixels) {
            _gl.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, 16, 16, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
    }

    /// <summary><c>Lightmap.getBrightness</c>: the curve that makes each level look a step apart.</summary>
    public static float Brightness(float ambient, int level) {
        float f = level / 15.0F;
        float curved = f / (4.0F - 3.0F * f);
        return curved + (1.0F - curved) * ambient;
    }

    private static float NotGamma(float x) {
        float inverse = 1.0F - x;
        return 1.0F - inverse * inverse * inverse * inverse;
    }

    public void Dispose() => _gl.DeleteTexture(LightmapTexture);
}
