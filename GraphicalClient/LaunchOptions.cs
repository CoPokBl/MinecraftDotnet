using System.Globalization;
using System.Numerics;
using Minecraft.Schemas.Sound;

namespace GraphicalClient;

/// <summary>
/// Everything the client is started with. The options a player can also change in game are kept in
/// <see cref="GameSettings"/>; a flag given here overrides the saved value.
/// </summary>
public sealed class LaunchOptions {
    public string Host { get; private set; } = "localhost";
    public int Port { get; private set; } = 25565;
    public string Username { get; private set; } = "Player";
    public bool Microsoft { get; private set; }
    public string? Brand { get; private set; }
    public int ViewDistance { get; private set; } = 12;

    /// <summary>Chunks out at which terrain drops to half detail, 0 for never.</summary>
    public int LodDistance { get; private set; } = 12;
    public bool Headless { get; private set; }
    public int Width { get; private set; } = 1280;
    public int Height { get; private set; } = 720;
    public bool Fullscreen { get; private set; }
    public int? Fov { get; private set; }
    public double? MouseSensitivity { get; private set; }
    public bool VSync { get; private set; }

    /// <summary>Null caps at the display's refresh rate; 0 is uncapped.</summary>
    public int? MaxFps { get; private set; }
    public string? Screenshot { get; private set; }
    public double? ExitAfter { get; private set; }
    public double ScreenshotAfter { get; private set; } = 8.0;
    public bool Verbose { get; private set; }
    public bool LogSent { get; private set; }

    /// <summary>Degrees a second the view turns by itself.</summary>
    public float Spin { get; private set; }
    public Dictionary<SoundCategory, float> Volumes { get; } = new();
    public bool DebugOverlay { get; private set; }
    public bool OpenInventory { get; private set; }

    /// <summary>Where the cursor is taken to be, in window pixels, in place of the real one.</summary>
    public Vector2? Cursor { get; private set; }
    public string? OpenChat { get; private set; }

    /// <summary>Seconds after joining to right click once.</summary>
    public double? UseAfter { get; private set; }
    public bool AutoRespawn { get; private set; }

    /// <summary>Text typed into the open screen at a time after joining, <c>\n</c> pressing Enter.</summary>
    public List<(double At, string Text)> Types { get; } = [];

    /// <summary>Left clicks on the open screen at a time after joining, in GUI pixels.</summary>
    public List<(double At, float X, float Y)> Clicks { get; } = [];

    /// <summary>Keys pressed once at a time after joining: a digit, a key's name, or attack for a left click.</summary>
    public List<(string Key, double At)> Presses { get; } = [];

    /// <summary>Keys held over a window of seconds after joining: w, a, s, d, space, shift and ctrl, and e pressed once.</summary>
    public List<(string[] Keys, double From, double To)> Holds { get; } = [];
    public string? Shaders { get; private set; }

    /// <summary>Resource packs, lowest priority first: later ones override earlier ones file by file.</summary>
    public List<string> ResourcePacks { get; } = [];
    public bool VanillaPack { get; private set; }

    /// <summary>The game's own sounds and other assets the jar lacks, set by the program when <see cref="VanillaPack"/> fetched them.</summary>
    public Assets.ResourcePacks.VanillaAssets? VanillaAssets { get; set; }
    public List<string> Commands { get; } = [];

    /// <param name="Value">The argument's placeholder, null for a switch.</param>
    /// <param name="Help">Null leaves the flag out of <see cref="Usage"/>.</param>
    private sealed record Flag(string Name, string? Value, string? Help, Action<LaunchOptions, string> Apply);

