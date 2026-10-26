using System.Globalization;
using System.Numerics;
using Minecraft.Schemas.Sound;

namespace GraphicalClient;

/// <summary>
/// Everything the client is started with. The options a player can also change in game are kept in
/// <see cref="GameSettings"/>; a flag given here overrides the saved value for this run, and never changes
/// the saved file.
/// </summary>
public sealed class LaunchOptions {
    public string Host { get; private set; } = "localhost";
    public int Port { get; private set; } = 25565;

    /// <summary>Whether <c>--server</c> was given. Without it the window opens on the title screen; headless joins the default.</summary>
    public bool ServerGiven { get; private set; }

    /// <summary><c>--server</c> as typed, which is the address its server list entry is kept under.</summary>
    public string ServerText { get; private set; } = "localhost";

    /// <summary><c>--title</c>: the title screen even with a server given, which then is not joined.</summary>
    public bool Title { get; private set; }

    /// <summary>
    /// <c>--return-to-menu</c>: a disconnect from the <c>--server</c> join leads back to the server list as
    /// vanilla's does, rather than stopping on the disconnected screen, and the pause menu's Disconnect
    /// goes there rather than closing the window.
    /// </summary>
    public bool ReturnToMenu { get; private set; }

    /// <summary>Whether leaving a server leads to the server list rather than ending the session.</summary>
    public bool Menus => !ServerGiven || Title || ReturnToMenu;
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
    public bool VSync { get; private set; }

    /// <summary>Null caps at the display's refresh rate; 0 is uncapped.</summary>
    public int? MaxFps { get; private set; }
    public string? Screenshot { get; private set; }
    public double? ExitAfter { get; private set; }
    public double ScreenshotAfter { get; private set; } = 8.0;
    public bool Verbose { get; private set; }
    public bool LogSent { get; private set; }
    public bool LogInventory { get; private set; }

    /// <summary>Degrees a second the view turns by itself.</summary>
    public float Spin { get; private set; }
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
    public List<(double At, float X, float Y, bool Right)> Clicks { get; } = [];
    public List<(double At, float Delta)> Scrolls { get; } = [];

    /// <summary>Keys pressed once at a time after joining: a digit, a key's name, or attack for a left click.</summary>
    public List<(string Key, double At)> Presses { get; } = [];

    /// <summary>Keys held over a window of seconds after joining: w, a, s, d, space, shift and ctrl, and e pressed once.</summary>
    public List<(string[] Keys, double From, double To)> Holds { get; } = [];
    public string? Shaders { get; private set; }

    /// <summary>Resource packs, lowest priority first: later ones override earlier ones file by file.</summary>
    public List<string> ResourcePacks { get; } = [];
    public bool VanillaPack { get; private set; }

    /// <summary>The game's jar, which with <see cref="VanillaAssets"/> is the bottom pack, set by the program when <see cref="VanillaPack"/> fetched it.</summary>
    public string? VanillaJar { get; set; }

    /// <summary><c>--server-packs</c>: every server's resource pack policy, in place of the one the server list keeps.</summary>
    public ClientLib.Multiplayer.ServerPackStatus? ServerPacks { get; private set; }

    /// <summary>The game's own sounds and other assets the jar lacks, set by the program when <see cref="VanillaPack"/> fetched them.</summary>
    public Assets.ResourcePacks.VanillaAssets? VanillaAssets { get; set; }
    public List<string> Commands { get; } = [];

    /// <summary><c>options.txt</c> lines applied over the saved options, in order.</summary>
    public List<(string Key, string Value)> SettingOverrides { get; } = [];

    /// <summary><c>--test-weather</c>: the weather drawn in place of the server's, for testing how it looks.</summary>
    public Rendering.Weather.TestWeather? TestWeather { get; private set; }

    /// <param name="Value">The argument's placeholder, null for a switch.</param>
    /// <param name="Help">Null leaves the flag out of <see cref="Usage"/>.</param>
    private sealed record Flag(string Name, string? Value, string? Help, Action<LaunchOptions, string> Apply);

    /// <summary><c>ChatVisiblity</c> by id, as <c>--chat-visibility</c> names them.</summary>
    private static readonly string[] ChatVisibilities = ["full", "system", "hidden"];
    private static readonly string[] ParticleLevels = ["all", "decreased", "minimal"];

