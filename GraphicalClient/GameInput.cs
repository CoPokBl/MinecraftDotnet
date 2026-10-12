using System.Numerics;
using ClientLib;
using ClientLib.Interaction;
using ClientLib.Player;
using GraphicalClient.Gui;
using GraphicalClient.Gui.Inventory;
using GraphicalClient.Rendering;
using Silk.NET.Input;

namespace GraphicalClient;

/// <summary>
/// The keyboard and mouse. While a screen is open they go to it; otherwise they turn the player at
/// once and press keys for the next tick. Vanilla acts on every game key in <c>Minecraft.handleKeybinds</c>,
/// inside the tick and ahead of the movement packet, so a press here only counts a click for the tick
/// to act on: an action sent between frames lands after a tick's movement packet, the order
/// anticheats flag. Only turning, the hotbar scroll, Escape and the debug and shader keys act between
/// ticks, as they do in vanilla.
/// </summary>
public sealed class GameInput {
    private readonly IKeyboard? _keyboard;
    private readonly IMouse? _mouse;
    private readonly MinecraftClient _client;
    private readonly LaunchOptions _options;
    private readonly GameSettings _settings;
    private readonly ScreenManager _screens;
    private readonly GameRenderer _renderer;
    private readonly DebugOverlay _debug;
    private readonly Action _quit;
    private Vector2? _lastMouse;
    private int _perspectiveClicks, _toggleGuiClicks, _chatClicks, _commandClicks, _inventoryClicks;
    private double _scrollX, _scrollY;

    public bool MouseCaptured { get; private set; }

    public GameInput(IInputContext input, MinecraftClient client, LaunchOptions options, GameSettings settings, ScreenManager screens,
        GameRenderer renderer, DebugOverlay debug, Action quit) {
        _client = client;
        _options = options;
        _settings = settings;
        _screens = screens;
        _renderer = renderer;
        _debug = debug;
        _quit = quit;
        _keyboard = input.Keyboards.FirstOrDefault();
        _mouse = input.Mice.FirstOrDefault();
        if (_keyboard != null) {
            _keyboard.KeyDown += OnKeyDown;
            _keyboard.KeyChar += OnChar;
        }
        if (_mouse != null) {
            _mouse.MouseDown += OnMouseDown;
            _mouse.MouseUp += OnMouseUp;
            _mouse.MouseMove += OnMouseMove;
            _mouse.Scroll += OnScroll;
        }
        ContainerScreen.ShiftHeld = () => _keyboard != null && (_keyboard.IsKeyPressed(Key.ShiftLeft) || _keyboard.IsKeyPressed(Key.ShiftRight));
        Assets.ResourcePacks.ItemModelQuery.ShiftDown = ContainerScreen.ShiftHeld;
        Assets.ResourcePacks.ItemModelQuery.KeyMappingDown = KeyMappingDown;
        screens.CaptureMouse = CaptureMouse;
        client.Interactions.ScreenOpen = () => _screens.Current != null;
    }

    public string Clipboard {
        get => _keyboard?.ClipboardText ?? "";
        set {
            if (_keyboard != null) {
                _keyboard.ClipboardText = value;
            }
        }
    }

    public bool TabHeld => _keyboard?.IsKeyPressed(Key.Tab) == true;

    /// <summary>
    /// <c>KeyMapping.isDown</c> by a mapping's name, on the default keys, which are the only ones this
    /// client binds; null for a name vanilla has no mapping of.
    /// </summary>
    private bool? KeyMappingDown(string name) {
        if (name is "key.attack" or "key.use" or "key.pickItem" or "key.spectatorHotbar") {
            MouseButton button = name == "key.attack" ? MouseButton.Left : name == "key.use" ? MouseButton.Right : MouseButton.Middle;
            return _mouse?.IsButtonPressed(button) == true;
        }
        Key? key = name switch {
            "key.forward" => Key.W, "key.left" => Key.A, "key.back" => Key.S, "key.right" => Key.D, "key.jump" => Key.Space,
            "key.sneak" => Key.ShiftLeft, "key.sprint" => Key.ControlLeft, "key.drop" => Key.Q, "key.inventory" => Key.E,
            "key.chat" => Key.T, "key.playerlist" => Key.Tab, "key.command" => Key.Slash, "key.socialInteractions" => Key.P,
            "key.screenshot" => Key.F2, "key.togglePerspective" => Key.F5, "key.fullscreen" => Key.F11, "key.swapOffhand" => Key.F,
            "key.saveToolbarActivator" => Key.C, "key.loadToolbarActivator" => Key.X, "key.advancements" => Key.L,
            "key.quickActions" => Key.G, "key.friends" => Key.O, "key.toggleGui" => Key.F1, "key.toggleSpectatorShaderEffects" => Key.F4,
            "key.debug.overlay" or "key.debug.modifier" => Key.F3, "key.smoothCamera" or "key.spectatorOutlines" => Key.Unknown,
            _ when name.StartsWith("key.hotbar.") && int.TryParse(name["key.hotbar.".Length..], out int slot) && slot is >= 1 and <= 9 => Key.Number0 + slot,
            _ => null
        };
        return key switch {
            null => null,
            Key.Unknown => false,
            { } pressed => _keyboard?.IsKeyPressed(pressed) == true
        };
    }

