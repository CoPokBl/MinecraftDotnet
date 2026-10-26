using System.Globalization;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace GraphicalClient;

/// <summary>
/// The options a player changes from the options screens, kept in an <c>options.txt</c> written the way
/// vanilla's <c>Options.save</c> writes its own: one <c>key:value</c> a line, under the same keys and in
/// the same stored units. Lines this client does not know are kept as they were.
/// </summary>
public sealed partial class GameSettings {
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

    /// <summary>The file's own value for each key it held, which an overridden option writes back.</summary>
    private readonly Dictionary<string, string> _fileValues = [];

    /// <summary>
    /// Options set by launch flags, by key, with the value they took. They last for the run only: saving
    /// writes the file's value back for each, unless the player has since changed it in game.
    /// </summary>
    private readonly Dictionary<string, string> _overrides = [];

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

    /// <summary>
    /// The accessibility option <c>darknessEffectScale</c>, 0 to 1: how far the darkness effect dims and pulses the
    /// lightmap. Its slider and <c>options.txt</c> hold the square root, as <c>fovEffectScale</c>'s do.
    /// </summary>
    public double DarknessEffectScale { get; set; } = 1.0;

    /// <summary>The video option <c>gamma</c>, shown as Brightness: 0 is Moody, 0.5 the default, 1 Bright.</summary>
    public double Gamma { get; set; } = 0.5;

    /// <summary>The video option <c>particles</c>, which the server is told of too.</summary>
    public ParticleStatus Particles { get; set; } = ParticleStatus.All;

    /// <summary>The video option <c>vignette</c>: the darkening at the screen's edges, and the world border's warning tint.</summary>
    public bool Vignette { get; set; } = true;

    /// <summary>The video option <c>ao</c>, Smooth Lighting: blocks whose model asks for it are lit with ambient occlusion.</summary>
    public bool AmbientOcclusion { get; set; } = true;

    /// <summary>The video option <c>entityShadows</c>: the round shadows under entities, and entities throwing shadows at all.</summary>
    public bool EntityShadows { get; set; } = true;

    /// <summary><c>lastServer</c>: what direct connect last had typed in.</summary>
    public string LastServer { get; set; } = "";

    /// <summary><c>skipMultiplayerWarning</c>: the online play warning was ticked away.</summary>
    public bool SkipMultiplayerWarning { get; set; }

    /// <summary><c>hideServerAddress</c>: LAN games list without their address.</summary>
    public bool HideServerAddress { get; set; }

    /// <summary>The accessibility option <c>panoramaScrollSpeed</c>, 0 to 1.</summary>
    public double PanoramaSpeed { get; set; } = 1.0;

    /// <summary>The accessibility option <c>hideSplashTexts</c>.</summary>
    public bool HideSplashTexts { get; set; }

    /// <summary>The <c>key_</c> lines.</summary>
    public KeyBinds Keys { get; } = new();

    /// <summary>The controls options <c>toggleCrouch</c>, <c>toggleSprint</c>, <c>toggleAttack</c> and <c>toggleUse</c>: a press flips the key rather than holding it.</summary>
    public bool ToggleCrouch { get; set; }

    /// <inheritdoc cref="ToggleCrouch"/>
    public bool ToggleSprint { get; set; }

    /// <inheritdoc cref="ToggleCrouch"/>
    public bool ToggleAttack { get; set; }

    /// <inheritdoc cref="ToggleCrouch"/>
    public bool ToggleUse { get; set; }

    public bool AutoJump { get; set; }

    /// <summary><c>sprintWindow</c>, 0 to 10 ticks: how quickly forward must be pressed twice to sprint, 0 for never.</summary>
    public int SprintWindow { get; set; } = 7;

    public bool OperatorItemsTab { get; set; }

    /// <summary><c>mouseWheelSensitivity</c>, 0.01 to 10 on a log scale.</summary>
    public double MouseWheelSensitivity { get; set; } = 1.0;

