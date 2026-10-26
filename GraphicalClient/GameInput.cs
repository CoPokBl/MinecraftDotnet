using System.Diagnostics;
using System.Numerics;
using ClientLib;
using ClientLib.Interaction;
using ClientLib.Player;
using GraphicalClient.Gui;
using GraphicalClient.Gui.Inventory;
using GraphicalClient.Narration;
using GraphicalClient.Rendering;
using Silk.NET.Input;

namespace GraphicalClient;

/// <summary>
/// The keyboard and mouse. While a screen is open they go to it; otherwise they turn the player at
/// once and press the key mappings bound to them for the next tick. Vanilla acts on every game key in
/// <c>Minecraft.handleKeybinds</c>, inside the tick and ahead of the movement packet, so a press here only
/// counts a click for the tick to act on: an action sent between frames lands after a tick's movement
/// packet, the order anticheats flag. Only turning, the hotbar scroll, Escape and the debug, narrator and
/// shader keys act between ticks, as they do in vanilla.
/// </summary>
public sealed class GameInput {
    private readonly IKeyboard? _keyboard;
    private readonly IMouse? _mouse;
    private MinecraftClient _client;
    private readonly LaunchOptions _options;
    private readonly GameSettings _settings;
    private readonly KeyBinds _binds;
    private readonly ScreenManager _screens;
    private readonly GameRenderer _renderer;
    private readonly DebugOverlay _debug;
    private readonly Action _quit;

    /// <summary>The mappings the window acts on itself; the client's own are its <see cref="KeyMappings"/>.</summary>
    private readonly Dictionary<KeyBind, KeyMapping> _windowKeys = new();
    private readonly SmoothDouble _smoothTurnX = new(), _smoothTurnY = new();
    private readonly Stopwatch _turnClock = Stopwatch.StartNew();
    private Vector2? _lastMouse;
    private double _lastTurn;
    private double _scrollX, _scrollY;
    private bool _smoothCamera, _scriptedUse, _scriptedAttack;

    public bool MouseCaptured { get; private set; }

    /// <summary><c>Minecraft.toggleFullscreen</c>, which the window does.</summary>
    public Action? ToggleFullscreen { get; set; }

    public GameNarrator? Narrator { get; set; }

    /// <summary>
    /// A resource reload's overlay is up: as vanilla's mouse and character handlers check, it takes no clicks,
    /// scrolls or typing, and the tick handles no key mappings, while keys still move and the mouse still turns.
    /// </summary>
    public Func<bool> OverlayOpen { get; set; } = () => false;

    public GameInput(IInputContext input, MinecraftClient client, LaunchOptions options, GameSettings settings, ScreenManager screens,
        GameRenderer renderer, DebugOverlay debug, Action quit) {
        _client = client;
        _options = options;
        _settings = settings;
        _binds = settings.Keys;
        _screens = screens;
        _renderer = renderer;
        _debug = debug;
        _quit = quit;
        screens.Quit = quit;
        _keyboard = input.Keyboards.FirstOrDefault();
        _mouse = input.Mice.FirstOrDefault();
        if (_keyboard != null) {
            _keyboard.KeyDown += OnKeyDown;
            _keyboard.KeyUp += OnKeyUp;
            _keyboard.KeyChar += OnChar;
        }
        if (_mouse != null) {
            _mouse.MouseDown += OnMouseDown;
            _mouse.MouseUp += OnMouseUp;
            _mouse.MouseMove += OnMouseMove;
            _mouse.Scroll += OnScroll;
            MouseSettingsScreen.RawMouseInputSupported = _mouse.Cursor.IsSupported(CursorMode.Raw);
        }
        foreach (KeyBind bind in _binds.All) {
            if (ClientMapping(bind) == null) {
                _windowKeys[bind] = new KeyMapping(true);
            }
        }
        try {
            Silk.NET.GLFW.Glfw glfw = Silk.NET.GLFW.Glfw.GetApi();
            InputKey.SystemKeyName = (key, scancode) => glfw.GetKeyName(key, scancode);
        }
        catch (Exception e) when (e is not OutOfMemoryException) {
            InputKey.SystemKeyName = null;
        }
        ContainerScreen.ShiftHeld = () => _keyboard != null && (_keyboard.IsKeyPressed(Key.ShiftLeft) || _keyboard.IsKeyPressed(Key.ShiftRight));
        ContainerScreen.ControlHeld = () => _keyboard != null && (_keyboard.IsKeyPressed(Key.ControlLeft) || _keyboard.IsKeyPressed(Key.ControlRight));
        Assets.ResourcePacks.ItemModelQuery.ShiftDown = ContainerScreen.ShiftHeld;
        Assets.ResourcePacks.ItemModelQuery.KeyMappingDown = KeyMappingDown;
        screens.CaptureMouse = CaptureMouse;
        screens.ScreenSet = OnScreenSet;
        Attach(client);
    }

