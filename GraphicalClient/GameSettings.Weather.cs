using System.Globalization;

namespace GraphicalClient;

/// <summary><c>CloudStatus</c>: no clouds, a flat layer, or cells with sides.</summary>
public enum CloudStatus {
    Off,
    Fast,
    Fancy
}

/// <summary>The sky's options: clouds and weather from the video settings, and the accessibility one for lightning.</summary>
public sealed partial class GameSettings {
    /// <summary><c>renderClouds</c>.</summary>
    public CloudStatus Clouds { get; set; } = CloudStatus.Fancy;

    /// <summary><c>cloudRange</c>, in chunks, 2 to 128: how far out clouds are drawn.</summary>
    public int CloudRange { get; set; } = 128;

    /// <summary><c>weatherRadius</c>, in blocks, 3 to 10: how far round the camera rain and snow fall, and splash.</summary>
    public int WeatherRadius { get; set; } = 10;

    /// <summary>The accessibility option <c>hideLightningFlashes</c>: lightning no longer lights up the sky.</summary>
    public bool HideLightningFlashes { get; set; }

    /// <summary>The weather lines; null for a key that is none of them.</summary>
    private bool? ReadWeather(string key, string value) {
        switch (key) {
            case "renderClouds":
                // CloudStatus' names, or a boolean for the two ends, quoted or not.
                switch (value.Trim('"')) {
                    case "true": Clouds = CloudStatus.Fancy; return true;
                    case "fast": Clouds = CloudStatus.Fast; return true;
                    case "false": Clouds = CloudStatus.Off; return true;
                    default: return false;
                }
            case "cloudRange":
                if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int range) || range is < 2 or > 128) {
                    return false;
                }
                CloudRange = range;
                return true;
            case "weatherRadius":
                if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int radius) || radius is < 3 or > 10) {
                    return false;
                }
                WeatherRadius = radius;
                return true;
            case "hideLightningFlashes":
                return Bool(value, on => HideLightningFlashes = on);
        }
        return null;
    }

    private IEnumerable<string> WeatherLines() => [
        "renderClouds:" + Clouds switch { CloudStatus.Off => "\"false\"", CloudStatus.Fast => "\"fast\"", _ => "\"true\"" },
        "cloudRange:" + CloudRange.ToString(CultureInfo.InvariantCulture),
        "weatherRadius:" + WeatherRadius.ToString(CultureInfo.InvariantCulture),
        "hideLightningFlashes:" + Lower(HideLightningFlashes)
    ];
}