    public bool DiscreteMouseScroll { get; set; }
    public bool InvertMouseX { get; set; }
    public bool InvertMouseY { get; set; }
    public bool RawMouseInput { get; set; } = true;
    public bool AllowCursorChanges { get; set; } = true;

    /// <summary>The <c>modelPart_</c> lines, as the bit set <c>buildPlayerInformation</c> sends.</summary>
    public SkinParts ModelParts { get; set; } = SkinParts.All;

    public DominantHand MainHand { get; set; } = DominantHand.Right;

    public Narration.NarratorStatus Narrator { get; set; } = Narration.NarratorStatus.Off;

    /// <summary>The accessibility option <c>narratorHotkey</c>: whether Ctrl+B cycles the narrator.</summary>
    public bool NarratorHotkey { get; set; } = true;

    /// <summary><c>darkMojangStudiosBackground</c>: the loading overlay on black instead of its usual colour.</summary>
    public bool DarkMojangStudiosBackground { get; set; }

    /// <summary><c>resourcePacks</c>: the chosen packs that are not fixed in place, lowest first, by pack id.</summary>
    public List<string> ResourcePacks { get; set; } = [];

    /// <summary><c>incompatibleResourcePacks</c>: those of them the player chose despite their format.</summary>
    public List<string> IncompatibleResourcePacks { get; set; } = [];

    /// <summary><c>lang</c>, the language code the translations and the client information use.</summary>
    public string Language { get; set; } = "en_us";

    /// <summary><c>forceUnicodeFont</c>: every character from the unifont, the font's <c>uniform</c> option.</summary>
    public bool ForceUnicodeFont { get; set; }

    /// <summary><c>japaneseGlyphVariants</c>, the font's <c>jp</c> option; on by default where the system's language is Japanese.</summary>
    public bool JapaneseGlyphVariants { get; set; } = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ja";

    /// <summary><c>Options.save</c>'s <c>broadcastOptions</c>, which runs after every save, written or not.</summary>
    public event Action? Saved;