    /// <summary>Takes up the connection a join makes.</summary>
    public void Attach(MinecraftClient client) {
        _client = client;
        client.Interactions.ScreenOpen = () => _screens.Current != null;
        client.Interactions.OverlayOpen = () => OverlayOpen();
        client.Interactions.Keys.UseToggleOptions(() => _settings.ToggleAttack, () => _settings.ToggleUse, () => _settings.ToggleCrouch,
            () => _settings.ToggleSprint);
    }

    public string Clipboard {
        get => _keyboard?.ClipboardText ?? "";
        set {
            if (_keyboard != null) {
                _keyboard.ClipboardText = value;
            }
        }
    }

    public bool TabHeld => State(_binds.PlayerList).IsDown;

    /// <summary>The client's own mapping for a binding, or null for one the window acts on.</summary>
    private KeyMapping? ClientMapping(KeyBind bind) {
        KeyMappings keys = _client.Interactions.Keys;
        int hotbar = Array.IndexOf(_binds.Hotbar, bind);
        if (hotbar >= 0) {
            return keys.Hotbar[hotbar];
        }
        return bind == _binds.Attack ? keys.Attack
            : bind == _binds.Use ? keys.Use
            : bind == _binds.PickItem ? keys.PickItem
            : bind == _binds.SpectatorHotbar ? keys.SpectatorHotbar
            : bind == _binds.Drop ? keys.Drop
            : bind == _binds.SwapOffhand ? keys.SwapOffhand
            : bind == _binds.Forward ? keys.Forward
            : bind == _binds.Left ? keys.Left
            : bind == _binds.Back ? keys.Back
            : bind == _binds.Right ? keys.Right
            : bind == _binds.Jump ? keys.Jump
            : bind == _binds.Sneak ? keys.Sneak
            : bind == _binds.Sprint ? keys.Sprint
            : null;
    }

    private KeyMapping State(KeyBind bind) => ClientMapping(bind) ?? _windowKeys[bind];

    /// <summary><c>KeyMapping.isDown</c> by a mapping's name; null for a name vanilla has no mapping of.</summary>
    private bool? KeyMappingDown(string name) => _binds.Get(name) is { } bind ? State(bind).IsDown : null;

    /// <summary><c>KeyMapping.set</c>: every mapping on the key.</summary>
    private void SetKeys(InputKey key, bool down) {
        foreach (KeyBind bind in _binds.All) {
            if (bind.Key == key) {
                State(bind).SetDown(down);
            }
        }
    }

    /// <summary><c>KeyMapping.click</c>: every mapping on the key.</summary>
    private void ClickKeys(InputKey key) {
        foreach (KeyBind bind in _binds.All) {
            if (bind.Key == key) {
                State(bind).Click();
            }
        }
    }

    private bool Control => _scriptedControl || _keyboard != null && (_keyboard.IsKeyPressed(Key.ControlLeft) || _keyboard.IsKeyPressed(Key.ControlRight));

    /// <summary>Control held down for a scripted <c>ctrl+</c> press.</summary>
    private bool _scriptedControl;

