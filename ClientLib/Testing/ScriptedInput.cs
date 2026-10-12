using ClientLib.Player;

namespace ClientLib.Testing;

/// <summary>
/// A queue of held inputs, looks and one-off actions, pumped once per tick in place of a keyboard.
/// Lets a headless client walk a fixed route, which is what checking movement against a real server
/// needs.
/// </summary>
public sealed class ScriptedInput {
    private readonly Queue<Step> _steps = new();
    private Step? _current;
    private int _remaining;

    public string? CurrentLabel => _current?.Label;
    public bool Finished => _current == null && _steps.Count == 0;

    /// <summary>Holds <paramref name="input"/> for <paramref name="ticks"/> ticks, optionally facing a fixed direction.</summary>
    public ScriptedInput Hold(string label, PlayerInput input, int ticks, float? yRot = null, float? xRot = null) {
        _steps.Enqueue(new Step(label, input, ticks, yRot, xRot, null, null));
        return this;
    }

    public ScriptedInput Idle(string label, int ticks) => Hold(label, PlayerInput.None, ticks);

    /// <summary>Runs <paramref name="action"/> once, with no keys held that tick.</summary>
    public ScriptedInput Do(string label, Action action) {
        _steps.Enqueue(new Step(label, PlayerInput.None, 1, null, null, action, null));
        return this;
    }

    /// <summary>Holds nothing until <paramref name="condition"/> holds or <paramref name="timeoutTicks"/> pass.</summary>
    public ScriptedInput WaitUntil(string label, Func<bool> condition, int timeoutTicks) {
        _steps.Enqueue(new Step(label, PlayerInput.None, timeoutTicks, null, null, null, condition));
        return this;
    }

    /// <summary>Call before every tick: sets the player's keys and look for the step in progress.</summary>
    public void Apply(LocalPlayer player) {
        while (true) {
            if (_current == null || _remaining <= 0 || _current.Until?.Invoke() == true) {
                if (!_steps.TryDequeue(out Step? next)) {
                    _current = null;
                    player.Input = PlayerInput.None;
                    return;
                }
                _current = next;
                _remaining = next.Ticks;
                next.Action?.Invoke();
                if (next.Until?.Invoke() == true) {
                    continue;
                }
            }
            break;
        }

        _remaining--;
        player.Input = _current.Input;
        if (_current.YRot is { } yRot) {
            player.YRot = yRot;
        }
        if (_current.XRot is { } xRot) {
            player.XRot = xRot;
        }
    }

    private sealed record Step(string Label, PlayerInput Input, int Ticks, float? YRot, float? XRot, Action? Action, Func<bool>? Until);
}