    /// <summary><c>PlayerModelPart</c>'s ids, in its order, by bit.</summary>
    public static readonly (SkinParts Part, string Id)[] ModelPartIds = [
        (SkinParts.CapeEnabled, "cape"), (SkinParts.JacketEnabled, "jacket"), (SkinParts.LeftSleeveEnabled, "left_sleeve"),
        (SkinParts.RightSleeveEnabled, "right_sleeve"), (SkinParts.LeftPantsEnabled, "left_pants_leg"),
        (SkinParts.RightPantsEnabled, "right_pants_leg"), (SkinParts.HatEnabled, "hat")
    ];

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
            else {
                settings._fileValues[line[..colon]] = line[(colon + 1)..];
            }
        }
        return settings;
    }

    /// <summary>Sets one option from its <c>options.txt</c> key and value, as a launch flag does.</summary>
    /// <exception cref="ArgumentException">The key is not one this client keeps, or the value does not parse.</exception>
    public void Override(string key, string value) {
        if (!Read(key, value)) {
            throw new ArgumentException($"Unknown option {key}, or a value it cannot take: {value}");
        }
    }

    /// <summary>Applies launch flags over the saved options for this run only, leaving the file as it was.</summary>
    public void ApplyOverrides(IEnumerable<(string Key, string Value)> overrides) {
        HashSet<string> keys = [];
        foreach ((string key, string value) in overrides) {
            Override(key, value);
            keys.Add(key);
        }
        foreach ((string key, string value) in Lines().Select(Split)) {
            if (keys.Contains(key)) {
                _overrides[key] = value;
            }
        }
    }

    private static (string Key, string Value) Split(string line) {
        int colon = line.IndexOf(':');
        return (line[..colon], line[(colon + 1)..]);
    }

    /// <summary>
    /// One <c>options.txt</c> line. Every option a screen changes is read here, which is also what makes it
    /// overridable from the command line.
    /// </summary>
    private bool Read(string key, string value) {
        if (ReadControls(key, value) is { } controls) {
            return controls;
        }
        if (ReadMenus(key, value) is { } menus) {
            return menus;
        }
        if (ReadPacks(key, value) is { } packs) {
            return packs;
        }
        if (ReadChat(key, value) is { } chat) {
            return chat;
        }
        if (ReadToasts(key, value) is { } toasts) {
            return toasts;
        }
        if (ReadWeather(key, value) is { } weather) {
            return weather;
        }
        if (ReadMusic(key, value) is { } music) {
            return music;
        }
        if (key == "particles") {
            // ParticleStatus.LEGACY_CODEC: the id, wrapped round the three values.
            if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int particles)) {
                return false;
            }
            Particles = (ParticleStatus)((particles % 3 + 3) % 3);
            return true;
        }
        if (key == "entityShadows") {
            return Bool(value, on => EntityShadows = on);
        }
        if (key == "ao") {
            return Bool(value, on => AmbientOcclusion = on);
        }
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
            // Both are UnitDouble.xmap(square, sqrt): the file holds the slider's position, and one outside the
            // unit range is skipped, keeping the default.
            case "fovEffectScale":
                if (number is >= 0.0 and <= 1.0) {
                    FovEffectScale = number * number;
                }
                return true;
            case "darknessEffectScale":
                if (number is >= 0.0 and <= 1.0) {
                    DarknessEffectScale = number * number;
                }
                return true;
            case "gamma":
                // UnitDouble's codec: a value outside it is skipped, keeping the default.
                if (number is >= 0.0 and <= 1.0) {
                    Gamma = number;
                }
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

    /// <summary>The controls, skin and narrator lines; null for a key that is none of them.</summary>
    private bool? ReadControls(string key, string value) {
        if (key.StartsWith("key_", StringComparison.Ordinal) && Keys.Get(key[4..]) is { } bind) {
            try {
                bind.Key = InputKey.FromName(value);
                return true;
            }
            catch (Exception e) when (e is FormatException or OverflowException) {
                return false;
            }
        }
        foreach ((SkinParts part, string id) in ModelPartIds) {
            if (key == "modelPart_" + id) {
                return Bool(value, on => ModelParts = on ? ModelParts | part : ModelParts & ~part);
            }
        }
        switch (key) {
            case "toggleCrouch": return Bool(value, on => ToggleCrouch = on);
            case "toggleSprint": return Bool(value, on => ToggleSprint = on);
            case "toggleAttack": return Bool(value, on => ToggleAttack = on);
            case "toggleUse": return Bool(value, on => ToggleUse = on);
            case "autoJump": return Bool(value, on => AutoJump = on);
            case "operatorItemsTab": return Bool(value, on => OperatorItemsTab = on);
            case "discrete_mouse_scroll": return Bool(value, on => DiscreteMouseScroll = on);
            case "invertXMouse": return Bool(value, on => InvertMouseX = on);
            case "invertYMouse": return Bool(value, on => InvertMouseY = on);
            case "rawMouseInput": return Bool(value, on => RawMouseInput = on);
            case "allowCursorChanges": return Bool(value, on => AllowCursorChanges = on);
            case "narratorHotkey": return Bool(value, on => NarratorHotkey = on);
            case "darkMojangStudiosBackground": return Bool(value, on => DarkMojangStudiosBackground = on);
            case "sprintWindow":
                // IntRange(0, 10): a value outside it fails the codec, keeping the default.
                if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int window) || window is < 0 or > 10) {
                    return false;
                }
                SprintWindow = window;
                return true;
            case "mouseWheelSensitivity":
                if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double wheel) || wheel is < 0.01 or > 10.0) {
                    return false;
                }
                MouseWheelSensitivity = wheel;
                return true;
            case "narrator":
                // NarratorStatus.LEGACY_CODEC: the id, wrapped round the four values.
                if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int narrator)) {
                    return false;
                }
                Narrator = (Narration.NarratorStatus)((narrator % 4 + 4) % 4);
                return true;
            case "mainHand":
                // HumanoidArm.CODEC as JSON, which the lenient parser also takes unquoted.
                switch (value.Trim('"')) {
                    case "left": MainHand = DominantHand.Left; return true;
                    case "right": MainHand = DominantHand.Right; return true;
                    default: return false;
                }
        }
        return null;
    }

    private static bool Bool(string value, Action<bool> set) {
        if (!bool.TryParse(value, out bool on)) {
            return false;
        }
        set(on);
        return true;
    }

    /// <summary>The title screen's and server list's options; null for a key that is not one of them.</summary>
    private bool? ReadMenus(string key, string value) {
        switch (key) {
            case "lastServer":
                LastServer = value;
                return true;
            case "skipMultiplayerWarning" or "hideServerAddress" or "hideSplashTexts":
                if (value is not ("true" or "false")) {
                    return false;
                }
                if (key == "hideServerAddress") {
                    HideServerAddress = value == "true";
                }
                else if (key == "hideSplashTexts") {
                    HideSplashTexts = value == "true";
                }
                else {
                    SkipMultiplayerWarning = value == "true";
                }
                return true;
            case "panoramaScrollSpeed":
                // UnitDouble's codec: 0 to 1, or a boolean for either end.
                if (value is "true" or "false") {
                    PanoramaSpeed = value == "true" ? 1.0 : 0.0;
                    return true;
                }
                if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double speed) || speed is < 0.0 or > 1.0) {
                    return false;
                }
                PanoramaSpeed = speed;
                return true;
        }
        return null;
    }

    public void Save() {
        try {
            Write();
        }
        finally {
            Saved?.Invoke();
        }
    }

    private void Write() {
        if (_path == null) {
            return;
        }
        List<string> lines = [];
        Dictionary<string, string>? defaults = null;
        foreach (string line in Lines()) {
            (string key, string value) = Split(line);
            if (!_overrides.TryGetValue(key, out string? overridden)) {
                lines.Add(line);
            }
            else if (value != overridden) {
                _overrides.Remove(key);
                lines.Add(line);
            }
            else if (_fileValues.TryGetValue(key, out string? saved)) {
                lines.Add($"{key}:{saved}");
            }
            else {
                defaults ??= new GameSettings(null).Lines().Select(Split).ToDictionary(l => l.Key, l => l.Value);
                lines.Add($"{key}:{defaults[key]}");
            }
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

    /// <summary>Every option this client keeps, as its <c>options.txt</c> line.</summary>
    private List<string> Lines() {
        List<string> lines = [
            "fov:" + ((Fov - 70.0) / 40.0).ToString(CultureInfo.InvariantCulture),
            "mouseSensitivity:" + Sensitivity.ToString(CultureInfo.InvariantCulture),
            "glintSpeed:" + GlintSpeed.ToString(CultureInfo.InvariantCulture),
            "glintStrength:" + GlintStrength.ToString(CultureInfo.InvariantCulture),
            "screenEffectScale:" + ScreenEffectScale.ToString(CultureInfo.InvariantCulture),
            "fovEffectScale:" + Math.Sqrt(FovEffectScale).ToString(CultureInfo.InvariantCulture),
            "darknessEffectScale:" + Math.Sqrt(DarknessEffectScale).ToString(CultureInfo.InvariantCulture),
            "gamma:" + Gamma.ToString(CultureInfo.InvariantCulture),
            "vignette:" + (Vignette ? "true" : "false"),
            "entityShadows:" + Lower(EntityShadows),
            "ao:" + Lower(AmbientOcclusion),
            "particles:" + (int)Particles,
            "entityDistanceScaling:" + EntityDistanceScaling.ToString(CultureInfo.InvariantCulture)
        ];
        lines.AddRange([
            "autoJump:" + Lower(AutoJump), "operatorItemsTab:" + Lower(OperatorItemsTab), "discrete_mouse_scroll:" + Lower(DiscreteMouseScroll),
            "invertXMouse:" + Lower(InvertMouseX), "invertYMouse:" + Lower(InvertMouseY), "toggleCrouch:" + Lower(ToggleCrouch),
            "toggleSprint:" + Lower(ToggleSprint), "toggleAttack:" + Lower(ToggleAttack), "toggleUse:" + Lower(ToggleUse),
            "sprintWindow:" + SprintWindow.ToString(CultureInfo.InvariantCulture), "narratorHotkey:" + Lower(NarratorHotkey),
            "narrator:" + (int)Narrator, "mainHand:" + (MainHand == DominantHand.Left ? "\"left\"" : "\"right\""),
            "mouseWheelSensitivity:" + MouseWheelSensitivity.ToString(CultureInfo.InvariantCulture), "rawMouseInput:" + Lower(RawMouseInput),
            "allowCursorChanges:" + Lower(AllowCursorChanges), "darkMojangStudiosBackground:" + Lower(DarkMojangStudiosBackground)
        ]);
        foreach (KeyBind bind in Keys.All) {
            lines.Add($"key_{bind.Name}:{bind.Key.Name}");
        }
        foreach ((SoundCategory category, string name) in CategoryNames) {
            lines.Add($"soundCategory_{name}:" + Volumes[(int)category].ToString(CultureInfo.InvariantCulture));
        }
        foreach ((SkinParts part, string id) in ModelPartIds) {
            lines.Add($"modelPart_{id}:" + Lower((ModelParts & part) != 0));
        }
        lines.AddRange([
            "lastServer:" + LastServer, "skipMultiplayerWarning:" + Lower(SkipMultiplayerWarning), "hideServerAddress:" + Lower(HideServerAddress), "hideSplashTexts:" + Lower(HideSplashTexts),
            "panoramaScrollSpeed:" + PanoramaSpeed.ToString(CultureInfo.InvariantCulture)
        ]);
        lines.AddRange([
            "resourcePacks:" + GsonList(ResourcePacks), "incompatibleResourcePacks:" + GsonList(IncompatibleResourcePacks), "lang:" + Language,
            "forceUnicodeFont:" + Lower(ForceUnicodeFont), "japaneseGlyphVariants:" + Lower(JapaneseGlyphVariants)
        ]);
        lines.AddRange(ChatLines());
        lines.AddRange(ToastLines());
        lines.AddRange(WeatherLines());
        lines.AddRange(MusicLines());
        return lines;
    }

    private static string Lower(bool value) => value ? "true" : "false";

    /// <summary>The resource pack, language and font lines; null for a key that is none of them.</summary>
    private bool? ReadPacks(string key, string value) {
        switch (key) {
            case "lang":
                Language = value;
                return true;
            case "forceUnicodeFont":
                return Bool(value, on => ForceUnicodeFont = on);
            case "japaneseGlyphVariants":
                return Bool(value, on => JapaneseGlyphVariants = on);
            case "resourcePacks" or "incompatibleResourcePacks":
                // Options.readListOfStrings: a JSON list of strings, an empty value being an empty list.
                List<string>? list;
                try {
                    list = value.Trim().Length == 0 ? [] : Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(value);
                }
                catch (Newtonsoft.Json.JsonException) {
                    return false;
                }
                if (key == "resourcePacks") {
                    ResourcePacks = list ?? [];
                }
                else {
                    IncompatibleResourcePacks = list ?? [];
                }
                return true;
        }
        return null;
    }

    /// <summary>A list of strings as <c>new Gson().toJson</c> writes it, which escapes the HTML characters too.</summary>
    private static string GsonList(IEnumerable<string> values) {
        System.Text.StringBuilder json = new("[");
        foreach (string value in values) {
            if (json.Length > 1) {
                json.Append(',');
            }
            json.Append('"');
            foreach (char c in value) {
                json.Append(c switch {
                    '"' => "\\\"",
                    '\\' => "\\\\",
                    '\t' => "\\t",
                    '\b' => "\\b",
                    '\n' => "\\n",
                    '\r' => "\\r",
                    '\f' => "\\f",
                    < ' ' or '<' or '>' or '&' or '=' or '\'' or '\u2028' or '\u2029' => $"\\u{(int)c:x4}",
                    _ => c.ToString()
                });
            }
            json.Append('"');
        }
        return json.Append(']').ToString();
    }
}