    /// <summary>Whether the key a binding is on is held, by the window's own state of the keyboard and buttons.</summary>
    private bool PhysicallyDown(InputKey key) => key.Type switch {
        InputType.Keysym => key != InputKey.Unknown && _keyboard?.IsKeyPressed((Key)key.Value) == true,
        InputType.Scancode => _keyboard?.IsScancodePressed(key.Value) == true,
        _ => _mouse?.IsButtonPressed((MouseButton)key.Value) == true
    };

    public void CaptureMouse(bool capture) {
        if (_mouse == null) {
            return;
        }
        MouseCaptured = capture;
        ApplyCursorMode();
        _lastMouse = null;
    }

    /// <summary>The <c>rawMouseInput</c> option, which turns raw motion on while the mouse is captured.</summary>
    public void ApplyCursorMode() {
        if (_mouse != null) {
            _mouse.Cursor.CursorMode = !MouseCaptured ? CursorMode.Normal
                : _settings.RawMouseInput && MouseSettingsScreen.RawMouseInputSupported ? CursorMode.Raw : CursorMode.Disabled;
        }
    }

    /// <summary>
    /// <c>Gui.setScreen</c>'s key handling: opening a screen lets every mapping go; closing one in a level
    /// presses again a toggled key the opening let go. The window gets no GLFW key repeats, which in vanilla
    /// set a held key down again once the screen has gone, so a closing screen also reads the keys again as
    /// <c>KeyMapping.setAll</c> does.
    /// </summary>
    private void OnScreenSet(Screen? screen) {
        KeyMappings keys = _client.Interactions.Keys;
        if (screen != null) {
            keys.ReleaseAll();
            foreach (KeyMapping key in _windowKeys.Values) {
                key.Release();
            }
            return;
        }
        if (_client.Level == null) {
            return;
        }
        foreach (KeyBind bind in _binds.All) {
            if (State(bind).ShouldRestoreStateOnScreenClosed(bind.Key.Type == InputType.Keysym)) {
                State(bind).SetDown(true);
            }
        }
        foreach (KeyBind bind in _binds.All) {
            if (bind.Key.Type == InputType.Keysym && !bind.IsUnbound && State(bind).FollowsKeyOnFocus) {
                State(bind).SetDown(PhysicallyDown(bind.Key));
            }
        }
    }

    /// <summary>The cursor in HUD pixels.</summary>
    public (float X, float Y) MouseInGui() {
        Vector2 position = _options.Cursor ?? _mouse?.Position ?? default;
        return (position.X / _renderer.Gui.Scale, position.Y / _renderer.Gui.Scale);
    }

    /// <summary>A right click for the next tick, as if the button had been pressed and let go.</summary>
    public void QueueUse() {
        KeyMapping use = _client.Interactions.Keys.Use;
        use.Press();
        use.SetDown(false);
    }

    /// <summary>A key pressed and let go from <c>--press</c>: a digit, a <see cref="Key"/> name, or attack for a left click, with <c>ctrl+</c> before it to hold Control.</summary>
    public void Press(string key) {
        if (key.StartsWith("ctrl+", StringComparison.OrdinalIgnoreCase)) {
            _scriptedControl = true;
            try {
                Press(key["ctrl+".Length..]);
            }
            finally {
                _scriptedControl = false;
            }
            return;
        }
        if (key == "attack") {
            KeyMapping attack = _client.Interactions.Keys.Attack;
            attack.Press();
            attack.SetDown(false);
            return;
        }
        Key pressed = key.Length == 1 && char.IsDigit(key[0]) ? Key.Number0 + (key[0] - '0') : Enum.Parse<Key>(key, true);
        OnKeyDown(_keyboard!, pressed, 0);
        OnKeyUp(_keyboard!, pressed, 0);
    }

