using System.Globalization;
using ClientLib;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient;

/// <summary><c>InputConstants.Type</c>.</summary>
public enum InputType {
    Keysym,
    Scancode,
    Mouse
}

/// <summary>
/// <c>InputConstants.Key</c>: a keyboard key by its GLFW key code (which <see cref="Key"/>'s values are), a
/// key the layout gives no code by its scancode, or a mouse button.
/// </summary>
public readonly record struct InputKey(InputType Type, int Value) {
    public static readonly InputKey Unknown = new(InputType.Keysym, -1);

    public static InputKey Keyboard(Key key) => new(InputType.Keysym, (int)key);

    public static InputKey Mouse(MouseButton button) => new(InputType.Mouse, (int)button);

    /// <summary><c>InputConstants.getKey(KeyEvent)</c>.</summary>
    public static InputKey FromEvent(Key key, int scancode) => key == Key.Unknown ? new InputKey(InputType.Scancode, scancode) : Keyboard(key);

    /// <summary>The <c>addKey</c> table: the names of the keys that have one.</summary>
    private static readonly Dictionary<InputKey, string> Names = BuildNames();

    private static readonly Dictionary<string, InputKey> ByName = Names.ToDictionary(e => e.Value, e => e.Key);

    private static Dictionary<InputKey, string> BuildNames() {
        Dictionary<InputKey, string> names = new() { [Unknown] = "key.keyboard.unknown" };
        string[] mouse = ["left", "right", "middle", "4", "5", "6", "7", "8"];
        for (int i = 0; i < mouse.Length; i++) {
            names[new InputKey(InputType.Mouse, i)] = "key.mouse." + mouse[i];
        }
        for (int i = 0; i <= 9; i++) {
            names[new InputKey(InputType.Keysym, 48 + i)] = "key.keyboard." + i;
            names[new InputKey(InputType.Keysym, 320 + i)] = "key.keyboard.keypad." + i;
        }
        for (char c = 'a'; c <= 'z'; c++) {
            names[new InputKey(InputType.Keysym, 65 + c - 'a')] = "key.keyboard." + c;
        }
        for (int i = 1; i <= 25; i++) {
            names[new InputKey(InputType.Keysym, 289 + i)] = "key.keyboard.f" + i;
        }
        (int Code, string Name)[] named = [
            (282, "num.lock"), (334, "keypad.add"), (330, "keypad.decimal"), (335, "keypad.enter"), (336, "keypad.equal"),
            (332, "keypad.multiply"), (331, "keypad.divide"), (333, "keypad.subtract"), (264, "down"), (263, "left"), (262, "right"),
            (265, "up"), (39, "apostrophe"), (92, "backslash"), (44, "comma"), (61, "equal"), (96, "grave.accent"), (91, "left.bracket"),
            (45, "minus"), (46, "period"), (93, "right.bracket"), (59, "semicolon"), (47, "slash"), (32, "space"), (258, "tab"),
            (342, "left.alt"), (341, "left.control"), (340, "left.shift"), (343, "left.win"), (346, "right.alt"), (345, "right.control"),
            (344, "right.shift"), (347, "right.win"), (257, "enter"), (256, "escape"), (259, "backspace"), (261, "delete"), (269, "end"),
            (268, "home"), (260, "insert"), (267, "page.down"), (266, "page.up"), (280, "caps.lock"), (284, "pause"),
            (281, "scroll.lock"), (348, "menu"), (283, "print.screen"), (161, "world.1"), (162, "world.2")
        ];
        foreach ((int code, string name) in named) {
            names[new InputKey(InputType.Keysym, code)] = "key.keyboard." + name;
        }
        return names;
    }

    private string Prefix => Type switch {
        InputType.Keysym => "key.keyboard",
        InputType.Scancode => "scancode",
        _ => "key.mouse"
    };

    /// <summary><c>getName</c>, the form <c>options.txt</c> keeps: a table name, or the prefix and the number, a mouse button's counted from one.</summary>
    public string Name => Names.TryGetValue(this, out string? name) ? name : $"{Prefix}.{(Type == InputType.Mouse ? Value + 1 : Value)}";

    /// <summary><c>InputConstants.getKey(String)</c>.</summary>
    /// <exception cref="FormatException">The name is neither in the table nor a prefix and a number.</exception>
    public static InputKey FromName(string name) {
        if (ByName.TryGetValue(name, out InputKey known)) {
            return known;
        }
        foreach (InputType type in Enum.GetValues<InputType>()) {
            string prefix = new InputKey(type, 0).Prefix;
            if (name.StartsWith(prefix, StringComparison.Ordinal) && name.Length > prefix.Length) {
                int value = int.Parse(name[(prefix.Length + 1)..], CultureInfo.InvariantCulture);
                return new InputKey(type, type == InputType.Mouse ? value - 1 : value);
            }
        }
        throw new FormatException($"Unknown key name: {name}");
    }

    /// <summary>The window's <c>glfwGetKeyName</c>, for the layout's own name of a printable key; null where there is no window.</summary>
    public static Func<int, int, string?>? SystemKeyName { get; set; }

    /// <summary>A name with no translation read off its own words: <c>key.keyboard.left.shift</c> as "Left Shift".</summary>
    private string FallbackName {
        get {
            string[] words = Name[(Prefix.Length + 1)..].Split('.');
            return string.Join(' ', words.Select(w => w.Length == 0 ? w : char.ToUpperInvariant(w[0]) + w[1..]));
        }
    }

    /// <summary><c>getDisplayName</c>, through each type's <c>displayTextSupplier</c>.</summary>
    public string DisplayName {
        get {
            switch (Type) {
                case InputType.Keysym when this != Unknown && SystemKeyName?.Invoke(Value, -1) is { } system:
                    return system.ToUpperInvariant();
                case InputType.Scancode when SystemKeyName?.Invoke(-1, Value) is { } system:
                    return system;
                case InputType.Mouse when Translations.Get(Name) == null:
                    return TextFlattener.Plain(TextComponent.Translatable("key.mouse", null, [TextComponent.Text((Value + 1).ToString(CultureInfo.InvariantCulture))]));
                default:
                    return Translations.Get(Name) ?? FallbackName;
            }
        }
    }
}