    /// <summary><c>NarratorStatus</c> by id, as <c>--narrator</c> names them.</summary>
    private static readonly string[] NarratorModes = ["off", "all", "chat", "system"];

    private static readonly Flag[] Flags = [
        new("--server", "<host[:port]>", "Server to join at once; without it the window opens on the title screen\n(headless joins localhost:25565)",
            (o, v) => o.SetServer(v)),
        new("--title", null, "Open on the title screen even with --server given, joining nothing; the\nscripted flags' times then count from launch rather than from joining",
            (o, _) => o.Title = true),
        new("--return-to-menu", null, "After leaving or losing the --server join, go back to the server list as\nvanilla does, instead of stopping on the disconnected screen",
            (o, _) => o.ReturnToMenu = true),
        new("--username", "<name>", "Offline mode username (default Player)", (o, v) => o.Username = v),
        new("--microsoft", null, "Sign in with a Microsoft account for online mode servers", (o, _) => o.Microsoft = true),
        new("--brand", "<name>", "Client brand told to the server (default mcdotnet; vanilla sends vanilla)", (o, v) => o.Brand = v),
        new("--view-distance", "<n>", "Chunks, 2 to 32 (default 12)", (o, v) => o.ViewDistance = Math.Clamp(Int(v), 2, 32)),
        new("--lod-distance", "<n>", "Chunks out at which terrain drops to half detail, quarter at\ntwice that; 0 keeps full detail everywhere (default 12)",
            (o, v) => o.LodDistance = Math.Max(0, Int(v))),
        new("--width", "<px>", "", (o, v) => o.Width = Int(v)),
        new("--height", "<px>", "", (o, v) => o.Height = Int(v)),
        new("--fullscreen", null, "", (o, _) => o.Fullscreen = true),
        new("--fov", "<30..110>", "Vertical field of view, overriding Options (default 70)", (o, v) => o.AddSettingOverride("fov:" + ((Math.Clamp(Int(v), 30, 110) - 70.0) / 40.0).ToString(CultureInfo.InvariantCulture))),
        new("--sensitivity", "<0..1>", "Mouse sensitivity, overriding Options (default 0.5)", (o, v) => o.AddSettingOverride("mouseSensitivity:" + Math.Clamp(Double(v), 0, 1).ToString(CultureInfo.InvariantCulture))),
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
        new("--log-sent", null, "Log the sprint, held slot, attack, block action, client command, position,\ncontainer click, recipe book and seen advancements packets sent, for scripted tests", (o, _) => o.LogSent = true),
        new("--log-inventory", null, "Log what the server puts in the player's inventory, with each stack's\ncomponents, and every change to the hotbar and the selected slot", (o, _) => o.LogInventory = true),
        new("--spin", "<degrees/s>", "Turn the view by itself, for measuring what looking around costs", (o, v) => o.Spin = Float(v)),
        new("--f3", null, "Start with the debug overlay open", (o, _) => o.DebugOverlay = true),
        new("--open-inventory", null, "Open the inventory once joined, for screenshots", (o, _) => o.OpenInventory = true),
        new("--cursor", "<x>,<y>", "Take the cursor to be at this window pixel, for screenshots", (o, v) => o.SetCursor(v)),
        new("--open-chat", "<text>", "Open chat and type the text once joined, for screenshots", (o, v) => o.OpenChat = v),
        new("--use-after", "<s>", "Right click once this many seconds after joining, for screenshots", (o, v) => o.UseAfter = Double(v)),
        new("--hold", "<keys>@<from>-<to>", "Hold keys (w,a,s,d,space,shift,ctrl,e,use,attack, comma separated) from <from> to\n<to> seconds after joining, for scripted tests; repeatable",
            (o, v) => o.AddHold(v)),
        new("--press", "<key>@<s>", "Press a key (a digit, a key name such as Escape, or attack for a left\nclick; ctrl+ before it holds Control, as in ctrl+b) once this many seconds\nafter joining, for scripted tests; repeatable, in time order",
            (o, v) => o.Presses.Add((v.Split('@', 2)[0], Double(v.Split('@', 2)[1])))),
        new("--type", "<s>:<text>", "Type into the open screen this many seconds after joining, \\n for Enter;\nrepeatable", (o, v) => o.AddType(v)),
        new("--click", "<x>,<y>[,right]@<s>", "Left click (or right click) the open screen at this GUI pixel this many\nseconds after joining; repeatable", (o, v) => o.AddClick(v)),
        new("--scroll", "<delta>@<s>", "Turn the mouse wheel over the open screen by this many notches (positive is\nup) this many seconds after joining; repeatable, in time order",
            (o, v) => o.Scrolls.Add((Double(v.Split('@', 2)[1]), Float(v.Split('@', 2)[0])))),
        new("--auto-respawn", null, "Respawn at once on death instead of showing the death screen", (o, _) => o.AutoRespawn = true),
        new("--shaders", "<dir>", "Use the shader pack in this folder (F7 reloads it)", (o, v) => o.Shaders = v),
        new("--resource-pack", "<path>", "A resource pack folder or zip, or the game's jar for its own look;\nrepeatable, later packs override earlier ones. These sit fixed just above\nthe game's own pack, under the packs chosen in Options > Resource Packs\n(saved in options.txt), with server packs on top of all; they are not saved",
            (o, v) => o.ResourcePacks.Add(v)),
        new("--vanilla-pack", null, "Download the vanilla client jar and sounds once (cached under local app\ndata) and use them as the bottom resource pack, the game's own",
            (o, _) => o.VanillaPack = true),
        new("--server-packs", "<prompt|accept|decline>", "What to do with a server's resource packs, overriding the server list's\nsetting: ask, take them without asking, or refuse them, refusing for the\nplayer when the server requires one (which then disconnects, as vanilla does)",
            (o, v) => o.ServerPacks = v switch {
                "prompt" => ClientLib.Multiplayer.ServerPackStatus.Prompt,
                "accept" => ClientLib.Multiplayer.ServerPackStatus.Enabled,
                "decline" => ClientLib.Multiplayer.ServerPackStatus.Disabled,
                _ => throw new ArgumentException($"--server-packs takes prompt, accept or decline, not {v}")
            }),
        new("--language", "<code>", "The language, by its code such as de_de, overriding Options > Language;\nthe game's languages need --vanilla-pack (default en_us)",
            (o, v) => o.AddSettingOverride("lang:" + v)),
        new("--option", "<key>:<value>", "Any options.txt setting, by vanilla's key and stored value, overriding the\nsaved one; repeatable. Example: --option glintStrength:0.5",
            (o, v) => o.AddSettingOverride(v)),
        new("--particles", "<all|decreased|minimal>", "How many particles to show, overriding Options > Video Settings; sent to the\nserver as that option is",
            (o, v) => o.AddSettingOverride("particles:" + (Array.IndexOf(ParticleLevels, v) is var level and >= 0 ? level
                : throw new ArgumentException($"--particles takes all, decreased or minimal, not {v}")))),
        new("--no-entity-shadows", null, "No shadows under or thrown by entities, overriding Options > Video Settings",
            (o, _) => o.AddSettingOverride("entityShadows:false")),
        new("--clouds", "<off|fast|fancy>", "The clouds, overriding Options > Video Settings: none, a flat layer, or\ncells with sides",
            (o, v) => o.AddSettingOverride("renderClouds:" + v switch {
                "off" => "false",
                "fast" => "fast",
                "fancy" => "true",
                _ => throw new ArgumentException($"--clouds takes off, fast or fancy, not {v}")
            })),
        new("--cloud-range", "<2..128>", "Chunks out to which clouds are drawn, overriding Options > Video Settings", (o, v) => o.AddSettingOverride("cloudRange:" + v)),
        new("--weather-radius", "<3..10>", "Blocks round the camera that rain and snow fall in, overriding Options >\nVideo Settings", (o, v) => o.AddSettingOverride("weatherRadius:" + v)),
        new("--test-weather", "<clear|rain|thunder|snow>", "For testing: draw this weather instead of the server's, snow being rain\nturned to snow wherever it falls. Only the picture changes; the server and\neverything it can see keep the real weather",
            (o, v) => o.TestWeather = v switch {
                "clear" => Rendering.Weather.TestWeather.Clear,
                "rain" => Rendering.Weather.TestWeather.Rain,
                "thunder" => Rendering.Weather.TestWeather.Thunder,
                "snow" => Rendering.Weather.TestWeather.Snow,
                _ => throw new ArgumentException($"--test-weather takes clear, rain, thunder or snow, not {v}")
            }),
        new("--main-hand", "<left|right>", "The hand the player holds things in, as Skin Customization sets it", (o, v) => o.AddSettingOverride("mainHand:" + v)),
        new("--narrator", "<off|all|chat|system>", "What the narrator reads out, spoken through spd-say or espeak-ng",
            (o, v) => o.AddSettingOverride("narrator:" + (Array.IndexOf(NarratorModes, v) is var mode and >= 0 ? mode
                : throw new ArgumentException($"--narrator takes off, all, chat or system, not {v}")))),
        new("--chat-visibility", "<full|system|hidden>", "What chat shows: everything, only commands and their output, or nothing;\nsent to the server as the chat options screen sets it",
            (o, v) => o.AddSettingOverride("chatVisibility:" + (Array.IndexOf(ChatVisibilities, v) is var visibility and >= 0 ? visibility
                : throw new ArgumentException($"--chat-visibility takes full, system or hidden, not {v}")))),
        new("--chat-delay", "<0..6>", "Seconds to hold each received chat message back, as the chat options screen sets it",
            (o, v) => o.AddSettingOverride("chatDelay:" + v)),
        new("--only-secure-chat", null, "Hide player messages whose signature cannot be checked", (o, _) => o.AddSettingOverride("onlyShowSecureChat:true")),
        new("--no-chat-signing", null, "Never sign chat: no chat key is fetched and no chat session is sent, so\nservers enforcing secure chat may refuse your messages", (o, _) => o.AddSettingOverride("chatSigning:false")),
        new("--save-chat-drafts", null, "Keep text chat was closed on for the next time it opens", (o, _) => o.AddSettingOverride("saveChatDrafts:true")),
        new("--volume", "<category=0..1>", "A sound category's volume: master, music, record, weather, block,\nhostile, neutral, player, ambient, voice or ui; repeatable",
            (o, v) => o.SetVolume(v)),
        new("--music-toast", "<never|pause|toast>", "Where the song playing is named, overriding Options > Sounds & Music: nowhere,\non the pause menu, or on the pause menu and in a popup as each song starts",
            (o, v) => o.AddSettingOverride("musicToast:" + v switch {
                "never" => "never",
                "pause" => "pause",
                "toast" => "pause_and_toast",
                _ => throw new ArgumentException($"--music-toast takes never, pause or toast, not {v}")
            }))
    ];