    /// <summary><c>MouseHandler.turnPlayer</c>, once a frame, with the cinematic camera's smoothing and the invert options.</summary>
    public void TurnPlayer() {
        double now = _turnClock.Elapsed.TotalSeconds;
        double mousea = now - _lastTurn;
        _lastTurn = now;
        if (_mouse == null || !MouseCaptured) {
            return;
        }
        Vector2 position = _mouse.Position;
        if (_lastMouse is { } last && _client.Player != null) {
            Vector2 d = position - last;
            double ss = _settings.Sensitivity * 0.6F + 0.2F;
            double sensitivityMod = ss * ss * ss;
            double sens = sensitivityMod * 8.0;
            double xo, yo;
            if (_smoothCamera) {
                xo = _smoothTurnX.GetNewDeltaValue(d.X * sens, mousea * sens);
                yo = _smoothTurnY.GetNewDeltaValue(d.Y * sens, mousea * sens);
            }
            else {
                _smoothTurnX.Reset();
                _smoothTurnY.Reset();
                double scale = _renderer.View.FirstPerson && _client.Player.IsScoping ? sensitivityMod : sens;
                xo = d.X * scale;
                yo = d.Y * scale;
            }
            _client.Player.Turn(_settings.InvertMouseX ? -xo : xo, _settings.InvertMouseY ? -yo : yo);
        }
        _lastMouse = position;
    }

    /// <summary><c>KeyboardInput.tick</c>'s keys.</summary>
    public PlayerInput Movement() => _client.Interactions.Keys.KeyboardInput();

    /// <summary>The tick's interactions, which take the presses since the last tick.</summary>
    /// <param name="scriptedUse">The use button is held by <c>--hold use</c>.</param>
    /// <param name="scriptedAttack">The attack button is held by <c>--hold attack</c>.</param>
    public void TickInteractions(bool scriptedUse = false, bool scriptedAttack = false) {
        KeyMappings keys = _client.Interactions.Keys;
        if (_client.Player == null) {
            keys.ReleaseAll();
            foreach (KeyMapping key in _windowKeys.Values) {
                key.Release();
            }
            return;
        }
        if (scriptedUse || _scriptedUse) {
            keys.Use.SetDown(scriptedUse || PhysicallyDown(_binds.Use.Key));
        }
        _scriptedUse = scriptedUse;
        if (scriptedAttack || _scriptedAttack) {
            keys.Attack.SetDown(scriptedAttack || PhysicallyDown(_binds.Attack.Key));
        }
        _scriptedAttack = scriptedAttack;
        keys.ControlDown = Control;
        _client.Interactions.Tick(HostKeybinds);
    }

    /// <summary>The window's part of <c>Minecraft.handleKeybinds</c> and <c>Gui.handleKeybinds</c>, ahead of the hotbar keys.</summary>
    private void HostKeybinds() {
        while (State(_binds.TogglePerspective).ConsumeClick()) {
            _renderer.View.CycleMode();
        }
        while (State(_binds.SmoothCamera).ConsumeClick()) {
            _smoothCamera = !_smoothCamera;
        }
        while (State(_binds.ToggleGui).ConsumeClick()) {
            _renderer.HideGui = !_renderer.HideGui;
        }
        while (State(_binds.Advancements).ConsumeClick()) {
            _screens.Set(new AdvancementsScreen(_screens.Context, _client.Advancements));
        }
        // This client has no social interactions or quick actions screen, nor a spectator shader to toggle.
        while (State(_binds.SocialInteractions).ConsumeClick()) {
        }
        while (State(_binds.Chat).ConsumeClick()) {
            _screens.OpenChat(Gui.ChatComponent.ChatMethod.Message);
        }
        if (_screens.Current == null && State(_binds.Command).ConsumeClick()) {
            _screens.OpenChat(Gui.ChatComponent.ChatMethod.Command);
        }
        while (State(_binds.ToggleSpectatorShaderEffects).ConsumeClick()) {
        }
        while (State(_binds.Inventory).ConsumeClick()) {
            _screens.OpenInventory(_client.Player!);
        }
        while (State(_binds.QuickActions).ConsumeClick()) {
        }
    }