/// <summary><c>KeyMapping.Category</c>, in <c>SORT_ORDER</c>.</summary>
public enum KeyCategory {
    Movement,
    Misc,
    Multiplayer,
    Gameplay,
    Inventory,
    Creative,
    Spectator,
    Debug
}

/// <summary><c>KeyMapping</c>'s binding: its name, where the controls screen lists it, and the key it is on.</summary>
public sealed class KeyBind(string name, KeyCategory category, InputKey defaultKey, int order = 0) {
    public string Name { get; } = name;
    public KeyCategory Category { get; } = category;
    public int Order { get; } = order;
    public InputKey Default { get; } = defaultKey;
    public InputKey Key { get; set; } = defaultKey;
    public bool IsDefault => Key == Default;
    public bool IsUnbound => Key == InputKey.Unknown;

    /// <summary><c>KeyMapping.matches(KeyEvent)</c> for a key with a key code, which is every key a screen hears.</summary>
    public bool Matches(Key key) => Key == InputKey.Keyboard(key);

    /// <summary><c>KeyMapping.compareTo</c>: by category, then order, then translated name.</summary>
    public int CompareTo(KeyBind other) {
        if (Category != other.Category) {
            return Category.CompareTo(other.Category);
        }
        return Order != other.Order ? Order.CompareTo(other.Order) : string.CompareOrdinal(Translations.Get(Name) ?? Name, Translations.Get(other.Name) ?? other.Name);
    }
}

/// <summary>
/// <c>Options.keyMappings</c>, in its order, at vanilla's default keys. A binding is saved as
/// <c>key_&lt;name&gt;:&lt;key name&gt;</c>, which is also how <c>--option</c> rebinds one.
/// </summary>
public sealed class KeyBinds {
    private static InputKey K(Key key) => InputKey.Keyboard(key);
    private static InputKey M(MouseButton button) => InputKey.Mouse(button);

    public KeyBind Attack { get; } = new("key.attack", KeyCategory.Gameplay, M(MouseButton.Left));
    public KeyBind Use { get; } = new("key.use", KeyCategory.Gameplay, M(MouseButton.Right));
    public KeyBind Forward { get; } = new("key.forward", KeyCategory.Movement, K(Key.W));
    public KeyBind Left { get; } = new("key.left", KeyCategory.Movement, K(Key.A));
    public KeyBind Back { get; } = new("key.back", KeyCategory.Movement, K(Key.S));
    public KeyBind Right { get; } = new("key.right", KeyCategory.Movement, K(Key.D));
    public KeyBind Jump { get; } = new("key.jump", KeyCategory.Movement, K(Key.Space));
    public KeyBind Sneak { get; } = new("key.sneak", KeyCategory.Movement, K(Key.ShiftLeft));
    public KeyBind Sprint { get; } = new("key.sprint", KeyCategory.Movement, K(Key.ControlLeft));
    public KeyBind Drop { get; } = new("key.drop", KeyCategory.Inventory, K(Key.Q));
    public KeyBind Inventory { get; } = new("key.inventory", KeyCategory.Inventory, K(Key.E));
    public KeyBind Chat { get; } = new("key.chat", KeyCategory.Multiplayer, K(Key.T));
    public KeyBind PlayerList { get; } = new("key.playerlist", KeyCategory.Multiplayer, K(Key.Tab));
    public KeyBind PickItem { get; } = new("key.pickItem", KeyCategory.Gameplay, M(MouseButton.Middle));
    public KeyBind Command { get; } = new("key.command", KeyCategory.Multiplayer, K(Key.Slash));
    public KeyBind Friends { get; } = new("key.friends", KeyCategory.Multiplayer, K(Key.O));
    public KeyBind SocialInteractions { get; } = new("key.socialInteractions", KeyCategory.Multiplayer, K(Key.P));
    public KeyBind ToggleGui { get; } = new("key.toggleGui", KeyCategory.Misc, K(Key.F1));
    public KeyBind ToggleSpectatorShaderEffects { get; } = new("key.toggleSpectatorShaderEffects", KeyCategory.Misc, K(Key.F4));
    public KeyBind Screenshot { get; } = new("key.screenshot", KeyCategory.Misc, K(Key.F2));
    public KeyBind TogglePerspective { get; } = new("key.togglePerspective", KeyCategory.Misc, K(Key.F5));
    public KeyBind SmoothCamera { get; } = new("key.smoothCamera", KeyCategory.Misc, InputKey.Unknown);
    public KeyBind Fullscreen { get; } = new("key.fullscreen", KeyCategory.Misc, K(Key.F11));
    public KeyBind SpectatorOutlines { get; } = new("key.spectatorOutlines", KeyCategory.Spectator, InputKey.Unknown);
    public KeyBind SpectatorHotbar { get; } = new("key.spectatorHotbar", KeyCategory.Spectator, M(MouseButton.Middle));
    public KeyBind SwapOffhand { get; } = new("key.swapOffhand", KeyCategory.Inventory, K(Key.F));
    public KeyBind SaveHotbarActivator { get; } = new("key.saveToolbarActivator", KeyCategory.Creative, K(Key.C));
    public KeyBind LoadHotbarActivator { get; } = new("key.loadToolbarActivator", KeyCategory.Creative, K(Key.X));
    public KeyBind Advancements { get; } = new("key.advancements", KeyCategory.Misc, K(Key.L));
    public KeyBind QuickActions { get; } = new("key.quickActions", KeyCategory.Misc, K(Key.G));
    public KeyBind DebugOverlay { get; } = new("key.debug.overlay", KeyCategory.Debug, K(Key.F3), -2);
    public KeyBind DebugModifier { get; } = new("key.debug.modifier", KeyCategory.Debug, K(Key.F3), -1);
    public KeyBind[] Hotbar { get; } = Enumerable.Range(1, 9).Select(i => new KeyBind("key.hotbar." + i, KeyCategory.Inventory, K(Key.Number0 + i))).ToArray();

