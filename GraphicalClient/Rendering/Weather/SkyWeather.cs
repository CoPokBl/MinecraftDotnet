using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.World;
using Minecraft;
using Minecraft.Data.Biomes;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using NBT;

namespace GraphicalClient.Rendering.Weather;

/// <summary>What <c>--test-weather</c> puts in place of the server's weather, for the renderer only.</summary>
public enum TestWeather {
    Clear,
    Rain,
    Thunder,

    /// <summary>Rain where it would rain, drawn as snow.</summary>
    Snow
}

/// <summary>
/// The weather a frame is drawn in: <c>Level.getRainLevel</c> and <c>getThunderLevel</c>, which is the thunder
/// level times the rain level, or what the test flag says in their place. Only what is drawn follows the flag;
/// the splashes, the sounds and everything the client tells the server keep the real weather.
/// </summary>
public readonly record struct WeatherView(float Rain, float Thunder, bool ForceSnow) {
    public static WeatherView Of(ClientLevel level, TestWeather? test) => test is { } forced && level.CanHaveWeather
        ? forced switch {
            TestWeather.Rain => new WeatherView(1.0F, 0.0F, false),
            TestWeather.Thunder => new WeatherView(1.0F, 1.0F, false),
            TestWeather.Snow => new WeatherView(1.0F, 0.0F, true),
            _ => new WeatherView(0.0F, 0.0F, false)
        }
        : new WeatherView(level.RainLevel, level.ThunderLevel * level.RainLevel, false);

    /// <summary>
    /// <c>WeatherAttributes</c>' two layers for a colour: the rain's, weighted by the rain less the thunder, then
    /// the thunder's over it, each a <c>BlendToGray</c> lerped in sRGB.
    /// </summary>
    public Vector3 BlendToGray(Vector3 colour, float rainBrightness, float rainFactor, float thunderBrightness, float thunderFactor) {
        float rainOnly = Rain - Thunder;
        if (rainOnly > 0.0F) {
            colour = Vector3.Lerp(colour, Grey(colour, rainBrightness, rainFactor), rainOnly);
        }
        if (Thunder > 0.0F) {
            colour = Vector3.Lerp(colour, Grey(colour, thunderBrightness, thunderFactor), Thunder);
        }
        return colour;
    }

    /// <summary>The same two layers for a colour each multiplies.</summary>
    public Vector3 Multiply(Vector3 colour, Vector3 rainMultiplier, Vector3 thunderMultiplier) {
        float rainOnly = Rain - Thunder;
        if (rainOnly > 0.0F) {
            colour = Vector3.Lerp(colour, colour * rainMultiplier, rainOnly);
        }
        if (Thunder > 0.0F) {
            colour = Vector3.Lerp(colour, colour * thunderMultiplier, Thunder);
        }
        return colour;
    }

    /// <summary><c>ColorModifier.BLEND_TO_GRAY</c>: toward the colour's own <c>ARGB.greyscale</c>, scaled.</summary>
    private static Vector3 Grey(Vector3 colour, float brightness, float factor) =>
        Vector3.Lerp(colour, new Vector3((colour.X * 0.3F + colour.Y * 0.59F + colour.Z * 0.11F) * brightness), factor);
}

/// <summary>
/// The sky flash of lightning: the client half of <c>LightningBolt.tick</c>, which keeps <c>ClientLevel.skyFlashTime</c>
/// at two while a bolt is in one of its flashes. A bolt flashes one to three times with a pause of up to ten ticks
/// between, drawn from this client's own random as vanilla draws from the client entity's; the server only says
/// when the bolt arrives and when it is gone.
/// </summary>
public sealed class LightningFlash {
    private sealed class Bolt {
        public int Life = 2;
        public int Flashes;
    }

    private readonly Dictionary<ClientEntity, Bolt> _bolts = new(ReferenceEqualityComparer.Instance);
    private readonly List<ClientEntity> _gone = [];
    private readonly Random _random = new();
    private int _skyFlashTime;

    /// <summary><c>ClientLevel.getSkyFlashTime</c> above zero: the sky is lit this tick.</summary>
    public bool Flashing => _skyFlashTime > 0;

