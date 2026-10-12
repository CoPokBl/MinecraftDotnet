using System.Globalization;
using Minecraft.Schemas.Sound;

namespace GraphicalClient;

/// <summary>
/// The options a player changes from the options screens, kept in an <c>options.txt</c> written the way
/// vanilla's <c>Options.save</c> writes its own: one <c>key:value</c> a line, under the same keys and in
/// the same stored units. Lines this client does not know are kept as they were.
/// </summary>
public sealed class GameSettings {
    /// <summary><c>SoundSource.getName</c>, by category: what the volume keys are made of.</summary>
    public static readonly IReadOnlyDictionary<SoundCategory, string> CategoryNames = new Dictionary<SoundCategory, string> {
        [SoundCategory.Master] = "master",
        [SoundCategory.Music] = "music",
        [SoundCategory.Records] = "record",
        [SoundCategory.Weather] = "weather",
        [SoundCategory.Blocks] = "block",
        [SoundCategory.Hostile] = "hostile",
        [SoundCategory.Neutral] = "neutral",
        [SoundCategory.Players] = "player",
        [SoundCategory.Ambient] = "ambient",
        [SoundCategory.Voice] = "voice",
        [SoundCategory.Ui] = "ui"
    };

    private readonly string? _path;
    private readonly List<string> _unknown = [];

    public int Fov { get; set; } = 70;

    /// <summary>The slider's position, 0 to 1; <c>MouseHandler.turnPlayer</c> cubes it.</summary>
    public double Sensitivity { get; set; } = 0.5;

    public float[] Volumes { get; } = Enumerable.Repeat(1.0F, CategoryNames.Count).ToArray();

    /// <summary><c>entityDistanceScaling</c>, 0.5 to 5 in quarters: how far entities are drawn, against the render distance's own scale.</summary>
    public double EntityDistanceScaling { get; set; } = 1.0;

    /// <summary>The accessibility options <c>glintSpeed</c> and <c>glintStrength</c>, 0 to 1.</summary>
    public double GlintSpeed { get; set; } = 0.5;

    /// <inheritdoc cref="GlintSpeed"/>
    public double GlintStrength { get; set; } = 0.75;

    /// <summary>The accessibility option <c>screenEffectScale</c>, 0 to 1: how far the portal and nausea warp the view.</summary>
    public double ScreenEffectScale { get; set; } = 1.0;

    /// <summary>The accessibility option <c>fovEffectScale</c>, 0 to 1: how far speed, flight, a bow and fluids change the field of view.</summary>
    public double FovEffectScale { get; set; } = 1.0;

    /// <summary>The video option <c>vignette</c>: the darkening at the screen's edges, and the world border's warning tint.</summary>
    public bool Vignette { get; set; } = true;

    private GameSettings(string? path) {
        _path = path;
    }

    public static GameSettings Load(string? path) {
        GameSettings settings = new(path);
        if (path == null || !File.Exists(path)) {
            return settings;
        }
        foreach (string line in File.ReadAllLines(path)) {
            int colon = line.IndexOf(':');
            if (colon < 0 || !settings.Read(line[..colon], line[(colon + 1)..])) {
                settings._unknown.Add(line);
            }
        }
        return settings;
    }

    private bool Read(string key, string value) {
        if (key == "vignette") {
            if (bool.TryParse(value, out bool on)) {
                Vignette = on;
            }
            return true;
        }
        if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double number)) {
            return false;
        }
        switch (key) {
            case "fov":
                // Stored as Options' fov codec does, -1 to 1 around 70.
                Fov = Math.Clamp((int)(number * 40.0 + 70.0), 30, 110);
                return true;
            case "mouseSensitivity":
                Sensitivity = Math.Clamp(number, 0.0, 1.0);
                return true;
            case "glintSpeed":
                GlintSpeed = Math.Clamp(number, 0.0, 1.0);
                return true;
            case "glintStrength":
                GlintStrength = Math.Clamp(number, 0.0, 1.0);
                return true;
            case "screenEffectScale":
                ScreenEffectScale = Math.Clamp(number, 0.0, 1.0);
                return true;
            case "fovEffectScale":
                FovEffectScale = Math.Clamp(number, 0.0, 1.0);
                return true;
            case "entityDistanceScaling":
                // Codec.doubleRange: a value outside it is skipped, keeping the default.
                if (number is >= 0.5 and <= 5.0) {
                    EntityDistanceScaling = number;
                }
                return true;
        }
        foreach ((SoundCategory category, string name) in CategoryNames) {
            if (key == "soundCategory_" + name) {
                Volumes[(int)category] = (float)Math.Clamp(number, 0.0, 1.0);
                return true;
            }
        }
        return false;
    }

    public void Save() {
        if (_path == null) {
            return;
        }
        List<string> lines = [
            "fov:" + ((Fov - 70.0) / 40.0).ToString(CultureInfo.InvariantCulture),
            "mouseSensitivity:" + Sensitivity.ToString(CultureInfo.InvariantCulture),
            "glintSpeed:" + GlintSpeed.ToString(CultureInfo.InvariantCulture),
            "glintStrength:" + GlintStrength.ToString(CultureInfo.InvariantCulture),
            "screenEffectScale:" + ScreenEffectScale.ToString(CultureInfo.InvariantCulture),
            "fovEffectScale:" + FovEffectScale.ToString(CultureInfo.InvariantCulture),
            "vignette:" + (Vignette ? "true" : "false"),
            "entityDistanceScaling:" + EntityDistanceScaling.ToString(CultureInfo.InvariantCulture)
        ];
        foreach ((SoundCategory category, string name) in CategoryNames) {
            lines.Add($"soundCategory_{name}:" + Volumes[(int)category].ToString(CultureInfo.InvariantCulture));
        }
        lines.AddRange(_unknown);
        try {
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
            File.WriteAllLines(_path, lines);
        }
        catch (IOException e) {
            Console.Error.WriteLine($"Could not save the options: {e.Message}");
        }
    }
}