    private const int HelpColumn = 27;

    public static string Usage => "Usage: GraphicalClient [--server <host[:port]>] [options]\n\n" + string.Join("\n", Flags.Where(f => f.Help != null).Select(f => {
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
        ServerGiven = true;
        ServerText = server;
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
        Clicks.Add((Double(parts[1]), Float(point[0]), Float(point[1]), point.Length > 2 && point[2] == "right"));
    }

    private void AddSettingOverride(string value) {
        int colon = value.IndexOf(':');
        if (colon <= 0) {
            throw new ArgumentException($"--option takes <key>:<value>, not {value}");
        }
        (string Key, string Value) setting = (value[..colon], value[(colon + 1)..]);
        GameSettings.Load(null).Override(setting.Key, setting.Value);
        SettingOverrides.Add(setting);
    }

    private void SetVolume(string value) {
        string[] parts = value.Split('=', 2);
        foreach ((SoundCategory category, string name) in GameSettings.CategoryNames) {
            if (name == parts[0]) {
                float volume = parts.Length == 2 ? Math.Clamp(Float(parts[1]), 0, 1) : 1;
                AddSettingOverride($"soundCategory_{name}:" + volume.ToString(CultureInfo.InvariantCulture));
                return;
            }
        }
        throw new ArgumentException($"Unknown sound category {parts[0]}");
    }
}

public sealed class HelpRequestedException : Exception;