    private static readonly Flag[] Flags = [
        new("--server", "<host[:port]>", "Server to join (default localhost:25565)", (o, v) => o.SetServer(v)),
        new("--username", "<name>", "Offline mode username (default Player)", (o, v) => o.Username = v),
        new("--microsoft", null, "Sign in with a Microsoft account for online mode servers", (o, _) => o.Microsoft = true),
        new("--brand", "<name>", "Client brand told to the server (default mcdotnet; vanilla sends vanilla)", (o, v) => o.Brand = v),
        new("--view-distance", "<n>", "Chunks, 2 to 32 (default 12)", (o, v) => o.ViewDistance = Math.Clamp(Int(v), 2, 32)),
        new("--lod-distance", "<n>", "Chunks out at which terrain drops to half detail, quarter at\ntwice that; 0 keeps full detail everywhere (default 12)",
            (o, v) => o.LodDistance = Math.Max(0, Int(v))),
        new("--width", "<px>", "", (o, v) => o.Width = Int(v)),
        new("--height", "<px>", "", (o, v) => o.Height = Int(v)),
        new("--fullscreen", null, "", (o, _) => o.Fullscreen = true),
        new("--fov", "<30..110>", "Vertical field of view, overriding Options (default 70)", (o, v) => o.Fov = Math.Clamp(Int(v), 30, 110)),
        new("--sensitivity", "<0..1>", "Mouse sensitivity, overriding Options (default 0.5)", (o, v) => o.MouseSensitivity = Math.Clamp(Double(v), 0, 1)),
        new("--vsync", null, "Sync to the display. Off by default: under Wayland a hidden\nwindow then stops presenting, which stalls the game loop",
            (o, _) => o.VSync = true),
        new("--no-vsync", null, null, (o, _) => o.VSync = false),
        new("--max-fps", "<n>", "Frame cap without vsync, 0 for none (default: the display's refresh rate)", (o, v) => o.MaxFps = Int(v)),
        new("--headless", null, "Join without a window, for testing", (o, _) => o.Headless = true),
        new("--run", "<text>", "Send a chat line or command once joined; repeatable", (o, v) => o.Commands.Add(v)),
        new("--screenshot", "<file.png>", "Save a frame then keep running (see --exit-after)", (o, v) => o.Screenshot = v),
        new("--screenshot-after", "<s>", "Seconds after joining to take it (default 8)", (o, v) => o.ScreenshotAfter = Double(v)),
        new("--exit-after", "<s>", "Quit after this many seconds", (o, v) => o.ExitAfter = Double(v)),
        new("--verbose", null, "Log frame rate, section counts and the slowest frame every second", (o, _) => o.Verbose = true),
        new("--log-sent", null, "Log the sprint, held slot, attack, block action and position packets sent, for\nscripted tests", (o, _) => o.LogSent = true),
        new("--spin", "<degrees/s>", "Turn the view by itself, for measuring what looking around costs", (o, v) => o.Spin = Float(v)),
        new("--f3", null, "Start with the debug overlay open", (o, _) => o.DebugOverlay = true),
        new("--open-inventory", null, "Open the inventory once joined, for screenshots", (o, _) => o.OpenInventory = true),
        new("--cursor", "<x>,<y>", "Take the cursor to be at this window pixel, for screenshots", (o, v) => o.SetCursor(v)),
        new("--open-chat", "<text>", "Open chat and type the text once joined, for screenshots", (o, v) => o.OpenChat = v),
        new("--use-after", "<s>", "Right click once this many seconds after joining, for screenshots", (o, v) => o.UseAfter = Double(v)),
        new("--hold", "<keys>@<from>-<to>", "Hold keys (w,a,s,d,space,shift,ctrl,e,use, comma separated) from <from> to\n<to> seconds after joining, for scripted tests; repeatable",
            (o, v) => o.AddHold(v)),
        new("--press", "<key>@<s>", "Press a key (a digit, a key name such as Escape, or attack for a left\nclick) once this many seconds after joining, for scripted tests; repeatable,\nin time order",
            (o, v) => o.Presses.Add((v.Split('@', 2)[0], Double(v.Split('@', 2)[1])))),
        new("--type", "<s>:<text>", "Type into the open screen this many seconds after joining, \\n for Enter;\nrepeatable", (o, v) => o.AddType(v)),
        new("--click", "<x>,<y>@<s>", "Left click the open screen at this GUI pixel this many seconds after\njoining; repeatable", (o, v) => o.AddClick(v)),
        new("--auto-respawn", null, "Respawn at once on death instead of showing the death screen", (o, _) => o.AutoRespawn = true),
        new("--shaders", "<dir>", "Use the shader pack in this folder (F7 reloads it)", (o, v) => o.Shaders = v),
        new("--resource-pack", "<path>", "A resource pack folder or zip, or the game's jar for its own look;\nrepeatable, later packs override earlier ones",
            (o, v) => o.ResourcePacks.Add(v)),
        new("--vanilla-pack", null, "Download the vanilla client jar and sounds once (cached under local app\ndata) and use them as the bottom resource pack",
            (o, _) => o.VanillaPack = true),
        new("--volume", "<category=0..1>", "A sound category's volume: master, music, record, weather, block,\nhostile, neutral, player, ambient, voice or ui; repeatable",
            (o, v) => o.SetVolume(v))
    ];