    /// <summary>Once a game tick: the level's count down, then each bolt's tick, as <c>ClientLevel.tick</c> runs them.</summary>
    public void Tick(MinecraftClient client) {
        if (_skyFlashTime > 0) {
            _skyFlashTime--;
        }
        foreach (ClientEntity entity in client.Entities.Values) {
            if (!entity.Is(EntityClass.LightningBolt)) {
                continue;
            }
            if (!_bolts.TryGetValue(entity, out Bolt? bolt)) {
                bolt = new Bolt { Flashes = _random.Next(3) + 1 };
                _bolts[entity] = bolt;
            }
            bolt.Life--;
            if (bolt.Life < 0 && bolt.Flashes > 0 && bolt.Life < -_random.Next(10)) {
                bolt.Flashes--;
                bolt.Life = 1;
            }
            if (bolt.Life >= 0) {
                _skyFlashTime = 2;
            }
        }
        foreach (ClientEntity tracked in _bolts.Keys) {
            if (!client.Entities.TryGetValue(tracked.Id, out ClientEntity? current) || current != tracked) {
                _gone.Add(tracked);
            }
        }
        foreach (ClientEntity gone in _gone) {
            _bolts.Remove(gone);
        }
        _gone.Clear();
    }
}

/// <summary>The cloud environment attributes, read from the camera's biome over the dimension, as this client keeps no timelines.</summary>
public static class CloudAttributes {
    /// <summary><c>Timelines.NIGHT_CLOUD_COLOR_MULTIPLIER</c>.</summary>
    private static readonly Vector3 NightMultiplier = new(0.1F, 0.1F, 0.15F);

    /// <summary>
    /// <c>visual/cloud_color</c> as it reaches <c>CloudRenderer</c>: sRGB and alpha, the alpha zero where the
    /// dimension has no clouds. The day timeline's track multiplies it toward night between its keyframes at
    /// 11867 and 13670 and back between 22330 and 133, for a dimension whose time passes, and the weather greys it.
    /// </summary>
    public static Vector4 Colour(ClientLevel level, IBiome biome, double dayTime, WeatherView weather) {
        uint argb = Read(level, biome, EnvironmentAttribute.VisualCloudColor, tag => (uint)PackedColor.StringArgbFromNbt(tag), 0u);
        Vector3 colour = new(((argb >> 16) & 0xFF) / 255.0F, ((argb >> 8) & 0xFF) / 255.0F, (argb & 0xFF) / 255.0F);
        if (level.DimensionType.DefaultClock != null) {
            double t = (dayTime % 24000 + 24000) % 24000;
            if (t < 133) {
                t += 24000;
            }
            float night = t <= 11867 ? 0.0F
                : t < 13670 ? (float)((t - 11867) / (13670 - 11867))
                : t <= 22330 ? 1.0F
                : 1.0F - (float)((t - 22330) / (24133 - 22330));
            colour *= Vector3.Lerp(Vector3.One, NightMultiplier, night);
        }
        colour = weather.BlendToGray(colour, 0.24F, 0.5F, 0.095F, 0.94F);
        return new Vector4(colour, (argb >> 24) / 255.0F);
    }

    /// <summary><c>visual/cloud_height</c>: the y of the clouds' underside.</summary>
    public static float Height(ClientLevel level, IBiome biome) =>
        Read(level, biome, EnvironmentAttribute.VisualCloudHeight, tag => tag.AsFloat(), 192.33F);

    /// <summary><c>visual/cloud_fog_end_distance</c>: where the clouds have faded out.</summary>
    public static float FogEnd(ClientLevel level, IBiome biome) =>
        Read(level, biome, EnvironmentAttribute.VisualCloudFogEndDistance, tag => tag.AsFloat(), 2048.0F);

    private static T Read<T>(ClientLevel level, IBiome biome, IEnvironmentAttribute attribute, Func<INbtTag, T> parse, T fallback) {
        try {
            if (biome.Attributes[attribute] is EnvironmentAttributeEntry.Constant constant) {
                return parse(constant.Value.ToNbt());
            }
            if (level.DimensionType.Attributes?[attribute.Identifier.ToString()] is { } tag) {
                return parse(tag);
            }
        }
        catch (Exception e) when (e is InvalidCastException or FormatException or OverflowException) {
            // A value of the wrong shape is ignored, as the codec would refuse it.
        }
        return fallback;
    }
}