    /// <summary>
    /// <c>Minecraft.handleGlobalKeyPress</c>, which takes the key before anything else does. A screenshot is
    /// not saved here; the key is still taken, as vanilla's is.
    /// </summary>
    private bool HandleGlobalKeyPress(InputKey key) {
        if (State(_binds.DebugModifier).IsDown) {
            return false;
        }
        if (_binds.Fullscreen.Key == key) {
            ToggleFullscreen?.Invoke();
            return true;
        }
        // The friends screen does not exist here, so its key falls through as vanilla's does when it opens nothing.
        return _binds.Screenshot.Key == key;
    }

    /// <summary><c>KeyboardHandler.keyPress</c> for a press.</summary>
    private void OnKeyDown(IKeyboard keyboard, Key key, int scancode) {
        InputKey input = InputKey.FromEvent(key, scancode);
        Screen? screen = _screens.Current;
        bool justBound = screen is KeyBindsScreen { LastKeySelection: var selected } && selected > Environment.TickCount64 - 20;
        if (!justBound && HandleGlobalKeyPress(input)) {
            return;
        }
        if (Control && key == Key.B && screen is not { HasFocusedEditBox: true } && Narrator is { IsActive: true } narrator && _settings.NarratorHotkey) {
            bool wasDisabled = _settings.Narrator == NarratorStatus.Off;
            _settings.Narrator = (NarratorStatus)(((int)_settings.Narrator + 1) % 4);
            narrator.UpdateNarratorStatus(_settings.Narrator);
            _settings.Save();
            screen?.UpdateNarratorStatus(wasDisabled, _settings.Narrator);
        }
        if (screen != null) {
            screen.AfterKeyboardAction();
            if (screen is not KeyBindsScreen keyBinds || !keyBinds.KeyPressed(key, scancode)) {
                screen.KeyDown(_screens.Context, key, Control);
            }
            _screens.CloseIfClosed();
            if (_screens.Current == null) {
                SetKeys(input, false);
            }
            return;
        }
        if (_binds.DebugOverlay.Key == input && _binds.DebugModifier.Key != input) {
            _debug.Visible = !_debug.Visible;
        }
        if (key == Key.Escape) {
            _screens.Set(new PauseScreen(_quit));
            return;
        }
        if (key == Key.F7) {
            _renderer.LoadPipeline();
        }
        if (!MouseCaptured) {
            CaptureMouse(true);
        }
        SetKeys(input, true);
        ClickKeys(input);
    }

    /// <summary>
    /// <c>KeyboardHandler.keyPress</c> for a release. With the debug overlay and modifier on one key the overlay
    /// toggles as it is let go, there being no debug key combinations here for it to have been a modifier of.
    /// </summary>
    private void OnKeyUp(IKeyboard keyboard, Key key, int scancode) {
        InputKey input = InputKey.FromEvent(key, scancode);
        _screens.Current?.KeyUp(_screens.Context, key);
        if (_binds.DebugModifier.Key == input && _binds.DebugOverlay.Key == input) {
            _debug.Visible = !_debug.Visible;
        }
        SetKeys(input, false);
    }

    // The key that opens a text field produces its character in the same poll, before the tick opens the screen.
    private void OnChar(IKeyboard keyboard, char c) {
        if (!OverlayOpen()) {
            _screens.Current?.Char(_screens.Context, c);
        }
    }

    /// <summary><c>MouseHandler.onButton</c> for a press.</summary>
    private void OnMouseDown(IMouse mouse, MouseButton button) {
        InputKey input = InputKey.Mouse(button);
        if (OverlayOpen() || HandleGlobalKeyPress(input)) {
            return;
        }
        if (_screens.Current is { } screen) {
            (float x, float y) = MouseInGui();
            screen.AfterMouseAction();
            screen.MouseDown(_screens.Context, x, y, button);
            _screens.CloseIfClosed();
            return;
        }
        if (!MouseCaptured) {
            CaptureMouse(true);
            _client.Interactions.OnMouseGrabbed();
        }
        SetKeys(input, true);
        ClickKeys(input);
    }