    private bool Control => _keyboard != null && (_keyboard.IsKeyPressed(Key.ControlLeft) || _keyboard.IsKeyPressed(Key.ControlRight));

    public void CaptureMouse(bool capture) {
        if (_mouse == null) {
            return;
        }
        MouseCaptured = capture;
        _mouse.Cursor.CursorMode = capture ? CursorMode.Raw : CursorMode.Normal;
        _lastMouse = null;
    }

    /// <summary>The cursor in HUD pixels.</summary>
    public (float X, float Y) MouseInGui() {
        Vector2 position = _options.Cursor ?? _mouse?.Position ?? default;
        return (position.X / _renderer.Gui.Scale, position.Y / _renderer.Gui.Scale);
    }

    /// <summary>A right click for the next tick, as if the button had been pressed.</summary>
    public void QueueUse() => _client.Interactions.Keys.Use.Press();

    /// <summary>A key press from <c>--press</c>: a digit, a <see cref="Key"/> name, or attack for a left click.</summary>
    public void Press(string key) {
        if (key == "attack") {
            _client.Interactions.Keys.Attack.Press();
        }
        else if (key.Length == 1 && char.IsDigit(key[0])) {
            OnKeyDown(_keyboard!, Key.Number0 + (key[0] - '0'), 0);
        }
        else {
            OnKeyDown(_keyboard!, Enum.Parse<Key>(key, true), 0);
        }
    }

    /// <summary><c>MouseHandler.turnPlayer</c>, once a frame.</summary>
    public void TurnPlayer() {
        if (_mouse == null || !MouseCaptured) {
            return;
        }
        Vector2 position = _mouse.Position;
        if (_lastMouse is { } last && _client.Player != null) {
            Vector2 d = position - last;
            double ss = _settings.Sensitivity * 0.6F + 0.2F;
            double sensitivityMod = ss * ss * ss;
            double sens = sensitivityMod * 8.0;
            // The smooth camera key is not bound here, so its branch never runs.
            double scale = _renderer.View.FirstPerson && _client.Player.IsScoping ? sensitivityMod : sens;
            _client.Player.Turn(d.X * scale, d.Y * scale);
        }
        _lastMouse = position;
    }

    public PlayerInput Movement() {
        if (_keyboard == null || !MouseCaptured || _screens.Current != null) {
            return PlayerInput.None;
        }
        return new PlayerInput(
            Forward: _keyboard.IsKeyPressed(Key.W),
            Backward: _keyboard.IsKeyPressed(Key.S),
            Left: _keyboard.IsKeyPressed(Key.A),
            Right: _keyboard.IsKeyPressed(Key.D),
            Jump: _keyboard.IsKeyPressed(Key.Space),
            Shift: _keyboard.IsKeyPressed(Key.ShiftLeft),
            Sprint: _keyboard.IsKeyPressed(Key.ControlLeft));
    }

    /// <summary>The buttons as they are now, then the tick's interactions, which take the presses since the last tick.</summary>
    /// <param name="scriptedUse">The use button is held by <c>--hold use</c>.</param>
    public void TickInteractions(bool scriptedUse = false) {
        KeyMappings keys = _client.Interactions.Keys;
        if (_client.Player == null) {
            keys.ReleaseAll();
            _perspectiveClicks = _toggleGuiClicks = _chatClicks = _commandClicks = _inventoryClicks = 0;
            return;
        }
        // KeyMapping.setAll: the game reads the buttons only while it has the mouse.
        bool grabbed = MouseCaptured && _screens.Current == null && _mouse != null;
        keys.Attack.SetDown(grabbed && _mouse!.IsButtonPressed(MouseButton.Left));
        keys.Use.SetDown(scriptedUse || grabbed && _mouse!.IsButtonPressed(MouseButton.Right));
        keys.PickItem.SetDown(grabbed && _mouse!.IsButtonPressed(MouseButton.Middle));
        keys.SpectatorHotbar.SetDown(keys.PickItem.IsDown);
        keys.ControlDown = Control;
        _client.Interactions.Tick(HostKeybinds);
    }

