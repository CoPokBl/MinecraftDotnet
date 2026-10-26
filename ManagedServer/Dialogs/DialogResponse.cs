using System.Globalization;
using ManagedServer.Entities.Types;
using Minecraft.Data.Dialogs;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ManagedServer.Dialogs;

/// <summary>
/// What the player sent back when they pressed a dialog button: the values of every input on the
/// dialog, keyed by the names they were given.
/// </summary>
public class DialogResponse {
    public required Player Player { get; init; }

    /// <summary>The id of the custom action the pressed button carried.</summary>
    public required Identifier ActionId { get; init; }

    /// <summary>
    /// The dialog the press came from, or null when it came from something we didn't show, such as
    /// a registry dialog or a <c>custom</c> click event in a chat message.
    /// </summary>
    public ManagedDialog? Dialog { get; init; }

    /// <summary>Which of <see cref="Dialog"/>'s buttons was pressed, or -1 when there's no dialog.</summary>
    public int ButtonIndex { get; init; } = -1;

    /// <summary>The raw payload, which is a compound of the inputs unless the client sent nothing.</summary>
    public CompoundTag? Payload { get; init; }

    public string? this[string key] => GetString(key);

    public bool Contains(string key) {
        return Payload?.Contains(key) ?? false;
    }

    /// <summary>
    /// The value of an input, or null when the dialog had no input by that name. Every input is sent
    /// as text, whatever kind of control collected it.
    /// </summary>
    public string? GetString(string key) {
        INbtTag? tag = Payload?[key];

        return tag switch {
            null => null,
            StringTag text => text.Value,
            // Only reachable for values we put in the action's additions ourselves
            _ => tag.ToJson().ToString()
        };
    }

    public string GetString(string key, string fallback) {
        return GetString(key) ?? fallback;
    }

    /// <summary>The value of a boolean input, compared against the strings it was set to send.</summary>
    public bool GetBool(string key, bool fallback = false) {
        string? value = GetString(key);
        if (value == null) {
            return fallback;
        }

        // The control sends its on_true/on_false strings rather than a boolean, and those don't
        // have to be "true" and "false"
        if (ControlFor(key) is InputControl.Boolean control) {
            return value == control.OnTrue;
        }

        return bool.TryParse(value, out bool parsed) ? parsed : fallback;
    }

    public float GetFloat(string key, float fallback = 0f) {
        return float.TryParse(GetString(key), NumberStyles.Float, CultureInfo.InvariantCulture, out float value)
            ? value
            : fallback;
    }

    /// <summary>
    /// The value of a number range input as a whole number. Ranges are sent as decimals even when
    /// their step is 1, so the value is rounded rather than parsed as an integer.
    /// </summary>
    public int GetInt(string key, int fallback = 0) {
        return float.TryParse(GetString(key), NumberStyles.Float, CultureInfo.InvariantCulture, out float value)
            ? (int)MathF.Round(value)
            : fallback;
    }

    private InputControl? ControlFor(string key) {
        return Dialog?.Inputs.FirstOrDefault(i => i.Key == key)?.Control;
    }
}