    /// <summary><c>MouseHandler.onButton</c> for a release, which reaches the mappings only with no screen open.</summary>
    private void OnMouseUp(IMouse mouse, MouseButton button) {
        if (OverlayOpen()) {
            return;
        }
        if (_screens.Current is { } screen) {
            (float x, float y) = MouseInGui();
            screen.MouseUp(_screens.Context, x, y, button);
            _screens.CloseIfClosed();
            return;
        }
        SetKeys(InputKey.Mouse(button), false);
    }

    private void OnMouseMove(IMouse mouse, Vector2 position) {
        if (_screens.Current is { } screen && !OverlayOpen()) {
            (float x, float y) = MouseInGui();
            screen.MouseMove(_screens.Context, x, y);
            screen.AfterMouseMove();
        }
    }

    /// <summary><c>MouseHandler.onScroll</c>, scaled by the scroll options, then through <c>ScrollWheelHandler</c> for the hotbar.</summary>
    private void OnScroll(IMouse mouse, ScrollWheel wheel) {
        double scrollSensitivity = _settings.MouseWheelSensitivity;
        double scaledX = (_settings.DiscreteMouseScroll ? Math.Sign(wheel.X) : wheel.X) * scrollSensitivity;
        double scaledY = (_settings.DiscreteMouseScroll ? Math.Sign(wheel.Y) : wheel.Y) * scrollSensitivity;
        if (OverlayOpen()) {
            return;
        }
        if (_screens.Current is { } screen) {
            screen.Scroll(_screens.Context, (float)scaledY);
            screen.AfterMouseAction();
            return;
        }
        if (_client.Player is not { } player) {
            return;
        }
        if (_scrollX != 0.0 && Math.Sign(scaledX) != Math.Sign(_scrollX)) {
            _scrollX = 0.0;
        }
        if (_scrollY != 0.0 && Math.Sign(scaledY) != Math.Sign(_scrollY)) {
            _scrollY = 0.0;
        }
        _scrollX += scaledX;
        _scrollY += scaledY;
        int wheelX = (int)_scrollX, wheelY = (int)_scrollY;
        if (wheelX == 0 && wheelY == 0) {
            return;
        }
        _scrollX -= wheelX;
        _scrollY -= wheelY;

        int step = wheelY == 0 ? -wheelX : wheelY;
        if (player.IsSpectator) {
            if (_client.SpectatorGui.IsMenuActive) {
                _client.SpectatorGui.OnMouseScrolled(-step);
            }
            else {
                player.FlyingSpeed = Math.Clamp(player.FlyingSpeed + wheelY * 0.005F, 0.0F, 0.2F);
            }
            return;
        }
        // Inventory.setSelectedSlot: the server hears of it from the next tick's ensureHasSentCarriedItem.
        _client.Inventory.SelectedSlot = ((_client.Inventory.SelectedSlot - Math.Sign(step)) % 9 + 9) % 9;
    }

    /// <summary><c>SmoothDouble</c>, which eases the cinematic camera's turning.</summary>
    private sealed class SmoothDouble {
        private double _targetValue, _remainingValue, _lastAmount;

        public double GetNewDeltaValue(double targetDelta, double time) {
            _targetValue += targetDelta;
            double delta = _targetValue - _remainingValue;
            double newLastAmount = _lastAmount + 0.5 * (delta - _lastAmount);
            double deltaSign = Math.Sign(delta);
            if (deltaSign * delta > deltaSign * _lastAmount) {
                delta = newLastAmount;
            }
            _lastAmount = newLastAmount;
            _remainingValue += delta * time;
            return delta * time;
        }

        public void Reset() {
            _targetValue = 0.0;
            _remainingValue = 0.0;
            _lastAmount = 0.0;
        }
    }
}