    /// <summary>The window's part of <c>Minecraft.handleKeybinds</c>, ahead of the hotbar keys.</summary>
    private void HostKeybinds() {
        for (; _perspectiveClicks > 0; _perspectiveClicks--) {
            _renderer.View.CycleMode();
        }
        for (; _toggleGuiClicks > 0; _toggleGuiClicks--) {
            _renderer.HideGui = !_renderer.HideGui;
        }
        for (; _chatClicks > 0; _chatClicks--) {
            _screens.OpenChat();
        }
        if (_commandClicks > 0 && _screens.Current == null) {
            _commandClicks--;
            _screens.OpenChat("/");
        }
        for (; _inventoryClicks > 0; _inventoryClicks--) {
            _screens.OpenInventory(_client.Player!);
        }
    }

    private void OnKeyDown(IKeyboard keyboard, Key key, int scancode) {
        if (key == Key.F3 && _screens.Current is not ChatScreen) {
            _debug.Visible = !_debug.Visible;
            return;
        }
        if (_screens.Current is { } screen) {
            screen.KeyDown(_screens.Context, key, Control);
            _screens.CloseIfClosed();
            return;
        }
        if (key == Key.Escape) {
            // There is no title screen to disconnect to, so leaving the game closes the window.
            _screens.Set(new PauseScreen(_quit));
            return;
        }
        if (!MouseCaptured) {
            CaptureMouse(true);
        }

        KeyMappings keys = _client.Interactions.Keys;
        switch (key) {
            case Key.E: _inventoryClicks++; break;
            case Key.T: _chatClicks++; break;
            case Key.Slash: _commandClicks++; break;
            case Key.F1: _toggleGuiClicks++; break;
            case Key.F5: _perspectiveClicks++; break;
            case Key.F7: _renderer.LoadPipeline(); break;
            case Key.Q: keys.Drop.Press(); break;
            case Key.F: keys.SwapOffhand.Press(); break;
            case >= Key.Number1 and <= Key.Number9: keys.Hotbar[key - Key.Number1].Press(); break;
        }
    }

    /// <summary><c>Inventory.setSelectedSlot</c>: the server hears of it from the next tick's <c>ensureHasSentCarriedItem</c>.</summary>
    private void SelectSlot(int slot) {
        if (_client.Player != null) {
            _client.Inventory.SelectedSlot = slot;
        }
    }

    // The key that opens a text field produces its character in the same poll, before the tick opens the screen.
    private void OnChar(IKeyboard keyboard, char c) => _screens.Current?.Char(_screens.Context, c);

    private void OnMouseDown(IMouse mouse, MouseButton button) {
        if (_screens.Current is { } screen) {
            (float x, float y) = MouseInGui();
            screen.MouseDown(_screens.Context, x, y, button);
            _screens.CloseIfClosed();
            return;
        }
        if (!MouseCaptured) {
            CaptureMouse(true);
            return;
        }
        KeyMappings keys = _client.Interactions.Keys;
        switch (button) {
            case MouseButton.Left: keys.Attack.Press(); break;
            case MouseButton.Right: keys.Use.Press(); break;
            case MouseButton.Middle:
                keys.PickItem.Press();
                keys.SpectatorHotbar.Press();
                break;
        }
    }

    private void OnMouseUp(IMouse mouse, MouseButton button) {
        KeyMappings keys = _client.Interactions.Keys;
        switch (button) {
            case MouseButton.Left: keys.Attack.SetDown(false); break;
            case MouseButton.Right: keys.Use.SetDown(false); break;
            case MouseButton.Middle:
                keys.PickItem.SetDown(false);
                keys.SpectatorHotbar.SetDown(false);
                break;
        }
        (float x, float y) = MouseInGui();
        _screens.Current?.MouseUp(_screens.Context, x, y, button);
        _screens.CloseIfClosed();
    }

    private void OnMouseMove(IMouse mouse, Vector2 position) {
        (float x, float y) = MouseInGui();
        _screens.Current?.MouseMove(_screens.Context, x, y);
    }

    /// <summary><c>MouseHandler.onScroll</c> through <c>ScrollWheelHandler</c>, at the default sensitivity and smooth scrolling.</summary>
    private void OnScroll(IMouse mouse, ScrollWheel wheel) {
        if (_screens.Current is { } screen) {
            screen.Scroll(_screens.Context, wheel.Y);
            return;
        }
        if (_client.Player is not { } player) {
            return;
        }
        if (_scrollX != 0.0 && Math.Sign(wheel.X) != Math.Sign(_scrollX)) {
            _scrollX = 0.0;
        }
        if (_scrollY != 0.0 && Math.Sign(wheel.Y) != Math.Sign(_scrollY)) {
            _scrollY = 0.0;
        }
        _scrollX += wheel.X;
        _scrollY += wheel.Y;
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
        SelectSlot(((_client.Inventory.SelectedSlot - Math.Sign(step)) % 9 + 9) % 9);
    }
}