    /// <summary><c>debugKeys</c>, which this client lists and saves but does not act on.</summary>
    public KeyBind[] DebugKeys { get; } = [
        new("key.debug.reloadChunk", KeyCategory.Debug, K(Key.A)),
        new("key.debug.showHitboxes", KeyCategory.Debug, K(Key.B)),
        new("key.debug.clearChat", KeyCategory.Debug, K(Key.D)),
        new("key.debug.crash", KeyCategory.Debug, K(Key.C)),
        new("key.debug.showChunkBorders", KeyCategory.Debug, K(Key.G)),
        new("key.debug.showAdvancedTooltips", KeyCategory.Debug, K(Key.H)),
        new("key.debug.copyRecreateCommand", KeyCategory.Debug, K(Key.I)),
        new("key.debug.spectate", KeyCategory.Debug, K(Key.N)),
        new("key.debug.switchGameMode", KeyCategory.Debug, K(Key.F4)),
        new("key.debug.debugOptions", KeyCategory.Debug, K(Key.F6)),
        new("key.debug.focusPause", KeyCategory.Debug, K(Key.P)),
        new("key.debug.dumpDynamicTextures", KeyCategory.Debug, K(Key.S)),
        new("key.debug.reloadResourcePacks", KeyCategory.Debug, K(Key.T)),
        new("key.debug.profiling", KeyCategory.Debug, K(Key.L)),
        new("key.debug.copyLocation", KeyCategory.Debug, K(Key.C)),
        new("key.debug.dumpVersion", KeyCategory.Debug, K(Key.V)),
        new("key.debug.profilingChart", KeyCategory.Debug, K(Key.Number1), 1),
        new("key.debug.fpsCharts", KeyCategory.Debug, K(Key.Number2), 2),
        new("key.debug.networkCharts", KeyCategory.Debug, K(Key.Number3), 3),
        new("key.debug.lightmapTexture", KeyCategory.Debug, K(Key.Number4), 4)
    ];

    public KeyBinds() {
        All = [
            Attack, Use, Forward, Left, Back, Right, Jump, Sneak, Sprint, Drop, Inventory, Chat, PlayerList, PickItem, Command, Friends,
            SocialInteractions, ToggleGui, ToggleSpectatorShaderEffects, Screenshot, TogglePerspective, SmoothCamera, Fullscreen,
            SpectatorOutlines, SpectatorHotbar, SwapOffhand, SaveHotbarActivator, LoadHotbarActivator, Advancements, QuickActions,
            DebugOverlay, DebugModifier, .. Hotbar, .. DebugKeys
        ];
    }

    public IReadOnlyList<KeyBind> All { get; }

    public KeyBind? Get(string name) => All.FirstOrDefault(b => b.Name == name);

    /// <summary>
    /// <c>KeyBindsList.KeyEntry.refreshEntry</c>'s conflict test: the other mappings on the same key, where
    /// at least one of the pair has been moved off its default.
    /// </summary>
    public IEnumerable<KeyBind> Conflicts(KeyBind bind) =>
        bind.IsUnbound ? [] : All.Where(other => other != bind && other.Key == bind.Key && (!other.IsDefault || !bind.IsDefault));
}