    private const int HelpColumn = 27;

    public static string Usage => "Usage: GraphicalClient --server <host[:port]> [options]\n\n" + string.Join("\n", Flags.Where(f => f.Help != null).Select(f => {
        string flag = f.Value == null ? $"  {f.Name}" : $"  {f.Name} {f.Value}";
        if (f.Help == "") {
            return flag;
        }
        return (flag.Length < HelpColumn ? flag.PadRight(HelpColumn) : flag + " ") + f.Help!.Replace("\n", "\n" + new string(' ', HelpColumn));
    }));

    public static LaunchOptions Parse(string[] args) {
        LaunchOptions options = new();
        for (int i = 0; i < args.Length; i++) {
            string arg = args[i];
            if (arg is "--help" or "-h") {
                throw new HelpRequestedException();
            }
            Flag flag = Array.Find(Flags, f => f.Name == arg) ?? throw new ArgumentException($"Unknown argument {arg}");
            string value = flag.Value == null ? "" : i + 1 < args.Length ? args[++i] : throw new ArgumentException($"{arg} needs a value");
            flag.Apply(options, value);
        }
        return options;
    }

    private static int Int(string value) => int.Parse(value, CultureInfo.InvariantCulture);

    private static double Double(string value) => double.Parse(value, CultureInfo.InvariantCulture);

    private static float Float(string value) => float.Parse(value, CultureInfo.InvariantCulture);

    private void SetServer(string server) {
        int colon = server.LastIndexOf(':');
        if (colon > 0 && !server.EndsWith(']')) {
            Host = server[..colon];
            Port = Int(server[(colon + 1)..]);
        }
        else {
            Host = server;
        }
    }

    private void SetCursor(string value) {
        string[] cursor = value.Split(',');
        Cursor = new Vector2(Float(cursor[0]), Float(cursor[1]));
    }

    private void AddHold(string value) {
        string[] parts = value.Split('@', 2);
        string[] window = parts[1].Split('-', 2);
        Holds.Add((parts[0].Split(','), Double(window[0]), Double(window[1])));
    }

    private void AddType(string value) {
        string[] parts = value.Split(':', 2);
        Types.Add((Double(parts[0]), parts[1].Replace("\\n", "\n")));
    }

    private void AddClick(string value) {
        string[] parts = value.Split('@', 2);
        string[] point = parts[0].Split(',');
        Clicks.Add((Double(parts[1]), Float(point[0]), Float(point[1])));
    }

    private void SetVolume(string value) {
        string[] parts = value.Split('=', 2);
        foreach ((SoundCategory category, string name) in GameSettings.CategoryNames) {
            if (name == parts[0]) {
                Volumes[category] = parts.Length == 2 ? Math.Clamp(Float(parts[1]), 0, 1) : 1;
                return;
            }
        }
        throw new ArgumentException($"Unknown sound category {parts[0]}");
    }
}

public sealed class HelpRequestedException : Exception;
