using System.Diagnostics;
using ClientLib;
using ClientLib.Player;
using Minecraft.Packets.Play.ServerBound;
using GraphicalClient.Gui.Inventory;

namespace GraphicalClient;

/// <summary>The launch flags that drive the client by themselves, for scripted tests, screenshots and measuring.</summary>
public sealed class LaunchScript(LaunchOptions options, MinecraftClient client, Stopwatch clock) {
    private double _joinedAt = -1;
    private bool _screenshotTaken, _used, _inventoryHeld, _useHeld;
    private int _commandIndex, _pressIndex, _typeIndex, _clickIndex;

    /// <summary><c>--run</c>: the next line on every 20th client tick once loaded in.</summary>
    public void SendCommands() {
        if (client.ClientLoaded && _commandIndex < options.Commands.Count && client.ClientTicks % 20 == 0) {
            client.SendChat(options.Commands[_commandIndex++]);
        }
    }

    public void Spin(double delta) {
        if (options.Spin != 0 && client.Player is { } player && client.ClientLoaded) {
            // Turn takes mouse units, which it scales by 0.15 into degrees.
            player.Turn(options.Spin * delta / 0.15, 0);
        }
    }

    /// <summary>Notes the first frame the player is loaded in, which every delay counts from, and opens what was asked for then.</summary>
    public void CheckJoined(double now, ScreenManager screens) {
        if (_joinedAt >= 0) {
            DriveScreen(now - _joinedAt, screens);
            return;
        }
        if (!client.ClientLoaded) {
            return;
        }
        _joinedAt = now;
        if (options.OpenInventory) {
            screens.Set(ContainerScreens.PlayerInventory(client));
        }
        if (options.OpenChat != null) {
            // Typed rather than given as the initial text: vanilla only lists suggestions after an edit.
            screens.OpenChat();
            foreach (char c in options.OpenChat) {
                screens.Current!.Char(screens.Context, c);
            }
        }
    }

    /// <summary><c>--type</c> and <c>--click</c>, each once its time comes, on whatever screen is open then.</summary>
    private void DriveScreen(double sinceJoin, ScreenManager screens) {
        while (_typeIndex < options.Types.Count && sinceJoin >= options.Types[_typeIndex].At) {
            foreach (char c in options.Types[_typeIndex++].Text) {
                if (c == '\n') {
                    screens.Current?.KeyDown(screens.Context, Silk.NET.Input.Key.Enter, false);
                }
                else {
                    screens.Current?.Char(screens.Context, c);
                }
            }
        }
        while (_clickIndex < options.Clicks.Count && sinceJoin >= options.Clicks[_clickIndex].At) {
            (_, float x, float y) = options.Clicks[_clickIndex++];
            screens.Current?.MouseMove(screens.Context, x, y);
            screens.Current?.MouseDown(screens.Context, x, y, Silk.NET.Input.MouseButton.Left);
            screens.Current?.MouseUp(screens.Context, x, y, Silk.NET.Input.MouseButton.Left);
            screens.CloseIfClosed();
        }
    }

    /// <summary>The keys <c>--hold</c> holds at this moment, or null while it is not driving the player.</summary>
    public PlayerInput? HeldKeys(ScreenManager screens) {
        if (options.Holds.Count == 0 || _joinedAt < 0) {
            return null;
        }
        double sinceJoin = clock.Elapsed.TotalSeconds - _joinedAt;
        HashSet<string> held = [];
        foreach ((string[] keys, double from, double to) in options.Holds) {
            if (sinceJoin >= from && sinceJoin < to) {
                held.UnionWith(keys);
            }
        }
        // e is the inventory key, pressed once as the window starts rather than held.
        bool inventory = held.Contains("e");
        if (inventory && !_inventoryHeld && screens.Current == null && client.Player is { } player) {
            screens.OpenInventory(player);
        }
        _inventoryHeld = inventory;
        return new PlayerInput(held.Contains("w"), held.Contains("s"), held.Contains("a"), held.Contains("d"),
            held.Contains("space"), held.Contains("shift"), held.Contains("ctrl"));
    }

    /// <summary>Whether <c>--hold use</c> holds the use button this tick; the tick it starts is a click as well.</summary>
    public bool HoldsUse(GameInput input) {
        bool held = false;
        if (_joinedAt >= 0) {
            double sinceJoin = clock.Elapsed.TotalSeconds - _joinedAt;
            held = options.Holds.Any(h => h.Keys.Contains("use") && sinceJoin >= h.From && sinceJoin < h.To);
        }
        if (held && !_useHeld) {
            input.QueueUse();
        }
        _useHeld = held;
        return held;
    }

    /// <summary><c>--use-after</c>, <c>--press</c>, <c>--screenshot</c> and <c>--exit-after</c>, checked once the frame is drawn.</summary>
    /// <param name="screenshot">Where to save this frame, when it is the one to save.</param>
    public void AfterFrame(double now, GameInput input, out string? screenshot, out bool exit) {
        bool joined = _joinedAt >= 0;
        if (options.UseAfter is { } useAfter && !_used && joined && now - _joinedAt >= useAfter) {
            input.QueueUse();
            _used = true;
        }
        while (joined && _pressIndex < options.Presses.Count && now - _joinedAt >= options.Presses[_pressIndex].At) {
            input.Press(options.Presses[_pressIndex++].Key);
        }
        screenshot = null;
        if (options.Screenshot != null && !_screenshotTaken && joined && now - _joinedAt >= options.ScreenshotAfter) {
            screenshot = options.Screenshot;
            _screenshotTaken = true;
        }
        exit = options.ExitAfter is { } exitAfter && now >= exitAfter;
    }

    /// <summary><c>--log-sent</c>.</summary>
    public static void LogSent(MinecraftClient client, Minecraft.Packets.MinecraftPacket packet) {
        string? what = packet switch {
            ServerBoundPlayerCommandPacket command => command.PlayAction.ToString(),
            ServerBoundSetHeldItemPacket held => $"set held slot {held.Slot}",
            ServerBoundAttackPacket attack => $"attack {attack.EntityId}",
            ServerBoundPlayerActionPacket action => $"{action.ActionStatus} sequence {action.Sequence}",
            ServerBoundUseItemOnPacket use => $"use item on sequence {use.Sequence}",
            ServerBoundSetPlayerPositionPacket move => $"move {move.Position.X:F4} {move.Position.Y:F4} {move.Position.Z:F4} {move.Flags}",
            ServerBoundSetPlayerPosAndRotPacket move => $"move {move.Position.X:F4} {move.Position.Y:F4} {move.Position.Z:F4} {move.Flags}",
            _ => null
        };
        if (what != null) {
            Console.WriteLine($"Sent at tick {client.ClientTicks}: {what}");
        }
    }
}
