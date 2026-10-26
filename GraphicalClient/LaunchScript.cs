using System.Diagnostics;
using ClientLib;
using ClientLib.Player;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas.Items;
using GraphicalClient.Gui.Inventory;

namespace GraphicalClient;

/// <summary>The launch flags that drive the client by themselves, for scripted tests, screenshots and measuring.</summary>
public sealed class LaunchScript(LaunchOptions options, MinecraftClient client, Stopwatch clock) {
    // A client started on the title screen counts every delay from launch, so a script can work the menus.
    private double _joinedAt = options.ServerGiven && !options.Title ? -1 : 0;
    private bool _loadedIn, _screenshotTaken, _used, _inventoryHeld, _useHeld, _attackHeld;
    private int _commandIndex, _pressIndex, _typeIndex, _clickIndex, _scrollIndex;
    private const int HotbarSize = 9;
    private readonly string?[] _hotbar = new string?[HotbarSize + 1];

    /// <summary>Follows the connection a join makes; the script's progress carries over.</summary>
    public void Attach(MinecraftClient joined) => client = joined;

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
        if (_loadedIn || !client.ClientLoaded) {
            if (_joinedAt >= 0) {
                DriveScreen(now - _joinedAt, screens);
            }
            return;
        }
        _loadedIn = true;
        if (_joinedAt < 0) {
            _joinedAt = now;
        }
        if (options.OpenInventory) {
            screens.Set(ContainerScreens.PlayerInventory(client));
        }
        if (options.OpenChat != null) {
            // Typed rather than given as the initial text: vanilla only lists suggestions after an edit.
            screens.OpenChat(Gui.ChatComponent.ChatMethod.Message);
            foreach (char c in options.OpenChat) {
                screens.Current!.Char(screens.Context, c);
            }
        }
    }

    /// <summary><c>--type</c>, <c>--click</c> and <c>--scroll</c>, each once its time comes, on whatever screen is open then.</summary>
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
            (_, float x, float y, bool right) = options.Clicks[_clickIndex++];
            Silk.NET.Input.MouseButton button = right ? Silk.NET.Input.MouseButton.Right : Silk.NET.Input.MouseButton.Left;
            screens.Current?.MouseMove(screens.Context, x, y);
            screens.Current?.MouseDown(screens.Context, x, y, button);
            screens.Current?.MouseUp(screens.Context, x, y, button);
            screens.CloseIfClosed();
        }
        while (_scrollIndex < options.Scrolls.Count && sinceJoin >= options.Scrolls[_scrollIndex].At) {
            screens.Current?.Scroll(screens.Context, options.Scrolls[_scrollIndex++].Delta);
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

    /// <summary>Whether <c>--hold attack</c> holds the attack button this tick; the tick it starts is a click as well.</summary>
    public bool HoldsAttack(GameInput input) {
        bool held = false;
        if (_joinedAt >= 0) {
            double sinceJoin = clock.Elapsed.TotalSeconds - _joinedAt;
            held = options.Holds.Any(h => h.Keys.Contains("attack") && sinceJoin >= h.From && sinceJoin < h.To);
        }
        if (held && !_attackHeld) {
            input.Press("attack");
        }
        _attackHeld = held;
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
            ServerBoundClientStatusPacket command => $"client command {command.Action}",
            ServerBoundSetPlayerPositionPacket move => $"move {move.Position.X:F4} {move.Position.Y:F4} {move.Position.Z:F4} {move.Flags}",
            ServerBoundSetPlayerPosAndRotPacket move => $"move {move.Position.X:F4} {move.Position.Y:F4} {move.Position.Z:F4} {move.Flags}",
            ServerBoundChangeRecipeBookSettingsPacket book => $"recipe book {book.BookType} open {book.Open} filtering {book.Filtering}",
            ServerBoundPlaceRecipePacket place => $"place recipe {place.RecipeId} in window {place.WindowId} max {place.UseMaxItems}",
            ServerBoundSetSeenRecipePacket seen => $"seen recipe {seen.RecipeId}",
            ServerBoundSeenAdvancementsPacket seen => $"seen advancements {seen.Action} {seen.Tab}",
            ServerBoundClickContainerPacket click => $"click window {click.WindowId} slot {click.Slot} button {click.Button} mode {click.Mode}",
            ServerBoundCloseContainerPacket close => $"close window {close.WindowId}",
            _ => null
        };
        if (what != null) {
            Console.WriteLine($"Sent at tick {client.ClientTicks}: {what}");
        }
    }

    /// <summary>
    /// <c>--log-inventory</c>, once a tick: each hotbar slot, and the selected one, that changed since the last
    /// tick, whether the server or the client changed it.
    /// </summary>
    public void WatchHotbar() {
        if (!options.LogInventory || client.Player == null) {
            return;
        }
        PlayerInventory inventory = client.Inventory;
        for (int i = 0; i <= HotbarSize; i++) {
            string now = i < HotbarSize ? Describe(inventory.Hotbar(i)) : "selected " + inventory.SelectedSlot;
            if (now != _hotbar[i]) {
                _hotbar[i] = now;
                Console.WriteLine($"Tick {client.ClientTicks}: hotbar {(i < HotbarSize ? $"slot {i} is {now}" : $"{now}")}");
            }
        }
    }

    /// <summary><c>--log-inventory</c>: the inventory packets as they arrive, before the client handles them.</summary>
    public static void LogInventory(MinecraftClient client, Minecraft.Packets.MinecraftPacket packet) {
        string? what = packet switch {
            ClientBoundSetContainerContentPacket content => $"window {content.WindowId} state {content.StateId} contents "
                + string.Join(", ", content.SlotData.Select((stack, slot) => (stack, slot)).Where(s => !s.stack.IsAir()).Select(s => $"{s.slot} = {Describe(s.stack)}"))
                + $"; cursor {Describe(content.CursorItem)}",
            ClientBoundSetContainerSlotPacket slot => $"window {slot.WindowId} state {slot.StateId} slot {slot.SlotId} = {Describe(slot.Data)}",
            ClientBoundSetPlayerInventorySlotPacket slot => $"inventory slot {slot.Slot} = {Describe(slot.Contents)}",
            ClientBoundSetCursorItemPacket cursor => $"cursor = {Describe(cursor.Item)}",
            ClientBoundSetHeldItemPacket held => $"select hotbar slot {held.Slot}",
            _ => null
        };
        if (what != null) {
            Console.WriteLine($"Received at tick {client.ClientTicks}: {what}");
        }
    }

    private static string Describe(ItemStack stack) {
        if (stack.IsAir()) {
            return stack.Type.Identifier == Minecraft.Data.Generated.Item.Air.Identifier ? "empty" : $"empty ({stack.Count} {stack.Type.Identifier})";
        }
        IEnumerable<string> components = stack.Components.Select(c => $"{c.Key.Identifier}={Format(c.Value)}")
            .Concat(stack.RemoveComponents.Select(c => "!" + c.Identifier));
        return $"{stack.Count} {stack.Type.Identifier} [{string.Join(", ", components)}]";
    }

    /// <summary>A component's value for the log: collections and tuples spelled out, registry entries by their id.</summary>
    private static string Format(object? value) => value switch {
        null => "null",
        string text => text,
        Minecraft.Data.Components.IDataComponent component => component.Identifier.ToString(),
        System.Runtime.CompilerServices.ITuple tuple => "(" + string.Join(", ", Enumerable.Range(0, tuple.Length).Select(i => Format(tuple[i]))) + ")",
        System.Collections.IEnumerable items => "[" + string.Join(", ", items.Cast<object?>().Select(Format)) + "]",
        _ when value.GetType().GetProperty("Identifier")?.GetValue(value) is Minecraft.Schemas.Identifier id => id.ToString(),
        _ => value.ToString() ?? ""
    };
}
