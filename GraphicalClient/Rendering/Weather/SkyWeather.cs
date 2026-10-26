using ClientLib.World;

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
/// level times the rain level, or what the test flag says in their place. Only what is drawn follows the flag, along
/// with the level's environment attributes; the splashes, the sounds and everything the client tells the server keep
/// the real weather.
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
}
