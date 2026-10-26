namespace Minecraft.Schemas.Blocks.BlockEnums;

/// <summary>
/// <c>vertical_direction</c>, which way a speleothem's tip points. Upstream this is an ordinary
/// <c>Direction</c> property narrowed to two values rather than an enum of its own, so the name here
/// is ours; the wire values are vanilla's.
/// </summary>
public enum VerticalDirection {
    Up,
    Down
}

public static class VerticalDirectionExtensions {
    public static VerticalDirection FromString(string value) {
        return value switch {
            "up" => VerticalDirection.Up,
            "down" => VerticalDirection.Down,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for VerticalDirection.")
        };
    }
    
    public static string ToName(this VerticalDirection verticalDirection) {
        return verticalDirection switch {
            VerticalDirection.Up => "up",
            VerticalDirection.Down => "down",
            _ => throw new ArgumentOutOfRangeException(nameof(verticalDirection), verticalDirection, "Unknown VerticalDirection value.")
        };
    }
}
